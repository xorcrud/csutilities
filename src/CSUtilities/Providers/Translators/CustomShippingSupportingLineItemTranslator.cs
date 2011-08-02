using System;
using Microsoft.Commerce.Providers.Translators;
using Microsoft.CommerceServer.Runtime.Orders;

namespace CSUtilities.Providers.Translators
{
    public class CustomShippingSupportingLineItemTranslator : LineItemTranslator
    {
        protected override bool TranslateToStronglyTypedCommerceServerProperty(LineItem commerceServerObject, string commerceServerPropertyName, object value)
        {
            bool result =
                base.TranslateToStronglyTypedCommerceServerProperty(commerceServerObject, commerceServerPropertyName, value);

            if (!result && 
                value is String &&
                String.Equals(commerceServerPropertyName, MetadataDefinitions.Shipment.Properties.ShippingMethodName, StringComparison.OrdinalIgnoreCase))
            {
                commerceServerObject.ShippingMethodName = value.ToString();
                result = true;
            }

            return result;
        }
    }
}
