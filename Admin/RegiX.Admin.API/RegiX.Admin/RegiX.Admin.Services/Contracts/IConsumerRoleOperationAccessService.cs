using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ConsumerRoleOperationAccess;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace TechnoLogica.RegiX.Admin.Services.Contracts
{
    public interface IConsumerRoleOperationAccessService : IBaseService<ConsumerRoleOperationAccessInDto,
        ConsumerRoleOperationAccessOutDto, ConsumerRoleOperationAccess, decimal>
    {
        
    }
}