# CS Utilities 0.0.0.1 #
**Released Feb 11th 2011**

## Features in this release: ##
  * Code Generation based on MetadataDefinitions.xml

**Code Generation based on MetadataDefinitions.xml**

This T4 template can be added to any Class Library in your Commerce Server solution. The T4 template will generate classes with all the entities and their properties and relationships found in the MetadataDefinitions.xml file. All generated classes are partial so that you can extend them with any properties that should not exist in the MetadataDefinitions.xml file.

You decide whether properties are created as constants or static readonly fields based on your preferences. Also class visibility, namespace and more can be configured through the T4 template.

**Usage scenarios**

  * Avoid magic strings in your Commerce Server Multi-Channel Foundation API Queries / Entities
  * Avoid magic strings in your custom pipeline components
  * Avoid magic strings in your Order Object Model Extensions

**Examples**

The code below is an example of a Catalog Query that is not using the T4 template

```
var query = new CommerceQuery<CommerceEntity>("Product"); 
 
query.Model.Properties.Add("Id"); 
query.Model.Properties.Add("DisplayName"); 
query.Model.Properties.Add("ListPrice"); 
 
query.SearchCriteria.Model.SetPropertyValue("CatalogId", catalogId); 
query.SearchCriteria.Model.SetPropertyValue("Id", productId); 
```

When using the strongly-typed code generated MetadataDefinitions class, the code will look like

```
var query = new CommerceQuery<CommerceEntity>(MetadataDefinitions.Product.EntityName); 
 
query.Model.Properties.Add(MetadataDefinitions.Product.Properties.Id); 
query.Model.Properties.Add(MetadataDefinitions.Product.Properties.DisplayName); 
query.Model.Properties.Add(MetadataDefinitions.Product.Properties.ListPrice); 
 
query.SearchCriteria.Model.SetPropertyValue(MetadataDefinitions.Product.Properties.CatalogId, catalogId); 
query.SearchCriteria.Model.SetPropertyValue(MetadataDefinitions.Product.Properties.Id, productId);
```


**How to get started**

  1. Download the CSUtilities 0.0.0.1 release
  1. Drag the MetadataDefinitions.tt file from the "CommerceServer.Extensions" project into your own class library
  1. Change the MetadataFile property within the MetadataDefinitions.tt file to point to your MetadataDefinitions.xml file (relative path).
  1. You are ready to go.