using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjetMVC.Enums;
using ProjetMVC.Models;
using ProjetMVC.Services;
using ProjetMVC.ViewModels;

namespace ProjetMVC.Controllers
{
    [Authorize]
    public class BornesController : Controller
    {
        private readonly IBorneService _borneService;
        private readonly IAdresseService _adresseService;
        private readonly UserManager<Utilisateur> _userManager;
        private readonly GeocodingService _geocodingService;
        private readonly IUtilisateurService _utilisateurService;


        public BornesController(IBorneService borneService,  IAdresseService adresseService, UserManager<Utilisateur> userManager, GeocodingService geocodageService, IUtilisateurService utilisateurService)
        {
            _borneService = borneService;
            _adresseService = adresseService;
            _userManager = userManager;
            _geocodingService = geocodageService;
            _utilisateurService = utilisateurService;
        }

        public IActionResult Add()
        {
            var model = new BorneCreateVM
            {
                Adresse = new Adresse()
            };
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Add(BorneCreateVM model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = await _userManager.GetUserAsync(User);
                    if (await _borneService.AdresseExistsAsync(model.Adresse))
                    {
                        TempData["ErrorMessage"] = "Une borne existe déjà à cette adresse.";
                        return View(model);
                    }

                    var borne = await _borneService.AddBorneAsync(model, user);
                    if (borne != null)
                    {
                        await _borneService.AddBorneUtilisateurAsync(borne.BorneId, user.Id);
                        TempData["AddBorneSuccessMessage"] = "Borne ajoutée avec succès.";
                        return RedirectToAction("Index");
                    }
                }
                catch
                {
                    TempData["ErrorMessage"] = "Adresse non trouvée ou invalide.";
                    return View(model);
                }
            }
            return View(model);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var bornes = await _borneService.GetAllBornesAsync();
            var borneViewModels = bornes.Select(borne => new BorneViewModel
            {
                BorneId = borne.BorneId,
                TypeConnecteur = borne.TypeConnecteur,
                PuissanceKW = borne.PuissanceKW,
                Adresse = borne.Adresse,
                DateCreation = borne.DateCreation ?? DateTime.MinValue,
                EstFavori = _borneService.IsBorneFavoriAsync(borne.BorneId, user.Id).Result,
                NoteMoyenne = borne.MoyenneNote

            }).OrderByDescending(b => b.DateCreation)
              .ToList();
            return View(borneViewModels);
        }

        // GET: Bornes/RechercherBorne
        public IActionResult RechercherBorne()
        {
            return View(new BorneRechercheVM());
        }

        [HttpPost]
        public async Task<IActionResult> ResultatsRecherche(BorneRechercheVM model)
        {
            bool adresseComplete = model.Adresse != null &&
                                   !string.IsNullOrEmpty(model.Adresse.NoCivique) &&
                                   !string.IsNullOrEmpty(model.Adresse.Rue) &&
                                   !string.IsNullOrEmpty(model.Adresse.Ville) &&
                                   model.Adresse.Province != 0 &&
                                   !string.IsNullOrEmpty(model.Adresse.CodePostal);

            if (adresseComplete)
            {
                if ((ProvincesCanadiennes)model.Adresse.Province != ProvincesCanadiennes.Québec)
                {
                    ViewData["Message"] = "Cette application ne prend actuellement en charge que les adresses situées dans la province de Québec. Veuillez entrer une adresse québécoise valide.";
                    return View(new List<BorneRechercheVM>());
                }
            }

            var viewModelList = await _borneService.RechercherBornesAsync(model);

            if (!viewModelList.Any())
            {
                ViewData["Message"] = adresseComplete
                    ? "L'adresse fournie n'existe pas ou n'a pas pu être trouvée. Veuillez vérifier les informations saisies et réessayer."
                    : "Aucune borne compatible trouvée.";
            }

            return View(viewModelList);
        }

        public async Task<IActionResult> Details(int id)
        {
            var borne = await _borneService.GetBorneByIdAsync(id);
            if (borne == null)
            {
                return NotFound();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Unauthorized();
            }

            var disponibilites = await _borneService.GetDisponibilitesByBorneIdAsync(id);
            var evaluations = await _borneService.GetEvaluationsByBorneIdAsync(id);
            var isFavori = await _borneService.IsBorneFavoriAsync(id, user.Id);

            var viewModel = new BorneDetailsViewModel
            {
                Borne = borne,
                Disponibilites = disponibilites,
                Evaluations = evaluations?.OrderByDescending(e => e.DateEvaluation).ToList(),
                EstFavori = isFavori
            };

            return View(viewModel);
        }





