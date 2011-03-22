using System.Collections.Generic;
using Microsoft.CommerceServer.Runtime;

namespace CSUtilities.Pipelines.OrderAdapters
{
    public class OrderAdapter : Adapter
    {
        public OrderAdapter(IDictionary inner)
            : base(inner)
        {
        }

        public AddressListAdapter Addresses
        {
            get
            {
                return 
                    new AddressListAdapter(
                        GetValue<IDictionary>(OrderPipelineMappings.OrderForm.Addresses));
            }
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
                        x => PaymentAdapter.Create(x));
            }
        }

        public decimal SubTotal
        {
            get { return GetValue<decimal>(OrderPipelineMappings.OrderForm.SubTotal); }
            set { this[OrderPipelineMappings.OrderForm.SubTotal] = value; }
        }

        public decimal ShippingTotal
        {
            get { return GetValue<decimal>(OrderPipelineMappings.OrderForm.ShippingTotal); }
            set { this[OrderPipelineMappings.OrderForm.ShippingTotal] = value; }
        }

        public decimal HandlingTotal
        {
            get { return GetValue<decimal>(OrderPipelineMappings.OrderForm.HandlingTotal); }
            set { this[OrderPipelineMappings.OrderForm.HandlingTotal] = value; }
        }

        public decimal TaxTotal
        {
            get { return GetValue<decimal>(OrderPipelineMappings.OrderForm.TaxTotal); }
            set { this[OrderPipelineMappings.OrderForm.TaxTotal] = value; }
        }

        public decimal Total
        {
            get { return GetValue<decimal>(OrderPipelineMappings.OrderForm.Total); }
            set { this[OrderPipelineMappings.OrderForm.Total] = value; }
        }

        public string Status
        {
            get { return GetValue<string>(OrderPipelineMappings.OrderForm.Status); }
            set { this[OrderPipelineMappings.OrderForm.Status] = value; }
        }

        public string TrackingNumber
        {
            get { return GetValue<string>(OrderPipelineMappings.OrderForm.TrackingNumber); }
            set { this[OrderPipelineMappings.OrderForm.TrackingNumber] = value; }
        }
    }
}