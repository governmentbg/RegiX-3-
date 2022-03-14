using System;
using System.Collections.Generic;
using System.Text;
using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ElementConsumer;
using TechnoLogica.RegiX.Admin.Infrastructure.Models.DatabaseOperationService;

namespace TechnoLogica.RegiX.Admin.Services.Contracts
{
    public interface IElementConsumerWithElementsService : IBaseService<ElementConsumerWithElementsInDto, ElementConsumerWithElementsOutDto,
        GetElementConsumersElementsViewOutput, decimal>
    {

    }
}
