using IsisPapyrus.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsisPapyrus.InterpreterRuntime
{
    internal class IsisInstructionFor : IsisInstruction
    {
        public IsisExpression initialExpr;
        public IsisBoolExpression condition;
        public IsisExpression iterationStep;

        public List<IsisInstruction> instructions;

        public override void Do()
        {
            for(initialExpr.Do(); (bool)condition.evaluate(); iterationStep.Do())
            {
                foreach(var instruction in instructions)
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
            }
        }
    }
}
