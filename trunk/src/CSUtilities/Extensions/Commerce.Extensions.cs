using System;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.Commerce.Common;
using Microsoft.Commerce.Common.MessageBuilders;
using Microsoft.Commerce.Contracts;
using Microsoft.Commerce.Contracts.Messages;

namespace CSUtilities.Extensions
{
	public static class CommerceExtensions
	{
		public static string ToCommerceId(this Guid guid)
		{
			return guid.ToString("B");
		}

	    public static CommerceResponse ProcessRequestWithContext(this IOperationServiceAgent agent, CommerceRequest request)
	    {
	        if (agent == null) throw new ArgumentNullException("agent");
	        if (request == null) throw new ArgumentNullException("request");

	        var requestContext = new CommerceRequestContext
	        {
	            Channel = "DefaultChannel",
	            UserId = Guid.NewGuid().ToString("b"),
	            UserLocale = CultureInfo.CurrentCulture.ToString(),
	            UserUILocale = CultureInfo.CurrentUICulture.ToString(),
	            RequestId = Guid.NewGuid().ToString()
	        };

	        return agent.ProcessRequest(requestContext, request);
	    }

        /// <summary>
        /// Includes Addresses, LineItems, Shipments, Payments and Discounts
        /// </summary>
        /// <param name="basketQuery">The Query object for which relationships are being added to.</param>
        public static void IncludeBasketRelationships(this CommerceQuery<CommerceEntity> basketQuery)
        {
            if (basketQuery == null) throw new ArgumentNullException("basketQuery");

            if (basketQuery.Model == null)
                throw new InvalidOperationException("Model has not been specified on Query.");

            if (!String.Equals(basketQuery.Model.ModelName, MetadataDefinitions.Basket.EntityName, StringComparison.OrdinalIgnoreCase))
                throw new InvalidOperationException(String.Format("This method can only be used on a 'Basket' model. Current model: '{0}'", basketQuery.Model.ModelName));

            basketQuery.RelatedOperations.Add(new CommerceQueryRelatedItem<CommerceEntity>(MetadataDefinitions.Basket.Relationships.Addresses, MetadataDefinitions.Address.EntityName));
            basketQuery.RelatedOperations.Add(new CommerceQueryRelatedItem<CommerceEntity>(MetadataDefinitions.Basket.Relationships.LineItems, MetadataDefinitions.LineItem.EntityName));
            basketQuery.RelatedOperations.Add(new CommerceQueryRelatedItem<CommerceEntity>(MetadataDefinitions.Basket.Relationships.Payments, MetadataDefinitions.Payment.EntityName));
            basketQuery.RelatedOperations.Add(new CommerceQueryRelatedItem<CommerceEntity>(MetadataDefinitions.Basket.Relationships.Shipments, MetadataDefinitions.Shipment.EntityName));
            basketQuery.RelatedOperations.Add(new CommerceQueryRelatedItem<CommerceEntity>(MetadataDefinitions.Basket.Relationships.Discounts, MetadataDefinitions.Discount.EntityName));
        }

        public static CommerceRequest ToRequestWithBasketReturnModel(this CommerceUpdate<CommerceEntity, CommerceModelSearch<CommerceEntity>, CommerceBasketUpdateOptionsBuilder> updateQuery)
        {
            if (updateQuery == null) throw new ArgumentNullException("updateQuery");

            var updateOperation = updateQuery.ToOperation() as CommerceUpdateOperation;

            if (updateOperation == null)
                throw new InvalidOperationException();

            updateOperation.Options.ReturnModel = new CommerceEntity(MetadataDefinitions.Basket.EntityName);

            updateOperation.Options.ReturnModelQueries.Add(new CommerceQueryRelatedItem
            {
                RelationshipName = MetadataDefinitions.Basket.Relationships.Addresses,
                Model = new CommerceEntity(MetadataDefinitions.Address.EntityName)                                                                   
            });

            updateOperation.Options.ReturnModelQueries.Add(new CommerceQueryRelatedItem
            {
                RelationshipName = MetadataDefinitions.Basket.Relationships.LineItems,
                Model = new CommerceEntity(MetadataDefinitions.LineItem.EntityName)
            });

            updateOperation.Options.ReturnModelQueries.Add(new CommerceQueryRelatedItem
            {
                RelationshipName = MetadataDefinitions.Basket.Relationships.Shipments,
                Model = new CommerceEntity(MetadataDefinitions.Shipment.EntityName)
            });

            updateOperation.Options.ReturnModelQueries.Add(new CommerceQueryRelatedItem
            {
                RelationshipName = MetadataDefinitions.Basket.Relationships.Discounts,
                Model = new CommerceEntity(MetadataDefinitions.Discount.EntityName)
            });

            updateOperation.Options.ReturnModelQueries.Add(new CommerceQueryRelatedItem
            {
                RelationshipName = MetadataDefinitions.Basket.Relationships.Payments,
                Model = new CommerceEntity(MetadataDefinitions.Payment.EntityName),
                RelatedOperations = new List<CommerceRelatedOperation>
                { 
                    new CommerceQueryRelatedItem 
                    { 
                        RelationshipName = "PaymentAccount", 
                        Model = new CommerceEntity() 
                    } 
                }
            });

            return new CommerceRequest
            {
                Operations = new List<CommerceOperation> { updateOperation }
            };
        }
	}
}