using Microsoft.CommerceServer.Runtime;

namespace CSUtilities.Pipelines
{
    public class PaymentAdapter : Adapter
    {
        public PaymentAdapter(IDictionary inner)
            : base(inner)
        {
        }
    }
}