using Allvis.Kaylee.Analyzer.Models;
using Antlr4.Runtime.Misc;

namespace Allvis.Kaylee.Analyzer.Listeners
{
    public class ParseListener : KayleeParserBaseListener
    {
        public Ast Ast { get; } = new Ast();

        public override void EnterParse([NotNull] KayleeParser.ParseContext context)
        {
            var schemata = context.schema();
            foreach (var schema in schemata)
            {
                var schemaListener = new SchemaListener(Ast);
                schema.EnterRule(schemaListener);
            }
            ResolveFieldReferences();
        }

        private void ResolveFieldReferences()
        {
            const int MAX_PASSES = 2;
            for (var pass = 0; pass < MAX_PASSES; pass++)
            {
                foreach (var schema in Ast.Schemata)
                {
                    foreach (var entity in schema.Entities)
                    {
                        entity.ResolveReferences(pass);
                    }
                }
            }
        }
    }
}
