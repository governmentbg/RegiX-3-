using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RegiX.Info.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
using TechnoLogica.API.Common;

namespace MetaDataService
{
    public partial class RegiXMetaDataServiceClient
    {
        public RegiXMetaDataServiceClient(IConfiguration configuration, ILogger<RegiXMetaDataServiceClient> logger) : base(RegiXMetaDataServiceClient.GetDefaultBinding(), RegiXMetaDataServiceClient.GetDefaultEndpointAddress())
        {
            var metaDataServiceConfiguration = configuration.GetSettings<MetaDataServiceClientSettings>();
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_IRegiXMetaDataService.ToString();

            if (!string.IsNullOrEmpty(metaDataServiceConfiguration.EndpointAddress))
            {
                this.Endpoint.Address = new System.ServiceModel.EndpointAddress(metaDataServiceConfiguration.EndpointAddress);
                if (this.Endpoint.Address.Uri.Scheme == "https")
                {
                    Console.WriteLine($"Setting transport security mode");
                    (this.Endpoint.Binding as BasicHttpBinding).Security.Mode = BasicHttpSecurityMode.Transport;
                }
            }
            logger.LogInformation($"Endpoint address: {this.Endpoint.Address.Uri.AbsoluteUri}");
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
    }
}
