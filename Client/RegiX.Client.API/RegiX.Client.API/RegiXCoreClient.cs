using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Threading.Tasks;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.Core.Interfaces;
using TechnoLogica.RegiX.Core.Interfaces.TransportObjects;

namespace TechnoLogica.RegiX.Client.API
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1")]
    [System.ServiceModel.ServiceContractAttribute(Namespace = "http://egov.bg/RegiX", ConfigurationName = "TechnoLogica.RegiX.Core.IRegiXEntryPointV2")]
    public interface IRegiXEntryPointV2
    {

        [System.ServiceModel.OperationContractAttribute(Action = "http://egov.bg/RegiX/IRegiXEntryPointV2/Execute", ReplyAction = "http://egov.bg/RegiX/IRegiXEntryPointV2/ExecuteResponse")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults = true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(AccessMatrixType))]
        System.Threading.Tasks.Task<ResultWrapper> ExecuteAsync(RequestWrapper request);

        [System.ServiceModel.OperationContractAttribute(Action = "http://egov.bg/RegiX/IRegiXEntryPointV2/CheckResult", ReplyAction = "http://egov.bg/RegiX/IRegiXEntryPointV2/CheckResultResponse")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults = true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(AccessMatrixType))]
        System.Threading.Tasks.Task<ResultWrapper> CheckResultAsync(ServiceCheckResultWrapper argument);

        [System.ServiceModel.OperationContractAttribute(Action = "http://egov.bg/RegiX/IRegiXEntryPointV2/AcknowledgeResultReceived", ReplyAction = "http://egov.bg/RegiX/IRegiXEntryPointV2/CheckResultResponse")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults = true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(AccessMatrixType))]
        System.Threading.Tasks.Task<ResultWrapper> AcknowledgeResultReceivedAsync(ServiceCheckResultWrapper argument);


        [System.ServiceModel.OperationContractAttribute(Action = "http://egov.bg/RegiX/IRegiXEntryPointV2/ExecuteCallback", ReplyAction = "http://egov.bg/RegiX/IRegiXEntryPointV2/ExecuteCallbackResponse")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults = true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(AccessMatrixType))]
        System.Threading.Tasks.Task ExecuteCallbackAsync(ResultWrapper request);
    }


    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1")]
    public partial class RegiXCoreClient : ClientBase<IRegiXEntryPointV2>, IRegiXEntryPointV2
    {
        public static string ENDPOINT_ADDRESS = "";

        /// <summary>
        /// Implement this method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static void ConfigureEndpoint(ServiceEndpoint serviceEndpoint, ClientCredentials clientCredentials)
        {
            if (!string.IsNullOrEmpty(ENDPOINT_ADDRESS))
            {
                serviceEndpoint.Address = new System.ServiceModel.EndpointAddress(ENDPOINT_ADDRESS);                
            }
        }

        public RegiXCoreClient(EndpointConfiguration endpointConfiguration) :
                base(RegiXCoreClient.GetBindingForEndpoint(endpointConfiguration), RegiXCoreClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }

        public RegiXCoreClient(EndpointConfiguration endpointConfiguration, string remoteAddress) :
                base(RegiXCoreClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }

        public RegiXCoreClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) :
                base(RegiXCoreClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }

        public RegiXCoreClient(Binding binding, EndpointAddress remoteAddress) :
                base(binding, remoteAddress)
        {
        }

        public Task<ResultWrapper> ExecuteAsync(RequestWrapper request)
        {
            return base.Channel.ExecuteAsync(request);
        }

        public Task<ResultWrapper> CheckResultAsync(ServiceCheckResultWrapper argument)
        {
            return base.Channel.CheckResultAsync(argument);
        }

        public Task<ResultWrapper> AcknowledgeResultReceivedAsync(ServiceCheckResultWrapper argument)
        {
            return base.Channel.AcknowledgeResultReceivedAsync(argument);
        }

        public Task ExecuteCallbackAsync(ResultWrapper request)
        {
            return base.Channel.ExecuteCallbackAsync(request);
        }

        public virtual Task OpenAsync()
        {
            return Task.Factory.FromAsync(((ICommunicationObject)(this)).BeginOpen(null, null), new Action<System.IAsyncResult>(((ICommunicationObject)(this)).EndOpen));
        }

        public virtual Task CloseAsync()
        {
            return Task.Factory.FromAsync(((ICommunicationObject)(this)).BeginClose(null, null), new Action<System.IAsyncResult>(((ICommunicationObject)(this)).EndClose));
        }

        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBindingSecurityClientCertificate))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                result.Security.Mode = System.ServiceModel.BasicHttpSecurityMode.Transport;
                result.Security.Transport.ClientCredentialType = HttpClientCredentialType.Certificate;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }

        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBindingSecurityClientCertificate))
            {
                return new System.ServiceModel.EndpointAddress("https://regix3.egov.bg:9111/RegiXEntryPointV2.svc/basic");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }

        public enum EndpointConfiguration
       {
            BasicHttpBindingSecurityClientCertificate,
        }
    }
}
