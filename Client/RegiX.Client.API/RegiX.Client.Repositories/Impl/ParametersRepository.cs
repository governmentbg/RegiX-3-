using System.Linq;
using Microsoft.EntityFrameworkCore;
using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.Client.Infrastructure.Models;
using TechnoLogica.RegiX.Client.Repositories.Contracts;

namespace TechnoLogica.RegiX.Client.Repositories.Impl
{
    public class ParametersRepository : ABaseRepository<Parameters, int,RegiXClientContext>, IParametersRepository
    {
        public override IQueryable<Parameters> SelectAll()
        {
            return GetDbContext().Set<Parameters>()
                .Include(p => p.ParentParameter)
                .Include(p => p.ParameterType)
                .AsQueryable();
        }

        public override Parameters Select(int aId)
        {
            return GetDbContext().Set<Parameters>()
                .Include(p => p.ParentParameter)
                .Include(p => p.ParameterType)
                .SingleOrDefault(p => p.Id == aId);
        }

        public ParametersRepository(RegiXClientContext aDbContext) : base(aDbContext)
        {
        }
    }
}