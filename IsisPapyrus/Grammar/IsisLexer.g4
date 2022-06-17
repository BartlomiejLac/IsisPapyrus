lexer grammar IsisLexer;

 /* Lexer Rules
 */
 
 channels {COMMENTS}
 
 LINECOMMENT : '\u{13305}' ~[\r\n]* -> channel(COMMENTS);
 STRINGCONST : DOUBLEQUOTE ANYCHARACTER* DOUBLEQUOTE;

//keywords
PROGRAMSTART : '\u{13080}';
PROGRAMEND : '\u{1314A}';
INSTRUCTIONEND : '\u{132F9}';
VOID : '\u{1316F}';
NUMERIC : '\u{130D5}';
STRING : '\u{130EF}';
WHILE : '\u{13133}';
DO : '\u{13136}';
FOR : '\u{13138}';
IF : '\u{13038}';
ELSE : '\u{131A3}';
BREAK : '\u{130BF}';
CONTINUE : '\u{13216}';
RETURN : '\u{130C2}';
PRINT : '\u{130AB}';

//number and text related stuff
fragment RAWNUMBERCONST : MILLIONSYMBOL+ HUNDREDTHOUSANDSYMBOL* TENTHOUSANDSYMBOL* THOUSANDSYMBOL? HUNDREDSYMBOL? TENSYMBOL? UNITSYMBOL? 
          | HUNDREDTHOUSANDSYMBOL+ TENTHOUSANDSYMBOL* THOUSANDSYMBOL? HUNDREDSYMBOL? TENSYMBOL? UNITSYMBOL? 
          | TENTHOUSANDSYMBOL+ THOUSANDSYMBOL? HUNDREDSYMBOL? TENSYMBOL? UNITSYMBOL? 
          | THOUSANDSYMBOL HUNDREDSYMBOL? TENSYMBOL? UNITSYMBOL? 
          | HUNDREDSYMBOL TENSYMBOL? UNITSYMBOL? 
          | TENSYMBOL UNITSYMBOL? 
          | UNITSYMBOL;
fragment FRACTION : FRACTIONSYMBOL RAWNUMBERCONST;
NUMBERCONST : ZERO | RAWNUMBERCONST FRACTION* | FRACTION+;
fragment THOUSANDSYMBOL      : [\u{131BC}-\u{131C4}];
fragment HUNDREDSYMBOL       : [\u{13362}-\u{1336A}];
fragment TENSYMBOL           : [\u{13386}-\u{1338E}];
fragment UNITSYMBOL          : [\u{133FA}-\u{13402}];
fragment ZERO : '\u{13124}' ;
fragment FRACTIONSYMBOL : '\u{1308B}';
fragment TENTHOUSANDSYMBOL : '\u{130AD}';
fragment HUNDREDTHOUSANDSYMBOL : '\u{13190}';
fragment MILLIONSYMBOL : '\u{13068}';

BOOLCONST : TRUE | FALSE;
fragment TRUE : '\u{1303E}';
fragment FALSE : '\u{1303F}';

LEFTPAREN : '\u{13023}';
RIGHTPAREN : '\u{13022}';
LEFTBRACE : '\u{13020}';
RIGHTBRACE : '\u{13021}';
DOUBLEQUOTE : '\u{1339B}';
COMMA : '\u{133F0}';

//various operators
INCREMENT : PLUS PLUS;
DECREMENT : MINUS MINUS;
INCREMENTBY : PLUS ASSIGN;
DECREMENTBY : MINUS ASSIGN;
MULTIPLYBY : MULTSYMBOL ASSIGN;
DIVIDEBY : DIVSYMBOL ASSIGN;
PLUS : '\u{130BD}';
MINUS : '\u{130BB}';
ASSIGN : '\u{1335D}';
MULTSYMBOL : '\u{13188}';
DIVSYMBOL : '\u{133F5}';
MODSYMBOL : '\u{132AD}';

//logical operators
GREATEREQUAL : GREATER EQUALS;
LESSEREQUAL : LESSER EQUALS;
NOTEQUALS : '\u{13399}' | NOT EQUALS;
EQUALS : '\u{1339A}';
AND : '\u{13093}';
OR : '\u{13098}';
NOT : '\u{1309C}';
GREATER : '\u{13287}';
LESSER : '\u{13286}';

fragment NUMBERCHARACTER : ZERO | UNITSYMBOL | TENSYMBOL | HUNDREDSYMBOL | THOUSANDSYMBOL | TENTHOUSANDSYMBOL | HUNDREDTHOUSANDSYMBOL | MILLIONSYMBOL | FRACTIONSYMBOL;
IDENTIFIER
    : VALIDLETTER (VALIDLETTER | NUMBERCHARACTER)*
    ;
fragment VALIDLETTER
    : [\u{13000}-\u{13067}]
    | [\u{13069}-\u{1308A}]
    | [\u{1308C}-\u{130AC}]
    | [\u{130AE}-\u{13123}]
    | [\u{13125}-\u{1318F}]
    | [\u{13191}-\u{131BB}]
    | [\u{131C5}-\u{13361}]
    | [\u{1336C}-\u{13385}]
    | [\u{13393}-\u{133F9}]
    | [\u{13404}-\u{1342F}]
    ;
WHITESPACE
    :   [ \t]+
        -> skip
    ;
NEWLINE
    :   (   '\r' '\n'?
        |   '\n'
        )
        -> skip
    ;

fragment ANYCHARACTER : . | LETTER;
fragment LETTER : [\u{13000}-\u{1342F}];

UNRECOGNIZED : .+?;