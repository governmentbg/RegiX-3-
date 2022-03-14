using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.AVTRAdapter.ActualStateV2;
using TechnoLogica.RegiX.AVTRAdapter.ActualStateV3;
using TechnoLogica.RegiX.AVTRAdapter.AdapterService;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;

namespace TechnoLogica.RegiX.AVTRAdapter.APIService
{
    [ExportFullName(typeof(ITRAPI), typeof(IAPIService))]
    [Export(typeof(IAPIService))]
    public class TRAPI : BaseAPIService<ITRAPI>, ITRAPI 
    {
        public ServiceResultDataSigned<ActualStateRequestType, ActualStateResponseType> GetActualState(ServiceRequestData<ActualStateRequestType> argument)
        {
            return AdapterClient.Execute<ITRAdapter, ActualStateRequestType, ActualStateResponseType>(
                        (i, r, a, o) => i.GetActualState(r, a, o),
                        argument);
        }

        public ServiceResultDataSigned<ActualStateRequestV2, ActualStateResponseV2> GetActualStateV2(ServiceRequestData<ActualStateRequestV2> argument)
        {
            return AdapterClient.Execute<ITRAdapter, ActualStateRequestV2, ActualStateResponseV2>(
                        (i, r, a, o) => i.GetActualStateV2(r, a, o),
                        argument);
        }

        public ServiceResultDataSigned<ActualStateRequestV3, ActualStateResponseV3> GetActualStateV3(ServiceRequestData<ActualStateRequestV3> argument)
        {
            return AdapterClient.Execute<ITRAdapter, ActualStateRequestV3, ActualStateResponseV3>(
                        (i, r, a, o) => i.GetActualStateV3(r, a, o),
                        argument);
        }

        public ServiceResultDataSigned<GetBranchOfficeRequest, GetBranchOfficeResponse> GetBranchOffice(ServiceRequestData<GetBranchOfficeRequest> argument)
        {
            return AdapterClient.Execute<ITRAdapter, GetBranchOfficeRequest, GetBranchOfficeResponse>(
                        (i, r, a, o) => i.GetBranchOffice(r, a, o),
                        argument);
        }

        public ServiceResultDataSigned<ValidUICRequestType, ValidUICResponseType> GetValidUICInfo(ServiceRequestData<ValidUICRequestType> argument)
        {
            return AdapterClient.Execute<ITRAdapter, ValidUICRequestType, ValidUICResponseType>(
                        (i, r, a, o) => i.GetValidUICInfo(r, a, o),
                        argument);
        }

        public ServiceResultDataSigned<SearchParticipationInCompaniesRequestType, SearchParticipationInCompaniesResponseType> PersonInCompaniesSearch(ServiceRequestData<SearchParticipationInCompaniesRequestType> argument)
        {
            return AdapterClient.Execute<ITRAdapter, SearchParticipationInCompaniesRequestType, SearchParticipationInCompaniesResponseType>(
                        (i, r, a, o) => i.PersonInCompaniesSearch(r, a, o),
                        argument);
        }
    }
}
