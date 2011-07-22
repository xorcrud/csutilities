using System;
using Microsoft.CommerceServer.Runtime;

namespace CSUtilities.Pipelines.OrderAdapters
{
    public abstract class Adapter
    {
        private readonly IDictionary _inner;

        protected Adapter(IDictionary inner)
        {
            if (inner == null) throw new ArgumentNullException("inner");

            _inner = inner;
        }

        public object this[string name]
        {
            get { return _inner[name]; }
            set { _inner[name] = value; }
        }

        public TType GetValue<TType>(string name)
        {
            return GetValue<TType>(Entity, name);
        }

        public IDictionary Entity
        {
            get { return _inner; }
        }

        internal static bool TryGetValue<TType>(IDictionary entity, string name, out TType value)
        {
            value = default(TType);

            if (entity != null)
            {
                object objectValue = entity[name];

                if (objectValue != null)
                {
                    if (objectValue is TType)
                        value = (TType) objectValue;
                }
            }

            return false;
        }

        internal static TType GetValue<TType>(IDictionary entity, string name)
        {
            if (entity == null) throw new ArgumentNullException("entity");

            TType value;
            TryGetValue(entity, name, out value);

            return value;
        }
    }
}