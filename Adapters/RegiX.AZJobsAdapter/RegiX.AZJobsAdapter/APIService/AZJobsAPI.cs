using TechnoLogica.RegiX.AZJobsAdapter.AdapterService;
using TechnoLogica.RegiX.Adapters.Common;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Common;

namespace TechnoLogica.RegiX.AZJobsAdapter.APIService
{
    [ExportFullName(typeof(IAZJobsAPI), typeof(IAPIService))]
    [Export(typeof(IAPIService))]
    public class AZJobsAPI : BaseAPIService<IAZJobsAPI>, IAZJobsAPI
    {
        public ServiceResultDataSigned<EmployerFreeJobPositionsRequestType, EmployerFreeJobPositionsResponse> GetEmployerFreeJobPositions(ServiceRequestData<EmployerFreeJobPositionsRequestType> argument)
        {
            return AdapterClient.Execute<IAZJobsAdapter, EmployerFreeJobPositionsRequestType, EmployerFreeJobPositionsResponse>(
                (i, r, a, o) => i.GetEmployerFreeJobPositions(r, a, o), 
                argument);
        }

        public ServiceResultDataSigned<EmploymentMeasureContractRequestType, EmploymentMeasureContractResponse> GetEmploymentMeasureContract(ServiceRequestData<EmploymentMeasureContractRequestType> argument)
        {
            return AdapterClient.Execute<IAZJobsAdapter, EmploymentMeasureContractRequestType, EmploymentMeasureContractResponse>(
                (i, r, a, o) => i.GetEmploymentMeasureContract(r, a, o), 
                 argument);
        }

        public ServiceResultDataSigned<EmploymentProgramContractRequestType, EmploymentProgramContractResponse> GetEmploymentProgramContract(ServiceRequestData<EmploymentProgramContractRequestType> argument)
        {
            return AdapterClient.Execute<IAZJobsAdapter, EmploymentProgramContractRequestType, EmploymentProgramContractResponse>(
                (i, r, a, o) => i.GetEmploymentProgramContract(r, a, o), 
                argument);
        }

        public ServiceResultDataSigned<JobSeekerContractsRequestType, JobSeekerContractsData> GetJobSeekerContracts(ServiceRequestData<JobSeekerContractsRequestType> argument)
        {
            return AdapterClient.Execute<IAZJobsAdapter, JobSeekerContractsRequestType, JobSeekerContractsData>(
                (i, r, a, o) => i.GetJobSeekerContracts(r, a, o), 
                 argument);
        }

        public ServiceResultDataSigned<JobSeekerDirectionsRequestType, JobSeekerDirectionsData> GetJobSeekerDirections(ServiceRequestData<JobSeekerDirectionsRequestType> argument)
        {
            return AdapterClient.Execute<IAZJobsAdapter, JobSeekerDirectionsRequestType, JobSeekerDirectionsData>(
                (i, r, a, o) => i.GetJobSeekerDirections(r, a, o), 
                 argument);
        }

        public ServiceResultDataSigned<JobSeekerHistoryRegistrationsRequestType, JobSeekerHistoryData> GetJobSeekerHistoryRegistrations(ServiceRequestData<JobSeekerHistoryRegistrationsRequestType> argument)
        {
            return AdapterClient.Execute<IAZJobsAdapter, JobSeekerHistoryRegistrationsRequestType, JobSeekerHistoryData>(
                (i, r, a, o) => i.GetJobSeekerHistoryRegistrations(r, a, o), 
                 argument);
        }

        public ServiceResultDataSigned<JobSeekerStatusRequestType, JobSeekerStatusData> GetJobSeekerStatus(ServiceRequestData<JobSeekerStatusRequestType> argument)
        {
            return AdapterClient.Execute<IAZJobsAdapter, JobSeekerStatusRequestType, JobSeekerStatusData>(
                (i, r, a, o) => i.GetJobSeekerStatus(r, a, o), 
                 argument);
        }

        public ServiceResultDataSigned<JobSeekerTrainingsRequestType, JobSeekerTrainingsData> GetJobSeekerTrainings(ServiceRequestData<JobSeekerTrainingsRequestType> argument)
        {
            return AdapterClient.Execute<IAZJobsAdapter, JobSeekerTrainingsRequestType, JobSeekerTrainingsData>(
                (i, r, a, o) => i.GetJobSeekerTrainings(r, a, o),
                 argument);
        }
    }
}
