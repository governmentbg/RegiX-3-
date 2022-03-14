﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TraderBrokerServiceReferenceV2
{
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/IAOS/TraderBroker")]
    public partial class WebServiceException
    {
        
        private string messageField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public string message
        {
            get
            {
                return this.messageField;
            }
            set
            {
                this.messageField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/IAOS/TraderBroker")]
    public partial class AuthorizationWasteCodes
    {
        
        private string authNumField;
        
        private string authTypeField;
        
        private string companyNameField;
        
        private string stateField;
        
        private string[] wasteCodeField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string AuthNum
        {
            get
            {
                return this.authNumField;
            }
            set
            {
                this.authNumField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string AuthType
        {
            get
            {
                return this.authTypeField;
            }
            set
            {
                this.authTypeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string CompanyName
        {
            get
            {
                return this.companyNameField;
            }
            set
            {
                this.companyNameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string State
        {
            get
            {
                return this.stateField;
            }
            set
            {
                this.stateField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("WasteCode", Order=4)]
        public string[] WasteCode
        {
            get
            {
                return this.wasteCodeField;
            }
            set
            {
                this.wasteCodeField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/IAOS/TraderBroker")]
    public partial class tbWasteCodesByEIK
    {
        
        private AuthorizationWasteCodes authorizationField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public AuthorizationWasteCodes Authorization
        {
            get
            {
                return this.authorizationField;
            }
            set
            {
                this.authorizationField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://egov.bg/RegiX/IAOS/TraderBroker", ConfigurationName="TraderBrokerServiceReferenceV2.TraderBrokerService")]
    public interface TraderBrokerService
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://egov.bg/RegiX/IAOS/TraderBroker/TraderBrokerService/getWasteCodesByEIKRequ" +
            "est", ReplyAction="http://egov.bg/RegiX/IAOS/TraderBroker/TraderBrokerService/getWasteCodesByEIKResp" +
            "onse")]
        [System.ServiceModel.FaultContractAttribute(typeof(TraderBrokerServiceReferenceV2.WebServiceException), Action="http://egov.bg/RegiX/IAOS/TraderBroker/TraderBrokerService/getWasteCodesByEIK/Fau" +
            "lt/WebServiceException", Name="WebServiceException")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<TraderBrokerServiceReferenceV2.getWasteCodesByEIKResponse> getWasteCodesByEIKAsync(TraderBrokerServiceReferenceV2.getWasteCodesByEIKRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://egov.bg/RegiX/IAOS/TraderBroker/TraderBrokerService/getWasteCodesByEIKRequ" +
            "est", ReplyAction="http://egov.bg/RegiX/IAOS/TraderBroker/TraderBrokerService/getWasteCodesByEIKResp" +
            "onse")]
        [System.ServiceModel.FaultContractAttribute(typeof(TraderBrokerServiceReferenceV2.WebServiceException), Action="http://egov.bg/RegiX/IAOS/TraderBroker/TraderBrokerService/getWasteCodesByEIK/Fau" +
            "lt/WebServiceException", Name="WebServiceException")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<TraderBrokerServiceReferenceV2.getWasteCodesByEIKV2Response> getWasteCodesByEIKV2Async(TraderBrokerServiceReferenceV2.getWasteCodesByEIKV2Request request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://egov.bg/RegiX/IAOS/TraderBroker/TraderBrokerService/getValidityCheckReques" +
            "t", ReplyAction="http://egov.bg/RegiX/IAOS/TraderBroker/TraderBrokerService/getValidityCheckRespon" +
            "se")]
        [System.ServiceModel.FaultContractAttribute(typeof(TraderBrokerServiceReferenceV2.WebServiceException), Action="http://egov.bg/RegiX/IAOS/TraderBroker/TraderBrokerService/getValidityCheck/Fault" +
            "/WebServiceException", Name="WebServiceException")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<TraderBrokerServiceReferenceV2.getValidityCheckResponse> getValidityCheckAsync(TraderBrokerServiceReferenceV2.getValidityCheckRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="TRADER_BROKER_Waste_Codes_By_EIK_Request", WrapperNamespace="http://egov.bg/RegiX/IAOS/TraderBroker", IsWrapped=true)]
    public partial class getWasteCodesByEIKRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://egov.bg/RegiX/IAOS/TraderBroker", Order=0)]
        public string EIK;
        
        public getWasteCodesByEIKRequest()
        {
        }
        
        public getWasteCodesByEIKRequest(string EIK)
        {
            this.EIK = EIK;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="getWasteCodesByEIKResponse", WrapperNamespace="http://egov.bg/RegiX/IAOS/TraderBroker", IsWrapped=true)]
    public partial class getWasteCodesByEIKResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://egov.bg/RegiX/IAOS/TraderBroker", Order=0)]
        public TraderBrokerServiceReferenceV2.tbWasteCodesByEIK TRADER_BROKER_Waste_Codes_By_EIK_Response;
        
        public getWasteCodesByEIKResponse()
        {
        }
        
        public getWasteCodesByEIKResponse(TraderBrokerServiceReferenceV2.tbWasteCodesByEIK TRADER_BROKER_Waste_Codes_By_EIK_Response)
        {
            this.TRADER_BROKER_Waste_Codes_By_EIK_Response = TRADER_BROKER_Waste_Codes_By_EIK_Response;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/IAOS/TraderBroker")]
    public partial class tbWasteCodesByEIKV2
    {
        
        private AuthorizationWasteCodesV2 authorizationField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public AuthorizationWasteCodesV2 Authorization
        {
            get
            {
                return this.authorizationField;
            }
            set
            {
                this.authorizationField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/IAOS/TraderBroker")]
    public partial class AuthorizationWasteCodesV2
    {
        
        private string authNumField;
        
        private string authTypeField;
        
        private string companyNameField;
        
        private string stateField;
        
        private WasteCodesOperations[] wasteOperationsCodesField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string AuthNum
        {
            get
            {
                return this.authNumField;
            }
            set
            {
                this.authNumField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string AuthType
        {
            get
            {
                return this.authTypeField;
            }
            set
            {
                this.authTypeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string CompanyName
        {
            get
            {
                return this.companyNameField;
            }
            set
            {
                this.companyNameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string State
        {
            get
            {
                return this.stateField;
            }
            set
            {
                this.stateField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order=4)]
        [System.Xml.Serialization.XmlArrayItemAttribute("WasteOperationsCode", IsNullable=false)]
        public WasteCodesOperations[] WasteOperationsCodes
        {
            get
            {
                return this.wasteOperationsCodesField;
            }
            set
            {
                this.wasteOperationsCodesField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/IAOS/TraderBroker")]
    public partial class WasteCodesOperations
    {
        
        private string wasteOperationField;
        
        private WasteCodesType wasteOperationsCodeField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string WasteOperation
        {
            get
            {
                return this.wasteOperationField;
            }
            set
            {
                this.wasteOperationField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public WasteCodesType WasteOperationsCode
        {
            get
            {
                return this.wasteOperationsCodeField;
            }
            set
            {
                this.wasteOperationsCodeField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/IAOS/TraderBroker")]
    public partial class WasteCodesType
    {
        
        private string[] wasteCodeField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("WasteCode", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public string[] WasteCode
        {
            get
            {
                return this.wasteCodeField;
            }
            set
            {
                this.wasteCodeField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="TRADER_BROKER_Waste_Codes_By_EIK_RequestV2", WrapperNamespace="http://egov.bg/RegiX/IAOS/TraderBroker", IsWrapped=true)]
    public partial class getWasteCodesByEIKV2Request
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://egov.bg/RegiX/IAOS/TraderBroker", Order=0)]
        public string EIK;
        
        public getWasteCodesByEIKV2Request()
        {
        }
        
        public getWasteCodesByEIKV2Request(string EIK)
        {
            this.EIK = EIK;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="getWasteCodesByEIKResponseV2", WrapperNamespace="http://egov.bg/RegiX/IAOS/TraderBroker", IsWrapped=true)]
    public partial class getWasteCodesByEIKV2Response
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://egov.bg/RegiX/IAOS/TraderBroker", Order=0)]
        public TraderBrokerServiceReferenceV2.tbWasteCodesByEIKV2 TRADER_BROKER_Waste_Codes_By_EIK_ResponseV2;
        
        public getWasteCodesByEIKV2Response()
        {
        }
        
        public getWasteCodesByEIKV2Response(TraderBrokerServiceReferenceV2.tbWasteCodesByEIKV2 TRADER_BROKER_Waste_Codes_By_EIK_ResponseV2)
        {
            this.TRADER_BROKER_Waste_Codes_By_EIK_ResponseV2 = TRADER_BROKER_Waste_Codes_By_EIK_ResponseV2;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/IAOS/TraderBroker")]
    public partial class tbValidityCheck
    {
        
        private AuthorizationValidityCheck authorizationField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public AuthorizationValidityCheck Authorization
        {
            get
            {
                return this.authorizationField;
            }
            set
            {
                this.authorizationField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/IAOS/TraderBroker")]
    public partial class AuthorizationValidityCheck
    {
        
        private string authNumField;
        
        private string authTypeField;
        
        private string companyNameField;
        
        private string distNameField;
        
        private string firstNameField;
        
        private string lastNameField;
        
        private string midNameField;
        
        private string popNameField;
        
        private string stateField;
        
        private string terNameField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string AuthNum
        {
            get
            {
                return this.authNumField;
            }
            set
            {
                this.authNumField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string AuthType
        {
            get
            {
                return this.authTypeField;
            }
            set
            {
                this.authTypeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string CompanyName
        {
            get
            {
                return this.companyNameField;
            }
            set
            {
                this.companyNameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string DistName
        {
            get
            {
                return this.distNameField;
            }
            set
            {
                this.distNameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string FirstName
        {
            get
            {
                return this.firstNameField;
            }
            set
            {
                this.firstNameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string LastName
        {
            get
            {
                return this.lastNameField;
            }
            set
            {
                this.lastNameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public string MidName
        {
            get
            {
                return this.midNameField;
            }
            set
            {
                this.midNameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public string PopName
        {
            get
            {
                return this.popNameField;
            }
            set
            {
                this.popNameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public string State
        {
            get
            {
                return this.stateField;
            }
            set
            {
                this.stateField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        public string TerName
        {
            get
            {
                return this.terNameField;
            }
            set
            {
                this.terNameField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="TRADER_BROKER_Validity_Check_Request", WrapperNamespace="http://egov.bg/RegiX/IAOS/TraderBroker", IsWrapped=true)]
    public partial class getValidityCheckRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://egov.bg/RegiX/IAOS/TraderBroker", Order=0)]
        public string EIK;
        
        public getValidityCheckRequest()
        {
        }
        
        public getValidityCheckRequest(string EIK)
        {
            this.EIK = EIK;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="getValidityCheckResponse", WrapperNamespace="http://egov.bg/RegiX/IAOS/TraderBroker", IsWrapped=true)]
    public partial class getValidityCheckResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://egov.bg/RegiX/IAOS/TraderBroker", Order=0)]
        public TraderBrokerServiceReferenceV2.tbValidityCheck TRADER_BROKER_Validity_Check_Response;
        
        public getValidityCheckResponse()
        {
        }
        
        public getValidityCheckResponse(TraderBrokerServiceReferenceV2.tbValidityCheck TRADER_BROKER_Validity_Check_Response)
        {
            this.TRADER_BROKER_Validity_Check_Response = TRADER_BROKER_Validity_Check_Response;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    public interface TraderBrokerServiceChannel : TraderBrokerServiceReferenceV2.TraderBrokerService, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    public partial class TraderBrokerServiceClient : System.ServiceModel.ClientBase<TraderBrokerServiceReferenceV2.TraderBrokerService>, TraderBrokerServiceReferenceV2.TraderBrokerService
    {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public TraderBrokerServiceClient() : 
                base(TraderBrokerServiceClient.GetDefaultBinding(), TraderBrokerServiceClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.TraderBrokerServiceImplPort.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public TraderBrokerServiceClient(EndpointConfiguration endpointConfiguration) : 
                base(TraderBrokerServiceClient.GetBindingForEndpoint(endpointConfiguration), TraderBrokerServiceClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public TraderBrokerServiceClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(TraderBrokerServiceClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public TraderBrokerServiceClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(TraderBrokerServiceClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public TraderBrokerServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<TraderBrokerServiceReferenceV2.getWasteCodesByEIKResponse> TraderBrokerServiceReferenceV2.TraderBrokerService.getWasteCodesByEIKAsync(TraderBrokerServiceReferenceV2.getWasteCodesByEIKRequest request)
        {
            return base.Channel.getWasteCodesByEIKAsync(request);
        }
        
        public System.Threading.Tasks.Task<TraderBrokerServiceReferenceV2.getWasteCodesByEIKResponse> getWasteCodesByEIKAsync(string EIK)
        {
            TraderBrokerServiceReferenceV2.getWasteCodesByEIKRequest inValue = new TraderBrokerServiceReferenceV2.getWasteCodesByEIKRequest();
            inValue.EIK = EIK;
            return ((TraderBrokerServiceReferenceV2.TraderBrokerService)(this)).getWasteCodesByEIKAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<TraderBrokerServiceReferenceV2.getWasteCodesByEIKV2Response> TraderBrokerServiceReferenceV2.TraderBrokerService.getWasteCodesByEIKV2Async(TraderBrokerServiceReferenceV2.getWasteCodesByEIKV2Request request)
        {
            return base.Channel.getWasteCodesByEIKV2Async(request);
        }
        
        public System.Threading.Tasks.Task<TraderBrokerServiceReferenceV2.getWasteCodesByEIKV2Response> getWasteCodesByEIKV2Async(string EIK)
        {
            TraderBrokerServiceReferenceV2.getWasteCodesByEIKV2Request inValue = new TraderBrokerServiceReferenceV2.getWasteCodesByEIKV2Request();
            inValue.EIK = EIK;
            return ((TraderBrokerServiceReferenceV2.TraderBrokerService)(this)).getWasteCodesByEIKV2Async(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<TraderBrokerServiceReferenceV2.getValidityCheckResponse> TraderBrokerServiceReferenceV2.TraderBrokerService.getValidityCheckAsync(TraderBrokerServiceReferenceV2.getValidityCheckRequest request)
        {
            return base.Channel.getValidityCheckAsync(request);
        }
        
        public System.Threading.Tasks.Task<TraderBrokerServiceReferenceV2.getValidityCheckResponse> getValidityCheckAsync(string EIK)
        {
            TraderBrokerServiceReferenceV2.getValidityCheckRequest inValue = new TraderBrokerServiceReferenceV2.getValidityCheckRequest();
            inValue.EIK = EIK;
            return ((TraderBrokerServiceReferenceV2.TraderBrokerService)(this)).getValidityCheckAsync(inValue);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.TraderBrokerServiceImplPort))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                result.Security.Mode = System.ServiceModel.BasicHttpSecurityMode.None;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.TraderBrokerServiceImplPort))
            {
                return new System.ServiceModel.EndpointAddress("https://source.gravis.bg/egov/services/trader-broker");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return TraderBrokerServiceClient.GetBindingForEndpoint(EndpointConfiguration.TraderBrokerServiceImplPort);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return TraderBrokerServiceClient.GetEndpointAddress(EndpointConfiguration.TraderBrokerServiceImplPort);
        }
        
        public enum EndpointConfiguration
        {
            
            TraderBrokerServiceImplPort,
        }
    }
}
