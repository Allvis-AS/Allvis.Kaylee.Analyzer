using System;
using System.Runtime.Serialization;

namespace Allvis.Kaylee.Analyzer.Exceptions
{
    public class FieldNotFoundException : NotFoundException
    {
        private static string Compose(string fieldName)
            => $"Failed to resolve the field {fieldName}.";

        public FieldNotFoundException()
        {
        }

        public FieldNotFoundException(string fieldName) : base(Compose(fieldName))
        {
        }

        public FieldNotFoundException(string fieldName, Exception innerException) : base(Compose(fieldName), innerException)
        {
        }

        protected FieldNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
