using System;
using System.Linq;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.Common.Utils;
using System.Data;
using System.ComponentModel.Composition;
using Oracle.ManagedDataAccess.Client;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Adapters.Common.DataContracts;
using TechnoLogica.RegiX.Common.DataContracts.Parameter;
using TechnoLogica.RegiX.Adapters.Common.ObjectMapping;

namespace TechnoLogica.RegiX.KzldDeniedAdministratorsAdapter.AdapterService
{
    [Export(typeof(IAdapterService))]
    [ExportFullName(typeof(KzldDeniedAdministratorsAdapter), typeof(IAdapterService))]
    [ExportSimpleName(typeof(KzldDeniedAdministratorsAdapter), typeof(IAdapterService))]
    public class KzldDeniedAdministratorsAdapter : OracleAdapterService.OracleBaseAdapterService, IKzldDeniedAdministratorsAdapter, IAdapterService
    {
        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(KzldDeniedAdministratorsAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> ConnectionString =
            new ParameterInfo<string>(@"Data Source=;User ID=;Password=;")
            {
                Key = Constants.ConnectionStringParameterKeyName,
                Description = "Connection String for Oracle datatabase",
                OwnerAssembly = typeof(KzldDeniedAdministratorsAdapter).Assembly
            };

        public CommonSignedResponse<DeniedEntryAdministratorRequestType, DeniedEntryAdministratorResponse> GetRegisteredAdministratorByID(DeniedEntryAdministratorRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
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
//                command.CommandText = @"BEGIN
//                                      regix_interface.list_denied(p_eik => :p_eik,
//                                                                  o_pdc_data => :o_pdc_data);
//                                    END;";

//                command.Parameters.Add("p_eik", argument.PersonalDataControllerID);

                command.CommandText = "regix_interface.list_denied";
                command.Parameters.Add(new OracleParameter("p_eik", OracleDbType.Varchar2, argument.PersonalDataControllerID, ParameterDirection.Input));

                OracleParameter pdc_data = new OracleParameter();
                pdc_data.Direction = ParameterDirection.Output;
                pdc_data.ParameterName = "o_pdc_data";
                pdc_data.OracleDbType = OracleDbType.RefCursor;
                command.Parameters.Add(pdc_data);

                OracleDataAdapter resultDataSet = new OracleDataAdapter(command);
                try
                {
                    connection.Open();
                    resultDataSet.Fill(ds);

                }
                finally
                {
                    connection.Close();
                }

                DataSetMapper<DeniedEntryAdministratorResponse> mapper = CreateMap(accessMatrix, argument.PersonalDataControllerID);
                DeniedEntryAdministratorResponse result = new DeniedEntryAdministratorResponse();
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

        private DataSetMapper<DeniedEntryAdministratorResponse> CreateMap(AccessMatrix accessMatrix, string personalDataControllerID)
        {
            DataSetMapper<DeniedEntryAdministratorResponse> mapper = new DataSetMapper<DeniedEntryAdministratorResponse>(accessMatrix);

            mapper.AddDataSetObjectInitializer((ds) => (ds.Tables[0].Rows.Count == 1) ? ds.Tables[0].Rows[0] : null);

            mapper.AddDataColumnMap((r) => r.PDCDeniedEntryData.Address, "ADDRESS");
            mapper.AddDataColumnMap((r) => r.PDCDeniedEntryData.Identifier, "ID", (o) => o.ToString());
            mapper.AddDataColumnMap((r) => r.PDCDeniedEntryData.LegalForm, "LAW_STATUS");
            mapper.AddDataColumnMap((r) => r.PDCDeniedEntryData.Location, "LOCATION");
            mapper.AddDataColumnMap((r) => r.PDCDeniedEntryData.LocationCode, "LOC_CODE", (o) => o.ToString());
            mapper.AddDataColumnMap((r) => r.PDCDeniedEntryData.Name, "NAME");

            return mapper;
        }
    }
}
