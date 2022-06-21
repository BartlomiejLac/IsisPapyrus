using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsisPapyrus.Exceptions
{
    internal class LoopContinueException : InterpreterException
    {
        public LoopContinueException(int line, int charIndex) : base(line, charIndex, "Continue statement outside of loop") { }
    }
}
