//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TechnoLogica.RegiX.NapooStudentDocumentsAdapter.NSDServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://is.navet.government.bg/ws/egov", ConfigurationName="NSDServiceReference.Data")]
    public interface Data {
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:DataWSDL#egovSearchStudentDocument", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        TechnoLogica.RegiX.NapooStudentDocumentsAdapter.NSDServiceReference.egovSearchStudentDocumentResponse egovSearchStudentDocument(TechnoLogica.RegiX.NapooStudentDocumentsAdapter.NSDServiceReference.egovSearchStudentDocumentRequest request);
        
        // CODEGEN: Generating message contract since the operation has multiple return values.
        [System.ServiceModel.OperationContractAttribute(Action="urn:DataWSDL#egovSearchStudentDocument", ReplyAction="*")]
        System.Threading.Tasks.Task<TechnoLogica.RegiX.NapooStudentDocumentsAdapter.NSDServiceReference.egovSearchStudentDocumentResponse> egovSearchStudentDocumentAsync(TechnoLogica.RegiX.NapooStudentDocumentsAdapter.NSDServiceReference.egovSearchStudentDocumentRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:DataWSDL#egovSearchStudentDocumentByStudent", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        TechnoLogica.RegiX.NapooStudentDocumentsAdapter.NSDServiceReference.egovSearchStudentDocumentByStudentResponse egovSearchStudentDocumentByStudent(TechnoLogica.RegiX.NapooStudentDocumentsAdapter.NSDServiceReference.egovSearchStudentDocumentByStudentRequest request);
        
        // CODEGEN: Generating message contract since the operation has multiple return values.
        [System.ServiceModel.OperationContractAttribute(Action="urn:DataWSDL#egovSearchStudentDocumentByStudent", ReplyAction="*")]
        System.Threading.Tasks.Task<TechnoLogica.RegiX.NapooStudentDocumentsAdapter.NSDServiceReference.egovSearchStudentDocumentByStudentResponse> egovSearchStudentDocumentByStudentAsync(TechnoLogica.RegiX.NapooStudentDocumentsAdapter.NSDServiceReference.egovSearchStudentDocumentByStudentRequest request);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://is.navet.government.bg/ws/egov")]
    public partial class StudentDocumentRequestType : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string identifierField;
        
        private string document_noField;
        
        /// <remarks/>
        public string identifier {
            get {
                return this.identifierField;
            }
            set {
                this.identifierField = value;
                this.RaisePropertyChanged("identifier");
            }
        }
        
        /// <remarks/>
        public string document_no {
            get {
                return this.document_noField;
            }
            set {
                this.document_noField = value;
                this.RaisePropertyChanged("document_no");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://is.navet.government.bg/ws/egov")]
    public partial class DocumentsByStudentResponseType : object, System.ComponentModel.INotifyPropertyChanged {
        
        private bool statusField;
        
        private string messageField;
        
        private StudentDocument[] dataField;
        
        /// <remarks/>
        public bool status {
            get {
                return this.statusField;
            }
            set {
                this.statusField = value;
                this.RaisePropertyChanged("status");
            }
        }
        
        /// <remarks/>
        public string message {
            get {
                return this.messageField;
            }
            set {
                this.messageField = value;
                this.RaisePropertyChanged("message");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("entries")]
        public StudentDocument[] data {
            get {
                return this.dataField;
            }
            set {
                this.dataField = value;
                this.RaisePropertyChanged("data");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://is.navet.government.bg/ws/egov")]
    public partial class StudentDocument : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int client_idField;
        
        private string vc_egnField;
        
        private string first_nameField;
        
        private string second_nameField;
        
        private string family_nameField;
        
        private int licence_numberField;
        
        private string provider_ownerField;
        
        private string city_nameField;
        
        private int document_type_idField;
        
        private string document_type_nameField;
        
        private int course_type_idField;
        
        private string course_type_nameField;
        
        private string profession_nameField;
        
        private string speciality_nameField;
        
        private int speciality_vqsField;
        
        private int year_finishedField;
        
        private string document_prn_serField;
        
        private string document_prn_noField;
        
        private string document_reg_noField;
        
        private System.DateTime document_issue_dateField;
        
        /// <remarks/>
        public int client_id {
            get {
                return this.client_idField;
            }
            set {
                this.client_idField = value;
                this.RaisePropertyChanged("client_id");
            }
        }
        
        /// <remarks/>
        public string vc_egn {
            get {
                return this.vc_egnField;
            }
            set {
                this.vc_egnField = value;
                this.RaisePropertyChanged("vc_egn");
            }
        }
        
        /// <remarks/>
        public string first_name {
            get {
                return this.first_nameField;
            }
            set {
                this.first_nameField = value;
                this.RaisePropertyChanged("first_name");
            }
        }
        
        /// <remarks/>
        public string second_name {
            get {
                return this.second_nameField;
            }
            set {
                this.second_nameField = value;
                this.RaisePropertyChanged("second_name");
            }
        }
        
        /// <remarks/>
        public string family_name {
            get {
                return this.family_nameField;
            }
            set {
                this.family_nameField = value;
                this.RaisePropertyChanged("family_name");
            }
        }
        
        /// <remarks/>
        public int licence_number {
            get {
                return this.licence_numberField;
            }
            set {
                this.licence_numberField = value;
                this.RaisePropertyChanged("licence_number");
            }
        }
        
        /// <remarks/>
        public string provider_owner {
            get {
                return this.provider_ownerField;
            }
            set {
                this.provider_ownerField = value;
                this.RaisePropertyChanged("provider_owner");
            }
        }
        
        /// <remarks/>
        public string city_name {
            get {
                return this.city_nameField;
            }
            set {
                this.city_nameField = value;
                this.RaisePropertyChanged("city_name");
            }
        }
        
        /// <remarks/>
        public int document_type_id {
            get {
                return this.document_type_idField;
            }
            set {
                this.document_type_idField = value;
                this.RaisePropertyChanged("document_type_id");
            }
        }
        
        /// <remarks/>
        public string document_type_name {
            get {
                return this.document_type_nameField;
            }
            set {
                this.document_type_nameField = value;
                this.RaisePropertyChanged("document_type_name");
            }
        }
        
        /// <remarks/>
        public int course_type_id {
            get {
                return this.course_type_idField;
            }
            set {
                this.course_type_idField = value;
                this.RaisePropertyChanged("course_type_id");
            }
        }
        
        /// <remarks/>
        public string course_type_name {
            get {
                return this.course_type_nameField;
            }
            set {
                this.course_type_nameField = value;
                this.RaisePropertyChanged("course_type_name");
            }
        }
        
        /// <remarks/>
        public string profession_name {
            get {
                return this.profession_nameField;
            }
            set {
                this.profession_nameField = value;
                this.RaisePropertyChanged("profession_name");
            }
        }
        
        /// <remarks/>
        public string speciality_name {
            get {
                return this.speciality_nameField;
            }
            set {
                this.speciality_nameField = value;
                this.RaisePropertyChanged("speciality_name");
            }
        }
        
        /// <remarks/>
        public int speciality_vqs {
            get {
                return this.speciality_vqsField;
            }
            set {
                this.speciality_vqsField = value;
                this.RaisePropertyChanged("speciality_vqs");
            }
        }
        
        /// <remarks/>
        public int year_finished {
            get {
                return this.year_finishedField;
            }
            set {
                this.year_finishedField = value;
                this.RaisePropertyChanged("year_finished");
            }
        }
        
        /// <remarks/>
        public string document_prn_ser {
            get {
                return this.document_prn_serField;
            }
            set {
                this.document_prn_serField = value;
                this.RaisePropertyChanged("document_prn_ser");
            }
        }
        
        /// <remarks/>
        public string document_prn_no {
            get {
                return this.document_prn_noField;
            }
            set {
                this.document_prn_noField = value;
                this.RaisePropertyChanged("document_prn_no");
            }
        }
        
        /// <remarks/>
        public string document_reg_no {
            get {
                return this.document_reg_noField;
            }
            set {
                this.document_reg_noField = value;
                this.RaisePropertyChanged("document_reg_no");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date")]
        public System.DateTime document_issue_date {
            get {
                return this.document_issue_dateField;
            }
            set {
                this.document_issue_dateField = value;
                this.RaisePropertyChanged("document_issue_date");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://is.navet.government.bg/ws/egov")]
    public partial class DocumentsByStudentRequestType : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string identifierField;
        
        /// <remarks/>
        public string identifier {
            get {
                return this.identifierField;
            }
            set {
                this.identifierField = value;
                this.RaisePropertyChanged("identifier");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://is.navet.government.bg/ws/egov")]
    public partial class StudentDocumentResponseType : object, System.ComponentModel.INotifyPropertyChanged {
        
        private bool statusField;
        
        private string messageField;
        
        private StudentDocument[] dataField;
        
        /// <remarks/>
        public bool status {
            get {
                return this.statusField;
            }
            set {
                this.statusField = value;
                this.RaisePropertyChanged("status");
            }
        }
        
        /// <remarks/>
        public string message {
            get {
                return this.messageField;
            }
            set {
                this.messageField = value;
                this.RaisePropertyChanged("message");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("entries")]
        public StudentDocument[] data {
            get {
                return this.dataField;
            }
            set {
                this.dataField = value;
                this.RaisePropertyChanged("data");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="egovSearchStudentDocument", WrapperNamespace="urn:DataWSDL#egovSearchStudentDocument", IsWrapped=true)]
    public partial class egovSearchStudentDocumentRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=0)]
        public TechnoLogica.RegiX.NapooStudentDocumentsAdapter.NSDServiceReference.StudentDocumentRequestType param1;
        
        public egovSearchStudentDocumentRequest() {
        }
        
        public egovSearchStudentDocumentRequest(TechnoLogica.RegiX.NapooStudentDocumentsAdapter.NSDServiceReference.StudentDocumentRequestType param) {
            this.param1 = param;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="egovSearchStudentDocumentResponse", WrapperNamespace="urn:DataWSDL#egovSearchStudentDocument", IsWrapped=true)]
    public partial class egovSearchStudentDocumentResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=0)]
        public TechnoLogica.RegiX.NapooStudentDocumentsAdapter.NSDServiceReference.StudentDocumentResponseType param;
        
        public egovSearchStudentDocumentResponse() {
        }
        
        public egovSearchStudentDocumentResponse(TechnoLogica.RegiX.NapooStudentDocumentsAdapter.NSDServiceReference.StudentDocumentResponseType param) {
            this.param = param;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="egovSearchStudentDocumentByStudent", WrapperNamespace="urn:DataWSDL#egovSearchStudentDocumentByStudent", IsWrapped=true)]
    public partial class egovSearchStudentDocumentByStudentRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=0)]
        public TechnoLogica.RegiX.NapooStudentDocumentsAdapter.NSDServiceReference.DocumentsByStudentRequestType param3;
        
        public egovSearchStudentDocumentByStudentRequest() {
        }
        
        public egovSearchStudentDocumentByStudentRequest(TechnoLogica.RegiX.NapooStudentDocumentsAdapter.NSDServiceReference.DocumentsByStudentRequestType param) {
            this.param3 = param;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="egovSearchStudentDocumentByStudentResponse", WrapperNamespace="urn:DataWSDL#egovSearchStudentDocumentByStudent", IsWrapped=true)]
    public partial class egovSearchStudentDocumentByStudentResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=0)]
        public TechnoLogica.RegiX.NapooStudentDocumentsAdapter.NSDServiceReference.DocumentsByStudentResponseType param4;
        
        public egovSearchStudentDocumentByStudentResponse() {
        }
        
        public egovSearchStudentDocumentByStudentResponse(TechnoLogica.RegiX.NapooStudentDocumentsAdapter.NSDServiceReference.DocumentsByStudentResponseType param) {
            this.param4 = param;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface DataChannel : TechnoLogica.RegiX.NapooStudentDocumentsAdapter.NSDServiceReference.Data, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DataClient : System.ServiceModel.ClientBase<TechnoLogica.RegiX.NapooStudentDocumentsAdapter.NSDServiceReference.Data>, TechnoLogica.RegiX.NapooStudentDocumentsAdapter.NSDServiceReference.Data {
        
        public DataClient() {
        }
        
        public DataClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public DataClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DataClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DataClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        TechnoLogica.RegiX.NapooStudentDocumentsAdapter.NSDServiceReference.egovSearchStudentDocumentResponse TechnoLogica.RegiX.NapooStudentDocumentsAdapter.NSDServiceReference.Data.egovSearchStudentDocument(TechnoLogica.RegiX.NapooStudentDocumentsAdapter.NSDServiceReference.egovSearchStudentDocumentRequest request) {
            return base.Channel.egovSearchStudentDocument(request);
        }
        
        public TechnoLogica.RegiX.NapooStudentDocumentsAdapter.NSDServiceReference.StudentDocumentResponseType egovSearchStudentDocument(TechnoLogica.RegiX.NapooStudentDocumentsAdapter.NSDServiceReference.StudentDocumentRequestType param) {
            TechnoLogica.RegiX.NapooStudentDocumentsAdapter.NSDServiceReference.egovSearchStudentDocumentRequest inValue = new TechnoLogica.RegiX.NapooStudentDocumentsAdapter.NSDServiceReference.egovSearchStudentDocumentRequest();
            inValue.param1 = param;
            TechnoLogica.RegiX.NapooStudentDocumentsAdapter.NSDServiceReference.egovSearchStudentDocumentResponse retVal = ((TechnoLogica.RegiX.NapooStudentDocumentsAdapter.NSDServiceReference.Data)(this)).egovSearchStudentDocument(inValue);
            return retVal.param;
        }
        
        public System.Threading.Tasks.Task<TechnoLogica.RegiX.NapooStudentDocumentsAdapter.NSDServiceReference.egovSearchStudentDocumentResponse> egovSearchStudentDocumentAsync(TechnoLogica.RegiX.NapooStudentDocumentsAdapter.NSDServiceReference.egovSearchStudentDocumentRequest request) {
            return base.Channel.egovSearchStudentDocumentAsync(request);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        TechnoLogica.RegiX.NapooStudentDocumentsAdapter.NSDServiceReference.egovSearchStudentDocumentByStudentResponse TechnoLogica.RegiX.NapooStudentDocumentsAdapter.NSDServiceReference.Data.egovSearchStudentDocumentByStudent(TechnoLogica.RegiX.NapooStudentDocumentsAdapter.NSDServiceReference.egovSearchStudentDocumentByStudentRequest request) {
            return base.Channel.egovSearchStudentDocumentByStudent(request);
        }
        
        public TechnoLogica.RegiX.NapooStudentDocumentsAdapter.NSDServiceReference.DocumentsByStudentResponseType egovSearchStudentDocumentByStudent(TechnoLogica.RegiX.NapooStudentDocumentsAdapter.NSDServiceReference.DocumentsByStudentRequestType param) {
            TechnoLogica.RegiX.NapooStudentDocumentsAdapter.NSDServiceReference.egovSearchStudentDocumentByStudentRequest inValue = new TechnoLogica.RegiX.NapooStudentDocumentsAdapter.NSDServiceReference.egovSearchStudentDocumentByStudentRequest();
            inValue.param3 = param;
            TechnoLogica.RegiX.NapooStudentDocumentsAdapter.NSDServiceReference.egovSearchStudentDocumentByStudentResponse retVal = ((TechnoLogica.RegiX.NapooStudentDocumentsAdapter.NSDServiceReference.Data)(this)).egovSearchStudentDocumentByStudent(inValue);
            return retVal.param4;
        }
        
        public System.Threading.Tasks.Task<TechnoLogica.RegiX.NapooStudentDocumentsAdapter.NSDServiceReference.egovSearchStudentDocumentByStudentResponse> egovSearchStudentDocumentByStudentAsync(TechnoLogica.RegiX.NapooStudentDocumentsAdapter.NSDServiceReference.egovSearchStudentDocumentByStudentRequest request) {
            return base.Channel.egovSearchStudentDocumentByStudentAsync(request);
        }
    }
}
