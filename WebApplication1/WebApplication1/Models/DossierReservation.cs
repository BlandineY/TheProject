using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BoVoyage.Models;

namespace BoVoyage.Models
{

    public class DossierReservation
    {
        [Key]
        public int IdDossierReservation { get; set; }
        public string NumeroCarteBancaire { get; set; }
        public decimal PrixTotal { get; set; }

        public int NombreParticipant { get; set; }
        public bool Assurance { get; set; }

        [ForeignKey("IdClient")]
        public  Client Client { get; set; }
        public int IdClient { get; set; }

        //La classe participant nous empêchant de tester certaines fonctionnalités, nous avons choisi de nous passer de la clé étrangère pour l'instant
        /*[ForeignKey("IdParticipant")]
        public Participant Participant { get; set; }
        public int IdParticipant { get; set; }*/


        [ForeignKey("IdVoyage")]
        public Voyage Voyage { get; set; }
        public int IdVoyage { get; set; }
    }

    public enum EtatDossierReservation : byte
    {
        enAttente = 0,
        enCours = 1,
        refusee = 2,
        acceptee = 3
    }

    public enum RaisonAnnulatoionDossier : byte
    {
        client = 0,
        placesInsuffisantes = 2
    }
}


