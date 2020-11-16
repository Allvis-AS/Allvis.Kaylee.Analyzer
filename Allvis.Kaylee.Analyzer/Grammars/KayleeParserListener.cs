//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.8
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from KayleeParser.g4 by ANTLR 4.8

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using Antlr4.Runtime.Misc;
using IParseTreeListener = Antlr4.Runtime.Tree.IParseTreeListener;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete listener for a parse tree produced by
/// <see cref="KayleeParser"/>.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.8")]
[System.CLSCompliant(false)]
public interface IKayleeParserListener : IParseTreeListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="KayleeParser.parse"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterParse([NotNull] KayleeParser.ParseContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KayleeParser.parse"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitParse([NotNull] KayleeParser.ParseContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="KayleeParser.error"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterError([NotNull] KayleeParser.ErrorContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KayleeParser.error"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitError([NotNull] KayleeParser.ErrorContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="KayleeParser.schema"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSchema([NotNull] KayleeParser.SchemaContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KayleeParser.schema"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSchema([NotNull] KayleeParser.SchemaContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="KayleeParser.schemaBody"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSchemaBody([NotNull] KayleeParser.SchemaBodyContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KayleeParser.schemaBody"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSchemaBody([NotNull] KayleeParser.SchemaBodyContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="KayleeParser.entity"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterEntity([NotNull] KayleeParser.EntityContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KayleeParser.entity"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitEntity([NotNull] KayleeParser.EntityContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="KayleeParser.entityBody"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterEntityBody([NotNull] KayleeParser.EntityBodyContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KayleeParser.entityBody"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitEntityBody([NotNull] KayleeParser.EntityBodyContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="KayleeParser.fields"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFields([NotNull] KayleeParser.FieldsContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KayleeParser.fields"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFields([NotNull] KayleeParser.FieldsContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="KayleeParser.fieldsBody"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFieldsBody([NotNull] KayleeParser.FieldsBodyContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KayleeParser.fieldsBody"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFieldsBody([NotNull] KayleeParser.FieldsBodyContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="KayleeParser.field"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterField([NotNull] KayleeParser.FieldContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KayleeParser.field"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitField([NotNull] KayleeParser.FieldContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="KayleeParser.fieldBody"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFieldBody([NotNull] KayleeParser.FieldBodyContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KayleeParser.fieldBody"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFieldBody([NotNull] KayleeParser.FieldBodyContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="KayleeParser.fieldParameterDefault"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFieldParameterDefault([NotNull] KayleeParser.FieldParameterDefaultContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KayleeParser.fieldParameterDefault"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFieldParameterDefault([NotNull] KayleeParser.FieldParameterDefaultContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="KayleeParser.fieldParameterDefaultValue"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFieldParameterDefaultValue([NotNull] KayleeParser.FieldParameterDefaultValueContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KayleeParser.fieldParameterDefaultValue"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFieldParameterDefaultValue([NotNull] KayleeParser.FieldParameterDefaultValueContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="KayleeParser.entityKeys"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterEntityKeys([NotNull] KayleeParser.EntityKeysContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KayleeParser.entityKeys"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitEntityKeys([NotNull] KayleeParser.EntityKeysContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="KayleeParser.entityKeysBody"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterEntityKeysBody([NotNull] KayleeParser.EntityKeysBodyContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KayleeParser.entityKeysBody"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitEntityKeysBody([NotNull] KayleeParser.EntityKeysBodyContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="KayleeParser.entityKeyPrimary"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterEntityKeyPrimary([NotNull] KayleeParser.EntityKeyPrimaryContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KayleeParser.entityKeyPrimary"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitEntityKeyPrimary([NotNull] KayleeParser.EntityKeyPrimaryContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="KayleeParser.entityKeyReference"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterEntityKeyReference([NotNull] KayleeParser.EntityKeyReferenceContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KayleeParser.entityKeyReference"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitEntityKeyReference([NotNull] KayleeParser.EntityKeyReferenceContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="KayleeParser.mutations"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterMutations([NotNull] KayleeParser.MutationsContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KayleeParser.mutations"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitMutations([NotNull] KayleeParser.MutationsContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="KayleeParser.mutationsBody"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterMutationsBody([NotNull] KayleeParser.MutationsBodyContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KayleeParser.mutationsBody"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitMutationsBody([NotNull] KayleeParser.MutationsBodyContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="KayleeParser.mutation"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterMutation([NotNull] KayleeParser.MutationContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KayleeParser.mutation"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitMutation([NotNull] KayleeParser.MutationContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="KayleeParser.qualified"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterQualified([NotNull] KayleeParser.QualifiedContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KayleeParser.qualified"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitQualified([NotNull] KayleeParser.QualifiedContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="KayleeParser.identifierList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIdentifierList([NotNull] KayleeParser.IdentifierListContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KayleeParser.identifierList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIdentifierList([NotNull] KayleeParser.IdentifierListContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="KayleeParser.dtype"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterDtype([NotNull] KayleeParser.DtypeContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KayleeParser.dtype"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitDtype([NotNull] KayleeParser.DtypeContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="KayleeParser.dtypeIntAutoIncrement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterDtypeIntAutoIncrement([NotNull] KayleeParser.DtypeIntAutoIncrementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KayleeParser.dtypeIntAutoIncrement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitDtypeIntAutoIncrement([NotNull] KayleeParser.DtypeIntAutoIncrementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="KayleeParser.dtypeTextSize"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterDtypeTextSize([NotNull] KayleeParser.DtypeTextSizeContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KayleeParser.dtypeTextSize"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitDtypeTextSize([NotNull] KayleeParser.DtypeTextSizeContext context);
}
