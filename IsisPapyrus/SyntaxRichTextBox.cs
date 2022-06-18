using Antlr4.Runtime;
using IsisPapyrus;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OsirisInterpreter
{
    //Klasa dziedzicząca po RichTextBox z dodatkowymi funkcjami
    public class SyntaxRichTextBox : System.Windows.Forms.RichTextBox
    {
        //Tutaj jest blok kodu z https://stackoverflow.com/questions/192413/how-do-you-prevent-a-richtextbox-from-refreshing-its-display
        //Dodaje metody do zatrzymywania odświeżania textBoxa podczas kolorowania, żeby tekst nie migał
        private const int WM_USER = 0x0400;
        private const int EM_SETEVENTMASK = (WM_USER + 69);
        private const int WM_SETREDRAW = 0x0b;
        private IntPtr OldEventMask;

        
        
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        public void BeginUpdate()
        {
            SendMessage(this.Handle, WM_SETREDRAW, IntPtr.Zero, IntPtr.Zero);
            OldEventMask = (IntPtr)SendMessage(this.Handle, EM_SETEVENTMASK, IntPtr.Zero, IntPtr.Zero);
        }

        public void EndUpdate()
        {
            SendMessage(this.Handle, WM_SETREDRAW, (IntPtr)1, IntPtr.Zero);
            SendMessage(this.Handle, EM_SETEVENTMASK, IntPtr.Zero, OldEventMask);
        }

        //Co się dzieje w Evencie jak ktoś zmieni tekst w okienku, czyli np jak użytkownik coś wpisze
        protected override void OnTextChanged(EventArgs e)
        {
            BeginUpdate();
            int cursorLoc = SelectionStart;
            clearHighlight();
            BetterHighlight();
            Select(cursorLoc, 0);
            EndUpdate();
        }

        private void BetterHighlight()
        {
            var input = CharStreams.fromString(this.Text);
            IsisLexer lexer = new IsisLexer(input);
            while (true)
            {
                var token = lexer.NextToken();
                if (token.Type == -1) break;
                int lineIdx = token.Line - 1;
                int charIdx = actualPosition(lineIdx, token.Column);
                int idx = this.GetFirstCharIndexFromLine(lineIdx) + charIdx;
                int length = token.Text.ToCharArray().Length;
                Select(idx, length);
                Color c = ColorMap.getTokenColor(token.Type);
                SelectionColor = c;
                SelectionLength = 0;
            }

        }

        private int actualPosition(int lineID, int idx)
        {
            var line = Lines[lineID];
            int i = 0;
            while (i < idx)
            {
                if (Char.IsHighSurrogate(line[i]))
                {
                    idx++;
                }
                i++;
            }
            return idx;
        }

        private void clearHighlight()
        {
            SelectAll();
            SelectionColor = Color.Black;
            SelectionLength = 0;
        }
    }
}
