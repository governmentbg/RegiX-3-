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
//    public class RegiXService : IRegiXService
//    {
         

//        public ServiceResultData CheckResult(ServiceCheckResultArgument argument)
//        {
//            throw new NotImplementedException();
//        }

//        public ServiceResultData ExecuteSynchronous(ServiceRequestData request)
//        {
//            ServiceResultData result = new ServiceResultData();
//            try
//            {
//                PastureMeadowLandRequestType adapterRequest = (PastureMeadowLandRequestType)request.Argument.Deserialize(typeof(PastureMeadowLandRequestType));
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
//                    var adapterResult = adapter.GetPastureMeadowLand(adapterRequest, AccessMatrix.CreateForType(typeof(PastureMeadowLandResponse)), additionalParameters);

//                    result.HasError = false;
//                    XmlDocument doc = new XmlDocument();
//                    doc.LoadXml(adapterResult.XmlSerialize());
//                    result.Result = doc.DocumentElement;
//                }
//            }
//            catch (Exception ex)
//            {
//                result.HasError = true;
//                result.Error = ex.Message;
//                if (ex.InnerException != null)
//                {
//                    result.Error += ex.InnerException.Message;
//                    if (ex.InnerException.InnerException != null)
//                    {
//                        result.Error += ex.InnerException.InnerException.Message;
//                        if (ex.InnerException.InnerException.InnerException != null)
//                        {
//                            result.Error += ex.InnerException.InnerException.InnerException.Message;
//                        }
//                    }
//                }
//            }
//            return result;
//        }

//    }
//}
