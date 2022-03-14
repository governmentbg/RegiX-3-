using MetaDataService;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using TechnoLogica.API.Common;
using TechnoLogica.RegiX.Common.Utils;

namespace RegiX.Info.API
{
    public static class IMemoryCacheExtensions
    {
        public static IEnumerable<AdapterInfo> AdaptersInfo(this IMemoryCache memoryCache, IDistributedCache distributedCache, IAdapterInformationLoader loader)
        {
            return memoryCache.GetOrCreate<IEnumerable<AdapterInfo>>(
                AdapterInformationLoader.AdaptersInfo, 
                (e) => 
                {
                    var adapterInfoBytes = distributedCache.GetString(AdapterInformationLoader.AdaptersInfo);
                    if (string.IsNullOrEmpty(adapterInfoBytes))
                    {
                        loader.Load().Wait();
                        adapterInfoBytes = distributedCache.GetString(AdapterInformationLoader.AdaptersInfo);
                    }
                    if (!string.IsNullOrEmpty(adapterInfoBytes))
                    {
                        return adapterInfoBytes.XmlDeserialize<AdapterInfo[]>();
                    }
                    else
                    {
                        return new List<AdapterInfo>();
                    }                
                }
            );
        }
        public static IEnumerable<Administration> Administrations(this IMemoryCache memoryCache, IDistributedCache distributedCache, IAdapterInformationLoader loader)
        {
            return memoryCache.GetOrCreate<IEnumerable<Administration>>(
                AdapterInformationLoader.Administrations,
                (e) =>
                {
                    var administrationsBytes = distributedCache.GetString(AdapterInformationLoader.Administrations);
                    if (string.IsNullOrEmpty(administrationsBytes))
                    {
                        loader.Load().Wait();
                        administrationsBytes = distributedCache.GetString(AdapterInformationLoader.Administrations);
                    }
                    if (!string.IsNullOrEmpty(administrationsBytes))
                    {
                        return administrationsBytes.XmlDeserialize<Administration[]>();
                    }
                    else
                    {
                        return new List<Administration>();
                    }
                }
            );
        }
    }

    public interface IAdapterInformationLoader
    {
        Task Load();
    }

    public class AdapterInformationLoader : IAdapterInformationLoader
    {
        public static string AdaptersInfo = "AdaptersInfo";
        public static string Administrations = "Administrations";
        private IMemoryCache MemoryCache { get; set; }
        private IDistributedCache DistributedCache { get; set; }
        private MetaDataServiceClientSettings Configuration { get; set; }
        private ILogger<AdapterInformationLoader> Logger { get; set; }
        private IRegiXMetaDataService MetaDataClient { get; set; }

        public AdapterInformationLoader(
            ILogger<AdapterInformationLoader> logger,
            IRegiXMetaDataService metaDataService,
            IConfiguration configuration,
            IDistributedCache distributedCache,
            IMemoryCache memoryCache)
        {
            MetaDataClient = metaDataService;
            Configuration = configuration.GetSettings<MetaDataServiceClientSettings>();
            MemoryCache = memoryCache;
            DistributedCache = distributedCache;
            Logger = logger;
        }

        public async Task Load()
        {
            Logger.LogDebug($"MetaDataClient state: {(MetaDataClient as ICommunicationObject).State}");
            using (MetaDataClient as IDisposable)
            {
                var adaptersInfo = await MetaDataClient.GetAdaptersInfoAsync();                
                MemoryCache.Set(AdapterInformationLoader.AdaptersInfo, adaptersInfo);
                Logger.LogInformation($"Received info for {AdaptersInfo.Count()} adapters");
                try
                {
                    var administrations = await MetaDataClient.GetAdministrationsAsync();                    
                    MemoryCache.Set(AdapterInformationLoader.Administrations, administrations);
                    await AddAdaptersToAdministration(adaptersInfo, administrations);
                    await DistributedCache.SetStringAsync(AdapterInformationLoader.AdaptersInfo, adaptersInfo.XmlSerialize());
                    await DistributedCache.SetStringAsync(AdapterInformationLoader.Administrations, administrations.XmlSerialize());
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex, "Error while retrieving Administrations");
                }
            }
        }

        private async Task AddAdaptersToAdministration(IEnumerable<AdapterInfo> adaptersInfo,
            IEnumerable<Administration> administrations)
        {
            foreach (var administration in administrations)
            {
                var notEmptyRegisters = new List<Register>();
                foreach (var register in administration.Registers)
                {
                    var existingAdapters = new List<AdapterInfo>();
                    foreach (var adapter in register.Adapters)
                    {
                        var name = "RegiX." + adapter.Name;
                        var currAdapter = adaptersInfo.FirstOrDefault(a => a.Name == name);
                        if (currAdapter != null)
                        {
                            existingAdapters.Add(adapter);
                            adapter.Operations = currAdapter.Operations;
                            adapter.Interface = currAdapter.Interface;
                            adapter.Version = currAdapter.Version;
                            adapter.Name = currAdapter.Name;
                        }
                        else
                        {
                            Logger.LogWarning($"There is no information for adapter {name}! Removing from List");
                        }
                    }
                    register.Adapters = existingAdapters.ToArray();
                    if (register.Adapters.Length > 0)
                    {
                        notEmptyRegisters.Add(register);
                    }
                }
                administration.Registers = notEmptyRegisters.ToArray();
            }
        }
    }
}
