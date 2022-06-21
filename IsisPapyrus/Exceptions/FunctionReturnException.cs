using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsisPapyrus.Exceptions
{
    internal class FunctionReturnException : InterpreterException
    {
        public object? returnable;
        public FunctionReturnException(object rt, int line, int charIndex) : base(line, charIndex, "Return statement outside of function") 
        {
            returnable = rt;
        }
    }
}
