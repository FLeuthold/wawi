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
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            TabControl tabControl = new TabControl
            {
                Dock = DockStyle.Fill
            };
            this.Controls.Add(tabControl);

            // Add FormAuftraege as a Tab
            
            FormAuftraege formAuftraege = new FormAuftraege
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };
            TabPage auftraegeTab = new TabPage("Aufträge");
            auftraegeTab.Controls.Add(formAuftraege);
            tabControl.TabPages.Add(auftraegeTab);
            formAuftraege.Show();

            // Add FormWareneingang as a Tab
            FormWareneingang formWareneingang = new FormWareneingang
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };
            TabPage wareneingangTab = new TabPage("Wareneingang");
            wareneingangTab.Controls.Add(formWareneingang);
            tabControl.TabPages.Add(wareneingangTab);
            formWareneingang.Show();
            // Add FormWareneingang as a Tab


            FormBestellvorschlag formBestellvorschlag = new FormBestellvorschlag
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };
            TabPage bestellvorschlagTab = new TabPage("Bestellvorschlag");
            bestellvorschlagTab.Controls.Add(formBestellvorschlag);
            tabControl.TabPages.Add(bestellvorschlagTab);
            formBestellvorschlag.Show();


            FormVerbrauch formVerbrauch = new FormVerbrauch
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };
            TabPage verbrauchTab = new TabPage("Verbrauch");
            verbrauchTab.Controls.Add(formVerbrauch);
            tabControl.TabPages.Add(verbrauchTab);
            formVerbrauch.Show();
        }
    }
}
