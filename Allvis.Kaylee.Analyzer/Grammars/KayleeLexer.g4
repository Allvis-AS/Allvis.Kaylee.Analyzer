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

DTYPE_BIT
	: 'BIT'
	;
DTYPE_TINYINT
	: 'TINYINT'
	;
DTYPE_INT
	: 'INT'
	;
DTYPE_CHAR
	: 'CHAR'
	;
DTYPE_TEXT
	: 'TEXT'
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

COMPUTED
	: 'computed'
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

AUTO
	: 'AUTO'
	;
INCREMENT
	: 'INCREMENT'
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
	: WS -> skip
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

fragment WS
	: [ \t\r\n\u000C]+
	;