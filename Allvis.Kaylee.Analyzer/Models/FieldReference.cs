using System.Collections.Generic;

namespace Allvis.Kaylee.Analyzer.Models
{
    public class FieldReference
    {
        public string SchemaName { get; set; } = string.Empty;
        public List<string> EntityPath { get; } = new List<string>();
        public string FieldName { get; set; } = string.Empty;

        public Field ResolvedField { get; set; }

        public bool IsResolved => ResolvedField != null;

        public void Resolve(Ast ast)
        {
            if (!IsResolved)
            {
                ResolvedField = ast.Locate(SchemaName, EntityPath, FieldName);
            }
        }
    }
}