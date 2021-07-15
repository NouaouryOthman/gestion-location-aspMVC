using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Projet.Models
{
    public class Client
    {
        [Key]
        public int IdClient { get; set; }

        [Required]
        [Display(Name = "Nom")]
        public string Nom { get; set; }

        [Required]
        [Display(Name = "Prenom")]
        public string Prenom { get; set; }

        [Required]
        [Display(Name = "N° CIN")]
        public string NumCIN { get; set; }

        [Required]
        [Display(Name = "N° Permis")]
        public string NumPermis { get; set; }

        [Required]
        [Display(Name = "Experience de Conduite")]
        public string Experience { get; set; }

        [Required]
        [Display(Name = "N° téléphone")]
        [DataType(DataType.PhoneNumber)]
        public string NumTel { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}