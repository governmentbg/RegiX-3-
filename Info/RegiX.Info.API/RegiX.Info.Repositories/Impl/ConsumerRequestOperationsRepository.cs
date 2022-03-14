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
    public class ConsumerRequestOperationsRepository : ABaseRepository<ConsumerRequestOperations, decimal, RegiXContext>, IConsumerRequestOperationsRepository
    {
        public ConsumerRequestOperationsRepository(RegiXContext aDbContext)
            : base(aDbContext)
        {
        }

        public override IQueryable<ConsumerRequestOperations> SelectAll()
        {
            var result = GetDbContext().Set<ConsumerRequestOperations>()
                .Include(r => r.AdapterOperation)
                .Include(r => r.ConsumerAccessRequest)
                .AsQueryable();

            return result;
        }

        public override ConsumerRequestOperations Select(decimal aId)
        {
            return this.SelectAll().SingleOrDefault(x => x.Id == aId);
        }
    }
}
