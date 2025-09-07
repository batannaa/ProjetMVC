using ProjetMVC.Enums;
using ProjetMVC.Models;

namespace ProjetMVC.ViewModels
{
    public class BorneViewModel
    {
        public int BorneId { get; set; }
        public TypeConnecteur TypeConnecteur { get; set; }
        public double PuissanceKW { get; set; }
        public Adresse Adresse { get; set; }
        public bool EstFavori { get; set; }
        public double? NoteMoyenne { get; set; }
        public DateTime DateCreation { get; set; }
        public Borne Borne { get; set; }
    }
}
