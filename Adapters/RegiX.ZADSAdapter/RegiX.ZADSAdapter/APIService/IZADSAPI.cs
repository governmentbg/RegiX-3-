using System.ServiceModel;
using System.ComponentModel;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Adapters.Common.Attributes;

namespace TechnoLogica.RegiX.ZADSAdapter.APIService
{
    [ServiceContract]
    [XmlSerializerFormat]
    [Description("API на адаптер за комуникация с регистъра за вписани лица по ЗАДС")]
    public interface IZADSAPI : IAPIService
    {
        [OperationContract]
        [Description("Справка за статут на лице по ЗАДС")]
        [Info(requestXSD: "RegistrationInfoRequest.xsd",
              responseXSD: "RegistrationInfoResponse.xsd",
              requestXSLT: "RegistrationInfoRequest.xslt",
              responseXSLT: "RegistrationInfoResponse.xslt")]
        ServiceResultDataSigned<RegistrationInfoRequestType, RegistrationInfoResponseType> GetRegistrationInfo(ServiceRequestData<RegistrationInfoRequestType> argument);
    }
}
