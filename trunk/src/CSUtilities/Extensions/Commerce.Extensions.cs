using System;
using System.Diagnostics.Contracts;
using System.Globalization;
using Microsoft.Commerce.Common;
using Microsoft.Commerce.Contracts.Messages;

namespace Vertica.CoreCommerce.Repositories.Commerce
{
	public static class CommerceExtensions
	{
		public static string ToCommerceId(this Guid guid)
		{
			return guid.ToString("B");
		}

	    public static CommerceResponse ProcessRequestWithContext(this IOperationServiceAgent agent, CommerceRequest request)
	    {
	        Contract.Requires<ArgumentNullException>(agent != null);
	        Contract.Requires<ArgumentNullException>(request != null);

	        var requestContext = new CommerceRequestContext
	        {
	            Channel = "DefaultChannel",
	            UserId = Guid.NewGuid().ToString("b"),
	            UserLocale = CultureInfo.CurrentCulture.ToString(),
	            UserUILocale = CultureInfo.CurrentUICulture.ToString(),
	            RequestId = Guid.NewGuid().ToString()
	        };

	        return agent.ProcessRequest(requestContext, request);
	    }
	}
}