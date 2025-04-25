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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dgvAuftraege.AutoGenerateColumns = false;
        }

        private void TextBox1_Leave(object sender, EventArgs e)
        {
            
        }

        static string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["wawi.Properties.Settings.Database1ConnectionString"].ConnectionString;
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: Diese Codezeile lädt Daten in die Tabelle "database1DataSet1.View". Sie können sie bei Bedarf verschieben oder entfernen.
            //this.viewTableAdapter.Fill(this.database1DataSet1.View);
            // TODO: Diese Codezeile lädt Daten in die Tabelle "database1DataSetDrucker.Drucker". Sie können sie bei Bedarf verschieben oder entfernen.
            //this.druckerTableAdapter.Fill(this.database1DataSetDrucker.Drucker);
            // TODO: Diese Codezeile lädt Daten in die Tabelle "database1DataSet.Artikel". Sie können sie bei Bedarf verschieben oder entfernen.
            //this.artikelTableAdapter.Fill(this.database1DataSet.Artikel);
            dgvAuftraege.DataSource = SelectData("select * from [View]");
            lstbxArtikel.DataSource = SelectData("select * from Artikel");
            lstbxDrucker.DataSource = SelectData("select * from Drucker");
        }
        public static DataTable SelectData(string selectquery)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                using (SqlCommand sqlcmd = new SqlCommand())
                {
                    sqlcmd.Connection = conn;
                    sqlcmd.CommandText = selectquery;
                    SqlDataReader rd = sqlcmd.ExecuteReader();
                    
                    dt.Load(rd);
                    //dgvPunkte.DataSource = dt;
                    rd.Close();
                }
            }

            return dt;
        }

        private void txtArtikel_TextChanged(object sender, EventArgs e)
        {

            //artikelBindingSource.Filter = string.Format("Name Like '%{0}%' ", txtArtikel.Text); //"Name like 'CF4%'";// + + "'";
            lstbxArtikel.DataSource = SelectData("select * from Artikel where Name like '%" + txtArtikel.Text + "%'");
        }

        private void txtDrucker_TextChanged(object sender, EventArgs e)
        {
            //druckerBindingSource.Filter = string.Format("Bezeichnung Like '%{0}%' ", txtDrucker.Text);
            lstbxDrucker.DataSource = SelectData("select * from Drucker where Bezeichnung like '%" + txtDrucker.Text + "%'");
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
            using (SqlConnection sqlConnection = new SqlConnection(connStr)) { 
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
            dgvAuftraege.DataSource = SelectData("select * from View");

        }

        private void btnStatus_Click(object sender, EventArgs e)
        {
            int SelectedAuftragsId = Int32.Parse(dgvAuftraege.SelectedRows[0].Cells["Id"].Value.ToString());
            string SelectedStatus = dgvAuftraege.SelectedRows[0].Cells["colStatus"].Value.ToString();
            string NewStatus = "";
            switch(SelectedStatus)
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
            using (SqlConnection sqlConnection = new SqlConnection(connStr))
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
            dgvAuftraege.DataSource = SelectData("select * from [View]");
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if ((Application.OpenForms["Form2"]) == null)
            {

                var einform = new Form2();
                einform.Visible = true;
            }
        }

        private void lstbxDrucker_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
