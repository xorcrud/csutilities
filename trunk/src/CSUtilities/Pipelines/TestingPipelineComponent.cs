using System;
using System.Runtime.InteropServices;
using CSUtilities.Pipelines.OrderAdapters;

namespace CSUtilities.Pipelines
{
    [Guid("34104807-4B22-40A4-89AA-4686D092BE29")]
    [ComVisible(true)]
    public class TestingPipelineComponent : OrderPipelineComponentBase
    {
        protected override void Execute(OrderAdapter order)
        {
            string currency = order.GetValue<string>("BillingCurrency");

            foreach (var lineItem in order.LineItems)
            {
                string currencyProperty = String.Format("{0}_Price", currency);

                lineItem.ListPrice = lineItem.GetProductProperty<decimal>(currencyProperty);
                lineItem.PersistProductProperty("Product", "Description");
            }

            foreach (var shipment in order.Shipments)
            {
            }

            foreach (var payment in order.Payments)
            {
            }

            foreach (var address in order.Addresses)
            {
            }
        }

        private object TryGetProperty(OrderAdapter order, string name)
        {
            try
            {
                return order[name];
            }
            catch
            {
                return "n/a";
            }
        }
    }
}