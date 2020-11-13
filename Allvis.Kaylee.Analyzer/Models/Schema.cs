using Allvis.Kaylee.Analyzer.Exceptions;
using Allvis.Kaylee.Analyzer.Extensions;
using System;
using System.Collections.Generic;

namespace Allvis.Kaylee.Analyzer.Models
{
    public class Schema
    {
        public Ast Ast { get; }
        public string Name { get; set; } = string.Empty;
        public List<Entity> Entities { get; } = new List<Entity>();

        public Schema(Ast ast)
        {
            Ast = ast;

            ast.Schemata.Add(this);
        }

        public Entity Locate(IEnumerable<string> path)
        {
            try
            {
                return Entities.Locate(path);
            }
            catch (InvalidOperationException)
            {
                throw new EntityNotFoundException($"{Name}::{string.Join(".", path)}");
            }
        }
    }
}