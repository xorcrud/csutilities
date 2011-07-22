using System;
using System.Web;
using Microsoft.Commerce.Common;

namespace CSUtilities.Common
{
    public class ActualFaultExceptionHandler : IExceptionHandler
    {
        private const string ContextKey = "875CBF75-DDB5-4F87-B773-A4888211BF93";

        public Exception HandleException(Exception exception)
        {
            if (exception != null)
                HttpContext.Current.Items[ContextKey] = exception;

            return exception;
        }

        public static bool TryGetActualException(out Exception exception)
        {
            exception = HttpContext.Current.Items[ContextKey] as Exception;

            return exception != null;
        }

        public string InitializationData
        {
            get; set;
        }
    }
}