using MetaDataService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;
using RegiX.Info.API.DTOs.Adapter;
using System.Collections.Generic;
using System.Linq;

namespace RegiX.Info.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/Adapter")]
    [Route("api/v{version:apiVersion}/Adapter")]
    [ApiController]
    public class AdapterController : ControllerBase
    {
        private IMemoryCache MemoryCache { get; set; }
        private IDistributedCache DistributedCache { get; set; }
        private IAdapterInformationLoader AdapterInformationLoader { get; set; }

        public AdapterController(IMemoryCache memoryCache, IDistributedCache distributedCache, IAdapterInformationLoader loader)
        {
            MemoryCache = memoryCache;
            DistributedCache = distributedCache;
            AdapterInformationLoader = loader;
        }

        [HttpGet("")]
        public IEnumerable<AdapterListOutDto> Get()
        {
            var adapterInfo = MemoryCache.AdaptersInfo(DistributedCache, AdapterInformationLoader).Select(x => new AdapterListOutDto { Name = x.Name, Version = x.Version });

            return adapterInfo;
        }

        [HttpGet("{id}")]
        public AdapterInfo Get(string id)
        {
            var adapterInfo = MemoryCache.AdaptersInfo(DistributedCache, AdapterInformationLoader).FirstOrDefault(x => x.Name == id);

            return adapterInfo;
        }

        [HttpPost("GetByRegister")]
        public IEnumerable<AdapterListOutDto> GetByRegister([FromBody] JObject obj)
        {
            var adapters = new List<AdapterListOutDto>();
            var administrations =
                MemoryCache
                    .Administrations(DistributedCache, AdapterInformationLoader).
                    Where(a => a.Registers.Length > 0)
                    .OrderBy(a => a.Acronym);//Order by is not needed 

            foreach (var administration in administrations)
            {
                foreach (var register in administration.Registers.Where(x => x.Name == obj["value"].ToString()))
                {
                    foreach (var adapter in register.Adapters)
                    {
                        var currRegister = new AdapterListOutDto() { Name = adapter.Name, Version = adapter.Version };
                        adapters.Add(currRegister);
                    }
                    
                }
            }

            return adapters;
        }

        [HttpGet("adapterBasicInfo/{id}")]
        public AdapterInfo AdapterBasicInfo(string id)
        {

            var adapterInfo = MemoryCache.AdaptersInfo(DistributedCache, AdapterInformationLoader).FirstOrDefault(x => x.Name == id);
            if (adapterInfo == null)
            {
                return null;
            }
            var result = new AdapterInfo
            {
                Name = adapterInfo.Name,
                Interface = adapterInfo.Interface,
                Version = adapterInfo.Version //TODO: Status need to be implemented
            };
            return result;
        }
    }
}