using System;
using System.Reflection;
using CSUtilities.Resources;

namespace CSUtilities.Infrastructure.Utilities
{
	internal static class AttributeExtensions
	{
		#region HasAttribute

		public static bool HasAttribute<T>(this object element) where T : Attribute
		{
			return Attribute.IsDefined(element.GetType(), typeof(T));
		}

		public static bool HasAttribute<T>(this object element, bool inherit) where T : Attribute
		{
			return Attribute.IsDefined(element.GetType(), typeof(T), inherit);
		}

		public static bool HasAttribute(this object element, Type attribute, bool inherit)
		{
			AssertAttribute(attribute);
			return Attribute.IsDefined(element.GetType(), attribute, inherit);
		}

		public static bool HasAttribute<T>(this Assembly element) where T : Attribute
		{
			return Attribute.IsDefined(element, typeof(T));
		}

		public static bool HasAttribute<T>(this Assembly element, bool inherit) where T : Attribute
		{
			return Attribute.IsDefined(element, typeof(T), inherit);
		}

		public static bool HasAttribute(this Assembly element, Type attribute, bool inherit)
		{
			AssertAttribute(attribute);
			return Attribute.IsDefined(element, attribute, inherit);
		}

		public static bool HasAttribute<T>(this MemberInfo element) where T : Attribute
		{
			return Attribute.IsDefined(element, typeof(T));
		}

		public static bool HasAttribute<T>(this MemberInfo element, bool inherit) where T : Attribute
		{
			return Attribute.IsDefined(element, typeof(T), inherit);
		}

		public static bool HasAttribute(this MemberInfo element, Type attribute, bool inherit)
		{
			AssertAttribute(attribute);
			return Attribute.IsDefined(element, attribute, inherit);
		}

		public static bool HasAttribute<T>(this Module element) where T : Attribute
		{
			return Attribute.IsDefined(element, typeof(T));
		}

		public static bool HasAttribute<T>(this Module element, bool inherit) where T : Attribute
		{
			return Attribute.IsDefined(element, typeof(T), inherit);
		}

		public static bool HasAttribute(this Module element, Type attribute, bool inherit)
		{
			AssertAttribute(attribute);
			return Attribute.IsDefined(element, attribute, inherit);
		}

		public static bool HasAttribute<T>(this ParameterInfo element) where T : Attribute
		{
			return Attribute.IsDefined(element, typeof(T));
		}

		public static bool HasAttribute<T>(this ParameterInfo element, bool inherit) where T : Attribute
		{
			return Attribute.IsDefined(element, typeof(T), inherit);
		}

		public static bool HasAttribute(this ParameterInfo element, Type attribute, bool inherit)
		{
			AssertAttribute(attribute);
			return Attribute.IsDefined(element, attribute, inherit);
		}

		#endregion

		#region GetAttribute

		public static T GetAttribute<T>(this object element) where T : Attribute
		{
			return Attribute.GetCustomAttribute(element.GetType(), typeof(T)) as T;
		}

		public static T GetAttribute<T>(this object element, bool inherit) where T : Attribute
		{
			return Attribute.GetCustomAttribute(element.GetType(), typeof(T), inherit) as T;
		}

		public static Attribute GetAttribute(this object element, Type attribute, bool inherit)
		{
			AssertAttribute(attribute);
			return Attribute.GetCustomAttribute(element.GetType(), attribute, inherit);
		}

		public static T GetAttribute<T>(this Assembly element) where T : Attribute
		{
			return Attribute.GetCustomAttribute(element, typeof(T)) as T;
		}

		public static T GetAttribute<T>(this Assembly element, bool inherit) where T : Attribute
		{
			return Attribute.GetCustomAttribute(element, typeof(T), inherit) as T;
		}

		public static Attribute GetAttribute(this Assembly element, Type attribute, bool inherit)
		{
			AssertAttribute(attribute);
			return Attribute.GetCustomAttribute(element, attribute, inherit);
		}

		public static T GetAttribute<T>(this MemberInfo element) where T : Attribute
		{
			return Attribute.GetCustomAttribute(element, typeof(T)) as T;
		}

		public static T GetAttribute<T>(this MemberInfo element, bool inherit) where T : Attribute
		{
			return Attribute.GetCustomAttribute(element, typeof(T), inherit) as T;
		}

		public static Attribute GetAttribute(this MemberInfo element, Type attribute, bool inherit)
		{
			AssertAttribute(attribute);
			return Attribute.GetCustomAttribute(element, attribute, inherit);
		}

