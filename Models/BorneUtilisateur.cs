using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetMVC.Models
{
    public class BorneUtilisateur
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Borne")]
        public int BorneId { get; set; }

        [ForeignKey("Utilisateur")]
        public string UtilisateurId { get; set; }

        public Borne Borne { get; set; }
        public Utilisateur Utilisateur { get; set; }

        public double? Note { get; set; }
        public string? Commentaire { get; set; }
        public DateTime? DateEvaluation { get; set; }

        public bool EstFavoris { get; set; }
        public DateTime? DateAjoutFavori { get; set; }
    }
}