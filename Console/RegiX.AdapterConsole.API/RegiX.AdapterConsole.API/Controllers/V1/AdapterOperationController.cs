using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechnoLogica.API.Common.Controllers;
using TechnoLogica.RegiX.AdapterConsole.DataContracts.AdapterOperation;
using TechnoLogica.RegiX.AdapterConsole.Infrastructure.Models;
using TechnoLogica.RegiX.AdapterConsole.Services.Contracts;
using TechnoLogica.RegiX.Common.Metadata.AdapterOperations;
using TechnoLogica.RegiX.Common.Utils;

namespace TechnoLogica.RegiX.AdapterConsole.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/adapter-operations")] //required for default versioning
    [Route("api/v{version:apiVersion}/adapter-operations")]
    [Authorize]
    public class AdapterOperationController : ABaseGetAllController<AdapterOperationsInDto, AdapterOperationsOutDto,
        AdapterOperations, int>
    {
        private readonly IAdapterOperationsService _aBaseService;

        public AdapterOperationController(IAdapterOperationsService aBaseService)
            : base(aBaseService)
        {
            _aBaseService = aBaseService;
        }

        public override IActionResult Get(int aId)
        {
            var result = ((IAdapterOperationsService) baseService).Select(aId);

            if (result != null)
            {
                var withParams = new AdapterOperationsWithParams
                {
                    Id = result.Id,
                    Name = result.Name,
                    Description = result.Description,
                    Contract = result.Contract,
                    RequestMetadata = result.MetadataRequestXml.XmlDeserialize<AdapterOperation>().Parameters,
                    ResponseMetadata = result.MetadataResponseXml.XmlDeserialize<AdapterOperation>().Parameters
                };
                return Ok(withParams);
            }

            return NotFound();
        }

        public class AdapterOperationsWithParams : AdapterOperationsOutDto
        {
            public List<Parameter> RequestMetadata { get; set; }
            public List<Parameter> ResponseMetadata { get; set; }
        }
    }
}