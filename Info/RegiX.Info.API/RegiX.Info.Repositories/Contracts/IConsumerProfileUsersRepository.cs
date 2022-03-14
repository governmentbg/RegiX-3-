using RegiX.Info.Infrastructure.Models;
using TechnoLogica.API.Repositories.Contracts;

namespace RegiX.Info.Repositories.Contracts
{
    public interface IConsumerProfileUsersRepository : IBaseRepository<ConsumerProfileUsers, decimal, RegiXContext>
    {
        
    }
}