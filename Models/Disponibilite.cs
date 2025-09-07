using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetMVC.Models
{
    public class Disponibilite
    {
        [Key]
        public int DisponibiliteId { get; set; }

        [ForeignKey("Borne")]
        public int BorneId { get; set; }

        [ForeignKey("Utilisateur")]
        public string UtilisateurId { get; set; }

        [Required]
        public DateTime DateDebut { get; set; }

        [Required]
        public DateTime DateFin { get; set; }

        // Navigation properties
        public Borne Borne { get; set; }

        public Utilisateur Utilisateur { get; set; }



    }
}
