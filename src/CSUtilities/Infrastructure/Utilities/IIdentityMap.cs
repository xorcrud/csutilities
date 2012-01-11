namespace CSUtilities.Infrastructure.Utilities
{
	internal interface IIdentityMap<in TKey, TValue>
	{
		bool Register(TKey key, TValue instance);
		bool UnRegister(TKey key);
		bool Contains(TKey key);
		TValue Retrieve(TKey key);
		TValue this[TKey key] { get; }
	}
}