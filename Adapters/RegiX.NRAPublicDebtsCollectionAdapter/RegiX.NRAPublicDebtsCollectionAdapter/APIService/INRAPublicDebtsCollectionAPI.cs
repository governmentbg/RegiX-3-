using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Adapters.Common.Attributes;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;


namespace TechnoLogica.RegiX.NRAPublicDebtsCollectionAdapter.APIService
{
    [ServiceContract]
    [XmlSerializerFormat]
    [Description("?????????????????????Регистър на задължените лица?!!!!!!")]
    public interface INRAPublicDebtsCollectionAPI : IAPIService
    {
        //NRANoXslt.xslt
        //RQ01    
        [Info(requestXSD: "RQ01_SendDataForNewIOAndCollectionRequest.xsd",
            responseXSD: "RQ01_SendDataForNewIOAndCollectionResponse.xsd",
            requestXSLT: "NRANoXslt.xslt",
            responseXSLT: "NRANoXslt.xslt")]
        [OperationContract]
        [Description("Изпълнява услуга по Предаване на информация за ново изпълнително основание (ИО) и вземане/вземания за събиране от взискател/актосъставител към Национална агенция за приходите (НАП)")]
        ServiceResultDataSigned<SendDataForNewIOAndCollectionRequestType, SendDataForNewIOAndCollectionResponseType> SendDataForNewIOAndCollection(ServiceRequestData<SendDataForNewIOAndCollectionRequestType> argument);

        //RQ02   
        [Info(requestXSD: "RQ02_SendDataForCollectionAdditionToIORequest.xsd",
            responseXSD: "RQ02_SendDataForCollectionAdditionToIOResponse.xsd",
            requestXSLT: "NRANoXslt.xslt",
            responseXSLT: "NRANoXslt.xslt")]
        [OperationContract]
        [Description("Изпълнява услуга по Предаване на информация за добавяне на ново вземане/вземания за събиране към вече подадено изпълнително основание (ИО)")]
        ServiceResultDataSigned<SendDataForCollectionAdditionToIORequestType, SendDataForCollectionAdditionToIOResponseType> SendDataForCollectionAdditionToIO(ServiceRequestData<SendDataForCollectionAdditionToIORequestType> argument);

        //RQ03
        [Info(requestXSD: "RQ03_SendDataForCollectionDataCorrectionRequest.xsd",
            responseXSD: "RQ03_SendDataForCollectionDataCorrectionResponse.xsd",
            requestXSLT: "NRANoXslt.xslt",
            responseXSLT: "NRANoXslt.xslt")]
        [OperationContract]
        [Description("Изпълнява услуга по Предаване на информация за корекция на данни за вземане")]
        ServiceResultDataSigned<SendDataForCollectionDataCorrectionRequestType, SendDataForCollectionDataCorrectionResponseType> SendDataForCollectionDataCorrection(ServiceRequestData<SendDataForCollectionDataCorrectionRequestType> argument);

        //RQ04
        [Info(requestXSD: "RQ04_SendDataForCollectionAppealToIORequest.xsd",
            responseXSD: "RQ04_SendDataForCollectionAppealToIOResponse.xsd",
            requestXSLT: "NRANoXslt.xslt",
            responseXSLT: "NRANoXslt.xslt")]
        [OperationContract]
        [Description("Изпълнява услуга по Предаване на информация за обжалване на вземане към ИО при взискател/актосъставител")]
        ServiceResultDataSigned<SendDataForCollectionAppealToIORequestType, SendDataForCollectionAppealToIOResponseType> SendDataForCollectionAppealToIO(ServiceRequestData<SendDataForCollectionAppealToIORequestType> argument);

        //RQ05  
        [Info(requestXSD: "RQ05_SendDataForCollectedAmountUpdateRequest.xsd",
            responseXSD: "RQ05_SendDataForCollectedAmountUpdateResponse.xsd",
            requestXSLT: "NRANoXslt.xslt",
            responseXSLT: "NRANoXslt.xslt")]
        [OperationContract]
        [Description("Изпълнява услуга по Предаване на информация за отразяване на събрана сума по вземане при взискател/актосъставител")]
        ServiceResultDataSigned<SendDataForCollectedAmountUpdateRequestType, SendDataForCollectedAmountUpdateResponseType> SendDataForCollectedAmountUpdate(ServiceRequestData<SendDataForCollectedAmountUpdateRequestType> argument);

        //RQ06
        [Info(requestXSD: "RQ06_SendDataForCollectionProceedingsTerminationRequest.xsd",
            responseXSD: "RQ06_SendDataForCollectionProceedingsTerminationResponse.xsd",
            requestXSLT: "NRANoXslt.xslt",
            responseXSLT: "NRANoXslt.xslt")]
        [OperationContract]
        [Description("Изпълнява услуга по Предаване на информация за прекратяване на производство по събиране на вземане при взискател/актосъставител")]
        ServiceResultDataSigned<SendDataForCollectionProceedingsTerminationRequestType, SendDataForCollectionProceedingsTerminationResponseType> SendDataForCollectionProceedingsTermination(ServiceRequestData<SendDataForCollectionProceedingsTerminationRequestType> argument);

        //RQ09
        [Info(requestXSD: "RQ09_GetActualStateForIOOrCollectionRequest.xsd",
            responseXSD: "RQ09_GetActualStateForIOOrCollectionResponse.xsd",
            requestXSLT: "NRANoXslt.xslt",
            responseXSLT: "NRANoXslt.xslt")]
        [OperationContract]
        [Description("Изпълнява услуга по Получаване на информация за актуално състояние по изпълнително основание/вземане от НАП")]
        ServiceResultDataSigned<GetActualStateForIOOrCollectionRequestType, GetActualStateForIOOrCollectionResponseType> GetActualStateForIOOrCollection(ServiceRequestData<GetActualStateForIOOrCollectionRequestType> argument);

    }
}
