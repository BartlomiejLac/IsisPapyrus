using IsisPapyrus.Exceptions;
using IsisPapyrus.InterpreterRuntime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static IsisParser;

namespace IsisPapyrus.VisitorClasses
{
    internal class InstructionExecutor
    {
        public Dictionary<string, IsisVariable> localVariables;
        public IsisProgram ownerProgram;
        public ExpressionEvaluator evaluator;

        public InstructionExecutor(ref Dictionary<string, IsisVariable> localVariables, ref IsisProgram ownerProgram)
        {
            this.localVariables = localVariables;
            this.ownerProgram = ownerProgram;
            this.evaluator = new ExpressionEvaluator(ref localVariables, ref ownerProgram);
        }

        public void ExecuteInstruction(InstructionContext ctx)
        {
            if (ctx.expression() != null)
            {
                evaluator.EvaluateExpression(ctx.expression());
            }
            if (ctx.instructionBreak() != null)
            {
                throw new LoopBreakException();
            }
            if (ctx.instructionContinue() != null)
            {
                throw new LoopContinueException();
            }
            if (ctx.instructionIf() != null)
            {
                ExecuteIfInstruction(ctx.instructionIf());
                return;
            }
            if (ctx.instructionFor() != null)
            {
                ExecuteForInstruction(ctx.instructionFor());
                return;
            }
            if (ctx.instructionWhile() != null)
            {
                ExecuteWhileInstruction(ctx.instructionWhile());
                return;
            }
            if (ctx.instructionDo() != null)
            {
                ExecuteDoInstruction(ctx.instructionDo());
                return;
            }
            if (ctx.instructionPrint() != null)
            {
                ExecutePrintInstruction(ctx.instructionPrint());
                return;
            }
            if (ctx.instructionReturn() != null)
            {
                ExecuteReturnInstruction(ctx.instructionReturn());
                return;
            }
        }

        public void ExecuteIfInstruction(InstructionIfContext ctx)
        {
            if (evaluator.EvaluateBoolExpression(ctx.boolExpression()))
            {
                var ictx = ctx.instructions()[0].instructionsList();
                while (ictx != null)
                {
                    var ins = ictx.instruction();
                    ExecuteInstruction(ins);
                    ictx = ictx.instructionsList();
                }
            }
            else
            {
                if (ctx.ELSE() != null)
                {
                    var ictx = ctx.instructions()[1].instructionsList();
                    while (ictx != null)
                    {
                        var ins = ictx.instruction();
                        ictx = ictx.instructionsList();
                        ExecuteInstruction(ins);
                    }
                }
            }
        }

        public void ExecuteForInstruction(InstructionForContext ctx)
        {
            for (evaluator.EvaluateExpression(ctx.expression()[0]); evaluator.EvaluateBoolExpression(ctx.boolExpression()); evaluator.EvaluateExpression(ctx.expression()[1]))
            {
                try
                {
                    var ictx = ctx.instructions().instructionsList();
                    while (ictx != null)
                    {
                        var ins = ictx.instruction();
                        ictx = ictx.instructionsList();
                        ExecuteInstruction(ins);
                        
                    }
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
        public void ExecuteWhileInstruction(InstructionWhileContext ctx)
        {
            while(evaluator.EvaluateBoolExpression(ctx.boolExpression()))
            {
                try
                {
                    var ictx = ctx.instructions().instructionsList();
                    while (ictx != null)
                    {
                        var ins = ictx.instruction();
                        ictx = ictx.instructionsList();
                        ExecuteInstruction(ins);
                    }
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

        public void ExecuteDoInstruction(InstructionDoContext ctx)
        {
            do
            {
                try
                {
                    var ictx = ctx.instructions().instructionsList();
                    while (ictx != null)
                    {
                        var ins = ictx.instruction();
                        ictx = ictx.instructionsList();
                        ExecuteInstruction(ins);
                    }
                }
                catch (LoopBreakException)
                {
                    break;
                }
                catch (LoopContinueException)
                {
                    continue;
                }
            } while (evaluator.EvaluateBoolExpression(ctx.boolExpression()));
        }

        public void ExecutePrintInstruction(InstructionPrintContext ctx)
        {
            ownerProgram.console.printText(evaluator.EvaluateSumExpression(ctx.sumExpression()).ToString());
        }

        public void ExecuteReturnInstruction(InstructionReturnContext ctx)
        {
            if (ctx.sumExpression() == null) throw new FunctionReturnException(null);
            throw new FunctionReturnException(evaluator.EvaluateSumExpression(ctx.sumExpression()));
        }
    }
}
