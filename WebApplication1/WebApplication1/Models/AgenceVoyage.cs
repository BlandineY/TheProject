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
        public string NumeroCarteBancaire { get; set; }
        public decimal PrixTotal { get; set; }

        public int NombreParticipant { get; set; }
        public bool Assurance { get; set; }


        [ForeignKey("IdClient")]
        public Client Client { get; set; }
        public int IdClient { get; set; }

        [ForeignKey("IdVoyage")]
        public Voyage Voyage { get; set; }
        public int IdVoyage { get; set; }

    }
}