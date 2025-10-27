using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Globalization;
using System.Windows.Forms;
namespace WindowsFormsApp2
{

    public class NumericColumn : DataGridViewColumn
    {
        public NumericColumn() : base(new NumericCell())
        {
        }

        public override DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }
            set
            {
                // Ensure that the cell used for the template is a NumericCell.
                if (value != null &&
                    !value.GetType().IsAssignableFrom(typeof(NumericCell)))
                {
                    throw new InvalidCastException("Must be a NumericCell");
                }
                base.CellTemplate = value;
            }
        }
    }

    public class NumericCell : DataGridViewTextBoxCell
    {
        public NumericCell()
        {
            Value = "0.000";
        }

        public override Type EditType => typeof(NumericEditingControl);
        public override Type ValueType => typeof(string);
        public override object DefaultNewRowValue => "0.000";
    }

    class NumericEditingControl : TextBox, IDataGridViewEditingControl
    {
        private DataGridView dataGridView;
        private bool valueChanged;
        private int rowIndex;
        private bool isEntry;

        protected override void OnEnter(EventArgs e)
        {

            if (decimal.TryParse(this.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out decimal value))
            {

                if (this.Text.StartsWith("0"))
                {
                    this.Text = this.Text.Remove(0, 1);

                }
            }
            isEntry = true;
        }

        protected override void OnLeave(EventArgs e)
        {
            if (this.Text.StartsWith("."))
            {
                this.Text = "0" + this.Text;
            }
        }


        public NumericEditingControl()
        {
            this.TextAlign = HorizontalAlignment.Right;
        }

        public object EditingControlFormattedValue
        {
            get { return this.Text; }
            set { this.Text = value?.ToString() ?? "0.000"; }
        }

        public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
        {

            return this.Text;
        }

        public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
        {
            this.Font = dataGridViewCellStyle.Font;
            this.ForeColor = dataGridViewCellStyle.ForeColor;
            this.BackColor = dataGridViewCellStyle.BackColor;
        }

        public int EditingControlRowIndex
        {
            get { return rowIndex; }
            set { rowIndex = value; }
        }

        public bool EditingControlWantsInputKey(Keys key, bool dataGridViewWantsInputKey)
        {
            return key == Keys.Left || key == Keys.Right || key == Keys.Home || key == Keys.End || key == Keys.Back || key == Keys.Delete;
        }

        public void PrepareEditingControlForEdit(bool selectAll)
        {
            if (selectAll)
            {
                this.SelectAll();
            }
        }

        public bool RepositionEditingControlOnValueChange => false;

        public DataGridView EditingControlDataGridView
        {
            get { return dataGridView; }
            set { dataGridView = value; }
        }

        public bool EditingControlValueChanged
        {
            get { return valueChanged; }
            set
            {
                valueChanged = value;
                this.EditingControlDataGridView?.NotifyCurrentCellDirty(value);
            }

        }

        public Cursor EditingPanelCursor => base.Cursor;

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            int cursorPosition = this.SelectionStart;
            int dotIndex = this.Text.IndexOf('.');
            if ((ModifierKeys & Keys.Control) == Keys.Control && e.KeyChar == 22) return;
            if ((!char.IsDigit(e.KeyChar) && e.KeyChar != '.') || (cursorPosition >= this.TextLength && char.IsDigit(e.KeyChar)))//)
            {
                e.Handled = true;
                return;
            }

            if (e.KeyChar == '.')
            {

                if (cursorPosition <= dotIndex)
                {
                    this.SelectionStart = dotIndex + 1;
                }
                else
                {
                    this.SelectionStart = dotIndex;
                }
                e.Handled = true;
            }
            if (char.IsDigit(e.KeyChar))
            {
                if(isEntry)
                {
                    isEntry = false;
                    this.Text = ".000";
                }
                this.Text = this.Text.Insert(cursorPosition, e.KeyChar.ToString());

                if (decimal.TryParse(this.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out decimal value))
                {
                    this.Text = value.ToString(".000", CultureInfo.InvariantCulture);
                }
                this.SelectionStart = Math.Min(cursorPosition + 1, this.Text.Length);
                e.Handled = true;
            }
            EditingControlValueChanged = true;

        }

        // Handle the whole "delete with backspace" thing
        protected override void OnKeyDown(KeyEventArgs e)
        {
            
            
            if ((e.KeyCode == Keys.Back)|| e.KeyCode == Keys.Delete)
            {

                int cursorPosition = this.SelectionStart;
                int dotIndex = this.Text.IndexOf('.');

                //this.Text.Length

                if (this.SelectionStart + this.SelectionLength > dotIndex)
                {
                    int sellength = this.SelectionLength;
                    int cursPos = this.SelectionStart;
                    if (sellength == 0)
                    {
                        sellength = 1;
                        cursPos--;
                    }

                    this.Text = this.Text.Remove(cursPos, sellength);
                    if (!this.Text.Contains("."))
                    {
                        this.Text = this.Text.Insert(cursPos, ".");
                    }
                    int i = 3 - (this.Text.Length - this.Text.IndexOf('.') - 1);//anzahl gelöschte nachkommastellen

                    for (int j = 0; j < i; j++)
                    {
                        this.Text = this.Text + "0";
                    }
                    this.SelectionStart = Math.Max(cursPos, 0);

                }
                else if (cursorPosition == dotIndex + 1)
                {
                    this.SelectionStart = Math.Max(cursorPosition - 1, 0);
                }
                else
                {
                    if(this.SelectionLength > 0)
                    {
                        this.Text = this.Text.Remove(cursorPosition, this.SelectionLength);
                        //cursorPosition = this.SelectionStart;
                        cursorPosition++;
                    }
                    else
                    {
                        //if(this.SelectionStart >0)
                            this.Text = this.Text.Remove(cursorPosition - 1, 1);
                        
                    }
                        //
                        
                    if (cursorPosition > dotIndex + 1)
                    {
                        this.Text = this.Text + "0";
                    }
                    this.SelectionStart = Math.Max(cursorPosition - 1, 0);
                }
                e.Handled = true;
                EditingControlValueChanged = true;
            }
        }


        protected  void OnKeyDown_bck(KeyEventArgs e)
        {
            int cursorPosition = this.SelectionStart;
            int dotIndex = this.Text.IndexOf('.');

            if (e.KeyCode == Keys.Delete)
            {
                e.Handled = true;
                EditingControlValueChanged = true;
                if (this.SelectionLength == this.Text.Length)
                {
                    this.Text = ".000";
                    this.SelectionStart = 0;
                }


                return;
            }
            if (e.KeyCode == Keys.Back && this.SelectionStart > 0)
            {
                //this.Text.Length

                if (this.SelectionStart < dotIndex + 1 && this.SelectionStart + this.SelectionLength > dotIndex)
                {
                    //int i = dotIndex- this.SelectionLength - this.SelectionLength;//anzahl gelöschte nachkommastellen
                    //this.SelectionLength = dotIndex - this.SelectionStart;

                    this.Text = this.Text.Remove(cursorPosition, this.SelectionLength).Insert(cursorPosition, ".");

                    int i = 3 - (this.Text.Length - this.Text.IndexOf('.') - 1);

                    for (int j = 0; j < i; j++)
                    {
                        this.Text = this.Text + "0";
                    }
                }
                if (cursorPosition == dotIndex + 1)
                {
                    this.SelectionStart = Math.Max(cursorPosition - 1, 0);
                }
                else
                {
                    if (this.SelectionLength > 0)
                    {
                        this.Text = this.Text.Remove(cursorPosition, this.SelectionLength);
                        //cursorPosition = this.SelectionStart;
                        cursorPosition++;
                    }
                    else
                    {
                        this.Text = this.Text.Remove(cursorPosition - 1, 1);

                    }
                    //

                    if (cursorPosition > dotIndex + 1)
                    {
                        this.Text = this.Text + "0";
                    }
                    this.SelectionStart = Math.Max(cursorPosition - 1, 0);
                }
                e.Handled = true;
                EditingControlValueChanged = true;
            }
        }
        //Handle Ctrl + V
        protected override void WndProc(ref Message m)
        {
            const int WM_PASTE = 0x0302;
            if (m.Msg == WM_PASTE)
            {
                if (Clipboard.ContainsText())
                {
                    string pastedText = Clipboard.GetText();
                    if (decimal.TryParse(pastedText, NumberStyles.Float, CultureInfo.InvariantCulture, out decimal value))
                    {

                        this.Text = Math.Round(value, 3).ToString(".000", CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        this.Text = ".000";
                    }
                    EditingControlValueChanged = true;
                }
                return;
            }
            base.WndProc(ref m);
        }
    }

}
