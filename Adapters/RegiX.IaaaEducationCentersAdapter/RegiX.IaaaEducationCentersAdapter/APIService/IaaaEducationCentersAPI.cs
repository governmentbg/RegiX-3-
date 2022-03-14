using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.IaaaEducationCentersAdapter.AdapterService;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.Adapters.Common;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using System.ComponentModel.Composition;

namespace TechnoLogica.RegiX.IaaaEducationCentersAdapter.APIService
{
    [ExportFullName(typeof(IIaaaEducationCentersAPI), typeof(IAPIService))]
    [Export(typeof(IAPIService))]
    public class IaaaEducationCentersAPI : BaseAPIService<IIaaaEducationCentersAPI>, IIaaaEducationCentersAPI
    {
        public ServiceResultDataSigned<PermitsRequestType, PermitResponse> GetReport1Permit(ServiceRequestData<PermitsRequestType> argument)
        {
            return  AdapterClient.Execute<IIaaaEducationCentersAdapter, PermitsRequestType, PermitResponse>(
                (i, r, a, o) => i.GetReport1Permit(r, a, o),
                 argument);
        }
        public ServiceResultDataSigned<PermitsRequestType, PermitInstructorsResponse> GetReport2PermitInstructors(ServiceRequestData<PermitsRequestType> argument)
        {
            return AdapterClient.Execute<IIaaaEducationCentersAdapter, PermitsRequestType, PermitInstructorsResponse>(
                (i, r, a, o) => i.GetReport2PermitInstructors(r, a, o),
                 argument);
        }
        public ServiceResultDataSigned<PermitsRequestType, PermitVehiclesResponse> GetReport3PermitVehicles(ServiceRequestData<PermitsRequestType> argument)
        {
            return AdapterClient.Execute<IIaaaEducationCentersAdapter, PermitsRequestType, PermitVehiclesResponse>(
                (i, r, a, o) => i.GetReport3PermitVehicles(r, a, o),
                 argument);
        }
        public ServiceResultDataSigned<PermitsInstructorsRequestType, PermitsInstructorsResponse> GetReport4InstructorPermitsDetails(ServiceRequestData<PermitsInstructorsRequestType> argument)
        {
            return AdapterClient.Execute<IIaaaEducationCentersAdapter, PermitsInstructorsRequestType, PermitsInstructorsResponse>(
                (i, r, a, o) => i.GetReport4InstructorPermitsDetails(r, a, o),
                 argument);
        }
        public ServiceResultDataSigned<PermitsExamPeopleCountRequestType, PermitsExamPeopleCountResponse> GetReport5PermitsExamPeopleCount(ServiceRequestData<PermitsExamPeopleCountRequestType> argument)
        {
            return  AdapterClient.Execute<IIaaaEducationCentersAdapter, PermitsExamPeopleCountRequestType, PermitsExamPeopleCountResponse>(
                (i, r, a, o) => i.GetReport5PermitsExamPeopleCount(r, a, o),
                 argument);
        }
        public ServiceResultDataSigned<SubjectOwnedCategoriesRequestType, SubjectOwnedCategoriesResponse> GetReport6SubjectOwnedCategories(ServiceRequestData<SubjectOwnedCategoriesRequestType> argument)
        {
            return AdapterClient.Execute<IIaaaEducationCentersAdapter, SubjectOwnedCategoriesRequestType, SubjectOwnedCategoriesResponse>(
                (i, r, a, o) => i.GetReport6SubjectOwnedCategories(r, a, o),
                 argument);
        }
    }
}
 