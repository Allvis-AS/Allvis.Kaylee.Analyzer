using Allvis.Kaylee.Analyzer.Extensions;
using Allvis.Kaylee.Analyzer.Models;
using System;

namespace Allvis.Kaylee.Analyzer.Utils
{
    public static class CircularDependencyUtils
    {
        public static void Check(Entity parent, Entity child)
        {
            if (child.IsAncestorOf(parent))
            {
                throw new InvalidOperationException($"The entity {child.DisplayName} is an ancestor of {parent.DisplayName}, therefore {parent.DisplayName} can not be made the parent of {child.DisplayName}.");
            }
        }
    }
}
