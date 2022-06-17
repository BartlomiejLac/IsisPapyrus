using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsisPapyrus.InterpreterRuntime
{
    internal class IsisVariableDeclaration : IsisExpression
    {
        string name;
        varType type;
        object? value;
        public override void Do()
        {
            if (this.ownerFunction.localVariables.ContainsKey(name)) throw new Exception();
            if (this.ownerFunction.ownerProgram.globalVariables.ContainsKey(name)) throw new Exception();
            this.ownerFunction.localVariables.Add(name, new IsisVariable(type, value));
        }
    }
}
