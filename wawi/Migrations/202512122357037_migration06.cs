namespace wawi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration06 : DbMigration
    {
        public override void Up()
        {
            RenameColumn("dbo.Druckers", "Bezeichnung", "NameD");
        }
        
        public override void Down()
        {
            RenameColumn("dbo.Druckers", "NameD", "Bezeichnung");
        }
    }
}
