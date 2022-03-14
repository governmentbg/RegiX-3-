using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.Common.Utils;
using TechnoLogica.RegiX.Core.Data.Interfaces;
using TechnoLogica.RegiX.Core.Helpers.Interfaces;
using TechnoLogica.RegiX.Core.Interfaces;
using TechnoLogica.RegiX.Core.Properties;
using TechnoLogica.RegiX.Common.DataContracts.Parameter;
using TechnoLogica.RegiX.Common.DataContracts.Health;

namespace TechnoLogica.RegiX.Core
{
    /// <summary>
    /// Контекст за изпълнение на операции върху адаптер
    /// </summary>
    /// <typeparam name="I">Тип на адаптера</typeparam>
    [Export(typeof(ExecutionAdapterContext<>))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ExecutionAdapterContext<I> : IExecutionAdapterContext
        where I : IAdapterService
    {
        /// <summary>
        /// Интерфейс към базата данни
        /// </summary>
        [Import]
        public IRegiXData RegiXData { get; set; }

        /// <summary>
        /// Composition Container - необходим за инстанциране на IRegisterChannelFacotry<I>, който не може да бъде import-нат директно като property.
        /// </summary>
        [Import]
        public CompositionContainer CompositionContainer { get; set; }

        /// <summary>
        /// Интерфейс към помощния клас за обработка на STS информацията
        /// </summary>
        [Import]
        public ISTSHelper STSHelper { get; set; }

        /// <summary>
        /// Интерфейс към помощния клас за обработка на IP информация
        /// </summary>
        [Import]
        public IIPHelper IPHelper { get; set; }

        /// <summary>
        /// Интерфейс към помощния клас за обработка на информация от сертификати
        /// </summary>
        [Import]
        public ICertificateHelper CertificateHelper { get; set; }

        /// <summary>
        /// Logger
        /// </summary>
        private static readonly log4net.ILog Logger =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Инициализация на контракта на адаптера извлечено от I
        /// </summary>
        private Lazy<string> _adapterContractName = new Lazy<string>(() => typeof(I).FullName);

        /// <summary>
        /// Инизицализация на идентификатор на регистър
        /// </summary>
        private decimal _registerAdapterID = 0;

        /// <summary>
        /// Клиентско IP
        /// </summary>
        public string ClientIP { get; set; }

        /// <summary>
        /// OID токен
        /// </summary>
        public string TokenOID { get; set; }

        /// <summary>
        /// Контракт на API услугата
        /// </summary>
        public string APIContractName { get; set; }

        /// <summary>
        /// Име на операция на API услугата
        /// </summary>
        public string APIOperationName { get; set; }

        /// <summary>
        /// Идентификатор на APIService извикване
        /// </summary>
        public decimal ApiServiceCallId { get; set; }

        /// <summary>
        /// Информация за услугата и консуматора
        /// </summary>
        public ServiceAndConsumerInformation ServiceInformation { get; set; }

        /// <summary>
        /// Допълнителен параметър
        /// </summary>
        public AdapterAdditionalParameters AdditionalParameter { get; set; }

        /// <summary>
        /// Име на операция на адаптер
        /// </summary>
        public string AdapterOperationName { get; set; }

        /// <summary>
        /// Поле съхраняващо идентификатор на инстанция
        /// </summary>
        private Guid instanceID;

        /// <summary>
        /// Идентификатор на инстанция. Може да бъде премахнато
        /// </summary>
        [Obsolete]
        public Guid InstanceID
        {
            get
            {
                if (instanceID == null)
                {
                    instanceID = Guid.NewGuid();
                }
                return instanceID;
            }
        }

        /// <summary>
        /// Инициализира контекст за изпълнение
        /// </summary>
        /// <param name="serviceRequest">Заявка за изпълнение на операция</param>
        public virtual void Initialize(IServiceRequestData serviceRequest)
        {
            if (serviceRequest is IServiceRequestDataWithOperation)
            {
                APIContractName = (serviceRequest as IServiceRequestDataWithOperation).Contract;
                APIOperationName = (serviceRequest as IServiceRequestDataWithOperation).OperationName;
            }
            AdditionalParameter = new AdapterAdditionalParameters();
            AdditionalParameter.EIDToken = serviceRequest.EIDToken;
            AdditionalParameter.SignResult = serviceRequest.SignResult;
            AdditionalParameter.ReturnAccessMatrix = serviceRequest.ReturnAccessMatrix;
            AdditionalParameter.CallContext = serviceRequest.CallContext;
            AdditionalParameter.CitizenEGN = serviceRequest.CitizenEGN;
            AdditionalParameter.EmployeeEGN = serviceRequest.EmployeeEGN;
            AdditionalParameter.CallbackURL = serviceRequest.CallbackURL;
        }

        /// <summary>
        /// Обрабток на контракта на адаптера и неговота операция.
        /// </summary>
        public void ProcessAdapterContractAndOperation()
        {
            //TODO: Resolve from database. If this is implemented the value should be also forwarded to the Adapter's execute operation.
            AdapterOperationName = APIOperationName;
        }

        /// <summary>
        /// Матрица на достъп
        /// </summary>
        public AccessMatrix AccessMatrix
        {
            get
            {
                Dictionary<string, bool> amDictionary = RegiXData.GetPropertyAccess(APIOperationName, RegisterAdapterID, ServiceInformation.CertificateID.Value);
                return AccessMatrix.LoadFromDictionary(amDictionary);
            }
        }

        /// <summary>
        /// Контракт на адаптера
        /// </summary>
        public string AdapterContractName
        {
            get
            {
                return _adapterContractName.Value;
            }
        }

        /// <summary>
        /// Излича идентификатор на адаптер
        /// </summary>
        public decimal RegisterAdapterID
        {
            get
            {
                if (_registerAdapterID == 0)
                {
                    _registerAdapterID = RegiXData.GetRegisterAdapterID(AdapterContractName);
                }
                return _registerAdapterID;
            }
        }

        /// <summary>
        /// Създава Channel за адаптер с контракт I
        /// </summary>
        public I Channel
        {
            get
            {
                return CompositionContainer.GetExportedValue<IRegisterChannelFacotry<I>>().CreateChannel();
            }
        }

        /// <summary>
        /// Зареждане на информацията за услугата и консуматора
        /// </summary>
        public void LoadServiceAndConsumerInformation()
        {
            try
            {
                ClientIP = IPHelper.GetClientIP();
                TokenOID = STSHelper.ExtractOIDFromSAML();
                string certThumb = String.Empty;
                var address = System.ServiceModel.OperationContext.Current?.EndpointDispatcher?.EndpointAddress?.Uri?.Segments?.LastOrDefault();
                switch (address)
                {
                    case "serviceBus":
                    {
                        break;
                    }
                    default:
                    {
                        certThumb = CertificateHelper.ResolveCertificateThumbprint(Settings.Default.ExpectedClientCertificatePlace);
                        break;
                    }
                }
                ServiceInformation = RegiXData.GetServiceAndConsumerInformation(certThumb, APIContractName, APIOperationName, TokenOID);
            }
            catch (Exception e)
            {
                Logger.Error(e);
                ClientIP = "";
                ServiceInformation = new ServiceAndConsumerInformation();
            }
        }

        /// <summary>
        /// Проверява дали клиента има достъп до заявената операция
        /// </summary>
        /// <param name="resultData">Обект, в който да бъде записан резултата</param>
        /// <returns>Дали клиента има достъп</returns>
        public bool EnsureHasAccess(IErrorInfo resultData)
        {
            bool isCertificateFound = ServiceInformation.CertificateID.HasValue;

            if (!isCertificateFound)
            {
                resultData.Error = "Access denied! ConsumerCertificate is not found.";
                return false;
            }

            bool isCertificateActive = ServiceInformation.IsCertificateActive.HasValue && ServiceInformation.IsCertificateActive.Value;

            if (!isCertificateActive)
            {
                resultData.Error = "Access denied! ConsumerCertificate is not active";
                return false;
            }

            bool hasAccess = ServiceInformation.HasAccess.HasValue && ServiceInformation.HasAccess.Value;

            if (!hasAccess)
            {
                resultData.Error = "Access denied!";
                return false;
            }
            return hasAccess && isCertificateActive && isCertificateFound;
        }

        /// <summary>
        /// Проверява дали операцията, която достъпва е активна
        /// </summary>
        /// <param name="resultData">Обект, в който да бъде записан резултата</param>
        /// <returns>Дали операцията е активна</returns>
        public bool EnsureAPIServiceIsEnabled(IErrorInfo resultData)
        {
            bool serviceEnabled = ServiceInformation.Enabled;
            if (!serviceEnabled)
            {
                resultData.Error = string.Format("Service is disabled!");
            }
            return serviceEnabled;
        }

        /// <summary>
        /// Изпълнява Execute операцията
        /// </summary>
        /// <param name="request">Заявка</param>
        /// <returns>Върнат резултат</returns>
        public ServiceResultData Execute(ServiceRequestData request)
        {
            ServiceResultData resultData;
            DateTime startTime = DateTime.Now;
            try
            {
                resultData =
                    Channel.Execute(request, AccessMatrix, AdditionalParameter);
            }
            catch (Exception ex)
            {
                string message;
                string stackTrace = ExceptionManager.GetExceptionFullStackTrace(ex);
                string adapterResultMessage;
                ExceptionManager.ExtractMessageAndStackTrace(ex, out adapterResultMessage, out message);
                RegiXData.AddAdapterOperationErrorLog(
                    ServiceInformation.APIServiceOperationID,
                    ServiceInformation.AdapterOperationID,
                    ApiServiceCallId,
                    DateTime.Now,
                    message,
                    stackTrace
                    );
                resultData = new ServiceResultData() { IsReady = true, HasError = true, Error = adapterResultMessage };
            }
            RegiXData.AddAdapterOperationLog(ApiServiceCallId, ServiceInformation.AdapterOperationID, startTime, DateTime.Now);
            return resultData;
        }

        /// <summary>
        /// Изпълнява операцията за проверка на резултат при асинхронно изпълнение на заявки
        /// </summary>
        /// <param name="checkResult">Информация за подадена заявка</param>
        /// <returns>Върнат резултат</returns>
        public ServiceResultData CheckResult(ServiceCheckResultArgument checkResult)
        {
            ServiceResultData resultData;
            DateTime startTime = DateTime.Now;
            try
            {
                resultData =
                    Channel.CheckResult(checkResult);
            }
            catch (Exception ex)
            {
                string message;
                string stackTrace = ExceptionManager.GetExceptionFullStackTrace(ex);
                string adapterResultMessage;
                ExceptionManager.ExtractMessageAndStackTrace(ex, out adapterResultMessage, out message);
                //APIServiceCallsData.AddAdapterOperationErrorLog(
                //    DbContextUtils.GetDbContext(),
                //    ServiceInformation.APIServiceOperationID,
                //    ServiceInformation.AdapterOperationID,
                //    ApiServiceCallId,
                //    DateTime.Now,
                //    message,
                //    stackTrace
                //    );
                resultData = new ServiceResultData() { IsReady = true, HasError = true, Error = adapterResultMessage };
            }
            // APIServiceCallsData.AddAdapterOperationLog(DbContextUtils.GetDbContext(), ApiServiceCallId, ServiceInformation.AdapterOperationID, startTime, DateTime.Now);
            return resultData;
        }

        /// <summary>
        /// Sends the acknowledge message to the adapter. After the acknowledge message is received
        /// the adapter should remove the persisted information for the message with the provided 
        /// ServiceCallID
        /// </summary>
        /// <param name="checkResult">Acknoweldge message</param>
        public void AcknowledgeResultReceived(ServiceCheckResultArgument checkResult)
        {
            try
            {
                Channel.AcknowledgeResultReceived(checkResult);
            }
            catch (Exception ex)
            {
                string message;
                string stackTrace = ExceptionManager.GetExceptionFullStackTrace(ex);
                string adapterResultMessage;
                ExceptionManager.ExtractMessageAndStackTrace(ex, out adapterResultMessage, out message);
            }
        }

        /// <summary>
        /// Инициализира AdditionalParameter обекта с данни от контекста. Позволява създаването на връзка между журнала на адаптера и журнала на ядрото
        /// </summary>
        public void InitializeAdditionalParameter()
        {
            AdditionalParameter.ApiServiceCallId = ApiServiceCallId;
            AdditionalParameter.ClientIPAddress = ClientIP;
            AdditionalParameter.OrganizationUnit = ServiceInformation.ConsumerName;
            AdditionalParameter.OrganizationEIK = ServiceInformation.ConsumerOID;
            AdditionalParameter.ConsumerCertificateThumbprint = ServiceInformation.CertificateThumbprint;
        }

        /// <summary>
        /// Sets the value of a single parameter of adapter
        /// </summary>
        /// <param name="key">Key of the parameter</param>
        /// <param name="value">String representation of the parameter</param>
        public void SetParameter(string key, string value)
        {
            Channel.SetParameter(key, value);
        }

        /// <summary>
        /// Sets the value of a list of parameters
        /// </summary>
        /// <param name="parameters">List of parameters</param>
        public void SetParameters(Parameters parameters)
        {
            Channel.SetParameters(parameters.ParameterList);
        }

        /// <summary>
        /// Gets the definition of all the arguments
        /// </summary>
        /// <returns>All arguments' definitions</returns>
        public Parameters GetParameters()
        {
            return Channel.GetParameters();
        }

        /// <summary>
        /// Checks a single health check function
        /// </summary>
        /// <param name="key">Key of the health check function</param>
        /// <returns>result of the health check</returns>
        public string CheckHealthFunction(string key)
        {
            return Channel.CheckHealthFunction(key);
        }

        /// <summary>
        /// Gets the public key of the adapter used for signing responses
        /// </summary>
        /// <returns>The current public key of the certificate used for signing responses</returns>
        public string GetPublicKeyString()
        {
            return Channel.GetPublicKeyString();
        }

        /// <summary>
        /// Get all health check function definitions
        /// </summary>
        /// <returns>The health check definitions</returns>
        public HealthCheckFunctions GetHealthCheckFunctions()
        {
            return Channel.GetHealthCheckFunctions();
        }

        /// <summary>
        /// Checks the accessibility of the adapter by accepting and returning a data argument
        /// </summary>
        /// <param name="data">Data to be returned</param>
        /// <returns>The data response</returns>
        public byte[] Ping(byte[] data)
        {
            return Channel.Ping(data);
        }

        /// <summary>
        /// Gets the version of the adapter
        /// </summary>
        /// <returns>Version of the adapter</returns>
        public string GetAdapterVersion()
        {
            return Channel.GetAdapterVersion();
        }

        /// <summary>
        /// Gets the adapter's uptime
        /// </summary>
        /// <returns>Adapter's uptime</returns>
        public uint GetAdapterUptime()
        {
            return Channel.GetAdapterUptime();
        }

        /// <summary>
        /// Gets the system's uptime
        /// </summary>
        /// <returns>System's uptime</returns>
        public uint GetSystemUptime()
        {
            return Channel.GetSystemUptime();
        }

        /// <summary>
        /// Gets information for the host machine
        /// </summary>
        /// <returns>Host machine information</returns>
        public string GetHostMachineInfo()
        {
            return Channel.GetHostMachineInfo();
        }

        /// <summary>
        /// Checks the connection to the register
        /// </summary>
        /// <returns>Result of the check</returns>
        public string CheckRegisterConnection()
        {
            return Channel.CheckRegisterConnection();
        }
    }
}
