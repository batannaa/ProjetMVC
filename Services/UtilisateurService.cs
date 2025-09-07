using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using ProjetMVC.Models;
using System.Security.Claims;

namespace ProjetMVC.Services
{
    public class UtilisateurService : IUtilisateurService
    {
        private readonly UserManager<Utilisateur> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UtilisateurService(UserManager<Utilisateur> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IdentityResult> CreateUserAsync(Utilisateur utilisateur, string motDePasse)
        {
            return await _userManager.CreateAsync(utilisateur, motDePasse);
        }

        public async Task<string> GetCurrentUserId()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return await Task.FromResult(userId);  // Wrap in Task.FromResult to maintain async pattern
        }
    }
}
