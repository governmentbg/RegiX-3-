//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TechnoLogica.RegiX.MtTouristRegisterAdapter.CategorizationResortService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://egov.bg/RegiX/MT/BarRestaurantCategoryByEIKRequest", ConfigurationName="CategorizationResortService.CategorizationDB")]
    public interface CategorizationDB {
        
        // CODEGEN: Generating message contract since the operation BARRESTAURANTCATEGORYBYEIK is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(Action="BARRESTAURANTCATEGORYBYEIK", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        TechnoLogica.RegiX.MtTouristRegisterAdapter.CategorizationResortService.BARRESTAURANTCATEGORYBYEIKResponse BARRESTAURANTCATEGORYBYEIK(TechnoLogica.RegiX.MtTouristRegisterAdapter.CategorizationResortService.BARRESTAURANTCATEGORYBYEIKRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="BARRESTAURANTCATEGORYBYEIK", ReplyAction="*")]
        System.Threading.Tasks.Task<TechnoLogica.RegiX.MtTouristRegisterAdapter.CategorizationResortService.BARRESTAURANTCATEGORYBYEIKResponse> BARRESTAURANTCATEGORYBYEIKAsync(TechnoLogica.RegiX.MtTouristRegisterAdapter.CategorizationResortService.BARRESTAURANTCATEGORYBYEIKRequest request);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/MT/BarRestaurantCategoryByEIKRequest")]
    public partial class BARRESTAURANTCATEGORYBYEIKREQUESTTYPE : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string eIKField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public string EIK {
            get {
                return this.eIKField;
            }
            set {
                this.eIKField = value;
                this.RaisePropertyChanged("EIK");
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/MT/BarRestaurantCategoryByEIKResponse")]
    public partial class CERTIFICATETYPE : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string nUMBERField;
        
        private System.Nullable<System.DateTime> dATEField;
        
        private System.Nullable<System.DateTime> vALIDITYField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public string NUMBER {
            get {
                return this.nUMBERField;
            }
            set {
                this.nUMBERField = value;
                this.RaisePropertyChanged("NUMBER");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="date", IsNullable=true, Order=1)]
        public System.Nullable<System.DateTime> DATE {
            get {
                return this.dATEField;
            }
            set {
                this.dATEField = value;
                this.RaisePropertyChanged("DATE");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="date", IsNullable=true, Order=2)]
        public System.Nullable<System.DateTime> VALIDITY {
            get {
                return this.vALIDITYField;
            }
            set {
                this.vALIDITYField = value;
                this.RaisePropertyChanged("VALIDITY");
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/MT/BarRestaurantCategoryByEIKResponse")]
    public partial class TOURISTSUBOBJECTTYPE : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string dESCRIPTIONField;
        
        private System.Nullable<ENTOBJECTTYPEENUM> tYPEField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public string DESCRIPTION {
            get {
                return this.dESCRIPTIONField;
            }
            set {
                this.dESCRIPTIONField = value;
                this.RaisePropertyChanged("DESCRIPTION");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true, Order=1)]
        public System.Nullable<ENTOBJECTTYPEENUM> TYPE {
            get {
                return this.tYPEField;
            }
            set {
                this.tYPEField = value;
                this.RaisePropertyChanged("TYPE");
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/MT/BarRestaurantCategoryByEIKResponse")]
    public enum ENTOBJECTTYPEENUM {
        
        /// <remarks/>
        Bar,
        
        /// <remarks/>
        Restaurant,
        
        /// <remarks/>
        Other,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/MT/BarRestaurantCategoryByEIKResponse")]
    public partial class CAPACITYTYPE : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int tOTALField;
        
        private int iNDOORSField;
        
        private int oUTDOORSField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public int TOTAL {
            get {
                return this.tOTALField;
            }
            set {
                this.tOTALField = value;
                this.RaisePropertyChanged("TOTAL");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public int INDOORS {
            get {
                return this.iNDOORSField;
            }
            set {
                this.iNDOORSField = value;
                this.RaisePropertyChanged("INDOORS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=2)]
        public int OUTDOORS {
            get {
                return this.oUTDOORSField;
            }
            set {
                this.oUTDOORSField = value;
                this.RaisePropertyChanged("OUTDOORS");
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/MT/BarRestaurantCategoryByEIKResponse")]
    public partial class CONTACTTYPE : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string rEGIONField;
        
        private string mUNICIPALITYField;
        
        private string cITYField;
        
        private string aDDRESSField;
        
        private string pHONEField;
        
        private string fAXField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public string REGION {
            get {
                return this.rEGIONField;
            }
            set {
                this.rEGIONField = value;
                this.RaisePropertyChanged("REGION");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public string MUNICIPALITY {
            get {
                return this.mUNICIPALITYField;
            }
            set {
                this.mUNICIPALITYField = value;
                this.RaisePropertyChanged("MUNICIPALITY");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=2)]
        public string CITY {
            get {
                return this.cITYField;
            }
            set {
                this.cITYField = value;
                this.RaisePropertyChanged("CITY");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=3)]
        public string ADDRESS {
            get {
                return this.aDDRESSField;
            }
            set {
                this.aDDRESSField = value;
                this.RaisePropertyChanged("ADDRESS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=4)]
        public string PHONE {
            get {
                return this.pHONEField;
            }
            set {
                this.pHONEField = value;
                this.RaisePropertyChanged("PHONE");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=5)]
        public string FAX {
            get {
                return this.fAXField;
            }
            set {
                this.fAXField = value;
                this.RaisePropertyChanged("FAX");
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/MT/BarRestaurantCategoryByEIKResponse")]
    public partial class TOURISTENTERTAINMENTOBJECT : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string nAMEField;
        
        private CONTACTTYPE aDDRESSField;
        
        private string tYPEField;
        
        private string sUBTYPEField;
        
        private int cATEGORYField;
        
        private CAPACITYTYPE cAPACITYField;
        
        private string wORKTIMEField;
        
        private TOURISTSUBOBJECTTYPE[] sUBOBJECTSField;
        
        private CERTIFICATETYPE cERTIFICATEField;
        
        private string eIKField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public string NAME {
            get {
                return this.nAMEField;
            }
            set {
                this.nAMEField = value;
                this.RaisePropertyChanged("NAME");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true, Order=1)]
        public CONTACTTYPE ADDRESS {
            get {
                return this.aDDRESSField;
            }
            set {
                this.aDDRESSField = value;
                this.RaisePropertyChanged("ADDRESS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=2)]
        public string TYPE {
            get {
                return this.tYPEField;
            }
            set {
                this.tYPEField = value;
                this.RaisePropertyChanged("TYPE");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=3)]
        public string SUBTYPE {
            get {
                return this.sUBTYPEField;
            }
            set {
                this.sUBTYPEField = value;
                this.RaisePropertyChanged("SUBTYPE");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=4)]
        public int CATEGORY {
            get {
                return this.cATEGORYField;
            }
            set {
                this.cATEGORYField = value;
                this.RaisePropertyChanged("CATEGORY");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true, Order=5)]
        public CAPACITYTYPE CAPACITY {
            get {
                return this.cAPACITYField;
            }
            set {
                this.cAPACITYField = value;
                this.RaisePropertyChanged("CAPACITY");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=6)]
        public string WORKTIME {
            get {
                return this.wORKTIMEField;
            }
            set {
                this.wORKTIMEField = value;
                this.RaisePropertyChanged("WORKTIME");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SUBOBJECTS", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true, Order=7)]
        public TOURISTSUBOBJECTTYPE[] SUBOBJECTS {
            get {
                return this.sUBOBJECTSField;
            }
            set {
                this.sUBOBJECTSField = value;
                this.RaisePropertyChanged("SUBOBJECTS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true, Order=8)]
        public CERTIFICATETYPE CERTIFICATE {
            get {
                return this.cERTIFICATEField;
            }
            set {
                this.cERTIFICATEField = value;
                this.RaisePropertyChanged("CERTIFICATE");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=9)]
        public string EIK {
            get {
                return this.eIKField;
            }
            set {
                this.eIKField = value;
                this.RaisePropertyChanged("EIK");
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
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class BARRESTAURANTCATEGORYBYEIKRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="BARRESTAURANTCATEGORYBYEIKREQUEST", Namespace="http://egov.bg/RegiX/MT/BarRestaurantCategoryByEIKRequest", Order=0)]
        public TechnoLogica.RegiX.MtTouristRegisterAdapter.CategorizationResortService.BARRESTAURANTCATEGORYBYEIKREQUESTTYPE BARRESTAURANTCATEGORYBYEIKREQUEST1;
        
        public BARRESTAURANTCATEGORYBYEIKRequest() {
        }
        
        public BARRESTAURANTCATEGORYBYEIKRequest(TechnoLogica.RegiX.MtTouristRegisterAdapter.CategorizationResortService.BARRESTAURANTCATEGORYBYEIKREQUESTTYPE BARRESTAURANTCATEGORYBYEIKREQUEST1) {
            this.BARRESTAURANTCATEGORYBYEIKREQUEST1 = BARRESTAURANTCATEGORYBYEIKREQUEST1;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class BARRESTAURANTCATEGORYBYEIKResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://egov.bg/RegiX/MT/BarRestaurantCategoryByEIKRequest", Order=0)]
        [System.Xml.Serialization.XmlArrayItemAttribute("OBJECTS", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public TechnoLogica.RegiX.MtTouristRegisterAdapter.CategorizationResortService.TOURISTENTERTAINMENTOBJECT[] BARRESTAURANTCATEGORYBYEIKReturn;
        
        public BARRESTAURANTCATEGORYBYEIKResponse() {
        }
        
        public BARRESTAURANTCATEGORYBYEIKResponse(TechnoLogica.RegiX.MtTouristRegisterAdapter.CategorizationResortService.TOURISTENTERTAINMENTOBJECT[] BARRESTAURANTCATEGORYBYEIKReturn) {
            this.BARRESTAURANTCATEGORYBYEIKReturn = BARRESTAURANTCATEGORYBYEIKReturn;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface CategorizationDBChannel : TechnoLogica.RegiX.MtTouristRegisterAdapter.CategorizationResortService.CategorizationDB, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CategorizationDBClient : System.ServiceModel.ClientBase<TechnoLogica.RegiX.MtTouristRegisterAdapter.CategorizationResortService.CategorizationDB>, TechnoLogica.RegiX.MtTouristRegisterAdapter.CategorizationResortService.CategorizationDB {
        
        public CategorizationDBClient() {
        }
        
        public CategorizationDBClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CategorizationDBClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CategorizationDBClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CategorizationDBClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        TechnoLogica.RegiX.MtTouristRegisterAdapter.CategorizationResortService.BARRESTAURANTCATEGORYBYEIKResponse TechnoLogica.RegiX.MtTouristRegisterAdapter.CategorizationResortService.CategorizationDB.BARRESTAURANTCATEGORYBYEIK(TechnoLogica.RegiX.MtTouristRegisterAdapter.CategorizationResortService.BARRESTAURANTCATEGORYBYEIKRequest request) {
            return base.Channel.BARRESTAURANTCATEGORYBYEIK(request);
        }
        
        public TechnoLogica.RegiX.MtTouristRegisterAdapter.CategorizationResortService.TOURISTENTERTAINMENTOBJECT[] BARRESTAURANTCATEGORYBYEIK(TechnoLogica.RegiX.MtTouristRegisterAdapter.CategorizationResortService.BARRESTAURANTCATEGORYBYEIKREQUESTTYPE BARRESTAURANTCATEGORYBYEIKREQUEST1) {
            TechnoLogica.RegiX.MtTouristRegisterAdapter.CategorizationResortService.BARRESTAURANTCATEGORYBYEIKRequest inValue = new TechnoLogica.RegiX.MtTouristRegisterAdapter.CategorizationResortService.BARRESTAURANTCATEGORYBYEIKRequest();
            inValue.BARRESTAURANTCATEGORYBYEIKREQUEST1 = BARRESTAURANTCATEGORYBYEIKREQUEST1;
            TechnoLogica.RegiX.MtTouristRegisterAdapter.CategorizationResortService.BARRESTAURANTCATEGORYBYEIKResponse retVal = ((TechnoLogica.RegiX.MtTouristRegisterAdapter.CategorizationResortService.CategorizationDB)(this)).BARRESTAURANTCATEGORYBYEIK(inValue);
            return retVal.BARRESTAURANTCATEGORYBYEIKReturn;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<TechnoLogica.RegiX.MtTouristRegisterAdapter.CategorizationResortService.BARRESTAURANTCATEGORYBYEIKResponse> TechnoLogica.RegiX.MtTouristRegisterAdapter.CategorizationResortService.CategorizationDB.BARRESTAURANTCATEGORYBYEIKAsync(TechnoLogica.RegiX.MtTouristRegisterAdapter.CategorizationResortService.BARRESTAURANTCATEGORYBYEIKRequest request) {
            return base.Channel.BARRESTAURANTCATEGORYBYEIKAsync(request);
        }
        
        public System.Threading.Tasks.Task<TechnoLogica.RegiX.MtTouristRegisterAdapter.CategorizationResortService.BARRESTAURANTCATEGORYBYEIKResponse> BARRESTAURANTCATEGORYBYEIKAsync(TechnoLogica.RegiX.MtTouristRegisterAdapter.CategorizationResortService.BARRESTAURANTCATEGORYBYEIKREQUESTTYPE BARRESTAURANTCATEGORYBYEIKREQUEST1) {
            TechnoLogica.RegiX.MtTouristRegisterAdapter.CategorizationResortService.BARRESTAURANTCATEGORYBYEIKRequest inValue = new TechnoLogica.RegiX.MtTouristRegisterAdapter.CategorizationResortService.BARRESTAURANTCATEGORYBYEIKRequest();
            inValue.BARRESTAURANTCATEGORYBYEIKREQUEST1 = BARRESTAURANTCATEGORYBYEIKREQUEST1;
            return ((TechnoLogica.RegiX.MtTouristRegisterAdapter.CategorizationResortService.CategorizationDB)(this)).BARRESTAURANTCATEGORYBYEIKAsync(inValue);
        }
    }
}
