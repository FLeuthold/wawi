namespace wawi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration04 : DbMigration
    {
        public override void Up()
        {
            // Berechnete Spalte hinzufügen
            Sql(@"
            ALTER TABLE dbo.Artikels
            DROP COLUMN Bestellvorschlag
        ");
            Sql(@"
            ALTER TABLE dbo.Artikels
            ADD Bestellvorschlag AS (Mindestbestand + Reserviert - Bestand - Bestellt)
        ");
        }

        public override void Down()
        {
            // Berechnete Spalte wieder entfernen
            Sql(@"
            ALTER TABLE dbo.Artikels
            DROP COLUMN Bestellvorschlag
        ");
        }
    }
}
