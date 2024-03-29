﻿using Antlr4.Runtime;
using IsisPapyrus.Exceptions;
using IsisPapyrus.InterpreterRuntime;
using IsisPapyrus.VisitorClasses;
using System;
using System.Windows.Forms;
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
                this.syntaxRichTextBox1.Text = System.IO.File.ReadAllText(this.openFileDialog1.FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var input = CharStreams.fromString(this.syntaxRichTextBox1.Text);
            IsisLexer lex = new IsisLexer(input);
            CommonTokenStream tokens = new CommonTokenStream(lex);
            IsisParser parser = new IsisParser(tokens);
            ProgramContext start = parser.program();

            this.textBox1.Text = start.ToStringTree(parser);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.saveFileDialog1.DefaultExt = "*.isis";
            this.saveFileDialog1.Filter = "ISIS Files | *.isis";
            this.saveFileDialog1.RestoreDirectory = true;

            if (this.saveFileDialog1.ShowDialog() == DialogResult.OK
                && this.saveFileDialog1.FileName.Length > 0)
            {
                System.IO.File.WriteAllText(this.saveFileDialog1.FileName, this.syntaxRichTextBox1.Text);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.textBox1.Clear();
            RuntimeConsole rc = new RuntimeConsole();
            rc.Show();

            IsisProgram prog = new IsisProgram(ref rc);
            IsisVisitor vis = new IsisVisitor(prog);
            try
            {
                var input = CharStreams.fromString(this.syntaxRichTextBox1.Text);
                IsisLexer lex = new IsisLexer(input);
                lex.RemoveErrorListeners();
                lex.AddErrorListener(ThrowingErrorListener.Instance);
                CommonTokenStream tokens = new CommonTokenStream(lex);
                IsisParser parser = new IsisParser(tokens);
                parser.RemoveErrorListeners();
                parser.AddErrorListener(ThrowingErrorListener.Instance);
                ProgramContext start = parser.program();
                vis.Visit(start);
            } catch (InterpreterException ex)
            {
                rc.printText(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.textBox1.Clear();
            var input = CharStreams.fromString(this.syntaxRichTextBox1.Text);
            IsisLexer lexer = new IsisLexer(input);
            while (true)
            {
                var token = lexer.NextToken();
                if (token.Type == -1) break;
                this.textBox1.AppendText(token.Type.ToString() + "  ");
            }
        }

        private void keyboardUsed(object sender, EventArgs e)
        {
            var args = e as EgyptianKeyboard.CharacterSendEventArgs;
            this.syntaxRichTextBox1.SelectedText = args.sign;
        }
    }
}