using System;
using System.Web.UI;
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

            using (var pipeline = new PipelineInfo("Basket", OrderPipelineType.Basket))
            {
                basket.RunPipeline(pipeline);
            }
        }
    }
}