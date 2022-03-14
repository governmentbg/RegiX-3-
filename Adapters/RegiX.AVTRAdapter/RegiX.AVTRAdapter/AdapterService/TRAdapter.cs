using System;
using System.Collections.Generic;
using System.Linq;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.Common.Utils;
using System.ComponentModel.Composition;
using System.Data;
using TechnoLogica.RegiX.Common.DataContracts;
using Oracle.ManagedDataAccess.Client;
using TechnoLogica.RegiX.AVTRAdapter.ActualStateV2;
using System.Xml;
using TechnoLogica.RegiX.AVTRAdapter.ActualStateV3;
using TechnoLogica.RegiX.OracleAdapterService;
using TechnoLogica.RegiX.Adapters.Common.DataContracts;
using TechnoLogica.RegiX.Common.DataContracts.Parameter;
using TechnoLogica.RegiX.Adapters.Common.ObjectMapping;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.AVTRAdapter.Helpers;

namespace TechnoLogica.RegiX.AVTRAdapter.AdapterService
{
    [Export(typeof(IAdapterService))]
    [ExportFullName(typeof(TRAdapter), typeof(IAdapterService))]
    [ExportSimpleName(typeof(TRAdapter), typeof(IAdapterService))]
    public class TRAdapter : OracleBaseAdapterService, ITRAdapter, IAdapterService
    {
        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(TRAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> ConnectionString =
            new ParameterInfo<string>("data source=;password=;persist security info=True;user id=")
            {
                Key = Constants.ConnectionStringParameterKeyName,
                Description = "Connection String for Oracle datatabase",
                OwnerAssembly = typeof(TRAdapter).Assembly
            };


        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(TRAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> OracleRefreshGroupName =
            new ParameterInfo<string>("EGOV_MVIEWS")
            {
                Key = "OracleRefreshGroupName",
                Description = "Name of refresh group for views in Oracle datatabase",
                OwnerAssembly = typeof(TRAdapter).Assembly
            };

        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(TRAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> MViewsUser =
            new ParameterInfo<string>("comreg")
            {
                Key = "MViewsUser",
                Description = "Name of user where MViews are created",
                OwnerAssembly = typeof(TRAdapter).Assembly
            };


        public static XmlElement DeedElement = (new ActualStateV2.DeedType()).XmlSerialize().ToXmlElement();
        //public static XmlElement SubDeedElement = (new SubDeedType()).XmlSerialize().ToXmlElement();
        //public static System.Reflection.PropertyInfo[] SubdeedPropertyInfoCollection = (typeof(SubDeedType)).GetProperties();

        public CommonSignedResponse<ActualStateRequestType, ActualStateResponseType> GetActualState(ActualStateRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
            try
            {
            OracleConnection connection = new OracleConnection(ConnectionString.Value);
            DataSet ds = new DataSet();

            OracleCommand commandFields = new OracleCommand();
            commandFields.Connection = connection;
            commandFields.CommandType = CommandType.Text;
            commandFields.CommandText =
                      @"SELECT t.deed_id,
                               v.deed_status,
                               v.uic,
                               v.company_name,
                               v.legal_form_name,
                               v.legal_form_abbr,
                               transliteration,
                               countrycode,
                               country,
                               isforeign,
                               districtekatte,
                               district,
                               municipalityekatte,
                               municipality,
                               settlementekatte,
                               settlement,
                               areaekatte,
                               area,
                               postcode,
                               foreignplace,
                               housingestate,
                               street,
                               streetnumber,
                               BLOCK,
                               entrance,
                               floor,
                               apartment,
                               contactsphone,
                               contactsfax,
                               contactsemail,
                               contactsurl,
                               corrcountrycode,
                               corrcountry,
                               corrisforeign,
                               corrdistrictekatte,
                               corrdistrict,
                               corrmunicipalityekatte,
                               corrmunicipality,
                               corrsettlementekatte,
                               corrsettlement,
                               corrareaekatte,
                               corrarea,
                               corrpostcode,
                               corrforeignplace,
                               corrhousingestate,
                               corrstreet,
                               corrstreetnumber,
                               corrblock,
                               correntrance,
                               corrfloor,
                               corrapartment,
                               subjectofactivity,
                               subjectofactisbank,
                               subjectofactisinsurer,
                               subjectofactivitynkidtext,
                               subjectofactivitynkidcode,
                               wayofmanagement,
                               wayofrepresentation,
                               boardofdirectorsmandate,
                               boardofdirectorsmandatetype,
                               administrativeboardmandate,
                               administrativeboardmandatetype,
                               managersmandate,
                               managersmandatetype,
                               managersmandate2,
                               managersmandate2type,
                               leadingboardmandate,
                               leadingboardmandatetype,
                               supervisingboardmandate,
                               supervisingboardmandatetype,
                               supervisingboardmandate2,
                               supervisingboardmandate2type,
                               controllingboardmandate,
                               controllingboardmandatetype,
                               termsofpartnership,
                               termofexisting,
                               specialconditions,
                               hiddennonmonetarydeposit,
                               sharepaymentresponsibility,
                               concededestatevalue,
                               cessationoftrade,
                               addemptionoftrader,
                               funds,
                               fundseuro,
                               minimumamount,
                               minimumamounteuro,
                               depositedfunds,
                               depositedfundseuro,
                               buybackdecision,
                               addemptioncountrycode,
                               addemptioncountry,
                               addemptionisforeign,
                               addemptiondistrictekatte,
                               addemptiondistrict,
                               addemptionmunicipalityekatte,
                               addemptionmunicipality,
                               addemptionsettlementekatte,
                               addemptionsettlement,
                               addemptionareaekatte,
                               addemptionarea,
                               addemptionpostcode,
                               addemptionforeignplace,
                               addemptionhousingestate,
                               addemptionstreet,
                               addemptionstreetnumber,
                               addemptionblock,
                               addemptionentrance,
                               addemptionfloor,
                               addemptionapartment,
                               addemptioncontactsphone,
                               addemptioncontactsfax,
                               addemptioncontactsemail,
                               addemptioncontactsurl,
                               addemptioncompetentauthority,
                               addemptionregistrationnumber,
                               v.liquidation_or_insolvency liquidation_or_insolvency
                          FROM " + MViewsUser.Value + @".egov_actual_state_fields t 
                          join " + MViewsUser.Value + @".egov_valid_uic v on t.deed_id = v.deed_id
                         where v.uic = :p_uic";
            commandFields.Parameters.Add(new OracleParameter("p_uic", OracleDbType.Varchar2, argument.UIC, ParameterDirection.Input));

            OracleDataAdapter daFields = new OracleDataAdapter(commandFields);
            ds.Tables.Add("Fields");
            ds.Tables.Add("Shares");
            ds.Tables.Add("NonMonetaryDeposits");
            ds.Tables.Add("Details");
            DateTime? date = null;

            try
            {
                connection.Open();
                daFields.Fill(ds.Tables["Fields"]);
                if (ds.Tables["Fields"].Rows.Count > 0 && !String.IsNullOrEmpty(ds.Tables["Fields"].Rows[0]["deed_id"].ToString()))
                {
                    string deedID = ds.Tables["Fields"].Rows[0]["deed_id"].ToString();

                    OracleCommand commandShares = new OracleCommand();
                    commandShares.Connection = connection;
                    commandShares.CommandType = CommandType.Text;
                    commandShares.CommandText =
                              @"SELECT deed_id,
                                       sharetype,
                                       sharecount,
                                       sharenominalvalue
                                  FROM " + MViewsUser.Value + @".egov_shares t
                                 WHERE t.deed_id = :p_deed_id";
                    commandShares.Parameters.Add(new OracleParameter("p_deed_id", OracleDbType.Varchar2, deedID, ParameterDirection.Input));

                    OracleCommand commandNonMonetaryDeposits = new OracleCommand();
                    commandNonMonetaryDeposits.Connection = connection;
                    commandNonMonetaryDeposits.CommandType = CommandType.Text;
                    commandNonMonetaryDeposits.CommandText =
                           @"SELECT t.deed_id,
                                    t.nonmonetarydeposit,
                                    t.nonmonetarydepositvalue
                                FROM " + MViewsUser.Value + @".egov_nonmonetary_deposits t
                                WHERE t.deed_id = :p_deed_id";
                    commandNonMonetaryDeposits.Parameters.Add(new OracleParameter("p_deed_id", OracleDbType.Varchar2, deedID, ParameterDirection.Input));

                    OracleCommand commandDetails = new OracleCommand();
                    commandDetails.Connection = connection;
                    commandDetails.CommandType = CommandType.Text;
                    commandDetails.CommandText =
                           @"SELECT t.deed_id,
                                    t.field_name,
                                    t.name,
                                    t.ident_type,
                                    t.ident,
                                    t.field_code,
                                    t.field_order
                                FROM " + MViewsUser.Value + @".egov_actual_state_details t
                                where t.deed_id = :p_deed_id
                                  and substr(field_ident, 1, 4) IN (
                                                '0007',
                                                '0009',
                                                '0010',
                                                '0012',
                                                '0013',
                                                '0014',
                                                '0015',
                                                '0018',
                                                '0019',
                                                '0020',
                                                '0021',
                                                '0023',
                                                '0534',
                                                '0537',
                                                '0538',
                                                '0550'
                                                    )
                                                    ";
                        //'00071'(Лица, на които е възложено управлението)
                        //'00101','00102'(Представители)
                        //'00180'(Физическо лице - търговец)
                        //'00190'(Съдружници)
                        //'00201'(Неограничено отговорни членове на ЕОИИ)
                        //'00210'(Ограничено отговорни съдружници)
                        //05340    Представители
                        //05371    Представители на дружество, контролирано пряко от дружество регистрирано в ЮПДР
                        //05381    Представители на дружество, контролирано непряко от дружество регистрирано в ЮПДР
                        //05500    Действителни собственици -физически лица, участващи пряко или косвено в дружеството
                       
                    commandDetails.Parameters.Add(new OracleParameter("p_deed_id", OracleDbType.Varchar2, deedID, ParameterDirection.Input));

                    OracleDataAdapter daShares = new OracleDataAdapter(commandShares);
                    OracleDataAdapter daNonMonetaryDeposits = new OracleDataAdapter(commandNonMonetaryDeposits);
                    OracleDataAdapter daDetails = new OracleDataAdapter(commandDetails);

                    daShares.Fill(ds.Tables["Shares"]);
                    daNonMonetaryDeposits.Fill(ds.Tables["NonMonetaryDeposits"]);
                    daDetails.Fill(ds.Tables["Details"]);

                    ds.Relations.Add("SharesForCompany",
                                ds.Tables["Fields"].Columns["deed_id"],
                                ds.Tables["Shares"].Columns["deed_id"]);

                    ds.Relations.Add("NonMonetaryDepositsForCompany",
                                ds.Tables["Fields"].Columns["deed_id"],
                                ds.Tables["NonMonetaryDeposits"].Columns["deed_id"]);

                    ds.Relations.Add("DetailsForCompany",
                                ds.Tables["Fields"].Columns["deed_id"],
                                ds.Tables["Details"].Columns["deed_id"]);
                    date = GetValidDate(connection);
                }
            }
            finally
            {
                connection.Close();
            }

            ActualStateResponseType result = new ActualStateResponseType();
            DataSetMapper<ActualStateResponseType> mapper = CreateActualStateMap(accessMatrix, date);

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

        private DateTime GetValidDate(OracleConnection connection)
        {
            return DateTime.Now;
        }

        private DataSetMapper<ActualStateResponseType> CreateActualStateMap(AccessMatrix accessMatrix, DateTime? validDate)
        {
            DataSetMapper<ActualStateResponseType> mapper = new DataSetMapper<ActualStateResponseType>(accessMatrix);

            mapper.AddDataSetObjectInitializer((ds) => (ds.Tables["Fields"].Rows.Count == 1) ? ds.Tables["Fields"].Rows[0] : null);
            if (validDate.HasValue)
            {
                mapper.AddConstantMap<DateTime>((r) => r.DataValidForDate, validDate.Value);
            }
            mapper.AddDataColumnMap((r) => r.Status, "deed_status", (o) =>
            {
                if (o != null && o != System.DBNull.Value)
                {
                    StatusType result;
                    switch (o.ToString())
                    {
                        case "N":
                            result = StatusType.Новапартида;
                            break;
                        case "E":
                            result = StatusType.Пререгистриранапартида;
                            break;
                        case "C":
                            result = StatusType.Новазакритапартида;
                            break;
                        case "L":
                            result = StatusType.Пререгистрираназакритапартида;
                            break;
                        default:
                            return o;
                    }
                    return result;
                }
                else
                {
                    return o;
                }
            });
            mapper.AddDataColumnMap((r) => r.LiquidationOrInsolvency, "liquidation_or_insolvency", (o) =>
            {
                if (o != null && o != System.DBNull.Value)
                {
                    LiquidationOrInsolvency result;
                    switch (o.ToString())
                    {
                        case "Liquidation":
                            result = LiquidationOrInsolvency.Вликвидация;
                            break;
                        case "Insolvency":
                            result = LiquidationOrInsolvency.Внесъстоятелност;
                            break;
                        case "InsolvencySecIns":
                            result = LiquidationOrInsolvency.ВнесъстоятелностнаIIинстанция;
                            break;
                        case "InsolvencyThirdIns":
                            result = LiquidationOrInsolvency.ВнесъстоятелностнаIIIинстанция;
                            break;
                        default:
                            return o;
                    }
                    return result;
                }
                else
                {
                    return o;
                }
            });
            mapper.AddDataColumnMap((r) => r.UIC, "uic");
            mapper.AddDataColumnMap((r) => r.Company, "company_name");
            mapper.AddDataColumnMap((r) => r.LegalForm.LegalFormName, "legal_form_name");
            mapper.AddDataColumnMap((r) => r.LegalForm.LegalFormAbbr, "legal_form_abbr");
            mapper.AddDataColumnMap((r) => r.Transliteration, "transliteration");
            mapper.AddDataColumnMap((r) => r.Seat.Address.CountryCode, "countrycode");
            mapper.AddDataColumnMap((r) => r.Seat.Address.Country, "country");
            mapper.AddDataColumnMap((r) => r.Seat.Address.IsForeign, "isforeign");
            mapper.AddDataColumnMap((r) => r.Seat.Address.DistrictEkatte, "districtekatte");
            mapper.AddDataColumnMap((r) => r.Seat.Address.District, "district");
            mapper.AddDataColumnMap((r) => r.Seat.Address.MunicipalityEkatte, "municipalityekatte");
            mapper.AddDataColumnMap((r) => r.Seat.Address.Municipality, "municipality");
            mapper.AddDataColumnMap((r) => r.Seat.Address.SettlementEKATTE, "settlementekatte");
            mapper.AddDataColumnMap((r) => r.Seat.Address.Settlement, "settlement");
            mapper.AddDataColumnMap((r) => r.Seat.Address.AreaEkatte, "areaekatte");
            mapper.AddDataColumnMap((r) => r.Seat.Address.Area, "area");
            mapper.AddDataColumnMap((r) => r.Seat.Address.PostCode, "postcode");
            mapper.AddDataColumnMap((r) => r.Seat.Address.ForeignPlace, "foreignplace");
            mapper.AddDataColumnMap((r) => r.Seat.Address.HousingEstate, "housingestate");
            mapper.AddDataColumnMap((r) => r.Seat.Address.Street, "street");
            mapper.AddDataColumnMap((r) => r.Seat.Address.StreetNumber, "streetnumber");
            mapper.AddDataColumnMap((r) => r.Seat.Address.Block, "BLOCK");
            mapper.AddDataColumnMap((r) => r.Seat.Address.Entrance, "entrance");
            mapper.AddDataColumnMap((r) => r.Seat.Address.Floor, "floor");
            mapper.AddDataColumnMap((r) => r.Seat.Address.Apartment, "apartment");
            mapper.AddDataColumnMap((r) => r.Seat.Contacts.Phone, "contactsphone");
            mapper.AddDataColumnMap((r) => r.Seat.Contacts.Fax, "contactsfax");
            mapper.AddDataColumnMap((r) => r.Seat.Contacts.EMail, "contactsemail");
            mapper.AddDataColumnMap((r) => r.Seat.Contacts.URL, "contactsurl");
            mapper.AddDataColumnMap((r) => r.SeatForCorrespondence.CountryCode, "corrcountrycode");
            mapper.AddDataColumnMap((r) => r.SeatForCorrespondence.Country, "corrcountry");
            mapper.AddDataColumnMap((r) => r.SeatForCorrespondence.IsForeign, "corrisforeign");
            mapper.AddDataColumnMap((r) => r.SeatForCorrespondence.DistrictEkatte, "corrdistrictekatte");
            mapper.AddDataColumnMap((r) => r.SeatForCorrespondence.District, "corrdistrict");
            mapper.AddDataColumnMap((r) => r.SeatForCorrespondence.MunicipalityEkatte, "corrmunicipalityekatte");
            mapper.AddDataColumnMap((r) => r.SeatForCorrespondence.Municipality, "corrmunicipality");
            mapper.AddDataColumnMap((r) => r.SeatForCorrespondence.SettlementEKATTE, "corrsettlementekatte");
            mapper.AddDataColumnMap((r) => r.SeatForCorrespondence.Settlement, "corrsettlement");
            mapper.AddDataColumnMap((r) => r.SeatForCorrespondence.AreaEkatte, "corrareaekatte");
            mapper.AddDataColumnMap((r) => r.SeatForCorrespondence.Area, "corrarea");
            mapper.AddDataColumnMap((r) => r.SeatForCorrespondence.PostCode, "corrpostcode");
            mapper.AddDataColumnMap((r) => r.SeatForCorrespondence.ForeignPlace, "corrforeignplace");
            mapper.AddDataColumnMap((r) => r.SeatForCorrespondence.HousingEstate, "corrhousingestate");
            mapper.AddDataColumnMap((r) => r.SeatForCorrespondence.Street, "corrstreet");
            mapper.AddDataColumnMap((r) => r.SeatForCorrespondence.StreetNumber, "corrstreetnumber");
            mapper.AddDataColumnMap((r) => r.SeatForCorrespondence.Block, "corrblock");
            mapper.AddDataColumnMap((r) => r.SeatForCorrespondence.Entrance, "correntrance");
            mapper.AddDataColumnMap((r) => r.SeatForCorrespondence.Floor, "corrfloor");
            mapper.AddDataColumnMap((r) => r.SeatForCorrespondence.Apartment, "corrapartment");
            mapper.AddDataColumnMap((r) => r.SubjectOfActivity.Subject, "subjectofactivity");
            mapper.AddDataColumnMap((r) => r.SubjectOfActivity.IsBank, "subjectofactisbank", (o) => o.ToString().ToUpper().Equals("TRUE") ? true : false);
            mapper.AddDataColumnMap((r) => r.SubjectOfActivity.IsInsurer, "subjectofactisinsurer", (o) => o.ToString().ToUpper().Equals("TRUE") ? true : false);
            mapper.AddDataColumnMap((r) => r.SubjectOfActivityNKID.NKIDname, "subjectofactivitynkidtext");
            mapper.AddDataColumnMap((r) => r.SubjectOfActivityNKID.NKIDcode, "subjectofactivitynkidcode");
            mapper.AddDataColumnMap((r) => r.WayOfManagement, "wayofmanagement");
            mapper.AddDataColumnMap((r) => r.WayOfRepresentation, "wayofrepresentation");
            mapper.AddDataColumnMap((r) => r.BoardOfDirectorsMandate.MandateValue, "boardofdirectorsmandate");
            mapper.AddDataColumnMap((r) => r.BoardOfDirectorsMandate.Type, "boardofdirectorsmandatetype");
            mapper.AddDataColumnMap((r) => r.AdministrativeBoardMandate.MandateValue, "administrativeboardmandate");
            mapper.AddDataColumnMap((r) => r.AdministrativeBoardMandate.Type, "administrativeboardmandatetype");
            mapper.AddDataColumnMap((r) => r.BoardOfManagersMandate.MandateValue, "managersmandate");
            mapper.AddDataColumnMap((r) => r.BoardOfManagersMandate.Type, "managersmandatetype");
            mapper.AddDataColumnMap((r) => r.BoardOfManagers2Mandate.MandateValue, "managersmandate2");
            mapper.AddDataColumnMap((r) => r.BoardOfManagers2Mandate.Type, "managersmandate2type");
            mapper.AddDataColumnMap((r) => r.LeadingBoardMandate.MandateValue, "leadingboardmandate");
            mapper.AddDataColumnMap((r) => r.LeadingBoardMandate.Type, "leadingboardmandatetype");
            mapper.AddDataColumnMap((r) => r.SupervisingBoardMandate.MandateValue, "supervisingboardmandate");
            mapper.AddDataColumnMap((r) => r.SupervisingBoardMandate.Type, "supervisingboardmandatetype");
            mapper.AddDataColumnMap((r) => r.SupervisingBoard2Mandate.MandateValue, "supervisingboardmandate2");
            mapper.AddDataColumnMap((r) => r.SupervisingBoard2Mandate.Type, "supervisingboardmandate2type");
            mapper.AddDataColumnMap((r) => r.ControllingBoardMandate.MandateValue, "controllingboardmandate");
            mapper.AddDataColumnMap((r) => r.ControllingBoardMandate.Type, "controllingboardmandatetype");
            mapper.AddDataColumnMap((r) => r.TermsOfPartnership, "termsofpartnership");
            mapper.AddDataColumnMap((r) => r.TermOfExisting, "termofexisting");
            mapper.AddDataColumnMap((r) => r.SpecialConditions, "specialconditions");
            mapper.AddDataColumnMap((r) => r.HiddenNonMonetaryDeposit, "hiddennonmonetarydeposit");
            mapper.AddDataColumnMap((r) => r.SharePaymentResponsibility, "sharepaymentresponsibility");
            mapper.AddDataColumnMap((r) => r.ConcededEstateValue, "concededestatevalue");
            mapper.AddDataColumnMap((r) => r.CessationOfTrade, "cessationoftrade");
            mapper.AddDataColumnMap((r) => r.AddemptionOfTrader, "addemptionoftrader");
            mapper.AddDataColumnMap((r) => r.Funds.Value, "funds");
            mapper.AddDataColumnMap((r) => r.Funds.Euro, "fundseuro");
            mapper.AddDataColumnMap((r) => r.MinimumAmount.Value, "minimumamount");
            mapper.AddDataColumnMap((r) => r.MinimumAmount.Euro, "minimumamounteuro");
            mapper.AddDataColumnMap((r) => r.DepositedFunds.Value, "depositedfunds");
            mapper.AddDataColumnMap((r) => r.DepositedFunds.Euro, "depositedfundseuro");
            mapper.AddDataColumnMap((r) => r.BuyBackDecision, "buybackdecision");
            mapper.AddDataColumnMap((r) => r.AddemptionOfTraderSeatChange.Address.CountryCode, "addemptioncountrycode");
            mapper.AddDataColumnMap((r) => r.AddemptionOfTraderSeatChange.Address.Country, "addemptioncountry");
            mapper.AddDataColumnMap((r) => r.AddemptionOfTraderSeatChange.Address.IsForeign, "addemptionisforeign");
            mapper.AddDataColumnMap((r) => r.AddemptionOfTraderSeatChange.Address.DistrictEkatte, "addemptiondistrictekatte");
            mapper.AddDataColumnMap((r) => r.AddemptionOfTraderSeatChange.Address.District, "addemptiondistrict");
            mapper.AddDataColumnMap((r) => r.AddemptionOfTraderSeatChange.Address.MunicipalityEkatte, "addemptionmunicipalityekatte");
            mapper.AddDataColumnMap((r) => r.AddemptionOfTraderSeatChange.Address.Municipality, "addemptionmunicipality");
            mapper.AddDataColumnMap((r) => r.AddemptionOfTraderSeatChange.Address.SettlementEKATTE, "addemptionsettlementekatte");
            mapper.AddDataColumnMap((r) => r.AddemptionOfTraderSeatChange.Address.Settlement, "addemptionsettlement");
            mapper.AddDataColumnMap((r) => r.AddemptionOfTraderSeatChange.Address.AreaEkatte, "addemptionareaekatte");
            mapper.AddDataColumnMap((r) => r.AddemptionOfTraderSeatChange.Address.Area, "addemptionarea");
            mapper.AddDataColumnMap((r) => r.AddemptionOfTraderSeatChange.Address.PostCode, "addemptionpostcode");
            mapper.AddDataColumnMap((r) => r.AddemptionOfTraderSeatChange.Address.ForeignPlace, "addemptionforeignplace");
            mapper.AddDataColumnMap((r) => r.AddemptionOfTraderSeatChange.Address.HousingEstate, "addemptionhousingestate");
            mapper.AddDataColumnMap((r) => r.AddemptionOfTraderSeatChange.Address.Street, "addemptionstreet");
            mapper.AddDataColumnMap((r) => r.AddemptionOfTraderSeatChange.Address.StreetNumber, "addemptionstreetnumber");
            mapper.AddDataColumnMap((r) => r.AddemptionOfTraderSeatChange.Address.Block, "addemptionblock");
            mapper.AddDataColumnMap((r) => r.AddemptionOfTraderSeatChange.Address.Entrance, "addemptionentrance");
            mapper.AddDataColumnMap((r) => r.AddemptionOfTraderSeatChange.Address.Floor, "addemptionfloor");
            mapper.AddDataColumnMap((r) => r.AddemptionOfTraderSeatChange.Address.Apartment, "addemptionapartment");
            mapper.AddDataColumnMap((r) => r.AddemptionOfTraderSeatChange.Contacts.Phone, "addemptioncontactsphone");
            mapper.AddDataColumnMap((r) => r.AddemptionOfTraderSeatChange.Contacts.Fax, "addemptioncontactsfax");
            mapper.AddDataColumnMap((r) => r.AddemptionOfTraderSeatChange.Contacts.EMail, "addemptioncontactsemail");
            mapper.AddDataColumnMap((r) => r.AddemptionOfTraderSeatChange.Contacts.URL, "addemptioncontactsurl");
            mapper.AddDataColumnMap((r) => r.AddemptionOfTraderSeatChange.CompetentAuthorityForRegistration, "addemptioncompetentauthority");
            mapper.AddDataColumnMap((r) => r.AddemptionOfTraderSeatChange.RegistrationNumber, "addemptionregistrationnumber");

            mapper.AddDataRowMap((r) => r.Shares, (dr) => dr.GetChildRows("SharesForCompany"));
            mapper.AddDataColumnMap((r) => r.Shares[0].Type, "sharetype");
            mapper.AddDataColumnMap((r) => r.Shares[0].Count, "sharecount");
            mapper.AddDataColumnMap((r) => r.Shares[0].NominalValue, "sharenominalvalue");

            mapper.AddDataRowMap((r) => r.NonMonetaryDeposits, (dr) => dr.GetChildRows("NonMonetaryDepositsForCompany"));
            mapper.AddDataColumnMap((r) => r.NonMonetaryDeposits[0].Description, "nonmonetarydeposit");
            mapper.AddDataColumnMap((r) => r.NonMonetaryDeposits[0].Value, "nonmonetarydepositvalue");

            mapper.AddDataRowMap((r) => r.Details, (dr) => dr.GetChildRows("DetailsForCompany"));
            mapper.AddDataColumnMap((r) => r.Details[0].FieldName, "field_name");
            mapper.AddDataColumnMap((r) => r.Details[0].Subject.Name, "name");
            mapper.AddDataColumnMap((r) => r.Details[0].Subject.IndentType, "ident_type");
            mapper.AddDataColumnMap((r) => r.Details[0].Subject.Indent, "ident");
            mapper.AddDataColumnMap((r) => r.Details[0].FieldCode, "field_code");
            mapper.AddDataColumnMap((r) => r.Details[0].FieldOrder, "field_order");

            return mapper;
        }

        public CommonSignedResponse<ValidUICRequestType, ValidUICResponseType> GetValidUICInfo(ValidUICRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
            try
            {
            OracleConnection connection = new OracleConnection(ConnectionString.Value);
            DataSet ds = new DataSet();

            OracleCommand command = new OracleCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.CommandText =
                   @"SELECT deed_status,
                            uic,
                            company_name,
                            legal_form_name,
                            legal_form_abbr
                        FROM " + MViewsUser.Value + @".egov_valid_uic t
                        WHERE uic = :p_uic";
            command.Parameters.Add(new OracleParameter("p_uic", OracleDbType.Varchar2, argument.UIC, ParameterDirection.Input));
            OracleDataAdapter da = new OracleDataAdapter(command);

            ds.Tables.Add("ValidUIC");
            DateTime? validDate = null;
            try
            {
                connection.Open();
                da.Fill(ds.Tables["ValidUIC"]);
                validDate = GetValidDate(connection);
            }
            finally
            {
                connection.Close();
            }

            ValidUICResponseType result = new ValidUICResponseType();
            DataSetMapper<ValidUICResponseType> mapper = CreateValidUICMap(accessMatrix, validDate);

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

        private DataSetMapper<ValidUICResponseType> CreateValidUICMap(AccessMatrix accessMatrix, DateTime? validDate)
        {
            DataSetMapper<ValidUICResponseType> mapper = new DataSetMapper<ValidUICResponseType>(accessMatrix);

            mapper.AddDataSetObjectInitializer((ds) => (ds.Tables["ValidUIC"].Rows.Count == 1) ? ds.Tables["ValidUIC"].Rows[0] : null);
            if (validDate.HasValue)
            {
                mapper.AddConstantMap<DateTime>((r) => r.DataValidForDate, validDate.Value);
            }
            mapper.AddDataColumnMap((r) => r.Status, "deed_status", (o) =>
            {
                if (o != null && o != System.DBNull.Value)
                {
                    StatusType result;
                    switch (o.ToString())
                    {
                        case "N":
                            result = StatusType.Новапартида;
                            break;
                        case "E":
                            result = StatusType.Пререгистриранапартида;
                            break;
                        case "C":
                            result = StatusType.Новазакритапартида;
                            break;
                        case "L":
                            result = StatusType.Пререгистрираназакритапартида;
                            break;
                        default:
                            return o;
                    }
                    return result;
                }
                else
                {
                    return o;
                }
            });
            mapper.AddDataColumnMap((r) => r.UIC, "uic");
            mapper.AddDataColumnMap((r) => r.Company, "company_name");
            mapper.AddDataColumnMap((r) => r.LegalForm.LegalFormName, "legal_form_name");
            mapper.AddDataColumnMap((r) => r.LegalForm.LegalFormAbbr, "legal_form_abbr");

            return mapper;
        }

        public CommonSignedResponse<SearchParticipationInCompaniesRequestType, SearchParticipationInCompaniesResponseType> PersonInCompaniesSearch(SearchParticipationInCompaniesRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
            try
        {

            OracleConnection connection = new OracleConnection(ConnectionString.Value);
            DataSet ds = new DataSet();

            OracleCommand commandPerson = new OracleCommand();
            commandPerson.Connection = connection;
            commandPerson.CommandType = CommandType.Text;
            commandPerson.CommandText =
                   @"SELECT t.name,
                            t.ident,
                            t.ident_type
                       FROM " + MViewsUser.Value + @".EGOV_ACTUAL_STATE_DETAILS t
                      WHERE t.ident = :p_egn
                        AND ident_type = 'EGN'
                        AND rownum = 1 ";
            commandPerson.Parameters.Add(new OracleParameter("p_egn", OracleDbType.Varchar2, argument.EGN, ParameterDirection.Input));


            OracleCommand commandCompanies = new OracleCommand();
            commandCompanies.Connection = connection;
            commandCompanies.CommandType = CommandType.Text;
            commandCompanies.CommandText =
                    @"SELECT DISTINCT v.uic,
                                        v.company_name,
                                        v.legal_form_name as form_name,
                                        v.legal_form_abbr,
                                        v.deed_id,
                                        t.ident
                          FROM " + MViewsUser.Value + @".egov_actual_state_details t
                          JOIN " + MViewsUser.Value + @".egov_valid_uic v
                            ON t.deed_id = v.deed_id
                         WHERE t.ident_type = 'EGN'
                           AND t.ident = :p_egn";
            commandCompanies.Parameters.Add(new OracleParameter("p_egn", OracleDbType.Varchar2, argument.EGN, ParameterDirection.Input));

            OracleCommand commandFields = new OracleCommand();
            commandFields.Connection = connection;
            commandFields.CommandType = CommandType.Text;
            commandFields.CommandText =
                    @"SELECT t.field_name,
                             t.deed_id,
                             t.ident
                        FROM " + MViewsUser.Value + @".egov_actual_state_details t
                       WHERE t.ident = :p_egn";
            commandFields.Parameters.Add(new OracleParameter("p_egn", OracleDbType.Varchar2, argument.EGN, ParameterDirection.Input));

            OracleDataAdapter daPerson = new OracleDataAdapter(commandPerson);
            OracleDataAdapter daCompanies = new OracleDataAdapter(commandCompanies);
            OracleDataAdapter daFields = new OracleDataAdapter(commandFields);

            ds.Tables.Add("Persons");
            ds.Tables.Add("Companies");
            ds.Tables.Add("Fields");
            DateTime? validDate = null;
            try
            {
                connection.Open();
                daPerson.Fill(ds.Tables["Persons"]);
                daCompanies.Fill(ds.Tables["Companies"]);
                daFields.Fill(ds.Tables["Fields"]);

                ds.Relations.Add("CompaniesForPerson",
                                ds.Tables["Persons"].Columns["ident"],
                                ds.Tables["Companies"].Columns["ident"]);

                ds.Relations.Add("FieldsInCompany",
                                 new DataColumn[] 
                                 { 
                                     ds.Tables["Companies"].Columns["deed_id"], 
                                     ds.Tables["Companies"].Columns["ident"] 
                                 },
                                 new DataColumn[] 
                                 {
                                     ds.Tables["Fields"].Columns["deed_id"], 
                                     ds.Tables["Fields"].Columns["ident"] 
                                 });
                validDate = GetValidDate(connection);
            }
            finally
            {
                connection.Close();
            }

            bool isFound = ds.Tables["Persons"].Rows.Count > 0;
            SearchParticipationInCompaniesResponseType result = new SearchParticipationInCompaniesResponseType();
            if (isFound)
            {
                DataSetMapper<SearchParticipationInCompaniesResponseType> mapper = CreatePersonInCompaniesMap(accessMatrix, isFound, validDate);
                mapper.Map(ds, result);
            }
            else
            {
                ObjectMapper<object, SearchParticipationInCompaniesResponseType> mapper = NotFoundMap(accessMatrix, validDate);
                mapper.Map(new object(), result);
            }
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

        private static ObjectMapper<object, SearchParticipationInCompaniesResponseType> NotFoundMap(AccessMatrix accessMatrix, DateTime? validDate)
        {
            ObjectMapper<object, SearchParticipationInCompaniesResponseType> mapper = new ObjectMapper<object, SearchParticipationInCompaniesResponseType>(accessMatrix);
            mapper.AddConstantMap((o) => o.IsFound, false);
            if (validDate.HasValue)
            {
                mapper.AddConstantMap<DateTime>((r) => r.DataValidForDate, validDate.Value);
            }
            return mapper;
        }
        private DataSetMapper<SearchParticipationInCompaniesResponseType> CreatePersonInCompaniesMap(AccessMatrix accessMatrix, bool isFound, DateTime? validDate)
        {
            DataSetMapper<SearchParticipationInCompaniesResponseType> mapper = new DataSetMapper<SearchParticipationInCompaniesResponseType>(accessMatrix);

            mapper.AddConstantMap((r) => r.IsFound, true);
            if (validDate.HasValue)
            {
                mapper.AddConstantMap<DateTime>((r) => r.DataValidForDate, validDate.Value);
            }
            mapper.AddDataSetObjectInitializer((ds) => (ds.Tables["Persons"].Rows.Count == 1) ? ds.Tables["Persons"].Rows[0] : null);

            mapper.AddDataColumnMap((r) => r.PersonInformation.Indent, "ident");
            mapper.AddDataColumnMap((r) => r.PersonInformation.Name, "name");
            mapper.AddDataColumnMap((r) => r.PersonInformation.IndentType, "ident_type");

            mapper.AddDataRowMap((r) => r.CompanyParticipation, (dr) => dr.GetChildRows("CompaniesForPerson"));
            mapper.AddDataColumnMap((r) => r.CompanyParticipation[0].EIK, "uic");
            mapper.AddDataColumnMap((r) => r.CompanyParticipation[0].CompanyName, "company_name");
            mapper.AddDataColumnMap((r) => r.CompanyParticipation[0].LegalForm.LegalFormName, "form_name");
            mapper.AddDataColumnMap((r) => r.CompanyParticipation[0].LegalForm.LegalFormAbbr, "legal_form_abbr");


            mapper.AddFunctionMap<SearchParticipationInCompaniesResponseType, List<string>>(
                (r) => r.CompanyParticipation[0].Fields,
                (dr) => dr.GetChildRows("FieldsInCompany").Select(r => r["field_name"].ToString()).ToList()
            );


            return mapper;
        }
        private XmlElement ConvertRecordDataToXmlElement(string recordData)
        {
            XmlElement elemWithoutXmlDeclaration = DeedElement.OwnerDocument.CreateElement("record");
            elemWithoutXmlDeclaration.InnerXml = recordData;
            string recordTemplate = "<record xmlns=\"" + DeedElement.NamespaceURI + "\">" + elemWithoutXmlDeclaration.ChildNodes.OfType<XmlElement>().FirstOrDefault().OuterXml + "</record>";
            XmlElement elem_WithoutXmlDeclaration_WithProperNamespace = DeedElement.OwnerDocument.CreateElement("record2", DeedElement.OwnerDocument.DocumentElement.NamespaceURI);
            elem_WithoutXmlDeclaration_WithProperNamespace.InnerXml = recordTemplate;
            return (XmlElement)elem_WithoutXmlDeclaration_WithProperNamespace.FirstChild.FirstChild;
        }

        //private void SetRecordCommonAttributes(DataRow row, Type type, object obj)
        //{
        //    type.GetProperty("RecordID").SetValue(obj, Convert.ToInt32(row["record_id"]));
        //    type.GetProperty("GroupID").SetValue(obj, Convert.ToInt32(row["group_id"]));
        //    type.GetProperty("RecordIncomingNumber").SetValue(obj, row["incoming_id"].ToString());
        //}

        //private void SetFieldCommonAttributes(DataRow row, Type type, object obj)
        //{
        //    type.GetProperty("FieldIdent").SetValue(obj, row["field_ident"].ToString());
        // //   type.GetProperty("FieldOperation").SetValue(obj, FieldOperation.Add); //TODO operation_id ???
        //    type.GetProperty("FieldEntryNumber").SetValue(obj, row["entry_number"].ToString());
        //    type.GetProperty("FieldActionDate").SetValue(obj, Convert.ToDateTime(row["action_date"]));
        //}



        //private System.Reflection.PropertyInfo GetPropertyInfo(Type type, string targetName, string fieldIdentCode)
        //{
        //    if (type == typeof(SubDeedType))
        //    {
        //        string code;
        //        if (fieldIdentCode.StartsWith("1001"))
        //        {
        //            code = fieldIdentCode.Substring(0, 6);
        //        }
        //        else
        //        {
        //            code = fieldIdentCode.Substring(0, 5);
        //        }
        //        string propName = XMLSchemas.Constants.SubDeedFieldsPropertiesDict.Where(t => t.Key == code).FirstOrDefault().Value;
        //        return type.GetProperty(propName);
        //    }
        //    else
        //    {
        //        return type.GetProperty(targetName);
        //    }

        //}
        //private void SetObjectPropertyValue(object parentObj, XmlElement targetValue, DataRow row)
        //{
        //    try
        //    {
        //        System.Reflection.PropertyInfo currObjProp = GetPropertyInfo(parentObj.GetType(), targetValue.Name, row["field_ident"].ToString());
        //        Type currObjType = currObjProp.PropertyType;
        //        if (currObjType.IsGenericType && currObjType.Namespace == "System.Collections.Generic")
        //        {
        //            Type targetType = currObjType.GenericTypeArguments.First();
        //            if (targetType.GetProperty("RecordID") != null)
        //            {
        //                object listObject = currObjProp.GetValue(parentObj);
        //                if (listObject == null)
        //                {
        //                    listObject = Activator.CreateInstance(currObjProp.PropertyType);
        //                    currObjProp.SetValue(parentObj, listObject);
        //                }
        //                object targetObject = targetValue.Deserialize(targetType);
        //                SetRecordCommonAttributes(row, targetType, targetObject);
        //                if (targetType.GetProperty("FieldIdent") != null)
        //                {
        //                    SetFieldCommonAttributes(row, targetType, targetObject);
        //                }

        //                currObjType.GetMethod("Add").Invoke(listObject, new object[] { targetObject });

        //            }
        //            else
        //            {  
        //                object listObject = currObjProp.GetValue(parentObj);
        //                if (listObject == null)
        //                {
        //                    listObject = Activator.CreateInstance(currObjProp.PropertyType);
        //                    currObjProp.SetValue(parentObj, listObject);
        //                }
        //                object currObject = null;
        //                foreach (object listitem in (listObject as IEnumerable))
        //                {
        //                    currObject = listitem;
        //                }
        //                if(currObject == null)
        //                {
        //                    currObject = Activator.CreateInstance(targetType);
        //                    currObjType.GetMethod("Add").Invoke(listObject, new object[] { currObject });
        //                }

        //                if (targetType.GetProperty("FieldIdent") != null)
        //                {
        //                    SetFieldCommonAttributes(row, targetType, currObject);
        //                }
        //                SetObjectPropertyValue(currObject, targetValue, row);
        //            }
        //        }
        //        else
        //        {
        //            if (currObjType.GetProperty("RecordID") != null)
        //            {
        //                object targetObject = targetValue.Deserialize(currObjType);
        //                currObjProp.SetValue(parentObj, targetObject);
        //                SetRecordCommonAttributes(row, currObjType, targetObject);
        //                if (currObjType.GetProperty("FieldIdent") != null)
        //                {
        //                    SetFieldCommonAttributes(row, currObjType, targetObject);
        //                }
        //            }
        //            else
        //            {
        //                object currObject = Activator.CreateInstance(currObjType);
        //                currObjProp.SetValue(parentObj, currObject);
        //                if (currObjType.GetProperty("FieldIdent") != null)
        //                {
        //                    SetFieldCommonAttributes(row, currObjType, currObject);
        //                }
        //                SetObjectPropertyValue(currObject, targetValue, row);
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}
        //private void SetPropertyValue(DataRow row, SubDeedType subdeedObject, AccessMatrix accessMatrix)
        //{
        //    XmlElement propElem = ConvertRecordDataToXmlElement(row["record_data"].ToString());
        //    SetObjectPropertyValue(subdeedObject, propElem, row);            
        //}

        private void SetRecordValue(DataRow row, List<ActualStateV2.Record> recordsList, AccessMatrix accessMatrix)
        {
            XmlElement propElem = ConvertRecordDataToXmlElement(row["record_data"].ToString());
            ActualStateV2.Record rec = new ActualStateV2.Record();
            rec.RecordData = propElem;
            rec.RecordId = Convert.ToInt32(row["record_id"]);
            //rec.GroupId = Convert.ToInt32(row["group_id"]);
            rec.IncomingId = row["incoming_id"] != DBNull.Value ? Convert.ToInt32(row["incoming_id"]) : 0;
            rec.FieldIdent = row["field_ident"] != DBNull.Value ? row["field_ident"].ToString() : null;

            rec.MainField = new ActualStateV2.Field();

            rec.MainField.GroupId = row["main_field_GROUP_id"] != DBNull.Value ? Convert.ToInt32(row["main_field_GROUP_id"]) : 0;
            rec.MainField.GroupIdSpecified = row["main_field_GROUP_id"] != DBNull.Value ? true : false;
            rec.MainField.GroupName = row["main_field_group_name"] != DBNull.Value ? row["main_field_group_name"].ToString() : null;

            rec.MainField.SectionId = row["main_field_section_id"] != DBNull.Value ? Convert.ToInt32(row["main_field_section_id"]) : 0;
            rec.MainField.SectionIdSpecified = row["main_field_section_id"] != DBNull.Value ? true : false;
            rec.MainField.SectionName = row["main_field_section_name"] != DBNull.Value ? row["main_field_section_name"].ToString() : null;

            rec.MainField.MainFieldCode = row["main_field_code"] != DBNull.Value ? row["main_field_code"].ToString() : null;
            rec.MainField.MainFieldIdent = row["main_field_ident"] != DBNull.Value ? row["main_field_ident"].ToString() : null;
            rec.MainField.MainFieldIdentSpecified = row["main_field_ident"] != DBNull.Value ? true : false;
            rec.MainField.MainFieldName = row["main_field_name"] != DBNull.Value ? row["main_field_name"].ToString() : null;
            rec.FieldEntryNumber = row["entry_number"] != DBNull.Value ? row["entry_number"].ToString() : null; 
            rec.FieldActionDate = row["action_date"] != DBNull.Value ? Convert.ToDateTime(row["action_date"]) : DateTime.MinValue;
            recordsList.Add(rec);
        }        
        private ActualStateV2.LegalFormType GetLegalFormEnum(DataRow deedrow)
        {
            switch (Convert.ToInt32(deedrow["legal_form_id"]))
            {
                case 1: return ActualStateV2.LegalFormType.ET;
                case 2: return ActualStateV2.LegalFormType.SD;
                case 3: return ActualStateV2.LegalFormType.KD;
                case 4: return ActualStateV2.LegalFormType.OOD;
                case 5: return ActualStateV2.LegalFormType.AD;
                case 6: return ActualStateV2.LegalFormType.KDA;
                case 7: return ActualStateV2.LegalFormType.K;
                case 8: return ActualStateV2.LegalFormType.KCHT;
                case 9: return ActualStateV2.LegalFormType.TPP;
                case 10: return ActualStateV2.LegalFormType.EOOD;
                case 11: return ActualStateV2.LegalFormType.EAD;
                case 12: return ActualStateV2.LegalFormType.IAD;
                case 13: return ActualStateV2.LegalFormType.TPPD;
                case 14: return ActualStateV2.LegalFormType.TPPO;
                case 15: return ActualStateV2.LegalFormType.IEAD;
                case 16: return ActualStateV2.LegalFormType.EUIE;
                case 17: return ActualStateV2.LegalFormType.DEUIE;
                case 18: return ActualStateV2.LegalFormType.ED;
                case 19: return ActualStateV2.LegalFormType.EKD;
                case 20: return ActualStateV2.LegalFormType.LEKD;
                case 21: return ActualStateV2.LegalFormType.CHD;
                case 22: return ActualStateV2.LegalFormType.CHDU;
                case 23: return ActualStateV2.LegalFormType.CHDF;
                case 24: return ActualStateV2.LegalFormType.SDR;
                case 25: return ActualStateV2.LegalFormType.FOND;
                case 26: return ActualStateV2.LegalFormType.KLCHULNC;
                case 27: return ActualStateV2.LegalFormType.NCH;
                default: return ActualStateV2.LegalFormType.Item1;
                    //ET = 1, //	Едноличен търговец
                    //SD = 2, //	Събирателно дружество
                    //KD = 3, //	Командитно дружество
                    //OOD = 4, //	Дружество с ограничена отговорност
                    //EOOD = 10, //Еднолично Дружество с ограничена отговорност
                    //AD = 5, //	Акционерно дружество
                    //EAD = 11,// Еднолично Акционерно дружество
                    //IAD = 12,// Акционерно дружество със специално инвестиционна цел
                    //IEAD = 15,// Еднолично Акционерно дружество със специално инвестиционна цел
                    //KDA = 6, //	Командитно дружество с акции
                    //K = 7, //	Кооперация
                    //KCHT = 8, //	Клон на чуждестранен търговец
                    //TPPD = 13,//	Търговец публично предприятие -държавно
                    //TPPO = 14,//	Търговец публично предприятие -общинско
                    //TPP = 9,//	Търговец публично предприятие да премехне и да се замени с горните две
                    //EUIE = 16,// Европейско обединение по икономически интереси ЕОИИ
                    //DEUIE = 17,// Поделение на ЕОИИ (Division Of EUIE)
                    //ED = 18,// Европейско дружество
                    //EKD = 19,// Европейско кооперативно дружество
                    //LEKD = 20 // Европейско кооперативно дружество с ограничена отговорност (Limited EKD)

            }
        }       

        private string CreateFiledsAMFilter(AccessMatrix am)
        {
            var fields = am.AMEntry.AccessMatrix.Where(t => t.Value.HasAccess);
            if (fields.Count() > 0)
            {
                return fields.Select(t => "'" + t.Key.Substring(6) + "'").Aggregate((a, b) => a + "," + b);
            }
            else
            {
                return "''";
            }
        }

        private string CreateFieldsArgumentFilter(string fieldList)
        {
            if (!string.IsNullOrEmpty(fieldList) && !string.IsNullOrWhiteSpace(fieldList))
            {
                var list = fieldList.Split(',').Where(t => !string.IsNullOrEmpty(t) && !string.IsNullOrWhiteSpace(t));
                if (list.Count() > 0)
                {
                    return "and (" + list.Select(field => "field_ident like '" + field.Trim() + "%'").Aggregate((a, b) => a + " or " + b) + ")";
                }
                else
                {
                    return string.Empty;
                }
            }
            else
            {
                return string.Empty;
            }
            
        }
        public CommonSignedResponse<ActualStateRequestV2, ActualStateResponseV2> GetActualStateV2(ActualStateRequestV2 argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.XmlSerialize(), Guid = id });
            try
            {
                string fieldsFilter = CreateFiledsAMFilter(accessMatrix);
                string fieldsArgumentORWhereclause = CreateFieldsArgumentFilter(argument.FieldList);

                OracleConnection connection = new OracleConnection(ConnectionString.Value);
                DataSet ds = new DataSet();

                OracleCommand command = new OracleCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText =
                       @"SELECT deed_id, 
                                deed_status, 
                                liquidation_or_insolvency, 
                                uic, 
                                company_name, 
                                transliterated_name, 
                                legal_form_name, 
                                legal_form_abbr, 
                                case_no, 
                                case_year, 
                                court_no, 
                                legal_form_id, 
                                guid
                        FROM " + MViewsUser.Value + @".egov_valid_uic t
                        WHERE uic = :p_uic";
                command.Parameters.Add(new OracleParameter("p_uic", OracleDbType.Varchar2, argument.UIC, ParameterDirection.Input));

                OracleDataAdapter da = new OracleDataAdapter(command);
                ds.Tables.Add("ValidUIC");

                OracleCommand commandRecords = new OracleCommand();
                commandRecords.Connection = connection;
                commandRecords.CommandType = CommandType.Text;
                commandRecords.CommandText =
                       @"select record_id record_id ,
                                deed_id deed_id ,
                                record_data record_data ,
                               -- a.status_id ,
                               -- a.operation_id ,
                                incoming_id incoming_id ,
                                incoming_app incoming_app,
                                field_ident field_ident ,
                               -- a.group_id ,
                               -- a.entry_date ,
                                action_date action_date ,
                                subdeed_id subdeed_id ,
                                uic,
                                entry_number entry_number,
                                group_id main_field_GROUP_id,
                                group_name main_field_group_name,
                                section_id main_field_section_id,
                                section_name main_field_section_name,
                                field_code main_field_code,
                                substr(a.field_ident, 1, 5) as main_field_ident,
                                field_name main_field_name
                        from  " + MViewsUser.Value + @".EGOV_ACTUAL_RECORDS a
                        where a.deed_id = :p_deed_id
                          and substr(a.field_ident, 1, 5) in (" + fieldsFilter + @")
                          " + fieldsArgumentORWhereclause + @"
                        order by a.field_ident, a.record_id";
                //commandRecords.Parameters.Add(new OracleParameter("p_uic", OracleDbType.Varchar2, argument.UIC, ParameterDirection.Input));
                
                OracleDataAdapter daRecords = new OracleDataAdapter(commandRecords);
                ds.Tables.Add("Records");
                bool isDeedFound = false;
                try
                {
                    connection.Open();
                    da.Fill(ds.Tables["ValidUIC"]);
                    isDeedFound = ds.Tables["ValidUIC"].Rows.Count > 0;
                    if (isDeedFound)
                    {
                        commandRecords.Parameters.Add(new OracleParameter("p_deed_id", OracleDbType.Int32, Convert.ToInt32(ds.Tables["ValidUIC"].Rows[0]["deed_id"]), ParameterDirection.Input));
                        daRecords.Fill(ds.Tables["Records"]);
                    }
                }
                finally
                {
                    connection.Close();
                }

                ActualStateResponseV2 result = new ActualStateResponseV2();
                if (isDeedFound)
                {
                    bool isFound = ds.Tables["Records"].Rows.Count > 0;

                    DataRow deedrow = ds.Tables["ValidUIC"].Rows[0];
                    result.Deed = new ActualStateV2.DeedType();
                    result.Deed.CompanyName = deedrow["company_name"].ToString();
                    result.Deed.DeedStatus = (ActualStateV2.DeedStatusType)Enum.Parse(typeof(ActualStateV2.DeedStatusType), deedrow["deed_status"].ToString());
                    result.Deed.LegalForm = GetLegalFormEnum(deedrow);
                    result.Deed.UIC = deedrow["uic"].ToString();
                    result.Deed.GUID = deedrow["guid"].ToString();
                    if (deedrow["liquidation_or_insolvency"] != DBNull.Value)
                    {
                        result.Deed.LiquidationOrInsolvency = (ActualStateV2.LiquidationOrInsolvency)Enum.Parse(typeof(ActualStateV2.LiquidationOrInsolvency), deedrow["liquidation_or_insolvency"].ToString());
                        result.Deed.LiquidationOrInsolvencySpecified = true;
                    }
                    result.Deed.CaseNo = deedrow["case_no"] != DBNull.Value ? deedrow["case_no"].ToString() : null;
                    result.Deed.CaseYear = deedrow["case_year"] != DBNull.Value ? deedrow["case_year"].ToString() : null;
                    result.Deed.CourtNo = deedrow["court_no"] != DBNull.Value ? deedrow["court_no"].ToString() : null;

                    result.DataValidForDate = DateTime.Now;
                    result.DataValidForDateSpecified = true;
                    if (isFound)
                    {   
                        List <ActualStateV2.Record> recordsList = new List<ActualStateV2.Record>();
                        foreach (DataRow rec in ds.Tables["Records"].Rows)
                        {
                            SetRecordValue(rec, recordsList, accessMatrix);
                        }
                        result.Deed.Records = recordsList;
                    }
                }
                else
                {
                    result.Deed = null;
                }
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

        public CommonSignedResponse<ActualStateRequestV3, ActualStateResponseV3> GetActualStateV3(ActualStateRequestV3 argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.XmlSerialize(), Guid = id });
            try
            {
                string fieldsFilter = CreateFiledsAMFilter(accessMatrix);
                string fieldsArgumentORWhereclause = CreateFieldsArgumentFilter(argument.FieldList);

                OracleConnection connection = new OracleConnection(ConnectionString.Value);
                DataSet ds = new DataSet();

                OracleCommand command = new OracleCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText =
                       @"SELECT deed_id, 
                                deed_status, 
                                liquidation_or_insolvency, 
                                uic, 
                                company_name, 
                                transliterated_name, 
                                legal_form_name, 
                                legal_form_abbr, 
                                case_no, 
                                case_year, 
                                court_no, 
                                legal_form_id, 
                                guid
                        FROM " + MViewsUser.Value + @".egov_valid_uic t
                        WHERE uic = :p_uic";
                command.Parameters.Add(new OracleParameter("p_uic", OracleDbType.Varchar2, argument.UIC, ParameterDirection.Input));

                OracleDataAdapter da = new OracleDataAdapter(command);
                ds.Tables.Add("ValidUIC");

                OracleCommand commandRecords = new OracleCommand();
                commandRecords.Connection = connection;
                commandRecords.CommandType = CommandType.Text;
                commandRecords.CommandText =
                       @"select record_id record_id ,
                                deed_id deed_id ,
                                record_data record_data ,
                               -- a.status_id ,
                               -- a.operation_id ,
                                incoming_id incoming_id ,
                                incoming_app incoming_app,
                                field_ident field_ident ,
                               -- a.group_id ,
                               -- a.entry_date ,
                                action_date action_date ,
                                subdeed_id subdeed_id ,
                                uic,
                                entry_number entry_number,
                                group_id main_field_GROUP_id,
                                group_name main_field_group_name,
                                section_id main_field_section_id,
                                section_name main_field_section_name,
                                field_code main_field_code,
                                substr(a.field_ident, 1, 5) as main_field_ident,
                                field_name main_field_name,
                                sub_uic sub_uic,
                                sub_uic_type sub_uic_type,
                                subdeed_status subdeed_status,
                                sub_uic_name sub_uic_name
                        from  " + MViewsUser.Value + @".EGOV_ACTUAL_RECORDS a
                        where a.deed_id = :p_deed_id
                          and substr(a.field_ident, 1, 5) in (" + fieldsFilter + @")
                          " + fieldsArgumentORWhereclause + @"
                        order by a.field_ident, a.record_id";
                //commandRecords.Parameters.Add(new OracleParameter("p_uic", OracleDbType.Varchar2, argument.UIC, ParameterDirection.Input));

                OracleDataAdapter daRecords = new OracleDataAdapter(commandRecords);

                //ds.Tables.Add("Sections");
                ds.Tables.Add("Records");

                bool isDeedFound = false;
                try
                {
                    connection.Open();
                    da.Fill(ds.Tables["ValidUIC"]);
                    isDeedFound = ds.Tables["ValidUIC"].Rows.Count > 0;
                    if (isDeedFound)
                    {
                        commandRecords.Parameters.Add(new OracleParameter("p_deed_id", OracleDbType.Int32, Convert.ToInt32(ds.Tables["ValidUIC"].Rows[0]["deed_id"]), ParameterDirection.Input));
                        daRecords.Fill(ds.Tables["Records"]);
                    }
                }
                finally
                {
                    connection.Close();
                }

                ActualStateResponseV3 result = new ActualStateResponseV3();
                if (isDeedFound)
                {
                    bool isFound = ds.Tables["Records"].Rows.Count > 0;

                    DataRow deedrow = ds.Tables["ValidUIC"].Rows[0];
                    result.Deed = new ActualStateV3.DeedType();
                    result.Deed.CompanyName = deedrow["company_name"].ToString();
                    result.Deed.DeedStatus = (ActualStateV3.DeedStatusType)Enum.Parse(typeof(ActualStateV3.DeedStatusType), deedrow["deed_status"].ToString());
                    result.Deed.LegalForm = ActualStateV3Helper.GetLegalFormEnumV3(deedrow);
                    result.Deed.UIC = deedrow["uic"].ToString();
                    result.Deed.GUID = deedrow["guid"].ToString();
                    if (deedrow["liquidation_or_insolvency"] != DBNull.Value)
                    {
                        result.Deed.LiquidationOrInsolvency = (ActualStateV3.LiquidationOrInsolvency)Enum.Parse(typeof(ActualStateV3.LiquidationOrInsolvency), deedrow["liquidation_or_insolvency"].ToString());
                        result.Deed.LiquidationOrInsolvencySpecified = true;
                    }
                    result.Deed.CaseNo = deedrow["case_no"] != DBNull.Value ? deedrow["case_no"].ToString() : null;
                    result.Deed.CaseYear = deedrow["case_year"] != DBNull.Value ? deedrow["case_year"].ToString() : null;
                    result.Deed.CourtNo = deedrow["court_no"] != DBNull.Value ? deedrow["court_no"].ToString() : null;

                    result.DataValidForDate = DateTime.Now;
                    result.DataValidForDateSpecified = true;

                    result.DataFound = true;
                    result.DataFoundSpecified = true;

                    if (isFound)
                    {

                        var records = ds.Tables["Records"].AsEnumerable();

                        var subdeedGroups = records.GroupBy(r => r["subdeed_id"]);
                        result.Deed.Subdeeds = new Subdeeds();
                        result.Deed.Subdeeds.Subdeed = new List<Subdeed>();
                        foreach(var grp in subdeedGroups)
                        {
                            List<ActualStateV3.Record> recordsList = new List<ActualStateV3.Record>();


                            Subdeed subdeedRecord = new Subdeed();

                            var row = grp.FirstOrDefault();

                            if (row["sub_uic_type"] != DBNull.Value)
                            {
                                subdeedRecord.SubUICType = ActualStateV3Helper.GetSubUICTypeEnumValue(row);
                                subdeedRecord.SubUICTypeSpecified = true;
                            }
                            else
                            {
                                subdeedRecord.SubUICTypeSpecified = false;
                            }

                            if (row["subdeed_status"] != DBNull.Value)
                            {
                                subdeedRecord.SubdeedStatus = (ActualStateV3.SubdeedStatusType)Enum.Parse(typeof(ActualStateV3.SubdeedStatusType), row["subdeed_status"].ToString());
                                subdeedRecord.SubdeedStatusSpecified = true;
                            }
                            else
                            {
                                subdeedRecord.SubdeedStatusSpecified = false;
                            }

                            //subdeedRecord.SubdeedStatus = row["subdeed_status"] != DBNull.Value ? row["subdeed_status"].ToString() : null;
                            subdeedRecord.SubUIC = row["sub_uic"] != DBNull.Value ? row["sub_uic"].ToString() : null;
                            subdeedRecord.SubUICName = row["sub_uic_name"] != DBNull.Value ? row["sub_uic_name"].ToString() : null;
                            //subdeedRecord.SubUICType = row["sub_uic_type"] != DBNull.Value ? row["sub_uic_type"].ToString() : null;

                            foreach (DataRow rec in grp)
                            {
                                ActualStateV3Helper.SetRecordValueV3(rec, recordsList);
                            }

                            subdeedRecord.Records = recordsList;

                            result.Deed.Subdeeds.Subdeed.Add(subdeedRecord);
                        }

                    }
                }
                else
                {
                    result.Deed = null;

                    result.DataValidForDate = DateTime.Now;
                    result.DataValidForDateSpecified = true;

                    result.DataFound = false;
                    result.DataFoundSpecified = true;
                }
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

        public CommonSignedResponse<GetBranchOfficeRequest, GetBranchOfficeResponse> GetBranchOffice(GetBranchOfficeRequest argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.XmlSerialize(), Guid = id });
            try
            {
                string fieldsFilter = CreateFiledsAMFilter(accessMatrix);
                //string fieldsArgumentORWhereclause = CreateFieldsArgumentFilter(argument.FieldList);

                if(string.IsNullOrEmpty(argument.UIC) || argument.UIC.Length != 13)
                {
                    throw new ArgumentException("Invalid length of UIC. UIC of branch company must be 13 symbols long.");
                }

                string uic = argument.UIC.Substring(0, 9);
                string sub_uic = argument.UIC.Substring(9);

                OracleConnection connection = new OracleConnection(ConnectionString.Value);
                DataSet ds = new DataSet();

                OracleCommand command = new OracleCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText =
                       @"SELECT deed_id, 
                                deed_status, 
                                liquidation_or_insolvency, 
                                uic, 
                                company_name, 
                                transliterated_name, 
                                legal_form_name, 
                                legal_form_abbr, 
                                case_no, 
                                case_year, 
                                court_no, 
                                legal_form_id, 
                                guid
                        FROM " + MViewsUser.Value + @".egov_valid_uic t
                        WHERE uic = :p_uic";
                command.Parameters.Add(new OracleParameter("p_uic", OracleDbType.Varchar2, uic, ParameterDirection.Input));

                OracleDataAdapter da = new OracleDataAdapter(command);
                ds.Tables.Add("ValidUIC");

                OracleCommand commandRecords = new OracleCommand();
                commandRecords.Connection = connection;
                commandRecords.CommandType = CommandType.Text;
                commandRecords.CommandText =
                       @"select record_id record_id ,
                                deed_id deed_id ,
                                record_data record_data ,
                               -- a.status_id ,
                               -- a.operation_id ,
                                incoming_id incoming_id ,
                                incoming_app incoming_app,
                                field_ident field_ident ,
                               -- a.group_id ,
                               -- a.entry_date ,
                                action_date action_date ,
                                subdeed_id subdeed_id ,
                                uic,
                                entry_number entry_number,
                                group_id main_field_GROUP_id,
                                group_name main_field_group_name,
                                section_id main_field_section_id,
                                section_name main_field_section_name,
                                field_code main_field_code,
                                substr(a.field_ident, 1, 5) as main_field_ident,
                                field_name main_field_name,
                                sub_uic sub_uic,
                                sub_uic_type sub_uic_type,
                                subdeed_status subdeed_status,
                                sub_uic_name sub_uic_name
                        from  " + MViewsUser.Value + @".EGOV_ACTUAL_RECORDS a
                        where a.deed_id = :p_deed_id
                          and (a.sub_uic_type = 1 or (a.sub_uic_type = 3 and a.sub_uic = :p_sub_uic))
                          and substr(a.field_ident, 1, 5) in (" + fieldsFilter + @")
                        order by a.field_ident, a.record_id";

                OracleDataAdapter daRecords = new OracleDataAdapter(commandRecords);
                ds.Tables.Add("Records");
                bool isDeedFound = false;
                try
                {
                    connection.Open();
                    da.Fill(ds.Tables["ValidUIC"]);
                    isDeedFound = ds.Tables["ValidUIC"].Rows.Count > 0;
                    if (isDeedFound)
                    {
                        commandRecords.Parameters.Add(new OracleParameter("p_deed_id", OracleDbType.Int32, Convert.ToInt32(ds.Tables["ValidUIC"].Rows[0]["deed_id"]), ParameterDirection.Input));
                        commandRecords.Parameters.Add(new OracleParameter("p_sub_uic", OracleDbType.Varchar2, sub_uic, ParameterDirection.Input));
                        daRecords.Fill(ds.Tables["Records"]);
                    }
                }
                finally
                {
                    connection.Close();
                }

                GetBranchOfficeResponse result = new GetBranchOfficeResponse();
                if (isDeedFound)
                {
                    //Check if there are actual records found
                    bool isFound = ds.Tables["Records"].Rows.Count > 0;

                    #region Типове раздели

                    //Типовете на разделите са:
                    //MainCircumstances = 1, //Основни данни
                    //B1_Procura = 2, //Прокура      
                    //B2_Branch = 3, //Клонове
                    //B3_Pledge_DD = 4,//Залог на дружествен дял
                    //B4_Pledge_TP = 5, //Залог на търговско предприятие
                    //B5_Distraint_DD = 6, //Запор върху дружествен дял
                    //B6_Liquidation = 7, //Ликвидация
                    //B7_ActualOwner = 500, //действителни собственици
                    //V1_Transfer = 8, //Прехвърляне
                    //V2_Conversion = 9, //Преобразуване
                    //V3_Reorganization_K = 10,//Преустройство
                    //Bankruptcy = 11, //Несъстоятелност
                    //G1_ActAnnouncement = 13,//Обявени актове
                    //AdditionalCircumstances = 15, //специален предмет на дейност

                    #endregion

                    //Проверка дали има записи от раздел Клонове
                    bool isBranchFound = ds.Tables["Records"].Select("sub_uic_type=3").Count() > 0;

                    //TODO: Какво да се връща, когато не е намерен резултат за клонове, а само за основното дружество - дали да се връща основното дружество
                    if (isFound && isBranchFound)
                    {
                        DataRow deedrow = ds.Tables["ValidUIC"].Rows[0];
                        result.Deed = new ActualStateV3.DeedType();
                        result.Deed.CompanyName = deedrow["company_name"].ToString();
                        result.Deed.DeedStatus = (ActualStateV3.DeedStatusType)Enum.Parse(typeof(ActualStateV3.DeedStatusType), deedrow["deed_status"].ToString());
                        result.Deed.LegalForm = ActualStateV3Helper.GetLegalFormEnumV3(deedrow);
                        result.Deed.UIC = deedrow["uic"].ToString();
                        result.Deed.GUID = deedrow["guid"].ToString();
                        if (deedrow["liquidation_or_insolvency"] != DBNull.Value)
                        {
                            result.Deed.LiquidationOrInsolvency = (ActualStateV3.LiquidationOrInsolvency)Enum.Parse(typeof(ActualStateV3.LiquidationOrInsolvency), deedrow["liquidation_or_insolvency"].ToString());
                            result.Deed.LiquidationOrInsolvencySpecified = true;
                        }
                        result.Deed.CaseNo = deedrow["case_no"] != DBNull.Value ? deedrow["case_no"].ToString() : null;
                        result.Deed.CaseYear = deedrow["case_year"] != DBNull.Value ? deedrow["case_year"].ToString() : null;
                        result.Deed.CourtNo = deedrow["court_no"] != DBNull.Value ? deedrow["court_no"].ToString() : null;

                        result.DataValidForDate = DateTime.Now;
                        result.DataValidForDateSpecified = true;

                        result.DataFound = true;
                        result.DataFoundSpecified = true;

                        var records = ds.Tables["Records"].AsEnumerable();

                        var subdeedGroups = records.GroupBy(r => r["subdeed_id"]);
                        result.Deed.Subdeeds = new Subdeeds();
                        result.Deed.Subdeeds.Subdeed = new List<Subdeed>();
                        foreach (var grp in subdeedGroups)
                        {
                            List<ActualStateV3.Record> recordsList = new List<ActualStateV3.Record>();

                            Subdeed subdeedRecord = new Subdeed();

                            var row = grp.FirstOrDefault();

                            if (row["sub_uic_type"] != DBNull.Value)
                            {
                                subdeedRecord.SubUICType = ActualStateV3Helper.GetSubUICTypeEnumValue(row);
                                subdeedRecord.SubUICTypeSpecified = true;
                            }
                            else
                            {
                                subdeedRecord.SubUICTypeSpecified = false;
                            }

                            if (row["subdeed_status"] != DBNull.Value)
                            {
                                subdeedRecord.SubdeedStatus = (ActualStateV3.SubdeedStatusType)Enum.Parse(typeof(ActualStateV3.SubdeedStatusType), row["subdeed_status"].ToString());
                                subdeedRecord.SubdeedStatusSpecified = true;
                            }
                            else
                            {
                                subdeedRecord.SubdeedStatusSpecified = false;
                            }

                            //subdeedRecord.SubdeedStatus = row["subdeed_status"] != DBNull.Value ? row["subdeed_status"].ToString() : null;
                            subdeedRecord.SubUIC = row["sub_uic"] != DBNull.Value ? row["sub_uic"].ToString() : null;
                            subdeedRecord.SubUICName = row["sub_uic_name"] != DBNull.Value ? row["sub_uic_name"].ToString() : null;
                            //subdeedRecord.SubUICType = row["sub_uic_type"] != DBNull.Value ? row["sub_uic_type"].ToString() : null;

                            foreach (DataRow rec in grp)
                            {
                                ActualStateV3Helper.SetRecordValueV3(rec, recordsList);
                            }

                            subdeedRecord.Records = recordsList;

                            result.Deed.Subdeeds.Subdeed.Add(subdeedRecord);
                        }
                    }

                    else
                    {
                        result.Deed = null;

                        result.DataValidForDate = DateTime.Now;
                        result.DataValidForDateSpecified = true;

                        result.DataFound = false;
                        result.DataFoundSpecified = true;
                    }
                }
                else
                {
                    result.Deed = null;

                    result.DataValidForDate = DateTime.Now;
                    result.DataValidForDateSpecified = true;

                    result.DataFound = false;
                    result.DataFoundSpecified = true;
                }
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
    }
}
