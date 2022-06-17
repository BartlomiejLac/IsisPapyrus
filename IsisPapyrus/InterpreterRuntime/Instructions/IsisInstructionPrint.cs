using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsisPapyrus.InterpreterRuntime
{
    internal class IsisInstructionPrint : IsisInstruction
    {
        public IsisSumExpression exprToBePrinted;

        public override void Do()
        {
            this.ownerFunction.ownerProgram.console.AppendText(exprToBePrinted.evaluate().ToString());
        }
    }
}
