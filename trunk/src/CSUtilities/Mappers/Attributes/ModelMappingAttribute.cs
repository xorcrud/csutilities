using System;

namespace CSUtilities.Mappers.Attributes
{
	[AttributeUsage(AttributeTargets.Class)]
	public sealed class ModelMappingAttribute : Attribute
	{
		public ModelMappingAttribute(string modelName)
		{
			ModelName = modelName;
		}

		public string ModelName { get; set; }
	}
}