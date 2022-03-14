using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.ReflectionModel;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Configuration;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Web;
using TechnoLogica.RegiX.Common;

namespace TechnoLogica.RegiX.Adapters.WCFAdapterHost.MessageInspector
{
    public class InspectorInserter : BehaviorExtensionElement, IServiceBehavior
    {
        #region IServiceBehavior Members
        public void AddBindingParameters(
          ServiceDescription serviceDescription,
          ServiceHostBase serviceHostBase,
          System.Collections.ObjectModel.Collection<ServiceEndpoint> endpoints,
          BindingParameterCollection bindingParameters
        )
        { return; }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            var adapterInterfaces =
                Composition
                    .CompositionContainer
                    .Catalog
                    .Parts
                    .Where(p => p.ExportDefinitions.Any(e => e.ContractName == typeof(IAdapterService).FullName))
                    .Select(ed => ReflectionModelServices.GetPartType(ed).Value)
                    .SelectMany( a => a.GetInterfaces())
                    .Distinct()
                    .ToList();
            foreach (ChannelDispatcher chDisp in serviceHostBase.ChannelDispatchers)
            {
                chDisp.ErrorHandlers.Add(new Inspector(""));
                foreach (EndpointDispatcher epDisp in chDisp.Endpoints)
                {
                    var serviceInterface =
                        adapterInterfaces.SingleOrDefault(f => f.FullName.EndsWith(epDisp.ContractName));

                    foreach (DispatchOperation op in epDisp.DispatchRuntime.Operations)
                    {
                        if (serviceInterface != null &&
                            (serviceInterface.GetMethods().Any( m => m.Name == op.Name) ||
                             op.Name == nameof(IAdapterService.Execute)))
                        {                            
                            op.ParameterInspectors.Add(new Inspector(serviceInterface.FullName));
                        }                        
                    }
                }
            }
        }

        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase) { return; }

        #endregion

        public override Type BehaviorType
        {
            get { return typeof(InspectorInserter); }
        }

        protected override object CreateBehavior()
        { return new InspectorInserter(); }
    }
}