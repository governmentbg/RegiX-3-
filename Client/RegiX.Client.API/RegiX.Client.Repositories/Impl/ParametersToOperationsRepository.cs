using System.Linq;
using Microsoft.EntityFrameworkCore;
using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.Client.Infrastructure.Models;
using TechnoLogica.RegiX.Client.Repositories.Contracts;

namespace TechnoLogica.RegiX.Client.Repositories.Impl
{
    public class ParametersToOperationsRepository : ABaseRepository<ParametersToOperation, int,RegiXClientContext>,
        IParametersToOperationsRepository
    {
        public override IQueryable<ParametersToOperation> SelectAll()
        {
            return GetDbContext().Set<ParametersToOperation>()
                .Include(po => po.Parameter)
                .Include(po => po.AdapterOperation)
                .AsQueryable();
        }

        public override ParametersToOperation Select(int aId)
        {
            return GetDbContext().Set<ParametersToOperation>()
                .Include(po => po.Parameter)
                .Include(po => po.AdapterOperation)
                .SingleOrDefault(po => po.ParameterId == aId);
        }

        public ParametersToOperationsRepository(RegiXClientContext aDbContext) : base(aDbContext)
        {
        }
    }
}