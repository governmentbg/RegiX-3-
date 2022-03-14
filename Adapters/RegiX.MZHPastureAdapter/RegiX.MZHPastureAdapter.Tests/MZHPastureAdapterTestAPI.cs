//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using NUnit.Framework;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.ServiceModel;
//using System.Text;
//using System.Threading.Tasks;
//using System.Xml;
//using TechnoLogica.RegiX.Common.ObjectMapping;
//using TechnoLogica.RegiX.Common.ServiceContracts;
//using TechnoLogica.RegiX.Common.TransportObject;
//using TechnoLogica.RegiX.MZHPastureAdapter;
//using TechnoLogica.RegiX.MZHPastureAdapter.AdapterService;
//using TechnoLogica.RegiX.MZHPastureAdapter.APIService;
//using TechnoLogica.RegiX.Common.Utils;
//using TechnoLogica.RegiX.Common.DataContracts;

//namespace RegiX.MZHPastureAdapterTests
//{
//    public class MZHPastureAdapterTestAPI : BaseAPIService, IMZHPastureAPI
//    {
//        ServiceResultDataSigned<PastureMeadowLandRequestType, PastureMeadowLandResponse> IMZHPastureAPI.GetPastureMeadowLandCheckResult(ServiceCheckResultArgument argument)
//        {
//            throw new NotImplementedException();
//        }

//        ServiceResultDataSigned<PastureMeadowLandRequestType, PastureMeadowLandResponse> IMZHPastureAPI.GetPastureMeadowLand(ServiceRequestData<PastureMeadowLandRequestType> argument)
//        {
//            ServiceResultDataSigned<PastureMeadowLandRequestType, PastureMeadowLandResponse> result = new ServiceResultDataSigned<PastureMeadowLandRequestType, PastureMeadowLandResponse>();
//            try
//            {
//                // IMZHPastureAdapterService adapter = new MZHPastureAdapterService();
//                using (ChannelFactory<IMZHPastureAdapterService> channelFactory = new ChannelFactory<IMZHPastureAdapterService>("IMZHPastureAdapterService"))
//                {
//                    var adapter = channelFactory.CreateChannel();
//                    AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
//                    additionalParameters.CallContext = new CallContext();// "\"LawReason\":\"Тестване на RegiX\",\"ServiceURI\":\"123456789\",\”ServiceType\”:\”За проверовъчна дейност\”\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"Министерство на земеделието и храните\",\” UserAdministrationID\”:\”10.20.503.4\”,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";
//                    additionalParameters.CitizenEGN = "8888888888";
//                    additionalParameters.ClientIPAddress = "111.111.111.111";
//                    additionalParameters.ConsumerCertificateThumbprint = "###";
//                    additionalParameters.EIDToken = "token123";
//                    additionalParameters.EmployeeEGN = "11111111111111";
//                    additionalParameters.OrganizationEIK = "12121212121";
//                    additionalParameters.OrganizationUnit = "qqqqqq";
//                    var adapterResult = adapter.GetPastureMeadowLand(argument.Argument, AccessMatrix.CreateForType(typeof(PastureMeadowLandResponse)), additionalParameters);
//                    result.HasError = false;
//                    result.Request = adapterResult.Data.Request;
//                    result.Result = adapterResult.Data.Response;
//                    result.Matrix = adapterResult.Data.Matrix;
//                }
//            }
//            catch (Exception ex)
//            {
//                result.HasError = false;
//                result.Error = ex.Message;
//            }
//            return result;
//        }

         


         

         

//        public ServiceResultDataSigned<PastureMeadowLandDetailRequestType, PastureMeadowLandDetailResponse> GetPastureMeadowLandDetail(ServiceRequestData<PastureMeadowLandDetailRequestType> argument)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
