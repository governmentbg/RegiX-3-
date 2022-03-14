using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechnoLogica.API.Common.Controllers;
using TechnoLogica.API.DataContracts;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ElementConsumer;
using TechnoLogica.RegiX.Admin.Infrastructure.Models.DatabaseOperationService;
using TechnoLogica.RegiX.Admin.Infrastructure.Models.DatabaseOperationsModels;
using TechnoLogica.RegiX.Admin.Services.Contracts;

namespace TechnoLogica.RegiX.Admin.API.Controllers.V1.DatabaseOperationsControllers
{
    [ApiVersion("1.0")]
    [Route("api/consumer-usage")]//required for default versioning
    [Route("api/v{version:apiVersion}/consumer-usage")]
    [Authorize]
    public class ElementConsumerViewController : ABaseGetAllController<ElementConsumerInDto, ElementConsumerOutDto, GetElementConsumersViewOutput, decimal>
    {
        public ElementConsumerViewController(IElementConsumerService aBaseService)
           : base(aBaseService)
        {
        }
    }
}
