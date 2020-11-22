lexer grammar KayleeLexer;

STRING_LITERAL: '\'' (~'\'' | '\'\'')* '\'';

BOOLEAN: TRUE | FALSE;

UNSIGNED_INTEGER: DIGIT+;

UNSIGNED_FLOAT: DIGIT+ (DOT DIGIT+);

HEX_NUMBER: HEX_PREFIX HEX_DIGIT+;

DTYPE_BIT: 'BIT';
DTYPE_TINYINT: 'TINYINT';
DTYPE_INT: 'INT';
DTYPE_BIGINT: 'BIGINT';
DTYPE_DECIMAL: 'DECIMAL';
DTYPE_CHAR: 'CHAR';
DTYPE_TEXT: 'TEXT';
DTYPE_GUID: 'GUID';
DTYPE_DATE: 'DATE';
DTYPE_VARBINARY: 'VARBINARY';
DTYPE_BINARY: 'BINARY';
DTYPE_ROWVERSION: 'ROWVERSION';

FIELD_PARAMETER_DEFAULT_FUNCTION: 'NEWID' | 'SYSDATETIMEOFFSET';

SCHEMA: 'schema';
ENTITY: 'entity';
QUERY: 'query';
FIELDS: 'fields';
KEYS: 'keys';
MUTATIONS: 'mutations';

COMPUTED: 'computed';
DEFAULT: 'default';
PRIMARY: 'primary';
UNIQUE: 'unique';
REFERENCE: 'reference';

AUTO: 'AUTO';
INCREMENT: 'INCREMENT';
MAX: 'MAX';
TRUE: 'true';
FALSE: 'false';

SCOL: ';';
DOT: '.';
OPEN_PAR: '(';
CLOSE_PAR: ')';
OPEN_BLOCK: '{';
CLOSE_BLOCK: '}';
COMMA: ',';
ASSIGN: '=';
MINUS: '-';
QUESTION_MARK: '?';
SCHEMA_ACCESSOR: '::';
ARROW: '=>';

IDENTIFIER: IDENTIFIER_START IDENTIFIER_PART*;

// Comments and whitespace
SINGLE_LINE_COMMENT: '//' ~[\r\n]* -> skip;
MULTI_LINE_COMMENT: '/*' .*? '*/' -> skip;
WHITESPACE: WS -> skip;

// Unexpected characters, used for error rule
UNEXPECTED_CHAR: .;

// Fragments
fragment IDENTIFIER_PART: IDENTIFIER_START | DIGIT;
fragment IDENTIFIER_START: LETTER;
fragment HEX_PREFIX: '0x' | '0X';
fragment HEX_DIGIT: [a-f] | [A-F] | DIGIT;
fragment LETTER: [a-z] | [A-Z];
fragment DIGIT: [0-9];

fragment WS: [ \t\r\n\u000C]+;