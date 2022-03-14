namespace TechnoLogica.RegiX.AZJobsAdapter.AdapterService
{
    //public class AZJobsAdapter : OracleAdapterService.OracleBaseAdapterService, IAZJobsAdapter, IAdapterService
    //{

    //    public CommonSignedResponse<EmployerFreeJobPositionsRequestType, EmployerFreeJobPositionsResponse> GetEmployerFreeJobPositions(EmployerFreeJobPositionsRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
    //    {
    //        Guid id = Guid.NewGuid();
    //        LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
    //        try
    //        {
    //            EmployerFreeJobPositionsResponse result = new EmployerFreeJobPositionsResponse();
    //            if (argument.EntityID != null)
    //            {
    //                result = (EmployerFreeJobPositionsResponse)FileUtils.ReadXml("\\XMLData\\GetEmployerFreeJobPositionsTest.xml", typeof(EmployerFreeJobPositionsResponse));
    //            }
    //            else
    //            {
    //                result = (EmployerFreeJobPositionsResponse)FileUtils.ReadXml("\\XMLData\\GetEmployerFreeJobPositionsNULLTest.xml", typeof(EmployerFreeJobPositionsResponse));
    //            }

    //            return
    //                SigningUtils.CreateAndSign(
    //                    argument,
    //                    result,
    //                    accessMatrix,
    //                    aditionalParameters
    //                );
    //        }
    //        catch (Exception ex)
    //        {
    //            LogError(aditionalParameters, ex, new { Guid = id });
    //            throw ex;
    //        }
    //    }


    //    public CommonSignedResponse<EmploymentMeasureContractRequestType, EmploymentMeasureContractResponse> GetEmploymentMeasureContract(EmploymentMeasureContractRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
    //    {
    //        Guid id = Guid.NewGuid();
    //        LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
    //        try
    //        {

    //            EmploymentMeasureContractResponse result = new EmploymentMeasureContractResponse();
    //            if (argument.EntityID != null)
    //            {
    //                result = (EmploymentMeasureContractResponse)FileUtils.ReadXml("\\XMLData\\GetEmploymentMeasureContractTest.xml", typeof(EmploymentMeasureContractResponse));
    //            }
    //            else
    //            {
    //                result = (EmploymentMeasureContractResponse)FileUtils.ReadXml("\\XMLData\\GetEmploymentMeasureContractNULLTest.xml", typeof(EmploymentMeasureContractResponse));
    //            }
    //            return
    //                SigningUtils.CreateAndSign(
    //                    argument,
    //                    result,
    //                    accessMatrix,
    //                    aditionalParameters
    //                );
    //        }
    //        catch (Exception ex)
    //        {
    //            LogError(aditionalParameters, ex, new { Guid = id });
    //            throw ex;
    //        }
    //    }

    //    public CommonSignedResponse<EmploymentProgramContractRequestType, EmploymentProgramContractResponse> GetEmploymentProgramContract(EmploymentProgramContractRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
    //    {
    //        Guid id = Guid.NewGuid();
    //        LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
    //        try
    //        {
    //            EmploymentProgramContractResponse result = new EmploymentProgramContractResponse();
    //            if (argument.EntityID != null)
    //            {
    //                result = (EmploymentProgramContractResponse)FileUtils.ReadXml("\\XMLData\\GetEmploymentProgramContractTest.xml", typeof(EmploymentProgramContractResponse));
    //            }
    //            else
    //            {
    //                result = (EmploymentProgramContractResponse)FileUtils.ReadXml("\\XMLData\\GetEmploymentProgramContractNULLTest.xml", typeof(EmploymentProgramContractResponse));
    //            }
    //            return
    //                SigningUtils.CreateAndSign(
    //                    argument,
    //                    result,
    //                    accessMatrix,
    //                    aditionalParameters
    //                );
    //        }
    //        catch (Exception ex)
    //        {
    //            LogError(aditionalParameters, ex, new { Guid = id });
    //            throw ex;
    //        }
    //    }

    //    public CommonSignedResponse<JobSeekerContractsRequestType, JobSeekerContractsData> GetJobSeekerContracts(JobSeekerContractsRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
    //    {
    //        Guid id = Guid.NewGuid();
    //        LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
    //        try
    //        {

    //            JobSeekerContractsData result = new JobSeekerContractsData();
    //            if (argument.PersonalID != null)
    //            {
    //                result = (JobSeekerContractsData)FileUtils.ReadXml("\\XMLData\\GetJobSeekerContractsTest.xml", typeof(JobSeekerContractsData));
    //            }
    //            else
    //            {
    //                result = (JobSeekerContractsData)FileUtils.ReadXml("\\XMLData\\GetJobSeekerContractsNULLTest.xml", typeof(JobSeekerContractsData));
    //            }
    //            return
    //                SigningUtils.CreateAndSign(
    //                    argument,
    //                    result,
    //                    accessMatrix,
    //                    aditionalParameters
    //                );
    //        }
    //        catch (Exception ex)
    //        {
    //            LogError(aditionalParameters, ex, new { Guid = id });
    //            throw ex;
    //        }
    //    }

    //    public CommonSignedResponse<JobSeekerDirectionsRequestType, JobSeekerDirectionsData> GetJobSeekerDirections(JobSeekerDirectionsRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
    //    {
    //        Guid id = Guid.NewGuid();
    //        LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
    //        try
    //        {

    //            JobSeekerDirectionsData result = new JobSeekerDirectionsData();
    //            if (argument.PersonalID != null)
    //            {
    //                result = (JobSeekerDirectionsData)FileUtils.ReadXml("\\XMLData\\GetJobSeekerDirectionsTest.xml", typeof(JobSeekerDirectionsData));
    //            }
    //            else
    //            {
    //                result = (JobSeekerDirectionsData)FileUtils.ReadXml("\\XMLData\\GetJobSeekerDirectionsNULLTest.xml", typeof(JobSeekerDirectionsData));
    //            }
    //            return
    //                SigningUtils.CreateAndSign(
    //                    argument,
    //                    result,
    //                    accessMatrix,
    //                    aditionalParameters
    //                );
    //        }
    //        catch (Exception ex)
    //        {
    //            LogError(aditionalParameters, ex, new { Guid = id });
    //            throw ex;
    //        }
    //    }

    //    public CommonSignedResponse<JobSeekerHistoryRegistrationsRequestType, JobSeekerHistoryData> GetJobSeekerHistoryRegistrations(JobSeekerHistoryRegistrationsRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
    //    {
    //        Guid id = Guid.NewGuid();
    //        LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
    //        try
    //        {

    //            JobSeekerHistoryData result = new JobSeekerHistoryData();
    //            if (argument.PersonalID != null)
    //            {
    //                result = (JobSeekerHistoryData)FileUtils.ReadXml("\\XMLData\\GetJobSeekerHistoryRegistrationsTest.xml", typeof(JobSeekerHistoryData));
    //            }
    //            else
    //            {
    //                result = (JobSeekerHistoryData)FileUtils.ReadXml("\\XMLData\\GetJobSeekerHistoryRegistrationsNULLTest.xml", typeof(JobSeekerHistoryData));
    //            }
    //            return
    //                SigningUtils.CreateAndSign(
    //                    argument,
    //                    result,
    //                    accessMatrix,
    //                    aditionalParameters
    //                );
    //        }
    //        catch (Exception ex)
    //        {
    //            LogError(aditionalParameters, ex, new { Guid = id });
    //            throw ex;
    //        }
    //    }


    //    public CommonSignedResponse<JobSeekerStatusRequestType, JobSeekerStatusData> GetJobSeekerStatus(JobSeekerStatusRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
    //    {
    //        Guid id = Guid.NewGuid();
    //        LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
    //        try
    //        {

    //            JobSeekerStatusData result = new JobSeekerStatusData();
    //            if (argument.PersonalID != null)
    //            {
    //                result = (JobSeekerStatusData)FileUtils.ReadXml("\\XMLData\\GetJobSeekerStatusTest.xml", typeof(JobSeekerStatusData));
    //            }
    //            else
    //            {
    //                result = (JobSeekerStatusData)FileUtils.ReadXml("\\XMLData\\GetJobSeekerStatusNULLTest.xml", typeof(JobSeekerStatusData));
    //            }
    //            return
    //                SigningUtils.CreateAndSign(
    //                    argument,
    //                    result,
    //                    accessMatrix,
    //                    aditionalParameters
    //                );
    //        }
    //        catch (Exception ex)
    //        {
    //            LogError(aditionalParameters, ex, new { Guid = id });
    //            throw ex;
    //        }
    //    }

    //    public CommonSignedResponse<JobSeekerTrainingsRequestType, JobSeekerTrainingsData> GetJobSeekerTrainings(JobSeekerTrainingsRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
    //    {
    //        Guid id = Guid.NewGuid();
    //        LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
    //        try
    //        {
    //            JobSeekerTrainingsData result = new JobSeekerTrainingsData();
    //            if (argument.PersonalID != null)
    //            {
    //                result = (JobSeekerTrainingsData)FileUtils.ReadXml("\\XMLData\\GetJobSeekerTrainingsTest.xml", typeof(JobSeekerTrainingsData));
    //            }
    //            else
    //            {
    //                result = (JobSeekerTrainingsData)FileUtils.ReadXml("\\XMLData\\GetJobSeekerTrainingsNULLTest.xml", typeof(JobSeekerTrainingsData));
    //            }
    //            return
    //                SigningUtils.CreateAndSign(
    //                    argument,
    //                    result,
    //                    accessMatrix,
    //                    aditionalParameters
    //                );
    //        }
    //        catch (Exception ex)
    //        {
    //            LogError(aditionalParameters, ex, new { Guid = id });
    //            throw ex;
    //        }
    //    }

    //}
}
