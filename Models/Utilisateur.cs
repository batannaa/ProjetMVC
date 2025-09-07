using Microsoft.AspNetCore.Identity;

namespace ProjetMVC.Models
{
    public class Utilisateur : IdentityUser
    {
        
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //navigation
        public virtual ICollection<BorneUtilisateur> BorneUtilisateurs { get; set; }
        public ICollection<Disponibilite> Disponibilites { get; set; }

    }
}
