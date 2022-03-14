using System.Linq;
using Microsoft.EntityFrameworkCore;
using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;

namespace TechnoLogica.RegiX.Admin.Repositories.Impl
{
    public class ConsumerProfileUsersRepository : ABaseRepository<ConsumerProfileUsers, decimal, RegiXContext>,
        IConsumerProfileUsersRepository
    {
        public ConsumerProfileUsersRepository(RegiXContext aDbContext)
            : base(aDbContext)
        {
        }

        public override IQueryable<ConsumerProfileUsers> SelectAll()
        {
            return GetDbContext().Set<ConsumerProfileUsers>()
                .Include(r => r.ConsumerProfile)
                .AsQueryable();
        }

        public override ConsumerProfileUsers Select(decimal aId)
        {
            return this.SelectAll().SingleOrDefault(x => x.ConsumerProfileUserId == aId);
        }
    }
}