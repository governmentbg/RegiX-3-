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

namespace TechnoLogica.RegiX.GraoLEAdapter.AdapterService
{
    [Export(typeof(IAdapterService))]
    [ExportFullName(typeof(LEAdapter), typeof(IAdapterService))]
    [ExportSimpleName(typeof(LEAdapter), typeof(IAdapterService))]
    public class LEAdapter : InformixAdapterService.InformixBaseAdapterService, ILEAdapter, IAdapterService
    {

        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(LEAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> ConnectionString =
            new ParameterInfo<string>("Database=;Host=;Server=;Service=25852;Protocol=onsoctcp;UID=informix;Password=;DB_LOCALE=en_US.57372")
            {
                Key = Constants.ConnectionStringParameterKeyName,
                Description = "Connection string for Informix",
                OwnerAssembly = typeof(LEAdapter).Assembly
            };

        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(LEAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> SchemaName =
            new ParameterInfo<string>("grao")
            {
                Key = "SchemaName",
                Description = "Name of the schema in database",
                OwnerAssembly = typeof(LEAdapter).Assembly
            };

        public CommonSignedResponse<LocationsRequestType, LocationsResponseType> LocationsSearch(
            LocationsRequestType argument,
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
                command.CommandText = @"select trim(t.nm_kod) as nm_kod, 
                                           trim(t.nm_ime) as nm_ime, 
                                           trim(t.le_kod) as le_kod, 
                                           trim(t.le_name) as le_name
                                      from regix_getlechange t
                                     where (? is null or t.change_type = ?)
                                       and t.le_date between ? and ?
                                     order by t.nm_kod, t.nm_ime, t.le_kod, t.le_name";

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
                ds.Tables.Add("Locations");
                try
                {
                    connection.Open();
                    da.Fill(ds.Tables["Locations"]);
                }
                finally
                {
                    connection.Close();
                }
                DataSetMapper<LocationsResponseType> locationsMapper = CreateLocationsMap(accessMatrix);
                LocationsResponseType result = new LocationsResponseType();
                locationsMapper.Map(ds, result);
                LogWarn(Utils.GetLogMessageForSuccessOperation(argument.StartDate.ToString(), 
                    aditionalParameters,
                    String.Format("EndDate='{1}',ActualizationType='{2}'",
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

        private static DataSetMapper<LocationsResponseType> CreateLocationsMap(AccessMatrix accessMatrix)
        {
            DataSetMapper<LocationsResponseType> locationsMapper = new DataSetMapper<LocationsResponseType>(accessMatrix);
            locationsMapper.AddDataSetMap((r) => r.Locations, (d) => d.Tables["Locations"].Rows);
            locationsMapper.AddDataColumnMap((r) => r.Locations[0].SettlementPlaceCode, "nm_kod");
            locationsMapper.AddDataColumnMap((r) => r.Locations[0].SettlementPlaceName, "nm_ime");
            locationsMapper.AddDataColumnMap((r) => r.Locations[0].LocationCode, "le_kod");
            locationsMapper.AddDataColumnMap((r) => r.Locations[0].LocationName, "le_name");
            return locationsMapper;
        }
    }
}
