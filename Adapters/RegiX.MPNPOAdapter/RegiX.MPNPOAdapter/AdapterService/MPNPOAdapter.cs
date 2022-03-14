using System;
using System.ComponentModel.Composition;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using TechnoLogica.RegiX.Adapters.Common.DataContracts;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Adapters.Common.ObjectMapping;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.DataContracts.Parameter;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.Common.Utils;

namespace TechnoLogica.RegiX.MPNPOAdapter.AdapterService
{
    [Export(typeof(IAdapterService))]
    [ExportFullName(typeof(MPNPOAdapter), typeof(IAdapterService))]
    [ExportSimpleName(typeof(MPNPOAdapter), typeof(IAdapterService))]
    public class MPNPOAdapter : SQLServerAdapterService.SQLServerAdapterService, IMPNPOAdapter
    {
        //public MPNPOAdapter()
        //{
        //    ConnectionString =
        //    new ParameterInfo<string>(@"Data Source=egov;Initial Catalog=NGO_WEB;Password=ngo;User ID=ngo")
        //    {
        //        Key = "ConnectionString",
        //        Description = "Connection string",
        //        OwnerAssembly = typeof(MPNPOAdapter).Assembly
        //    };
        //    }

        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(MPNPOAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> ConnectionString =
            new ParameterInfo<string>(@"Data Source=tlsql2012\mssql2012;Initial Catalog=Regix_Ngo;Password=regix;User ID=regix")
            {
                Key = Constants.ConnectionStringParameterKeyName,
                Description = "Connection string",
                OwnerAssembly = typeof(MPNPOAdapter).Assembly
            };

        public CommonSignedResponse<NPODetailsRequestType, NPODetailsResponseType> GetNPORegistrationInfo(NPODetailsRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(additionalParameters, new { Request = argument.Serialize(), Guid = id });
            try
            {
                SqlConnection connection = new SqlConnection(ConnectionString.Value);
                SqlCommand registrationInfo = new SqlCommand();
                registrationInfo.Connection = connection;
                registrationInfo.CommandType = System.Data.CommandType.Text;
                registrationInfo.CommandText = @"select [NgoId]
                                                      ,[RegistrationNumber]
                                                      ,[CompanyName]
                                                      ,[OrgForm]
                                                      ,[Address] + ' ' + ISNULL('обл.' + [SeatDistrict], '')
				                                             + ' ' + ISNULL('общ.' + [SeatMunicipality], '')
				                                             + ' ' + ISNULL('гр/с.' + [SeatSettlement], '') as [Address]
                                                      ,[ContactInfo]
                                                      ,[CourtName]
                                                      ,[LotNumber]
                                                      ,[NationalityCode]
                                                      ,[Nationality]
                                                      ,[BoardType]
                                                      ,CourtCaseNumber + ' ' + ISNULL([CourtCaseYear], '') as [CourtCase]
                                                      ,[NgoStatus]
                                                      ,[NgoStatusDate]
                                                      ,[Bulstat]
                                                from [dbo].[RegiXNGODetails]
                                                where ((LTRIM(RTRIM(Bulstat))))= LTRIM(RTRIM(@bulstat))";
                registrationInfo.Parameters.AddWithValue("@bulstat", argument.Bulstat);
                
                SqlCommand boardMembersInfo = new SqlCommand();
                boardMembersInfo.Connection = connection;
                boardMembersInfo.CommandType = System.Data.CommandType.Text;
                boardMembersInfo.CommandText = @"select [NgoId]
                                                      ,[Bulstat]
                                                      ,[NgoMemberId]
                                                      ,[BoardMemberName]
                                                      ,[DateFrom]
                                                      ,[DateTo]
                                                from [dbo].[RegiXNGOBoardMembers] 
                                                where ((LTRIM(RTRIM(Bulstat))))= LTRIM(RTRIM(@bulstat))";
                boardMembersInfo.Parameters.AddWithValue("@bulstat", argument.Bulstat);

                SqlDataAdapter registrationInfoDA = new SqlDataAdapter(registrationInfo);
                SqlDataAdapter boardMembersInfoDA = new SqlDataAdapter(boardMembersInfo);
                DataSet ds = new DataSet();
                ds.Tables.Add("NPORegistrationInfo");
                ds.Tables.Add("NPOBoardMembers");

                try
                {
                    connection.Open();
                    registrationInfoDA.Fill(ds.Tables["NPORegistrationInfo"]);
                    boardMembersInfoDA.Fill(ds.Tables["NPOBoardMembers"]);
                    ds.Tables["NPORegistrationInfo"].ChildRelations.Add(new DataRelation("RegistrationBoardMembers", ds.Tables["NPORegistrationInfo"].Columns["NgoId"], ds.Tables["NPOBoardMembers"].Columns["NgoId"], true));
                }
                finally
                {
                    connection.Close();
                }
                DataSetMapper<NPODetailsResponseType> mapper = CreateMPNPORegMap(accessMatrix);
                NPODetailsResponseType result = new NPODetailsResponseType();
                mapper.Map(ds, result);
                return
                    SigningUtils.CreateAndSign(
                        argument,
                        result,
                        accessMatrix,
                        additionalParameters
                    );
            }
            catch (Exception ex)
            {
                LogError(additionalParameters, ex, new { Guid = id });
                throw ex;
            }
        }

        public CommonSignedResponse<NPOStatusRequestType, NPOStatusResponseType> GetNPOStatusInfo(NPOStatusRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(additionalParameters, new { Request = argument.Serialize(), Guid = id });
            try
            {
                SqlConnection connection = new SqlConnection(ConnectionString.Value);
                SqlCommand npoStatusInfo = new SqlCommand();
                npoStatusInfo.Connection = connection;
                npoStatusInfo.CommandType = System.Data.CommandType.Text;
                npoStatusInfo.CommandText = @"select [regStatusID]
                                              ,[StatusCode]
                                              ,[StatusName]
                                              ,[RegisterID]
                                              ,[CompanyName]
                                              ,[OrgForm]
                                              ,[Bulstat] 
                                            FROM [dbo].[RegixNGOStatusData]
                                            WHERE ((LTRIM(RTRIM(Bulstat))))= LTRIM(RTRIM(@bulstat))";
                npoStatusInfo.Parameters.AddWithValue("@bulstat", argument.Bulstat);


                SqlDataAdapter npoStatusInfoDA = new SqlDataAdapter(npoStatusInfo);
                DataSet ds = new DataSet();
                ds.Tables.Add("NPOStatusInfo");

                try
                {
                    connection.Open();
                    npoStatusInfoDA.Fill(ds.Tables["NPOStatusInfo"]);
                }
                finally
                {
                    connection.Close();
                }
                DataSetMapper<NPOStatusResponseType> mapper = CreateMPNPOStatusMap(accessMatrix);
                NPOStatusResponseType result = new NPOStatusResponseType();
                mapper.Map(ds, result);
                return
                    SigningUtils.CreateAndSign(
                        argument,
                        result,
                        accessMatrix,
                        additionalParameters
                    );
            }

            catch (Exception ex)
            {
                LogError(additionalParameters, ex, new { Guid = id });
                throw ex;
            }
        }

        private static DataSetMapper<NPODetailsResponseType> CreateMPNPORegMap(AccessMatrix accessMatrix)
        {
            DataSetMapper<NPODetailsResponseType> mapper = new DataSetMapper<NPODetailsResponseType>(accessMatrix);

            mapper.AddDataSetObjectInitializer((ds) => (ds.Tables["NPORegistrationInfo"].Rows.Count == 1) ? ds.Tables["NPORegistrationInfo"].Rows[0] : null);

            mapper.AddDataColumnMap((f) => f.RegistrationNumber, "RegistrationNumber");
            mapper.AddDataColumnMap((f) => f.Name, "CompanyName");
            mapper.AddDataColumnMap((f) => f.OrgForm, "OrgForm");
            mapper.AddDataColumnMap((f) => f.Address, "Address");
            mapper.AddDataColumnMap((f) => f.ContactInfo, "ContactInfo");
            mapper.AddDataColumnMap((f) => f.BoardType, "BoardType");
            mapper.AddDataColumnMap((f) => f.LotNumber, "LotNumber");
            mapper.AddDataColumnMap((f) => f.CourtCase, "CourtCase", o => o.ToString());
            mapper.AddDataColumnMap((f) => f.CourtName, "CourtName");
            mapper.AddDataColumnMap((f) => f.NationalityCode, "NationalityCode");
            mapper.AddDataColumnMap((f) => f.Nationality, "Nationality");
            
            mapper.AddDataRowMap((f) => f.BoardMembers, (dr) => dr.GetChildRows("RegistrationBoardMembers"));

            mapper.AddDataColumnMap((f) => f.BoardMembers[0].Name, "BoardMemberName");
            mapper.AddDataColumnMap((f) => f.BoardMembers[0].DateFrom, "DateFrom");
            mapper.AddDataColumnMap((f) => f.BoardMembers[0].DateTo, "DateTo");

            return mapper;
        }

        private static DataSetMapper<NPOStatusResponseType> CreateMPNPOStatusMap(AccessMatrix accessMatrix)
        {
            DataSetMapper<NPOStatusResponseType> mapper = new DataSetMapper<NPOStatusResponseType>(accessMatrix);

            mapper.AddDataSetObjectInitializer((ds) => (ds.Tables["NPOStatusInfo"].Rows.Count == 1) ? ds.Tables["NPOStatusInfo"].Rows[0] : null);

            mapper.AddDataColumnMap((f) => f.Name, "CompanyName");
            mapper.AddDataColumnMap((f) => f.OrgForm, "OrgForm");
            mapper.AddDataColumnMap((f) => f.Status, "StatusName");
            mapper.AddDataColumnMap((f) => f.StatusCode, "StatusCode");
            
            return mapper;
        }
    }
}
