using Microsoft.AspNetCore.Mvc;
using System.Linq;
using RegiX.Info.API;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Caching.Distributed;

namespace RegiX.Info.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class RequestMetadataController : ControllerBase
    {
        private IMemoryCache MemoryCache { get; set; }
        private IDistributedCache DistributedCache { get; set; }
        private IAdapterInformationLoader AdapterInformationLoader { get; set; }

        public RequestMetadataController(IMemoryCache memoryCache, IDistributedCache distributedCache, IAdapterInformationLoader loader)
        {
            MemoryCache = memoryCache;
            DistributedCache = distributedCache;
        }

        [HttpGet("{id}")]
        public string Get(string id)
        {
            var lastDotIndex = id.LastIndexOf('.');
            var name = id.Substring(0, lastDotIndex); //TechnoLogica.RegiX.MVRBDSAdapter.APIService.IMVRBDSAPI
            var operationName = id.Substring(lastDotIndex + 1); // GetPersonalIdentity

            var adapterInfo = MemoryCache.AdaptersInfo(DistributedCache, AdapterInformationLoader).FirstOrDefault(x => x.Interface == name);
            var currentOperation = adapterInfo.Operations.FirstOrDefault(x => x.FullName == operationName);
            var resultDataXml = currentOperation.MetaDataXML;

            return resultDataXml;
        }
    }
}