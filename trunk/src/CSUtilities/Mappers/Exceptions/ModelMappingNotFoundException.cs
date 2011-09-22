using System;
using System.Runtime.Serialization;

namespace CSUtilities.Mappers.Exceptions
{
    [Serializable]
	public class ModelMappingNotFoundException : Exception
	{
        public ModelMappingNotFoundException() : this(Resources.Exceptions.Mapping_ModelNotFound)
        {
        }

        public ModelMappingNotFoundException(string message) : base(message)
        {
        }

        public ModelMappingNotFoundException(string message, Exception inner) : base(message, inner)
        {
        }

        protected ModelMappingNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
	}
}