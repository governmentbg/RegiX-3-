using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.Common.Utils;

using System.Net.Http;
using System;
using Infosys.RegiX.CRCAdapter.CRC;
using Newtonsoft.Json;
using System.Collections.Generic;
using TechnoLogica.RegiX.Adapters.Common.ObjectMapping;
using TechnoLogica.RegiX.Common.DataContracts.Parameter;
using TechnoLogica.RegiX.Adapters.Common.DataContracts;
using System.Globalization;

namespace Infosys.RegiX.CRCAdapter.AdapterService
{
    [Export(typeof(IAdapterService))]
    [ExportFullName(typeof(CRCAdapter), typeof(IAdapterService))]
    [ExportSimpleName(typeof(CRCAdapter), typeof(IAdapterService))]
    public class CRCAdapter  : BaseAdapterService, ICRCAdapter
    {
        private static readonly HttpClient client = new HttpClient();

        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(CRCAdapter), typeof(ParameterInfo))]        
        public static ParameterInfo<string> crcApiURL =
                   new ParameterInfo<string>("https://test-rmbt.infosys.bg/crc-admin-ws/regix")
                   {
                       Key = "crcApiURL",
                       Description = "CRC API URL",
                       OwnerAssembly = typeof(CRCAdapter).Assembly
                   };

        public CommonSignedResponse<CRCFindAllRequestType, CRCFindAllResponseType> FindAllMeasurements(CRCFindAllRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            string response = GetDataAsync(argument);
            List<CRCResponse> responseObj = new List<CRCResponse>();
            if (response != null)
            {
                responseObj = JsonConvert.DeserializeObject<List<CRCResponse>>(response);
            }

            CRCFindAllResponseType result = new CRCFindAllResponseType();
            var mapper = BuildMapper(accessMatrix);
            mapper.Map(responseObj, result);

            return SigningUtils.CreateAndSign(argument, result, accessMatrix, aditionalParameters);
        }

        private string GetDataAsync(CRCFindAllRequestType argument)
        {
            string from = argument.DateFrom.ToString("yyyy-MM-dd");
            string to = argument.DateTo.ToString("yyyy-MM-dd");

            UriBuilder builder = new UriBuilder(crcApiURL.Value);
            //UriBuilder builder = new UriBuilder("https://test-rmbt.infosys.bg/crc-admin-ws/regix");
            builder.Query = "from=" + from + "&to=" + to;

            HttpResponseMessage response = client.GetAsync(builder.Uri).Result;
            try
            {
                response.EnsureSuccessStatusCode();
                return response.Content.ReadAsStringAsync().Result;
            }
            catch (HttpRequestException)
            {
                return null;
            }          
        }

        protected ObjectMapper<List<CRCResponse>, CRCFindAllResponseType> BuildMapper(AccessMatrix accessMatrix)
        {
            var objectMapper = new ObjectMapper<List<CRCResponse>, CRCFindAllResponseType>(accessMatrix);
            objectMapper.AddCollectionMap<List<CRCResponse>>((o) => o.Measurement, c => c.ToArray());
            objectMapper.AddPropertyMap((o) => o.Measurement[0].BlockedPorts, (c) => c[0].blockedPorts);
            objectMapper.AddPropertyMap((o) => o.Measurement[0].City, (c) => c[0].city);
            objectMapper.AddPropertyMap((o) => o.Measurement[0].ClientUuid, (c) => c[0].clientUuid);
            objectMapper.AddPropertyMap((o) => o.Measurement[0].Code, (c) => c[0].code);
            objectMapper.AddPropertyMap((o) => o.Measurement[0].GeoLocation, (c) => c[0].geoLocation);
            objectMapper.AddPropertyMap((o) => o.Measurement[0].Hostname, (c) => c[0].hostname);
            objectMapper.AddPropertyMap((o) => o.Measurement[0].IP, (c) => c[0].ip);
            objectMapper.AddPropertyMap((o) => o.Measurement[0].LoopModeLoopUid, (c) => c[0].loopModeLoopUid);
            objectMapper.AddPropertyMap((o) => o.Measurement[0].LoopModeUid, (c) => c[0].loopModeUid);
            objectMapper.AddPropertyMap((o) => o.Measurement[0].Model, (c) => c[0].model);
            objectMapper.AddPropertyMap((o) => o.Measurement[0].ModelVersion, (c) => c[0].modelVersion);
            objectMapper.AddPropertyMap((o) => o.Measurement[0].NetworkType, (c) => c[0].networkType);
            objectMapper.AddPropertyMap((o) => o.Measurement[0].NetworkTypeGroup, (c) => c[0].networkTypeGroup);
            objectMapper.AddPropertyMap((o) => o.Measurement[0].OpenTestUuid, (c) => c[0].openTestUuid);
            objectMapper.AddPropertyMap((o) => o.Measurement[0].PacketLoss, (c) => c[0].packetLoss);
            objectMapper.AddPropertyMap((o) => o.Measurement[0].Ping, (c) => c[0].ping);
            objectMapper.AddPropertyMap((o) => o.Measurement[0].Platform, (c) => c[0].platform);
            objectMapper.AddPropertyMap((o) => o.Measurement[0].Provider, (c) => c[0].provider);
            objectMapper.AddPropertyMap((o) => o.Measurement[0].Region, (c) => c[0].region);
            objectMapper.AddPropertyMap((o) => o.Measurement[0].SignalStrength, (c) => c[0].signalStrength);
            objectMapper.AddPropertyMap((o) => o.Measurement[0].SpeedDownload, (c) => c[0].speedDownload);
            objectMapper.AddPropertyMap((o) => o.Measurement[0].SpeedUpload, (c) => c[0].speedUpload);
            objectMapper.AddPropertyMap((o) => o.Measurement[0].Status, (c) => c[0].status);
            objectMapper.AddPropertyMap((o) => o.Measurement[0].TestDuration, (c) => c[0].testDuration);
            objectMapper.AddPropertyMap((o) => o.Measurement[0].TestUuid, (c) => c[0].testUuid);
            objectMapper.AddPropertyMap((o) => o.Measurement[0].IMEI, (c) => c[0].imei);
            objectMapper.AddFunctionMap<CRCResponse, DateTime>((o) => o.Measurement[0].Time, (c) => DateTime.ParseExact(c.time, "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture));
            objectMapper.AddPropertyMap((o) => o.Measurement[0].UID, (c) => c[0].uid);
            return objectMapper;
        }
    }
}
