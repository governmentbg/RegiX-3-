using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Data;
using TechnoLogica.RegiX.DataAccess.Utils;
using TechnoLogica.RegiX.Core.Data.Interfaces;
using System.Xml;
using System.Threading.Tasks;
using TechnoLogica.RegiX.RecordLog;

namespace TechnoLogica.RegiX.DataAccess.DataClasses
{
    public static class APIServiceCallsData
    {
        public static decimal AddAPIServiceCall(
                decimal certificateID,
                decimal operationID,
                Guid instanceID,
                string EIDToken,
                string remark,
                string clientIPAddress,
                XmlElement request,
                string operationFullName,
                ILogRecord logData,
                string serviceURI = null,
                string serviceType = null,
                string employeeIdentifier = null,
                string employeeNames = null,
                string employeeAditionalIdentifier = null,
                string employeePosition = null,
                string administrationOId = null,
                string administrationName = null,
                string responsiblePersonIdentifier = null,
                string lawReason = null,
                string OIDToken = null,
                string consumerName = null,
                string adapterOperationName = null,
                string producerAdministration = null,
                string consumerAdmin = null,
                string producer = null,
                string consumerOID = null
                )
        {
            using (RegiXContext context = DbContextUtils.GetDbContext())
            {
                API_SERVICE_CALLS apiServiceCall = context.API_SERVICE_CALLS.Create();
                apiServiceCall.INSTANCE_ID = instanceID;
                apiServiceCall.RESULT_READY = false;
                apiServiceCall.API_SERVICE_OPERATION_ID = operationID;
                apiServiceCall.CONSUMER_CERTIFICATE_ID = certificateID;
                apiServiceCall.START_TIME = DateTime.Now;
                apiServiceCall.RESULT_RETURNED = false;
                
                //context
                apiServiceCall.CALL_CONTEXT = remark;
                apiServiceCall.CONTEXT_ADMINISTRATION_NAME = administrationName;
                apiServiceCall.CONTEXT_ADMINISTRATION_OID = administrationOId;
                apiServiceCall.CONTEXT_EMPLOYEE_ADITIONAL_ID = employeeAditionalIdentifier;
                apiServiceCall.CONTEXT_EMPLOYEE_NAMES = employeeNames;
                apiServiceCall.CONTEXT_EMPLOYEE_POSITION = employeePosition;
                apiServiceCall.CONTEXT_EMPLOYEE_IDENTIFIER = employeeIdentifier;
                apiServiceCall.CONTEXT_LAW_REASON = lawReason;
                apiServiceCall.CONTEXT_RESPONSIBLE_NAMES = responsiblePersonIdentifier;
                apiServiceCall.CONTEXT_SERIVCE_URI = serviceURI;
                apiServiceCall.CONTEXT_SERVICE_TYPE = serviceType;

                apiServiceCall.EID_TOKEN = EIDToken;
                apiServiceCall.OID_TOKEN = OIDToken;
                apiServiceCall.CLIENT_IP_ADDRESS = clientIPAddress;

                context.API_SERVICE_CALLS.Add(apiServiceCall);
                context.SaveChanges();
                if (logData != null)
                {
                    Task.Run(
                       () => {
                           string error = null;
                           var logRecord = new RegiXLogRecordType()
                           {
                               APIServiceCallID = apiServiceCall.API_SERVICE_CALL_ID,
                               StartTime = apiServiceCall.START_TIME,
                               Request = request,
                               APIServiceOperationID = operationID,
                               APIServiceOperationIDSpecified = true,
                               ConsumerCertificateID = certificateID,
                               ConsumerCertificateIDSpecified = true,
                               CallContext = remark,
                               ContextAdministrationName = administrationName,
                               ContextAdministrationOID = administrationOId,
                               ContextEmployeeAdditionalIdentifier = employeeAditionalIdentifier,
                               ContextEmployeeNames = employeeNames,
                               ContextEmployeePosition = employeePosition,
                               ContextEmployeeIdentifier = employeeIdentifier,
                               ContextLawReason = lawReason,
                               ContextResponsibleNames = responsiblePersonIdentifier,
                               ContextServiceURI = serviceURI,
                               ContextServiceType = serviceType,
                               EIDToken = EIDToken,
                               OIDToken = OIDToken,
                               ClientIPAddres = clientIPAddress,
                               ReportName = adapterOperationName,
                               Consumer = consumerName,
                               ConsumerAdministration = consumerAdmin,
                               Producer = producer,
                               ProducerAdministration = producerAdministration,
                               ConsumerOID = consumerOID
                           };
                           logData.LogRecord(operationFullName, logRecord, error);
                       }
                    );
                }

                return apiServiceCall.API_SERVICE_CALL_ID;
            }
        }

