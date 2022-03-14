using MetaDataService;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TechnoLogica.API.Common;

namespace RegiX.Info.API
{    
    public class AdapterInformationService : BackgroundService
    {
        private ILogger<AdapterInformationService> Logger { get; set; }
        public IAdapterInformationLoader AdapterInformationLoader { get; set; }
        private MetaDataServiceClientSettings Configuration { get; set; }

        public AdapterInformationService(
            ILogger<AdapterInformationService> logger, 
            IConfiguration configuration,
            IAdapterInformationLoader adapterInformationLoader)
        {
            Logger = logger;
            Configuration = configuration.GetSettings<MetaDataServiceClientSettings>();
            AdapterInformationLoader = adapterInformationLoader;
            Logger.LogInformation("AdapterInformationLoader instance created");
        }
        public override Task StartAsync(CancellationToken cancellationToken)
        {
            Logger.LogDebug("Starting AdapterInformationLoader");
            return base.StartAsync(cancellationToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            Logger.LogDebug("Stopping AdapterInformationLoader");
            return base.StopAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Logger.LogDebug("Executing AdapterInformationLoader");
            var policy = Policy
               .Handle<Exception>()
               .WaitAndRetryForeverAsync(
                    (i) => TimeSpan.FromSeconds(Configuration.RetryIntervalSeconds),
                    (ex, timespan) =>
                    Logger.LogError(ex,
                        $"Error while retrieving data! Retring in {timespan.TotalSeconds} seconds..."
                    )
                );
            await policy.ExecuteAsync(() => AdapterInformationLoader.Load());
        }
    }
}
