using Microsoft.CommerceServer.Runtime;

namespace CSUtilities.Pipelines
{
    public class ShipmentAdapter : Adapter
    {
        public ShipmentAdapter(IDictionary inner)
            : base(inner)
        {
        }

        public string TrackingNumber
        {
            get { return GetValue<string>(OrderPipelineMappings.Shipment.ShipmentTrackingNumber); }
            set { this[OrderPipelineMappings.Shipment.ShipmentTrackingNumber] = value; }
        }

        public decimal Total
        {
            get { return GetValue<decimal>(OrderPipelineMappings.Shipment.ShipmentTotal); }
            set { this[OrderPipelineMappings.Shipment.ShipmentTotal] = value; }
        }

        public decimal DiscountTotal
        {
            get { return GetValue<decimal>(OrderPipelineMappings.Shipment.ShippingDiscountAmount); }
            set { this[OrderPipelineMappings.Shipment.ShippingDiscountAmount] = value; }
        }

        public string MethodName
        {
            get { return GetValue<string>(OrderPipelineMappings.Shipment.ShippingMethodName); }
            set { this[OrderPipelineMappings.Shipment.ShippingMethodName] = value; }
        }

        public string Status
        {
            get { return GetValue<string>(OrderPipelineMappings.Shipment.Status); }
            set { this[OrderPipelineMappings.Shipment.Status] = value; }
        }
    }
}