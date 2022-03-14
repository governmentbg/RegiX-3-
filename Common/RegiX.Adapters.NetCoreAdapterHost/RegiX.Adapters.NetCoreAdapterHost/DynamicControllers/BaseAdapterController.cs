using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TechnoLogica.RegiX.Adapters.Common.Interfaces;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.DataContracts.Health;
using TechnoLogica.RegiX.Common.DataContracts.Parameter;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.Common.Utils;

namespace TechnoLogica.RegiX.Adapters.NetCoreAdapterHost.DynamicControllers
{
    [Route("[controller]")]
    public class BaseAdapterController<T> : Controller, IAdapterServiceNETCore
        where T : IAdapterServiceNETCore
    {
        ILogger _logger;
        T BaseAdapterService { get; set; }
        IAdapterLogger AdapterLogger { get; set; }

        public Type AdapterServiceInterface => throw new NotImplementedException();

        public Type AdapterServiceType => throw new NotImplementedException();

        public string AdapterServiceName => throw new NotImplementedException();

        public BaseAdapterController(T baseAdapterService, ILoggerFactory loggerFactory, IAdapterLogger adapterLogger) : base()
        {
            _logger = loggerFactory.CreateLogger<AdapterServiceControllerModelConvention>();
            BaseAdapterService = baseAdapterService;
            AdapterLogger = adapterLogger;
        }
        
        [HttpGet("GetAdapterServiceInterface")]
        public string GetAdapterServiceInterface()
        {
            return BaseAdapterService.AdapterServiceInterface.FullName;
        }

        [HttpGet("GetAdapterServiceType")]
        public string GetAdapterServiceType()
        {
            return BaseAdapterService.AdapterServiceType.FullName;
        }

        [HttpGet("GetAdapterServiceName")]
        public string GetAdapterServiceName()
        {
            return BaseAdapterService.AdapterServiceName;
        }


        [HttpPost("CheckHealthFunction")]
        public string CheckHealthFunction([FromBody]string key)
        {
            return BaseAdapterService.CheckHealthFunction(key);
        }

        [HttpGet("CheckRegisterConnection")]
        public string CheckRegisterConnection()
        {
            return BaseAdapterService.CheckRegisterConnection();
        }

        [HttpPost("CheckResult")]
        public ServiceResultData CheckResult([FromBody]ServiceCheckResultArgument checkResult)
        {
            return BaseAdapterService.CheckResult(checkResult);
        }

        [HttpPost("AcknowledgeResultReceived")]
        public void AcknowledgeResultReceived([FromBody]ServiceCheckResultArgument checkResult)
        {
            BaseAdapterService.AcknowledgeResultReceived(checkResult);
        }

        public ServiceResultData Execute(ServiceRequestData request, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters)
        {
            return BaseAdapterService.Execute(request, accessMatrix, additionalParameters);
        }

        [HttpPost("Execute")]
        public ServiceResultData Execute([FromBody]RequestWrapper request)
        {
            var additionalParameters = request?.AdditionalParameters?.Deserialize<AdapterAdditionalParameters>();
            try
            {
                LogBeforeExecution(request, additionalParameters);
                var result =
                    Execute(
                        request?.Request,
                        request?.AccessMatrix,
                        additionalParameters
                    );
                LogAfterExecution(request, additionalParameters, result);
                return result;
            }
            catch (Exception ex)
            {
                LogError(request, additionalParameters, ex);
                return new ServiceResultData()
                {
                    HasError = true,
                    ServiceCallID = (additionalParameters != null) ? additionalParameters.ApiServiceCallId : 0,
                    Error = ex.Message
                };
            }
        }
        
        [HttpGet("GetAdapterVersion")]
        public string GetAdapterVersion()
        {
            return BaseAdapterService.GetAdapterVersion();
        }

        [HttpGet("GetHealthCheckFunctions")]
        public HealthCheckFunctions GetHealthCheckFunctions()
        {
            return BaseAdapterService.GetHealthCheckFunctions();
        }

        [HttpGet("GetHostMachineInfo")]
        public string GetHostMachineInfo()
        {
            return BaseAdapterService.GetHostMachineInfo();
        }

        [HttpGet("GetParameters")]
        public Parameters GetParameters()
        {
            return BaseAdapterService.GetParameters();
        }

        [HttpPost("Ping")]
        public byte[] Ping([FromBody] byte[] data)
        {
            return BaseAdapterService.Ping(data);
        }

        [HttpPost("SetParameter")]
        public void SetParameter(string key, string value)
        {
            BaseAdapterService.SetParameter(key, value);
        }

        [HttpPost("SetParameters")]
        public void SetParameters(List<ParameterInfo> parameters)
        {
            BaseAdapterService.SetParameters(parameters);
        }

        [HttpGet("GetAdapterUptime")]
        public uint GetAdapterUptime()
        {
            return BaseAdapterService.GetAdapterUptime();
        }

        [HttpGet("GetSystemUptime")]
        public uint GetSystemUptime()
        {
            return BaseAdapterService.GetSystemUptime();
        }

        [HttpGet("GetPublicKeyString")]
        public string GetPublicKeyString()
        {
            return BaseAdapterService.GetPublicKeyString();
        }

        private void LogError(RequestWrapper request, AdapterAdditionalParameters additionalParameters, Exception ex)
        {
            AdapterLogger.LogRecord(request?.Request?.Operation,
                new Common.DataContracts.AdapterLogRecordType()
                {
                    ApiServiceCallId = (additionalParameters != null) ? additionalParameters.ApiServiceCallId : 0,
                    ApiServiceCallIdSpecified = (additionalParameters != null && additionalParameters.ApiServiceCallId != 0),
                    ErrorMessage = ex.Message
                });
        }

        private void LogAfterExecution(RequestWrapper request, AdapterAdditionalParameters additionalParameters, ServiceResultData result)
        {
            AdapterLogger.LogRecord(request?.Request?.Operation,
                new Common.DataContracts.AdapterLogRecordType()
                {
                    ApiServiceCallId = (additionalParameters != null) ? additionalParameters.ApiServiceCallId : 0,
                    ApiServiceCallIdSpecified = (additionalParameters != null && additionalParameters.ApiServiceCallId != 0),
                    Response = result?.Data?.Response?.XmlSerialize()?.ToXmlElement()
                });
        }

        private void LogBeforeExecution(RequestWrapper request, AdapterAdditionalParameters additionalParameters)
        {
            AdapterLogger.LogRecord(request?.Request?.Operation,
                new Common.DataContracts.AdapterLogRecordType()
                {
                    AccessMatrix = request?.AccessMatrix,
                    AdditionalParameters = additionalParameters,
                    ApiServiceCallId = (additionalParameters != null) ? additionalParameters.ApiServiceCallId : 0,
                    ApiServiceCallIdSpecified = (additionalParameters != null && additionalParameters.ApiServiceCallId != 0),
                    Argument = request?.Request?.Argument
                });
        }

        public bool SendResultToCore(ServiceResultData result, string callbackURL)
        {
            throw new NotImplementedException();
        }
    }
}
