using Allvis.Kaylee.Analyzer.Models;
using Antlr4.Runtime.Misc;

namespace Allvis.Kaylee.Analyzer.Listeners
{
    public class UniqueKeyListener : KayleeParserBaseListener
    {
        public Entity Entity { get; }

        public UniqueKeyListener(Entity entity)
        {
            Entity = entity;
        }

        public override void EnterEntityKeyUnique([NotNull] KayleeParser.EntityKeyUniqueContext context)
        {
            var identifierList = context.identifierList();
            var identifiers = identifierList.IDENTIFIER();
            var uniqueKey = new UniqueKey(Entity);
            foreach (var identifier in identifiers)
            {
                var fieldReference = new FieldReference
                {
                    SchemaName = Entity.Schema.Name,
                    FieldName = identifier.GetText()
                };
                fieldReference.EntityPath.AddRange(Entity.Path);
                uniqueKey.FieldReferences.Add(fieldReference);
            }
        }
    }
}
