using System;
using CSUtilities.Pipelines;
using CSUtilities.Pipelines.OrderAdapters;

namespace CSUtilities.Samples.Pipelines
{
    public class PropertyPersistingComponent : OrderPipelineComponentBase
    {
        protected override void Execute(OrderAdapter order)
        {
            throw new NotImplementedException("undone");

            foreach (var lineItem in order.LineItems)
            {
                foreach (var property in new[] { "test", "test2", "test3"})
                    lineItem.PersistProductProperty(property);
            }
        }
    }
}