using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using ProjetMVC.Enums;
using ProjetMVC.Models;
using ProjetMVC.ViewModels;
using SendGrid.Helpers.Mail;
using System.Globalization;
using System.Security.Claims;

namespace ProjetMVC.Services
{
    public class BorneService : IBorneService
    {
        private readonly MyDbContext _context;
        private readonly GeocodingService _geocodageService;
        private readonly UserManager<Utilisateur> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BorneService(MyDbContext context, GeocodingService geocodageService, UserManager<Utilisateur> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _geocodageService = geocodageService;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Borne> AddBorneAsync(BorneCreateVM model, Utilisateur user)
        {
            var adresseComplete = $"{model.Adresse.NoCivique} {model.Adresse.Rue} {model.Adresse.Ville} {ProvinceHelper.GetProvinceName(model.Adresse.Province)}";
            GeoCoordinates coordonnees = await _geocodageService.ValidateAndGeocodeAddressAsync(adresseComplete);

            var borne = new Borne
            {
                TypeConnecteur = model.TypeConnecteur,
                PuissanceKW = model.PuissanceKW,
                DateCreation = DateTime.Now,
                Adresse = new Adresse
                {
                    NoCivique = model.Adresse.NoCivique,
                    Rue = model.Adresse.Rue,
                    Ville = model.Adresse.Ville,
                    CodePostal = model.Adresse.CodePostal,
                    Province = model.Adresse.Province,
                    Latitude = coordonnees.Latitude,
                    Longitude = coordonnees.Longitude
                },

            };

            _context.Borne.Add(borne);
            await _context.SaveChangesAsync();

            return borne;
        }

        public async Task<List<Borne>> GetBornesByTypeConnecteurAsync(TypeConnecteur typeConnecteur)
        {
            return await _context.Borne
                 .Include(b => b.Adresse)
                 .Where(b => b.TypeConnecteur == typeConnecteur)
                 .ToListAsync();
        }

        public async Task<List<Borne>> GetBornesByPuissanceAsync(int puissanceMinimale)
        {
            return await _context.Borne
                .Where(b => b.PuissanceKW >= puissanceMinimale)
                .ToListAsync();
        }

        public async Task<List<Borne>> GetBornesByAdresseAsync(string adresse, string noCivique)
        {
            return await _context.Borne
                .Where(b => b.Adresse.CodePostal == adresse && b.Adresse.NoCivique == noCivique)
                .ToListAsync();
        }

        //public async Task<List<Borne>> GetAllBornesAsync()
        //{
        //    return await _context.Borne
        //        .Include(b => b.Adresse)
        //        .ToListAsync();
        //}

        public async Task<List<Borne>> GetAllBornesAsync()
        {
            // Obtenir la liste des bornes avec leurs adresses
            var bornes = await _context.Borne
                .Include(b => b.Adresse) // Inclure l'adresse
                .Select(b => new
                {
                    Borne = b,
                    MoyenneNote = _context.BorneUtilisateurs
                        .Where(bu => bu.BorneId == b.BorneId)
                        .Average(bu => (double?)bu.Note) // Calculer la moyenne des notes (peut être null)
                })
                .ToListAsync();

            // Transformer en liste de bornes avec la MoyenneNote
            return bornes.Select(b => {
                b.Borne.MoyenneNote = b.MoyenneNote; // Assigner la moyenne des notes à la borne
                return b.Borne;
            }).ToList();
        }


        public async Task<bool> AdresseExistsAsync(Adresse adresse)
        {
            return await _context.Borne.AnyAsync(b => b.Adresse.NoCivique == adresse.NoCivique &&
                                                      b.Adresse.Rue == adresse.Rue &&
                                                      b.Adresse.Ville == adresse.Ville &&
                                                      b.Adresse.CodePostal == adresse.CodePostal &&
                                                      b.Adresse.Province == adresse.Province);
        }

        public async Task<List<BorneRechercheVM>> RechercherBornesAsync(BorneRechercheVM model)
        {
            var utilisateurCourant = await ObtenirUtilisateurCourantAsync();
            var borneCompatible = _context.Borne
                                   .Include(b => b.Adresse)
                                   .Include(b => b.BorneUtilisateurs)
                                   .AsQueryable();

            // Filtrer par note minimale si spécifiée
            if (model.NoteMinimale.HasValue)
            {
                borneCompatible = borneCompatible
                    .Where(b => b.BorneUtilisateurs.Any() &&
                                b.BorneUtilisateurs.Average(bu => bu.Note) >= model.NoteMinimale.Value)
                    .OrderByDescending(b => b.BorneUtilisateurs.Any(bu => bu.UtilisateurId == utilisateurCourant.Id && bu.EstFavoris)) // Tri par favoris
                    .ThenByDescending(b => b.BorneUtilisateurs.Average(bu => bu.Note)) // Tri par note moyenne
                    .ThenByDescending(b => b.PuissanceKW); // Tri par puissance de connecteur
            }

            // Filtrer par type de connecteur si spécifié
            if (model.TypeConnecteur.HasValue)
            {
                borneCompatible = borneCompatible.Where(b => b.TypeConnecteur == model.TypeConnecteur.Value)
                                                 .OrderByDescending(b => b.PuissanceKW);
            }

            // Filtrer par puissance minimale si spécifié
            if (model.PuissanceMinimale.HasValue)
            {
                borneCompatible = borneCompatible.Where(b => b.PuissanceKW >= model.PuissanceMinimale.Value)
                                                 .OrderByDescending(b => b.PuissanceKW)
                                                 .ThenByDescending(b => b.BorneUtilisateurs.Average(bu => bu.Note));
            }

            // Filtrer uniquement dans les favoris si spécifié
            if (model.RechercheDansFavorisSeulement)
            {
                borneCompatible = borneCompatible.Where(b => b.BorneUtilisateurs.Any(e => e.UtilisateurId == utilisateurCourant.Id && e.EstFavoris));
            }

            


            var borneCompatibleList = await borneCompatible.ToListAsync();
            var viewModelList = new List<BorneRechercheVM>();

            // Filtrer par adresse si tous les champs d'adresse sont fournis
            bool adresseComplete = model.Adresse != null &&
                                   !string.IsNullOrEmpty(model.Adresse.NoCivique) &&
                                   !string.IsNullOrEmpty(model.Adresse.Rue) &&
                                   !string.IsNullOrEmpty(model.Adresse.Ville) &&
                                   model.Adresse.Province != 0 &&
                                   !string.IsNullOrEmpty(model.Adresse.CodePostal);

            // Calcul de la distance si l’adresse est complète
            if (adresseComplete)
            {

                var nomProvince = Enum.GetName(typeof(ProvincesCanadiennes), model.Adresse.Province);
                var adresseCompleteStr = $"{model.Adresse.NoCivique} {model.Adresse.Rue}, {model.Adresse.Ville}, {nomProvince}";
                var coordoonees = await _geocodageService.ValidateAndGeocodeAddressAsync(adresseCompleteStr);

                if (coordoonees == null)
                {
                    return new List<BorneRechercheVM>();
                }

                foreach (var borne in borneCompatibleList)
                {
                    double distance = double.MaxValue;
                    if (borne.Adresse.Latitude.HasValue && borne.Adresse.Longitude.HasValue)
                    {
                        distance = CalculateDistance(coordoonees.Latitude, coordoonees.Longitude, borne.Adresse.Latitude.Value, borne.Adresse.Longitude.Value);
                    }

                    var noteMoyenne = borne.BorneUtilisateurs.Any() ? borne.BorneUtilisateurs.Average(bu => bu.Note) : (double?)null;
                    var isFavoris = borne.BorneUtilisateurs.Any(bu => bu.UtilisateurId == utilisateurCourant.Id && bu.EstFavoris);
                    borne.MoyenneNote = noteMoyenne;

                    viewModelList.Add(new BorneRechercheVM
                    {
                        Borne = borne,
                        TypeConnecteur = borne.TypeConnecteur,
                        PuissanceMinimale = (int)borne.PuissanceKW,
                        Adresse = borne.Adresse,
                        AdresseComplete = $"{borne.Adresse.NoCivique} {borne.Adresse.Rue}, {borne.Adresse.Ville} {borne.Adresse.CodePostal}",
                        Distance = distance,
                        NoteMinimale = noteMoyenne,
                        RechercheDansFavorisSeulement = isFavoris
                    });
                }

                // Trier par distance
                viewModelList = viewModelList.OrderBy(vm => vm.Distance).ToList();
            } 
            else
            {
                viewModelList = borneCompatibleList.Select(borne =>
                {
                    var noteMoyenne = borne.BorneUtilisateurs.Any() ? borne.BorneUtilisateurs.Average(bu => bu.Note) : (double?)null;
                    var isFavoris = borne.BorneUtilisateurs.Any(bu => bu.EstFavoris);
                    borne.MoyenneNote = noteMoyenne;

                    return new BorneRechercheVM
                    {
                        Borne = borne,
                        TypeConnecteur = borne.TypeConnecteur,
                        PuissanceMinimale = (int)borne.PuissanceKW,
                        Adresse = borne.Adresse,
                        AdresseComplete = $"{borne.Adresse.NoCivique} {borne.Adresse.Rue}, {borne.Adresse.Ville} {borne.Adresse.CodePostal}",
                        Distance = double.MaxValue,
                        NoteMinimale = noteMoyenne,
                        RechercheDansFavorisSeulement = isFavoris
                    };
                }).ToList();
            }

            return viewModelList;
        }

        private static double CalculateDistance(double lat1, double lon1, double lat2, double lon2)
        {
            var R = 6371;
            var dLat = ToRadians(lat2 - lat1);
            var dLon = ToRadians(lon2 - lon1);
            var a =
                Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                Math.Cos(ToRadians(lat1)) * Math.Cos(ToRadians(lat2)) *
                Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return R * c;
        }

        private static double ToRadians(double angle)
        {
            return Math.PI * angle / 180.0;
        }

        public async Task<Borne> GetBorneByIdAsync(int id)
        {
            return await _context.Borne
                .Include(b => b.Adresse)
                .FirstOrDefaultAsync(b => b.BorneId == id);
        }

        public async Task<bool> ToggleFavoriteAsync(int borneId, string utilisateurId)
        {

            // Vérifier si la relation utilisateur-borne existe
            BorneUtilisateur borneUtilisateur = await _context.BorneUtilisateurs
                .SingleOrDefaultAsync(ub => ub.BorneId == borneId && ub.UtilisateurId == utilisateurId);

            if (borneUtilisateur == null)
            {
                borneUtilisateur = new BorneUtilisateur
                {
                    UtilisateurId = utilisateurId,
                    BorneId = borneId,
                    EstFavoris = true,
                    DateAjoutFavori = DateTime.Now
                };
                _context.BorneUtilisateurs.Add(borneUtilisateur);
                await _context.SaveChangesAsync();
                return borneUtilisateur.EstFavoris;
            }
            borneUtilisateur.EstFavoris = !borneUtilisateur.EstFavoris;
            if (borneUtilisateur.EstFavoris)
            {
                borneUtilisateur.DateAjoutFavori = DateTime.Now;
            }
            _context.BorneUtilisateurs.Update(borneUtilisateur);
            await _context.SaveChangesAsync();

            return borneUtilisateur.EstFavoris;
        }

        public async Task<bool> IsBorneFavoriAsync(int borneId, string utilisateurId)
        {
            return await _context.BorneUtilisateurs
                .AnyAsync(ub => ub.BorneId == borneId && ub.UtilisateurId == utilisateurId && ub.EstFavoris);
        }

        public async Task AddBorneUtilisateurAsync(int borneId, string utilisateurId)
        {
            var BorneUtilisateur = new BorneUtilisateur
            {
                BorneId = borneId,
                UtilisateurId = utilisateurId,
                EstFavoris = false,

            };

            _context.BorneUtilisateurs.Add(BorneUtilisateur);
            await _context.SaveChangesAsync();
        }

        public async Task<List<BorneUtilisateur>> GetFavorisByUserIdAsync(string utilisateurId)
        {
            var listBornes = await _context.BorneUtilisateurs
                .Where(ub => ub.UtilisateurId == utilisateurId && ub.EstFavoris)
                .Include(ub => ub.Borne)
                .ThenInclude(a => a.Adresse)
                .ToListAsync();

            return listBornes;
        }

        public async Task AddEvaluationAsync(BorneUtilisateur borneUtilisateur)
        {
            _context.BorneUtilisateurs.Add(borneUtilisateur);
            await _context.SaveChangesAsync();
        }

        public async Task<List<BorneUtilisateur>> GetEvaluationsByBorneIdAsync(int borneId)
        {
            return await _context.BorneUtilisateurs
                 .Include(e => e.Utilisateur)
                 .Where(e => e.BorneId == borneId && e.Note.HasValue)
                 .OrderByDescending(e => e.DateEvaluation)
                 .ToListAsync();
        }
        public async Task<List<BorneViewModel>> GetBornesForMapAsync()
        {
            var bornes = await GetAllBornesAsync();
            return bornes.Select(b => new BorneViewModel
            {
                BorneId = b.BorneId,
                TypeConnecteur = b.TypeConnecteur,
                PuissanceKW = b.PuissanceKW,
                Adresse = b.Adresse
            }).ToList();
        }

        public async Task<BorneUtilisateur> GetEvaluationByUserAndBorneIdAsync(string utilisateurId, int borneId)
        {
            return await _context.BorneUtilisateurs
                .Include(e => e.Borne)
                .Include(e => e.Utilisateur)
                .FirstOrDefaultAsync(e => e.UtilisateurId == utilisateurId && e.BorneId == borneId && e.Note.HasValue);
        }

        public async Task<bool> UserAddedBorneAsync(string utilisateurId, int borneId)
        {
            var borne = await _context.BorneUtilisateurs.FirstOrDefaultAsync(b => b.BorneId == borneId && b.UtilisateurId == utilisateurId);
            return borne != null;
        }

        #region Méthodes pour l’affichage des notes dans la recherche
        private async Task<Utilisateur> ObtenirUtilisateurCourantAsync()
        {
            var userId = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return await _context.Utilisateurs.FindAsync(userId);
        }

        public async Task<IEnumerable<Borne>> ObtenirBornesAvecMoyenneNoteAsync()
        {
            return await _context.Borne
                .Select(b => new Borne
                {
                    BorneId = b.BorneId,
                    TypeConnecteur = b.TypeConnecteur,
                    PuissanceKW = b.PuissanceKW,
                    Adresse = b.Adresse,
                    DateCreation = b.DateCreation,
                    MoyenneNote = _context.BorneUtilisateurs
                        .Where(bu => bu.BorneId == b.BorneId)
                        .Average(bu => bu.Note)
                })
                .ToListAsync();
        }
        #endregion

        public async Task<bool> AddDisponibiliteAsync(Disponibilite disponibilite)
        {
            var existingDisponibilites = await _context.Disponibilites
                .Where(d => d.BorneId == disponibilite.BorneId && d.UtilisateurId == disponibilite.UtilisateurId)
                .OrderBy(d => d.DateDebut)
                .ToListAsync();

            // Vérifier les contraintes
            foreach (var existing in existingDisponibilites)
            {
                if (existing.DateDebut < disponibilite.DateFin.AddMinutes(-30) && disponibilite.DateDebut < existing.DateFin.AddMinutes(30))
                {
                    return false; // Conflit de disponibilité
                }
            }

            _context.Disponibilites.Add(disponibilite);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Disponibilite>> GetDisponibilitesByBorneIdAsync(int borneId)
        {
            return await _context.Disponibilites
                .Where(d => d.BorneId == borneId && d.DateDebut >= DateTime.Now)
                .OrderBy(d => d.DateDebut)
                .ToListAsync();
        }

        public async Task<bool> RemoveDisponibiliteAsync(int disponibiliteId)
        {
            var disponibilite = await _context.Disponibilites.FindAsync(disponibiliteId);
            if (disponibilite == null) return false;

            // Vérifier qu'il reste au moins une disponibilité
            var remainingDisponibilites = await _context.Disponibilites
                .Where(d => d.BorneId == disponibilite.BorneId)
                .CountAsync();

            if (remainingDisponibilites <= 1) return false;

            _context.Disponibilites.Remove(disponibilite);
            await _context.SaveChangesAsync();
            return true;

        }
        public async Task<Disponibilite> GetDisponibiliteByIdAsync(int disponibiliteId)
        {
            return await _context.Disponibilites
                                 .Include(d => d.Borne)
                                 .Include(d => d.Utilisateur)
                                 .FirstOrDefaultAsync(d => d.DisponibiliteId == disponibiliteId);
        }

        // Method to update a Disponibilite
        public async Task<bool> UpdateDisponibiliteAsync(Disponibilite disponibilite)
        {
            _context.Disponibilites.Update(disponibilite);
            return await _context.SaveChangesAsync() > 0;
        }


        public async Task<BorneDisponibilitesViewModel> GetBorneDisponibilitesViewModelAsync(int borneId, string utilisateurId)
        {
            var disponibilites = await _context.Disponibilites
                .Where(d => d.BorneId == borneId && d.DateDebut >= DateTime.Now)
                .OrderBy(d => d.DateDebut)
                .ToListAsync();

            var borneUtilisateurs = await _context.BorneUtilisateurs
                .Where(bu => bu.BorneId == borneId)
                .ToListAsync();

            var utilisateurEstProprietaire = borneUtilisateurs
                .Any(bu => bu.BorneId == borneId && bu.UtilisateurId == utilisateurId);

            var viewModel = new BorneDisponibilitesViewModel
            {
                BorneId = borneId,
                Disponibilites = disponibilites,
                BorneUtilisateurs = borneUtilisateurs,
                UtilisateurEstProprietaire = utilisateurEstProprietaire // Set the value here
            };

            return viewModel;
        }

        public async Task<string> GetUserIdByBorneIdAsync(int borneId)
        {
            return await _context.BorneUtilisateurs
                .Where(bu => bu.BorneId == borneId)
                .Select(bu => bu.UtilisateurId)
                .FirstOrDefaultAsync();
        }




    }


}
