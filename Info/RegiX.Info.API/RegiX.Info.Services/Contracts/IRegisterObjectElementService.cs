using RegiX.Info.DataContracts.DTO.RegisterObjectElement;
using RegiX.Info.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;
using TechnoLogica.API.Services;

namespace RegiX.Info.Services.Contracts
{
    public interface IRegisterObjectElementService : IBaseService<RegisterObjectElementInDto,
        RegisterObjectElementOutDto, RegisterObjectElements, decimal>
    {
        //IEnumerable<decimal> GetSelectedElements(decimal registerObjectId, decimal certificateId);

        //IEnumerable<decimal> GetSelectedConsumerRoleElements(decimal registerObjectId, decimal consumerRoleId);
    }
}
