using System.Linq;
using Microsoft.EntityFrameworkCore;
using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;

namespace TechnoLogica.RegiX.Admin.Repositories.Impl
{
    public class ConsumerRequestStatusRepository :
        ABaseRepository<ConsumerRequestStatus, decimal, RegiXContext>,
        IConsumerRequestStatusRepository
    {
        public ConsumerRequestStatusRepository(RegiXContext aDbContext) 
            : base(aDbContext)
        {
        }

        public override IQueryable<ConsumerRequestStatus> SelectAll()
        {
            var result =
                GetDbContext()
                    .Set<ConsumerRequestStatus>()
                    .Include(r => r.ConsumerRequest)
                    .AsQueryable();

            return result;
        }

        public override ConsumerRequestStatus Select(decimal aId)
        {
            return this.SelectAll().SingleOrDefault(x => x.Id == aId);
        }
    }
}