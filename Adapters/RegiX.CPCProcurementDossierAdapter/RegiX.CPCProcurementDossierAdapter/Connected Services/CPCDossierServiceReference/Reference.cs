﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CPCDossierServiceReference
{
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.cpc.bg/DossierService")]
    public partial class CPC_serviceFault
    {
        
        private string messageField;
        
        private string detailField;
        
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
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public string detail
        {
            get
            {
                return this.detailField;
            }
            set
            {
                this.detailField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.cpc.bg/DossierService")]
    public partial class ProcurementDossier
    {
        
        private string procurementNumberField;
        
        private string proceedingsNumberField;
        
        private System.DateTime proceedingsStartDateField;
        
        private bool proceedingsStartDateFieldSpecified;
        
        private System.DateTime proceedingsCloseDateField;
        
        private bool proceedingsCloseDateFieldSpecified;
        
        private string legalBaseField;
        
        private string proceedingsTypeField;
        
        private string[] proceedingsSubsectionField;
        
        private string[] initiatorField;
        
        private string[] defendantField;
        
        private string[] unitedProceedingsField;
        
        private bool interimMeasuresField;
        
        private bool interimMeasuresFieldSpecified;
        
        private string[] imposedInterimMeasureField;
        
        private string currentStatusField;
        
        private string[] imposedPenaltyField;
        
        private System.DateTime dossierPublishDateField;
        
        private bool dossierPublishDateFieldSpecified;
        
        private System.DateTime lastDecisionPublishDateField;
        
        private bool lastDecisionPublishDateFieldSpecified;
        
        private string dossierLinkField;
        
        private string registerIDField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public string ProcurementNumber
        {
            get
            {
                return this.procurementNumberField;
            }
            set
            {
                this.procurementNumberField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public string ProceedingsNumber
        {
            get
            {
                return this.proceedingsNumberField;
            }
            set
            {
                this.proceedingsNumberField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="date", Order=2)]
        public System.DateTime ProceedingsStartDate
        {
            get
            {
                return this.proceedingsStartDateField;
            }
            set
            {
                this.proceedingsStartDateField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ProceedingsStartDateSpecified
        {
            get
            {
                return this.proceedingsStartDateFieldSpecified;
            }
            set
            {
                this.proceedingsStartDateFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="date", Order=3)]
        public System.DateTime ProceedingsCloseDate
        {
            get
            {
                return this.proceedingsCloseDateField;
            }
            set
            {
                this.proceedingsCloseDateField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ProceedingsCloseDateSpecified
        {
            get
            {
                return this.proceedingsCloseDateFieldSpecified;
            }
            set
            {
                this.proceedingsCloseDateFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=4)]
        public string LegalBase
        {
            get
            {
                return this.legalBaseField;
            }
            set
            {
                this.legalBaseField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=5)]
        public string ProceedingsType
        {
            get
            {
                return this.proceedingsTypeField;
            }
            set
            {
                this.proceedingsTypeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ProceedingsSubsection", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=6)]
        public string[] ProceedingsSubsection
        {
            get
            {
                return this.proceedingsSubsectionField;
            }
            set
            {
                this.proceedingsSubsectionField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Initiator", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=7)]
        public string[] Initiator
        {
            get
            {
                return this.initiatorField;
            }
            set
            {
                this.initiatorField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Defendant", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=8)]
        public string[] Defendant
        {
            get
            {
                return this.defendantField;
            }
            set
            {
                this.defendantField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("UnitedProceedings", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=9)]
        public string[] UnitedProceedings
        {
            get
            {
                return this.unitedProceedingsField;
            }
            set
            {
                this.unitedProceedingsField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=10)]
        public bool InterimMeasures
        {
            get
            {
                return this.interimMeasuresField;
            }
            set
            {
                this.interimMeasuresField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool InterimMeasuresSpecified
        {
            get
            {
                return this.interimMeasuresFieldSpecified;
            }
            set
            {
                this.interimMeasuresFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ImposedInterimMeasure", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=11)]
        public string[] ImposedInterimMeasure
        {
            get
            {
                return this.imposedInterimMeasureField;
            }
            set
            {
                this.imposedInterimMeasureField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=12)]
        public string CurrentStatus
        {
            get
            {
                return this.currentStatusField;
            }
            set
            {
                this.currentStatusField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ImposedPenalty", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=13)]
        public string[] ImposedPenalty
        {
            get
            {
                return this.imposedPenaltyField;
            }
            set
            {
                this.imposedPenaltyField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="date", Order=14)]
        public System.DateTime DossierPublishDate
        {
            get
            {
                return this.dossierPublishDateField;
            }
            set
            {
                this.dossierPublishDateField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DossierPublishDateSpecified
        {
            get
            {
                return this.dossierPublishDateFieldSpecified;
            }
            set
            {
                this.dossierPublishDateFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="date", Order=15)]
        public System.DateTime LastDecisionPublishDate
        {
            get
            {
                return this.lastDecisionPublishDateField;
            }
            set
            {
                this.lastDecisionPublishDateField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool LastDecisionPublishDateSpecified
        {
            get
            {
                return this.lastDecisionPublishDateFieldSpecified;
            }
            set
            {
                this.lastDecisionPublishDateFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=16)]
        public string DossierLink
        {
            get
            {
                return this.dossierLinkField;
            }
            set
            {
                this.dossierLinkField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=17)]
        public string RegisterID
        {
            get
            {
                return this.registerIDField;
            }
            set
            {
                this.registerIDField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.cpc.bg/DossierService")]
    public partial class GetProcurementDossierResult
    {
        
        private string resultMessageField;
        
        private GetProcurementDossierResultResultStatus resultStatusField;
        
        private bool resultStatusFieldSpecified;
        
        private ProcurementDossier[] procurementDossierField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public string ResultMessage
        {
            get
            {
                return this.resultMessageField;
            }
            set
            {
                this.resultMessageField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public GetProcurementDossierResultResultStatus ResultStatus
        {
            get
            {
                return this.resultStatusField;
            }
            set
            {
                this.resultStatusField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ResultStatusSpecified
        {
            get
            {
                return this.resultStatusFieldSpecified;
            }
            set
            {
                this.resultStatusFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ProcurementDossier", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=2)]
        public ProcurementDossier[] ProcurementDossier
        {
            get
            {
                return this.procurementDossierField;
            }
            set
            {
                this.procurementDossierField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.cpc.bg/DossierService")]
    public enum GetProcurementDossierResultResultStatus
    {
        
        /// <remarks/>
        OK,
        
        /// <remarks/>
        INVALID_INPUT,
        
        /// <remarks/>
        NO_DATA_FOUND,
        
        /// <remarks/>
        ERROR,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://www.cpc.bg/DossierService", ConfigurationName="CPCDossierServiceReference.DossierPortType")]
    public interface DossierPortType
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.cpc.bg/GetProcurementDossier", ReplyAction="http://www.cpc.bg/GetProcurementDossierResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(CPCDossierServiceReference.CPC_serviceFault), Action="http://www.cpc.bg/CPC_serviceFault", Name="CPC_serviceFault")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<CPCDossierServiceReference.GetProcurementDossierResponse> GetProcurementDossierAsync(CPCDossierServiceReference.GetProcurementDossierRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetProcurementDossier", WrapperNamespace="http://www.cpc.bg/DossierService", IsWrapped=true)]
    public partial class GetProcurementDossierRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.cpc.bg/DossierService", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ProcurementNumber;
        
        public GetProcurementDossierRequest()
        {
        }
        
        public GetProcurementDossierRequest(string ProcurementNumber)
        {
            this.ProcurementNumber = ProcurementNumber;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetProcurementDossierResponse", WrapperNamespace="http://www.cpc.bg/DossierService", IsWrapped=true)]
    public partial class GetProcurementDossierResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.cpc.bg/DossierService", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public CPCDossierServiceReference.GetProcurementDossierResult ResultData;
        
        public GetProcurementDossierResponse()
        {
        }
        
        public GetProcurementDossierResponse(CPCDossierServiceReference.GetProcurementDossierResult ResultData)
        {
            this.ResultData = ResultData;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    public interface DossierPortTypeChannel : CPCDossierServiceReference.DossierPortType, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    public partial class DossierPortTypeClient : System.ServiceModel.ClientBase<CPCDossierServiceReference.DossierPortType>, CPCDossierServiceReference.DossierPortType
    {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public DossierPortTypeClient() : 
                base(DossierPortTypeClient.GetDefaultBinding(), DossierPortTypeClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.DossierPort.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public DossierPortTypeClient(EndpointConfiguration endpointConfiguration) : 
                base(DossierPortTypeClient.GetBindingForEndpoint(endpointConfiguration), DossierPortTypeClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public DossierPortTypeClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(DossierPortTypeClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public DossierPortTypeClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(DossierPortTypeClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public DossierPortTypeClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<CPCDossierServiceReference.GetProcurementDossierResponse> CPCDossierServiceReference.DossierPortType.GetProcurementDossierAsync(CPCDossierServiceReference.GetProcurementDossierRequest request)
        {
            return base.Channel.GetProcurementDossierAsync(request);
        }
        
        public System.Threading.Tasks.Task<CPCDossierServiceReference.GetProcurementDossierResponse> GetProcurementDossierAsync(string ProcurementNumber)
        {
            CPCDossierServiceReference.GetProcurementDossierRequest inValue = new CPCDossierServiceReference.GetProcurementDossierRequest();
            inValue.ProcurementNumber = ProcurementNumber;
            return ((CPCDossierServiceReference.DossierPortType)(this)).GetProcurementDossierAsync(inValue);
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
            if ((endpointConfiguration == EndpointConfiguration.DossierPort))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.DossierPort))
            {
                return new System.ServiceModel.EndpointAddress("http://reg.cpc.bg:8080/cpc-ws/services/DossierService");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return DossierPortTypeClient.GetBindingForEndpoint(EndpointConfiguration.DossierPort);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return DossierPortTypeClient.GetEndpointAddress(EndpointConfiguration.DossierPort);
        }
        
        public enum EndpointConfiguration
        {
            
            DossierPort,
        }
    }
}
