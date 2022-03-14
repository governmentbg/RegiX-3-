using System.ServiceModel;
using System.ComponentModel;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Adapters.Common.Attributes;

namespace TechnoLogica.RegiX.AZJobsAdapter.APIService
{
    [ServiceContract]
    [XmlSerializerFormat]
    [Description("API на Адаптер за комуникация с Агенция по заетостта - Регистър на търсещите работа лица")]
    public interface IAZJobsAPI : IAPIService
    {
        //Справка по ЕИК/БУЛСТАТ за обявени свободни работни места при работодател

        [OperationContract]
        [Description("Справка по ЕИК/БУЛСТАТ за обявени свободни работни места при работодател")]
        [Info(
            requestXSD: "EmployerFreeJobPositionsRequest.xsd",
            responseXSD: "EmployerFreeJobPositionsResponse.xsd",
            commonXSD: "AZCommon.xsd",
            requestXSLT: "EmployerFreeJobPositionsRequest.xslt",
            responseXSLT: "EmployerFreeJobPositionsResponse.xslt")]
        ServiceResultDataSigned<EmployerFreeJobPositionsRequestType, EmployerFreeJobPositionsResponse> GetEmployerFreeJobPositions(ServiceRequestData<EmployerFreeJobPositionsRequestType> argument);

        // Справка по ЕИК/БУЛСТАТ за сключен рамков договор с работодател по мярка за заетост
        
        [OperationContract]
        [Description("Справка по ЕИК/БУЛСТАТ за сключен рамков договор с работодател по мярка за заетост")]
        [Info(
            requestXSD: "EmploymentMeasureContractRequest.xsd",
            responseXSD: "EmploymentMeasureContractResponse.xsd",
            commonXSD: "AZCommon.xsd",
            requestXSLT: "EmploymentMeasureContactRequest.xslt",
            responseXSLT: "EmploymentMeasureContactResponse.xslt")]
        ServiceResultDataSigned<EmploymentMeasureContractRequestType, EmploymentMeasureContractResponse> GetEmploymentMeasureContract(ServiceRequestData<EmploymentMeasureContractRequestType> argument);

        //Справка по ЕИК/БУЛСТАТ за сключен рамков договор с работодател по програма за заетост

        [OperationContract]
        [Description("Справка по ЕИК/БУЛСТАТ за сключен рамков договор с работодател по програма за заетост")]
        [Info(
            requestXSD: "EmploymentProgramContractRequest.xsd",
            responseXSD: "EmploymentProgramContractResponse.xsd",
            commonXSD: "AZCommon.xsd",
            requestXSLT: "EmploymentProgramContractRequest.xslt",
            responseXSLT: "EmploymentProgramContractResponse.xslt")]
        ServiceResultDataSigned<EmploymentProgramContractRequestType, EmploymentProgramContractResponse> GetEmploymentProgramContract(ServiceRequestData<EmploymentProgramContractRequestType> argument);

        //Справка по ЕГН/ЛНЧ за сключен договор между Агенцията по заетостта и безработно лице

        [OperationContract]
        [Description("Справка по ЕГН/ЛНЧ за сключен договор между Агенцията по заетостта и безработно лице")]
        [Info(
            requestXSD: "JobSeekerContractsRequest.xsd",
            responseXSD: "JobSeekerContractsResponse.xsd",
            commonXSD: "AZCommon.xsd",
            requestXSLT: "JobSeekerContractsRequest.xslt",
            responseXSLT: "JobSeekerContractsResponse.xslt")]
        ServiceResultDataSigned<JobSeekerContractsRequestType, JobSeekerContractsData> GetJobSeekerContracts(ServiceRequestData<JobSeekerContractsRequestType> argument);

        //Справка по ЕГН/ЛНЧ за насочвания на търсещо работа лице

        [OperationContract]
        [Description("Справка по ЕГН/ЛНЧ за насочвания на търсещо работа лице")]
        [Info(
            requestXSD: "JobSeekerDirectionsRequest.xsd",
            responseXSD: "JobSeekerDirectionsResponse.xsd",
            commonXSD: "AZCommon.xsd",
            requestXSLT: "JobSeekerDirectionsRequest.xslt",
            responseXSLT: "JobSeekerDirectionsResponse.xslt")]
        ServiceResultDataSigned<JobSeekerDirectionsRequestType, JobSeekerDirectionsData> GetJobSeekerDirections(ServiceRequestData<JobSeekerDirectionsRequestType> argument);

        //Справка по ЕГН/ЛНЧ за история на регистрацията на търсещо работа лице

        [OperationContract]
        [Description("Справка по ЕГН/ЛНЧ за история на регистрацията на търсещо работа лице")]
        [Info(
            requestXSD: "JobSeekerHistoryRegistrationsRequest.xsd",
            responseXSD: "JobSeekerHistoryRegistrationsResponse.xsd",
            commonXSD: "AZCommon.xsd",
            requestXSLT: "JobSeekerHistoryRegistrationsRequest.xslt",
            responseXSLT: "JobSeekerHistoryRegistrationsResponse.xslt")]
        ServiceResultDataSigned<JobSeekerHistoryRegistrationsRequestType, JobSeekerHistoryData> GetJobSeekerHistoryRegistrations(ServiceRequestData<JobSeekerHistoryRegistrationsRequestType> argument);

        //Справка по ЕГН/ЛНЧ за статус на търсещо работа лице
        
        [OperationContract]
        [Description("Справка по ЕГН/ЛНЧ за статус на търсещо работа лице")]
        [Info(
            requestXSD: "JobSeekerStatusRequest.xsd",
            responseXSD: "JobSeekerStatusResponse.xsd",
            commonXSD: "AZCommon.xsd",
            requestXSLT: "JobSeekerStatusRequest.xslt",
            responseXSLT: "JobSeekerStatusResponse.xslt")]
        ServiceResultDataSigned<JobSeekerStatusRequestType, JobSeekerStatusData> GetJobSeekerStatus(ServiceRequestData<JobSeekerStatusRequestType> argument);

        //Справка по ЕГН/ЛНЧ за обучения на търсещо работа лице

        [OperationContract]
        [Description("Справка по ЕГН/ЛНЧ за обучения на търсещо работа лице")]
        [Info(
            requestXSD: "JobSeekerTrainingsRequest.xsd",
            responseXSD: "JobSeekerTrainingsResponse.xsd",
            commonXSD: "AZCommon.xsd",
            requestXSLT: "JobSeekerTrainingsRequest.xslt",
            responseXSLT: "JobSeekerTrainingsResponse.xslt")]
        ServiceResultDataSigned<JobSeekerTrainingsRequestType, JobSeekerTrainingsData> GetJobSeekerTrainings(ServiceRequestData<JobSeekerTrainingsRequestType> argument);
    }
}
