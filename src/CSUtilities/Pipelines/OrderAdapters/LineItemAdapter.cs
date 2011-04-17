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
            get { return GetValue<decimal>(OrderPipelineMappings.LineItem.ProductListPrice); }
            set
            {
                this[OrderPipelineMappings.LineItem.ProductListPrice] = value;
                this[OrderPipelineMappings.LineItem.ListPrice] = value;    
            }
        }

        public decimal ExtendedPrice
        {
            get { return GetValue<decimal>(OrderPipelineMappings.LineItem.ExtendedPrice); }
            set { this[OrderPipelineMappings.LineItem.ExtendedPrice] = value; }
        }

        /// <summary>
        /// Returns the value of a Product Property that temporarily is copied to the Line Item by the Orders System.
        /// </summary>
        /// <param name="propertyName">The name of the property in the Catalog System.</param>
        /// <returns>Returns the value of the product property.</returns>
        public object GetProductProperty(string propertyName)
        {
            return Entity[String.Format(ProductPropertyFormat, propertyName)];
        }

        /// <summary>
        /// Returns the value of a Product Property that temporarily is copied to the Line Item by the Orders System.
        /// </summary>
        /// <typeparam name="TType">The expected type to convert into.</typeparam>
        /// <param name="propertyName">The name of the property in the Catalog System.</param>
        /// <returns>Returns the value of the product property.</returns>
        public TType GetProductProperty<TType>(string propertyName)
        {
            return GetValue<TType>(String.Format(ProductPropertyFormat, propertyName));
        }

        /// <summary>
        /// Copies a temporary Product Property from the line item into another weakly typed property that gets persisted.
        /// </summary>
        /// <param name="prefixWhenPersisting">Prefix, if any, that gets added as part of the new property name on the line item.</param>
        /// <param name="propertyName">The name of the Product Property in the Catalog System.</param>
        public void PersistProductProperty(string prefixWhenPersisting, string propertyName)
        {
            if (String.IsNullOrEmpty(propertyName))
                throw new ArgumentException("Value cannot be null or empty.", "propertyName");

            this[String.Concat(prefixWhenPersisting, propertyName)] = 
                GetProductProperty(propertyName);
        }

        /// <summary>
        /// Copies a temporary Product Property from the line item into another weakly typed property that gets persisted.
        /// </summary>
        /// <param name="propertyName">The name of the Product Property in the Catalog System.</param>
        public void PersistProductProperty(string propertyName)
        {
            PersistProductProperty(null /* prefixWhenPersisting */, propertyName);
        }
    }
}