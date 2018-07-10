namespace BoVoyage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AgenceVoyages",
                c => new
                    {
                        IdAgenceVoyage = c.Int(nullable: false, identity: true),
                        NomAgence = c.String(),
                    })
                .PrimaryKey(t => t.IdAgenceVoyage);
            
            CreateTable(
                "dbo.AssuranceAnnulations",
                c => new
                    {
                        IdAssuranceAnnulation = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.IdAssuranceAnnulation);
            
            CreateTable(
                "dbo.Assurances",
                c => new
                    {
                        IdAssurance = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.IdAssurance);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        IdClient = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Civilite = c.String(),
                        Nom = c.String(),
                        Prenom = c.String(),
                        Adresse = c.String(),
                        Telephone = c.String(),
                        DateNaissance = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdClient);
            
            CreateTable(
                "dbo.Destinations",
                c => new
                    {
                        IdDestination = c.Int(nullable: false, identity: true),
                        Continent = c.String(),
                        Pays = c.String(),
                        Region = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.IdDestination);
            
            CreateTable(
                "dbo.DossierReservations",
                c => new
                    {
                        IdDossierReservation = c.Int(nullable: false, identity: true),
                        NumeroCarteBancaire = c.String(),
                        PrixTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NombreParticipant = c.Int(nullable: false),
                        Assurance = c.Boolean(nullable: false),
                        IdClient = c.Int(nullable: false),
                        IdParticipant = c.Int(nullable: false),
                        IdVoyage = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdDossierReservation)
                .ForeignKey("dbo.Clients", t => t.IdClient, cascadeDelete: true)
                .ForeignKey("dbo.Voyages", t => t.IdVoyage, cascadeDelete: true)
                .Index(t => t.IdClient)
                .Index(t => t.IdVoyage);
            
            CreateTable(
                "dbo.Participants",
                c => new
                    {
                        IdParticipant = c.Int(nullable: false),
                        Reduction = c.Double(nullable: false),
                        Civilite = c.String(),
                        Nom = c.String(),
                        Prenom = c.String(),
                        Adresse = c.String(),
                        Telephone = c.String(),
                        DateNaissance = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdParticipant)
                .ForeignKey("dbo.DossierReservations", t => t.IdParticipant)
                .Index(t => t.IdParticipant);
            
            CreateTable(
                "dbo.Voyages",
                c => new
                    {
                        IdVoyage = c.Int(nullable: false, identity: true),
                        DateAller = c.DateTime(nullable: false),
                        DateRetour = c.DateTime(nullable: false),
                        PlacesDisponibles = c.Int(nullable: false),
                        TarifToutCompris = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IdAgenceVoyage = c.Int(nullable: false),
                        IdDestination = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdVoyage)
                .ForeignKey("dbo.AgenceVoyages", t => t.IdAgenceVoyage, cascadeDelete: true)
                .ForeignKey("dbo.Destinations", t => t.IdDestination, cascadeDelete: true)
                .Index(t => t.IdAgenceVoyage)
                .Index(t => t.IdDestination);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DossierReservations", "IdVoyage", "dbo.Voyages");
            DropForeignKey("dbo.Voyages", "IdDestination", "dbo.Destinations");
            DropForeignKey("dbo.Voyages", "IdAgenceVoyage", "dbo.AgenceVoyages");
            DropForeignKey("dbo.Participants", "IdParticipant", "dbo.DossierReservations");
            DropForeignKey("dbo.DossierReservations", "IdClient", "dbo.Clients");
            DropIndex("dbo.Voyages", new[] { "IdDestination" });
            DropIndex("dbo.Voyages", new[] { "IdAgenceVoyage" });
            DropIndex("dbo.Participants", new[] { "IdParticipant" });
            DropIndex("dbo.DossierReservations", new[] { "IdVoyage" });
            DropIndex("dbo.DossierReservations", new[] { "IdClient" });
            DropTable("dbo.Voyages");
            DropTable("dbo.Participants");
            DropTable("dbo.DossierReservations");
            DropTable("dbo.Destinations");
            DropTable("dbo.Clients");
            DropTable("dbo.Assurances");
            DropTable("dbo.AssuranceAnnulations");
            DropTable("dbo.AgenceVoyages");
        }
    }
}
