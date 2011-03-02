using System;
using System.Configuration;

namespace CSUtilities.Providers.Components.FullTextSearch
{
    public class LoggingConfigurationElement : ConfigurationElement, ILoggingConfiguration
    {
        private const string ThrowOnConfigurationErrorsName = "throwOnConfigurationErrors";
        private const string MeasureExecutionTimeName = "measureExecutionTime";

        [ConfigurationProperty(MeasureExecutionTimeName, IsRequired = false, DefaultValue = true)]
        public bool MeasureExecutionTime
        {
            get
            {
                return (bool)base[MeasureExecutionTimeName];
            }
        }

        [ConfigurationProperty(ThrowOnConfigurationErrorsName, IsRequired = false, DefaultValue = true)]
        public bool ThrowOnConfigurationErrors
        {
            get
            {
                return (bool)base[ThrowOnConfigurationErrorsName];
            }
        }
    }
}