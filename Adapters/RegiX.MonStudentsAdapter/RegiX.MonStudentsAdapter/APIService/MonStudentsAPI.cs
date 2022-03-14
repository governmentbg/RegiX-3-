using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.MonStudentsAdapter.AdapterService;
using TechnoLogica.RegiX.Adapters.Common;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Common.TransportObjects;

namespace TechnoLogica.RegiX.MonStudentsAdapter.APIService
{
    [ExportFullName(typeof(IMonStudentsAPI), typeof(IAPIService))]
    [Export(typeof(IAPIService))]
    public class MonStudentsAPI : BaseAPIService<IMonStudentsAPI>, IMonStudentsAPI
    {
        public ServiceResultDataSigned<HigherEduStudentByStatusRequestType, HigherEduStudentByStatusResponse> GetHigherEduStudentByStatus(ServiceRequestData<HigherEduStudentByStatusRequestType> argument)
        {
            return  AdapterClient.Execute<IMonStudentsAdapter, HigherEduStudentByStatusRequestType, HigherEduStudentByStatusResponse>(
                (i, r, a, o) => i.GetHigherEduStudentByStatus(r, a, o),
                 argument);
        }

        public ServiceResultDataSigned<HigherEduStudentRequestType, HigherEduStudentResponse> GetHigherEduStudent(ServiceRequestData<HigherEduStudentRequestType> argument)
        {
            return AdapterClient.Execute<IMonStudentsAdapter, HigherEduStudentRequestType, HigherEduStudentResponse>(
                (i, r, a, o) => i.GetHigherEduStudent(r, a, o),
                 argument);
        }
    }
}
