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

namespace TechnoLogica.RegiX.CRCIOORNumbersAdapter.AdapterService
{
	[Export(typeof(IAdapterService))]
	[ExportFullName(typeof(CRCIOORNumbersAdapter), typeof(IAdapterService))]
	[ExportSimpleName(typeof(CRCIOORNumbersAdapter), typeof(IAdapterService))]
	public class CRCIOORNumbersAdapter : OracleAdapterService.OracleBaseAdapterService, ICRCIOORNumbersAdapter, IAdapterService
	{
		[Export(typeof(ParameterInfo))]
		[ExportFullName(typeof(CRCIOORNumbersAdapter), typeof(ParameterInfo))]
		public static ParameterInfo<string> ConnectionString =
		  new ParameterInfo<string>(@"Data Source = IP / CRCLRN; User ID = ; Password=;")
		  {
			  Key = Constants.ConnectionStringParameterKeyName,
			  Description = "Connection string",
			  OwnerAssembly = typeof(CRCIOORNumbersAdapter).Assembly
		  };

		[Export(typeof(ParameterInfo))]
		[ExportFullName(typeof(CRCIOORNumbersAdapter), typeof(ParameterInfo))]
		public static ParameterInfo<string> GetCompanyInfoProcedureName =
			new ParameterInfo<string>("regix_registers.get_numbers")
			{
				Key = "GetCompanyInfoProcedureName",
				Description = "the procedure which is called by GetCompanyInfo()",
				OwnerAssembly = typeof(CRCIOORNumbersAdapter).Assembly
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
				command.CommandText = GetCompanyInfoProcedureName.Value; //"regix_registers.get_numbers"; //

				string p_company_name = argument.CompanyName;
				command.Parameters.Add(new OracleParameter("p_company_name", OracleDbType.Varchar2, p_company_name, ParameterDirection.Input));
				string p_company_type = argument.CompanyType;
				command.Parameters.Add(new OracleParameter("p_company_type", OracleDbType.Varchar2, p_company_type, ParameterDirection.Input));
				string p_company_EIK = argument.EIK;
				command.Parameters.Add(new OracleParameter("p_company_EIK", OracleDbType.Varchar2, p_company_EIK, ParameterDirection.Input));
				string p_company_address = argument.Address;
				command.Parameters.Add(new OracleParameter("p_company_address", OracleDbType.Varchar2, p_company_address, ParameterDirection.Input));
				string p_company_web = argument.WebPageAddress;
				command.Parameters.Add(new OracleParameter("p_company_web", OracleDbType.Varchar2, p_company_web, ParameterDirection.Input));
				string p_permition_no = argument.PermissionNumber;
				command.Parameters.Add(new OracleParameter("p_permition_no", OracleDbType.Varchar2, p_permition_no, ParameterDirection.Input));

				DateTime? p_from_date_issue = argument.IssueDateFrom;
				command.Parameters.Add(new OracleParameter("p_from_date_issue", OracleDbType.Date, p_from_date_issue, ParameterDirection.Input));
				DateTime? p_to_date_issue = argument.IssueDateTo;
				command.Parameters.Add(new OracleParameter("p_to_date_issue", OracleDbType.Date, p_to_date_issue, ParameterDirection.Input));

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
			mapper.AddDataRowMap((r) => r.Companies.Company, (dr) => dr.Table.DataSet.Tables["p_out_records"].Rows);

			mapper.AddDataColumnMap((r) => r.Companies.Company[0].CompanyName, "UL_NAME");
			mapper.AddDataColumnMap((r) => r.Companies.Company[0].CompType, "UL_TYPE");
			mapper.AddDataColumnMap((r) => r.Companies.Company[0].EIK, "EIK");
			mapper.AddDataColumnMap((r) => r.Companies.Company[0].HeadquartersAddress, "UL_ADDRESS");
			mapper.AddDataColumnMap((r) => r.Companies.Company[0].WebPageAddress, "WEB");
			mapper.AddDataColumnMap((r) => r.Companies.Company[0].IndividualResourcePermission.PermissionNumber, "RESH_NOMER");
			mapper.AddDataColumnMap((r) => r.Companies.Company[0].IndividualResourcePermission.IssueDate, "RESH_DATA");
			mapper.AddDataColumnMap((r) => r.Companies.Company[0].IndividualResourcePermission.EndOfActionDate, "DATA_PRIK");
			mapper.AddDataColumnMap((r) => r.Companies.Company[0].IndividualResourcePermission.TerminationDate, "TERMINATION_DATE");
			mapper.AddDataColumnMap((r) => r.Companies.Company[0].IndividualResourcePermission.Status, "STATUS");
			mapper.AddDataColumnMap((r) => r.Companies.Company[0].IndividualResourcePermission.PermissionType, "VID_RAZRESHENIE");

			return mapper;
		}
	}
}