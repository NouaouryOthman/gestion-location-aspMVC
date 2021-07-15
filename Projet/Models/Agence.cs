using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Projet.Models
{
    public class Agence
    {
        [Key]
        public int IdAgence { get; set; }
        [Required]
        [Display(Name = "Ville")]
        public string  Ville { get; set; }
        [Required]
        [Display(Name =  "Telephone")]
        [DataType(DataType.PhoneNumber)]
        public string Telephone { get; set; }
        [Required]
        [Display(Name = "Email Responsable de l'agence")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public ICollection<Vehicule> Vehicules { get; set; }
        [Display(Name = "Active")]
        public Boolean Etat { get; set; }
    }
}