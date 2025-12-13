using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wawi
{
    public partial class FormBestellvorschlag: Form
    {
        public FormBestellvorschlag()
        {
            InitializeComponent();
        }
       
        private void frmBestellvorschlag_Load(object sender, EventArgs e)
        {
            // TODO: Diese Codezeile lädt Daten in die Tabelle "database1DataSetBestellvorschlag.ViewBestellvorschlag". Sie können sie bei Bedarf verschieben oder entfernen.
            //this.viewBestellvorschlagTableAdapter.Fill(this.database1DataSetBestellvorschlag.ViewBestellvorschlag);
            btnRefresh.PerformClick();
        }
        private void btnBestellvorschlag_Click(object sender, EventArgs e)
        {
            using (var context = new DerContext())
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    var username = Environment.UserName;
                    var jetzt = DateTime.Now;

                    // Alle Artikel mit Bestellvorschlag > 0 laden
                    var artikelMitVorschlag = context.Artikels
                        .Where(a => (a.Mindestbestand + a.Reserviert - a.Bestand - a.Bestellt) > 0)
                        .ToList();

                    foreach (var artikel in artikelMitVorschlag)
                    {
                        // Bestellung anlegen
                        var bv = artikel.Bestellvorschlag;
                        var bestellung = new Bestellung
                        {
                            Artikel = artikel,
                            Bestellt = bv,
                            ErfUser = username,
                            ErfDat = jetzt,
                            Geliefert = 0,
                            Eingang = 0
                        };
                        context.Bestellungs.Add(bestellung);

                        // Artikel aktualisieren
                        artikel.Bestellt += bv;
                    }

                    context.SaveChanges();
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }

            btnRefresh.PerformClick();
        }


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            using (var context = new DerContext())
            {
                /*var result = context.Artikels
                    .Where(a => (a.Mindestbestand + a.Reserviert - a.Bestand - a.Bestellt) > 0)
                    .Select(a => new
                    {
                        a.Name,
                        a.Mindestbestand,//,
                        a.Bestellvorschlag
                    })
                    .ToList();*/
                /*var result = context.Artikels
    .Where(a => (a.Mindestbestand + a.Reserviert - a.Bestand - a.Bestellt) > 0)
    .ToList()
    .Select(a => new
    {
        a.Name,
        a.Mindestbestand,
        a.Bestellvorschlag
    }).ToList();*/
                var result = context.Artikels
    .Where(a => a.Bestellvorschlag > 0)
    .Select(a => new
    {
        a.Name,
        a.Mindestbestand,
        a.Bestellvorschlag
    }).ToList();
                /*var result = context.Artikels
    .Where(a => (a.Bestellvorschlag) > 0)
    .ToList();*/
                //var resultList = result
                dataGridView1.DataSource = result;
            }
            //dataGridView1.DataSource = DBHelper.SelectData("SELECT Name, Mindestbestand, Bestellvorschlag FROM     dbo.Artikel WHERE(Bestellvorschlag > 0)");

        }
    }
}
