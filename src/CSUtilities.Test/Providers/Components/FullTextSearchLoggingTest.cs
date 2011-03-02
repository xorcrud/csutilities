using CSUtilities.Infrastructure;
using CSUtilities.Providers.Components.FullTextSearch;
using Microsoft.Commerce.Broker;
using Microsoft.Commerce.Contracts.Messages;
using NUnit.Framework;
using Rhino.Mocks;

namespace CSUtilities.Test.Providers.Components
{
    [TestFixture]
    public class FullTextSearchLoggingTest
    {
        [Test]
        public void Test()
        {
            var container = MockRepository.GenerateMock<IServiceContainer>();
            var configuration = MockRepository.GenerateMock<ILoggingConfiguration>();
            var subject = new EndLogging(container, configuration);

            var operation = new CommerceQueryOperation();
            var cache = new OperationCacheDictionary();
            var response = new CommerceQueryOperationResponse();

            subject.ExecuteQuery(operation, cache, response);
        }
    }
}