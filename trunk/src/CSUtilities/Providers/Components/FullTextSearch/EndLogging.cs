using System;
using System.Configuration;
using System.Diagnostics;
using CSUtilities.Infrastructure;
using CSUtilities.Resources;
using Microsoft.Commerce.Application.Common.Configuration;
using Microsoft.Commerce.Broker;
using Microsoft.Commerce.Contracts.Messages;
using Microsoft.Commerce.Providers.Components;

namespace CSUtilities.Providers.Components.FullTextSearch
{
    public class EndLogging : OperationSequenceComponent, IConfigurable
    {
        private readonly IServiceContainer _container;
        private ILoggingConfiguration _configuration;

        #region Constructors

        [Obsolete("Required by Foundation API.")]
        public EndLogging()
        {
            _container = new ServiceContainerAdapter();
        }

        internal EndLogging(IServiceContainer container, ILoggingConfiguration configuration)
        {
            if (container == null) throw new ArgumentNullException("container");

            SetConfiguration(configuration);
        }

        #endregion

        public void Configure(ConfigurationElement configuration)
        {
            if (configuration == null) throw new ArgumentNullException("configuration");

            SetConfiguration(configuration as ILoggingConfiguration);
        }

        public override void ExecuteQuery(CommerceQueryOperation queryOperation, OperationCacheDictionary operationCache, CommerceQueryOperationResponse response)
        {
            if (queryOperation == null) throw new ArgumentNullException("queryOperation");
            if (operationCache == null) throw new ArgumentNullException("operationCache");
            if (response == null) throw new ArgumentNullException("response");

            if (LoggingShared.SkipLogging(queryOperation))
                return;

            if (!EnsureStorageProvider())
                return;

            TimeSpan? elapsedTime = GetExecutionTime(operationCache);
            CommerceCatalogFullTextSearch searchCriteria = GetSearchCriteria(queryOperation);

            if (searchCriteria == null)
                return;

            var provider = _container.GetService<ILoggingStorageProvider>();
            provider.Log(new LoggingResult());
        }

        private CommerceCatalogFullTextSearch GetSearchCriteria(CommerceQueryOperation queryOperation)
        {
            var result = queryOperation.SearchCriteria as CommerceCatalogFullTextSearch;

            if (result == null && _configuration.ThrowOnConfigurationErrors)
                throw new InvalidOperationException(Exceptions.FullTextSearchEndLoggingComponentWronglyRegistred);

            return result;
        }

        private TimeSpan? GetExecutionTime(OperationCacheDictionary operationCache)
        {
            if (_configuration.MeasureExecutionTime)
            {
                Stopwatch watch = null;

                object tmp;
                if (operationCache.TryGetValue(LoggingShared.WatchCacheKey, out tmp))
                    watch = tmp as Stopwatch;

                if (watch == null)
                {
                    if (_configuration.ThrowOnConfigurationErrors)
                        throw new InvalidOperationException(Exceptions.NoFullTextSearchBeginLoggingComponentRegistred);
                }
                else
                {
                    watch.Stop();
                    return watch.Elapsed;                    
                }
            }

            return null;
        }

        private bool EnsureStorageProvider()
        {
            if (_container.HasService<ILoggingStorageProvider>())
                return true;

            if (_configuration.ThrowOnConfigurationErrors)
                throw new InvalidOperationException(Exceptions.NoFullTextSearchLoggingSearchProviderRegistred);

            return false;
        }

        internal void SetConfiguration(ILoggingConfiguration configuration)
        {
            if (configuration == null) throw new ArgumentNullException("configuration");

            _configuration = configuration;
        }
    }
}