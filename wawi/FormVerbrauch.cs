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
            // TODO: Diese Codezeile lädt Daten in die Tabelle "verbrauchDS.ViewVerbrauch". Sie können sie bei Bedarf verschieben oder entfernen.
            this.viewVerbrauchTableAdapter.Fill(this.verbrauchDS.ViewVerbrauch);
            //reportViewer1.DataBindings.Add()

            this.reportViewer1.RefreshReport();
        }
    }
}
