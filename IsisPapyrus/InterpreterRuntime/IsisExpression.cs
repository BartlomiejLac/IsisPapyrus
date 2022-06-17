using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsisPapyrus.InterpreterRuntime
{
    internal abstract class IsisExpression : IsisInstruction
    {
        public bool returnsValue;
        public virtual object evaluate() { return null; }
    }
}
