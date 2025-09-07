using System;
using System.ComponentModel.DataAnnotations;

namespace ProjetMVC.Models
{
    public class Evaluation
    {
        [Key]
        public int EvaluationId { get; set; }

        [Required]
        public int BorneId { get; set; }

        
        [Required]
        public string UtilisateurId { get; set; }

        public Utilisateur Utilisateur { get; set; }

        [Required]
        [Range(1, 5)]
        public int Note { get; set; }

        [StringLength(500)]
        public string Commentaire { get; set; }

        public DateTime DateEvaluation { get; set; } = DateTime.Now;

        //navigation
        public Borne borne { get; set; }
    }
}
