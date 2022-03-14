using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Configuration;
using System.ServiceModel.Description;
using TechnoLogica.RegiX.Adapters.Common.Utils;
using System.Web;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Adapters.WCFAdapterHost.MessageInspector;

namespace TechnoLogica.RegiX.Adapters.WCFAdapterHost.ServiceHost
{
    public class AdapterServiceHost : System.ServiceModel.ServiceHost
    {
        private Type _serviceType;
        private string _serviceName;

        public AdapterServiceHost(object singletonInstance, params Uri[] baseAddresses)
            : base(singletonInstance, baseAddresses)
        {
        }

        public AdapterServiceHost(Type serviceType, string serviceName, params Uri[] baseAddresses)
            : base(serviceType, baseAddresses)
        {
            _serviceType = serviceType;
            _serviceName = serviceName;
        }

        protected override ServiceDescription CreateDescription(out IDictionary<string, ContractDescription> implementedContracts)
        {
            return base.CreateDescription(out implementedContracts);
        }

        protected override void InitializeRuntime()
        {
            ConfigureServiceEndpoints();
            ConfigureServiceBehaviors();

            base.InitializeRuntime();
        }

        protected override void OnFaulted()
        {
            base.OnFaulted();
        }

        #region Helper Methods

        private void ConfigureServiceBehaviors()
        {
            //TODO: Add support for more behaviors
            string serviceBehaviorName = "DefaultBehavior";

            Dictionary<Type, object> serviceBehaviorExtesions = new Dictionary<Type, object>();
            BehaviorsSection behaviorData = (BehaviorsSection)ConfigurationManager.GetSection("system.serviceModel/behaviors");
            if (!behaviorData.ServiceBehaviors.ContainsKey(serviceBehaviorName))
            {
                throw new ArgumentException("Invalid service behavior configuration name.");
            }

            ServiceBehaviorElement serviceElement = behaviorData.ServiceBehaviors[serviceBehaviorName];
            foreach (BehaviorExtensionElement behaviorPart in serviceElement)
            {
                serviceBehaviorExtesions.Add(behaviorPart.BehaviorType, behaviorPart.CreateBehavior());
            }

            var inspectorInserter = new InspectorInserter();
            serviceBehaviorExtesions.Add(inspectorInserter.BehaviorType, inspectorInserter.CreateBehavior());

            foreach (Type behaviorType in serviceBehaviorExtesions.Keys)
            {
                this.Description.Behaviors.Remove(behaviorType);
                this.Description.Behaviors.Add((IServiceBehavior)serviceBehaviorExtesions[behaviorType]);
            }
        }

        private void ConfigureServiceEndpoints()
        {
            Binding basicHttp = GetConfiguredBinding(typeof(BasicHttpBinding), "DefaultBinding");
            string contract = Composition.CompositionContainer.GetExportedValue<IAdapterService>(_serviceName).AdapterServiceInterface.FullName;
            ServiceEndpoint endpoint = this.AddServiceEndpoint(contract, basicHttp, "");

            //Configure endpoint behavior
            string endpointBehaviorName = "DefaultEndpointBehavior";
            Dictionary<Type, object> endpointBehaviorExtensions = new Dictionary<Type, object>();
            BehaviorsSection behaviorData = (BehaviorsSection)ConfigurationManager.GetSection("system.serviceModel/behaviors");

            if (!behaviorData.EndpointBehaviors.ContainsKey(endpointBehaviorName))
            {
                throw new ArgumentException("Invalid endpoint behavior configuration name.");
            }

            EndpointBehaviorElement enpointElement = behaviorData.EndpointBehaviors[endpointBehaviorName];
            foreach (BehaviorExtensionElement behaviorPart in enpointElement)
            {
                endpointBehaviorExtensions.Add(behaviorPart.BehaviorType, behaviorPart.CreateBehavior());
            }

            foreach (Type behaviorType in endpointBehaviorExtensions.Keys)
            {
                endpoint.Behaviors.Add((IEndpointBehavior)endpointBehaviorExtensions[behaviorType]);
            }
        }

        private static Binding GetConfiguredBinding(Type bindingType, string bindingConfigurationName)
        {
            Binding binding = null;

            if (!typeof(Binding).IsAssignableFrom(bindingType))
            {
                throw new ArgumentException();
            }
            try
            {
                binding = (Binding)Activator.CreateInstance(bindingType, bindingConfigurationName);
            }
            catch (Exception e)
            {
                throw e;
            }

            return binding;
        }

        #endregion

        protected override void OnOpening()
        {
            if (Description.Behaviors.Find<ComposedServiceBehavior>() == null)
            {
                Description.Behaviors.Add(new ComposedServiceBehavior(_serviceType, _serviceName, Composition.CompositionContainer));
            }
            base.OnOpening();
        }
    }

    public static class System_ServiceModel_Configuration_BehaviorExtensionElement_Extension
    {
        /// <summary>
        /// Creates a behavior extension based on the current configuration settings. This is
        /// accomplished by exposing the internal protected method BehaviorExtensionElement.CreateBehavior
        /// through Reflection.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns>The behavior extension.</returns>
        public static object CreateBehavior(this BehaviorExtensionElement element)
        {
            return element.GetType().GetMethod("CreateBehavior",
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.NonPublic).Invoke(
                    element, new object[0] { });
        }
    }
}