        public static ServiceAndConsumerInformation GetServiceAndConsumerInformation(RegiXContext context, string thumbprint, string contractName, string operationName, string oid)
        {
            ServiceAndConsumerInformation result = null;
            using (context)
            {
                if (string.IsNullOrEmpty(oid))
                {
                    // Try query access from ceritificate configuration
                    IQueryable<ServiceAndConsumerInformation> query = 
                        GetServiceAndConsumerInformationFromCertificate(context, thumbprint, contractName, operationName);
                    result = query.FirstOrDefault();
                    if (result == null || !result.HasAccess.HasValue)
                    {
                        // If certificate has no permissions try query access from consumer role
                        query = GetServiceAndConsumerInformationFromConsumerRole(context, thumbprint, contractName, operationName);
                        var rolesResult = query.FirstOrDefault( sci => sci.HasAccess.HasValue && sci.HasAccess.Value);
                        result = rolesResult ?? result;
                    }
                }
                else
                {
                    //При търсене по OID, се следва следната логика:
                    //Търси се по OID на консуматора, и ако той има повече от един сертифиакт, се взима първият му сертификат подредени по 
                    //Активност(намаляващо) и Име(намаляващо)
                    result = new ServiceAndConsumerInformation();

                    var apiServicequery = from a in context.API_SERVICES
                                          join o in context.API_SERVICE_OPERATIONS
                                              on a.API_SERVICE_ID equals o.API_SERVICE_ID
                                          join aso in context.API_SERVICE_ADAPTER_OPERATIONS
                                              on o.API_SERVICE_OPERATION_ID equals aso.API_SERVICE_OPERATION_ID
                                          join ao in context.ADAPTER_OPERATIONS
                                              on aso.ADAPTER_OPERATION_ID equals ao.ADAPTER_OPERATION_ID
                                          join regAdapter in context.REGISTER_ADAPTERS
                                            on ao.REGISTER_ADAPTER_ID equals regAdapter.REGISTER_ADAPTER_ID
                                          join register in context.REGISTERS
                                            on regAdapter.REGISTER_ID equals register.REGISTER_ID
                                          join producerAdmin in context.ADMINISTRATIONS on register.ADMINISTRATION_ID equals producerAdmin.ADMINISTRATION_ID
                                          where a.CONTRACT == contractName &&
                                              o.NAME == operationName
                                          select new
                                          {
                                              Enabled = a.ENABLED,
                                              APIServiceOperationID = o.API_SERVICE_OPERATION_ID,
                                              AdapterOperationID = aso.ADAPTER_OPERATION_ID,
                                              ProducerAdministration = producerAdmin.NAME,
                                              Producer = register.NAME,
                                              AdapterOperationName = ao.DESCRIPTION
                                          };
                    var apiServiceInfo = apiServicequery.FirstOrDefault();
                    result.Enabled = apiServiceInfo.Enabled;
                    result.APIServiceOperationID = apiServiceInfo.APIServiceOperationID;
                    result.AdapterOperationID = apiServiceInfo.AdapterOperationID;
                    result.ProducerAdministration = apiServiceInfo.ProducerAdministration;
                    result.Producer = apiServiceInfo.Producer;
                    result.AdapterOperationName = apiServiceInfo.AdapterOperationName;

                    var consumerQuery = from consumer in context.API_SERVICE_CONSUMERS.Where(c => c.OID == oid)
                                        join cs in context.CONSUMER_CERTIFICATES on consumer.API_SERVICE_CONSUMER_ID equals cs.API_SERVICE_CONSUMER_ID
                                        join coa in context.CERTIFICATE_OPERATION_ACCESS on new { CONSUMER_CERTIFICATE_ID = cs.CONSUMER_CERTIFICATE_ID, ADAPTER_OPERATION_ID = result.AdapterOperationID } equals new { CONSUMER_CERTIFICATE_ID = coa.CONSUMER_CERTIFICATE_ID, ADAPTER_OPERATION_ID = coa.ADAPTER_OPERATION_ID } into coad
                                        from x_coa in coad.DefaultIfEmpty()
                                        join consumerAdmin in context.ADMINISTRATIONS on consumer.ADMINISTRATION_ID equals consumerAdmin.ADMINISTRATION_ID into consumerAdminLeft
                                        from consumerAdmin in consumerAdminLeft.DefaultIfEmpty()
                                        orderby cs.ACTIVE descending, cs.NAME descending
                                        select new
                                        {
                                            ConsumerName = consumer.NAME,
                                            ConsumerOID = consumer.OID,
                                            CertificateID = cs.CONSUMER_CERTIFICATE_ID,
                                            CertificateThumbprint = cs.THUMBPRINT,
                                            IsCertificateActive = cs.ACTIVE,
                                            HasAccess = x_coa.HAS_ACCESS,
                                            ConsumerAdmin = consumerAdmin.NAME
                                        };
                    var consumerInfo = consumerQuery.FirstOrDefault();

                    result.ConsumerName = consumerInfo.ConsumerName;
                    result.ConsumerOID = consumerInfo.ConsumerOID;
                    result.CertificateID = consumerInfo.CertificateID;
                    result.CertificateThumbprint = consumerInfo.CertificateThumbprint;
                    result.IsCertificateActive = consumerInfo.IsCertificateActive;
                    result.HasAccess = consumerInfo.HasAccess;
                    result.ConsumerAdmin = consumerInfo.ConsumerAdmin;
                    //var query =
                    //from a in context.API_SERVICES
                    //join o in context.API_SERVICE_OPERATIONS
                    //  on a.API_SERVICE_ID equals o.API_SERVICE_ID
                    //join aso in context.API_SERVICE_ADAPTER_OPERATIONS
                    //  on o.API_SERVICE_OPERATION_ID equals aso.API_SERVICE_OPERATION_ID
                    //join ao in context.ADAPTER_OPERATIONS
                    //  on aso.ADAPTER_OPERATION_ID equals ao.ADAPTER_OPERATION_ID
                    //join cs in context.CONSUMER_CERTIFICATES
                    //  on oid equals cs.OID into csd
                    //from x_csd in csd.DefaultIfEmpty()
                    //join coa in context.CERTIFICATE_OPERATION_ACCESS
                    //  on new { CONSUMER_CERTIFICATE_ID = x_csd.CONSUMER_CERTIFICATE_ID, ADAPTER_OPERATION_ID = ao.ADAPTER_OPERATION_ID } equals new { CONSUMER_CERTIFICATE_ID = coa.CONSUMER_CERTIFICATE_ID, ADAPTER_OPERATION_ID = coa.ADAPTER_OPERATION_ID } into coad
                    //from x_coad in coad.DefaultIfEmpty()
                    //join asc in context.API_SERVICE_CONSUMERS
                    //  on x_csd.API_SERVICE_CONSUMER_ID equals asc.API_SERVICE_CONSUMER_ID into ascd
                    //from x_asc in ascd.DefaultIfEmpty()
                    //where a.CONTRACT == contractName &&
                    //      o.NAME == operationName
                    //select new ServiceAndConsumerInformation()
                    //{
                    //    Enabled = a.ENABLED,
                    //    APIServiceOperationID = o.API_SERVICE_OPERATION_ID,
                    //    HasAccess = x_coad.HAS_ACCESS,
                    //    ConsumerName = x_asc.NAME,
                    //    ConsumerOID = x_asc.OID,
                    //    CertificateID = x_csd.CONSUMER_CERTIFICATE_ID,
                    //    CertificateThumbprint = x_csd.THUMBPRINT,
                    //    IsCertificateActive = x_csd.ACTIVE,
                    //    AdapterOperationID = aso.ADAPTER_OPERATION_ID
                    //};

                    //result = query.FirstOrDefault();
                }
            }
            if (result == null)
            {
                result = new ServiceAndConsumerInformation() { HasAccess = false };
            }
            return result;
        }

