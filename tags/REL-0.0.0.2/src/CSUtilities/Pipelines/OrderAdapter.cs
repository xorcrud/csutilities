using System.Collections.Generic;
using Microsoft.CommerceServer.Runtime;
using IDictionary = Microsoft.CommerceServer.Runtime.IDictionary;

namespace CSUtilities.Pipelines
{
    public class OrderAdapter : Adapter
    {
        public OrderAdapter(IDictionary inner)
            : base(inner)
        {
        }

        public IEnumerable<LineItemAdapter> LineItems
        {
            get
            {
                return 
                    new ListAdapter<LineItemAdapter>(
                        GetValue<ISimpleList>(OrderPipelineMappings.OrderForm.LineItems),
                        x => new LineItemAdapter(x));
            }
        }

        public IEnumerable<ShipmentAdapter> Shipments
        {
            get
            {
                return
                    new ListAdapter<ShipmentAdapter>(
                        GetValue<ISimpleList>(OrderPipelineMappings.OrderForm.Shipments),
                        x => new ShipmentAdapter(x));
            }
        }

        public IEnumerable<PaymentAdapter> Payments
        {
            get
            {
                return
                    new ListAdapter<PaymentAdapter>(
                        GetValue<ISimpleList>(OrderPipelineMappings.OrderForm.Payments),
                        x => new PaymentAdapter(x));
            }
        }
    }
}