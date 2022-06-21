using IsisPapyrus.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsisPapyrus.InterpreterRuntime
{
    internal class IsisVariable 
    {
        public varType type;
        public object value;
        public IsisVariable(varType type, object value)
        {
            this.type = type;
            if (type == varType.IsisNumber && value is Number ||
                type == varType.IsisString && value is string ||
                value == null) this.value = value;
            else throw new VariableTypeException(type);
        }

        public void setValue(object val)
        {
            if (type == varType.IsisNumber && val is Number ||
                type == varType.IsisString && val is string) this.value = val;
            else throw new VariableTypeException(type);
        }
    }

}
