using Allvis.Kaylee.Analyzer.Models;
using Antlr4.Runtime.Misc;

namespace Allvis.Kaylee.Analyzer.Listeners
{
    public class PrimaryKeyListener : KayleeParserBaseListener
    {
        public Entity Entity { get; }

        public PrimaryKeyListener(Entity entity)
        {
            Entity = entity;
        }

        public override void EnterEntityKeyPrimary([NotNull] KayleeParser.EntityKeyPrimaryContext context)
        {
            var identifierList = context.identifierList();
            var identifiers = identifierList.IDENTIFIER();
            foreach (var identifier in identifiers)
            {
                var fieldReference = new FieldReference
                {
                    SchemaName = Entity.Schema.Name,
                    FieldName = identifier.GetText()
                };
                fieldReference.EntityPath.AddRange(Entity.Path);
                Entity.PrimaryKey.Add(fieldReference);
            }
        }
    }
}
