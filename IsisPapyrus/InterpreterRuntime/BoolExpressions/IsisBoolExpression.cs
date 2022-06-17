using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsisPapyrus.InterpreterRuntime
{
    internal class IsisBoolExpression : IsisExpression
    {
        public IsisBoolExpression? leftSide;
        public IsisAndExpression rightSide;

        public override void Do()
        {
            this.evaluate();
        }
        public override object evaluate()
        {
            if (leftSide == null) return rightSide.evaluate();
            else
            {
                return ((bool)leftSide.evaluate() || (bool)rightSide.evaluate());
            }
        }
    }
}
