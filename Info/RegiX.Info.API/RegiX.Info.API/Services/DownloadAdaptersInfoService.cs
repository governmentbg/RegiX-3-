using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using RegiX.Info.API.Helpers;

namespace RegiX.Info.API.Services
{
    public class DownloadAdaptersInfoService
    {
        private IMemoryCache MemoryCache { get; set; }
        private IDistributedCache DistributedCache { get; set; }
        private IAdapterInformationLoader AdapterInformationLoader { get; set; }

        public DownloadAdaptersInfoService(
            IMemoryCache memoryCache,
            IDistributedCache distributedCache,
            IAdapterInformationLoader loader)
        {
            MemoryCache = memoryCache;
            DistributedCache = distributedCache;
            AdapterInformationLoader = loader;
        }

        private const string XML_EXTENSION = "xml";
        private const string XSD_EXTENSION = "xsd";
        private const string REQUEST = "Request";
        private const string RESPONSE = "Response";
        private const string COMMON = "Common";

        public Stream DownloadSamplesByAdapterName(string id)
        {
            var adapter = MemoryCache.AdaptersInfo(DistributedCache, AdapterInformationLoader).FirstOrDefault(a => a.Interface == id);

            var itemsToZip = new List<ZipItem>();
            foreach (var operation in adapter.Operations)
            {
                var requestToZip = new ZipItem(operation.FullName + REQUEST, operation.SampleRequestXML, XML_EXTENSION,
                    Encoding.UTF8);
                var responseToZip = new ZipItem(operation.FullName + RESPONSE, operation.SampleResponseXML,
                    XML_EXTENSION, Encoding.UTF8);

                itemsToZip.Add(requestToZip);
                itemsToZip.Add(responseToZip);
            }

            var result = Zipper.Zip(itemsToZip);
            return result;
        }

        public Stream DownloadXSDByAdapterName(string id)
        {
            var adapter = MemoryCache.AdaptersInfo(DistributedCache, AdapterInformationLoader).FirstOrDefault(a => a.Interface == id);
            var ds = Path.DirectorySeparatorChar;
            var itemsToZip = new List<ZipItem>();
            foreach (var operation in adapter.Operations)
            {
                if (operation.RequestXSD != null)
                {
                    var requestToZip = new ZipItem(operation.FullName + ds + operation.FullName + REQUEST, operation.RequestXSD, XSD_EXTENSION,
                        Encoding.UTF8);
                    itemsToZip.Add(requestToZip);
                }

                if (operation.ResponseXSD != null)
                {
                    var responseToZip = new ZipItem(operation.FullName + ds + operation.FullName + RESPONSE, operation.ResponseXSD, XSD_EXTENSION,
                        Encoding.UTF8);
                    itemsToZip.Add(responseToZip);
                }

                for (int i = 0; i < operation.CommonXSD.Length; i++)
                {
                    var commonToZip = new ZipItem(operation.FullName + ds + operation.CommonXSDNames[i].Replace(".xsd", ""), operation.CommonXSD[i], XSD_EXTENSION,
                        Encoding.UTF8);
                    itemsToZip.Add(commonToZip);
                }
            }

            var result = Zipper.Zip(itemsToZip);
            return result;
        }

        public Stream DownloadSamplesByOperationName(string id)
        {
            var lastDotIndex = id.LastIndexOf('.');
            var name = id.Substring(0, lastDotIndex); //TechnoLogica.RegiX.MVRBDSAdapter.APIService.IMVRBDSAPI
            var operationName = id.Substring(lastDotIndex + 1);

            var adapter = MemoryCache.AdaptersInfo(DistributedCache, AdapterInformationLoader).FirstOrDefault(a => a.Interface == name);
            var operation = adapter.Operations.FirstOrDefault(o => o.FullName == operationName);

            var requestToZip = new ZipItem(operation.FullName + REQUEST, operation.SampleRequestXML, XML_EXTENSION,
                Encoding.UTF8);
            var responseToZip = new ZipItem(operation.FullName + RESPONSE, operation.SampleResponseXML, XML_EXTENSION,
                Encoding.UTF8);
            var itemsToZip = new List<ZipItem>();
            itemsToZip.Add(requestToZip);
            itemsToZip.Add(responseToZip);

            var result = Zipper.Zip(itemsToZip);

            return result;
        }

        public Stream DownloadXSDByOperationName(string id)
        {
            var lastDotIndex = id.LastIndexOf('.');
            var name = id.Substring(0, lastDotIndex); //TechnoLogica.RegiX.MVRBDSAdapter.APIService.IMVRBDSAPI
            var operationName = id.Substring(lastDotIndex + 1);

            var adapter = MemoryCache.AdaptersInfo(DistributedCache, AdapterInformationLoader).FirstOrDefault(a => a.Interface == name);
            var operation = adapter.Operations.FirstOrDefault(o => o.FullName == operationName);

            var itemsToZip = new List<ZipItem>();

            if (operation.RequestXSD != null)
            {
                var requestToZip = new ZipItem(operation.FullName + REQUEST, operation.RequestXSD, XSD_EXTENSION,
                    Encoding.UTF8);
                itemsToZip.Add(requestToZip);
            }

            if (operation.ResponseXSD != null)
            {
                var responseToZip = new ZipItem(operation.FullName + RESPONSE, operation.ResponseXSD, XSD_EXTENSION,
                    Encoding.UTF8);
                itemsToZip.Add(responseToZip);
            }

            for(int i = 0; i < operation.CommonXSD.Length; i++)
            {
                var commonToZip = new ZipItem(operation.CommonXSDNames[i].Replace(".xsd",""), operation.CommonXSD[i], XSD_EXTENSION,
                    Encoding.UTF8);
                itemsToZip.Add(commonToZip);
            }

            var result = Zipper.Zip(itemsToZip);

            return result;
        }
    }
}