        [HttpPost("{id}/favorite")]
        public async Task<IActionResult> ToggleFavorite(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Unauthorized();
            }
            bool isFavori;
            try
            {
                isFavori = await _borneService.ToggleFavoriteAsync(id, user.Id);
                if (isFavori)
                {
                    TempData["successMessage"] = "La borne a été ajoutée aux favoris avec succès.";
                }
                else
                {
                    TempData["successMessage"] = "La borne a été retirée des favoris avec succès.";
                }
            }
            catch
            {
                TempData["errorMessage"] = "Erreur lors de l'ajout de la borne aux favoris.";
            }
            return RedirectToAction("Favorites");
        }

        public async Task<IActionResult> Favorites()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Unauthorized();
            }
            var bornesFavoris = await _borneService.GetFavorisByUserIdAsync(user.Id);
            var sortedBornesFavoris = bornesFavoris
            .Where(b => b.EstFavoris)
            .OrderByDescending(b => b.DateAjoutFavori)
            .ToList();
            return View(sortedBornesFavoris);
        }

        [HttpGet]
        public IActionResult CreateEvaluation(int borneId)
        {
            var model = new EvaluationCreateVM { BorneId = borneId };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddEvaluation(EvaluationCreateVM model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                if (user == null)
                {
                    return Unauthorized();
                }
                var borne = await _borneService.GetBorneByIdAsync(model.BorneId);
                if (borne == null)
                {
                    TempData["ErrorMessage"] = "La borne spécifiée n'existe pas.";
                    return RedirectToAction("Details", new { id = model.BorneId });
                }

                var userAddedBorne = await _borneService.UserAddedBorneAsync(user.Id, model.BorneId);
                var existingEvaluation = await _borneService.GetEvaluationByUserAndBorneIdAsync(user.Id, model.BorneId);
                if (existingEvaluation != null && existingEvaluation.Note.HasValue)
                {
                    TempData["ErrorMessage"] = "Vous avez déjà évalué cette borne.";
                    return RedirectToAction("Details", new { id = model.BorneId });
                }
                if (userAddedBorne)
                {
                    TempData["ErrorMessage"] = "Vous ne pouvez pas évaluer une borne que vous avez ajoutée.";
                    return RedirectToAction("Details", new { id = model.BorneId });
                }

                var borneUtilisateur = new BorneUtilisateur
                {
                    BorneId = model.BorneId,
                    UtilisateurId = user.Id,
                    Note = model.Note,
                    Commentaire = model.Commentaire,
                    DateEvaluation = DateTime.Now
                };
                await _borneService.AddEvaluationAsync(borneUtilisateur);

                TempData["SuccessMessage"] = "Votre évaluation a été soumise avec succès.";
                return RedirectToAction("Details", new { id = model.BorneId });
            }
            return View("CreateEvaluation", model);
        }

        // Action pour afficher la carte
        [AllowAnonymous]
        public async Task<IActionResult> Map()
        {
            var model = await _borneService.GetBornesForMapAsync();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Disponibilites(int borneId)
        {
            
            var borne = await _borneService.GetBorneByIdAsync(borneId);
            if (borne == null)
            {
                return NotFound();
            }

           
            var disponibilites = await _borneService.GetDisponibilitesByBorneIdAsync(borneId);

            //service pour aller chercher le userId selon le BorneId de la table BorneUtilisateurs

            //service qui va chercher le id du user qui est connecter

        

            // Fetch the userId associated with this BorneId
            var userBorneId = await _borneService.GetUserIdByBorneIdAsync(borneId);

            // Fetch the ID of the currently logged-in user
            var userConnecterId = await _utilisateurService.GetCurrentUserId();

            // Determine if the logged-in user is the owner of this borne
            var viewModel = new BorneDisponibilitesViewModel
            {
                BorneId = borne.BorneId,
                Disponibilites = disponibilites.OrderBy(d => d.DateDebut).ToList(),
                UtilisateurEstProprietaire = userConnecterId == userBorneId
            };

            return View(viewModel);
        }


        [HttpPost]
        public async Task<IActionResult> AjouterDisponibilite(int borneId, DateTime dateDebut, DateTime dateFin)
        {
            var utilisateurId = _userManager.GetUserId(User);

            var borne = await _borneService.GetBorneByIdAsync(borneId);


            if (borne == null)
            {
                return Unauthorized();
            }
            var disponibilite = new Disponibilite
            {
                BorneId = borneId,
                UtilisateurId = utilisateurId,
                DateDebut = dateDebut,
                DateFin = dateDebut.AddHours(4)
            };

            if (await _borneService.AddDisponibiliteAsync(disponibilite))
            {
                return RedirectToAction("Disponibilites", new { borneId = borneId });
            }

            ModelState.AddModelError("", "Erreur: Conflit de disponibilité ou autre problème.");

            var disponibilites = await _borneService.GetDisponibilitesByBorneIdAsync(borneId);
            var evaluations = await _borneService.GetEvaluationsByBorneIdAsync(borneId);
            var isFavori = await _borneService.IsBorneFavoriAsync(borneId, User.Identity.Name);

            var viewModel = new BorneDetailsViewModel
            {
                Borne = borne,
                Disponibilites = disponibilites,
                Evaluations = evaluations?.OrderByDescending(e => e.DateEvaluation).ToList(),
                EstFavori = isFavori
            };

            return View(viewModel);


        }

        [HttpPost]
        public async Task<IActionResult> SupprimerDisponibilite(int id, int borneId)
        {
            var utilisateurId = _userManager.GetUserId(User);
            var borne = await _borneService.GetBorneByIdAsync(borneId);

            if (borne == null)
            {
                return NotFound();
            }

            // Check how many disponibilites are remaining before attempting to delete
            var disponibilites = await _borneService.GetDisponibilitesByBorneIdAsync(borneId);

            if (disponibilites.Count <= 1)
            {
                TempData["ErrorMessage"] = "Erreur: Impossible de supprimer la disponibilité. Il doit rester au moins une disponibilité.";
                return RedirectToAction("Disponibilites", new { borneId = borneId });
            }

            // Attempt to remove the disponibilite
            try
            {
                if (await _borneService.RemoveDisponibiliteAsync(id))
                {
                    TempData["SuccessMessage"] = "Disponibilité supprimée avec succès.";
                    return RedirectToAction("Disponibilites", new { borneId = borneId });
                }
                else
                {
                    TempData["ErrorMessage"] = "Erreur: Impossible de supprimer la disponibilité.";
                }
            }
            catch
            {
                TempData["ErrorMessage"] = "Erreur: Une erreur s'est produite lors de la suppression.";
            }

            return RedirectToAction("Disponibilites", new { borneId = borneId });
        }





        [HttpGet]
        public async Task<IActionResult> ModifierDisponibilite(int id, int borneId)
        {
            var utilisateurId = _userManager.GetUserId(User);
            var disponibilite = await _borneService.GetDisponibiliteByIdAsync(id);

            if (disponibilite == null || disponibilite.UtilisateurId != utilisateurId)
            {
                return Unauthorized();
            }

            var viewModel = new ModifierDisponibiliteViewModel
            {
                DisponibiliteId = disponibilite.DisponibiliteId,
                BorneId = borneId,
                DateDebut = disponibilite.DateDebut,
                DateFin = disponibilite.DateDebut.AddHours(4)


            };

            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> ModifierDisponibilite(ModifierDisponibiliteViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var utilisateurId = _userManager.GetUserId(User);
            var disponibilite = await _borneService.GetDisponibiliteByIdAsync(viewModel.DisponibiliteId);

            if (disponibilite == null || disponibilite.UtilisateurId != utilisateurId)
            {
                return Unauthorized();
            }

            disponibilite.DateDebut = viewModel.DateDebut;
            disponibilite.DateFin = viewModel.DateDebut.AddHours(4);

            if (await _borneService.UpdateDisponibiliteAsync(disponibilite))
            {
                return RedirectToAction("Disponibilites", new { borneId = viewModel.BorneId });
            }

            ModelState.AddModelError("", "Erreur: Impossible de modifier la disponibilité.");
            return View(viewModel);
        }

    }

}
