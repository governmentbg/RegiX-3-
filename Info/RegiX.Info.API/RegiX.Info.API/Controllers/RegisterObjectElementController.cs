using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using RegiX.Info.DataContracts.DTO.RegisterObjectElement;
using RegiX.Info.Infrastructure.Models;
using RegiX.Info.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnoLogica.API.Common.Controllers;

namespace RegiX.Info.API.Controllers
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

        //[HttpPost("GetSelectedElements")]
        //public IEnumerable<decimal> GetSelectedElements([FromBody] JObject request)
        //{
        //    var certificateId = decimal.Parse(request.GetValue("certificate").ToString());
        //    var registerObjectId = decimal.Parse(request.GetValue("operation").ToString());
        //    var result = this.aBaseService.GetSelectedElements(registerObjectId, certificateId);
        //    return result;
        //}

        //[HttpPost("GetSelectedConsumerRoleElements")]
        //public IEnumerable<decimal> GetSelectedConsumerRoleElements([FromBody] JObject request)
        //{
        //    var roleId = decimal.Parse(request.GetValue("role").ToString());
        //    var registerObjectId = decimal.Parse(request.GetValue("operation").ToString());
        //    var result = this.aBaseService.GetSelectedConsumerRoleElements(registerObjectId, roleId);
        //    return result;
        //}
    }
}
