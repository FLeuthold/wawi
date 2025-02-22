using System;
using System.Globalization;
using System.Windows.Forms;

public class NumericTextBox : TextBox
{
    public NumericTextBox()
    {
        this.Text = "0.000";
        this.TextAlign = HorizontalAlignment.Right;
        
    }
    

    protected override void OnEnter(EventArgs e)
    {
        
        if (decimal.TryParse(this.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out decimal value))
        {

            if (this.Text.StartsWith("0"))
            {
                this.Text = this.Text.Remove(0, 1);
                
            }
        }
    }

    protected override void OnLeave(EventArgs e)
    {
        if (this.Text.StartsWith("."))
        {
            this.Text = "0" + this.Text;
        }
    }

    protected override void OnKeyPress(KeyPressEventArgs e)
    {
        int cursorPosition = this.SelectionStart;
        int dotIndex = this.Text.IndexOf('.');
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
            
            this.Text = this.Text.Insert(cursorPosition, e.KeyChar.ToString());

            if(decimal.TryParse(this.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out decimal value))
            {
                this.Text = value.ToString(".000", CultureInfo.InvariantCulture);
            } 
            this.SelectionStart = Math.Min(cursorPosition + 1, this.Text.Length);
            e.Handled = true;
        }

    }


    // Handle the whole "delete with backspace" thing
    protected override void OnKeyDown(KeyEventArgs e)
    {
        int cursorPosition = this.SelectionStart;
        int dotIndex = this.Text.IndexOf('.');
        if (e.KeyCode == Keys.Back && this.SelectionStart > 0 )
        {
            
            if (cursorPosition == dotIndex + 1)
            {
                this.SelectionStart = Math.Max(cursorPosition - 1, 0);                
            }
            else
            {
                this.Text = this.Text.Remove(cursorPosition - 1, 1);
                if (cursorPosition > dotIndex + 1)
                {
                    this.Text = this.Text + "0";
                }
                this.SelectionStart = Math.Max(cursorPosition - 1, 0);
            }
            e.Handled = true;
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
            }
            return;
        }
        base.WndProc(ref m);
    }
}
