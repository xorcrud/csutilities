using System.Diagnostics;
using Microsoft.Commerce.Broker;
using Microsoft.Commerce.Contracts.Messages;
using Microsoft.Commerce.Providers.Components;

namespace CSUtilities.Providers.Components.FullTextSearch
{
    public class BeginLogging : OperationSequenceComponent
    {
        public override void ExecuteQuery(CommerceQueryOperation queryOperation, OperationCacheDictionary operationCache, CommerceQueryOperationResponse response)
        {
            if (LoggingShared.SkipLogging(queryOperation))
                return;

            operationCache[LoggingShared.WatchCacheKey] = Stopwatch.StartNew();
        }
    }
}