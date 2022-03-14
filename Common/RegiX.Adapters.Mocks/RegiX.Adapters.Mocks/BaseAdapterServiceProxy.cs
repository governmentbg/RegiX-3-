using log4net;
using RegiX.Adapters.Mocks.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Reflection;
using TechnoLogica.RegiX.Adapters.Common;
using TechnoLogica.RegiX.Adapters.Common.Interfaces;
using TechnoLogica.RegiX.Adapters.Common.Utils;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.Common.Utils;

namespace RegiX.Adapters.Mocks
{
    public class BaseAdapterServiceProxy<T> : DispatchProxy
        where T : IAdapterService
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static readonly string OPERATION_NAME_KEY = "OperationName";
        public static readonly string API_SERVICE_INTERFACE = "APIServiceInterface";

        public static string DataFolder = string.Empty;

        private static Dictionary<Type, Type> SERVICE_NAMES = new Dictionary<Type, Type>();

        private static Dictionary<string, Func<object, string>> FILE_NAME_RESOLVER = new Dictionary<string, Func<object, string>>();

        private static Dictionary<string, Action<object>> AUGMENTED_RESPONSE_RESOLVER = new Dictionary<string, Action<object>>();

        private BaseAdapterService baseServiceImplementation;

        /// <summary>
        /// Constructor. Registers the type names. This is needed because in runtime
        /// the created instance's name is not apprropriate
        /// </summary>
        public BaseAdapterServiceProxy()
        {
            if (!SERVICE_NAMES.ContainsKey(typeof(T)))
            {
                SERVICE_NAMES.Add(typeof(T), GetType());
            }
            if (string.IsNullOrEmpty(DataFolder))
            {
                DataFolder = $"{Path.DirectorySeparatorChar}XMLData{Path.DirectorySeparatorChar}{GetType().Assembly.GetName().Name}{Path.DirectorySeparatorChar}";
            }
            baseServiceImplementation = new BaseAdapterServiceImplementation();
        }

        /// <summary>
        /// Creates a proxy instance
        /// </summary>
        /// <returns></returns>
        public T Create()
        {
            return Create<T, BaseAdapterServiceProxy<T>>();
        }

        /// <summary>
        /// Processes method invocations
        /// </summary>
        /// <param name="targetMethod">Metrhod to be invoked</param>
        /// <param name="args">Arguments</param>
        /// <returns>Result of the method's execution</returns>
        protected override object Invoke(MethodInfo targetMethod, object[] args)
        {
            string targetMethodName = targetMethod.Name;
            log.Debug($"Invoking {targetMethodName}");
            if (targetMethodName == "get_AdapterServiceName")
            {
                return SERVICE_NAMES[typeof(T)].Name;
            }
            else if (targetMethodName == "get_AdapterServiceInterface")
            {
                return typeof(T);
            }
            else if (targetMethodName == "get_AdapterServiceType")
            {
                return SERVICE_NAMES[typeof(T)];
            }
            else if (targetMethodName == "Execute")
            {
                return InvokeExecute(targetMethod, args);
            }
            else if (!TechnoLogica.RegiX.Adapters.Common.Utils.TypeExtensions.AdapterBaseInterfaces.Exists(abi => abi == targetMethod.DeclaringType))
            {
                return InvokeAdapterSpecificMethod(targetMethod, args);
            }
            else
            {
                // Invoke BaseService methods
                return targetMethod.Invoke(baseServiceImplementation, args);
            }
        }

        private object InvokeAdapterSpecificMethod(MethodInfo targetMethod, object[] args)
        {
            var parameters = targetMethod.GetParameters();
            var result = FileUtils.ReadXml(GetResponseFileName(targetMethod.Name, args[0]), targetMethod.ReturnType.GenericTypeArguments[1]);
            if (AUGMENTED_RESPONSE_RESOLVER.ContainsKey($"{typeof(T).FullName}.{targetMethod.Name}"))
            {
                AUGMENTED_RESPONSE_RESOLVER[$"{typeof(T).FullName}.{targetMethod.Name}"].Invoke(result);
            }
            var returnValue =
                SigningUtils.CreateAndSignNonGeneric(
                    args[0],
                    parameters[0].ParameterType,
                    result,
                    targetMethod.ReturnType.GenericTypeArguments[1],
                    args[1] as AccessMatrix,
                    args[2] as AdapterAdditionalParameters,
                    ConfigurationUtils.GetSignResponse()
                );
            return returnValue;
        }

