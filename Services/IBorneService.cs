using ProjetMVC.Enums;
using ProjetMVC.Models;
using ProjetMVC.ViewModels;

namespace ProjetMVC.Services
{
    public interface IBorneService
    {
        Task<Borne> GetBorneByIdAsync(int id);
        Task<Borne> AddBorneAsync(BorneCreateVM model, Utilisateur user);
        Task<List<Borne>> GetBornesByTypeConnecteurAsync(TypeConnecteur typeConnecteur);
        Task<List<Borne>> GetBornesByPuissanceAsync(int puissanceMinimale);
        Task<List<Borne>> GetBornesByAdresseAsync(string adresse, string noCivique);
        Task<List<Borne>> GetAllBornesAsync();
        Task<bool> ToggleFavoriteAsync(int borneId, string utilisateurId);
        Task<bool> IsBorneFavoriAsync(int borneId, string utilisateurId);
        Task AddBorneUtilisateurAsync(int borneId, string utilisateurId);
        Task<List<BorneUtilisateur>> GetFavorisByUserIdAsync(string utilisateurId);
        Task AddEvaluationAsync(BorneUtilisateur borneUtilisateur);
        Task<List<BorneUtilisateur>> GetEvaluationsByBorneIdAsync(int borneId);
        Task<bool> AdresseExistsAsync(Adresse adresse);
        Task<List<BorneRechercheVM>> RechercherBornesAsync(BorneRechercheVM model);
        Task<List<BorneViewModel>> GetBornesForMapAsync();
        Task<BorneUtilisateur> GetEvaluationByUserAndBorneIdAsync(string utilisateurId, int borneId);
        Task<bool> UserAddedBorneAsync(string utilisateurId, int borneId);
        Task<List<Disponibilite>> GetDisponibilitesByBorneIdAsync(int borneId);
        Task<bool> AddDisponibiliteAsync(Disponibilite disponibilite);
        Task<bool> RemoveDisponibiliteAsync(int disponibiliteId);
        Task<Disponibilite> GetDisponibiliteByIdAsync(int disponibiliteId);
        Task<bool> UpdateDisponibiliteAsync(Disponibilite disponibilite);
        Task<string> GetUserIdByBorneIdAsync(int borneId);


        }
}
