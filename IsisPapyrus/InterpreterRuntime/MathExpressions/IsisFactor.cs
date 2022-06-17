using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsisPapyrus.InterpreterRuntime
{
    internal class IsisFactor : IsisExpression
    {
        public bool inverted;
        public IsisVariable? variable;
        public object? constant;

        public override void Do()
        {
            this.evaluate();
        }
        public override object evaluate()
        {
            if (variable != null)
            {
                if (inverted)
                {
                    var value = variable.value;
                    if (value is Number) return -(Number)value;
                    throw new Exception();
                }
                return variable.value;
            }
            if (constant != null)
            {
                if (inverted)
                {
                    if (constant is Number) return -(Number)constant;
                    throw new Exception();
                }
                return constant;
            }
            throw new Exception();
        }
    }
}
