namespace wawi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration02 : DbMigration
    {
        public override void Up()
        {
            // Spalte "Name" in "Bezeichnung" umbenennen
            RenameColumn("dbo.Artikels", "Bezeichnung", "Name");

            // Typ der Spalte "Bezeichnung" ändern: nvarchar(100) statt nvarchar(max)
            AlterColumn("dbo.Artikels", "Name", c => c.String(maxLength: 100));
            //AddColumn("dbo.Artikels", "Name", c => c.String());
            AlterColumn("dbo.Auftrags", "ErfDat", c => c.DateTime());
            AlterColumn("dbo.Auftrags", "MutDat", c => c.DateTime());
            AlterColumn("dbo.Bestellungs", "ErfDat", c => c.DateTime());
            AlterColumn("dbo.Bestellungs", "MutDat", c => c.DateTime());
            //DropColumn("dbo.Artikels", "Bezeichnung");
            //DropColumn("dbo.Artikels", "Bestellvorschlag");
            //DropColumn("dbo.Bestellungs", "Offen");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bestellungs", "Offen", c => c.Int(nullable: false));
            AddColumn("dbo.Artikels", "Bestellvorschlag", c => c.Int(nullable: false));
            AddColumn("dbo.Artikels", "Bezeichnung", c => c.String());
            AlterColumn("dbo.Bestellungs", "MutDat", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Bestellungs", "ErfDat", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Auftrags", "MutDat", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Auftrags", "ErfDat", c => c.DateTime(nullable: false));
            //DropColumn("dbo.Artikels", "Name");
            // Typ zurück auf nvarchar(max)
            AlterColumn("dbo.Artikels", "Name", c => c.String());

            // Spalte wieder zurück auf "Name"
            RenameColumn("dbo.Artikels", "Name", "Bezeichnung");

        }
    }
}
