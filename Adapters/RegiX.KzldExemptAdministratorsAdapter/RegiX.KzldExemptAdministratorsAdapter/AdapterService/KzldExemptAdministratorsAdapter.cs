using System;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.Common.Utils;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Adapters.Common.DataContracts;
using TechnoLogica.RegiX.Common.DataContracts.Parameter;
using TechnoLogica.RegiX.Adapters.Common.ObjectMapping;

namespace TechnoLogica.RegiX.KzldExemptAdministratorsAdapter.AdapterService
{
    [Export(typeof(IAdapterService))]
    [ExportFullName(typeof(KzldExemptAdministratorsAdapter), typeof(IAdapterService))]
    [ExportSimpleName(typeof(KzldExemptAdministratorsAdapter), typeof(IAdapterService))]
    public class KzldExemptAdministratorsAdapter : OracleAdapterService.OracleBaseAdapterService, IKzldExemptAdministratorsAdapter, IAdapterService
    {
        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(KzldExemptAdministratorsAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> ConnectionString =
            new ParameterInfo<string>(@"Data Source=;User ID=;Password=;")
            {
                Key = Constants.ConnectionStringParameterKeyName,
                Description = "Connection String for Oracle datatabase",
                OwnerAssembly = typeof(KzldExemptAdministratorsAdapter).Assembly
            };

        public CommonSignedResponse<ExemptRegistrationRequestType, ExemptRegistrationAdministratorResponse> GetExemptRegistrationAdministrator(ExemptRegistrationRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
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
//                                      regix_interface.list_exempt(p_eik => :p_eik,
//                                                                  o_pdc_data => :o_pdc_data);
//                                    END;";

//                command.Parameters.Add("p_eik", argument.PersonalDataControllerID);
                command.CommandText = "regix_interface.list_exempt";
                command.Parameters.Add(new OracleParameter("p_eik", OracleDbType.Varchar2, argument.PersonalDataControllerID, ParameterDirection.Input));

                OracleParameter pdc_data = new OracleParameter();
                pdc_data.Direction = ParameterDirection.Output;
                pdc_data.ParameterName = "o_pdc_data";
                pdc_data.OracleDbType = OracleDbType.RefCursor;
                command.Parameters.Add(pdc_data);

                OracleDataAdapter resultDataSet = new OracleDataAdapter(command);
                //ds.Tables.Add(TableName);
                try
                {
                    connection.Open();
                    resultDataSet.Fill(ds);//.Tables[TableName]);

                }
                finally
                {
                    connection.Close();
                }

                DataSetMapper<ExemptRegistrationAdministratorResponse> mapper = CreateMap(accessMatrix, argument.PersonalDataControllerID);
                ExemptRegistrationAdministratorResponse result = new ExemptRegistrationAdministratorResponse();
                mapper.Map(ds, result);
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

        private DataSetMapper<ExemptRegistrationAdministratorResponse> CreateMap(AccessMatrix accessMatrix, string personalDataControllerID)
        {
            DataSetMapper<ExemptRegistrationAdministratorResponse> mapper = new DataSetMapper<ExemptRegistrationAdministratorResponse>(accessMatrix);

            mapper.AddDataSetObjectInitializer((ds) => (ds.Tables[0].Rows.Count == 1) ? ds.Tables[0].Rows[0] : null);

            mapper.AddDataColumnMap((r) => r.PDCExemptRegistrationData.Address, "ADDRESS");
            mapper.AddDataColumnMap((r) => r.PDCExemptRegistrationData.Identifier, "ID", (o) => o.ToString());
            mapper.AddDataColumnMap((r) => r.PDCExemptRegistrationData.LegalForm, "LAW_STATUS");
            mapper.AddDataColumnMap((r) => r.PDCExemptRegistrationData.LocationCode, "LOC_CODE", (o) => o.ToString());
            mapper.AddDataColumnMap((r) => r.PDCExemptRegistrationData.Location, "LOCATION");
            mapper.AddDataColumnMap((r) => r.PDCExemptRegistrationData.Name, "NAME");
            mapper.AddDataColumnMap(r => r.Protocol.ProtocolDate, "DECISION_DATE");
            mapper.AddDataColumnMap(r => r.Protocol.ProtocolNumber, "DECISION_NUMBER");
            mapper.AddDataColumnMap(r => r.LegalBasis, "DECISION_DESCRIPTION");
            return mapper;
        }      
    }
}
