// ------------------------------------------------------------------------------
//  <auto-generated>
//    Generated by Xsd2Code. Version 3.4.0.20336
//    <NameSpace>TechnoLogica.RegiX.CRCNumbersAdapter</NameSpace><Collection>List</Collection><codeType>CSharp</codeType><EnableDataBinding>False</EnableDataBinding><EnableLazyLoading>False</EnableLazyLoading><TrackingChangesEnable>False</TrackingChangesEnable><GenTrackingClasses>False</GenTrackingClasses><HidePrivateFieldInIDE>False</HidePrivateFieldInIDE><EnableSummaryComment>True</EnableSummaryComment><VirtualProp>False</VirtualProp><IncludeSerializeMethod>False</IncludeSerializeMethod><UseBaseClass>False</UseBaseClass><GenBaseClass>False</GenBaseClass><GenerateCloneMethod>False</GenerateCloneMethod><GenerateDataContracts>False</GenerateDataContracts><CodeBaseTag>Net40</CodeBaseTag><SerializeMethodName>Serialize</SerializeMethodName><DeserializeMethodName>Deserialize</DeserializeMethodName><SaveToFileMethodName>SaveToFile</SaveToFileMethodName><LoadFromFileMethodName>LoadFromFile</LoadFromFileMethodName><GenerateXMLAttributes>True</GenerateXMLAttributes><EnableEncoding>False</EnableEncoding><AutomaticProperties>False</AutomaticProperties><GenerateShouldSerialize>False</GenerateShouldSerialize><DisableDebug>False</DisableDebug><PropNameSpecified>Default</PropNameSpecified><Encoder>UTF8</Encoder><CustomUsings></CustomUsings><ExcludeIncludedTypes>True</ExcludeIncludedTypes><EnableInitializeFields>True</EnableInitializeFields>
//  </auto-generated>
// ------------------------------------------------------------------------------
namespace TechnoLogica.RegiX.CRCNumbersAdapter {
    using System;
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System.Collections;
    using System.Xml.Schema;
    using System.ComponentModel;
    using System.Collections.Generic;
    
    
    /// <summary>
    /// Входни параметри на Справка за номера
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.19053")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://egov.bg/RegiX/CRC/Numbers/GetNumbersInfoRequest")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://egov.bg/RegiX/CRC/Numbers/GetNumbersInfoRequest", IsNullable=false)]
    [System.ComponentModel.DescriptionAttribute("Входни параметри на Справка за номера")]
    public partial class GetNumbersInfoRequest {
        
        private string companyNameField;
        
        private string companyTypeField;
        
        private string codeField;
        
        private string numbersGroupField;
        
        private string decisionField;
        
        private System.Nullable<System.DateTime> decisionDateFromField;
        
        private bool decisionDateFromFieldSpecified;
        
        private System.Nullable<System.DateTime> decisionDateToField;
        
        private bool decisionDateToFieldSpecified;
        
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string CompanyName {
            get {
                return this.companyNameField;
            }
            set {
                this.companyNameField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string CompanyType {
            get {
                return this.companyTypeField;
            }
            set {
                this.companyTypeField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string Code {
            get {
                return this.codeField;
            }
            set {
                this.codeField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string NumbersGroup {
            get {
                return this.numbersGroupField;
            }
            set {
                this.numbersGroupField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string Decision {
            get {
                return this.decisionField;
            }
            set {
                this.decisionField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(DataType="date", IsNullable=true, Order=5)]
        public System.Nullable<System.DateTime> DecisionDateFrom {
            get {
                return this.decisionDateFromField;
            }
            set {
                this.decisionDateFromField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DecisionDateFromSpecified {
            get {
                return this.decisionDateFromFieldSpecified;
            }
            set {
                this.decisionDateFromFieldSpecified = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(DataType="date", IsNullable=true, Order=6)]
        public System.Nullable<System.DateTime> DecisionDateTo {
            get {
                return this.decisionDateToField;
            }
            set {
                this.decisionDateToField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DecisionDateToSpecified {
            get {
                return this.decisionDateToFieldSpecified;
            }
            set {
                this.decisionDateToFieldSpecified = value;
            }
        }
    }
}
