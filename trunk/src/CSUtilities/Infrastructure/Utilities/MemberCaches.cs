using System;
using System.Reflection;

namespace CSUtilities.Infrastructure.Utilities
{
	internal class TypeCache<T> : IIdentityMap<Type, T> where T : class
	{
		private readonly DictionaryIdentityMap<RuntimeTypeHandle, T> _inner = new DictionaryIdentityMap<RuntimeTypeHandle, T>();

		#region Implementation of IIdentityMap<Type,T>

		public bool Register(Type key, T instance)
		{
			return _inner.Register(key.TypeHandle, instance);
		}

		public bool UnRegister(Type key)
		{
			return _inner.UnRegister(key.TypeHandle);
		}

		public bool Contains(Type key)
		{
			return _inner.Contains(key.TypeHandle);
		}

		public T Retrieve(Type key)
		{
			return _inner.Retrieve(key.TypeHandle);
		}

		public T this[Type key]
		{
			get { return _inner[key.TypeHandle]; }
		}

		#endregion
	}

	public class MethodCache<T> : IIdentityMap<MethodInfo, T> where T : class
	{
		private readonly DictionaryIdentityMap<RuntimeMethodHandle, T> _inner = new DictionaryIdentityMap<RuntimeMethodHandle, T>();

		#region Implementation of IIdentityMap<Type,T>

		public bool Register(MethodInfo key, T instance)
		{
			return _inner.Register(key.MethodHandle, instance);
		}

		public bool UnRegister(MethodInfo key)
		{
			return _inner.UnRegister(key.MethodHandle);
		}

		public bool Contains(MethodInfo key)
		{
			return _inner.Contains(key.MethodHandle);
		}

		public T Retrieve(MethodInfo key)
		{
			return _inner.Retrieve(key.MethodHandle);
		}

		public T this[MethodInfo key]
		{
			get { return _inner[key.MethodHandle]; }
		}

		#endregion
	}

	public class PropertyGetterCache<T> : IIdentityMap<PropertyInfo, T> where T : class
	{
		private readonly DictionaryIdentityMap<RuntimeMethodHandle, T> _inner = new DictionaryIdentityMap<RuntimeMethodHandle, T>();

		#region Implementation of IIdentityMap<Type,T>

		public bool Register(PropertyInfo key, T instance)
		{
			MethodInfo getter = key.GetGetMethod();
			return getter == null ? false : _inner.Register(getter.MethodHandle, instance);
		}

		public bool UnRegister(PropertyInfo key)
		{
			MethodInfo getter = key.GetGetMethod();
			return getter == null ? false : _inner.UnRegister(getter.MethodHandle);
		}

		public bool Contains(PropertyInfo key)
		{
			MethodInfo getter = key.GetGetMethod();
			return getter == null ? false : _inner.Contains(getter.MethodHandle);
		}

		public T Retrieve(PropertyInfo key)
		{
			MethodInfo getter = key.GetGetMethod();
			return getter == null ? null : _inner.Retrieve(getter.MethodHandle);
		}

		public T this[PropertyInfo key]
		{
			get
			{
				MethodInfo getter = key.GetGetMethod();
				return getter == null ? null : _inner[getter.MethodHandle];
			}
		}

		#endregion
	}

	public class PropertySetterCache<T> : IIdentityMap<PropertyInfo, T> where T : class
	{
		private readonly DictionaryIdentityMap<RuntimeMethodHandle, T> _inner = new DictionaryIdentityMap<RuntimeMethodHandle, T>();

		#region Implementation of IIdentityMap<Type,T>

		public bool Register(PropertyInfo key, T instance)
		{
			MethodInfo setter = key.GetSetMethod();
			return setter == null ? false : _inner.Register(setter.MethodHandle, instance);
		}

		public bool UnRegister(PropertyInfo key)
		{
			MethodInfo setter = key.GetSetMethod();
			return setter == null ? false : _inner.UnRegister(setter.MethodHandle);
		}

		public bool Contains(PropertyInfo key)
		{
			MethodInfo setter = key.GetSetMethod();
			return setter == null ? false : _inner.Contains(setter.MethodHandle);
		}

		public T Retrieve(PropertyInfo key)
		{
			MethodInfo setter = key.GetSetMethod();
			return setter == null ? null : _inner.Retrieve(setter.MethodHandle);
		}

		public T this[PropertyInfo key]
		{
			get
			{
				MethodInfo setter = key.GetSetMethod();
				return setter == null ? null : _inner[setter.MethodHandle];
			}
		}

		#endregion
	}

	/// <summary>
	/// Stores information based on a field
	/// </summary>
	/// <remarks>Internally used the <see cref="FieldInfo.FieldHandle"/> structure as a key as it is lighter that the whole
	/// <see cref="FieldInfo"/> class.</remarks>
	/// <typeparam name="T">Type of the information to be stored.</typeparam>
	public class FieldCache<T> : IIdentityMap<FieldInfo, T> where T : class
	{
		private readonly IIdentityMap<RuntimeFieldHandle, T> _inner = new DictionaryIdentityMap<RuntimeFieldHandle, T>();

		#region Implementation of IIdentityMap<Type,T>

		public bool Register(FieldInfo key, T instance)
		{
			return _inner.Register(key.FieldHandle, instance);
		}

		public bool UnRegister(FieldInfo key)
		{
			return _inner.UnRegister(key.FieldHandle);
		}

		public bool Contains(FieldInfo key)
		{
			return _inner.Contains(key.FieldHandle);
		}

		public T Retrieve(FieldInfo key)
		{
			return _inner.Retrieve(key.FieldHandle);
		}

		public T this[FieldInfo key]
		{
			get
			{
				return _inner[key.FieldHandle];
			}
		}

		#endregion
	}

	/// <summary>
	/// Stores information based on an enumeration value (it's a field indeed).
	/// </summary>
	/// <typeparam name="T">Type of the information to be stored.</typeparam>
	/// <remarks>As calling <see cref="FieldInfo.FieldHandle"/> on a field of an enum throws a <see cref="NotSupportedException"/>
	/// the key to store the value is the heavier whole <see cref="FieldInfo"/> class.
	/// </remarks>
	internal class EnumCache<T> : IIdentityMap<FieldInfo, T> where T : class
	{
		private readonly IIdentityMap<FieldInfo, T> _inner;

		public EnumCache()
		{
			_inner = new DictionaryIdentityMap<FieldInfo, T>();
		}

		public EnumCache(IIdentityMap<FieldInfo, T> inner)
		{
			_inner = inner;
		}

		#region Implementation of IIdentityMap<Type,T>

		public bool Register(FieldInfo key, T instance)
		{
			return _inner.Register(key, instance);
		}

		public bool UnRegister(FieldInfo key)
		{
			return _inner.UnRegister(key);
		}

		public bool Contains(FieldInfo key)
		{
			return _inner.Contains(key);
		}

		public T Retrieve(FieldInfo key)
		{
			return _inner.Retrieve(key);
		}

		public T this[FieldInfo key]
		{
			get
			{
				return _inner[key];
			}
		}

		#endregion
	}
}
