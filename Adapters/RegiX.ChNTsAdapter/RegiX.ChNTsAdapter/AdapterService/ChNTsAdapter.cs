using System;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.Common.Utils;
using System.ComponentModel.Composition;
using System.Data.SqlClient;
using System.Data;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Adapters.Common.DataContracts;
using TechnoLogica.RegiX.Common.DataContracts.Parameter;
using TechnoLogica.RegiX.Adapters.Common.ObjectMapping;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;

namespace TechnoLogica.RegiX.ChNTsAdapter.AdapterService
{
    [Export(typeof(IAdapterService))]
    [ExportFullName(typeof(ChNTsAdapter), typeof(IAdapterService))]
    [ExportSimpleName(typeof(ChNTsAdapter), typeof(IAdapterService))]
    public class ChNTsAdapter : SQLServerAdapterService.SQLServerAdapterService, IChNTsAdapter, IAdapterService
    {
        //public ChNTsAdapter()
        //{
        //    ConnectionString =
        //    new ParameterInfo<string>("data source=;initial catalog=;user id=chnts;password=;")
        //    {
        //        Key = "ConnectionString",
        //        Description = "Connection string",
        //        OwnerAssembly = typeof(ChNTsAdapter).Assembly
        //    };
        //}

        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(ChNTsAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> ConnectionString =
            new ParameterInfo<string>(@"Data Source=;Initial Catalog=;Password=;User ID=")
            {
                Key = Constants.ConnectionStringParameterKeyName,
                Description = "Connection string",
                OwnerAssembly = typeof(ChNTsAdapter).Assembly
            };

        public CommonSignedResponse<ForeignerPermissionsRequestType, ForeignerPermissionsResponseType> GetForeignerPermissions(ForeignerPermissionsRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
            try
            {
            SqlConnection connection = new SqlConnection(ConnectionString.Value);
            DataSet ds = new DataSet();

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text; ;
            string birthDateWhereClause = (argument.BirthDateSpecified ? "and (t.BirthDate = @birthDate)" : "");
            command.CommandText = @"select *
                                            from [dbo].[RegiXForeignersData] t
                                            where @searchDate > t.ValidFrom and (@searchDate < t.ValidTo or t.ValidTo is null)
                                            and (upper (t.NamesLatin)) like '%' + upper(@namesLatin) + '%'"                                            
                                            + birthDateWhereClause + 
                                            "and (@LNCh is null or t.LNCh = @LNCh)";

            command.Parameters.AddWithValue("@searchDate", argument.SearchDate);
            command.Parameters.AddWithValue("@namesLatin", argument.NamesLatin);
            if(argument.BirthDateSpecified)
                command.Parameters.AddWithValue("@birthDate", argument.BirthDate);
            command.Parameters.AddWithValue("@LNCh", argument.GetValueOrNull(r => r.LNCh));
            SqlDataAdapter resultDataSet = new SqlDataAdapter(command);
            ds.Tables.Add("ForeignersData");
            try
            {
                connection.Open();
                resultDataSet.Fill(ds.Tables["ForeignersData"]);

            }
            finally
            {
                connection.Close();
            }

            DataSetMapper<ForeignerPermissionsResponseType> mapper = CreateMap(accessMatrix, argument.SearchDate);
            ForeignerPermissionsResponseType result = new ForeignerPermissionsResponseType();
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

        private DataSetMapper<ForeignerPermissionsResponseType> CreateMap(AccessMatrix accessMatrix, DateTime searchDate)
        {
            DataSetMapper<ForeignerPermissionsResponseType> mapper = new DataSetMapper<ForeignerPermissionsResponseType>(accessMatrix);

            mapper.AddDataSetMap((r) => r.PermissionData, (d) => d.Tables["ForeignersData"].Rows);
            //mapper.AddDataColumnMap((r) => r.PermissionData[0].BatchNumber, "BatchNumber");
            mapper.AddDataColumnMap((r) => r.PermissionData[0].NationalityCode, "NationalityCode");
            mapper.AddDataColumnMap((r) => r.PermissionData[0].NationalityName, "NationalityName");
            mapper.AddDataColumnMap((r) => r.PermissionData[0].StatusCode, "StatusCode");
            mapper.AddDataColumnMap((r) => r.PermissionData[0].StatusName, "StatusName");
            mapper.AddDataColumnMap((r) => r.PermissionData[0].NamesLatin, "NamesLatin");
            mapper.AddDataColumnMap((r) => r.PermissionData[0].NamesCyrillic, "NamesCyrillic");
            mapper.AddDataColumnMap((r) => r.PermissionData[0].Resolution.OrderNumber, "ResolutionOrderNumber");
            mapper.AddDataColumnMap((r) => r.PermissionData[0].Resolution.OrderDate, "ResolutionOrderDate");
            mapper.AddDataColumnMap((r) => r.PermissionData[0].Permission.DateFrom, "PermissionDateFrom");
            mapper.AddDataColumnMap((r) => r.PermissionData[0].Permission.DateTo, "PermissionDateTo");
            mapper.AddDataColumnMap((r) => r.PermissionData[0].Permission.ActivityType, "PermissionActivityType");
            mapper.AddDataColumnMap((r) => r.PermissionData[0].Permission.NonprofitEntityName, "PermissionNonprofitEntityName");
            mapper.AddDataColumnMap((r) => r.PermissionData[0].Permission.Address.DistrictCode, "DistrictCode");
            mapper.AddDataColumnMap((r) => r.PermissionData[0].Permission.Address.DistrictName, "DistrictName");
            mapper.AddDataColumnMap((r) => r.PermissionData[0].Permission.Address.MunicipalityCode, "MunicipalityCode");
            mapper.AddDataColumnMap((r) => r.PermissionData[0].Permission.Address.MunicipalityName, "MunicipalityName");
            mapper.AddDataColumnMap((r) => r.PermissionData[0].Permission.Address.TerritorialUnitCode, "SettlementCode");
            mapper.AddDataColumnMap((r) => r.PermissionData[0].Permission.Address.TerritorialUnitName, "SettlementName");
            mapper.AddDataColumnMap((r) => r.PermissionData[0].Permission.Address.AddressDescription, "AddressDescription");

            mapper.AddConstantMap((r) => r.SearchDate, searchDate);

            return mapper;
        }



    }
}
