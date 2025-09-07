using ProjetMVC.Models;


namespace ProjetMVC.ViewModels
{
    public class BorneDisponibilitesViewModel
    {
        public int BorneId { get; set; }
        public string BorneNom { get; set; }
        public List<Disponibilite> Disponibilites { get; set; }
        public List<BorneUtilisateur> BorneUtilisateurs { get; set; }
        public bool UtilisateurEstProprietaire { get; set; }
    }
}