        private object InvokeExecute(MethodInfo targetMethod, object[] args)
        {
            var parameters = targetMethod.GetParameters();
            if (parameters.Length == 1)
            {
                var request = args[0] as RequestWrapper;
                log.Debug($"Executing with 1 argument: { request }");
                var executeMethod = GetType().GetMethod("Execute", new Type[] { typeof(ServiceRequestData), typeof(AccessMatrix), typeof(AdapterAdditionalParameters) });
                log.Debug($"Invoking method {executeMethod}");
                return executeMethod.Invoke(this, new object[] { request?.Request, request?.AccessMatrix, request?.AdditionalParameters?.Deserialize<AdapterAdditionalParameters>() });
            }
            else if (parameters.Length == 3)
            {
                var request = args[0] as ServiceRequestData;
                var accessMatrix = args[1] as AccessMatrix;
                var additionalParameters = args[2] as AdapterAdditionalParameters;
                log.Debug($"Executing with 3 arguments: {request}; {accessMatrix}; {additionalParameters}");
                AddOperationInfo(request, additionalParameters);
                MethodInfo operationMethod = GetType().GetMethod(request.OperationName);
                Type expectedType = operationMethod.GetParameters()[0].ParameterType;
                log.Debug($"Invoking method {operationMethod}");
                IProvideServiceResultData result =
                    operationMethod.Invoke(
                        this,
                        new object[]
                        {
                                ExtractArgument(expectedType, request),
                                accessMatrix,
                                additionalParameters
                        }
                    ) as IProvideServiceResultData;
                var preparedResult = PrepareResult(result, additionalParameters);
                return preparedResult;
            }
            else
            {
                throw new ArgumentException($"Wrong number of parameters: {parameters.Length}. Expected 1 or 3.");
            }
        }

        private void AddOperationInfo(ServiceRequestData request, AdapterAdditionalParameters additionalParameters)
        {   
            additionalParameters.RequestProcessing = request.RequestProcessing;
            additionalParameters.ResponseProcessing = request.ResponseProcessing;
            additionalParameters.ProcessingData.AddRange(
                new ProcessingDataEntry[] {
                    new ProcessingDataEntry()
                    {
                        Key = OPERATION_NAME_KEY,
                        Value = request.OperationName.XmlSerialize().ToXmlElement()
                    },
                    new ProcessingDataEntry()
                    {
                        Key = API_SERVICE_INTERFACE,
                        Value = request.Contract.XmlSerialize().ToXmlElement()
                    }
                }
            );
        }


        private ServiceResultData PrepareResult(IProvideServiceResultData result, AdapterAdditionalParameters additionalParameters)
        {
            log.Debug("Preparing result...");
            ServiceResultData serviceResult = result.ToServiceResultDataSigned();
            if (!serviceResult.HasError && serviceResult.IsReady)
            {
                var requestProcessingFlags =
                    new ResponseProcessing[]
                    {
                        ResponseProcessing.TransformToPDF,
                        ResponseProcessing.Encrypt
                    };
                foreach (var responseProcessingFlag in requestProcessingFlags)
                {
                    if (additionalParameters .ResponseProcessing.HasFlag(responseProcessingFlag))
                    {
                        log.Debug($"Response processing for {responseProcessingFlag}...");
                        var requestProcessor = Composition.CompositionContainer.GetExportedValue<IResponseProcessor>(Enum.GetName(typeof(ResponseProcessing), responseProcessingFlag));
                        serviceResult = requestProcessor.ProcessResponse(serviceResult, additionalParameters);
                    }
                }
            }
            return serviceResult;
        }

        /// <summary>
        /// Adds the specified resolvers (for file name or response augmentation)
        /// </summary>
        /// <typeparam name="Req">Type of the request</typeparam>
        /// <typeparam name="Res">Type of the response</typeparam>
        /// <param name="action">Target method (specified with expression)</param>
        /// <param name="fileNameResolver">File name resolver</param>
        /// <param name="augmentActionResolver">Agumented response resolver</param>
        public static void RegisterResolver<Req, Res>(
            Expression<Func<T, Req, AccessMatrix, AdapterAdditionalParameters, CommonSignedResponse<Req, Res>>> action,
            Expression<Func<Req, string>> fileNameResolver = null,
            Expression<Action<Res>> augmentActionResolver = null)
            where Req : class
            where Res : class
        {
            MethodCallExpression str = action.Body as MethodCallExpression;
            var methodName = str.Method.Name;
            if (fileNameResolver != null)
            {
                var compileResolver = fileNameResolver.Compile();
                Func<object, string> compiledExpression =
                    (o) => compileResolver.Invoke(o as Req);
                FILE_NAME_RESOLVER.Add($"{typeof(T).FullName}.{methodName}", compiledExpression);
            }
            if (augmentActionResolver != null)
            {
                var compiledAugmentAction = augmentActionResolver.Compile();
                Action<object> compilecAction =
                    (o) => compiledAugmentAction.Invoke(o as Res);
                AUGMENTED_RESPONSE_RESOLVER.Add($"{typeof(T).FullName}.{methodName}", compilecAction);
            }
        }

        private object ExtractArgument(Type expectedType, ServiceRequestData request)
        {
            if (request.RequestProcessing.HasFlag(RequestProcessing.Decrypt) ||
                request.RequestProcessing.HasFlag(RequestProcessing.TransformFromPDF))
            {
                throw new ArgumentException("Decrypt and TransformFromPDF processing are not supported in Mock");
            }
            else
            {
                return request.Argument.Deserialize(expectedType);
            }
        }

        protected string GetResponseFileName(string methodName, object request)
        {
            string methodFullName = $"{typeof(T).FullName}.{methodName}";
            if (FILE_NAME_RESOLVER.ContainsKey(methodFullName))
            {
                var func = FILE_NAME_RESOLVER[methodFullName];
                return func(request);
            }
            else
            {
                return $"{Path.DirectorySeparatorChar}XMLData{Path.DirectorySeparatorChar}{SERVICE_NAMES[typeof(T)].Assembly.GetName().Name}{Path.DirectorySeparatorChar}{typeof(T).Name}.{methodName}.response.xml";
            }
        }

    }
}
