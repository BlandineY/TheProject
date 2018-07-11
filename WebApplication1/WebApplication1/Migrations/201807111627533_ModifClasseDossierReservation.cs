namespace BoVoyage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifClasseDossierReservation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DossierReservations", "IdParticipant", "dbo.Participants");
            DropIndex("dbo.DossierReservations", new[] { "IdParticipant" });
            DropColumn("dbo.DossierReservations", "IdParticipant");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DossierReservations", "IdParticipant", c => c.Int(nullable: false));
            CreateIndex("dbo.DossierReservations", "IdParticipant");
            AddForeignKey("dbo.DossierReservations", "IdParticipant", "dbo.Participants", "IdParticipant", cascadeDelete: true);
        }
    }
}
