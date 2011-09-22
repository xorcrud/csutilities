using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CSUtilities.Extensions;
using CSUtilities.Infrastructure.Utilities;
using CSUtilities.Mappers.Attributes;
using CSUtilities.Mappers.Exceptions;
using Microsoft.Commerce.Contracts;

namespace CSUtilities.Mappers
{
	internal class Mapping<TTo> : BaseMapping where TTo : class, new()
	{
		public Mapping()
		{
			Properties = new List<PropertyMapper>();

			Type typeInfo = typeof(TTo);

			var modelMapping = typeInfo.GetAttribute<ModelMappingAttribute>();
			if (modelMapping != null && !String.IsNullOrEmpty(modelMapping.ModelName))
			{
				ModelName = modelMapping.ModelName;

				var properties = typeInfo.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
					.Where(p => p.CanRead && p.CanWrite);

				foreach (PropertyInfo info in properties)
				{
					var mappingAttribute = info.GetAttribute<MappingAttribute>();

					if (mappingAttribute != null)
					{
						var propertyMapping = new PropertyMapper(info, mappingAttribute);
						Properties.Add(propertyMapping);
					}
				}
			}
			else
			{
				throw new ModelMappingNotFoundException();
			}
		}

		public IList<PropertyMapper> Properties { get; set; }

		public override object MapTo(CommerceEntity entity)
		{
			entity.AssertModel(ModelName);

			var mapped = new TTo();

			foreach (PropertyMapper mapper in Properties)
			{
				mapper.MapTo(mapped, entity);
			}

			return mapped;
		}

		public override CommerceEntity MapFrom(object from)
		{
			var entity = new CommerceEntity(ModelName);
			foreach (PropertyMapper mapper in Properties)
			{
				mapper.MapFrom(from, entity);
			}

			return entity;
		}
	}
}