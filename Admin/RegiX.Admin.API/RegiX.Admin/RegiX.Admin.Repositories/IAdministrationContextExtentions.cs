using System;
using System.Linq;
using System.Linq.Expressions;
using TechnoLogica.RegiX.Admin.Infrastructure;
using TechnoLogica.RegiX.Admin.Infrastructure.Models.Filters;

namespace TechnoLogica.RegiX.Admin.Repositories
{
    public static class IAdministrationContextExtentions
    {
        public static IQueryable<T> FilterByAdministration<T>(this IUserContext context, IQueryable<T> queryable)
            where T : IAdministrationIDFilter
        {
            if ((context?.AdministrationID).HasValue)
            {
                return queryable.Where(t => t.AdministrationId == context.AdministrationID);
            }
            else
            {
                return queryable; // Only Global Admin has no AdministrationID so we return all the data.
            }
        }
        public static IQueryable<T> FilterByAdministration<T>(this IUserContext context, IQueryable<T> queryable, Expression<Func<T, decimal>> selector)
        {
            if ((context?.AdministrationID).HasValue)
            {
                var selectorBodyExpression = selector.Body;
                var expressionBody = Expression.Equal(selectorBodyExpression, Expression.Constant(context.AdministrationID.Value));
                var whereExpression = Expression.Lambda<Func<T, bool>>(expressionBody, selector.Parameters.First());
                return queryable.Where(whereExpression);
            }
            else
            {
                return queryable; // Only Global Admin has no AdministrationID so we return all the data.
            }
        }
    }
}