﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgyptianKeyboard
{
    public class CharSource
    {
        public static string[][] keywords = new string[][]
        {
            new string [2] { "𓂀", "start" },
            new string [2] { "𓅊", "end" },
            new string [2] { "𓋹", "instructionend" },
            new string [2] { "𓃕", "numeric" },
            new string [2] { "𓃯", "string" },
            new string [2] { "𓅯", "void" },
            new string [2] { "𓀣", "leftparen" },
            new string [2] { "𓀢", "rightparen" },
            new string [2] { "𓀠", "leftbrace" },
            new string [2] { "𓀡", "rightbrace" },
            new string [2] { "𓍝", "assign" },
            new string [2] { "𓎛", "quote" },
            new string [2] { "𓏰", "comma" },
            new string [2] { "𓌅", "comment" },
            new string [2] { "𓎚", "equals" },
            new string [2] { "𓂽", "plus" },
            new string [2] { "𓂻", "minus" },
            new string [2] { "𓆈", "multiply" },
            new string [2] { "𓊇", "greater" },
            new string [2] { "𓊆", "lesser" },
            new string [2] { "𓎙", "notequals" },
            new string [2] { "𓂜", "not" },
            new string [2] { "𓂓", "and" },
            new string [2] { "𓂘", "or" },
            new string [2] { "𓂫", "print" },
            new string [2] { "𓀸", "if" },
            new string [2] { "𓆣", "else" },
            new string [2] { "𓄸", "for" },
            new string [2] { "𓄳", "while" },
            new string [2] { "𓄶", "do" },
            new string [2] { "𓂿", "break" },
            new string [2] { "𓈖", "continue" },
            new string [2] { "𓃂", "return" },
            new string [2] { "𓀾", "true" },
            new string [2] { "𓀿", "false" }
        };

        public static string[][] numberSigns = new string[][]
        {
            new string[9] { "𓏺", "𓏻", "𓏼", "𓏽", "𓏾", "𓏿", "𓐀", "𓐁", "𓐂" },
            new string[9] { "𓎆", "𓎇", "𓎈", "𓎉", "𓎊", "𓎋", "𓎌", "𓎍", "𓎎" },
            new string[9] { "𓍢", "𓍣", "𓍤", "𓍥", "𓍦", "𓍧", "𓍨", "𓍩", "𓍪" },
            new string[9] { "𓆼", "𓆽", "𓆾", "𓆿", "𓇀", "𓇁", "𓇂", "𓇃", "𓇄" }
        };

        public static string[] otherNumberSigns = new string[5] { "𓂋", "𓄤", "𓂭", "𓆐", "𓁨" };
}
}
