using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Adapters.Common.Attributes;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.GraoCivilStatusActsAdapter.XMLSchemas;

namespace TechnoLogica.RegiX.GraoCivilStatusActsAdapter.APIService
{
    [ServiceContract]
    [Description("Регистър на съставените актове за гражданско състояние")]
    public interface IGraoCivilStatusActsAPI : IAPIService
    {
        [OperationContract]
        [Description("Справка за сключен граждански брак")]
        [Info(requestXSD: "MarriageCertificateRequest.xsd",
            responseXSD: "MarriageCertificateResponse.xsd",
            requestXSLT: "MarriageCertificateRequest.xslt",
            responseXSLT: "MarriageCertificateResponse.xslt")]
        ServiceResultDataSigned<MarriageCertificateRequestType, MarriageCertificateResponseType> GetMarriageCertificate(ServiceRequestData<MarriageCertificateRequestType> argument);

    }
}
