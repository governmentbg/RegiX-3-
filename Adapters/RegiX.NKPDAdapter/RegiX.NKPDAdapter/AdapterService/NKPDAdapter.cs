using System;
using System.Data;
using System.Data.SqlClient;
using TechnoLogica.RegiX.Common.Utils;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.ObjectMapping;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Adapters.Common.DataContracts;
using TechnoLogica.RegiX.Common.DataContracts.Parameter;
using TechnoLogica.RegiX.Adapters.Common.ObjectMapping;

namespace TechnoLogica.RegiX.NKPDAdapter.AdapterService
{
    [Export(typeof(IAdapterService))]
    [ExportFullName(typeof(NKPDAdapter), typeof(IAdapterService))]
    [ExportSimpleName(typeof(NKPDAdapter), typeof(IAdapterService))]
    public class NKPDAdapter : SQLServerAdapterService.SQLServerAdapterService, INKPDAdapter, IAdapterService
    {

        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(NKPDAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> ConnectionString =
            new ParameterInfo<string>("Data Source=egov;Initial Catalog=NKPD;Password=;User ID=")
            {
                Key = Constants.ConnectionStringParameterKeyName,
                Description = "Connection string",
                OwnerAssembly = typeof(NKPDAdapter).Assembly
            };


        public CommonSignedResponse<AllNKPDDataSearchType, AllNKPDDataType> GetNKPDAllData(AllNKPDDataSearchType allNkpdSearch, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(additionalParameters, new { Request = allNkpdSearch.XmlSerialize(), Guid = id });
            try
            {
                SqlConnection connection = new SqlConnection(ConnectionString.Value);
                DataSet ds = new DataSet();
                //NKPD
                SqlCommand commandNKPD = new SqlCommand();
                commandNKPD.Connection = connection;
                commandNKPD.CommandType = CommandType.Text; ;
                commandNKPD.CommandText = @"Select n.Type, n.Code, n.Name, n.ClassCode, n.SubclassCode, n.GroupCode, n.IndividualGroupCode, n.EducationLevelCode 
                                          from NKPD n join Versions v on n.VersionID = v.ID 
                                         where @activeDate between v.datefrom and v.dateto 
                                           and @activeDate between n.datefrom and n.dateto 
                                       ";
                commandNKPD.Parameters.AddWithValue("@activeDate", allNkpdSearch.ValidDate);
                SqlDataAdapter daNKPD = new SqlDataAdapter(commandNKPD);
                ds.Tables.Add("NKPD");
                try
                {
                    connection.Open();
                    daNKPD.Fill(ds.Tables["NKPD"]);

                }
                finally
                {
                    connection.Close();
                }

                string versionName = GetVersionName(allNkpdSearch.ValidDate);
                DataSetMapper<AllNKPDDataType> routesMapper = CreateMapAllNKPD(accessMatrix, allNkpdSearch.ValidDate, versionName);
                AllNKPDDataType result = new AllNKPDDataType();
                routesMapper.Map(ds, result);
                return SigningUtils.CreateAndSign(
                    allNkpdSearch,
                    result,
                    accessMatrix,
                    additionalParameters);
            }
            catch (Exception ex)
            {
                LogError(additionalParameters, ex, new { Guid = id });
                throw ex;
            }
        }

        private string GetVersionName(DateTime ValidDate)
        {
            string versionName = String.Empty;

            SqlConnection connection = new SqlConnection(ConnectionString.Value);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = @"SELECT Name FROM Versions v where @activeDate between v.DateFrom and v.DateTo";
            cmd.Parameters.AddWithValue("@activeDate", ValidDate);

            try
            {
                connection.Open();
                versionName = (string)cmd.ExecuteScalar();

            }
            finally
            {
                connection.Close();
            }
            return versionName;
        }

        private static DataSetMapper<AllNKPDDataType> CreateMapAllNKPD(AccessMatrix accessMatrix, DateTime validDate, string VersionName)
        {
            DataSetMapper<AllNKPDDataType> routesMapper = new DataSetMapper<AllNKPDDataType>(accessMatrix);

            routesMapper.AddDataSetMap((r) => r.NKPD, (d) => d.Tables["NKPD"].Rows);
            routesMapper.AddDataColumnMap((r) => r.NKPD[0].Type, "Type");
            routesMapper.AddDataColumnMap((r) => r.NKPD[0].Code, "Code");
            routesMapper.AddDataColumnMap((r) => r.NKPD[0].Name, "Name");
            routesMapper.AddDataColumnMap((r) => r.NKPD[0].ClassCode, "ClassCode");
            routesMapper.AddDataColumnMap((r) => r.NKPD[0].SubclassCode, "SubclassCode");
            routesMapper.AddDataColumnMap((r) => r.NKPD[0].GroupCode, "GroupCode");
            routesMapper.AddDataColumnMap((r) => r.NKPD[0].IndividualGroupCode, "IndividualGroupCode");
            routesMapper.AddDataColumnMap((r) => r.NKPD[0].EducationLevelCode, "EducationLevelCode");

            routesMapper.AddConstantMap((r) => r.ValidDate, validDate);
            routesMapper.AddConstantMap((r) => r.VersionName, VersionName);

            return routesMapper;
        }




        public CommonSignedResponse<NKPDDataSearchType, NKPDDataType> GetNKPDData(NKPDDataSearchType nkpdDataSearch, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(additionalParameters, new { Request = nkpdDataSearch.XmlSerialize(), Guid = id });
            try
            {
                SqlConnection connection = new SqlConnection(ConnectionString.Value);
                DataSet ds = new DataSet();
                //NKPD
                SqlCommand commandNKPD = new SqlCommand();
                commandNKPD.Connection = connection;
                commandNKPD.CommandType = CommandType.Text; ;
                commandNKPD.CommandText = @"Select n.Type, n.Code, n.Name, n.ClassCode, n.SubclassCode, n.GroupCode, n.IndividualGroupCode, n.EducationLevelCode 
                                          from NKPD n join Versions v on n.VersionID = v.ID 
                                         where @p_activeDate between v.datefrom and v.dateto 
                                           and @p_activeDate between n.datefrom and n.dateto
                                           and (@p_code is null or n.Code like @p_code + '%') 
                                           and (@p_name is null or upper(n.Name) like '%' + upper(@p_name) + '%')
                                       ";
                commandNKPD.Parameters.AddWithValue("@p_activeDate", nkpdDataSearch.ValidDate);
                commandNKPD.Parameters.AddWithValue("@p_code", GetNullableParameterValue(nkpdDataSearch.Code));
                commandNKPD.Parameters.AddWithValue("@p_name", GetNullableParameterValue(nkpdDataSearch.Name));

                SqlDataAdapter daNKPD = new SqlDataAdapter(commandNKPD);
                ds.Tables.Add("NKPD");
                try
                {
                    connection.Open();
                    daNKPD.Fill(ds.Tables["NKPD"]);

                }
                finally
                {
                    connection.Close();
                }
                string versionName = GetVersionName(nkpdDataSearch.ValidDate);
                DataSetMapper<NKPDDataType> routesMapper = CreateMapNKPD(accessMatrix, nkpdDataSearch.ValidDate, versionName);
                NKPDDataType result = new NKPDDataType();
                routesMapper.Map(ds, result);
                return SigningUtils.CreateAndSign(
                    nkpdDataSearch,
                    result,
                    accessMatrix,
                    additionalParameters);

            }
            catch (Exception ex)
            {
                LogError(additionalParameters, ex, new { Guid = id });
                throw ex;
            }

        }

        private static DataSetMapper<NKPDDataType> CreateMapNKPD(AccessMatrix accessMatrix, DateTime validDate, string VersionName)
        {
            DataSetMapper<NKPDDataType> routesMapper = new DataSetMapper<NKPDDataType>(accessMatrix);

            routesMapper.AddDataSetMap((r) => r.NKPD, (d) => d.Tables["NKPD"].Rows);
            routesMapper.AddDataColumnMap((r) => r.NKPD[0].Type, "Type");
            routesMapper.AddDataColumnMap((r) => r.NKPD[0].Code, "Code");
            routesMapper.AddDataColumnMap((r) => r.NKPD[0].Name, "Name");
            routesMapper.AddDataColumnMap((r) => r.NKPD[0].ClassCode, "ClassCode");
            routesMapper.AddDataColumnMap((r) => r.NKPD[0].SubclassCode, "SubclassCode");
            routesMapper.AddDataColumnMap((r) => r.NKPD[0].GroupCode, "GroupCode");
            routesMapper.AddDataColumnMap((r) => r.NKPD[0].IndividualGroupCode, "IndividualGroupCode");
            routesMapper.AddDataColumnMap((r) => r.NKPD[0].EducationLevelCode, "EducationLevelCode");

            routesMapper.AddConstantMap((r) => r.ValidDate, validDate);
            routesMapper.AddConstantMap((r) => r.VersionName, VersionName);

            return routesMapper;
        }

        private object GetNullableParameterValue(string paramValue)
        {
            if (String.IsNullOrEmpty(paramValue))
            {
                return DBNull.Value;
            }
            else
            {
                return paramValue;
            }
        }

    }
}
