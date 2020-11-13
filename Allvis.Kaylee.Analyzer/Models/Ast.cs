using Allvis.Kaylee.Analyzer.Listeners;
using Antlr4.Runtime;
using System.Collections.Generic;
using System.Linq;

namespace Allvis.Kaylee.Analyzer.Models
{
    public class Ast
    {
        public List<Schema> Schemata { get; set; } = new List<Schema>();

        public Field Locate(string schemaName, IEnumerable<string> path, string fieldName)
        {
            var entity = Locate(schemaName, path);
            return entity.Locate(fieldName);
        }

        public Entity Locate(string schemaName, IEnumerable<string> path)
        {
            var schema = Locate(schemaName);
            return schema.Locate(path);
        }

        public Schema Locate(string schemaName)
            => Schemata.Single(s => s.Name == schemaName);

        public static Ast Parse(string model)
        {
            var stream = CharStreams.fromstring(model);
            var lexer = new KayleeLexer(stream);
            var tokens = new CommonTokenStream(lexer);
            var parser = new KayleeParser(tokens)
            {
                BuildParseTree = true
            };

            var parseListener = new ParseListener();
            parser.parse().EnterRule(parseListener);
            return parseListener.Ast;
        }
    }
}