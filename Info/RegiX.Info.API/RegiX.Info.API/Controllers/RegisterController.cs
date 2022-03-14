using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MetaDataService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;
using RegiX.Info.API.DTOs.Registries;

namespace RegiX.Info.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/registers")]
    [Route("api/v{version:apiVersion}/registers")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private IMemoryCache MemoryCache { get; set; }
        private IDistributedCache DistributedCache { get; set; }
        private IAdapterInformationLoader AdapterInformationLoader { get; set; }

        public RegisterController(IMemoryCache memoryCache, IDistributedCache distributedCache, IAdapterInformationLoader loader)
        {
            MemoryCache = memoryCache;
            DistributedCache = distributedCache;
            AdapterInformationLoader = loader;
        }

        [HttpGet("")]
        public IEnumerable<RegisterOutDto> Get()
        {
            var registries = new List<RegisterOutDto>();
            var administrations =
                MemoryCache
                    .Administrations(DistributedCache, AdapterInformationLoader).
                    Where(a => a.Registers.Length > 0)
                    .OrderBy(a => a.Acronym);//Order by is not needed 

            foreach (var administration in administrations)
            {
                foreach (var register in administration.Registers)
                {
                    var currRegister = new RegisterOutDto() { Name = register.Name, Description =  register.Description};
                    registries.Add(currRegister);
                }
            }

            return registries;
        }

        [HttpPost("GetByAdministration")]
        public IEnumerable<RegisterOutDto> GetByAdministration([FromBody] JObject acronym)
        {

            var registries = new List<RegisterOutDto>();
            var administrations =
                MemoryCache
                    .Administrations(DistributedCache, AdapterInformationLoader).
                    Where(a => a.Registers.Length > 0 && a.Acronym == acronym["value"].ToString())
                    .OrderBy(a => a.Acronym);//Order by is not needed 

            foreach (var administration in administrations)
            {
                foreach (var register in administration.Registers)
                {
                    
                    var currRegister = new RegisterOutDto() { Name = register.Name, Description = register.Description };
                    registries.Add(currRegister);
                }
            }

            return registries;
        }

        [HttpGet("GetByAdministrationCode/{adminCode}")]
        public IEnumerable<Register> GetByAdministrationCode([FromRoute]string adminCode)
        {
            //var result = Startup.administrations;
            var result =
                MemoryCache
                    .Administrations(DistributedCache, AdapterInformationLoader)
                    .Where(a => a.Registers.Length > 0 && (a.Code == adminCode || adminCode == "-"))
                    .SelectMany(a =>
                        a.Registers
                        .Where(r => r.Adapters.Length > 0)
                        .Select(r => new Register
                        {
                            Name = r.Name,
                            BindingName = r.BindingName,
                            AuthorityId = r.AuthorityId,
                            ClientName = r.ClientName,
                            Code = r.Code,
                            Adapters = r.Adapters.Select(adp => new AdapterInfo
                            {
                                Interface = adp.Interface,
                                Description = adp.Description,
                                Name = adp.Name,
                                Version = adp.Version,
                                Operations = adp.Operations?.Select(o => new OperationInfo
                                {
                                    FullName = o.FullName,
                                    Description = o.Description //Display name in DB !
                                })
                                .OrderBy(o => o.Description)
                                .ToArray()
                            })
                            .OrderBy(a => a.Name)
                            .ToArray()
                        })
                        .OrderBy(r => r.Name)
                        .ToArray()
                    )
                    .OrderBy(r => r.Name);
            return result;
        }
    }
}