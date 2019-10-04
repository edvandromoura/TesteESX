using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Modelo.Infra.CrossCutting.Extensions
{
    public static class EntityExtension
    {
        public static string PropertieFieldName<T>(Expression<Func<T, object>> expr)
        {
            var path = new StringBuilder();
            MemberExpression memberExpression = GetMemberExpression(expr);
            while (memberExpression != null)
            {
                if (path.Length > 0)
                {
                    path.Insert(0, ".");
                }
                path.Insert(0, memberExpression.Member.Name);
                memberExpression = GetMemberExpression(memberExpression.Expression);
            }

            return path.ToString();
        }

        public static MemberExpression GetMemberExpression(Expression expression)
        {
            if (expression is MemberExpression)
            {
                return (MemberExpression)expression;
            }
            else if (expression is LambdaExpression)
            {
                var lambdaExpression = expression as LambdaExpression;
                if (lambdaExpression.Body is MemberExpression)
                {
                    return (MemberExpression)lambdaExpression.Body;
                }
                else if (lambdaExpression.Body is UnaryExpression)
                {
                    return ((MemberExpression)((UnaryExpression)lambdaExpression.Body).Operand);
                }
            }
            else if (expression is MethodCallExpression)
            {
                var methodCall = expression as MethodCallExpression;
                var property = methodCall.Object as MemberExpression;

                return property;

            }
            return null;
        }
    }
}
