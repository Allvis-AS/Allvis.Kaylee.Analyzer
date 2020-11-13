using System;
using System.Runtime.Serialization;

namespace Allvis.Kaylee.Analyzer.Exceptions
{
    public class EntityNotFoundException : NotFoundException
    {
        private static string Compose(string entityName)
            => $"Failed to resolve the entity {entityName}.";

        public EntityNotFoundException()
        {
        }

        public EntityNotFoundException(string entityName) : base(Compose(entityName))
        {
        }

        public EntityNotFoundException(string entityName, Exception innerException) : base(Compose(entityName), innerException)
        {
        }

        protected EntityNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
