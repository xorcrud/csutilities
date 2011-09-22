using Microsoft.Commerce.Contracts;

namespace CSUtilities.Mappers
{
	internal abstract class BaseMapping
	{
		public string ModelName { get; protected set; }
		public abstract object MapTo(CommerceEntity entity);
		public abstract CommerceEntity MapFrom(object from);
	}
}