using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;

namespace TechnoLogica.RegiX.NoiRPAdapter.AdapterService
{
    [ServiceContract]
    [Description("Адаптер за комуникация с Регистър на пенсионерите")]
    public interface IRPAdapter : IAdapterServiceWCF
    {
        [OperationContract]
        [Description("Справка за наличието на упражнено право на пенсия за осигурителен стаж и възраст")]
        CommonSignedResponse<PensionRightRequestType, PensionRightResponseType> GetPensionRightInfoReport(PensionRightRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters);

        //old UP-7
        [OperationContract]
        [Description("Справка за размер и вид на пенсия и добавка")]
        CommonSignedResponse<UP7RequestType, UP7ResponseType> GetPensionTypeAndAmountReport(UP7RequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters);

        //NEW UP-7
        [OperationContract]
        [Description("Справка за размер и вид на пенсия и добавка (УП-7)")]
        CommonSignedResponse<UP7NewRequestType, UP7NewResponseType> GetPensionTypeAndAmountReportUP7(UP7NewRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters);

        [OperationContract]
        [Description("Справка за доход от пенсия и добавка (УП-8)")]
        CommonSignedResponse<UP8RequestType, UP8ResponseType> GetPensionIncomeAmountReport(UP8RequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters);
    }
}