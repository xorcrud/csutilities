namespace CSUtilities.Infrastructure.Utilities
{
    internal static class DataHelper
    {
        public static string SafeToString<T>(this T instance)
            where T : class
        {
            if (instance != null)
                return instance.ToString();

            return null;
        }
    }
}