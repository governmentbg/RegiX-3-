using System;
using System.Linq;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.Common.Utils;
using System.Data;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.OracleAdapterService;
using System.Globalization;
using Oracle.ManagedDataAccess.Client;
using TechnoLogica.RegiX.Adapters.Common.DataContracts;
using TechnoLogica.RegiX.Common.DataContracts.Parameter;
using TechnoLogica.RegiX.Adapters.Common.ObjectMapping;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;

namespace TechnoLogica.RegiX.ASPSocialAdapter.AdapterService
{
    [Export(typeof(IAdapterService))]
    [ExportFullName(typeof(ASPSocialAdapter), typeof(IAdapterService))]
    [ExportSimpleName(typeof(ASPSocialAdapter), typeof(IAdapterService))]
    public class ASPSocialAdapter : OracleBaseAdapterService, IASPSocialAdapter, IAdapterService
    {
        private const string EgnInputParameter = "E";
        private const string LnchInputParamter = "L";

        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(ASPSocialAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> ConnectionString =
            new ParameterInfo<string>(@"Data Source=ip:port/path;User ID=;Password=;")
            {
                Key = Constants.ConnectionStringParameterKeyName,
                Description = "Connection string",
                OwnerAssembly = typeof(ASPSocialAdapter).Assembly
            };
        //---
        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(ASPSocialAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> ConnectionStringPeopleWithDisabilities =
            new ParameterInfo<string>(@"Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=IP)(PORT=1521))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=aspiis.ad.tlogica.com)));User ID=;Password=;")
            {
                Key = "ConnectionStringPeopleWithDisabilities",
                Description = "ConnectionStringPeopleWithDisabilities",
                OwnerAssembly = typeof(ASPSocialAdapter).Assembly
            };

        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(ASPSocialAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> GetBenefitsProcedureName =
            new ParameterInfo<string>("ahu_routines.get_benefits")
            {
                Key = "GetBenefitsProcedureName",
                Description = "the procedure which is called by ....()",
                OwnerAssembly = typeof(ASPSocialAdapter).Assembly
            };
//---
        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(ASPSocialAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> MonthlySocialBenefitsProcedureName =
            new ParameterInfo<string>("regix_routines.get_monthly_social_benefits")
            {
                Key = "MonthlySocialBenefitsProcedureName",
                Description = "the procedure which is called by GetMonthlySocialBenefits()",
                OwnerAssembly = typeof(ASPSocialAdapter).Assembly
            };

        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(ASPSocialAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> BenefitsForHeatingProcedureName =
            new ParameterInfo<string>("regix_routines.get_benefits_for_heating")
            {
                Key = "BenefitsForHeatingProcedureName",
                Description = "the procedure which is called by GetBenefitsForHeating()",
                OwnerAssembly = typeof(ASPSocialAdapter).Assembly
            };

        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(ASPSocialAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> SocialServicesDecisionsProcedureName =
            new ParameterInfo<string>("regix_routines.get_social_services_decisions")
            {
                Key = "SocialServicesDecisionsProcedureName",
                Description = "the procedure which is called by GetSocialServicesDecisions()",
                OwnerAssembly = typeof(ASPSocialAdapter).Assembly
            };

        public CommonSignedResponse<GetMonthlySocialBenefitsRequest, GetMonthlySocialBenefitsResponseType> GetMonthlySocialBenefits(GetMonthlySocialBenefitsRequest argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
            try
            {
                OracleConnection connection = new OracleConnection(ConnectionString.Value);
                DataSet ds = new DataSet();

                OracleCommand command = new OracleCommand();
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;

                command.CommandText = MonthlySocialBenefitsProcedureName.Value;

                string p_id_type = (argument.PersonData.IdentifierType == IdentifierType.EGN) ? EgnInputParameter : LnchInputParamter;
                command.Parameters.Add(new OracleParameter("p_id_type", OracleDbType.Varchar2, p_id_type, ParameterDirection.Input));

                string p_id = argument.PersonData.Identifier;
                command.Parameters.Add(new OracleParameter("p_id", OracleDbType.Varchar2, p_id, ParameterDirection.Input));
                
                OracleParameter p_out_person = new OracleParameter();
                p_out_person.Direction = ParameterDirection.Output;
                p_out_person.ParameterName = "p_out_person";
                p_out_person.OracleDbType = OracleDbType.RefCursor;
                command.Parameters.Add(p_out_person);

                OracleParameter p_out_decisions = new OracleParameter();
                p_out_decisions.Direction = ParameterDirection.Output;
                p_out_decisions.ParameterName = "p_out_decisions";
                p_out_decisions.OracleDbType = OracleDbType.RefCursor;
                command.Parameters.Add(p_out_decisions);

                string p_req_no = aditionalParameters.ApiServiceCallId.ToString();
                command.Parameters.Add(new OracleParameter("p_req_no", OracleDbType.Varchar2, p_req_no, ParameterDirection.Input));

                string p_user = this.CreateUserText(aditionalParameters);
                command.Parameters.Add(new OracleParameter("p_user", OracleDbType.Varchar2, p_user, ParameterDirection.Input));

                OracleDataAdapter resultDataSet = new OracleDataAdapter(command);
                try
                {
                    connection.Open();
                    resultDataSet.Fill(ds);
                    ds.Tables[0].TableName = "p_out_person";
                    ds.Tables[1].TableName = "p_out_decisions";
                }
                finally
                {
                    connection.Close();
                }

                DataSetMapper<GetMonthlySocialBenefitsResponseType> mapper = CreateGetMonthlySocialBenefitsMapper(accessMatrix, argument);
                GetMonthlySocialBenefitsResponseType result = new GetMonthlySocialBenefitsResponseType();
                result.CurrentTime = DateTime.Now;
                result.CurrentTimeSpecified = true;
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
                LogError(aditionalParameters, ex, new { Guid = id });
                throw ex;
            }
        }

        public CommonSignedResponse<GetBenefitsForHeatingRequest, GetBenefitsForHeatingResponseType> GetBenefitsForHeating(GetBenefitsForHeatingRequest argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
            try
            {
                OracleConnection connection = new OracleConnection(ConnectionString.Value);
                DataSet ds = new DataSet();

                OracleCommand command = new OracleCommand();
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;

                command.CommandText = BenefitsForHeatingProcedureName.Value;

                string p_id_type = (argument.PersonData.IdentifierType == IdentifierType.EGN) ? EgnInputParameter : LnchInputParamter;
                command.Parameters.Add(new OracleParameter("p_id_type", OracleDbType.Varchar2, p_id_type, ParameterDirection.Input));

                string p_id = argument.PersonData.Identifier;
                command.Parameters.Add(new OracleParameter("p_id", OracleDbType.Varchar2, p_id, ParameterDirection.Input));

                OracleParameter p_out_person = new OracleParameter();
                p_out_person.Direction = ParameterDirection.Output;
                p_out_person.ParameterName = "p_out_person";
                p_out_person.OracleDbType = OracleDbType.RefCursor;
                command.Parameters.Add(p_out_person);

                OracleParameter p_out_decisions = new OracleParameter();
                p_out_decisions.Direction = ParameterDirection.Output;
                p_out_decisions.ParameterName = "p_out_decisions";
                p_out_decisions.OracleDbType = OracleDbType.RefCursor;
                command.Parameters.Add(p_out_decisions);

                string p_req_no = aditionalParameters.ApiServiceCallId.ToString();
                command.Parameters.Add(new OracleParameter("p_req_no", OracleDbType.Varchar2, p_req_no, ParameterDirection.Input));

                string p_user = this.CreateUserText(aditionalParameters);
                command.Parameters.Add(new OracleParameter("p_user", OracleDbType.Varchar2, p_user, ParameterDirection.Input));

                OracleDataAdapter resultDataSet = new OracleDataAdapter(command);
                try
                {
                    connection.Open();
                    resultDataSet.Fill(ds);
                    ds.Tables[0].TableName = "p_out_person";
                    ds.Tables[1].TableName = "p_out_decisions";
                }
                finally
                {
                    connection.Close();
                }

                DataSetMapper<GetBenefitsForHeatingResponseType> mapper = CreateGetBenefitsForHeatingMapper(accessMatrix, argument);
                GetBenefitsForHeatingResponseType result = new GetBenefitsForHeatingResponseType();
                result.CurrentTime = DateTime.Now;
                result.CurrentTimeSpecified = true;
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
                LogError(aditionalParameters, ex, new { Guid = id });
                throw ex;
            }
        }

        public CommonSignedResponse<GetSocialServicesDecisionsRequest, GetSocialServicesDecisionsResponseType> GetSocialServicesDecisions(GetSocialServicesDecisionsRequest argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
            try
            {
                OracleConnection connection = new OracleConnection(ConnectionString.Value);
                DataSet ds = new DataSet();

                OracleCommand command = new OracleCommand();
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;

                command.CommandText = SocialServicesDecisionsProcedureName.Value;

                string p_id_type = (argument.PersonData.IdentifierType == IdentifierType.EGN) ? EgnInputParameter : LnchInputParamter;
                command.Parameters.Add(new OracleParameter("p_id_type", OracleDbType.Varchar2, p_id_type, ParameterDirection.Input));

                string p_id = argument.PersonData.Identifier;
                command.Parameters.Add(new OracleParameter("p_id", OracleDbType.Varchar2, p_id, ParameterDirection.Input));

                OracleParameter p_out_person = new OracleParameter();
                p_out_person.Direction = ParameterDirection.Output;
                p_out_person.ParameterName = "p_out_person";
                p_out_person.OracleDbType = OracleDbType.RefCursor;
                command.Parameters.Add(p_out_person);

                OracleParameter p_out_decisions = new OracleParameter();
                p_out_decisions.Direction = ParameterDirection.Output;
                p_out_decisions.ParameterName = "p_out_decisions";
                p_out_decisions.OracleDbType = OracleDbType.RefCursor;
                command.Parameters.Add(p_out_decisions);

                string p_req_no = aditionalParameters.ApiServiceCallId.ToString();
                command.Parameters.Add(new OracleParameter("p_req_no", OracleDbType.Varchar2, p_req_no, ParameterDirection.Input));

                string p_user = this.CreateUserText(aditionalParameters);
                command.Parameters.Add(new OracleParameter("p_user", OracleDbType.Varchar2, p_user, ParameterDirection.Input));

                OracleDataAdapter resultDataSet = new OracleDataAdapter(command);
                try
                {
                    connection.Open();
                    resultDataSet.Fill(ds);
                    ds.Tables[0].TableName = "p_out_person";
                    ds.Tables[1].TableName = "p_out_decisions";
                }
                finally
                {
                    connection.Close();
                }

                DataSetMapper<GetSocialServicesDecisionsResponseType> mapper = CreateGetSocialServicesDecisionsMapper(accessMatrix, argument);
                GetSocialServicesDecisionsResponseType result = new GetSocialServicesDecisionsResponseType();
                result.CurrentTime = DateTime.Now;
                result.CurrentTimeSpecified = true;
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
                LogError(aditionalParameters, ex, new { Guid = id });
                throw ex;
            }
        }

        public CommonSignedResponse<PeopleWithDisabilitiesRequest, PeopleWithDisabilitiesResponseType> GetPersonWithDisabilitiesSocialBenefitsList(PeopleWithDisabilitiesRequest argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
            try
            {
                OracleConnection connection = new OracleConnection(ConnectionStringPeopleWithDisabilities.Value);
                DataSet ds = new DataSet();

                OracleCommand command = new OracleCommand();
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;

                command.CommandText = GetBenefitsProcedureName.Value;


                string p_r_id_type = argument.RIdentType.ToString();
                command.Parameters.Add(new OracleParameter("p_r_id_type", OracleDbType.Varchar2, p_r_id_type, ParameterDirection.Input));

                string p_r_id = argument.RIdentificator;
                command.Parameters.Add(new OracleParameter("p_r_id", OracleDbType.Varchar2, p_r_id, ParameterDirection.Input));

                string p_relation = argument.RDRelation;
                command.Parameters.Add(new OracleParameter("p_relation", OracleDbType.Varchar2, p_relation, ParameterDirection.Input));

                object p_d_id_type = DBNull.Value;
                if (argument.DIdentTypeSpecified)
                {
                    p_d_id_type = argument.DIdentType.ToString();
                }
                command.Parameters.Add(new OracleParameter("p_d_id_type", OracleDbType.Varchar2, p_d_id_type, ParameterDirection.Input));

                object p_d_id = DBNull.Value;

                if (argument.DIdentificatorSpecified)
                {
                    p_d_id = argument.DIdentificator.ToString();
                }
                command.Parameters.Add(new OracleParameter("p_d_id", OracleDbType.Varchar2, p_d_id, ParameterDirection.Input));

                string p_req_no = aditionalParameters.ApiServiceCallId.ToString();
                command.Parameters.Add(new OracleParameter("p_req_no", OracleDbType.Varchar2, p_req_no, ParameterDirection.Input));

                string p_user = this.CreateUserText(aditionalParameters);
                command.Parameters.Add(new OracleParameter("p_user", OracleDbType.Varchar2, p_user, ParameterDirection.Input));

                
                OracleParameter p_out_header = new OracleParameter();
                p_out_header.Direction = ParameterDirection.Output;
                p_out_header.ParameterName = "p_out_header";
                p_out_header.OracleDbType = OracleDbType.RefCursor;
                command.Parameters.Add(p_out_header);

                OracleParameter p_out_is = new OracleParameter();
                p_out_is.Direction = ParameterDirection.Output;
                p_out_is.ParameterName = "p_out_is";
                p_out_is.OracleDbType = OracleDbType.RefCursor;
                command.Parameters.Add(p_out_is);

                OracleParameter p_out_other = new OracleParameter();
                p_out_other.Direction = ParameterDirection.Output;
                p_out_other.ParameterName = "p_out_other";
                p_out_other.OracleDbType = OracleDbType.RefCursor;
                command.Parameters.Add(p_out_other);

                OracleParameter p_out_aux = new OracleParameter();
                p_out_aux.Direction = ParameterDirection.Output;
                p_out_aux.ParameterName = "p_out_aux";
                p_out_aux.OracleDbType = OracleDbType.RefCursor;
                command.Parameters.Add(p_out_aux);

                OracleParameter p_out_vignette = new OracleParameter();
                p_out_vignette.Direction = ParameterDirection.Output;
                p_out_vignette.ParameterName = "p_out_vignette";
                p_out_vignette.OracleDbType = OracleDbType.RefCursor;
                command.Parameters.Add(p_out_vignette);

                OracleParameter p_out_bdz = new OracleParameter();
                p_out_bdz.Direction = ParameterDirection.Output;
                p_out_bdz.ParameterName = "p_out_bdz";
                p_out_bdz.OracleDbType = OracleDbType.RefCursor;
                command.Parameters.Add(p_out_bdz);

                OracleParameter p_out_ss = new OracleParameter();
                p_out_ss.Direction = ParameterDirection.Output;
                p_out_ss.ParameterName = "p_out_ss";
                p_out_ss.OracleDbType = OracleDbType.RefCursor;
                command.Parameters.Add(p_out_ss);

                OracleParameter p_out_error = new OracleParameter();
                p_out_error.Direction = ParameterDirection.Output;
                p_out_error.ParameterName = "p_out_error";
                p_out_error.OracleDbType = OracleDbType.RefCursor;
                command.Parameters.Add(p_out_error);
                
                OracleDataAdapter resultDataSet = new OracleDataAdapter(command);
                try
                {
                    connection.Open();
                    resultDataSet.Fill(ds);
                    ds.Tables[0].TableName = "p_out_header";
                    ds.Tables[1].TableName = "p_out_is";
                    ds.Tables[2].TableName = "p_out_other";
                    ds.Tables[3].TableName = "p_out_aux";
                    ds.Tables[4].TableName = "p_out_vignette";
                    ds.Tables[5].TableName = "p_out_bdz";
                    ds.Tables[6].TableName = "p_out_ss";
                    ds.Tables[7].TableName = "p_out_error";
                    
                }
                finally
                {
                    connection.Close();
                }

                DataSetMapper<PeopleWithDisabilitiesResponseType> mapper = CreateGetPersonWithDisabilitiesSocialBenefitsMapper(accessMatrix, argument);
                DataSetMapper<PeopleWithDisabilitiesResponseType> mapperError = CreateGetPersonWithDisabilitiesErrorMapper(accessMatrix, argument);
                PeopleWithDisabilitiesResponseType result = new PeopleWithDisabilitiesResponseType();
                //result.CurrentTime = DateTime.Now;
                //result.CurrentTimeSpecified = true;

                if (ds.Tables[0].Rows.Count >0 )
                {
                    mapper.Map(ds, result);

                }
                if (ds.Tables[0].Rows.Count == 0)
                {
                    mapperError.Map(ds, result);
                }

                result.Header.Size = CountDataSetRows(ds);
      
                return SigningUtils.CreateAndSign(
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


        private DataSetMapper<GetMonthlySocialBenefitsResponseType> CreateGetMonthlySocialBenefitsMapper(AccessMatrix accessMatrix, GetMonthlySocialBenefitsRequest request)
        {
            DataSetMapper<GetMonthlySocialBenefitsResponseType> mapper = new DataSetMapper<GetMonthlySocialBenefitsResponseType>(accessMatrix);

            mapper.AddDataSetObjectInitializer((ds) => (ds.Tables["p_out_person"].Rows.Count == 1) ? ds.Tables["p_out_person"].Rows[0] : null);

            mapper.AddConstantMap((r) => r.CurrentTime, DateTime.Now);
            mapper.AddConstantMap((r) => r.PersonData.Identifier, request.PersonData.Identifier);
            mapper.AddConstantMap((r) => r.PersonData.IdentifierType, request.PersonData.IdentifierType);

            mapper.AddDataColumnMap((r) => r.PersonData.BirthDatе, "PERSON_BIRTH_DATE");
            mapper.AddDataColumnMap((r) => r.PersonData.FirstName, "FIRST_NAME");
            mapper.AddDataColumnMap((r) => r.PersonData.Gender.GenderCode, "PERSON_GENDER_CODE");
            mapper.AddDataColumnMap((r) => r.PersonData.Gender.GenderName, "PERSON_GENDER");
            mapper.AddDataColumnMap((r) => r.PersonData.LastName, "LAST_NAME");
            mapper.AddDataColumnMap((r) => r.PersonData.MiddleName, "SECOND_NAME");

            mapper.AddDataRowMap((r) => r.DecisionData, (dr) => dr.Table.DataSet.Tables["p_out_decisions"].Rows);
            mapper.AddDataColumnMap((r) => r.DecisionData[0].Details.Date, "DECISION_DATE");
            mapper.AddDataColumnMap((r) => r.DecisionData[0].Details.DecisionNumber, "DECISION_NO");
            mapper.AddDataColumnMap((r) => r.DecisionData[0].Details.OrganizationUnitCode, "ORG_UNIT_CODE");
            mapper.AddDataColumnMap((r) => r.DecisionData[0].Details.OrganizationUnitName, "ORG_UNIT_NAME");

            mapper.AddDataColumnMap((r) => r.DecisionData[0].IsArchivedRequest, "REQUEST_IS_ARCHIVED", (o) => (o.ToString().Trim().ToUpper() == "Y" ? true : false));
            mapper.AddDataColumnMap((r) => r.DecisionData[0].LegalGroundCode, "LEGAL_GROUND_CODE");
            mapper.AddDataColumnMap((r) => r.DecisionData[0].LegalGroundName, "LEGAL_GROUND_NAME");
            mapper.AddDataColumnMap((r) => r.DecisionData[0].RequestEndDate, "REQUEST_END_DATE");

            return mapper;
        }

        private DataSetMapper<GetBenefitsForHeatingResponseType> CreateGetBenefitsForHeatingMapper(AccessMatrix accessMatrix, GetBenefitsForHeatingRequest request)
        {
            DataSetMapper<GetBenefitsForHeatingResponseType> mapper = new DataSetMapper<GetBenefitsForHeatingResponseType>(accessMatrix);

            mapper.AddDataSetObjectInitializer((ds) => (ds.Tables["p_out_person"].Rows.Count == 1) ? ds.Tables["p_out_person"].Rows[0] : null);

            mapper.AddConstantMap((r) => r.CurrentTime, DateTime.Now);
            mapper.AddConstantMap((r) => r.PersonData.Identifier, request.PersonData.Identifier);
            mapper.AddConstantMap((r) => r.PersonData.IdentifierType, request.PersonData.IdentifierType);

            mapper.AddDataColumnMap((r) => r.PersonData.BirthDatе, "PERSON_BIRTH_DATE");
            mapper.AddDataColumnMap((r) => r.PersonData.FirstName, "FIRST_NAME");
            mapper.AddDataColumnMap((r) => r.PersonData.Gender.GenderCode, "PERSON_GENDER_CODE");
            mapper.AddDataColumnMap((r) => r.PersonData.Gender.GenderName, "PERSON_GENDER");
            mapper.AddDataColumnMap((r) => r.PersonData.LastName, "LAST_NAME");
            mapper.AddDataColumnMap((r) => r.PersonData.MiddleName, "SECOND_NAME");

            mapper.AddDataRowMap((r) => r.DecisionData, (dr) => dr.Table.DataSet.Tables["p_out_decisions"].Rows);
            mapper.AddDataColumnMap((r) => r.DecisionData[0].Details.Date, "DECISION_DATE");
            mapper.AddDataColumnMap((r) => r.DecisionData[0].Details.DecisionNumber, "DECISION_NO");
            mapper.AddDataColumnMap((r) => r.DecisionData[0].Details.OrganizationUnitCode, "ORG_UNIT_CODE");
            mapper.AddDataColumnMap((r) => r.DecisionData[0].Details.OrganizationUnitName, "ORG_UNIT_NAME");

            mapper.AddDataColumnMap((r) => r.DecisionData[0].IsArchivedRequest, "REQUEST_IS_ARCHIVED", (o) => (o.ToString().Trim().ToUpper() == "Y" ? true : false));
            mapper.AddDataColumnMap((r) => r.DecisionData[0].LegalGroundCode, "LEGAL_GROUND_CODE");
            mapper.AddDataColumnMap((r) => r.DecisionData[0].LegalGroundName, "LEGAL_GROUND_NAME");
            mapper.AddDataColumnMap((r) => r.DecisionData[0].RequestEndDate, "REQUEST_END_DATE");

            return mapper;
        }

        private DataSetMapper<GetSocialServicesDecisionsResponseType> CreateGetSocialServicesDecisionsMapper(AccessMatrix accessMatrix, GetSocialServicesDecisionsRequest request)
        {
            DataSetMapper<GetSocialServicesDecisionsResponseType> mapper = new DataSetMapper<GetSocialServicesDecisionsResponseType>(accessMatrix);

            mapper.AddDataSetObjectInitializer((ds) => (ds.Tables["p_out_person"].Rows.Count == 1) ? ds.Tables["p_out_person"].Rows[0] : null);

            mapper.AddConstantMap((r) => r.CurrentTime, DateTime.Now);
            mapper.AddConstantMap((r) => r.PersonData.Identifier, request.PersonData.Identifier);
            mapper.AddConstantMap((r) => r.PersonData.IdentifierType, request.PersonData.IdentifierType);

            mapper.AddDataColumnMap((r) => r.PersonData.BirthDatе, "PERSON_BIRTH_DATE");
            mapper.AddDataColumnMap((r) => r.PersonData.FirstName, "FIRST_NAME");
            mapper.AddDataColumnMap((r) => r.PersonData.Gender.GenderCode, "PERSON_GENDER_CODE");
            mapper.AddDataColumnMap((r) => r.PersonData.Gender.GenderName, "PERSON_GENDER");
            mapper.AddDataColumnMap((r) => r.PersonData.LastName, "LAST_NAME");
            mapper.AddDataColumnMap((r) => r.PersonData.MiddleName, "SECOND_NAME");
            
            mapper.AddDataRowMap((r) => r.SocialServicesData, (dr) => dr.Table.DataSet.Tables["p_out_decisions"].Rows);

            mapper.AddDataColumnMap((r) => r.SocialServicesData[0].Details.Date, "DECISION_DATE");
            mapper.AddDataColumnMap((r) => r.SocialServicesData[0].Details.DecisionNumber, "DECISION_NO");
            mapper.AddDataColumnMap((r) => r.SocialServicesData[0].Details.OrganizationUnitCode, "ORG_UNIT_CODE");
            mapper.AddDataColumnMap((r) => r.SocialServicesData[0].Details.OrganizationUnitName, "ORG_UNIT_NAME");

            mapper.AddDataColumnMap((r) => r.SocialServicesData[0].Address, "SS_ADDRESS");
            mapper.AddDataColumnMap((r) => r.SocialServicesData[0].CityEkatteCode, "SS_ADDRESS_CITY_CODE");
            mapper.AddDataColumnMap((r) => r.SocialServicesData[0].CityName, "SS_ADDRESS_CITY_NAME");
            mapper.AddDataColumnMap((r) => r.SocialServicesData[0].IsResidentType, "IS_RESIDENT_TYPE", (o) => (o.ToString().Trim().ToUpper() == "Y" ? true : false));
            mapper.AddDataColumnMap((r) => r.SocialServicesData[0].PhoneNumber, "SS_PHONE_NUMBER");
            mapper.AddDataColumnMap((r) => r.SocialServicesData[0].SocialServiceCode, "SOCIAL_SERVICE_CODE");
            mapper.AddDataColumnMap((r) => r.SocialServicesData[0].SocialServiceName, "SOCIAL_SERVICE_NAME");
            mapper.AddDataColumnMap((r) => r.SocialServicesData[0].SocialServiceType, "SOCIAL_SERVICE_TYPE");
            mapper.AddDataColumnMap((r) => r.SocialServicesData[0].SocialServiceTypeCode, "SOCIAL_SERVICE_TYPE_CODE");

            return mapper;
        }

        private DataSetMapper<PeopleWithDisabilitiesResponseType> CreateGetPersonWithDisabilitiesSocialBenefitsMapper(AccessMatrix accessMatrix, PeopleWithDisabilitiesRequest request)
        {
            DataSetMapper<PeopleWithDisabilitiesResponseType> mapper = new DataSetMapper<PeopleWithDisabilitiesResponseType>(accessMatrix);
            mapper.AddDataSetObjectInitializer((ds) => (ds.Tables["p_out_header"].Rows.Count == 1) ? ds.Tables["p_out_header"].Rows[0] : null);
            mapper.AddDataColumnMap((r) => r.Header.RequestNumber, "REQUESTNUMBER");
            mapper.AddDataColumnMap((r) => r.Header.Size, "Size");
            mapper.AddDataColumnMap((r) => r.Header.PaymentMonth, "PAYMENTMONTH", (o) => string.IsNullOrEmpty(o.ToString()) ? new DateTime() : DateTime.ParseExact(o.ToString(), "yyyy-MM-dd", CultureInfo.InvariantCulture.DateTimeFormat));
            mapper.AddDataColumnMap((r) => r.Header.PersonName, "PERSONNAME");

            mapper.AddDataRowMap((r) => r.Data.IS, (dr) => dr.Table.DataSet.Tables["p_out_is"].Rows);
            mapper.AddDataColumnMap((r) => r.Data.IS[0].Row, "ROWNUM");
            mapper.AddDataColumnMap((r) => r.Data.IS[0].GroundName, "GROUNDNAME");
            mapper.AddDataColumnMap((r) => r.Data.IS[0].Amount, "AMOUNT");

            mapper.AddDataRowMap((r) => r.Data.Other, (dr) => dr.Table.DataSet.Tables["p_out_other"].Rows);
            mapper.AddDataColumnMap((r) => r.Data.Other[0].Row, "ROWNUM");
            mapper.AddDataColumnMap((r) => r.Data.Other[0].GroundName, "GROUNDNAME");
            mapper.AddDataColumnMap((r) => r.Data.Other[0].Amount, "AMOUNT");

            mapper.AddDataRowMap((r) => r.Data.Aux, (dr) => dr.Table.DataSet.Tables["p_out_aux"].Rows);
            mapper.AddDataColumnMap((r) => r.Data.Aux[0].Row, "Row");
            mapper.AddDataColumnMap((r) => r.Data.Aux[0].PSName, "PSNAME");
            mapper.AddDataColumnMap((r) => r.Data.Aux[0].EndDate, "ENDDATE", (o) => string.IsNullOrEmpty(o.ToString()) ? new DateTime() : DateTime.ParseExact(o.ToString(), "yyyy-MM-dd", CultureInfo.InvariantCulture.DateTimeFormat));

            mapper.AddDataRowMap((r) => r.Data.Vignette, (dr) => dr.Table.DataSet.Tables["p_out_vignette"].Rows);
            mapper.AddDataColumnMap((r) => r.Data.Vignette[0].EndDate, "ENDDATE", (o) => string.IsNullOrEmpty(o.ToString()) ? new DateTime() : DateTime.ParseExact(o.ToString(), "yyyy-MM-dd", CultureInfo.InvariantCulture.DateTimeFormat));

            mapper.AddDataRowMap((r) => r.Data.BDZ, (dr) => dr.Table.DataSet.Tables["p_out_bdz"].Rows);
            mapper.AddDataColumnMap((r) => r.Data.BDZ[0].EndDate, "ENDDATE", (o) => string.IsNullOrEmpty(o.ToString()) ? new DateTime() : DateTime.ParseExact(o.ToString(), "yyyy-MM-dd", CultureInfo.InvariantCulture.DateTimeFormat));

            mapper.AddDataRowMap((r) => r.Data.SS, (dr) => dr.Table.DataSet.Tables["p_out_ss"].Rows);
            mapper.AddDataColumnMap((r) => r.Data.SS[0].Row, "Row");
            mapper.AddDataColumnMap((r) => r.Data.SS[0].Type, "Type");
            mapper.AddDataColumnMap((r) => r.Data.SS[0].OrderNo, "ORDERNO");
            mapper.AddDataColumnMap((r) => r.Data.SS[0].OrderDate, "ORDERDATE", (o) => string.IsNullOrEmpty(o.ToString()) ? new DateTime() : DateTime.ParseExact(o.ToString(), "yyyy-MM-dd", CultureInfo.InvariantCulture.DateTimeFormat));

            mapper.AddDataRowMap((r) => r.Data.Error, (dr) => dr.Table.DataSet.Tables["p_out_error"].Rows);

            mapper.AddDataColumnMap((r) => r.Data.Error[0].ErrorCode, "ERRORCODE");
            mapper.AddDataColumnMap((r) => r.Data.Error[0].ErrorText, "ERRORTEXT");

            return mapper;
        }

        private DataSetMapper<PeopleWithDisabilitiesResponseType> CreateGetPersonWithDisabilitiesErrorMapper(AccessMatrix accessMatrix, PeopleWithDisabilitiesRequest request)
        {
            DataSetMapper<PeopleWithDisabilitiesResponseType> mapper = new DataSetMapper<PeopleWithDisabilitiesResponseType>(accessMatrix);
            mapper.AddDataSetObjectInitializer((ds) => (ds.Tables["p_out_error"].Rows.Count == 1) ? ds.Tables["p_out_error"].Rows[0] : null);
            //mapper.AddDataColumnMap((r) => r.Header.RequestNumber, "REQUESTNUMBER");
            //mapper.AddDataColumnMap((r) => r.Header.Size, "Size");
            //mapper.AddDataColumnMap((r) => r.Header.PaymentMonth, "PAYMENTMONTH", (o) => string.IsNullOrEmpty(o.ToString()) ? new DateTime() : DateTime.ParseExact(o.ToString(), "yyyy-MM-dd", CultureInfo.InvariantCulture.DateTimeFormat));
            //mapper.AddDataColumnMap((r) => r.Header.PersonName, "PERSONNAME");

            mapper.AddDataRowMap((r) => r.Data.IS, (dr) => dr.Table.DataSet.Tables["p_out_is"].Rows);
            mapper.AddDataColumnMap((r) => r.Data.IS[0].Row, "ROWNUM");
            mapper.AddDataColumnMap((r) => r.Data.IS[0].GroundName, "GROUNDNAME");
            mapper.AddDataColumnMap((r) => r.Data.IS[0].Amount, "AMOUNT");

            mapper.AddDataRowMap((r) => r.Data.Other, (dr) => dr.Table.DataSet.Tables["p_out_other"].Rows);
            mapper.AddDataColumnMap((r) => r.Data.Other[0].Row, "ROWNUM");
            mapper.AddDataColumnMap((r) => r.Data.Other[0].GroundName, "GROUNDNAME");
            mapper.AddDataColumnMap((r) => r.Data.Other[0].Amount, "AMOUNT");

            mapper.AddDataRowMap((r) => r.Data.Aux, (dr) => dr.Table.DataSet.Tables["p_out_aux"].Rows);
            mapper.AddDataColumnMap((r) => r.Data.Aux[0].Row, "Row");
            mapper.AddDataColumnMap((r) => r.Data.Aux[0].PSName, "PSNAME");
            mapper.AddDataColumnMap((r) => r.Data.Aux[0].EndDate, "ENDDATE", (o) => string.IsNullOrEmpty(o.ToString()) ? new DateTime() : DateTime.ParseExact(o.ToString(), "yyyy-MM-dd", CultureInfo.InvariantCulture.DateTimeFormat));

            mapper.AddDataRowMap((r) => r.Data.Vignette, (dr) => dr.Table.DataSet.Tables["p_out_vignette"].Rows);
            mapper.AddDataColumnMap((r) => r.Data.Vignette[0].EndDate, "ENDDATE", (o) => string.IsNullOrEmpty(o.ToString()) ? new DateTime() : DateTime.ParseExact(o.ToString(), "yyyy-MM-dd", CultureInfo.InvariantCulture.DateTimeFormat));

            mapper.AddDataRowMap((r) => r.Data.BDZ, (dr) => dr.Table.DataSet.Tables["p_out_bdz"].Rows);
            mapper.AddDataColumnMap((r) => r.Data.BDZ[0].EndDate, "ENDDATE", (o) => string.IsNullOrEmpty(o.ToString()) ? new DateTime() : DateTime.ParseExact(o.ToString(), "yyyy-MM-dd", CultureInfo.InvariantCulture.DateTimeFormat));

            mapper.AddDataRowMap((r) => r.Data.SS, (dr) => dr.Table.DataSet.Tables["p_out_ss"].Rows);
            mapper.AddDataColumnMap((r) => r.Data.SS[0].Row, "Row");
            mapper.AddDataColumnMap((r) => r.Data.SS[0].Type, "Type");
            mapper.AddDataColumnMap((r) => r.Data.SS[0].OrderNo, "ORDERNO");
            mapper.AddDataColumnMap((r) => r.Data.SS[0].OrderDate, "ORDERDATE", (o) => string.IsNullOrEmpty(o.ToString()) ? new DateTime() : DateTime.ParseExact(o.ToString(), "yyyy-MM-dd", CultureInfo.InvariantCulture.DateTimeFormat));

            mapper.AddDataRowMap((r) => r.Data.Error, (dr) => dr.Table.DataSet.Tables["p_out_error"].Rows);

            mapper.AddDataColumnMap((r) => r.Data.Error[0].ErrorCode, "ERRORCODE");
            mapper.AddDataColumnMap((r) => r.Data.Error[0].ErrorText, "ERRORTEXT");

            return mapper;
        }

        private string CreateUserText(AdapterAdditionalParameters additionalParameters)
        {
            string userValue = null;
            if (additionalParameters != null && additionalParameters.CallContext != null)
            {
                string identifier = additionalParameters.CallContext.EmployeeIdentifier;
                string names = additionalParameters.CallContext.EmployeeNames;
                userValue = string.Format("{0}-{1}", identifier, names);
            }

            return userValue;
        }

        private int CountDataSetRows(DataSet ds)
        {
            int result = 0;
            int DataSetTableCount = ds.Tables.Count;
            for (int i = 0; i < DataSetTableCount; i++)
            {
                result += ds.Tables[i].Rows.Count;
            }
            return result;
        }
    }
}