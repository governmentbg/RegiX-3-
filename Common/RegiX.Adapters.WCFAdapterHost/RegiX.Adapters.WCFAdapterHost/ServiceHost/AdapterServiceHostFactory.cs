using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Web;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.Utils;

namespace TechnoLogica.RegiX.Adapters.WCFAdapterHost.ServiceHost
{
    public class AdapterServiceHostFactory : ServiceHostFactory
    {
        public AdapterServiceHostFactory()
        {

        }

        public override ServiceHostBase CreateServiceHost(string constructorString, Uri[] baseAddresses)
        {
            var adapterService = Composition.CompositionContainer.GetExportedValue<IAdapterService>(constructorString);

            return 
                new AdapterServiceHost(
                    adapterService.GetType(),
                    adapterService.AdapterServiceName,
                    baseAddresses);
        }

        protected override System.ServiceModel.ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            return new AdapterServiceHost(serviceType, baseAddresses);
        }
    }
}