using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            dataGridView1.DataSource = FormAuftraege.SelectData("SELECT b.Id, b.ErfDat, a.Name, b.Bestellt, b.Geliefert, b.Offen, b.Eingang FROM Artikel a INNER JOIN Bestellungen b ON a.Id = b.ArtikelId WHERE (((b.offen)>0)); ");
            dataGridView1.Columns["Id"].Visible = false;
        }

        private void btnEinbuchen_Click(object sender, EventArgs e)
        {
            string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["wawi.Properties.Settings.Database1ConnectionString"].ConnectionString;
            /*string queryString = @"
BEGIN TRANSACTION;

update Bestellungen set Geliefert = Geliefert + Eingang, Eingang = 0, MutUser = @WindowsUser, MutDat = GetDate() WHERE Eingang >0;
COMMIT;";*/

            //" + lstbxDrucker.SelectedValue + ", " + lstbxArtikel.SelectedValue + "Environment.UserName
            /*using (SqlConnection sqlConnection = new SqlConnection(connStr))
            {
                using (SqlCommand sqlCommand = new SqlCommand(queryString, sqlConnection))
                {
                    //sqlCommand.Parameters.Add("@SelectedDruckerId", SqlDbType.Int).Value = lstbxDrucker.SelectedValue;
                    //sqlCommand.Parameters.Add("@SelectedArtikelId", SqlDbType.Int).Value = lstbxArtikel.SelectedValue;
                    sqlCommand.Parameters.Add("@WindowsUser", SqlDbType.VarChar).Value = Environment.UserName;
                    sqlCommand.CommandType = CommandType.Text;
                    sqlConnection.Open();

                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }

            }*/

            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.IsNewRow) continue;

                    int id = (int)row.Cells["Id"].Value;
                    int eingang = (int)row.Cells["Eingang"].Value;

                    using (var cmd = new SqlCommand(
                        "UPDATE Bestellungen SET Eingang = @Eingang WHERE Id = @Id", conn))
                    {
                        cmd.Parameters.AddWithValue("@Eingang", eingang);
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.ExecuteNonQuery();
                    }
                }

                // Danach dein Sammelupdate:
                using (var cmd = new SqlCommand(
                    @"UPDATE Bestellungen
          SET Geliefert = Geliefert + Eingang,
              Eingang   = 0,
              MutUser   = @WindowsUser,
              MutDat    = GETDATE()
          WHERE Eingang > 0", conn))
                {
                    cmd.Parameters.AddWithValue("@WindowsUser", Environment.UserName);
                    cmd.ExecuteNonQuery();
                }
            }



            //this.viewTableAdapter.Fill(this.database1DataSet1.View);
            //FormAuftraege.SelectData("SELECT Bestellungen.ErfDat, Artikel.Name, Bestellungen.Bestellt, Bestellungen.Geliefert, Bestellungen.Offen, Bestellungen.Eingang FROM Artikel INNER JOIN Bestellungen ON Artikel.Id = Bestellungen.ArtikelId WHERE (((Bestellungen.Offen)>0)); ");
            dataGridView1.DataSource = FormAuftraege.SelectData("SELECT b.Id, b.ErfDat, a.Name, b.Bestellt, b.Geliefert, b.Offen, b.Eingang FROM Artikel a INNER JOIN Bestellungen b ON a.Id = b.ArtikelId WHERE (((b.offen)>0)); ");


        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            FormWareneingang_Load(sender, e);
        }
    }
}
