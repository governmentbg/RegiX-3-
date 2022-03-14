using System;
using System.Linq;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.Common.Utils;
using System.Data;
using System.ComponentModel.Composition;
using Oracle.ManagedDataAccess.Client;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.OracleAdapterService;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Adapters.Common.DataContracts;
using TechnoLogica.RegiX.Common.DataContracts.Parameter;
using TechnoLogica.RegiX.Adapters.Common.ObjectMapping;

namespace TechnoLogica.RegiX.KzldAdministratorsAdapter.AdapterService
{
    [Export(typeof(IAdapterService))]
    [ExportFullName(typeof(KzldAdministratorsAdapter), typeof(IAdapterService))]
    [ExportSimpleName(typeof(KzldAdministratorsAdapter), typeof(IAdapterService))]
    public class KzldAdministratorsAdapter : OracleBaseAdapterService, IKzldAdministratorsAdapter, IAdapterService
    {
        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(KzldAdministratorsAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> ConnectionString =
            new ParameterInfo<string>(@"Data Source=;User ID=;Password=;")
            {
                Key = Constants.ConnectionStringParameterKeyName,
                Description = "Connection String for Oracle datatabase",
                OwnerAssembly = typeof(KzldAdministratorsAdapter).Assembly
            };

        public CommonSignedResponse<RegisteredAdministratorByIDType, RegisteredAdministratorByIDResponse> GetRegisteredAdministratorByID(RegisteredAdministratorByIDType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
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
                command.CommandText = "regix_interface.list_registered";
//                command.CommandText = @"BEGIN
//                                      regix_interface.list_registered(p_eik => :p_eik,
//                                                                      o_pdc_data => :o_pdc_data,
//                                                                      o_pdc_register => :o_pdc_register);
//                                    END;";

                //command.Parameters.Add("p_eik", argument.PersonalDataControllerID);
                command.Parameters.Add(new OracleParameter("p_eik", OracleDbType.Varchar2, argument.PersonalDataControllerID, ParameterDirection.Input));

                OracleParameter pdc_data = new OracleParameter();
                pdc_data.Direction = ParameterDirection.Output;
                pdc_data.ParameterName = "o_pdc_data";
                pdc_data.OracleDbType = OracleDbType.RefCursor;
                command.Parameters.Add(pdc_data);

                OracleParameter pdc_register = new OracleParameter();
                pdc_register.Direction = ParameterDirection.Output;
                pdc_register.ParameterName = "o_pdc_register";
                pdc_register.OracleDbType = OracleDbType.RefCursor;
                command.Parameters.Add(pdc_register);

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

                ds.Tables[0].TableName = "PDCData";
                ds.Tables[1].TableName = "RegisterData";

                OracleDataAdapter dataAdapter = new OracleDataAdapter(command);
                dataAdapter.Fill(ds.Tables["RegisterData"]);

                ds.Relations.Add("RegistersForPDC",
                    ds.Tables["PDCData"].Columns["ID"],
                    ds.Tables["RegisterData"].Columns["PDC_DATA_ID"]);

                DataSetMapper<RegisteredAdministratorByIDResponse> mapper = CreateMapById(accessMatrix, argument.PersonalDataControllerID);
                RegisteredAdministratorByIDResponse result = new RegisteredAdministratorByIDResponse();
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


        private DataSetMapper<RegisteredAdministratorByIDResponse> CreateMapById(AccessMatrix accessMatrix, string personalDataControllerID)
        {
            DataSetMapper<RegisteredAdministratorByIDResponse> mapper = new DataSetMapper<RegisteredAdministratorByIDResponse>(accessMatrix);

            mapper.AddDataSetObjectInitializer((ds) => (ds.Tables["PDCData"].Rows.Count == 1) ? ds.Tables["PDCData"].Rows[0] : null);

            mapper.AddDataColumnMap((r) => r.PDCData.Address, "ADDRESS");
            mapper.AddDataColumnMap((r) => r.PDCData.Identifier, "ID", (o) => o.ToString());
            mapper.AddDataColumnMap((r) => r.PDCData.LegalForm, "LAW_STATUS");
            mapper.AddDataColumnMap((r) => r.PDCData.Location, "LOCATION");
            mapper.AddDataColumnMap((r) => r.PDCData.LocationCode, "LOC_CODE", (o) => o.ToString());
            mapper.AddDataColumnMap((r) => r.PDCData.Name, "NAME");


            mapper.AddDataRowMap((r) => r.PDSRegisters, (dr) => dr.GetChildRows("RegistersForPDC"));

            mapper.AddDataColumnMap((r) => r.PDSRegisters[0].IndividualsCount, "PERSON_COUNT");
            mapper.AddDataColumnMap((r) => r.PDSRegisters[0].IndividualsCountText, "PERSON_COUNT_TEXT");
            mapper.AddDataColumnMap((r) => r.PDSRegisters[0].RegisterName, "REG_NAME");
            mapper.AddDataColumnMap((r) => r.PDSRegisters[0].UpdateDate, "DATE_MODIFIED");

            return mapper;
        }

        public CommonSignedResponse<RegisteredAdministratorByNumberType, RegisteredAdministratorByNumberResponse> GetRegisteredAdministratorByNumber(RegisteredAdministratorByNumberType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
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
//                                      regix_interface.list_registered(p_ident_num => :p_ident_num,
//                                                                      o_pdc_data => :o_pdc_data,
//                                                                      o_pdc_register => :o_pdc_register);
//                                    END;";

                //command.Parameters.Add("p_ident_num", argument.PDCRegisterNumber);
                command.CommandText = "regix_interface.list_registered";
                command.Parameters.Add(new OracleParameter("p_ident_num", OracleDbType.Varchar2, argument.PDCRegisterNumber, ParameterDirection.Input));


                OracleParameter pdc_data = new OracleParameter();
                pdc_data.Direction = ParameterDirection.Output;
                pdc_data.ParameterName = "o_pdc_data";
                pdc_data.OracleDbType = OracleDbType.RefCursor;
                command.Parameters.Add(pdc_data);

                OracleParameter pdc_register = new OracleParameter();
                pdc_register.Direction = ParameterDirection.Output;
                pdc_register.ParameterName = "o_pdc_register";
                pdc_register.OracleDbType = OracleDbType.RefCursor;
                command.Parameters.Add(pdc_register);

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

                ds.Tables[0].TableName = "PDCData";
                ds.Tables[1].TableName = "RegisterData";

                OracleDataAdapter dataAdapter = new OracleDataAdapter(command);
                dataAdapter.Fill(ds.Tables["RegisterData"]);

                ds.Relations.Add("RegistersForPDC",
                    ds.Tables["PDCData"].Columns["ID"],
                    ds.Tables["RegisterData"].Columns["PDC_DATA_ID"]);

                DataSetMapper<RegisteredAdministratorByNumberResponse> mapper = CreateMapByRegisterNumber(accessMatrix, argument.PDCRegisterNumber);
                RegisteredAdministratorByNumberResponse result = new RegisteredAdministratorByNumberResponse();
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

        private DataSetMapper<RegisteredAdministratorByNumberResponse> CreateMapByRegisterNumber(AccessMatrix accessMatrix, string registerNumber)
        {
            DataSetMapper<RegisteredAdministratorByNumberResponse> mapper = new DataSetMapper<RegisteredAdministratorByNumberResponse>(accessMatrix);

            mapper.AddDataSetObjectInitializer((ds) => (ds.Tables["PDCData"].Rows.Count == 1) ? ds.Tables["PDCData"].Rows[0] : null);

            mapper.AddConstantMap((r) => r.PDCRegisterNumer, registerNumber);

            mapper.AddDataColumnMap((r) => r.PDCData.Address, "ADDRESS");
            mapper.AddDataColumnMap((r) => r.PDCData.Identifier, "ID", (o) => o.ToString());
            mapper.AddDataColumnMap((r) => r.PDCData.LegalForm, "LAW_STATUS");
            mapper.AddDataColumnMap((r) => r.PDCData.Location, "LOCATION");
            mapper.AddDataColumnMap((r) => r.PDCData.LocationCode, "LOC_CODE", (o) => o.ToString());
            mapper.AddDataColumnMap((r) => r.PDCData.Name, "NAME");

            mapper.AddDataRowMap((r) => r.PDSRegisters, (dr) => dr.GetChildRows("RegistersForPDC"));

            mapper.AddDataColumnMap((r) => r.PDSRegisters[0].IndividualsCount, "PERSON_COUNT");
            mapper.AddDataColumnMap((r) => r.PDSRegisters[0].IndividualsCountText, "PERSON_COUNT_TEXT");
            mapper.AddDataColumnMap((r) => r.PDSRegisters[0].RegisterName, "REG_NAME");
            mapper.AddDataColumnMap((r) => r.PDSRegisters[0].UpdateDate, "DATE_MODIFIED");

            return mapper;
        }
    }
}
