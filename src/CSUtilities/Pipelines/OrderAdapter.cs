using System.Collections.Generic;
using Microsoft.CommerceServer.Runtime;

namespace CSUtilities.Pipelines
{
    public class OrderAdapter : Adapter
    {
        protected OrderAdapter(IDictionary inner)
            : base(inner)
        {
        }

        public ICollection<LineItemAdapter> LineItems
        {
            get { return new ListAdapter<LineItemAdapter>((ISimpleList)Inner["LineItems"]); }
        }
    }
}