using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Web;
using TechnoLogica.RegiX.Common;

namespace TechnoLogica.RegiX.Adapters.WCFAdapterHost.ServiceHost
{
    public class ComposedInstanceProvider : IInstanceProvider
    {
        private readonly Type _serviceType;
        private readonly string _serviceName;

        private readonly CompositionContainer _container;

        public ComposedInstanceProvider(Type serviceType, string serviceName, CompositionContainer container)
        {
            _serviceType = serviceType;
            _container = container;
            _serviceName = serviceName;
        }

        public object GetInstance(InstanceContext context)
        {
            var service = _container.GetExportedValue<IAdapterService>(_serviceName);
            return service;
        }

        public object GetInstance(InstanceContext context, Message message)
        {
            return GetInstance(context);
        }

        public void ReleaseInstance(InstanceContext context, object instance)
        {
            var disposable = instance as IDisposable;

            if (disposable != null)
            {
                disposable.Dispose();
            }
        }
    }
}