        /// <summary>
        /// Get ServiceAndConsumerInformation for certificate associated with a consumer role
        /// </summary>
        /// <param name="context">RegiX DB Context</param>
        /// <param name="thumbprint">Certificate's thrumbprint</param>
        /// <param name="contractName">Contract name</param>
        /// <param name="operationName">Operation name</param>
        /// <returns>Retrieved service and consumer information</returns>
        private static IQueryable<ServiceAndConsumerInformation> GetServiceAndConsumerInformationFromConsumerRole(RegiXContext context, string thumbprint, string contractName, string operationName)
        {
            return from a in context.API_SERVICES
                   join o in context.API_SERVICE_OPERATIONS
                     on a.API_SERVICE_ID equals o.API_SERVICE_ID
                   join aso in context.API_SERVICE_ADAPTER_OPERATIONS
                     on o.API_SERVICE_OPERATION_ID equals aso.API_SERVICE_OPERATION_ID
                   join ao in context.ADAPTER_OPERATIONS
                     on aso.ADAPTER_OPERATION_ID equals ao.ADAPTER_OPERATION_ID
                   join regAdapter in context.REGISTER_ADAPTERS
                     on ao.REGISTER_ADAPTER_ID equals regAdapter.REGISTER_ADAPTER_ID
                   join register in context.REGISTERS
                     on regAdapter.REGISTER_ID equals register.REGISTER_ID
                   join producerAdmin in context.ADMINISTRATIONS on register.ADMINISTRATION_ID equals producerAdmin.ADMINISTRATION_ID
                   join cs in context.CONSUMER_CERTIFICATES
                     on thumbprint.ToLower() equals cs.THUMBPRINT into csd
                   from x_csd in csd.DefaultIfEmpty()
                   join ccr in context.CERTIFICATE_CONSUMER_ROLE on x_csd.CONSUMER_CERTIFICATE_ID equals ccr.CONSUMER_CERTIFICATE_ID
                   join coa in context.CONSUMER_ROLE_OPERATION_ACCESS
                     on new
                     {
                         CONSUMER_CERTIFICATE_ID = ccr.CONSUMER_ROLE_ID,
                         ADAPTER_OPERATION_ID = ao.ADAPTER_OPERATION_ID
                     } equals
                       new
                       {
                           CONSUMER_CERTIFICATE_ID = coa.CONSUMER_ROLE_ID,
                           ADAPTER_OPERATION_ID = coa.ADAPTER_OPERATION_ID
                       } into coad
                   from x_coad in coad.DefaultIfEmpty()
                   join asc in context.API_SERVICE_CONSUMERS
                     on x_csd.API_SERVICE_CONSUMER_ID equals asc.API_SERVICE_CONSUMER_ID into ascd
                   from x_asc in ascd.DefaultIfEmpty()
                   join consumerAdmin in context.ADMINISTRATIONS on x_asc.ADMINISTRATION_ID equals consumerAdmin.ADMINISTRATION_ID into consumerAdminLeft
                   from consumerAdmin in consumerAdminLeft.DefaultIfEmpty()
                   where a.CONTRACT == contractName &&
                         o.NAME == operationName
                   select new ServiceAndConsumerInformation()
                   {
                       Enabled = a.ENABLED,
                       APIServiceOperationID = o.API_SERVICE_OPERATION_ID,
                       HasAccess = x_coad.HAS_ACCESS,
                       ConsumerName = x_asc.NAME,
                       ConsumerOID = x_asc.OID,
                       CertificateID = x_csd.CONSUMER_CERTIFICATE_ID,
                       CertificateThumbprint = x_csd.THUMBPRINT,
                       IsCertificateActive = x_csd.ACTIVE,
                       AdapterOperationID = aso.ADAPTER_OPERATION_ID,
                       AdapterOperationName = ao.DESCRIPTION,
                       ProducerAdministration = producerAdmin.NAME,
                       ConsumerAdmin = consumerAdmin.NAME,
                       Producer = register.NAME
                   };
        }

