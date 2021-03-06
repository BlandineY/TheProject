﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BoVoyage.Models;

namespace BoVoyage.Models
{

    public class Participant : Personne
    {
        [Key]
        public int IdParticipant { get; set; }
        public double Reduction { get; set; }

        //[Key, ForeignKey("DossierReservation")]
        //[ForeignKey("IdDossierReservation")]
        //public DossierReservation DossierReservation { get; set; }
        //public int IdDossierReservation { get; set; }
    }
}