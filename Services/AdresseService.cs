using ProjetMVC.Models;

namespace ProjetMVC.Services
{
    public class AdresseService : IAdresseService
    {
        private readonly MyDbContext _context;

        public AdresseService(MyDbContext context)
        {
            _context = context;
        }

        public async Task<Adresse> AddAdresseAsync(Adresse adresse)
        {
            _context.Adresses.Add(adresse);
            await _context.SaveChangesAsync();
            return adresse;

        }
    }
}
