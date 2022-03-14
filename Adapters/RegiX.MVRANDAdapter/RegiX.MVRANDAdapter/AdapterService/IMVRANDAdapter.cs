using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;


namespace TechnoLogica.RegiX.MVRANDAdapter.AdapterService
{
    [ServiceContract]
    [Description("Aдаптер за връзка с регистър АНД на МВР")]
    public interface IMVRANDAdapter: IAdapterServiceWCF
    {
        [OperationContract]
        [Description("Справка за задълженията по конкретен документ, издаден от Пътна полиция")]
        CommonSignedResponse<ObligationDocumentsRequestType, ObligationDocumentsResponseType> GetObligationDocuments(ObligationDocumentsRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters);

        [OperationContract]
        [Description("Отразяване на онлайн плащане в АИС АНД")]
        CommonSignedResponse<SendPaymentNotificationRequestType, SendPaymentNotificationResponseType> SendPaymentNotification(SendPaymentNotificationRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters);

        [OperationContract]
        [Description("Проверка за налични неплатени документи в АИС АНД на дадено лице")]
        CommonSignedResponse<GetObligationDocumentsByEGNRequestType, GetObligationDocumentsByEGNResponseType> GetObligationDocumentsByEGN(GetObligationDocumentsByEGNRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters);

        [OperationContract]
        [Description("Проверка за налични неплатени документи в АИС АНД по номер на СУМПС и ЕГН")]
        CommonSignedResponse<GetObligationDocumentsByLicenceNumRequestType, GetObligationDocumentsByLicenceNumResponseType> GetObligationDocumentsByLicenceNum(GetObligationDocumentsByLicenceNumRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters);
    }
}
