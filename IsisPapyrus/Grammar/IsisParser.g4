parser grammar IsisParser;

 /* Parser Rules
 */

options { tokenVocab = IsisLexer; }

program : declarationList mainFunction | mainFunction;
mainFunction : PROGRAMSTART instructions PROGRAMEND;
declarationList : declarationList declaration | declaration;
declaration : declarationVariable INSTRUCTIONEND | declarationFunc;

////////////////////////

declarationVariable : type variableName;
variableName : IDENTIFIER | IDENTIFIER LEFTBRACKET RIGHTBRACKET;
type : INT | FRACTIONAL | CHAR | STRING;

////////////////////////

declarationFunc : functionType IDENTIFIER LEFTPAREN arguments RIGHTPAREN LEFTBRACE instructionsList RIGHTBRACE;
functionType : type | VOID;
arguments : argumentsList | /*eps*/;
argumentsList : argumentsList COMMA argument | argument;
argument : type variableName;

////////////////////////

instructions : instructionsList | /*eps*/;
instructionsList : instructionsList instruction | instruction;
instruction : expression INSTRUCTIONEND | instructionIf | instructionLoop | instructionReturn | instructionBreak;
instructionIf : IF LEFTPAREN boolExpression RIGHTPAREN LEFTBRACE instructions RIGHTBRACE
              | IF LEFTPAREN boolExpression RIGHTPAREN LEFTBRACE instructions RIGHTBRACE ELSE LEFTBRACE instructions RIGHTBRACE;
instructionLoop : FOR LEFTPAREN expression INSTRUCTIONEND boolExpression INSTRUCTIONEND expression RIGHTPAREN LEFTBRACE instructions RIGHTBRACE
                | WHILE LEFTPAREN boolExpression RIGHTPAREN LEFTBRACE instructions RIGHTBRACE
                | DO LEFTBRACE instructions RIGHTBRACE WHILE LEFTPAREN boolExpression RIGHTPAREN;
instructionReturn : RETURN INSTRUCTIONEND | RETURN expression INSTRUCTIONEND;
instructionBreak : BREAK INSTRUCTIONEND;

///////////////////////

expression : variable ASSIGN expression | variable INCREMENTBY expression | variable DECREMENTBY expression
           | variable MULTIPLYBY expression | variable DIVIDEBY expression | variable INCREMENT | variable DECREMENT
           | boolExpression | sumExpression | declarationVariable | declarationVariable ASSIGN expression;
boolExpression : boolExpression OR andExpression | andExpression;
andExpression : andExpression AND notExpression | notExpression;
notExpression : NOT notExpression | compareExpression;
compareExpression : sumExpression compareOperator sumExpression;
compareOperator : EQUALS | NOTEQUALS | GREATER | GREATEREQUAL | LESSER | LESSEREQUAL;
sumExpression : sumExpression sumOperator multExpression | multExpression;
sumOperator : PLUS | MINUS;
multExpression : multExpression multOperator unaryExpression | unaryExpression;
multOperator : MULTSYMBOL | DIVSYMBOL | MODSYMBOL;
unaryExpression : unaryOperator unaryExpression | factor;
unaryOperator : PLUS | MINUS;
factor : variable | constant;
variable : IDENTIFIER | IDENTIFIER LEFTBRACKET numberConstant RIGHTBRACKET;
constant : stringConstant | charConstant | numberConstant | boolConstant | LEFTBRACKET constants RIGHTBRACKET;
constants : constantList | /* eps */;
constantList : constantList COMMA constant | constant;

///////////////////////

rawNumber : MILLIONSYMBOL+ HUNDREDTHOUSANDSYMBOL* TENTHOUSANDSYMBOL* THOUSANDSYMBOL? HUNDREDSYMBOL? TENSYMBOL? UNITSYMBOL? 
          | HUNDREDTHOUSANDSYMBOL+ TENTHOUSANDSYMBOL* THOUSANDSYMBOL? HUNDREDSYMBOL? TENSYMBOL? UNITSYMBOL? 
          | TENTHOUSANDSYMBOL+ THOUSANDSYMBOL? HUNDREDSYMBOL? TENSYMBOL? UNITSYMBOL? 
          | THOUSANDSYMBOL HUNDREDSYMBOL? TENSYMBOL? UNITSYMBOL? 
          | HUNDREDSYMBOL TENSYMBOL? UNITSYMBOL? 
          | TENSYMBOL UNITSYMBOL? 
          | UNITSYMBOL;
fraction : FRACTIONSYMBOL rawNumber;
numberConstant : ZERO | rawNumber | rawNumber fractionList;
fractionList : fractionList fraction | fraction;
charConstant : CHARCONST;
stringConstant : STRINGCONST;
boolConstant : TRUE | FALSE;