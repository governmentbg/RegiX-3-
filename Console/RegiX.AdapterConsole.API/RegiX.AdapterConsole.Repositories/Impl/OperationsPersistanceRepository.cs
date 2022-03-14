using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.AdapterConsole.Infrastructure.Models;
using TechnoLogica.RegiX.AdapterConsole.Repositories.Contracts;

namespace TechnoLogica.RegiX.AdapterConsole.Repositories.Impl
{
    public class OperationsPersistanceRepository : ABaseRepository<OperationsPersistance, int, RegiXAdapterConsoleContext>,
        IOperationsPersistanceRepository
    {
        public OperationsPersistanceRepository(RegiXAdapterConsoleContext aDbContext): base(aDbContext) { }

        public override IQueryable<OperationsPersistance> SelectAll()
        {
            var result =
                GetDbContext().Set<OperationsPersistance>()
                    .Include(r => r.AdapterOperation)
                    .Where( r => r.RawUnsignedResult != null && r.RawResult == null);
            return result;
        }
    }
}