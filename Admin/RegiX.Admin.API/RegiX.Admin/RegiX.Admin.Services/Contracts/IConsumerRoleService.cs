using System;
using System.Collections.Generic;
using System.Text;
using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ConsumerRole;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace TechnoLogica.RegiX.Admin.Services.Contracts
{
    public interface IConsumerRoleService : IBaseService<ConsumerRoleInDto,
        ConsumerRoleOutDto, ConsumerRoles, decimal>
    {
    }
}
