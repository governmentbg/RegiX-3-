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

namespace TechnoLogica.RegiX.CRCNonUniversalPostalServicesAdapter.AdapterService
{
	[Export(typeof(IAdapterService))]
	[ExportFullName(typeof(CRCNonUniversalPostalServicesAdapter), typeof(IAdapterService))]
	[ExportSimpleName(typeof(CRCNonUniversalPostalServicesAdapter), typeof(IAdapterService))]
	public class CRCNonUniversalPostalServicesAdapter : OracleAdapterService.OracleBaseAdapterService, ICRCNonUniversalPostalServicesAdapter, IAdapterService
	{
		[Export(typeof(ParameterInfo))]
		[ExportFullName(typeof(CRCNonUniversalPostalServicesAdapter), typeof(ParameterInfo))]
		public static ParameterInfo<string> ConnectionString =
		  new ParameterInfo<string>(@"Data Source =; User ID = ; Password=;")
		  {
			  Key = Constants.ConnectionStringParameterKeyName,
			  Description = "Connection string",
			  OwnerAssembly = typeof(CRCNonUniversalPostalServicesAdapter).Assembly
		  };

		[Export(typeof(ParameterInfo))]
		[ExportFullName(typeof(CRCNonUniversalPostalServicesAdapter), typeof(ParameterInfo))]
		public static ParameterInfo<string> GetNonUniversalOperatorsInfoProcedureName =
			new ParameterInfo<string>("regix_registers.get_post_non_universal")
			{
				Key = "GetGetNonUniversalOperatorsInfoProcedureName",
				Description = "the procedure which is called by GetNonUniversalOperatorsInfo()",
				OwnerAssembly = typeof(CRCNonUniversalPostalServicesAdapter).Assembly
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

		public CommonSignedResponse<GetNonUniversalOperatorsInfoRequest, GetNonUniversalOperatorsInfoResponseType> GetNonUniversalOperatorsInfo(GetNonUniversalOperatorsInfoRequest argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters)
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
				command.CommandText =  GetNonUniversalOperatorsInfoProcedureName.Value; //"regix_registers.get_post_non_universal";

				string p_company_name = argument.Operator;
				command.Parameters.Add(new OracleParameter("p_company_name", OracleDbType.Varchar2, p_company_name, ParameterDirection.Input));
				string p_company_type = argument.Type;
				command.Parameters.Add(new OracleParameter("p_company_type", OracleDbType.Varchar2, p_company_type, ParameterDirection.Input));
				string p_address = argument.Address;
				command.Parameters.Add(new OracleParameter("p_address", OracleDbType.Varchar2, p_address, ParameterDirection.Input));
				string p_license = argument.Certificate;
				command.Parameters.Add(new OracleParameter("p_license", OracleDbType.Varchar2, p_license, ParameterDirection.Input));

				DateTime? p_issue_date_from = argument.StartFromDate;
				command.Parameters.Add(new OracleParameter("p_issue_date_from", OracleDbType.Date, p_issue_date_from, ParameterDirection.Input));
				DateTime? p_issue_date_to = argument.StartToDate;
				command.Parameters.Add(new OracleParameter("p_issue_date_to", OracleDbType.Date, p_issue_date_to, ParameterDirection.Input));
				string p_shipments = argument.PostalServices;
				command.Parameters.Add(new OracleParameter("p_shipments", OracleDbType.Varchar2, p_shipments, ParameterDirection.Input));
				string p_cour_services = argument.CourierServices;
				command.Parameters.Add(new OracleParameter("p_cour_services", OracleDbType.Varchar2, p_cour_services, ParameterDirection.Input));
				string p_advertising = argument.DirectPostalAdvertising;
				command.Parameters.Add(new OracleParameter("p_advertising", OracleDbType.Varchar2, p_advertising, ParameterDirection.Input));
				
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
				DataSetMapper<GetNonUniversalOperatorsInfoResponseType> mapper = CreateGetNonUniversalOperatorsInfoMapper(accessMatrix);
				var result = new GetNonUniversalOperatorsInfoResponseType();
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

		private DataSetMapper<GetNonUniversalOperatorsInfoResponseType> CreateGetNonUniversalOperatorsInfoMapper(AccessMatrix accessMatrix)
		{
			DataSetMapper<GetNonUniversalOperatorsInfoResponseType> mapper = new DataSetMapper<GetNonUniversalOperatorsInfoResponseType>(accessMatrix);
			mapper.AddDataSetObjectInitializer((ds) => (ds.Tables["p_out_records"].Rows.Count > 0) ? ds.Tables["p_out_records"].Rows[0] : null);
			mapper.AddDataRowMap((r) => r.OperatorsInfo.OperatorInfo, (dr) => dr.Table.DataSet.Tables["p_out_records"].Rows);

			mapper.AddDataColumnMap((r) => r.OperatorsInfo.OperatorInfo[0].OperatorName, "UL_NAME");
			mapper.AddDataColumnMap((r) => r.OperatorsInfo.OperatorInfo[0].OperatorType, "UL_TYPE");
			mapper.AddDataColumnMap((r) => r.OperatorsInfo.OperatorInfo[0].HeadquartersAddress, "ADDRESS");
			mapper.AddDataColumnMap((r) => r.OperatorsInfo.OperatorInfo[0].Notification.CertificateNumber, "VHOD_NOMER");
			mapper.AddDataColumnMap((r) => r.OperatorsInfo.OperatorInfo[0].Notification.ActionStartDate, "VHOD_DATA");
			mapper.AddDataColumnMap((r) => r.OperatorsInfo.OperatorInfo[0].Notification.PostalServiceScope.PostalServices, "POSHT_PRATKI");
			mapper.AddDataColumnMap((r) => r.OperatorsInfo.OperatorInfo[0].Notification.PostalServiceScope.CourierServices, "KURIER_USLUGI");
			mapper.AddDataColumnMap((r) => r.OperatorsInfo.OperatorInfo[0].Notification.PostalServiceScope.DirectPostalAdvertising, "PRIAKA_POST_REKLAMA");
			mapper.AddDataColumnMap((r) => r.OperatorsInfo.OperatorInfo[0].Notification.Remark, "ZABELEJKA");

			return mapper;
		}
	}
}