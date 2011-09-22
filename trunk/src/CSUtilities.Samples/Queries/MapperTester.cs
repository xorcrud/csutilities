using System.Linq;
using CSUtilities.Extensions;
using CSUtilities.Mappers;
using CSUtilities.Mappers.Attributes;
using Microsoft.Commerce.Common;
using Microsoft.Commerce.Common.MessageBuilders;
using Microsoft.Commerce.Contracts;
using Microsoft.Commerce.Contracts.Messages;

namespace CSUtilities.Samples.Queries
{
    [ModelMapping("Product")]
    public class Product
    {
        [Mapping]
        public string Id { get; set; }

        [Mapping]
        public string DisplayName { get; set; }
    }

    public class MapperTester
    {
        public Product GetProduct(string catalogName, string productId)
        {
            var query = new CommerceQuery<CommerceEntity>("Product");
            query.SearchCriteria.Model.SetPropertyValue("CatalogId", catalogName);
            query.SearchCriteria.Model.SetPropertyValue("Id", productId);

            var service = new OperationServiceAgent();
            var response = service.ProcessRequestWithContext(query.ToRequest());

            return
                new Mapper().Map<Product>(
                    response
                        .OperationResponses.OfType<CommerceQueryOperationResponse>()
                        .Single().CommerceEntities.Single());
        }
    }
}