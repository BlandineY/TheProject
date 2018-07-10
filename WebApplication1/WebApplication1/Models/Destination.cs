using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BoVoyage.Models;

namespace BoVoyage.Models
{
    public class Destination
    {
        [Key]
        public int IdDestination { get; set; }
        public string Continent { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire")]
        public string Pays { get; set; }
        public string Region { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return Pays;
        }
    }
}


