using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace wawi
{
    enum StatusAuftrag
    {
        Reserviert,
        Bereit,
        Ausgeliefert,
        Ausgewechselt
    }
    public partial class FormAuftraege : Form
    {
        public FormAuftraege()
        {
            InitializeComponent();
            dgvAuftraege.AutoGenerateColumns = false;
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: Diese Codezeile lädt Daten in die Tabelle "database1DataSet1.View". Sie können sie bei Bedarf verschieben oder entfernen.
            //this.viewTableAdapter.Fill(this.database1DataSet1.View);
            // TODO: Diese Codezeile lädt Daten in die Tabelle "database1DataSetDrucker.Drucker". Sie können sie bei Bedarf verschieben oder entfernen.
            //this.druckerTableAdapter.Fill(this.database1DataSetDrucker.Drucker);
            // TODO: Diese Codezeile lädt Daten in die Tabelle "database1DataSet.Artikel". Sie können sie bei Bedarf verschieben oder entfernen.
            //this.artikelTableAdapter.Fill(this.database1DataSet.Artikel);

            /**
             * SELECT dbo.Auftrag.Id, dbo.Auftrag.ErfDat, dbo.Artikel.Name, dbo.Drucker.Bezeichnung, dbo.Auftrag.Status, dbo.Auftrag.ErfUser
FROM     dbo.Drucker INNER JOIN
                  dbo.Artikel INNER JOIN
                  dbo.Auftrag ON dbo.Artikel.Id = dbo.Auftrag.ArtikelId ON dbo.Drucker.Id = dbo.Auftrag.DruckerId
             */
            ErneuernAnzeige();
            using (var context = new DerContext())
            {


                //DBHelper.SelectData("select * from [View] order by Id desc");

                lstbxArtikel.DataSource = context.Artikels.ToList();
                lstbxArtikel.DisplayMember = "Bezeichnung";
                lstbxArtikel.ValueMember = "Id";//DBHelper.SelectData("select * from Artikel");
                lstbxDrucker.DataSource = context.Druckers.ToList();
                lstbxDrucker.DisplayMember = "Bezeichnung";
                lstbxDrucker.ValueMember = "Id";
                //DBHelper.SelectData("select * from Drucker");
            }
        }
 

        private void txtArtikel_TextChanged(object sender, EventArgs e)
        {
            using (var context = new DerContext())
            {
                var result = context.Artikels
                    .Where(a => a.Name.Contains(txtArtikel.Text))
                    .ToList();

                lstbxArtikel.DataSource = result;
                lstbxArtikel.DisplayMember = "Bezeichnung";   // was im ListBox angezeigt wird
                lstbxArtikel.ValueMember = "Id";       // optional: interner Wert
            }
                                                       //artikelBindingSource.Filter = string.Format("Name Like '%{0}%' ", txtArtikel.Text); //"Name like 'CF4%'";// + + "'";
                //lstbxArtikel.DataSource = DBHelper.SelectData("select * from Artikel where Name like '%" + txtArtikel.Text + "%'");
        }

        private void txtDrucker_TextChanged(object sender, EventArgs e)
        {
            using (var context = new DerContext())
            {
                var result = context.Druckers
                    .Where(d => d.Bezeichnung.Contains(txtDrucker.Text))
                    .ToList();

                lstbxDrucker.DataSource = result;
                lstbxDrucker.DisplayMember = "Bezeichnung";   // was im ListBox angezeigt wird
                lstbxDrucker.ValueMember = "Id";       // optional: interner Wert
            }
            //druckerBindingSource.Filter = string.Format("Bezeichnung Like '%{0}%' ", txtDrucker.Text);
            //lstbxDrucker.DataSource = DBHelper.SelectData("select * from Drucker where Bezeichnung like '%" + txtDrucker.Text + "%'");
        }
        private void ErneuernAnzeige()
        {
            using (var context = new DerContext())
            {
                var auftraege = context.Auftrags
                    .Select(a => new
                    {
                        a.Id,
                        a.ErfDat,
                        ArtikelName = a.Artikel.Name,
                        DruckerBez = a.Drucker.Bezeichnung,
                        a.Status,
                        a.ErfUser
                    })
                    .OrderBy(a => a.Id)
                    .ToList();
                dgvAuftraege.DataSource = auftraege;
            }
        }
        private void btnErfassen_Click(object sender, EventArgs e)
        {
            using (var context = new DerContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var artikel = context.Artikels.Find((int)lstbxArtikel.SelectedValue);
                        var drucker = context.Druckers.Find((int)lstbxDrucker.SelectedValue);
                        // Auftrag anlegen
                        var neuerAuftrag = new Auftrag
                        {
                            Drucker = drucker,
                            Artikel = artikel,
                            Status = "Reserviert",
                            ErfUser = Environment.UserName,
                            ErfDat = DateTime.Today   // entspricht CONVERT(date, SYSDATETIME())
                        };

                        context.Auftrags.Add(neuerAuftrag);

                        // Artikel aktualisieren
                        //var artikel = context.Artikels.Find((int)lstbxArtikel.SelectedValue);
                        if (artikel != null)
                        {
                            artikel.Reserviert += 1;
                        }

                        // Änderungen speichern
                        context.SaveChanges();

                        // Transaktion committen
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }

            ErneuernAnzeige();
        }

        private void btnStatus_Click(object sender, EventArgs e)
        {
            int firstDisplayedRowIndex = dgvAuftraege.FirstDisplayedScrollingRowIndex;
            int currentRowIndex = dgvAuftraege.CurrentCell.RowIndex;

            int selectedAuftragsId = (int)dgvAuftraege.SelectedRows[0].Cells["Id"].Value;
            string selectedStatus = dgvAuftraege.SelectedRows[0].Cells["colStatus"].Value.ToString();

            string newStatus;
            switch (selectedStatus)
            {
                case "Reserviert": newStatus = "Bereit"; break;
                case "Bereit": newStatus = "Ausgeliefert"; break;
                case "Ausgeliefert": newStatus = "Ausgewechselt"; break;
                default: newStatus = "Ausgewechselt"; break;
            }

            using (var context = new DerContext())
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    // Auftrag laden
                    var auftrag = context.Auftrags
                        .Include(a => a.Artikel) // Artikel gleich mitladen
                        .FirstOrDefault(a => a.Id == selectedAuftragsId);

                    if (auftrag != null)
                    {
                        // Status ändern
                        auftrag.Status = newStatus;

                        // Nebenwirkung: wenn Status "Bereit", Artikelbestand anpassen
                        if (newStatus == "Bereit" && auftrag.Artikel != null)
                        {
                            auftrag.Artikel.Bestand -= 1;
                            auftrag.Artikel.Reserviert -= 1;
                        }

                        context.SaveChanges();
                        transaction.Commit();
                    }
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }

            ErneuernAnzeige();

            // Anzeige wiederherstellen
            dgvAuftraege.CurrentCell = dgvAuftraege.Rows[currentRowIndex].Cells[0];
            dgvAuftraege.FirstDisplayedScrollingRowIndex = firstDisplayedRowIndex;
        }


        private void dgvAuftraege_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            var row = dgvAuftraege.Rows[e.RowIndex];
            var cellValue = row.Cells["colStatus"].Value;
            Color color;

            switch (cellValue)
            {
                case "Reserviert": color = Color.Blue; break;
                case "Bereit": color = Color.Green; break;
                case "Ausgeliefert": color = Color.DarkRed; break;
                default: color = Color.Black; break;
            }
            
            row.DefaultCellStyle.ForeColor = color;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //DataTable dt = (DataTable)dgvAuftraege.DataSource;
            //dt.TableName = "Auftraege";
            //dt.WriteXml("auftraege_export44.xml", XmlWriteMode.IgnoreSchema);
            //DataSet ds = new DataSet();
            //ds.ReadXmlSchema("auftraege2.xsd");//Tables[0] ist schon initialisiert
            //ds.ReadXml("auftraege_export44.xml");
            //dataGridView1.DataSource = ds.Tables[0].Copy();
            //ds.ReadXml("auftraege_export66.xml");
            
            //dataGridView2.DataSource = ds.Tables[0];
            //auftraege_export332.xml

            //DataSet ds2 = new DataSet();
            //ds2.ReadXmlSchema("auftraege2.xsd");
            //ds2.ReadXml("auftraege_export332.xml");
            //DataTable dt3= ds2.Tables[0];
            //dt3.Merge(ds.Tables[0]);
            //dataGridView1.DataSource = dt3;
            //NewDataSet nds = new NewDataSet();
            //nds.ReadXml("auftraege_export44.xml");
            //dataGridView1.DataSource = nds.Tables[0];
        }
    }

        /*private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if ((Application.OpenForms["Form2"]) == null)
            {

                var einform = new Form2();
                einform.Visible = true;
            }
        }*/
    }

