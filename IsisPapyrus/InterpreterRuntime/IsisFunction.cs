using IsisPapyrus.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsisPapyrus.InterpreterRuntime
{
    internal class IsisFunction
    {
        public IsisProgram ownerProgram;
        public Dictionary<string, IsisVariable> localVariables;
        public List<Tuple<varType, string>> argTypes;
        public List<IsisInstruction> instructions;
        public varType returnType;
        public object call(List<object> args)
        {
            if (args.Count != argTypes.Count) throw new Exception();
            for (int i = 0; i < argTypes.Count; i++)
            {
                if (argTypes[i].Item1 == varType.IsisNumber && args[i] is Number ||
                    argTypes[i].Item1 == varType.IsisString && args[i] is string)
                {
                    localVariables.Add(argTypes[i].Item2, new IsisVariable(argTypes[i].Item1, args[i]));
                }
                else throw new Exception();
            }
            foreach (IsisInstruction instruction in instructions) 
            {
                try
                {
                    instruction.Do();
                } catch(FunctionReturnException e)
                {
                    if (returnType == varType.IsisString && e.returnable is string) return e.returnable;
                    if (returnType == varType.IsisNumber && e.returnable is Number) return e.returnable;
                    if (returnType == varType.IsisVoid && e.returnable == null) return null;
                    throw new Exception();
                }
            }
            throw new Exception();
        }
    }
}
