using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Hosting;
using System.Web.Security;
using System.Web.SessionState;
using TechnoLogica.RegiX.Adapters.Common;
using TechnoLogica.RegiX.Adapters.Common.Interfaces;
using TechnoLogica.RegiX.Adapters.WCFAdapterHost.ServiceHost;
using TechnoLogica.RegiX.Common;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace TechnoLogica.RegiX.Adapters.WCFAdapterHost
{
    public class Global : System.Web.HttpApplication
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        static Global()
        {
            Logger.Info("Logger in global created");
        }
        protected void Application_Start(object sender, EventArgs e)
        {
            HostingEnvironment.RegisterVirtualPathProvider(new ServiceVirtualPathProvider());

            AggregateCatalog catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new DirectoryCatalog(HttpRuntime.BinDirectory, "RegiX.*.dll"));
            CompositionContainer result = new CompositionContainer(catalog, true);
            result.ComposeExportedValue(result);
            Composition.CompositionContainer = result;

            var logstashLogger = Composition.CompositionContainer.GetExportedValueOrDefault<IAdapterLogger>();
            Composition.CompositionContainer.ComposeExportedValue<IAdapterLogger>(logstashLogger ?? new NOPLogstashAdapterLogger());

            var adapters = Composition.CompositionContainer.GetExportedValues<IAdapterService>();
            bool hasAsynchronousProcessing = false;
            foreach (var adapter in adapters)
            {
                bool isMock = false;
                if (!typeof(IAdapterServiceWCF).IsAssignableFrom(adapter.AdapterServiceType))
                {
                    isMock = true;
                }
                if (!isMock && typeof(IAsynchronousAdapterService).IsAssignableFrom(adapter.AdapterServiceInterface))
                {
                    hasAsynchronousProcessing = true;
                    var asyncProcessorType = typeof(IAsynchronousProcessor<>).MakeGenericType(adapter.GetType());
                    var genericMethod = typeof(CompositionContainer).GetMethod(nameof(CompositionContainer.GetExportedValue), new Type[] { }).MakeGenericMethod(asyncProcessorType);
                    var asyncProcessorInstance = genericMethod.Invoke(Composition.CompositionContainer, new object[] { });
                    Logger.Info($"Async processor added: {asyncProcessorInstance}");
                }
            }
            if (hasAsynchronousProcessing)
            {
                // Check persistance provider
                Composition.CompositionContainer.GetExportedValues<IPersistanceProvider>();
            }
        }

        protected void Application_End(object sender, EventArgs e)
        {
            var adapters = Composition.CompositionContainer.GetExportedValues<IAdapterService>();
            foreach (var adapter in adapters)
            {
                bool isNotMock = typeof(IAdapterServiceWCF).IsAssignableFrom(adapter.AdapterServiceType);
                if (isNotMock && typeof(IAsynchronousAdapterService).IsAssignableFrom(adapter.AdapterServiceInterface))
                {
                    var asyncProcessorType = typeof(IAsynchronousProcessor<>).MakeGenericType(adapter.GetType());
                    var genericMethod = typeof(CompositionContainer).GetMethod(nameof(CompositionContainer.GetExportedValue), new Type[] { }).MakeGenericMethod(asyncProcessorType);
                    var asyncProcessorInstance = genericMethod.Invoke(Composition.CompositionContainer, new object[] { });
                    (asyncProcessorInstance as IDisposable).Dispose();
                }
            }
        }
    }
}