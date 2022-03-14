using System.Collections.Generic;
using System.Linq;
using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.RegisterObjectElement;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace TechnoLogica.RegiX.Admin.Services.Contracts
{
    public interface IRegisterObjectElementService : IBaseService<RegisterObjectElementInDto,
        RegisterObjectElementOutDto, RegisterObjectElements, decimal>
    {
        IEnumerable<decimal> GetSelectedElements(decimal registerObjectId, decimal certificateId);

        IEnumerable<decimal> GetSelectedConsumerRoleElements(decimal registerObjectId, decimal consumerRoleId);
    }
}