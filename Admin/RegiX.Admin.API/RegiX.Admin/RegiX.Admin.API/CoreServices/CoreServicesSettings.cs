using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CoreServices.RegiXMetaDataServiceClient;

namespace TechnoLogica.RegiX.Admin.API.CoreServices
{
    public class CoreServicesSettings
    {
        public string EndpointAddress { get; set; }
        public EndpointConfiguration EndpointConfiguration { get; set; }
    }
}
