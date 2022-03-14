
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace TechnoLogica.RegiX.Admin.API.RegiXInfo
{
    public class InfoAPIClient : HttpClient, IInfoAPIClient
    {
        private ILogger<InfoAPIClient> Logger { get; set; }

        public InfoAPIClient(IConfiguration configuration, ILogger<InfoAPIClient> logger)
        {
            Logger = logger;
            var infoAPIClientSettings = configuration.GetSettings<InfoAPIClientSettings>();
            Logger.LogDebug($"InfoAPIClient created with endpoint address: {infoAPIClientSettings.EndpointAddress}");
            this.BaseAddress = new Uri(infoAPIClientSettings.EndpointAddress);
        }

        public async Task NotifyInfoAPI()
        {
            Logger.LogDebug("Notifying RegiX.Info.API");
            var response = await this.GetAsync("api/NotifyChanged");
            Logger.LogDebug($"RegiX.Info.API status code:{response.StatusCode}");
        }
    }
}
