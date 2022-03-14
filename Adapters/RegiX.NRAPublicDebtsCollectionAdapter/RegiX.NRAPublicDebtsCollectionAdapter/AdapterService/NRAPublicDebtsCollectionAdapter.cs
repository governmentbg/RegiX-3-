using Oracle.ManagedDataAccess.Client;
using TechnoLogica.RegiX.OracleAdapterService;
using System;
using System.ComponentModel.Composition;
using System.Globalization;
using System.Collections.Generic;
using TechnoLogica.RegiX.Adapters.Common.DataContracts;
using TechnoLogica.RegiX.Adapters.Common.ObjectMapping;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.DataContracts.Parameter;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.Common.Utils;
using System.Data;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;

namespace TechnoLogica.RegiX.NRAPublicDebtsCollectionAdapter.AdapterService
{
    [Export(typeof(IAdapterService))]
    [ExportFullName(typeof(NRAPublicDebtsCollectionAdapter), typeof(IAdapterService))]
    [ExportSimpleName(typeof(NRAPublicDebtsCollectionAdapter), typeof(IAdapterService))]
    public class NRAPublicDebtsCollectionAdapter : OracleBaseAdapterService, IAdapterService, INRAPublicDebtsCollectionAdapter
    {

        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(NRAPublicDebtsCollectionAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> ConnectionString =
            new ParameterInfo<string>(@"Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = )(PORT = 1521))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = RVD122)));User ID=IDS_DATA_NEW;Password=;")
            {
                Key = Constants.ConnectionStringParameterKeyName,
                Description = "Connection string",
                OwnerAssembly = typeof(NRAPublicDebtsCollectionAdapter).Assembly
            };

        public override string CheckRegisterConnection()
        {
            try
            {
                var connectionString = ConnectionString;
                if (connectionString != null && !String.IsNullOrEmpty(connectionString.CurrentValue))
                {
                    using (OracleConnection connection = new OracleConnection(connectionString.CurrentValue))
                    {
                        connection.Open();
                        return Constants.ConnectionOk;
                    };
                }
                else
                {
                    return Constants.ConnectionStringNotSet;
                }
            }
            catch (Exception ex)
            {
                return String.Format(Constants.ConnectionException, ex.Message);
            }
        }

        //RQ01: Предаване на информация за ново изпълнително основание (ИО) и вземане/вземания за събиране от взискател/актосъставител към Национална агенция за приходите (НАП)
        public CommonSignedResponse<SendDataForNewIOAndCollectionRequestType, SendDataForNewIOAndCollectionResponseType> SendDataForNewIOAndCollection(SendDataForNewIOAndCollectionRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
            try
            {
                #region Request
                OracleConnection connection = new OracleConnection(ConnectionString.Value);
                DataSet ds = new DataSet();
                OracleCommand command = new OracleCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = @"select t.*
                                        from vw_receive_data_RQ01 t
                                        where Auto_exch_info.Set_Params_DATA(
                                        :p_xml,
                                        :p_Administration_oID) = 1";


                var pXML = new OracleParameter("p_xml", OracleDbType.Clob, ParameterDirection.Input);
                pXML.Value = argument.XmlSerialize();
                command.Parameters.Add(pXML);

                var pAdministrationOID = new OracleParameter("p_Administration_oID", OracleDbType.Varchar2, ParameterDirection.Input);
                pAdministrationOID.Value = aditionalParameters.CallContext.AdministrationOId;
                command.Parameters.Add(pAdministrationOID);

                OracleDataAdapter resultDataSet = new OracleDataAdapter(command);
                #endregion
                #region Response 
                try
                {
                    connection.Open();
                    resultDataSet.Fill(ds);

                }
                finally
                {
                    connection.Close();
                }


                SendDataForNewIOAndCollectionResponseType result = new SendDataForNewIOAndCollectionResponseType();
                DataSetMapper<SendDataForNewIOAndCollectionResponseType> mapper = SendDataForNewIOAndCollectionDataMapper(accessMatrix);
                mapper.Map(ds, result);

                return SigningUtils.CreateAndSign(
                    argument,
                    result,
                    accessMatrix,
                    aditionalParameters
                );
                #endregion

            }
            catch (Exception ex)
            {
                LogError(aditionalParameters, ex, new { Guid = id });
                System.IO.File.AppendAllText("C://RegiX//NRAAdapters//public_debts_errors.txt", GetFullExceptionDetails(ex, true));

                throw ex;
            }
        }

        private DataSetMapper<SendDataForNewIOAndCollectionResponseType> SendDataForNewIOAndCollectionDataMapper(AccessMatrix accessMatrix)
        {
            DataSetMapper<SendDataForNewIOAndCollectionResponseType> mapper = new DataSetMapper<SendDataForNewIOAndCollectionResponseType>(accessMatrix);
            mapper.AddDataSetObjectInitializer((ds) => (ds.Tables[0].Rows.Count >= 1) ? ds.Tables[0].Rows[0] : null);

            mapper.AddDataColumnMap((r) => r.Response.Status, "status");
            mapper.AddDataColumnMap((r) => r.Response.DateProcessed, "dateProcessed", (o) => DateTime.ParseExact(o.ToString(), "yyyy-MM-dd", CultureInfo.InvariantCulture));
            mapper.AddDataColumnMap((r) => r.Response.Errors.Code, "code", (o)=>
            {
                if (o == null || o == DBNull.Value)
                {
                    return new List<string>();
                }
                else
                { 
                List<string> codes = new List<string>();
                codes.AddRange(o.ToString().Split(','));
                    return codes;
                }
            });
            return mapper;
        }

        //RQ02: Предаване на информация за добавяне на ново вземане/вземания за събиране към вече подадено изпълнително основание (ИО)
        public CommonSignedResponse<SendDataForCollectionAdditionToIORequestType, SendDataForCollectionAdditionToIOResponseType> SendDataForCollectionAdditionToIO(SendDataForCollectionAdditionToIORequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
            try
            {
                #region Request
                OracleConnection connection = new OracleConnection(ConnectionString.Value);
                DataSet ds = new DataSet();
                OracleCommand command = new OracleCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = @"select t.*
                                        from  vw_receive_data_RQ02 t
                                        where  Auto_exch_info.Set_Params_DATA(
                                        :p_xml,
                                        :p_Administration_oID) = 1";

                var pXML = new OracleParameter("p_xml", OracleDbType.Clob, ParameterDirection.Input);
                pXML.Value = argument.XmlSerialize();
                command.Parameters.Add(pXML);

                var pAdministrationOID = new OracleParameter("p_Administration_oID", OracleDbType.Varchar2, ParameterDirection.Input);
                pAdministrationOID.Value = aditionalParameters.CallContext.AdministrationOId;
                command.Parameters.Add(pAdministrationOID);

                OracleDataAdapter resultDataSet = new OracleDataAdapter(command);
                #endregion
                #region Response 
                try
                {
                    connection.Open();
                    resultDataSet.Fill(ds);

                }
                finally
                {
                    connection.Close();
                }
                DataSetMapper<SendDataForCollectionAdditionToIOResponseType> mapper = SendDataForCollectionAdditionToIODataMapper(accessMatrix, argument);
                SendDataForCollectionAdditionToIOResponseType result = new SendDataForCollectionAdditionToIOResponseType();

                mapper.Map(ds, result);

                return SigningUtils.CreateAndSign(
                    argument,
                    result,
                    accessMatrix,
                    aditionalParameters
                );
                #endregion

            }
            catch (Exception ex)
            {
                LogError(aditionalParameters, ex, new { Guid = id });
                System.IO.File.AppendAllText("C://RegiX//NRAAdapters//public_debts_errors.txt", GetFullExceptionDetails(ex, true));
                throw ex;
            }
        }

        private DataSetMapper<SendDataForCollectionAdditionToIOResponseType> SendDataForCollectionAdditionToIODataMapper(AccessMatrix accessMatrix, SendDataForCollectionAdditionToIORequestType request)
        {
            DataSetMapper<SendDataForCollectionAdditionToIOResponseType> mapper = new DataSetMapper<SendDataForCollectionAdditionToIOResponseType>(accessMatrix);
            mapper.AddDataSetObjectInitializer((ds) => (ds.Tables[0].Rows.Count >= 1) ? ds.Tables[0].Rows[0] : null);

            mapper.AddDataColumnMap((r) =>  r.Response.Status, "status");
            mapper.AddDataColumnMap((r) => r.Response.DateProcessed, "dateProcessed", (o) => DateTime.ParseExact(o.ToString(), "yyyy-MM-dd", null));
            mapper.AddDataColumnMap((r) => r.Response.Errors.Code, "code", (o) =>
            {
                if (o == null || o == DBNull.Value)
                {
                    return new List<string>();
                }
                else
                {
                    List<string> codes = new List<string>();
                    codes.AddRange(o.ToString().Split(','));
                    return codes;
                }
            });
            return mapper;
        }

        //RQ03: Предаване на информация за корекция на данни за вземане
        public CommonSignedResponse<SendDataForCollectionDataCorrectionRequestType, SendDataForCollectionDataCorrectionResponseType> SendDataForCollectionDataCorrection(SendDataForCollectionDataCorrectionRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
            try
            {
                #region Request
                OracleConnection connection = new OracleConnection(ConnectionString.Value);
                DataSet ds = new DataSet();
                OracleCommand command = new OracleCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = @"select t.*
                                        from vw_receive_data_RQ03 t
                                        where Auto_exch_info.Set_Params_DATA(
                                        :p_xml,
                                        :p_Administration_oID) = 1";

                var pXML = new OracleParameter("p_xml", OracleDbType.Clob, ParameterDirection.Input);
                pXML.Value = argument.XmlSerialize();
                command.Parameters.Add(pXML);

                var pAdministrationOID = new OracleParameter("p_Administration_oID", OracleDbType.Varchar2, ParameterDirection.Input);
                pAdministrationOID.Value = aditionalParameters.CallContext.AdministrationOId;
                command.Parameters.Add(pAdministrationOID);

                OracleDataAdapter resultDataSet = new OracleDataAdapter(command);
                #endregion
                #region Response 
                try
                {
                    connection.Open();
                    resultDataSet.Fill(ds);

                }
                finally
                {
                    connection.Close();
                }
                DataSetMapper<SendDataForCollectionDataCorrectionResponseType> mapper = SendDataForCollectionDataCorrectionDataMapper(accessMatrix, argument);
                SendDataForCollectionDataCorrectionResponseType result = new SendDataForCollectionDataCorrectionResponseType();

                mapper.Map(ds, result);

                return SigningUtils.CreateAndSign(
                    argument,
                    result,
                    accessMatrix,
                    aditionalParameters
                );
                #endregion

            }
            catch (Exception ex)
            {
                LogError(aditionalParameters, ex, new { Guid = id });
                System.IO.File.AppendAllText("C://RegiX//NRAAdapters//public_debts_errors.txt", GetFullExceptionDetails(ex, true));
                throw ex;
            }
        }

        private DataSetMapper<SendDataForCollectionDataCorrectionResponseType> SendDataForCollectionDataCorrectionDataMapper(AccessMatrix accessMatrix, SendDataForCollectionDataCorrectionRequestType request)
        {
            DataSetMapper<SendDataForCollectionDataCorrectionResponseType> mapper = new DataSetMapper<SendDataForCollectionDataCorrectionResponseType>(accessMatrix);
            mapper.AddDataSetObjectInitializer((ds) => (ds.Tables[0].Rows.Count >= 1) ? ds.Tables[0].Rows[0] : null);
            mapper.AddDataColumnMap((r) =>  r.Response.Status, "status");
            mapper.AddDataColumnMap((r) => r.Response.DateProcessed, "dateProcessed", (o) => DateTime.ParseExact(o.ToString(), "yyyy-MM-dd", null));
            mapper.AddDataColumnMap((r) => r.Response.Errors.Code, "code", (o) =>
            {
                if (o == null || o == DBNull.Value)
                {
                    return new List<string>();
                }
                else
                {
                    List<string> codes = new List<string>();
                    codes.AddRange(o.ToString().Split(','));
                    return codes;
                }
            });
            return mapper;
        }

        //RQ04: Предаване на информация за обжалване на вземане към ИО при взискател/актосъставител
        public CommonSignedResponse<SendDataForCollectionAppealToIORequestType, SendDataForCollectionAppealToIOResponseType> SendDataForCollectionAppealToIO(SendDataForCollectionAppealToIORequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
            try
            {
                #region Request
                OracleConnection connection = new OracleConnection(ConnectionString.Value);
                DataSet ds = new DataSet();
                OracleCommand command = new OracleCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = @"select t.*
                                        from vw_receive_data_RQ04 t
                                        where Auto_exch_info.Set_Params_DATA(
                                        :p_xml,
                                        :p_Administration_oID) = 1";

                var pXML = new OracleParameter("p_xml", OracleDbType.Clob, ParameterDirection.Input);
                pXML.Value = argument.XmlSerialize();
                command.Parameters.Add(pXML);

                var pAdministrationOID = new OracleParameter("p_Administration_oID", OracleDbType.Varchar2, ParameterDirection.Input);
                pAdministrationOID.Value = aditionalParameters.CallContext.AdministrationOId;
                command.Parameters.Add(pAdministrationOID);

                OracleDataAdapter resultDataSet = new OracleDataAdapter(command);
                #endregion
                #region Response 
                try
                {
                    connection.Open();
                    resultDataSet.Fill(ds);

                }
                finally
                {
                    connection.Close();
                }
                DataSetMapper<SendDataForCollectionAppealToIOResponseType> mapper = SendDataForCollectionAppealToIODataMapper(accessMatrix, argument);
                SendDataForCollectionAppealToIOResponseType result = new SendDataForCollectionAppealToIOResponseType();

                mapper.Map(ds, result);

                return SigningUtils.CreateAndSign(
                    argument,
                    result,
                    accessMatrix,
                    aditionalParameters
                );
                #endregion

            }
            catch (Exception ex)
            {
                LogError(aditionalParameters, ex, new { Guid = id });
                System.IO.File.AppendAllText("C://RegiX//NRAAdapters//public_debts_errors.txt", GetFullExceptionDetails(ex, true));
                throw ex;
            }
        }

        private DataSetMapper<SendDataForCollectionAppealToIOResponseType> SendDataForCollectionAppealToIODataMapper(AccessMatrix accessMatrix, SendDataForCollectionAppealToIORequestType request)
        {
            DataSetMapper<SendDataForCollectionAppealToIOResponseType> mapper = new DataSetMapper<SendDataForCollectionAppealToIOResponseType>(accessMatrix);
            mapper.AddDataSetObjectInitializer((ds) => (ds.Tables[0].Rows.Count >= 1) ? ds.Tables[0].Rows[0] : null);
            mapper.AddDataColumnMap((r) =>  r.Response.Status, "status");
            mapper.AddDataColumnMap((r) => r.Response.DateProcessed, "dateProcessed", (o) => DateTime.ParseExact(o.ToString(), "yyyy-MM-dd", null));
            mapper.AddDataColumnMap((r) => r.Response.Errors.Code, "code", (o) =>
            {
                if (o == null || o == DBNull.Value)
                {
                    return new List<string>();
                }
                else
                {
                    List<string> codes = new List<string>();
                    codes.AddRange(o.ToString().Split(','));
                    return codes;
                }
            });
            return mapper;
        }

        //RQ05: Предаване на информация за отразяване на събрана сума по вземане при взискател/актосъставител
        public CommonSignedResponse<SendDataForCollectedAmountUpdateRequestType, SendDataForCollectedAmountUpdateResponseType> SendDataForCollectedAmountUpdate(SendDataForCollectedAmountUpdateRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
            try
            {
                #region Request
                OracleConnection connection = new OracleConnection(ConnectionString.Value);
                DataSet ds = new DataSet();
                OracleCommand command = new OracleCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = @"select t.*
                                        from vw_receive_data_RQ05 t
                                        where Auto_exch_info.Set_Params_DATA(
                                        :p_xml,
                                        :p_Administration_oID) = 1";

                var pXML = new OracleParameter("p_xml", OracleDbType.Clob, ParameterDirection.Input);
                pXML.Value = argument.XmlSerialize();
                command.Parameters.Add(pXML);

                var pAdministrationOID = new OracleParameter("p_Administration_oID", OracleDbType.Varchar2, ParameterDirection.Input);
                pAdministrationOID.Value = aditionalParameters.CallContext.AdministrationOId;
                command.Parameters.Add(pAdministrationOID);

                OracleDataAdapter resultDataSet = new OracleDataAdapter(command);
                #endregion
                #region Response 
                try
                {
                    connection.Open();
                    resultDataSet.Fill(ds);

                }
                finally
                {
                    connection.Close();
                }
                DataSetMapper<SendDataForCollectedAmountUpdateResponseType> mapper = SendDataForCollectedAmountUpdateDataMapper(accessMatrix, argument);
                SendDataForCollectedAmountUpdateResponseType result = new SendDataForCollectedAmountUpdateResponseType();

                mapper.Map(ds, result);

                return SigningUtils.CreateAndSign(
                    argument,
                    result,
                    accessMatrix,
                    aditionalParameters
                );
                #endregion

            }
            catch (Exception ex)
            {
                LogError(aditionalParameters, ex, new { Guid = id });
                System.IO.File.AppendAllText("C://RegiX//NRAAdapters//public_debts_errors.txt", GetFullExceptionDetails(ex, true));
                throw ex;
            }
        }

        private DataSetMapper<SendDataForCollectedAmountUpdateResponseType> SendDataForCollectedAmountUpdateDataMapper(AccessMatrix accessMatrix, SendDataForCollectedAmountUpdateRequestType request)
        {
            DataSetMapper<SendDataForCollectedAmountUpdateResponseType> mapper = new DataSetMapper<SendDataForCollectedAmountUpdateResponseType>(accessMatrix);
            mapper.AddDataSetObjectInitializer((ds) => (ds.Tables[0].Rows.Count >= 1) ? ds.Tables[0].Rows[0] : null);
            mapper.AddDataColumnMap((r) =>  r.Response.Status, "status");
            mapper.AddDataColumnMap((r) => r.Response.DateProcessed, "dateProcessed", (o) => DateTime.ParseExact(o.ToString(), "yyyy-MM-dd", null));
            mapper.AddDataColumnMap((r) =>  r.Response.NRAPaymentID, "nraPaymentId", (o) => long.Parse(o.ToString()));
            mapper.AddDataColumnMap((r) => r.Response.Errors.Code, "code", (o) =>
            {
                if (o == null || o == DBNull.Value)
                {
                    return new List<string>();
                }
                else
                {
                    List<string> codes = new List<string>();
                    codes.AddRange(o.ToString().Split(','));
                    return codes;
                }
            });
            return mapper;
        }
        
        //RQ06: Предаване на информация за прекратяване на производство по събиране на вземане при взискател/актосъставител
        public CommonSignedResponse<SendDataForCollectionProceedingsTerminationRequestType, SendDataForCollectionProceedingsTerminationResponseType> SendDataForCollectionProceedingsTermination(SendDataForCollectionProceedingsTerminationRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
            try
            {
                #region Request
                OracleConnection connection = new OracleConnection(ConnectionString.Value);
                DataSet ds = new DataSet();
                OracleCommand command = new OracleCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = @"select t.*
                                        from vw_receive_data_RQ06 t
                                        where Auto_exch_info.Set_Params_DATA(
                                        :p_xml,
                                        :p_Administration_oID) = 1";

                var pXML = new OracleParameter("p_xml", OracleDbType.Clob, ParameterDirection.Input);
                pXML.Value = argument.XmlSerialize();
                command.Parameters.Add(pXML);

                var pAdministrationOID = new OracleParameter("p_Administration_oID", OracleDbType.Varchar2, ParameterDirection.Input);
                pAdministrationOID.Value = aditionalParameters.CallContext.AdministrationOId;
                command.Parameters.Add(pAdministrationOID);

                OracleDataAdapter resultDataSet = new OracleDataAdapter(command);
                #endregion
                #region Response 
                try
                {
                    connection.Open();
                    resultDataSet.Fill(ds);

                }
                finally
                {
                    connection.Close();
                }
                DataSetMapper<SendDataForCollectionProceedingsTerminationResponseType> mapper = SendDataForCollectionProceedingsTerminationDataMapper(accessMatrix, argument);
                SendDataForCollectionProceedingsTerminationResponseType result = new SendDataForCollectionProceedingsTerminationResponseType();

                mapper.Map(ds, result);

                return SigningUtils.CreateAndSign(
                    argument,
                    result,
                    accessMatrix,
                    aditionalParameters
                );
                #endregion

            }
            catch (Exception ex)
            {
                LogError(aditionalParameters, ex, new { Guid = id });
                System.IO.File.AppendAllText("C://RegiX//NRAAdapters//public_debts_errors.txt", GetFullExceptionDetails(ex, true));
                throw ex;
            }
        }

        private DataSetMapper<SendDataForCollectionProceedingsTerminationResponseType> SendDataForCollectionProceedingsTerminationDataMapper(AccessMatrix accessMatrix, SendDataForCollectionProceedingsTerminationRequestType request)
        {
            DataSetMapper<SendDataForCollectionProceedingsTerminationResponseType> mapper = new DataSetMapper<SendDataForCollectionProceedingsTerminationResponseType>(accessMatrix);
            mapper.AddDataSetObjectInitializer((ds) => (ds.Tables[0].Rows.Count >= 1) ? ds.Tables[0].Rows[0] : null);
            mapper.AddDataColumnMap((r) =>  r.Response.Status, "status");
            mapper.AddDataColumnMap((r) => r.Response.DateProcessed, "dateProcessed", (o) => DateTime.ParseExact(o.ToString(), "yyyy-MM-dd", null));
            mapper.AddDataColumnMap((r) => r.Response.Errors.Code, "code", (o) =>
            {
                if (o == null || o == DBNull.Value)
                {
                    return new List<string>();
                }
                else
                {
                    List<string> codes = new List<string>();
                    codes.AddRange(o.ToString().Split(','));
                    return codes;
                }
            });
            return mapper;
        }

        //RQ09: Получаване на информация за актуално състояние по изпълнително основание/вземане от НАП
        public CommonSignedResponse<GetActualStateForIOOrCollectionRequestType, GetActualStateForIOOrCollectionResponseType> GetActualStateForIOOrCollection(GetActualStateForIOOrCollectionRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
            try
            {
                #region Request
                OracleConnection connection = new OracleConnection(ConnectionString.Value);
                DataSet ds = new DataSet();
                OracleCommand command = new OracleCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = @"select t.*
                                        from vw_receive_data_RQ09 t
                                        where Auto_exch_info.Set_Params_DATA(
                                        :p_xml,
                                        :p_Administration_oID) = 1";

                var pXML = new OracleParameter("p_xml", OracleDbType.Clob, ParameterDirection.Input);
                pXML.Value = argument.XmlSerialize();
                command.Parameters.Add(pXML);

                var pAdministrationOID = new OracleParameter("p_Administration_oID", OracleDbType.Varchar2, ParameterDirection.Input);
                pAdministrationOID.Value = aditionalParameters.CallContext.AdministrationOId;
                command.Parameters.Add(pAdministrationOID);

                OracleDataAdapter resultDataSet = new OracleDataAdapter(command);
                #endregion
                #region Response 
                try
                {
                    connection.Open();
                    resultDataSet.Fill(ds);

                }
                finally
                {
                    connection.Close();
                }
                DataSetMapper<GetActualStateForIOOrCollectionResponseType> mapper = GetActualStateForIOOrCollectionDataMapper(accessMatrix, argument);
                GetActualStateForIOOrCollectionResponseType result = new GetActualStateForIOOrCollectionResponseType();

                mapper.Map(ds, result);

                return SigningUtils.CreateAndSign(
                    argument,
                    result,
                    accessMatrix,
                    aditionalParameters
                );
                #endregion

            }
            catch (Exception ex)
            {
                LogError(aditionalParameters, ex, new { Guid = id });
                System.IO.File.AppendAllText("C://RegiX//NRAAdapters//public_debts_errors.txt", GetFullExceptionDetails(ex, true));
                throw ex;
            }
        }

        private DataSetMapper<GetActualStateForIOOrCollectionResponseType> GetActualStateForIOOrCollectionDataMapper(AccessMatrix accessMatrix, GetActualStateForIOOrCollectionRequestType request)
        {
            DataSetMapper<GetActualStateForIOOrCollectionResponseType> mapper = new DataSetMapper<GetActualStateForIOOrCollectionResponseType>(accessMatrix);
            mapper.AddDataSetMap((r) => r.Results, (d) => d.Tables[0].Rows);

            //IO
            mapper.AddDataColumnMap((r) => r.Results[0].Errors.Code, "code", (o) =>
            {
                if (o == null || o == DBNull.Value)
                {
                    return new List<string>();
                }
                else
                {
                    List<string> codes = new List<string>();
                    codes.AddRange(o.ToString().Split(','));
                    return codes;
                }
            });
            mapper.AddDataColumnMap((r) => r.Results[0].IO.TitulID, "TITULID", (o) => long.Parse(o.ToString()));
            mapper.AddDataColumnMap((r) => r.Results[0].IO.EIK, "EIK");

            mapper.AddDataColumnMap((r) => r.Results[0].IO.EIKType, "EIKTYPE", (o) => Enum.Parse(typeof(EIKTypeEnumeration),o.ToString()));
            mapper.AddDataColumnMap((r) => r.Results[0].IO.Name, "NAME");
            mapper.AddDataColumnMap((r) => r.Results[0].IO.DocumentType, "DOCUMENTTYPE");
            mapper.AddDataColumnMap((r) => r.Results[0].IO.DocumentNo, "DOCUMENTNO");
            mapper.AddDataColumnMap((r) => r.Results[0].IO.DocumentSeries, "DOCUMENTSERIES");
            mapper.AddDataColumnMap((r) => r.Results[0].IO.IssueDate, "ISSUEDATE", (o) => DateTime.ParseExact(o.ToString(), "yyyy-MM-dd", null));
            mapper.AddDataColumnMap((r) => r.Results[0].IO.EnforcementDate, "ENFORCEMENTDATE", (o) => DateTime.ParseExact(o.ToString(), "yyyy-MM-dd", null));
            //Collection
            mapper.AddDataColumnMap((r) => r.Results[0].Collection.CollectibleID, "COLLECTIBLEID", (o) => long.Parse(o.ToString()));
            mapper.AddDataColumnMap((r) => r.Results[0].Collection.BeneficiaryCode, "BENEFICIARYCODE", (o) => long.Parse(o.ToString()));
            mapper.AddDataColumnMap((r) => r.Results[0].Collection.DepartmentCode, "DEPARTMENTCODE", (o) => long.Parse(o.ToString()));
            mapper.AddDataColumnMap((r) => r.Results[0].Collection.BeneficiaryEIK, "BENEFICIARYEIK");
            mapper.AddDataColumnMap((r) => r.Results[0].Collection.BeneficiaryName, "BENEFICIARYNAME");
            mapper.AddDataColumnMap((r) => r.Results[0].Collection.CollectibleType, "COLLECTIBLETYPE");
            mapper.AddDataColumnMap((r) => r.Results[0].Collection.PeriodFrom, "PERIODFROM", (o) => DateTime.ParseExact(o.ToString(), "yyyy-MM-dd", null));
            mapper.AddDataColumnMap((r) => r.Results[0].Collection.PeriodTo, "PERIODTO", (o) => DateTime.ParseExact(o.ToString(), "yyyy-MM-dd", null));
            mapper.AddDataColumnMap((r) => r.Results[0].Collection.UnforcedPaymentDate, "UNFORCEDPAYMENTDATE", (o) => DateTime.ParseExact(o.ToString(), "yyyy-MM-dd", null));
            mapper.AddDataColumnMap((r) => r.Results[0].Collection.DateProcessed, "DATEPROCESSED", (o) => DateTime.ParseExact(o.ToString(), "yyyy-MM-dd", null));
            mapper.AddDataColumnMap((r) => r.Results[0].Collection.OutstandingPrincipalAmountInterest, "outstPrincipalAmountInterest");
            mapper.AddDataColumnMap((r) => r.Results[0].Collection.OutstandingInterestAmount, "OUTSTANDINGINTERESTAMOUNT");
            mapper.AddDataColumnMap((r) => r.Results[0].Collection.OutstandingNRAInterestAmount, "OUTSTANDINGNRAITERESTAMOUNT");
            mapper.AddDataColumnMap((r) => r.Results[0].Collection.OutstandingPrincipalAmountNoInterest, "outstPrincipalAmountNoInterest");
            mapper.AddDataColumnMap((r) => r.Results[0].Collection.Currency, "CURRENCY");
            mapper.AddDataColumnMap((r) => r.Results[0].Collection.AppealStatus, "APPEALSTATUS");
            mapper.AddDataColumnMap((r) => r.Results[0].Collection.AppealDate, "APPEALDATE", (o) => DateTime.ParseExact(o.ToString(), "yyyy-MM-dd", null));
            mapper.AddDataColumnMap((r) => r.Results[0].Collection.NRACollectibleStage, "NRACOLLECTIBLESTAGE");
            mapper.AddDataColumnMap((r) => r.Results[0].Collection.NRADeedNoAndYear, "NRADEEDNOANDYEAR");
            mapper.AddDataColumnMap((r) => r.Results[0].Collection.NRACollectibleStatus, "NRACOLLECTIBLESTATUS");
            mapper.AddDataColumnMap((r) => r.Results[0].Collection.NRACancelDate, "NRACANCELDATE", (o) => DateTime.ParseExact(o.ToString(), "yyyy-MM-dd", null));

            //Specified?

            return mapper;
        }

        private static string GetFullExceptionDetails(Exception e, bool includeStackTrace = false)
        {
            string newLine = Environment.NewLine;
            string message = e.Message;
            string exceptionType = e.GetType().ToString();



            string stack = "";
            if (includeStackTrace && !string.IsNullOrEmpty(e.StackTrace))
            {
                stack = e.StackTrace + newLine;
            }


            string LinesSeparator = new string('=', 27);
            string result = string.Format("{0}{1}{2}{1}{3}{1}{4}{1}{5}",
                LinesSeparator,
                newLine,
                exceptionType,
                e.Source,
                message,
                stack);
            if (e.InnerException != null)
            {
                result = result + GetFullExceptionDetails(e.InnerException, includeStackTrace);
            }

            return result;
        }
    }
}
