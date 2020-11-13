using Allvis.Kaylee.Analyzer.Exceptions;
using Allvis.Kaylee.Analyzer.Extensions;
using Allvis.Kaylee.Analyzer.Utils;
using System;
using System.Collections.Generic;

namespace Allvis.Kaylee.Analyzer.Models
{
    public class Entity
    {
        public Schema Schema { get; }
        public Entity Parent { get; }
        public string Name { get; }
        public IEnumerable<string> Path { get; }
        public List<Field> Fields { get; } = new List<Field>();
        public List<FieldReference> PrimaryKey { get; } = new List<FieldReference>();
        public List<Reference> References { get; } = new List<Reference>();
        public List<Mutation> Mutations { get; } = new List<Mutation>();
        public List<Entity> Children { get; } = new List<Entity>();

        public string DisplayName => $"{Schema.Name}::{string.Join(".", Path)}";

        public Entity(Schema schema, Entity parent, string name)
        {
            Schema = schema;
            Parent = parent;
            Name = name;
            Path = ConstructPath();

            if (parent != null)
            {
                CircularDependencyUtils.Check(parent, this);
                parent.Children.Add(this);
            }
            else
            {
                schema.Entities.Add(this);
            }
        }

        private List<string> ConstructPath()
        {
            var path = new List<string>();
            ConstructPath(path);
            return path;
        }

        private void ConstructPath(List<string> path)
        {
            if (Parent != null)
            {
                Parent.ConstructPath(path);
            }
            path.Add(Name);
        }

        public Entity Locate(IEnumerable<string> path)
        {
            try
            {
                return Children.Locate(path);
            }
            catch (InvalidOperationException)
            {
                throw new EntityNotFoundException($"{DisplayName}.{string.Join(".", path)}");
            }
        }

        public Field Locate(string fieldName)
        {
            try
            {
                return Fields.Locate(fieldName);
            }
            catch (InvalidOperationException)
            {
                throw new FieldNotFoundException($"{DisplayName}.{fieldName}");
            }
        }

        public void ResolveReferences()
        {
            foreach (var fieldReference in PrimaryKey)
            {
                fieldReference.Resolve(Schema.Ast);

                if (fieldReference.ResolvedField.Entity != this)
                {
                    throw new SemanticException($"The primary key field \"{fieldReference.FieldName}\" referenced the entity \"{fieldReference.ResolvedField.Entity.DisplayName}\" instead of the current entity \"{DisplayName}\".");
                }
            }
            foreach (var reference in References)
            {
                reference.ResolveReferences(Schema.Ast);
            }
            foreach (var mutation in Mutations)
            {
                mutation.ResolveReferences();
            }
        }
    }
}