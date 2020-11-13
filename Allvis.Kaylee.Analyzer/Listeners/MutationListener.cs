using Allvis.Kaylee.Analyzer.Models;
using Antlr4.Runtime.Misc;

namespace Allvis.Kaylee.Analyzer.Listeners
{
    public class MutationListener : KayleeParserBaseListener
    {
        public Mutation Mutation { get; }

        public MutationListener(Entity entity)
        {
            Mutation = new Mutation(entity);
        }

        public override void EnterMutation([NotNull] KayleeParser.MutationContext context)
        {
            var identifier = context.IDENTIFIER();
            Mutation.Name = identifier.GetText();

            var parameterList = context.identifierList();
            var parameters = parameterList.IDENTIFIER();
            foreach (var parameter in parameters)
            {
                var reference = new FieldReference
                {
                    SchemaName = Mutation.Entity.Schema.Name,
                    FieldName = parameter.GetText()
                };
                reference.EntityPath.AddRange(Mutation.Entity.Path);
                Mutation.FieldReferences.Add(reference);
            }
        }
    }
}
