using System.ComponentModel;
using TechnoLogica.RegiX.Common.ObjectMapping;
using System.ServiceModel;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common;

namespace TechnoLogica.RegiX.REZMAAdapter.AdapterService
{
    [ServiceContract]
    [Description("Адаптер за комуникация с Регистър Задължения към митническата администрация")]
    public interface IREZMAAdapter: IAdapterServiceWCF
    {
        [OperationContract]
        [Description("Справка за митнически задължения")]
        CommonSignedResponse<CustomsObligationsRequestType, CustomsObligationsResponseType> GetCustomsObligations(CustomsObligationsRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Справка за акцизни задължения")]
        CommonSignedResponse<ExciseObligationsRequestType, ExciseObligationsResponseType> GetExciseObligations(ExciseObligationsRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Справка за наличие/липса на задължения")]
        CommonSignedResponse<CheckObligationsRequestType, CheckObligationsResponseType> CheckObligations(CheckObligationsRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

    }
}

