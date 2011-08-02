using System;
using System.Linq;
using System.ServiceModel;
using Microsoft.Commerce.Broker;
using Microsoft.Commerce.Common;
using Microsoft.Commerce.Contracts;
using Microsoft.Commerce.Contracts.CommerceEntities.Metadata;
using Microsoft.Commerce.Contracts.Faults;
using Microsoft.Commerce.Contracts.Messages;
using Microsoft.Commerce.Providers;
using Microsoft.Commerce.Providers.Components;
using Microsoft.Commerce.Providers.Translators;
using Microsoft.Commerce.Providers.Utility;
using Microsoft.CommerceServer.Runtime.Orders;

namespace CSUtilities.Providers.Components
{
    public class CustomShipmentsProcessor : BasketRelatedItemOperationSequenceComponent
    {
        protected override string RelationshipName
        {
            get { return MetadataDefinitions.Basket.Relationships.Shipments; }
        }

        protected override void CreateRelatedItem(CommerceCreateRelatedItem createRelatedItemOperation)
        {
            CommerceEntity shipmentEntity = createRelatedItemOperation.Model;

            var newShipment =
                CommerceServerClassFactory.CreateInstance<Shipment>(
                    shipmentEntity.ModelName, CommerceServerArea.Orders);

            shipmentEntity.Id = newShipment.ShipmentId.ToString("B");

            Translator.ToExternalEntity(shipmentEntity, newShipment);

            OrderForm orderForm = CachedOrderGroup.GetDefaultOrderForm();

            UpdateShippingLineItemsAssociation(newShipment, orderForm);

            orderForm.Shipments.Add(newShipment);
        }

        public override void ExecuteUpdate(CommerceUpdateOperation updateOperation, OperationCacheDictionary operationCache, CommerceUpdateOperationResponse response)
        {
            base.ExecuteUpdate(updateOperation, operationCache, response);

            EnsureLineItemsHasShippingMethod();
        }

        private void EnsureLineItemsHasShippingMethod()
        {
            OrderForm orderForm = CachedOrderGroup.GetDefaultOrderForm();

            foreach (LineItem lineItem in
                orderForm.LineItems
                    .OfType<LineItem>()
                    .Where(x => x.ShippingMethodId == Guid.Empty))
            {
                lineItem.ShippingMethodId = Guid.NewGuid();
            }
        }

        protected override void DeleteRelatedItem(CommerceDeleteRelatedItem deleteRelatedItemOperation)
        {
            string shipmentId = GetSearchModelId(deleteRelatedItemOperation, MetadataDefinitions.Shipment.EntityName, true);

            if (!String.IsNullOrEmpty(shipmentId))
            {
                Shipment deletingShipment = GetShipmentFromCachedOrderGroup(shipmentId);
                CachedOrderGroup.GetDefaultOrderForm().Shipments.Remove(deletingShipment);
            }
            else
                CachedOrderGroup.GetDefaultOrderForm().Shipments.Clear();
        }

        protected override void UpdateRelatedItem(CommerceUpdateRelatedItem updateRelatedItemOperation)
        {
            OrderForm orderForm = CachedOrderGroup.GetDefaultOrderForm();

            CommerceEntity model = updateRelatedItemOperation.GetModel(MetadataDefinitions.Shipment.EntityName);
            string shipmentId = GetSearchModelId(updateRelatedItemOperation, MetadataDefinitions.Shipment.EntityName, true);

            if (!String.IsNullOrEmpty(shipmentId))
            {
                Shipment updatingShipment = GetShipmentFromCachedOrderGroup(shipmentId);
                Translator.ToExternalEntity(model, updatingShipment);
                UpdateShippingLineItemsAssociation(updatingShipment, orderForm);
            }
            else
            {
                foreach (Shipment shipment in orderForm.Shipments)
                    Translator.ToExternalEntity(model, shipment);
            }
        }

        protected virtual Shipment GetShipmentFromCachedOrderGroup(string shipmentId)
        {
            OrderForm orderForm = CachedOrderGroup.GetDefaultOrderForm();

            int index = orderForm.Shipments.IndexOf(new Guid(shipmentId));

            if (index < 0)
                throw ItemDoesNotExist(MetadataDefinitions.Shipment.EntityName, shipmentId);

            return orderForm.Shipments[index];
        }

        protected virtual void UpdateShippingLineItemsAssociation(Shipment shipment, OrderForm orderForm)
        {
            foreach (LineItem lineItem in
                orderForm.LineItems
                    .OfType<LineItem>()
                    .Where(x => 
                        String.IsNullOrEmpty(x.ShippingMethodName) ||
                        String.Equals(x.ShippingMethodName, shipment.ShippingMethodName, StringComparison.OrdinalIgnoreCase)))
            {
                lineItem.ShippingMethodId = shipment.ShipmentId;
                shipment.LineItemIndexes.Add(lineItem.Index);
            }
        }

        protected virtual FaultException<ItemDoesNotExistFault> ItemDoesNotExist(string entityName, string entityId)
        {
            string message = ProviderResources.ExceptionMessages.GetMessage("ItemDoesNotExist", new object[0]);

            var detail = new ItemDoesNotExistFault(message);

            if (!String.IsNullOrEmpty(entityName))
            {
                detail.CommerceEntityName = entityName;
            }

            if (!String.IsNullOrEmpty(entityId))
            {
                detail.CommerceEntityId = entityId;
            }

            return new FaultException<ItemDoesNotExistFault>(detail, message);
        }
    }
}