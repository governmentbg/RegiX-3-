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

namespace TechnoLogica.RegiX.CRCPostalServicesAdapter.AdapterService
{
	[Export(typeof(IAdapterService))]
	[ExportFullName(typeof(CRCPostalServicesAdapter), typeof(IAdapterService))]
	[ExportSimpleName(typeof(CRCPostalServicesAdapter), typeof(IAdapterService))]
	public class CRCPostalServicesAdapter : OracleAdapterService.OracleBaseAdapterService, ICRCPostalServicesAdapter, IAdapterService
	{
		[Export(typeof(ParameterInfo))]
		[ExportFullName(typeof(CRCPostalServicesAdapter), typeof(ParameterInfo))]
		public static ParameterInfo<string> ConnectionString =
		  new ParameterInfo<string>(@"Data Source =; User ID = ; Password=;")
		  {
			  Key = Constants.ConnectionStringParameterKeyName,
			  Description = "Connection string",
			  OwnerAssembly = typeof(CRCPostalServicesAdapter).Assembly
		  };

		[Export(typeof(ParameterInfo))]
		[ExportFullName(typeof(CRCPostalServicesAdapter), typeof(ParameterInfo))]
		public static ParameterInfo<string> GetUniversalOperatorsInfoProcedureName =
			new ParameterInfo<string>("regix_registers.get_post_universal")
			{
				Key = "GetUniversalOperatorsInfoProcedureName",
				Description = "the procedure which is called by GetUniversalOperatorsInfo()",
				OwnerAssembly = typeof(CRCPostalServicesAdapter).Assembly
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

		public CommonSignedResponse<GetUniversalOperatorsInfoRequest, GetUniversalOperatorsInfoResponseType> GetUniversalOperatorsInfo(GetUniversalOperatorsInfoRequest argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters)
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
				command.CommandText = GetUniversalOperatorsInfoProcedureName.Value; //"regix_registers.get_post_universal"; //

				string p_company_name = argument.Holder;
				command.Parameters.Add(new OracleParameter("p_company_name", OracleDbType.Varchar2, p_company_name, ParameterDirection.Input));
				string p_company_type = argument.Type;
				command.Parameters.Add(new OracleParameter("p_company_type", OracleDbType.Varchar2, p_company_type, ParameterDirection.Input));
				string p_uri = argument.URI;
				command.Parameters.Add(new OracleParameter("p_uri", OracleDbType.Varchar2, p_uri, ParameterDirection.Input));
				string p_address = argument.Address;
				command.Parameters.Add(new OracleParameter("p_address", OracleDbType.Varchar2, p_address, ParameterDirection.Input));
				string p_license = argument.License;
				command.Parameters.Add(new OracleParameter("p_license", OracleDbType.Varchar2, p_license, ParameterDirection.Input));

				DateTime? p_issue_date_from = argument.LicenseDateFrom;
				command.Parameters.Add(new OracleParameter("p_issue_date_from", OracleDbType.Date, p_issue_date_from, ParameterDirection.Input));
				DateTime? p_issue_date_to = argument.LicenseDateTo;
				command.Parameters.Add(new OracleParameter("p_issue_date_to", OracleDbType.Date, p_issue_date_to, ParameterDirection.Input));
				DateTime? p_start_date_from = argument.ActionDateFrom;
				command.Parameters.Add(new OracleParameter("p_start_date_from", OracleDbType.Date, p_start_date_from, ParameterDirection.Input));
				DateTime? p_start_date_to = argument.ActionDateTo;
				command.Parameters.Add(new OracleParameter("p_start_date_to", OracleDbType.Date, p_start_date_to, ParameterDirection.Input));
				DateTime? p_end_date_from = argument.ActionEndDateFrom;
				command.Parameters.Add(new OracleParameter("p_end_date_from", OracleDbType.Date, p_end_date_from, ParameterDirection.Input));
				DateTime? p_end_date_to = argument.ActionEndDateTo;
				command.Parameters.Add(new OracleParameter("p_end_date_to", OracleDbType.Date, p_end_date_to, ParameterDirection.Input));

				string p_shipments = argument.ShippingServices;
				command.Parameters.Add(new OracleParameter("p_shipments", OracleDbType.Varchar2, p_shipments, ParameterDirection.Input));
				string p_parcels = argument.ParcelServices;
				command.Parameters.Add(new OracleParameter("p_parcels", OracleDbType.Varchar2, p_parcels, ParameterDirection.Input));
				string p_additionals = argument.AdditionalServices;
				command.Parameters.Add(new OracleParameter("p_additionals", OracleDbType.Varchar2, p_additionals, ParameterDirection.Input));
				string p_transfers = argument.TransferServices;
				command.Parameters.Add(new OracleParameter("p_transfers", OracleDbType.Varchar2, p_transfers, ParameterDirection.Input));

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
				DataSetMapper<GetUniversalOperatorsInfoResponseType> mapper = CreateGetUniversalOperatorsInfoMapper(accessMatrix);

				var result = new GetUniversalOperatorsInfoResponseType();
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

		private DataSetMapper<GetUniversalOperatorsInfoResponseType> CreateGetUniversalOperatorsInfoMapper(AccessMatrix accessMatrix)
		{
			DataSetMapper<GetUniversalOperatorsInfoResponseType> mapper = new DataSetMapper<GetUniversalOperatorsInfoResponseType>(accessMatrix);
			mapper.AddDataSetObjectInitializer((ds) => (ds.Tables["p_out_records"].Rows.Count > 0) ? ds.Tables["p_out_records"].Rows[0] : null);
			mapper.AddDataRowMap((r) => r.OperatorsInfo.OperatorInfo, (dr) => dr.Table.DataSet.Tables["p_out_records"].Rows);

			mapper.AddDataColumnMap((r) => r.OperatorsInfo.OperatorInfo[0].LicenseHolder, "UL_NAME");
			mapper.AddDataColumnMap((r) => r.OperatorsInfo.OperatorInfo[0].Type, "UL_TYPE");
			mapper.AddDataColumnMap((r) => r.OperatorsInfo.OperatorInfo[0].URI, "URI");
			mapper.AddDataColumnMap((r) => r.OperatorsInfo.OperatorInfo[0].HeadquartersAddress, "ADDRESS");
			mapper.AddDataColumnMap((r) => r.OperatorsInfo.OperatorInfo[0].License.LicenseNumber, "VHOD_NOMER");
			mapper.AddDataColumnMap((r) => r.OperatorsInfo.OperatorInfo[0].License.LicenseDate, "VHOD_DATA");
			mapper.AddDataColumnMap((r) => r.OperatorsInfo.OperatorInfo[0].License.StartOfActionDate, "NACH_DATA");
			mapper.AddDataColumnMap((r) => r.OperatorsInfo.OperatorInfo[0].License.EndOfActionDate, "KRAI_DATA");
			mapper.AddDataColumnMap((r) => r.OperatorsInfo.OperatorInfo[0].License.ProvidedPostalServices.TransferServices, "PAR_PREV");
			mapper.AddDataColumnMap((r) => r.OperatorsInfo.OperatorInfo[0].License.ProvidedPostalServices.AdditionalServices, "DOP_USLUGI");
			mapper.AddDataColumnMap((r) => r.OperatorsInfo.OperatorInfo[0].License.ProvidedPostalServices.ParcelServices, "POSHT_KOLETI");
			mapper.AddDataColumnMap((r) => r.OperatorsInfo.OperatorInfo[0].License.ProvidedPostalServices.ShippingServices, "POSHT_PRATKI");
			mapper.AddDataColumnMap((r) => r.OperatorsInfo.OperatorInfo[0].License.TerritorialScope, "TER_OBHVAT");
			mapper.AddDataColumnMap((r) => r.OperatorsInfo.OperatorInfo[0].License.Remark, "ZABELEJKA");

			return mapper;
		}
	}
}