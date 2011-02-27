using System;
using Microsoft.CommerceServer.Runtime;

namespace CSUtilities.Pipelines
{
    public class LineItemAdapter : Adapter
    {
        public static readonly string ProductPropertyFormat = "_product_{0}";

        public LineItemAdapter(IDictionary inner)
            : base(inner)
        {
        }

        public string Catalog
        {
            get { return GetValue<string>(OrderPipelineMappings.LineItem.ProductCatalog); }
        }

        public string ProductId
        {
            get { return GetValue<string>(OrderPipelineMappings.LineItem.ProductId); }
        }

        public string VariantId
        {
            get { return GetValue<string>(OrderPipelineMappings.LineItem.ProductVariantId); }
        }

        public int Quantity
        {
            get { return GetValue<int>(OrderPipelineMappings.LineItem.Quantity); }
        }

        public object GetProductProperty(string propertyName)
        {
            return Entity[String.Format(ProductPropertyFormat, propertyName)];
        }

        public TType GetProductProperty<TType>(string propertyName)
        {
            return GetValue<TType>(String.Format(ProductPropertyFormat, propertyName));
        }
    }
}