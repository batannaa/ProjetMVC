
using ProjetMVC.Enums;
using System.ComponentModel.DataAnnotations;

namespace ProjetMVC.ViewModels
{
    public class AdresseVM
    {
        [Required]
        [RegularExpression(@"^\d+$", ErrorMessage = "Le numéro civique ne doit contenir que des chiffres.")]
        [StringLength(10)]
        public string NoCivique { get; set; }

        [Required]
        [StringLength(100)]
        public string Rue { get; set; }

        [Required]
        [StringLength(50)]
        public string Ville { get; set; }

        [RegularExpression(@"^[A-Za-z]\d[A-Za-z]\d[A-Za-z]\d$", ErrorMessage = "Le code postal doit être un code postal canadien valide (Ex.: A1A1A1).")]
        [StringLength(9)]
        public string CodePostal { get; set; }

        [Required(ErrorMessage = "Veuillez sélectionner une province.")]
        public int Province { get; set; }


    }
}
