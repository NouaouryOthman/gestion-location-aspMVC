using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projet.Models
{
    public class Location
    {
        [Key]
        public int IdLocation { get; set; }
        [Required]
        [Display(Name = "Date de Début")]
        [DataType(DataType.Date)]
        public DateTime DateDebut { get; set; }
        [Required]
        [Display(Name = "Date de Fin")]
        [DataType(DataType.Date)]
        public DateTime DateFin { get; set; }
        [Required]
        [Display(Name = "Prix par Jour")]
        [DataType(DataType.Currency)]
        public double Prix { get; set; }
        public virtual Client Client { get; set; }
        [ForeignKey("Client")]
        public int IdClient { get; set; }
        public virtual Agence Agence { get; set; }
        [ForeignKey("Agence")]
        public int IdAgence { get; set; }
        public virtual Vehicule Vehicule { get; set; }
        [ForeignKey("Vehicule")]
        public int? IdVehicule { get; set; }
        public double CalculerPrix()
        {
            return (DateDebut - DateFin).TotalDays * Prix;
        }
    }
}