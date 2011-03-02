using System;
using Microsoft.Commerce.Contracts.Messages;

namespace CSUtilities.Providers.Components.FullTextSearch
{
    internal static class LoggingShared
    {
        public static readonly string WatchCacheKey = "52FE965C-49B6-4D05-BB02-393758F9E67A";

        public static bool SkipLogging(CommerceQueryOperation operation)
        {
            if (operation == null) throw new ArgumentNullException("operation");

            var skipLogging =
                operation.RelatedOperations != null &&
                operation.RelatedOperations.Exists(
                    x => String.Equals(x.RelationshipName, "SkipLogging", StringComparison.OrdinalIgnoreCase));

            return skipLogging;
        }
    }
}