        /// <summary>
        /// Get ServiceAndConsumerInformation for certificate
        /// </summary>
        /// <param name="context">RegiX DB Context</param>
        /// <param name="thumbprint">Certificate's thrumbprint</param>
        /// <param name="contractName">Contract name</param>
        /// <param name="operationName">Operation name</param>
        /// <returns>Retrieved service and consumer information</returns>
        private static IQueryable<ServiceAndConsumerInformation> GetServiceAndConsumerInformationFromCertificate(RegiXContext context, string thumbprint, string contractName, string operationName)
        {
            return from a in context.API_SERVICES
                   join o in context.API_SERVICE_OPERATIONS
                     on a.API_SERVICE_ID equals o.API_SERVICE_ID
                   join aso in context.API_SERVICE_ADAPTER_OPERATIONS
                     on o.API_SERVICE_OPERATION_ID equals aso.API_SERVICE_OPERATION_ID
                   join ao in context.ADAPTER_OPERATIONS
                     on aso.ADAPTER_OPERATION_ID equals ao.ADAPTER_OPERATION_ID
                   join regAdapter in context.REGISTER_ADAPTERS
                     on ao.REGISTER_ADAPTER_ID equals regAdapter.REGISTER_ADAPTER_ID
                   join register in context.REGISTERS
                     on regAdapter.REGISTER_ID equals register.REGISTER_ID
                   join producerAdmin in context.ADMINISTRATIONS on register.ADMINISTRATION_ID equals producerAdmin.ADMINISTRATION_ID
                   join cs in context.CONSUMER_CERTIFICATES
                     on thumbprint.ToLower() equals cs.THUMBPRINT into csd
                   from x_csd in csd.DefaultIfEmpty()
                   join coa in context.CERTIFICATE_OPERATION_ACCESS
                     on new { CONSUMER_CERTIFICATE_ID = x_csd.CONSUMER_CERTIFICATE_ID, ADAPTER_OPERATION_ID = ao.ADAPTER_OPERATION_ID } equals new { CONSUMER_CERTIFICATE_ID = coa.CONSUMER_CERTIFICATE_ID, ADAPTER_OPERATION_ID = coa.ADAPTER_OPERATION_ID } into coad
                   from x_coad in coad.DefaultIfEmpty()
                   join asc in context.API_SERVICE_CONSUMERS
                     on x_csd.API_SERVICE_CONSUMER_ID equals asc.API_SERVICE_CONSUMER_ID into ascd
                   from x_asc in ascd.DefaultIfEmpty()
                   join consumerAdmin in context.ADMINISTRATIONS on x_asc.ADMINISTRATION_ID equals consumerAdmin.ADMINISTRATION_ID into consumerAdminLeft
                   from consumerAdmin in consumerAdminLeft.DefaultIfEmpty()
                   where a.CONTRACT == contractName &&
                         o.NAME == operationName
                   select new ServiceAndConsumerInformation()
                   {
                       Enabled = a.ENABLED,
                       APIServiceOperationID = o.API_SERVICE_OPERATION_ID,
                       HasAccess = x_coad.HAS_ACCESS,
                       ConsumerName = x_asc.NAME,
                       ConsumerOID = x_asc.OID,
                       CertificateID = x_csd.CONSUMER_CERTIFICATE_ID,
                       CertificateThumbprint = x_csd.THUMBPRINT,
                       IsCertificateActive = x_csd.ACTIVE,
                       AdapterOperationID = aso.ADAPTER_OPERATION_ID,
                       AdapterOperationName = ao.DESCRIPTION,
                       ProducerAdministration = producerAdmin.NAME,
                       ConsumerAdmin = consumerAdmin.NAME,
                       Producer = register.NAME
                   };
        }

