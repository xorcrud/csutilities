using Microsoft.CommerceServer.Runtime;

namespace CSUtilities.Pipelines.OrderAdapters
{
    public class PaymentAdapter : Adapter
    {
        public PaymentAdapter(IDictionary inner)
            : base(inner)
        {
        }

        public string BillingAddressId
        {
            get { return GetValue<string>(BillingAddressIdKeyName); }
            set { this[BillingAddressIdKeyName] = value; }
        }

        public string PaymentMethodName
        {
            get { return GetValue<string>(PaymentMethodNameKeyName); }
            set { this[PaymentMethodNameKeyName] = value; }
        }

        public string CustomerNameOnPayment
        {
            get { return GetValue<string>(CustomerNameOnPaymentKeyName); }
            set { this[CustomerNameOnPaymentKeyName] = value; }
        }

        public decimal Amount
        {
            get { return GetValue<decimal>(AmountKeyName); }
            set { this[AmountKeyName] = value; }
        }


        public string Status
        {
            get { return GetValue<string>(StatusKeyName); }
            set { this[StatusKeyName] = value; }
        }

        public string ClassName
        {
            get { return GetClassName(Entity); }
            set { this[OrderPipelineMappings.Payment.ClassName] = value; }
        }

        protected virtual string BillingAddressIdKeyName
        {
            get { return OrderPipelineMappings.CreditCardPayment.BillingAddressId; }
        }

        protected virtual string CustomerNameOnPaymentKeyName
        {
            get { return OrderPipelineMappings.CreditCardPayment.CustomerNameOnPayment; }
        }

        protected virtual string PaymentMethodNameKeyName
        {
            get { return OrderPipelineMappings.CreditCardPayment.PaymentMethodName; }
        }

        protected virtual string AmountKeyName
        {
            get { return OrderPipelineMappings.CreditCardPayment.Amount; }
        }

        protected virtual string StatusKeyName
        {
            get { return OrderPipelineMappings.CreditCardPayment.Status; }
        }

        public static PaymentAdapter Create(IDictionary inner)
        {
            switch (GetClassName(inner))
            {
                case OrderPipelineMappings.Payment.CreditCardPaymentClassName:
                    return new CreditCardPaymentAdapter(inner);

                case OrderPipelineMappings.Payment.GiftCertificatePaymentClassName:
                    return new GiftCertificatePaymentAdapter(inner);

                case OrderPipelineMappings.Payment.PurchaseOrderPaymentClassName:
                    return new PurchaseOrderPaymentAdapter(inner);

                case OrderPipelineMappings.Payment.CashCardPaymentClassName:
                    return new CashCardPaymentAdapter(inner);
            }

            return new PaymentAdapter(inner);
        }

        public static string GetClassName(IDictionary inner)
        {
            return GetValue<string>(inner, OrderPipelineMappings.Payment.ClassName);
        }
    }
}