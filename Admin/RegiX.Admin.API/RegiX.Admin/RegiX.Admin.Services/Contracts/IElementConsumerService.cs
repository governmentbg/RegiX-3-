using Microsoft.AspNet.OData.Query;
using TechnoLogica.API.DataContracts;
using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ElementConsumer;
using TechnoLogica.RegiX.Admin.Infrastructure.Models.DatabaseOperationService;
using TechnoLogica.RegiX.Admin.Infrastructure.Models.DatabaseOperationsModels;

namespace TechnoLogica.RegiX.Admin.Services.Contracts
{
    public interface IElementConsumerService : IBaseService<ElementConsumerInDto, ElementConsumerOutDto,
        GetElementConsumersViewOutput, decimal>
    {
        
    }
}
