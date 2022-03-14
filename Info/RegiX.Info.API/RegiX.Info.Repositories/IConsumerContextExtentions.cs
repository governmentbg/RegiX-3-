using RegiX.Info.Infrastructure.Filters;
using System;
using System.Linq;

namespace RegiX.Info.Repositories
{
    public static class IConsumerContextExtentions
    {
        public static IQueryable<T> FilterByProfile<T>(this IConsumerContext context, IQueryable<T> queryable)
            where T : IConsumerIDFilter
        {
            if ((context?.ConsumerProfileID).HasValue)
            {
                return queryable.Where(t => t.ConsumerProfileId == context.ConsumerProfileID);
            }
            else
            {
                throw new ArgumentException("ConsumerProfileID is mandatory");
            }
        }
    }
}
