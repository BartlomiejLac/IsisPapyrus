using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using IsisPapyrus.InterpreterRuntime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsisPapyrus.VisitorClasses
{
    internal class IsisVisitor : IsisParserBaseVisitor<int>
    {
        public IsisProgram program;

        public IsisVisitor(IsisProgram program)
        {
            this.program = program;
        }

        public override int VisitProgram([NotNull] IsisParser.ProgramContext context)
        {
            foreach(var child in context.children)
            {
                Visit(child);
            }
            return 0;
        }

        public override int VisitDeclarations([NotNull] IsisParser.DeclarationsContext context)
        {
            foreach (var child in context.children)
            {
                Visit(child);
            }
            return 0;
        }

        public override int VisitDeclarationList([NotNull] IsisParser.DeclarationListContext context)
        {
            foreach (var child in context.children)
            {
                Visit(child);
            }
            return 0;
        }

        public override int VisitDeclaration([NotNull] IsisParser.DeclarationContext context)
        {
            foreach (var child in context.children)
            {
                Visit(child);
            }
            return 0;
        }

        public override int VisitDeclarationVariable([NotNull] IsisParser.DeclarationVariableContext context)
        {
            var type = context.type();
            var name = context.variableName();

            if (type.NUMERIC() != null) this.program.globalVariables.Add(name.IDENTIFIER().GetText(),
                    new IsisVariable(varType.IsisNumber, null));
            if (type.STRING() != null) this.program.globalVariables.Add(name.IDENTIFIER().GetText(),
                new IsisVariable(varType.IsisString, null));
            return 0;
        }

        public override int VisitDeclarationFunc([NotNull] IsisParser.DeclarationFuncContext context)
        {
            var newFunc = new IsisFunction();
            var argTypes = new List<Tuple<varType, string>>();
            var ctx = context.arguments().argumentsList();
            while (ctx != null)
            {
                var arg = ctx.argument();
                if (arg != null)
                {
                    if (arg.type().NUMERIC() != null)
                    {
                        argTypes.Add(new Tuple<varType, string>(varType.IsisNumber, arg.variableName().IDENTIFIER().GetText()));
                    }
                }
                ctx = ctx.argumentsList();
            }
            argTypes.Reverse();
            newFunc.argTypes = argTypes;
            var instructions = new List<IsisInstruction>();
            var ictx = context.instructions().instructionsList();
            while (ictx != null)
            {
                var ins = ictx.instruction();
                var newIns = InstructionCreator.createInstruction(ins, newFunc);
                instructions.Add(newIns);
                ictx = ictx.instructionsList();
            }
            instructions.Reverse();
            newFunc.instructions = instructions;
            newFunc.ownerProgram = program;
            if (context.functionType().VOID() != null) newFunc.returnType = varType.IsisVoid;
            if (context.functionType().type() != null)
            {
                if (context.functionType().type().NUMERIC() != null) newFunc.returnType = varType.IsisNumber;
                if (context.functionType().type().STRING() != null) newFunc.returnType = varType.IsisString;
            }
            program.globalFunctions.Add(context.IDENTIFIER().GetText(), newFunc);
            return 0;
        }
    }
}
