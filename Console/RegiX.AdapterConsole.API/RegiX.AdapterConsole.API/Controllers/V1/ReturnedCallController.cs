using System.Linq;
using System.Xml.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechnoLogica.API.Common.Controllers;
using TechnoLogica.RegiX.AdapterConsole.API.Controllers.Helpers;
using TechnoLogica.RegiX.AdapterConsole.DataContracts.DTO;
using TechnoLogica.RegiX.AdapterConsole.DataContracts.ReturnedCalls;
using TechnoLogica.RegiX.AdapterConsole.Infrastructure.Models;
using TechnoLogica.RegiX.AdapterConsole.Services.Contracts;

namespace TechnoLogica.RegiX.AdapterConsole.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/returned-calls")] //required for default versioning
    [Route("api/v{version:apiVersion}/returned-calls")]
    [Authorize]
    public class
        ReturnedCallController : ABaseGetAllController<ReturnedCallsInDto, ReturnedCallsOutDto, ReturnedCalls, int>
    {
        public ReturnedCallController(IReturnedCallsService aBaseService)
            : base(aBaseService)
        {
        }

        public override IActionResult Get(int aId)
        {
            var result = ((IReturnedCallsService) baseService).Select(aId);

            if (result != null)
            {
                var withParams = new ReturnedCallsOutDto
                {
                    Id = result.Id,
                    AdapterOperation = result.AdapterOperation,
                    StartTime = result.StartTime,
                    ReturnedBy = result.ReturnedBy,    
                    RequestParamsValues = XmlToDic.ConvertXmlToDic(result.Request),
                    ResponseParamsValues = XmlToDic.ConvertXmlToDic(result.Response)
                };
                return Ok(withParams);
            }

            return NotFound();
        }

       
    }
}