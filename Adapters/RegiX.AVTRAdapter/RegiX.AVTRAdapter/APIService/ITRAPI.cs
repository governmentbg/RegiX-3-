using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Adapters.Common.Attributes;
using TechnoLogica.RegiX.AVTRAdapter.ActualStateV2;
using TechnoLogica.RegiX.AVTRAdapter.ActualStateV3;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;

namespace TechnoLogica.RegiX.AVTRAdapter.APIService
{
    [ServiceContract]
    [XmlSerializerFormat]
    [Description("API на адаптер за комуникация с Търговски регистър")]
    public interface ITRAPI : IAPIService
    {
        [OperationContract]
        [Description("Справка за актуално състояние(v1)")]
        [Info(
            requestXSD: "TR_ActualStateRequest.xsd",
            responseXSD: "TR_ActualStateResponse.xsd",
            commonXSD: "TRCommon.xsd",
            responseXSLT: "TR_ActualStateResponse.xslt",
            requestXSLT: "TR_ActualStateResponse.xslt")]
        ServiceResultDataSigned<ActualStateRequestType, ActualStateResponseType> GetActualState(ServiceRequestData<ActualStateRequestType> argument);

        [OperationContract]
        [Description("Справка за актуално състояние за всички вписани обстоятелства(v2)")]
        [Info(
            requestXSD: "TR_ActualStateRequestV2.xsd",
            responseXSD: "TR_ActualStateResponseV2.xsd",
            responseXSLT: "TR_ActualStateResponseV2.xslt",
            requestXSLT: "TR_ActualStateRequestV2.xslt")]
        ServiceResultDataSigned<ActualStateRequestV2, ActualStateResponseV2> GetActualStateV2(ServiceRequestData<ActualStateRequestV2> argument);

        [OperationContract]
        [Description("Справка за актуално състояние за всички вписани обстоятелства по раздели(v3)")]
        [Info(
            requestXSD: "TR_ActualStateRequestv3.xsd",
            responseXSD: "TR_ActualStateResponsev3.xsd",
            commonXSD: "TRSubdeedsCommon.xsd",
            sampleRequest: "ActualStateRequestV3.xml",
            sampleResponse: "ActualStateResponseV3.xml",
            responseXSLT: "TR_ActualStateResponseV3.xslt",
            requestXSLT: "TR_ActualStateRequestV3.xslt")]
        ServiceResultDataSigned<ActualStateRequestV3, ActualStateResponseV3> GetActualStateV3(ServiceRequestData<ActualStateRequestV3> argument);

        [OperationContract]
        [Description("Справка за актуално състояние на клон на търговско дружество")]
        [Info(
            requestXSD: "TR_GetBranchOfficeRequest.xsd",
            responseXSD: "TR_GetBranchOfficeResponse.xsd",
            commonXSD: "TRSubdeedsCommon.xsd",
            responseXSLT: "TR_GetBranchOfficeResponse.xslt",
            requestXSLT: "TR_GetBranchOfficeRequest.xslt")]
        ServiceResultDataSigned<GetBranchOfficeRequest, GetBranchOfficeResponse> GetBranchOffice(ServiceRequestData<GetBranchOfficeRequest> argument);

        [OperationContract]
        [Description("Справка за Валидност на ЕИК номер")]
        [Info(
            requestXSD: "TR_ValidUICRequest.xsd",
            responseXSD: "TR_ValidUICResponse.xsd",
            commonXSD: "TRCommon.xsd",
            responseXSLT: "TR_ValidUICResponse.xslt",
            requestXSLT: "TR_ValidUICRequest.xslt")]
        ServiceResultDataSigned<ValidUICRequestType, ValidUICResponseType> GetValidUICInfo(ServiceRequestData<ValidUICRequestType> argument);

        [OperationContract]
        [Description("Справка по физическо лице за участие в търговски дружества")]
        [Info(
            requestXSD: "TR_SearchParticipationInCompaniesRequest.xsd",
            responseXSD: "TR_SearchParticipationInCompaniesResponse.xsd",
            commonXSD: "TRCommon.xsd",
            responseXSLT: "TR_SearchParticipationInCompaniesResponse.xslt",
            requestXSLT: "TR_SearchParticipationInCompaniesRequest.xslt")]
        ServiceResultDataSigned<SearchParticipationInCompaniesRequestType, SearchParticipationInCompaniesResponseType> PersonInCompaniesSearch(ServiceRequestData<SearchParticipationInCompaniesRequestType> argument);

    }
}
