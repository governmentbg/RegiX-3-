using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Adapters.Common.Attributes;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;

namespace TechnoLogica.RegiX.RDSOAdapter.APIService
{
    [ServiceContract]
    [XmlSerializerFormat]
    [Description("API на адаптер за комуникация с Регистър на дипломите за средно образование")]
    public interface IRDSOAPI : IAPIService
    {
        // Извлича данни за дипломите за средно образование на определено лице
        [OperationContract]
        [Description("Справка за диплома за средно образование на определено лице")]
        [Info(
            requestXSD: "DiplomaDocumentsRequest.xsd",
            responseXSD: "DiplomaDocumentsResponse.xsd",
            commonXSD: "RDSOCommonXSD.xsd",
            requestXSLT: "DiplomaDocumentsRequest.xslt",
            responseXSLT: "DiplomaDocumentsResponse.xslt")]
        ServiceResultDataSigned<DiplomaSearchType, DiplomaDocumentsType> GetDiplomaInfo(ServiceRequestData<DiplomaSearchType> argument);

        [OperationContract]
        [Description("Справка за вписани в регистъра заверки на образователни документи")]
        [Info(
            requestXSD: "CertifiedDocumentsRequest.xsd",
            responseXSD: "CertifiedDocumentsResponse.xsd",
            commonXSD: "RDSOCommonXSD.xsd",
            requestXSLT: "CertifiedDocumentsRequest.xslt",
            responseXSLT: "CertifiedDocumentsResponse.xslt")]
        ServiceResultDataSigned<CertifiedDocumentsSearchType, CertifiedDocumentsType> GetCertifiedDiplomaInfo(ServiceRequestData<CertifiedDocumentsSearchType> argument);
  }
}
