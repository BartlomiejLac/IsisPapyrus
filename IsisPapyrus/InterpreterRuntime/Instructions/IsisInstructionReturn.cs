using IsisPapyrus.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsisPapyrus.InterpreterRuntime
{
    internal class IsisInstructionReturn : IsisInstruction
    {
        public IsisSumExpression? returnable;

        public override void Do()
        {
            if (returnable == null) throw new FunctionReturnException(null);
            throw new FunctionReturnException(returnable.evaluate());
        }
    }
}
