//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Data;
//using TechnoLogica.RegiX.Common.Utils;
//using System.Diagnostics;
//using System.Threading.Tasks;
//using TechnoLogica.RegiX.Common;
//using TechnoLogica.RegiX.Common.ObjectMapping;
//using TechnoLogica.RegiX.Common.AdapterCore;
//using System.ComponentModel.Composition;
//using TechnoLogica.RegiX.Common.ServiceContracts;
//using TechnoLogica.RegiX.NpgsqlAdapterService;
//using TechnoLogica.RegiX.Common.TransportObject;
//using TechnoLogica.RegiX.Common.DataContracts;
//using System.IO;

//namespace TechnoLogica.RegiX.RTSAdapter.AdapterService
//{
//    public class RTSAdapter : NpgsqlAdapterService.NpgsqlBaseAdapterService, IRTSAdapter, IAdapterService
//    {
//        public override string CheckRegisterConnection()
//        {
//            return Constants.ConnectionOk;
//        }

//        public CommonSignedResponse<RoutesSearch, RoutesResponse> GetRoutesTimeTable(RoutesSearch routesSearch, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
//        {
//             Guid id = Guid.NewGuid();
//             DateTime executionStart = DateTime.Now;
//             LogData(aditionalParameters, new { Request = routesSearch.XmlSerialize(), Guid = id });
//             try
//             {
//                 RoutesResponse result = new RoutesResponse();
//                 string fileName = AppDomain.CurrentDomain.BaseDirectory + "\\XMLData\\" + routesSearch.ForwardFirstStopMunicipality.ToUpper() + routesSearch.BackwardFirstStopMunicipality.ToLower() + ".xml";

//                 if (File.Exists(fileName))
//                 {
//                     result = (RoutesResponse)FileUtils.ReadXml("\\XMLData\\" + routesSearch.ForwardFirstStopMunicipality.ToUpper() + routesSearch.BackwardFirstStopMunicipality.ToLower() + ".xml", typeof(RoutesResponse));
//                 }
//                 else
//                 {
//                     result = (RoutesResponse)FileUtils.ReadXml("\\XMLData\\default.xml", typeof(RoutesResponse));
//                 }
//                 result.GenerationTimeStamp = DateTime.Now;
//                 LogData(aditionalParameters, new { Result = "Success", ExecutionTime = (DateTime.Now - executionStart), Guid = id });
//                 return
//                        SigningUtils.CreateAndSign(
//                            routesSearch,
//                            result,
//                            accessMatrix,
//                            aditionalParameters
//                        );
//             }
//             catch (Exception ex)
//             {
//                 LogError(aditionalParameters, ex, new { Guid = id });
//                 throw ex;
//             }
//        }

  
//    }
//}
