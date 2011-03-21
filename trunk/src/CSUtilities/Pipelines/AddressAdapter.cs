using System;
using Microsoft.CommerceServer.Runtime;

namespace CSUtilities.Pipelines
{
    public class AddressAdapter : Adapter
    {
        public AddressAdapter(IDictionary inner)
            : base(inner)
        {
        }

        public string AddressId
        {
            get { return GetValue<string>(OrderPipelineMappings.OrderAddress.OrderAddressId); }
        }

        public string Name
        {
            get { return GetValue<string>(OrderPipelineMappings.OrderAddress.Name); }
            set { this[OrderPipelineMappings.OrderAddress.Name] = value; }
        }

        public string City
        {
            get { return GetValue<string>(OrderPipelineMappings.OrderAddress.City); }
            set { this[OrderPipelineMappings.OrderAddress.City] = value; }
        }
    }
}