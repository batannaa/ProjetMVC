using ProjetMVC.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetMVC.Models
{
    public class Borne
    {
        [Key]
        public int BorneId { get; set; }

        [Required]
        public TypeConnecteur TypeConnecteur { get; set; }

        [Required]
        [Range(1, 100)]
        [Display(Name = "Puissance (KW)")]
        [DisplayFormat(DataFormatString = "{0:0.##} kW")]
        public double PuissanceKW { get; set; }

        public DateTime? DateCreation { get; set; }

        [ForeignKey("Adresse")]
        public int AdresseId { get; set; }

        [NotMapped]
        public double? MoyenneNote { get; set; }

        //navigation
        public ICollection<BorneUtilisateur> BorneUtilisateurs { get; set; }
        public Adresse? Adresse { get; set; }
        public ICollection<Disponibilite> Disponibilites { get; set; }
       

    }
}
