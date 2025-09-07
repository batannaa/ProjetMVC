using ProjetMVC.Enums;
using ProjetMVC.Models;
using System.ComponentModel.DataAnnotations;

namespace ProjetMVC.ViewModels
{
    public class BorneCreateVM
    {
        [Required]
        public TypeConnecteur TypeConnecteur { get; set; }

        [Required]
        [Range(1, 100)]
        [Display(Name = "Puissance (KW)")]
        [DisplayFormat(DataFormatString = "{0:0.##} kW")]
        public double PuissanceKW { get; set; }

        [Required]
        public Adresse Adresse { get; set; }
       
        

    }
}
