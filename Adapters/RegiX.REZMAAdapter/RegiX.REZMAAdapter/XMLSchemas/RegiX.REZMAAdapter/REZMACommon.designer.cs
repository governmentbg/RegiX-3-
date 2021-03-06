// ------------------------------------------------------------------------------
//  <auto-generated>
//    Generated by Xsd2Code. Version 3.4.0.19886
//    <NameSpace>TechnoLogica.RegiX.REZMAAdapter</NameSpace><Collection>List</Collection><codeType>CSharp</codeType><EnableDataBinding>False</EnableDataBinding><EnableLazyLoading>False</EnableLazyLoading><TrackingChangesEnable>False</TrackingChangesEnable><GenTrackingClasses>False</GenTrackingClasses><HidePrivateFieldInIDE>False</HidePrivateFieldInIDE><EnableSummaryComment>True</EnableSummaryComment><VirtualProp>False</VirtualProp><IncludeSerializeMethod>False</IncludeSerializeMethod><UseBaseClass>False</UseBaseClass><GenBaseClass>False</GenBaseClass><GenerateCloneMethod>False</GenerateCloneMethod><GenerateDataContracts>False</GenerateDataContracts><CodeBaseTag>Net40</CodeBaseTag><SerializeMethodName>Serialize</SerializeMethodName><DeserializeMethodName>Deserialize</DeserializeMethodName><SaveToFileMethodName>SaveToFile</SaveToFileMethodName><LoadFromFileMethodName>LoadFromFile</LoadFromFileMethodName><GenerateXMLAttributes>True</GenerateXMLAttributes><EnableEncoding>False</EnableEncoding><AutomaticProperties>False</AutomaticProperties><GenerateShouldSerialize>False</GenerateShouldSerialize><DisableDebug>False</DisableDebug><PropNameSpecified>Default</PropNameSpecified><Encoder>UTF8</Encoder><CustomUsings></CustomUsings><ExcludeIncludedTypes>False</ExcludeIncludedTypes><EnableInitializeFields>True</EnableInitializeFields>
//  </auto-generated>
// ------------------------------------------------------------------------------
namespace TechnoLogica.RegiX.REZMAAdapter {
    using System;
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System.Collections;
    using System.Xml.Schema;
    using System.ComponentModel;
    using System.Collections.Generic;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.29975")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/AM/REZMA")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://egov.bg/RegiX/AM/REZMA", IsNullable=true)]
    public partial class ObligationType {
        
        private string codeMUField;
        
        private string muField;
        
        private string documentField;
        
        private string documentNumberField;
        
        private System.DateTime creationDateField;
        
        private bool creationDateFieldSpecified;
        
        private string typeObligationField;
        
        private decimal obligationAmountField;
        
        private bool obligationAmountFieldSpecified;
        
        private string payingDocumentField;
        
        private System.DateTime payingDateField;
        
        private bool payingDateFieldSpecified;
        
        private decimal payingAmountField;
        
        private bool payingAmountFieldSpecified;
        
        private decimal payingTotalField;
        
        private bool payingTotalFieldSpecified;
        
        private decimal differenceField;
        
        private bool differenceFieldSpecified;
        
        private string statusField;
        
        /// <summary>
        /// ?????? ????
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        [System.ComponentModel.DescriptionAttribute("?????? ????")]
        public string CodeMU {
            get {
                return this.codeMUField;
            }
            set {
                this.codeMUField = value;
            }
        }
        
        /// <summary>
        /// ???????????????????? ????????????????????
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        [System.ComponentModel.DescriptionAttribute("???????????????????? ????????????????????")]
        public string MU {
            get {
                return this.muField;
            }
            set {
                this.muField = value;
            }
        }
        
        /// <summary>
        /// ????????????????
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        [System.ComponentModel.DescriptionAttribute("????????????????")]
        public string Document {
            get {
                return this.documentField;
            }
            set {
                this.documentField = value;
            }
        }
        
        /// <summary>
        /// ?????????? ???? ????????????????
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        [System.ComponentModel.DescriptionAttribute("?????????? ???? ????????????????")]
        public string DocumentNumber {
            get {
                return this.documentNumberField;
            }
            set {
                this.documentNumberField = value;
            }
        }
        
        /// <summary>
        /// ???????? ???? ????????????????????
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date", Order=4)]
        [System.ComponentModel.DescriptionAttribute("???????? ???? ????????????????????")]
        public System.DateTime CreationDate {
            get {
                return this.creationDateField;
            }
            set {
                this.creationDateField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CreationDateSpecified {
            get {
                return this.creationDateFieldSpecified;
            }
            set {
                this.creationDateFieldSpecified = value;
            }
        }
        
        /// <summary>
        /// ?????? ????????????????????
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        [System.ComponentModel.DescriptionAttribute("?????? ????????????????????")]
        public string TypeObligation {
            get {
                return this.typeObligationField;
            }
            set {
                this.typeObligationField = value;
            }
        }
        
        /// <summary>
        /// ???????? ???? ????????????????????
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        [System.ComponentModel.DescriptionAttribute("???????? ???? ????????????????????")]
        public decimal ObligationAmount {
            get {
                return this.obligationAmountField;
            }
            set {
                this.obligationAmountField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ObligationAmountSpecified {
            get {
                return this.obligationAmountFieldSpecified;
            }
            set {
                this.obligationAmountFieldSpecified = value;
            }
        }
        
        /// <summary>
        /// ???????????????? ???? ????????????????????
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        [System.ComponentModel.DescriptionAttribute("???????????????? ???? ????????????????????")]
        public string PayingDocument {
            get {
                return this.payingDocumentField;
            }
            set {
                this.payingDocumentField = value;
            }
        }
        
        /// <summary>
        /// ???????? ???? ????????????????????
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date", Order=8)]
        [System.ComponentModel.DescriptionAttribute("???????? ???? ????????????????????")]
        public System.DateTime PayingDate {
            get {
                return this.payingDateField;
            }
            set {
                this.payingDateField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PayingDateSpecified {
            get {
                return this.payingDateFieldSpecified;
            }
            set {
                this.payingDateFieldSpecified = value;
            }
        }
        
        /// <summary>
        /// ???????? ???? ????????????????????
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        [System.ComponentModel.DescriptionAttribute("???????? ???? ????????????????????")]
        public decimal PayingAmount {
            get {
                return this.payingAmountField;
            }
            set {
                this.payingAmountField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PayingAmountSpecified {
            get {
                return this.payingAmountFieldSpecified;
            }
            set {
                this.payingAmountFieldSpecified = value;
            }
        }
        
        /// <summary>
        /// ???????????????? ??????????
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
        [System.ComponentModel.DescriptionAttribute("???????????????? ??????????")]
        public decimal PayingTotal {
            get {
                return this.payingTotalField;
            }
            set {
                this.payingTotalField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PayingTotalSpecified {
            get {
                return this.payingTotalFieldSpecified;
            }
            set {
                this.payingTotalFieldSpecified = value;
            }
        }
        
        /// <summary>
        /// ??????????????
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=11)]
        [System.ComponentModel.DescriptionAttribute("??????????????")]
        public decimal Difference {
            get {
                return this.differenceField;
            }
            set {
                this.differenceField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DifferenceSpecified {
            get {
                return this.differenceFieldSpecified;
            }
            set {
                this.differenceFieldSpecified = value;
            }
        }
        
        /// <summary>
        /// ????????????
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=12)]
        [System.ComponentModel.DescriptionAttribute("????????????")]
        public string Status {
            get {
                return this.statusField;
            }
            set {
                this.statusField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.29975")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/AM/REZMA")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://egov.bg/RegiX/AM/REZMA", IsNullable=true)]
    public partial class ObligationsType {
        
        private List<ObligationType> obligationField;
        
        /// <summary>
        /// ObligationsType class constructor
        /// </summary>
        public ObligationsType() {
            this.obligationField = new List<ObligationType>();
        }
        
        /// <summary>
        /// ????????????????????
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("Obligation", Order=0)]
        [System.ComponentModel.DescriptionAttribute("????????????????????")]
        public List<ObligationType> Obligation {
            get {
                return this.obligationField;
            }
            set {
                this.obligationField = value;
            }
        }
    }
}
