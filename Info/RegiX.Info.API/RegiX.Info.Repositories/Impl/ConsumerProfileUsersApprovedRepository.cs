using System.Linq;
using Microsoft.EntityFrameworkCore;
using RegiX.Info.Infrastructure.Models;
using RegiX.Info.Repositories.Contracts;
using TechnoLogica.API.Repositories.Impl;

namespace RegiX.Info.Repositories.Impl
{
    public class ConsumerProfileUsersApprovedRepository : ABaseRepository<ConsumerProfileUsers, decimal, RegiXContext>, IConsumerProfileUsersApprovedRepository
    {
        private readonly IConsumerContext consumerContext;

        public ConsumerProfileUsersApprovedRepository(RegiXContext aDbContext, IConsumerContext consumerContext) 
            : base(aDbContext)
        {
            this.consumerContext = consumerContext;
        }

        public override IQueryable<ConsumerProfileUsers> SelectAll()
        {
            var result = 
                GetDbContext()
                    .Set<ConsumerProfileUsers>()
                    .Include(r => r.ConsumerProfile)
                    .AsQueryable();

            //gets all ConsumerProfileUsers(representatives) for current ConsumerProfile that are not activated 
            result = result
                .Where(x => x.ConsumerProfileId == consumerContext.ConsumerProfileID)
                .Where(x => x.IsActive == false);

            return result;
        }

        public override ConsumerProfileUsers Select(decimal aId)
        {
            return this.SelectAll().SingleOrDefault(x => x.ConsumerProfileUserId == aId);
        }
    }
}