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

namespace TechnoLogica.RegiX.GraoNBDAdapter.AdapterService
{
    [Export(typeof(IAdapterService))]
    [ExportFullName(typeof(NBDAdapter), typeof(IAdapterService))]
    [ExportSimpleName(typeof(NBDAdapter), typeof(IAdapterService))]
    //[XmlSerializerFormat]
    public class NBDAdapter : InformixAdapterService.InformixBaseAdapterService, INBDAdapter, IAdapterService
    {

        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(NBDAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> ConnectionString =
            new ParameterInfo<string>("Database=grao;Host=egov;Server=;Service=25852;Protocol=onsoctcp;User Id=informix;Password=;DB_LOCALE=en_US.57372")
            {
                Key = Constants.ConnectionStringParameterKeyName,
                Description = "Connection string for Informix",
                OwnerAssembly = typeof(NBDAdapter).Assembly
            };

        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(NBDAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> SchemaName =
            new ParameterInfo<string>("grao")
            {
                Key = "SchemaName",
                Description = "Name of the schema in database",
                OwnerAssembly = typeof(NBDAdapter).Assembly
            };
        
        public CommonSignedResponse<ValidPersonRequestType, ValidPersonResponseType> ValidPersonSearch(
            ValidPersonRequestType argument,
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
                command.CommandText = @"select trim(imes) imes,  
                                            trim(imeb) imeb, 
                                            trim(imef) imef, 
                                            dsm dsm, 
                                            trim(egn) egn 
                                       from regix_checkegn 
                                      where vegn = ?";
                command.Parameters.Add("egn", Utils.EGNtoVEGN(argument.EGN));
                IfxDataAdapter da = new IfxDataAdapter(command);
                DataSet ds = new DataSet();
                ds.Tables.Add("ValidPerson");
                try
                {
                    connection.Open();
                    da.Fill(ds.Tables["ValidPerson"]);
                }
                finally
                {
                    connection.Close();
                }
                DataSetMapper<ValidPersonResponseType> mapper = CreateValidPersonMap(accessMatrix);
                ValidPersonResponseType result = new ValidPersonResponseType();
                mapper.Map(ds, result);

                LogWarn(Utils.GetLogMessageForSuccessOperation(argument.EGN, aditionalParameters));

                return SigningUtils.CreateAndSign(
                   argument,
                   result,
                   accessMatrix,
                   aditionalParameters,
                   true
                   );
            }

            catch (Exception ex)
            {
                LogError(aditionalParameters, ex, new { Guid = id });
                throw ex;
            }
        }

        private static DataSetMapper<ValidPersonResponseType> CreateValidPersonMap(AccessMatrix accessMatrix)
        {
            DataSetMapper<ValidPersonResponseType> mapper = new DataSetMapper<ValidPersonResponseType>(accessMatrix);
            mapper.AddDataSetObjectInitializer((ds) => (ds.Tables["ValidPerson"].Rows.Count == 1) ? ds.Tables["ValidPerson"].Rows[0] : null);
            mapper.AddDataColumnMap((f) => f.FirstName, "imes");
            mapper.AddDataColumnMap((f) => f.SurName, "imeb");
            mapper.AddDataColumnMap((f) => f.FamilyName, "imef");
            mapper.AddDataColumnMap((f) => f.BirthDate, "egn", Conversions.EGNtoBirthDate);
            mapper.AddDataColumnMap((f) => f.DeathDate, "dsm");
            return mapper;
        }

        public CommonSignedResponse<RelationsRequestType, RelationsResponseType> RelationsSearch(
            RelationsRequestType argument,
            AccessMatrix accessMatrix, 
            AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.XmlSerialize(), Guid = id });
            try
            {
                string vegn = Utils.EGNtoVEGN(argument.EGN);
                IfxConnection connection = new IfxConnection(ConnectionString.Value);
                IfxCommand command = new IfxCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = @"SELECT
                                            rel_type rel_type, 
                                            trim(egnb)  as rel_egn, 
                                            trim(imes) imes, 
                                            trim(imeb) imeb, 
                                            trim(imef) imef, 
                                            dsm, 
                                            trim(pol) pol, 
                                            trim(gr) gr, 
                                            trim(gr_ime) gr_ime, 
                                            trim(gr2) gr2, 
                                            trim(gr2_ime) gr2_ime  
                                       from regix_getmother
                                      where vegn = ?
                                     union all
                                     SELECT 
                                            rel_type rel_type, 
                                            trim(egnb) as rel_egn , 
                                            trim(imes) imes, 
                                            trim(imeb) imeb, 
                                            trim(imef) imef, 
                                            dsm dsm, 
                                            trim(pol) pol, 
                                            trim(gr) gr, 
                                            trim(gr_ime) gr_ime, 
                                            trim(gr2) gr2, 
                                            trim(gr2_ime) gr2_ime
                                       from regix_getfather
                                      where vegn = ?
                                    union all 
                                    SELECT 
                                            case when rel_type = 5 and pol = 1 then 51 else 52 end as rel_type, 
                                            trim(egnc) as rel_egn, 
                                            trim(imes) imes, 
                                            trim(imeb) imeb, 
                                            trim(imef) imef, 
                                            dsm, 
                                            trim(pol) pol, 
                                            trim(gr) gr, 
                                            trim(gr_ime) gr_ime, 
                                            trim(gr2) gr2, 
                                            trim(gr2_ime) gr2_ime  
                                       FROM regix_getchildren
                                      where egnb = ? or egnm = ?
                                    union all 
                                      SELECT 
                                            case when pol = 1 then 51 else 52 end as rel_type, 
                                            trim(rodegn) as rel_egn, 
                                            trim(imes) imes, 
                                            trim(imeb) imeb, 
                                            trim(imef) imef, 
                                            case when trim(dsm) = '' or trim(dsm) is null then null::date
                                                else date(to_date(trim(dsm), '%d.%m.%Y')) end dsm, 
                                            trim(pol) pol, 
                                            trim(gr) gr, 
                                            trim(gr_ime) gr_ime, 
                                            trim(gr2) gr2, 
                                            trim(gr2_ime) gr2_ime  
                                       FROM regix_getrod
                                      where regix_getrod.rodvr = 'ДЕ' 
                                        and egn = ?
                                    union all 
                                     SELECT
                                            case when rel_type = 6 and pol = 1 then 61 else 62 end as rel_type, 
                                            trim(egns) as rel_egn, 
                                            trim(imes) imes, 
                                            trim(imeb) imeb, 
                                            trim(imef) imef, 
                                            dsm, 
                                            trim(pol) pol, 
                                            trim(gr) gr, 
                                            trim(gr_ime) gr_ime, 
                                            trim(gr2) gr2, 
                                            trim(gr2_ime) gr2_ime  
                                       FROM regix_getsiblings
                                      where vegn = ?
                                      order by rel_type";
                command.Parameters.Add("1", vegn);
                command.Parameters.Add("2", vegn);
                command.Parameters.Add("3", argument.EGN);
                command.Parameters.Add("4", argument.EGN);
                command.Parameters.Add("5", argument.EGN);
                command.Parameters.Add("6", vegn);
                IfxDataAdapter da = new IfxDataAdapter(command);
                DataSet ds = new DataSet();
                ds.Tables.Add("Relations");
                try
                {
                    connection.Open();
                    da.Fill(ds.Tables["Relations"]);
                }
                finally
                {
                    connection.Close();
                }
                DataSetMapper<RelationsResponseType> mapper = CreateRelationsMap(accessMatrix);
                RelationsResponseType result = new RelationsResponseType();
                mapper.Map(ds, result);
                LogWarn(Utils.GetLogMessageForSuccessOperation(argument.EGN, aditionalParameters));
                return SigningUtils.CreateAndSign(
                   argument,
                   result,
                   accessMatrix,
                   aditionalParameters,
                   true
                   );
            }
            catch (Exception ex)
            {
                LogError(aditionalParameters, ex, new { Guid = id });
                throw ex;
            }
        }

