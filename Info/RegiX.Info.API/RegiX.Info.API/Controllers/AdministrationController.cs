using System.Collections.Generic;
using System.Linq;
using MetaDataService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using RegiX.Info.API.DTOs.Administration;

namespace RegiX.Info.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/administrations")]
    [Route("api/v{version:apiVersion}/administrations")]
    [ApiController]
    public class AdministrationController : ControllerBase
    {
        private IMemoryCache MemoryCache { get; set; }
        private IDistributedCache DistributedCache { get; set; }
        private IAdapterInformationLoader AdapterInformationLoader { get; set; }

        public AdministrationController(IMemoryCache memoryCache, IDistributedCache distributedCache, IAdapterInformationLoader loader)
        {
            MemoryCache = memoryCache;
            DistributedCache = distributedCache;
            AdapterInformationLoader = loader;
        }

        [HttpGet("")]
        public IEnumerable<Administration> Get()
        {
            var result =
                MemoryCache
                    .Administrations(DistributedCache, AdapterInformationLoader)
                    .Where(a => a.Registers.Length > 0)
                    .Select(a => new Administration
                    {
                        Acronym = a.Acronym,
                        Name = a.Name,
                        Code = a.Code,
                        Registers =
                            a.Registers
                            .Where(r => r.Adapters.Length > 0)
                            .Select(r => new Register
                            {
                                Name = r.Name,
                                Adapters = r.Adapters.Select(adp => new AdapterInfo
                                {
                                    Interface = adp.Interface,
                                    Description = adp.Description,
                                    Name = adp.Name,
                                    Version = adp.Version
                                }).ToArray()
                            }).ToArray()
                    }
                    )
                    .OrderBy(a => a.Acronym)
                    .ToArray();

            return result;
        }

        [HttpGet("GetNames")]
        public IEnumerable<Administration> GetNames(bool orderByAcronym = false)
        {
            var result =
                MemoryCache
                    .Administrations(DistributedCache, AdapterInformationLoader)
                    .Where(a => a.Registers.Length > 0)
                    .Select(a => new Administration
                    {
                        Acronym = a.Acronym,
                        Name = a.Name,
                        Code = a.Code
                    });
            if (orderByAcronym)
            {
                result = result.OrderBy(a => a.Acronym);
            }
            else
            {
                result = result.OrderBy(a => a.Name);
            }

            return result;
        }

        [HttpGet("GetWithOperations")]
        public IEnumerable<Administration> GetWithOperations()
        {
            //var result = Startup.administrations;
            var result =
                MemoryCache
                    .Administrations(DistributedCache, AdapterInformationLoader)
                    .Where(a => a.Registers.Length > 0)
                    .Select(a => new Administration
                    {
                        Acronym = a.Acronym,
                        Name = a.Name,
                        Code = a.Code,
                        IdentificationCode = a.IdentificationCode,
                        OID = a.OID,
                        Registers =
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
                                        RequestXslt = o.RequestXslt,
                                        ResponseXslt = o.ResponseXslt,
                                        MetaDataXML = o.MetaDataXML,
                                        FullName = o.FullName,
                                        Description = o.Description //Display name in DB !

                                    }).ToArray()
                                }).ToArray()
                            })
                            .ToArray()
                    })
                    .OrderBy(a => a.Acronym);
            return result;
        }

        [HttpGet("GetAll")]
        public IEnumerable<AdministrationOutDto> GetAll()
        {
            var administrations =
                MemoryCache
                    .Administrations(DistributedCache, AdapterInformationLoader).
                    Where(a => a.Registers.Length > 0)
                    .OrderBy(a => a.Acronym);
            var result = GetAdapterInfo(administrations);

            return result;
        }

        [HttpGet("GetByCode/{adminCode}")]
        public AdministrationOutDto GetByCode([FromRoute] string adminCode)
        {
            var administration =
                MemoryCache
                    .Administrations(DistributedCache, AdapterInformationLoader)
                    .Where(a => a.Code == adminCode && a.Registers.Length > 0)
                    .Select(a => new AdministrationOutDto() {
                        Acronym = a.Acronym,
                        Name = a.Name
                    })
                    .FirstOrDefault();

            return administration;
        }

        private IEnumerable<AdministrationOutDto> GetAdapterInfo(IEnumerable<Administration> administrations)
        {
            var adaptersInfo = new List<AdministrationOutDto>();

            foreach (var administration in administrations)
            {
                var currAdministration = new AdministrationOutDto();

                currAdministration.Name = administration.Name;
                currAdministration.Acronym = administration.Acronym;
                currAdministration.RegistersCount = administration.Registers.Count();
                currAdministration.AdaptersCount = administration.Registers.Count();

                //int operationsCount = OperationsCount(administration);
                currAdministration.OperationsCount = OperationsCount(administration);

                adaptersInfo.Add(currAdministration);
            }

            return adaptersInfo;
        }

        private int OperationsCount(Administration administration)
        {
            var result =
                administration?.Registers?.Select(
                    r =>
                        r.Adapters?.Select(a => a.Operations?.Length).Sum()).Sum();
            return result ?? 0;
        }
    }
}