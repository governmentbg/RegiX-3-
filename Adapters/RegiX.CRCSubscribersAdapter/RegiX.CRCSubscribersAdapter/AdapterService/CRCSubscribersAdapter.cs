using Oracle.ManagedDataAccess.Client;
using System;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Data;
using System.ServiceModel;
using TechnoLogica.RegiX.Adapters.Common.DataContracts;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Adapters.Common.ObjectMapping;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.DataContracts.Parameter;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.Common.Utils;

namespace TechnoLogica.RegiX.CRCSubscribersAdapter.AdapterService
{
    [Export(typeof(IAdapterService))]
    [ExportFullName(typeof(CRCSubscribersAdapter), typeof(IAdapterService))]
    [ExportSimpleName(typeof(CRCSubscribersAdapter), typeof(IAdapterService))]
    public class CRCSubscribersAdapter : OracleAdapterService.OracleBaseAdapterService, ICRCSubscribersAdapter, IAdapterService
    {
        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(CRCSubscribersAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> ConnectionString =
           new ParameterInfo<string>(@"Data Source =; User ID = ; Password=;")
           {
               Key = Constants.ConnectionStringParameterKeyName,
               Description = "Connection string",
               OwnerAssembly = typeof(CRCSubscribersAdapter).Assembly
           };

        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(CRCSubscribersAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> GetCompanyInfoProcedureName =
            new ParameterInfo<string>("regix_registers.get_number_end_users")
            {
                Key = "GetCompanyInfoProcedureName",
                Description = "the procedure which is called by GetCompanyInfo()",
                OwnerAssembly = typeof(CRCSubscribersAdapter).Assembly
            };
        public override string CheckRegisterConnection()
        {
            try
            {
                var connectionString = ConnectionString;
                if (connectionString != null && !String.IsNullOrEmpty(connectionString.CurrentValue))
                {
                    using (OracleConnection connection = new OracleConnection(connectionString.CurrentValue))
                    {
                        connection.Open();
                        return Constants.ConnectionOk;
                    };
                }
                else
                {
                    return Constants.ConnectionStringNotSet;
                }
            }
            catch (Exception ex)
            {
                return String.Format(Constants.ConnectionException, ex.Message);
            }
        }
        public CommonSignedResponse<GetCompanyInfoRequest, GetCompanyInfoResponseType> GetCompanyInfo(GetCompanyInfoRequest argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(additionalParameters, new { Request = argument.XmlSerialize(), Guid = id });
            try
            {
                OracleConnection connection = new OracleConnection(ConnectionString.Value);
                DataSet ds = new DataSet();

                OracleCommand command = new OracleCommand();
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = GetCompanyInfoProcedureName.Value; //"regix_registers.get_number_end_users"; 


                string p_company_name = argument.CompanyName;
                command.Parameters.Add(new OracleParameter("p_company_name", OracleDbType.Varchar2, p_company_name, ParameterDirection.Input));
                string p_company_type = argument.CompanyType;
                command.Parameters.Add(new OracleParameter("p_company_type", OracleDbType.Varchar2, p_company_type, ParameterDirection.Input));
                string p_company_eik = argument.EIK;
                command.Parameters.Add(new OracleParameter("p_company_eik", OracleDbType.Varchar2, p_company_eik, ParameterDirection.Input));

                OracleParameter p_out_records = new OracleParameter();
                p_out_records.Direction = ParameterDirection.Output;
                p_out_records.ParameterName = "p_out_records";
                p_out_records.OracleDbType = OracleDbType.RefCursor;
                command.Parameters.Add(p_out_records);

                OracleDataAdapter resultDataSet = new OracleDataAdapter(command);
                try
                {
                    connection.Open();
                    resultDataSet.Fill(ds);
                    ds.Tables[0].TableName = "p_out_records";
                }
                finally
                {
                    connection.Close();
                }

                DataSetMapper<GetCompanyInfoResponseType> mapper = CreateGetCompanyInfoMapper(accessMatrix);
                var result = new GetCompanyInfoResponseType();
                mapper.Map(ds, result);

                return SigningUtils.CreateAndSign(
                    argument,
                    result,
                    accessMatrix,
                    additionalParameters
                );
            }
            catch (Exception ex)
            {
                LogError(additionalParameters, ex, new { Guid = id });
                throw;
            }
        }

        private DataSetMapper<GetCompanyInfoResponseType> CreateGetCompanyInfoMapper(AccessMatrix accessMatrix)
        {
            DataSetMapper<GetCompanyInfoResponseType> mapper = new DataSetMapper<GetCompanyInfoResponseType>(accessMatrix);

            mapper.AddDataSetObjectInitializer((ds) => (ds.Tables["p_out_records"].Rows.Count > 0) ? ds.Tables["p_out_records"].Rows[0] : null);
            mapper.AddDataRowMap((r) => r.CompaniesData.CompanyData, (dr) => dr.Table.DataSet.Tables["p_out_records"].Rows);

            mapper.AddDataColumnMap((r) => r.CompaniesData.CompanyData[0].CompanyName, "PR_NAME");
            mapper.AddDataColumnMap((r) => r.CompaniesData.CompanyData[0].CompanyType, "PR_TYPE");
            mapper.AddDataColumnMap((r) => r.CompaniesData.CompanyData[0].EIK, "PR_EIK");
            mapper.AddDataColumnMap((r) => r.CompaniesData.CompanyData[0].InfoProvided, "INFO");
            mapper.AddDataColumnMap((r) => r.CompaniesData.CompanyData[0].PublicMessagesActivityDeclared, "DECLAR");
            mapper.AddDataColumnMap((r) => r.CompaniesData.CompanyData[0].DeclaredSubscribersCount.FixedTelephoneService, "FICS_TEL");
            mapper.AddDataColumnMap((r) => r.CompaniesData.CompanyData[0].DeclaredSubscribersCount.MobileTelephoneService, "MOBIL_TEL");
            mapper.AddDataColumnMap((r) => r.CompaniesData.CompanyData[0].DeclaredSubscribersCount.ChooseOperatorService, "OBSHT_TEL_OPER");
            mapper.AddDataColumnMap((r) => r.CompaniesData.CompanyData[0].DeclaredSubscribersCount.MobileInternetAccess, "USL_INTERNET");
            mapper.AddDataColumnMap((r) => r.CompaniesData.CompanyData[0].DeclaredSubscribersCount.DataTransferAndInternetAccess, "USL_DATA");
            mapper.AddDataColumnMap((r) => r.CompaniesData.CompanyData[0].DeclaredSubscribersCount.RadioAndTVProgramsDistribution, "RADO_TV");

            return mapper;
        }
    }
}