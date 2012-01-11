using System;
using System.Collections.Generic;

namespace CSUtilities.Infrastructure.Utilities
{
	internal static class ClassMapper<TFrom, TTo>
		where TFrom : class
		where TTo : class
	{
		public static IEnumerable<TTo> MapIfNotNull(IEnumerable<TFrom> from, Func<TFrom, TTo> doMapping)
		{
			List<TTo> to = null;
			if (from != null)
			{
				to = new List<TTo>();

			    foreach (var item in from)
			    {
			        var itemCopy = item;

                    TTo partial = MapIfNotNull(item, () => doMapping(itemCopy));

                    if (partial != null) 
                        to.Add(partial);			        
			    }
			}

			return to;
		}

		public static TTo MapIfNotNull(TFrom from, Func<TTo> doMapping)
		{
			return MapIfNotNull(from, doMapping, null);
		}

		public static TTo MapIfNotNull(TFrom from, Func<TTo> doMapping, TTo defaultTo)
		{
			TTo to = defaultTo;
			if (from != null)
			{
				to = doMapping();
			}
			return to;
		}
	}
}
