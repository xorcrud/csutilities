using System;
using System.Linq;
using Microsoft.CommerceServer.Runtime;
using Microsoft.CommerceServer.Runtime.Orders;
using System.IO;

namespace CSUtilities.Debugging
{
    internal class OrderGroupErrorWriter
    {
        private const string BasketErrorsKey = "_Basket_Errors";
        private const string PurchaseErrorsKey = "_Purchase_Errors";

        private readonly TextWriter _writer;

        public OrderGroupErrorWriter(TextWriter writer)
        {
            if (writer == null) throw new ArgumentNullException("writer");

            _writer = writer;
        }

        public void Write(OrderGroup order)
        {
            if (order == null) return;

            foreach (OrderForm orderForm in order.OrderForms)
            {
                WriteErrors(orderForm, BasketErrorsKey);
                WriteErrors(orderForm, PurchaseErrorsKey);
            }
        }

        private void WriteErrors(OrderForm orderForm, string key)
        {
            var errors = orderForm[key] as SimpleList;

            if (errors != null && errors.Count > 0)
            {
                _writer.WriteLine("OrderForm: {0} - Source: {1}", orderForm.Name, key);

                foreach (var error in errors.Cast<string>())
                    _writer.WriteLine("--- {0}", error);
            }
        }
    }
}