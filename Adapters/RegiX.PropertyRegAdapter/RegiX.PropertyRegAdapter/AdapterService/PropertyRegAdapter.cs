using System;
using System.Collections.Generic;
using System.Linq;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.Common.Utils;
using System.ComponentModel.Composition;
using System.Data;
using System.Globalization;
using TechnoLogica.RegiX.Common.DataContracts;
using Oracle.ManagedDataAccess.Client;
using TechnoLogica.RegiX.OracleAdapterService;
using System.Configuration;
using TechnoLogica.RegiX.Adapters.Common.DataContracts;
using TechnoLogica.RegiX.Common.DataContracts.Parameter;
using TechnoLogica.RegiX.Adapters.Common.ObjectMapping;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;

namespace TechnoLogica.RegiX.PropertyRegAdapter.AdapterService
{
    [Export(typeof(IAdapterService))]
    [ExportFullName(typeof(PropertyRegAdapter), typeof(IAdapterService))]
    [ExportSimpleName(typeof(PropertyRegAdapter), typeof(IAdapterService))]
    // Данните за имената на колоните се взимат от Web.config-a на адаптера
    public class PropertyRegAdapter : OracleBaseAdapterService, IPropertyRegAdapter, IAdapterService
    {
        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(PropertyRegAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> ConnectionString =
            new ParameterInfo<string>("data source=egov/egov;password=;persist security info=True;user id=")
            {
                Key = Constants.ConnectionStringParameterKeyName,
                Description = "Connection String for Oracle datatabase",
                OwnerAssembly = typeof(PropertyRegAdapter).Assembly
            };

        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(PropertyRegAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> SchemaName =
            new ParameterInfo<string>("prop_reg.iiscir_eGov")
            {
                Key = "SchemaName",
                Description = "Schema name",
                OwnerAssembly = typeof(PropertyRegAdapter).Assembly
            };

        #region GetEntityInfo - 1. Справка по персонална партида на юридическо лице

        public CommonSignedResponse<EntityInfoRequestType, EntityInfoResponseType> GetEntityInfo(EntityInfoRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });            
            try
            {
                OracleConnection connection = new OracleConnection(ConnectionString.Value);
                DataSet ds = new DataSet();
                
                OracleCommand command = new OracleCommand();
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = SchemaName.Value + ".selbyperson_all_site2";
                command.Parameters.Add(new OracleParameter("p_egn", OracleDbType.Varchar2, DBNull.Value, ParameterDirection.Input));
                command.Parameters.Add(new OracleParameter("p_bulstat", OracleDbType.Varchar2, argument.EIK, ParameterDirection.Input));
                command.Parameters.Add(new OracleParameter("p_date_from", OracleDbType.Date, argument.DateFrom, ParameterDirection.Input));
                command.Parameters.Add(new OracleParameter("p_date_to", OracleDbType.Date, argument.DateTo, ParameterDirection.Input));
                command.Parameters.Add(new OracleParameter("p_book_type_id", OracleDbType.Varchar2, DBNull.Value, ParameterDirection.Input));
                command.Parameters.Add(new OracleParameter("p_act_type_id", OracleDbType.Varchar2, DBNull.Value, ParameterDirection.Input));
                command.Parameters.Add(new OracleParameter("p_site_id", OracleDbType.Varchar2, argument.SiteID, ParameterDirection.Input));
                command.Parameters.Add(new OracleParameter("outcursor", OracleDbType.RefCursor, ParameterDirection.Output));

                OracleDataAdapter resultDataAdapter = new OracleDataAdapter(command);

                try
                {
                    connection.Open();
                    resultDataAdapter.Fill(ds);
                }
                finally
                {
                    connection.Close();
                }

                //LogToDatabase(aditionalParameters, null, argument.EIK, null, "001:Справка по персонална партида на юридическо лице", argument, id);

                //Конструиране на dataset за маппинг
                DataSet resulDS = new DataSet();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    string columnIsRefusal = GetConfigColumn("sp_all_site2_IsRefusal");
                    string columnLeId = GetConfigColumn("sp_all_site2_LeId");
                    string columnSiteId = GetConfigColumn("sp_all_site2_SiteId");
                    string columnSiteName = GetConfigColumn("sp_all_site2_SiteName");
                    string columnSiteStartDate = GetConfigColumn("sp_all_site2_SiteStartDate");
                    string columnPersonalLotNumber = GetConfigColumn("sp_all_site2_PersonalLotNumber");
                    string columnDescription = GetConfigColumn("sp_all_site2_Description");
                    string columnLeftSide = GetConfigColumn("sp_all_site2_LeftSide");
                    string columnRightSide = GetConfigColumn("sp_all_site2_RightSide");
                    string columnActId = GetConfigColumn("sp_all_site2_ActId");

                    var query = from act in ds.Tables[0].AsEnumerable()
                                where act.Field<decimal>(columnIsRefusal) == 0
                                select act;

                    DataTable actsTable = query.CopyToDataTable<DataRow>();
                    actsTable.TableName = "acts";
                    resulDS.Tables.Add(actsTable);

                    //AddLeftRightSide(ds, resulDS, columnIsRefusal, columnPersonalLotNumber, columnLeftSide, columnRightSide, columnActId, columnSiteId, columnDescription, columnLeId);

                    var entityInfos = from act in ds.Tables[0].AsEnumerable()
                                      where act.Field<decimal>(columnIsRefusal) == 0
                                      select new
                                      {
                                          ENTITY_ID = act.Field<string>(columnLeId),
                                          SITE_ID = act.Field<string>(columnSiteId),
                                          SITE_NAME = act.Field<string>(columnSiteName),
                                          SITE_START_DATE = act.Field<string>(columnSiteStartDate),
                                          PERSONAL_LOT_NUMBER = act.Field<string>(columnPersonalLotNumber),
                                          DESCRIPTION = act.Field<string>(columnDescription),
                                      };



                    DataTable dt = new DataTable("entityInfo");
                    dt.Columns.Add(columnLeId, typeof(string));
                    dt.Columns.Add(columnSiteId, typeof(string));
                    dt.Columns.Add(columnSiteName, typeof(string));
                    dt.Columns.Add(columnSiteStartDate, typeof(string));
                    dt.Columns.Add(columnPersonalLotNumber, typeof(string));
                    dt.Columns.Add(columnDescription, typeof(string));

                    foreach (var p in entityInfos.Distinct())
                    {
                        dt.Rows.Add(new object[]
                        {
                            p.ENTITY_ID,
                            p.SITE_ID,
                            p.SITE_NAME,
                            p.SITE_START_DATE,
                            p.PERSONAL_LOT_NUMBER,
                            p.DESCRIPTION
                        });
                    }

                    resulDS.Tables.Add(dt);


                    resulDS.Relations.Add("entity_acts_fk",
                        new DataColumn[6] { resulDS.Tables["entityInfo"].Columns[columnSiteId],
                                            resulDS.Tables["entityInfo"].Columns[columnSiteName],
                                            resulDS.Tables["entityInfo"].Columns[columnSiteStartDate],
                                            resulDS.Tables["entityInfo"].Columns[columnLeId],
                                            resulDS.Tables["entityInfo"].Columns[columnPersonalLotNumber],
                                            resulDS.Tables["entityInfo"].Columns[columnDescription]},
                        new DataColumn[6] { resulDS.Tables["acts"].Columns[columnSiteId],
                                            resulDS.Tables["acts"].Columns[columnSiteName],
                                            resulDS.Tables["acts"].Columns[columnSiteStartDate],
                                            resulDS.Tables["acts"].Columns[columnLeId],
                                            resulDS.Tables["acts"].Columns[columnPersonalLotNumber],
                                            resulDS.Tables["acts"].Columns[columnDescription]});

                }

                EntityInfoResponseType result = new EntityInfoResponseType();
                var constMapper = CreateConstEntityMap(accessMatrix, argument.DateFrom, argument.DateTo);
                var mapper = CreateEntityMap(accessMatrix);
                constMapper.Map(result, result);
                mapper.Map(resulDS, result);

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

        //private static void AddLeftRightSide(DataSet ds, DataSet resulDS, string columnIsRefusal, string columnPersonalLotNumber, string columnLeftSide, 
        //    string columnRightSide, string columnActId, string columnSiteId, string columnDescription = null, string otherColumn = null)
        //{
        //    //LeftSides
        //    var queryLeftSide = ds.Tables[0].AsEnumerable()
        //       .Where(act => act.Field<decimal>(columnIsRefusal) == 0)
        //       .SelectMany(
        //           act =>
        //           {
        //               int order = 1;
        //               return (act.Field<string>(columnLeftSide) ?? string.Empty)
        //                               .Split(new string[] { @"/n" }, StringSplitOptions.RemoveEmptyEntries)
        //                               .Select(
        //                                   s => new
        //                                   {
        //                                       NAME = s,
        //                                       OrderNumber = order++,
        //                                       Act = act.Field<string>(columnActId),
        //                                       PersonalLotNumber = act.Field<string>(columnPersonalLotNumber),
        //                                       SiteId = act.Field<string>(columnSiteId),
        //                                       ColumnDescription = "",
        //                                       OtherColumn = "",
        //                                       LeftSide = act.Field<string>(columnLeftSide),
        //                                       RightSide = act.Field<string>(columnRightSide)
        //                                   });
        //           });

        //    if (!string.IsNullOrEmpty(columnDescription) && !string.IsNullOrEmpty(otherColumn))
        //    { 
                
        //        queryLeftSide = ds.Tables[0].AsEnumerable()
        //            .Where(act => act.Field<decimal>(columnIsRefusal) == 0)
        //            .SelectMany(
        //                act =>
        //                {
        //                    int order = 1;
        //                    return (act.Field<string>(columnLeftSide) ?? string.Empty)
        //                                    .Split(new string[] { @"/n" }, StringSplitOptions.RemoveEmptyEntries)
        //                                    .Select(
        //                                        s => new
        //                                        {
        //                                            NAME = s,
        //                                            OrderNumber = order++,
        //                                            Act = act.Field<string>(columnActId),
        //                                            PersonalLotNumber = act.Field<string>(columnPersonalLotNumber),
        //                                            SiteId = act.Field<string>(columnSiteId),
        //                                            ColumnDescription = act.Field<string>(columnDescription),
        //                                            OtherColumn = act.Field<string>(otherColumn),
        //                                            LeftSide = act.Field<string>(columnLeftSide),
        //                                            RightSide = act.Field<string>(columnRightSide)
        //                                        });
        //                });
        //    }

        //    DataTable leftSidesTable = new DataTable("leftSides");
        //    leftSidesTable.Columns.Add(columnLeftSide, typeof(string));
        //    leftSidesTable.Columns.Add("OrderNumber", typeof(int));
        //    leftSidesTable.Columns.Add(columnActId, typeof(string));
        //    leftSidesTable.Columns.Add(columnPersonalLotNumber, typeof(string));
        //    leftSidesTable.Columns.Add(columnSiteId, typeof(string));

        //    if (!string.IsNullOrEmpty(columnDescription) && !string.IsNullOrEmpty(otherColumn))
        //    {
        //        leftSidesTable.Columns.Add(columnDescription, typeof(string));
        //        leftSidesTable.Columns.Add(otherColumn, typeof(string));
        //    }
        //    leftSidesTable.Columns.Add("LS", typeof(string));
        //    leftSidesTable.Columns.Add("RS", typeof(string));

        //    foreach (var p in queryLeftSide)
        //    {
        //        if (!string.IsNullOrEmpty(columnDescription) && !string.IsNullOrEmpty(otherColumn))
        //        {
        //            leftSidesTable.Rows.Add(new object[]
        //            {
        //                        p.NAME,
        //                        p.OrderNumber,
        //                        p.Act,
        //                        p.PersonalLotNumber,
        //                        p.SiteId,
        //                        p.ColumnDescription,
        //                        p.OtherColumn,
        //                        p.LeftSide,
        //                        p.RightSide
        //            });
        //        }
        //        else
        //        {
        //           leftSidesTable.Rows.Add(new object[]
        //           {
        //                        p.NAME,
        //                        p.OrderNumber,
        //                        p.Act,
        //                        p.PersonalLotNumber,
        //                        p.SiteId,
        //                        p.LeftSide,
        //                        p.RightSide
        //           });
        //        }
        //    }

        //    resulDS.Tables.Add(leftSidesTable);

        //    if (!string.IsNullOrEmpty(columnDescription) && !string.IsNullOrEmpty(otherColumn))
        //    {
        //        resulDS.Relations.Add("acts_leftSide_fk",
        //        new DataColumn[7]
        //        {
        //            resulDS.Tables["acts"].Columns[columnActId],
        //            resulDS.Tables["acts"].Columns[columnPersonalLotNumber],
        //            resulDS.Tables["acts"].Columns[columnSiteId],
        //            resulDS.Tables["acts"].Columns[columnDescription],
        //            resulDS.Tables["acts"].Columns[otherColumn],
        //            resulDS.Tables["acts"].Columns[columnLeftSide],
        //            resulDS.Tables["acts"].Columns[columnRightSide]
        //        },
        //        new DataColumn[7]
        //        {
        //            resulDS.Tables["leftSides"].Columns[columnActId],
        //            resulDS.Tables["leftSides"].Columns[columnPersonalLotNumber],
        //            resulDS.Tables["leftSides"].Columns[columnSiteId],
        //            resulDS.Tables["leftSides"].Columns[columnDescription],
        //            resulDS.Tables["leftSides"].Columns[otherColumn],
        //            resulDS.Tables["leftSides"].Columns["LS"],
        //            resulDS.Tables["leftSides"].Columns["RS"]
        //        });
        //    }
        //    else
        //    {
        //        resulDS.Relations.Add("acts_leftSide_fk",
        //        new DataColumn[5]
        //        {
        //            resulDS.Tables["acts"].Columns[columnActId],
        //            resulDS.Tables["acts"].Columns[columnPersonalLotNumber],
        //            resulDS.Tables["acts"].Columns[columnSiteId],
        //            resulDS.Tables["acts"].Columns[columnLeftSide],
        //            resulDS.Tables["acts"].Columns[columnRightSide]
        //        },
        //        new DataColumn[5]
        //        {
        //            resulDS.Tables["leftSides"].Columns[columnActId],
        //            resulDS.Tables["leftSides"].Columns[columnPersonalLotNumber],
        //            resulDS.Tables["leftSides"].Columns[columnSiteId],
        //            resulDS.Tables["leftSides"].Columns["LS"],
        //            resulDS.Tables["leftSides"].Columns["RS"]
        //        });
        //    }

        //    //RightSides
        //    var queryRightSide = ds.Tables[0].AsEnumerable()
        //        .Where(act => act.Field<decimal>(columnIsRefusal) == 0)
        //        .SelectMany(
        //            act =>
        //            {
        //                int order = 1;
        //                return (act.Field<string>(columnRightSide) ?? string.Empty)
        //                    .Split(new string[] { @"/n" }, StringSplitOptions.RemoveEmptyEntries)
        //                    .Select(
        //                        s => new
        //                        {
        //                            NAME = s,
        //                            OrderNumber = order++,
        //                            Act = act.Field<string>(columnActId),
        //                            PersonalLotNumber = act.Field<string>(columnPersonalLotNumber),
        //                            SiteId = act.Field<string>(columnSiteId),
        //                            ColumnDescription = "",
        //                            OtherColumn = "",
        //                            LeftSide = act.Field<string>(columnLeftSide),
        //                            RightSide = act.Field<string>(columnRightSide)
        //                        });
        //            });

        //    if (!string.IsNullOrEmpty(columnDescription) && !string.IsNullOrEmpty(otherColumn))
        //    { 

        //        queryRightSide = ds.Tables[0].AsEnumerable()
        //        .Where(act => act.Field<decimal>(columnIsRefusal) == 0)
        //        .SelectMany(
        //            act =>
        //            {
        //                int order = 1;
        //                return (act.Field<string>(columnRightSide) ?? string.Empty)
        //                    .Split(new string[] { @"/n" }, StringSplitOptions.RemoveEmptyEntries)
        //                    .Select(
        //                        s => new
        //                        {
        //                            NAME = s,
        //                            OrderNumber = order++,
        //                            Act = act.Field<string>(columnActId),
        //                            PersonalLotNumber = act.Field<string>(columnPersonalLotNumber),
        //                            SiteId = act.Field<string>(columnSiteId),
        //                            ColumnDescription = act.Field<string>(columnDescription),
        //                            OtherColumn = act.Field<string>(otherColumn),
        //                            LeftSide = act.Field<string>(columnLeftSide),
        //                            RightSide = act.Field<string>(columnRightSide)
        //                        });
        //            });

        //    }

        //    DataTable rightSidesTable = new DataTable("rightSides");
        //    rightSidesTable.Columns.Add(columnRightSide, typeof(string));
        //    rightSidesTable.Columns.Add("OrderNumber", typeof(int));
        //    rightSidesTable.Columns.Add(columnActId, typeof(string));
        //    rightSidesTable.Columns.Add(columnPersonalLotNumber, typeof(string));
        //    rightSidesTable.Columns.Add(columnSiteId, typeof(string));

        //    if (!string.IsNullOrEmpty(columnDescription) && !string.IsNullOrEmpty(otherColumn))
        //    {
        //        rightSidesTable.Columns.Add(columnDescription, typeof(string));
        //        rightSidesTable.Columns.Add(otherColumn, typeof(string));
        //    }
        //    rightSidesTable.Columns.Add("LS", typeof(string));
        //    rightSidesTable.Columns.Add("RS", typeof(string));

        //    foreach (var p in queryRightSide)
        //    {
        //        if (!string.IsNullOrEmpty(columnDescription) && !string.IsNullOrEmpty(otherColumn))
        //        {
        //            rightSidesTable.Rows.Add(new object[]
        //                {
        //                    p.NAME,
        //                    p.OrderNumber,
        //                    p.Act,
        //                    p.PersonalLotNumber,
        //                    p.SiteId,
        //                    p.ColumnDescription,
        //                    p.OtherColumn,
        //                    p.LeftSide,
        //                    p.RightSide
        //                });
        //        }
        //        else
        //        {
        //            rightSidesTable.Rows.Add(new object[]
        //            {
        //                    p.NAME,
        //                    p.OrderNumber,
        //                    p.Act,
        //                    p.PersonalLotNumber,
        //                    p.SiteId,
        //                    p.LeftSide,
        //                    p.RightSide
        //            });
        //        }

        //    }

        //    resulDS.Tables.Add(rightSidesTable);

        //    if (!string.IsNullOrEmpty(columnDescription) && !string.IsNullOrEmpty(otherColumn))
        //    {
        //        resulDS.Relations.Add("acts_rightSide_fk",
        //        new DataColumn[7]
        //        {
        //            resulDS.Tables["acts"].Columns[columnActId],
        //            resulDS.Tables["acts"].Columns[columnPersonalLotNumber],
        //            resulDS.Tables["acts"].Columns[columnSiteId],
        //            resulDS.Tables["acts"].Columns[columnDescription],
        //            resulDS.Tables["acts"].Columns[otherColumn],
        //            resulDS.Tables["acts"].Columns[columnLeftSide],
        //            resulDS.Tables["acts"].Columns[columnRightSide]
        //        },
        //        new DataColumn[7]
        //        {
        //            resulDS.Tables["rightSides"].Columns[columnActId],
        //            resulDS.Tables["rightSides"].Columns[columnPersonalLotNumber],
        //            resulDS.Tables["rightSides"].Columns[columnSiteId],
        //            resulDS.Tables["rightSides"].Columns[columnDescription],
        //            resulDS.Tables["rightSides"].Columns[otherColumn],
        //            resulDS.Tables["rightSides"].Columns["LS"],
        //            resulDS.Tables["rightSides"].Columns["RS"]
        //        });
        //    }
        //    else
        //    {
        //        resulDS.Relations.Add("acts_rightSide_fk",
        //        new DataColumn[5]
        //        {
        //            resulDS.Tables["acts"].Columns[columnActId],
        //            resulDS.Tables["acts"].Columns[columnPersonalLotNumber],
        //            resulDS.Tables["acts"].Columns[columnSiteId],
        //            resulDS.Tables["acts"].Columns[columnLeftSide],
        //            resulDS.Tables["acts"].Columns[columnRightSide]
        //        },
        //        new DataColumn[5]
        //        {
        //            resulDS.Tables["rightSides"].Columns[columnActId],
        //            resulDS.Tables["rightSides"].Columns[columnPersonalLotNumber],
        //            resulDS.Tables["rightSides"].Columns[columnSiteId],
        //            resulDS.Tables["rightSides"].Columns["LS"],
        //            resulDS.Tables["rightSides"].Columns["RS"]
        //        });
        //    }
        //}

        private ObjectMapper<EntityInfoResponseType, EntityInfoResponseType> CreateConstEntityMap(AccessMatrix accessMatrix, DateTime dateFrom, DateTime dateTo)
        {
            ObjectMapper<EntityInfoResponseType, EntityInfoResponseType> mapper = new ObjectMapper<EntityInfoResponseType, EntityInfoResponseType>(accessMatrix);

            mapper.AddConstantMap((r) => r.DateFrom, dateFrom);
            mapper.AddConstantMap((r) => r.DateTo, dateTo);

            return mapper;
        }

        private DataSetMapper<EntityInfoResponseType> CreateEntityMap(AccessMatrix accessMatrix)
        {
            DataSetMapper<EntityInfoResponseType> mapper = new DataSetMapper<EntityInfoResponseType>(accessMatrix);
            
            mapper.AddDataSetObjectInitializer((ds) => (ds.Tables["entityInfo"] != null && ds.Tables["entityInfo"].Rows.Count > 0) ? ds.Tables["entityInfo"].Rows[0] : null);
            
            mapper.AddDataRowMap((r) => r.EntityLotDataList, row => row.Table.Rows);
            mapper.AddDataColumnMap((r) => r.EntityLotDataList[0].RegistryAgency, GetConfigColumn("sp_all_site2_SiteName"));
            mapper.AddDataColumnMap((r) => r.EntityLotDataList[0].SiteID, GetConfigColumn("sp_all_site2_SiteId"));
            mapper.AddDataColumnMap((r) => r.EntityLotDataList[0].SiteStartDate, GetConfigColumn("sp_all_site2_SiteStartDate"), DateParse());
            mapper.AddDataColumnMap((r) => r.EntityLotDataList[0].EntityBasicData, GetConfigColumn("sp_all_site2_Description"));
            mapper.AddDataColumnMap((r) => r.EntityLotDataList[0].PersonalLotNumber, GetConfigColumn("sp_all_site2_PersonalLotNumber"));

            mapper.AddDataRowMap((r) => r.EntityLotDataList[0].PersonalLotEntryList, row => row.GetChildRows("entity_acts_fk"));
            mapper.AddDataColumnMap((r) => r.EntityLotDataList[0].PersonalLotEntryList[0].Act.IncomingRegistrationNumber, GetConfigColumn("sp_all_site2_IncomingRegisterNumber"));
            mapper.AddDataColumnMap((r) => r.EntityLotDataList[0].PersonalLotEntryList[0].Act.IncomingRegistrationDate, GetConfigColumn("sp_all_site2_IncomingRegisterDate"), DateParse());
            mapper.AddDataColumnMap((r) => r.EntityLotDataList[0].PersonalLotEntryList[0].Act.DoubleRegisterNumber, GetConfigColumn("sp_all_site2_DoubleRegisterNumber"));
            mapper.AddDataColumnMap((r) => r.EntityLotDataList[0].PersonalLotEntryList[0].Act.RegistrationDate, GetConfigColumn("sp_all_site2_RegistrationDate"), DateParse());
            mapper.AddDataColumnMap((r) => r.EntityLotDataList[0].PersonalLotEntryList[0].Act.Volume, GetConfigColumn("sp_all_site2_File"));
            mapper.AddDataColumnMap((r) => r.EntityLotDataList[0].PersonalLotEntryList[0].Act.Page, GetConfigColumn("sp_all_site2_FileNumber"));
            mapper.AddDataColumnMap((r) => r.EntityLotDataList[0].PersonalLotEntryList[0].Act.ActYear, GetConfigColumn("sp_all_site2_ActYear"));
            mapper.AddDataColumnMap((r) => r.EntityLotDataList[0].PersonalLotEntryList[0].Act.Condition, GetConfigColumn("sp_all_site2_Condition"));

            string columnLeftSide = GetConfigColumn("sp_all_site2_LeftSide");
            mapper.AddFunctionMap<EntityInfoResponseType, List<string>>(
                (r) => r.EntityLotDataList[0].PersonalLotEntryList[0].Act.LeftSide.Side, 
                row => (
                        (row[columnLeftSide] != DBNull.Value && row[columnLeftSide] != null) ?
                         row[columnLeftSide].ToString().Split(new string[] { @"/n" }, StringSplitOptions.RemoveEmptyEntries).ToList<string>() :
                         new List<string>())
                );

            string columnRightSide = GetConfigColumn("sp_all_site2_RightSide");
            mapper.AddFunctionMap<EntityInfoResponseType, List<string>>(
                (r) => r.EntityLotDataList[0].PersonalLotEntryList[0].Act.RightSide.Side,
                row => (
                        (row[columnRightSide] != DBNull.Value && row[columnRightSide] != null) ?
                         row[columnRightSide].ToString().Split(new string[] { @"/n" }, StringSplitOptions.RemoveEmptyEntries).ToList<string>() :
                         new List<string>())
                );
            ////LeftSides
            //mapper.AddDataRowMap((r) => r.EntityLotDataList[0].PersonalLotEntryList[0].Act.LeftSide.Side, row => row.GetChildRows("acts_leftSide_fk"));
            //mapper.AddDataColumnMap((r) => r.EntityLotDataList[0].PersonalLotEntryList[0].Act.LeftSide.Side[0].OrderNumber, "OrderNumber");
            //mapper.AddDataColumnMap((r) => r.EntityLotDataList[0].PersonalLotEntryList[0].Act.LeftSide.Side[0].Text, GetConfigColumn("sp_all_site2_LeftSide"));
            ////RightSides
            //mapper.AddDataRowMap((r) => r.EntityLotDataList[0].PersonalLotEntryList[0].Act.RightSide.Side, row => row.GetChildRows("acts_rightSide_fk"));
            //mapper.AddDataColumnMap((r) => r.EntityLotDataList[0].PersonalLotEntryList[0].Act.RightSide.Side[0].OrderNumber, "OrderNumber");
            //mapper.AddDataColumnMap((r) => r.EntityLotDataList[0].PersonalLotEntryList[0].Act.RightSide.Side[0].Text, GetConfigColumn("sp_all_site2_RightSide"));

            string columnOldBook = GetConfigColumn("sp_all_site2_OldBook");
            string columnBook = GetConfigColumn("sp_all_site2_Book");
            mapper.AddFunctionMap<EntityInfoResponseType, string>((r) => r.EntityLotDataList[0].PersonalLotEntryList[0].Act.BookTypeName,
                row => ((row[columnOldBook] != DBNull.Value && row[columnOldBook] != null) ?
                         row[columnOldBook].ToString() :
                        (row[columnBook] != DBNull.Value && row[columnBook] != null ? row[columnBook].ToString() : String.Empty)));

            string columnOldActType = GetConfigColumn("sp_all_site2_OldActType");
            string columnActType = GetConfigColumn("sp_all_site2_ActType");
            mapper.AddFunctionMap<EntityInfoResponseType, string>((r) => r.EntityLotDataList[0].PersonalLotEntryList[0].Act.ActTypeName,
                row => ((row[columnOldActType] != DBNull.Value && row[columnOldActType] != null) ?
                         row[columnOldActType].ToString() :
                        (row[columnActType] != DBNull.Value && row[columnActType] != null ? row[columnActType].ToString() : String.Empty)));

            string columnConnActs = GetConfigColumn("sp_all_site2_ConnActs");
            string columnConnActsC = GetConfigColumn("sp_all_site2_ConActsC");
            mapper.AddFunctionMap<EntityInfoResponseType, string>((r) => r.EntityLotDataList[0].PersonalLotEntryList[0].Act.ConnectedActs,
                row => ((row[columnConnActs] != DBNull.Value && row[columnConnActs] != null) ?
                         row[columnConnActs].ToString().Replace("/n", ";") :
                        (row[columnConnActsC] != DBNull.Value && row[columnConnActsC] != null ? row[columnConnActsC].ToString().Replace("/n", ";") : String.Empty)));
            
            mapper.AddDataColumnMap((r) => r.EntityLotDataList[0].PersonalLotEntryList[0].PropertyData, GetConfigColumn("sp_all_site2_PropertyRemarkAsString"));
            mapper.AddDataColumnMap((r) => r.EntityLotDataList[0].PersonalLotEntryList[0].LotNumber, GetConfigColumn("sp_all_site2_PropertyLotNumber"));
            mapper.AddDataColumnMap((r) => r.EntityLotDataList[0].PersonalLotEntryList[0].CadastreIdentificator, GetConfigColumn("sp_all_site2_PropertyCadastreNumber"));

            return mapper;
        }

        #endregion

        #region GetEntityInfoV2 - 1.1 Справка по персонална партида на юридическо лице - V2

        public CommonSignedResponse<EntityInfoV2RequestType, EntityInfoV2ResponseType> GetEntityInfoV2(EntityInfoV2RequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
            try
            {
                OracleConnection connection = new OracleConnection(ConnectionString.Value);
                DataSet ds = new DataSet();

                OracleCommand command = new OracleCommand();
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = SchemaName.Value + ".selbyperson_all_site2";
                command.Parameters.Add(new OracleParameter("p_egn", OracleDbType.Varchar2, DBNull.Value, ParameterDirection.Input));
                command.Parameters.Add(new OracleParameter("p_bulstat", OracleDbType.Varchar2, argument.EIK, ParameterDirection.Input));
                command.Parameters.Add(new OracleParameter("p_date_from", OracleDbType.Date, argument.DateFrom, ParameterDirection.Input));
                command.Parameters.Add(new OracleParameter("p_date_to", OracleDbType.Date, argument.DateTo, ParameterDirection.Input));
                command.Parameters.Add(new OracleParameter("p_book_type_id", OracleDbType.Varchar2, DBNull.Value, ParameterDirection.Input));
                command.Parameters.Add(new OracleParameter("p_act_type_id", OracleDbType.Varchar2, DBNull.Value, ParameterDirection.Input));
                command.Parameters.Add(new OracleParameter("p_site_id", OracleDbType.Varchar2, argument.SiteID, ParameterDirection.Input));
                command.Parameters.Add(new OracleParameter("outcursor", OracleDbType.RefCursor, ParameterDirection.Output));

                OracleDataAdapter resultDataAdapter = new OracleDataAdapter(command);

                try
                {
                    connection.Open();
                    resultDataAdapter.Fill(ds);
                }
                finally
                {
                    connection.Close();
                }

                //Конструиране на dataset за маппинг
                DataSet resulDS = new DataSet();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    string columnIsRefusal = GetConfigColumn("sp_all_site2_IsRefusal");
                    string columnLeId = GetConfigColumn("sp_all_site2_LeId");
                    string columnSiteId = GetConfigColumn("sp_all_site2_SiteId");
                    string columnSiteName = GetConfigColumn("sp_all_site2_SiteName");
                    string columnSiteStartDate = GetConfigColumn("sp_all_site2_SiteStartDate");
                    string columnPersonalLotNumber = GetConfigColumn("sp_all_site2_PersonalLotNumber");
                    string columnDescription = GetConfigColumn("sp_all_site2_Description");
                    string columnLeftSide = GetConfigColumn("sp_all_site2_LeftSide");
                    string columnRightSide = GetConfigColumn("sp_all_site2_RightSide");
                    string columnActId = GetConfigColumn("sp_all_site2_ActId");

                    var query = from act in ds.Tables[0].AsEnumerable()
                                where act.Field<decimal>(columnIsRefusal) == 0
                                select act;

                    DataTable actsTable = query.CopyToDataTable<DataRow>();
                    actsTable.TableName = "acts";
                    resulDS.Tables.Add(actsTable);

                    var entityInfos = from act in ds.Tables[0].AsEnumerable()
                                      where act.Field<decimal>(columnIsRefusal) == 0
                                      select new
                                      {
                                          ENTITY_ID = act.Field<string>(columnLeId),
                                          SITE_ID = act.Field<string>(columnSiteId),
                                          SITE_NAME = act.Field<string>(columnSiteName),
                                          SITE_START_DATE = act.Field<string>(columnSiteStartDate),
                                          PERSONAL_LOT_NUMBER = act.Field<string>(columnPersonalLotNumber),
                                          DESCRIPTION = act.Field<string>(columnDescription),
                                      };



                    DataTable dt = new DataTable("entityInfo");
                    dt.Columns.Add(columnLeId, typeof(string));
                    dt.Columns.Add(columnSiteId, typeof(string));
                    dt.Columns.Add(columnSiteName, typeof(string));
                    dt.Columns.Add(columnSiteStartDate, typeof(string));
                    dt.Columns.Add(columnPersonalLotNumber, typeof(string));
                    dt.Columns.Add(columnDescription, typeof(string));

                    foreach (var p in entityInfos.Distinct())
                    {
                        dt.Rows.Add(new object[]
                        {
                            p.ENTITY_ID,
                            p.SITE_ID,
                            p.SITE_NAME,
                            p.SITE_START_DATE,
                            p.PERSONAL_LOT_NUMBER,
                            p.DESCRIPTION
                        });
                    }

                    resulDS.Tables.Add(dt);


                    resulDS.Relations.Add("entity_acts_fk",
                        new DataColumn[6] { resulDS.Tables["entityInfo"].Columns[columnSiteId],
                                            resulDS.Tables["entityInfo"].Columns[columnSiteName],
                                            resulDS.Tables["entityInfo"].Columns[columnSiteStartDate],
                                            resulDS.Tables["entityInfo"].Columns[columnLeId],
                                            resulDS.Tables["entityInfo"].Columns[columnPersonalLotNumber],
                                            resulDS.Tables["entityInfo"].Columns[columnDescription]},
                        new DataColumn[6] { resulDS.Tables["acts"].Columns[columnSiteId],
                                            resulDS.Tables["acts"].Columns[columnSiteName],
                                            resulDS.Tables["acts"].Columns[columnSiteStartDate],
                                            resulDS.Tables["acts"].Columns[columnLeId],
                                            resulDS.Tables["acts"].Columns[columnPersonalLotNumber],
                                            resulDS.Tables["acts"].Columns[columnDescription]});

                }

                EntityInfoV2ResponseType result = new EntityInfoV2ResponseType();
                var constMapper = CreateConstEntityMapV2(accessMatrix, argument.DateFrom, argument.DateTo);
                var mapper = CreateEntityMapV2(accessMatrix);
                constMapper.Map(result, result);
                mapper.Map(resulDS, result);

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

        private ObjectMapper<EntityInfoV2ResponseType, EntityInfoV2ResponseType> CreateConstEntityMapV2(AccessMatrix accessMatrix, DateTime dateFrom, DateTime dateTo)
        {
            ObjectMapper<EntityInfoV2ResponseType, EntityInfoV2ResponseType> mapper = new ObjectMapper<EntityInfoV2ResponseType, EntityInfoV2ResponseType>(accessMatrix);

            mapper.AddConstantMap((r) => r.DateFrom, dateFrom);
            mapper.AddConstantMap((r) => r.DateTo, dateTo);

            return mapper;
        }

        private DataSetMapper<EntityInfoV2ResponseType> CreateEntityMapV2(AccessMatrix accessMatrix)
        {
            DataSetMapper<EntityInfoV2ResponseType> mapper = new DataSetMapper<EntityInfoV2ResponseType>(accessMatrix);

            mapper.AddDataSetObjectInitializer((ds) => (ds.Tables["entityInfo"] != null && ds.Tables["entityInfo"].Rows.Count > 0) ? ds.Tables["entityInfo"].Rows[0] : null);

            mapper.AddDataRowMap((r) => r.EntityLotDataList, row => row.Table.Rows);
            mapper.AddDataColumnMap((r) => r.EntityLotDataList[0].RegistryAgency, GetConfigColumn("sp_all_site2_SiteName"));
            mapper.AddDataColumnMap((r) => r.EntityLotDataList[0].SiteID, GetConfigColumn("sp_all_site2_SiteId"));
            mapper.AddDataColumnMap((r) => r.EntityLotDataList[0].SiteStartDate, GetConfigColumn("sp_all_site2_SiteStartDate"), DateParse());
            mapper.AddDataColumnMap((r) => r.EntityLotDataList[0].EntityBasicData, GetConfigColumn("sp_all_site2_Description"));
            mapper.AddDataColumnMap((r) => r.EntityLotDataList[0].PersonalLotNumber, GetConfigColumn("sp_all_site2_PersonalLotNumber"));

            mapper.AddDataRowMap((r) => r.EntityLotDataList[0].PersonalLotEntryList, row => row.GetChildRows("entity_acts_fk"));
            mapper.AddDataColumnMap((r) => r.EntityLotDataList[0].PersonalLotEntryList[0].Act.IncomingRegistrationNumber, GetConfigColumn("sp_all_site2_IncomingRegisterNumber"));
            mapper.AddDataColumnMap((r) => r.EntityLotDataList[0].PersonalLotEntryList[0].Act.IncomingRegistrationDate, GetConfigColumn("sp_all_site2_IncomingRegisterDate"), DateParse());
            mapper.AddDataColumnMap((r) => r.EntityLotDataList[0].PersonalLotEntryList[0].Act.DoubleRegisterNumber, GetConfigColumn("sp_all_site2_DoubleRegisterNumber"));
            mapper.AddDataColumnMap((r) => r.EntityLotDataList[0].PersonalLotEntryList[0].Act.RegistrationDate, GetConfigColumn("sp_all_site2_RegistrationDate"), DateParse());
            mapper.AddDataColumnMap((r) => r.EntityLotDataList[0].PersonalLotEntryList[0].Act.Volume, GetConfigColumn("sp_all_site2_File"));
            mapper.AddDataColumnMap((r) => r.EntityLotDataList[0].PersonalLotEntryList[0].Act.Page, GetConfigColumn("sp_all_site2_FileNumber"));
            mapper.AddDataColumnMap((r) => r.EntityLotDataList[0].PersonalLotEntryList[0].Act.ActYear, GetConfigColumn("sp_all_site2_ActYear"));
            mapper.AddDataColumnMap((r) => r.EntityLotDataList[0].PersonalLotEntryList[0].Act.Condition, GetConfigColumn("sp_all_site2_Condition"));

            //The new fields
            mapper.AddDataColumnMap((r) => r.EntityLotDataList[0].PersonalLotEntryList[0].Act.WorthCurrency, GetConfigColumn("sp_all_site2_WorthCurrency"));
            mapper.AddDataColumnMap((r) => r.EntityLotDataList[0].PersonalLotEntryList[0].Act.WorthValue, GetConfigColumn("sp_all_site2_WorthValue"));
            //

            string columnLeftSide = GetConfigColumn("sp_all_site2_LeftSide");
            mapper.AddFunctionMap<EntityInfoV2ResponseType, List<string>>(
                (r) => r.EntityLotDataList[0].PersonalLotEntryList[0].Act.LeftSide.Side,
                row => (
                        (row[columnLeftSide] != DBNull.Value && row[columnLeftSide] != null) ?
                         row[columnLeftSide].ToString().Split(new string[] { @"/n" }, StringSplitOptions.RemoveEmptyEntries).ToList<string>() :
                         new List<string>())
                );

            string columnRightSide = GetConfigColumn("sp_all_site2_RightSide");
            mapper.AddFunctionMap<EntityInfoV2ResponseType, List<string>>(
                (r) => r.EntityLotDataList[0].PersonalLotEntryList[0].Act.RightSide.Side,
                row => (
                        (row[columnRightSide] != DBNull.Value && row[columnRightSide] != null) ?
                         row[columnRightSide].ToString().Split(new string[] { @"/n" }, StringSplitOptions.RemoveEmptyEntries).ToList<string>() :
                         new List<string>())
                );

            string columnOldBook = GetConfigColumn("sp_all_site2_OldBook");
            string columnBook = GetConfigColumn("sp_all_site2_Book");
            mapper.AddFunctionMap<EntityInfoV2ResponseType, string>((r) => r.EntityLotDataList[0].PersonalLotEntryList[0].Act.BookTypeName,
                row => ((row[columnOldBook] != DBNull.Value && row[columnOldBook] != null) ?
                         row[columnOldBook].ToString() :
                        (row[columnBook] != DBNull.Value && row[columnBook] != null ? row[columnBook].ToString() : String.Empty)));

            string columnOldActType = GetConfigColumn("sp_all_site2_OldActType");
            string columnActType = GetConfigColumn("sp_all_site2_ActType");
            mapper.AddFunctionMap<EntityInfoV2ResponseType, string>((r) => r.EntityLotDataList[0].PersonalLotEntryList[0].Act.ActTypeName,
                row => ((row[columnOldActType] != DBNull.Value && row[columnOldActType] != null) ?
                         row[columnOldActType].ToString() :
                        (row[columnActType] != DBNull.Value && row[columnActType] != null ? row[columnActType].ToString() : String.Empty)));

            string columnConnActs = GetConfigColumn("sp_all_site2_ConnActs");
            string columnConnActsC = GetConfigColumn("sp_all_site2_ConActsC");
            mapper.AddFunctionMap<EntityInfoV2ResponseType, string>((r) => r.EntityLotDataList[0].PersonalLotEntryList[0].Act.ConnectedActs,
                row => ((row[columnConnActs] != DBNull.Value && row[columnConnActs] != null) ?
                         row[columnConnActs].ToString().Replace("/n", ";") :
                        (row[columnConnActsC] != DBNull.Value && row[columnConnActsC] != null ? row[columnConnActsC].ToString().Replace("/n", ";") : String.Empty)));

            mapper.AddDataColumnMap((r) => r.EntityLotDataList[0].PersonalLotEntryList[0].PropertyData, GetConfigColumn("sp_all_site2_PropertyRemarkAsString"));
            mapper.AddDataColumnMap((r) => r.EntityLotDataList[0].PersonalLotEntryList[0].LotNumber, GetConfigColumn("sp_all_site2_PropertyLotNumber"));
            mapper.AddDataColumnMap((r) => r.EntityLotDataList[0].PersonalLotEntryList[0].CadastreIdentificator, GetConfigColumn("sp_all_site2_PropertyCadastreNumber"));

            return mapper;
        }

        #endregion

        #region GetPersonInfo - 2. Справка по персонална партида на физическо лице

        public CommonSignedResponse<PersonInfoRequestType, PersonInfoResponseType> GetPersonInfo(PersonInfoRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
            try
            {
                OracleConnection connection = new OracleConnection(ConnectionString.Value);
                DataSet ds = new DataSet();
                
                OracleCommand command = new OracleCommand();
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = SchemaName.Value + ".selbyperson_all_site2";
                command.Parameters.Add(new OracleParameter("p_egn", OracleDbType.Varchar2, argument.EGN, ParameterDirection.Input));
                command.Parameters.Add(new OracleParameter("p_bulstat", OracleDbType.Varchar2, DBNull.Value, ParameterDirection.Input));
                command.Parameters.Add(new OracleParameter("p_date_from", OracleDbType.Date, argument.DateFrom, ParameterDirection.Input));
                command.Parameters.Add(new OracleParameter("p_date_to", OracleDbType.Date, argument.DateTo, ParameterDirection.Input));
                command.Parameters.Add(new OracleParameter("p_book_type_id", OracleDbType.Varchar2, DBNull.Value, ParameterDirection.Input));
                command.Parameters.Add(new OracleParameter("p_act_type_id", OracleDbType.Varchar2, DBNull.Value, ParameterDirection.Input));
                command.Parameters.Add(new OracleParameter("p_site_id", OracleDbType.Varchar2, argument.SiteID, ParameterDirection.Input));
                command.Parameters.Add(new OracleParameter("outcursor", OracleDbType.RefCursor, ParameterDirection.Output));

                OracleDataAdapter resultDataAdapter = new OracleDataAdapter(command);

                try
                {
                    connection.Open();
                    resultDataAdapter.Fill(ds);

                }
                finally
                {
                    connection.Close();
                }

                //LogToDatabase(aditionalParameters, argument.EGN, null, null, "002:Справка по персонална партида на физическо лице", argument, id);
                
                //Конструиране на dataset за маппинг
                DataSet resulDS = new DataSet();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    string columnIsRefusal = GetConfigColumn("sp_all_site2_IsRefusal");
                    string columnCitizenId = GetConfigColumn("sp_all_site2_CitizenId");
                    string columnSiteId = GetConfigColumn("sp_all_site2_SiteId");
                    string columnSiteName = GetConfigColumn("sp_all_site2_SiteName");
                    string columnSiteStartDate = GetConfigColumn("sp_all_site2_SiteStartDate");
                    string columnPersonalLotNumber = GetConfigColumn("sp_all_site2_PersonalLotNumber");
                    string columnDescription = GetConfigColumn("sp_all_site2_Description");
                    string columnLeftSide = GetConfigColumn("sp_all_site2_LeftSide");
                    string columnRightSide = GetConfigColumn("sp_all_site2_RightSide");
                    string columnActId = GetConfigColumn("sp_all_site2_ActId");

                    var query = from act in ds.Tables[0].AsEnumerable()
                                where act.Field<decimal>(columnIsRefusal) == 0
                                select act;
                    DataTable actsTable = query.CopyToDataTable<DataRow>();
                    actsTable.TableName = "acts";
                    resulDS.Tables.Add(actsTable);


                    var personInfos = from act in ds.Tables[0].AsEnumerable()
                                      where act.Field<decimal>(columnIsRefusal) == 0
                                      select new
                                      {
                                          CITIZEN_ID = act.Field<string>(columnCitizenId),
                                          SITE_ID = act.Field<string>(columnSiteId),
                                          SITE_NAME = act.Field<string>(columnSiteName),
                                          SITE_START_DATE = act.Field<string>(columnSiteStartDate),
                                          PERSONAL_LOT_NUMBER = act.Field<string>(columnPersonalLotNumber),
                                          DESCRIPTION = act.Field<string>(columnDescription),
                                      };

                    DataTable dt = new DataTable("personInfo");
                    dt.Columns.Add(columnCitizenId, typeof(string));
                    dt.Columns.Add(columnSiteId, typeof(string));
                    dt.Columns.Add(columnSiteName, typeof(string));
                    dt.Columns.Add(columnSiteStartDate, typeof(string));
                    dt.Columns.Add(columnPersonalLotNumber, typeof(string));
                    dt.Columns.Add(columnDescription, typeof(string));

                    foreach (var p in personInfos.Distinct())
                    {
                        dt.Rows.Add(new object[] 
                        {
                            p.CITIZEN_ID,
                            p.SITE_ID,
                            p.SITE_NAME,
                            p.SITE_START_DATE,
                            p.PERSONAL_LOT_NUMBER,
                            p.DESCRIPTION
                        });
                    }

                    resulDS.Tables.Add(dt);


                    resulDS.Relations.Add("person_acts_fk",
                        new DataColumn[6] { resulDS.Tables["personInfo"].Columns[columnSiteId],
                                            resulDS.Tables["personInfo"].Columns[columnSiteName],
                                            resulDS.Tables["personInfo"].Columns[columnSiteStartDate],
                                            resulDS.Tables["personInfo"].Columns[columnCitizenId],
                                            resulDS.Tables["personInfo"].Columns[columnPersonalLotNumber],
                                            resulDS.Tables["personInfo"].Columns[columnDescription]},
                        new DataColumn[6] { resulDS.Tables["acts"].Columns[columnSiteId],
                                            resulDS.Tables["acts"].Columns[columnSiteName],
                                            resulDS.Tables["acts"].Columns[columnSiteStartDate],
                                            resulDS.Tables["acts"].Columns[columnCitizenId] ,
                                            resulDS.Tables["acts"].Columns[columnPersonalLotNumber],
                                            resulDS.Tables["acts"].Columns[columnDescription] });

                    //AddLeftRightSide(ds, resulDS, columnIsRefusal, columnPersonalLotNumber, columnLeftSide, columnRightSide, columnActId, columnSiteId, columnDescription, columnCitizenId);

                }
                PersonInfoResponseType result = new PersonInfoResponseType();
                var constMapper = CreateConstPersonMap(accessMatrix, argument.DateFrom, argument.DateTo);
                var mapper = CreatePersonMap(accessMatrix);
                constMapper.Map(result, result);
                mapper.Map(resulDS, result);

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

        private ObjectMapper<PersonInfoResponseType, PersonInfoResponseType> CreateConstPersonMap(AccessMatrix accessMatrix, DateTime dateFrom, DateTime dateTo)
        {
            ObjectMapper<PersonInfoResponseType, PersonInfoResponseType> mapper = new ObjectMapper<PersonInfoResponseType, PersonInfoResponseType>(accessMatrix);

            mapper.AddConstantMap((r) => r.DateFrom, dateFrom);
            mapper.AddConstantMap((r) => r.DateTo, dateTo);

            return mapper;
        }

        private DataSetMapper<PersonInfoResponseType> CreatePersonMap(AccessMatrix accessMatrix)
        {
            DataSetMapper<PersonInfoResponseType> mapper = new DataSetMapper<PersonInfoResponseType>(accessMatrix);

            mapper.AddDataSetObjectInitializer((ds) => (ds.Tables["personInfo"] != null && ds.Tables["personInfo"].Rows.Count > 0) ? ds.Tables["personInfo"].Rows[0] : null);
            
            mapper.AddDataRowMap((r) => r.PersonLotDataList, row => row.Table.Rows);
            mapper.AddDataColumnMap((r) => r.PersonLotDataList[0].RegistryAgency, GetConfigColumn("sp_all_site2_SiteName"));
            mapper.AddDataColumnMap((r) => r.PersonLotDataList[0].SiteID, GetConfigColumn("sp_all_site2_SiteId"));
            mapper.AddDataColumnMap((r) => r.PersonLotDataList[0].SiteStartDate, GetConfigColumn("sp_all_site2_SiteStartDate"), DateParse());
            mapper.AddDataColumnMap((r) => r.PersonLotDataList[0].PersonBasicData, GetConfigColumn("sp_all_site2_Description"));
            mapper.AddDataColumnMap((r) => r.PersonLotDataList[0].PersonalLotNumber, GetConfigColumn("sp_all_site2_PersonalLotNumber"));

            mapper.AddDataRowMap((r) => r.PersonLotDataList[0].PersonalLotEntryList, row => row.GetChildRows("person_acts_fk"));
            mapper.AddDataColumnMap((r) => r.PersonLotDataList[0].PersonalLotEntryList[0].Act.IncomingRegistrationNumber, GetConfigColumn("sp_all_site2_IncomingRegisterNumber"));
            mapper.AddDataColumnMap((r) => r.PersonLotDataList[0].PersonalLotEntryList[0].Act.IncomingRegistrationDate, GetConfigColumn("sp_all_site2_IncomingRegisterDate"), DateParse());
            mapper.AddDataColumnMap((r) => r.PersonLotDataList[0].PersonalLotEntryList[0].Act.DoubleRegisterNumber, GetConfigColumn("sp_all_site2_DoubleRegisterNumber"));
            mapper.AddDataColumnMap((r) => r.PersonLotDataList[0].PersonalLotEntryList[0].Act.RegistrationDate, GetConfigColumn("sp_all_site2_RegistrationDate"), DateParse());
            mapper.AddDataColumnMap((r) => r.PersonLotDataList[0].PersonalLotEntryList[0].Act.Volume, GetConfigColumn("sp_all_site2_File"));
            mapper.AddDataColumnMap((r) => r.PersonLotDataList[0].PersonalLotEntryList[0].Act.Page, GetConfigColumn("sp_all_site2_FileNumber"));
            mapper.AddDataColumnMap((r) => r.PersonLotDataList[0].PersonalLotEntryList[0].Act.ActYear, GetConfigColumn("sp_all_site2_ActYear"));
            mapper.AddDataColumnMap((r) => r.PersonLotDataList[0].PersonalLotEntryList[0].Act.Condition, GetConfigColumn("sp_all_site2_Condition"));
            //mapper.AddDataColumnMap((r) => r.PersonLotDataList[0].PersonalLotEntryList[0].Act.LeftSide, GetConfigColumn("sp_all_site2_LeftSide"));
            //mapper.AddDataColumnMap((r) => r.PersonLotDataList[0].PersonalLotEntryList[0].Act.RightSide, GetConfigColumn("sp_all_site2_RightSide"));

            string columnLeftSide = GetConfigColumn("sp_all_site2_LeftSide");
            mapper.AddFunctionMap<PersonInfoResponseType, List<string>>(
                (r) => r.PersonLotDataList[0].PersonalLotEntryList[0].Act.LeftSide.Side,
                row => (
                        (row[columnLeftSide] != DBNull.Value && row[columnLeftSide] != null) ?
                         row[columnLeftSide].ToString().Split(new string[] { @"/n" }, StringSplitOptions.RemoveEmptyEntries).ToList<string>() :
                         new List<string>())
                );

            string columnRightSide = GetConfigColumn("sp_all_site2_RightSide");
            mapper.AddFunctionMap<PersonInfoResponseType, List<string>>(
                (r) => r.PersonLotDataList[0].PersonalLotEntryList[0].Act.RightSide.Side,
                row => (
                        (row[columnRightSide] != DBNull.Value && row[columnRightSide] != null) ?
                         row[columnRightSide].ToString().Split(new string[] { @"/n" }, StringSplitOptions.RemoveEmptyEntries).ToList<string>() :
                         new List<string>())
                );

            ////LeftSides
            //mapper.AddDataRowMap((r) => r.PersonLotDataList[0].PersonalLotEntryList[0].Act.LeftSide.Side, row => row.GetChildRows("acts_leftSide_fk"));
            //mapper.AddDataColumnMap((r) => r.PersonLotDataList[0].PersonalLotEntryList[0].Act.LeftSide.Side[0].OrderNumber, "OrderNumber");
            //mapper.AddDataColumnMap((r) => r.PersonLotDataList[0].PersonalLotEntryList[0].Act.LeftSide.Side[0].Text, GetConfigColumn("sp_all_site2_LeftSide"));
            ////RightSides
            //mapper.AddDataRowMap((r) => r.PersonLotDataList[0].PersonalLotEntryList[0].Act.RightSide.Side, row => row.GetChildRows("acts_rightSide_fk"));
            //mapper.AddDataColumnMap((r) => r.PersonLotDataList[0].PersonalLotEntryList[0].Act.RightSide.Side[0].OrderNumber, "OrderNumber");
            //mapper.AddDataColumnMap((r) => r.PersonLotDataList[0].PersonalLotEntryList[0].Act.RightSide.Side[0].Text, GetConfigColumn("sp_all_site2_RightSide"));

            string columnOldBook = GetConfigColumn("sp_all_site2_OldBook");
            string columnBook = GetConfigColumn("sp_all_site2_Book");
            mapper.AddFunctionMap<PersonInfoResponseType, string>((r) => r.PersonLotDataList[0].PersonalLotEntryList[0].Act.BookTypeName,
                row => ((row[columnOldBook] != DBNull.Value && row[columnOldBook] != null) ?
                         row[columnOldBook].ToString() :
                        (row[columnBook] != DBNull.Value && row[columnBook] != null ? row[columnBook].ToString() : String.Empty)));

            string columnOldActType = GetConfigColumn("sp_all_site2_OldActType");
            string columnActType = GetConfigColumn("sp_all_site2_ActType");
            mapper.AddFunctionMap<PersonInfoResponseType, string>((r) => r.PersonLotDataList[0].PersonalLotEntryList[0].Act.ActTypeName,
                row => ((row[columnOldActType] != DBNull.Value && row[columnOldActType] != null) ?
                         row[columnOldActType].ToString() :
                        (row[columnActType] != DBNull.Value && row[columnActType] != null ? row[columnActType].ToString() : String.Empty)));

            string columnConnActs = GetConfigColumn("sp_all_site2_ConnActs");
            string columnConnActsC = GetConfigColumn("sp_all_site2_ConActsC");
            mapper.AddFunctionMap<PersonInfoResponseType, string>((r) => r.PersonLotDataList[0].PersonalLotEntryList[0].Act.ConnectedActs,
                row => ((row[columnConnActs] != DBNull.Value && row[columnConnActs] != null) ?
                         row[columnConnActs].ToString().Replace("/n", ";") :
                        (row[columnConnActsC] != DBNull.Value && row[columnConnActsC] != null ? row[columnConnActsC].ToString().Replace("/n", ";") : String.Empty)));
            
            mapper.AddDataColumnMap((r) => r.PersonLotDataList[0].PersonalLotEntryList[0].PropertyData, GetConfigColumn("sp_all_site2_PropertyRemarkAsString"));
            mapper.AddDataColumnMap((r) => r.PersonLotDataList[0].PersonalLotEntryList[0].LotNumber, GetConfigColumn("sp_all_site2_PropertyLotNumber"));
            mapper.AddDataColumnMap((r) => r.PersonLotDataList[0].PersonalLotEntryList[0].CadastreIdentificator, GetConfigColumn("sp_all_site2_PropertyCadastreNumber"));

            return mapper;
        }

        #endregion

        #region GetPersonInfoV2 - 2.1 Справка по персонална партида на физическо лице V2

        public CommonSignedResponse<PersonInfoV2RequestType, PersonInfoV2ResponseType> GetPersonInfoV2(PersonInfoV2RequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
            try
            {
                OracleConnection connection = new OracleConnection(ConnectionString.Value);
                DataSet ds = new DataSet();

                OracleCommand command = new OracleCommand();
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = SchemaName.Value + ".selbyperson_all_site2";
                command.Parameters.Add(new OracleParameter("p_egn", OracleDbType.Varchar2, argument.EGN, ParameterDirection.Input));
                command.Parameters.Add(new OracleParameter("p_bulstat", OracleDbType.Varchar2, DBNull.Value, ParameterDirection.Input));
                command.Parameters.Add(new OracleParameter("p_date_from", OracleDbType.Date, argument.DateFrom, ParameterDirection.Input));
                command.Parameters.Add(new OracleParameter("p_date_to", OracleDbType.Date, argument.DateTo, ParameterDirection.Input));
                command.Parameters.Add(new OracleParameter("p_book_type_id", OracleDbType.Varchar2, DBNull.Value, ParameterDirection.Input));
                command.Parameters.Add(new OracleParameter("p_act_type_id", OracleDbType.Varchar2, DBNull.Value, ParameterDirection.Input));
                command.Parameters.Add(new OracleParameter("p_site_id", OracleDbType.Varchar2, argument.SiteID, ParameterDirection.Input));
                command.Parameters.Add(new OracleParameter("outcursor", OracleDbType.RefCursor, ParameterDirection.Output));

                OracleDataAdapter resultDataAdapter = new OracleDataAdapter(command);

                try
                {
                    connection.Open();
                    resultDataAdapter.Fill(ds);

                }
                finally
                {
                    connection.Close();
                }

                //Конструиране на dataset за маппинг
                DataSet resulDS = new DataSet();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    string columnIsRefusal = GetConfigColumn("sp_all_site2_IsRefusal");
                    string columnCitizenId = GetConfigColumn("sp_all_site2_CitizenId");
                    string columnSiteId = GetConfigColumn("sp_all_site2_SiteId");
                    string columnSiteName = GetConfigColumn("sp_all_site2_SiteName");
                    string columnSiteStartDate = GetConfigColumn("sp_all_site2_SiteStartDate");
                    string columnPersonalLotNumber = GetConfigColumn("sp_all_site2_PersonalLotNumber");
                    string columnDescription = GetConfigColumn("sp_all_site2_Description");
                    string columnLeftSide = GetConfigColumn("sp_all_site2_LeftSide");
                    string columnRightSide = GetConfigColumn("sp_all_site2_RightSide");
                    string columnActId = GetConfigColumn("sp_all_site2_ActId");

                    var query = from act in ds.Tables[0].AsEnumerable()
                                where act.Field<decimal>(columnIsRefusal) == 0
                                select act;
                    DataTable actsTable = query.CopyToDataTable<DataRow>();
                    actsTable.TableName = "acts";
                    resulDS.Tables.Add(actsTable);


                    var personInfos = from act in ds.Tables[0].AsEnumerable()
                                      where act.Field<decimal>(columnIsRefusal) == 0
                                      select new
                                      {
                                          CITIZEN_ID = act.Field<string>(columnCitizenId),
                                          SITE_ID = act.Field<string>(columnSiteId),
                                          SITE_NAME = act.Field<string>(columnSiteName),
                                          SITE_START_DATE = act.Field<string>(columnSiteStartDate),
                                          PERSONAL_LOT_NUMBER = act.Field<string>(columnPersonalLotNumber),
                                          DESCRIPTION = act.Field<string>(columnDescription),
                                      };

                    DataTable dt = new DataTable("personInfo");
                    dt.Columns.Add(columnCitizenId, typeof(string));
                    dt.Columns.Add(columnSiteId, typeof(string));
                    dt.Columns.Add(columnSiteName, typeof(string));
                    dt.Columns.Add(columnSiteStartDate, typeof(string));
                    dt.Columns.Add(columnPersonalLotNumber, typeof(string));
                    dt.Columns.Add(columnDescription, typeof(string));

                    foreach (var p in personInfos.Distinct())
                    {
                        dt.Rows.Add(new object[]
                        {
                            p.CITIZEN_ID,
                            p.SITE_ID,
                            p.SITE_NAME,
                            p.SITE_START_DATE,
                            p.PERSONAL_LOT_NUMBER,
                            p.DESCRIPTION
                        });
                    }

                    resulDS.Tables.Add(dt);


                    resulDS.Relations.Add("person_acts_fk",
                        new DataColumn[6] { resulDS.Tables["personInfo"].Columns[columnSiteId],
                                            resulDS.Tables["personInfo"].Columns[columnSiteName],
                                            resulDS.Tables["personInfo"].Columns[columnSiteStartDate],
                                            resulDS.Tables["personInfo"].Columns[columnCitizenId],
                                            resulDS.Tables["personInfo"].Columns[columnPersonalLotNumber],
                                            resulDS.Tables["personInfo"].Columns[columnDescription]},
                        new DataColumn[6] { resulDS.Tables["acts"].Columns[columnSiteId],
                                            resulDS.Tables["acts"].Columns[columnSiteName],
                                            resulDS.Tables["acts"].Columns[columnSiteStartDate],
                                            resulDS.Tables["acts"].Columns[columnCitizenId] ,
                                            resulDS.Tables["acts"].Columns[columnPersonalLotNumber],
                                            resulDS.Tables["acts"].Columns[columnDescription] });

                }
                PersonInfoV2ResponseType result = new PersonInfoV2ResponseType();
                var constMapper = CreateConstPersonMapV2(accessMatrix, argument.DateFrom, argument.DateTo);
                var mapper = CreatePersonMapV2(accessMatrix);
                constMapper.Map(result, result);
                mapper.Map(resulDS, result);

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

        private ObjectMapper<PersonInfoV2ResponseType, PersonInfoV2ResponseType> CreateConstPersonMapV2(AccessMatrix accessMatrix, DateTime dateFrom, DateTime dateTo)
        {
            ObjectMapper<PersonInfoV2ResponseType, PersonInfoV2ResponseType> mapper = new ObjectMapper<PersonInfoV2ResponseType, PersonInfoV2ResponseType>(accessMatrix);

            mapper.AddConstantMap((r) => r.DateFrom, dateFrom);
            mapper.AddConstantMap((r) => r.DateTo, dateTo);

            return mapper;
        }

        private DataSetMapper<PersonInfoV2ResponseType> CreatePersonMapV2(AccessMatrix accessMatrix)
        {
            DataSetMapper<PersonInfoV2ResponseType> mapper = new DataSetMapper<PersonInfoV2ResponseType>(accessMatrix);

            mapper.AddDataSetObjectInitializer((ds) => (ds.Tables["personInfo"] != null && ds.Tables["personInfo"].Rows.Count > 0) ? ds.Tables["personInfo"].Rows[0] : null);

            mapper.AddDataRowMap((r) => r.PersonLotDataList, row => row.Table.Rows);
            mapper.AddDataColumnMap((r) => r.PersonLotDataList[0].RegistryAgency, GetConfigColumn("sp_all_site2_SiteName"));
            mapper.AddDataColumnMap((r) => r.PersonLotDataList[0].SiteID, GetConfigColumn("sp_all_site2_SiteId"));
            mapper.AddDataColumnMap((r) => r.PersonLotDataList[0].SiteStartDate, GetConfigColumn("sp_all_site2_SiteStartDate"), DateParse());
            mapper.AddDataColumnMap((r) => r.PersonLotDataList[0].PersonBasicData, GetConfigColumn("sp_all_site2_Description"));
            mapper.AddDataColumnMap((r) => r.PersonLotDataList[0].PersonalLotNumber, GetConfigColumn("sp_all_site2_PersonalLotNumber"));

            mapper.AddDataRowMap((r) => r.PersonLotDataList[0].PersonalLotEntryList, row => row.GetChildRows("person_acts_fk"));
            mapper.AddDataColumnMap((r) => r.PersonLotDataList[0].PersonalLotEntryList[0].Act.IncomingRegistrationNumber, GetConfigColumn("sp_all_site2_IncomingRegisterNumber"));
            mapper.AddDataColumnMap((r) => r.PersonLotDataList[0].PersonalLotEntryList[0].Act.IncomingRegistrationDate, GetConfigColumn("sp_all_site2_IncomingRegisterDate"), DateParse());
            mapper.AddDataColumnMap((r) => r.PersonLotDataList[0].PersonalLotEntryList[0].Act.DoubleRegisterNumber, GetConfigColumn("sp_all_site2_DoubleRegisterNumber"));
            mapper.AddDataColumnMap((r) => r.PersonLotDataList[0].PersonalLotEntryList[0].Act.RegistrationDate, GetConfigColumn("sp_all_site2_RegistrationDate"), DateParse());
            mapper.AddDataColumnMap((r) => r.PersonLotDataList[0].PersonalLotEntryList[0].Act.Volume, GetConfigColumn("sp_all_site2_File"));
            mapper.AddDataColumnMap((r) => r.PersonLotDataList[0].PersonalLotEntryList[0].Act.Page, GetConfigColumn("sp_all_site2_FileNumber"));
            mapper.AddDataColumnMap((r) => r.PersonLotDataList[0].PersonalLotEntryList[0].Act.ActYear, GetConfigColumn("sp_all_site2_ActYear"));
            mapper.AddDataColumnMap((r) => r.PersonLotDataList[0].PersonalLotEntryList[0].Act.Condition, GetConfigColumn("sp_all_site2_Condition"));

            //The new fields
            mapper.AddDataColumnMap((r) => r.PersonLotDataList[0].PersonalLotEntryList[0].Act.WorthCurrency, GetConfigColumn("sp_all_site2_WorthCurrency"));
            mapper.AddDataColumnMap((r) => r.PersonLotDataList[0].PersonalLotEntryList[0].Act.WorthValue, GetConfigColumn("sp_all_site2_WorthValue"));
            //

            string columnLeftSide = GetConfigColumn("sp_all_site2_LeftSide");
            mapper.AddFunctionMap<PersonInfoV2ResponseType, List<string>>(
                (r) => r.PersonLotDataList[0].PersonalLotEntryList[0].Act.LeftSide.Side,
                row => (
                        (row[columnLeftSide] != DBNull.Value && row[columnLeftSide] != null) ?
                         row[columnLeftSide].ToString().Split(new string[] { @"/n" }, StringSplitOptions.RemoveEmptyEntries).ToList<string>() :
                         new List<string>())
                );

            string columnRightSide = GetConfigColumn("sp_all_site2_RightSide");
            mapper.AddFunctionMap<PersonInfoV2ResponseType, List<string>>(
                (r) => r.PersonLotDataList[0].PersonalLotEntryList[0].Act.RightSide.Side,
                row => (
                        (row[columnRightSide] != DBNull.Value && row[columnRightSide] != null) ?
                         row[columnRightSide].ToString().Split(new string[] { @"/n" }, StringSplitOptions.RemoveEmptyEntries).ToList<string>() :
                         new List<string>())
                );

            string columnOldBook = GetConfigColumn("sp_all_site2_OldBook");
            string columnBook = GetConfigColumn("sp_all_site2_Book");
            mapper.AddFunctionMap<PersonInfoV2ResponseType, string>((r) => r.PersonLotDataList[0].PersonalLotEntryList[0].Act.BookTypeName,
                row => ((row[columnOldBook] != DBNull.Value && row[columnOldBook] != null) ?
                         row[columnOldBook].ToString() :
                        (row[columnBook] != DBNull.Value && row[columnBook] != null ? row[columnBook].ToString() : String.Empty)));

            string columnOldActType = GetConfigColumn("sp_all_site2_OldActType");
            string columnActType = GetConfigColumn("sp_all_site2_ActType");
            mapper.AddFunctionMap<PersonInfoV2ResponseType, string>((r) => r.PersonLotDataList[0].PersonalLotEntryList[0].Act.ActTypeName,
                row => ((row[columnOldActType] != DBNull.Value && row[columnOldActType] != null) ?
                         row[columnOldActType].ToString() :
                        (row[columnActType] != DBNull.Value && row[columnActType] != null ? row[columnActType].ToString() : String.Empty)));

            string columnConnActs = GetConfigColumn("sp_all_site2_ConnActs");
            string columnConnActsC = GetConfigColumn("sp_all_site2_ConActsC");
            mapper.AddFunctionMap<PersonInfoV2ResponseType, string>((r) => r.PersonLotDataList[0].PersonalLotEntryList[0].Act.ConnectedActs,
                row => ((row[columnConnActs] != DBNull.Value && row[columnConnActs] != null) ?
                         row[columnConnActs].ToString().Replace("/n", ";") :
                        (row[columnConnActsC] != DBNull.Value && row[columnConnActsC] != null ? row[columnConnActsC].ToString().Replace("/n", ";") : String.Empty)));

            mapper.AddDataColumnMap((r) => r.PersonLotDataList[0].PersonalLotEntryList[0].PropertyData, GetConfigColumn("sp_all_site2_PropertyRemarkAsString"));
            mapper.AddDataColumnMap((r) => r.PersonLotDataList[0].PersonalLotEntryList[0].LotNumber, GetConfigColumn("sp_all_site2_PropertyLotNumber"));
            mapper.AddDataColumnMap((r) => r.PersonLotDataList[0].PersonalLotEntryList[0].CadastreIdentificator, GetConfigColumn("sp_all_site2_PropertyCadastreNumber"));

            return mapper;
        }

        #endregion

        #region GetPropertyInfo - 4. Справка по имот

        public CommonSignedResponse<PropertyInfoRequestType, PropertyInfoResponseType> GetPropertyInfo(PropertyInfoRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
            try
            {
                OracleConnection connection = new OracleConnection(ConnectionString.Value);
                DataSet ds = new DataSet();

                OracleCommand command = new OracleCommand();
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = SchemaName.Value + ".selbyproperty3";
                command.Parameters.Add(new OracleParameter("p_property_id", OracleDbType.Varchar2, argument.PropertyID, ParameterDirection.Input));
                command.Parameters.Add(new OracleParameter("p_date_from", OracleDbType.Date, argument.DateFrom, ParameterDirection.Input));
                command.Parameters.Add(new OracleParameter("p_date_to", OracleDbType.Date, argument.DateTo, ParameterDirection.Input));
                command.Parameters.Add(new OracleParameter("p_book_type_id", OracleDbType.Varchar2, DBNull.Value, ParameterDirection.Input));
                command.Parameters.Add(new OracleParameter("p_act_type_id", OracleDbType.Varchar2, DBNull.Value, ParameterDirection.Input));
                command.Parameters.Add(new OracleParameter("p_site_id", OracleDbType.Varchar2, argument.SiteID, ParameterDirection.Input));
                command.Parameters.Add(new OracleParameter("outcursor", OracleDbType.RefCursor, ParameterDirection.Output));
                OracleDataAdapter resultDataAdapter = new OracleDataAdapter(command);

                try
                {
                    connection.Open();
                    resultDataAdapter.Fill(ds);

                }
                catch (Exception ex)
                {
                    //ORA-01403: no data found
                    if (ex is OracleException && !ex.Message.StartsWith("ORA-01403"))
                    {
                        throw;
                    }
                }
                finally
                {
                    connection.Close();
                }

                //LogToDatabase(aditionalParameters, null, null, argument.PropertyID, "004:Справка по имот", argument, id);

                //Конструиране на dataset за маппинг
                DataSet resulDS = new DataSet();

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    string columnIsRefusal = GetConfigColumn("selbyproperty3_IsRefusal");
                    string columnPropertyLotNumber = GetConfigColumn("selbyproperty3_PropertyLotNumber");
                    string columnPropertyLotPublicationDate = GetConfigColumn("selbyproperty3_PropertyLotPublicationDate");
                    string columnA27 = GetConfigColumn("selbyproperty3_A27");
                    string columnPropertyCadastreNumber = GetConfigColumn("selbyproperty3_PropertyCadastreNumber");
                    string columnPropertyRemarkAsString = GetConfigColumn("selbyproperty3_PropertyRemarkAsString");
                    string columnSiteName = GetConfigColumn("selbyproperty3_SiteName");
                    string columnSiteId = GetConfigColumn("selbyproperty3_SiteId");
                    string columnSiteStartDate = GetConfigColumn("selbyproperty3_SiteStartDate");
                    string columnLeftSide = GetConfigColumn("selbyproperty3_LeftSide");
                    string columnRightSide = GetConfigColumn("selbyproperty3_RightSide");
                    string columnActId = GetConfigColumn("selbyproperty3_ActId");

                    var query = from act in ds.Tables[0].AsEnumerable()
                                where act.Field<decimal>(columnIsRefusal) == 0
                                select act;
                    DataTable actsTable = query.CopyToDataTable<DataRow>();
                    actsTable.TableName = "acts";
                    resulDS.Tables.Add(actsTable);

                    var property = from act in ds.Tables[0].AsEnumerable()
                                   where act.Field<decimal>(columnIsRefusal) == 0
                                   select new
                                   {
                                       PROPERTY_LOT_NUMBER = act.Field<string>(columnPropertyLotNumber),
                                       PROPERTY_LOT_PUBLICATION_DATE = act.Field<string>(columnPropertyLotPublicationDate),
                                       LOT_TYPE = act.Field<string>(columnA27),
                                       PROPERTY_CADASTRE_NUMBER = act.Field<string>(columnPropertyCadastreNumber),
                                       PROPERTY_REMARK_AS_STRING = act.Field<string>(columnPropertyRemarkAsString),
                                       SITE_NAME = act.Field<string>(columnSiteName),
                                       SITE_ID = act.Field<string>(columnSiteId),
                                       SITE_START_DATE = act.Field<string>(columnSiteStartDate),
                                   };

                    DataTable dt = new DataTable("propertyInfo");
                    dt.Columns.Add(columnPropertyLotNumber, typeof(string));
                    dt.Columns.Add(columnPropertyLotPublicationDate, typeof(string));
                    dt.Columns.Add(columnA27, typeof(string));
                    dt.Columns.Add(columnPropertyCadastreNumber, typeof(string));
                    dt.Columns.Add(columnPropertyRemarkAsString, typeof(string));
                    dt.Columns.Add(columnSiteName, typeof(string));
                    dt.Columns.Add(columnSiteId, typeof(string));
                    dt.Columns.Add(columnSiteStartDate, typeof(string));

                    foreach (var p in property.Distinct())
                    {
                        dt.Rows.Add(new object[] 
                        {
                            p.PROPERTY_LOT_NUMBER,
                            p.PROPERTY_LOT_PUBLICATION_DATE,
                            p.LOT_TYPE,
                            p.PROPERTY_CADASTRE_NUMBER,
                            p.PROPERTY_REMARK_AS_STRING,
                            p.SITE_NAME,
                            p.SITE_ID,
                            p.SITE_START_DATE,
                        });
                    }

                    resulDS.Tables.Add(dt);

                    resulDS.Relations.Add("prop_acts_fk",
                      resulDS.Tables["propertyInfo"].Columns[columnPropertyLotNumber],
                      resulDS.Tables["acts"].Columns[columnPropertyLotNumber]);

                    //AddLeftRightSide(ds, resulDS, columnIsRefusal, columnPropertyLotNumber, columnLeftSide, columnRightSide, columnActId, columnSiteId);
                }

                PropertyInfoResponseType result = new PropertyInfoResponseType();
                var constMapper = CreateConstPropertyMap(accessMatrix, argument.DateFrom, argument.DateTo);
                var mapper = CreatePropertyMap(accessMatrix);
                constMapper.Map(result, result);
                mapper.Map(resulDS, result);

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

        private ObjectMapper<PropertyInfoResponseType, PropertyInfoResponseType> CreateConstPropertyMap(AccessMatrix accessMatrix, DateTime dateFrom, DateTime dateTo)
        {
            ObjectMapper<PropertyInfoResponseType, PropertyInfoResponseType> mapper = new ObjectMapper<PropertyInfoResponseType, PropertyInfoResponseType>(accessMatrix);

            mapper.AddConstantMap((r) => r.DateFrom, dateFrom);
            mapper.AddConstantMap((r) => r.DateTo, dateTo);

            return mapper;
        }
        
        private DataSetMapper<PropertyInfoResponseType> CreatePropertyMap(AccessMatrix accessMatrix)
        {
            DataSetMapper<PropertyInfoResponseType> mapper = new DataSetMapper<PropertyInfoResponseType>(accessMatrix);

            mapper.AddDataSetObjectInitializer((ds) => (ds.Tables["propertyInfo"] != null && ds.Tables["propertyInfo"].Rows.Count > 0) ? ds.Tables["propertyInfo"].Rows[0] : null);

            mapper.AddDataColumnMap((r) => r.PropertyData, GetConfigColumn("selbyproperty3_PropertyRemarkAsString"));
            mapper.AddDataColumnMap((r) => r.LotType, GetConfigColumn("selbyproperty3_A27"));
            mapper.AddDataColumnMap((r) => r.LotNumber, GetConfigColumn("selbyproperty3_PropertyLotNumber"));
            mapper.AddDataColumnMap((r) => r.DateOpened, GetConfigColumn("selbyproperty3_PropertyLotPublicationDate"), DateParse());
            mapper.AddDataColumnMap((r) => r.CadastreNumber, GetConfigColumn("selbyproperty3_PropertyCadastreNumber"));
            mapper.AddDataColumnMap((r) => r.RegistryAgency, GetConfigColumn("selbyproperty3_SiteName"));
            mapper.AddDataColumnMap((r) => r.SiteID, GetConfigColumn("selbyproperty3_SiteId"));
            mapper.AddDataColumnMap((r) => r.SiteStartDate, GetConfigColumn("selbyproperty3_SiteStartDate"), DateParse());

            mapper.AddDataRowMap((r) => r.PropertyActDetailList, row => row.GetChildRows("prop_acts_fk"));
            mapper.AddDataColumnMap((r) => r.PropertyActDetailList[0].Act.IncomingRegistrationNumber, GetConfigColumn("selbyproperty3_IncomingRegisterNumber"));
            mapper.AddDataColumnMap((r) => r.PropertyActDetailList[0].Act.IncomingRegistrationDate, GetConfigColumn("selbyproperty3_IncomingRegisterDate"), DateParse());
            mapper.AddDataColumnMap((r) => r.PropertyActDetailList[0].Act.DoubleRegisterNumber, GetConfigColumn("selbyproperty3_A17"));
            mapper.AddDataColumnMap((r) => r.PropertyActDetailList[0].Act.RegistrationDate, GetConfigColumn("selbyproperty3_DoubleIncomingRegisterDate"), DateParse());
            mapper.AddDataColumnMap((r) => r.PropertyActDetailList[0].Act.Volume, GetConfigColumn("selbyproperty3_A21"));
            mapper.AddDataColumnMap((r) => r.PropertyActDetailList[0].Act.Page, GetConfigColumn("selbyproperty3_A22"));
            mapper.AddDataColumnMap((r) => r.PropertyActDetailList[0].Act.ActYear, GetConfigColumn("selbyproperty3_A23"));
            mapper.AddDataColumnMap((r) => r.PropertyActDetailList[0].Act.Condition, GetConfigColumn("selbyproperty3_Condition"));
            //mapper.AddDataColumnMap((r) => r.PropertyActDetailList[0].Act.LeftSide, GetConfigColumn("selbyproperty3_LeftSide"));
            //mapper.AddDataColumnMap((r) => r.PropertyActDetailList[0].Act.RightSide, GetConfigColumn("selbyproperty3_RightSide"));

            string columnLeftSide = GetConfigColumn("selbyproperty3_LeftSide");
            mapper.AddFunctionMap<PropertyInfoResponseType, List<string>>(
                (r) => r.PropertyActDetailList[0].Act.LeftSide.Side,
                row => (
                        (row[columnLeftSide] != DBNull.Value && row[columnLeftSide] != null) ?
                         row[columnLeftSide].ToString().Split(new string[] { @"/n" }, StringSplitOptions.RemoveEmptyEntries).ToList<string>() :
                         new List<string>())
                );

            string columnRightSide = GetConfigColumn("selbyproperty3_RightSide");
            mapper.AddFunctionMap<PropertyInfoResponseType, List<string>>(
                (r) => r.PropertyActDetailList[0].Act.RightSide.Side,
                row => (
                        (row[columnRightSide] != DBNull.Value && row[columnRightSide] != null) ?
                         row[columnRightSide].ToString().Split(new string[] { @"/n" }, StringSplitOptions.RemoveEmptyEntries).ToList<string>() :
                         new List<string>())
                );

            ////LeftSides
            //mapper.AddDataRowMap((r) => r.PropertyActDetailList[0].Act.LeftSide.Side, row => row.GetChildRows("acts_leftSide_fk"));
            //mapper.AddDataColumnMap((r) => r.PropertyActDetailList[0].Act.LeftSide.Side[0].OrderNumber, "OrderNumber");
            //mapper.AddDataColumnMap((r) => r.PropertyActDetailList[0].Act.LeftSide.Side[0].Text, GetConfigColumn("selbyproperty3_LeftSide"));
            ////RightSides
            //mapper.AddDataRowMap((r) => r.PropertyActDetailList[0].Act.RightSide.Side, row => row.GetChildRows("acts_rightSide_fk"));
            //mapper.AddDataColumnMap((r) => r.PropertyActDetailList[0].Act.RightSide.Side[0].OrderNumber, "OrderNumber");
            //mapper.AddDataColumnMap((r) => r.PropertyActDetailList[0].Act.RightSide.Side[0].Text, GetConfigColumn("selbyproperty3_RightSide"));

            string columnOldBook = GetConfigColumn("selbyproperty3_OldBook");
            string columnA20 = GetConfigColumn("selbyproperty3_A20");
            mapper.AddFunctionMap<PropertyInfoResponseType, string>((r) => r.PropertyActDetailList[0].Act.BookTypeName, 
                row => ((row[columnOldBook] != DBNull.Value && row[columnOldBook] != null) ?
                         row[columnOldBook].ToString() :
                        (row[columnA20] != DBNull.Value && row[columnA20] != null ? row[columnA20].ToString() : String.Empty)));

            string columnOldActType = GetConfigColumn("selbyproperty3_OldActType");
            string columnA18 = GetConfigColumn("selbyproperty3_A18");
            mapper.AddFunctionMap<PropertyInfoResponseType, string>((r) => r.PropertyActDetailList[0].Act.ActTypeName, 
                row => ((row[columnOldActType] != DBNull.Value && row[columnOldActType] != null) ?
                         row[columnOldActType].ToString() :
                        (row[columnA18] != DBNull.Value && row[columnA18] != null ? row[columnA18].ToString() : String.Empty)));

            string columnConnActs = GetConfigColumn("selbyproperty3_ConnActs");
            string columnConnActsC = GetConfigColumn("selbyproperty3_ConnActsC");
            mapper.AddFunctionMap<PropertyInfoResponseType, string>((r) => r.PropertyActDetailList[0].Act.ConnectedActs, 
                row => ((row[columnConnActs] != DBNull.Value && row[columnConnActs] != null) ?
                         row[columnConnActs].ToString().Replace("/n", ";") :
                        (row[columnConnActsC] != DBNull.Value && row[columnConnActsC] != null ? row[columnConnActsC].ToString().Replace("/n", ";") : String.Empty)));

            mapper.AddDataColumnMap((r) => r.PropertyActDetailList[0].Sequence, GetConfigColumn("selbyproperty3_R"));
            mapper.AddDataColumnMap((r) => r.PropertyActDetailList[0].LotPart, GetConfigColumn("selbyproperty3_LotPart"));
            mapper.AddDataColumnMap((r) => r.PropertyActDetailList[0].ListBookNumber, GetConfigColumn("selbyproperty3_ListBookNumber"));
            mapper.AddDataColumnMap((r) => r.PropertyActDetailList[0].ListBookDate, GetConfigColumn("selbyproperty3_ListBookDate"), DateParse());

            return mapper;
        }

        #endregion

        #region GetPropertyInfoV2 - 4.1 Справка по имот - V2

        public CommonSignedResponse<PropertyInfoV2RequestType, PropertyInfoV2ResponseType> GetPropertyInfoV2(PropertyInfoV2RequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
            try
            {
                OracleConnection connection = new OracleConnection(ConnectionString.Value);
                DataSet ds = new DataSet();

                OracleCommand command = new OracleCommand();
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = SchemaName.Value + ".selbyproperty3";
                command.Parameters.Add(new OracleParameter("p_property_id", OracleDbType.Varchar2, argument.PropertyID, ParameterDirection.Input));
                command.Parameters.Add(new OracleParameter("p_date_from", OracleDbType.Date, argument.DateFrom, ParameterDirection.Input));
                command.Parameters.Add(new OracleParameter("p_date_to", OracleDbType.Date, argument.DateTo, ParameterDirection.Input));
                command.Parameters.Add(new OracleParameter("p_book_type_id", OracleDbType.Varchar2, DBNull.Value, ParameterDirection.Input));
                command.Parameters.Add(new OracleParameter("p_act_type_id", OracleDbType.Varchar2, DBNull.Value, ParameterDirection.Input));
                command.Parameters.Add(new OracleParameter("p_site_id", OracleDbType.Varchar2, argument.SiteID, ParameterDirection.Input));
                command.Parameters.Add(new OracleParameter("outcursor", OracleDbType.RefCursor, ParameterDirection.Output));
                OracleDataAdapter resultDataAdapter = new OracleDataAdapter(command);

                try
                {
                    connection.Open();
                    resultDataAdapter.Fill(ds);

                }
                catch (Exception ex)
                {
                    //ORA-01403: no data found
                    if (ex is OracleException && !ex.Message.StartsWith("ORA-01403"))
                    {
                        throw;
                    }
                }
                finally
                {
                    connection.Close();
                }

                //Конструиране на dataset за маппинг
                DataSet resulDS = new DataSet();

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    string columnIsRefusal = GetConfigColumn("selbyproperty3_IsRefusal");
                    string columnPropertyLotNumber = GetConfigColumn("selbyproperty3_PropertyLotNumber");
                    string columnPropertyLotPublicationDate = GetConfigColumn("selbyproperty3_PropertyLotPublicationDate");
                    string columnA27 = GetConfigColumn("selbyproperty3_A27");
                    string columnPropertyCadastreNumber = GetConfigColumn("selbyproperty3_PropertyCadastreNumber");
                    string columnPropertyRemarkAsString = GetConfigColumn("selbyproperty3_PropertyRemarkAsString");
                    string columnSiteName = GetConfigColumn("selbyproperty3_SiteName");
                    string columnSiteId = GetConfigColumn("selbyproperty3_SiteId");
                    string columnSiteStartDate = GetConfigColumn("selbyproperty3_SiteStartDate");
                    string columnLeftSide = GetConfigColumn("selbyproperty3_LeftSide");
                    string columnRightSide = GetConfigColumn("selbyproperty3_RightSide");
                    string columnActId = GetConfigColumn("selbyproperty3_ActId");

                    var query = from act in ds.Tables[0].AsEnumerable()
                                where act.Field<decimal>(columnIsRefusal) == 0
                                select act;
                    DataTable actsTable = query.CopyToDataTable<DataRow>();
                    actsTable.TableName = "acts";
                    resulDS.Tables.Add(actsTable);

                    var property = from act in ds.Tables[0].AsEnumerable()
                                   where act.Field<decimal>(columnIsRefusal) == 0
                                   select new
                                   {
                                       PROPERTY_LOT_NUMBER = act.Field<string>(columnPropertyLotNumber),
                                       PROPERTY_LOT_PUBLICATION_DATE = act.Field<string>(columnPropertyLotPublicationDate),
                                       LOT_TYPE = act.Field<string>(columnA27),
                                       PROPERTY_CADASTRE_NUMBER = act.Field<string>(columnPropertyCadastreNumber),
                                       PROPERTY_REMARK_AS_STRING = act.Field<string>(columnPropertyRemarkAsString),
                                       SITE_NAME = act.Field<string>(columnSiteName),
                                       SITE_ID = act.Field<string>(columnSiteId),
                                       SITE_START_DATE = act.Field<string>(columnSiteStartDate),
                                   };

                    DataTable dt = new DataTable("propertyInfo");
                    dt.Columns.Add(columnPropertyLotNumber, typeof(string));
                    dt.Columns.Add(columnPropertyLotPublicationDate, typeof(string));
                    dt.Columns.Add(columnA27, typeof(string));
                    dt.Columns.Add(columnPropertyCadastreNumber, typeof(string));
                    dt.Columns.Add(columnPropertyRemarkAsString, typeof(string));
                    dt.Columns.Add(columnSiteName, typeof(string));
                    dt.Columns.Add(columnSiteId, typeof(string));
                    dt.Columns.Add(columnSiteStartDate, typeof(string));

                    foreach (var p in property.Distinct())
                    {
                        dt.Rows.Add(new object[]
                        {
                            p.PROPERTY_LOT_NUMBER,
                            p.PROPERTY_LOT_PUBLICATION_DATE,
                            p.LOT_TYPE,
                            p.PROPERTY_CADASTRE_NUMBER,
                            p.PROPERTY_REMARK_AS_STRING,
                            p.SITE_NAME,
                            p.SITE_ID,
                            p.SITE_START_DATE,
                        });
                    }

                    resulDS.Tables.Add(dt);

                    resulDS.Relations.Add("prop_acts_fk",
                      resulDS.Tables["propertyInfo"].Columns[columnPropertyLotNumber],
                      resulDS.Tables["acts"].Columns[columnPropertyLotNumber]);

                }

                PropertyInfoV2ResponseType result = new PropertyInfoV2ResponseType();
                var constMapper = CreateConstPropertyMapV2(accessMatrix, argument.DateFrom, argument.DateTo);
                var mapper = CreatePropertyMapV2(accessMatrix);
                constMapper.Map(result, result);
                mapper.Map(resulDS, result);

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

        private ObjectMapper<PropertyInfoV2ResponseType, PropertyInfoV2ResponseType> CreateConstPropertyMapV2(AccessMatrix accessMatrix, DateTime dateFrom, DateTime dateTo)
        {
            ObjectMapper<PropertyInfoV2ResponseType, PropertyInfoV2ResponseType> mapper = new ObjectMapper<PropertyInfoV2ResponseType, PropertyInfoV2ResponseType>(accessMatrix);

            mapper.AddConstantMap((r) => r.DateFrom, dateFrom);
            mapper.AddConstantMap((r) => r.DateTo, dateTo);

            return mapper;
        }

        private DataSetMapper<PropertyInfoV2ResponseType> CreatePropertyMapV2(AccessMatrix accessMatrix)
        {
            DataSetMapper<PropertyInfoV2ResponseType> mapper = new DataSetMapper<PropertyInfoV2ResponseType>(accessMatrix);

            mapper.AddDataSetObjectInitializer((ds) => (ds.Tables["propertyInfo"] != null && ds.Tables["propertyInfo"].Rows.Count > 0) ? ds.Tables["propertyInfo"].Rows[0] : null);

            mapper.AddDataColumnMap((r) => r.PropertyData, GetConfigColumn("selbyproperty3_PropertyRemarkAsString"));
            mapper.AddDataColumnMap((r) => r.LotType, GetConfigColumn("selbyproperty3_A27"));
            mapper.AddDataColumnMap((r) => r.LotNumber, GetConfigColumn("selbyproperty3_PropertyLotNumber"));
            mapper.AddDataColumnMap((r) => r.DateOpened, GetConfigColumn("selbyproperty3_PropertyLotPublicationDate"), DateParse());
            mapper.AddDataColumnMap((r) => r.CadastreNumber, GetConfigColumn("selbyproperty3_PropertyCadastreNumber"));
            mapper.AddDataColumnMap((r) => r.RegistryAgency, GetConfigColumn("selbyproperty3_SiteName"));
            mapper.AddDataColumnMap((r) => r.SiteID, GetConfigColumn("selbyproperty3_SiteId"));
            mapper.AddDataColumnMap((r) => r.SiteStartDate, GetConfigColumn("selbyproperty3_SiteStartDate"), DateParse());

            mapper.AddDataRowMap((r) => r.PropertyActDetailList, row => row.GetChildRows("prop_acts_fk"));
            mapper.AddDataColumnMap((r) => r.PropertyActDetailList[0].Act.IncomingRegistrationNumber, GetConfigColumn("selbyproperty3_IncomingRegisterNumber"));
            mapper.AddDataColumnMap((r) => r.PropertyActDetailList[0].Act.IncomingRegistrationDate, GetConfigColumn("selbyproperty3_IncomingRegisterDate"), DateParse());
            mapper.AddDataColumnMap((r) => r.PropertyActDetailList[0].Act.DoubleRegisterNumber, GetConfigColumn("selbyproperty3_A17"));
            mapper.AddDataColumnMap((r) => r.PropertyActDetailList[0].Act.RegistrationDate, GetConfigColumn("selbyproperty3_DoubleIncomingRegisterDate"), DateParse());
            mapper.AddDataColumnMap((r) => r.PropertyActDetailList[0].Act.Volume, GetConfigColumn("selbyproperty3_A21"));
            mapper.AddDataColumnMap((r) => r.PropertyActDetailList[0].Act.Page, GetConfigColumn("selbyproperty3_A22"));
            mapper.AddDataColumnMap((r) => r.PropertyActDetailList[0].Act.ActYear, GetConfigColumn("selbyproperty3_A23"));
            mapper.AddDataColumnMap((r) => r.PropertyActDetailList[0].Act.Condition, GetConfigColumn("selbyproperty3_Condition"));

            //The new columns 
            mapper.AddDataColumnMap((r) => r.PropertyActDetailList[0].Act.WorthCurrency, GetConfigColumn("selbyproperty3_WorthValue"));
            mapper.AddDataColumnMap((r) => r.PropertyActDetailList[0].Act.WorthValue, GetConfigColumn("selbyproperty3_WorthCurrency"));
            //

            string columnLeftSide = GetConfigColumn("selbyproperty3_LeftSide");
            mapper.AddFunctionMap<PropertyInfoV2ResponseType, List<string>>(
                (r) => r.PropertyActDetailList[0].Act.LeftSide.Side,
                row => (
                        (row[columnLeftSide] != DBNull.Value && row[columnLeftSide] != null) ?
                         row[columnLeftSide].ToString().Split(new string[] { @"/n" }, StringSplitOptions.RemoveEmptyEntries).ToList<string>() :
                         new List<string>())
                );

            string columnRightSide = GetConfigColumn("selbyproperty3_RightSide");
            mapper.AddFunctionMap<PropertyInfoV2ResponseType, List<string>>(
                (r) => r.PropertyActDetailList[0].Act.RightSide.Side,
                row => (
                        (row[columnRightSide] != DBNull.Value && row[columnRightSide] != null) ?
                         row[columnRightSide].ToString().Split(new string[] { @"/n" }, StringSplitOptions.RemoveEmptyEntries).ToList<string>() :
                         new List<string>())
                );

            string columnOldBook = GetConfigColumn("selbyproperty3_OldBook");
            string columnA20 = GetConfigColumn("selbyproperty3_A20");
            mapper.AddFunctionMap<PropertyInfoV2ResponseType, string>((r) => r.PropertyActDetailList[0].Act.BookTypeName,
                row => ((row[columnOldBook] != DBNull.Value && row[columnOldBook] != null) ?
                         row[columnOldBook].ToString() :
                        (row[columnA20] != DBNull.Value && row[columnA20] != null ? row[columnA20].ToString() : String.Empty)));

            string columnOldActType = GetConfigColumn("selbyproperty3_OldActType");
            string columnA18 = GetConfigColumn("selbyproperty3_A18");
            mapper.AddFunctionMap<PropertyInfoV2ResponseType, string>((r) => r.PropertyActDetailList[0].Act.ActTypeName,
                row => ((row[columnOldActType] != DBNull.Value && row[columnOldActType] != null) ?
                         row[columnOldActType].ToString() :
                        (row[columnA18] != DBNull.Value && row[columnA18] != null ? row[columnA18].ToString() : String.Empty)));

            string columnConnActs = GetConfigColumn("selbyproperty3_ConnActs");
            string columnConnActsC = GetConfigColumn("selbyproperty3_ConnActsC");
            mapper.AddFunctionMap<PropertyInfoV2ResponseType, string>((r) => r.PropertyActDetailList[0].Act.ConnectedActs,
                row => ((row[columnConnActs] != DBNull.Value && row[columnConnActs] != null) ?
                         row[columnConnActs].ToString().Replace("/n", ";") :
                        (row[columnConnActsC] != DBNull.Value && row[columnConnActsC] != null ? row[columnConnActsC].ToString().Replace("/n", ";") : String.Empty)));

            mapper.AddDataColumnMap((r) => r.PropertyActDetailList[0].Sequence, GetConfigColumn("selbyproperty3_R"));
            mapper.AddDataColumnMap((r) => r.PropertyActDetailList[0].LotPart, GetConfigColumn("selbyproperty3_LotPart"));
            mapper.AddDataColumnMap((r) => r.PropertyActDetailList[0].ListBookNumber, GetConfigColumn("selbyproperty3_ListBookNumber"));
            mapper.AddDataColumnMap((r) => r.PropertyActDetailList[0].ListBookDate, GetConfigColumn("selbyproperty3_ListBookDate"), DateParse());

            return mapper;
        }

        #endregion

        #region PropertySearch - 3. Търсене на имот

        public CommonSignedResponse<PropertySearchRequestType, PropertySearchResponseType> PropertySearch(PropertySearchRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
            try
            {
                OracleConnection connection = new OracleConnection(ConnectionString.Value);
                DataSet ds = new DataSet();
                ds.Tables.Add("properties");
                
                OracleCommand command = new OracleCommand();
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = SchemaName.Value + ".SEL_LIKE_ALL";
                command.Parameters.Add(new OracleParameter("outCursor", OracleDbType.RefCursor, ParameterDirection.Output));
                command.Parameters.Add(new OracleParameter("p_PROPERTY_ID", OracleDbType.Varchar2, DBNull.Value, ParameterDirection.Input));
                command.Parameters.Add(new OracleParameter("p_CREATOR_ID", OracleDbType.Varchar2, DBNull.Value, ParameterDirection.Input));
                command.Parameters.Add(new OracleParameter("p_CREATE_DATE", OracleDbType.Date, DBNull.Value, ParameterDirection.Input));
                command.Parameters.Add(new OracleParameter("p_MODIFIER_ID", OracleDbType.Varchar2, DBNull.Value, ParameterDirection.Input));
                command.Parameters.Add(new OracleParameter("p_MODIFY_DATE", OracleDbType.Date, DBNull.Value, ParameterDirection.Input));
                command.Parameters.Add(new OracleParameter("p_SITE_ID", OracleDbType.Varchar2, argument.GetValueOrNull(r => r.SiteID), ParameterDirection.Input));
                command.Parameters.Add(new OracleParameter("p_UPDATE_COUNT", OracleDbType.Decimal, DBNull.Value, ParameterDirection.Input));
                command.Parameters.Add(new OracleParameter("p_CADASTRE_NUMBER", OracleDbType.Varchar2, argument.GetValueOrNull(r => r.CadastreNumber), ParameterDirection.Input));
                command.Parameters.Add(new OracleParameter("p_SECOND_CADASTRE_NUMBER", OracleDbType.Varchar2, argument.GetValueOrNull(r => r.SecondCadastreNumber), ParameterDirection.Input));
                command.Parameters.Add(new OracleParameter("p_PROPERTY_TYPE_ID", OracleDbType.Varchar2, DBNull.Value, ParameterDirection.Input));
                command.Parameters.Add(new OracleParameter("p_SURFACE_DOC", OracleDbType.Decimal, DBNull.Value, ParameterDirection.Input));
                command.Parameters.Add(new OracleParameter("p_SURFACE_REAL", OracleDbType.Decimal, DBNull.Value, ParameterDirection.Input));
                command.Parameters.Add(new OracleParameter("p_SOIL_CATEGORY", OracleDbType.Varchar2, DBNull.Value, ParameterDirection.Input));
                command.Parameters.Add(new OracleParameter("p_REGULATED_QUARTER", OracleDbType.Varchar2, DBNull.Value, ParameterDirection.Input));
                command.Parameters.Add(new OracleParameter("p_REGULATION_PLAN_YEAR", OracleDbType.Varchar2, DBNull.Value, ParameterDirection.Input));
                command.Parameters.Add(new OracleParameter("p_PLACE_ID", OracleDbType.Varchar2, DBNull.Value, ParameterDirection.Input));
                command.Parameters.Add(new OracleParameter("p_HOUSING_ESTATE", OracleDbType.Varchar2, argument.GetValueOrNull(r => r.HousingEstate), ParameterDirection.Input));
                command.Parameters.Add(new OracleParameter("p_DISTRICT", OracleDbType.Varchar2, argument.GetValueOrNull(r => r.NeighborhoodName), ParameterDirection.Input));
                command.Parameters.Add(new OracleParameter("p_STREET", OracleDbType.Varchar2, argument.GetValueOrNull(r => r.StreetName), ParameterDirection.Input));
                command.Parameters.Add(new OracleParameter("p_STREET_NUMBER", OracleDbType.Varchar2, argument.GetValueOrNull(r => r.StreetNumber), ParameterDirection.Input));
                command.Parameters.Add(new OracleParameter("p_BLOCK", OracleDbType.Varchar2, argument.GetValueOrNull(r => r.Block), ParameterDirection.Input));
                command.Parameters.Add(new OracleParameter("p_ENTRANCE", OracleDbType.Varchar2, argument.GetValueOrNull(r => r.Entrance), ParameterDirection.Input));
                command.Parameters.Add(new OracleParameter("p_FLOOR", OracleDbType.Varchar2, argument.GetValueOrNull(r => r.Floor), ParameterDirection.Input));
                command.Parameters.Add(new OracleParameter("p_APARTMENT", OracleDbType.Varchar2, argument.GetValueOrNull(r => r.Appartment), ParameterDirection.Input));
                command.Parameters.Add(new OracleParameter("p_POST_BOX", OracleDbType.Varchar2, argument.GetValueOrNull(r => r.PostBox), ParameterDirection.Input));
                command.Parameters.Add(new OracleParameter("p_REMARK", OracleDbType.Varchar2, DBNull.Value, ParameterDirection.Input));
                command.Parameters.Add(new OracleParameter("p_NUM_LEVELS", OracleDbType.Decimal, DBNull.Value, ParameterDirection.Input));
                command.Parameters.Add(new OracleParameter("p_IDEAL_PARTS", OracleDbType.Varchar2, DBNull.Value, ParameterDirection.Input));
                command.Parameters.Add(new OracleParameter("p_IDEAL_PARTS_TYPE", OracleDbType.Decimal, DBNull.Value, ParameterDirection.Input));
                command.Parameters.Add(new OracleParameter("p_COUNTRYSIDE", OracleDbType.Varchar2, DBNull.Value, ParameterDirection.Input));
                command.Parameters.Add(new OracleParameter("p_MASSIF_NUMBER", OracleDbType.Varchar2, DBNull.Value, ParameterDirection.Input));
                command.Parameters.Add(new OracleParameter("p_PARCEL", OracleDbType.Varchar2, DBNull.Value, ParameterDirection.Input));
                command.Parameters.Add(new OracleParameter("p_PERMANENT_FUNCTION_ID", OracleDbType.Varchar2, DBNull.Value, ParameterDirection.Input));
                command.Parameters.Add(new OracleParameter("p_WAY_OF_USAGE_ID", OracleDbType.Varchar2, DBNull.Value, ParameterDirection.Input));
                command.Parameters.Add(new OracleParameter("p_FUNCTION_ID", OracleDbType.Varchar2, DBNull.Value, ParameterDirection.Input));
                command.Parameters.Add(new OracleParameter("p_PLOT_IDENTIFIER", OracleDbType.Varchar2, DBNull.Value, ParameterDirection.Input));
                command.Parameters.Add(new OracleParameter("p_PROPERTY_LOT_NUMBER", OracleDbType.Varchar2, argument.GetValueOrNull(r => r.PropertyLot), ParameterDirection.Input));
                command.Parameters.Add(new OracleParameter("p_PROPERTY_LOT_TYPE_ID", OracleDbType.Varchar2, DBNull.Value, ParameterDirection.Input));
                command.Parameters.Add(new OracleParameter("p_CONNECTED_OBJECT", OracleDbType.Varchar2, DBNull.Value, ParameterDirection.Input));
                command.Parameters.Add(new OracleParameter("p_CONNECTED_OBJECT_NUMBER", OracleDbType.Decimal, DBNull.Value, ParameterDirection.Input));
                //IISCIR_HELPER.ADD_NUMBER_PARAMETER(p_AREA_MEASURE_ID, 'AREA_MEASURE_ID',SQLSTMT) е в базата
                command.Parameters.Add(new OracleParameter("p_AREA_MEASURE_ID", OracleDbType.Varchar2, DBNull.Value, ParameterDirection.Input));
                command.Parameters.Add(new OracleParameter("p_OLD_LOT_NUMBER", OracleDbType.Varchar2, argument.GetValueOrNull(r => r.OldPropertyLot), ParameterDirection.Input));
                
                OracleDataAdapter resultDataAdapter = new OracleDataAdapter(command);

                try
                {
                    connection.Open();
                    resultDataAdapter.Fill(ds.Tables["properties"]);
                }
                finally
                {
                    connection.Close();
                }

                //LogToDatabase(aditionalParameters, null, null, null, "003:Търсене на имот", argument, id);

                PropertySearchResponseType result = new PropertySearchResponseType();
                DataSetMapper<PropertySearchResponseType> mapper = CreatePropertySearchMap(accessMatrix);
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

        private DataSetMapper<PropertySearchResponseType> CreatePropertySearchMap(AccessMatrix accessMatrix)
        {
            DataSetMapper<PropertySearchResponseType> mapper = new DataSetMapper<PropertySearchResponseType>(accessMatrix);

            mapper.AddDataSetMap((r) => r.PropertyDetailList, (d) => d.Tables["properties"].Rows);
            mapper.AddDataColumnMap((r) => r.PropertyDetailList[0].PropertyID, GetConfigColumn("sel_like_all_PropertyId"));
            mapper.AddDataColumnMap((r) => r.PropertyDetailList[0].LotNumber, GetConfigColumn("sel_like_all_LotNumber"));
            mapper.AddDataColumnMap((r) => r.PropertyDetailList[0].OldLotNumber, GetConfigColumn("sel_like_all_OldLotNumber"));
            mapper.AddDataColumnMap((r) => r.PropertyDetailList[0].RegistryAgency, GetConfigColumn("sel_like_all_SiteName"));
            mapper.AddDataColumnMap((r) => r.PropertyDetailList[0].SiteID, GetConfigColumn("sel_like_all_SiteId"));
            mapper.AddDataColumnMap((r) => r.PropertyDetailList[0].SiteStartDate, GetConfigColumn("sel_like_all_SiteStartDate"), DateParse());
            mapper.AddDataColumnMap((r) => r.PropertyDetailList[0].CadastreNumber, GetConfigColumn("sel_like_all_CadastreNumber"));
            mapper.AddDataColumnMap((r) => r.PropertyDetailList[0].SecondCadastreNumber, GetConfigColumn("sel_like_all_SecondCadastreNumber"));
            mapper.AddDataColumnMap((r) => r.PropertyDetailList[0].PropertyType, GetConfigColumn("sel_like_all_PropertyTypeName"));
            mapper.AddDataColumnMap((r) => r.PropertyDetailList[0].DistrictName, GetConfigColumn("sel_like_all_Oblast"));
            mapper.AddDataColumnMap((r) => r.PropertyDetailList[0].MunicipalityName, GetConfigColumn("sel_like_all_Obshtina"));
            mapper.AddDataColumnMap((r) => r.PropertyDetailList[0].TerritorialUnitName, GetConfigColumn("sel_like_all_City"));
            mapper.AddDataColumnMap((r) => r.PropertyDetailList[0].HousingEstate, GetConfigColumn("sel_like_all_HostingEstate"));
            mapper.AddDataColumnMap((r) => r.PropertyDetailList[0].NeighborhoodName, GetConfigColumn("sel_like_all_District"));
            mapper.AddDataColumnMap((r) => r.PropertyDetailList[0].StreetName, GetConfigColumn("sel_like_all_Street"));
            mapper.AddDataColumnMap((r) => r.PropertyDetailList[0].StreetNumber, GetConfigColumn("sel_like_all_StreetNumber"));
            mapper.AddDataColumnMap((r) => r.PropertyDetailList[0].Block, GetConfigColumn("sel_like_all_BlockName"));
            mapper.AddDataColumnMap((r) => r.PropertyDetailList[0].Entrance, GetConfigColumn("sel_like_all_Entrance"));
            mapper.AddDataColumnMap((r) => r.PropertyDetailList[0].Floor, GetConfigColumn("sel_like_all_FloorName"));
            mapper.AddDataColumnMap((r) => r.PropertyDetailList[0].Appartment, GetConfigColumn("sel_like_all_Apartment"));
            mapper.AddDataColumnMap((r) => r.PropertyDetailList[0].PostBox, GetConfigColumn("sel_like_all_PostBox"));
            mapper.AddDataColumnMap((r) => r.PropertyDetailList[0].Remark, GetConfigColumn("sel_like_all_Remark"));

            return mapper;
        }

        #endregion

        #region GetSites - 5. Справка за година на стартиране на информационните системи в Службите по вписванията

        public CommonSignedResponse<GetSitesRequestType, GetSitesResponseType> GetSites(GetSitesRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
            try
            {
                OracleConnection connection = new OracleConnection(ConnectionString.Value);
                DataSet ds = new DataSet();
                ds.Tables.Add("sites");

                OracleCommand command = new OracleCommand();
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = SchemaName.Value + ".GET_SITES";

                command.Parameters.Add(new OracleParameter("outcursor", OracleDbType.RefCursor, ParameterDirection.Output));
                OracleDataAdapter resultDataAdapter = new OracleDataAdapter(command);

                try
                {
                    connection.Open();
                    resultDataAdapter.Fill(ds.Tables["sites"]);
                }
                finally
                {
                    connection.Close();
                }

                //LogToDatabase(aditionalParameters, null, null, null, "005:Справка за година на стартиране на информационните системи в Службите по вписванията", argument, id);

                GetSitesResponseType result = new GetSitesResponseType();
                DataSetMapper<GetSitesResponseType> mapper = CreateGetSitesMap(accessMatrix);
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

        private DataSetMapper<GetSitesResponseType> CreateGetSitesMap(AccessMatrix accessMatrix)
        {
            DataSetMapper<GetSitesResponseType> mapper = new DataSetMapper<GetSitesResponseType>(accessMatrix);

            mapper.AddDataSetMap((r) => r.site, (d) => d.Tables["sites"].Rows);
            mapper.AddDataColumnMap((r) => r.site[0].siteID, GetConfigColumn("get_sites_SiteCode"), (o) => o.ToString().Trim());
            mapper.AddDataColumnMap((r) => r.site[0].siteName, GetConfigColumn("get_sites_SiteName"));
            mapper.AddDataColumnMap((r) => r.site[0].siteStartDate, GetConfigColumn("get_sites_SiteStartDate"), DateParse());

            return mapper;
        }

        #endregion

        #region Log to database

        //private string TruncateLogParamLength(string value, int maxLength = 500)
        //{
        //    if (string.IsNullOrEmpty(value))
        //    {
        //        return value;
        //    }

        //    return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        //}

        //private void LogToDatabase<T>(AdapterAdditionalParameters additionalParameters,
        //    string egnParam, string eikParam, string propIdParam,
        //    string reportType, T request,
        //    Guid id)
        //{

        //    try
        //    {
        //        string inputParams = FormatRequestParametersForLog(request);
        //        string reportId = TruncateLogParamLength(additionalParameters.ApiServiceCallId.ToString());//2
        //        string userId = TruncateLogParamLength(additionalParameters.CallContext.EmployeeIdentifier); //8
        //        string userName1 = TruncateLogParamLength(additionalParameters.CallContext.EmployeeNames); //9
        //        string userName2 = TruncateLogParamLength(additionalParameters.CallContext.ResponsiblePersonIdentifier); //10
        //        string userPosition = TruncateLogParamLength(additionalParameters.CallContext.EmployeePosition); //11
        //        string admName = TruncateLogParamLength(additionalParameters.CallContext.AdministrationName); //12
        //        string systemName = TruncateLogParamLength(additionalParameters.OrganizationUnit); //13

        //        egnParam = TruncateLogParamLength(egnParam);
        //        eikParam = TruncateLogParamLength(eikParam);
        //        propIdParam = TruncateLogParamLength(propIdParam);
        //        reportType = TruncateLogParamLength(reportType);
        //        inputParams = TruncateLogParamLength(inputParams);

        //        string logTableSchema = LogTableSchemaName.Value;
        //        OracleConnection connection = new OracleConnection(ConnectionString.Value);

        //        string commandTextTemplate =
        //            @"INSERT INTO {0}.IISCIR_REGIX_LOG (
        //        REPORT_DATETIME,
        //        REPORT_ID,
        //        REPORT_TYPE,
        //        INPUT_PARAMS,
        //        INPUT_EGN,
        //        INPUT_EIK,
        //        INPUT_PROPERTY,
        //        USER_ID,
        //        USER_NAME1,
        //        USER_NAME2,
        //        USER_POSITION,
        //        ADM_NAME,
        //        SYSTEM_NAME) 
        //        VALUES(
        //        :dateTime, 
        //        :reportId, 
        //        :reportType, 
        //        :inputParams, 
        //        :inputEgn, 
        //        :inputEik, 
        //        :inputProperty, 
        //        :userId, 
        //        :username1, 
        //        :username2, 
        //        :userPosition, 
        //        :admName, 
        //        :systemName )";

        //        string commandText = String.Format(commandTextTemplate, logTableSchema);

        //        OracleCommand command = new OracleCommand();
        //        command.Connection = connection;
        //        command.CommandType = CommandType.Text;
        //        command.CommandText = commandText;
        //        command.Parameters.Add(new OracleParameter("dateTime", OracleDbType.Date, DateTime.Now, ParameterDirection.Input));
        //        command.Parameters.Add(new OracleParameter("reportId", OracleDbType.NVarchar2, reportId, ParameterDirection.Input));
        //        command.Parameters.Add(new OracleParameter("reportType", OracleDbType.NVarchar2, reportType, ParameterDirection.Input));
        //        command.Parameters.Add(new OracleParameter("inputParams", OracleDbType.NVarchar2, inputParams, ParameterDirection.Input));
        //        command.Parameters.Add(new OracleParameter("inputEgn", OracleDbType.NVarchar2, egnParam, ParameterDirection.Input));
        //        command.Parameters.Add(new OracleParameter("inputEik", OracleDbType.NVarchar2, eikParam, ParameterDirection.Input));
        //        command.Parameters.Add(new OracleParameter("inputProperty", OracleDbType.NVarchar2, propIdParam, ParameterDirection.Input));
        //        command.Parameters.Add(new OracleParameter("userId", OracleDbType.NVarchar2, userId, ParameterDirection.Input));
        //        command.Parameters.Add(new OracleParameter("username1", OracleDbType.NVarchar2, userName1, ParameterDirection.Input));
        //        command.Parameters.Add(new OracleParameter("username2", OracleDbType.NVarchar2, userName2, ParameterDirection.Input));
        //        command.Parameters.Add(new OracleParameter("userPosition", OracleDbType.NVarchar2, userPosition, ParameterDirection.Input));
        //        command.Parameters.Add(new OracleParameter("admName", OracleDbType.NVarchar2, admName, ParameterDirection.Input));
        //        command.Parameters.Add(new OracleParameter("systemName", OracleDbType.NVarchar2, systemName, ParameterDirection.Input));

        //        try
        //        {
        //            connection.Open();
        //            command.ExecuteNonQuery();
        //        }
        //        finally
        //        {
        //            connection.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LogError(additionalParameters, ex, new { Guid = id, Info = "Error in logging request data to database." });
        //    }
        //}

        //private string FormatRequestParametersForLog<T>(T request)
        //{
        //    string inputParams = string.Empty;
        //    string template = "&[{0}]:[{1}]";
        //    foreach (var prop in request.GetType().GetProperties())
        //    {
        //        object value = prop.GetValue(request);

        //        if (value != null)
        //        {
        //            string valueString = value.ToString();
        //            inputParams += string.Format(template, prop.Name, valueString);
        //        }
        //    }

        //    inputParams = String.IsNullOrEmpty(inputParams) ? inputParams : inputParams.Substring(1);

        //    return inputParams;
        //}

        #endregion

        private string GetConfigColumn(string key)
        {
            object result = ConfigurationManager.AppSettings[key];
            return result?.ToString();
        }

        private static Func<object, object> DateParse()
        {
            return (o) =>
            {
                if (o != null && o != System.DBNull.Value)
                {
                    DateTime date;
                    if (DateTime.TryParseExact(o.ToString(), new string[] { "dd.MM.yyyy", "dd/MM/yyyy" }, CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                    {
                        return date;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return o;
                }
            };
        }
    }
}
