namespace CSUtilities.Providers.Components.FullTextSearch
{
    internal interface ILoggingConfiguration
    {
        bool MeasureExecutionTime { get; }
        bool ThrowOnConfigurationErrors { get; }
    }
}