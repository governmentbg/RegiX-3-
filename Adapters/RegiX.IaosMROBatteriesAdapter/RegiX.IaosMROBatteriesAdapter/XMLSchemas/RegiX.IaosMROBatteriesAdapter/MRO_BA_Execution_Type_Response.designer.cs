// ------------------------------------------------------------------------------
//  <auto-generated>
//    Generated by Xsd2Code. Version 3.4.0.30983
//    <NameSpace>TechnoLogica.RegiX.IaosMROBatteriesAdapter</NameSpace><Collection>List</Collection><codeType>CSharp</codeType><EnableDataBinding>False</EnableDataBinding><EnableLazyLoading>False</EnableLazyLoading><TrackingChangesEnable>False</TrackingChangesEnable><GenTrackingClasses>False</GenTrackingClasses><HidePrivateFieldInIDE>False</HidePrivateFieldInIDE><EnableSummaryComment>True</EnableSummaryComment><VirtualProp>False</VirtualProp><IncludeSerializeMethod>False</IncludeSerializeMethod><UseBaseClass>False</UseBaseClass><GenBaseClass>False</GenBaseClass><GenerateCloneMethod>False</GenerateCloneMethod><GenerateDataContracts>False</GenerateDataContracts><CodeBaseTag>Net40</CodeBaseTag><SerializeMethodName>Serialize</SerializeMethodName><DeserializeMethodName>Deserialize</DeserializeMethodName><SaveToFileMethodName>SaveToFile</SaveToFileMethodName><LoadFromFileMethodName>LoadFromFile</LoadFromFileMethodName><GenerateXMLAttributes>True</GenerateXMLAttributes><EnableEncoding>False</EnableEncoding><AutomaticProperties>False</AutomaticProperties><GenerateShouldSerialize>False</GenerateShouldSerialize><DisableDebug>False</DisableDebug><PropNameSpecified>Default</PropNameSpecified><Encoder>UTF8</Encoder><CustomUsings></CustomUsings><ExcludeIncludedTypes>True</ExcludeIncludedTypes><EnableInitializeFields>True</EnableInitializeFields>
//  </auto-generated>
// ------------------------------------------------------------------------------
namespace TechnoLogica.RegiX.IaosMROBatteriesAdapter {
    using System;
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System.Collections;
    using System.Xml.Schema;
    using System.ComponentModel;
    using System.Collections.Generic;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.32405")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/IAOS/MROBatteries/ExecutionTypeResponse")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://egov.bg/RegiX/IAOS/MROBatteries/ExecutionTypeResponse", IsNullable=false)]
    public partial class MRO_BA_Execution_Type_Response {
        
        private AuthorizationExecutionType authorizationField;
        
        /// <summary>
        /// MRO_BA_Execution_Type_Response class constructor
        /// </summary>
        public MRO_BA_Execution_Type_Response() {
            this.authorizationField = new AuthorizationExecutionType();
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public AuthorizationExecutionType Authorization {
            get {
                return this.authorizationField;
            }
            set {
                this.authorizationField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.32405")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/IAOS/MROBatteries/ExecutionTypeResponse")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://egov.bg/RegiX/IAOS/MROBatteries/ExecutionTypeResponse", IsNullable=true)]
    public partial class AuthorizationExecutionType {
        
        private string authNumField;
        
        private string companyNameField;
        
        private Fulfilment mroFulfillmentField;
        
        private bool mroFulfillmentFieldSpecified;
        
        private string recOrgNumField;
        
        private string uonNameField;
        
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
        /// Наименование на организацията
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
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
        /// Начин на изпълнение на задължения
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        [System.ComponentModel.DescriptionAttribute("Начин на изпълнение на задължения")]
        public Fulfilment MroFulfillment {
            get {
                return this.mroFulfillmentField;
            }
            set {
                this.mroFulfillmentField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MroFulfillmentSpecified {
            get {
                return this.mroFulfillmentFieldSpecified;
            }
            set {
                this.mroFulfillmentFieldSpecified = value;
            }
        }
        
        /// <summary>
        /// Номер на организация по оползотворяване (ООп)/ индивидуално изпълнение на задължения
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        [System.ComponentModel.DescriptionAttribute("Номер на организация по оползотворяване (ООп)/ индивидуално изпълнение на задълже" +
            "ния")]
        public string RecOrgNum {
            get {
                return this.recOrgNumField;
            }
            set {
                this.recOrgNumField = value;
            }
        }
        
        /// <summary>
        /// Наименование на организацията по оползотворяване
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        [System.ComponentModel.DescriptionAttribute("Наименование на организацията по оползотворяване")]
        public string UonName {
            get {
                return this.uonNameField;
            }
            set {
                this.uonNameField = value;
            }
        }
    }
}
