 
 
 
//////////////////////////////////////////////////////////////////////
//
// Summary:		Represents a T4 text template used for generating strongly-typed
//				classes for dictionary keys represented in the OrderPipelineMappings.xml 
//				file for the Commerce Server 2007 Order Object System.
//
// Usage:		Copy the OrderPipelineMappings.tt file to the class library/project
//				in which you want to be able to expose the Commerce Server properties.
//		
//				Configuration of class visibility, class name, namespace 
//				and more are done in the last section of this file.
//
// Issues:		Changes you make in the OrderPipelineMappings.xml file are not automatically
//				reflected in the generated code. 
//				But you can just open this file and save it again to run the tool.
//
//				Customization tip:
//				Free edition of T4 editor tool from tangible-engineering
//				can be used to get syntax highlighting in Visual Studio.
//
///////////////////////////////////////////////////////////////////////
//
// February/2011 by
// Brian Holmgård Kristensen 
// (author of CSUtilities)
// blog.brianh.dk / CommerceServerTraining.com
//
// All information, source code, and especially tools are 
// provided as is and on a "use at your own risk" basis.
//
///////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSUtilities
{
    public partial class OrderPipelineMappings
    {
		#region OrderForm

		public partial class OrderForm
		{
			public static readonly string OrderFormId = "orderform_id";
			public static readonly string OrderGroupId = "BasketOrderGroupId";
			public static readonly string PromoUserIdentity = "promo_user_identity";
			public static readonly string SubTotal = "_cy_oadjust_subtotal";
			public static readonly string ShippingTotal = "_cy_shipping_total";
			public static readonly string HandlingTotal = "_cy_handling_total";
			public static readonly string TaxTotal = "_cy_tax_total";
			public static readonly string Total = "_cy_total_total";
			public static readonly string BillingAddressId = "billing_address_id";
			public static readonly string Status = "orderform_status";
			public static readonly string TrackingNumber = "order_number";
			public static readonly string SoldToId = "user_id";
			public static readonly string PromoCodes = "promo_codes";
			public static readonly string Shipments = "shipments";
			public static readonly string LineItems = "items";
			public static readonly string PromoCodeRecords = "promo_code_info";
			public static readonly string Payments = "payments";
			public static readonly string Addresses = "Addresses";
		}

		#endregion

		#region CreditCardPayment

		public partial class CreditCardPayment
		{
			public static readonly string BillingAddressId = "billing_address_id";
			public static readonly string PaymentId = "payment_id";
			public static readonly string PaymentMethodId = "payment_method_id";
			public static readonly string PaymentMethodName = "payment_method_name";
			public static readonly string CustomerNameOnPayment = "customer_name_on_payment";
			public static readonly string Amount = "cy_amount";
			public static readonly string DerivedClassName = "derived_class_name";
			public static readonly string CreditCardNumber = "_cc_number";
			public static readonly string CreditCardIdentifier = "cc_identifier";
			public static readonly string ExpirationMonth = "_cc_expmonth";
			public static readonly string ExpirationYear = "_cc_expyear";
			public static readonly string CardType = "cc_type";
			public static readonly string ValidationCode = "validation_code";
			public static readonly string AuthorizationCode = "authorization_code";
			public static readonly string Status = "payment_status";
		}

		#endregion

		#region GiftCertificatePayment

		public partial class GiftCertificatePayment
		{
			public static readonly string BillingAddressId = "billing_address_id";
			public static readonly string PaymentId = "payment_id";
			public static readonly string PaymentMethodId = "payment_method_id";
			public static readonly string PaymentMethodName = "payment_method_name";
			public static readonly string CustomerNameOnPayment = "customer_name_on_payment";
			public static readonly string Amount = "cy_amount";
			public static readonly string DerivedClassName = "derived_class_name";
			public static readonly string GiftCertificateNumber = "gift_certificate_number";
			public static readonly string ExpirationDate = "dt_expiration";
			public static readonly string Pin = "pin";
			public static readonly string Status = "payment_status";
		}

		#endregion

		#region PurchaseOrderPayment

		public partial class PurchaseOrderPayment
		{
			public static readonly string BillingAddressId = "billing_address_id";
			public static readonly string PaymentId = "payment_id";
			public static readonly string PaymentMethodId = "payment_method_id";
			public static readonly string PaymentMethodName = "payment_method_name";
			public static readonly string CustomerNameOnPayment = "customer_name_on_payment";
			public static readonly string Amount = "cy_amount";
			public static readonly string DerivedClassName = "derived_class_name";
			public static readonly string PurchaseOrderPaymentNumber = " purchase_order_payment_number";
			public static readonly string Status = "payment_status";
		}

		#endregion

		#region CashCardPayment

		public partial class CashCardPayment
		{
			public static readonly string BillingAddressId = "billing_address_id";
			public static readonly string PaymentId = "payment_id";
			public static readonly string PaymentMethodId = "payment_method_id";
			public static readonly string PaymentMethodName = "payment_method_name";
			public static readonly string CustomerNameOnPayment = "customer_name_on_payment";
			public static readonly string Amount = "cy_amount";
			public static readonly string DerivedClassName = "derived_class_name";
			public static readonly string CashCardNumber = "cash_card_number";
			public static readonly string Pin = "pin";
			public static readonly string Status = "payment_status";
		}

		#endregion

		#region Shipment

		public partial class Shipment
		{
			public static readonly string ShipmentId = "shipment_id";
			public static readonly string ShippingAddressId = "shipping_address_id";
			public static readonly string ShippingMethodId = "shipping_method_id";
			public static readonly string ShipmentTrackingNumber = "shipment_tracking_number";
			public static readonly string ShipmentTotal = "_cy_shipping_total";
			public static readonly string ShippingDiscountAmount = "_cy_shipping_discounts_subtotal";
			public static readonly string ShippingMethodName = "shipping_method_name";
			public static readonly string Status = "shipment_status";
			public static readonly string LineItemIndexes = "ItemIndexes";
			public static readonly string ShippingDiscounts = "_shipping_discounts_applied";
		}

		#endregion

		#region OrderAddress

		public partial class OrderAddress
		{
			public static readonly string OrderAddressId = "address_id";
			public static readonly string Name = "name";
			public static readonly string FirstName = "first_name";
			public static readonly string LastName = "last_name";
			public static readonly string Line1 = "address_line1";
			public static readonly string Line2 = "address_line2";
			public static readonly string City = "city";
			public static readonly string State = "state";
			public static readonly string CountryCode = "country_code";
			public static readonly string CountryName = "country_name";
			public static readonly string PostalCode = "postal_code";
			public static readonly string RegionName = "region_name";
			public static readonly string RegionCode = "region_code";
			public static readonly string DaytimePhoneNumber = "day_time_phone_number";
			public static readonly string EveningPhoneNumber = "evening_phone_number";
			public static readonly string Email = "email";
			public static readonly string OrderGroupId = "order_group_id";
		}

		#endregion

		#region LineItem

		public partial class LineItem
		{
			public static readonly string LineItemId = "index";
			public static readonly string ProductCatalog = "product_catalog";
			public static readonly string ProductCategory = "product_category";
			public static readonly string ProductId = "product_id";
			public static readonly string ProductVariantId = "product_variant_id";
			public static readonly string Quantity = "quantity";
			public static readonly string PlacedPrice = "cy_placed_price";
			public static readonly string ListPrice = "_cy_iadjust_regularprice";
			public static readonly string LineItemDiscountAmount = "_cy_itemlevel_discounts_subtotal";
			public static readonly string OrderLevelDiscountAmount = "_cy_orderlevel_discounts_subtotal";
			public static readonly string ShippingAddressId = "shipping_address_id";
			public static readonly string ShippingMethodId = "shipping_method_id";
			public static readonly string ShippingMethodName = "shipping_method_name";
			public static readonly string ExtendedPrice = "_cy_oadjust_adjustedprice";
			public static readonly string DisplayName = "_product_DisplayName";
			public static readonly string InStockQuantity = "_inventory_in_stock_for_request";
			public static readonly string PreorderQuantity = "_inventory_pre_order_for_request";
			public static readonly string InventoryCondition = "_inventory_condition";
			public static readonly string BackorderQuantity = "_inventory_back_order_for_request";
			public static readonly string AllowBackordersAndPreorders = "_inventory_allow_backorder_and_preorder";
			public static readonly string Status = "item_status";
			public static readonly string ItemLevelDiscountsApplied = "_itemlevel_discounts_applied";
			public static readonly string OrderLevelDiscountsApplied = "_orderlevel_discounts_applied";
		}

		#endregion

		#region DiscountApplicationRecord

		public partial class DiscountApplicationRecord
		{
			public static readonly string DiscountId = "discount_id";
			public static readonly string Priority = "discount_priority";
			public static readonly string DiscountAmount = "cy_discount_amount";
			public static readonly string DiscountValue = "cy_discount_value";
			public static readonly string DiscountName = "discount_name";
			public static readonly string TypeOfDiscount = "discount_type";
			public static readonly string LastModified = "discount_timestamp";
			public static readonly string PromoCode = "promo_code";
			public static readonly string PromoCodeDefinitionId = "promocode_defn_id";
			public static readonly string BasketDisplayMessage = "discount_basket_display";
		}

		#endregion

		#region ShippingDiscountRecord

		public partial class ShippingDiscountRecord
		{
			public static readonly string DiscountId = "discount_id";
			public static readonly string Priority = "discount_priority";
			public static readonly string DiscountAmount = "cy_discount_amount";
			public static readonly string DiscountValue = "cy_discount_value";
			public static readonly string DiscountName = "discount_name";
			public static readonly string TypeOfDiscount = "discount_type";
			public static readonly string LastModified = "discount_timestamp";
			public static readonly string PromoCode = "promo_code";
			public static readonly string PromoCodeDefinitionId = "promocode_defn_id";
			public static readonly string BasketDisplayMessage = "discount_basket_display";
		}

		#endregion

		#region PromoCodeRecord

		public partial class PromoCodeRecord
		{
			public static readonly string PromoCode = "promo_code";
			public static readonly string PromoCodeDefinitionId = "promo_code_definition_id";
			public static readonly string PromoCodeLookupDate = "dt_promo_code_lookup";
			public static readonly string PromoCodeStatus = "promo_code_status";
			public static readonly string PromoApplied = "promo_applied";
			public static readonly string PromoCodeReserved = "promo_code_reserved";
		}

		#endregion

	
	}
}	

