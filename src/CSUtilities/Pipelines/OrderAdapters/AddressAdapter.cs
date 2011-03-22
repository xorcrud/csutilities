using Microsoft.CommerceServer.Runtime;

namespace CSUtilities.Pipelines.OrderAdapters
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

        public string FirstName
        {
            get { return GetValue<string>(OrderPipelineMappings.OrderAddress.FirstName); }
            set { this[OrderPipelineMappings.OrderAddress.FirstName] = value; }
        }

        public string LastName
        {
            get { return GetValue<string>(OrderPipelineMappings.OrderAddress.LastName); }
            set { this[OrderPipelineMappings.OrderAddress.LastName] = value; }
        }

        public string Line1
        {
            get { return GetValue<string>(OrderPipelineMappings.OrderAddress.Line1); }
            set { this[OrderPipelineMappings.OrderAddress.Line1] = value; }
        }

        public string Line2
        {
            get { return GetValue<string>(OrderPipelineMappings.OrderAddress.Line2); }
            set { this[OrderPipelineMappings.OrderAddress.Line2] = value; }
        }

        public string City
        {
            get { return GetValue<string>(OrderPipelineMappings.OrderAddress.City); }
            set { this[OrderPipelineMappings.OrderAddress.City] = value; }
        }

        public string State
        {
            get { return GetValue<string>(OrderPipelineMappings.OrderAddress.State); }
            set { this[OrderPipelineMappings.OrderAddress.State] = value; }
        }

        public string CountryCode
        {
            get { return GetValue<string>(OrderPipelineMappings.OrderAddress.CountryCode); }
            set { this[OrderPipelineMappings.OrderAddress.CountryCode] = value; }
        }

        public string CountryName
        {
            get { return GetValue<string>(OrderPipelineMappings.OrderAddress.CountryName); }
            set { this[OrderPipelineMappings.OrderAddress.CountryName] = value; }
        }

        public string PostalCode
        {
            get { return GetValue<string>(OrderPipelineMappings.OrderAddress.PostalCode); }
            set { this[OrderPipelineMappings.OrderAddress.PostalCode] = value; }
        }

        public string RegionName
        {
            get { return GetValue<string>(OrderPipelineMappings.OrderAddress.RegionName); }
            set { this[OrderPipelineMappings.OrderAddress.RegionName] = value; }
        }

        public string RegionCode
        {
            get { return GetValue<string>(OrderPipelineMappings.OrderAddress.RegionCode); }
            set { this[OrderPipelineMappings.OrderAddress.RegionCode] = value; }
        }

        public string DaytimePhoneNumber
        {
            get { return GetValue<string>(OrderPipelineMappings.OrderAddress.DaytimePhoneNumber); }
            set { this[OrderPipelineMappings.OrderAddress.DaytimePhoneNumber] = value; }
        }

        public string EveningPhoneNumber
        {
            get { return GetValue<string>(OrderPipelineMappings.OrderAddress.EveningPhoneNumber); }
            set { this[OrderPipelineMappings.OrderAddress.EveningPhoneNumber] = value; }
        }

        public string Email
        {
            get { return GetValue<string>(OrderPipelineMappings.OrderAddress.Email); }
            set { this[OrderPipelineMappings.OrderAddress.Email] = value; }
        }
    }
}