using System;
using System.Collections.Generic;
using Microsoft.Commerce.Common.MessageBuilders;
using Microsoft.Commerce.Contracts;
using Microsoft.Commerce.Contracts.Messages;

namespace CSUtilities.Extensions
{
    public static class QueryExtensions
    {
        public static CommerceRequest ToRequestWithBasketReturnModel(this CommerceUpdate<CommerceEntity, CommerceModelSearch<CommerceEntity>, CommerceBasketUpdateOptionsBuilder> updateQuery)
        {
            if (updateQuery == null) 
                throw new ArgumentNullException("updateQuery");

            var updateOperation = updateQuery.ToOperation() as CommerceUpdateOperation;

            if (updateOperation == null)
                throw new InvalidOperationException();

            updateOperation.Options.ReturnModel = new CommerceEntity(MetadataDefinitions.Basket.EntityName);

            updateOperation.Options.ReturnModelQueries.Add(new CommerceQueryRelatedItem
            {
                RelationshipName = MetadataDefinitions.Basket.Relationships.LineItems,
                Model = new CommerceEntity(MetadataDefinitions.LineItem.EntityName)
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

            updateOperation.Options.ReturnModelQueries.Add(new CommerceQueryRelatedItem
            {
                RelationshipName = MetadataDefinitions.Basket.Relationships.Shipments,
                Model = new CommerceEntity(MetadataDefinitions.Shipment.EntityName)
            });

            return new CommerceRequest
            {
                Operations = new List<CommerceOperation> { updateOperation }
            };
        }
    }
}