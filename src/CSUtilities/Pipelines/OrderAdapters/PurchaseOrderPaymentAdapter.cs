using Microsoft.CommerceServer.Runtime;

namespace CSUtilities.Pipelines.OrderAdapters
{
    public class PurchaseOrderPaymentAdapter : PaymentAdapter
    {
        public PurchaseOrderPaymentAdapter(IDictionary inner)
            : base(inner)
        {
        }
    }
}