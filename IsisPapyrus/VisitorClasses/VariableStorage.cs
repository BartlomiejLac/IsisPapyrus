using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsisPapyrus.VisitorClasses
{
    internal class VariableStorage
    {
        private Dictionary<string, Number?> numberStorage = new Dictionary<string, Number?>();

        public void declareNumberVariable(string name)
        {
            if (numberStorage.ContainsKey(name))
            {
                throw new ArgumentException("Cannot declare already declared variable." + nameof(name));
            }
            numberStorage.Add(name, null);
        }

        public void assignValueToNumberVariable(string name, string value)
        {
            if (!numberStorage.ContainsKey(name)) throw new ArgumentException("Variable was not declared.");
            numberStorage[name] = EgyptianNumberParser.fromEgyptian(value);
        }

        public Number getValueFromNumberVariable(string name)
        {
            if (!numberStorage.ContainsKey(name)) throw new ArgumentException("Variable was not declared.");
            return numberStorage[name];
        }
    }
}
