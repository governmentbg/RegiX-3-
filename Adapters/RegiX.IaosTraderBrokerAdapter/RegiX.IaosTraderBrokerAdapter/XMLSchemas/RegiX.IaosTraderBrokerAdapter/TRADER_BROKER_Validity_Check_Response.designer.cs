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
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.33700")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/IAOS/TraderBroker/ValidityCheckResponse")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://egov.bg/RegiX/IAOS/TraderBroker/ValidityCheckResponse", IsNullable=false)]
    public partial class TRADER_BROKER_Validity_Check_Response {
        
        private AuthorizationValidityCheck authorizationField;
        
        /// <summary>
        /// TRADER_BROKER_Validity_Check_Response class constructor
        /// </summary>
        public TRADER_BROKER_Validity_Check_Response() {
            this.authorizationField = new AuthorizationValidityCheck();
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public AuthorizationValidityCheck Authorization {
            get {
                return this.authorizationField;
            }
            set {
                this.authorizationField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.33700")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/IAOS/TraderBroker/ValidityCheckResponse")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://egov.bg/RegiX/IAOS/TraderBroker/ValidityCheckResponse", IsNullable=true)]
    public partial class AuthorizationValidityCheck {
        
        private string authNumField;
        
        private AuthorizationType authTypeField;
        
        private bool authTypeFieldSpecified;
        
        private string companyNameField;
        
        private string distNameField;
        
        private string firstNameField;
        
        private string lastNameField;
        
        private string midNameField;
        
        private string popNameField;
        
        private AuthState stateField;
        
        private bool stateFieldSpecified;
        
        private string terNameField;
        
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
        /// Област
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        [System.ComponentModel.DescriptionAttribute("Област")]
        public string DistName {
            get {
                return this.distNameField;
            }
            set {
                this.distNameField = value;
            }
        }
        
        /// <summary>
        /// Име на лицето за контакт
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        [System.ComponentModel.DescriptionAttribute("Име на лицето за контакт")]
        public string FirstName {
            get {
                return this.firstNameField;
            }
            set {
                this.firstNameField = value;
            }
        }
        
        /// <summary>
        /// Фамилия на лицето за контакт
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        [System.ComponentModel.DescriptionAttribute("Фамилия на лицето за контакт")]
        public string LastName {
            get {
                return this.lastNameField;
            }
            set {
                this.lastNameField = value;
            }
        }
        
        /// <summary>
        /// Презиме на лицето за контакт
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        [System.ComponentModel.DescriptionAttribute("Презиме на лицето за контакт")]
        public string MidName {
            get {
                return this.midNameField;
            }
            set {
                this.midNameField = value;
            }
        }
        
        /// <summary>
        /// Населено място
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        [System.ComponentModel.DescriptionAttribute("Населено място")]
        public string PopName {
            get {
                return this.popNameField;
            }
            set {
                this.popNameField = value;
            }
        }
        
        /// <summary>
        /// Статус на регистрацията
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        [System.ComponentModel.DescriptionAttribute("Статус на регистрацията")]
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
        /// Община
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        [System.ComponentModel.DescriptionAttribute("Община")]
        public string TerName {
            get {
                return this.terNameField;
            }
            set {
                this.terNameField = value;
            }
        }
    }
}
