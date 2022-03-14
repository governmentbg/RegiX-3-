using System;
using System.Collections.Generic;
using System.Text;
using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;

namespace TechnoLogica.RegiX.Admin.Repositories.Impl
{
    public class ConsumerRolesRepository : ABaseRepository<ConsumerRoles, decimal, RegiXContext>,
            IConsumerRolesRepository
    {
        public ConsumerRolesRepository(RegiXContext aDbContext)
            : base(aDbContext)
        {
        }
    }
}
