using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;

namespace TechnoLogica.RegiX.ASPSocialAdapter.AdapterService
{
    [ServiceContract]
    [Description("Адаптер за комуникация с Агенция за социално подпомагане - Списък на издадени заповеди за отпускане на помощи и ползване на социални услуги")]
    public interface IASPSocialAdapter : IAdapterServiceWCF
    {
        [OperationContract]
        [Description("Справка по ЕГН/ЛНЧ за отпуснати помощи по чл. 9 от ППЗСП")]
        CommonSignedResponse<GetMonthlySocialBenefitsRequest, GetMonthlySocialBenefitsResponseType> GetMonthlySocialBenefits(GetMonthlySocialBenefitsRequest argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Справка по ЕГН/ЛНЧ за отпуснати помощи за отопление по Наредба РД-07-5")]
        CommonSignedResponse<GetBenefitsForHeatingRequest, GetBenefitsForHeatingResponseType> GetBenefitsForHeating(GetBenefitsForHeatingRequest argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Справка по ЕГН/ЛНЧ за издадени заповеди за ползване на социални услуги")]
        CommonSignedResponse<GetSocialServicesDecisionsRequest, GetSocialServicesDecisionsResponseType> GetSocialServicesDecisions(GetSocialServicesDecisionsRequest argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Списък на получаваните помощи и социални услуги за лице с увреждания")]
        CommonSignedResponse<PeopleWithDisabilitiesRequest, PeopleWithDisabilitiesResponseType> GetPersonWithDisabilitiesSocialBenefitsList(PeopleWithDisabilitiesRequest argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);
    }
}