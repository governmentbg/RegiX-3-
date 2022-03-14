using System;
using System.Linq;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.Common.Utils;
using System.Data;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Common.DataContracts;
using Oracle.ManagedDataAccess.Client;
using TechnoLogica.RegiX.OracleAdapterService;
using TechnoLogica.RegiX.Adapters.Common.DataContracts;
using TechnoLogica.RegiX.Common.DataContracts.Parameter;
using TechnoLogica.RegiX.Adapters.Common.ObjectMapping;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;

namespace TechnoLogica.RegiX.AZJobsAdapter.AdapterService
{
    [Export(typeof(IAdapterService))]
    [ExportFullName(typeof(AZJobsAdapter), typeof(IAdapterService))]
    [ExportSimpleName(typeof(AZJobsAdapter), typeof(IAdapterService))]
    public class AZJobsAdapter : OracleBaseAdapterService, IAZJobsAdapter, IAdapterService
    {
        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(AZJobsAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> ConnectionString =
            new ParameterInfo<string>(@"Data Source=;User ID=;Password=;")
            {
                Key = Constants.ConnectionStringParameterKeyName,
                Description = "Connection String",
                OwnerAssembly = typeof(AZJobsAdapter).Assembly
            };

        public CommonSignedResponse<EmployerFreeJobPositionsRequestType, EmployerFreeJobPositionsResponse> GetEmployerFreeJobPositions(EmployerFreeJobPositionsRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
            try
            {
                OracleConnection connection = new OracleConnection(ConnectionString.Value);
                DataSet ds = new DataSet();

                OracleCommand command = new OracleCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;

                command.CommandText = @"SELECT *
                                  FROM V_EMPLOYER_FREE_JOB_POSITIONS
                                    where EntityID = :entityID";

                command.Parameters.Add("entityID", argument.EntityID);

                OracleDataAdapter resultDataSet = new OracleDataAdapter(command);
                ds.Tables.Add("EMPLOYER_FREE_JOB_POSITIONS");

                try
                {
                    connection.Open();
                    resultDataSet.Fill(ds.Tables["EMPLOYER_FREE_JOB_POSITIONS"]);

                }
                finally
                {
                    connection.Close();
                }
                if (ds.Tables["EMPLOYER_FREE_JOB_POSITIONS"].Rows.Count > 0)
                {
                    DataTable master = new DataTable("MASTER");
                    master = ds.Tables["EMPLOYER_FREE_JOB_POSITIONS"].Clone();
                    master.TableName = "MASTER";
                    master.ImportRow(ds.Tables["EMPLOYER_FREE_JOB_POSITIONS"].Rows[0]);
                    ds.Tables.Add(master);
                    ds.Relations.Add("free_job_positions", ds.Tables["MASTER"].Columns["EntityID"], ds.Tables["EMPLOYER_FREE_JOB_POSITIONS"].Columns["EntityID"]);
                }
                else
                {
                    DataTable master = new DataTable("MASTER");
                    master = ds.Tables["EMPLOYER_FREE_JOB_POSITIONS"].Clone();
                    master.TableName = "MASTER";
                    ds.Tables.Add(master);
                }

                DataSetMapper<EmployerFreeJobPositionsResponse> mapper = CreateMapForEmployerFreeJobPositions(accessMatrix);
                EmployerFreeJobPositionsResponse result = new EmployerFreeJobPositionsResponse();
                mapper.Map(ds, result);
                return
                    SigningUtils.CreateAndSign(
                        argument,
                        result,
                        accessMatrix,
                        aditionalParameters
                    );
            }
            catch (Exception ex)
            {
                LogError(aditionalParameters, ex, new { Guid = id });
                throw ex;
            }
        }

        private DataSetMapper<EmployerFreeJobPositionsResponse> CreateMapForEmployerFreeJobPositions(AccessMatrix accessMatrix)
        {
            DataSetMapper<EmployerFreeJobPositionsResponse> mapper = new DataSetMapper<EmployerFreeJobPositionsResponse>(accessMatrix);
            mapper.AddDataSetObjectInitializer((ds) => (ds.Tables["MASTER"].Rows.Count == 1) ? ds.Tables["MASTER"].Rows[0] : null);


            mapper.AddDataColumnMap((r) => r.EmployerData.EntityID, "EntityID");
            mapper.AddDataColumnMap((r) => r.EmployerData.EntityName, "EntityName");

            mapper.AddDataRowMap((r) => r.FreeJobPositions, (dr) => dr.GetChildRows("free_job_positions"));
            mapper.AddDataColumnMap((r) => r.FreeJobPositions[0].Address, "Address");
            mapper.AddDataColumnMap((r) => r.FreeJobPositions[0].AnnouncedFreeJobsCount, "AnnouncedFreeJobsCount");
            mapper.AddDataColumnMap((r) => r.FreeJobPositions[0].Area, "Area");
            mapper.AddDataColumnMap((r) => r.FreeJobPositions[0].ComputerSkillsRequirements, "ComputerSkillsRequirements");
            mapper.AddDataColumnMap((r) => r.FreeJobPositions[0].DateFrom, "DateFrom");
            mapper.AddDataColumnMap((r) => r.FreeJobPositions[0].DateTo, "DateTo");
            mapper.AddDataColumnMap((r) => r.FreeJobPositions[0].District, "District");
            mapper.AddDataColumnMap((r) => r.FreeJobPositions[0].EducationRequirements, "EducationRequirements");
            mapper.AddDataColumnMap((r) => r.FreeJobPositions[0].JobPosition, "JobPosition");
            mapper.AddDataColumnMap((r) => r.FreeJobPositions[0].JobSeekersDirectedCount, "JobSeekersDirectedCount");
            mapper.AddDataColumnMap((r) => r.FreeJobPositions[0].LanguageSkillsRequirements, "LanguageSkillsRequirements");
            mapper.AddDataColumnMap((r) => r.FreeJobPositions[0].Minucipality, "Minucipality");
            mapper.AddDataColumnMap((r) => r.FreeJobPositions[0].Town, "Town");
            mapper.AddDataColumnMap((r) => r.FreeJobPositions[0].VacantJobsCount, "VacantJobsCount");

            return mapper;
        }



        public CommonSignedResponse<EmploymentMeasureContractRequestType, EmploymentMeasureContractResponse> GetEmploymentMeasureContract(EmploymentMeasureContractRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
            try
            {
                OracleConnection connection = new OracleConnection(ConnectionString.Value);
                DataSet ds = new DataSet();

                OracleCommand command = new OracleCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;

                command.CommandText = @"SELECT *
                                  FROM V_EMPLOYMENT_MEASURE_CONTRACT
                                    where EntityID = :entityID";

                command.Parameters.Add("entityID", argument.EntityID);

                OracleDataAdapter resultDataSet = new OracleDataAdapter(command);
                ds.Tables.Add("EMPLOYMENT_MEASURE_CONTRACT");

                try
                {
                    connection.Open();
                    resultDataSet.Fill(ds.Tables["EMPLOYMENT_MEASURE_CONTRACT"]);

                }
                finally
                {
                    connection.Close();
                }
                if (ds.Tables["EMPLOYMENT_MEASURE_CONTRACT"].Rows.Count > 0)
                {
                    DataTable master = new DataTable("MASTER");
                    master = ds.Tables["EMPLOYMENT_MEASURE_CONTRACT"].Clone();
                    master.TableName = "MASTER";
                    master.ImportRow(ds.Tables["EMPLOYMENT_MEASURE_CONTRACT"].Rows[0]);
                    ds.Tables.Add(master);
                    ds.Relations.Add("measure_contract", ds.Tables["MASTER"].Columns["EntityID"], ds.Tables["EMPLOYMENT_MEASURE_CONTRACT"].Columns["EntityID"]);
                }
                else
                {
                    DataTable master = new DataTable("MASTER");
                    master = ds.Tables["EMPLOYMENT_MEASURE_CONTRACT"].Clone();
                    master.TableName = "MASTER";
                    ds.Tables.Add(master);
                }

                DataSetMapper<EmploymentMeasureContractResponse> mapper = CreateMapForEmploymentMeasureContract(accessMatrix);
                EmploymentMeasureContractResponse result = new EmploymentMeasureContractResponse();
                mapper.Map(ds, result);
                return
                    SigningUtils.CreateAndSign(
                        argument,
                        result,
                        accessMatrix,
                        aditionalParameters
                    );
            }
            catch (Exception ex)
            {
                LogError(aditionalParameters, ex, new { Guid = id });
                throw ex;
            }
        }
        private DataSetMapper<EmploymentMeasureContractResponse> CreateMapForEmploymentMeasureContract(AccessMatrix accessMatrix)
        {
            DataSetMapper<EmploymentMeasureContractResponse> mapper = new DataSetMapper<EmploymentMeasureContractResponse>(accessMatrix);


            mapper.AddDataSetObjectInitializer((ds) => (ds.Tables["MASTER"].Rows.Count == 1) ? ds.Tables["MASTER"].Rows[0] : null);


            mapper.AddDataColumnMap((r) => r.EmployerData.EntityID, "EntityID");
            mapper.AddDataColumnMap((r) => r.EmployerData.EntityName, "EntityName");

            mapper.AddDataRowMap((r) => r.EmploymentMeasureContracts, (dr) => dr.GetChildRows("measure_contract"));

            mapper.AddDataColumnMap((r) => r.EmploymentMeasureContracts[0].ContractNumber, "ContractNumber");
            mapper.AddDataColumnMap((r) => r.EmploymentMeasureContracts[0].ContractDate, "ContractDate");
            mapper.AddDataColumnMap((r) => r.EmploymentMeasureContracts[0].ContractStatus, "ContractStatus");
            mapper.AddDataColumnMap((r) => r.EmploymentMeasureContracts[0].EmploymentMeasureName, "EmploymentMeasureName");

            return mapper;
        }

        public CommonSignedResponse<EmploymentProgramContractRequestType, EmploymentProgramContractResponse> GetEmploymentProgramContract(EmploymentProgramContractRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
            try
            {
                OracleConnection connection = new OracleConnection(ConnectionString.Value);
                DataSet ds = new DataSet();

                OracleCommand command = new OracleCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;

                command.CommandText = @"SELECT *
                                  FROM V_EMPLOYMENT_PROGRAM_CONTRACT
                                    where EntityID = :entityID";

                command.Parameters.Add("entityID", argument.EntityID);

                OracleDataAdapter resultDataSet = new OracleDataAdapter(command);
                ds.Tables.Add("EMPLOYMENT_PROGRAM_CONTRACT");

                try
                {
                    connection.Open();
                    resultDataSet.Fill(ds.Tables["EMPLOYMENT_PROGRAM_CONTRACT"]);

                }
                finally
                {
                    connection.Close();
                }
                if (ds.Tables["EMPLOYMENT_PROGRAM_CONTRACT"].Rows.Count > 0)
                {
                    DataTable master = new DataTable("MASTER");
                    master = ds.Tables["EMPLOYMENT_PROGRAM_CONTRACT"].Clone();
                    master.TableName = "MASTER";
                    master.ImportRow(ds.Tables["EMPLOYMENT_PROGRAM_CONTRACT"].Rows[0]);
                    ds.Tables.Add(master);
                    ds.Relations.Add("program_contract", ds.Tables["MASTER"].Columns["EntityID"], ds.Tables["EMPLOYMENT_PROGRAM_CONTRACT"].Columns["EntityID"]);
                }
                else
                {
                    DataTable master = new DataTable("MASTER");
                    master = ds.Tables["EMPLOYMENT_PROGRAM_CONTRACT"].Clone();
                    master.TableName = "MASTER";
                    ds.Tables.Add(master);
                }

                DataSetMapper<EmploymentProgramContractResponse> mapper = CreateMapForEmploymenProgramContract(accessMatrix);
                EmploymentProgramContractResponse result = new EmploymentProgramContractResponse();
                mapper.Map(ds, result);
                return
                    SigningUtils.CreateAndSign(
                        argument,
                        result,
                        accessMatrix,
                        aditionalParameters
                    );
            }
            catch (Exception ex)
            {
                LogError(aditionalParameters, ex, new { Guid = id });
                throw ex;
            }
        }
        private DataSetMapper<EmploymentProgramContractResponse> CreateMapForEmploymenProgramContract(AccessMatrix accessMatrix)
        {
            DataSetMapper<EmploymentProgramContractResponse> mapper = new DataSetMapper<EmploymentProgramContractResponse>(accessMatrix);

            mapper.AddDataSetObjectInitializer((ds) => (ds.Tables["MASTER"].Rows.Count >= 1) ? ds.Tables["MASTER"].Rows[0] : null);

            mapper.AddDataColumnMap((r) => r.EmployerData.EntityID, "EntityID");
            mapper.AddDataColumnMap((r) => r.EmployerData.EntityName, "EntityName");

            mapper.AddDataRowMap((r) => r.EmploymentProgramContracts, (dr) => dr.GetChildRows("program_contract"));
            mapper.AddDataColumnMap((r) => r.EmploymentProgramContracts[0].ContractNumber, "ContractNumber");
            mapper.AddDataColumnMap((r) => r.EmploymentProgramContracts[0].ContractDate, "ContractDate");
            mapper.AddDataColumnMap((r) => r.EmploymentProgramContracts[0].ContractStatus, "ContractStatus");
            mapper.AddDataColumnMap((r) => r.EmploymentProgramContracts[0].EmploymentProgramName, "EmploymentProgramName");

            return mapper;
        }

        public CommonSignedResponse<JobSeekerContractsRequestType, JobSeekerContractsData> GetJobSeekerContracts(JobSeekerContractsRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
            try
            {
                OracleConnection connection = new OracleConnection(ConnectionString.Value);
                DataSet ds = new DataSet();

                OracleCommand command = new OracleCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;

                command.CommandText = @"SELECT *
                                  FROM V_JOB_SEEKER_CONTRACTS_RESP
                                    where PersonalID = :personalID";

                command.Parameters.Add("personalID", argument.PersonalID);

                OracleDataAdapter resultDataSet = new OracleDataAdapter(command);
                ds.Tables.Add("JOB_SEEKER_CONTRACTS_RESP");
                try
                {
                    connection.Open();
                    resultDataSet.Fill(ds.Tables["JOB_SEEKER_CONTRACTS_RESP"]);

                }
                finally
                {
                    connection.Close();
                }
                if (ds.Tables["JOB_SEEKER_CONTRACTS_RESP"].Rows.Count > 0)
                {
                    DataTable master = new DataTable("MASTER");
                    master = ds.Tables["JOB_SEEKER_CONTRACTS_RESP"].Clone();
                    master.TableName = "MASTER";
                    master.ImportRow(ds.Tables["JOB_SEEKER_CONTRACTS_RESP"].Rows[0]);
                    ds.Tables.Add(master);
                    ds.Relations.Add("job_seeker_contracts", ds.Tables["MASTER"].Columns["PersonalID"], ds.Tables["JOB_SEEKER_CONTRACTS_RESP"].Columns["PersonalID"]);
                }
                else
                {
                    DataTable master = new DataTable("MASTER");
                    master = ds.Tables["JOB_SEEKER_CONTRACTS_RESP"].Clone();
                    master.TableName = "MASTER";
                    ds.Tables.Add(master);
                }
                DataSetMapper<JobSeekerContractsData> mapper = CreateMapForJobSeekerContracts(accessMatrix);
                JobSeekerContractsData result = new JobSeekerContractsData();
                mapper.Map(ds, result);
                return
                    SigningUtils.CreateAndSign(
                        argument,
                        result,
                        accessMatrix,
                        aditionalParameters
                    );
            }
            catch (Exception ex)
            {
                LogError(aditionalParameters, ex, new { Guid = id });
                throw ex;
            }
        }
        private DataSetMapper<JobSeekerContractsData> CreateMapForJobSeekerContracts(AccessMatrix accessMatrix)
        {
            DataSetMapper<JobSeekerContractsData> mapper = new DataSetMapper<JobSeekerContractsData>(accessMatrix);

            mapper.AddDataSetObjectInitializer((ds) => (ds.Tables["MASTER"].Rows.Count >= 1) ? ds.Tables["MASTER"].Rows[0] : null);
            mapper.AddConstantMap((r) => r.JobSeekerPersonData.PersonalID, "PersonalID");
            mapper.AddDataColumnMap((r) => r.JobSeekerPersonData.FirstName, "FirstName");
            mapper.AddDataColumnMap((r) => r.JobSeekerPersonData.LastName, "LastName");
            mapper.AddDataColumnMap((r) => r.JobSeekerPersonData.MiddleName, "MiddleName");
            mapper.AddDataColumnMap((r) => r.JobSeekerPersonData.RegistrationDate, "RegistrationDate");
            mapper.AddDataColumnMap((r) => r.JobSeekerPersonData.RegistrationDBT, "RegistrationDBT");
            mapper.AddDataColumnMap((r) => r.JobSeekerPersonData.RegistrationNumber, "RegistrationNumber", (o) => o.ToString());
            mapper.AddDataColumnMap((r) => r.JobSeekerPersonData.RegistrationStatus, "RegistrationStatus");

            mapper.AddDataRowMap((r) => r.Contracts.Contract, (dr) => dr.GetChildRows("job_seeker_contracts"));
            mapper.AddDataColumnMap((r) => r.Contracts.Contract[0].ContractStatus, "ContractStatus");
            mapper.AddDataColumnMap((r) => r.Contracts.Contract[0].Measure, "Measure");
            mapper.AddDataColumnMap((r) => r.Contracts.Contract[0].ContractNumber, "ContractNumber");


            return mapper;
        }

        public CommonSignedResponse<JobSeekerDirectionsRequestType, JobSeekerDirectionsData> GetJobSeekerDirections(JobSeekerDirectionsRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
            try
            {

                OracleConnection connection = new OracleConnection(ConnectionString.Value);
                DataSet ds = new DataSet();

                OracleCommand command = new OracleCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;

                command.CommandText = @"SELECT *
                                  FROM V_JOB_SEEKER_DIRECTIONS_RESP
                                    where PersonalID = :personalID";

                command.Parameters.Add("personalID", argument.PersonalID);

                OracleDataAdapter resultDataSet = new OracleDataAdapter(command);
                ds.Tables.Add("JOB_SEEKER_DIRECTIONS_RESP");
                try
                {
                    connection.Open();
                    resultDataSet.Fill(ds.Tables["JOB_SEEKER_DIRECTIONS_RESP"]);

                }
                finally
                {
                    connection.Close();
                }
                if (ds.Tables["JOB_SEEKER_DIRECTIONS_RESP"].Rows.Count > 0)
                {
                    DataTable master = new DataTable("MASTER");
                    master = ds.Tables["JOB_SEEKER_DIRECTIONS_RESP"].Clone();
                    master.TableName = "MASTER";
                    master.ImportRow(ds.Tables["JOB_SEEKER_DIRECTIONS_RESP"].Rows[0]);
                    ds.Tables.Add(master);
                    ds.Relations.Add("job_seeker_directions", ds.Tables["MASTER"].Columns["PersonalID"], ds.Tables["JOB_SEEKER_DIRECTIONS_RESP"].Columns["PersonalID"]);
                }
                else
                {
                    DataTable master = new DataTable("MASTER");
                    master = ds.Tables["JOB_SEEKER_DIRECTIONS_RESP"].Clone();
                    master.TableName = "MASTER";
                    ds.Tables.Add(master);
                }

                DataSetMapper<JobSeekerDirectionsData> mapper = CreateMapForJobSeekerDirections(accessMatrix);
                JobSeekerDirectionsData result = new JobSeekerDirectionsData();
                mapper.Map(ds, result);
                return
                    SigningUtils.CreateAndSign(
                        argument,
                        result,
                        accessMatrix,
                        aditionalParameters
                    );
            }
            catch (Exception ex)
            {
                LogError(aditionalParameters, ex, new { Guid = id });
                throw ex;
            }
        }
        private DataSetMapper<JobSeekerDirectionsData> CreateMapForJobSeekerDirections(AccessMatrix accessMatrix)
        {
            DataSetMapper<JobSeekerDirectionsData> mapper = new DataSetMapper<JobSeekerDirectionsData>(accessMatrix);

            mapper.AddDataSetObjectInitializer((ds) => (ds.Tables["MASTER"].Rows.Count >= 1) ? ds.Tables["MASTER"].Rows[0] : null);
            mapper.AddDataColumnMap((r) => r.JobSeekerPersonData.PersonalID, "PersonalID");
            mapper.AddDataColumnMap((r) => r.JobSeekerPersonData.FirstName, "FirstName");
            mapper.AddDataColumnMap((r) => r.JobSeekerPersonData.LastName, "LastName");
            mapper.AddDataColumnMap((r) => r.JobSeekerPersonData.MiddleName, "MiddleName");
            mapper.AddDataColumnMap((r) => r.JobSeekerPersonData.RegistrationDate, "RegistrationDate");
            mapper.AddDataColumnMap((r) => r.JobSeekerPersonData.RegistrationDBT, "RegistrationDBT");
            mapper.AddDataColumnMap((r) => r.JobSeekerPersonData.RegistrationNumber, "RegistrationNumber", (o) => o.ToString());
            mapper.AddDataColumnMap((r) => r.JobSeekerPersonData.RegistrationStatus, "RegistrationStatus");
            mapper.AddDataRowMap((r) => r.Directions.Direction, (dr) => dr.GetChildRows("job_seeker_directions"));
            mapper.AddDataColumnMap((r) => r.Directions.Direction[0].Employer, "Employer");
            mapper.AddDataColumnMap((r) => r.Directions.Direction[0].FreeWorkPlace, "FreeWorkPlace", (o) => o.ToString());
            mapper.AddDataColumnMap((r) => r.Directions.Direction[0].JobPosition, "JobPosition");
            mapper.AddDataColumnMap((r) => r.Directions.Direction[0].RegistrationNumber, "RegistrationNumber", (o) => o.ToString());
            mapper.AddDataColumnMap((r) => r.Directions.Direction[0].ResultDate, "ResultDate");
            mapper.AddDataColumnMap((r) => r.Directions.Direction[0].State, "State");

            return mapper;
        }

        public CommonSignedResponse<JobSeekerHistoryRegistrationsRequestType, JobSeekerHistoryData> GetJobSeekerHistoryRegistrations(JobSeekerHistoryRegistrationsRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
            try
            {
                OracleConnection connection = new OracleConnection(ConnectionString.Value);
                DataSet ds = new DataSet();

                OracleCommand command = new OracleCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;

                command.CommandText = @"SELECT *
                                  FROM V_JOB_SEEKER_HISTORY_REGS
                                    where PersonalID = :personalID";

                command.Parameters.Add("personalID", argument.PersonalID);

                OracleDataAdapter resultDataSet = new OracleDataAdapter(command);
                ds.Tables.Add("JOB_SEEKER_HISTORY_REGS");
                try
                {
                    connection.Open();
                    resultDataSet.Fill(ds.Tables["JOB_SEEKER_HISTORY_REGS"]);

                }
                finally
                {
                    connection.Close();
                }

                if (ds.Tables["JOB_SEEKER_HISTORY_REGS"].Rows.Count > 0)
                {
                    DataTable master = new DataTable("MASTER");
                    master = ds.Tables["JOB_SEEKER_HISTORY_REGS"].Clone();
                    master.TableName = "MASTER";
                    master.ImportRow(ds.Tables["JOB_SEEKER_HISTORY_REGS"].Rows[0]);
                    ds.Tables.Add(master);
                    ds.Relations.Add("job_seeker_history", ds.Tables["MASTER"].Columns["PersonalID"], ds.Tables["JOB_SEEKER_HISTORY_REGS"].Columns["PersonalID"]);
                }
                else
                {
                    DataTable master = new DataTable("MASTER");
                    master = ds.Tables["JOB_SEEKER_HISTORY_REGS"].Clone();
                    master.TableName = "MASTER";
                    ds.Tables.Add(master);
                }

                DataSetMapper<JobSeekerHistoryData> mapper = CreateMapForJobSeekerHistoryRegistrations(accessMatrix);
                JobSeekerHistoryData result = new JobSeekerHistoryData();
                mapper.Map(ds, result);
                return
                    SigningUtils.CreateAndSign(
                        argument,
                        result,
                        accessMatrix,
                        aditionalParameters
                    );
            }
            catch (Exception ex)
            {
                LogError(aditionalParameters, ex, new { Guid = id });
                throw ex;
            }
        }

        private DataSetMapper<JobSeekerHistoryData> CreateMapForJobSeekerHistoryRegistrations(AccessMatrix accessMatrix)
        {
            DataSetMapper<JobSeekerHistoryData> mapper = new DataSetMapper<JobSeekerHistoryData>(accessMatrix);


            mapper.AddDataSetObjectInitializer((ds) => (ds.Tables["MASTER"].Rows.Count >= 1) ? ds.Tables["MASTER"].Rows[0] : null);
            mapper.AddDataColumnMap((r) => r.JobSeekerPersonData.PersonalID, "PersonalID");
            mapper.AddDataColumnMap((r) => r.JobSeekerPersonData.FirstName, "FirstName");
            mapper.AddDataColumnMap((r) => r.JobSeekerPersonData.LastName, "LastName");
            mapper.AddDataColumnMap((r) => r.JobSeekerPersonData.MiddleName, "MiddleName");
            mapper.AddDataColumnMap((r) => r.JobSeekerPersonData.RegistrationDate, "RegistrationDate");
            mapper.AddDataColumnMap((r) => r.JobSeekerPersonData.RegistrationDBT, "RegistrationDBT");
            mapper.AddDataColumnMap((r) => r.JobSeekerPersonData.RegistrationNumber, "RegistrationNumber", (o) => o.ToString());
            mapper.AddDataColumnMap((r) => r.JobSeekerPersonData.RegistrationStatus, "RegistrationStatus");

            mapper.AddDataRowMap((r) => r.HistoryOfRegistrations.HistoryOfRegistration, (dr) => dr.GetChildRows("job_seeker_history"));
            mapper.AddDataColumnMap((r) => r.HistoryOfRegistrations.HistoryOfRegistration[0].Activity, "Activity");
            mapper.AddDataColumnMap((r) => r.HistoryOfRegistrations.HistoryOfRegistration[0].Reason, "Reason");
            mapper.AddDataColumnMap((r) => r.HistoryOfRegistrations.HistoryOfRegistration[0].RegistrationDate, "RegistrationDate");
            mapper.AddDataColumnMap((r) => r.HistoryOfRegistrations.HistoryOfRegistration[0].RegistrationDBT, "RegistrationDBT");
            mapper.AddDataColumnMap((r) => r.HistoryOfRegistrations.HistoryOfRegistration[0].RegistrationGroup, "RegistrationGroup");
            mapper.AddDataColumnMap((r) => r.HistoryOfRegistrations.HistoryOfRegistration[0].RegistrationNumber, "RegistrationNumberHistory", (o) => o.ToString());

            return mapper;
        }

        public CommonSignedResponse<JobSeekerStatusRequestType, JobSeekerStatusData> GetJobSeekerStatus(JobSeekerStatusRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
            try
            {

                OracleConnection connection = new OracleConnection(ConnectionString.Value);
                DataSet ds = new DataSet();

                OracleCommand command = new OracleCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;

                command.CommandText = @"SELECT *
                                  FROM V_JOB_SEEKER_STATUS
                                    where PersonalID = :personalID";

                command.Parameters.Add("personalID", argument.PersonalID);

                OracleDataAdapter resultDataSet = new OracleDataAdapter(command);
                ds.Tables.Add("JOB_SEEKER_STATUS");
                try
                {
                    connection.Open();
                    resultDataSet.Fill(ds.Tables["JOB_SEEKER_STATUS"]);

                }
                finally
                {
                    connection.Close();
                }

                DataSetMapper<JobSeekerStatusData> mapper = CreateMapForJobSeekerStatus(accessMatrix);
                JobSeekerStatusData result = new JobSeekerStatusData();
                mapper.Map(ds, result);
                return
                    SigningUtils.CreateAndSign(
                        argument,
                        result,
                        accessMatrix,
                        aditionalParameters
                    );
            }
            catch (Exception ex)
            {
                LogError(aditionalParameters, ex, new { Guid = id });
                throw ex;
            }
        }
        private DataSetMapper<JobSeekerStatusData> CreateMapForJobSeekerStatus(AccessMatrix accessMatrix)
        {
            DataSetMapper<JobSeekerStatusData> mapper = new DataSetMapper<JobSeekerStatusData>(accessMatrix);
            mapper.AddDataSetObjectInitializer((ds) => (ds.Tables["JOB_SEEKER_STATUS"].Rows.Count >= 1) ? ds.Tables["JOB_SEEKER_STATUS"].Rows[0] : null);

            mapper.AddDataColumnMap((r) => r.RegistrationGroup, "RegistrationGroup");
            mapper.AddDataColumnMap((r) => r.JobSeekerPersonData.PersonalID, "PersonalID");
            mapper.AddDataColumnMap((r) => r.JobSeekerPersonData.FirstName, "FirstName");
            mapper.AddDataColumnMap((r) => r.JobSeekerPersonData.LastName, "LastName");
            mapper.AddDataColumnMap((r) => r.JobSeekerPersonData.MiddleName, "MiddleName");
            mapper.AddDataColumnMap((r) => r.JobSeekerPersonData.RegistrationDate, "RegistrationDate");
            mapper.AddDataColumnMap((r) => r.JobSeekerPersonData.RegistrationDBT, "RegistrationDBT");
            mapper.AddDataColumnMap((r) => r.JobSeekerPersonData.RegistrationNumber, "RegistrationNumber", (o) => o.ToString());
            mapper.AddDataColumnMap((r) => r.JobSeekerPersonData.RegistrationStatus, "RegistrationStatus");

            return mapper;
        }

        public CommonSignedResponse<JobSeekerTrainingsRequestType, JobSeekerTrainingsData> GetJobSeekerTrainings(JobSeekerTrainingsRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
            try
            {
                OracleConnection connection = new OracleConnection(ConnectionString.Value);
                DataSet ds = new DataSet();

                OracleCommand command = new OracleCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;

                command.CommandText = @"SELECT *
                                  FROM V_JOB_SEEKER_TRAININGS
                                    where PersonalID = :personalID";

                command.Parameters.Add("PersonalID", argument.PersonalID);

                OracleDataAdapter resultDataSet = new OracleDataAdapter(command);
                ds.Tables.Add("JOB_SEEKER_TRAININGS");
                try
                {
                    connection.Open();
                    resultDataSet.Fill(ds.Tables["JOB_SEEKER_TRAININGS"]);

                }
                finally
                {
                    connection.Close();
                }

                if (ds.Tables["JOB_SEEKER_TRAININGS"].Rows.Count > 0)
                {
                    DataTable master = new DataTable("MASTER");
                    master = ds.Tables["JOB_SEEKER_TRAININGS"].Clone();
                    master.TableName = "MASTER";
                    master.ImportRow(ds.Tables["JOB_SEEKER_TRAININGS"].Rows[0]);
                    ds.Tables.Add(master);
                    ds.Relations.Add("job_seeker_trainings", ds.Tables["MASTER"].Columns["PersonalID"], ds.Tables["JOB_SEEKER_TRAININGS"].Columns["PersonalID"]);
                }
                else
                {
                    DataTable master = new DataTable("MASTER");
                    master = ds.Tables["JOB_SEEKER_TRAININGS"].Clone();
                    master.TableName = "MASTER";
                    ds.Tables.Add(master);
                }

                DataSetMapper<JobSeekerTrainingsData> mapper = CreateMapForJobSeekerTrainings(accessMatrix);
                JobSeekerTrainingsData result = new JobSeekerTrainingsData();
                mapper.Map(ds, result);
                return
                    SigningUtils.CreateAndSign(
                        argument,
                        result,
                        accessMatrix,
                        aditionalParameters
                    );
            }
            catch (Exception ex)
            {
                LogError(aditionalParameters, ex, new { Guid = id });
                throw ex;
            }
        }
        private DataSetMapper<JobSeekerTrainingsData> CreateMapForJobSeekerTrainings(AccessMatrix accessMatrix)
        {
            DataSetMapper<JobSeekerTrainingsData> mapper = new DataSetMapper<JobSeekerTrainingsData>(accessMatrix);

            mapper.AddDataSetObjectInitializer((ds) => (ds.Tables["MASTER"].Rows.Count >= 1) ? ds.Tables["MASTER"].Rows[0] : null);
            mapper.AddDataColumnMap((r) => r.JobSeekerPersonData.PersonalID, "PersonalID");
            mapper.AddDataColumnMap((r) => r.JobSeekerPersonData.FirstName, "FirstName");
            mapper.AddDataColumnMap((r) => r.JobSeekerPersonData.LastName, "LastName");
            mapper.AddDataColumnMap((r) => r.JobSeekerPersonData.MiddleName, "MiddleName");
            mapper.AddDataColumnMap((r) => r.JobSeekerPersonData.RegistrationDate, "RegistrationDate");
            mapper.AddDataColumnMap((r) => r.JobSeekerPersonData.RegistrationDBT, "RegistrationDBT");
            mapper.AddDataColumnMap((r) => r.JobSeekerPersonData.RegistrationNumber, "RegistrationNumber", (o) => o.ToString());
            mapper.AddDataColumnMap((r) => r.JobSeekerPersonData.RegistrationStatus, "RegistrationStatus");

            mapper.AddDataRowMap((r) => r.Trainings.Training, (dr) => dr.GetChildRows("job_seeker_trainings"));
            mapper.AddDataColumnMap((r) => r.Trainings.Training[0].DateFrom, "DateFrom");
            mapper.AddDataColumnMap((r) => r.Trainings.Training[0].DateTo, "DateTo");
            mapper.AddDataColumnMap((r) => r.Trainings.Training[0].Measure, "Measure");
            mapper.AddDataColumnMap((r) => r.Trainings.Training[0].RegistrationNumber, "RegistrationNumber", (o) => o.ToString());
            mapper.AddDataColumnMap((r) => r.Trainings.Training[0].Result, "Result");
            mapper.AddDataColumnMap((r) => r.Trainings.Training[0].TrainingName, "TrainingName");
            mapper.AddDataColumnMap((r) => r.Trainings.Training[0].TrainingType, "TrainingType");

            return mapper;
        }

    }
}
