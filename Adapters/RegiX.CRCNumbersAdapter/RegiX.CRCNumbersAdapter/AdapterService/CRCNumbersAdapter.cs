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

namespace TechnoLogica.RegiX.CRCNumbersAdapter.AdapterService
{
	[Export(typeof(IAdapterService))]
	[ExportFullName(typeof(CRCNumbersAdapter), typeof(IAdapterService))]
	[ExportSimpleName(typeof(CRCNumbersAdapter), typeof(IAdapterService))]
	public class CRCNumbersAdapter : OracleAdapterService.OracleBaseAdapterService, ICRCNumbersAdapter, IAdapterService
	{
		[Export(typeof(ParameterInfo))]
		[ExportFullName(typeof(CRCNumbersAdapter), typeof(ParameterInfo))]
		public static ParameterInfo<string> ConnectionString =
		  new ParameterInfo<string>(@"Data Source =; User ID = ; Password=;")
		  {
			  Key = Constants.ConnectionStringParameterKeyName,
			  Description = "Connection string",
			  OwnerAssembly = typeof(CRCNumbersAdapter).Assembly
		  };

		[Export(typeof(ParameterInfo))]
		[ExportFullName(typeof(CRCNumbersAdapter), typeof(ParameterInfo))]
		public static ParameterInfo<string> GetNumbersInfoProcedureName =
			new ParameterInfo<string>("regix_registers.get_number_resources")
			{
				Key = "GetNumbersInfoProcedureName",
				Description = "the procedure which is called by GetNumbersInfo()",
				OwnerAssembly = typeof(CRCNumbersAdapter).Assembly
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

		public CommonSignedResponse<GetNumbersInfoRequest, GetNumbersInfoResponseType> GetNumbersInfo(GetNumbersInfoRequest argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters)
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
				command.CommandText = GetNumbersInfoProcedureName.Value; //"regix_registers.get_number_resources"; //

				string p_company_name = argument.CompanyName;
				command.Parameters.Add(new OracleParameter("p_company_name", OracleDbType.Varchar2, p_company_name, ParameterDirection.Input));
				string p_company_type = argument.CompanyType;
				command.Parameters.Add(new OracleParameter("p_company_type", OracleDbType.Varchar2, p_company_type, ParameterDirection.Input));
				string p_code = argument.Code;
				command.Parameters.Add(new OracleParameter("p_code", OracleDbType.Varchar2, p_code, ParameterDirection.Input));
				string p_group = argument.NumbersGroup;
				command.Parameters.Add(new OracleParameter("p_group", OracleDbType.Varchar2, p_group, ParameterDirection.Input));
				string p_decision = argument.Decision;
				command.Parameters.Add(new OracleParameter("p_decision", OracleDbType.Varchar2, p_decision, ParameterDirection.Input));
				
				DateTime? p_issue_date_from = argument.DecisionDateFrom;
				command.Parameters.Add(new OracleParameter("p_issue_date_from", OracleDbType.Date, p_issue_date_from, ParameterDirection.Input));
				DateTime? p_issue_date_to = argument.DecisionDateTo;
				command.Parameters.Add(new OracleParameter("p_issue_date_to", OracleDbType.Date, p_issue_date_to, ParameterDirection.Input));
				
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
				DataSetMapper<GetNumbersInfoResponseType> mapper = CreateGetNumbersInfoMapper(accessMatrix);

				var result = new GetNumbersInfoResponseType();
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

		private DataSetMapper<GetNumbersInfoResponseType> CreateGetNumbersInfoMapper(AccessMatrix accessMatrix)
		{
			DataSetMapper<GetNumbersInfoResponseType> mapper = new DataSetMapper<GetNumbersInfoResponseType>(accessMatrix);
			mapper.AddDataSetObjectInitializer((ds) => (ds.Tables["p_out_records"].Rows.Count > 0) ? ds.Tables["p_out_records"].Rows[0] : null);
			mapper.AddDataRowMap((r) => r.CompaniesData.CompanyData, (dr) => dr.Table.DataSet.Tables["p_out_records"].Rows);

			mapper.AddDataColumnMap((r) => r.CompaniesData.CompanyData[0].CompanyName, "ENTERPRISE_NAME");
			mapper.AddDataColumnMap((r) => r.CompaniesData.CompanyData[0].CompanyType, "ENTERPRISE_TYPE");
			mapper.AddDataColumnMap((r) => r.CompaniesData.CompanyData[0].AccessCode, "CODE");
			mapper.AddDataColumnMap((r) => r.CompaniesData.CompanyData[0].SuppliedGroupOfNumbers, "GROUP_OF_NUMBERS");
			mapper.AddDataColumnMap((r) => r.CompaniesData.CompanyData[0].Service, "SERVICE");
			mapper.AddDataColumnMap((r) => r.CompaniesData.CompanyData[0].DecisionNumber, "DECISION_NO");
			mapper.AddDataColumnMap((r) => r.CompaniesData.CompanyData[0].DecisionDate, "DECISION_DATE");

			return mapper;
		}
	}
}