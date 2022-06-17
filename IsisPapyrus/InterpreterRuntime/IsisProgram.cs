using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IsisPapyrus.InterpreterRuntime
{
    internal class IsisProgram
    {
        public Dictionary<string, IsisVariable> globalVariables;
        public Dictionary<string, IsisFunction> globalFunctions;
        public TextBox console;

        public IsisFunction mainFunction;

        public void run()
        {
            mainFunction.call(new List<object>());
        }
    }
}