		public static T GetAttribute<T>(this Module element) where T : Attribute
		{
			return Attribute.GetCustomAttribute(element, typeof(T)) as T;
		}

		public static T GetAttribute<T>(this Module element, bool inherit) where T : Attribute
		{
			return Attribute.GetCustomAttribute(element, typeof(T), inherit) as T;
		}

		public static Attribute GetAttribute(this Module element, Type attribute, bool inherit)
		{
			AssertAttribute(attribute);
			return Attribute.GetCustomAttribute(element, attribute, inherit);
		}

		public static T GetAttribute<T>(this ParameterInfo element) where T : Attribute
		{
			return Attribute.GetCustomAttribute(element, typeof(T)) as T;
		}

		public static T GetAttribute<T>(this ParameterInfo element, bool inherit) where T : Attribute
		{
			return Attribute.GetCustomAttribute(element, typeof(T), inherit) as T;
		}

		public static Attribute GetAttribute(this ParameterInfo element, Type attribute, bool inherit)
		{
			AssertAttribute(attribute);
			return Attribute.GetCustomAttribute(element, attribute, inherit);
		}

		#endregion

		#region GetAttributes

		public static T[] GetAttributes<T>(this object element) where T : Attribute
		{
			return Attribute.GetCustomAttributes(element.GetType(), typeof(T)) as T[];
		}

		public static T[] GetAttributes<T>(this object element, bool inherit) where T : Attribute
		{
			return Attribute.GetCustomAttributes(element.GetType(), typeof(T), inherit) as T[];
		}

		public static Attribute[] GetAttributes(this object element, Type attribute, bool inherit)
		{
			AssertAttribute(attribute);
			return Attribute.GetCustomAttributes(element.GetType(), attribute, inherit);
		}

		public static T[] GetAttributes<T>(this Assembly element) where T : Attribute
		{
			return Attribute.GetCustomAttributes(element, typeof(T)) as T[];
		}

		public static T[] GetAttributes<T>(this Assembly element, bool inherit) where T : Attribute
		{
			return Attribute.GetCustomAttributes(element, typeof(T), inherit) as T[];
		}

		public static Attribute[] GetAttributes(this Assembly element, Type attribute, bool inherit)
		{
			AssertAttribute(attribute);
			return Attribute.GetCustomAttributes(element, attribute, inherit);
		}

		public static T[] GetAttributes<T>(this MemberInfo element) where T : Attribute
		{
			return Attribute.GetCustomAttributes(element, typeof(T)) as T[];
		}

		public static T[] GetAttributes<T>(this MemberInfo element, bool inherit) where T : Attribute
		{
			return Attribute.GetCustomAttributes(element, typeof(T), inherit) as T[];
		}

		public static Attribute[] GetAttributes(this MemberInfo element, Type attribute, bool inherit)
		{
			AssertAttribute(attribute);
			return Attribute.GetCustomAttributes(element, attribute, inherit);
		}

		public static T[] GetAttributes<T>(this Module element) where T : Attribute
		{
			return Attribute.GetCustomAttributes(element, typeof(T)) as T[];
		}

		public static T[] GetAttributes<T>(this Module element, bool inherit) where T : Attribute
		{
			return Attribute.GetCustomAttributes(element, typeof(T), inherit) as T[];
		}

		public static Attribute[] GetAttributes(this Module element, Type attribute, bool inherit)
		{
			AssertAttribute(attribute);
			return Attribute.GetCustomAttributes(element, attribute, inherit);
		}

		public static T[] GetAttributes<T>(this ParameterInfo element) where T : Attribute
		{
			return Attribute.GetCustomAttributes(element, typeof(T)) as T[];
		}

		public static T[] GetAttributes<T>(this ParameterInfo element, bool inherit) where T : Attribute
		{
			return Attribute.GetCustomAttributes(element, typeof(T), inherit) as T[];
		}

		public static Attribute[] GetAttributes(this ParameterInfo element, Type attribute, bool inherit)
		{
			AssertAttribute(attribute);
			return Attribute.GetCustomAttributes(element, attribute, inherit);
		}

		#endregion

		private static void AssertAttribute(Type attribute)
		{
            if (!attribute.IsSubclassOf(typeof(Attribute)))
                throw new ArgumentException(String.Format(Exceptions.AttributeExtensions_NonAttribute, attribute.FullName, "attribute"));
		}
	}
}