        private static DataSetMapper<RelationsResponseType> CreateRelationsMap(AccessMatrix accessMatrix)
        {
            DataSetMapper<RelationsResponseType> mapper = new DataSetMapper<RelationsResponseType>(accessMatrix);
            mapper.AddDataSetMap((r) => r.PersonRelations, (d) => d.Tables["Relations"].Rows);
            mapper.AddDataColumnMap((r) => r.PersonRelations[0].RelationCode, "rel_type", (o) =>
            {
                if (o != null && o != System.DBNull.Value)
                {
                    RelationType result;
                    switch (o.ToString())
                    {
                        case "1":
                            result = RelationType.Баща;
                            break;
                        case "2":
                            result = RelationType.Осиновител;
                            break;
                        case "3":
                            result = RelationType.Майка;
                            break;
                        case "4":
                            result = RelationType.Осиновителка;
                            break;
                        case "51":
                            result = RelationType.Син;
                            break;
                        case "52":
                            result = RelationType.Дъщеря;
                            break;
                        case "61":
                            result = RelationType.Брат;
                            break;
                        case "62":
                            result = RelationType.Сестра;
                            break;
                        default:
                            return null;
                    }
                    return result;
                }
                else
                {
                    return o;
                }
            });
            mapper.AddDataColumnMap((r) => r.PersonRelations[0].EGN, "rel_egn");
            mapper.AddDataColumnMap((r) => r.PersonRelations[0].BirthDate, "rel_egn", Conversions.EGNtoBirthDate);
            mapper.AddDataColumnMap((r) => r.PersonRelations[0].FirstName, "imes");
            mapper.AddDataColumnMap((r) => r.PersonRelations[0].SurName, "imeb");
            mapper.AddDataColumnMap((r) => r.PersonRelations[0].FamilyName, "imef");
            mapper.AddDataColumnMap((r) => r.PersonRelations[0].Gender.GenderCode, "pol");
            mapper.AddDataColumnMap((r) => r.PersonRelations[0].Gender.GenderName, "pol", ToGenderNameType);
            mapper.AddDataColumnMap((r) => r.PersonRelations[0].Nationality.NationalityCode, "gr");
            mapper.AddDataColumnMap((r) => r.PersonRelations[0].Nationality.NationalityName, "gr_ime");
            mapper.AddDataColumnMap((r) => r.PersonRelations[0].Nationality.NationalityCode2, "gr2");
            mapper.AddDataColumnMap((r) => r.PersonRelations[0].Nationality.NationalityName2, "gr2_ime");
            mapper.AddDataColumnMap((r) => r.PersonRelations[0].DeathDate, "dsm");
            return mapper;
        }

