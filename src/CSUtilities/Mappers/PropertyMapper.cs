using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CSUtilities.Extensions;
using CSUtilities.Infrastructure.Utilities;
using CSUtilities.Mappers.Attributes;
using CSUtilities.Mappers.Converters;
using CSUtilities.Mappers.Exceptions;
using Microsoft.Commerce.Contracts;

namespace CSUtilities.Mappers
{
	internal class PropertyMapper
	{
		private const string DefaultIdName = "Id";
		private const string AddMethodName = "Add";

		private readonly Mapper _mapper;

		public PropertyMapper(PropertyInfo propertyInfo, MappingAttribute mappingAttribute)
		{
			if (propertyInfo == null)
				throw new MappingException("PropertyMapping must contain the PropertyInfo or else it cant map the property");

			if (mappingAttribute == null)
				throw new MappingException("A PropertyMapping must have a mapping attribute specified");

			Info = propertyInfo;
			MappingInfo = mappingAttribute;
			_mapper = new Mapper();

			if (mappingAttribute.Mapping == MappingType.Relationship && mappingAttribute.ToSingle == false)
			{
				ListElementType = Info.PropertyType.GetGenericArguments().FirstOrDefault();

				Type genericListType = typeof(List<>);
				GeneratedListType = genericListType.MakeGenericType(new[] { ListElementType });
				AddMethod = GeneratedListType.GetMethod(AddMethodName);
			}
		}

		internal MethodInfo AddMethod { get; set; }

		internal Type GeneratedListType { get; set; }
		internal Type ListElementType { get; set; }

		public MappingAttribute MappingInfo { get; private set; }

		internal PropertyInfo Info { get; set; }

		public string FieldName
		{
			get { return !String.IsNullOrEmpty(MappingInfo.FieldName) ? MappingInfo.FieldName : Info.Name; }
		}

		public object MapTo(object mapped, CommerceEntity entity)
		{
			MappingType mappingType = MappingInfo.Mapping;
			object value = entity.GetPropertyValue(FieldName);

			if (MappingInfo.FromConverter != null)
				value = ConverterLazyRegistry.Instance.Resolve(MappingInfo.FromConverter).Convert(value);
			else if (value != null)
			{
				if (mappingType == MappingType.Property)
				{
					if (value.GetType() != Info.PropertyType)
						value = Convert.ChangeType(value, Info.PropertyType);
				}
				else if (mappingType == MappingType.Identity)
				{
					if (MappingInfo.FromConverter == null && !String.IsNullOrEmpty(value.ToString()))
						value = new Guid(value.ToString());
					else
					{
						value = null;
					}
				}
				else
				{
					var mapper = new Mapper();

					var relationshipList = value as CommerceRelationshipList;

					if (relationshipList != null)
					{
						value = Activator.CreateInstance(GeneratedListType);

						foreach (var relation in relationshipList)
						{
							object element = mapper.Map(relation.Target, ListElementType);

							AddMethod.Invoke(value, new[] { element });
						}
					}
					else
					{
						var relationship = value as CommerceRelationship;
						if (relationship != null)
						{
							value = mapper.Map(relationship.Target, Info.PropertyType);
						}
					}
				}
			}


			if (value != null || (ReflectionHelper.IsNullableType(Info.PropertyType) || !Info.PropertyType.IsValueType))
				Info.SetValue(mapped, value, null);

			return mapped;
		}

		public CommerceEntity MapFrom(object mapped, CommerceEntity entity)
		{
			MappingType mappingType = MappingInfo.Mapping;
			object value = Info.GetValue(mapped, null);

			// IsDefault and Object doesnt go that well so im validating these to special cases before accepting not null to be valid.
			if (Info.PropertyType == typeof(Guid) && value.SafeToString() == default(Guid).ToString())
				value = null;
			if (Info.PropertyType == typeof(DateTime) && value.SafeToString() == default(DateTime).ToString())
				value = null;

			if (value != null)
			{
				if (MappingInfo.ToConverter != null)
					value = ConverterLazyRegistry.Instance.Resolve(MappingInfo.ToConverter).Convert(value);
				else if (MappingInfo.ExpectedType != null && value.GetType() != MappingInfo.ExpectedType)
				{
					if (value as IConvertible != null)
						value = Convert.ChangeType(value, MappingInfo.ExpectedType);
					else if (MappingInfo.ExpectedType == typeof(string))
						value = value.SafeToString();
				}

				if (mappingType == MappingType.Identity && FieldName == DefaultIdName)
				{
					entity.Id = ((Guid)value).ToCommerceId();
					return entity;
				}
			}

			if (mappingType == MappingType.Relationship)
			{
				IEnumerable elements = null;
				if (value != null)
					elements = value as IEnumerable;


				if (!MappingInfo.ToSingle)
				{
					var csRelationshipList = new CommerceRelationshipList();

					if (elements != null)
						foreach (var element in elements)
						{
							var csEntity = _mapper.Map(element);

							var relationship = new CommerceRelationship(csEntity);
							csRelationshipList.Add(relationship);

						}
					value = csRelationshipList;
				}
				else
				{
					CommerceEntity csEntity = null;
					if (value != null)
						csEntity = _mapper.Map(value);

					var relationship = new CommerceRelationship(csEntity);
					value = relationship;
				}


			}

			entity.SetPropertyValue(FieldName, value);

			return entity;
		}
	}
}