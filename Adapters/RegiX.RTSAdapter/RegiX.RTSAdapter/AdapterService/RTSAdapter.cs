using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using TechnoLogica.RegiX.Common.Utils;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.ObjectMapping;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Common.DataContracts;
using NpgsqlTypes;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Adapters.Common.DataContracts;
using TechnoLogica.RegiX.Common.DataContracts.Parameter;
using TechnoLogica.RegiX.Adapters.Common.ObjectMapping;

namespace TechnoLogica.RegiX.RTSAdapter.AdapterService
{
    [Export(typeof(IAdapterService))]
    [ExportFullName(typeof(RTSAdapter), typeof(IAdapterService))]
    [ExportSimpleName(typeof(RTSAdapter), typeof(IAdapterService))]
    public class RTSAdapter : NpgsqlAdapterService.NpgsqlBaseAdapterService, IRTSAdapter, IAdapterService
    {
        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(RTSAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> ConnectionString =
            new ParameterInfo<string>("Server=egov;Port=5432;Database=drive;UserId=;Password=;Timeout=1024")
            {
                Key = Constants.ConnectionStringParameterKeyName,
                Description = "Connection string",
                OwnerAssembly = typeof(RTSAdapter).Assembly
            };

        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(RTSAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> ProcedureName =
            new ParameterInfo<string>("busroutes.RegiX_Search_Lines")
            {
                Key = "ProcedureName",
                Description = "Procedure Name",
                OwnerAssembly = typeof(RTSAdapter).Assembly
            };

        public CommonSignedResponse<RoutesSearch, RoutesResponse> GetRoutesTimeTable(RoutesSearch routesSearch, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
             Guid id = Guid.NewGuid();
             DateTime executionStart = DateTime.Now;
             LogData(aditionalParameters, new { Request = routesSearch.XmlSerialize(), Guid = id });
             try
             {
                 Npgsql.NpgsqlConnection connection = new Npgsql.NpgsqlConnection(ConnectionString.Value);

                 //backwordForwordMunicipalityFilterCommand
                 Npgsql.NpgsqlCommand backwordForwordMunicipalityFilterCommand = new Npgsql.NpgsqlCommand();
                 backwordForwordMunicipalityFilterCommand.Connection = connection;
                 backwordForwordMunicipalityFilterCommand.CommandType = CommandType.Text;
                 backwordForwordMunicipalityFilterCommand.Parameters.Add("@pForwardMunicipality", NpgsqlTypes.NpgsqlDbType.Text).Value = routesSearch.GetValueOrNull(r => r.ForwardFirstStopMunicipality);
                 backwordForwordMunicipalityFilterCommand.Parameters.Add("@pBackwardMunicipality", NpgsqlTypes.NpgsqlDbType.Text).Value = routesSearch.GetValueOrNull(r => r.BackwardFirstStopMunicipality);
                
                 if(routesSearch.ForwardTimeSpecified || routesSearch.BackwardTimeSpecified)
                 {
                     
                     backwordForwordMunicipalityFilterCommand.CommandText = _textFilterBackForMunAndTime;
                     backwordForwordMunicipalityFilterCommand.Parameters.Add("@pForwardTime", NpgsqlTypes.NpgsqlDbType.Time).Value = routesSearch.GetValueOrNull(r => r.ForwardTime);//routesSearch.ForwardTimeSpecified ? (object)((DateTime)routesSearch.ForwardTime).ToString("HH:mm:ss") : (object)DBNull.Value;
                     backwordForwordMunicipalityFilterCommand.Parameters.Add("@pBackwardTime", NpgsqlTypes.NpgsqlDbType.Time).Value = routesSearch.GetValueOrNull(r => r.BackwardTime);//routesSearch.BackwardTimeSpecified ? (object)((DateTime)routesSearch.BackwardTime).ToString("HH:mm:ss") : (object)DBNull.Value;
              
                 }
                 else
                 {
                     backwordForwordMunicipalityFilterCommand.CommandText = _textFilterBackForMun;
                 }

                 //seasonalFilterCommand
                 Npgsql.NpgsqlCommand seasonalFilterCommand = null;
                 if (routesSearch.Seasonal.IsSeasonalSpecified)
                 {
                     seasonalFilterCommand = new Npgsql.NpgsqlCommand();
                     seasonalFilterCommand.Connection = connection;
                     seasonalFilterCommand.CommandType = CommandType.Text;
                     DateTime? seasonStart;
                     DateTime? seasonEnd;

                     if (routesSearch.Seasonal.IsSeasonal)
                     {
                         try
                         {
                             int day = Conversions.GDayToInt.Invoke(routesSearch.Seasonal.SeasonStartDay);
                             int month = Conversions.GMonthToInt.Invoke(routesSearch.Seasonal.SeasonStartMonth);
                             int year = 2001;
                             seasonStart = new DateTime(year, month, day);
                         }
                         catch
                         {
                             seasonStart = null; //new DateTime(2003, 1, 1);
                         }
                         try
                         {
                             int day = Conversions.GDayToInt.Invoke(routesSearch.Seasonal.SeasonEndDay);
                             int month = Conversions.GMonthToInt.Invoke(routesSearch.Seasonal.SeasonEndMonth);
                             int year = 2001;
                             seasonEnd = new DateTime(year, month, day);
                             if (seasonEnd < seasonStart)
                             {
                                 ((DateTime)seasonEnd).AddYears(1);
                             }
                         }
                         catch
                         {
                             seasonEnd = null; //new DateTime(2003, 12, 31);
                         }
                         seasonalFilterCommand.CommandText = _textFilterSeasonalTrue;
                         seasonalFilterCommand.Parameters.Add("@pSeasonStartDate", NpgsqlTypes.NpgsqlDbType.Date).Value = seasonStart;
                         seasonalFilterCommand.Parameters.Add("@pSeasonEndDate", NpgsqlTypes.NpgsqlDbType.Date).Value = seasonEnd;
                     }
                     else
                     {
                         seasonalFilterCommand.CommandText = _textFilterSeasonalFalse;
                     }
                 }

                 //holidayFilterCommand
                 Npgsql.NpgsqlCommand holidayFilterCommand = null;
                 if (routesSearch.Schedule.HolidaySpecified || routesSearch.Schedule.BeforeHolidaySpecified)
                 {
                     holidayFilterCommand = new Npgsql.NpgsqlCommand();
                     holidayFilterCommand.Connection = connection;
                     holidayFilterCommand.CommandType = CommandType.Text;
                     holidayFilterCommand.CommandText = _textFilterHoliday;
                     holidayFilterCommand.Parameters.Add("@pBeforeHoliday", NpgsqlTypes.NpgsqlDbType.Boolean).Value = routesSearch.Schedule.GetValueOrNull(r => r.BeforeHoliday);
                     holidayFilterCommand.Parameters.Add("@pHoliday", NpgsqlTypes.NpgsqlDbType.Boolean).Value = routesSearch.Schedule.GetValueOrNull(r => r.Holiday);
             
                 }

                 //dailyFilterCommand
                 Npgsql.NpgsqlCommand dailyFilterCommand = null;
                 if( routesSearch.Schedule.IsDailySpecified 
                     || routesSearch.Schedule.MondaySpecified
                     || routesSearch.Schedule.ThursdaySpecified
                     || routesSearch.Schedule.WednesdaySpecified
                     || routesSearch.Schedule.ThursdaySpecified
                     || routesSearch.Schedule.FridaySpecified
                     || routesSearch.Schedule.SaturdaySpecified
                     || routesSearch.Schedule.SundaySpecified)
                 {
                     dailyFilterCommand = new Npgsql.NpgsqlCommand();
                     dailyFilterCommand.Connection = connection;
                     dailyFilterCommand.CommandType = CommandType.Text;
                     
                     
                     if (routesSearch.Schedule.IsDailySpecified == false || routesSearch.Schedule.IsDaily == false)
                     {
                         dailyFilterCommand.Parameters.Add("@pIsDaily", NpgsqlTypes.NpgsqlDbType.Boolean).Value = routesSearch.Schedule.GetValueOrNull(r => r.IsDaily);
                         dailyFilterCommand.Parameters.Add("@pMonday", NpgsqlTypes.NpgsqlDbType.Boolean).Value = routesSearch.Schedule.GetValueOrNull(r => r.Monday);
                         dailyFilterCommand.Parameters.Add("@pTuesday", NpgsqlTypes.NpgsqlDbType.Boolean).Value = routesSearch.Schedule.GetValueOrNull(r => r.Tuesday);
                         dailyFilterCommand.Parameters.Add("@pWednesday", NpgsqlTypes.NpgsqlDbType.Boolean).Value = routesSearch.Schedule.GetValueOrNull(r => r.Wednesday);
                         dailyFilterCommand.Parameters.Add("@pThursday", NpgsqlTypes.NpgsqlDbType.Boolean).Value = routesSearch.Schedule.GetValueOrNull(r => r.Thursday);
                         dailyFilterCommand.Parameters.Add("@pFriday", NpgsqlTypes.NpgsqlDbType.Boolean).Value = routesSearch.Schedule.GetValueOrNull(r => r.Friday);
                         dailyFilterCommand.Parameters.Add("@pSaturday", NpgsqlTypes.NpgsqlDbType.Boolean).Value = routesSearch.Schedule.GetValueOrNull(r => r.Saturday);
                         dailyFilterCommand.Parameters.Add("@pSunday", NpgsqlTypes.NpgsqlDbType.Boolean).Value = routesSearch.Schedule.GetValueOrNull(r => r.Sunday);
                         dailyFilterCommand.CommandText = _textFilterDailyFalse;
                     }
                     else
                     {
                          dailyFilterCommand.CommandText = _textFilterDailyTrue;
                     }
                 }

                
                 Npgsql.NpgsqlCommand commandMaster = new Npgsql.NpgsqlCommand();
                 commandMaster.Connection = connection;
                 commandMaster.CommandType = CommandType.Text;
                 commandMaster.CommandText = commandTextMasterTable;
                 

                 Npgsql.NpgsqlCommand commandDetail = new Npgsql.NpgsqlCommand();
                 commandDetail.Connection = connection;
                 commandDetail.CommandType = CommandType.Text;
                 commandDetail.CommandText = commandTextDetail;

                 Npgsql.NpgsqlDataAdapter daBackwordForwordMunicipalityFilter = new Npgsql.NpgsqlDataAdapter(backwordForwordMunicipalityFilterCommand);
                 Npgsql.NpgsqlDataAdapter daMaster = new Npgsql.NpgsqlDataAdapter(commandMaster);
                 Npgsql.NpgsqlDataAdapter daDetail = new Npgsql.NpgsqlDataAdapter(commandDetail);
                 DataSet dsFilters = new DataSet();
                 dsFilters.Tables.Add("backwordForwordMunicipalityFilterCommand");
                 dsFilters.Tables.Add("seasonalFilterCommand");
                 dsFilters.Tables.Add("holidayFilterCommand");
                 dsFilters.Tables.Add("dailyFilterCommand");
                 DataSet ds = new DataSet();
                 
                 ds.Tables.Add("Lines_info");
                 ds.Tables.Add("Paths_info");
                 try
                 {
                     connection.Open();
                     using (Npgsql.NpgsqlTransaction t = connection.BeginTransaction())
                     {
                         daBackwordForwordMunicipalityFilter.Fill(dsFilters.Tables["backwordForwordMunicipalityFilterCommand"]);
                         List<int> filterIds = GetListIds(dsFilters.Tables["backwordForwordMunicipalityFilterCommand"]);
                         if(seasonalFilterCommand != null)
                         {
                             seasonalFilterCommand.Parameters.Add("@id_list", NpgsqlDbType.Array | NpgsqlDbType.Integer).Value = filterIds;
                             Npgsql.NpgsqlDataAdapter daSeasonalFilter = new Npgsql.NpgsqlDataAdapter(seasonalFilterCommand);
                             daSeasonalFilter.Fill(dsFilters.Tables["seasonalFilterCommand"]);
                             filterIds = GetListIds(dsFilters.Tables["seasonalFilterCommand"]);
                         }
                         if (holidayFilterCommand != null)
                         {
                             holidayFilterCommand.Parameters.Add("@id_list", NpgsqlDbType.Array | NpgsqlDbType.Integer).Value = filterIds;
                             Npgsql.NpgsqlDataAdapter daHolidayFilter = new Npgsql.NpgsqlDataAdapter(holidayFilterCommand);
                             daHolidayFilter.Fill(dsFilters.Tables["holidayFilterCommand"]);
                             filterIds = GetListIds(dsFilters.Tables["holidayFilterCommand"]);
                         }
                         if (dailyFilterCommand != null)
                         {
                             dailyFilterCommand.Parameters.Add("@id_list", NpgsqlDbType.Array | NpgsqlDbType.Integer).Value = filterIds;
                             Npgsql.NpgsqlDataAdapter daDailyFilter = new Npgsql.NpgsqlDataAdapter(dailyFilterCommand);
                             daDailyFilter.Fill(dsFilters.Tables["dailyFilterCommand"]);
                             filterIds = GetListIds(dsFilters.Tables["dailyFilterCommand"]);
                         }

                         if (filterIds.Count > 100) filterIds = filterIds.GetRange(0, 100);

                         commandMaster.Parameters.Add("@id_list", NpgsqlDbType.Array | NpgsqlDbType.Integer).Value = filterIds;
                         daMaster.Fill(ds.Tables["Lines_info"]);
                         commandDetail.Parameters.Add("@id_list", NpgsqlDbType.Array | NpgsqlDbType.Integer).Value = filterIds;
                         daDetail.Fill(ds.Tables["Paths_info"]);
                         t.Commit();
                     }
                 }
                 finally
                 {
                     connection.Close();
                 }

                 //ds.Tables[0].TableName = "Lines_info";
                 //ds.Tables[1].TableName = "Paths_info";
                 ds.Tables["Lines_info"].ChildRelations.Add(new DataRelation("LinePaths", ds.Tables["Lines_info"].Columns["id"], ds.Tables["Paths_info"].Columns["line_id"], true));


                 DataSetMapper<RoutesResponse> routesMapper = CreateRoutesMap(accessMatrix);
                 RoutesResponse result = new RoutesResponse();
                 routesMapper.Map(ds, result);
                 LogData(aditionalParameters, new { Result = "Success", ExecutionTime = (DateTime.Now - executionStart), Guid = id });
                 return
                        SigningUtils.CreateAndSign(
                            routesSearch,
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

        private static List<int> GetListIds(DataTable table)
        {
            List<int> filterIds = new List<int>();
            foreach (DataRow row in table.Rows)
            {
                filterIds.Add((int)row["id"]);
            }
            return filterIds;
        }

        private static DataSetMapper<RoutesResponse> CreateRoutesMap(AccessMatrix accessMatrix)
        {
            DataSetMapper<RoutesResponse> routesMapper = new DataSetMapper<RoutesResponse>(accessMatrix);
            
            routesMapper.AddConstantMap((r) => r.GenerationTimeStamp, DateTime.Now);
            
            routesMapper.AddDataSetMap((r) => r.Routes, (d) => d.Tables["Lines_info"].Rows);

            routesMapper.AddDataColumnMap((r) => r.Routes[0].RouteCode, "routecode");
            routesMapper.AddDataColumnMap((r) => r.Routes[0].RouteName, "routename");
            routesMapper.AddDataColumnMap((r) => r.Routes[0].RouteDescrtiption, "routedescrtiption");
            routesMapper.AddDataColumnMap((r) => r.Routes[0].DriversCount, "driverscount");
            routesMapper.AddDataColumnMap((r) => r.Routes[0].BusesCount, "busescount");
            routesMapper.AddDataColumnMap((r) => r.Routes[0].ApprovalDate, "approvaldate");
            routesMapper.AddDataColumnMap((r) => r.Routes[0].ValidTo, "validto");
            routesMapper.AddDataColumnMap((r) => r.Routes[0].Contractor.ContractorName, "contractorname");
            routesMapper.AddDataColumnMap((r) => r.Routes[0].Contractor.ContractorCode, "contractorcode");
            routesMapper.AddDataColumnMap((r) => r.Routes[0].Contractor.ContractorRegionCode, "regioncode");

            routesMapper.AddDataColumnMap((r) => r.Routes[0].Seasonal.IsSeasonal, "seasonal");
            routesMapper.AddDataColumnMap((r) => r.Routes[0].Seasonal.SeasonStartDay, "seasonstartday", Conversions.ToGDay);
            routesMapper.AddDataColumnMap((r) => r.Routes[0].Seasonal.SeasonEndDay, "seasonendday", Conversions.ToGDay);
            routesMapper.AddDataColumnMap((r) => r.Routes[0].Seasonal.SeasonStartMonth, "seasonstartmonth", Conversions.ToGMonth);
            routesMapper.AddDataColumnMap((r) => r.Routes[0].Seasonal.SeasonEndMonth, "seasonendmonth", Conversions.ToGMonth);

            routesMapper.AddDataColumnMap((r) => r.Routes[0].Schedule.IsDaily, "isdaily");
            routesMapper.AddDataColumnMap((r) => r.Routes[0].Schedule.Monday, "monday");
            routesMapper.AddDataColumnMap((r) => r.Routes[0].Schedule.Tuesday, "tuesday");
            routesMapper.AddDataColumnMap((r) => r.Routes[0].Schedule.Wednesday, "wednesday");
            routesMapper.AddDataColumnMap((r) => r.Routes[0].Schedule.Thursday, "thursday");
            routesMapper.AddDataColumnMap((r) => r.Routes[0].Schedule.Friday, "friday");
            routesMapper.AddDataColumnMap((r) => r.Routes[0].Schedule.Saturday, "saturday");
            routesMapper.AddDataColumnMap((r) => r.Routes[0].Schedule.Sunday, "sunday");
            routesMapper.AddDataColumnMap((r) => r.Routes[0].Schedule.BeforeHoliday, "beforeholiday");
            routesMapper.AddDataColumnMap((r) => r.Routes[0].Schedule.Holiday, "holiday");

            routesMapper.AddDataColumnMap((r) => r.Routes[0].ForwardRoute.Distance, "fdistance");
            routesMapper.AddDataColumnMap((r) => r.Routes[0].ForwardRoute.TravelTime, "ftraveltime", Conversions.ToTimeSpan);
            routesMapper.AddDataColumnMap((r) => r.Routes[0].ForwardRoute.TravelSpeed, "ftravelspeed");
            routesMapper.AddDataColumnMap((r) => r.Routes[0].ForwardRoute.TripTime, "ftriptime", Conversions.ToTimeSpan);
            routesMapper.AddDataColumnMap((r) => r.Routes[0].ForwardRoute.TripSpeed, "ftripspeed");

            routesMapper.AddDataColumnMap((r) => r.Routes[0].BackwardRoute.Distance, "bdistance");
            routesMapper.AddDataColumnMap((r) => r.Routes[0].BackwardRoute.TravelTime, "btraveltime", Conversions.ToTimeSpan);
            routesMapper.AddDataColumnMap((r) => r.Routes[0].BackwardRoute.TravelSpeed, "btravelspeed");
            routesMapper.AddDataColumnMap((r) => r.Routes[0].BackwardRoute.TripTime, "btriptime", Conversions.ToTimeSpan);
            routesMapper.AddDataColumnMap((r) => r.Routes[0].BackwardRoute.TripSpeed, "btripspeed");

            routesMapper.AddDataRowMap((r) => r.Routes[0].BackwardRoute.Paths, (dr) => dr.GetChildRows("LinePaths").OrderBy((d) => d["order"]).Where((d) => Convert.ToString(d["direction"]) == "forward"));
            routesMapper.AddDataRowMap((r) => r.Routes[0].ForwardRoute.Paths, (dr) => dr.GetChildRows("LinePaths").OrderBy((d) => d["order"]).Where((d) => Convert.ToString(d["direction"]) == "backward"));

            routesMapper.AddDataColumnMap((r) => r.Routes[0].ForwardRoute.Paths[0].Order, "order");
            routesMapper.AddDataColumnMap((r) => r.Routes[0].ForwardRoute.Paths[0].FromStation.Station, "fromstation");
            routesMapper.AddDataColumnMap((r) => r.Routes[0].ForwardRoute.Paths[0].FromStation.StationType, "fromsttype");
            routesMapper.AddDataColumnMap((r) => r.Routes[0].ForwardRoute.Paths[0].FromStation.CityCode, "fromcitycode");
            routesMapper.AddDataColumnMap((r) => r.Routes[0].ForwardRoute.Paths[0].FromStation.CityName, "fromcityname");
            routesMapper.AddDataColumnMap((r) => r.Routes[0].ForwardRoute.Paths[0].FromStation.MunicipalityCode, "frommuncode");
            routesMapper.AddDataColumnMap((r) => r.Routes[0].ForwardRoute.Paths[0].FromStation.MunicipalityName, "frommunname");
            routesMapper.AddDataColumnMap((r) => r.Routes[0].ForwardRoute.Paths[0].FromStation.RegionCode, "fromregioncode");

            routesMapper.AddDataColumnMap((r) => r.Routes[0].ForwardRoute.Paths[0].ToStation.Station, "tostation");
            routesMapper.AddDataColumnMap((r) => r.Routes[0].ForwardRoute.Paths[0].ToStation.StationType, "tosttype");
            routesMapper.AddDataColumnMap((r) => r.Routes[0].ForwardRoute.Paths[0].ToStation.CityCode, "tocitycode");
            routesMapper.AddDataColumnMap((r) => r.Routes[0].ForwardRoute.Paths[0].ToStation.CityName, "tocityname");
            routesMapper.AddDataColumnMap((r) => r.Routes[0].ForwardRoute.Paths[0].ToStation.MunicipalityCode, "tomuncode");
            routesMapper.AddDataColumnMap((r) => r.Routes[0].ForwardRoute.Paths[0].ToStation.MunicipalityName, "tomunname");
            routesMapper.AddDataColumnMap((r) => r.Routes[0].ForwardRoute.Paths[0].ToStation.RegionCode, "toregioncode");
            routesMapper.AddDataColumnMap((r) => r.Routes[0].ForwardRoute.Paths[0].DepartTime, "departtime");
            routesMapper.AddDataColumnMap((r) => r.Routes[0].ForwardRoute.Paths[0].ArriveTime, "arrivetime");
            routesMapper.AddDataColumnMap((r) => r.Routes[0].ForwardRoute.Paths[0].Rest, "rest", Conversions.ToTimeSpan);
            routesMapper.AddDataColumnMap((r) => r.Routes[0].ForwardRoute.Paths[0].Distance, "distance");
            routesMapper.AddDataColumnMap((r) => r.Routes[0].ForwardRoute.Paths[0].Speed, "speed");

            routesMapper.AddDataColumnMap((r) => r.Routes[0].BackwardRoute.Paths[0].Order, "order");
            routesMapper.AddDataColumnMap((r) => r.Routes[0].BackwardRoute.Paths[0].FromStation.Station, "fromstation");
            routesMapper.AddDataColumnMap((r) => r.Routes[0].BackwardRoute.Paths[0].FromStation.StationType, "fromsttype");
            routesMapper.AddDataColumnMap((r) => r.Routes[0].BackwardRoute.Paths[0].FromStation.CityCode, "fromcitycode");
            routesMapper.AddDataColumnMap((r) => r.Routes[0].BackwardRoute.Paths[0].FromStation.CityName, "fromcityname");
            routesMapper.AddDataColumnMap((r) => r.Routes[0].BackwardRoute.Paths[0].FromStation.MunicipalityCode, "frommuncode");
            routesMapper.AddDataColumnMap((r) => r.Routes[0].BackwardRoute.Paths[0].FromStation.MunicipalityName, "frommunname");
            routesMapper.AddDataColumnMap((r) => r.Routes[0].BackwardRoute.Paths[0].FromStation.RegionCode, "fromregioncode");

            routesMapper.AddDataColumnMap((r) => r.Routes[0].BackwardRoute.Paths[0].ToStation.Station, "tostation");
            routesMapper.AddDataColumnMap((r) => r.Routes[0].BackwardRoute.Paths[0].ToStation.StationType, "tosttype");
            routesMapper.AddDataColumnMap((r) => r.Routes[0].BackwardRoute.Paths[0].ToStation.CityCode, "tocitycode");
            routesMapper.AddDataColumnMap((r) => r.Routes[0].BackwardRoute.Paths[0].ToStation.CityName, "tocityname");
            routesMapper.AddDataColumnMap((r) => r.Routes[0].BackwardRoute.Paths[0].ToStation.MunicipalityCode, "tomuncode");
            routesMapper.AddDataColumnMap((r) => r.Routes[0].BackwardRoute.Paths[0].ToStation.MunicipalityName, "tomunname");
            routesMapper.AddDataColumnMap((r) => r.Routes[0].BackwardRoute.Paths[0].ToStation.RegionCode, "toregioncode");
            routesMapper.AddDataColumnMap((r) => r.Routes[0].BackwardRoute.Paths[0].DepartTime, "departtime");
            routesMapper.AddDataColumnMap((r) => r.Routes[0].BackwardRoute.Paths[0].ArriveTime, "arrivetime");
            routesMapper.AddDataColumnMap((r) => r.Routes[0].BackwardRoute.Paths[0].Rest, "rest", Conversions.ToTimeSpan);
            routesMapper.AddDataColumnMap((r) => r.Routes[0].BackwardRoute.Paths[0].Distance, "distance");
            routesMapper.AddDataColumnMap((r) => r.Routes[0].BackwardRoute.Paths[0].Speed, "speed");

            return routesMapper;
        }
        private static string _textFilterBackForMun = @"SELECT distinct l.id
	   from busroutes.lines l
	   join(
		    select distinct first.line_id
			from
				(select seq.line_id, 
					seq.direction,
					p.departure,	
					p.order,
					fmun.name
				from busroutes.path_sequences seq 
				join busroutes.paths p on seq.id = p.path_sequence_id
				join busroutes.station_points fsp on p.from_station_point_id = fsp.id
				join busroutes.stations fs on fsp.station_id = fs.id
				join public.n_cities fc on fc.code = fs.city_code 
				join public.n_muns fmun on fmun.code = fc.mun_code and fmun.region_code = fc.region_code
				where (upper(fmun.name) like '%' || upper(@pForwardMunicipality) || '%' 
				      or upper(fmun.name_lat) like '%' || upper(@pForwardMunicipality) || '%')
				      ) first
			  join
				( select seq.line_id, 
					seq.direction,
					p.departure,	
					p.order,
					fmun.name,
					p.to_station_point_id station_point_id
				from busroutes.path_sequences seq 
				join busroutes.paths p on seq.id = p.path_sequence_id
				join busroutes.station_points fsp on p.to_station_point_id = fsp.id
				join busroutes.stations fs on fsp.station_id = fs.id
				join public.n_cities fc on fc.code = fs.city_code 
				join public.n_muns fmun on fmun.code = fc.mun_code and fmun.region_code = fc.region_code
				where (upper(fmun.name) like '%' || upper(@pBackwardMunicipality) || '%' 
				      or upper(fmun.name_lat) like '%' || upper(@pBackwardMunicipality) || '%')
				     ) last
			   on first.line_id = last.line_id
			   and first.direction = last.direction
			   and first.order <= last.order
			   )f on f.line_id = l.id
	   where l.valid_to >= now();";

        private static string _textFilterBackForMunAndTime = @" SELECT distinct l.id
        from busroutes.lines l
	   join(
		    select distinct first.line_id
			from
				(select seq.line_id, 
					seq.direction,
					p.departure,	
					p.order,
					fmun.name
				from busroutes.path_sequences seq 
				join busroutes.paths p on seq.id = p.path_sequence_id
				join busroutes.station_points fsp on p.from_station_point_id = fsp.id
				join busroutes.stations fs on fsp.station_id = fs.id
				join public.n_cities fc on fc.code = fs.city_code 
				join public.n_muns fmun on fmun.code = fc.mun_code and fmun.region_code = fc.region_code
				where (upper(fmun.name) like '%' || upper(@pForwardMunicipality) || '%' 
				      or upper(fmun.name_lat) like '%' || upper(@pForwardMunicipality) || '%')
				      ) first
			  join
				( select seq.line_id, 
					seq.direction,
					p.departure,	
					p.order,
					fmun.name,
					p.to_station_point_id station_point_id
				from busroutes.path_sequences seq 
				join busroutes.paths p on seq.id = p.path_sequence_id
				join busroutes.station_points fsp on p.to_station_point_id = fsp.id
				join busroutes.stations fs on fsp.station_id = fs.id
				join public.n_cities fc on fc.code = fs.city_code 
				join public.n_muns fmun on fmun.code = fc.mun_code and fmun.region_code = fc.region_code
				where (upper(fmun.name) like '%' || upper(@pBackwardMunicipality) || '%' 
				      or upper(fmun.name_lat) like '%' || upper(@pBackwardMunicipality) || '%')
				     ) last
			   on first.line_id = last.line_id
			   and first.direction = last.direction
			   and first.order <= last.order
			join
				( select seq.line_id, 
					seq.direction,
					p.departure,	
					p.order,
					p.from_station_point_id
				from busroutes.path_sequences seq 
				join busroutes.paths p on seq.id = p.path_sequence_id
				     ) oposite
				 on last.line_id = oposite.line_id
				 and last.direction != oposite.direction
				 and last.station_point_id = oposite.from_station_point_id
			  where (@pForwardTime is null or first.departure between @pForwardTime - interval '1 hour' and @pForwardTime + interval '1 hour')
			    and (@pBackwardTime is null or oposite.departure between @pBackwardTime - interval '1 hour' and @pBackwardTime + interval '1 hour')
	       ) f on f.line_id = l.id
	   where l.valid_to >= now();";

        private static string _textFilterSeasonalTrue = @"SELECT ID
	    FROM
		   (SELECT DISTINCT l.id as id
		    FROM busroutes.""Lines_info"" l
		    where  l.id = ANY(@id_list)
			and (@pSeasonStartDate is null or 
				@pSeasonStartDate <=  --seasonenddate
					 CASE
						 WHEN to_date('2001-' --seasonenddate
								||l.seasonEndMonth
								|| '-' || l.seasonEndDay, 
								'YYYY-mm-dd') 
							< to_date('2001-' --seasonstartdate
									|| l.seasonStartMonth
									|| '-' || l.seasonStartDay, 'YYYY-mm-dd')
						THEN
						  to_date('2002-' --seasonenddate
								||l.seasonEndMonth
								|| '-' || l.seasonEndDay,  'YYYY-mm-dd')
						 ELSE
						  to_date('2001-' --seasonenddate
								||l.seasonEndMonth
								|| '-' || l.seasonEndDay,  'YYYY-mm-dd')
					       END
			    )
			and (@pSeasonEndDate is null 
				or @pSeasonEndDate >=  --seasonstartdate
							to_date('2001-' --seasonstartdate
								|| l.seasonStartMonth
									|| '-' || l.seasonStartDay, 'YYYY-mm-dd')) 
		) t;";

        private static string _textFilterSeasonalFalse = @"SELECT l.ID
         FROM busroutes.""Lines_info"" l
         WHERE l.ID = ANY(@id_list)
	    and l.seasonStartMonth is null and l.seasonStartDay is null 
	    and l.seasonEndMonth is null and l.seasonEndDay is null  
		;";

        private static string _textFilterHoliday = @"SELECT l.ID
         FROM busroutes.""Lines_info"" l
         WHERE l.ID = ANY(@id_list)
	      and (@pBeforeHoliday is null or @pBeforeHoliday = l.BeforeHoliday)
              and (@pHoliday is null or @pHoliday = l.Holiday)
	    ;";

        private static string _textFilterDailyFalse = @"SELECT ID 
	    FROM (
		   SELECT DISTINCT l.id ID
		    FROM busroutes.""Lines_info"" l
		    WHERE l.ID = ANY(@id_list)
		    and (@pMonday is null or @pMonday = false or (@pMonday= true and l.Monday = true))
		    and (@pTuesday is null or @pTuesday = false or (@pTuesday = true and l.Tuesday = true))
		    and (@pWednesday is null or @pWednesday = false or (@pWednesday = true and l.Wednesday = true))
		    and (@pThursday is null or @pThursday = false or (@pThursday = true and l.Thursday = true))
		    and (@pFriday is null or @pFriday = false or (@pFriday = true and l.Friday = true))
		    and (@pSaturday is null or @pSaturday = false or (@pSaturday = true and l.Saturday = true))
		    and (@pSunday is null or @pSunday = false or (@pSunday = true and l.Sunday = true))) t;";

        private static string _textFilterDailyTrue = @"SELECT l.ID
                 FROM busroutes.""Lines_info"" l
                 WHERE l.ID = ANY(@id_list)
	            and l.Monday is null 
	            and l.Tuesday is null 
	            and l.Wednesday is null 
	            and l.Thursday is null 
	            and l.Friday is null 
	            and l.Saturday is null  
	            and l.Sunday is null  
	            ;";

        private static string command1 = @"DO $$DECLARE
      linesRefcursor refcursor  := 'Lines'; 
      pathsRefcursor refcursor  := 'Paths'; 
        _pforwardmunicipality text := @pforwardmunicipality; 
        _pbackwardmunicipality text:= @pbackwardmunicipality; 
        _pisseasonal boolean:= @pisseasonal;
        _pseasonstartdate date:= @pseasonstartdate; 
        _pseasonenddate date:= @pseasonenddate;
        _pisdaily boolean:= @pisdaily;
        _pmonday boolean:= @pmonday;
        _ptuesday boolean:= @ptuesday; 
        _pwednesday boolean:= @pwednesday; 
        _pthursday boolean:= @pthursday; 
        _pfriday boolean:= @pfriday; 
        _psaturday boolean:= @psaturday; 
        _psunday boolean:= @psunday; 
        _pbeforeholiday boolean:= @pbeforeholiday; 
        _pholiday boolean:= @pholiday; 
        _pforwardtime time without time zone:= @pforwardtime;
         _pbackwardtime time without time zone:= @pbackwardtime;

BEGIN

--Реализация на филтър по Начална и Крайна спирка, който да се съобразява и с филтъра за време на тръгване и пристигане(ако е подаден такъв)
   CREATE TEMP TABLE temp_REGIX_lines_filter ON COMMIT DROP AS
	--insert into temp_REGIX_lines_filter
	 SELECT distinct l.id 
	   from busroutes.lines l
	   join(
		    select distinct first.line_id
			from
				(select seq.line_id, 
					seq.direction,
					p.departure,	
					p.order,
					fmun.name
				from busroutes.path_sequences seq 
				join busroutes.paths p on seq.id = p.path_sequence_id
				join busroutes.station_points fsp on p.from_station_point_id = fsp.id
				join busroutes.stations fs on fsp.station_id = fs.id
				join public.n_cities fc on fc.code = fs.city_code 
				join public.n_muns fmun on fmun.code = fc.mun_code and fmun.region_code = fc.region_code
				where (upper(fmun.name) like '%' || upper(_pForwardMunicipality) || '%' 
				      or upper(fmun.name_lat) like '%' || upper(_pForwardMunicipality) || '%')
				      ) first
			  join
				( select seq.line_id, 
					seq.direction,
					p.departure,	
					p.order,
					fmun.name,
					p.to_station_point_id station_point_id
				from busroutes.path_sequences seq 
				join busroutes.paths p on seq.id = p.path_sequence_id
				join busroutes.station_points fsp on p.to_station_point_id = fsp.id
				join busroutes.stations fs on fsp.station_id = fs.id
				join public.n_cities fc on fc.code = fs.city_code 
				join public.n_muns fmun on fmun.code = fc.mun_code and fmun.region_code = fc.region_code
				where (upper(fmun.name) like '%' || upper(_pBackwardMunicipality) || '%' 
				      or upper(fmun.name_lat) like '%' || upper(_pBackwardMunicipality) || '%')
				     ) last
			   on first.line_id = last.line_id
			   and first.direction = last.direction
			   and first.order <= last.order
			join
				( select seq.line_id, 
					seq.direction,
					p.departure,	
					p.order,
					p.from_station_point_id
				from busroutes.path_sequences seq 
				join busroutes.paths p on seq.id = p.path_sequence_id
				     ) oposite
				 on last.line_id = oposite.line_id
				 and last.direction != oposite.direction
				 and last.station_point_id = oposite.from_station_point_id
			  where (_pForwardTime is null or first.departure between _pForwardTime - interval '1 hour' and _pForwardTime + interval '1 hour')
			    and (_pBackwardTime is null or oposite.departure between _pBackwardTime - interval '1 hour' and _pBackwardTime + interval '1 hour')
	       ) f on f.line_id = l.id
	   where l.valid_to >= now();

---Ако има критерии за сезонност, тогава от вече намерените записи по община на нач. и крайна спирка, се премахват тези които не отговарят на критериите за сезонност. 
IF _pIsSeasonal is not null or _pSeasonStartDate is not null or _pSeasonEndDate is not null
THEN
 DELETE 
   FROM temp_REGIX_lines_filter
   WHERE _pIsSeasonal is null
	or 
	( _pIsSeasonal = true 
         and NOT EXISTS(
		   SELECT 1
		    FROM busroutes.time_constraints date_constr
		    where date_constr.constraint_type::text = 'date'::text
			and temp_REGIX_lines_filter.id = date_constr.line_id
			and (_pSeasonStartDate is null or 
				_pSeasonStartDate <=  --seasonenddate
					 CASE
						 WHEN to_date('2001-' --seasonenddate
								|| date_part('month'::text, to_date(substring(date_constr.constraint_param::text, 12, 10), 'dd.mm.yyyy'::text)) 
								|| '-' || date_part('day'::text, to_date(substring(date_constr.constraint_param::text, 12, 10), 'dd.mm.yyyy'::text)), 
								'YYYY-mm-dd') 
							< to_date('2001-' --seasonstartdate
									|| date_part('month'::text, to_date(substring(date_constr.constraint_param::text, 1, 10), 'dd.mm.yyyy'::text)) 
									|| '-' || date_part('day'::text, to_date(substring(date_constr.constraint_param::text, 1, 10), 'dd.mm.yyyy'::text)), 'YYYY-mm-dd')
						THEN
						  to_date('2002-' --seasonenddate
								|| date_part('month'::text, to_date(substring(date_constr.constraint_param::text, 12, 10), 'dd.mm.yyyy'::text)) 
								|| '-' || date_part('day'::text, to_date(substring(date_constr.constraint_param::text, 12, 10), 'dd.mm.yyyy'::text)), 'YYYY-mm-dd')
						 ELSE
						  to_date('2001-' --seasonenddate
								|| date_part('month'::text, to_date(substring(date_constr.constraint_param::text, 12, 10), 'dd.mm.yyyy'::text)) 
								|| '-' || date_part('day'::text, to_date(substring(date_constr.constraint_param::text, 12, 10), 'dd.mm.yyyy'::text)), 'YYYY-mm-dd')
					       END
			    )
			and (_pSeasonEndDate is null 
				or _pSeasonEndDate >=  --seasonstartdate
							to_date('2001-' --seasonstartdate
								|| date_part('month'::text, to_date(substring(date_constr.constraint_param::text, 1, 10), 'dd.mm.yyyy'::text)) 
								|| '-' || date_part('day'::text, to_date(substring(date_constr.constraint_param::text, 1, 10), 'dd.mm.yyyy'::text)), 'YYYY-mm-dd')) 
			)
          )			
	or 
	( _pIsSeasonal = false and EXISTS(
	   SELECT 1
	    FROM busroutes.time_constraints date_constr
	    where date_constr.constraint_type::text = 'date'::text
		and temp_REGIX_lines_filter.id = date_constr.line_id)
	);
 END IF;

---Ако има критерии за празници, тогава от вече намерените записи по община на нач. и крайна спирка, се премахват тези които не отговарят на критериите за празници. 
IF (_pBeforeHoliday is not null OR _pHoliday is not null)
THEN
 DELETE 
   FROM temp_REGIX_lines_filter
   WHERE  NOT EXISTS(
		   SELECT 1
		    FROM busroutes.time_constraints holi_constr
		    where  holi_constr.constraint_type::text = 'holiday'::text
			AND  temp_REGIX_lines_filter.id = holi_constr.line_id
			AND (_pBeforeHoliday  is null
			    or _pBeforeHoliday = false and substring(holi_constr.constraint_param::text, 1, 1) = '0'::text --beforeholiday
			    or _pBeforeHoliday = true and substring(holi_constr.constraint_param::text, 1, 1) = '1'::text)
			AND (_pHoliday  is null
			    or _pHoliday = false and substring(holi_constr.constraint_param::text, 3, 1) = '0'::text --holiday
			    or _pHoliday = true and substring(holi_constr.constraint_param::text, 3, 1) = '1'::text)
			);

END IF;

---Ако има критерии за ограничения по дни, тогава от вече намерените записи по община на нач. и крайна спирка, се премахват тези които не отговарят на критериите. 
IF  _pIsDaily IS NOT NULL or _pMonday IS NOT NULL OR _pTuesday IS NOT NULL OR _pWednesday IS NOT NULL OR _pThursday IS NOT NULL OR _pFriday IS NOT NULL OR _pSaturday IS NOT NULL OR _pSunday IS NOT NULL
THEN

DELETE 
   FROM temp_REGIX_lines_filter
   WHERE ( (_pIsDaily = false or _pIsDaily is null)
         and NOT EXISTS(
		   SELECT 1
		    FROM busroutes.time_constraints week_constr
		    where week_constr.constraint_type::text = 'week'::text
			and temp_REGIX_lines_filter.id = week_constr.line_id
			and (_pMonday is null or _pMonday = case when substring(week_constr.constraint_param::text, 1, 1) = '0'::text then false else true end )
			and (_pTuesday is null or _pTuesday = case when substring(week_constr.constraint_param::text, 3, 1) = '0'::text then false else true end )
			and (_pWednesday is null or _pWednesday = case when substring(week_constr.constraint_param::text, 5, 1) = '0'::text then false else true end )
			and (_pThursday is null or _pThursday = case when substring(week_constr.constraint_param::text, 7, 1) = '0'::text then false else true end )
			and (_pFriday is null or _pFriday = case when substring(week_constr.constraint_param::text, 9, 1) = '0'::text then false else true end )
			and (_pSaturday is null or _pSaturday = case when substring(week_constr.constraint_param::text, 11, 1) = '0'::text then false else true end )
			and (_pSunday is null or _pSunday = case when substring(week_constr.constraint_param::text, 13, 1) = '0'::text then false else true end )
			)
          )			
	or 
	( _pIsDaily = true and EXISTS(
	   SELECT 1
	    FROM busroutes.time_constraints week_constr
	    where week_constr.constraint_type::text = 'week'::text
		and temp_REGIX_lines_filter.id = week_constr.line_id)
	);

END IF;
END$$;";

        private static string commandTextMasterTable = @"  SELECT l.number AS routecode, 
	l.name AS routename, 
	l.description AS routedescrtiption, 
	l.drivers AS driverscount, 
	l.buses AS busescount, 
	l.valid_from AS approvaldate, 
	m.name AS contractorname, 
	m.code as contractorcode,
	l.region_code as regioncode,

	li.seasonal, 
	li.seasonstartday, 
	li.seasonstartmonth, 
	li.seasonendday, 	
	li.seasonendmonth, 
	li.isdaily, 
	li.monday, 
	li.tuesday, 
	li.wednesday, 
	li.thursday, 
	li.friday, 
	li.saturday, 
	li.sunday, 
	li.beforeholiday, 
	li.holiday, 
	
	forward_path.distance AS fdistance, 
	forward_path.traveltime AS ftraveltime, 
	forward_path.triptime AS ftriptime, 
	forward_path.travelspeed AS ftravelspeed, 
	forward_path.tripspeed AS ftripspeed, 
	backward_path.distance AS bdistance, 
	backward_path.traveltime AS btraveltime, 
	backward_path.triptime AS btriptime, 
	backward_path.travelspeed AS btravelspeed, 
	backward_path.tripspeed AS btripspeed, 
	
	l.id, 
	forward_path.departure AS fdeparture, 
	backward_path.departure AS bdeparture,
	l.valid_to as validto
  FROM busroutes.lines l 
  left join busroutes.""Lines_info"" li on li.id = l.id
  left JOIN n_muns m ON m.code::text = l.mun_code::text AND m.region_code::text = l.region_code::text
LEFT JOIN ( SELECT t.line_id, 
			t.distance, 
			t.departure, 
			t.totaltime AS traveltime, 
			CASE WHEN t.arrival >= t.departure THEN t.arrival - t.departure ELSE t.arrival - t.departure + '24:00:00'::interval END AS triptime, 
			CASE WHEN t.time = 0::double precision THEN 0::numeric ELSE round((t.distance / t.time)::numeric, 1) END AS travelspeed, 
			CASE WHEN t.arrival = t.departure THEN 0::numeric 
				 ELSE round((t.distance / (date_part('day'::text,  CASE WHEN t.arrival >= t.departure THEN t.arrival - t.departure ELSE t.arrival - t.departure + '24:00:00'::interval END) * 24::double precision 
							+ date_part('hour'::text,  CASE WHEN t.arrival >= t.departure THEN t.arrival - t.departure ELSE t.arrival - t.departure + '24:00:00'::interval END) 
							+ date_part('minute'::text, CASE WHEN t.arrival >= t.departure THEN t.arrival - t.departure ELSE t.arrival - t.departure + '24:00:00'::interval END) / 60::double precision)
							)::numeric, 1) END AS tripspeed
		  FROM ( SELECT seq.line_id, 
				 sum(p.length) AS distance, 
				max(p.f_dep) AS departure, 
				max(p.l_arr) AS arrival, 
				sum(CASE WHEN p.arrival >= p.departure THEN p.arrival - p.departure ELSE p.arrival - p.departure + '24:00:00'::interval END) AS totaltime, 
				sum(date_part('day'::text, CASE WHEN p.arrival >= p.departure THEN p.arrival - p.departure ELSE p.arrival - p.departure + '24:00:00'::interval END) * 24::double precision 
					+ date_part('hour'::text, CASE WHEN p.arrival >= p.departure THEN p.arrival - p.departure ELSE p.arrival - p.departure + '24:00:00'::interval END) 
					+ date_part('minute'::text, CASE WHEN p.arrival >= p.departure THEN p.arrival - p.departure ELSE p.arrival - p.departure + '24:00:00'::interval END) / 60::double precision
				) AS time
			FROM ( SELECT path.id, 
					--path.from_station_id, 
					--path.to_station_id, 
					path.length, 
					path.max_speed, 
					path.order, 
					path.arrival, 
					path.departure, 
					path.path_sequence_id, 
					first_value(path.departure) OVER (PARTITION BY path.path_sequence_id ORDER BY path.order) AS f_dep, 
					first_value(path.arrival) OVER (PARTITION BY path.path_sequence_id ORDER BY path.order DESC) AS l_arr
                            FROM busroutes.paths path) p
		  JOIN busroutes.path_sequences seq ON seq.id = p.path_sequence_id
		 WHERE seq.line_id = ANY(@id_list) and seq.direction::text = 'forward'::text
		 GROUP BY seq.line_id) t) forward_path ON forward_path.line_id = l.id
   LEFT JOIN ( SELECT 
			t.line_id, 
			t.departure, 
			t.distance, 
			t.totaltime AS traveltime, 
			CASE WHEN t.arrival >= t.departure THEN t.arrival - t.departure ELSE t.arrival - t.departure + '24:00:00'::interval END AS triptime, 
			CASE WHEN t.time = 0::double precision THEN 0::numeric ELSE round((t.distance / t.time)::numeric, 1) END AS travelspeed, 
			CASE WHEN t.arrival = t.departure THEN 0::numeric 
			 ELSE round((t.distance / (date_part('day'::text,  CASE WHEN t.arrival >= t.departure THEN t.arrival - t.departure ELSE t.arrival - t.departure + '24:00:00'::interval END) * 24::double precision 
										+ date_part('hour'::text, CASE WHEN t.arrival >= t.departure THEN t.arrival - t.departure ELSE t.arrival - t.departure + '24:00:00'::interval END) 
										+ date_part('minute'::text, CASE WHEN t.arrival >= t.departure THEN t.arrival - t.departure ELSE t.arrival - t.departure + '24:00:00'::interval END) / 60::double precision
									   ))::numeric, 1) END AS tripspeed
		FROM ( SELECT seq.line_id, 
				sum(p.length) AS distance, 
				max(p.f_dep) AS departure, 
				max(p.l_arr) AS arrival, 
				sum( CASE WHEN p.arrival >= p.departure THEN p.arrival - p.departure ELSE p.arrival - p.departure + '24:00:00'::interval END) AS totaltime, 
				sum(date_part('day'::text, CASE WHEN p.arrival >= p.departure THEN p.arrival - p.departure ELSE p.arrival - p.departure + '24:00:00'::interval END) * 24::double precision 
					+ date_part('hour'::text, CASE WHEN p.arrival >= p.departure THEN p.arrival - p.departure ELSE p.arrival - p.departure + '24:00:00'::interval END) 
					+ date_part('minute'::text, CASE WHEN p.arrival >= p.departure THEN p.arrival - p.departure ELSE p.arrival - p.departure + '24:00:00'::interval END) / 60::double precision
					) AS time
			   FROM ( SELECT path.id, 
					--path.from_station_id, 
					--path.to_station_id, 
					path.length, 
					path.max_speed, 
					path.order, 
					path.arrival, 
					path.departure, 
					path.path_sequence_id, 
					first_value(path.departure) OVER (PARTITION BY path.path_sequence_id ORDER BY path.order) AS f_dep, 
					first_value(path.arrival) OVER (PARTITION BY path.path_sequence_id ORDER BY path.order DESC) AS l_arr
				   FROM busroutes.paths path) p
		      JOIN busroutes.path_sequences seq ON seq.id = p.path_sequence_id
		     WHERE seq.direction::text = 'backward'::text and seq.line_id = ANY(@id_list)
		     GROUP BY seq.line_id
		  ) t) backward_path ON backward_path.line_id = l.id
WHERE l.id = ANY(@id_list)		  
order by routename, routecode
;";
        private static string commandTextDetail = @"SELECT t.line_id, 
	t.order, 
	t.direction, 
	t.fromstation, 
	t.tostation, 
	t.departtime, 
	t.arrivetime, 
	t.rest, 
	t.distance, 
        CASE
            WHEN (date_part('day'::text, t.time) * 24::double precision + date_part('hour'::text, t.time) + date_part('minute'::text, t.time) / 60::double precision) = 0::double precision THEN 0::numeric
            ELSE round((t.distance / (date_part('day'::text, t.time) * 24::double precision + date_part('hour'::text, t.time) + date_part('minute'::text, t.time) / 60::double precision))::numeric, 1)
        END AS speed,
        fromcityname,
	fromcitycode,
	tocityname,
	tocitycode,
	frommunname,
	frommuncode,
	tomunname,
	tomuncode,
	null::text fromsttype,
	null::text tosttype,
	fromregioncode,
	toregioncode
   FROM ( SELECT from_st.name AS fromstation, 
		 to_st.name AS tostation, 
		p.arrival AS arrivetime, 
		p.departure AS departtime, 
                CASE
                    WHEN lead(p.departure, 1, NULL::time without time zone) OVER (PARTITION BY p.path_sequence_id ORDER BY p.order) >= p.arrival THEN lead(p.departure, 1, NULL::time without time zone) OVER (PARTITION BY p.path_sequence_id ORDER BY p.order) - p.arrival
                    ELSE lead(p.departure, 1, NULL::time without time zone) OVER (PARTITION BY p.path_sequence_id ORDER BY p.order) - p.arrival + '24:00:00'::interval
                END AS rest, 
		p.length AS distance, 
                CASE
                    WHEN p.arrival >= p.departure THEN p.arrival - p.departure
                    ELSE p.arrival - p.departure + '24:00:00'::interval
                END AS time, 
		seq.line_id, 
		p.order, 
		seq.direction,
		from_city.name fromcityname,
		from_city.code fromcitycode,
		to_city.name tocityname,
		to_city.code tocitycode,
		from_mun.name frommunname,
		from_mun.code frommuncode,
		to_mun.name tomunname,
		to_mun.code tomuncode,
		--from_st_type.description fromsttype,
		--to_st_type.description tosttype,
		from_mun.region_code fromregioncode,
		to_mun.region_code toregioncode
        FROM busroutes.paths p
	JOIN busroutes.path_sequences seq ON seq.id = p.path_sequence_id
	LEFT JOIN busroutes.station_points from_stp ON from_stp.id = p.from_station_point_id
	LEFT JOIN busroutes.station_points to_stp ON to_stp.id = p.to_station_point_id
	LEFT JOIN busroutes.stations from_st ON from_st.id = from_stp.station_id
	LEFT JOIN busroutes.stations to_st ON to_st.id = to_stp.station_id
	LEFT JOIN n_cities from_city ON from_st.city_code = from_city.code
	LEFT JOIN n_cities to_city ON to_st.city_code = to_city.code
	LEFT JOIN n_muns from_mun ON from_city.mun_code = from_mun.code and from_city.region_code = from_mun.region_code
	LEFT JOIN n_muns to_mun ON to_city.mun_code = to_mun.code and to_city.region_code = to_mun.region_code
	--LEFT JOIN busroutes.n_station_type from_st_type ON from_st.type = from_st_type.id
	--LEFT JOIN busroutes.n_station_type to_st_type ON to_st.type = to_st_type.id
  WHERE seq.line_id = ANY(@id_list) -- Прилагане на филтъра
	) t;";
    }
}
