using ProjetMVC.Models;

namespace ProjetMVC.Services
{
    public interface IAdresseService
    {
        Task<Adresse> AddAdresseAsync(Adresse adresse);
    }
}
