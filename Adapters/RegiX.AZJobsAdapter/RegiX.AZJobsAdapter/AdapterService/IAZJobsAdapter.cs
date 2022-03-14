using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;

namespace TechnoLogica.RegiX.AZJobsAdapter.AdapterService
{
    [ServiceContract]
    [Description("Адаптер за комуникация с Агенция по заетостта - Регистър на търсещите работа лица")]
    public interface IAZJobsAdapter : IAdapterServiceWCF
    {
        [OperationContract]
        [Description("Справка по ЕИК/БУЛСТАТ за обявени свободни работни места при работодател")]
        CommonSignedResponse<EmployerFreeJobPositionsRequestType, EmployerFreeJobPositionsResponse> GetEmployerFreeJobPositions(EmployerFreeJobPositionsRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Справка по ЕИК/БУЛСТАТ за сключен рамков договор с работодател по мярка за заетост")]
        CommonSignedResponse<EmploymentMeasureContractRequestType, EmploymentMeasureContractResponse> GetEmploymentMeasureContract(EmploymentMeasureContractRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Справка по ЕИК/БУЛСТАТ за сключен рамков договор с работодател по програма за заетост")]
        CommonSignedResponse<EmploymentProgramContractRequestType, EmploymentProgramContractResponse> GetEmploymentProgramContract(EmploymentProgramContractRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Справка по ЕГН/ЛНЧ за сключен договор между Агенцията по заетостта и безработно лице")]
        CommonSignedResponse<JobSeekerContractsRequestType, JobSeekerContractsData> GetJobSeekerContracts(JobSeekerContractsRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Справка по ЕГН/ЛНЧ за насочвания на търсещо работа лице")]
        CommonSignedResponse<JobSeekerDirectionsRequestType, JobSeekerDirectionsData> GetJobSeekerDirections(JobSeekerDirectionsRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Справка по ЕГН/ЛНЧ за история на регистрацията на търсещо работа лице")]
        CommonSignedResponse<JobSeekerHistoryRegistrationsRequestType, JobSeekerHistoryData> GetJobSeekerHistoryRegistrations(JobSeekerHistoryRegistrationsRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Справка по ЕГН/ЛНЧ за статус на търсещо работа лице")]
        CommonSignedResponse<JobSeekerStatusRequestType, JobSeekerStatusData> GetJobSeekerStatus(JobSeekerStatusRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Справка по ЕГН/ЛНЧ за обучения на търсещо работа лице")]
        CommonSignedResponse<JobSeekerTrainingsRequestType, JobSeekerTrainingsData> GetJobSeekerTrainings(JobSeekerTrainingsRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);
    }
}

