using Microsoft.Commerce.Common.MessageBuilders;
using Microsoft.Commerce.Contracts;
using Microsoft.Commerce.Contracts.Messages;

namespace CSUtilities.Providers.Components.FullTextSearch
{
    public class SkipLoggingRelatedOperation : CommerceBaseRelatedOperation
    {
        public static readonly string Name = "SkipLogging";

        public SkipLoggingRelatedOperation()
            : base(Name)
        {
        }

        public override CommerceRelatedOperation ToRelatedOperation()
        {
            return new CommerceQueryRelatedItem<CommerceEntity>(Name).ToRelatedOperation();
        }
    }
}