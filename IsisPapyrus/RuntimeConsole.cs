using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IsisPapyrus
{
    public partial class RuntimeConsole : Form
    {
        public RuntimeConsole()
        {
            InitializeComponent();
        }

        private void resized(object sender, EventArgs e)
        {
            this.richTextBox1.Size = this.Size;
        }

        public void printText(string text)
        {
            this.richTextBox1.AppendText(text);
            var charr = text.ToCharArray();
            for (int i = 0; i < charr.Length; i++)
            {
                var c = charr[i];
                if (Char.IsHighSurrogate(c))
                {
                    this.richTextBox1.Select(this.richTextBox1.GetFirstCharIndexFromLine(this.richTextBox1.Lines.Length - 1) + i, 2);
                    this.richTextBox1.SelectionFont = new Font(this.Font.FontFamily,
                                                                this.Font.Size + 12,
                                                                FontStyle.Bold,
                                                                this.Font.Unit,
                                                                this.Font.GdiCharSet,
                                                                this.Font.GdiVerticalFont);
                }
            }
            this.richTextBox1.AppendText(Environment.NewLine);
        }

        private void enterPressed(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return) this.Close();
            
        }
    }
}
