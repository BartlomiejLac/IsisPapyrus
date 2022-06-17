using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsisPapyrus.InterpreterRuntime
{
    internal class IsisSumExpression : IsisExpression
    {
        public IsisSumExpression? leftSide;
        public string type;
        public IsisMultExpression? rightSide;

        public override void Do()
        {
            this.evaluate();
        }
        public override object evaluate()
        {
            if (leftSide == null)
            {
                return rightSide.evaluate();
            }
            var A = leftSide.evaluate();
            var B = rightSide.evaluate();
            if (A is Number && B is Number)
            {
                if (type == "+") return (Number)A + (Number)B;
                return (Number)A - (Number)B;
            }
            if (type != "+") throw new Exception();
            if (A is string && B is string)
            {
                return (string)A + (string)B;
            }
            if (A is string && B is Number)
            {
                Number numB = B as Number;
                return (string)A + numB.ToString();
            }
            if (A is Number && B is string)
            {
                Number numA = A as Number;
                return numA.ToString() + (string)B;
            }
            throw new Exception();
        }
    }
}
