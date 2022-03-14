using System.Linq;
using Microsoft.EntityFrameworkCore;
using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;

namespace TechnoLogica.RegiX.Admin.Repositories.Impl
{
    public class ConsumerRequestElementsRepository : ABaseRepository<ConsumerRequestElements, decimal, RegiXContext>, IConsumerRequestElementsRepository
    {
        public ConsumerRequestElementsRepository(RegiXContext aDbContext) 
            : base(aDbContext)
        {
        }

        public override IQueryable<ConsumerRequestElements> SelectAll()
        {
            var result = GetDbContext().Set<ConsumerRequestElements>()
                .Include(r => r.RegisterObjectElement)
                .AsQueryable();

            return result;
        }

        public override ConsumerRequestElements Select(decimal aId)
        {
            return this.SelectAll().SingleOrDefault(x => x.Id == aId);
        }
    }
}