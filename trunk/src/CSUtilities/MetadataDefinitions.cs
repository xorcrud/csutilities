namespace CSUtilities
{
    /// <summary>
    /// Example on how you can extend the generated class by creating a partial class of name "MetadataDefinitions".
    /// </summary>
    public partial class MetadataDefinitions
    {
        public partial class Address
        {
            public partial class Properties
            {
                public const string FirstName = "FirstName";
                public const string LastName = "LastName";
                public const string Line1 = "Line1";
                public const string Line2 = "Line2";

                static partial void AddToAll(System.Action<string> addProperty)
                {
                    addProperty(FirstName);
                    addProperty(LastName);
                    addProperty(Line1);
                    addProperty(Line2);
                }
            }
        }    

        public partial class Shipment
        {
            public partial class Properties
            {
                public const string ShippingMethodName = "ShippingMethodName";
                public const string ShipmentTotal = "ShipmentTotal";
                public const string ShippingAddressId = "ShippingAddressId";
                public const string ShippingMethodId = "ShippingMethodId";
                public const string Status = "Status";
                public const string ShipmentTrackingNumber = "ShipmentTrackingNumber";
            }
        }

        public partial class Payment
        {
            public partial class Properties
            {
                public const string PaymentMethodName = "PaymentMethodName";
                public const string BillingAddressId = "BillingAddressId";
            }
        }

        public partial class Basket
        {
            public partial class Relationships
            {
                public const string LineItems = "LineItems";
                public const string Payments = "Payments";
                public const string Shipments = "Shipments";
            }
        }
    }
}