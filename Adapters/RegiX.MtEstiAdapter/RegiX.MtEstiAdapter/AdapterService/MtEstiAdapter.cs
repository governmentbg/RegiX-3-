using System;
using System.ComponentModel.Composition;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Xml;
using TechnoLogica.RegiX.Adapters.Common.DataContracts;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.DataContracts.Parameter;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.Common.Utils;
using TechnoLogica.RegiX.MtEstiAdapter.Helpers;
using TechnoLogica.RegiX.NpgsqlAdapterService;

namespace TechnoLogica.RegiX.MtEstiAdapter.AdapterService
{
    [Export(typeof(IAdapterService))]
    [ExportFullName(typeof(MtEstiAdapter), typeof(IAdapterService))]
    [ExportSimpleName(typeof(MtEstiAdapter), typeof(IAdapterService))]
    public class MtEstiAdapter : NpgsqlBaseAdapterService, IMtEstiAdapter, IAdapterService
    {
        private const string WebServiceLogInfo = "INFO";
        private const string WebServiceLogSuccess = "SUCCESS";
        private const string WebServiceLogError = "ERROR";

        private readonly NpgsqlDbUtils dbUtils;

        public MtEstiAdapter()
        {
            this.dbUtils = this.CreateNpgsqlDbUtils();
        }

        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(MtEstiAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> ConnectionString =
            new ParameterInfo<string>("Host=172.31.12.64;Database=esti;Username=esti;Password=3st1;Timeout=1024")
            {
                Key = Constants.ConnectionStringParameterKeyName,
                Description = "Connection string",
                OwnerAssembly = typeof(MtEstiAdapter).Assembly
            };

        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(MtEstiAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> ShouldGenerateEmail =
            new ParameterInfo<string>("true")
            {
                Key = "ShouldGenerateEmail",
                Description = "Should generate email - true / false",
                OwnerAssembly = typeof(MtEstiAdapter).Assembly
            };

        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(MtEstiAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> EstiUrl =
            new ParameterInfo<string>("http://giswmr:85/Public/RequestLido/LidoRequest?lidoRequestUid=")
            {
                Key = "EstiUrl",
                Description = "Public link for claiming lido superuser account",
                OwnerAssembly = typeof(MtEstiAdapter).Assembly
            };

        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(MtEstiAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> EmailSubject =
            new ParameterInfo<string>("Please claim your superuser account")
            {
                Key = "EmailSubject",
                Description = "Subject of email",
                OwnerAssembly = typeof(MtEstiAdapter).Assembly
            };

        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(MtEstiAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> EmailBody =
            new ParameterInfo<string>("Go to &lt;a href=&quot;{0}&quot;&gt;ESTI&lt;/a&gt; to claim your account here")
            {
                Key = "EmailBody",
                Description = "Body of email",
                OwnerAssembly = typeof(MtEstiAdapter).Assembly
            };

        public CommonSignedResponse<AccomodationPlaceRequestType, AccomodationPlaceResponseType> SendInfoForAccomodationPlace(AccomodationPlaceRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            bool shouldLogFullRequest = Convert.ToBoolean(ConfigurationManager.AppSettings["LogFullAccomodationPlaceRequest"]);
            var request = shouldLogFullRequest ? argument.XmlSerialize() : argument.UIN.XmlSerialize();

            Guid id = Guid.NewGuid();
            DateTime executionStart = DateTime.Now;
            LogData(aditionalParameters, new { Request = request, Guid = id });
            long logId = 0;
            long accomodationPlaceId = 0;
            try
            {
                logId = this.InsertWebServiceLog(nameof(SendInfoForAccomodationPlace), id, request, aditionalParameters);
                dbUtils.ValidateAccomodationPlace(argument);
                DbConnection connection = dbUtils.CreateDbConnection();

                int responseCode = 0;
                try
                {
                    connection.Open();
                    dbUtils.CompleteOperationAccmodationPlace(connection, argument, out accomodationPlaceId, out responseCode);
                    this.UpdateWebServiceLog(logId, accomodationPlaceId, responseCode.ToString(), WebServiceLogSuccess, id, aditionalParameters);
                }
                finally
                {
                    connection.Close();
                }

                AccomodationPlaceResponseType result = new AccomodationPlaceResponseType();
                result.ResponseCode = responseCode;
                LogData(aditionalParameters, new { Result = "Success", ExecutionTime = (DateTime.Now - executionStart), Guid = id });
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
                this.UpdateWebServiceLog(logId, accomodationPlaceId, ex.Message, WebServiceLogError, id, aditionalParameters);
                throw;
            }
        }

        public CommonSignedResponse<AccRegister.AccomodationRegisterRequestType, AccRegister.AccomodationRegisterResponseType> SendInfoForAccomodationRegister(AccRegister.AccomodationRegisterRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            bool shouldLogFullRequest = Convert.ToBoolean(ConfigurationManager.AppSettings["LogFullAccomodationRegisterRequest"]);
            string request;
            if (shouldLogFullRequest)
            {
                request = argument.XmlSerialize();
            }
            else
            {
                var data = new { argument.AccomodationPlaceUIN, Change = argument.Change.ToString() };
                request = data.XmlSerialize();
            }

            Guid id = Guid.NewGuid();
            DateTime executionStart = DateTime.Now;
            LogData(aditionalParameters, new { Request = request, Guid = id });

            long logId = 0;
            long accomodationPlaceId = 0;
            try
            {
                logId = this.InsertWebServiceLog(nameof(SendInfoForAccomodationRegister), id, request, aditionalParameters);
                DbConnection connection = dbUtils.CreateDbConnection();

                AccRegister.AccomodationRegisterResponseType result;
                try
                {
                    connection.Open();
                    result = dbUtils.CompleteOperationAccomodationRegister(connection, argument, aditionalParameters, out accomodationPlaceId);
                    this.UpdateWebServiceLog(logId, accomodationPlaceId, result.XmlSerialize(), WebServiceLogSuccess, id, aditionalParameters);
                }
                finally
                {
                    connection.Close();
                }

                LogData(aditionalParameters, new { Result = "Success", ExecutionTime = (DateTime.Now - executionStart), Guid = id });
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
                this.UpdateWebServiceLog(logId, accomodationPlaceId, ex.Message, WebServiceLogError, id, aditionalParameters);
                throw;
            }
        }

        private long InsertWebServiceLog(
            string methodName,
            Guid guid,
            string argument,
            AdapterAdditionalParameters aditionalParameters)
        {
            DbConnection connection = dbUtils.CreateDbConnection();
            try
            {
                DbCommand command = dbUtils.CreateCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText =
                @"insert into web_service_log
                (
                    log_request_uid,
                    log_timestamp,
                    log_web_service,
                    log_request,
                    log_remote_address,
                    log_request_certificate,
                    log_message,
                    log_message_type
                )
                values
                (
                    @p_log_request_uid,
                    @p_log_timestamp,
                    @p_log_web_service,
                    @p_log_request,
                    @p_log_remote_address,
                    @p_log_request_certificate,
                    @p_log_message,
                    @p_log_message_type
                )
                RETURNING id";

                XmlDocument doc = new XmlDocument();
                doc.PreserveWhitespace = false;
                doc.LoadXml(argument);
                string request = doc.DocumentElement.OuterXml;

                dbUtils.AddParameter(command, "p_log_request_uid", CustomDbType.Varchar, guid.ToString());
                dbUtils.AddParameter(command, "p_log_timestamp", CustomDbType.Timestamp, DateTime.Now);
                dbUtils.AddParameter(command, "p_log_web_service", CustomDbType.Varchar, methodName);
                dbUtils.AddParameter(command, "p_log_request", CustomDbType.Text, request);
                dbUtils.AddParameter(command, "p_log_remote_address", CustomDbType.Varchar, aditionalParameters.ClientIPAddress);
                dbUtils.AddParameter(command, "p_log_request_certificate", CustomDbType.Text, aditionalParameters.ConsumerCertificateThumbprint);
                dbUtils.AddParameter(command, "p_log_message", CustomDbType.Text, aditionalParameters.XmlSerialize());
                dbUtils.AddParameter(command, "p_log_message_type", CustomDbType.Varchar, WebServiceLogInfo);

                connection.Open();

                var obj = dbUtils.ExtractScalarValue(command);
                long result = Convert.ToInt64(obj);
                return result;
            }
            catch (Exception ex)
            {
                LogError(aditionalParameters, ex, new { Msg = "Error while inserting in log", Guid = guid });
                return 0;
            }
            finally
            {
                connection.Close();
            }
        }

        private void UpdateWebServiceLog(
            long logId,
            long accomodationPlaceId,
            string response,
            string logMessageType,
            Guid guid,
            AdapterAdditionalParameters aditionalParameters)
        {
            if (logId == 0)
            {
                // Error while inserting log
                return;
            }

            DbConnection connection = dbUtils.CreateDbConnection();
            try
            {
                connection.Open();
                DbCommand command = dbUtils.CreateCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText =
                @"
                    update web_service_log set 
                    log_response = @p_log_response,
                    accomodation_place_id = @p_accomodation_place_id,
                    log_message_type = @p_log_message_type
                    where id = @p_id
                ";

                object paramAccPlaceId = accomodationPlaceId == 0 ? DBNull.Value : (object)accomodationPlaceId;

                dbUtils.AddParameter(command, "p_id", CustomDbType.Bigint, logId);
                dbUtils.AddParameter(command, "p_log_response", CustomDbType.Text, response);
                dbUtils.AddParameter(command, "p_accomodation_place_id", CustomDbType.Bigint, paramAccPlaceId);
                dbUtils.AddParameter(command, "p_log_message_type", CustomDbType.Varchar, logMessageType);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                LogError(aditionalParameters, ex, new { Msg = "Error while updating in log", Guid = guid });
            }
            finally
            {
                connection.Close();
            }
        }

        private NpgsqlDbUtils CreateNpgsqlDbUtils()
        {
            bool generateEmail = Convert.ToBoolean(ShouldGenerateEmail.Value);
            var result = new NpgsqlDbUtils(ConnectionString.Value, generateEmail, EstiUrl.Value, EmailSubject.Value, EmailBody.Value);
            return result;
        }
    }
}
