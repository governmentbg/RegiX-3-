using System.ServiceModel;
using System.ComponentModel;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Adapters.Common.Attributes;

namespace TechnoLogica.RegiX.KzldExemptAdministratorsAdapter.APIService
{
    [ServiceContract]
    [XmlSerializerFormat]
    [Description("API на Адаптер за комуникация с Комисия за защита на личните данни - Регистър на освободените от регистрация администратори на лични данни")]
    public interface IKzldExemptAdministratorsAPI : IAPIService
    {
        [OperationContract]
        [Description("Справка по ЕИК/БУЛСТАТ/ЕГН/ЛНЧ за освободен от регистрация администратор на лични данни")]
        [Info(
            requestXSD: "ExemptRegistrationAdministratorRequest.xsd", 
            responseXSD: "ExemptRegistrationAdministratorResponse.xsd", 
            commonXSD: "KZLDCommon.xsd",
            requestXSLT: "ExemptRegistrationAdministratorRequest.xslt",
            responseXSLT: "ExemptRegistrationAdministratorResponse.xslt")]
        ServiceResultDataSigned<ExemptRegistrationRequestType, ExemptRegistrationAdministratorResponse> GetExemptRegistrationAdministrator(ServiceRequestData<ExemptRegistrationRequestType> argument);
    }
}
