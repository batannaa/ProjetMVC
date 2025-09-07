using Microsoft.AspNetCore.Identity;
using ProjetMVC.Models;

namespace ProjetMVC.Services
{
    public interface IUtilisateurService
    {
        Task<IdentityResult> CreateUserAsync(Utilisateur utilisateur, string motDePasse);
        Task<string> GetCurrentUserId();
    }
}
