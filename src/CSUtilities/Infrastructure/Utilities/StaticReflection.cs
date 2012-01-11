using System;
using System.Linq.Expressions;
using System.Reflection;

namespace CSUtilities.Infrastructure.Utilities
{
	/* based on Rhinocommons.StaticReflection to provide "refactoring-safe" reflection
	 * https://rhino-tools.svn.sourceforge.net/svnroot/rhino-tools/trunk/rhino-commons/Rhino.Commons.Clr/ */

	internal static class StaticReflection
	{
		public static PropertyInfo PropertyInfo<TObject, TValue>(Expression<Func<TObject, TValue>> propertyExpr)
		{
			return GetMemberExpression(propertyExpr).Member as PropertyInfo;
		}

		private static MemberExpression GetMemberExpression<TObject, TValue>(Expression<Func<TObject, TValue>> expression)
		{
			MemberExpression memberExpression = null;
			if (expression.Body.NodeType == ExpressionType.Convert)
			{
				var body = (UnaryExpression)expression.Body;
				memberExpression = body.Operand as MemberExpression;
			}
			else if (expression.Body.NodeType == ExpressionType.MemberAccess)
			{
				memberExpression = expression.Body as MemberExpression;
			}

            if (memberExpression == null)
                throw new ArgumentException("Expression does not represent a member", "expression");

			return memberExpression;
		}
	}
}