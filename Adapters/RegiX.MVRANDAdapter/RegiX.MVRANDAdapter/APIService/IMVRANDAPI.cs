using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Adapters.Common.Attributes;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;

namespace TechnoLogica.RegiX.MVRANDAdapter.APIService
{
    [ServiceContract]
    [XmlSerializerFormat]
    [Description("API на адаптер за комуникация с регистър АНД на МВР")]
    public interface IMVRANDAPI : IAPIService
    {
        
        [OperationContract]
        [Description("Справка за задълженията по конкретен документ, издаден от Пътна полиция")]
        [Info(requestXSD: "GetObligationDocumentsRequest.xsd",
            responseXSD: "GetObligationDocumentsResponse.xsd",
            commonXSD: "MVRANDCommon.xsd",
            requestXSLT: "GetObligationDocumentsRequest.xslt",
            responseXSLT: "GetObligationDocumentsResponse.xslt")]
        ServiceResultDataSigned<ObligationDocumentsRequestType, ObligationDocumentsResponseType> GetObligationDocuments(ServiceRequestData<ObligationDocumentsRequestType> argument);

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
        
        [OperationContract]
        [Description("Отразяване на онлайн плащане в АИС АНД")]
        [Info(requestXSD: "SendPaymentNotificationRequest.xsd",
            responseXSD: "SendPaymentNotificationResponse.xsd",
            commonXSD: "MVRANDCommon.xsd",
            requestXSLT: "SendPaymentNotificationRequest.xslt",
            responseXSLT: "SendPaymentNotificationResponse.xslt")]
        ServiceResultDataSigned<SendPaymentNotificationRequestType, SendPaymentNotificationResponseType> SendPaymentNotification(ServiceRequestData<SendPaymentNotificationRequestType> argument);

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        
        [OperationContract]
        [Description("Проверка за налични неплатени документи в АИС АНД на дадено лице")]
        [Info(requestXSD: "GetObligationDocumentsByEGNRequest.xsd",
            responseXSD: "GetObligationDocumentsByEGNResponse.xsd",
            commonXSD: "MVRANDCommon.xsd",
            requestXSLT: "GetObligationDocumentsByEGNRequest.xslt",
            responseXSLT: "GetObligationDocumentsByEGNResponse.xslt")]
        ServiceResultDataSigned<GetObligationDocumentsByEGNRequestType, GetObligationDocumentsByEGNResponseType> GetObligationDocumentsByEGN(ServiceRequestData<GetObligationDocumentsByEGNRequestType> argument);

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        
        [OperationContract]
        [Description("Проверка за налични неплатени документи в АИС АНД по номер на СУМПС и ЕГН")]
        [Info(requestXSD: "GetObligationDocumentsByLicenceNumRequest.xsd",
            responseXSD: "GetObligationDocumentsByLicenceNumResponse.xsd",
            commonXSD: "MVRANDCommon.xsd",
            requestXSLT: "GetObligationDocumentsByLicenceNumRequest.xslt",
            responseXSLT: "GetObligationDocumentsByLicenceNumResponse.xslt")]
        ServiceResultDataSigned<GetObligationDocumentsByLicenceNumRequestType, GetObligationDocumentsByLicenceNumResponseType> GetObligationDocumentsByLicenceNum(ServiceRequestData<GetObligationDocumentsByLicenceNumRequestType> argument);

    }
}
