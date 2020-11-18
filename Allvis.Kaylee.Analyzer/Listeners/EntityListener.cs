using Allvis.Kaylee.Analyzer.Models;
using Antlr4.Runtime.Misc;
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
            // This nesting is caused by the fact that there can be multiple
            // "fields" blocks in a single entity, so we have to dive 2
            // levels deep.
            var fieldsBodies = entityBody.fields().Select(f => f.fieldsBody());
            foreach (var body in fieldsBodies)
            {
                var fields = body.field();
                foreach (var field in fields)
                {
                    var fieldListener = new FieldListener(Entity);
                    field.EnterRule(fieldListener);
                }
            }
        }

        private void VisitKeys(KayleeParser.EntityBodyContext entityBody)
        {
            // This nesting is caused by the fact that there can be multiple
            // "keys" blocks in a single entity, so we have to dive 2
            // levels deep.
            var keysBodies = entityBody.entityKeys().Select(k => k.entityKeysBody());
            foreach (var body in keysBodies)
            {
                var primaryKeys = body.entityKeyPrimary();
                foreach (var key in primaryKeys)
                {
                    var keyListener = new PrimaryKeyListener(Entity);
                    key.EnterRule(keyListener);
                }
                var uniqueKeys = body.entityKeyUnique();
                foreach (var key in uniqueKeys)
                {
                    var keyListener = new UniqueKeyListener(Entity);
                    key.EnterRule(keyListener);
                }
                var referenceKeys = body.entityKeyReference();
                foreach (var key in referenceKeys)
                {
                    var keyListener = new ReferenceKeyListener(Entity);
                    key.EnterRule(keyListener);
                }
            }
        }

        private void VisitMutations(KayleeParser.EntityBodyContext entityBody)
        {
            // This nesting is caused by the fact that there can be multiple
            // "mutations" blocks in a single entity, so we have to dive 2
            // levels deep.
            var mutationsBodies = entityBody.mutations().Select(m => m.mutationsBody());
            foreach (var body in mutationsBodies)
            {
                var mutations = body.mutation();
                foreach (var mutation in mutations)
                {
                    var mutationListener = new MutationListener(Entity);
                    mutation.EnterRule(mutationListener);
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
            }
        }
    }
}
