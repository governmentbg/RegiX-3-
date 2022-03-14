using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechnoLogica.API.Common.Controllers;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO.Register;
using TechnoLogica.RegiX.Client.Infrastructure.Models;
using TechnoLogica.RegiX.Client.Services.Contracts;

namespace TechnoLogica.RegiX.Client.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/registers")] //required for default versioning
    [Route("api/v{version:apiVersion}/registers")]
    [Authorize]
    public class RegisterController : ABaseGetAllController<RegisterInDto, RegisterOutDto, Registers, int>
    {
        public RegisterController(IRegisterService aBaseService)
            : base(aBaseService)
        {
        }
    }
}