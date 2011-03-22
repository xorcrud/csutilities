using Microsoft.CommerceServer.Runtime;

namespace CSUtilities.Pipelines.OrderAdapters
{
    public class CreditCardPaymentAdapter : PaymentAdapter
    {
        public CreditCardPaymentAdapter(IDictionary inner)
            : base(inner)
        {
        }
    }
}