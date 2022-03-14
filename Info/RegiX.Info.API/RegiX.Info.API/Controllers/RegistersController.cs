using Microsoft.AspNetCore.Mvc;
using RegiX.Info.DataContracts.DTO.Registers;
using RegiX.Info.Infrastructure.Models;
using RegiX.Info.Services.Contracts;
using TechnoLogica.API.Common.Controllers;

namespace RegiX.Info.API.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/registers-filter")]//required for default versioning
    [Route("api/v{version:apiVersion}/registers-filter")]
    //[Authorize]
    public class RegistersController : ABaseGetAllController<RegisterInDto, RegisterOutDto, Registers, decimal>
    {
        public RegistersController(
            IRegistersService aBaseService
           )
            : base(aBaseService)
        {
        }
    }
}