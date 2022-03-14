using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.CROZAdapter.AdapterService;

namespace TechnoLogica.RegiX.CROZAdapter.APIService
{
    [ExportFullName(typeof(ICROZAPI), typeof(IAPIService))]
    [Export(typeof(IAPIService))]
    public class CROZAPI: BaseAPIService<ICROZAPI>, ICROZAPI
    {
        public ServiceResultDataSigned<ParticipantsSearchType, ParticipantsDataType> ParticipantsSearch(ServiceRequestData<ParticipantsSearchType> argument)
        {
            return AdapterClient.Execute<ICROZAdapter, ParticipantsSearchType, ParticipantsDataType>(
                        (i, r, a, o) => i.ParticipantsSearch(r, a, o),
                        argument);
        }

        public ServiceResultDataSigned<ConsignmentInfoSearchType, ConsignmentDataType> GetConsignmentInfo(ServiceRequestData<ConsignmentInfoSearchType> argument)
        {
            return AdapterClient.Execute<ICROZAdapter, ConsignmentInfoSearchType, ConsignmentDataType>(
                        (i, r, a, o) => i.GetConsignmentInfo(r, a, o),
                        argument);
        }
        
        public ServiceResultDataSigned<DealInfoSearchType, DealInfoDataType> GetDealInfo(ServiceRequestData<DealInfoSearchType> argument)
        {
            return AdapterClient.Execute<ICROZAdapter, DealInfoSearchType, DealInfoDataType>(
                        (i, r, a, o) => i.GetDealInfo(r, a, o),
                        argument);
        }
    }
}
