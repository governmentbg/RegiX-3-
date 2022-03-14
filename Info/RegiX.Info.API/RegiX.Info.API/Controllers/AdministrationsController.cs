

using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Hosting.Internal;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RegiX.Info.API.DTOs.Administrations;
using RegiX.Info.Infrastructure.Models;
using RegiX.Info.Services.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TechnoLogica.API.Common.Controllers;

namespace RegiX.Info.API.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/administrations-filter")]//required for default versioning
    [Route("api/v{version:apiVersion}/administrations-filter")]
    //[Authorize]
    public class AdministrationsController : ABaseGetAllController<AdministrationsInDto, AdministrationsOutDto, Administrations, decimal>
    {
        private IMemoryCache MemoryCache { get; set; }
        private IDistributedCache DistributedCache { get; set; }
        private IAdapterInformationLoader AdapterInformationLoader { get; set; }
        private IWebHostEnvironment Environment { get; set; }

        public AdministrationsController(
            IMemoryCache memoryCache,
            IDistributedCache distributedCache,
            IAdapterInformationLoader loader,
            IAdministrationsService aBaseService,
            IWebHostEnvironment  environment)
            : base(aBaseService)
        {
            MemoryCache = memoryCache;
            DistributedCache = distributedCache;
            AdapterInformationLoader = loader;
            Environment = environment;
        }

        [HttpGet("GetAllPrimaries")]
        public IActionResult GetAllPrimaries(ODataQueryOptions<Administrations> aQueryOptions)
        {
            return Ok((this.baseService as IAdministrationsService).SelectAllPrimaries(aQueryOptions));
        }

        [HttpPost("Search/{term}")]
        public IEnumerable<SearchResult> Search([FromRoute] string term)
        {
            var administrations =
                 MemoryCache
                     .Administrations(DistributedCache, AdapterInformationLoader)
                     .Where(a => a.Registers.Length > 0)
                     .OrderBy(a => a.Acronym);//Order by is not needed 
            var result = new List<SearchResult>();
            foreach (var administration in administrations)
            {
                if (administration.Name.Contains(term, System.StringComparison.InvariantCultureIgnoreCase) ||
                    administration.Acronym.Contains(term, System.StringComparison.InvariantCultureIgnoreCase))
                {

                    result.Add(
                        new SearchResult()
                        {
                            DisplayName = administration.Name,
                            Type = "Administration",
                            Arguments = new string[] { administration.Code } //$"public/administrations/{administration.Code}/registries"
                        }
                    );
                }
                foreach (var register in administration.Registers)
                {
                    if (register.Name.Contains(term, System.StringComparison.InvariantCultureIgnoreCase))
                    {
                        result.Add(
                            new SearchResult()
                            {
                                DisplayName = register.Name,
                                Type = "Register",
                                Arguments = new string[] { administration.Code }
                            }
                        );
                    }
                    foreach (var adapter in register.Adapters)
                    {
                        if (adapter.Name.Contains(term, System.StringComparison.InvariantCultureIgnoreCase) ||
                            adapter.Interface.Contains(term, System.StringComparison.InvariantCultureIgnoreCase) ||
                            adapter.Version.Contains(term, System.StringComparison.InvariantCultureIgnoreCase)
                            )
                        {
                            result.Add(
                               new SearchResult()
                               {
                                   DisplayName = adapter.Name,
                                   Type = "Adapter",
                                   Arguments = new string[] { administration.Code }
                               }
                            );
                        }
                        foreach (var operation in adapter.Operations)
                        {
                            if (operation.Description.Contains(term, System.StringComparison.InvariantCultureIgnoreCase) ||
                                operation.FullName.Contains(term, System.StringComparison.InvariantCultureIgnoreCase)
                                )
                            {
                                result.Add(
                                   new SearchResult()
                                   {
                                       DisplayName = operation.Description,
                                       Type = "Operation",
                                       Arguments = new string[] { administration.Code, adapter.Interface, operation.FullName }
                                   }
                                );
                            }
                            if (operation.CommonXSD.Any(s => s.Contains(term, System.StringComparison.InvariantCultureIgnoreCase)))
                            {
                                result.Add(
                                   new SearchResult()
                                   {
                                       DisplayName = operation.Description,
                                       Type = "CommonXSD",
                                       Arguments = new string[] { administration.Code, adapter.Interface, operation.FullName }
                                   }
                                );
                            }
                            if (operation.RequestXSD.Contains(term, System.StringComparison.InvariantCultureIgnoreCase))
                            {
                                result.Add(
                                   new SearchResult()
                                   {
                                       DisplayName = operation.Description,
                                       Type = "Request",
                                       Arguments = new string[] { administration.Code, adapter.Interface, operation.FullName }
                                   }
                                );
                            }
                            if (operation.ResponseXSD.Contains(term, System.StringComparison.InvariantCultureIgnoreCase))
                            {
                                result.Add(
                                   new SearchResult()
                                   {
                                       DisplayName = operation.Description,
                                       Type = "Response",
                                       Arguments = new string[] { administration.Code, adapter.Interface, operation.FullName }
                                   }
                                );
                            }
                        }
                    }
                }
            }
            AddStaticFilesSearch(result, term);
            return result;
        }

        private void AddStaticFilesSearch(List<SearchResult> result, string term)
        {

            var serializer = new JsonSerializer();
            Dictionary<string, string> markedFileTitles;
            using(var stream = Environment.ContentRootFileProvider.GetDirectoryContents("marked").Where(f => f.Name == "md-description").First().CreateReadStream())
            using (var sr = new StreamReader(stream))
            {
                var jsonString = sr.ReadToEnd();
                var jobj = JObject.Parse(jsonString);
                markedFileTitles = jobj.Children().Cast<JProperty>()
                            .ToDictionary(x => x.Name, x => (string)x.Value);
            }

            foreach (var file in Environment.ContentRootFileProvider.GetDirectoryContents("marked"))
            {
                if (!file.IsDirectory && file.Name.EndsWith(".md"))
                {
                    using (var reader = new StreamReader(file.CreateReadStream()))
                    {
                        string content = reader.ReadToEnd();
                        if (content.Contains(term))
                        {
                            result.Add(new SearchResult()
                            {
                                DisplayName = markedFileTitles.Keys.Contains(file.Name) ? markedFileTitles[file.Name] : file.Name,
                                Arguments = new string[] { file.Name },
                                Type = "marked"
                            });
                        }
                    }
                }
            }
        }
    }
    public class SearchResult
    {
        public string DisplayName { get; set; }
        public string Type { get; set; }
        public string[] Arguments { get; set; }
    }
}