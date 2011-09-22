using System;
using System.Collections.Generic;
using System.Globalization;
using CSUtilities.Mappers.Exceptions;
using Microsoft.Commerce.Common;
using Microsoft.Commerce.Common.MessageBuilders;
using Microsoft.Commerce.Contracts;
using Microsoft.Commerce.Contracts.Messages;

namespace CSUtilities.Extensions
{
	public static class CommerceExtensions
	{
        /// <summary>
        /// Converts Guid to a string recognized by Commerce Server.
        /// </summary>
        /// <returns>String representation of the Guid.</returns>
		public static string ToCommerceId(this Guid guid)
		{
			return guid.ToString("B");
		}

        /// <summary>
        /// Validates the ModelName of a given Entity.
        /// </summary>
        /// <param name="from">The Entity to validate.</param>
        /// <param name="modelName">The expected ModelName.</param>
        public static void AssertModel(this CommerceEntity from, string modelName)
        {
            if (from == null) throw new ArgumentNullException("from");

            if (!from.ModelName.Equals(modelName, StringComparison.OrdinalIgnoreCase))
                throw new WrongModelException(from, modelName);
        }

        /// <summary>
        /// Creates a CommerceRequestContext object, associates this to the IOperationServiceAgent and issues a request.
        /// </summary>
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
	    /// <param name="customRelationships">Name of any custom relationsships to be added in the basket query.</param>
	    public static void IncludeBasketRelationships(this CommerceQuery<CommerceEntity> basketQuery, params Relationship[] customRelationships)
        {
            if (basketQuery == null) throw new ArgumentNullException("basketQuery");

            if (basketQuery.Model == null)
                throw new InvalidOperationException("Model has not been specified on Query.");

            if (!String.Equals(basketQuery.Model.ModelName, MetadataDefinitions.Basket.EntityName, StringComparison.OrdinalIgnoreCase))
                throw new InvalidOperationException(String.Format("This method can only be used on a 'Basket' model. Current model: '{0}'", basketQuery.Model.ModelName));

            var relationships = new List<Relationship>
            {
                new Relationship(MetadataDefinitions.Basket.Relationships.Addresses, MetadataDefinitions.Address.EntityName),
                new Relationship(MetadataDefinitions.Basket.Relationships.LineItems, MetadataDefinitions.LineItem.EntityName),
                new Relationship(MetadataDefinitions.Basket.Relationships.Payments, MetadataDefinitions.Payment.EntityName),
                new Relationship(MetadataDefinitions.Basket.Relationships.Shipments, MetadataDefinitions.Shipment.EntityName),
                new Relationship(MetadataDefinitions.Basket.Relationships.Discounts, MetadataDefinitions.Discount.EntityName)
            };

            if (customRelationships != null)
                relationships.AddRange(customRelationships);

	        foreach (var relationship in relationships)
	        {
	            basketQuery.RelatedOperations.Add(
	                new CommerceQueryRelatedItem<CommerceEntity>(relationship.Name, relationship.Model));
	        }
        }

        /// <summary>
        /// Puts a ReturnModel to the Basket Update Query that returns the updated Basket (full model with all properties and default relationships (Addresses, LineItems, Shipments, Discounts and Payments)) as part of the response.
        /// </summary>
        /// <param name="updateQuery">The Basket Update Query that gets the ReturnModel query added.</param>
        /// <param name="customRelationships">Any custom relationships that should be returned with the updated basket.</param>
        public static CommerceRequest ToRequestWithBasketReturnModel(this CommerceUpdate<CommerceEntity, CommerceModelSearch<CommerceEntity>, CommerceBasketUpdateOptionsBuilder> updateQuery, params Relationship[] customRelationships)
        {
            if (updateQuery == null) throw new ArgumentNullException("updateQuery");

            var updateOperation = updateQuery.ToOperation() as CommerceUpdateOperation;

            if (updateOperation == null)
                throw new InvalidOperationException();

            updateOperation.Options.ReturnModel = new CommerceEntity(MetadataDefinitions.Basket.EntityName);

            var relationships = new List<Relationship>
            {
                new Relationship(MetadataDefinitions.Basket.Relationships.Addresses, MetadataDefinitions.Address.EntityName),
                new Relationship(MetadataDefinitions.Basket.Relationships.LineItems, MetadataDefinitions.LineItem.EntityName),
                new Relationship(MetadataDefinitions.Basket.Relationships.Shipments, MetadataDefinitions.Shipment.EntityName),
                new Relationship(MetadataDefinitions.Basket.Relationships.Discounts, MetadataDefinitions.Discount.EntityName)
            };

            if (customRelationships != null)
                relationships.AddRange(customRelationships);

            foreach (var relationship in relationships)
            {
                updateOperation.Options.ReturnModelQueries.Add(new CommerceQueryRelatedItem
                {
                    RelationshipName = relationship.Name,
                    Model = new CommerceEntity(relationship.Model)
                });
            }

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