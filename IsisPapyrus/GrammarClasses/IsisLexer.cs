//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.10.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from C:/Users/bartt/RiderProjects/IsisPapyrus/IsisPapyrus/Grammar\IsisLexer.g4 by ANTLR 4.10.1

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using System;
using System.IO;
using System.Text;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.10.1")]
[System.CLSCompliant(false)]
public partial class IsisLexer : Lexer {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		LINECOMMENT=1, CHARCONST=2, STRINGCONST=3, PROGRAMSTART=4, PROGRAMEND=5, 
		INSTRUCTIONEND=6, VOID=7, CHAR=8, INT=9, BOOL=10, FRACTIONAL=11, STRING=12, 
		WHILE=13, DO=14, FOR=15, IF=16, ELSE=17, BREAK=18, CONTINUE=19, RETURN=20, 
		THOUSANDSYMBOL=21, HUNDREDSYMBOL=22, TENSYMBOL=23, UNITSYMBOL=24, ZERO=25, 
		FRACTIONSYMBOL=26, TENTHOUSANDSYMBOL=27, HUNDREDTHOUSANDSYMBOL=28, MILLIONSYMBOL=29, 
		TRUE=30, FALSE=31, LEFTPAREN=32, RIGHTPAREN=33, LEFTBRACKET=34, RIGHTBRACKET=35, 
		LEFTBRACE=36, RIGHTBRACE=37, SINGLEQUOTE=38, DOUBLEQUOTE=39, COMMA=40, 
		INCREMENT=41, DECREMENT=42, INCREMENTBY=43, DECREMENTBY=44, MULTIPLYBY=45, 
		DIVIDEBY=46, PLUS=47, MINUS=48, ASSIGN=49, MULTSYMBOL=50, DIVSYMBOL=51, 
		MODSYMBOL=52, GREATEREQUAL=53, LESSEREQUAL=54, NOTEQUALS=55, EQUALS=56, 
		AND=57, OR=58, NOT=59, GREATER=60, LESSER=61, IDENTIFIER=62, WHITESPACE=63, 
		NEWLINE=64;
	public static string[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"LINECOMMENT", "CHARCONST", "STRINGCONST", "PROGRAMSTART", "PROGRAMEND", 
		"INSTRUCTIONEND", "VOID", "CHAR", "INT", "BOOL", "FRACTIONAL", "STRING", 
		"WHILE", "DO", "FOR", "IF", "ELSE", "BREAK", "CONTINUE", "RETURN", "THOUSANDSYMBOL", 
		"HUNDREDSYMBOL", "TENSYMBOL", "UNITSYMBOL", "ZERO", "FRACTIONSYMBOL", 
		"TENTHOUSANDSYMBOL", "HUNDREDTHOUSANDSYMBOL", "MILLIONSYMBOL", "TRUE", 
		"FALSE", "LEFTPAREN", "RIGHTPAREN", "LEFTBRACKET", "RIGHTBRACKET", "LEFTBRACE", 
		"RIGHTBRACE", "SINGLEQUOTE", "DOUBLEQUOTE", "COMMA", "INCREMENT", "DECREMENT", 
		"INCREMENTBY", "DECREMENTBY", "MULTIPLYBY", "DIVIDEBY", "PLUS", "MINUS", 
		"ASSIGN", "MULTSYMBOL", "DIVSYMBOL", "MODSYMBOL", "GREATEREQUAL", "LESSEREQUAL", 
		"NOTEQUALS", "EQUALS", "AND", "OR", "NOT", "GREATER", "LESSER", "NUMBERCHARACTER", 
		"IDENTIFIER", "VALIDLETTER", "WHITESPACE", "NEWLINE", "ANYCHARACTER", 
		"LETTER"
	};


	public IsisLexer(ICharStream input)
	: this(input, Console.Out, Console.Error) { }

