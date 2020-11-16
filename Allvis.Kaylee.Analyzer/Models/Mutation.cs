using System.Collections.Generic;

namespace Allvis.Kaylee.Analyzer.Models
{
    public class Mutation
    {
        public Entity Entity { get; }
        public string Name { get; set; } = string.Empty;
        public List<FieldReference> FieldReferences { get; } = new List<FieldReference>();

        public Mutation(Entity entity)
        {
            Entity = entity;

            entity.Mutations.Add(this);
        }

        public void ResolveReferences()
        {
            foreach (var fieldReference in FieldReferences)
            {
                fieldReference.Resolve(Entity.Schema.Ast);
            }
        }
    }
}