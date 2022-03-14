using System.Linq;
using Microsoft.EntityFrameworkCore;
using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.Client.Infrastructure.Models;
using TechnoLogica.RegiX.Client.Repositories.Contracts;

namespace TechnoLogica.RegiX.Client.Repositories.Impl
{
    public class RegistersRepository : ABaseRepository<Registers, int,RegiXClientContext>, IRegistersRepository
    {
        protected IUserContext UserContext { get; private set; }
        public RegistersRepository(RegiXClientContext aDbContext, IUserContext userContext) 
            : base(aDbContext)
        {
            UserContext = userContext;
        }
        public override IQueryable<Registers> SelectAll()
        {
            var result = GetDbContext().Set<Registers>().AsNoTracking()
                .Include(r => r.Authority)
                .AsQueryable();
            return result;
        }

        public override Registers Select(int aId)
        {
            return SelectAll()
                .SingleOrDefault(r => r.Id == aId);
        }

        public Registers SelectByCode(string code)
        {
            var all = GetDbContext().Registers;
            var result = all.FirstOrDefault(r => r.Code == code);
            return result;

        }
    }
}