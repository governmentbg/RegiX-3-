using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Reflection;
using TechnoLogica.RegiX.Common;

namespace TechnoLogica.RegiX.Adapters.NetCoreAdapterHost.DynamicControllers
{
    public class AdapterServiceControllerFeatureProvider : IApplicationFeatureProvider<ControllerFeature>
    {
        ILogger _logger;

        public AdapterServiceControllerFeatureProvider(ILoggerFactory loggerFactory) : base()
        {
            _logger = loggerFactory.CreateLogger<AdapterServiceControllerFeatureProvider>();
        }

        public void PopulateFeature(IEnumerable<ApplicationPart> parts, ControllerFeature feature)
        {
            var exports = Composition.CompositionContainer.GetExportedValues<IAdapterService>();
            foreach (var export in exports)
            {
                _logger.LogInformation($"AdapterServiceType: {export.AdapterServiceType.FullName}");
                if (typeof(IAdapterServiceNETCore).IsAssignableFrom(export.AdapterServiceType))
                {
                    _logger.LogInformation($"Adding controller: {export.AdapterServiceName}");
                    feature.Controllers.Add(typeof(BaseAdapterController<>).MakeGenericType(export.AdapterServiceType).GetTypeInfo());
                }
                else
                {
                    _logger.LogInformation($"Adding Mock controller: {export.AdapterServiceName}");
                    feature.Controllers.Add(typeof(BaseAdapterController<>).MakeGenericType(export.AdapterServiceInterface).GetTypeInfo());
                }
            }
        }
    }
}
