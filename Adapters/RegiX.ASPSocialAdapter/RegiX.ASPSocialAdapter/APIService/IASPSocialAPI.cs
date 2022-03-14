using System.ServiceModel;
using System.ComponentModel;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.Adapters.Common.Attributes;

namespace TechnoLogica.RegiX.ASPSocialAdapter.APIService
{
    [ServiceContract]
    [XmlSerializerFormat]
    [Description("API на Адаптер за комуникация с Агенция за социално подпомагане")]
    public interface IASPSocialAPI : IAPIService
    {
        [OperationContract]
        [Description("Справка по ЕГН/ЛНЧ за отпуснати помощи по чл. 9 от ППЗСП")]
        [Info(
            requestXSD: "GetMonthlySocialBenefitsRequest.xsd",
            responseXSD: "GetMonthlySocialBenefitsResponse.xsd",
            commonXSD: "ASPCommon.xsd",
            requestXSLT: "GetMonthlySocialBenefitsRequest.xslt",
            responseXSLT: "GetMonthlySocialBenefitsResponse.xslt")]
        ServiceResultDataSigned <GetMonthlySocialBenefitsRequest, GetMonthlySocialBenefitsResponseType> GetMonthlySocialBenefits(ServiceRequestData<GetMonthlySocialBenefitsRequest> argument);

        [OperationContract]
        [Description("Справка по ЕГН/ЛНЧ за отпуснати помощи за отопление по Наредба РД-07-5")]
        [Info(
            requestXSD: "GetBenefitsForHeatingRequest.xsd",
            responseXSD: "GetBenefitsForHeatingResponse.xsd",
            commonXSD: "ASPCommon.xsd",
            requestXSLT: "GetBenefitsForHeatingRequest.xslt",
            responseXSLT: "GetBenefitsForHeatingResponse.xslt")
        ]
        ServiceResultDataSigned<GetBenefitsForHeatingRequest, GetBenefitsForHeatingResponseType> GetBenefitsForHeating(ServiceRequestData<GetBenefitsForHeatingRequest> argument);

        [OperationContract]
        [Description("Справка по ЕГН/ЛНЧ за издадени заповеди за ползване на социални услуги")]
        [Info(requestXSD: "GetSocialServicesDecisionsRequest.xsd",
            responseXSD: "GetSocialServicesDecisionsResponse.xsd",
            commonXSD: "ASPCommon.xsd",
            requestXSLT: "GetSocialServicesDecisionsRequest.xslt",
            responseXSLT: "GetSocialServicesDecisionsResponse.xslt")]
        ServiceResultDataSigned<GetSocialServicesDecisionsRequest, GetSocialServicesDecisionsResponseType> GetSocialServicesDecisions(ServiceRequestData<GetSocialServicesDecisionsRequest> argument);

        [OperationContract]
        [Description("Списък на получаваните помощи и социални услуги за лице с увреждания")]
        [Info(requestXSD: "PeopleWithDisabilitiesRequest.xsd", 
            responseXSD: "PeopleWithDisabilitiesResponse.xsd", 
            commonXSD: "ASPCommon.xsd",
            requestXSLT: "PeopleWithDisabilitiesRequest.xslt",
            responseXSLT: "PeopleWithDisabilitiesResponse.xslt")]
        ServiceResultDataSigned<PeopleWithDisabilitiesRequest, PeopleWithDisabilitiesResponseType> GetPersonWithDisabilitiesSocialBenefitsList(ServiceRequestData<PeopleWithDisabilitiesRequest> argument);
    }
}