using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;

namespace TechnoLogica.RegiX.KzldAdministratorsAdapter.AdapterService
{
    [ServiceContract]
    [Description("Адаптер за комуникация с Комисия за защита на личните данни - Регистър на вписаните администратори на лични данни")]
    public interface IKzldAdministratorsAdapter : IAdapterServiceWCF
    {
        [OperationContract]
        [Description("Справка по ЕИК/БУЛСТАТ/ЕГН за вписан администратор на лични данни")]
        CommonSignedResponse<RegisteredAdministratorByIDType, RegisteredAdministratorByIDResponse> GetRegisteredAdministratorByID(RegisteredAdministratorByIDType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Справка по Уникален идентификационен номер за вписан администратор на лични данни")]
        CommonSignedResponse<RegisteredAdministratorByNumberType, RegisteredAdministratorByNumberResponse> GetRegisteredAdministratorByNumber(RegisteredAdministratorByNumberType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);
    }
}

