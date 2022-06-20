using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgyptianKeyboard
{
    public class CharacterSendEventArgs : EventArgs
    {
        public string sign;
        public CharacterSendEventArgs(string s)
        {
            sign = s;
        }
    }
}
