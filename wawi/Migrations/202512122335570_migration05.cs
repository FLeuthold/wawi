namespace wawi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration05 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Auftrags", "Status", c => c.String(maxLength: 100));
            AlterColumn("dbo.Auftrags", "MutUser", c => c.String(maxLength: 100));
            AlterColumn("dbo.Auftrags", "ErfUser", c => c.String(maxLength: 100));

            AlterColumn("dbo.Bestellungs", "MutUser", c => c.String(maxLength: 100));
            AlterColumn("dbo.Bestellungs", "ErfUser", c => c.String(maxLength: 100));
            AlterColumn("dbo.Druckers", "Bezeichnung", c => c.String(maxLength: 100));
            //AddColumn("dbo.Artikels", "Bestellvorschlag", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Auftrags", "Status", c => c.String());
            AlterColumn("dbo.Auftrags", "MutUser", c => c.String());
            AlterColumn("dbo.Auftrags", "ErfUser", c => c.String());

            AlterColumn("dbo.Bestellungs", "MutUser", c => c.String());
            AlterColumn("dbo.Bestellungs", "ErfUser", c => c.String());

            AlterColumn("dbo.Druckers", "Bezeichnung", c => c.String());
            //DropColumn("dbo.Artikels", "Bestellvorschlag");
        }
    }
}
