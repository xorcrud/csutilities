using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.CommerceServer.Runtime;
using IDictionary = Microsoft.CommerceServer.Runtime.IDictionary;

namespace CSUtilities.Pipelines
{
    public class ListAdapter<TElementAdapter> : ICollection<TElementAdapter>
        where TElementAdapter : Adapter
    {
        private readonly ISimpleList _inner;
        private readonly Func<IDictionary, TElementAdapter> _createItemAdapter;

        public ListAdapter(ISimpleList inner/*, Func<IDictionary, TElementAdapter> createItemAdapter*/)
        {
            if (inner == null) throw new ArgumentNullException("inner");

            _inner = inner;
            //_createItemAdapter = createItemAdapter;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<TElementAdapter> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void Add(TElementAdapter item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(TElementAdapter item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(TElementAdapter[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(TElementAdapter item)
        {
            throw new NotImplementedException();
        }

        public int Count
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }
    }
}