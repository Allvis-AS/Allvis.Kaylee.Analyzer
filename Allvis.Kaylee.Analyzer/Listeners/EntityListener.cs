using Allvis.Kaylee.Analyzer.Models;
using Antlr4.Runtime.Misc;
using System;
using System.Linq;

namespace Allvis.Kaylee.Analyzer.Listeners
{
    public class EntityListener : KayleeParserBaseListener
    {
        private readonly Schema schema;
        private readonly Entity parent;

        public Entity Entity { get; private set; }

        public EntityListener(Schema schema, Entity parent = null)
        {
            this.schema = schema;
            this.parent = parent;
        }

        public override void EnterEntity([NotNull] KayleeParser.EntityContext context)
        {
            var identifier = context.IDENTIFIER();
            Entity = new Entity(schema, parent, identifier.GetText());

            var body = context.entityBody();
            VisitFields(body);
            VisitKeys(body);
            VisitMutations(body);
            VisitEntities(body);
        }

        private void VisitFields(KayleeParser.EntityBodyContext entityBody)
        {
            // TODO
            throw new NotImplementedException();
        }

        private void VisitKeys(KayleeParser.EntityBodyContext entityBody)
        {
            // TODO
            throw new NotImplementedException();
        }

        private void VisitMutations(KayleeParser.EntityBodyContext entityBody)
        {
            // This nesting is caused by the fact that there can be multiple
            // "mutations" blocks in a single entity, so we have to dive two
            // levels deep.
            var mutationsBodies = entityBody.mutations().Select(m => m.mutationsBody());
            foreach (var body in mutationsBodies)
            {
                var mutations = body.mutation();
                foreach (var mutation in mutations)
                {
                    var mutationListener = new MutationListener(Entity);
                    mutation.EnterRule(mutationListener);
                    Entity.Mutations.Add(mutationListener.Mutation);
                }
            }
        }

        private void VisitEntities(KayleeParser.EntityBodyContext body)
        {
            var entities = body.entity();
            foreach (var entity in entities)
            {
                var entityListener = new EntityListener(Entity.Schema, Entity);
                entity.EnterRule(entityListener);
                Entity.Children.Add(entityListener.Entity);
            }
        }
    }
}
