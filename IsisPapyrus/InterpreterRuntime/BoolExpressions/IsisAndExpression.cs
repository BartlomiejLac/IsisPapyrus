using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsisPapyrus.InterpreterRuntime
{
    internal class IsisAndExpression : IsisExpression
    {
        public IsisAndExpression? leftSide;
        public IsisCompareExpression? rightSide;
        public bool constant;

        public override void Do()
        {
            this.evaluate();
        }
        public override object evaluate()
        {
            if (leftSide == null)
            {
                if (rightSide == null) return constant;
                return rightSide.evaluate();
            }
            return ((bool)leftSide.evaluate() && (bool)rightSide.evaluate());
        }
    }
}
