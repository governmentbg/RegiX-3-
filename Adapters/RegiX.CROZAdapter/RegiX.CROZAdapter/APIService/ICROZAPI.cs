using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Adapters.Common.Attributes;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;

namespace TechnoLogica.RegiX.CROZAdapter.APIService
{
    [ServiceContract]
    [XmlSerializerFormat]
    [Description("API на адаптер за комуникация с Централен регистър на особените залози ")]
    public interface ICROZAPI : IAPIService
    {
        //Намира участници по зададен идентификационен код или наименование

        [OperationContract]
        [Description("Справка за търсене на участници по зададен идентификационен код и наименование")]
        [Info(
            requestXSD: "ParticipantsRequest.xsd",
            responseXSD: "ParticipantsResponse.xsd",
            commonXSD: "CROZCommon.xsd",
            requestXSLT: "ParticipantsRequest.xslt",
            responseXSLT: "ParticipantsResponse.xslt")]
        ServiceResultDataSigned<ParticipantsSearchType, ParticipantsDataType> ParticipantsSearch(ServiceRequestData<ParticipantsSearchType> argument);


        // Извлича данни за вписванията по партида на определено лице

        [OperationContract]
        [Description("Справка за извличане на данни за вписванията по партида на определено лице")]
        [Info(
            requestXSD: "ConsignmentsRequest.xsd",
            responseXSD: "ConsignmentsResponse.xsd",
            commonXSD: "CROZCommon.xsd",
            requestXSLT: "ConsignmentsRequest.xslt",
            responseXSLT: "ConsignmentsResponse.xslt")]
        ServiceResultDataSigned<ConsignmentInfoSearchType, ConsignmentDataType> GetConsignmentInfo(ServiceRequestData<ConsignmentInfoSearchType> argument);


        // Извлича данни за вписванията във връзка с определена сделка, запор на имущество или решение на съда по несъстоятелност

        [OperationContract]
        [Description("Справка за извличане на данни за вписванията във връзка с определена сделка, запор на имущество или решение на съда по несъстоятелност")]
        [Info(
            requestXSD: "DealInfoRequest.xsd",
            responseXSD: "DealInfoResponse.xsd",
            commonXSD: "CROZCommon.xsd",
            requestXSLT: "DealInfoRequest.xslt",
            responseXSLT: "DealInfoResponse.xslt")]
        ServiceResultDataSigned<DealInfoSearchType, DealInfoDataType> GetDealInfo(ServiceRequestData<DealInfoSearchType> argument);
    }
}
