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

namespace TechnoLogica.RegiX.GraoNMAdapter.AdapterService
{
    [Export(typeof(IAdapterService))]
    [ExportFullName(typeof(NMAdapter), typeof(IAdapterService))]
    [ExportSimpleName(typeof(NMAdapter), typeof(IAdapterService))]
    public class NMAdapter : InformixAdapterService.InformixBaseAdapterService, INMAdapter, IAdapterService
    {

        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(NMAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> ConnectionString =
            new ParameterInfo<string>("Database=grao;Host=egov;Server=;Service=25852;Protocol=onsoctcp;UID=informix;Password=;DB_LOCALE=en_US.57372")
            {
                Key = Constants.ConnectionStringParameterKeyName,
                Description = "Connection string for Informix",
                OwnerAssembly = typeof(NMAdapter).Assembly
            };
        
        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(NMAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> SchemaName =
            new ParameterInfo<string>("grao")
            {
                Key = "SchemaName",
                Description = "Name of the schema in database",
                OwnerAssembly = typeof(NMAdapter).Assembly
            };

        public CommonSignedResponse<SettlementPlacesRequestType, SettlementPlacesResponseType> SettlementPlacesSearch(
            SettlementPlacesRequestType argument,
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
                command.CommandText = @"select trim(t.obl_kod) as obl_kod, 
                                           trim(t.obl_ime) as obl_ime, 
                                           trim(t.ob_kod) as ob_kod,
                                           trim(t.ob_ime) as ob_ime, 
                                           trim(t.nm_kod) as nm_kod,
                                           trim(t.nm_name) as nm_name,
                                           trim(t.nm_type) as nm_type
                                      from regix_getnmchange t
                                     where (? is null or t.change_type = ?)
                                       and t.nm_date between ? and ?
                                     order by obl_kod, obl_ime, ob_kod, ob_ime, nm_kod, nm_name";
                IfxParameter actualizationType1 = new IfxParameter();
                actualizationType1.IfxType = IfxType.VarChar;
                actualizationType1.DbType = DbType.String;
                actualizationType1.Value = argument.GetValueOrNull(r => r.ActualizationType);
                IfxParameter actualizationType2 = new IfxParameter();
                actualizationType2.IfxType = IfxType.VarChar;
                actualizationType2.DbType = DbType.String;
                actualizationType2.Value = argument.GetValueOrNull(r => r.ActualizationType);

                IfxParameter startDate = new IfxParameter();
                startDate.IfxType = IfxType.VarChar;
                startDate.DbType = DbType.String;
                startDate.Value = argument.StartDate.ToString("yyyyMMdd");


                IfxParameter endDate = new IfxParameter();
                endDate.IfxType = IfxType.VarChar;
                endDate.DbType = DbType.String;
                endDate.Value = argument.EndDate.ToString("yyyyMMdd");

                command.Parameters.Add(actualizationType1);
                command.Parameters.Add(actualizationType2);
                command.Parameters.Add(startDate);
                command.Parameters.Add(endDate);

                IfxDataAdapter da = new IfxDataAdapter(command);
                DataSet ds = new DataSet();
                ds.Tables.Add("SettlementPlaces");
                try
                {
                    connection.Open();
                    da.Fill(ds.Tables["SettlementPlaces"]);
                }
                finally
                {
                    connection.Close();
                }
                DataSetMapper<SettlementPlacesResponseType> settlementPlacesMapper = CreateLocationsMap(accessMatrix);
                SettlementPlacesResponseType result = new SettlementPlacesResponseType();
                settlementPlacesMapper.Map(ds, result);
                LogWarn(Utils.GetLogMessageForSuccessOperation(argument.StartDate.ToString(),
                    aditionalParameters,
                    String.Format("StartDate='{0}',EndDate='{1}',ActualizationType='{2}'",
                    argument.StartDate.ToString(),
                        argument.EndDate.ToString(),
                        (argument.ActualizationTypeSpecified ? argument.ActualizationType.ToString() : string.Empty))));
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

        private static DataSetMapper<SettlementPlacesResponseType> CreateLocationsMap(AccessMatrix accessMatrix)
        {
            DataSetMapper<SettlementPlacesResponseType> mapper = new DataSetMapper<SettlementPlacesResponseType>(accessMatrix);
            mapper.AddDataSetMap((r) => r.SettlementPlaces, (d) => d.Tables["SettlementPlaces"].Rows);
            mapper.AddDataColumnMap((r) => r.SettlementPlaces[0].DistrictCode, "obl_kod");
            mapper.AddDataColumnMap((r) => r.SettlementPlaces[0].DistrictName, "obl_ime");
            mapper.AddDataColumnMap((r) => r.SettlementPlaces[0].MunicipalityCode, "ob_kod");
            mapper.AddDataColumnMap((r) => r.SettlementPlaces[0].MunicipalityName, "ob_ime");
            mapper.AddDataColumnMap((r) => r.SettlementPlaces[0].SettlementPlaceCode, "nm_kod");
            mapper.AddDataColumnMap((r) => r.SettlementPlaces[0].SettlementPlaceName, "nm_name");
            mapper.AddDataColumnMap((r) => r.SettlementPlaces[0].SettlementTypeCode, "nm_type");
            mapper.AddDataColumnMap((r) => r.SettlementPlaces[0].SettlementTypeName, "nm_type", Utils.ToSettlementTypeName);
            return mapper;
        }
    }
}
