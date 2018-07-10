using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using BoVoyage.Models;

namespace BoVoyage.Data
{
    public class BoVoyageDbContext : DbContext
    {
        public BoVoyageDbContext() : base("Blandine-Jonathan") // Constructeur de la classe de base
        {
        }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Voyage> Voyages { get; set; }

        public DbSet<AgenceVoyage> AgenceVoyages { get; set; }

        public DbSet<Assurance> Assurances { get; set; }

        public DbSet<AssuranceAnnulation> AssuranceAnnulations { get; set; }

        public DbSet<Destination> Destinations { get; set; }

        public DbSet<DossierReservation> DossiersReservations { get; set; }

        public DbSet<Participant> Participants { get; set; }
    }
}