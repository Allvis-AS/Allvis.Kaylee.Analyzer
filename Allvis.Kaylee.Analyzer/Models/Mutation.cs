using System.Collections.Generic;

namespace Allvis.Kaylee.Analyzer.Models
{
    public class Mutation
    {
        public Entity Entity { get; }
        public string Name { get; set; } = string.Empty;
        public List<Field> Fields { get; } = new List<Field>();
        public List<FieldReference> FieldReferences { get; } = new List<FieldReference>();

        public Mutation(Entity entity)
        {
            Entity = entity;
        }
    }
}