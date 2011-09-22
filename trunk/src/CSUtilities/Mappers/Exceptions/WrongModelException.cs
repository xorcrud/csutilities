using System;
using System.Runtime.Serialization;
using Microsoft.Commerce.Contracts;

namespace CSUtilities.Mappers.Exceptions
{
    [Serializable]
    public class WrongModelException : Exception
    {
        public WrongModelException()
        {
        }

        public WrongModelException(ICommerceEntity entity, string expectedModelName) :
            this(String.Format(Resources.Exceptions.Entity_WrongModel, entity.ModelName, expectedModelName))
        {
        }

        public WrongModelException(string message) : base(message)
        {
        }

        public WrongModelException(string message, Exception inner) : base(message, inner)
        {
        }

        protected WrongModelException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}