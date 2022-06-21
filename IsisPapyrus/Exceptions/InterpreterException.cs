using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsisPapyrus.Exceptions
{
    internal class InterpreterException : Exception
    {
        public InterpreterException(int line, int charIndex, string msg) : base(msg + " at " + line.ToString() + ":" + charIndex.ToString()) { }
    }
}
