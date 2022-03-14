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

namespace TechnoLogica.RegiX.CRCTransferredRightsAdapter.AdapterService
{
    [Export(typeof(IAdapterService))]
    [ExportFullName(typeof(CRCTransferredRightsAdapter), typeof(IAdapterService))]
    [ExportSimpleName(typeof(CRCTransferredRightsAdapter), typeof(IAdapterService))]
    public class CRCTransferredRightsAdapter : OracleAdapterService.OracleBaseAdapterService, ICRCTransferredRightsAdapter, IAdapterService
    {
        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(CRCTransferredRightsAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> ConnectionString =
           new ParameterInfo<string>(@"Data Source =; User ID = ; Password=;")
           {
               Key = Constants.ConnectionStringParameterKeyName,
               Description = "Connection string",
               OwnerAssembly = typeof(CRCTransferredRightsAdapter).Assembly
           };

        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(CRCTransferredRightsAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> GetRentedIOORInfoProcedureName =
            new ParameterInfo<string>("regix_registers.get_leased")
            {
                Key = "GetCompanyInfoProcedureName",
                Description = "the procedure which is called by GetRentedIOORInfo()",
                OwnerAssembly = typeof(CRCTransferredRightsAdapter).Assembly
            };

        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(CRCTransferredRightsAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> GetTransferredRightsInfoProcedureName =
            new ParameterInfo<string>("regix_registers.get_transfered")
            {
                Key = "GetNetworksAndServicesInfoProcedureName",
                Description = "the procedure which is called by GetTransferredRightsInfo()",
                OwnerAssembly = typeof(CRCTransferredRightsAdapter).Assembly
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
        public CommonSignedResponse<GetRentedIOORInfoRequest, GetRentedIOORInfoResponseType> GetRentedIOORInfo(GetRentedIOORInfoRequest argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(additionalParameters, new { Request = argument.XmlSerialize(), Guid = id });
            try
            {
                OracleConnection connection = new OracleConnection(@"Data Source =; User ID = ; Password=;");
                DataSet ds = new DataSet();

                OracleCommand command = new OracleCommand();
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "regix_registers.get_leased"; // GetRentedIOORInfoProcedureName.Value; 

                string p_receiver_name = argument.TenantName;
                command.Parameters.Add(new OracleParameter("p_receiver_name", OracleDbType.Varchar2, p_receiver_name, ParameterDirection.Input));
                string p_receiver_type = argument.TenantType;
                command.Parameters.Add(new OracleParameter("p_receiver_type", OracleDbType.Varchar2, p_receiver_type, ParameterDirection.Input));
                string p_permition = argument.TenantPermission;
                command.Parameters.Add(new OracleParameter("p_permition", OracleDbType.Varchar2, p_permition, ParameterDirection.Input));
                DateTime? p_transf_date_from = argument.RentalFromDate;
                command.Parameters.Add(new OracleParameter("p_transf_date_from", OracleDbType.Date, p_transf_date_from, ParameterDirection.Input));
                DateTime? p_transf_date_to = argument.RentalToDate;
                command.Parameters.Add(new OracleParameter("p_transf_date_to", OracleDbType.Date, p_transf_date_to, ParameterDirection.Input));
                DateTime? p_end_date_from = argument.EndOfActionFromDate;
                command.Parameters.Add(new OracleParameter("p_end_date_from", OracleDbType.Date, p_end_date_from, ParameterDirection.Input));
                DateTime? p_end_date_to = argument.EndOfActionToDate;
                command.Parameters.Add(new OracleParameter("p_end_date_to", OracleDbType.Date, p_end_date_to, ParameterDirection.Input));
                string p_giving_name = argument.LandlordName;
                command.Parameters.Add(new OracleParameter("p_giving_name", OracleDbType.Varchar2, p_giving_name, ParameterDirection.Input));
                string p_giving_type = argument.LandlordType;
                command.Parameters.Add(new OracleParameter("p_giving_type", OracleDbType.Varchar2, p_giving_type, ParameterDirection.Input));
                string p_permition_g = argument.Permission;
                command.Parameters.Add(new OracleParameter("p_permition_g", OracleDbType.Varchar2, p_permition_g, ParameterDirection.Input));
                DateTime? p_issue_date_from = argument.IssueFromDate;
                command.Parameters.Add(new OracleParameter("p_issue_date_from", OracleDbType.Date, p_issue_date_from, ParameterDirection.Input));
                DateTime? p_issue_date_to = argument.IssueToDate;
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
                DataSetMapper<GetRentedIOORInfoResponseType> mapper = CreateGetRentedIOORInfoMapper(accessMatrix);
                var result = new GetRentedIOORInfoResponseType();
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

        public CommonSignedResponse<GetTransferredRightsRequest, GetTransferredRightsInfoResponseType> GetTransferredRightsInfo(GetTransferredRightsRequest argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(additionalParameters, new { Request = argument.XmlSerialize(), Guid = id });
            try
            {
                OracleConnection connection = new OracleConnection(@"Data Source =; User ID = ; Password=;");
                DataSet ds = new DataSet();

                OracleCommand command = new OracleCommand();
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "regix_registers.get_transfered"; // GetTransferredRightsInfoProcedureName.Value; 

                string p_receiver_name = argument.PurchaserName;
                command.Parameters.Add(new OracleParameter("p_receiver_name", OracleDbType.Varchar2, p_receiver_name, ParameterDirection.Input));
                string p_receiver_type = argument.Type;
                command.Parameters.Add(new OracleParameter("p_receiver_type", OracleDbType.Varchar2, p_receiver_type, ParameterDirection.Input));
                string p_permition = argument.Permission;
                command.Parameters.Add(new OracleParameter("p_permition", OracleDbType.Varchar2, p_permition, ParameterDirection.Input));
                DateTime? p_transf_date_from = argument.TransferFromDate;
                command.Parameters.Add(new OracleParameter("p_transf_date_from", OracleDbType.Date, p_transf_date_from, ParameterDirection.Input));
                DateTime? p_transf_date_to = argument.TransferToDate;
                command.Parameters.Add(new OracleParameter("p_transf_date_to", OracleDbType.Date, p_transf_date_to, ParameterDirection.Input));
                DateTime? p_end_date_from = argument.EndOfActionFromDate;
                command.Parameters.Add(new OracleParameter("p_end_date_from", OracleDbType.Date, p_end_date_from, ParameterDirection.Input));
                DateTime? p_end_date_to = argument.EndOfActionToDate;
                command.Parameters.Add(new OracleParameter("p_end_date_to", OracleDbType.Date, p_end_date_to, ParameterDirection.Input));
                string p_giving_name = argument.AttorneyName;
                command.Parameters.Add(new OracleParameter("p_giving_name", OracleDbType.Varchar2, p_giving_name, ParameterDirection.Input));
                string p_giving_type = argument.AttorneyType;
                command.Parameters.Add(new OracleParameter("p_giving_type", OracleDbType.Varchar2, p_giving_type, ParameterDirection.Input));
                string p_permition_g = argument.AttorneyPermission;
                command.Parameters.Add(new OracleParameter("p_permition_g", OracleDbType.Varchar2, p_permition_g, ParameterDirection.Input));
                DateTime? p_issue_date_from = argument.IssueFromDate;
                command.Parameters.Add(new OracleParameter("p_issue_date_from", OracleDbType.Date, p_issue_date_from, ParameterDirection.Input));
                DateTime? p_issue_date_to = argument.IssueToDate;
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
                DataSetMapper<GetTransferredRightsInfoResponseType> mapper = CreateGetTransferredRightsInfoMapper(accessMatrix);
                var result = new GetTransferredRightsInfoResponseType();
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

        private DataSetMapper<GetRentedIOORInfoResponseType> CreateGetRentedIOORInfoMapper(AccessMatrix accessMatrix)
        {
            DataSetMapper<GetRentedIOORInfoResponseType> mapper = new DataSetMapper<GetRentedIOORInfoResponseType>(accessMatrix);
            mapper.AddDataSetObjectInitializer((ds) => (ds.Tables["p_out_records"].Rows.Count > 0) ? ds.Tables["p_out_records"].Rows[0] : null);
            mapper.AddDataRowMap((r) => r.RentedResourcesInfo.RentedResourceInfo, (dr) => dr.Table.DataSet.Tables["p_out_records"].Rows);

            mapper.AddDataColumnMap((r) => r.RentedResourcesInfo.RentedResourceInfo[0].TenantCompanyData.CompanyName, "RES_NAME");
            mapper.AddDataColumnMap((r) => r.RentedResourcesInfo.RentedResourceInfo[0].TenantCompanyData.CompanyType, "RES_TYPE");
            mapper.AddDataColumnMap((r) => r.RentedResourcesInfo.RentedResourceInfo[0].TenantCompanyData.IssueDate, "RES_PERM_DATE");
            mapper.AddDataColumnMap((r) => r.RentedResourcesInfo.RentedResourceInfo[0].TenantCompanyData.EndOfActionDate, "RIGHT_DATE_END");

            mapper.AddDataColumnMap((r) => r.RentedResourcesInfo.RentedResourceInfo[0].LandlordCompanyData.CompanyName, "GEB_NAME");
            mapper.AddDataColumnMap((r) => r.RentedResourcesInfo.RentedResourceInfo[0].LandlordCompanyData.CompType, "GEB_TYPE");
            mapper.AddDataColumnMap((r) => r.RentedResourcesInfo.RentedResourceInfo[0].LandlordCompanyData.PermissionNumber, "GEB_PERM_IOOR");
            mapper.AddDataColumnMap((r) => r.RentedResourcesInfo.RentedResourceInfo[0].LandlordCompanyData.IssueDate, "GEB_PERM_DATE");

            mapper.AddDataColumnMap((r) => r.RentedResourcesInfo.RentedResourceInfo[0].RentedLimitedResource.TeritorialScope, "RIGHT_TERIT");
            mapper.AddDataColumnMap((r) => r.RentedResourcesInfo.RentedResourceInfo[0].RentedLimitedResource.FrequencyRange, "RIGHT_FREQ");
            mapper.AddDataColumnMap((r) => r.RentedResourcesInfo.RentedResourceInfo[0].RentedLimitedResource.BlocksCount, "RIGHT_NUMB_BLOCKS");
            mapper.AddDataColumnMap((r) => r.RentedResourcesInfo.RentedResourceInfo[0].RentedLimitedResource.TotalSpectrum, "RIGHT_SPCTRUM");
            mapper.AddDataColumnMap((r) => r.RentedResourcesInfo.RentedResourceInfo[0].RentedLimitedResource.PeriodStartDate, "RIGHT_DATE_START");
            mapper.AddDataColumnMap((r) => r.RentedResourcesInfo.RentedResourceInfo[0].RentedLimitedResource.PeriodStartDate, "RIGHT_DATE_END");
            mapper.AddDataColumnMap((r) => r.RentedResourcesInfo.RentedResourceInfo[0].RentedLimitedResource.Remark, "DESCR");

            return mapper;
        }

        private DataSetMapper<GetTransferredRightsInfoResponseType> CreateGetTransferredRightsInfoMapper(AccessMatrix accessMatrix)
        {
            DataSetMapper<GetTransferredRightsInfoResponseType> mapper = new DataSetMapper<GetTransferredRightsInfoResponseType>(accessMatrix);
            mapper.AddDataSetObjectInitializer((ds) => (ds.Tables["p_out_records"].Rows.Count > 0) ? ds.Tables["p_out_records"].Rows[0] : null);
            mapper.AddDataRowMap((r) => r.TransferredRights.TransferredRightInfo, (dr) => dr.Table.DataSet.Tables["p_out_records"].Rows);

            mapper.AddDataColumnMap((r) => r.TransferredRights.TransferredRightInfo[0].PurchaserCompanyData.CompanyName, "RES_NAME");
            mapper.AddDataColumnMap((r) => r.TransferredRights.TransferredRightInfo[0].PurchaserCompanyData.CompType, "RES_TYPE");
            mapper.AddDataColumnMap((r) => r.TransferredRights.TransferredRightInfo[0].PurchaserCompanyData.IssueDate, "RES_PERM_DATE");
            mapper.AddDataColumnMap((r) => r.TransferredRights.TransferredRightInfo[0].PurchaserCompanyData.EndDate, "RES_PERM_DATE_END");

            mapper.AddDataColumnMap((r) => r.TransferredRights.TransferredRightInfo[0].CompanyName.CompanyName, "GEB_NAME");
            mapper.AddDataColumnMap((r) => r.TransferredRights.TransferredRightInfo[0].CompanyName.CompType, "GEB_TYPE");
            mapper.AddDataColumnMap((r) => r.TransferredRights.TransferredRightInfo[0].CompanyName.PermissionNumber, "GEB_PERM_IOOR");
            mapper.AddDataColumnMap((r) => r.TransferredRights.TransferredRightInfo[0].CompanyName.IssueDate, "GEB_PERM_DATE");
            mapper.AddDataColumnMap((r) => r.TransferredRights.TransferredRightInfo[0].CompanyName.EndDate, "GEB_PERM_DATE_END");

            mapper.AddDataColumnMap((r) => r.TransferredRights.TransferredRightInfo[0].TransferredRightsInfo, "INFO");
           
            return mapper;
        }
    }
}