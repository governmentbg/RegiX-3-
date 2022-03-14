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

namespace TechnoLogica.RegiX.CRCNotificationsAdapter.AdapterService
{
	[Export(typeof(IAdapterService))]
	[ExportFullName(typeof(CRCNotificationsAdapter), typeof(IAdapterService))]
	[ExportSimpleName(typeof(CRCNotificationsAdapter), typeof(IAdapterService))]
	public class CRCNotificationsAdapter : OracleAdapterService.OracleBaseAdapterService, ICRCNotificationsAdapter, IAdapterService
	{
		[Export(typeof(ParameterInfo))]
		[ExportFullName(typeof(CRCNotificationsAdapter), typeof(ParameterInfo))]
		public static ParameterInfo<string> ConnectionString =
		   new ParameterInfo<string>(@"Data Source =; User ID = ; Password=;")
		   {
			   Key = Constants.ConnectionStringParameterKeyName,
			   Description = "Connection string",
			   OwnerAssembly = typeof(CRCNotificationsAdapter).Assembly
		   };

        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(CRCNotificationsAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> GetCompanyInfoProcedureName =
            new ParameterInfo<string>("regix_registers.get_notification_company")
            {
                Key = "GetCompanyInfoProcedureName",
                Description = "the procedure which is called by GetCompanyInfo()",
                OwnerAssembly = typeof(CRCNotificationsAdapter).Assembly
            };


		[Export(typeof(ParameterInfo))]
		[ExportFullName(typeof(CRCNotificationsAdapter), typeof(ParameterInfo))]
		public static ParameterInfo<string> GetNetworksAndServicesInfoProcedureName =
			new ParameterInfo<string>("regix_registers.get_notification_net_services")
			{
				Key = "GetNetworksAndServicesInfoProcedureName",
				Description = "the procedure which is called by GetNetworksAndServices()",
				OwnerAssembly = typeof(CRCNotificationsAdapter).Assembly
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
				command.CommandText = GetCompanyInfoProcedureName.Value; //"regix_registers.get_notification_company"


				string p_company_name = argument.CompanyName;
                command.Parameters.Add(new OracleParameter("p_company_name", OracleDbType.Varchar2, p_company_name, ParameterDirection.Input));
                string p_company_type = argument.CompanyType;
                command.Parameters.Add(new OracleParameter("p_company_type", OracleDbType.Varchar2, p_company_type, ParameterDirection.Input));
                string p_company_eik = argument.EIK;
                command.Parameters.Add(new OracleParameter("p_company_eik", OracleDbType.Varchar2, p_company_eik, ParameterDirection.Input));
				string p_company_address = argument.Address;
				command.Parameters.Add(new OracleParameter("p_company_address", OracleDbType.Varchar2, p_company_address, ParameterDirection.Input));
				string p_company_web = argument.WebPageAddress;
                command.Parameters.Add(new OracleParameter("p_company_web", OracleDbType.Varchar2, p_company_web, ParameterDirection.Input));

                OracleParameter p_out_notifications = new OracleParameter();
                p_out_notifications.Direction = ParameterDirection.Output;
                p_out_notifications.ParameterName = "p_out_notifications";
                p_out_notifications.OracleDbType = OracleDbType.RefCursor;
                command.Parameters.Add(p_out_notifications);

                OracleDataAdapter resultDataSet = new OracleDataAdapter(command);
                try
                {
                    connection.Open();
                    resultDataSet.Fill(ds);
                    ds.Tables[0].TableName = "p_out_notifications";
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

		public CommonSignedResponse<GetNetworksAndServicesInfoRequest, GetNetworksAndServicesInfoResponseType> GetNetworksAndServicesInfo(GetNetworksAndServicesInfoRequest argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters)
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
				command.CommandText = GetNetworksAndServicesInfoProcedureName.Value; //"regix_registers.get_notification_net_services";


				string p_net_sev_description = argument.Description;
				command.Parameters.Add(new OracleParameter("p_net_sev_description", OracleDbType.Varchar2, p_net_sev_description, ParameterDirection.Input));
				string p_city_abreviation = argument.Settlement;
				command.Parameters.Add(new OracleParameter("p_city_abreviation", OracleDbType.Varchar2, p_city_abreviation, ParameterDirection.Input));
				string p_city = argument.Name;
				command.Parameters.Add(new OracleParameter("p_city", OracleDbType.Varchar2, p_city, ParameterDirection.Input));
				string p_municipality = argument.Municipality;
				command.Parameters.Add(new OracleParameter("p_municipality", OracleDbType.Varchar2, p_municipality, ParameterDirection.Input));
				string p_district = argument.Region;
				command.Parameters.Add(new OracleParameter("p_district", OracleDbType.Varchar2, p_district, ParameterDirection.Input));
				DateTime? p_from_date = argument.RightsOriginStartDate;
				command.Parameters.Add(new OracleParameter("p_from_date", OracleDbType.Date, p_from_date, ParameterDirection.Input));
				DateTime? p_to_date = argument.RightsOriginEndDate.Date;
				command.Parameters.Add(new OracleParameter("p_to_date", OracleDbType.Date, p_to_date, ParameterDirection.Input));

				OracleParameter p_out_notifications = new OracleParameter();
				p_out_notifications.Direction = ParameterDirection.Output;
				p_out_notifications.ParameterName = "p_out_notifications";
				p_out_notifications.OracleDbType = OracleDbType.RefCursor;
				command.Parameters.Add(p_out_notifications);

				OracleDataAdapter resultDataSet = new OracleDataAdapter(command);
				try
				{
					connection.Open();
					resultDataSet.Fill(ds);
					ds.Tables[0].TableName = "p_out_notifications";
				}
				finally
				{
					connection.Close();
				}

				DataSetMapper<GetNetworksAndServicesInfoResponseType> mapper = CreateGetNetworksAndServicesInfoMapper(accessMatrix);
				var result = new GetNetworksAndServicesInfoResponseType();
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

			mapper.AddDataSetObjectInitializer((ds) => (ds.Tables["p_out_notifications"].Rows.Count > 0) ? ds.Tables["p_out_notifications"].Rows[0] : null);
			mapper.AddDataRowMap((r) => r.CompaniesData.CompanyData, (dr) => dr.Table.DataSet.Tables["p_out_notifications"].Rows);

			mapper.AddDataColumnMap((r) => r.CompaniesData.CompanyData[0].CompanyName, "UL_NAME");
			mapper.AddDataColumnMap((r) => r.CompaniesData.CompanyData[0].CompanyType, "UL_TYPE");
			mapper.AddDataColumnMap((r) => r.CompaniesData.CompanyData[0].EIK, "EIK");
			mapper.AddDataColumnMap((r) => r.CompaniesData.CompanyData[0].HeadquartersAddress, "SEDALISHTE");
			mapper.AddDataColumnMap((r) => r.CompaniesData.CompanyData[0].ContactPersonData.ContactPersonName, "LK_NAME");
			mapper.AddDataColumnMap((r) => r.CompaniesData.CompanyData[0].ContactPersonData.PhoneNumberCode, "TEL_KOD");
			mapper.AddDataColumnMap((r) => r.CompaniesData.CompanyData[0].ContactPersonData.PhoneNumber, "TEL");
			mapper.AddDataColumnMap((r) => r.CompaniesData.CompanyData[0].NetworksAndServicesData.Type, "NET_SERVICE");
			mapper.AddDataColumnMap((r) => r.CompaniesData.CompanyData[0].NetworksAndServicesData.RightsOriginStartDate, "DATE_NADLEJNO");
			mapper.AddDataColumnMap((r) => r.CompaniesData.CompanyData[0].NetworksAndServicesData.Description, "USL_MRE_DESCR");
			mapper.AddDataColumnMap((r) => r.CompaniesData.CompanyData[0].NetworksAndServicesData.TerritorialScope.Settlement.Town, "GR_SELO");
			mapper.AddDataColumnMap((r) => r.CompaniesData.CompanyData[0].NetworksAndServicesData.TerritorialScope.Settlement.Name, "NAS_MESTO");
			mapper.AddDataColumnMap((r) => r.CompaniesData.CompanyData[0].NetworksAndServicesData.TerritorialScope.Settlement.Municipality, "OBSHTINA");
			mapper.AddDataColumnMap((r) => r.CompaniesData.CompanyData[0].NetworksAndServicesData.TerritorialScope.Settlement.Region, "OBLAST");
			mapper.AddDataColumnMap((r) => r.CompaniesData.CompanyData[0].NetworksAndServicesData.TerritorialScope.EstimatedActivityStartDate, "PREDPOLAG_DATA");
			mapper.AddDataColumnMap((r) => r.CompaniesData.CompanyData[0].NetworksAndServicesData.RightsOriginEndDate, "DATA_PREKRATIAVANE");

			return mapper;
		}

		private DataSetMapper<GetNetworksAndServicesInfoResponseType> CreateGetNetworksAndServicesInfoMapper(AccessMatrix accessMatrix)
		{
			DataSetMapper<GetNetworksAndServicesInfoResponseType> mapper = new DataSetMapper<GetNetworksAndServicesInfoResponseType>(accessMatrix);

			mapper.AddDataSetObjectInitializer((ds) => (ds.Tables["p_out_notifications"].Rows.Count > 0) ? ds.Tables["p_out_notifications"].Rows[0] : null);
			mapper.AddDataRowMap((r) => r.NetworksAndServicesData.NetworkAndServiceData, (dr) => dr.Table.DataSet.Tables["p_out_notifications"].Rows);

			mapper.AddDataColumnMap((r) => r.NetworksAndServicesData.NetworkAndServiceData[0].CompanyName, "UL_NAME");
			mapper.AddDataColumnMap((r) => r.NetworksAndServicesData.NetworkAndServiceData[0].CompanyType, "UL_TYPE");
			mapper.AddDataColumnMap((r) => r.NetworksAndServicesData.NetworkAndServiceData[0].EIK, "EIK");
			mapper.AddDataColumnMap((r) => r.NetworksAndServicesData.NetworkAndServiceData[0].HeadquartersAddress, "SEDALISHTE");
			mapper.AddDataColumnMap((r) => r.NetworksAndServicesData.NetworkAndServiceData[0].ContactPersonData.ContactPersonName, "LK_NAME");
			mapper.AddDataColumnMap((r) => r.NetworksAndServicesData.NetworkAndServiceData[0].ContactPersonData.PhoneNumberCode, "TEL_KOD");
			mapper.AddDataColumnMap((r) => r.NetworksAndServicesData.NetworkAndServiceData[0].ContactPersonData.PhoneNumber, "TEL");
			mapper.AddDataColumnMap((r) => r.NetworksAndServicesData.NetworkAndServiceData[0].NetworksAndServicesData.Type, "NET_SERVICE");
			mapper.AddDataColumnMap((r) => r.NetworksAndServicesData.NetworkAndServiceData[0].NetworksAndServicesData.RightsOriginStartDate, "DATE_NADLEJNO");
			mapper.AddDataColumnMap((r) => r.NetworksAndServicesData.NetworkAndServiceData[0].NetworksAndServicesData.Description, "USL_MRE_DESCR");
			mapper.AddDataColumnMap((r) => r.NetworksAndServicesData.NetworkAndServiceData[0].NetworksAndServicesData.TerritorialScope.Settlement.Town, "GR_SELO");
			mapper.AddDataColumnMap((r) => r.NetworksAndServicesData.NetworkAndServiceData[0].NetworksAndServicesData.TerritorialScope.Settlement.Name, "NAS_MESTO");
			mapper.AddDataColumnMap((r) => r.NetworksAndServicesData.NetworkAndServiceData[0].NetworksAndServicesData.TerritorialScope.Settlement.Municipality, "OBSHTINA");
			mapper.AddDataColumnMap((r) => r.NetworksAndServicesData.NetworkAndServiceData[0].NetworksAndServicesData.TerritorialScope.Settlement.Region, "OBLAST");
			mapper.AddDataColumnMap((r) => r.NetworksAndServicesData.NetworkAndServiceData[0].NetworksAndServicesData.TerritorialScope.EstimatedActivityStartDate, "PREDPOLAG_DATA");
			mapper.AddDataColumnMap((r) => r.NetworksAndServicesData.NetworkAndServiceData[0].NetworksAndServicesData.RightsOriginEndDate, "DATA_PREKRATIAVANE");

			return mapper;
		}
	}
}