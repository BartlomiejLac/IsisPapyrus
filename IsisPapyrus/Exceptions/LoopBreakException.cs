﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsisPapyrus.Exceptions
{
    internal class LoopBreakException : Exception
    {
        public LoopBreakException() : base("break") { }
    }
}