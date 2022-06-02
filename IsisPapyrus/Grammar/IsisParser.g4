parser grammar IsisParser;

 /* Parser Rules
 */

options { tokenVocab = IsisLexer; }

program : declarations mainFunction EOF | declarations EOF;
declarations : declarationList | /*eps*/;
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
instruction : expression INSTRUCTIONEND | instructionIf | instructionLoop | instructionReturn | instructionBreak | instructionPrint;
instructionIf : IF LEFTPAREN boolExpression RIGHTPAREN LEFTBRACE instructions RIGHTBRACE
              | IF LEFTPAREN boolExpression RIGHTPAREN LEFTBRACE instructions RIGHTBRACE ELSE LEFTBRACE instructions RIGHTBRACE;
instructionLoop : FOR LEFTPAREN expression INSTRUCTIONEND boolExpression INSTRUCTIONEND expression RIGHTPAREN LEFTBRACE instructions RIGHTBRACE
                | WHILE LEFTPAREN boolExpression RIGHTPAREN LEFTBRACE instructions RIGHTBRACE
                | DO LEFTBRACE instructions RIGHTBRACE WHILE LEFTPAREN boolExpression RIGHTPAREN;
instructionReturn : RETURN INSTRUCTIONEND | RETURN expression INSTRUCTIONEND;
instructionBreak : BREAK INSTRUCTIONEND | CONTINUE INSTRUCTIONEND;
instructionPrint : PRINT LEFTPAREN sumExpression RIGHTPAREN INSTRUCTIONEND;

///////////////////////

expression : variable ASSIGN expression | variable INCREMENTBY expression | variable DECREMENTBY expression
           | variable MULTIPLYBY expression | variable DIVIDEBY expression | variable INCREMENT | variable DECREMENT
           | boolExpression | sumExpression | declarationVariable | declarationVariable ASSIGN expression;
boolExpression : boolExpression OR andExpression | andExpression;
andExpression : andExpression AND notExpression | notExpression;
notExpression : NOT notExpression | compareExpression;
compareExpression : sumExpression compareOperator sumExpression | BOOLCONST;
compareOperator : EQUALS | NOTEQUALS | GREATER | GREATEREQUAL | LESSER | LESSEREQUAL;
sumExpression : sumExpression sumOperator multExpression | multExpression;
sumOperator : PLUS | MINUS;
multExpression : multExpression multOperator unaryExpression | unaryExpression;
multOperator : MULTSYMBOL | DIVSYMBOL | MODSYMBOL;
unaryExpression : unaryOperator unaryExpression | factor;
unaryOperator : PLUS | MINUS;
factor : variable | constant;
variable : IDENTIFIER | IDENTIFIER LEFTBRACKET NUMBERCONST RIGHTBRACKET;
constant : CHARCONST | STRINGCONST | BOOLCONST | NUMBERCONST | LEFTBRACKET constants RIGHTBRACKET;
constants : constantList | /* eps */;
constantList : constantList COMMA constant | constant;
