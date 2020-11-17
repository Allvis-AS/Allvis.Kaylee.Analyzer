using Allvis.Kaylee.Analyzer.Listeners;
using Allvis.Kaylee.Analyzer.Models;
using Antlr4.Runtime;

namespace Allvis.Kaylee.Analyzer
{
    public static class KayleeHelper
    {
        public static Ast Parse(string model)
        {
            var parser = CreateParser(model);
            parser.BuildParseTree = true;
            var parseListener = new ParseListener();
            parser.parse().EnterRule(parseListener);
            return parseListener.Ast;
        }

        private static KayleeParser CreateParser(string model)
        {
            var stream = CharStreams.fromstring(model);
            var lexer = new KayleeLexer(stream);
            var tokens = new CommonTokenStream(lexer);
            return new KayleeParser(tokens);
        }
    }
}
