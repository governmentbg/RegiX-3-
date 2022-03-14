using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Configuration;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Configuration;
using System.ServiceModel.Description;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Core.Data.Interfaces;
using TechnoLogica.RegiX.Core.Interfaces;

namespace TechnoLogica.RegiX.Core.AdapterClientWCF
{
    /// <summary>
    /// Спомагателен клас изграждащ factory за канали към конкретен IAdapterService
    /// </summary>
    /// <typeparam name="I">Тип на IAdapterService</typeparam>
    [Export(typeof(IRegisterChannelFacotry<>))]
    public class RegisterChannelFacotry<I> : IRegisterChannelFacotry<I>
        where I : IAdapterServiceWCF
    {
        /// <summary>
        /// Интерфейс към базата
        /// </summary>
        [Import(typeof(IRegiXData))]
        public IRegiXData RegiXData { get; set; }
        
        /// <summary>
        /// Инициализация на контракта на адаптера извлечено от I
        /// </summary>
        private Lazy<string> _adapterContractName = new Lazy<string>(() => typeof(I).FullName);

        /// <summary>
        /// Променлива съхраняваща създаден ChannelFactory за конкретен IAdapterService
        /// </summary>
        private ChannelFactory<I> _channelFactory = null;

        /// <summary>
        /// Създаваа канал за специфичен IAdapterService
        /// </summary>
        /// <returns>Създаденият канал</returns>
        public I CreateChannel()
        {
            if (_channelFactory == null)
            {
                IRegisterBindingInfo bindingInfo = RegiXData.GetBindingInfo(_adapterContractName.Value);
                _channelFactory = CreateProxy(bindingInfo);
            }
            return _channelFactory.CreateChannel();
        }

        /// <summary>
        /// Създава ChannelFactory за подадения адаптер
        /// </summary>
        /// <param name="bindingInfo">Информация за адаптер</param>
        /// <returns>Създаденото ChannelFactory</returns>
        private ChannelFactory<I> CreateProxy(IRegisterBindingInfo bindingInfo)
        {
            Binding binding;
            EndpointAddress endpointAddress;
            switch (bindingInfo.BindingType)
            {
                case "WebHttpBinding":
                    {
                        binding = new WebHttpBinding(bindingInfo.BindingConfigName);
                        break;
                    }
                case "BasicHttpBinding":
                default:
                    {
                        binding = new BasicHttpBinding(bindingInfo.BindingConfigName);
                        break;
                    }
            }
            endpointAddress = new EndpointAddress(bindingInfo.AdapterURL);
            var channelFactory = new ChannelFactory<I>(binding, endpointAddress);
            if (!string.IsNullOrEmpty(bindingInfo.Behavior))
            {
                BehaviorsSection behaviorData = (BehaviorsSection)ConfigurationManager.GetSection("system.serviceModel/behaviors");
                if (!behaviorData.EndpointBehaviors.ContainsKey(bindingInfo.Behavior))
                {
                    //TODO: VIB_Exception handling
                    throw new ArgumentException("Invalid endpoint behavior configuration name.");
                }

                EndpointBehaviorElement endpoinBehaviorElement = behaviorData.EndpointBehaviors[bindingInfo.Behavior];
                Dictionary<Type, object> serviceBehaviorExtesions = new Dictionary<Type, object>();
                foreach (BehaviorExtensionElement behaviorPart in endpoinBehaviorElement)
                {
                    serviceBehaviorExtesions.Add(behaviorPart.BehaviorType, behaviorPart.CreateBehavior());
                }
                foreach (Type behaviorType in serviceBehaviorExtesions.Keys)
                {
                    channelFactory.Endpoint.EndpointBehaviors.Remove(behaviorType);
                    channelFactory.Endpoint.EndpointBehaviors.Add((IEndpointBehavior)serviceBehaviorExtesions[behaviorType]);
                }
            }
            return channelFactory;
        }
    }

    /// <summary>
    /// Helper за извикването на CreateBehavior метода на BehaviorExtensionElement
    /// </summary>
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