        public CommonSignedResponse<PersonDataRequestType, PersonDataResponseType> PersonDataSearch(
            PersonDataRequestType argument,
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
                command.CommandText = @"select first 1 trim(egn) egn, 
                                            trim(imes) imes, 
                                            trim(imeb) imeb, 
                                            trim(imef) imef, 
                                            trim(imes0) imes0, 
                                            trim(imesl) imesl, 
                                            trim(imebl) imebl, 
                                            trim(imefl) imefl, 
                                            trim(imesn) imesn, 
                                            trim(imebn) imebn, 
                                            trim(imefn) imefn, 
                                            trim(pol) pol, 
                                            trim(rjnm) rjnm, 
                                            trim(nm_ime) nm_ime, 
                                            trim(gr) gr, 
                                            trim(gr_ime) gr_ime, 
                                            trim(gr2) gr2, 
                                            trim(gr2_ime) gr2_ime, 
                                            dsm,
                                            rw
                                       from regix_getperson " +
                                         "where vegn = ?" + " order by rw desc";
                command.Parameters.Add("egn", Utils.EGNtoVEGN(argument.EGN));
                IfxDataAdapter da = new IfxDataAdapter(command);
                DataSet ds = new DataSet();
                ds.Tables.Add("PersonData");
                try
                {
                    connection.Open();
                    da.Fill(ds.Tables["PersonData"]);
                }
                finally
                {
                    connection.Close();
                }
                DataSetMapper<PersonDataResponseType> mapper = CreatePersonDataMap(accessMatrix);
                PersonDataResponseType result = new PersonDataResponseType();
                mapper.Map(ds, result);
                LogWarn(Utils.GetLogMessageForSuccessOperation(argument.EGN, aditionalParameters));
                return SigningUtils.CreateAndSign(
                    argument,
                    result,
                    accessMatrix,
                    aditionalParameters,
                    true
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
            if(Enum.TryParse(Utils.ToGenderNameType(o), out result))
            {
                return result;
            }
            else
            {
                return o;
            }
        };


        private static DataSetMapper<PersonDataResponseType> CreatePersonDataMap(AccessMatrix accessMatrix)
        {
            DataSetMapper<PersonDataResponseType> mapper = new DataSetMapper<PersonDataResponseType>(accessMatrix);
            mapper.AddDataSetObjectInitializer((ds) => (ds.Tables["PersonData"].Rows.Count == 1) ? ds.Tables["PersonData"].Rows[0] : null);
            mapper.AddDataColumnMap((f) => f.PersonNames.FirstName, "imes");
            mapper.AddDataColumnMap((f) => f.PersonNames.SurName, "imeb");
            mapper.AddDataColumnMap((f) => f.PersonNames.FamilyName, "imef");
            mapper.AddDataColumnMap((f) => f.Alias, "imes0");
            mapper.AddDataColumnMap((f) => f.LatinNames.FirstName, "imesl");
            mapper.AddDataColumnMap((f) => f.LatinNames.SurName, "imebl");
            mapper.AddDataColumnMap((f) => f.LatinNames.FamilyName, "imefl");
            mapper.AddDataColumnMap((f) => f.ForeignNames.FirstName, "imesn");
            mapper.AddDataColumnMap((f) => f.ForeignNames.SurName, "imebn");
            mapper.AddDataColumnMap((f) => f.ForeignNames.FamilyName, "imefn");
            mapper.AddDataColumnMap((f) => f.Gender.GenderCode, "pol");
            mapper.AddDataColumnMap((f) => f.Gender.GenderName, "pol", ToGenderNameType);
            mapper.AddDataColumnMap((f) => f.EGN, "egn");
            mapper.AddDataColumnMap((f) => f.BirthDate, "egn", Conversions.EGNtoBirthDate);
            mapper.AddDataColumnMap((f) => f.PlaceBirth, "nm_ime");
            mapper.AddDataColumnMap((f) => f.Nationality.NationalityCode, "gr");
            mapper.AddDataColumnMap((f) => f.Nationality.NationalityName, "gr_ime");
            mapper.AddDataColumnMap((f) => f.Nationality.NationalityCode2, "gr2");
            mapper.AddDataColumnMap((f) => f.Nationality.NationalityName2, "gr2_ime");
            mapper.AddDataColumnMap((f) => f.DeathDate, "dsm");
            return mapper;
        }
    }
}
