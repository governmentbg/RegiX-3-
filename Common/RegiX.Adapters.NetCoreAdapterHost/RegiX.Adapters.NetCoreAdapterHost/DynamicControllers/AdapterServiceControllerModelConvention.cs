using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using TechnoLogica.RegiX.Common;

namespace TechnoLogica.RegiX.Adapters.NetCoreAdapterHost.DynamicControllers
{
    public class AdapterServiceControllerModelConvention : IControllerModelConvention
    {
        ILogger _logger;
        IServiceProvider _serviceProvider;

        public AdapterServiceControllerModelConvention(ILoggerFactory loggerFactory, IServiceProvider serviceProvider): base()
        {
            _logger = loggerFactory.CreateLogger<AdapterServiceControllerModelConvention>();
            _serviceProvider = serviceProvider;
        }

        public void Apply(ControllerModel controller)
        {
            if (controller.ControllerType.IsGenericType)
            {
                var genericType = controller.ControllerType.GenericTypeArguments[0];
                _logger.LogInformation($"GenericType: {genericType.FullName}");
                var serviceInstance = _serviceProvider.GetService(genericType);
                controller.ControllerName = (serviceInstance as IAdapterService).AdapterServiceName;
                _logger.LogInformation($"Controller name: {controller.ControllerName}");
            }
        }
    }
}
