using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Projet.Models
{
    public class Reservation
    {
        [Key]
        public int IdReservation { get; set; }
        [Required]
        [Display(Name = "Numéro de téléphone")]
        [DataType(DataType.PhoneNumber)]
        public string NumTel { get; set; }
        [Required]
        [Display(Name = "Nom")]
        public string Nom { get; set; }
        [Required]
        [Display(Name = "Prenom")]
        public string Prenom { get; set; }
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public virtual Vehicule Vehicule { get; set; }
        
    }
}