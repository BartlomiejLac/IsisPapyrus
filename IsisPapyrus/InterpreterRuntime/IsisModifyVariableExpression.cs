using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsisPapyrus.InterpreterRuntime
{
    internal class IsisModifyVariableExpression : IsisExpression
    {
        public string name;
        public string operationType;
        public IsisSumExpression? rightSide;

        public override void Do()
        {
            IsisVariable variable;
            if (!this.ownerFunction.localVariables.ContainsKey(name))
            {
                if (!this.ownerFunction.ownerProgram.globalVariables.ContainsKey(name)) throw new Exception();
                variable = this.ownerFunction.ownerProgram.globalVariables[name];
            }
            else
            {
                variable = this.ownerFunction.localVariables[name];
            }
            if (operationType == "=")
            {
                variable.setValue(rightSide.evaluate());
                return;
            }
            if (variable.type == varType.IsisString) throw new Exception();
            if (operationType == "++")
            {
                variable.setValue((Number)variable.value + new Number(1, 0, 1));
                return;
            }
            if (operationType == "--")
            {
                variable.setValue((Number)variable.value - new Number(1, 0, 1));
                return;
            }
            var r = rightSide.evaluate();
            if (!(r is Number)) throw new Exception();
            Number result = r as Number;
            switch (operationType)
            {
                case "+=":
                    variable.setValue((Number)variable.value + result);
                    return;
                case "-=":
                    variable.setValue((Number)variable.value - result);
                    return;
                case "*=":
                    variable.setValue((Number)variable.value * result);
                    return;
                case "/=":
                    variable.setValue((Number)variable.value / result);
                    return;
            }

        }
    }
}
