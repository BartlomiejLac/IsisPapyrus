using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsisPapyrus.InterpreterRuntime
{
    internal class IsisCompareExpression : IsisExpression
    {
        public bool negated;
        public IsisSumExpression leftSide;
        public IsisSumExpression rightSide;
        public string type;

        public override void Do()
        {
            this.evaluate();
        }
        public override object evaluate()
        {
            var A = leftSide.evaluate();
            var B = rightSide.evaluate();
            if (A is Number && B is Number)
            {
                if (negated) return !numCompare((Number)A, (Number)B);
                return numCompare((Number)A, (Number)B);
            }
            if (A is string && B is string)
            {
                if (negated) return !strCompare((string)A, (string)B);
                return strCompare((string)A, (string)B);
            }
            throw new Exception();
        }

        public bool numCompare(Number A, Number B)
        {
            switch (type)
            {
                case "<":
                    return A < B;
                case ">":
                    return A > B;
                case "==":
                    return A == B;
                case "!=":
                    return A != B;
                case "<=":
                    return A <= B;
                case ">=":
                    return A >= B;
                default:
                    return false;
            }
        }

        public bool strCompare(string A, string B)
        {
            switch (type)
            {
                case "==":
                    return A == B;
                case "!=":
                    return A != B;
                default:
                    throw new Exception();
            }
        }
    }
}
