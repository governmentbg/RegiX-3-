using System;
using System.Linq;
using System.Data;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.Common.Utils;
using System.ComponentModel.Composition;
using IBM.Data.Informix;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.InformixAdapterService;
using TechnoLogica.RegiX.GraoCommon;
using TechnoLogica.RegiX.Adapters.Common.DataContracts;
using TechnoLogica.RegiX.Common.DataContracts.Parameter;
using TechnoLogica.RegiX.Adapters.Common.ObjectMapping;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;

namespace TechnoLogica.RegiX.GraoBRAdapter.AdapterService
{
    [Export(typeof(IAdapterService))]
    [ExportFullName(typeof(BRAdapter), typeof(IAdapterService))]
    [ExportSimpleName(typeof(BRAdapter), typeof(IAdapterService))]
    public class BRAdapter : InformixBaseAdapterService, IBRAdapter, IAdapterService
    {
        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(BRAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> ConnectionString =
            new ParameterInfo<string>("Database=grao;Host=;Server=;Service=25852;Protocol=onsoctcp;UID=informix;Password=;DB_LOCALE=en_US.57372")
            {
                Key = Constants.ConnectionStringParameterKeyName,
                Description = "Connection string for Informix",
                OwnerAssembly = typeof(BRAdapter).Assembly
            };

        public CommonSignedResponse<MaritalStatusRequestType, MaritalStatusResponseType> MaritalStatusSearch(MaritalStatusRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.XmlSerialize(), Guid = id });
            try
            {
                IfxConnection connection = new IfxConnection(ConnectionString.Value);
                IfxCommand command = new IfxCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = @"select trim(t.sp) as sp,
											   trim(gp.imes) as imes,
											   trim(gp.imeb) as imeb,
											   trim(gp.imef) as imef,
											   trim(gp.egn) as egn,
                                               trim(gp.pol) as pol,
                                               case when gp.pol='1' then trim(t.sp) 
                                                    when gp.pol='2' then trim(t.sp) ||'0' end as sp_code
											  from regix_getmarital t 
											  join regix_getperson as gp
											  on t.vegn = gp.vegn
                                     where t.vegn = ?";
                command.Parameters.Add("vegn", Utils.EGNtoVEGN(argument.EGN));
                IfxDataAdapter da = new IfxDataAdapter(command);
                DataSet ds = new DataSet();
                ds.Tables.Add("MaritalStatus");
                try
                {
                    connection.Open();
                    da.Fill(ds.Tables["MaritalStatus"]);
                }
                finally
                {
                    connection.Close();
                }

                DataSetMapper<MaritalStatusResponseType> maritalStatusMapper = CreateMaritalStatusMap(accessMatrix);
                var maritalStatusConstMapper = CreateMartialStatusConstMap(accessMatrix, DateTime.Now);

                MaritalStatusResponseType result = new MaritalStatusResponseType();

                maritalStatusConstMapper.Map(result, result);
                maritalStatusMapper.Map(ds, result);
                LogWarn(Utils.GetLogMessageForSuccessOperation(argument.EGN, aditionalParameters));
                return SigningUtils.CreateAndSign(
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

        private static DataSetMapper<MaritalStatusResponseType> CreateMaritalStatusMap(AccessMatrix accessMatrix)
        {
            DataSetMapper<MaritalStatusResponseType> maritalStatusMapper = new DataSetMapper<MaritalStatusResponseType>(accessMatrix);
            maritalStatusMapper.AddDataSetObjectInitializer((ds) => (ds.Tables["MaritalStatus"].Rows.Count == 1) ? ds.Tables["MaritalStatus"].Rows[0] : null);

            //maritalStatusMapper.AddConstantMap(f => f.ReportDate, reportDate);
            maritalStatusMapper.AddDataColumnMap((f) => f.MaritalStatusCode, "sp");
            maritalStatusMapper.AddDataColumnMap((f) => f.MaritalStatusName, "sp_code", Utils.ToMaritalStatusText);
            maritalStatusMapper.AddDataColumnMap((f) => f.FirstName, "imes");
            maritalStatusMapper.AddDataColumnMap((f) => f.MiddleName, "imeb");
            maritalStatusMapper.AddDataColumnMap((f) => f.LastName, "imef");
            maritalStatusMapper.AddDataColumnMap((f) => f.EGN, "egn");
            maritalStatusMapper.AddDataColumnMap((f) => f.Gender, "pol");
            return maritalStatusMapper;
        }

        private ObjectMapper<MaritalStatusResponseType, MaritalStatusResponseType> CreateMartialStatusConstMap(AccessMatrix accessMatrix, DateTime reportDate)
        {
            var mapper = new ObjectMapper<MaritalStatusResponseType, MaritalStatusResponseType>(accessMatrix);

            mapper.AddConstantMap((r) => r.ReportDate, reportDate);

            return mapper;
        }

        private ObjectMapper<MaritalStatusSpouseChildrenResponseType, MaritalStatusSpouseChildrenResponseType> CreateMartialStatusSpouseChildrenConstMap(AccessMatrix accessMatrix, DateTime reportDate)
        {
            var mapper = new ObjectMapper<MaritalStatusSpouseChildrenResponseType, MaritalStatusSpouseChildrenResponseType>(accessMatrix);

            mapper.AddConstantMap((r) => r.ReportDate, reportDate);

            return mapper;
        }

        public CommonSignedResponse<SpouseRequestType, SpouseResponseType> SpouseSearch(SpouseRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.XmlSerialize(), Guid = id });
            try
            {

                IfxConnection connection = new IfxConnection(ConnectionString.Value);
                IfxCommand command = new IfxCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = @"select --trim(vegn) tvegn, 
                                            trim(egns) egns, 
                                            trim(imes) imes, 
                                            trim(imeb) imeb, 
                                            trim(imef) imef, 
                                            dsm as dsm, 
                                            trim(pol) pol, 
                                            trim(gr) gr, 
                                            trim(gr_ime) gr_ime, 
                                            trim(gr2) gr2, 
                                            trim(gr2_ime) gr2_ime
                                       from regix_getspouse 
                                      where vegn = ?
                                     union all
                                        select --null::char(10) tvegn,
                                               trim(rodegn) as egns, 
                                               trim(imes) imes, 
                                               trim(imeb) imeb, 
                                               trim(imef) imef, 
                                               case when trim(dsm) = '' or trim(dsm) is null then null::date
                                                    else date(to_date(trim(dsm), '%d.%m.%Y')) end dsm, 
                                               trim(pol) pol,
                                               regix_getrod.gr, 
                                               regix_getrod.gr_ime, 
                                               regix_getrod.gr2, 
                                               regix_getrod.gr2_ime
                                          from regix_getrod
                                         where egn = ? 
                                           and rodvr = 'СЪ' 
                                    ";
                command.Parameters.Add("vegn", Utils.EGNtoVEGN(argument.EGN));
                command.Parameters.Add("egn", argument.EGN);
                IfxDataAdapter da = new IfxDataAdapter(command);
                DataSet ds = new DataSet();
                ds.Tables.Add("Spouse");
                try
                {
                    connection.Open();
                    da.Fill(ds.Tables["Spouse"]);
                }
                finally
                {
                    connection.Close();
                }
                DataSetMapper<SpouseResponseType> spouseMapper = CreateSpouseMap(accessMatrix);
                SpouseResponseType result = new SpouseResponseType();
                spouseMapper.Map(ds, result);
                LogWarn(Utils.GetLogMessageForSuccessOperation(argument.EGN, aditionalParameters));
                return SigningUtils.CreateAndSign(
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

        /// <summary>
        /// Конверсия от число към пол
        /// </summary>
        public static Func<object, object> ToGenderNameType = (o) =>
        {
            GenderNameType result;
            if (Enum.TryParse(Utils.ToGenderNameType(o), out result))
            {
                return result;
            }
            else
            {
                return o;
            }
        };

        private static DataSetMapper<SpouseResponseType> CreateSpouseMap(AccessMatrix accessMatrix)
        {
            DataSetMapper<SpouseResponseType> spouseMapper = new DataSetMapper<SpouseResponseType>(accessMatrix);
            spouseMapper.AddDataSetObjectInitializer((ds) => (ds.Tables["Spouse"].Rows.Count == 1) ? ds.Tables["Spouse"].Rows[0] : null);
            spouseMapper.AddDataColumnMap((f) => f.EGN, "egns");
            spouseMapper.AddDataColumnMap((f) => f.FirstName, "imes");
            spouseMapper.AddDataColumnMap((f) => f.SurName, "imeb");
            spouseMapper.AddDataColumnMap((f) => f.FamilyName, "imef");
            spouseMapper.AddDataColumnMap((f) => f.BirthDate, "egns", Conversions.EGNtoBirthDate);
            spouseMapper.AddDataColumnMap((f) => f.DeathDate, "dsm");
            spouseMapper.AddDataColumnMap((f) => f.GenderCode, "pol");
            spouseMapper.AddDataColumnMap((f) => f.GenderName, "pol", ToGenderNameType);
            spouseMapper.AddDataColumnMap((f) => f.NationalityCode, "gr");
            spouseMapper.AddDataColumnMap((f) => f.NationalityName, "gr_ime");
            spouseMapper.AddDataColumnMap((f) => f.SecondNationalityCode, "gr2");
            spouseMapper.AddDataColumnMap((f) => f.SecondNationalityName, "gr2_ime");
            return spouseMapper;
        }

        public CommonSignedResponse<MarriageRequestType, MarriageResponseType> MarriageSearch(MarriageRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.XmlSerialize(), Guid = id });
            try
            {

                IfxConnection connection = new IfxConnection(ConnectionString.Value);
                IfxCommand command = new IfxCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = @"select first 1 abrdata, 
                                                abrn, 
                                                brdata, 
                                                abrnm, 
                                                trim(nm_ime) nm_ime, 
                                                trim(brrdj) brrdj, 
                                                trim(gr_ime) gr_ime, 
                                                null::date devdata, 
                                                null::char devn 
                                       from regix_getmarriage 
                                      where egn = ? 
                                      order by brdata desc";
                command.Parameters.Add("egn", argument.EGN);
                IfxDataAdapter da = new IfxDataAdapter(command);
                DataSet ds = new DataSet();
                ds.Tables.Add("Marriage");
                try
                {
                    connection.Open();
                    da.Fill(ds.Tables["Marriage"]);
                    if (ds.Tables["Marriage"].Rows.Count == 1)
                    {
                        DateTime marriageDate = Convert.ToDateTime(ds.Tables["Marriage"].Rows[0]["brdata"]);
                        IfxCommand commandDevorce = new IfxCommand();
                        commandDevorce.Connection = connection;
                        commandDevorce.CommandType = System.Data.CommandType.Text;
                        commandDevorce.CommandText = @"select first 1 dev_date, trim(dev_nom) dev_nom
                                                    from regix_getdivorce 
                                                   where egn = ? and dev_date >= ? 
                                                    order by dev_date desc";
                        commandDevorce.Parameters.Add("egn", argument.EGN);
                        commandDevorce.Parameters.Add("marriageDate", marriageDate);
                        IfxDataAdapter daDevorce = new IfxDataAdapter(commandDevorce);
                        DataSet dsDevorce = new DataSet();
                        dsDevorce.Tables.Add("Devorce");
                        daDevorce.Fill(dsDevorce.Tables["Devorce"]);
                        if (dsDevorce.Tables["Devorce"].Rows.Count == 1)
                        {
                            ds.Tables["Marriage"].Rows[0]["devdata"] = dsDevorce.Tables["Devorce"].Rows[0]["dev_date"];
                            ds.Tables["Marriage"].Rows[0]["devn"] = dsDevorce.Tables["Devorce"].Rows[0]["dev_nom"];
                        }
                    }
                    else
                    {
                        IfxCommand commandDevorce = new IfxCommand();
                        commandDevorce.Connection = connection;
                        commandDevorce.CommandType = System.Data.CommandType.Text;
                        commandDevorce.CommandText = @"select first 1 
                                                                dev_date as devdata,
                                                                trim(dev_nom) as devn,
                                                                trim(brak_nom) as abrn,
                                                                brak_akt_date as abrdata,
                                                                brak_date as brdata,
                                                                trim(brak_place_code) as abrnm,
                                                                trim(brak_place) as nm_ime
                                                            from regix_getdivorce 
                                                           where egn = ? 
                                                            order by dev_date desc";
                        commandDevorce.Parameters.Add("egn", argument.EGN);
                        IfxDataAdapter daDevorce = new IfxDataAdapter(commandDevorce);
                        daDevorce.Fill(ds.Tables["Marriage"]);
                    }
                }
                finally
                {
                    connection.Close();
                }
                DataSetMapper<MarriageResponseType> marriageMapper = CreateMarriageMap(accessMatrix);
                MarriageResponseType result = new MarriageResponseType();
                marriageMapper.Map(ds, result);
                
                LogWarn(Utils.GetLogMessageForSuccessOperation(argument.EGN, aditionalParameters));

                return SigningUtils.CreateAndSign(
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

        private static DataSetMapper<MarriageResponseType> CreateMarriageMap(AccessMatrix accessMatrix)
        {
            DataSetMapper<MarriageResponseType> mapper = new DataSetMapper<MarriageResponseType>(accessMatrix);
            mapper.AddDataSetObjectInitializer((ds) => (ds.Tables["Marriage"].Rows.Count == 1) ? ds.Tables["Marriage"].Rows[0] : null);
            mapper.AddDataColumnMap((f) => f.MarriageLicenceDate, "abrdata");
            mapper.AddDataColumnMap((f) => f.MarriageLicenceNumber, "abrn");
            mapper.AddDataColumnMap((f) => f.MarriageDate, "brdata");
            mapper.AddDataColumnMap((f) => f.MarriagePlaceCode, "abrnm");
            mapper.AddDataColumnMap((f) => f.MarriagePlace, "nm_ime");
            mapper.AddDataColumnMap((f) => f.MarriageCountryCode, "brrdj");
            mapper.AddDataColumnMap((f) => f.MarriageCountry, "gr_ime");
            mapper.AddDataColumnMap((f) => f.DivorceCaseNumber, "devn");
            mapper.AddDataColumnMap((f) => f.DivorceDate, "devdata");
            return mapper;
        }

        public CommonSignedResponse<MaritalStatusSpouseChildrenRequestType, MaritalStatusSpouseChildrenResponseType> MaritalStatusSpouseChildrenSearch(MaritalStatusSpouseChildrenRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.XmlSerialize(), Guid = id });
            try
            {
                string vegn = Utils.EGNtoVEGN(argument.EGN);
                IfxConnection connection = new IfxConnection(ConnectionString.Value);
                IfxCommand command = new IfxCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = @"select trim(t.sp) as sp,
											   trim(gp.imes) as imes,
											   trim(gp.imeb) as imeb,
											   trim(gp.imef) as imef,
											   trim(gp.egn) as egn,
                                               trim(gp.pol) as pol,
                                               trim(case when gp.pol='1' then trim(t.sp) 
                                                    when gp.pol='2' then trim(t.sp) ||'0' end) as sp_code
											  from regix_getmarital t 
											  join regix_getperson as gp
											  on t.vegn = gp.vegn
                                     where t.vegn = ?";
                command.Parameters.Add("vegn", vegn);
                IfxDataAdapter da = new IfxDataAdapter(command);

                IfxCommand relativesCommand = new IfxCommand();
                relativesCommand.Connection = connection;
                relativesCommand.CommandType = CommandType.Text;
                string relCmdText =
                     @"select  1 as order_number,
                               '' as egn,
                               trim(egnc) as rel_egn, 
                               trim(imes) imes, 
                               trim(imeb) imeb, 
                               trim(imef) imef, 
                               dsm, 
                               trim(pol) pol,
                               trim(case when pol = 1 then 'СИН' WHEN pol = 2 then 'ДЪЩЕРЯ' end)  rel_type
                          from regix_getchildren
                         where {0} =  ? --egnb or egnm 
                        union all
                        select 1 as order_number,
                               '' as egn,
                               trim(egns) as rel_egn, 
                               trim(imes) imes, 
                               trim(imeb) imeb, 
                               trim(imef) imef, 
                               dsm, 
                               trim(pol) pol,
                               trim(case when pol = 1 then 'СЪПРУГ' WHEN pol = 2 then 'СЪПРУГА' end) as rel_type
                          from regix_getspouse
                         where vegn = ?
                        union all
                        select 1 as order_number,
                               '' as egn,
                               trim(rodegn) as rel_egn, 
                               trim(imes) imes, 
                               trim(imeb) imeb, 
                               trim(imef) imef, 
                               case when trim(dsm) = '' or trim(dsm) is null then null::date
                                    else date(to_date(trim(dsm), '%d.%m.%Y')) end dsm, 
                               trim(pol) pol,
                               trim(case 
                                when rodvr =  'ДЕ'
                                then case when pol = 1 then 'СИН' WHEN pol = 2 then 'ДЪЩЕРЯ' end 
                                when rodvr =  'СЪ' 
                                then case when pol = 1 then 'СЪПРУГ' WHEN pol = 2 then 'СЪПРУГА' end 
                               end) as rel_type
                          from regix_getrod
                         where egn = ?
                           and rodvr in ('ДЕ', 'СЪ')";
                relativesCommand.Parameters.Add("egn", argument.EGN);
                relativesCommand.Parameters.Add("vegn", vegn);
                relativesCommand.Parameters.Add("egn", argument.EGN);
                IfxDataAdapter darelativesCommand = new IfxDataAdapter(relativesCommand);

                DataSet ds = new DataSet();
                ds.Tables.Add("MaritalStatus");
                ds.Tables.Add("Relatives");
                try
                {
                    connection.Open();
                    da.Fill(ds.Tables["MaritalStatus"]);
                    //извличаме първо master-записа, и ако такъв е намерен търсим детайли
                    if (ds.Tables["MaritalStatus"].Rows.Count > 0)
                    {
                        if (ds.Tables["MaritalStatus"].Rows[0]["pol"].ToString() == "1") //мъж
                        {
                            relCmdText = string.Format(relCmdText, "egnb");
                        }
                        if (ds.Tables["MaritalStatus"].Rows[0]["pol"].ToString() == "2") //жена
                        {
                            relCmdText = string.Format(relCmdText, "egnm");
                        }
                        relativesCommand.CommandText = relCmdText;
                        darelativesCommand.Fill(ds.Tables["Relatives"]);
                    }
                }
                finally
                {
                    connection.Close();
                }

                MaritalStatusSpouseChildrenResponseType result = new MaritalStatusSpouseChildrenResponseType();
                if (ds.Tables["MaritalStatus"].Rows.Count > 0)
                {
                    //Подреждаме ги първо СЪПРУГ, СЪПРУГА , после децата по VEGN, т.е. по възраст
                    int i = 1;
                    foreach (DataRow r in ds.Tables["Relatives"].Select()
                        .OrderBy(t => (t["rel_type"].ToString().StartsWith("СЪПРУГ") || t["rel_type"].ToString().StartsWith("СЪПРУГА")) ? 1 : 2)
                        .ThenBy(t => ( t["rel_egn"] != DBNull.Value 
                                        ? ( t["rel_egn"].ToString().Trim().Length == 8 ? t["rel_egn"].ToString().Trim().Replace("18","0").Replace("19","1").Replace("20","2") : Utils.EGNtoVEGN(t["rel_egn"].ToString()))
                                        : "999999")))
                    {
                        r["order_number"] = i;
                        r["egn"] = argument.EGN;
                        i++;
                    }
                    ds.Relations.Add("relatives", ds.Tables["MaritalStatus"].Columns["egn"], ds.Tables["Relatives"].Columns["egn"]);

                    
                    DataSetMapper<MaritalStatusSpouseChildrenResponseType> maritalStatusMapper = MaritalStatusSpouseChildrenMap(accessMatrix);
                    
                    maritalStatusMapper.Map(ds, result);
                }
                else
                {
                    result.Relatives = null;
                }

                var maritalStatusConstMapper = CreateMartialStatusSpouseChildrenConstMap(accessMatrix, DateTime.Now);
                maritalStatusConstMapper.Map(result, result);

                LogWarn(Utils.GetLogMessageForSuccessOperation(argument.EGN, aditionalParameters));
                return SigningUtils.CreateAndSign(
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

        private static DataSetMapper<MaritalStatusSpouseChildrenResponseType> MaritalStatusSpouseChildrenMap(AccessMatrix accessMatrix)
        {
            DataSetMapper<MaritalStatusSpouseChildrenResponseType> mapper = new DataSetMapper<MaritalStatusSpouseChildrenResponseType>(accessMatrix);
            mapper.AddDataSetObjectInitializer((ds) => (ds.Tables["MaritalStatus"].Rows.Count == 1) ? ds.Tables["MaritalStatus"].Rows[0] : null);
            mapper.AddDataColumnMap((f) => f.MaritalStatusCode, "sp", (o) =>
            {
                MaritalStatusCode result;
                if (o != null && o != System.DBNull.Value)
                {
                    switch (o.ToString())
                    {
                        case "1":
                            result = MaritalStatusCode.Item1;
                            break;
                        case "2":
                            result = MaritalStatusCode.Item2;
                            break;
                        case "3":
                            result = MaritalStatusCode.Item3;
                            break;
                        case "4":
                            result = MaritalStatusCode.Item4;
                            break;
                        case "9":
                            result = MaritalStatusCode.Item9;
                            break;
                        default:
                            return null;
                    }
                    return result;
                }
                else
                {
                    return null;
                }
            });
            mapper.AddDataColumnMap((f) => f.Gender, "pol");
            mapper.AddDataColumnMap((f) => f.MaritalStatusName, "sp_code", Utils.ToMaritalStatusText);
            mapper.AddDataColumnMap((f) => f.FirstName, "imes");
            mapper.AddDataColumnMap((f) => f.MiddleName, "imeb");
            mapper.AddDataColumnMap((f) => f.LastName, "imef");
            mapper.AddDataColumnMap((f) => f.EGN, "egn");

            mapper.AddDataRowMap((r) => r.Relatives, (dr) => dr.GetChildRows("relatives"));

            
            mapper.AddDataColumnMap((r) => r.Relatives[0].OrderNumber, "order_number");
            mapper.AddDataColumnMap((r) => r.Relatives[0].EGN, "rel_egn", (o) =>
            {
                if (o != null && o != System.DBNull.Value)
                {
                    if (o.ToString().Trim().Length == 8)
                    {
                        string year = o.ToString().Substring(0, 4);
                        string month = o.ToString().Substring(4, 2);
                        string day = o.ToString().Substring(6);
                        return string.Format("{0}.{1}.{2} г.", day, month, year);
                    }
                    else
                    {
                        return o.ToString();
                    }
                }
                else
                {
                    return null;
                }
            });
            mapper.AddDataColumnMap((r) => r.Relatives[0].FirstName, "imes");
            mapper.AddDataColumnMap((r) => r.Relatives[0].MiddleName, "imeb");
            mapper.AddDataColumnMap((r) => r.Relatives[0].LastName, "imef");
            mapper.AddDataColumnMap((r) => r.Relatives[0].DateOfDeath, "dsm");
            mapper.AddDataColumnMap((r) => r.Relatives[0].RelativeType, "rel_type", (o) =>
            {
                RelativeType result;
                if (o != null && o != System.DBNull.Value && Enum.TryParse(o.ToString(), out result))
                {
                    return result;
                }
                else
                {
                    return null;
                }
            });

            return mapper;
        }
    }
}
