using ProjetMVC.Enums;
using ProjetMVC.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetMVC.ViewModels
{
    public class BorneRechercheVM
    {
        public Borne Borne { get; set; }

        [Display(Name = "Type de Connecteur")]
        public TypeConnecteur? TypeConnecteur { get; set; }

        [Display(Name = "Puissance Minimale (kW)")]
        public double? PuissanceMinimale { get; set; }

        [Display(Name = "Adresse")]
        public Adresse Adresse { get; set; }

        [Required(ErrorMessage = "L'adresse complète est requise.")]
        [Display(Name = "Adresse complète")]
        public string AdresseComplete { get; set; }

        public double Distance { get; set; }

        [Range(1, 5, ErrorMessage = "La note minimale doit être comprise entre 1 et 5.")]
        public double? NoteMinimale { get; set; }
        public double? NoteMoyenne { get; set; }
        public bool RechercheDansFavorisSeulement { get; set; }
    }
}