        public static void UpdateAPIServiceCall(RegiXContext context, Guid instanceID, bool? resultReady = null, bool? resultReturned = null)
        {
            using (context)
            {
                DateTime? endDateTime = null;
                string setClause = "";
                if (resultReady.HasValue)
                {
                    setClause += string.Format("RESULT_READY = {0} ", (short)((resultReady.Value) ? 1 : 0));
                }
                if (resultReturned.HasValue)
                {
                    if (string.IsNullOrEmpty(setClause))
                    {
                        setClause += string.Format("RESULT_RETURNED = {0} ", (short)((resultReturned.Value) ? 1 : 0));
                    }
                    else
                    {
                        setClause += string.Format(", RESULT_RETURNED = {0} ", (short)((resultReturned.Value) ? 1 : 0));
                    }

                    if (resultReturned.Value)
                    {
                        if (string.IsNullOrEmpty(setClause))
                        {
                            setClause += "END_TIME = {0} ";
                        }
                        else
                        {
                            setClause += ", END_TIME = {0} ";
                        }
                        endDateTime = DateTime.Now;
                    }
                }
                if (endDateTime.HasValue)
                {


                    context.Database.ExecuteSqlCommand(
                       string.Format("UPDATE API_SERVICE_CALLS SET {0} WHERE INSTANCE_ID= {1}", setClause),
                       endDateTime.Value,
                       instanceID.ToByteArray()
                   );
                }
                else if (!string.IsNullOrEmpty(setClause))
                {
                    context.Database.ExecuteSqlCommand(
                       string.Format("UPDATE API_SERVICE_CALLS SET {0} WHERE INSTANCE_ID= {1}", setClause),
                       instanceID.ToByteArray()
                   );
                }
            }
        }

