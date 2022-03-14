using System.ServiceModel;
using System.ComponentModel;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Adapters.Common.Attributes;

namespace TechnoLogica.RegiX.KzldDeniedAdministratorsAdapter.APIService
{
    [ServiceContract]
    [XmlSerializerFormat]
    [Description("API на Адаптер за комуникация с Комисия за защита на личните данни - Регистър на администратори на лични данни с отказана регистрация ")]
    public interface IKzldDeniedAdministratorsAPI : IAPIService
    {
        [OperationContract]
        [Description("Справка по ЕИК/БУЛСТАТ/ЕГН/ЛНЧ за администратор на лични данни с отказана регистрация")]
        [Info(
            requestXSD: "DeniedEntryAdministratorRequest.xsd",
            responseXSD: "DeniedEntryAdministratorResponse.xsd",
            commonXSD: "KZLDCommon.xsd",
            requestXSLT: "DeniedEntryAdministratorRequest.xslt",
            responseXSLT: "DeniedEntryAdministratorResponse.xslt")]
        ServiceResultDataSigned<DeniedEntryAdministratorRequestType, DeniedEntryAdministratorResponse> GetRegisteredAdministratorByID(ServiceRequestData<DeniedEntryAdministratorRequestType> argument);
    }
}
