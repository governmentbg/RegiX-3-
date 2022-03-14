using System;
using System.Linq;
using System.Linq.Expressions;
using TechnoLogica.RegiX.Client.Infrastructure;

namespace TechnoLogica.RegiX.Client.Repositories
{
    public static class IAuthorityContextExtensions
    {
        public static IQueryable<T> FilterByAuthority<T>(this IUserContext context, IQueryable<T> queryable)
            where T : IAuthorityIDFilter
        {
            if (context?.IsGlobalAdmin == true)
            {
                return queryable;
            }
            else if ((context?.AdministrationID).HasValue)
            {
                return queryable.Where(t => t.AuthorityId == context.AdministrationID);
            }
            else
            {
                throw new ArgumentException("Argument should have value!", "AuthorityId");
            }
        }

        public static IQueryable<T> FilterByAuthority<T>(this IUserContext context, IQueryable<T> queryable, Expression<Func<T, int>> selector)
        {
            if (context?.IsGlobalAdmin == true)
            {
                return queryable;
            }
            else if ((context?.AdministrationID).HasValue)
            {
                var selectorBodyExpression = selector.Body;
                var expressionBody = Expression.Equal(selectorBodyExpression, Expression.Constant(context.AdministrationID.Value));
                var whereExpression = Expression.Lambda<Func<T, bool>>(expressionBody, selector.Parameters.First());
                return queryable.Where(whereExpression);
            }
            else
            {
                throw new ArgumentException("Argument should have value!", "AuthorityId");
            }
        }
    }
}