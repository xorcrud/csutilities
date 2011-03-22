using Microsoft.CommerceServer.Runtime;

namespace CSUtilities.Pipelines.OrderAdapters
{
    public class CashCardPaymentAdapter : PaymentAdapter
    {
        public CashCardPaymentAdapter(IDictionary inner)
            : base(inner)
        {
        }

        public string CashCardNumber
        {
            get { return GetValue<string>(OrderPipelineMappings.CashCardPayment.CashCardNumber); }
            set { this[OrderPipelineMappings.CashCardPayment.CashCardNumber] = value; }
        }

        public string Pin
        {
            get { return GetValue<string>(OrderPipelineMappings.CashCardPayment.Pin); }
            set { this[OrderPipelineMappings.CashCardPayment.Pin] = value; }
        }
    }
}