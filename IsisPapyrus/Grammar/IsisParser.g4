parser grammar IsisParser;

 /* Parser Rules
 */

options { tokenVocab = IsisLexer; }

program : declarations mainFunction EOF | declarations EOF;
declarations : declarationList | /*eps*/;
mainFunction : PROGRAMSTART instructions PROGRAMEND;
declarationList : declaration declarationList | declaration;
declaration : declarationVariable INSTRUCTIONEND | declarationFunc;

////////////////////////

declarationVariable : type variableName;
variableName : IDENTIFIER;
type : NUMERIC | STRING;

////////////////////////

declarationFunc : functionType IDENTIFIER LEFTPAREN arguments RIGHTPAREN LEFTBRACE instructions RIGHTBRACE;
functionType : type | VOID;
arguments : argumentsList | /*eps*/;
argumentsList : argument COMMA argumentsList | argument;
argument : type variableName;

////////////////////////

instructions : instructionsList | /*eps*/;
instructionsList : instruction instructionsList | instruction;
instruction : expression INSTRUCTIONEND | instructionIf | instructionFor | instructionWhile | instructionDo | instructionReturn | instructionBreak | instructionContinue | instructionPrint;
instructionIf : IF LEFTPAREN boolExpression RIGHTPAREN LEFTBRACE instructions RIGHTBRACE
              | IF LEFTPAREN boolExpression RIGHTPAREN LEFTBRACE instructions RIGHTBRACE ELSE LEFTBRACE instructions RIGHTBRACE;
instructionFor : FOR LEFTPAREN expression INSTRUCTIONEND boolExpression INSTRUCTIONEND expression INSTRUCTIONEND RIGHTPAREN LEFTBRACE instructions RIGHTBRACE;
instructionWhile : WHILE LEFTPAREN boolExpression RIGHTPAREN LEFTBRACE instructions RIGHTBRACE;
instructionDo : DO LEFTBRACE instructions RIGHTBRACE WHILE LEFTPAREN boolExpression RIGHTPAREN;
instructionReturn : RETURN INSTRUCTIONEND | RETURN sumExpression INSTRUCTIONEND;
instructionBreak : BREAK INSTRUCTIONEND;
instructionContinue : CONTINUE INSTRUCTIONEND;
instructionPrint : PRINT LEFTPAREN sumExpression RIGHTPAREN INSTRUCTIONEND;

///////////////////////

expression : variable ASSIGN sumExpression | variable INCREMENTBY sumExpression | variable DECREMENTBY sumExpression
           | variable MULTIPLYBY sumExpression | variable DIVIDEBY sumExpression | variable INCREMENT | variable DECREMENT
           | boolExpression | sumExpression | declarationVariable | declarationVariable ASSIGN sumExpression;
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
factor : variable | constant | functionCall | LEFTPAREN sumExpression RIGHTPAREN;
functionCall : IDENTIFIER LEFTPAREN sumExpressions RIGHTPAREN;
sumExpressions : sumExpressionsList | /* eps */;
sumExpressionsList : sumExpression sumExpressionsList | sumExpression;
variable : IDENTIFIER;
constant : STRINGCONST | NUMBERCONST;
