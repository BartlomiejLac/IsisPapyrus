using IsisPapyrus.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsisPapyrus.InterpreterRuntime
{
    internal class IsisInstructionDo : IsisInstruction
    {
        public IsisBoolExpression condition;
        public List<IsisInstruction> instructions;

        public override void Do()
        {
            do
            {
                foreach (var instruction in instructions)
                {
                    try
                    {
                        instruction.Do();
                    }
                    catch (LoopBreakException)
                    {
                        break;
                    }
                    catch (LoopContinueException)
                    {
                        continue;
                    }
                }
            } while ((bool)condition.evaluate());
        }
    }
}
