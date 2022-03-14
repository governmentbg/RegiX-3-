using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using TechnoLogica.API.Common.Controllers;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.RegisterObjectElement;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Services.Contracts;
namespace TechnoLogica.RegiX.Admin.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/register-object-elements")]//required for default versioning
    [Route("api/v{version:apiVersion}/register-object-elements")]
    [Authorize]
    public class RegisterObjectElementController : ABaseGetAllController<RegisterObjectElementInDto, RegisterObjectElementOutDto, RegisterObjectElements, decimal>
    {
        private readonly IRegisterObjectElementService aBaseService;

        public RegisterObjectElementController(IRegisterObjectElementService aBaseService) 
            : base(aBaseService)
        {
            this.aBaseService = aBaseService;
        }

        [HttpPost("GetSelectedElements")]
        public IEnumerable<decimal> GetSelectedElements([FromBody]JObject request)
        {
            var certificateId = decimal.Parse(request.GetValue("certificate").ToString());
            var registerObjectId = decimal.Parse(request.GetValue("operation").ToString());
            var result = this.aBaseService.GetSelectedElements(registerObjectId, certificateId);
            return result;
        }

        [HttpPost("GetSelectedConsumerRoleElements")]
        public IEnumerable<decimal> GetSelectedConsumerRoleElements([FromBody]JObject request)
        {
            var roleId = decimal.Parse(request.GetValue("role").ToString());
            var registerObjectId = decimal.Parse(request.GetValue("operation").ToString());
            var result = this.aBaseService.GetSelectedConsumerRoleElements(registerObjectId, roleId);
            return result;
        }
    }
}
