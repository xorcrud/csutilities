using Microsoft.CommerceServer.Runtime;

namespace CSUtilities.Pipelines.OrderAdapters
{
    public class GiftCertificatePaymentAdapter : PaymentAdapter
    {
        public GiftCertificatePaymentAdapter(IDictionary inner)
            : base(inner)
        {
        }
    }
}