// ------------------------------------------------------------------------------
//  <auto-generated>
//    Generated by Xsd2Code. Version 3.4.0.20336
//    <NameSpace>TechnoLogica.RegiX.IaosTraderBrokerAdapter</NameSpace><Collection>List</Collection><codeType>CSharp</codeType><EnableDataBinding>False</EnableDataBinding><EnableLazyLoading>False</EnableLazyLoading><TrackingChangesEnable>False</TrackingChangesEnable><GenTrackingClasses>False</GenTrackingClasses><HidePrivateFieldInIDE>False</HidePrivateFieldInIDE><EnableSummaryComment>True</EnableSummaryComment><VirtualProp>False</VirtualProp><IncludeSerializeMethod>False</IncludeSerializeMethod><UseBaseClass>False</UseBaseClass><GenBaseClass>False</GenBaseClass><GenerateCloneMethod>False</GenerateCloneMethod><GenerateDataContracts>False</GenerateDataContracts><CodeBaseTag>Net40</CodeBaseTag><SerializeMethodName>Serialize</SerializeMethodName><DeserializeMethodName>Deserialize</DeserializeMethodName><SaveToFileMethodName>SaveToFile</SaveToFileMethodName><LoadFromFileMethodName>LoadFromFile</LoadFromFileMethodName><GenerateXMLAttributes>True</GenerateXMLAttributes><EnableEncoding>False</EnableEncoding><AutomaticProperties>False</AutomaticProperties><GenerateShouldSerialize>False</GenerateShouldSerialize><DisableDebug>False</DisableDebug><PropNameSpecified>Default</PropNameSpecified><Encoder>UTF8</Encoder><CustomUsings></CustomUsings><ExcludeIncludedTypes>True</ExcludeIncludedTypes><EnableInitializeFields>True</EnableInitializeFields>
//  </auto-generated>
// ------------------------------------------------------------------------------
namespace TechnoLogica.RegiX.IaosTraderBrokerAdapter {
    using System;
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System.Collections;
    using System.Xml.Schema;
    using System.ComponentModel;
    using System.Collections.Generic;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.19993")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/IAOS/TraderBroker/WasteCodesByEIKResponseV2")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://egov.bg/RegiX/IAOS/TraderBroker/WasteCodesByEIKResponseV2", IsNullable=false)]
    public partial class TRADER_BROKER_Waste_Codes_By_EIK_ResponseV2 {
        
        private AuthorizationWasteCodeV2 authorizationField;
        
        /// <summary>
        /// TRADER_BROKER_Waste_Codes_By_EIK_ResponseV2 class constructor
        /// </summary>
        public TRADER_BROKER_Waste_Codes_By_EIK_ResponseV2() {
            this.authorizationField = new AuthorizationWasteCodeV2();
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public AuthorizationWasteCodeV2 Authorization {
            get {
                return this.authorizationField;
            }
            set {
                this.authorizationField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.19993")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/IAOS/TraderBroker/WasteCodesByEIKResponseV2")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://egov.bg/RegiX/IAOS/TraderBroker/WasteCodesByEIKResponseV2", IsNullable=true)]
    public partial class AuthorizationWasteCodeV2 {
        
        private string authNumField;
        
        private AuthorizationType authTypeField;
        
        private bool authTypeFieldSpecified;
        
        private string companyNameField;
        
        private AuthState stateField;
        
        private bool stateFieldSpecified;
        
        private WasteOperationCodesType wasteOperationCodesField;
        
        /// <summary>
        /// AuthorizationWasteCodeV2 class constructor
        /// </summary>
        public AuthorizationWasteCodeV2() {
            this.wasteOperationCodesField = new WasteOperationCodesType();
        }
        
        /// <summary>
        /// Регистрационен номер
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        [System.ComponentModel.DescriptionAttribute("Регистрационен номер")]
        public string AuthNum {
            get {
                return this.authNumField;
            }
            set {
                this.authNumField = value;
            }
        }
        
        /// <summary>
        /// Тип на регистрацията
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        [System.ComponentModel.DescriptionAttribute("Тип на регистрацията")]
        public AuthorizationType AuthType {
            get {
                return this.authTypeField;
            }
            set {
                this.authTypeField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AuthTypeSpecified {
            get {
                return this.authTypeFieldSpecified;
            }
            set {
                this.authTypeFieldSpecified = value;
            }
        }
        
        /// <summary>
        /// Наименование на организацията
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        [System.ComponentModel.DescriptionAttribute("Наименование на организацията")]
        public string CompanyName {
            get {
                return this.companyNameField;
            }
            set {
                this.companyNameField = value;
            }
        }
        
        /// <summary>
        /// Статус
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        [System.ComponentModel.DescriptionAttribute("Статус")]
        public AuthState State {
            get {
                return this.stateField;
            }
            set {
                this.stateField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool StateSpecified {
            get {
                return this.stateFieldSpecified;
            }
            set {
                this.stateFieldSpecified = value;
            }
        }
        
        /// <summary>
        /// Кодове на отпадък
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        [System.ComponentModel.DescriptionAttribute("Кодове на отпадък")]
        public WasteOperationCodesType WasteOperationCodes {
            get {
                return this.wasteOperationCodesField;
            }
            set {
                this.wasteOperationCodesField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.19993")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/IAOS/TraderBroker/WasteCodesByEIKResponseV2")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://egov.bg/RegiX/IAOS/TraderBroker/WasteCodesByEIKResponseV2", IsNullable=true)]
    public partial class WasteOperationCodesType {
        
        private List<WasteOperationCodeType> wasteOperationCodeField;
        
        /// <summary>
        /// WasteOperationCodesType class constructor
        /// </summary>
        public WasteOperationCodesType() {
            this.wasteOperationCodeField = new List<WasteOperationCodeType>();
        }
        
        /// <summary>
        /// Код на отпадък
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("WasteOperationCode", Order=0)]
        [System.ComponentModel.DescriptionAttribute("Код на отпадък")]
        public List<WasteOperationCodeType> WasteOperationCode {
            get {
                return this.wasteOperationCodeField;
            }
            set {
                this.wasteOperationCodeField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.19993")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/IAOS/TraderBroker/WasteCodesByEIKResponseV2")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://egov.bg/RegiX/IAOS/TraderBroker/WasteCodesByEIKResponseV2", IsNullable=true)]
    public partial class WasteOperationCodeType {
        
        private string wasteOperationField;
        
        private WasteOperationsCodeType wasteOperationsCodeField;
        
        /// <summary>
        /// WasteOperationCodeType class constructor
        /// </summary>
        public WasteOperationCodeType() {
            this.wasteOperationsCodeField = new WasteOperationsCodeType();
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string WasteOperation {
            get {
                return this.wasteOperationField;
            }
            set {
                this.wasteOperationField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public WasteOperationsCodeType WasteOperationsCode {
            get {
                return this.wasteOperationsCodeField;
            }
            set {
                this.wasteOperationsCodeField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.19993")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/IAOS/TraderBroker/WasteCodesByEIKResponseV2")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://egov.bg/RegiX/IAOS/TraderBroker/WasteCodesByEIKResponseV2", IsNullable=true)]
    public partial class WasteOperationsCodeType {
        
        private List<string> wasteCodeField;
        
        /// <summary>
        /// WasteOperationsCodeType class constructor
        /// </summary>
        public WasteOperationsCodeType() {
            this.wasteCodeField = new List<string>();
        }
        
        [System.Xml.Serialization.XmlElementAttribute("WasteCode", Order=0)]
        public List<string> WasteCode {
            get {
                return this.wasteCodeField;
            }
            set {
                this.wasteCodeField = value;
            }
        }
    }
}
