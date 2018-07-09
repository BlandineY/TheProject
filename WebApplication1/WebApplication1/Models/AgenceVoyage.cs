using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using BoVoyage.Models;

namespace BoVoyage.Models
{
    public class AgenceVoyage

    {
        [Key]
        public int IdNumeroUnique { get; set; }
        public string NomAgence { get; set; }

        //[ForeignKey("IdVoyage")]
        //public Voyage Voyage { get; set; }
        //public int IdVoyage { get; set; }

    }
}