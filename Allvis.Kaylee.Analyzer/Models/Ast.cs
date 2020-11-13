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
    }
}