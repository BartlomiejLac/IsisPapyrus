using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsisPapyrus.Exceptions
{
    internal class ThrowingErrorListener : BaseErrorListener, IAntlrErrorListener<int>
    {
        public static ThrowingErrorListener Instance = new ThrowingErrorListener();
        public override void SyntaxError(TextWriter output, IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        {
            this.SyntaxError(output, recognizer, 0, line, charPositionInLine, msg, e);
        }

        public void SyntaxError(TextWriter output, IRecognizer recognizer, int offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        {
            throw new ParseException(line, charPositionInLine, msg);
        }
    }
}
