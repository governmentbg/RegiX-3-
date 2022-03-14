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
    public class ConsumerProfileRepository : ABaseRepository<ConsumerProfiles, decimal, RegiXContext>, IConsumerProfileRepository
    {
        public ConsumerProfileRepository(RegiXContext aDbContext) : base(aDbContext) { 

        }

        public override IQueryable<ConsumerProfiles> SelectAll()
        {
            var result = GetDbContext().Set<ConsumerProfiles>()
               .Include(r => r.ConsumerProfileStatus)
               .Include(r => r.ConsumerProfileUsers)
               .Include(r => r.ConsumerSystems)
               .AsQueryable();

            return result;
        }
    }
}
