lexer grammar KayleeLexer
	;

NUMERIC_LITERAL
	: INTEGER
	| FLOAT
	| HEX_NUMBER
	;

STRING_LITERAL
	: '\'' (~'\'' | '\'\'')* '\''
	;

BOOLEAN
	: TRUE
	| FALSE
	;

INTEGER
	: MINUS? UNSIGNED_INTEGER
	;
UNSIGNED_INTEGER
	: DIGIT+
	;

FLOAT
	: MINUS? UNSIGNED_FLOAT
	;
UNSIGNED_FLOAT
	: DIGIT+ (DOT DIGIT+)
	;

HEX_NUMBER
	: HEX_PREFIX HEX_DIGIT+
	;

DTYPE
	: DTYPE_BIT
	| DTYPE_TINYINT
	| DTYPE_INT
	| DTYPE_CHAR
	| DTYPE_TEXT
	| DTYPE_GUID
	| DTYPE_DATE
	| DTYPE_ROWVERSION
	;
DTYPE_BIT
	: 'BIT'
	;
DTYPE_TINYINT
	: 'TINYINT'
	;
DTYPE_INT
	: 'INT' AUTO_INCREMENT?
	;
DTYPE_CHAR
	: 'CHAR'
	;
DTYPE_TEXT
	: 'TEXT' '(' (UNSIGNED_INTEGER | MAX) ')'
	;
DTYPE_GUID
	: 'GUID'
	;
DTYPE_DATE
	: 'DATE'
	;
DTYPE_ROWVERSION
	: 'ROWVERSION'
	;

FIELD_PARAMETER_DEFAULT_FUNCTION
	: 'NEWID'
	| 'SYSDATETIMEOFFSET'
	;

SCHEMA
	: 'schema'
	;
ENTITY
	: 'entity'
	;
FIELDS
	: 'fields'
	;
KEYS
	: 'keys'
	;
MUTATIONS
	: 'mutations'
	;

DEFAULT
	: 'default'
	;
PRIMARY
	: 'primary'
	;
REFERENCE
	: 'reference'
	;

AUTO_INCREMENT
	: 'AUTO' 'INCREMENT'
	;
MAX
	: 'MAX'
	;
TRUE
	: 'true'
	;
FALSE
	: 'false'
	;

SCOL
	: ';'
	;
DOT
	: '.'
	;
OPEN_PAR
	: '('
	;
CLOSE_PAR
	: ')'
	;
OPEN_BLOCK
	: '{'
	;
CLOSE_BLOCK
	: '}'
	;
COMMA
	: ','
	;
ASSIGN
	: '='
	;
MINUS
	: '-'
	;
QUESTION_MARK
	: '?'
	;
SCHEMA_ACCESSOR
	: '::'
	;
ARROW
	: '=>'
	;

IDENTIFIER
	: IDENTIFIER_START IDENTIFIER_PART*
	;

// Comments and whitespace
SINGLE_LINE_COMMENT
	: '//' ~[\r\n]* -> skip
	;
MULTI_LINE_COMMENT
	: '/*' .*? '*/' -> skip
	;
WHITESPACE
	: [ \t\r\n\u000C]+ -> skip
	;

// Unexpected characters, used for error rule
UNEXPECTED_CHAR
	: .
	;

// Fragments
fragment IDENTIFIER_PART
	: IDENTIFIER_START
	| DIGIT
	;
fragment IDENTIFIER_START
	: LETTER
	;
fragment HEX_PREFIX
	: '0x'
	| '0X'
	;
fragment HEX_DIGIT
	: [a-f]
	| [A-F]
	| DIGIT
	;
fragment LETTER
	: [a-z]
	| [A-Z]
	;
fragment DIGIT
	: [0-9]
	;