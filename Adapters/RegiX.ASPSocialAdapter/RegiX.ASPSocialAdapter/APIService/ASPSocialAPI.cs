using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.ASPSocialAdapter.AdapterService;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;

namespace TechnoLogica.RegiX.ASPSocialAdapter.APIService
{
    [ExportFullName(typeof(IASPSocialAPI), typeof(IAPIService))]
    [Export(typeof(IAPIService))]
    public class ASPSocialAPI : BaseAPIService<IASPSocialAPI>, IASPSocialAPI
    {
        public ServiceResultDataSigned<GetMonthlySocialBenefitsRequest, GetMonthlySocialBenefitsResponseType> GetMonthlySocialBenefits(ServiceRequestData<GetMonthlySocialBenefitsRequest> argument)
        {
            return AdapterClient.Execute<IASPSocialAdapter, GetMonthlySocialBenefitsRequest, GetMonthlySocialBenefitsResponseType>(
                (i, r, a, o) => i.GetMonthlySocialBenefits(r, a, o),
                 argument);
        }
        
        public ServiceResultDataSigned<GetBenefitsForHeatingRequest, GetBenefitsForHeatingResponseType> GetBenefitsForHeating(ServiceRequestData<GetBenefitsForHeatingRequest> argument)
        {
            return AdapterClient.Execute<IASPSocialAdapter, GetBenefitsForHeatingRequest, GetBenefitsForHeatingResponseType>(
                (i, r, a, o) => i.GetBenefitsForHeating(r, a, o),
                 argument);
        }
        
        public ServiceResultDataSigned<GetSocialServicesDecisionsRequest, GetSocialServicesDecisionsResponseType> GetSocialServicesDecisions(ServiceRequestData<GetSocialServicesDecisionsRequest> argument)
        {
            return AdapterClient.Execute<IASPSocialAdapter, GetSocialServicesDecisionsRequest, GetSocialServicesDecisionsResponseType>(
                (i, r, a, o) => i.GetSocialServicesDecisions(r, a, o),
                 argument);
        }
        
        public ServiceResultDataSigned<PeopleWithDisabilitiesRequest, PeopleWithDisabilitiesResponseType> GetPersonWithDisabilitiesSocialBenefitsList(ServiceRequestData<PeopleWithDisabilitiesRequest> argument)
        {
            return AdapterClient.Execute<IASPSocialAdapter, PeopleWithDisabilitiesRequest, PeopleWithDisabilitiesResponseType>(
                (i, r, a, o) => i.GetPersonWithDisabilitiesSocialBenefitsList(r, a, o),
                 argument);
        }

        public override string GetMetaDataXML(string operationName)
        {
            if (operationName == "GetPersonWithDisabilitiesSocialBenefitsList")
            {
                return "---";
            }
            return base.GetMetaDataXML(operationName);
        }
    }
}