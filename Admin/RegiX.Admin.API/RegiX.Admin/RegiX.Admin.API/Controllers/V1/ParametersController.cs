using CoreServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TechnoLogica.API.Common.Controllers;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ParametersValuesLog;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Services.Contracts;
using System.Linq;
using System;
using TechnoLogica.RegiX.Admin.API.CoreServices;
using Microsoft.Extensions.Configuration;
using TechnoLogica.API.Common;

namespace TechnoLogica.RegiX.Admin.API.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/parameters")]//required for default versioning
    [Route("api/v{version:apiVersion}/parameters")]
    [Authorize]
    public class ParametersController : ControllerBase
    {
        private IRegisterAdapterService AdapterService { get; set; }
        private readonly CoreServicesSettings coreServicesSettings;

        public ParametersController(
            IRegisterAdapterService adapterService,
            IConfiguration configuration)
        {
            AdapterService = adapterService;
            coreServicesSettings = configuration.GetSettings<CoreServicesSettings>();
        }

        [HttpGet("{id}")]
        [Authorize(Roles = Constants.GLOBAL_ADMIN)]
        public IActionResult Get(decimal id)
        {
            var adapter = AdapterService.Select(id);

            var client = new RegiXMetaDataServiceClient(
                coreServicesSettings.EndpointConfiguration,
                coreServicesSettings.EndpointAddress);
            var result = client.GetParametersAsync(adapter.Contract)
                .GetAwaiter()
                .GetResult()?
                .ParameterListk__BackingField?.Select(
                 p => new ParameterOut
                 {
                     Description = p.Descriptionk__BackingField,
                     Key = p.Keyk__BackingField,
                     Value = p.CurrentValuek__BackingField
                 }).ToList();
            return Ok(result);
        }

        [HttpPost("{id}")]
        [Authorize(Roles = Constants.GLOBAL_ADMIN)]
        public IActionResult Post(decimal id, [FromBody] ParameterIn[] paramIn)
        {
            var adapter = AdapterService.Select(id);

            var client = new RegiXMetaDataServiceClient(
                coreServicesSettings.EndpointConfiguration,
                coreServicesSettings.EndpointAddress);
            try
            {
                foreach (var parameter in paramIn)
                {
                    client.SetParameterAsync(adapter.Contract, parameter.Key, parameter.Value).GetAwaiter().GetResult();
                }
                return Ok();
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
    public class ParameterIn
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }

    public class ParameterOut
    {
        public string Description { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