        public static void UpdateAPIServiceCall(RegiXContext context, decimal apiServiceCallId, ILogRecord logData, bool? resultReady = null, bool? resultReturned = null, bool? hasError = null, string resultContent = null, string errorContent = null)
        {
            using (context)
            {
                var apiServiceCall = context.API_SERVICE_CALLS.Find(apiServiceCallId);

                if (resultReady.HasValue)
                {
                    apiServiceCall.RESULT_READY = resultReady.Value;
                }
                if (resultReturned.HasValue)
                {
                    apiServiceCall.RESULT_RETURNED = resultReturned.Value;
                    if (resultReturned.Value)
                    {
                        apiServiceCall.END_TIME = DateTime.Now;
                    }
                }
                if (!string.IsNullOrEmpty(resultContent))
                {
                    apiServiceCall.RESULT_CONTENT = resultContent;
                }
                if (!string.IsNullOrEmpty(errorContent))
                {
                    apiServiceCall.ERROR_CONTENT = errorContent;
                }
                apiServiceCall.HAS_ERROR = hasError;
                context.SaveChanges();
                if (logData != null)
                {
                    Task.Run(
                       () =>
                       {
                           var logRecord = new RegiXLogRecordType()
                           {
                               APIServiceCallID = apiServiceCall.API_SERVICE_CALL_ID,
                               StartTime = apiServiceCall.START_TIME.ToUniversalTime(),
                               EndTime = apiServiceCall.END_TIME.Value,
                               EndTimeSpecified = resultReturned.HasValue,
                               ResultReady = apiServiceCall.RESULT_READY,
                               ResultReadySpecified = true,
                               ResultReturned = apiServiceCall.RESULT_RETURNED,
                               ResultReturnedSpecified = true,
                               HasError = hasError.HasValue ? hasError.Value : false,
                               HasErrorSpecified = hasError.HasValue,
                               RequestDuration = (apiServiceCall.END_TIME.Value - apiServiceCall.START_TIME).Ticks / TimeSpan.TicksPerMillisecond,
                               RequestDurationSpecified = true

                           };
                           logData.LogRecord("", logRecord, null);
                       }
                    );
                }
            }
        }

        public static void AddAPIServiceOperationLog(RegiXContext context, decimal serviceCallID, string contractName, string operatioName, DateTime startTime, DateTime endTime)
        {
            using (context)
            {
                API_SERVICE_CALLS apiServiceCall = context.API_SERVICE_CALLS.Where(sc => sc.API_SERVICE_CALL_ID == serviceCallID).SingleOrDefault();
                API_SERVICE_OPERATIONS apiServiceOperation = context.API_SERVICE_OPERATIONS.Where(so => so.NAME == operatioName && so.API_SERVICES.CONTRACT == contractName).SingleOrDefault();
                if (apiServiceCall != null && apiServiceOperation != null)
                {
                    API_SERVICE_OPERATION_LOG operationLog = context.API_SERVICE_OPERATION_LOG.Create();
                    //TODO: Why this line is commented?
                    //operationLog.api = apiServiceCall;
                    operationLog.START_TIME = startTime;
                    operationLog.END_TIME = endTime;
                    operationLog.API_SERVICE_OPERATIONS = apiServiceOperation;
                    context.API_SERVICE_OPERATION_LOG.Add(operationLog);
                    context.SaveChanges();
                }
            }
        }

        public static void AddAdapterOperationLog(RegiXContext context, Guid instanceID, decimal registerAdapterID, string operationName, DateTime StartTime, DateTime endTime)
        {
            using (context)
            {
                decimal? adapterOperationID =
                        context
                        .ADAPTER_OPERATIONS
                        .Where(ao => ao.REGISTER_ADAPTER_ID == registerAdapterID && ao.NAME == operationName)
                        .Select(ao => ao.ADAPTER_OPERATION_ID)
                        .SingleOrDefault();

                decimal? apiServiceCallID = context.API_SERVICE_CALLS.Where(sc => sc.INSTANCE_ID == instanceID).Select(sc=>sc.API_SERVICE_CALL_ID).SingleOrDefault();
                if (adapterOperationID.HasValue && apiServiceCallID.HasValue)
                {
                    ADAPTER_OPERATION_LOG operationLog = context.ADAPTER_OPERATION_LOG.Create();
                    context.ADAPTER_OPERATION_LOG.Add(operationLog);
                    operationLog.ADAPTER_OPERATION_ID = adapterOperationID.Value;
                    operationLog.API_SERVICE_CALL_ID = apiServiceCallID.Value;
                    operationLog.START_TIME = StartTime;
                    operationLog.END_TIME = endTime;
                    context.SaveChanges();
                }
            }
        }
        
