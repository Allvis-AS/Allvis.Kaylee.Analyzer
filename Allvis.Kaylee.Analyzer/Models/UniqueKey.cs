using System.Collections.Generic;

namespace Allvis.Kaylee.Analyzer.Models
{
    public class UniqueKey
    {
        public Entity Entity { get; }
        public List<FieldReference> FieldReferences { get; } = new List<FieldReference>();

        public UniqueKey(Entity entity)
        {
            Entity = entity;

            entity.UniqueKeys.Add(this);
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