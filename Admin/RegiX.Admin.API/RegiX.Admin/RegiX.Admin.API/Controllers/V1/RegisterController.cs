using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechnoLogica.API.Common.Controllers;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.Register;
using TechnoLogica.RegiX.Admin.API.RegiXInfo;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Services.Contracts;

namespace RegiX.Admin.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/registers")]//required for default versioning
    [Route("api/v{version:apiVersion}/registers")]
    [Authorize]
    public class RegisterController : ABaseGetAllController<RegisterInDto, RegisterOutDto, Registers, decimal>
    {
        private IInfoAPIClient InfoAPIClient { get; set; }

        public RegisterController(
            IRegisterService aBaseService,
            IInfoAPIClient infoAPIClient)
            : base(aBaseService)
        {
            InfoAPIClient = infoAPIClient;
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPut("{aId}")]
        public override IActionResult Put(decimal aId, [FromBody] RegisterInDto aInDto)
        {
            var result = base.Put(aId, aInDto);
            InfoAPIClient.NotifyInfoAPI().Wait();
            return result;
        }
    }
}