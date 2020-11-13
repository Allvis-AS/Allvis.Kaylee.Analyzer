parser grammar KayleeParser
	;

options {
	tokenVocab = KayleeLexer;
}

parse
	: (schema | error)* EOF
	;

error
	: UNEXPECTED_CHAR {
	throw new FormatException("UNEXPECTED_CHAR=" + $UNEXPECTED_CHAR.text);
}
	;

schema
	: SCHEMA IDENTIFIER OPEN_BLOCK schemaBody CLOSE_BLOCK
	;
schemaBody
	: (entity)*
	;

entity
	: ENTITY IDENTIFIER OPEN_BLOCK entityBody CLOSE_BLOCK
	;
entityBody
	: (fields | keys | mutations | entity)*
	;

fields
	: FIELDS OPEN_BLOCK fieldsBody CLOSE_BLOCK
	;
fieldsBody
	: (field)*
	;
field
	: IDENTIFIER QUESTION_MARK? DTYPE (
		OPEN_BLOCK fieldBody CLOSE_BLOCK
		| SCOL
	)
	;
fieldBody
	: (fieldParameterDefault)*
	;
fieldParameterDefault
	: DEFAULT ASSIGN fieldParameterDefaultValue SCOL
	;
fieldParameterDefaultValue
	: NUMERIC_LITERAL
	| STRING_LITERAL
	| FIELD_PARAMETER_DEFAULT_FUNCTION OPEN_PAR CLOSE_PAR
	;

keys
	: KEYS OPEN_BLOCK keysBody CLOSE_BLOCK
	;
keysBody
	: (keyPrimary | keyReference)*
	;
keyPrimary
	: PRIMARY ASSIGN identifierList SCOL
	;
keyReference
	: REFERENCE OPEN_PAR identifierList CLOSE_PAR ARROW qualified OPEN_PAR identifierList CLOSE_PAR SCOL
	;

mutations
	: MUTATIONS OPEN_BLOCK mutationsBody CLOSE_BLOCK
	;
mutationsBody
	: (mutation)*
	;
mutation
	: IDENTIFIER OPEN_PAR identifierList CLOSE_PAR SCOL
	;

qualified
	: (IDENTIFIER SCHEMA_ACCESSOR)? IDENTIFIER (DOT IDENTIFIER)*
	;

identifierList
	: IDENTIFIER (COMMA IDENTIFIER)*
	;
