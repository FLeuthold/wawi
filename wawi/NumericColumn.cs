using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Globalization;
using System.Windows.Forms;
namespace wawi
{

    public class NumericColumn : DataGridViewColumn
    {
        public NumericColumn() : base(new NumericCell())
        {
        }
    }

    public class NumericCell : DataGridViewTextBoxCell
    {
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
            base.OnLeave(e);
        }


        public NumericEditingControl()
        {
            this.TextAlign = HorizontalAlignment.Right;
        }

        public object EditingControlFormattedValue
        {
            get { return this.Text; }
            set { this.Text = value?.ToString();
            }
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                if (this.Text.StartsWith("."))
                {
                    this.Text = "0" + this.Text;
                }

            }

            return base.ProcessDialogKey(keyData);
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
                if (isEntry)
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
            if (e.KeyCode != Keys.Back && e.KeyCode != Keys.Delete)
            {
                base.OnKeyDown(e);
                return;
            }

            string text = this.Text;
            int cursor = this.SelectionStart;
            int length = this.SelectionLength;
            int dotIndex = text.IndexOf('.');

            if (dotIndex < 0)
            {
                // Ensure there's always a decimal point
                text += ".000";
                dotIndex = text.IndexOf('.');
            }

            // CASE 1: Deleting after the dot (decimal part)
            if (cursor + length > dotIndex)
            {
                int start = cursor;
                int removeLen = length > 0 ? length : 1;
                if (length == 0) start = Math.Max(cursor - 1, 0);

                text = text.Remove(start, Math.Min(removeLen, text.Length - start));

                // Ensure dot exists and pad zeros to keep 3 decimal places
                if (!text.Contains("."))
                    text = text.Insert(start, ".");

                int decimalsMissing = 3 - (text.Length - text.IndexOf('.') - 1);
                if (decimalsMissing > 0)
                    text = text.PadRight(text.Length + decimalsMissing, '0');

                this.Text = text;
                this.SelectionStart = Math.Max(start, 0);
            }
            // CASE 2: Deleting immediately after dot (prevent removing dot)
            else if (cursor == dotIndex + 1)
            {
                this.SelectionStart = Math.Max(cursor - 1, 0);
            }
            // CASE 3: Deleting before the dot (integer part)
            else
            {
                if (length > 0)
                {
                    text = text.Remove(cursor, Math.Min(length, text.Length - cursor));
                }
                else if (cursor > 0)
                {
                    text = text.Remove(cursor - 1, 1);
                    cursor--;
                }

                // Ensure 3 decimals after the dot
                int decimalsMissing = 3 - (text.Length - text.IndexOf('.') - 1);
                if (decimalsMissing > 0)
                    text = text.PadRight(text.Length + decimalsMissing, '0');

                this.Text = text;
                this.SelectionStart = Math.Max(cursor, 0);
            }

            e.Handled = true;
            EditingControlValueChanged = true;
        }
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
