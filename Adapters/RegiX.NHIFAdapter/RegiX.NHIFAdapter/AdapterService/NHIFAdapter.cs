using Oracle.ManagedDataAccess.Client;
using System;
using System.ComponentModel.Composition;
using System.Data;
using System.Diagnostics;
using TechnoLogica.RegiX.Adapters.Common.DataContracts;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Adapters.Common.ObjectMapping;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.DataContracts.Parameter;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.Common.Utils;
//using Oracle.ManagedDataAccess.Client;


namespace TechnoLogica.RegiX.NHIFAdapter.AdapterService
{
    [Export(typeof(IAdapterService))]
    [ExportFullName(typeof(NHIFAdapter), typeof(IAdapterService))]
    [ExportSimpleName(typeof(NHIFAdapter), typeof(IAdapterService))]
    public class NHIFAdapter : OracleAdapterService.OracleBaseAdapterService, INHIFAdapter, IAdapterService
    {
        private const string EgnInputParameter = "EGN";
        private const string LnchInputParamter = "LNCh";

        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(NHIFAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> ConnectionString =
            new ParameterInfo<string>(@"Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = IP)(PORT = 1521))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = nhifdev)));User ID=;Password=;")
            {
                Key = Constants.ConnectionStringParameterKeyName,
                Description = "Connection string",
                OwnerAssembly = typeof(NHIFAdapter).Assembly
            };


        public CommonSignedResponse<PatientRecordMedicalTreatmentsRequest, PatientRecordMedicalTreatmentsResponse> GetPatientRecordMedicalTreatments(PatientRecordMedicalTreatmentsRequest argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            CustomLog(aditionalParameters, argument.Serialize(), id.ToString());
            try
            {
                OracleConnection connection = new OracleConnection(ConnectionString.Value);
                DataSet ds = new DataSet();

                OracleCommand command = new OracleCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;

                command.CommandText = @"select * from table( ws_regix_patient_info.ahu_rep_med_treat( p_patient_ident_no => :p_patient_ident_no,
                                                          p_patient_ident_type => :p_patient_ident_type,
                                                          p_regix_context => :p_regix_context
                                                        ))";
                var p_patient_ident_no = new OracleParameter("p_patient_ident_no", OracleDbType.Varchar2, ParameterDirection.Input);
                p_patient_ident_no.Value = argument.Identifier;
                command.Parameters.Add(p_patient_ident_no);

                var p_patient_ident_type = new OracleParameter("p_parient_ident_type", OracleDbType.Varchar2, ParameterDirection.Input);
                p_patient_ident_type.Value = argument.IdentifierType == IdentifierType.EGN ? EgnInputParameter : LnchInputParamter;
                command.Parameters.Add(p_patient_ident_type);


                var p_regix_context = new OracleParameter("p_regix_context", OracleDbType.Varchar2, ParameterDirection.Input);
                p_regix_context.Value = aditionalParameters.CallContext.ToString();
                command.Parameters.Add(p_regix_context);

                OracleDataAdapter resultDataSet = new OracleDataAdapter(command);

                ds.Tables.Add("PR_MED_TR_TBL");

                try
                {
                    connection.Open();
                    resultDataSet.Fill(ds.Tables["PR_MED_TR_TBL"]);

                }
                finally
                {
                    connection.Close();
                }

                DataSetMapper<PatientRecordMedicalTreatmentsResponse> mapper = CreatePatientRecordMedicalTreatmentsMapper(accessMatrix, argument);
                PatientRecordMedicalTreatmentsResponse result = new PatientRecordMedicalTreatmentsResponse();

                mapper.Map(ds, result);

                return SigningUtils.CreateAndSign(
                    argument,
                    result,
                    accessMatrix,
                    aditionalParameters
                );
            }
            catch (Exception ex)
            {
                CustomLogError(aditionalParameters,argument.Serialize(),id.ToString(), ex);
                throw ex;
            }
        }

        public CommonSignedResponse<ReportExamsRequest, ReportExamsResponse> GetReportExams(ReportExamsRequest argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            CustomLog(aditionalParameters, argument.Serialize(), id.ToString());
            try
            {
                OracleConnection connection = new OracleConnection(ConnectionString.Value);
                DataSet ds = new DataSet();

                OracleCommand command = new OracleCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;

                command.CommandText = @"select * from table( ws_regix_patient_info.ahu_rep_exams( p_patient_ident_no => :p_patient_ident_no,
                                                          p_patient_ident_type => :p_patient_ident_type,
                                                          p_regix_context => :p_regix_context
                                                        ))";
                var p_patient_ident_no = new OracleParameter("p_patient_ident_no", OracleDbType.Varchar2, ParameterDirection.Input);
                p_patient_ident_no.Value = argument.Identifier;
                command.Parameters.Add(p_patient_ident_no);

                var p_patient_ident_type = new OracleParameter("p_parient_ident_type", OracleDbType.Varchar2, ParameterDirection.Input);
                p_patient_ident_type.Value = argument.IdentifierType == IdentifierType.EGN ? EgnInputParameter : LnchInputParamter;
                command.Parameters.Add(p_patient_ident_type);

                var p_regix_context = new OracleParameter("p_regix_context", OracleDbType.Varchar2, ParameterDirection.Input);
                p_regix_context.Value = aditionalParameters.CallContext.ToString();
                command.Parameters.Add(p_regix_context);

                OracleDataAdapter resultDataSet = new OracleDataAdapter(command);

                ds.Tables.Add("PR_EXAMS_TBL");

                try
                {
                    connection.Open();
                    resultDataSet.Fill(ds.Tables["PR_EXAMS_TBL"]);

                }
                finally
                {
                    connection.Close();
                }

                DataSetMapper<ReportExamsResponse> mapper = CreateReportExamsMapper(accessMatrix, argument);
                ReportExamsResponse result = new ReportExamsResponse();

