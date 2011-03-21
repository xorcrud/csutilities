using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using IDictionary = Microsoft.CommerceServer.Runtime.IDictionary;

namespace CSUtilities.Pipelines
{
    public class AddressListAdapter : IEnumerable<AddressAdapter>
    {
        private readonly IDictionary<string, AddressAdapter> _inner;

        public AddressListAdapter(IDictionary inner)
        {
            if (inner == null) throw new ArgumentNullException("inner");

            _inner =
                inner
                    .OfType<string>()
                    .Select(x => new AddressAdapter((IDictionary) inner[x]))
                    .ToDictionary(x => x.AddressId);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<AddressAdapter> GetEnumerator()
        {
            return _inner.Values.GetEnumerator();
        }

        public AddressAdapter this[string addressId]
        {
            get { return _inner[addressId]; }
        }
    }
}