using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Adapters.Common.Attributes;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.CPCProcurementDossierAdapter;

namespace RegiX.CPCProcurementDossierAdapter.APIService
{
    [ServiceContract]
    [XmlSerializerFormat]
    [Description("API на адаптер за комуникация с Регистър на жалби по ЗОП")]
    public interface ICPCProcurementDossierAPI : IAPIService
    {
        [OperationContract]
        [Description("Справка за жалби по ЗОП")]
        [Info(requestXSD: "GetProcurementDossierRequest.xsd",
            responseXSD: "GetProcurementDossierResponse.xsd",
            requestXSLT: "GetProcurementDossierRequest.xslt",
            responseXSLT: "GetProcurementDossierResponse.xslt")]
        ServiceResultDataSigned<GetProcurementDossierRequest, GetProcurementDossierResponse> GetProcurementDossier(ServiceRequestData<GetProcurementDossierRequest> argument);

    }
}
