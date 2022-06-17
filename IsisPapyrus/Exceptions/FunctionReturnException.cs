using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsisPapyrus.Exceptions
{
    internal class FunctionReturnException : Exception
    {
        public object? returnable;
        public FunctionReturnException(object rt) : base("return") 
        {
            returnable = rt;
        }
    }
}
