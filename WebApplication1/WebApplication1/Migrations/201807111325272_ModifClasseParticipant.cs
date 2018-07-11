namespace BoVoyage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifClasseParticipant : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Participants", "IdParticipant", "dbo.DossierReservations");
            DropIndex("dbo.Participants", new[] { "IdParticipant" });
            DropPrimaryKey("dbo.Participants");
            AlterColumn("dbo.Participants", "IdParticipant", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Participants", "IdParticipant");
            CreateIndex("dbo.DossierReservations", "IdParticipant");
            AddForeignKey("dbo.DossierReservations", "IdParticipant", "dbo.Participants", "IdParticipant", cascadeDelete: true);
            DropColumn("dbo.Participants", "IdDossierReservation");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Participants", "IdDossierReservation", c => c.Int(nullable: false));
            DropForeignKey("dbo.DossierReservations", "IdParticipant", "dbo.Participants");
            DropIndex("dbo.DossierReservations", new[] { "IdParticipant" });
            DropPrimaryKey("dbo.Participants");
            AlterColumn("dbo.Participants", "IdParticipant", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Participants", "IdParticipant");
            CreateIndex("dbo.Participants", "IdParticipant");
            AddForeignKey("dbo.Participants", "IdParticipant", "dbo.DossierReservations", "IdDossierReservation");
        }
    }
}
