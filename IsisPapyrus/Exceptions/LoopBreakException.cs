using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsisPapyrus.Exceptions
{
    internal class LoopBreakException : InterpreterException
    {
        public LoopBreakException(int line, int charIndex) : base(line, charIndex, "Break statement outside of loop") { }
    }
}
