using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Adapters.Common.Attributes;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;

namespace TechnoLogica.RegiX.KzldAdministratorsAdapter.APIService
{
    [ServiceContract]
    [Description("Адаптер за комуникация с Комисия за защита на личните данни - Регистър на вписаните администратори на лични данни")]
    public interface IKzldAdministratorsAPI : IAPIService
    {
        [OperationContract]
        [Description("Справка по ЕИК/БУЛСТАТ/ЕГН за вписан администратор на лични данни")]
        [Info(
            requestXSD: "RegisteredAdministratorByIDRequest.xsd",
            responseXSD: "RegisteredAdministratorByIDResponse.xsd",
            commonXSD: "KZLDCommon.xsd",
            requestXSLT: "RegisteredAdministratorByIDRequest.xslt",
            responseXSLT: "RegisteredAdministratorByIDResponse.xslt")]
        ServiceResultDataSigned<RegisteredAdministratorByIDType, RegisteredAdministratorByIDResponse> GetRegisteredAdministratorByID(ServiceRequestData<RegisteredAdministratorByIDType> argument);

        [OperationContract]
        [Description("Справка по Уникален идентификационен номер за вписан администратор на лични данни")]
        [Info(
            requestXSD: "RegisteredAdministratorByNumberRequest.xsd",
            responseXSD: "RegisteredAdministratorByNumberResponse.xsd",
            commonXSD: "KZLDCommon.xsd",
            requestXSLT: "GetRegisteredAdministratorByNumberRequest.xslt",
            responseXSLT: "GetRegisteredAdministratorByNumberResponse.xslt")]
        ServiceResultDataSigned<RegisteredAdministratorByNumberType, RegisteredAdministratorByNumberResponse> GetRegisteredAdministratorByNumber(ServiceRequestData<RegisteredAdministratorByNumberType> argument);
    }
}

