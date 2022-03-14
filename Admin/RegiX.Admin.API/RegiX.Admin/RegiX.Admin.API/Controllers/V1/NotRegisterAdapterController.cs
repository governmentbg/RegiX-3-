using CoreServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Services.Contracts;
using TechnoLogica.RegiX.Admin.Services.Services;
using TechnoLogica.RegiX.Admin.API.RegiXInfo;
using Microsoft.Extensions.Configuration;
using TechnoLogica.RegiX.Admin.API.CoreServices;

namespace RegiX.Admin.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/not-register-adapters")]//required for default versioning
    [Route("api/v{version:apiVersion}/not-register-adapters")]
    [Authorize]
    public class NotRegisterAdapterController : ControllerBase
    {
        private IInfoAPIClient InfoAPIClient { get; set; }
        private readonly INotRegisterAdapterService service;
        private readonly CoreServicesSettings coreServicesSettings;

        public NotRegisterAdapterController(
            INotRegisterAdapterService service,
            IInfoAPIClient infoAPIClient,
            IConfiguration configuration
            )
        {
            this.service = service;
            InfoAPIClient = infoAPIClient;
            coreServicesSettings = configuration.GetSettings<CoreServicesSettings>();
        }

        [HttpGet("getAll")]
        public IEnumerable<AdapterVersion> notRegisterAdapters()
        {
            var client = new RegiXMetaDataServiceClient(
                coreServicesSettings.EndpointConfiguration, 
                coreServicesSettings.EndpointAddress);
            var result = client.GetNotRegisteredAdaptersAsync()
                .GetAwaiter()
                .GetResult();
            return result;
        }

        [HttpGet("{id}")]
        public AdapterDataDto adapterInformation(string id)
        {
            if (!id.StartsWith("RegiX."))
            {
                id = "RegiX." + id;
            }
            var client = new RegiXMetaDataServiceClient(
                coreServicesSettings.EndpointConfiguration,
                coreServicesSettings.EndpointAddress);
            var result = client.GetAllAdapterDataAsync(id)
                .GetAwaiter()
                .GetResult();
            return result;
        }

        [HttpPut("{id}")]
        public IActionResult saveAdapter(string id, [FromBody] AdapterDataDto adapter)
        {
            try
            {
                ApiServices apiService = FillApiServiceValues(adapter);
                RegisterAdapters registerAdapter = FillAdapterValues(adapter);
                this.service.InsertRegisterAdapter(registerAdapter, apiService);
                InfoAPIClient.NotifyInfoAPI().Wait();
                return Ok(adapter);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        private RegisterAdapters FillAdapterValues(AdapterDataDto adapter)
        {
            var result = new RegisterAdapters()
            {
                AdapterUrl = adapter.NotRegisterAdapterInfo.AdapterUrl,
                Assembly = adapter.NotRegisterAdapterInfo.Assembly,
                BindingConfigName = adapter.NotRegisterAdapterInfo.BindingConfigName,
                BindingType = adapter.NotRegisterAdapterInfo.BindingType,
                Contract = adapter.NotRegisterAdapterInfo.Contract,
                Description = adapter.NotRegisterAdapterInfo.Description,
                Name = adapter.NotRegisterAdapterInfo.Name,
                RegisterId = adapter.NotRegisterAdapterInfo.Register,
                RegisterObjects = adapter.NotRegisterAdapterInfo.RegisterObjects.Select(x => new RegisterObjects()
                {
                    Description = x.Description,
                    FullName = x.FullName,
                    Name = x.Name,
                    RegisterObjectElements = x.RegisterObjectElements.Select(y => new RegisterObjectElements()
                    {
                        Description = y.Description,
                        Name = y.Name,
                        PathToRoot = y.PathToRoot
                    }).ToList()
                }).ToList(),
            };
            result.AdapterOperations = adapter.NotRegisterAdapterInfo.AdapterOperations.Select(x => new AdapterOperations
            {
                Description = x.Description,
                Name = x.Name,
                RegisterObject = 
                    (x.RegisterObjectFullName != null) ? 
                        result.RegisterObjects.Where( ro => ro.FullName == x.RegisterObjectFullName).Single() : 
                        null
            }).ToList();

            return result;
        }

        private ApiServices FillApiServiceValues(AdapterDataDto adapter)
        {
            var result = new ApiServices
            {
                Name = adapter.NotRegisterApiService.Name,
                Description = adapter.NotRegisterApiService.Description,
                Contract = adapter.NotRegisterApiService.Contract,
                Code = adapter.NotRegisterApiService.Code,
                ServiceUrl = adapter.NotRegisterApiService.ServiceUrl,
                Assembly = adapter.NotRegisterAdapterInfo.Assembly,
                Enabled = true,
                ApiServiceOperations = adapter.NotRegisterApiService.ApiServiceOperations.Select(x => new ApiServiceOperations()
                {
                    Code = x.Code,
                    Description = x.Description,
                    Name = x.Name,
                }).ToList(),
            };

            return result;
        }
    }
}