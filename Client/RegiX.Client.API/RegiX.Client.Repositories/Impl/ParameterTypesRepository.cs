using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.Client.Infrastructure.Models;
using TechnoLogica.RegiX.Client.Repositories.Contracts;

namespace TechnoLogica.RegiX.Client.Repositories.Impl
{
    public class ParameterTypesRepository : ABaseRepository<ParameterTypes, int,RegiXClientContext>, IParameterTypesRepository
    {
        public ParameterTypesRepository(RegiXClientContext aDbContext) : base(aDbContext)
        {
        }
    }
}