using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace wawi
{
    public class DerContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<Auftrag>()
                .Property(a => a.ErfDat)
                .HasColumnType("datetime"); // statt datetime2*/
        }
        public DbSet<Artikel> Artikels { get; set; }
        public DbSet<Auftrag> Auftrags { get; set; }
        public DbSet<Drucker> Druckers { get; set; }
        public DbSet<Bestellung> Bestellungs { get; set; }
    }
    public class Artikel
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        public decimal Preis { get; set; }
        public int Bestand { get; set; }
        public int Bestellt { get; set; }
        public int Reserviert { get; set; }
        public int Mindestbestand { get; set; }
        [NotMapped] // EF soll keine Spalte dafür anlegen
        public int Bestellvorschlag => Mindestbestand + Reserviert - Bestand - Bestellt;
        /*[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int Bestellvorschlag
        {
            get { return Mindestbestand + Reserviert - Bestand - Bestellt; }
            private set { }
        }*/
        
    }
    public class Auftrag
    {
        public int Id { get; set; }
        public Drucker Drucker { get; set; }
        public Artikel Artikel { get; set; }
        public string Status { get; set; }
        public string ErfUser { get; set; }
        public Nullable<DateTime> ErfDat { get; set; }
        public string MutUser { get; set; }
        public Nullable<DateTime> MutDat { get; set; }
    }

    public class Drucker
    {
        public int Id { get; set; }
        public string Bezeichnung { get; set; }
    }
    public class Bestellung
    {
        public int Id { get; set; }
        public Artikel Artikel { get; set; }
        public int Bestellt { get; set; }
        public int Geliefert { get; set; }
        public int Eingang { get; set; }
        //public int Offen { get; set; }
        /*[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int Offen
        {
            get { return Bestellt - Geliefert; }
            private set {  }
        }*/
        [NotMapped] // EF soll keine Spalte dafür anlegen
        public int Offen => Bestellt - Geliefert;

        public string ErfUser { get; set; }
        public Nullable<DateTime> ErfDat { get; set; }
        public string MutUser { get; set; }
        public Nullable<DateTime> MutDat { get; set; }
    }
}
