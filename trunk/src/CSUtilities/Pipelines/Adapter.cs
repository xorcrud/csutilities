using System;
using Microsoft.CommerceServer.Runtime;

namespace CSUtilities.Pipelines
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

        public bool TryGetValue<TType>(string name, out TType value)
        {
            value = default(TType);

            object tmp = this[name];

            if (tmp is TType)
            {
                value = (TType)tmp;
                return true;
            }

            return false;
        }

        public TType GetValue<TType>(string name)
        {
            TType value;
            if (!TryGetValue(name, out value))
            {
                throw new InvalidOperationException(
                    String.Format(
                        "Value of item '{0}' is not of expected type '{1}'.",
                        name,
                        typeof (TType).FullName));
            }

            return value;
        }

        public IDictionary Entity
        {
            get { return _inner; }
        }
    }
}