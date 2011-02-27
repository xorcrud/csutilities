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

        public TType GetValue<TType>(string name)
        {
            object value = this[name];

            if (value is TType)
                return (TType)value;

            return default(TType);
        }

        public IDictionary Entity
        {
            get { return _inner; }
        }
    }
}