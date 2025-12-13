namespace wawi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration03 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Artikels", "Name", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Artikels", "Name", c => c.String(maxLength: 100));
        }
    }
}