        [Obsolete]
        public static void AddAdapterOperationLog(
            RegiXContext context, 
            decimal apiServiceCallId, 
            decimal registerAdapterID, 
            string operationName, 
            DateTime startTime, 
            DateTime endTime)
        {
            using (context)
            {
                context.Database.ExecuteSqlCommand(
                    "INSERT INTO ADAPTER_OPERATION_LOG(ADAPTER_OPERATION_ID, API_SERVICE_CALL_ID, START_TIME, END_TIME) " +
                    "VALUES( " + //ADAPTER_OPERATION_LOG_S.Nextval, " +
                    "        (SELECT ADAPTER_OPERATION_ID " +
                    "           FROM ADAPTER_OPERATIONS " +
                    "          WHERE REGISTER_ADAPTER_ID = @p_register_adapter_id " +
                    "            AND NAME = @p_operation_name), " +
                    "       @p_api_service_call_id, " +
                    "       @p_start_time, " +
                    "       @p_end_time)",
                     new object[]
                        {
                            new SqlParameter("@p_register_adapter_id", registerAdapterID),
                            new SqlParameter("@p_operation_name",  operationName),
                            new SqlParameter("@p_api_service_call_id",  apiServiceCallId),
                            new SqlParameter("@p_start_time",  startTime),
                            new SqlParameter("@p_end_time",  endTime)
                        }
                    );
            }
        }

        public static void AddAdapterOperationLog(
            RegiXContext context,
            decimal apiServiceCallId,
            decimal adapterOperationID,
            DateTime startTime,
            DateTime endTime)
        {
            using (context)
            {
                var adapterOperationLog = context.ADAPTER_OPERATION_LOG.Create();
                adapterOperationLog.API_SERVICE_CALL_ID = apiServiceCallId;
                adapterOperationLog.ADAPTER_OPERATION_ID = adapterOperationID;
                adapterOperationLog.START_TIME = startTime;
                adapterOperationLog.END_TIME = endTime;
                context.ADAPTER_OPERATION_LOG.Add(adapterOperationLog);
                context.SaveChanges();
            }
        }


        public static void AddAdapterOperationErrorLog(
            RegiXContext context, 
            Guid instanceID, 
            decimal registerAdapterID, 
            string operationName,
            DateTime logTime, 
            string message,
            string errorContent)
        {
            using (context)
            {
                decimal? adapterOperationID =
                        context
                        .ADAPTER_OPERATIONS
                        .Where(ao => ao.REGISTER_ADAPTER_ID == registerAdapterID && ao.NAME == operationName)
                        .Select(ao => ao.ADAPTER_OPERATION_ID)
                        .Single();

                decimal? apiServiceOperationID =
                    context
                    .API_SERVICE_CALLS
                    .Where(sc => sc.INSTANCE_ID == instanceID)
                    .Select(sc => sc.API_SERVICE_OPERATION_ID)
                    .SingleOrDefault();

                if (adapterOperationID.HasValue && apiServiceOperationID.HasValue)
                {
                    OPERATIONS_ERROR_LOG operationLog = context.OPERATIONS_ERROR_LOG.Create();
                    context.OPERATIONS_ERROR_LOG.Add(operationLog);
                    operationLog.ADAPTER_OPERATION_ID = adapterOperationID.Value;
                    operationLog.API_SERVICE_OPERATION_ID = apiServiceOperationID.Value;
                    operationLog.LOG_TIME = logTime;
                    operationLog.ERROR_CONTENT = errorContent;
                    operationLog.ERROR_MESSAGE = message;
                    context.SaveChanges();
                }
            }
        }

