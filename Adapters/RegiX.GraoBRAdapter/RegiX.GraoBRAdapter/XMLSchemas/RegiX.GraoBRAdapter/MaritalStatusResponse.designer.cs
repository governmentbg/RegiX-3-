// ------------------------------------------------------------------------------
//  <auto-generated>
//    Generated by Xsd2Code. Version 3.4.0.25768
//    <NameSpace>TechnoLogica.RegiX.GraoBRAdapter</NameSpace><Collection>List</Collection><codeType>CSharp</codeType><EnableDataBinding>False</EnableDataBinding><EnableLazyLoading>False</EnableLazyLoading><TrackingChangesEnable>False</TrackingChangesEnable><GenTrackingClasses>False</GenTrackingClasses><HidePrivateFieldInIDE>False</HidePrivateFieldInIDE><EnableSummaryComment>True</EnableSummaryComment><VirtualProp>False</VirtualProp><IncludeSerializeMethod>False</IncludeSerializeMethod><UseBaseClass>False</UseBaseClass><GenBaseClass>False</GenBaseClass><GenerateCloneMethod>False</GenerateCloneMethod><GenerateDataContracts>False</GenerateDataContracts><CodeBaseTag>Net40</CodeBaseTag><SerializeMethodName>Serialize</SerializeMethodName><DeserializeMethodName>Deserialize</DeserializeMethodName><SaveToFileMethodName>SaveToFile</SaveToFileMethodName><LoadFromFileMethodName>LoadFromFile</LoadFromFileMethodName><GenerateXMLAttributes>True</GenerateXMLAttributes><EnableEncoding>False</EnableEncoding><AutomaticProperties>False</AutomaticProperties><GenerateShouldSerialize>False</GenerateShouldSerialize><DisableDebug>False</DisableDebug><PropNameSpecified>Default</PropNameSpecified><Encoder>UTF8</Encoder><CustomUsings></CustomUsings><ExcludeIncludedTypes>True</ExcludeIncludedTypes><EnableInitializeFields>True</EnableInitializeFields>
//  </auto-generated>
// ------------------------------------------------------------------------------
namespace TechnoLogica.RegiX.GraoBRAdapter {
    using System;
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System.Collections;
    using System.Xml.Schema;
    using System.ComponentModel;
    using System.Collections.Generic;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.32942")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/GRAO/BR/MaritalStatusResponse")]
    [System.Xml.Serialization.XmlRootAttribute("MaritalStatusResponse", Namespace="http://egov.bg/RegiX/GRAO/BR/MaritalStatusResponse", IsNullable=false)]
    public partial class MaritalStatusResponseType {
        
        private string maritalStatusCodeField;
        
        private string maritalStatusNameField;
        
        private string firstNameField;
        
        private string middleNameField;
        
        private string lastNameField;
        
        private string eGNField;
        
        private int genderField;
        
        private bool genderFieldSpecified;
        
        private System.DateTime reportDateField;
        
        private bool reportDateFieldSpecified;
        
        /// <summary>
        /// ?????? ???? ?????????????? ??????????????????
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        [System.ComponentModel.DescriptionAttribute("?????? ???? ?????????????? ??????????????????")]
        public string MaritalStatusCode {
            get {
                return this.maritalStatusCodeField;
            }
            set {
                this.maritalStatusCodeField = value;
            }
        }
        
        /// <summary>
        /// ???????????????????????? ???? ?????????????? ??????????????????
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        [System.ComponentModel.DescriptionAttribute("???????????????????????? ???? ?????????????? ??????????????????")]
        public string MaritalStatusName {
            get {
                return this.maritalStatusNameField;
            }
            set {
                this.maritalStatusNameField = value;
            }
        }
        
        /// <summary>
        /// ?????????????????? ??????
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        [System.ComponentModel.DescriptionAttribute("?????????????????? ??????")]
        public string FirstName {
            get {
                return this.firstNameField;
            }
            set {
                this.firstNameField = value;
            }
        }
        
        /// <summary>
        /// ???????????? ??????
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        [System.ComponentModel.DescriptionAttribute("???????????? ??????")]
        public string MiddleName {
            get {
                return this.middleNameField;
            }
            set {
                this.middleNameField = value;
            }
        }
        
        /// <summary>
        /// ?????????????? ??????
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        [System.ComponentModel.DescriptionAttribute("?????????????? ??????")]
        public string LastName {
            get {
                return this.lastNameField;
            }
            set {
                this.lastNameField = value;
            }
        }
        
        /// <summary>
        /// ???????????? ???????????????????? ??????????
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        [System.ComponentModel.DescriptionAttribute("???????????? ???????????????????? ??????????")]
        public string EGN {
            get {
                return this.eGNField;
            }
            set {
                this.eGNField = value;
            }
        }
        
        /// <summary>
        /// ??????
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        [System.ComponentModel.DescriptionAttribute("??????")]
        public int Gender {
            get {
                return this.genderField;
            }
            set {
                this.genderField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool GenderSpecified {
            get {
                return this.genderFieldSpecified;
            }
            set {
                this.genderFieldSpecified = value;
            }
        }
        
        /// <summary>
        /// ???????? ???? ??????????????????
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        [System.ComponentModel.DescriptionAttribute("???????? ???? ??????????????????")]
        public System.DateTime ReportDate {
            get {
                return this.reportDateField;
            }
            set {
                this.reportDateField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ReportDateSpecified {
            get {
                return this.reportDateFieldSpecified;
            }
            set {
                this.reportDateFieldSpecified = value;
            }
        }
    }
}
