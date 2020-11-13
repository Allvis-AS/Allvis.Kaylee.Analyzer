using Allvis.Kaylee.Analyzer.Exceptions;
using Allvis.Kaylee.Analyzer.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Allvis.Kaylee.Analyzer.Extensions
{
    public static class EntityExtensions
    {
        public static Entity Locate(this IEnumerable<Entity> entities, IEnumerable<string> path)
        {
            var domain = entities;
            Entity entity = null;
            foreach (var name in path)
            {
                entity = domain.Single(e => e.Name == name);
                domain = entity.Children;
            }
            if (entity == null)
            {
                throw new InvalidOperationException();
            }
            return entity;
        }

        public static Field Locate(this IEnumerable<Field> fields, string name)
            => fields.Single(f => f.Name == name);
    }
}
