using System;
using System.Globalization;
using Microsoft.Commerce.Contracts;
using Microsoft.Commerce.Providers.Translators;
using Microsoft.CommerceServer.Runtime.Orders;

namespace CSUtilities.Providers.Translators
{
    public class ExternalEntitySupportingShipmentTranslator : ShipmentTranslator, IToExternalEntityTranslator
    {
        private readonly PropertyTranslator<Shipment> _propertyTranslator;

        public ExternalEntitySupportingShipmentTranslator()
        {
            _propertyTranslator = 
                new PropertyTranslator<Shipment>(
                    null, 
                    null,
                    TranslateToStronglyTypedCommerceServerProperty,
                    TranslateToWeaklyTypedCommerceServerProperty);
        }

        public void Translate(CommerceEntity sourceCommerceEntity, object destination)
        {
            if (sourceCommerceEntity == null) throw new ArgumentNullException("sourceCommerceEntity");
            if (destination == null) throw new ArgumentNullException("destination");

            _propertyTranslator.TranslateToCommerceServer(sourceCommerceEntity, destination as Shipment, null);
        }

        protected virtual bool TranslateToWeaklyTypedCommerceServerProperty(Shipment commerceServerObject, string commerceServerPropertyName, object value)
        {
            commerceServerObject[commerceServerPropertyName] = value;
            return true;
        }

        protected virtual bool TranslateToStronglyTypedCommerceServerProperty(Shipment commerceServerObject, string commerceServerPropertyName, object value)
        {
            switch (commerceServerPropertyName)
            {
                case MetadataDefinitions.Shipment.Properties.ShipmentTotal:
                    if (value != null)
                        commerceServerObject.ShipmentTotal = Convert.ToDecimal(value, CultureInfo.InvariantCulture);
                    break;

                case MetadataDefinitions.Shipment.Properties.ShippingAddressId:
                    commerceServerObject.ShippingAddressId = value as string;
                    break;

                case MetadataDefinitions.Shipment.Properties.ShippingMethodName:
                    commerceServerObject.ShippingMethodName = value as string;
                    break;

                case MetadataDefinitions.Shipment.Properties.ShippingMethodId:
                    Guid methodId = (value is string) ? new Guid(value as string) : Guid.Empty;
                    commerceServerObject.ShippingMethodId = methodId;
                    break;

                case MetadataDefinitions.Shipment.Properties.Status:
                    commerceServerObject.Status = value as string;
                    break;

                case MetadataDefinitions.Shipment.Properties.ShipmentTrackingNumber:
                    commerceServerObject.ShipmentTrackingNumber = value as string;
                    break;

                default:
                    return false;
            }

            return true;
        }
    }
}