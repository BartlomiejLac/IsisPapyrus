using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static IsisParser;

namespace IsisPapyrus.InterpreterRuntime
{
    internal class IsisProgram
    {
        public Dictionary<string, IsisVariable> globalVariables;
        public Dictionary<string, DeclarationFuncContext> globalFunctions;
        public TextBox console;

        public IsisProgram(ref TextBox tb)
        {
            globalVariables = new Dictionary<string, IsisVariable>();
            globalFunctions = new Dictionary<string, DeclarationFuncContext>();
            console = tb;
        }
    }
}
