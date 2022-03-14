using System.ServiceModel;
using System.ComponentModel;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.Adapters.Common.Attributes;

namespace TechnoLogica.RegiX.GitActualDeclarationAdapter.APIService
{
    [ServiceContract]
    [XmlSerializerFormat]
    [Description("API на Адаптер за комуникация с Изпълнителна агенция Главна инспекция по труда - Публичен регистър на годишните декларации по чл. 15 от ЗЗБУТ")]
    public interface IGitActualDeclarationAPI : IAPIService
    {        
        [OperationContract]
        [Description("Справка по ЕГН/ЕИК за актуална декларация")]
        [Info(
            requestXSD: "ActualDeclarationRequest.xsd",
            responseXSD: "ActualDeclarationResponse.xsd",
            requestXSLT: "ActualDeclarationRequest.xslt",
            responseXSLT: "ActualDeclarationResponse.xslt")]
        ServiceResultDataSigned <AuthenticityExplosivesRequestType, RZZBUTDeclaration> GetActualDeclaration(ServiceRequestData<AuthenticityExplosivesRequestType> argument);
    }
}
