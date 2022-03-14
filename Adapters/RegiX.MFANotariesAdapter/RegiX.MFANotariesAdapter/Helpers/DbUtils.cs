using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.Common.Utils;

namespace TechnoLogica.RegiX.MFANotariesAdapter.Helpers
{
    public abstract class DbUtils
    {
        protected readonly string connectionString;

        // При Insert всеки път статусът by default се задава на PENDING
        const string _STATUS = "Pending";
        const string _ACKNOWLEDGED = "IsAcknowledged";
        const string _READY = "Ready";

        // Код на тип на документ, винаги е този при подаване на документи през RegiX
        const string _DOCUMENT_TYPE_CODE = "8";
        const string _ADAPTER_NAME = "MFANotariesAdapter";

        // Брой опити за изпращане на резултата обратно на callback url-a
        const int _RETRY_COUNT = 10;

        public DbUtils(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public abstract DbConnection CreateDbConnection();

        public abstract DbCommand CreateCommand(string text = null, DbConnection dbConnection = null);

        public abstract DbDataAdapter CreateDataAdapter(DbCommand command);

        public abstract DbParameter CreateParameter(string parameterName, NpgsqlDbType parameterType, object value = null, ParameterDirection direction = ParameterDirection.Input);

        public DbParameter AddParameter(DbCommand command, string parameterName, NpgsqlDbType parameterType, object value = null, ParameterDirection direction = ParameterDirection.Input)
        {
            var parameter = this.CreateParameter(parameterName, parameterType, value, direction);
            command.Parameters.Add(parameter);

            return parameter;
        }

        public object ExtractScalarValue(DbCommand command)
        {
            var result = command.ExecuteScalar();
            return result;
        }

        // Главен метод за SendNotaryDocumentsResponse
        public void InsertDataFromRequest(
            DbConnection connection,
            SendNotaryDocumentsRequest argument,
            AdapterAdditionalParameters aditionalParameters,
            string serializedRequestData)
        {
            long consulID;
            long documentTypeID;
            using (DbTransaction t = connection.BeginTransaction())
            {
                try
                {
                    InsertLog(connection, t, argument, aditionalParameters);
                    
                    consulID = GetConsulIDByCode(connection, argument.ConsulCode, t);
                    if (consulID == 0)
                    {
                        string message = "Cannot insert notary_service! ConsulCode is not contained in the consuls table!";
                        throw new ArgumentException(message);
                    }

                    var notaryServiceID = GetNotaryServiceByApiCall(connection, aditionalParameters.ApiServiceCallId);
                    if (notaryServiceID == 0)
                    {
                        string message = $"Notary service with api call id:{aditionalParameters.ApiServiceCallId} was not found!";
                        throw new ArgumentException(message);
                    }

                    UpdateNotaryService(connection, argument, t, notaryServiceID, consulID, aditionalParameters, serializedRequestData);
                    
                    documentTypeID = GetDocumentTypeID(connection, _DOCUMENT_TYPE_CODE, t);

                    // InsertDocuments
                    foreach (var document in argument.Documents.Document)
                    {
                        long documentID = InsertDocument(connection, document, t, documentTypeID);
                        if (documentID == 0)
                        {
                            string message = "Cannot insert one of the documents!";
                            throw new ArgumentException(message);
                        }
                        else
                        {
                            //Connect notary_service to inserted document
                            long notaryServiceDocument = InsertNotaryServiceDocument(connection, t, notaryServiceID, documentID);
                            if (notaryServiceDocument == 0)
                            {
                                string message = "Cannot attach document to notary!";
                                throw new ArgumentException(message);
                            }
                        }
                    }

                    t.Commit();
                }
                catch (Exception ex)
                {
                    t.Rollback();
                    throw;
                }
            }
        }

        #region GetConsulID

        private long GetConsulIDByCode(
                DbConnection connection,
                string consulCode,
                DbTransaction transaction)
        {
            if (string.IsNullOrEmpty(consulCode))
            {
                string message = "Can't select consul id";
                throw new ArgumentException(message);
            }

            DbCommand command = CreateCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.Transaction = transaction;
            command.CommandText =
                @"select id from consul where LOWER(code) = LOWER(@p_code)";

            this.AddParameter(command, "p_code", NpgsqlDbType.Varchar, consulCode);

            var obj = ExtractScalarValue(command);
            long result = Convert.ToInt64(obj);
            return result;
        }

        #endregion

        #region NotaryService

        private long GetNotaryServiceByApiCall(DbConnection connection, decimal apiServiceCallId)
        {
            DbCommand command = CreateCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.CommandText =
            @"select id from notary_service where api_service_call_id = @p_api_service_call_id";

            AddParameter(command, "p_api_service_call_id", NpgsqlDbType.Numeric, apiServiceCallId);

            var obj = ExtractScalarValue(command);
            long result = Convert.ToInt64(obj);
            return result;
        }

        private void UpdateNotaryService(
           DbConnection connection,
           SendNotaryDocumentsRequest request,
           DbTransaction transaction,
           long notaryServiceId,
           long consulID,
           AdapterAdditionalParameters additionalParameters,
           string serializedRequestData)
        {
            DbCommand command = CreateCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.Transaction = transaction;
            command.CommandText =
            @"update notary_service set 
            name = @p_name,
            authentication_number = @p_authentication_number,
            consul_id = @p_consul_id,
            api_service_call_id = @p_api_service_call_id,
            authentication_type = @p_authentication_type,
            authentication_date = @p_authentication_date,
            status_code = @p_status_code,
            raw_request = @p_raw_request,
            is_pdf = @p_is_pdf,
            callback_url = @p_callback_url,
            sys_ins_date_utc = @p_sys_ins_date_utc,
            sys_ins_username = @p_sys_ins_username
            where id = @p_id
            ";

            var authenticationType = request.AuthenticationType.ToString();
            AddParameter(command, "p_name", NpgsqlDbType.Varchar, additionalParameters.CallContext.AdministrationName);
            AddParameter(command, "p_authentication_number", NpgsqlDbType.Varchar, request.AuthenticationNumber);
            AddParameter(command, "p_consul_id", NpgsqlDbType.Numeric, consulID);
            AddParameter(command, "p_api_service_call_id", NpgsqlDbType.Numeric, additionalParameters.ApiServiceCallId);
            AddParameter(command, "p_authentication_type", NpgsqlDbType.Varchar, authenticationType);
            AddParameter(command, "p_authentication_date", NpgsqlDbType.Date, request.AuthenticationDate);
            AddParameter(command, "p_status_code", NpgsqlDbType.Varchar, _STATUS);
            AddParameter(command, "p_raw_request", NpgsqlDbType.Text, serializedRequestData);
            AddParameter(command, "p_is_pdf", NpgsqlDbType.Boolean, additionalParameters.ResponseProcessing.HasFlag(ResponseProcessing.TransformToPDF));
            AddParameter(command, "p_callback_url", NpgsqlDbType.Text, additionalParameters.CallbackURL);
            AddParameter(command, "p_sys_ins_date_utc", NpgsqlDbType.Timestamp, DateTime.UtcNow);
            AddParameter(command, "p_sys_ins_username", NpgsqlDbType.Text, _ADAPTER_NAME);
            AddParameter(command, "p_id", NpgsqlDbType.Numeric, notaryServiceId);

            command.ExecuteNonQuery();
        }

        #endregion

        #region GetDocumentTypeID
        private long GetDocumentTypeID(
                DbConnection connection,
                string documentTypeCode,
                DbTransaction transaction)
        {
            if (string.IsNullOrEmpty(documentTypeCode))
            {
                string message = "Cannot obtain document type id";
                throw new ArgumentException(message);
            }

            DbCommand command = CreateCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.Transaction = transaction;
            command.CommandText =
                @"select id from document_type where LOWER(code) = LOWER(@p_code)";

            this.AddParameter(command, "p_code", NpgsqlDbType.Varchar, documentTypeCode);

            var obj = ExtractScalarValue(command);
            long result = Convert.ToInt64(obj);
            return result;
        }
        #endregion

        #region InsertDocument
        private long InsertDocument(
            DbConnection connection,
            DocumentType document,
            DbTransaction transaction,
            long documentTypeID
            )
        {
            DbCommand command = CreateCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.Transaction = transaction;
            command.CommandText =
            @"insert into document
            (
                file_name,
                file_path,
                document_type_id, 
                document_content
            )
            values
            (
                @p_file_name,
                @p_file_path,
                @p_document_type_id,
                @p_document_content
            )
            RETURNING id";
            Guid fileGuid = Guid.NewGuid();
            string file_path = fileGuid.ToString() + "_" + document.FileName;
            AddParameter(command, "p_file_name", NpgsqlDbType.Varchar, document.FileName);
            AddParameter(command, "p_file_path", NpgsqlDbType.Varchar, file_path);
            AddParameter(command, "p_document_type_id", NpgsqlDbType.Numeric, documentTypeID);
            AddParameter(command, "p_document_content", NpgsqlDbType.Bytea, document.Content);

            var obj = ExtractScalarValue(command);
            long result = Convert.ToInt64(obj);
            return result;
        }
        #endregion

        #region Insert NotaryServiceDocument
        private long InsertNotaryServiceDocument(
            DbConnection connection,
            DbTransaction transaction,
            long notaryServiceID,
            long documentID
            )
        {
            DbCommand command = CreateCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.Transaction = transaction;
            command.CommandText =
            @"insert into notary_service_document
            (
                notary_service_id,
                document_id
            )
            values
            (
                @p_notary_service_id,
                @p_document_id
            )
            RETURNING id";
            AddParameter(command, "p_notary_service_id", NpgsqlDbType.Numeric, notaryServiceID);
            AddParameter(command, "p_document_id", NpgsqlDbType.Numeric, documentID);

            var obj = ExtractScalarValue(command);
            long result = Convert.ToInt64(obj);
            return result;
        }
        #endregion

        #region RemovePersistance
        public void RemovePersistance(
           DbConnection connection,
           decimal apiServiceCallID,
           string verificationCode
           )
        {
            using (DbTransaction t = connection.BeginTransaction())
            {
                try
                {
                    DbCommand command = CreateCommand();
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.Transaction = t;
                    command.CommandText =
                    @"update notary_service
                      set status_code = @p_acknowledged
                      where api_service_call_id = @p_api_service_call_id 
                      AND verification_code = @p_verification_code";

                    AddParameter(command, "p_api_service_call_id", NpgsqlDbType.Numeric, apiServiceCallID);
                    AddParameter(command, "p_verification_code", NpgsqlDbType.Varchar, verificationCode);
                    AddParameter(command, "p_acknowledged", NpgsqlDbType.Varchar, _ACKNOWLEDGED);


                    command.ExecuteNonQuery();
                    t.Commit();
                }
                catch (Exception ex)
                {
                    t.Rollback();
                    throw;
                }
            }
        }
        #endregion

        #region InsertVerificationCode

        public void InsertVerificationCode(
           DbConnection connection,
           decimal apiServiceCallID,
           string verificationCode
           )
        {
            using (DbTransaction t = connection.BeginTransaction())
            {
                try
                {
                    DbCommand command = CreateCommand();
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.Transaction = t;
                    command.CommandText =
                    @"insert into notary_service (api_service_call_id, verification_code, is_pdf)
                      values(@p_api_service_call_id, @p_verification_code, @p_is_pdf)";

                    AddParameter(command, "p_api_service_call_id", NpgsqlDbType.Numeric, apiServiceCallID);
                    AddParameter(command, "p_verification_code", NpgsqlDbType.Varchar, verificationCode);
                    AddParameter(command, "p_is_pdf", NpgsqlDbType.Boolean, false); // default, will be changed later

                    command.ExecuteNonQuery();

                    t.Commit();
                }
                catch (Exception ex)
                {
                    t.Rollback();
                    throw;
                }
            }
        }
        #endregion

        #region GetSignedResult
        public ServiceResultData GetSignedResult(
           DbConnection connection,
           decimal apiServiceCallID,
           string verificationCode
           )
        {
            DbCommand getVerificationCodeAndResult = CreateCommand();
            getVerificationCodeAndResult.Connection = connection;
            getVerificationCodeAndResult.CommandType = CommandType.Text;
            getVerificationCodeAndResult.CommandText =
            @"select raw_signed_result, verification_code
              from notary_service
              where api_service_call_id = @p_api_service_call_id
                and status_code = @p_status_code";
            AddParameter(getVerificationCodeAndResult, "p_api_service_call_id", NpgsqlDbType.Numeric, apiServiceCallID);
            AddParameter(getVerificationCodeAndResult, "p_status_code", NpgsqlDbType.Varchar, _READY);

            var resultDataSet = this.CreateDataAdapter(getVerificationCodeAndResult);
            DataSet ds = new DataSet();
            resultDataSet.Fill(ds);

            if (ds.Tables[0].Rows.Count != 0)
            {
                var rows = ds.Tables[0].Rows.Cast<DataRow>().ToList();
                var firstRow = rows[0];
                if (firstRow["verification_code"].ToString() == verificationCode)
                {
                    var rawSignedResult = firstRow["raw_signed_result"] as byte[];
                    if (rawSignedResult != null)
                    {
                        var xml = Encoding.UTF8.GetString(rawSignedResult);
                        return xml.XmlDeserialize<ServiceResultData>();
                    }
                    else
                    {
                        return new ServiceResultData()
                        {
                            IsReady = false,
                            ServiceCallID = apiServiceCallID
                        };
                    }
                }
                else
                {
                    return new ServiceResultData()
                    {
                        HasError = true,
                        Error = "Wrong verification code"
                    };
                }
            }
            else
            {
                return new ServiceResultData()
                {
                    HasError = true,
                    Error = $"There is no operation known with the provided id: {apiServiceCallID}"
                };
            }
        }
        #endregion

        #region GetCallResult
        
        public List<CallResult> GetCallResult(DbConnection connection)
        {
            DbCommand command = CreateCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.CommandText =
            @"select id, raw_signed_result, callback_url, raw_request, verification_code, api_service_call_id
              from notary_service
              where raw_request IS NOT NULL 
                and callback_url IS NOT NULL
                and raw_unsigned_result IS NOT NULL
                and (next_retry_utc IS NULL or @p_current_time > next_retry_utc)
                and (retry_count IS NULL or retry_count < @p_retry_count)
                and status_code = @p_ready
              order by id desc";
            AddParameter(command, "p_current_time", NpgsqlDbType.Timestamp, DateTime.UtcNow);
            AddParameter(command, "p_retry_count", NpgsqlDbType.Integer, _RETRY_COUNT);
            AddParameter(command, "p_ready", NpgsqlDbType.Varchar, _READY);


            var resultDataSet = this.CreateDataAdapter(command);
            DataSet ds = new DataSet();
            resultDataSet.Fill(ds);
            var rows = ds.Tables[0].Rows.Cast<DataRow>().ToList();

            List<CallResult> result = new List<CallResult>();

            foreach (var item in rows)
            {
                var callResult = new CallResult()
                {
                    Id = GetIntValue(item["id"]),
                    CallbackUrl = GetStringValue(item["callback_url"]),
                    RawRequest = GetStringValue(item["raw_request"]),
                    RawResult = GetStringValue(item["raw_signed_result"]),
                    VerificationCode = GetStringValue(item["verification_code"]),
                    ApiServiceCallId = GetDecimalValue(item["api_service_call_id"]),
                };

                result.Add(callResult);
            }
            return result;
        }

        #endregion

        #region InsertAdapterSignedResult
        public void InsertAdapterSignedResult(
          DbConnection connection,
          decimal apiServiceCallID,
          string verificationCode,
          byte[] adapterSignedResult
          )
        {
            using (DbTransaction t = connection.BeginTransaction())
            {
                try
                {
                    DbCommand command = CreateCommand();
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.Transaction = t;
                    command.CommandText =
                    @"update notary_service
                      set raw_signed_result = @p_adapter_signed_result
                      where api_service_call_id = @p_api_service_call_id 
                      AND verification_code = @p_verification_code";

                    AddParameter(command, "p_adapter_signed_result", NpgsqlDbType.Bytea, adapterSignedResult);
                    AddParameter(command, "p_verification_code", NpgsqlDbType.Numeric, verificationCode);
                    AddParameter(command, "p_api_service_call_id", NpgsqlDbType.Numeric, apiServiceCallID);

                    command.ExecuteNonQuery();
                    t.Commit();
                }
                catch (Exception ex)
                {
                    t.Rollback();
                    throw;
                }
            }
        }
        #endregion

        #region GetRetryCount
        public int GetRetryCount(
           DbConnection connection,
           decimal apiServiceCallId,
           string verificationCode
           )
        {
            DbCommand command = CreateCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.CommandText =
            @"select retry_count
              from notary_service
              where api_service_call_id = @p_api_service_call_id
              and verification_code = @p_verification_code";
            AddParameter(command, "p_api_service_call_id", NpgsqlDbType.Integer, apiServiceCallId);
            AddParameter(command, "p_verification_code", NpgsqlDbType.Varchar, verificationCode);

            var resultDataSet = this.CreateDataAdapter(command);
            DataSet ds = new DataSet();
            resultDataSet.Fill(ds);
            var rows = ds.Tables[0].Rows.Cast<DataRow>().ToList();

            if (rows.Count == 0)
            {
                throw new ArgumentException("Cound not find retry count by call id and verification code");
            }

            var retryCount = rows[0]["retry_count"];
            if (retryCount == null || retryCount == DBNull.Value)
            {
                return 0;
            }

            return Convert.ToInt32(retryCount);
        }
        #endregion

        #region IncreaseRetryCountAndNextRetry

        public void IncreaseRetryCount(DbConnection connection, decimal apiServiceCallID, string verificationCode)
        {
            int retryCount = GetRetryCount(connection, apiServiceCallID, verificationCode); 
            var nextRetryUTC = DateTime.UtcNow.AddMinutes(retryCount);

            DbCommand command = CreateCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.CommandText =
            @"update notary_service
                set retry_count = @p_retry_count,
                next_retry_utc = @p_next_retry_utc
                where api_service_call_id = @p_api_service_call_id 
                and verification_code = @p_verification_code";

            AddParameter(command, "p_api_service_call_id", NpgsqlDbType.Numeric, apiServiceCallID);
            AddParameter(command, "p_verification_code", NpgsqlDbType.Varchar, verificationCode);
            AddParameter(command, "p_retry_count", NpgsqlDbType.Integer, retryCount + 1);
            AddParameter(command, "p_next_retry_utc", NpgsqlDbType.Timestamp, nextRetryUTC);

            command.ExecuteNonQuery();
        }
        #endregion

        #region InsertLog
        private void InsertLog(
            DbConnection connection,
            DbTransaction transaction,
            SendNotaryDocumentsRequest request,
            AdapterAdditionalParameters additionalParameters)
        {
            DbCommand command = CreateCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.Transaction = transaction;
            command.CommandText =
            @"insert into web_service_log
            (
            api_service_call_id,
            insert_timestamp,
            request_content,
            web_service_name,
            remote_address,
            certificate
            )
            values
            (
            @p_api_service_call_id,
            @p_insert_timestamp,
            @p_request_content,
            @p_web_service_name,
            @p_remote_address,
            @p_certificate
            )";

            AddParameter(command, "p_api_service_call_id", NpgsqlDbType.Integer, additionalParameters.ApiServiceCallId);
            AddParameter(command, "p_insert_timestamp", NpgsqlDbType.Timestamp, DateTime.UtcNow);
            AddParameter(command, "p_request_content", NpgsqlDbType.Text, request.XmlSerialize());
            AddParameter(command, "p_web_service_name", NpgsqlDbType.Varchar, "RegiX.MFANotariesAdapter");
            AddParameter(command, "p_remote_address", NpgsqlDbType.Varchar, additionalParameters.ClientIPAddress);
            AddParameter(command, "p_certificate", NpgsqlDbType.Varchar, additionalParameters.ConsumerCertificateThumbprint);
            command.ExecuteNonQuery();
        }
        #endregion

        #region Helpers

        private string GetStringValue(object obj)
        {
            if (obj == null || obj == DBNull.Value)
            {
                return null;
            }

            return obj.ToString();
        }

        private int GetIntValue(object obj)
        {
            if (obj == null || obj == DBNull.Value)
            {
                return default(int);
            }

            return Convert.ToInt32(obj);
        }

        private decimal GetDecimalValue(object obj)
        {
            if (obj == null || obj == DBNull.Value)
            {
                return default(decimal);
            }

            return Convert.ToDecimal(obj);
        }

        #endregion
    }
}
