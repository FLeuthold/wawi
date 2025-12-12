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
    public partial class FormWareneingang: Form
    {        
        public FormWareneingang()
        {
            InitializeComponent();
        }

        private void FormWareneingang_Load(object sender, EventArgs e)
        {
            btnRefresh.PerformClick();


        }
        private void btnEinbuchen_Click(object sender, EventArgs e)
        {
            using (var context = new DerContext())
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    // Schritt 1: Einzelupdates aus dem Grid
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.IsNewRow) continue;

                        int id = (int)row.Cells["Id"].Value;
                        int eingang = (int)row.Cells["Eingang"].Value;

                        var bestellung = context.Bestellungs.Find(id);
                        if (bestellung != null)
                        {
                            bestellung.Eingang = eingang;
                        }
                    }

                    context.SaveChanges();

                    // Schritt 2: Sammelupdate für alle mit Eingang > 0
                    var betroffeneBestellungen = context.Bestellungs
                        .Where(b => b.Eingang > 0)
                        .ToList();

                    foreach (var b in betroffeneBestellungen)
                    {
                        b.Geliefert += b.Eingang;
                        b.Eingang = 0;
                        b.MutUser = Environment.UserName;
                        b.MutDat = DateTime.Now;
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
                var result = context.Bestellungs
    .Where(b => (b.Bestellt - b.Geliefert) > 0)
    .Join(context.Artikels,
          b => b.Artikel.Id,
          a => a.Id,
          (b, a) => new
          {
              b.Id,
              b.ErfDat,
              a.Name,
              b.Bestellt,
              b.Geliefert,
              //Offen = b.Bestellt - b.Geliefert,
              b.Eingang
          })
    .ToList();

                dataGridView1.DataSource = result;
            }
            //dataGridView1.DataSource = DBHelper.SelectData("SELECT b.Id, b.ErfDat, a.Name, b.Bestellt, b.Geliefert, b.Offen, b.Eingang FROM Artikel a INNER JOIN Bestellungen b ON a.Id = b.ArtikelId WHERE (((b.offen)>0)); ");
            //dataGridView1.Columns["Id"].Visible = false;
        }
    }
}
