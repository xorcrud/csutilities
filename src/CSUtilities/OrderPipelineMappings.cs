namespace CSUtilities
{
    public partial class OrderPipelineMappings
    {
        public partial class OrderForm
        {
            public static readonly string BasketErrors = "_Basket_Errors";
        }

        public class Payment
        {
            public static readonly string ClassName = "derived_class_name";

            public const string CreditCardPaymentClassName = "CreditCardPayment";
            public const string GiftCertificatePaymentClassName = "GiftCertificatePayment";
            public const string PurchaseOrderPaymentClassName = "PurchaseOrderPayment";
            public const string CashCardPaymentClassName = "CashCardPayment";
        }
    }
}