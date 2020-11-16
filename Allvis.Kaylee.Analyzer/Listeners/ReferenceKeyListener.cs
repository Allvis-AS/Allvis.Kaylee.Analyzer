using Allvis.Kaylee.Analyzer.Models;
using Antlr4.Runtime.Misc;
using System.Linq;

namespace Allvis.Kaylee.Analyzer.Listeners
{
    public class ReferenceKeyListener : KayleeParserBaseListener
    {
        public Entity Entity { get; }

        public ReferenceKeyListener(Entity entity)
        {
            Entity = entity;
        }

        public override void EnterEntityKeyReference([NotNull] KayleeParser.EntityKeyReferenceContext context)
        {
            var sourceIdentifierList = context.identifierList(0);
            var targetIdentifierList = context.identifierList(1);
            var sourceIdentifiers = sourceIdentifierList.IDENTIFIER();
            var targetIdentifiers = targetIdentifierList.IDENTIFIER();
            var targetEntity = context.qualified();

            var isFullyQualified = targetEntity.SCHEMA_ACCESSOR() != null;
            var targetSchemaName = isFullyQualified
                ? targetEntity.IDENTIFIER(0).GetText() // Absolute path
                : Entity.Schema.Name; // Relative to current entity
            var targetEntityPath = isFullyQualified
                ? targetEntity.IDENTIFIER().Skip(1).Select(i => i.GetText()) // Absolute path
                : Entity.Path.Concat(targetEntity.IDENTIFIER().Select(i => i.GetText())); // Relative to current entity

            var reference = new Reference();
            foreach (var identifier in sourceIdentifiers)
            {
                var fieldReference = new FieldReference
                {
                    SchemaName = Entity.Schema.Name,
                    FieldName = identifier.GetText()
                };
                fieldReference.EntityPath.AddRange(Entity.Path);
                reference.Source.Add(fieldReference);
            }
            foreach (var identifier in targetIdentifiers)
            {
                var fieldReference = new FieldReference
                {
                    SchemaName = targetSchemaName,
                    FieldName = identifier.GetText()
                };
                fieldReference.EntityPath.AddRange(targetEntityPath);
                reference.Target.Add(fieldReference);
            }
            Entity.References.Add(reference);
        }
    }
}
