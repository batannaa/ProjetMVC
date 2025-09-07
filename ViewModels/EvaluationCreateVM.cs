using System.ComponentModel.DataAnnotations;

namespace ProjetMVC.ViewModels
{
    public class EvaluationCreateVM
    {
        [Required]
        public int BorneId { get; set; }

        [Required]
        [Range(1, 5)]
        public int Note { get; set; }

        [StringLength(500)]
        public string Commentaire { get; set; }
    }
}

