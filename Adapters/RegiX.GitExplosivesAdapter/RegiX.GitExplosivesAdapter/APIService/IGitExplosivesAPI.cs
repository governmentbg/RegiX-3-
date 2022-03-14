using System.ServiceModel;
using System.ComponentModel;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.Adapters.Common.Attributes;

namespace TechnoLogica.RegiX.GitExplosivesAdapter.APIService
{
    [ServiceContract]
    [XmlSerializerFormat]
    [Description("API на Адаптер за комуникация с Изпълнителна агенция Главна инспекция по труда - Регистър на заверените свидетелства за работа с взривни материали")]
    public interface IGitExplosivesAPI : IAPIService
    {
        //Справка за автентичност на свидетелство за работа с взривни материали
        [OperationContract]
        [Description("Справка за автентичност на свидетелство за работа с взривни материали")]
        [Info(
            requestXSD: "AuthenticityExplosivesCertificateRequest.xsd",
            responseXSD: "ValidExplosivesCertificateResponse.xsd",
            commonXSD: "RVMCommon.xsd",
            requestXSLT: "AuthenticityExplosivesCertificateRequest.xslt",
            responseXSLT: "ValidExplosivesCertificateResponse.xslt"
            )]
        ServiceResultDataSigned<AuthenticityExplosivesRequestType, ValidExplosivesCertificateResponse> GetAuthenticityExplosivesCertificate(ServiceRequestData<AuthenticityExplosivesRequestType> argument);

        //Справка за валидни свидетелства за работа с взривни материали
        [OperationContract]
        [Description("Справка по ЕГН/ЛНЧ за валидни свидетелства за работа с взривни материали")]
        [Info(
            requestXSD: "ValidExplosivesCertificateRequest.xsd",
            responseXSD: "ValidExplosivesCertificateResponse.xsd",
            commonXSD: "RVMCommon.xsd",
            requestXSLT: "ValidExplosivesCertificateRequest.xslt",
            responseXSLT: "ValidExplosivesCertificateResponse.xslt"
            )]
        ServiceResultDataSigned<ValidExplosivesRequestType, ValidExplosivesCertificateResponse> GetValidExplosivesCertificate(ServiceRequestData<ValidExplosivesRequestType> argument);
    }
}
