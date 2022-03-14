using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Adapters.Common.Attributes;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;


namespace TechnoLogica.RegiX.MFANotariesAdapter.APIService
{
    [ServiceContract]
    [XmlSerializerFormat]
    [Description("API на адаптер за комуникация с Автоматизирана Информационна Система на МВнР")]
    public interface IMFANotariesAPI : IAPIService
    {
        [OperationContract]
        [Description("Удостоверяване на заверки")]
        [Info(
            requestXSD: "SendNotaryDocumentsRequest.xsd",
            responseXSD: "SendNotaryDocumentsResponse.xsd",
            requestXSLT: "SendNotaryDocumentsRеquest.xslt",
            responseXSLT: "SendNotaryDocumentsResponse.xslt")]
        ServiceResultDataSigned<SendNotaryDocumentsRequest, SendNotaryDocumentsResponse> SendNotaryDocuments(ServiceRequestData<SendNotaryDocumentsRequest> argument);
    }
}
