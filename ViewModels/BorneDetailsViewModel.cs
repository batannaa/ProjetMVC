using ProjetMVC.Models;

namespace ProjetMVC.ViewModels
{
    public class BorneDetailsViewModel
    {
        public Borne Borne { get; set; }
        public bool EstFavori { get; set; }
        public List<BorneUtilisateur> Evaluations { get; set; }
        public int Note { get; set; }
        public string Commentaire { get; set; }
        public DateTime Date { get; set; }
        public List<Disponibilite> Disponibilites { get; set; }
    }
}
