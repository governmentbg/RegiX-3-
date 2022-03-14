using System.Linq;
using RegiX.Info.Infrastructure.Models;
using RegiX.Info.Repositories.Contracts;
using TechnoLogica.API.Repositories.Impl;

namespace RegiX.Info.Repositories.Impl
{
    public class ConsumerProfileUsersRepository : ABaseRepository<ConsumerProfileUsers, decimal, RegiXContext>, IConsumerProfileUsersRepository
    {
        public ConsumerProfileUsersRepository(RegiXContext aDbContext) : base(aDbContext)
        {
        }

        public override IQueryable<ConsumerProfileUsers> SelectAll()
        {
            var result = GetDbContext().Set<ConsumerProfileUsers>()
                .AsQueryable();

            return result;
        }

        public override ConsumerProfileUsers Select(decimal aId)
        {
            return this.SelectAll().SingleOrDefault(x => x.ConsumerProfileUserId == aId);
        }

        
    }
}