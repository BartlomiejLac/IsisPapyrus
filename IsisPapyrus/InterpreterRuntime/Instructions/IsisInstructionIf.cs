using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsisPapyrus.InterpreterRuntime
{
    internal class IsisInstructionIf : IsisInstruction
    {
        public IsisBoolExpression condition;
        public List<IsisInstruction> instructionsIfTrue;
        public List<IsisInstruction> instructionsElse;

        public override void Do()
        {
            if ((bool)condition.evaluate())
            {
                foreach(var instruction in instructionsIfTrue)
                {
                    instruction.Do();
                }
            }
            else
            {
                foreach(var instruction in instructionsElse)
                {
                    instruction.Do();
                }
            }
        }
    }
}
