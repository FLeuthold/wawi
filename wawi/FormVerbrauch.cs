using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wawi
{
    public partial class FormVerbrauch : Form
    {
        public FormVerbrauch()
        {
            InitializeComponent();
        }

        private void FormVerbrauch_Load(object sender, EventArgs e)
        {
            LadeNeu();
        }

        private void reportViewer1_ReportRefresh(object sender, CancelEventArgs e)
        {
            LadeNeu();
            
        }
        private void LadeNeu()
        {
            DataTable dt = new DataTable();
            // ... hier deine Daten reinladen, z.B. mit SqlDataAdapter.Fill(dt)
            dt = DBHelper.SelectData("SELECT * FROM ViewVerbrauch");
            // ReportDataSource erzeugen
            var rds = new Microsoft.Reporting.WinForms.ReportDataSource("VerbrauchDataSet", dt);

            // Alte Datenquellen löschen und neue setzen
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.RefreshReport();
        }
    }
}
