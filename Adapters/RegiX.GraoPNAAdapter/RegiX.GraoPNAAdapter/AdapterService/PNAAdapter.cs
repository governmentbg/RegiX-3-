using System;
using System.Data;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.Common.Utils;
using System.ComponentModel.Composition;
using IBM.Data.Informix;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.GraoCommon;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Adapters.Common.DataContracts;
using TechnoLogica.RegiX.Common.DataContracts.Parameter;
using TechnoLogica.RegiX.Adapters.Common.ObjectMapping;

namespace TechnoLogica.RegiX.GraoPNAAdapter.AdapterService
{
    [Export(typeof(IAdapterService))]
    [ExportFullName(typeof(PNAAdapter), typeof(IAdapterService))]
    [ExportSimpleName(typeof(PNAAdapter), typeof(IAdapterService))]
    public class PNAAdapter : InformixAdapterService.InformixBaseAdapterService, IPNAAdapter, IAdapterService
    {

        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(PNAAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> ConnectionString =
            new ParameterInfo<string>("Database=grao;Host=egov;Server=ol_informix1170_1;Service=25852;Protocol=onsoctcp;UID=informix;Password=;DB_LOCALE=en_US.57372")
            {
                Key = Constants.ConnectionStringParameterKeyName,
                Description = "Connection string for Informix",
                OwnerAssembly = typeof(PNAAdapter).Assembly
            };

        public CommonSignedResponse<PermanentAddressRequestType, PermanentAddressResponseType> PermanentAddressSearch(
            PermanentAddressRequestType argument,
            AccessMatrix accessMatrix,
            AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.XmlSerialize(), Guid = id });
            try
            {
                IfxConnection connection = new IfxConnection(ConnectionString.Value);
                IfxCommand command = new IfxCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = @"select  trim(gr_kod) gr_kod, 
                                            trim(gr_ime) gr_ime, 
                                            trim(nm_kobl) nm_kobl, 
                                            trim(obl_ime) obl_ime,
                                            trim(nm_kob) nm_kob, 
                                            trim(ob_ime) ob_ime,
                                            trim(anm) anm,
                                            trim(nm_ime) nm_ime, 
                                            trim(nm_km) nm_km, 
                                            trim(apa) apa, 
                                            trim(pa_ime) pa_ime, 
                                            trim(anom) anom, 
                                            trim(avh) avh, 
                                            trim(aet) aet, 
                                            trim(aap) aap, 
                                            adataot as adata  
                                    from regix_gethaddress 
                                    where egn = ? and avid in ('1','2','3')
                                     and ? between adataot and adatado-1";
                command.Parameters.Add("egn", argument.EGN);
                IfxParameter searchDate = new IfxParameter();
                searchDate.IfxType = IfxType.Date;
                searchDate.DbType = DbType.Date;
                searchDate.Value = argument.GetValueOrNull(r => r.SearchDate);
                command.Parameters.Add(searchDate);

                IfxDataAdapter da = new IfxDataAdapter(command);
                DataSet ds = new DataSet();
                ds.Tables.Add("PermanentAddress");
                try
                {
                    connection.Open();
                    da.Fill(ds.Tables["PermanentAddress"]);
                    if (ds.Tables["PermanentAddress"].Rows.Count == 0)
                    {
                        command.CommandText = @"select  trim(gr_kod) gr_kod, 
                                            trim(gr_ime) gr_ime, 
                                            trim(nm_kobl) nm_kobl, 
                                            trim(obl_ime) obl_ime,
                                            trim(nm_kob) nm_kob, 
                                            trim(ob_ime) ob_ime,
                                            trim(panm) as anm,
                                            trim(nm_ime) nm_ime, 
                                            trim(nm_km) nm_km,
                                            trim(papa) as apa, 
                                            trim(pa_ime) pa_ime, 
                                            trim(panom) as anom, 
                                            trim(pavh) as avh, 
                                            trim(paet) as aet, 
                                            trim(paap) as aap, 
                                            padata as adata 
                                    from regix_getpaddress 
                                    where vegn = ? 
                                      and ? >= padata";
                        command.Parameters.Clear();
                        command.Parameters.Add("vegn", Utils.EGNtoVEGN(argument.EGN));
                        command.Parameters.Add(searchDate);
                        da.Fill(ds.Tables["PermanentAddress"]);

                    }
                }
                finally
                {
                    connection.Close();
                }
                DataSetMapper<PermanentAddressResponseType> mapper = CreatePermanentAddressMap(accessMatrix);
                PermanentAddressResponseType result = new PermanentAddressResponseType();
                mapper.Map(ds, result);
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

        private static DataSetMapper<PermanentAddressResponseType> CreatePermanentAddressMap(AccessMatrix accessMatrix)
        {
            DataSetMapper<PermanentAddressResponseType> mapper = new DataSetMapper<PermanentAddressResponseType>(accessMatrix);
            mapper.AddDataSetObjectInitializer((ds) => (ds.Tables["PermanentAddress"].Rows.Count == 1) ? ds.Tables["PermanentAddress"].Rows[0] : null);
            mapper.AddDataColumnMap((f) => f.DistrictCode, "nm_kobl");
            mapper.AddDataColumnMap((f) => f.DistrictName, "obl_ime");
            mapper.AddDataColumnMap((f) => f.MunicipalityCode, "nm_kob");
            mapper.AddDataColumnMap((f) => f.MunicipalityName, "ob_ime");
            mapper.AddDataColumnMap((f) => f.SettlementCode, "anm");
            mapper.AddDataColumnMap((f) => f.SettlementName, "nm_ime");
            mapper.AddDataColumnMap((f) => f.CityAreaCode, "nm_km");
            mapper.AddDataColumnMap((f) => f.LocationCode, "apa");
            mapper.AddDataColumnMap((f) => f.LocationName, "pa_ime");
            mapper.AddDataColumnMap((f) => f.BuildingNumber, "anom");
            mapper.AddDataColumnMap((f) => f.Entrance, "avh");
            mapper.AddDataColumnMap((f) => f.Floor, "aet");
            mapper.AddDataColumnMap((f) => f.Apartment, "aap");
            mapper.AddDataColumnMap((f) => f.FromDate, "adata");
            return mapper;
        }

        public CommonSignedResponse<TemporaryAddressRequestType, TemporaryAddressResponseType> TemporaryAddressSearch(TemporaryAddressRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.XmlSerialize(), Guid = id });
            try
            {
                IfxConnection connection = new IfxConnection(ConnectionString.Value);
                IfxCommand command = new IfxCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = @"select  trim(gr_kod) gr_kod, 
                                            trim(gr_ime) gr_ime, 
                                            trim(nm_kobl) nm_kobl, 
                                            trim(obl_ime) obl_ime,
                                            trim(nm_kob) nm_kob, 
                                            trim(ob_ime) ob_ime,
                                            trim(anm) anm, 
                                            trim(nm_ime) nm_ime, 
                                            trim(nm_km) nm_km,
                                            trim(apa) apa, 
                                            trim(pa_ime) pa_ime, 
                                            trim(anom) anom, 
                                            trim(avh) avh, 
                                            trim(aet) aet, 
                                            trim(aap) aap, 
                                            adataot as adata  
                                    from regix_gethaddress 
                                    where egn = ? and avid in ('4','5','6')
                                      and ? between adataot and adatado-1";
                command.Parameters.Add("egn", argument.EGN);
                IfxParameter searchDate = new IfxParameter();
                searchDate.IfxType = IfxType.Date;
                searchDate.DbType = DbType.Date;
                searchDate.Value = argument.GetValueOrNull(r => r.SearchDate);
                command.Parameters.Add(searchDate);

                IfxDataAdapter da = new IfxDataAdapter(command);
                DataSet ds = new DataSet();
                ds.Tables.Add("TemporaryAddress");
                try
                {
                    connection.Open();
                    da.Fill(ds.Tables["TemporaryAddress"]);
                    if (ds.Tables["TemporaryAddress"].Rows.Count == 0)
                    {
                        command.CommandText = @"select  trim(gr_kod) gr_kod, 
                                            trim(gr_ime) gr_ime, 
                                            trim(nm_kobl) nm_kobl, 
                                            trim(obl_ime) obl_ime,
                                            trim(nm_kob) nm_kob, 
                                            trim(ob_ime) ob_ime,
                                            trim(nanm) as anm,
                                            trim(nm_ime) nm_ime, 
                                            trim(nm_km) nm_km,
                                            trim(napa) as apa, 
                                            trim(pa_ime) pa_ime, 
                                            trim(nanom) as anom, 
                                            trim(navh) as avh, 
                                            trim(naet) as aet, 
                                            trim(naap) as aap, 
                                            nadata as adata 
                                    from regix_getnaddress 
                                    where vegn = ? 
                                      and ? >= nadata";
                        command.Parameters.Clear();
                        command.Parameters.Add("vegn", Utils.EGNtoVEGN(argument.EGN));
                        command.Parameters.Add(searchDate);
                        da.Fill(ds.Tables["TemporaryAddress"]);
                    }
                }
                finally
                {
                    connection.Close();
                }
                DataSetMapper<TemporaryAddressResponseType> mapper = CreateTemporaryAddressMap(accessMatrix);
                TemporaryAddressResponseType result = new TemporaryAddressResponseType();
                mapper.Map(ds, result);
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

        private static DataSetMapper<TemporaryAddressResponseType> CreateTemporaryAddressMap(AccessMatrix accessMatrix)
        {
            DataSetMapper<TemporaryAddressResponseType> mapper = new DataSetMapper<TemporaryAddressResponseType>(accessMatrix);
            mapper.AddDataSetObjectInitializer((ds) => (ds.Tables["TemporaryAddress"].Rows.Count == 1) ? ds.Tables["TemporaryAddress"].Rows[0] : null);
            mapper.AddDataColumnMap((f) => f.CountryCode, "gr_kod");
            mapper.AddDataColumnMap((f) => f.CountryName, "gr_ime");
            mapper.AddDataColumnMap((f) => f.DistrictCode, "nm_kobl");
            mapper.AddDataColumnMap((f) => f.DistrictName, "obl_ime");
            mapper.AddDataColumnMap((f) => f.MunicipalityCode, "nm_kob");
            mapper.AddDataColumnMap((f) => f.MunicipalityName, "ob_ime");
            mapper.AddDataColumnMap((f) => f.SettlementCode, "anm");
            mapper.AddDataColumnMap((f) => f.SettlementName, "nm_ime");
            mapper.AddDataColumnMap((f) => f.CityAreaCode, "nm_km");
            mapper.AddDataColumnMap((f) => f.LocationCode, "apa");
            mapper.AddDataColumnMap((f) => f.LocationName, "pa_ime");
            mapper.AddDataColumnMap((f) => f.BuildingNumber, "anom");
            mapper.AddDataColumnMap((f) => f.Entrance, "avh");
            mapper.AddDataColumnMap((f) => f.Floor, "aet");
            mapper.AddDataColumnMap((f) => f.Apartment, "aap");
            mapper.AddDataColumnMap((f) => f.FromDate, "adata");
            return mapper;
        }
    }
}
