using System.Linq;
using Microsoft.EntityFrameworkCore;
using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.Client.Infrastructure.Models;
using TechnoLogica.RegiX.Client.Repositories.Contracts;

namespace TechnoLogica.RegiX.Client.Repositories.Impl
{
    public class AdapterOperationsRepository : ABaseRepository<AdapterOperations, int, RegiXClientContext>, IAdapterOperationsRepository
    {

        public AdapterOperationsRepository(RegiXClientContext aDbContext) 
            : base(aDbContext)
        {
        }
        public override IQueryable<AdapterOperations> SelectAll()
        {

            return
                GetDbContext().Set<AdapterOperations>().AsNoTracking()
                .Include(r => r.Register)
                .AsQueryable();
        }

        public override AdapterOperations Select(int aId)
        {
            return SelectAll()
                .SingleOrDefault(r => r.Id == aId);
        }

        public AdapterOperations SelectByOperationName(string operationName)
        {
            return SelectAll()
                .FirstOrDefault(r => r.OperationName == operationName);
        }
    }
}