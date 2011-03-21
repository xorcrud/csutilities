using System;
using System.Diagnostics;
using System.Globalization;
using System.Web.UI;
using CSUtilities.Providers.Components.FullTextSearch;
using Microsoft.Commerce.Common;
using Microsoft.Commerce.Common.MessageBuilders;
using Microsoft.Commerce.Contracts;
using Microsoft.Commerce.Contracts.Messages;
using Microsoft.CommerceServer.Runtime;
using Microsoft.CommerceServer.Runtime.Orders;

namespace Website.WebForms.DotNet40
{
    public partial class SmokeTests : Page
    {
        protected void Pipeline_Execute(object sender, EventArgs e)
        {
            var basket = CommerceContext.Current.OrderSystem.GetBasket(Guid.NewGuid(), "Default2007");

            basket.OrderForms.Add(new OrderForm());

            basket.OrderForms[0].LineItems.Add(new LineItem("TestCatalog", "1-1", null, 5));
            basket.OrderForms[0].LineItems.Add(new LineItem("TestCatalog", "1-2", null, 5));

            basket.Addresses.Add(new OrderAddress("AddressName", Guid.NewGuid().ToString()) {City = "My City"});
            basket.Addresses.Add(new OrderAddress("AddressName2", Guid.NewGuid().ToString()) { City = "My City2" });

            using (var pipeline = new PipelineInfo("Basket", OrderPipelineType.Basket))
            {
                basket.RunPipeline(pipeline);
            }
        }

        protected void FullTextSearch_Execute(object sender, EventArgs e)
        {
            var query = new CommerceQuery<CommerceEntity,
                CommerceCatalogFullTextSearchBuilder>("CatalogEntity");
            query.Model.Properties.Add("Id");
            query.Model.Properties.Add("DisplayName");

            query.RelatedOperations.Add(new SkipLoggingRelatedOperation());

            query.SearchCriteria.Catalogs.Add("TestCatalog");
            query.SearchCriteria.FullTextSearchType = CommerceFullTextSearchType.FreeText;
            query.SearchCriteria.TypesToSearch = CommerceCatalogEntityTypes.All;
            query.SearchCriteria.Phrase = "Some search string";
            query.SearchCriteria.ReturnTotalItemCount = true;

            var serviceAgent = new OperationServiceAgent();

            var watch = Stopwatch.StartNew();

            var context = new CommerceRequestContext
            {
                Channel = "DefaultChannel",
                RequestId = Guid.NewGuid().ToString(),
                UserId = Guid.NewGuid().ToString("b"),
                UserLocale = CultureInfo.CurrentCulture.ToString(),
                UserUILocale = CultureInfo.CurrentUICulture.ToString()
            };

            var response = serviceAgent.ProcessRequest(context, query.ToRequest());

            var queryResponse = response.OperationResponses[0] as CommerceQueryOperationResponse;
        }

        protected void QueryThatThrows_Execute(object sender, EventArgs e)
        {
            var query = new CommerceQuery<CommerceEntity>("NonExistingModel");
            var serviceAgent = new OperationServiceAgent();

            var context = new CommerceRequestContext
            {
                Channel = "DefaultChannel",
                RequestId = Guid.NewGuid().ToString(),
                UserId = Guid.NewGuid().ToString("b"),
                UserLocale = CultureInfo.CurrentCulture.ToString(),
                UserUILocale = CultureInfo.CurrentUICulture.ToString()
            };

            serviceAgent.ProcessRequest(context, query.ToRequest());
        }
    }
}