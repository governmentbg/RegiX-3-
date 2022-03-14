using TechnoLogica.RegiX.Common.ObjectMapping;
using System.ServiceModel;
using TechnoLogica.RegiX.Common.DataContracts;
using System.ComponentModel;
using TechnoLogica.RegiX.Common;

namespace TechnoLogica.RegiX.NRAPublicDebtsCollectionAdapter.AdapterService
{
    [ServiceContract]
    [Description("Адаптер за събиране на публични вземания между информационните системи на взискателите/актосъставители и информационна система „Събиране“ в НАП")]
    public interface INRAPublicDebtsCollectionAdapter : IAdapterServiceWCF
    {
        [OperationContract]
        [Description("Предаване на информация за ново изпълнително основание (ИО) и вземане/вземания за събиране от взискател/актосъставител към Национална агенция за приходите (НАП)")]
        CommonSignedResponse<SendDataForNewIOAndCollectionRequestType, SendDataForNewIOAndCollectionResponseType> SendDataForNewIOAndCollection(SendDataForNewIOAndCollectionRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Предаване на информация за добавяне на ново вземане/вземания за събиране към вече подадено изпълнително основание (ИО)")]
        CommonSignedResponse<SendDataForCollectionAdditionToIORequestType, SendDataForCollectionAdditionToIOResponseType> SendDataForCollectionAdditionToIO(SendDataForCollectionAdditionToIORequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Предаване на информация за корекция на данни за вземане")]
        CommonSignedResponse<SendDataForCollectionDataCorrectionRequestType, SendDataForCollectionDataCorrectionResponseType> SendDataForCollectionDataCorrection(SendDataForCollectionDataCorrectionRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Предаване на информация за обжалване на вземане към ИО при взискател/актосъставител")]
        CommonSignedResponse<SendDataForCollectionAppealToIORequestType, SendDataForCollectionAppealToIOResponseType> SendDataForCollectionAppealToIO(SendDataForCollectionAppealToIORequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Предаване на информация за отразяване на събрана сума по вземане при взискател/актосъставител")]
        CommonSignedResponse<SendDataForCollectedAmountUpdateRequestType, SendDataForCollectedAmountUpdateResponseType> SendDataForCollectedAmountUpdate(SendDataForCollectedAmountUpdateRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Предаване на информация за прекратяване на производство по събиране на вземане при взискател/актосъставител")]
        CommonSignedResponse<SendDataForCollectionProceedingsTerminationRequestType, SendDataForCollectionProceedingsTerminationResponseType> SendDataForCollectionProceedingsTermination(SendDataForCollectionProceedingsTerminationRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Получаване на информация за актуално състояние по изпълнително основание/вземане от НАП")]
        CommonSignedResponse<GetActualStateForIOOrCollectionRequestType, GetActualStateForIOOrCollectionResponseType> GetActualStateForIOOrCollection(GetActualStateForIOOrCollectionRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);
    }
}
