using Allvis.Kaylee.Analyzer.Models;
using Antlr4.Runtime.Misc;
using System;

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
                Ast.Schemata.Add(schemaListener.Schema);
            }
            ResolveFieldReferences();
        }

        private void ResolveFieldReferences()
        {
            foreach (var schema in Ast.Schemata)
            {
                foreach (var entity in schema.Entities)
                {
                    entity.ResolveReferences();
                }
            }
        }
    }
}
