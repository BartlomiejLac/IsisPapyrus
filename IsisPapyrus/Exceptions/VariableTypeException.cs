using IsisPapyrus.InterpreterRuntime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsisPapyrus.Exceptions
{
    internal class VariableTypeException : Exception
    {
        public VariableTypeException(varType v) : base(v.ToString()) { }
    }
}
