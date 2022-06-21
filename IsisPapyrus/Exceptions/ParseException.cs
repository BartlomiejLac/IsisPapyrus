using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsisPapyrus.Exceptions
{
    internal class ParseException : InterpreterException
    {
        public ParseException(int line, int charIndex, string msg) : base(line, charIndex, msg) { }
    }
}
