using System;

namespace CSUtilities.Mappers.Attributes
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
	public sealed class MappingAttribute : Attribute
	{
		public MappingAttribute()
			: this(MappingType.Property)
		{
		}

		public MappingAttribute(MappingType mappingType)
		{
			Mapping = mappingType;
		}

		public MappingAttribute(string fieldName)
			: this()
		{
			FieldName = fieldName;
		}

		public MappingAttribute(MappingType mappingType, string fieldName)
			: this(mappingType)
		{
			FieldName = fieldName;
		}

		public MappingAttribute(MappingType mappingType, string fieldName, Type fromConverter)
			: this(mappingType, fieldName)
		{
			FromConverter = fromConverter;
		}

		public MappingAttribute(MappingType mappingType, string fieldName, Type fromConverter, Type toConverter)
			: this(mappingType, fieldName)
		{
			FromConverter = fromConverter;
			ToConverter = toConverter;
		}

		public MappingType Mapping { get; set; }
		public string FieldName { get; set; }
		public Type FromConverter { get; set; }
		public Type ToConverter { get; set; }
		public Type ExpectedType { get; set; }
		public bool ToSingle { get; set; }
	}
}