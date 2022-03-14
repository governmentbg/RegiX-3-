using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using RegiX.Info.API.DTOs.Operation;
using System.Collections.Generic;
using System.Linq;
using MetaDataService;
using Newtonsoft.Json.Linq;
using RegiX.Info.API.DTOs.Adapter;
using Microsoft.Extensions.Caching.Distributed;

namespace RegiX.Info.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/operations")]
    [Route("api/v{version:apiVersion}/operations")]
    [ApiController]
    public class OperationController : ControllerBase
    {
        private IMemoryCache MemoryCache { get; set; }
        private IDistributedCache DistributedCache { get; set; }
        private IAdapterInformationLoader AdapterInformationLoader { get; set; }

        public OperationController(IMemoryCache memoryCache, IDistributedCache distributedCache, IAdapterInformationLoader loader)
        {
            MemoryCache = memoryCache;
            DistributedCache = distributedCache;
            AdapterInformationLoader = loader;
        }

        [HttpGet("")]
        public IEnumerable<OperationOutDto> Get()
        {
            var operations = new List<OperationOutDto>();
            var administrations =
                MemoryCache
                    .Administrations(DistributedCache, AdapterInformationLoader).
                    Where(a => a.Registers.Length > 0)
                    .OrderBy(a => a.Acronym);//Order by is not needed 

            foreach (var administration in administrations)
            {
                foreach (var register in administration.Registers)
                {
                    foreach (var adapter in register.Adapters)
                    {
                        foreach (var operation in adapter.Operations)
                        {
                            operations.Add(new OperationOutDto(){Name = operation.FullName ,Description = operation.Description, Interface = adapter.Interface});
                        }
                    }
                }
            }

            return operations;
        }

        [HttpGet("GetByOperationName/{id}")]
        public OperationInfo GetByOperationName(string id)
        {
            var adapterInterface = id.Substring(0, id.LastIndexOf('.'));
            var operationName = id.Substring(id.LastIndexOf('.') + 1);

            var operations = new List<OperationInfo>();
            var administrations =
                MemoryCache
                    .Administrations(DistributedCache, AdapterInformationLoader).
                    Where(a => a.Registers.Length > 0)
                    .OrderBy(a => a.Acronym);//Order by is not needed 

            foreach (var administration in administrations)
            {
                foreach (var register in administration.Registers)
                {
                    foreach (var adapter in register.Adapters.Where(x => x.Interface == adapterInterface))
                    {
                        foreach (var operation in adapter.Operations)
                        {
                            operations.Add(operation);
                        }
                    }
                }
            }

            return operations.SingleOrDefault(x => x.FullName == operationName);
        }

        [HttpPost("GetByAdapter")]
        public IEnumerable<OperationOutDto> GetByAdapter([FromBody] JObject obj)
        {
            var operations = new List<OperationOutDto>();
            var administrations =
                MemoryCache
                    .Administrations(DistributedCache, AdapterInformationLoader).
                    Where(a => a.Registers.Length > 0)
                    .OrderBy(a => a.Acronym);//Order by is not needed 

            foreach (var administration in administrations)
            {
                foreach (var register in administration.Registers)
                {
                    foreach (var adapter in register.Adapters.Where(x => x.Name == obj["value"].ToString()))
                    {
                        foreach (var operation in adapter.Operations)
                        {
                            var currRegister = new OperationOutDto() { Name = operation.FullName, Description = operation.Description, Interface = adapter.Interface};
                            operations.Add(currRegister);
                        }
                        
                    }

                }
            }

            return operations;
        }
    }
}