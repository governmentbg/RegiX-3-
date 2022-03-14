using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.Common.Utils;
using TechnoLogica.RegiX.Core.Data.Interfaces;
using TechnoLogica.RegiX.Core.Utils;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace TechnoLogica.RegiX.Core
{
    /// <summary>
    /// Помощен клас управляващ логиката по изпълнение на обръщение към адаптер
    /// </summary>
    [Export(typeof(IAdapterClient<>))]
    public class AdapterClient<IAPI> : IAdapterClient<IAPI>
        where IAPI : IAPIService
    {
        /// <summary>
        /// Интерфейс за извличане на данни от базата
        /// </summary>
        [Import]
        private IRegiXData RegiXData { get; set; }

        /// <summary>
        /// Composition Container
        /// </summary>
        [Import]
        public CompositionContainer CompositionContainer { get; set; }

        /// <summary>
        /// Logger
        /// </summary>
        private static readonly log4net.ILog Logger =
            log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Изпълнява синхронно заявка към адаптер 
        /// </summary>
        /// <typeparam name="I">Интерфейс на адаптера</typeparam>
        /// <typeparam name="R">Тип на връщания обект</typeparam>
        /// <typeparam name="T">Тип на заявката</typeparam>
        /// <param name="func">Функция изпълняваща същинското извикване на адаптера</param>
        /// <param name="serviceRequest">Заявка</param>
        /// <param name="operationName">Name of the calling operation</param>
        /// <returns>Резултат от изпълнениенот на операцията</returns>
        public ServiceResultDataSigned<R, T> Execute<I, R, T>(Expression<Func<I, R, AccessMatrix, AdapterAdditionalParameters, CommonSignedResponse<R, T>>> func, ServiceRequestData<R> serviceRequest,
            [CallerMemberName] string operationName = "")
            where T : class
            where R : class
            where I : IAdapterService
        {
            ServiceResultDataSigned<R, T> result = new ServiceResultDataSigned<R, T>();
            ExecutionContext<I, R, CommonSignedResponse<R, T>> executionContext = CompositionContainer.GetExportedValue<ExecutionContext<I, R, CommonSignedResponse<R, T>>>();
            executionContext.Initialize(serviceRequest);
            executionContext.AdapterFunction = func;
            executionContext.APIContractName = typeof(IAPI).FullName;
            executionContext.APIOperationName = operationName;
            executionContext.ProcessAdapterContractAndOperation(func);
            executionContext.LoadServiceAndConsumerInformation();
            if (executionContext.EnsureHasAccess(result) &&
                executionContext.EnsureAPIServiceIsEnabled(result))
            {
                try
                {
                    executionContext.ApiServiceCallId = AddAPIServiceCall(serviceRequest, executionContext, serviceRequest.Argument.XmlSerialize().ToXmlElement());
                    executionContext.InitializeAdditionalParameter();
                    AdapterResult<CommonSignedResponse<R, T>> adapterResult = executionContext.Execute();
                    //TODO: FRomadapterresult
                    result.FromAdapterResult(adapterResult);
                    result.ServiceCallID = executionContext.ApiServiceCallId;
                    RegiXData.UpdateAPIServiceCall(executionContext.ApiServiceCallId, true, true, adapterResult.HasError);
                }
                catch (Exception e)
                {
                    result.Error = string.Format("Error occurred! {0}", e.Message);
                    //todo insert [API_SERVICE_OPERATION_LOG](executionContext.ApiServiceCallId, executionContext.ServiceInformation.APIServiceOperationID, ex)
                    LogError(result, executionContext, e);
                }
            }
            else
            {
                //todo insert [API_SERVICE_OPERATION_LOG](null, executionContext.ServiceInformation.APIServiceOperationID, result.Error)
                LogError(result, executionContext, null);
            }
            return result;
        }

        /// <summary>
        /// Обработва заявки получени от BaseAPIService имплементацията
        /// </summary>
        /// <param name="apiService">Инстанция на APIService изпълняващ извкиването</param>
        /// <param name="request">Заявка</param>
        /// <returns>Резултат от изпълнението на заявката</returns>
        public ServiceResultData Execute(IAPIService apiService, ServiceRequestData request)
        {
            switch (GetProcessingType(request))
            {
                case ProcessType.TransparentCore:
                    {
                        return ExecuteTransparent(apiService, request);
                    }
                case ProcessType.Normal:
                default:
                    {
                        return ExecuteNormal(apiService, request);
                    }
            }
        }

        /// <summary>
        /// Проверка на резултат от изпълненито на заявка към адаптер
        /// </summary>
        /// <param name="apiService">Инстанция на APIService</param>
        /// <param name="checkResult">Аргумент за проверка на резултат</param>
        /// <returns>Полчунеият резултат от изпълнението на заявката</returns>
        public ServiceResultData CheckResult(IAPIService apiService, ServiceCheckResultArgument checkResult)
        {
            ServiceResultData result = new ServiceResultData();
            IAdapterInfo adapterInfo = RegiXData.GetAdapterInfo(checkResult.ServiceCallID);
            Type adapterType = apiService.GetType().Assembly.GetType(adapterInfo.AdapterServiceContract);
            Type typedExecutionContext = typeof(ExecutionAdapterContext<>).MakeGenericType(adapterType);
            var executionContextExported = CompositionContainer.GetExports(typedExecutionContext, null, null).First().Value;
            IExecutionAdapterContext executionContext = executionContextExported as IExecutionAdapterContext;
            executionContext.APIContractName = adapterInfo.APIServiceContract;
            executionContext.APIOperationName = adapterInfo.APIServiceOperation;
            executionContext.ApiServiceCallId = checkResult.ServiceCallID;
            executionContext.LoadServiceAndConsumerInformation();
            if (executionContext.EnsureHasAccess(result))
                try
                {
                    result = executionContext.CheckResult(checkResult);
                    RegiXData.UpdateAPIServiceCall(executionContext.ApiServiceCallId, result.IsReady, true, result.HasError);
                }
                catch (Exception ex)
                {
                    result.Error = string.Format("Error occurred! {0}", ex.Message);
                    //todo insert [API_SERVICE_OPERATION_LOG](executionContext.ApiServiceCallId, executionContext.ServiceInformation.APIServiceOperationID, ex)
                    LogError(result, executionContext, ex);
                }
            return result;
        }

        /// <summary>
        /// Acknowledges that the result of an operation is received
        /// </summary>
        /// <param name="apiService">API Service instance</param>
        /// <param name="checkResult">Arugment containing the service call id and verification code</param>
        public void AcknowledgeResultReceived(IAPIService apiService, ServiceCheckResultArgument checkResult)
        {
            ServiceResultData result = new ServiceResultData();
            IAdapterInfo adapterInfo = RegiXData.GetAdapterInfo(checkResult.ServiceCallID);
            Type adapterType = apiService.GetType().Assembly.GetType(adapterInfo.AdapterServiceContract);
            Type typedExecutionContext = typeof(ExecutionAdapterContext<>).MakeGenericType(adapterType);
            var executionContextExported = CompositionContainer.GetExports(typedExecutionContext, null, null).First().Value;
            IExecutionAdapterContext executionContext = executionContextExported as IExecutionAdapterContext;
            executionContext.APIContractName = adapterInfo.APIServiceContract;
            executionContext.APIOperationName = adapterInfo.APIServiceOperation;
            executionContext.ApiServiceCallId = checkResult.ServiceCallID;
            executionContext.LoadServiceAndConsumerInformation();
            if (executionContext.EnsureHasAccess(result))
                try
                {
                    executionContext.AcknowledgeResultReceived(checkResult);
                }
                catch (Exception ex)
                {
                    result.Error = string.Format("Error occurred! {0}", ex.Message);
                    LogError(result, executionContext, ex);
                }
        }

        /// <summary>
        /// Стандартно извкивна на операция. Използва се имплементацията в apiServiceа-а
        /// </summary>
        /// <param name="apiService">Инстанция на APIService</param>
        /// <param name="request">Заявка</param>
        /// <returns>Полученият резултат от изпълнението на заявката</returns>
        private ServiceResultData ExecuteNormal(IAPIService apiService, ServiceRequestData request)
        {
            MethodInfo operationMethod = GetMethodByOperationName(apiService.GetType(), request?.OperationName);
            Type parameterType = operationMethod.GetParameters()[0].ParameterType;
            IServiceRequestData parameter = 
                Activator.CreateInstance(parameterType) as IServiceRequestData ??
                throw new ArgumentException(string.Format(StringResources.ArgumentOfOperationCouldntBeCastToServiceRequestData, request?.OperationName));
            parameter.InitializeFrom(request);
            IProvideServiceResultData result = 
                operationMethod.Invoke(apiService, new object[] { parameter }) as IProvideServiceResultData ??
                throw new ArgumentException(string.Format(StringResources.ResultOfOperationCouldntBeCastToIProvideServiceResultData, request?.OperationName));
            return result.ToServiceResultDataSigned();
        }

        /// <summary>
        /// Изпълнение на операцията като се извиква директно адаптера без дасе правят промени по заявката или резултата.
        /// </summary>
        /// <param name="apiService">Инстанция на APIService</param>
        /// <param name="request">Заявка</param>
        /// <returns>Полученият резултат от изпълнението на заявката</returns>
        private ServiceResultData ExecuteTransparent(IAPIService apiService, ServiceRequestData request)
        {
            ServiceResultData result = new ServiceResultData();
            string adapterServiceContract = RegiXData.GetAdapterContractName(request.Contract, request.OperationName);
            Type adapterType = apiService.GetType().Assembly.GetType(adapterServiceContract);
            Type typedExecutionContext = typeof(ExecutionAdapterContext<>).MakeGenericType(adapterType);
            IExecutionAdapterContext executionContext = CompositionContainer.GetExports(typedExecutionContext, null, null).First().Value as IExecutionAdapterContext;
            executionContext.Initialize(request);
            executionContext.ProcessAdapterContractAndOperation();
            executionContext.LoadServiceAndConsumerInformation();
            if (executionContext.EnsureHasAccess(result) &&
                executionContext.EnsureAPIServiceIsEnabled(result))
            {
                try
                {
                    executionContext.ApiServiceCallId = AddAPIServiceCall(request, executionContext, request.Argument.XmlSerialize().ToXmlElement());
                    executionContext.InitializeAdditionalParameter();
                    result = executionContext.Execute(request);
                    result.ServiceCallID = executionContext.ApiServiceCallId;
                    RegiXData.UpdateAPIServiceCall(executionContext.ApiServiceCallId, true, true, result.HasError);
                }
                catch (Exception e)
                {
                    result.Error = string.Format("Error occurred! {0}", e.Message);
                    LogError(result, executionContext, e);
                }
            }
            else
            {
                LogError(result, executionContext);
            }
            return result;
        }

        /// <summary>
        /// Извлича пълното име на операцията
        /// </summary>
        /// <param name="operationMethod">Извикващ метод</param>
        /// <returns>Извлеченото име на операция</returns>
        private string GetOperation(MethodBase operationMethod, out String apiContractName)
        {
            apiContractName =
                  operationMethod
                      .DeclaringType
                      .GetInterfaces()
                      .Where(i => i != typeof(IAPIService))
                      .First()
                      .FullName;
            string operationName = operationMethod.Name;
            return string.Format("{0}.{1}", apiContractName, operationName);
        }

        /// <summary>
        /// Adds an API Service Call to the DB
        /// </summary>
        /// <typeparam name="I">The adapter interface</typeparam>
        /// <param name="serviceRequest">Data for the service request</param>
        /// <param name="executionContext">Execution context</param>
        /// <param name="request">XmlElement of the argument</param>
        /// <returns>API service ID</returns>
        private decimal AddAPIServiceCall(IServiceRequestData serviceRequest, IExecutionAdapterContext executionContext, XmlElement request)
        {
            return
                RegiXData.AddAPIServiceCall(
                    certificateID: executionContext.ServiceInformation.CertificateID.Value,
                    operationID: executionContext.ServiceInformation.APIServiceOperationID,
                    instanceID: executionContext.InstanceID,
                    EIDToken: serviceRequest.EIDToken,
                    OIDToken: executionContext.TokenOID,
                    request: request,
                    operationFullName: string.Format("{0}.{1}", executionContext.APIContractName, executionContext.APIOperationName),
                    serviceURI: serviceRequest.CallContext?.ServiceURI,
                    serviceType: serviceRequest.CallContext?.ServiceType,
                    employeeIdentifier: serviceRequest.CallContext?.EmployeeIdentifier,
                    employeeAditionalIdentifier: serviceRequest.CallContext?.EmployeeAditionalIdentifier,
                    employeeNames: serviceRequest.CallContext?.EmployeeNames,
                    employeePosition: serviceRequest.CallContext?.EmployeePosition,
                    administrationName: serviceRequest.CallContext?.AdministrationName,
                    administrationOId: serviceRequest.CallContext?.AdministrationOId,
                    responsiblePersonIdentifier: serviceRequest.CallContext?.ResponsiblePersonIdentifier,
                    lawReason: serviceRequest.CallContext?.LawReason,
                    remark: serviceRequest.CallContext?.Remark,
                    clientIPAddress: executionContext.ClientIP,
                    consumerName: executionContext.ServiceInformation.ConsumerName,
                    adapterOperationName: executionContext.ServiceInformation.AdapterOperationName,
                    producerAdministration: executionContext.ServiceInformation.ProducerAdministration,
                    producer: executionContext.ServiceInformation.Producer,
                    consumerAdmin: executionContext.ServiceInformation.ConsumerAdmin,
                    consumerOID: executionContext.ServiceInformation.ConsumerOID);
        }

        /// <summary>
        /// Gets the processing type for the request
        /// </summary>
        /// <param name="request">Request</param>
        /// <returns>The appropriate processing type</returns>
        private ProcessType GetProcessingType(ServiceRequestData request)
        {
            if (request.RequestProcessing.HasFlag(RequestProcessing.Asynchronous) ||
                request.RequestProcessing.HasFlag(RequestProcessing.Decrypt) ||
                request.RequestProcessing.HasFlag(RequestProcessing.TransformFromPDF) ||
                request.RequestProcessing.HasFlag(RequestProcessing.Verify) ||
                request.ResponseProcessing.HasFlag(ResponseProcessing.Encrypt) ||
                request.ResponseProcessing.HasFlag(ResponseProcessing.TransformToPDF))
            {
                return ProcessType.TransparentCore;
            }
            else
            {
                return ProcessType.Normal;
            }
        }

        /// <summary>
        /// Gets the method of an API Service by the operation name
        /// </summary>
        /// <param name="type">Type of an APIService</param>
        /// <param name="operationName">Name of the operation</param>
        /// <returns>The appropraite method</returns>
        private MethodInfo GetMethodByOperationName(Type type, string operationName)
        {
            MethodInfo method = type.GetMethod(operationName);
            if (method != null)
            {
                if (method.GetParameters().Length == 0)
                {
                    throw new ArgumentException(string.Format(StringResources.OperationShouldHaveAtLeastOneArgument, operationName));
                }
                return method;
            }
            else
            {
                throw new ArgumentException(string.Format(StringResources.OperationNotFound, operationName));
            }
        }

        /// <summary>
        /// Converts the provided XmlElement to the provided type
        /// </summary>
        /// <param name="argument">XmlElement that should be converted</param>
        /// <param name="type">Type to which the argument should be covnerted</param>
        /// <returns>The converted argument</returns>
        private object GetRequestArgumentObject(XmlElement argument, Type type)
        {
            if (argument != null)
            {
                try
                {
                    return argument.Deserialize(type);
                }
                catch
                { 
                    //TODO: Exception Manager
                    throw new ArgumentException("");// ExceptionManager.GetEntryPointExceptionArgumentExceptionNameByCode("Argument"), "Argument");
                }
            }
            else
            {
                throw new ArgumentException("Element request.Argument is required and it must contain XML content", "Argument");
            }
        }

        /// <summary>
        /// Добавя запис в Log-а
        /// </summary>
        /// <param name="result"></param>
        /// <param name="executionContext"></param>
        /// <param name="e"></param>
        private static void LogError(IErrorInfo result, IExecutionAdapterContext executionContext, Exception e = null)
        {
            var errorInfo =
                new
                {
                    ApiServiceCallId = executionContext.ApiServiceCallId,
                    APIServiceOperationID = executionContext.ServiceInformation?.APIServiceOperationID,
                    Error = result.Error,
                    Result = result.XmlSerialize(),
                    ServiceInformation = executionContext.ServiceInformation.XmlSerialize(),
                    CallContext = executionContext.AdditionalParameter.CallContext.XmlSerialize(),
                    certificateID = executionContext.ServiceInformation.CertificateID,
                    operationID = executionContext.ServiceInformation.APIServiceOperationID,
                    instanceID = executionContext.InstanceID,
                    clientIPAddress = executionContext.ClientIP
                };
            if (e != null)
            {
                Logger.Error(errorInfo, e);
            }
            else
            {
                Logger.Error(errorInfo);
            }
        }

    }
}
