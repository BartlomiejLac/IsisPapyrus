using IsisPapyrus.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsisPapyrus.InterpreterRuntime
{
    internal class IsisInstructionContinue : IsisInstruction
    {
        public override void Do()
        {
            throw new LoopContinueException();
        }
    }
}
