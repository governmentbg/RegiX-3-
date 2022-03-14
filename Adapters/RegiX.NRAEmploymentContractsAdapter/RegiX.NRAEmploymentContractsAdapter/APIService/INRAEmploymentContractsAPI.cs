using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Adapters.Common.Attributes;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;

namespace TechnoLogica.RegiX.NRAEmploymentContractsAdapter.APIService
{
    [ServiceContract]
    [XmlSerializerFormat]
    [Description("Регистър на уведомленията за сключване, изменение или прекратяване на трудовите договори и уведомления за промяна на работодател")]
    public interface INRAEmploymentContractsAPI : IAPIService
    {
        [OperationContract]
        [Description("Справка за сключване, изменение или прекратяване на трудовите договори и уведомления за промяна на работодател")]
        [Info(
            requestXSD: "EmploymentContractsRequest.xsd",
            responseXSD: "EmploymentContractsResponse.xsd",
            commonXSD: "EmploymentContractsCommon.xsd",
            requestXSLT: "EmploymentContractsRequest.xslt",
            responseXSLT: "EmploymentContractsResponse.xslt")]
        ServiceResultDataSigned<EmploymentContractsRequest, EmploymentContractsResponse> GetEmploymentContracts(ServiceRequestData<EmploymentContractsRequest> argument);
    }
}
