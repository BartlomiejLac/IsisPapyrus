using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsisPapyrus.VisitorClasses
{
    public class IsisVisitor : IsisParserBaseVisitor<int>
    {

        private int simpleChildrenVisit([NotNull] ParserRuleContext context)
        {
            foreach (var child in context.children)
            {
                if (Visit(child) == 1) return 1;
            }
            return 0;
        }
        public override int VisitProgram([NotNull] IsisParser.ProgramContext context)
        {
            return simpleChildrenVisit(context);
        }

        public override int VisitDeclarations([NotNull] IsisParser.DeclarationsContext context)
        {
            //TODO
            return 0;
        }

        public override int VisitMainFunction([NotNull] IsisParser.MainFunctionContext context)
        {
            return simpleChildrenVisit(context);
        }

        public override int VisitInstructions([NotNull] IsisParser.InstructionsContext context)
        {
            return simpleChildrenVisit(context);
        }

        public override int VisitInstructionsList([NotNull] IsisParser.InstructionsListContext context)
        {
            return simpleChildrenVisit(context);
        }

        public override int VisitInstruction([NotNull] IsisParser.InstructionContext context)
        {
            return simpleChildrenVisit(context);
        }

        public override int VisitExpression([NotNull] IsisParser.ExpressionContext context)
        {
            return base.VisitExpression(context);
        }
    }
}
