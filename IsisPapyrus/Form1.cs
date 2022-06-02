using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Antlr4.Runtime;
using static IsisParser;

namespace IsisPapyrus
{
  public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.DefaultExt = "*.isis";
            this.openFileDialog1.Filter = "ISIS Files | *.isis";
            this.openFileDialog1.RestoreDirectory = true;

            if (this.openFileDialog1.ShowDialog() == DialogResult.OK
                && this.openFileDialog1.FileName.Length > 0)
            {
                var input = CharStreams.fromPath(this.openFileDialog1.FileName);
                this.syntaxRichTextBox1.Text = input.ToString();
                IsisLexer lex = new IsisLexer(input);
                CommonTokenStream tokens = new CommonTokenStream(lex);
                IsisParser parser = new IsisParser(tokens);
                ProgramContext start = parser.program();

                this.textBox1.Text = start.ToStringTree(parser);
            }
        }
    }
}