                mapper.Map(ds, result);
                return SigningUtils.CreateAndSign(
                    argument,
                    result,
                    accessMatrix,
                    aditionalParameters
                );
            }
            catch (Exception ex)
            {
                CustomLogError(aditionalParameters,argument.Serialize(),id.ToString(), ex);
                throw ex;
            }
        }

        public CommonSignedResponse<PatientRecordLaboratoryRequest, PatientRecordLaboratoryResponse> GetPatientRecordLaboratory(PatientRecordLaboratoryRequest argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            CustomLog(aditionalParameters, argument.Serialize(), id.ToString());
            try
            {
                OracleConnection connection = new OracleConnection(ConnectionString.Value);
                DataSet ds = new DataSet();

                OracleCommand command = new OracleCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;

                command.CommandText = @"select * from table( ws_regix_patient_info.ahu_rep_labs(p_patient_ident_no => :p_patient_ident_no,
                                               p_patient_ident_type => :p_patient_ident_type,
                                               p_regix_context => :p_regix_context
                                              ))";
                var p_patient_ident_no = new OracleParameter("p_patient_ident_no", OracleDbType.Varchar2, ParameterDirection.Input);
                p_patient_ident_no.Value = argument.Identifier;
                command.Parameters.Add(p_patient_ident_no);

                var p_patient_ident_type = new OracleParameter("p_parient_ident_type", OracleDbType.Varchar2, ParameterDirection.Input);
                p_patient_ident_type.Value = argument.IdentifierType == IdentifierType.EGN ? EgnInputParameter : LnchInputParamter;
                command.Parameters.Add(p_patient_ident_type);


                var p_regix_context = new OracleParameter("p_regix_context", OracleDbType.Varchar2, ParameterDirection.Input);
                p_regix_context.Value = aditionalParameters.CallContext.ToString();
                command.Parameters.Add(p_regix_context);

                OracleDataAdapter resultDataSet = new OracleDataAdapter(command);

                ds.Tables.Add("PR_LABS_TBL");

                try
                {
                    connection.Open();
                    resultDataSet.Fill(ds.Tables["PR_LABS_TBL"]);

                }
                finally
                {
                    connection.Close();
                }

                DataSetMapper<PatientRecordLaboratoryResponse> mapper = CreatePatientRecordLaboratoryMapper(accessMatrix, argument);
                PatientRecordLaboratoryResponse result = new PatientRecordLaboratoryResponse();

                mapper.Map(ds, result);

                return SigningUtils.CreateAndSign(
                    argument,
                    result,
                    accessMatrix,
                    aditionalParameters
                );
            }
            catch (Exception ex)
            {
                CustomLogError(aditionalParameters,argument.Serialize(),id.ToString(), ex);
                throw ex;
            }
        }

        public CommonSignedResponse<PatientRecordHospitalizationsRequest, PatientRecordHospitalizationsResponse> GetPatientRecordHospitalizations(PatientRecordHospitalizationsRequest argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            CustomLog(aditionalParameters, argument.Serialize(), id.ToString());
            try
            {
                OracleConnection connection = new OracleConnection(ConnectionString.Value);
                DataSet ds = new DataSet();

                OracleCommand command = new OracleCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;

                command.CommandText = @"select * from table(ws_regix_patient_info.ahu_rep_hosp(p_patient_ident_no => :p_patient_ident_no,
                                                    p_patient_ident_type => :p_patient_ident_type,
                                                    p_regix_context => :p_regix_context))";
                var p_patient_ident_no = new OracleParameter("p_patient_ident_no", OracleDbType.Varchar2, ParameterDirection.Input);
                p_patient_ident_no.Value = argument.Identifier;
                command.Parameters.Add(p_patient_ident_no);

                var p_patient_ident_type = new OracleParameter("p_parient_ident_type", OracleDbType.Varchar2, ParameterDirection.Input);
                p_patient_ident_type.Value = argument.IdentifierType == IdentifierType.EGN ? EgnInputParameter : LnchInputParamter;
                command.Parameters.Add(p_patient_ident_type);


                var p_regix_context = new OracleParameter("p_regix_context", OracleDbType.Varchar2, ParameterDirection.Input);
                p_regix_context.Value = aditionalParameters.CallContext.ToString();
                command.Parameters.Add(p_regix_context);

                OracleDataAdapter resultDataSet = new OracleDataAdapter(command);

                ds.Tables.Add("PR_HOSP_TBL");

                try
                {
                    connection.Open();
                    resultDataSet.Fill(ds.Tables["PR_HOSP_TBL"]);

                }
                finally
                {
                    connection.Close();
                }

                DataSetMapper<PatientRecordHospitalizationsResponse> mapper = CreatePatientRecordHospitalizationsMapper(accessMatrix, argument);
                PatientRecordHospitalizationsResponse result = new PatientRecordHospitalizationsResponse();

                mapper.Map(ds, result);

                return SigningUtils.CreateAndSign(
                    argument,
                    result,
                    accessMatrix,
                    aditionalParameters
                );
            }
            catch (Exception ex)
            {
                CustomLogError(aditionalParameters,argument.Serialize(),id.ToString(), ex);
                throw ex;
            }
        }

        public CommonSignedResponse<PatientRecordDentalRequest, PatientRecordDentalResponse> GetPatientRecordDental(PatientRecordDentalRequest argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            CustomLog(aditionalParameters, argument.Serialize(), id.ToString());
            try
            {
                OracleConnection connection = new OracleConnection(ConnectionString.Value);
                DataSet ds = new DataSet();

                OracleCommand command = new OracleCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;

                command.CommandText = @"select * from table(ws_regix_patient_info.ahu_rep_dent(p_patient_ident_no => :p_patient_ident_no,
                                                    p_patient_ident_type => :p_patient_ident_type,
                                                    p_regix_context => :p_regix_context))";
                var p_patient_ident_no = new OracleParameter("p_patient_ident_no", OracleDbType.Varchar2, ParameterDirection.Input);
                p_patient_ident_no.Value = argument.Identifier;
                command.Parameters.Add(p_patient_ident_no);

                var p_patient_ident_type = new OracleParameter("p_parient_ident_type", OracleDbType.Varchar2, ParameterDirection.Input);
                p_patient_ident_type.Value = argument.IdentifierType == IdentifierType.EGN ? EgnInputParameter : LnchInputParamter;
                command.Parameters.Add(p_patient_ident_type);


                var p_regix_context = new OracleParameter("p_regix_context", OracleDbType.Varchar2, ParameterDirection.Input);
                p_regix_context.Value = aditionalParameters.CallContext.ToString();
                command.Parameters.Add(p_regix_context);

                OracleDataAdapter resultDataSet = new OracleDataAdapter(command);

                ds.Tables.Add("PR_DENT_TBL");

                try
                {
                    connection.Open();
                    resultDataSet.Fill(ds.Tables["PR_DENT_TBL"]);

                }
                finally
                {
                    connection.Close();
                }

                DataSetMapper<PatientRecordDentalResponse> mapper = CreatePatientRecordDentalMapper(accessMatrix, argument);
                PatientRecordDentalResponse result = new PatientRecordDentalResponse();

                mapper.Map(ds, result);

                return SigningUtils.CreateAndSign(
                    argument,
                    result,
                    accessMatrix,
                    aditionalParameters
                );
            }
            catch (Exception ex)
            {
                CustomLogError(aditionalParameters,argument.Serialize(),id.ToString(), ex);
                throw ex;
            }
        }

        public CommonSignedResponse<PatientRecordClinicalProceduresRequest, PatientRecordClinicalProceduresResponse> GetPatientRecordClinicalProcedures(PatientRecordClinicalProceduresRequest argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            CustomLog(aditionalParameters, argument.Serialize(), id.ToString());
            try
            {
                OracleConnection connection = new OracleConnection(ConnectionString.Value);
                DataSet ds = new DataSet();

                OracleCommand command = new OracleCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;

                command.CommandText = @"select * from table(ws_regix_patient_info.ahu_rep_hosp_cpr(p_patient_ident_no => :p_patient_ident_no,
                                                    p_patient_ident_type => :p_patient_ident_type,
                                                    p_regix_context => :p_regix_context))";

                var p_patient_ident_no = new OracleParameter("p_patient_ident_no", OracleDbType.Varchar2, ParameterDirection.Input);
                p_patient_ident_no.Value = argument.Identifier;
                command.Parameters.Add(p_patient_ident_no);

                var p_patient_ident_type = new OracleParameter("p_parient_ident_type", OracleDbType.Varchar2, ParameterDirection.Input);
                p_patient_ident_type.Value = argument.IdentifierType == IdentifierType.EGN ? EgnInputParameter : LnchInputParamter;
                command.Parameters.Add(p_patient_ident_type);


                var p_regix_context = new OracleParameter("p_regix_context", OracleDbType.Varchar2, ParameterDirection.Input);
                p_regix_context.Value = aditionalParameters.CallContext.ToString();
                command.Parameters.Add(p_regix_context);

                OracleDataAdapter resultDataSet = new OracleDataAdapter(command);

                ds.Tables.Add("PR_HOSP_CPR_TBL");

                try
                {
                    connection.Open();
                    resultDataSet.Fill(ds.Tables["PR_HOSP_CPR_TBL"]);

                }
                finally
                {
                    connection.Close();
                }

                DataSetMapper<PatientRecordClinicalProceduresResponse> mapper = CreatePatientRecordClinicalProceduresMapper(accessMatrix, argument);
                PatientRecordClinicalProceduresResponse result = new PatientRecordClinicalProceduresResponse();

                mapper.Map(ds, result);

                return SigningUtils.CreateAndSign(
                    argument,
                    result,
                    accessMatrix,
                    aditionalParameters
                );
            }
            catch (Exception ex)
            {
                CustomLogError(aditionalParameters,argument.Serialize(),id.ToString(), ex);
                throw ex;
            }
        }

        public CommonSignedResponse<PatientRecordDrugsbyClinicalProceduresRequest, PatientRecordDrugsbyClinicalProceduresResponse> GetPatientRecordDrugsbyClinicalProcedures(PatientRecordDrugsbyClinicalProceduresRequest argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            CustomLog(aditionalParameters, argument.Serialize(), id.ToString());
            try
            {
                OracleConnection connection = new OracleConnection(ConnectionString.Value);
                DataSet ds = new DataSet();

                OracleCommand command = new OracleCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;

                command.CommandText = @"select * from table(ws_regix_patient_info.ahu_rep_drug_cpr(p_patient_ident_no => :p_patient_ident_no,
                                                    p_patient_ident_type => :p_patient_ident_type,
                                                    p_regix_context => :p_regix_context))";

                var p_patient_ident_no = new OracleParameter("p_patient_ident_no", OracleDbType.Varchar2, ParameterDirection.Input);
                p_patient_ident_no.Value = argument.Identifier;
                command.Parameters.Add(p_patient_ident_no);

                var p_patient_ident_type = new OracleParameter("p_parient_ident_type", OracleDbType.Varchar2, ParameterDirection.Input);
                p_patient_ident_type.Value = argument.IdentifierType == IdentifierType.EGN ? EgnInputParameter : LnchInputParamter;
                command.Parameters.Add(p_patient_ident_type);


                var p_regix_context = new OracleParameter("p_regix_context", OracleDbType.Varchar2, ParameterDirection.Input);
                p_regix_context.Value = aditionalParameters.CallContext.ToString();
                command.Parameters.Add(p_regix_context);

                OracleDataAdapter resultDataSet = new OracleDataAdapter(command);

                ds.Tables.Add("PR_DRUG_CPR_TBL");

                try
                {
                    connection.Open();
                    resultDataSet.Fill(ds.Tables["PR_DRUG_CPR_TBL"]);

                }
                finally
                {
                    connection.Close();
                }

                DataSetMapper<PatientRecordDrugsbyClinicalProceduresResponse> mapper = CreatePatientRecordDrugsbyClinicalProceduresMapper(accessMatrix, argument);
                PatientRecordDrugsbyClinicalProceduresResponse result = new PatientRecordDrugsbyClinicalProceduresResponse();

                mapper.Map(ds, result);

                return SigningUtils.CreateAndSign(
                    argument,
                    result,
                    accessMatrix,
                    aditionalParameters
                );
            }
            catch (Exception ex)
            {
                CustomLogError(aditionalParameters,argument.Serialize(),id.ToString(), ex);
                throw ex;
            }
        }

        public CommonSignedResponse<PatientRecordDrugsByHospitalizationsRequest, PatientRecordDrugsByHospitalizationsResponse> GetPatientRecordDrugsByHospitalizations(PatientRecordDrugsByHospitalizationsRequest argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            CustomLog(aditionalParameters, argument.Serialize(), id.ToString());
            try
            {
                OracleConnection connection = new OracleConnection(ConnectionString.Value);
                DataSet ds = new DataSet();

                OracleCommand command = new OracleCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;

                command.CommandText = @"select * from table(ws_regix_patient_info.ahu_rep_drug_hosp(p_patient_ident_no => :p_patient_ident_no,
                                                    p_patient_ident_type => :p_patient_ident_type,
                                                    p_regix_context => :p_regix_context))";

                var p_patient_ident_no = new OracleParameter("p_patient_ident_no", OracleDbType.Varchar2, ParameterDirection.Input);
                p_patient_ident_no.Value = argument.Identifier;
                command.Parameters.Add(p_patient_ident_no);

                var p_patient_ident_type = new OracleParameter("p_parient_ident_type", OracleDbType.Varchar2, ParameterDirection.Input);
                p_patient_ident_type.Value = argument.IdentifierType == IdentifierType.EGN ? EgnInputParameter : LnchInputParamter;
                command.Parameters.Add(p_patient_ident_type);


                var p_regix_context = new OracleParameter("p_regix_context", OracleDbType.Varchar2, ParameterDirection.Input);
                p_regix_context.Value = aditionalParameters.CallContext.ToString();
                command.Parameters.Add(p_regix_context);

                OracleDataAdapter resultDataSet = new OracleDataAdapter(command);

                ds.Tables.Add("PR_DRUG_HOSP_TBL");

                try
                {
                    connection.Open();
                    resultDataSet.Fill(ds.Tables["PR_DRUG_HOSP_TBL"]);

                }
                finally
                {
                    connection.Close();
                }

                DataSetMapper<PatientRecordDrugsByHospitalizationsResponse> mapper = CreatePatientRecordDrugsByHospitalizationsMapper(accessMatrix, argument);
                PatientRecordDrugsByHospitalizationsResponse result = new PatientRecordDrugsByHospitalizationsResponse();

                mapper.Map(ds, result);

                return SigningUtils.CreateAndSign(
                    argument,
                    result,
                    accessMatrix,
                    aditionalParameters
                );
            }
            catch (Exception ex)
            {
                CustomLogError(aditionalParameters,argument.Serialize(),id.ToString(), ex);
                throw ex;
            }
        }


        private DataSetMapper<PatientRecordMedicalTreatmentsResponse> CreatePatientRecordMedicalTreatmentsMapper(AccessMatrix accessMatrix, PatientRecordMedicalTreatmentsRequest request)
        {
            DataSetMapper<PatientRecordMedicalTreatmentsResponse> mapper = new DataSetMapper<PatientRecordMedicalTreatmentsResponse>(accessMatrix);
            mapper.AddDataSetMap((r) => r.PatientRecordMedicalTreatments, (d) => d.Tables["PR_MED_TR_TBL"].Rows);

            mapper.AddConstantMap((r) => r.PatientRecordMedicalTreatments[0].PatientIdentificator, request.Identifier);

            mapper.AddDataColumnMap((r) => r.PatientRecordMedicalTreatments[0].Pharmacy.MSPCode, "PHARM_MSP_CODE");
            mapper.AddDataColumnMap((r) => r.PatientRecordMedicalTreatments[0].Pharmacy.MSPName, "PHARM_MSP_NAME");
            mapper.AddDataColumnMap((r) => r.PatientRecordMedicalTreatments[0].Pharmacy.Address, "PHARM_ADDRESS");

            mapper.AddDataColumnMap((r) => r.PatientRecordMedicalTreatments[0].Prescription.PresctiptionNumber, "PRESCRIPTION_NO_PHARM");
            mapper.AddDataColumnMap((r) => r.PatientRecordMedicalTreatments[0].Prescription.PresctiptionDate, "PRESCRIPTION_DATE");

            mapper.AddDataColumnMap((r) => r.PatientRecordMedicalTreatments[0].ICD.ICDCode, "ICD_CODE");
            mapper.AddDataColumnMap((r) => r.PatientRecordMedicalTreatments[0].ICD.ICDName, "ICD_NAME");


            mapper.AddDataColumnMap((r) => r.PatientRecordMedicalTreatments[0].Practitioner.PractitionerUIN, "PRACTITIONER_UIN");
            mapper.AddDataColumnMap((r) => r.PatientRecordMedicalTreatments[0].Practitioner.PractitionerNames, "PRACTITIONER_NAMES");

            mapper.AddDataColumnMap((r) => r.PatientRecordMedicalTreatments[0].Sender.MSPCode, "MSP_CODE");
            mapper.AddDataColumnMap((r) => r.PatientRecordMedicalTreatments[0].Sender.MSPName, "MSP_NAME");

            mapper.AddDataColumnMap((r) => r.PatientRecordMedicalTreatments[0].DispensedDate, "DISPENSED_DATE");
            mapper.AddDataColumnMap((r) => r.PatientRecordMedicalTreatments[0].MedicalSupply.MedicalSupplyCode, "MEDICAL_SUPPLY_CODE");
            mapper.AddDataColumnMap((r) => r.PatientRecordMedicalTreatments[0].MedicalSupply.MedicalSupplyDescription, "MEDICAL_SUPPLY_DESCR");
            mapper.AddDataColumnMap((r) => r.PatientRecordMedicalTreatments[0].PrescribedQuantity, "PRESCRIBED_QUANTITY");
            mapper.AddDataColumnMap((r) => r.PatientRecordMedicalTreatments[0].UnitPrice, "UNIT_PRICE");
            mapper.AddDataColumnMap((r) => r.PatientRecordMedicalTreatments[0].Price, "PRICE");
            return mapper;
        }

        private DataSetMapper<ReportExamsResponse> CreateReportExamsMapper(AccessMatrix accessMatrix, ReportExamsRequest request)
        {
            DataSetMapper<ReportExamsResponse> mapper = new DataSetMapper<ReportExamsResponse>(accessMatrix);
            mapper.AddDataSetMap((r) => r.ReportExams, (d) => d.Tables["PR_EXAMS_TBL"].Rows);
            mapper.AddConstantMap((r) => r.ReportExams[0].PatientIdentificator, request.Identifier);

            mapper.AddDataColumnMap((r) => r.ReportExams[0].BranchName, "BRANCH_NAME");

            mapper.AddDataColumnMap((r) => r.ReportExams[0].Practitioner.UINNumber, "UIN_NUMBER");
            mapper.AddDataColumnMap((r) => r.ReportExams[0].Practitioner.PractitionerName, "PRACTITIONER_NAME");
            mapper.AddDataColumnMap((r) => r.ReportExams[0].Practitioner.PractitionerSpecialityCode, "PRA_SPEC_CODE");
            mapper.AddDataColumnMap((r) => r.ReportExams[0].Practitioner.PractitionerSpecialityName, "PRA_SPEC_NAME");

            mapper.AddDataColumnMap((r) => r.ReportExams[0].MSP.MSPCode, "MSP_CODE");
            mapper.AddDataColumnMap((r) => r.ReportExams[0].MSP.MSPName, "MSP_NAME");

            mapper.AddDataColumnMap((r) => r.ReportExams[0].AmbulatoryList.AmbulatoryListNumber, "AMB_LIST_NO");
            mapper.AddDataColumnMap((r) => r.ReportExams[0].AmbulatoryList.AmbulatoryListDate, "AMB_LIST_DATE");

            mapper.AddDataColumnMap((r) => r.ReportExams[0].ExamType, "EXAM_TYPE");

            mapper.AddDataColumnMap((r) => r.ReportExams[0].ICD.MainICD.MainICDCode, "MAIN_ICD_CODE");
            mapper.AddDataColumnMap((r) => r.ReportExams[0].ICD.MainICD.MainICDName, "MAIN_ICD_NAME");
            mapper.AddDataColumnMap((r) => r.ReportExams[0].ICD.AttachedICD.AttachedICDCode, "ATT_ICD_CODE");
            mapper.AddDataColumnMap((r) => r.ReportExams[0].ICD.AttachedICD.AttachedICDName, "ATT_ICD_NAME");
            mapper.AddDataColumnMap((r) => r.ReportExams[0].ImmunisationsInfo, "IMMUNISATIONS_INFO");
            mapper.AddDataColumnMap((r) => r.ReportExams[0].VSDInfo, "VSD_INFO");




            return mapper;
        }

        private DataSetMapper<PatientRecordLaboratoryResponse> CreatePatientRecordLaboratoryMapper(AccessMatrix accessMatrix, PatientRecordLaboratoryRequest request)
        {
            DataSetMapper<PatientRecordLaboratoryResponse> mapper = new DataSetMapper<PatientRecordLaboratoryResponse>(accessMatrix);
            mapper.AddDataSetMap((r) => r.PatientRecordLaboratories, (d) => d.Tables["PR_LABS_TBL"].Rows);
            mapper.AddConstantMap((r) => r.PatientRecordLaboratories[0].PatientIdentificator, request.Identifier);

            mapper.AddDataColumnMap((r) => r.PatientRecordLaboratories[0].BranchName, "BRANCH_NAME");


            mapper.AddDataColumnMap((r) => r.PatientRecordLaboratories[0].Lab.MSPCode, "LAB_MSP_CODE");
            mapper.AddDataColumnMap((r) => r.PatientRecordLaboratories[0].Lab.MSPName, "LAB_MSP_NAME");
            mapper.AddDataColumnMap((r) => r.PatientRecordLaboratories[0].Lab.UINNumber, "LAB_UIN_NUMBER");
            mapper.AddDataColumnMap((r) => r.PatientRecordLaboratories[0].Lab.PractitionerSpecialityCode, "LAB_PRA_SPEC_CODE");
            mapper.AddDataColumnMap((r) => r.PatientRecordLaboratories[0].Lab.PractitionerSpecialityName, "LAB_PRA_SPEC_NAME");
            mapper.AddDataColumnMap((r) => r.PatientRecordLaboratories[0].Lab.PractitioneerName, "LAB_PRACTITIONER_NAME");

            mapper.AddDataColumnMap((r) => r.PatientRecordLaboratories[0].MSP.MSPCode, "MSP_CODE");
            mapper.AddDataColumnMap((r) => r.PatientRecordLaboratories[0].MSP.MSPName, "MSP_NAME");

            mapper.AddDataColumnMap((r) => r.PatientRecordLaboratories[0].Practitioner.UINNumber, "UIN_NUMBER");
            mapper.AddDataColumnMap((r) => r.PatientRecordLaboratories[0].Practitioner.PractitionerName, "PRACTITIONER_NAME");
            mapper.AddDataColumnMap((r) => r.PatientRecordLaboratories[0].Practitioner.PractitionerSpecialityCode, "PRA_SPEC_CODE");
            mapper.AddDataColumnMap((r) => r.PatientRecordLaboratories[0].Practitioner.PractitionerSpecialityName, "PRA_SPEC_NAME");

            mapper.AddDataColumnMap((r) => r.PatientRecordLaboratories[0].AmbulatoryList.AmbulatoryListNumber, "AMB_LIST_NO");
            mapper.AddDataColumnMap((r) => r.PatientRecordLaboratories[0].AmbulatoryList.AmbulatoryListDate, "AMB_LIST_DATE");

            mapper.AddDataColumnMap((r) => r.PatientRecordLaboratories[0].ReferralNumber, "REFERRAL_NO");

            mapper.AddDataColumnMap((r) => r.PatientRecordLaboratories[0].Observation.ObservationCode, "OBSERV_CODE");
            mapper.AddDataColumnMap((r) => r.PatientRecordLaboratories[0].Observation.ObservationName, "OBSERV_NAME");

            mapper.AddDataColumnMap((r) => r.PatientRecordLaboratories[0].ActivityDate, "ACTIVITY_DATE");

            return mapper;

        }

        private DataSetMapper<PatientRecordHospitalizationsResponse> CreatePatientRecordHospitalizationsMapper(AccessMatrix accessMatrix, PatientRecordHospitalizationsRequest request)
        {
            DataSetMapper<PatientRecordHospitalizationsResponse> mapper = new DataSetMapper<PatientRecordHospitalizationsResponse>(accessMatrix);
            mapper.AddDataSetMap((r) => r.PatientRecordHospitalizations, (d) => d.Tables["PR_HOSP_TBL"].Rows);
            mapper.AddConstantMap((r) => r.PatientRecordHospitalizations[0].PatientIdentificator, request.Identifier);

            mapper.AddDataColumnMap((r) => r.PatientRecordHospitalizations[0].BranchName, "BRANCH_NAME");

            mapper.AddDataColumnMap((r) => r.PatientRecordHospitalizations[0].MSP.MSPCode, "MSP_CODE");
            mapper.AddDataColumnMap((r) => r.PatientRecordHospitalizations[0].MSP.MSPName, "MSP_NAME");

            mapper.AddDataColumnMap((r) => r.PatientRecordHospitalizations[0].ClinicalPath.ClinicalPathCode, "CLIN_PATH_CODE");
            mapper.AddDataColumnMap((r) => r.PatientRecordHospitalizations[0].ClinicalPath.ClinicalPathName, "CLIN_PATH_NAME");

            mapper.AddDataColumnMap((r) => r.PatientRecordHospitalizations[0].ICD.MainICD.ICDCode, "MAIN_ICD_CODE");
            mapper.AddDataColumnMap((r) => r.PatientRecordHospitalizations[0].ICD.MainICD.ICDName, "MAIN_ICD_NAME");
            mapper.AddDataColumnMap((r) => r.PatientRecordHospitalizations[0].ICD.AttachedICD1.AttachedICD1Code, "ATT_ICD_1_CODE");
            mapper.AddDataColumnMap((r) => r.PatientRecordHospitalizations[0].ICD.AttachedICD1.AttachedICD1Name, "ATT_ICD_1_NAME");
            mapper.AddDataColumnMap((r) => r.PatientRecordHospitalizations[0].ICD.AttachedICD2.AttachedICD2Code, "ATT_ICD_2_CODE");
            mapper.AddDataColumnMap((r) => r.PatientRecordHospitalizations[0].ICD.AttachedICD2.AttachedICD2Name, "ATT_ICD_2_NAME");
            mapper.AddDataColumnMap((r) => r.PatientRecordHospitalizations[0].ICD.AttachedICD3.AttachedICD3Code, "ATT_ICD_3_CODE");
            mapper.AddDataColumnMap((r) => r.PatientRecordHospitalizations[0].ICD.AttachedICD3.AttachedICD3Name, "ATT_ICD_3_NAME");

            mapper.AddDataColumnMap((r) => r.PatientRecordHospitalizations[0].DateFrom, "DATE_FROM");
            mapper.AddDataColumnMap((r) => r.PatientRecordHospitalizations[0].DateTo, "DATE_TO");

            mapper.AddDataColumnMap((r) => r.PatientRecordHospitalizations[0].BedDays, "BED_DAYS");

            mapper.AddDataColumnMap((r) => r.PatientRecordHospitalizations[0].ImplantsInfo, "IMPLANTS_INFO");

            return mapper;
        }

        private DataSetMapper<PatientRecordDentalResponse> CreatePatientRecordDentalMapper(AccessMatrix accessMatrix, PatientRecordDentalRequest request)
        {
            DataSetMapper<PatientRecordDentalResponse> mapper = new DataSetMapper<PatientRecordDentalResponse>(accessMatrix);
            mapper.AddDataSetMap((r) => r.PatientRecordDentals, (d) => d.Tables["PR_DENT_TBL"].Rows);
            mapper.AddConstantMap((r) => r.PatientRecordDentals[0].PatientIdentificator, request.Identifier);

            mapper.AddDataColumnMap((r) => r.PatientRecordDentals[0].BranchName, "BRANCH_NAME");

            mapper.AddDataColumnMap((r) => r.PatientRecordDentals[0].MSP.MSPCode, "MSP_CODE");
            mapper.AddDataColumnMap((r) => r.PatientRecordDentals[0].MSP.MSPName, "MSP_NAME");

            mapper.AddDataColumnMap((r) => r.PatientRecordDentals[0].Practitioner.UINNumber, "UIN_NUMBER");
            mapper.AddDataColumnMap((r) => r.PatientRecordDentals[0].Practitioner.PractitionerName, "PRACTITIONER_NAME");
            mapper.AddDataColumnMap((r) => r.PatientRecordDentals[0].Practitioner.PractitionerSpecialityCode, "PRA_SPEC_CODE");
            mapper.AddDataColumnMap((r) => r.PatientRecordDentals[0].Practitioner.PractitionerSpecialityName, "PRA_SPEC_NAME");

            mapper.AddDataColumnMap((r) => r.PatientRecordDentals[0].DeputyPractitioner.UINNumber, "DEP_UIN_NUMBER");
            mapper.AddDataColumnMap((r) => r.PatientRecordDentals[0].DeputyPractitioner.PractitionerName, "DEP_PRACTITIONER_NAME");
            mapper.AddDataColumnMap((r) => r.PatientRecordDentals[0].DeputyPractitioner.PractitionerSpecialityCode, "DEP_PRA_SPEC_CODE");
            mapper.AddDataColumnMap((r) => r.PatientRecordDentals[0].DeputyPractitioner.PractitionerSpecialityName, "DEP_PRA_SPEC_NAME");

            mapper.AddDataColumnMap((r) => r.PatientRecordDentals[0].AmbulatoryListNumber, "AMB_LIST_NO");

            mapper.AddDataColumnMap((r) => r.PatientRecordDentals[0].DentalActivity.ActivityDate, "ACTIVITY_DATE");
            mapper.AddDataColumnMap((r) => r.PatientRecordDentals[0].DentalActivity.DentalActivityCode, "DENTAL_ACTIVITY_CODE");
            mapper.AddDataColumnMap((r) => r.PatientRecordDentals[0].DentalActivity.DentalActivityName, "DENTAL_ACTIVITY_NAME");

            mapper.AddDataColumnMap((r) => r.PatientRecordDentals[0].ToothCode, "TOOTH_CODE");

            mapper.AddDataColumnMap((r) => r.PatientRecordDentals[0].Price, "PRICE");

            return mapper;
        }

        private DataSetMapper<PatientRecordClinicalProceduresResponse> CreatePatientRecordClinicalProceduresMapper(AccessMatrix accessMatrix, PatientRecordClinicalProceduresRequest request)
        {
            DataSetMapper<PatientRecordClinicalProceduresResponse> mapper = new DataSetMapper<PatientRecordClinicalProceduresResponse>(accessMatrix);
            mapper.AddDataSetMap((r) => r.PatientRecordClinicalProcedures, (d) => d.Tables["PR_HOSP_CPR_TBL"].Rows);
            mapper.AddConstantMap((r) => r.PatientRecordClinicalProcedures[0].PatientIdentificator, request.Identifier);

            mapper.AddDataColumnMap((r) => r.PatientRecordClinicalProcedures[0].BranchName, "BRANCH_NAME");

            mapper.AddDataColumnMap((r) => r.PatientRecordClinicalProcedures[0].MSP.MSPCode, "MSP_CODE");
            mapper.AddDataColumnMap((r) => r.PatientRecordClinicalProcedures[0].MSP.MSPName, "MSP_NAME");

            mapper.AddDataColumnMap((r) => r.PatientRecordClinicalProcedures[0].ActivityDate, "ACTIVITY_DATE");

            mapper.AddDataColumnMap((r) => r.PatientRecordClinicalProcedures[0].ClinicalProcedure.ClinicalProcedureCode, "CLIN_PROC_CODE");
            mapper.AddDataColumnMap((r) => r.PatientRecordClinicalProcedures[0].ClinicalProcedure.ClinicalProcedureName, "CLIN_PROC_NAME");

            mapper.AddDataColumnMap((r) => r.PatientRecordClinicalProcedures[0].ICD.ICDClinicalManipulationCode, "ICD_CM_CODE");
            mapper.AddDataColumnMap((r) => r.PatientRecordClinicalProcedures[0].ICD.ICDClinicalManipulationName, "ICD_CM_NAME");

            mapper.AddDataColumnMap((r) => r.PatientRecordClinicalProcedures[0].Price, "PRICE");

            return mapper;
        }

        private DataSetMapper<PatientRecordDrugsbyClinicalProceduresResponse> CreatePatientRecordDrugsbyClinicalProceduresMapper(AccessMatrix accessMatrix, PatientRecordDrugsbyClinicalProceduresRequest request)
        {
            DataSetMapper<PatientRecordDrugsbyClinicalProceduresResponse> mapper = new DataSetMapper<PatientRecordDrugsbyClinicalProceduresResponse>(accessMatrix);
            mapper.AddDataSetMap((r) => r.PatientRecordDrugsbyClinicalProcedures, (d) => d.Tables["PR_DRUG_CPR_TBL"].Rows);
            mapper.AddConstantMap((r) => r.PatientRecordDrugsbyClinicalProcedures[0].PatientIdentificator, request.Identifier);

            mapper.AddDataColumnMap((r) => r.PatientRecordDrugsbyClinicalProcedures[0].MSP.MSPCode, "MSP_CODE");
            mapper.AddDataColumnMap((r) => r.PatientRecordDrugsbyClinicalProcedures[0].MSP.MSPName, "MSP_NAME");

            mapper.AddDataColumnMap((r) => r.PatientRecordDrugsbyClinicalProcedures[0].DispensedDate, "DISPENSED_DATE");

            mapper.AddDataColumnMap((r) => r.PatientRecordDrugsbyClinicalProcedures[0].ClinicalProcedure.ClinicalProcedureCode, "CLIN_PROC_CODE");
            mapper.AddDataColumnMap((r) => r.PatientRecordDrugsbyClinicalProcedures[0].ClinicalProcedure.ClinicalProcedureName, "CLIN_PROC_NAME");

            mapper.AddDataColumnMap((r) => r.PatientRecordDrugsbyClinicalProcedures[0].MedicalSupply.MedicalSupplyCode, "MEDICAL_SUPPLY_CODE");
            mapper.AddDataColumnMap((r) => r.PatientRecordDrugsbyClinicalProcedures[0].MedicalSupply.MedicalSupplyName, "MEDICAL_SUPPLY_NAME");

            mapper.AddDataColumnMap((r) => r.PatientRecordDrugsbyClinicalProcedures[0].Price, "PRICE");

            return mapper;
        }

        private DataSetMapper<PatientRecordDrugsByHospitalizationsResponse> CreatePatientRecordDrugsByHospitalizationsMapper(AccessMatrix accessMatrix, PatientRecordDrugsByHospitalizationsRequest request)
        {
            DataSetMapper<PatientRecordDrugsByHospitalizationsResponse> mapper = new DataSetMapper<PatientRecordDrugsByHospitalizationsResponse>(accessMatrix);
            mapper.AddDataSetMap((r) => r.PatientRecordDrugsByHospitalizations, (d) => d.Tables["PR_DRUG_HOSP_TBL"].Rows);
            mapper.AddConstantMap((r) => r.PatientRecordDrugsByHospitalizations[0].PatientIdentificator, request.Identifier);

            mapper.AddDataColumnMap((r) => r.PatientRecordDrugsByHospitalizations[0].MSP.MSPCode, "MSP_CODE");
            mapper.AddDataColumnMap((r) => r.PatientRecordDrugsByHospitalizations[0].MSP.MSPName, "MSP_NAME");

            mapper.AddDataColumnMap((r) => r.PatientRecordDrugsByHospitalizations[0].DeceaseHistoryNumber, "DECEASE_HISTORY_NO");

            mapper.AddDataColumnMap((r) => r.PatientRecordDrugsByHospitalizations[0].DateFrom, "DATE_FROM");
            mapper.AddDataColumnMap((r) => r.PatientRecordDrugsByHospitalizations[0].DateTo, "DATE_TO");

            mapper.AddDataColumnMap((r) => r.PatientRecordDrugsByHospitalizations[0].DispensedDate, "DISPENSED_DATE");

            mapper.AddDataColumnMap((r) => r.PatientRecordDrugsByHospitalizations[0].ClinicalPath.ClinicalPathCode, "CLIN_PATH_CODE");
            mapper.AddDataColumnMap((r) => r.PatientRecordDrugsByHospitalizations[0].ClinicalPath.ClinicalPathName, "CLIN_PATH_NAME");

            mapper.AddDataColumnMap((r) => r.PatientRecordDrugsByHospitalizations[0].MedicalSupply.MedicalSupplyCode, "MEDICAL_SUPPLY_CODE");
            mapper.AddDataColumnMap((r) => r.PatientRecordDrugsByHospitalizations[0].MedicalSupply.MedicalSupplyName, "MEDICAL_SUPPLY_NAME");

            mapper.AddDataColumnMap((r) => r.PatientRecordDrugsByHospitalizations[0].Price, "PRICE");

            return mapper;
        }

        private void CustomLog(AdapterAdditionalParameters adapterAdditionalParameters,string argument ,string id )
        {
            var directory = AppDomain.CurrentDomain.BaseDirectory;
            var path = System.IO.Path.Combine(directory, "custom_log.txt");
            //System.IO.File.AppendAllText(path, text + "\n");
            string date = DateTime.Now.ToString();
            StackTrace stackTrace = new StackTrace();
            System.Reflection.MethodBase operationMethod = stackTrace.GetFrame(1).GetMethod();
            if (adapterAdditionalParameters != null)
            {
                string log = new
                {
                    RequestDate = date,
                    MethodName = operationMethod.Name,
                    CallId = adapterAdditionalParameters.ApiServiceCallId,
                    CallContext = adapterAdditionalParameters.CallContext,
                    ClientIPAddress = adapterAdditionalParameters.ClientIPAddress,
                    EIDToken = adapterAdditionalParameters.EIDToken,
                    OrganizationUnit = adapterAdditionalParameters.OrganizationUnit,
                    CitizenEGN = adapterAdditionalParameters.CitizenEGN,
                    ConsumerCertificateThumbprint = adapterAdditionalParameters.ConsumerCertificateThumbprint,
                    EmployeeEGN = adapterAdditionalParameters.EmployeeEGN,
                    OrganizationEIK = adapterAdditionalParameters.OrganizationEIK,
                    SignResult = adapterAdditionalParameters.SignResult,
                    ReturnAccessMatrix = adapterAdditionalParameters.ReturnAccessMatrix,
                    Guid = id != null ? id : String.Empty,
                    OtherData = argument != null ? argument : string.Empty
                }.ToString();
                try
                {
                    System.IO.File.AppendAllText(path, log + Environment.NewLine);
                }
                catch (Exception e)
                {

                    LogData(adapterAdditionalParameters, new { Request = argument, Guid = id });
                }
               
            }
        }

        private void CustomLogError(AdapterAdditionalParameters adapterAdditionalParameters, string argument, string id, Exception ex)
        {
            var directory = AppDomain.CurrentDomain.BaseDirectory;
            var path = System.IO.Path.Combine(directory, "custom_log_errors.txt");
            string date = DateTime.Now.ToString();

            StackTrace stackTrace = new StackTrace();
            System.Reflection.MethodBase operationMethod = stackTrace.GetFrame(1).GetMethod();
            string logError =
                 new
                 {
                     RequestDate = date,
                     MethodName = operationMethod.Name,
                     CallId = adapterAdditionalParameters.ApiServiceCallId,
                     CallContext = adapterAdditionalParameters.CallContext,
                     ClientIPAddress = adapterAdditionalParameters.ClientIPAddress,
                     EIDToken = adapterAdditionalParameters.EIDToken,
                     OrganizationUnit = adapterAdditionalParameters.OrganizationUnit,
                     CitizenEGN = adapterAdditionalParameters.CitizenEGN,
                     ConsumerCertificateThumbprint = adapterAdditionalParameters.ConsumerCertificateThumbprint,
                     EmployeeEGN = adapterAdditionalParameters.EmployeeEGN,
                     OrganizationEIK = adapterAdditionalParameters.OrganizationEIK,
                     SignResult = adapterAdditionalParameters.SignResult,
                     ReturnAccessMatrix = adapterAdditionalParameters.ReturnAccessMatrix,
                     Guid = id != null ? id : String.Empty,
                     OtherData = argument != null ? argument : string.Empty,
                     ExceptionText = ex
                 }.ToString();
            try
            {
                System.IO.File.AppendAllText(path, logError + Environment.NewLine);
            }
            catch (Exception e)
            {

                LogError(adapterAdditionalParameters,ex, new { Guid = id });
            }
            
        }
    }
}
