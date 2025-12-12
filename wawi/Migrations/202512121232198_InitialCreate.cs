namespace wawi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Artikels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Bezeichnung = c.String(),
                        Preis = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Bestand = c.Int(nullable: false),
                        Bestellt = c.Int(nullable: false),
                        Reserviert = c.Int(nullable: false),
                        Mindestbestand = c.Int(nullable: false),
                        Bestellvorschlag = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Auftrags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.String(),
                        ErfUser = c.String(),
                        ErfDat = c.DateTime(nullable: false),
                        MutUser = c.String(),
                        MutDat = c.DateTime(nullable: false),
                        Artikel_Id = c.Int(),
                        Drucker_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Artikels", t => t.Artikel_Id)
                .ForeignKey("dbo.Druckers", t => t.Drucker_Id)
                .Index(t => t.Artikel_Id)
                .Index(t => t.Drucker_Id);
            
            CreateTable(
                "dbo.Druckers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Bezeichnung = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Bestellungs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Bestellt = c.Int(nullable: false),
                        Geliefert = c.Int(nullable: false),
                        Eingang = c.Int(nullable: false),
                        Offen = c.Int(nullable: false),
                        ErfUser = c.String(),
                        ErfDat = c.DateTime(nullable: false),
                        MutUser = c.String(),
                        MutDat = c.DateTime(nullable: false),
                        Artikel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Artikels", t => t.Artikel_Id)
                .Index(t => t.Artikel_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bestellungs", "Artikel_Id", "dbo.Artikels");
            DropForeignKey("dbo.Auftrags", "Drucker_Id", "dbo.Druckers");
            DropForeignKey("dbo.Auftrags", "Artikel_Id", "dbo.Artikels");
            DropIndex("dbo.Bestellungs", new[] { "Artikel_Id" });
            DropIndex("dbo.Auftrags", new[] { "Drucker_Id" });
            DropIndex("dbo.Auftrags", new[] { "Artikel_Id" });
            DropTable("dbo.Bestellungs");
            DropTable("dbo.Druckers");
            DropTable("dbo.Auftrags");
            DropTable("dbo.Artikels");
        }
    }
}
