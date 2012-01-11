using System.Collections.Generic;

namespace CSUtilities.Infrastructure.Utilities
{
	internal class DictionaryIdentityMap<TKey, TValue> : IIdentityMap<TKey, TValue> where TValue : class
	{
		#region constructors

		private readonly IDictionary<TKey, TValue> _inner;

		public DictionaryIdentityMap()
		{
			_inner = new Dictionary<TKey, TValue>();
		}
		public DictionaryIdentityMap(int capacity)
		{
			_inner = new Dictionary<TKey, TValue>(capacity);
		}
		public DictionaryIdentityMap(IEqualityComparer<TKey> comparer)
		{
			_inner = new Dictionary<TKey, TValue>(comparer);
		}
		public DictionaryIdentityMap(int capacity, IEqualityComparer<TKey> comparer)
		{
			_inner = new Dictionary<TKey, TValue>(capacity, comparer);
		}

		internal DictionaryIdentityMap(IDictionary<TKey, TValue> dictionary)
		{
			_inner = dictionary;
		}

		#endregion

		#region IIdentityMap<TKey,TValue> Members

		public bool Register(TKey key, TValue instance)
		{
			bool result = false;
			if (!Contains(key))
			{
				_inner.Add(key, instance);
				result = true;
			}
			return result;
		}

		public bool UnRegister(TKey key)
		{
			bool result = false;
			if (Contains(key))
			{
				result = _inner.Remove(key);
			}

			return result;
		}

		public bool Contains(TKey key)
		{
			return _inner.ContainsKey(key);
		}

		public TValue Retrieve(TKey key)
		{
			TValue result = null;
			if (Contains(key))
			{
				result = _inner[key];
			}
			return result;
		}

		public TValue this[TKey key]
		{
			get { return Retrieve(key); }
		}

		#endregion
	}
}