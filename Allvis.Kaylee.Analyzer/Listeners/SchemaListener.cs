using Allvis.Kaylee.Analyzer.Models;
using Antlr4.Runtime.Misc;

namespace Allvis.Kaylee.Analyzer.Listeners
{
    public class SchemaListener : KayleeParserBaseListener
    {
        public Schema Schema { get; }

        public SchemaListener(Ast ast)
        {
            Schema = new Schema(ast);
        }

        public override void EnterSchema([NotNull] KayleeParser.SchemaContext context)
        {
            var identifier = context.IDENTIFIER();
            Schema.Name = identifier.GetText();

            var body = context.schemaBody();
            var entities = body.entity();
            foreach (var entity in entities)
            {
                var entityListener = new EntityListener(Schema);
                entity.EnterRule(entityListener);
            }
        }
    }
}
