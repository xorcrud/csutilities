 
 
 
//////////////////////////////////////////////////////////////////////
//
// Summary:		Represents a T4 text template used for generating strongly-typed
//				classes for values represented in MetadataDefinitions.xml file for
//				used by the Commerce Server 2009 Multi-Channel Foundation API
//
// Usage:		Copy the MetadataDefinitions.tt file to the class library/project
//				in which you want to be able to expose the Commerce Server properties.
//		
//				Configuration of class visibility, class name, namespace 
//				and more are done in the last section of this file.
//
// Issues:		Changes you make in the MetadataDefinitions.xml file are not automatically
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
    public partial class MetadataDefinitions
    {
		#region Site

		public partial class Site
		{
			public const string EntityName = "Site";
	
			public partial class Properties
			{
				public const string Id = "Id";
	
				public static IEnumerable<string> All
				{
					get
					{
						var result = new List<string>
						{
							Id,
						};

						AddToAll(result.Add);

						return result;
					}			
				}

				static partial void AddToAll(Action<string> addProperty);
			}

            public partial class Relationships
            {
				public const string Catalogs = "Catalogs";
			
				public static IEnumerable<string> All
				{
					get
					{
						var result = new List<string>
						{					
							Catalogs,
						};		

						AddToAll(result.Add);

						return result;						
					}			
				}
					
				static partial void AddToAll(Action<string> addRelationship);
            }
		}

		#endregion

		#region Catalog

		public partial class Catalog
		{
			public const string EntityName = "Catalog";
	
			public partial class Properties
			{
				public const string IsVirtualCatalog = "IsVirtualCatalog";
				public const string ActiveLanguage = "ActiveLanguage";
				public const string DisplayName = "DisplayName";
				public const string Id = "Id";
				public const string DefaultLanguage = "DefaultLanguage";
				public const string Currency = "Currency";
				public const string EndDate = "EndDate";
				public const string StartDate = "StartDate";
				public const string WeightMeasure = "WeightMeasure";
				public const string InternalId = "InternalId";
				public const string Languages = "Languages";
				public const string IdentifyingProductProperty = "IdentifyingProductProperty";
				public const string IdentifyingVariantProperty = "IdentifyingVariantProperty";
	
				public static IEnumerable<string> All
				{
					get
					{
						var result = new List<string>
						{
							IsVirtualCatalog,
							ActiveLanguage,
							DisplayName,
							Id,
							DefaultLanguage,
							Currency,
							EndDate,
							StartDate,
							WeightMeasure,
							InternalId,
							Languages,
							IdentifyingProductProperty,
							IdentifyingVariantProperty,
						};

						AddToAll(result.Add);

						return result;
					}			
				}

				static partial void AddToAll(Action<string> addProperty);
			}
		}

		#endregion

		#region Product

		public partial class Product
		{
			public const string EntityName = "Product";
	
			public partial class Properties
			{
				public const string BaseCatalogName = "BaseCatalogName";
				public const string CatalogId = "CatalogId";
				public const string CatalogName = "CatalogName";
				public const string DefinitionName = "DefinitionName";
				public const string DisplayName = "DisplayName";
				public const string Id = "Id";
				public const string ListPrice = "ListPrice";
				public const string UseCategoryPricing = "UseCategoryPricing";
				public const string Image_FileName = "Image_FileName";
				public const string Description = "Description";
				public const string InventoryCondition = "InventoryCondition";
	
				public static IEnumerable<string> All
				{
					get
					{
						var result = new List<string>
						{
							BaseCatalogName,
							CatalogId,
							CatalogName,
							DefinitionName,
							DisplayName,
							Id,
							ListPrice,
							UseCategoryPricing,
							Image_FileName,
							Description,
							InventoryCondition,
						};

						AddToAll(result.Add);

						return result;
					}			
				}

				static partial void AddToAll(Action<string> addProperty);
			}

            public partial class Relationships
            {
				public const string BaseCatalog = "BaseCatalog";
				public const string PrimaryParentCategory = "PrimaryParentCategory";
				public const string AncestorCategories = "AncestorCategories";
				public const string CanonicalCategories = "CanonicalCategories";
				public const string ParentCategories = "ParentCategories";
				public const string RelatedCategories = "RelatedCategories";
				public const string RelatedProducts = "RelatedProducts";
				public const string Discounts = "Discounts";
				public const string CrossSells = "CrossSells";
				public const string Variants = "Variants";
			
				public static IEnumerable<string> All
				{
					get
					{
						var result = new List<string>
						{					
							BaseCatalog,
							PrimaryParentCategory,
							AncestorCategories,
							CanonicalCategories,
							ParentCategories,
							RelatedCategories,
							RelatedProducts,
							Discounts,
							CrossSells,
							Variants,
						};		

						AddToAll(result.Add);

						return result;						
					}			
				}
					
				static partial void AddToAll(Action<string> addRelationship);
            }
		}

		#endregion

		#region Variant

		public partial class Variant
		{
			public const string EntityName = "Variant";
	
			public partial class Properties
			{
				public const string BaseCatalogName = "BaseCatalogName";
				public const string CatalogId = "CatalogId";
				public const string DefinitionName = "DefinitionName";
				public const string DisplayName = "DisplayName";
				public const string Id = "Id";
				public const string ListPrice = "ListPrice";
				public const string OriginalProductId = "OriginalProductId";
				public const string OriginalVariantId = "OriginalVariantId";
				public const string ProductId = "ProductId";
				public const string InventoryCondition = "InventoryCondition";
	
				public static IEnumerable<string> All
				{
					get
					{
						var result = new List<string>
						{
							BaseCatalogName,
							CatalogId,
							DefinitionName,
							DisplayName,
							Id,
							ListPrice,
							OriginalProductId,
							OriginalVariantId,
							ProductId,
							InventoryCondition,
						};

						AddToAll(result.Add);

						return result;
					}			
				}

				static partial void AddToAll(Action<string> addProperty);
			}

            public partial class Relationships
            {
				public const string BaseCatalog = "BaseCatalog";
				public const string PrimaryParentCategory = "PrimaryParentCategory";
				public const string InventoryItems = "InventoryItems";
				public const string PricingCategory = "PricingCategory";
				public const string Product = "Product";
			
				public static IEnumerable<string> All
				{
					get
					{
						var result = new List<string>
						{					
							BaseCatalog,
							PrimaryParentCategory,
							InventoryItems,
							PricingCategory,
							Product,
						};		

						AddToAll(result.Add);

						return result;						
					}			
				}
					
				static partial void AddToAll(Action<string> addRelationship);
            }
		}

		#endregion

		#region InventoryItem

		public partial class InventoryItem
		{
			public const string EntityName = "InventoryItem";
	
			public partial class Properties
			{
				public const string Id = "Id";
				public const string Backorderable = "Backorderable";
				public const string BackorderAvailabilityDate = "BackorderAvailabilityDate";
				public const string BackorderedQuantity = "BackorderedQuantity";
				public const string BackorderLimit = "BackorderLimit";
				public const string DateModified = "DateModified";
				public const string ExcessOnHandQuantity = "ExcessOnHandQuantity";
				public const string InventoryCatalogName = "InventoryCatalogName";
				public const string LastRestocked = "LastRestocked";
				public const string Memo = "Memo";
				public const string Preorderable = "Preorderable";
				public const string PreorderAvailabilityDate = "PreorderAvailabilityDate";
				public const string PreorderedQuantity = "PreorderedQuantity";
				public const string PreorderLimit = "PreorderLimit";
				public const string ProductId = "ProductId";
				public const string ProductCatalogName = "ProductCatalogName";
				public const string Quantity = "Quantity";
				public const string ReorderPoint = "ReorderPoint";
				public const string StockStatus = "StockStatus";
				public const string StockOutThreshold = "StockOutThreshold";
				public const string TargetQuantity = "TargetQuantity";
				public const string UnitOfMeasure = "UnitOfMeasure";
				public const string VariantId = "VariantId";
	
				public static IEnumerable<string> All
				{
					get
					{
						var result = new List<string>
						{
							Id,
							Backorderable,
							BackorderAvailabilityDate,
							BackorderedQuantity,
							BackorderLimit,
							DateModified,
							ExcessOnHandQuantity,
							InventoryCatalogName,
							LastRestocked,
							Memo,
							Preorderable,
							PreorderAvailabilityDate,
							PreorderedQuantity,
							PreorderLimit,
							ProductId,
							ProductCatalogName,
							Quantity,
							ReorderPoint,
							StockStatus,
							StockOutThreshold,
							TargetQuantity,
							UnitOfMeasure,
							VariantId,
						};

						AddToAll(result.Add);

						return result;
					}			
				}

				static partial void AddToAll(Action<string> addProperty);
			}
		}

		#endregion

		#region Category

		public partial class Category
		{
			public const string EntityName = "Category";
	
			public partial class Properties
			{
				public const string BaseCatalogName = "BaseCatalogName";
				public const string CatalogId = "CatalogId";
				public const string DefinitionName = "DefinitionName";
				public const string DisplayName = "DisplayName";
				public const string Id = "Id";
				public const string IsVirtualCatalog = "IsVirtualCatalog";
				public const string ListPrice = "ListPrice";
				public const string UseCategoryPricing = "UseCategoryPricing";
				public const string IsSearchable = "IsSearchable";
	
				public static IEnumerable<string> All
				{
					get
					{
						var result = new List<string>
						{
							BaseCatalogName,
							CatalogId,
							DefinitionName,
							DisplayName,
							Id,
							IsVirtualCatalog,
							ListPrice,
							UseCategoryPricing,
							IsSearchable,
						};

						AddToAll(result.Add);

						return result;
					}			
				}

				static partial void AddToAll(Action<string> addProperty);
			}

            public partial class Relationships
            {
				public const string BaseCatalog = "BaseCatalog";
				public const string PrimaryParentCategory = "PrimaryParentCategory";
				public const string AncestorCategories = "AncestorCategories";
				public const string CanonicalCategories = "CanonicalCategories";
				public const string Discounts = "Discounts";
				public const string ParentCategories = "ParentCategories";
				public const string RelatedCategories = "RelatedCategories";
				public const string RelatedProducts = "RelatedProducts";
				public const string CrossSells = "CrossSells";
				public const string ChildCategories = "ChildCategories";
				public const string ChildProducts = "ChildProducts";
			
				public static IEnumerable<string> All
				{
					get
					{
						var result = new List<string>
						{					
							BaseCatalog,
							PrimaryParentCategory,
							AncestorCategories,
							CanonicalCategories,
							Discounts,
							ParentCategories,
							RelatedCategories,
							RelatedProducts,
							CrossSells,
							ChildCategories,
							ChildProducts,
						};		

						AddToAll(result.Add);

						return result;						
					}			
				}
					
				static partial void AddToAll(Action<string> addRelationship);
            }
		}

		#endregion

		#region UserProfile

		public partial class UserProfile
		{
			public const string EntityName = "UserProfile";
	
			public partial class Properties
			{
			}

            public partial class Relationships
            {
				public const string Addresses = "Addresses";
				public const string CreditCards = "CreditCards";
				public const string OrderHistory = "OrderHistory";
			
				public static IEnumerable<string> All
				{
					get
					{
						var result = new List<string>
						{					
							Addresses,
							CreditCards,
							OrderHistory,
						};		

						AddToAll(result.Add);

						return result;						
					}			
				}
					
				static partial void AddToAll(Action<string> addRelationship);
            }
		}

		#endregion

		#region Address

		public partial class Address
		{
			public const string EntityName = "Address";
	
			public partial class Properties
			{
				public const string City = "City";
				public const string Telephone = "Telephone";
				public const string TestField = "TestField";
	
				public static IEnumerable<string> All
				{
					get
					{
						var result = new List<string>
						{
							City,
							Telephone,
							TestField,
						};

						AddToAll(result.Add);

						return result;
					}			
				}

				static partial void AddToAll(Action<string> addProperty);
			}
		}

		#endregion

		#region CreditCard

		public partial class CreditCard
		{
			public const string EntityName = "CreditCard";
	
			public partial class Properties
			{
				public const string CreditCardNumber = "CreditCardNumber";
				public const string BillingAddressId = "BillingAddressId";
	
				public static IEnumerable<string> All
				{
					get
					{
						var result = new List<string>
						{
							CreditCardNumber,
							BillingAddressId,
						};

						AddToAll(result.Add);

						return result;
					}			
				}

				static partial void AddToAll(Action<string> addProperty);
			}
		}

		#endregion

		#region TargetingContext

		public partial class TargetingContext
		{
			public const string EntityName = "TargetingContext";
	
			public partial class Properties
			{
				public const string Id = "Id";
				public const string PageGroup = "PageGroup";
				public const string Channel = "Channel";
	
				public static IEnumerable<string> All
				{
					get
					{
						var result = new List<string>
						{
							Id,
							PageGroup,
							Channel,
						};

						AddToAll(result.Add);

						return result;
					}			
				}

				static partial void AddToAll(Action<string> addProperty);
			}
		}

		#endregion

		#region SiteTerm

		public partial class SiteTerm
		{
			public const string EntityName = "SiteTerm";
	
			public partial class Properties
			{
				public const string Id = "Id";
	
				public static IEnumerable<string> All
				{
					get
					{
						var result = new List<string>
						{
							Id,
						};

						AddToAll(result.Add);

						return result;
					}			
				}

				static partial void AddToAll(Action<string> addProperty);
			}

            public partial class Relationships
            {
				public const string Elements = "Elements";
			
				public static IEnumerable<string> All
				{
					get
					{
						var result = new List<string>
						{					
							Elements,
						};		

						AddToAll(result.Add);

						return result;						
					}			
				}
					
				static partial void AddToAll(Action<string> addRelationship);
            }
		}

		#endregion

		#region SiteTermElement

		public partial class SiteTermElement
		{
			public const string EntityName = "SiteTermElement";
	
			public partial class Properties
			{
				public const string Id = "Id";
				public const string DisplayName = "DisplayName";
	
				public static IEnumerable<string> All
				{
					get
					{
						var result = new List<string>
						{
							Id,
							DisplayName,
						};

						AddToAll(result.Add);

						return result;
					}			
				}

				static partial void AddToAll(Action<string> addProperty);
			}
		}

		#endregion

		#region Basket

		public partial class Basket
		{
			public const string EntityName = "Basket";
	
			public partial class Properties
			{
				public const string BillingCurrency = "BillingCurrency";
				public const string OrderNumber = "OrderNumber";
				public const string UserId = "UserId";
				public const string BasketLevelDiscountsTotal = "BasketLevelDiscountsTotal";
				public const string BasketType = "BasketType";
				public const string DiscountsTotal = "DiscountsTotal";
				public const string LineItemDiscountsTotal = "LineItemDiscountsTotal";
				public const string ShippingDiscountsTotal = "ShippingDiscountsTotal";
				public const string BasketErrors = "BasketErrors";
				public const string PurchaseErrors = "PurchaseErrors";
	
				public static IEnumerable<string> All
				{
					get
					{
						var result = new List<string>
						{
							BillingCurrency,
							OrderNumber,
							UserId,
							BasketLevelDiscountsTotal,
							BasketType,
							DiscountsTotal,
							LineItemDiscountsTotal,
							ShippingDiscountsTotal,
							BasketErrors,
							PurchaseErrors,
						};

						AddToAll(result.Add);

						return result;
					}			
				}

				static partial void AddToAll(Action<string> addProperty);
			}
		}

		#endregion

		#region ShopperList

		public partial class ShopperList
		{
			public const string EntityName = "ShopperList";
	
			public partial class Properties
			{
				public const string BillingCurrency = "BillingCurrency";
				public const string UserId = "UserId";
				public const string BasketErrors = "BasketErrors";
				public const string TestProperty1 = "TestProperty1";
				public const string ListLastModified = "ListLastModified";
	
				public static IEnumerable<string> All
				{
					get
					{
						var result = new List<string>
						{
							BillingCurrency,
							UserId,
							BasketErrors,
							TestProperty1,
							ListLastModified,
						};

						AddToAll(result.Add);

						return result;
					}			
				}

				static partial void AddToAll(Action<string> addProperty);
			}
		}

		#endregion

		#region Discount

		public partial class Discount
		{
			public const string EntityName = "Discount";
	
			public partial class Properties
			{
				public const string DiscountType = "DiscountType";
	
				public static IEnumerable<string> All
				{
					get
					{
						var result = new List<string>
						{
							DiscountType,
						};

						AddToAll(result.Add);

						return result;
					}			
				}

				static partial void AddToAll(Action<string> addProperty);
			}
		}

		#endregion

		#region LineItem

		public partial class LineItem
		{
			public const string EntityName = "LineItem";
	
			public partial class Properties
			{
				public const string ItemPriority = "ItemPriority";
				public const string GiftMessage = "GiftMessage";
				public const string GiftWrap = "GiftWrap";
				public const string _product_Image_FileName = "_product_Image_FileName";
				public const string _product_Description = "_product_Description";
				public const string _product_DefinitionName = "_product_DefinitionName";
				public const string _product_i_ClassType = "_product_i_ClassType";
				public const string _product_ProductSize = "_product_ProductSize";
				public const string _product_ProductColor = "_product_ProductColor";
	
				public static IEnumerable<string> All
				{
					get
					{
						var result = new List<string>
						{
							ItemPriority,
							GiftMessage,
							GiftWrap,
							_product_Image_FileName,
							_product_Description,
							_product_DefinitionName,
							_product_i_ClassType,
							_product_ProductSize,
							_product_ProductColor,
						};

						AddToAll(result.Add);

						return result;
					}			
				}

				static partial void AddToAll(Action<string> addProperty);
			}
		}

		#endregion

		#region PurchaseOrder

		public partial class PurchaseOrder
		{
			public const string EntityName = "PurchaseOrder";
	
			public partial class Properties
			{
			}
		}

		#endregion

		#region CashCard

		public partial class CashCard
		{
			public const string EntityName = "CashCard";
	
			public partial class Properties
			{
			}
		}

		#endregion

		#region GiftCertificate

		public partial class GiftCertificate
		{
			public const string EntityName = "GiftCertificate";
	
			public partial class Properties
			{
			}
		}

		#endregion

		#region RequestedPromoCode

		public partial class RequestedPromoCode
		{
			public const string EntityName = "RequestedPromoCode";
	
			public partial class Properties
			{
			}
		}

		#endregion

		#region Shipment

		public partial class Shipment
		{
			public const string EntityName = "Shipment";
	
			public partial class Properties
			{
			}
		}

		#endregion

		#region Payment

		public partial class Payment
		{
			public const string EntityName = "Payment";
	
			public partial class Properties
			{
				public const string Id = "Id";
				public const string Amount = "Amount";
				public const string Status = "Status";
	
				public static IEnumerable<string> All
				{
					get
					{
						var result = new List<string>
						{
							Id,
							Amount,
							Status,
						};

						AddToAll(result.Add);

						return result;
					}			
				}

				static partial void AddToAll(Action<string> addProperty);
			}
		}

		#endregion

		#region PaymentMethod

		public partial class PaymentMethod
		{
			public const string EntityName = "PaymentMethod";
	
			public partial class Properties
			{
				public const string Id = "Id";
				public const string DisplayName = "DisplayName";
				public const string Description = "Description";
				public const string PaymentType = "PaymentType";
	
				public static IEnumerable<string> All
				{
					get
					{
						var result = new List<string>
						{
							Id,
							DisplayName,
							Description,
							PaymentType,
						};

						AddToAll(result.Add);

						return result;
					}			
				}

				static partial void AddToAll(Action<string> addProperty);
			}
		}

		#endregion

		#region ShippingMethod

		public partial class ShippingMethod
		{
			public const string EntityName = "ShippingMethod";
	
			public partial class Properties
			{
				public const string Id = "Id";
				public const string DisplayName = "DisplayName";
				public const string Description = "Description";
	
				public static IEnumerable<string> All
				{
					get
					{
						var result = new List<string>
						{
							Id,
							DisplayName,
							Description,
						};

						AddToAll(result.Add);

						return result;
					}			
				}

				static partial void AddToAll(Action<string> addProperty);
			}
		}

		#endregion

		#region HierarchicalCatalogEntity

		public partial class HierarchicalCatalogEntity
		{
			public const string EntityName = "HierarchicalCatalogEntity";
	
			public partial class Properties
			{
			}
		}

		#endregion

		#region DiscountDefinition

		public partial class DiscountDefinition
		{
			public const string EntityName = "DiscountDefinition";
	
			public partial class Properties
			{
				public const string Id = "Id";
				public const string ParentId = "ParentId";
				public const string DateModified = "DateModified";
				public const string Name = "Name";
				public const string BasketDisplay = "BasketDisplay";
				public const string StartDate = "StartDate";
				public const string EndDate = "EndDate";
				public const string OfferType = "OfferType";
				public const string Value = "Value";
				public const string ValueType = "ValueType";
	
				public static IEnumerable<string> All
				{
					get
					{
						var result = new List<string>
						{
							Id,
							ParentId,
							DateModified,
							Name,
							BasketDisplay,
							StartDate,
							EndDate,
							OfferType,
							Value,
							ValueType,
						};

						AddToAll(result.Add);

						return result;
					}			
				}

				static partial void AddToAll(Action<string> addProperty);
			}
		}

		#endregion

		#region VEClientToken

		public partial class VEClientToken
		{
			public const string EntityName = "VEClientToken";
	
			public partial class Properties
			{
				public const string ClientToken = "ClientToken";
	
				public static IEnumerable<string> All
				{
					get
					{
						var result = new List<string>
						{
							ClientToken,
						};

						AddToAll(result.Add);

						return result;
					}			
				}

				static partial void AddToAll(Action<string> addProperty);
			}
		}

		#endregion

		#region VENearbyStore

		public partial class VENearbyStore
		{
			public const string EntityName = "VENearbyStore";
	
			public partial class Properties
			{
				public const string EntityId = "EntityId";
				public const string Name = "Name";
				public const string DisplayName = "DisplayName";
				public const string AddressLine = "AddressLine";
				public const string City = "City";
				public const string Subdivision = "Subdivision";
				public const string PostalCode = "PostalCode";
				public const string Country = "Country";
				public const string Telephone = "Telephone";
				public const string Latitude = "Latitude";
				public const string Longitude = "Longitude";
	
				public static IEnumerable<string> All
				{
					get
					{
						var result = new List<string>
						{
							EntityId,
							Name,
							DisplayName,
							AddressLine,
							City,
							Subdivision,
							PostalCode,
							Country,
							Telephone,
							Latitude,
							Longitude,
						};

						AddToAll(result.Add);

						return result;
					}			
				}

				static partial void AddToAll(Action<string> addProperty);
			}
		}

		#endregion

	}
}

