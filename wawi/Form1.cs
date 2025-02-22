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
        private NumericTextBox textBox1;
        public Form1()
        {
            InitializeComponent();

            this.textBox1 = new NumericTextBox();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(499, 46);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(136, 22);
            this.textBox1.TabIndex = 7;
            //this.textBox1.Leave += TextBox1_Leave;
            this.Controls.Add(this.textBox1);
        }

        private void TextBox1_Leave(object sender, EventArgs e)
        {
            
        }

        string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["wawi.Properties.Settings.Database1ConnectionString"].ConnectionString;
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: Diese Codezeile lädt Daten in die Tabelle "database1DataSet1.View". Sie können sie bei Bedarf verschieben oder entfernen.
            this.viewTableAdapter.Fill(this.database1DataSet1.View);
            // TODO: Diese Codezeile lädt Daten in die Tabelle "database1DataSetDrucker.Drucker". Sie können sie bei Bedarf verschieben oder entfernen.
            this.druckerTableAdapter.Fill(this.database1DataSetDrucker.Drucker);
            // TODO: Diese Codezeile lädt Daten in die Tabelle "database1DataSet.Artikel". Sie können sie bei Bedarf verschieben oder entfernen.
            this.artikelTableAdapter.Fill(this.database1DataSet.Artikel);

        }

        private void txtArtikel_TextChanged(object sender, EventArgs e)
        {
            artikelBindingSource.Filter = string.Format("Name Like '%{0}%' ", txtArtikel.Text); //"Name like 'CF4%'";// + + "'";
        }

        private void txtDrucker_TextChanged(object sender, EventArgs e)
        {
            druckerBindingSource.Filter = string.Format("Bezeichnung Like '%{0}%' ", txtDrucker.Text);
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

            this.viewTableAdapter.Fill(this.database1DataSet1.View);

        }

        private void btnStatus_Click(object sender, EventArgs e)
        {
            int SelectedAuftragsId = Int32.Parse(dgvAuftraege.SelectedRows[0].Cells[0].Value.ToString());
            string SelectedStatus = dgvAuftraege.SelectedRows[0].Cells[4].Value.ToString();
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

            this.viewTableAdapter.Fill(this.database1DataSet1.View);
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            textBox2.Text = "0" + textBox2.Text;
        }

        /*private void txtNumberinput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtNumberinput_Validating(object sender, CancelEventArgs e)
        {
            decimal value;
            decimal.TryParse(txtNumberinput.Text, out value);



            txtNumberinput.Text = value.ToString("N3");
        }*/
    }
}
