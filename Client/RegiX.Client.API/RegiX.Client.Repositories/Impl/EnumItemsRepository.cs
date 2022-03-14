using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.Client.Infrastructure.Models;
using TechnoLogica.RegiX.Client.Repositories.Contracts;

namespace TechnoLogica.RegiX.Client.Repositories.Impl
{
    public class EnumItemsRepository : ABaseRepository<EnumItems, int,RegiXClientContext>, IEnumItemsRepository
    {
        public EnumItemsRepository(RegiXClientContext aDbContext) : base(aDbContext)
        {
        }
    }
}