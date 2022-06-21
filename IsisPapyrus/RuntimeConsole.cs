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
            this.textBox1.Size = this.Size;
        }

        public void printText(string text)
        {
            this.textBox1.AppendText(text);
            this.textBox1.AppendText(Environment.NewLine);
        }

        private void enterPressed(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return) this.Close();
        }
    }
}
