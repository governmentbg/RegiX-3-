using System.Linq;
using Microsoft.EntityFrameworkCore;
using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.Client.Infrastructure.Models;
using TechnoLogica.RegiX.Client.Repositories.Contracts;

namespace TechnoLogica.RegiX.Client.Repositories.Impl
{
    public class EnumItemsToParameterTypesRepository : ABaseRepository<EnumItemsToParameterTypes, int,RegiXClientContext>,
        IEnumItemsToParameterTypesRepository
    {
        public override IQueryable<EnumItemsToParameterTypes> SelectAll()
        {
            return GetDbContext().Set<EnumItemsToParameterTypes>().AsNoTracking()
                .Include(r => r.Enum)
                .Include(r => r.ParameterType)
                .AsQueryable();
        }

        public override EnumItemsToParameterTypes Select(int aId)
        {
            return SelectAll()
                .SingleOrDefault(r => r.EnumId == aId);
        }

        public EnumItemsToParameterTypesRepository(RegiXClientContext aDbContext) : base(aDbContext)
        {
        }
    }
}