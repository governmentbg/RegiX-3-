using System;
using System.Linq;
using System.Linq.Expressions;
using TechnoLogica.RegiX.AdapterConsole.Infrastructure.Filters;

namespace TechnoLogica.RegiX.AdapterConsole.Repositories
{
    public static class IUserContextExtentions
    {
        public static IQueryable<T> FilterByUser<T>(this IUserContext context, IQueryable<T> queryable)
            where T : IUserIdFilter
        {
            if (context.MainRole == "Admin") return queryable;
            return queryable.Where(t => t.UserId == context.UserId);
        }

        public static IQueryable<T> FilterByUser<T>(this IUserContext context, IQueryable<T> queryable,
            Expression<Func<T, int>> selector)
        {
            var selectorBodyExpression = selector.Body;
            var expressionBody = Expression.Equal(selectorBodyExpression, Expression.Constant(context.UserId.Value));
            var whereExpression = Expression.Lambda<Func<T, bool>>(expressionBody, selector.Parameters.First());
            return queryable.Where(whereExpression);
        }
    }
}