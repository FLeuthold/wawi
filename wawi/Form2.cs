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
    public partial class Form2: Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            NumericColumn col = new NumericColumn();
            this.dataGridView1.Columns.Add(col);
            this.dataGridView1.RowCount = 5;
            foreach (DataGridViewRow row in this.dataGridView1.Rows)
            {
                row.Cells[0].Value = DateTime.Now;
            }
        }
    }
}
