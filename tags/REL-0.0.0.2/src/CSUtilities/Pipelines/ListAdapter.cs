using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CommerceServer.Runtime;
using IDictionary = Microsoft.CommerceServer.Runtime.IDictionary;

namespace CSUtilities.Pipelines
{
    public class ListAdapter<TElementAdapter> : IEnumerable<TElementAdapter>
        where TElementAdapter : Adapter
    {
        private readonly IList<TElementAdapter> _inner;

        public ListAdapter(ISimpleList inner, Func<IDictionary, TElementAdapter> createItemAdapter)
        {
            if (inner == null) throw new ArgumentNullException("inner");

            _inner = inner.OfType<IDictionary>().Select(createItemAdapter).ToList();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<TElementAdapter> GetEnumerator()
        {
            return _inner.GetEnumerator();
        }
    }
}