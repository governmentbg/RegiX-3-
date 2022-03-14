using Microsoft.EntityFrameworkCore;
using RegiX.Info.Infrastructure.Models;
using RegiX.Info.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechnoLogica.API.Repositories.Impl;

namespace RegiX.Info.Repositories.Impl
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
