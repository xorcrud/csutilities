using System;
using Microsoft.CommerceServer.Runtime;

namespace CSUtilities.Pipelines.OrderAdapters
{
    public class LineItemAdapter : Adapter
    {
        public static readonly string ProductPropertyFormat = "_product_{0}";

        public LineItemAdapter(IDictionary inner)
            : base(inner)
        {
        }

        public int LineItemId
        {
            get { return GetValue<int>(OrderPipelineMappings.LineItem.LineItemId); }
        }

        public string Catalog
        {
            get { return GetValue<string>(OrderPipelineMappings.LineItem.ProductCatalog); }
        }

        public string Category
        {
            get { return GetValue<string>(OrderPipelineMappings.LineItem.ProductCategory); }
        }

        public string ProductId
        {
            get { return GetValue<string>(OrderPipelineMappings.LineItem.ProductId); }
        }

        public string VariantId
        {
            get { return GetValue<string>(OrderPipelineMappings.LineItem.ProductVariantId); }
        }

        public string DisplayName
        {
            get { return GetValue<string>(OrderPipelineMappings.LineItem.DisplayName); }
            set { this[OrderPipelineMappings.LineItem.DisplayName] = value; }
        }

        public int Quantity
        {
            get { return GetValue<int>(OrderPipelineMappings.LineItem.Quantity); }
            set { this[OrderPipelineMappings.LineItem.Quantity] = value; }
        }

        public decimal PlacedPrice
        {
            get { return GetValue<decimal>(OrderPipelineMappings.LineItem.PlacedPrice); }
            set { this[OrderPipelineMappings.LineItem.PlacedPrice] = value; }
        }

        public decimal ListPrice
        {
            get { return GetValue<decimal>(OrderPipelineMappings.LineItem.ListPrice); }
            set { this[OrderPipelineMappings.LineItem.ListPrice] = value; }
        }

        public decimal ExtendedPrice
        {
            get { return GetValue<decimal>(OrderPipelineMappings.LineItem.ExtendedPrice); }
            set { this[OrderPipelineMappings.LineItem.ExtendedPrice] = value; }
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