        [Obsolete]
        public static void AddAdapterOperationErrorLog(
            RegiXContext context,
            decimal apiServiceCallId,
            decimal registerAdapterID,
            string operationName,
            DateTime logTime,
            string message,
            string errorContent)
        {
            using (context)
            {
                context.Database.ExecuteSqlCommand(
                
                 "INSERT INTO " +
                 " OPERATIONS_ERROR_LOG( LOG_TIME, ERROR_MESSAGE, ERROR_CONTENT, ADAPTER_OPERATION_ID, API_SERVICE_OPERATION_ID) " +
                 " VALUES(  " +
                // "  OPERATIONS_ERROR_LOG_s.Nextval,  " +
                 "  @p_log_time,  " +
                 " @p_message,  " +
                 " @p_error_content,  " +
                 " (SELECT adapter_operation_id FROM ADAPTER_OPERATIONS WHERE ADAPTER_OPERATIONS.Register_Adapter_Id = @p_register_adapter_id AND NAME= @p_operation_name), " +
                 " (SELECT API_SERVICE_OPERATION_ID FROM API_SERVICE_CALLS WHERE API_SERVICE_CALL_ID = @p_api_service_call_id) " +
                 " ) ",
                     new object[]
                        {
                            new SqlParameter("p_log_time",  logTime),
                            new SqlParameter("p_message",  message),
                            new SqlParameter("p_error_content", errorContent),
                            new SqlParameter("p_register_adapter_id", registerAdapterID),
                            new SqlParameter("p_operation_name",operationName),
                            new SqlParameter("p_api_service_call_id", apiServiceCallId)
                        }
                    );
            }
        }

        public static void AddAdapterOperationErrorLog(
           RegiXContext context,
           decimal apiServiceOperationID,
           decimal adapterOperationID,
           decimal? apiServiceCallId,
           DateTime logTime,
           string message,
           string errorContent,
           ILogRecord logData)
        {
            using (context)
            {
                var errorLog = context.OPERATIONS_ERROR_LOG.Create();
                errorLog.LOG_TIME = logTime;
                errorLog.ERROR_MESSAGE = message;
                errorLog.ERROR_CONTENT = errorContent;
                errorLog.ADAPTER_OPERATION_ID = adapterOperationID;
                errorLog.API_SERVICE_OPERATION_ID = apiServiceOperationID;
                errorLog.API_SERVICE_CALL_ID = apiServiceCallId;
                context.OPERATIONS_ERROR_LOG.Add(errorLog);
                context.SaveChanges();

                if (apiServiceCallId.HasValue && logData != null)
                {
                    Task.Run(
                        () =>
                        {
                            DateTime startTime = DateTime.MinValue;
                            string error = null;
                            try
                            {
                                using (var innnerContext = DbContextUtils.GetDbContext())
                                {
                                    startTime =
                                        innnerContext
                                        .API_SERVICE_CALLS.Find(apiServiceCallId.Value).START_TIME.ToUniversalTime();
                                }
                            }
                            catch (Exception ex)
                            {
                                error = ex.Message;
                            }
                            var logRecord = new RegiXLogRecordType()
                            {
                                APIServiceCallID = apiServiceCallId.Value,
                                StartTime = startTime,
                                ErrorLogTime = logTime,
                                ErrorLogTimeSpecified = true,
                                ErrorMessage = message,
                                ErrorContent = errorContent
                            };
                            logData.LogRecord("", logRecord, error);
                        }
                    );
                }
            }
        }

        public static void GetContractAndOperationByInstanceID(RegiXContext context, decimal serviceCallID, out string contractName, out string operationName)
        {
            using (context)
            {
                API_SERVICE_CALLS serviceCall =
                    context.API_SERVICE_CALLS
                        .Include("API_SERVICE_OPERATIONS")
                        .Include("API_SERVICE_OPERATIONS.API_SERVICES")
                        .Where(asc => asc.API_SERVICE_CALL_ID == serviceCallID)
                        .Select(asc => asc)
                        .Single();
                operationName = Regex.Replace(serviceCall.API_SERVICE_OPERATIONS.NAME, "Execute$", "CheckResult");
                contractName = serviceCall.API_SERVICE_OPERATIONS.API_SERVICES.CONTRACT;
            }
        }

        public static decimal GetCertificateIDByInstanceID(RegiXContext context, Guid instanceID)
        {
            using (context)
            {
                return context.API_SERVICE_CALLS.Where(asc => asc.INSTANCE_ID == instanceID).Select(asc => asc.CONSUMER_CERTIFICATE_ID).Single();
            }
        }

        public static API_SERVICE_CALLS SelectAPIServiceCall(RegiXContext context, decimal apiServiceCallID)
        {
            using (context)
            {
                return context.API_SERVICE_CALLS.Where(sc => sc.API_SERVICE_CALL_ID == apiServiceCallID).FirstOrDefault();
            }
        }
    }
}
