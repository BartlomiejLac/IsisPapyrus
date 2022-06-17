using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsisPapyrus.InterpreterRuntime
{
    internal class IsisMultExpression : IsisExpression
    {
        public IsisMultExpression? leftSide;
        public string type;
        public IsisFactor rightSide;

        public override void Do()
        {
            this.evaluate();
        }
        public override object evaluate()
        {
            if (leftSide == null) return rightSide.evaluate();
            var A = leftSide.evaluate();
            var B = rightSide.evaluate();
            if (A is Number && B is Number)
            {
                if (type == "*") return (Number)A * (Number)B;
                return (Number)A / (Number)B;
            }
            throw new Exception();
        }
    }
}
