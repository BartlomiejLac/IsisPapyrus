using IsisPapyrus.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsisPapyrus.InterpreterRuntime
{
    internal class IsisInstructionBreak : IsisInstruction
    {
        public override void Do()
        {
            throw new LoopBreakException();
        }
    }
}
