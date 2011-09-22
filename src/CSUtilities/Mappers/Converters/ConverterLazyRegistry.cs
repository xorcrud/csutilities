using System;
using CSUtilities.Infrastructure.Utilities;

namespace CSUtilities.Mappers.Converters
{
	public class ConverterLazyRegistry
	{
		private readonly TypeCache<IConverter> _cache;

		internal ConverterLazyRegistry()
		{
			_cache = new TypeCache<IConverter>();
		}

		private readonly object _cachePadlock = new object();
		public IConverter Resolve(Type type)
		{
			if (!_cache.Contains(type))
			{
				lock (_cachePadlock)
				{
					if (!_cache.Contains(type))
					{
						_cache.Register(type, (IConverter) Activator.CreateInstance(type));
					}
				}
			}
			return _cache.Retrieve(type);
		}

		public IConverter Resolve<T>()
		{
			return Resolve(typeof(T));
		}

		public static ConverterLazyRegistry Instance
		{
			get { return Nested._instance; }
		}

		#region Nested type: Nested

		private static class Nested
		{
			public static readonly ConverterLazyRegistry _instance = new ConverterLazyRegistry();
		}

		#endregion
	}
}