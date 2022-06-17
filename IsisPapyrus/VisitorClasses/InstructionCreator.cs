using IsisPapyrus.InterpreterRuntime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static IsisParser;

namespace IsisPapyrus.VisitorClasses
{
    internal class InstructionCreator
    {
        public static IsisInstruction createInstruction(InstructionContext ctx, IsisFunction func)
        {
            if (ctx.instructionIf() != null) return createInstructionIf(ctx.instructionIf(), func);
            if (ctx.instructionFor() != null) return createInstructionFor(ctx.instructionFor(), func);
            if (ctx.instructionWhile() != null) return createInstructionWhile(ctx.instructionWhile(), func);
            if (ctx.instructionDo() != null) return createInstructionDo(ctx.instructionDo(), func);
            if (ctx.instructionPrint() != null) return createInstructionPrint(ctx.instructionPrint(), func);
            if (ctx.instructionReturn() != null) return createInstructionReturn(ctx.instructionReturn(), func);
            if (ctx.instructionBreak() != null) return new IsisInstructionBreak() { ownerFunction = func };
            if (ctx.instructionContinue() != null) return new IsisInstructionContinue() { ownerFunction = func };
        }

        public static IsisInstructionIf createInstructionIf(InstructionIfContext ctx, IsisFunction func)
        {
            var newIfIns = new IsisInstructionIf();
            newIfIns.ownerFunction = func;
            newIfIns.condition = ExpressionCreator.createBoolExpression(ctx.boolExpression(), func);
            var ictx = ctx.instructions()[0].instructionsList();
            var instructionsIfTrue = new List<IsisInstruction>();
            var instructionsElse = new List<IsisInstruction>();
            while (ictx != null)
            {
                var ins = ictx.instruction();
                var newIns = createInstruction(ins, func);
                instructionsIfTrue.Add(newIns);
                ictx = ictx.instructionsList();
            }
            newIfIns.instructionsIfTrue = instructionsIfTrue;
            if (ctx.ELSE() != null)
            {
                ictx = ctx.instructions()[1].instructionsList();
                while (ictx != null)
                {
                    var ins = ictx.instruction();
                    var newIns = createInstruction(ins, func);
                    instructionsElse.Add(newIns);
                    ictx = ictx.instructionsList();
                }
            }
            newIfIns.instructionsElse = instructionsElse;
            return newIfIns;
        }

        public static IsisInstructionFor createInstructionFor(InstructionForContext ctx, IsisFunction func)
        {
            var newForIns = new IsisInstructionFor();
            newForIns.ownerFunction = func;
            newForIns.condition = ExpressionCreator.createBoolExpression(ctx.boolExpression(), func);
            newForIns.initialExpr = ExpressionCreator.createExpression(ctx.expression()[0], func);
            newForIns.iterationStep = ExpressionCreator.createExpression(ctx.expression()[1], func);
            var ictx = ctx.instructions().instructionsList();
            var instructions = new List<IsisInstruction>();
            while (ictx != null)
            {
                var ins = ictx.instruction();
                var newIns = createInstruction(ins, func);
                instructions.Add(newIns);
                ictx = ictx.instructionsList();
            }
            newForIns.instructions = instructions;
            return newForIns;
        }

        public static IsisInstructionWhile createInstructionWhile(InstructionWhileContext ctx, IsisFunction func)
        {
            var newWhileIns = new IsisInstructionWhile();
            newWhileIns.ownerFunction = func;
            newWhileIns.condition = ExpressionCreator.createBoolExpression(ctx.boolExpression(), func);
            var ictx = ctx.instructions().instructionsList();
            var instructions = new List<IsisInstruction>();
            while (ictx != null)
            {
                var ins = ictx.instruction();
                var newIns = createInstruction(ins, func);
                instructions.Add(newIns);
                ictx = ictx.instructionsList();
            }
            newWhileIns.instructions = instructions;
            return newWhileIns;
        }

        public static IsisInstructionDo createInstructionDo(InstructionDoContext ctx, IsisFunction func)
        {
            var newDoIns = new IsisInstructionDo();
            newDoIns.ownerFunction = func;
            IsisBoolExpression boolExpr = ExpressionCreator.createBoolExpression(ctx.boolExpression(), func);
            newDoIns.condition = boolExpr;
            var ictx = ctx.instructions().instructionsList();
            var instructions = new List<IsisInstruction>();
            while (ictx != null)
            {
                var ins = ictx.instruction();
                var newIns = createInstruction(ins, func);
                instructions.Add(newIns);
                ictx = ictx.instructionsList();
            }
            newDoIns.instructions = instructions;
            return newDoIns;
        }

        public static IsisInstructionPrint createInstructionPrint(InstructionPrintContext ctx, IsisFunction func)
        {
            var newPriIns = new IsisInstructionPrint();
            newPriIns.ownerFunction = func;
            newPriIns.exprToBePrinted = ExpressionCreator.createSumExpression(ctx.sumExpression(), func);
            return newPriIns;
        }

        public static IsisInstructionReturn createInstructionReturn(InstructionReturnContext ctx, IsisFunction func)
        {
            var newRetIns = new IsisInstructionReturn();
            newRetIns.ownerFunction = func;
            if (ctx.sumExpression() != null) newRetIns.returnable = ExpressionCreator.createSumExpression(ctx.sumExpression(), func);
            return newRetIns;
        }
    }
}
