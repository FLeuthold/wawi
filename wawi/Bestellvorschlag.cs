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
    public partial class frmBestellvorschlag: Form
    {
        public frmBestellvorschlag()
        {
            InitializeComponent();
        }
        string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["wawi.Properties.Settings.Database1ConnectionString"].ConnectionString;
        private void frmBestellvorschlag_Load(object sender, EventArgs e)
        {
            // TODO: Diese Codezeile lädt Daten in die Tabelle "database1DataSetBestellvorschlag.ViewBestellvorschlag". Sie können sie bei Bedarf verschieben oder entfernen.
            //this.viewBestellvorschlagTableAdapter.Fill(this.database1DataSetBestellvorschlag.ViewBestellvorschlag);
           dataGridView1.DataSource = Form1.SelectData("select * from [ViewBestellvorschlag]");
        }

        private void btnBestellvorschlag_Click(object sender, EventArgs e)
        {
            string queryString = @"
BEGIN TRANSACTION;
insert into Bestellungen (ArtikelId, Bestellt, ErfUser, ErfDat) SELECT Id, Bestellvorschlag, @Username, Date() FROM Artikel where Bestellvorschlag > 0;

update Artikel set Bestellt = Bestellt + Bestellvorschlag;
COMMIT;
";
            using (SqlConnection sqlConnection = new SqlConnection(connStr))
            {
                using (SqlCommand sqlCommand = new SqlCommand(queryString, sqlConnection))
                {
                    sqlCommand.Parameters.Add("@Username", SqlDbType.Int).Value = Environment.UserName;
                    sqlCommand.CommandType = CommandType.Text;
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }

            }

            //this.viewBestellvorschlagTableAdapter.Fill(this.database1DataSetBestellvorschlag.ViewBestellvorschlag);
            dataGridView1.DataSource = Form1.SelectData("select * from [ViewBestellvorschlag]");
        }
    }
}
