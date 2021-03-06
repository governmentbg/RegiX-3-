// ------------------------------------------------------------------------------
//  <auto-generated>
//    Generated by Xsd2Code. Version 3.4.0.22562
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
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.33692")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/IAOS/TraderBroker/WasteCodesByEIKResponse")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://egov.bg/RegiX/IAOS/TraderBroker/WasteCodesByEIKResponse", IsNullable=false)]
    public partial class TRADER_BROKER_Waste_Codes_By_EIK_Response {
        
        private AuthorizationWasteCode authorizationField;
        
        /// <summary>
        /// TRADER_BROKER_Waste_Codes_By_EIK_Response class constructor
        /// </summary>
        public TRADER_BROKER_Waste_Codes_By_EIK_Response() {
            this.authorizationField = new AuthorizationWasteCode();
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public AuthorizationWasteCode Authorization {
            get {
                return this.authorizationField;
            }
            set {
                this.authorizationField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.33692")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/IAOS/TraderBroker/WasteCodesByEIKResponse")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://egov.bg/RegiX/IAOS/TraderBroker/WasteCodesByEIKResponse", IsNullable=true)]
    public partial class AuthorizationWasteCode {
        
        private string authNumField;
        
        private AuthorizationType authTypeField;
        
        private bool authTypeFieldSpecified;
        
        private string companyNameField;
        
        private AuthState stateField;
        
        private bool stateFieldSpecified;
        
        private AuthorizationWasteCodeWasteCodes wasteCodesField;
        
        /// <summary>
        /// AuthorizationWasteCode class constructor
        /// </summary>
        public AuthorizationWasteCode() {
            this.wasteCodesField = new AuthorizationWasteCodeWasteCodes();
        }
        
        /// <summary>
        /// ???????????????????????????? ??????????
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        [System.ComponentModel.DescriptionAttribute("???????????????????????????? ??????????")]
        public string AuthNum {
            get {
                return this.authNumField;
            }
            set {
                this.authNumField = value;
            }
        }
        
        /// <summary>
        /// ?????? ???? ??????????????????????????
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        [System.ComponentModel.DescriptionAttribute("?????? ???? ??????????????????????????")]
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
        /// ???????????????????????? ???? ??????????????????????????
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        [System.ComponentModel.DescriptionAttribute("???????????????????????? ???? ??????????????????????????")]
        public string CompanyName {
            get {
                return this.companyNameField;
            }
            set {
                this.companyNameField = value;
            }
        }
        
        /// <summary>
        /// ????????????
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        [System.ComponentModel.DescriptionAttribute("????????????")]
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
        /// ???????????? ???? ??????????????
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        [System.ComponentModel.DescriptionAttribute("???????????? ???? ??????????????")]
        public AuthorizationWasteCodeWasteCodes WasteCodes {
            get {
                return this.wasteCodesField;
            }
            set {
                this.wasteCodesField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.33692")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://egov.bg/RegiX/IAOS/TraderBroker/WasteCodesByEIKResponse")]
    public partial class AuthorizationWasteCodeWasteCodes {
        
        private List<string> wasteCodeField;
        
        /// <summary>
        /// AuthorizationWasteCodeWasteCodes class constructor
        /// </summary>
        public AuthorizationWasteCodeWasteCodes() {
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
