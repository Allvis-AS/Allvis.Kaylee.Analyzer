using Allvis.Kaylee.Analyzer.Enums;

namespace Allvis.Kaylee.Analyzer.Models
{
    public class Field
    {
        public Entity Entity { get; }
        public string Name { get; set; } = string.Empty;
        public FieldType Type { get; set; }
        public FieldSize Size { get; set; } = FieldSize.Identity();
        public bool Nullable { get; set; }
        public bool AutoIncrement { get; set; }
        public string DefaultExpression { get; set; }

        public string DisplayName => $"{Entity.DisplayName}.{Name}";

        public Field(Entity entity)
        {
            Entity = entity;

            entity.Fields.Add(this);
        }
    }
}