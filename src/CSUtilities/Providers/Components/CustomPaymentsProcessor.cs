using System;
using System.ServiceModel;
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
    public class CustomPaymentsProcessor : BasketRelatedItemOperationSequenceComponent
    {
        protected override string RelationshipName
        {
            get { return MetadataDefinitions.Basket.Relationships.Payments; }
        }

        protected override void CreateRelatedItem(CommerceCreateRelatedItem createRelatedItemOperation)
        {
            CommerceEntity paymentEntity = createRelatedItemOperation.Model;

            var newPayment =
                CommerceServerClassFactory.CreateInstance<Payment>(
                    paymentEntity.ModelName, 
                    CommerceServerArea.Orders,
                    new[] { paymentEntity.Properties[MetadataDefinitions.Payment.Properties.BillingAddressId], Guid.Empty,  });

            paymentEntity.Id = newPayment.PaymentId.ToString("B");

            Translate(paymentEntity, newPayment);

            OrderForm orderForm = CachedOrderGroup.GetDefaultOrderForm();

            orderForm.Payments.Add(newPayment);
        }

        private static void Translate(CommerceEntity from, Payment to)
        {
            Translator.ToExternalEntity(from, to);
            string originalModelName = from.ModelName;
            from.ModelName = MetadataDefinitions.Payment.EntityName;
            Translator.ToExternalEntity(from, to);
            from.ModelName = originalModelName;

            if (String.IsNullOrEmpty(to.PaymentMethodName) &&
                from.Properties.ContainsProperty(MetadataDefinitions.Payment.Properties.PaymentMethodName))
            {
                to.PaymentMethodName = from.Properties[MetadataDefinitions.Payment.Properties.PaymentMethodName].ToString();
            }
        }

        protected override void DeleteRelatedItem(CommerceDeleteRelatedItem deleteRelatedItemOperation)
        {
            string paymentId = GetSearchModelId(deleteRelatedItemOperation, MetadataDefinitions.Payment.EntityName, true);

            if (!String.IsNullOrEmpty(paymentId))
            {
                Payment deletingPayment = GetPaymentFromCachedOrderGroup(paymentId);
                CachedOrderGroup.GetDefaultOrderForm().Payments.Remove(deletingPayment);
            }
            else
                CachedOrderGroup.GetDefaultOrderForm().Payments.Clear();
        }

        protected override void UpdateRelatedItem(CommerceUpdateRelatedItem updateRelatedItemOperation)
        {
            OrderForm orderForm = CachedOrderGroup.GetDefaultOrderForm();

            CommerceEntity model = updateRelatedItemOperation.GetModel(MetadataDefinitions.Payment.EntityName);
            string paymentId = GetSearchModelId(updateRelatedItemOperation, MetadataDefinitions.Payment.EntityName, true);

            if (!String.IsNullOrEmpty(paymentId))
            {
                Payment updatingPayment = GetPaymentFromCachedOrderGroup(paymentId);
                Translate(model, updatingPayment);
            }
            else
            {
                foreach (Payment payment in orderForm.Payments)
                    Translate(model, payment);
            }
        }

        protected virtual Payment GetPaymentFromCachedOrderGroup(string paymentId)
        {
            OrderForm orderForm = CachedOrderGroup.GetDefaultOrderForm();

            int index = orderForm.Payments.IndexOf(new Guid(paymentId));

            if (index < 0)
                throw ItemDoesNotExist(MetadataDefinitions.Payment.EntityName, paymentId);

            return orderForm.Payments[index];
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