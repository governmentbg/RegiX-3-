using TechnoLogica.API.Repositories.Contracts;
using TechnoLogica.RegiX.Client.Infrastructure.Models;

namespace TechnoLogica.RegiX.Client.Repositories.Contracts
{
    public interface IParametersRepository : IBaseRepository<Parameters, int, RegiXClientContext>
    {
    }
}