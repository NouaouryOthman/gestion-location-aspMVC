using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projet.Models
{
    public class Vehicule
    {
        [Key]
        public int IdVehicule { get; set; }
        [Required]
        [Display(Name = "La Marque")]
        public string Marque { get; set; }
        [Required]
        [Display(Name = "Le Modele")]
        public string Modele { get; set; }
        [Required]
        [Display(Name = "Immatricule")]
        public string Immatricule { get; set; }
        [Required]
        [Display(Name = "Couleur")]
        public string Couleur { get; set; }
        [Required]
        [Display(Name = "Kilometrage")]
        public string Km { get; set; }
        [Required]
        [Display(Name = "Loué")]
        public bool Etat { get; set; }
        public virtual Agence Agence { get; set; }
        [ForeignKey("Agence")]
        public int AgenceId { get; set; }
        [NotMapped]
        public Localisation Localisation { get; set; }
    }
}