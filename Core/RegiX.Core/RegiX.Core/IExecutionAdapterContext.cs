using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.DataContracts.Health;
using TechnoLogica.RegiX.Common.DataContracts.Parameter;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.Core.Data.Interfaces;

namespace TechnoLogica.RegiX.Core
{
    /// <summary>
    /// Интерфейс на контекст за изпълнение на операции върху адаптер
    /// </summary>
    public interface IExecutionAdapterContext
    {
        /// <summary>
        /// Инициализира контекст за изпълнение
        /// </summary>
        /// <param name="serviceRequest">Заявка за изпълнение на операция</param>
        void Initialize(IServiceRequestData serviceRequest);

        /// <summary>
        /// Контракт на API услугата
        /// </summary>
        string APIContractName { get; set; }

        /// <summary>
        /// Име на операция на API услугата
        /// </summary>
        string APIOperationName { get; set; }

        /// <summary>
        /// Идентификатор на APIService извикване
        /// </summary>
        decimal ApiServiceCallId { get; set; }

        /// <summary>
        /// Клиентско IP
        /// </summary>
        string ClientIP { get; set; }

        /// <summary>
        /// Допълнителен параметър
        /// </summary>
        AdapterAdditionalParameters AdditionalParameter { get; set; }

        /// <summary>
        /// Информация за услугата и консуматора
        /// </summary>
        ServiceAndConsumerInformation ServiceInformation { get; set; }

        /// <summary>
        /// Идентификатор на инстанцията (Може да бъде премахнато)
        /// </summary>
        [Obsolete]
        Guid InstanceID { get; }

        /// <summary>
        /// OID токен
        /// </summary>
        string TokenOID { get; set; }

        /// <summary>
        /// Обработка на информацията за адаптера и съответната операция
        /// </summary>
        void ProcessAdapterContractAndOperation();

        /// <summary>
        /// Зареждане на информацията за услугата и консуматора
        /// </summary>
        void LoadServiceAndConsumerInformation();

        /// <summary>
        /// Проверява дали клиента има достъп до заявената операция
        /// </summary>
        /// <param name="result">Обект, в който да бъде записан резултата</param>
        /// <returns>Дали клиента има достъп</returns>
        bool EnsureHasAccess(IErrorInfo result);

        /// <summary>
        /// Проверява дали операцията, която достъпва е активна
        /// </summary>
        /// <param name="result">Обект, в който да бъде записан резултата</param>
        /// <returns>Дали операцията е активна</returns>
        bool EnsureAPIServiceIsEnabled(IErrorInfo result);

        /// <summary>
        /// Изпълнява Execute операцията
        /// </summary>
        /// <param name="request">Заявка</param>
        /// <returns>Върнат резултат</returns>
        ServiceResultData Execute(ServiceRequestData request);

        /// <summary>
        /// Изпълнява операцията за проверка на резултат при асинхронно изпълнение на заявки
        /// </summary>
        /// <param name="checkResult">Информация за подадена заявка</param>
        /// <returns>Върнат резултат</returns>
        ServiceResultData CheckResult(ServiceCheckResultArgument checkResult);

        /// <summary>
        /// Acknowledges that the result of an operation is received
        /// </summary>
        /// <param name="checkResult">Arugment containing the service call id and verification code</param>
        void AcknowledgeResultReceived(ServiceCheckResultArgument checkResult);

        /// <summary>
        /// Инициализира AdditionalParameter обекта с данни от контекста. Позволява създаването на връзка между журнала на адаптера и журнала на ядрото
        /// </summary>
        void InitializeAdditionalParameter();

        /// <summary>
        /// Sets the value of a single parameter of adapter
        /// </summary>
        /// <param name="key">Key of the parameter</param>
        /// <param name="value">String representation of the parameter</param>
        void SetParameter(string key, string value);

        /// <summary>
        /// Sets the value of a list of parameters
        /// </summary>
        /// <param name="parameters">List of parameters</param>
        void SetParameters(Parameters parameters);

        /// <summary>
        /// Gets the definition of all the arguments
        /// </summary>
        /// <returns>All arguments' definitions</returns>
        Parameters GetParameters();

        /// <summary>
        /// Checks a single health check function
        /// </summary>
        /// <param name="key">Key of the health check function</param>
        /// <returns>result of the health check</returns>
        string CheckHealthFunction(string key);

        /// <summary>
        /// Gets the public key of the adapter used for signing responses
        /// </summary>
        /// <returns>The current public key of the certificate used for signing responses</returns>
        string GetPublicKeyString();

        /// <summary>
        /// Get all health check function definitions
        /// </summary>
        /// <returns>The health check definitions</returns>
        HealthCheckFunctions GetHealthCheckFunctions();

        /// <summary>
        /// Checks the accessibility of the adapter by accepting and returning a data argument
        /// </summary>
        /// <param name="data">Data to be returned</param>
        /// <returns>The data response</returns>
        byte[] Ping(byte[] data);

        /// <summary>
        /// Gets the version of the adapter
        /// </summary>
        /// <returns>Version of the adapter</returns>
        string GetAdapterVersion();

        /// <summary>
        /// Gets the adapter's uptime
        /// </summary>
        /// <returns>Adapter's uptime</returns>
        uint GetAdapterUptime();

        /// <summary>
        /// Gets the system's uptime
        /// </summary>
        /// <returns>System's uptime</returns>
        uint GetSystemUptime();

        /// <summary>
        /// Gets information for the host machine
        /// </summary>
        /// <returns>Host machine information</returns> 
        string GetHostMachineInfo();

        /// <summary>
        /// Checks the connection to the register
        /// </summary>
        /// <returns>Result of the check</returns>
        string CheckRegisterConnection();
    }
}
