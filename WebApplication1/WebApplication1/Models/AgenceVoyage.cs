﻿using System;
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
        public int IdAgenceVoyage { get; set; }

        [Required(ErrorMessage = "Le champ nom est obligatoire")]
        public string NomAgence { get; set; }

        //public int IdVoyage { get; set; }
        //[ForeignKey("IdVoyage")]
        //public Voyage Voyage { get; set; }
    }
}