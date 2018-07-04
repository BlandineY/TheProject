using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BoVoyage.Models;

namespace BoVoyage.Models
{
    public class Voyage
    {
        [Key]
        public int IdVoyage { get; set; }
        public System.DateTime DateAller { get; set; }
        public System.DateTime DateRetour { get; set; }
        public int PlacesDisponibles { get; set; }
        public decimal TarifToutCompris { get; set; }

        [ForeignKey("IdAgenceVoyage")]
        public AgenceVoyage AgenceVoyage { get; set; }
        public int IdAgenceVoyage { get; set; }

        [ForeignKey("IdDestination")]
        public Destination Destination { get; set; }
        public int IdDestination { get; set; }
    }
}