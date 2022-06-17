using IsisPapyrus.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsisPapyrus.InterpreterRuntime
{
    internal class IsisInstructionWhile : IsisInstruction
    {
        public IsisBoolExpression condition;
        public List<IsisInstruction> instructions;

        public override void Do()
        {
            while ((bool)condition.evaluate())
            {
                foreach(var instruction in instructions)
                {
                    try
                    {
                        instruction.Do();
                    } catch(LoopBreakException)
                    {
                        break;
                    } catch(LoopContinueException)
                    {
                        continue;
                    }
                }
            }
        }
    }
}
