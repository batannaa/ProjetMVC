using ProjetMVC.Enums;
using NetTopologySuite.Geometries;
using System.ComponentModel.DataAnnotations;

namespace ProjetMVC.Models
{
    public class Adresse
    {
        public int AdresseId { get; set; }

        [Required]
        [StringLength(10)]
        public string NoCivique { get; set; }

        [Required]
        [StringLength(100)]
        public string Rue { get; set; }

        [Required]
        [StringLength(50)]
        public string Ville { get; set; }

        [StringLength(9)]
        [RegularExpression(@"^[A-Za-z]\d[A-Za-z]\d[A-Za-z]\d$", ErrorMessage = "Le code postal doit être un code postal canadien valide (Ex.: A1A1A1).")]
        public string CodePostal { get; set; }

        [Range(-90, 90, ErrorMessage = "La latitude doit être comprise entre -90 et 90.")]
        public double? Latitude { get; set; }

        [Range(-180, 180, ErrorMessage = "La longitude doit être comprise entre -180 et 180.")]
        public double? Longitude { get; set; }

        [Required(ErrorMessage = "Veuillez sélectionner une province.")]
        [EnumDataType(typeof(ProvincesCanadiennes), ErrorMessage = "L’application n’est disponible qu’au Québec à l’heure actuelle.")]
        public int Province { get; set; }

        //Propriété de navigation
        public Borne? Borne { get; set; }
    }

}

