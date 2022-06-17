using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsisPapyrus.InterpreterRuntime
{
    internal abstract class IsisInstruction
    {
        public IsisFunction ownerFunction;
        public virtual void Do() { }
    }
}
