using System;
using System.Linq;
using TechnoLogica.RegiX.Client.Infrastructure;

namespace TechnoLogica.RegiX.Client.Repositories
{
    public static class IUserContextExtensions
    {
        public static IQueryable<T> FilterByUser<T>(this IUserContext context, IQueryable<T> queryable)
            where T : IUserIDFilter
        {
            if ((context?.UserId).HasValue)
            {
                return queryable.Where(t => t.UserId == context.UserId);
            }
            else
            {
                throw new ArgumentException("Argument should have value!", "UserId");
            }
        }
    }
}