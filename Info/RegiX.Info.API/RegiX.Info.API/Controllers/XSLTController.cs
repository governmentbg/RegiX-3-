using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using TechnoLogica.API.Common;
using TechnoLogica.RegiX.Common.Utils;

namespace RegiX.Info.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class XSLTController : ControllerBase
    {
        private RegiXInfoSettings Configuration { get; set; }

        private IMemoryCache MemoryCache { get; set; }
        private IDistributedCache DistributedCache { get; set; }
        private IAdapterInformationLoader AdapterInformationLoader { get; set; }

        public XSLTController(
            IMemoryCache memoryCache,
            IDistributedCache distributedCache,
            IConfiguration configuration,
            IAdapterInformationLoader loader)
        {
            MemoryCache = memoryCache;
            DistributedCache = distributedCache;
            Configuration = configuration.GetSettings<RegiXInfoSettings>();
            AdapterInformationLoader = loader;
        }

        [HttpGet("{xsltName}")]
        public IActionResult Get(string xsltName)
        {
            System.Text.RegularExpressions.Regex regex =
                new System.Text.RegularExpressions.Regex(
                    @"(?<interface>.*)\.(?<operation>[^\.]*)\.(?<requestType>(request|response))\.xslt"
                    );
            var match = regex.Match(xsltName);
            if (match.Success)
            {
                string operationInterface = match.Groups["interface"].Value;
                string fullName = match.Groups["operation"].Value;
                bool request = match.Groups["requestType"].Value.Equals("request");
                string result =
                    MemoryCache.AdaptersInfo(DistributedCache, AdapterInformationLoader)
                        .Where(ai => ai.Interface.Equals(operationInterface))
                        .FirstOrDefault()?
                        .Operations
                        .Where(op => op.FullName.Equals(fullName))
                        .Select(s => request ? s.RequestXslt : s.ResponseXslt)
                        .FirstOrDefault();
                return (result != null) ? (IActionResult)Content(result, "text/xsl") : NotFound();

            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("operations")]
        public IActionResult Operations()
        {
            var res = new List<OperationShortInfo>();
            MemoryCache.AdaptersInfo(DistributedCache, AdapterInformationLoader)
                .Select(
                        ai =>
                        {
                            ai.Operations.Select(op =>
                            {
                                res.Add(
                                    new OperationShortInfo(){
                                        FullName = $"{ai.Interface}.{op.FullName}",
                                        Description = op.Description
                                    }
                                ); 
                                return 1;
                            }).ToList();
                            return 1;
                        })
                .ToList();
            return Ok(res);
        }
        [HttpGet("sample/{type}/{fullName}")]
        public IActionResult Sample(string type, string fullName)
        {
            System.Text.RegularExpressions.Regex regex =
               new System.Text.RegularExpressions.Regex(
                   @"(?<interface>.*)\.(?<operation>[^\.]*)\.xml"
                   );
            var match = regex.Match(fullName);
            if (match.Success)
            {
                var intrface = match.Groups["interface"].Value;
                var operation = match.Groups["operation"].Value;
                var adapterInfo = MemoryCache.AdaptersInfo(DistributedCache, AdapterInformationLoader).FirstOrDefault(x => x.Interface == intrface);
                var currentOperation = adapterInfo.Operations.FirstOrDefault(x => x.FullName == operation);
                var xsd = (type == "request") ? currentOperation?.SampleRequestXML : currentOperation?.SampleResponseXML;
                if (!string.IsNullOrEmpty(xsd))
                {
                    var xsdDocument = new XmlDocument();
                    xsdDocument.LoadXml(xsd);

                    string styleSheetReference =
                        $"type=\"text/xsl\" href=\"{Configuration.HostAddress}/api/XSLT/{intrface}.{operation}.{type}.xslt\"";
                    var styleSheetPI = xsdDocument.CreateProcessingInstruction("xml-stylesheet", styleSheetReference);
                    if (xsdDocument.FirstChild is XmlDeclaration)
                    {
                        xsdDocument.InsertAfter(styleSheetPI, xsdDocument.FirstChild);
                    }
                    else
                    {
                        xsdDocument.InsertBefore(styleSheetPI, xsdDocument.FirstChild);
                    }                    

                    return (IActionResult)Content(xsdDocument.OuterXml, "text/xml");
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return NotFound();
            }
        }
    }
    public class OperationShortInfo
    {
        public string FullName { get; set; }
        public string Description { get; set; }
    }
}
