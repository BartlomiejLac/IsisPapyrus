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
    internal class FunctionExecutor
    {
        Dictionary<string, IsisVariable> localVariables;
        public IsisProgram ownerProgram;
        public InstructionExecutor executor;

        public FunctionExecutor(ref IsisProgram ownerProgram)
        {
            this.ownerProgram = ownerProgram;
            this.localVariables = new Dictionary<string, IsisVariable>();
            this.executor = new InstructionExecutor(ref localVariables, ref ownerProgram);
        }

        public object ExecuteFunction(DeclarationFuncContext ctx, List<SumExpressionContext> arguments)
        {
            varType type = varType.IsisVoid;
            if (ctx.functionType().type() != null)
            {
                if (ctx.functionType().type().STRING() != null) type = varType.IsisString;
                if (ctx.functionType().type().NUMERIC() != null) type = varType.IsisNumber;
            }

            var actx = ctx.arguments().argumentsList();
            int argIndex = 0;
            while (actx != null)
            {
                if (arguments.Count <= argIndex) throw new RuntimeException(actx.Start.Line, actx.Start.Column, "Too few arguments for function " + ctx.IDENTIFIER().GetText());
                var name = actx.argument().variableName().IDENTIFIER().GetText();
                var argType = actx.argument().type();
                if (localVariables.ContainsKey(name)) throw new RuntimeException(actx.Start.Line, actx.Start.Column,
                                                                                                        "Cannot declare two arguments with the same name");
                if (ownerProgram.globalVariables.ContainsKey(name)) throw new RuntimeException(actx.Start.Line, actx.Start.Column,
                                                                                                        "Cannot declare argument that is already a global variable");
                var value = this.executor.evaluator.EvaluateSumExpression(arguments[argIndex]);
                if (argType.NUMERIC() != null && value is Number) this.localVariables.Add(name, new IsisVariable(varType.IsisNumber, value));
                else if (argType.STRING() != null && value is string) this.localVariables.Add(name, new IsisVariable(varType.IsisString, value));
                else throw new RuntimeException(actx.Start.Line, actx.Start.Column, "Argument does not match a required type");
                argIndex++;
                actx = actx.argumentsList();
            }
            if (argIndex < arguments.Count) throw new RuntimeException(ctx.Start.Line, ctx.Start.Column, "Too many arguments for function " + ctx.IDENTIFIER().GetText());
            try
            {
                var ictx = ctx.instructions().instructionsList();
                while (ictx != null)
                {
                    var ins = ictx.instruction();
                    ictx = ictx.instructionsList();
                    executor.ExecuteInstruction(ins);
                }
            }
            catch (FunctionReturnException ex)
            {
                if (type == varType.IsisVoid && ex.returnable is null) return null;
                if (type == varType.IsisNumber && ex.returnable is Number) return ex.returnable;
                if (type == varType.IsisString && ex.returnable is string) return ex.returnable;
                throw new RuntimeException(ctx.Start.Line, ctx.Start.Column, "Return does not match the function type");
            }
            throw new RuntimeException(ctx.Start.Line, ctx.Start.Column, "Function does not return anything");
        }
    }
}