	public IsisLexer(ICharStream input, TextWriter output, TextWriter errorOutput)
	: base(input, output, errorOutput)
	{
		Interpreter = new LexerATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	private static readonly string[] _LiteralNames = {
		null, null, null, null, "'\\U00013080'", "'\\U0001314A'", "'\\U000132F9'", 
		"'\\U0001316F'", "'\\U000130DC'", "'\\U000130D5'", "'\\U000130D2'", "'\\U000130F2'", 
		"'\\U000130EF'", "'\\U00013133'", "'\\U00013136'", "'\\U00013138'", "'\\U00013038'", 
		"'\\U000131A3'", "'\\U000130BF'", "'\\U00013216'", "'\\U000130C2'", null, 
		null, null, null, "'\\U00013124'", "'\\U0001308B'", "'\\U000130AD'", "'\\U00013190'", 
		"'\\U00013068'", "'\\U0001303E'", "'\\U0001303F'", "'\\U00013023'", "'\\U00013022'", 
		"'\\U00013024'", "'\\U00013025'", "'\\U00013020'", "'\\U00013021'", "'\\U000132FE'", 
		"'\\U0001339B'", "'\\U000133F0'", null, null, null, null, null, null, 
		"'\\U000130BD'", "'\\U000130BB'", "'\\U0001335D'", "'\\U00013188'", "'\\U000133F5'", 
		"'\\U000132AD'", null, null, null, "'\\U0001339A'", "'\\U00013093'", "'\\U00013098'", 
		"'\\U0001309C'", "'\\U00013287'", "'\\U00013286'"
	};
	private static readonly string[] _SymbolicNames = {
		null, "LINECOMMENT", "CHARCONST", "STRINGCONST", "PROGRAMSTART", "PROGRAMEND", 
		"INSTRUCTIONEND", "VOID", "CHAR", "INT", "BOOL", "FRACTIONAL", "STRING", 
		"WHILE", "DO", "FOR", "IF", "ELSE", "BREAK", "CONTINUE", "RETURN", "THOUSANDSYMBOL", 
		"HUNDREDSYMBOL", "TENSYMBOL", "UNITSYMBOL", "ZERO", "FRACTIONSYMBOL", 
		"TENTHOUSANDSYMBOL", "HUNDREDTHOUSANDSYMBOL", "MILLIONSYMBOL", "TRUE", 
		"FALSE", "LEFTPAREN", "RIGHTPAREN", "LEFTBRACKET", "RIGHTBRACKET", "LEFTBRACE", 
		"RIGHTBRACE", "SINGLEQUOTE", "DOUBLEQUOTE", "COMMA", "INCREMENT", "DECREMENT", 
		"INCREMENTBY", "DECREMENTBY", "MULTIPLYBY", "DIVIDEBY", "PLUS", "MINUS", 
		"ASSIGN", "MULTSYMBOL", "DIVSYMBOL", "MODSYMBOL", "GREATEREQUAL", "LESSEREQUAL", 
		"NOTEQUALS", "EQUALS", "AND", "OR", "NOT", "GREATER", "LESSER", "IDENTIFIER", 
		"WHITESPACE", "NEWLINE"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "IsisLexer.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string[] ChannelNames { get { return channelNames; } }

	public override string[] ModeNames { get { return modeNames; } }

	public override int[] SerializedAtn { get { return _serializedATN; } }

	static IsisLexer() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}
	private static int[] _serializedATN = {
		4,0,64,329,6,-1,2,0,7,0,2,1,7,1,2,2,7,2,2,3,7,3,2,4,7,4,2,5,7,5,2,6,7,
		6,2,7,7,7,2,8,7,8,2,9,7,9,2,10,7,10,2,11,7,11,2,12,7,12,2,13,7,13,2,14,
		7,14,2,15,7,15,2,16,7,16,2,17,7,17,2,18,7,18,2,19,7,19,2,20,7,20,2,21,
		7,21,2,22,7,22,2,23,7,23,2,24,7,24,2,25,7,25,2,26,7,26,2,27,7,27,2,28,
		7,28,2,29,7,29,2,30,7,30,2,31,7,31,2,32,7,32,2,33,7,33,2,34,7,34,2,35,
		7,35,2,36,7,36,2,37,7,37,2,38,7,38,2,39,7,39,2,40,7,40,2,41,7,41,2,42,
		7,42,2,43,7,43,2,44,7,44,2,45,7,45,2,46,7,46,2,47,7,47,2,48,7,48,2,49,
		7,49,2,50,7,50,2,51,7,51,2,52,7,52,2,53,7,53,2,54,7,54,2,55,7,55,2,56,
		7,56,2,57,7,57,2,58,7,58,2,59,7,59,2,60,7,60,2,61,7,61,2,62,7,62,2,63,
		7,63,2,64,7,64,2,65,7,65,2,66,7,66,2,67,7,67,1,0,1,0,5,0,140,8,0,10,0,
		12,0,143,9,0,1,1,1,1,1,1,1,1,1,2,1,2,5,2,151,8,2,10,2,12,2,154,9,2,1,2,
		1,2,1,3,1,3,1,4,1,4,1,5,1,5,1,6,1,6,1,7,1,7,1,8,1,8,1,9,1,9,1,10,1,10,
		1,11,1,11,1,12,1,12,1,13,1,13,1,14,1,14,1,15,1,15,1,16,1,16,1,17,1,17,
		1,18,1,18,1,19,1,19,1,20,1,20,1,21,1,21,1,22,1,22,1,23,1,23,1,24,1,24,
		1,25,1,25,1,26,1,26,1,27,1,27,1,28,1,28,1,29,1,29,1,30,1,30,1,31,1,31,
		1,32,1,32,1,33,1,33,1,34,1,34,1,35,1,35,1,36,1,36,1,37,1,37,1,38,1,38,
		1,39,1,39,1,40,1,40,1,40,1,41,1,41,1,41,1,42,1,42,1,42,1,43,1,43,1,43,
		1,44,1,44,1,44,1,45,1,45,1,45,1,46,1,46,1,47,1,47,1,48,1,48,1,49,1,49,
		1,50,1,50,1,51,1,51,1,52,1,52,1,52,1,53,1,53,1,53,1,54,1,54,1,54,1,54,
		3,54,272,8,54,1,55,1,55,1,56,1,56,1,57,1,57,1,58,1,58,1,59,1,59,1,60,1,
		60,1,61,1,61,1,61,1,61,1,61,1,61,1,61,1,61,1,61,3,61,295,8,61,1,62,1,62,
		1,62,5,62,300,8,62,10,62,12,62,303,9,62,1,63,3,63,306,8,63,1,64,4,64,309,
		8,64,11,64,12,64,310,1,64,1,64,1,65,1,65,3,65,317,8,65,1,65,3,65,320,8,
		65,1,65,1,65,1,66,1,66,3,66,326,8,66,1,67,1,67,0,0,68,1,1,3,2,5,3,7,4,
		9,5,11,6,13,7,15,8,17,9,19,10,21,11,23,12,25,13,27,14,29,15,31,16,33,17,
		35,18,37,19,39,20,41,21,43,22,45,23,47,24,49,25,51,26,53,27,55,28,57,29,
		59,30,61,31,63,32,65,33,67,34,69,35,71,36,73,37,75,38,77,39,79,40,81,41,
		83,42,85,43,87,44,89,45,91,46,93,47,95,48,97,49,99,50,101,51,103,52,105,
		53,107,54,109,55,111,56,113,57,115,58,117,59,119,60,121,61,123,0,125,62,
		127,0,129,63,131,64,133,0,135,0,1,0,8,2,0,10,10,13,13,1,0,78268,78276,
		1,0,78690,78698,1,0,78726,78734,1,0,78842,78850,10,0,77824,77927,77929,
		77962,77964,77996,77998,78115,78117,78223,78225,78267,78277,78689,78700,
		78725,78739,78841,78852,78895,2,0,9,9,32,32,1,0,77824,78895,341,0,1,1,
		0,0,0,0,3,1,0,0,0,0,5,1,0,0,0,0,7,1,0,0,0,0,9,1,0,0,0,0,11,1,0,0,0,0,13,
		1,0,0,0,0,15,1,0,0,0,0,17,1,0,0,0,0,19,1,0,0,0,0,21,1,0,0,0,0,23,1,0,0,
		0,0,25,1,0,0,0,0,27,1,0,0,0,0,29,1,0,0,0,0,31,1,0,0,0,0,33,1,0,0,0,0,35,
		1,0,0,0,0,37,1,0,0,0,0,39,1,0,0,0,0,41,1,0,0,0,0,43,1,0,0,0,0,45,1,0,0,
		0,0,47,1,0,0,0,0,49,1,0,0,0,0,51,1,0,0,0,0,53,1,0,0,0,0,55,1,0,0,0,0,57,
		1,0,0,0,0,59,1,0,0,0,0,61,1,0,0,0,0,63,1,0,0,0,0,65,1,0,0,0,0,67,1,0,0,
		0,0,69,1,0,0,0,0,71,1,0,0,0,0,73,1,0,0,0,0,75,1,0,0,0,0,77,1,0,0,0,0,79,
		1,0,0,0,0,81,1,0,0,0,0,83,1,0,0,0,0,85,1,0,0,0,0,87,1,0,0,0,0,89,1,0,0,
		0,0,91,1,0,0,0,0,93,1,0,0,0,0,95,1,0,0,0,0,97,1,0,0,0,0,99,1,0,0,0,0,101,
		1,0,0,0,0,103,1,0,0,0,0,105,1,0,0,0,0,107,1,0,0,0,0,109,1,0,0,0,0,111,
		1,0,0,0,0,113,1,0,0,0,0,115,1,0,0,0,0,117,1,0,0,0,0,119,1,0,0,0,0,121,
		1,0,0,0,0,125,1,0,0,0,0,129,1,0,0,0,0,131,1,0,0,0,1,137,1,0,0,0,3,144,
		1,0,0,0,5,148,1,0,0,0,7,157,1,0,0,0,9,159,1,0,0,0,11,161,1,0,0,0,13,163,
		1,0,0,0,15,165,1,0,0,0,17,167,1,0,0,0,19,169,1,0,0,0,21,171,1,0,0,0,23,
		173,1,0,0,0,25,175,1,0,0,0,27,177,1,0,0,0,29,179,1,0,0,0,31,181,1,0,0,
		0,33,183,1,0,0,0,35,185,1,0,0,0,37,187,1,0,0,0,39,189,1,0,0,0,41,191,1,
		0,0,0,43,193,1,0,0,0,45,195,1,0,0,0,47,197,1,0,0,0,49,199,1,0,0,0,51,201,
		1,0,0,0,53,203,1,0,0,0,55,205,1,0,0,0,57,207,1,0,0,0,59,209,1,0,0,0,61,
		211,1,0,0,0,63,213,1,0,0,0,65,215,1,0,0,0,67,217,1,0,0,0,69,219,1,0,0,
		0,71,221,1,0,0,0,73,223,1,0,0,0,75,225,1,0,0,0,77,227,1,0,0,0,79,229,1,
		0,0,0,81,231,1,0,0,0,83,234,1,0,0,0,85,237,1,0,0,0,87,240,1,0,0,0,89,243,
		1,0,0,0,91,246,1,0,0,0,93,249,1,0,0,0,95,251,1,0,0,0,97,253,1,0,0,0,99,
		255,1,0,0,0,101,257,1,0,0,0,103,259,1,0,0,0,105,261,1,0,0,0,107,264,1,
		0,0,0,109,271,1,0,0,0,111,273,1,0,0,0,113,275,1,0,0,0,115,277,1,0,0,0,
		117,279,1,0,0,0,119,281,1,0,0,0,121,283,1,0,0,0,123,294,1,0,0,0,125,296,
		1,0,0,0,127,305,1,0,0,0,129,308,1,0,0,0,131,319,1,0,0,0,133,325,1,0,0,
		0,135,327,1,0,0,0,137,141,5,78597,0,0,138,140,8,0,0,0,139,138,1,0,0,0,
		140,143,1,0,0,0,141,139,1,0,0,0,141,142,1,0,0,0,142,2,1,0,0,0,143,141,
		1,0,0,0,144,145,3,75,37,0,145,146,3,133,66,0,146,147,3,75,37,0,147,4,1,
		0,0,0,148,152,3,77,38,0,149,151,3,133,66,0,150,149,1,0,0,0,151,154,1,0,
		0,0,152,150,1,0,0,0,152,153,1,0,0,0,153,155,1,0,0,0,154,152,1,0,0,0,155,
		156,3,77,38,0,156,6,1,0,0,0,157,158,5,77952,0,0,158,8,1,0,0,0,159,160,
		5,78154,0,0,160,10,1,0,0,0,161,162,5,78585,0,0,162,12,1,0,0,0,163,164,
		5,78191,0,0,164,14,1,0,0,0,165,166,5,78044,0,0,166,16,1,0,0,0,167,168,
		5,78037,0,0,168,18,1,0,0,0,169,170,5,78034,0,0,170,20,1,0,0,0,171,172,
		5,78066,0,0,172,22,1,0,0,0,173,174,5,78063,0,0,174,24,1,0,0,0,175,176,
		5,78131,0,0,176,26,1,0,0,0,177,178,5,78134,0,0,178,28,1,0,0,0,179,180,
		5,78136,0,0,180,30,1,0,0,0,181,182,5,77880,0,0,182,32,1,0,0,0,183,184,
		5,78243,0,0,184,34,1,0,0,0,185,186,5,78015,0,0,186,36,1,0,0,0,187,188,
		5,78358,0,0,188,38,1,0,0,0,189,190,5,78018,0,0,190,40,1,0,0,0,191,192,
		7,1,0,0,192,42,1,0,0,0,193,194,7,2,0,0,194,44,1,0,0,0,195,196,7,3,0,0,
		196,46,1,0,0,0,197,198,7,4,0,0,198,48,1,0,0,0,199,200,5,78116,0,0,200,
		50,1,0,0,0,201,202,5,77963,0,0,202,52,1,0,0,0,203,204,5,77997,0,0,204,
		54,1,0,0,0,205,206,5,78224,0,0,206,56,1,0,0,0,207,208,5,77928,0,0,208,
		58,1,0,0,0,209,210,5,77886,0,0,210,60,1,0,0,0,211,212,5,77887,0,0,212,
		62,1,0,0,0,213,214,5,77859,0,0,214,64,1,0,0,0,215,216,5,77858,0,0,216,
		66,1,0,0,0,217,218,5,77860,0,0,218,68,1,0,0,0,219,220,5,77861,0,0,220,
		70,1,0,0,0,221,222,5,77856,0,0,222,72,1,0,0,0,223,224,5,77857,0,0,224,
		74,1,0,0,0,225,226,5,78590,0,0,226,76,1,0,0,0,227,228,5,78747,0,0,228,
		78,1,0,0,0,229,230,5,78832,0,0,230,80,1,0,0,0,231,232,3,93,46,0,232,233,
		3,93,46,0,233,82,1,0,0,0,234,235,3,95,47,0,235,236,3,95,47,0,236,84,1,
		0,0,0,237,238,3,93,46,0,238,239,3,97,48,0,239,86,1,0,0,0,240,241,3,95,
		47,0,241,242,3,97,48,0,242,88,1,0,0,0,243,244,3,99,49,0,244,245,3,97,48,
		0,245,90,1,0,0,0,246,247,3,101,50,0,247,248,3,97,48,0,248,92,1,0,0,0,249,
		250,5,78013,0,0,250,94,1,0,0,0,251,252,5,78011,0,0,252,96,1,0,0,0,253,
		254,5,78685,0,0,254,98,1,0,0,0,255,256,5,78216,0,0,256,100,1,0,0,0,257,
		258,5,78837,0,0,258,102,1,0,0,0,259,260,5,78509,0,0,260,104,1,0,0,0,261,
		262,3,119,59,0,262,263,3,111,55,0,263,106,1,0,0,0,264,265,3,121,60,0,265,
		266,3,111,55,0,266,108,1,0,0,0,267,272,5,78745,0,0,268,269,3,117,58,0,
		269,270,3,111,55,0,270,272,1,0,0,0,271,267,1,0,0,0,271,268,1,0,0,0,272,
		110,1,0,0,0,273,274,5,78746,0,0,274,112,1,0,0,0,275,276,5,77971,0,0,276,
		114,1,0,0,0,277,278,5,77976,0,0,278,116,1,0,0,0,279,280,5,77980,0,0,280,
		118,1,0,0,0,281,282,5,78471,0,0,282,120,1,0,0,0,283,284,5,78470,0,0,284,
		122,1,0,0,0,285,295,3,49,24,0,286,295,3,47,23,0,287,295,3,45,22,0,288,
		295,3,43,21,0,289,295,3,41,20,0,290,295,3,53,26,0,291,295,3,55,27,0,292,
		295,3,57,28,0,293,295,3,51,25,0,294,285,1,0,0,0,294,286,1,0,0,0,294,287,
		1,0,0,0,294,288,1,0,0,0,294,289,1,0,0,0,294,290,1,0,0,0,294,291,1,0,0,
		0,294,292,1,0,0,0,294,293,1,0,0,0,295,124,1,0,0,0,296,301,3,127,63,0,297,
		300,3,127,63,0,298,300,3,123,61,0,299,297,1,0,0,0,299,298,1,0,0,0,300,
		303,1,0,0,0,301,299,1,0,0,0,301,302,1,0,0,0,302,126,1,0,0,0,303,301,1,
		0,0,0,304,306,7,5,0,0,305,304,1,0,0,0,306,128,1,0,0,0,307,309,7,6,0,0,
		308,307,1,0,0,0,309,310,1,0,0,0,310,308,1,0,0,0,310,311,1,0,0,0,311,312,
		1,0,0,0,312,313,6,64,0,0,313,130,1,0,0,0,314,316,5,13,0,0,315,317,5,10,
		0,0,316,315,1,0,0,0,316,317,1,0,0,0,317,320,1,0,0,0,318,320,5,10,0,0,319,
		314,1,0,0,0,319,318,1,0,0,0,320,321,1,0,0,0,321,322,6,65,0,0,322,132,1,
		0,0,0,323,326,9,0,0,0,324,326,3,135,67,0,325,323,1,0,0,0,325,324,1,0,0,
		0,326,134,1,0,0,0,327,328,7,7,0,0,328,136,1,0,0,0,12,0,141,152,271,294,
		299,301,305,310,316,319,325,1,6,0,0
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}