using System.Collections.Generic;

namespace Allvis.Kaylee.Analyzer.Models
{
    public class Reference
    {
        public List<FieldReference> Source { get; } = new List<FieldReference>();
        public List<FieldReference> Target { get; } = new List<FieldReference>();

        public void ResolveReferences(Ast ast)
        {
            foreach (var fieldReference in Source)
            {
                fieldReference.Resolve(ast);
            }
            foreach (var fieldReference in Target)
            {
                fieldReference.Resolve(ast);
            }
        }
    }
}