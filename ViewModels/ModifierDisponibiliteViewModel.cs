
using System.ComponentModel.DataAnnotations;



namespace ProjetMVC.ViewModels
{
    public class ModifierDisponibiliteViewModel
    {
        public int DisponibiliteId { get; set; }
        public int BorneId { get; set; }

        [Required]
        public DateTime DateDebut { get; set; }

        [Required]
        public DateTime DateFin { get; set; }
    }
}
