parser grammar KayleeParser;

options {
	tokenVocab = KayleeLexer;
}

parse: (schema | error)* EOF;

error:
	UNEXPECTED_CHAR {
	throw new FormatException("UNEXPECTED_CHAR=" + $UNEXPECTED_CHAR.text);
};

schema: SCHEMA IDENTIFIER OPEN_BLOCK schemaBody CLOSE_BLOCK;
schemaBody: (entity)*;

entity: (ENTITY | QUERY) IDENTIFIER OPEN_BLOCK entityBody CLOSE_BLOCK;
entityBody: (fields | entityKeys | mutations | entity)*;

fields: FIELDS OPEN_BLOCK fieldsBody CLOSE_BLOCK;
fieldsBody: (field)*;
field:
	IDENTIFIER QUESTION_MARK? dtype (
		OPEN_BLOCK fieldBody CLOSE_BLOCK
		| SCOL
	);
fieldBody: (fieldParameterComputed | fieldParameterDefault)*;
// computed = <true|false>;
fieldParameterComputed:
	COMPUTED ASSIGN fieldParameterComputedValue SCOL;
fieldParameterComputedValue: BOOLEAN;
// default = <numeric|string|function>;
fieldParameterDefault:
	DEFAULT ASSIGN fieldParameterDefaultValue SCOL;
fieldParameterDefaultValue:
	numericLiteral
	| STRING_LITERAL
	| FIELD_PARAMETER_DEFAULT_FUNCTION OPEN_PAR CLOSE_PAR;

// Due to "keys" being a reserved keyword, we need to name it something else.
entityKeys: KEYS OPEN_BLOCK entityKeysBody CLOSE_BLOCK;
entityKeysBody: (
		entityKeyPrimary
		| entityKeyUnique
		| entityKeyReference
	)*;
entityKeyPrimary: PRIMARY ASSIGN identifierList SCOL;
entityKeyUnique: UNIQUE OPEN_PAR identifierList CLOSE_PAR SCOL;
entityKeyReference:
	REFERENCE OPEN_PAR identifierList CLOSE_PAR ARROW qualified OPEN_PAR identifierList CLOSE_PAR
		SCOL;

mutations: MUTATIONS OPEN_BLOCK mutationsBody CLOSE_BLOCK;
mutationsBody: (mutation)*;
mutation: IDENTIFIER OPEN_PAR identifierList CLOSE_PAR SCOL;

qualified: (IDENTIFIER SCHEMA_ACCESSOR)? IDENTIFIER (
		DOT IDENTIFIER
	)*;

identifierList: IDENTIFIER (COMMA IDENTIFIER)*;

dtype:
	DTYPE_BIT
	| DTYPE_TINYINT
	| DTYPE_INT dtypeIntAutoIncrement?
	| DTYPE_BIGINT dtypeBigintAutoIncrement?
	| DTYPE_DECIMAL OPEN_PAR dTypeDecimalSize COMMA dtypeDecimalPrecision CLOSE_PAR
	| DTYPE_CHAR
	| DTYPE_TEXT OPEN_PAR dtypeTextSize CLOSE_PAR
	| DTYPE_GUID
	| DTYPE_DATE
	| DTYPE_VARBINARY OPEN_PAR dtypeVarbinarySize CLOSE_PAR
	| DTYPE_BINARY OPEN_PAR dtypeBinarySize CLOSE_PAR
	| DTYPE_ROWVERSION;
dtypeIntAutoIncrement: AUTO INCREMENT;
dtypeBigintAutoIncrement: AUTO INCREMENT;
dTypeDecimalSize: UNSIGNED_INTEGER;
dtypeDecimalPrecision: UNSIGNED_INTEGER;
dtypeTextSize: UNSIGNED_INTEGER | MAX;
dtypeVarbinarySize: UNSIGNED_INTEGER | MAX;
dtypeBinarySize: UNSIGNED_INTEGER;

numericLiteral:
	MINUS? UNSIGNED_INTEGER
	| MINUS? UNSIGNED_FLOAT
	| HEX_NUMBER;