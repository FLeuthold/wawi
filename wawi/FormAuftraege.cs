using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            dgvAuftraege.DataSource = DBHelper.SelectData("select * from [View] order by Id desc");
            lstbxArtikel.DataSource = DBHelper.SelectData("select * from Artikel");
            lstbxDrucker.DataSource = DBHelper.SelectData("select * from Drucker");
        }
 

        private void txtArtikel_TextChanged(object sender, EventArgs e)
        {

            //artikelBindingSource.Filter = string.Format("Name Like '%{0}%' ", txtArtikel.Text); //"Name like 'CF4%'";// + + "'";
            lstbxArtikel.DataSource = DBHelper.SelectData("select * from Artikel where Name like '%" + txtArtikel.Text + "%'");
        }

        private void txtDrucker_TextChanged(object sender, EventArgs e)
        {
            //druckerBindingSource.Filter = string.Format("Bezeichnung Like '%{0}%' ", txtDrucker.Text);
            lstbxDrucker.DataSource = DBHelper.SelectData("select * from Drucker where Bezeichnung like '%" + txtDrucker.Text + "%'");
        }

        private void btnErfassen_Click(object sender, EventArgs e)
        {
            string queryString = @"
BEGIN TRANSACTION;


insert into Auftrag (DruckerId, ArtikelId, Status , ErfUser, ErfDat) 
values (@SelectedDruckerId,@SelectedArtikelId, 'Reserviert', @WindowsUser , CONVERT (date, SYSDATETIME()));

update Artikel set Reserviert = Reserviert + 1 where Id = @SelectedArtikelId; 

COMMIT;";

            //" + lstbxDrucker.SelectedValue + ", " + lstbxArtikel.SelectedValue + "Environment.UserName
            using (SqlConnection sqlConnection = new SqlConnection(Globals.ConnStr)) { 
                using (SqlCommand sqlCommand = new SqlCommand(queryString, sqlConnection))
                {
                    sqlCommand.Parameters.Add("@SelectedDruckerId", SqlDbType.Int).Value = lstbxDrucker.SelectedValue;
                    sqlCommand.Parameters.Add("@SelectedArtikelId", SqlDbType.Int).Value = lstbxArtikel.SelectedValue;
                    sqlCommand.Parameters.Add("@WindowsUser", SqlDbType.VarChar).Value = Environment.UserName;
                    sqlCommand.CommandType = CommandType.Text;
                    sqlConnection.Open();
                    
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }

            }

            //this.viewTableAdapter.Fill(this.database1DataSet1.View);
            dgvAuftraege.DataSource = DBHelper.SelectData("select * from [View] order by Id desc");

        }

        private void btnStatus_Click(object sender, EventArgs e)
        {
            //int scrollOffset = dgvAuftraege.HorizontalScrollingOffset;
            int firstDisplayedRowIndex = dgvAuftraege.FirstDisplayedScrollingRowIndex;
            int currentRowIndex = dgvAuftraege.CurrentCell.RowIndex;
            int SelectedAuftragsId = Int32.Parse(dgvAuftraege.SelectedRows[0].Cells["Id"].Value.ToString());
            string SelectedStatus = dgvAuftraege.SelectedRows[0].Cells["colStatus"].Value.ToString();
            string NewStatus = "";
            //StatusAuftrag status;
            //status = status + 1;
            switch (SelectedStatus)
            {
                case "Reserviert": NewStatus = "Bereit";
                    break;
                case "Bereit": NewStatus = "Ausgeliefert";
                    break;
                case "Ausgeliefert": NewStatus = "Ausgewechselt";
                    break;
                default: NewStatus = "Ausgewechselt";
                    break;
            }
                 
            

            string queryString = @"
update Auftrag set Status=@NewStatus where Id = @AuftragsId;

IF @NewStatus = 'Bereit'
Update Artikel set Bestand = Bestand - 1, Reserviert = Reserviert - 1 where Id =
(select ArtikelId from Auftrag where Id = @AuftragsId)
";

            //" + lstbxDrucker.SelectedValue + ", " + lstbxArtikel.SelectedValue + "Environment.UserName
            using (SqlConnection sqlConnection = new SqlConnection(Globals.ConnStr))
            {
                using (SqlCommand sqlCommand = new SqlCommand(queryString, sqlConnection))
                {
                    sqlCommand.Parameters.Add("@AuftragsId", SqlDbType.Int).Value = SelectedAuftragsId;
                    sqlCommand.Parameters.Add("@NewStatus", SqlDbType.VarChar).Value = NewStatus;
                    sqlCommand.CommandType = CommandType.Text;
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }

            }

            //this.viewTableAdapter.Fill(this.database1DataSet1.View);
            dgvAuftraege.DataSource = DBHelper.SelectData("select * from [View] order by Id desc");
            dgvAuftraege.CurrentCell = dgvAuftraege.Rows[currentRowIndex].Cells[0];
            //dgvAuftraege.HorizontalScrollingOffset = scrollOffset;
            dgvAuftraege.FirstDisplayedScrollingRowIndex = firstDisplayedRowIndex;
        }

        private void dgvAuftraege_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            var row = dgvAuftraege.Rows[e.RowIndex];
            var cellValue = row.Cells["colStatus"].Value;
            Color color;

            switch (cellValue)
            {
                case "Reserviert":
                    color = Color.Blue;
                    break;
                case "Bereit":
                    color = Color.Green;
                    break;
                case "Ausgeliefert":
                    color = Color.DarkRed;
                    break;
                default:
                    color = Color.Black;
                    break;
            }
            
            row.DefaultCellStyle.ForeColor = color;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //DataTable dt = (DataTable)dgvAuftraege.DataSource;
            //dt.TableName = "Auftraege";
            //dt.WriteXml("auftraege_export44.xml", XmlWriteMode.IgnoreSchema);
            DataSet ds = new DataSet();
            ds.ReadXmlSchema("auftraege2.xsd");//Tables[0] ist schon initialisiert
            ds.ReadXml("auftraege_export44.xml");
            //dataGridView1.DataSource = ds.Tables[0].Copy();
            ds.ReadXml("auftraege_export66.xml");
            
            dataGridView2.DataSource = ds.Tables[0];
            //auftraege_export332.xml

            DataSet ds2 = new DataSet();
            ds2.ReadXmlSchema("auftraege2.xsd");
            ds2.ReadXml("auftraege_export332.xml");
            DataTable dt3= ds2.Tables[0];
            dt3.Merge(ds.Tables[0]);
            dataGridView1.DataSource = dt3;
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

