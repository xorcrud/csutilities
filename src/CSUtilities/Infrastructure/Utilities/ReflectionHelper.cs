using System;

namespace CSUtilities.Infrastructure.Utilities
{
	/// <summary>
	/// Helper class to simplify common reflection tasks.
	/// </summary>
	internal static class ReflectionHelper
	{
		public static bool IsNullableType(Type type)
		{
			return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);
		}
	}
}