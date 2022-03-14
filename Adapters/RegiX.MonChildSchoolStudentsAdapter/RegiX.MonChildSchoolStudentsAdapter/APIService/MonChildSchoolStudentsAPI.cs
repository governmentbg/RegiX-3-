using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.MonChildSchoolStudentsAdapter.AdapterService;
using TechnoLogica.RegiX.Adapters.Common;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Common.TransportObjects;

namespace TechnoLogica.RegiX.MonChildSchoolStudentsAdapter.APIService
{
    [ExportFullName(typeof(IMonChildSchoolStudentsAPI), typeof(IAPIService))]
    [Export(typeof(IAPIService))]
    public class MonChildSchoolStudentsAPI : BaseAPIService<IMonChildSchoolStudentsAPI>, IMonChildSchoolStudentsAPI
    {
        public ServiceResultDataSigned<ChildStudentStatusRequestType, ChildStudentStatusResponse> GetChildStudentStatus(ServiceRequestData<ChildStudentStatusRequestType> argument)
        {
            return  AdapterClient.Execute<IMonChildSchoolStudentsAdapter, ChildStudentStatusRequestType, ChildStudentStatusResponse>(
                (i, r, a, o) => i.GetChildStudentStatus(r, a, o),
                 argument);
        }

        public ServiceResultDataSigned<SchoolStudentStatusRequestType, SchoolStudentStatusResponse> GetSchoolStudentStatus(ServiceRequestData<SchoolStudentStatusRequestType> argument)
        {
            return AdapterClient.Execute<IMonChildSchoolStudentsAdapter, SchoolStudentStatusRequestType, SchoolStudentStatusResponse>(
                (i, r, a, o) => i.GetSchoolStudentStatus(r, a, o),
                 argument);
        }
    }
}
