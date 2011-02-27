using System.Collections.Generic;
using Microsoft.CommerceServer.Runtime;

namespace CSUtilities.Pipelines
{
    public class OrderAdapter : Adapter
    {
        public OrderAdapter(IDictionary inner)
            : base(inner)
        {
        }

        public IEnumerable<LineItemAdapter> LineItems
        {
            get
            {
                return new ListAdapter<LineItemAdapter>((ISimpleList)Inner["items"], x => new LineItemAdapter(x));
            }
        }
    }
}