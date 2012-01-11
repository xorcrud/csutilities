using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using CSUtilities.Infrastructure.Utilities;
using CSUtilities.Mappers.Attributes;
using Microsoft.Commerce.Contracts;

namespace CSUtilities.Mappers
{
	public class Mapper
	{
		private readonly IDictionary<RuntimeTypeHandle, BaseMapping> _mappings =
			new Dictionary<RuntimeTypeHandle, BaseMapping>();

		public TTo Map<TTo>(CommerceEntity from) where TTo : class, new()
		{
			return ClassMapper<CommerceEntity, TTo>.MapIfNotNull(from, () => (TTo)Map(from, typeof(TTo)));
		}

		public IEnumerable<TTo> Map<TTo>(IEnumerable<CommerceEntity> from) where TTo : class, new()
		{
			return ClassMapper<CommerceEntity, TTo>.MapIfNotNull(from, Map<TTo>);
		}

		public object Map(CommerceEntity from, Type mappedType)
		{
			return ClassMapper<CommerceEntity, object>.MapIfNotNull(from, () =>
				{
					BaseMapping baseMapping = GetMapping(mappedType);
					return baseMapping != null ? baseMapping.MapTo(from) : null;
				});
		}

		internal BaseMapping GetMapping(Type typeInfo)
		{
			BaseMapping baseMapping = null;
			if (_mappings.ContainsKey(typeInfo.TypeHandle))
				baseMapping = _mappings[typeInfo.TypeHandle];
			else
			{
				var genericMappingType = typeof(Mapping<>);
				var mappingType = genericMappingType.MakeGenericType(new[] { typeInfo });
				var mapping = (BaseMapping)Activator.CreateInstance(mappingType);

				if (!String.IsNullOrEmpty(mapping.ModelName))
				{
					_mappings.Add(typeInfo.TypeHandle, mapping);
					baseMapping = mapping;
				}
			}

			return baseMapping;
		}

		public CommerceEntity Map(object from)
		{
			return ClassMapper<object, CommerceEntity>.MapIfNotNull(from, () =>
				{
					BaseMapping mapping = GetMapping(from.GetType());
					return (mapping != null) ? mapping.MapFrom(from) : null;
				});
		}

        public static string GetFieldName<TDomainEntity, TValue>(Expression<Func<TDomainEntity, TValue>> expression) where TDomainEntity : class, new()
		{
			var mappingAttribute = GetMappingAttribute(expression);
			string fieldName = null;

			if (mappingAttribute != null)
			{
				fieldName = mappingAttribute.FieldName;
			}

			return fieldName;
		}

		public static string GetRelationshipName<TDomainEntity, TValue>(Expression<Func<TDomainEntity, TValue>> expression) where TDomainEntity : class, new()
		{
			var mappingAttribute = GetMappingAttribute(expression);
			string fieldName = null;

			if (mappingAttribute != null)
			{
				fieldName = mappingAttribute.FieldName;
			}

			return fieldName;
		}

		public static string GetModelName<TDomainEntity>() where TDomainEntity : class, new()
		{
			var modelMapping = typeof(TDomainEntity).GetAttribute<ModelMappingAttribute>();
			return modelMapping.ModelName;
		}

		public static MappingAttribute GetMappingAttribute<TDomainEntity, TValue>(Expression<Func<TDomainEntity, TValue>> expression) where TDomainEntity : class, new()
		{
			PropertyInfo info = StaticReflection.PropertyInfo(expression);

			return GetMappingAttribute(info);
		}

		private static MappingAttribute GetMappingAttribute(PropertyInfo propertyInfo)
		{
		    if (propertyInfo == null) throw new ArgumentNullException("propertyInfo");

		    var mappingAttribute = propertyInfo.GetAttribute<MappingAttribute>();

			if (mappingAttribute != null && String.IsNullOrEmpty(mappingAttribute.FieldName))
			{
				mappingAttribute.FieldName = propertyInfo.Name;
			}

			return mappingAttribute;
		}

		public IEnumerable<string> PropertyNamesOf<TDomainEntity>() where TDomainEntity : class, new()
		{
			var mapping = (Mapping<TDomainEntity>)GetMapping(typeof(TDomainEntity));
			return mapping.Properties.Select(p => p.FieldName);
		}
	}
}