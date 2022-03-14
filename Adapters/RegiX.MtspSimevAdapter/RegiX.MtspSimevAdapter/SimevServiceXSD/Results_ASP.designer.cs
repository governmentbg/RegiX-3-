// ------------------------------------------------------------------------------
//  <auto-generated>
//    Generated by Xsd2Code. Version 3.4.0.23593
//    <NameSpace>TechnoLogica.RegiX.MtspSimevAdapter.SimevServiceXSD</NameSpace><Collection>List</Collection><codeType>CSharp</codeType><EnableDataBinding>False</EnableDataBinding><EnableLazyLoading>False</EnableLazyLoading><TrackingChangesEnable>False</TrackingChangesEnable><GenTrackingClasses>False</GenTrackingClasses><HidePrivateFieldInIDE>False</HidePrivateFieldInIDE><EnableSummaryComment>True</EnableSummaryComment><VirtualProp>False</VirtualProp><IncludeSerializeMethod>False</IncludeSerializeMethod><UseBaseClass>False</UseBaseClass><GenBaseClass>False</GenBaseClass><GenerateCloneMethod>False</GenerateCloneMethod><GenerateDataContracts>False</GenerateDataContracts><CodeBaseTag>Net40</CodeBaseTag><SerializeMethodName>Serialize</SerializeMethodName><DeserializeMethodName>Deserialize</DeserializeMethodName><SaveToFileMethodName>SaveToFile</SaveToFileMethodName><LoadFromFileMethodName>LoadFromFile</LoadFromFileMethodName><GenerateXMLAttributes>True</GenerateXMLAttributes><EnableEncoding>False</EnableEncoding><AutomaticProperties>False</AutomaticProperties><GenerateShouldSerialize>False</GenerateShouldSerialize><DisableDebug>False</DisableDebug><PropNameSpecified>Default</PropNameSpecified><Encoder>UTF8</Encoder><CustomUsings></CustomUsings><ExcludeIncludedTypes>False</ExcludeIncludedTypes><EnableInitializeFields>True</EnableInitializeFields>
//  </auto-generated>
// ------------------------------------------------------------------------------
namespace TechnoLogica.RegiX.MtspSimevAdapter.SimevServiceXSD {
    using System;
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System.Collections;
    using System.Xml.Schema;
    using System.ComponentModel;
    using System.Collections.Generic;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.17065")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
    public partial class Result {
        
        private ResultHeader headerField;
        
        private List<ResultDataItem> dataField;
        
        /// <summary>
        /// Result class constructor
        /// </summary>
        public Result() {
            this.dataField = new List<ResultDataItem>();
            this.headerField = new ResultHeader();
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public ResultHeader Header {
            get {
                return this.headerField;
            }
            set {
                this.headerField = value;
            }
        }
        
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        [System.Xml.Serialization.XmlArrayItemAttribute("DataItem", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public List<ResultDataItem> Data {
            get {
                return this.dataField;
            }
            set {
                this.dataField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.17065")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class ResultHeader {
        
        private int requestNumberField;
        
        private int sizeField;
        
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public int RequestNumber {
            get {
                return this.requestNumberField;
            }
            set {
                this.requestNumberField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public int Size {
            get {
                return this.sizeField;
            }
            set {
                this.sizeField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.17065")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class ResultDataItem {
        
        private int rowField;
        
        private string identificatorField;
        
        private Flag isRegisteredField;
        
        private Flag fosterParentField;
        
        private Flag hasTelkField;
        
        private string contractNumberField;
        
        private System.DateTime contractDateField;
        
        private bool contractDateFieldSpecified;
        
        private System.DateTime constractStartDateField;
        
        private bool constractStartDateFieldSpecified;
        
        private System.DateTime constractEndDateField;
        
        private bool constractEndDateFieldSpecified;
        
        private System.DateTime contracClosingDateField;
        
        private bool contracClosingDateFieldSpecified;
        
        private double amountField;
        
        private bool amountFieldSpecified;
        
        private string childIndentificatorField;
        
        private Flag isChildRegisteredField;
        
        private Flag isRegisteredInRiskField;
        
        private Flag isSettledField;
        
        private Flag isSettledEverField;
        
        private System.DateTime sattleDateField;
        
        private bool sattleDateFieldSpecified;
        
        private System.DateTime sattleEndDateField;
        
        private bool sattleEndDateFieldSpecified;
        
        private Flag hasChildTelkField;
        
        private double childAmountField;
        
        private bool childAmountFieldSpecified;
        
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public int Row {
            get {
                return this.rowField;
            }
            set {
                this.rowField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public string Identificator {
            get {
                return this.identificatorField;
            }
            set {
                this.identificatorField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=2)]
        public Flag isRegistered {
            get {
                return this.isRegisteredField;
            }
            set {
                this.isRegisteredField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=3)]
        public Flag FosterParent {
            get {
                return this.fosterParentField;
            }
            set {
                this.fosterParentField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=4)]
        public Flag HasTelk {
            get {
                return this.hasTelkField;
            }
            set {
                this.hasTelkField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=5)]
        public string ContractNumber {
            get {
                return this.contractNumberField;
            }
            set {
                this.contractNumberField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="date", Order=6)]
        public System.DateTime ContractDate {
            get {
                return this.contractDateField;
            }
            set {
                this.contractDateField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ContractDateSpecified {
            get {
                return this.contractDateFieldSpecified;
            }
            set {
                this.contractDateFieldSpecified = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="date", Order=7)]
        public System.DateTime ConstractStartDate {
            get {
                return this.constractStartDateField;
            }
            set {
                this.constractStartDateField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ConstractStartDateSpecified {
            get {
                return this.constractStartDateFieldSpecified;
            }
            set {
                this.constractStartDateFieldSpecified = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="date", Order=8)]
        public System.DateTime ConstractEndDate {
            get {
                return this.constractEndDateField;
            }
            set {
                this.constractEndDateField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ConstractEndDateSpecified {
            get {
                return this.constractEndDateFieldSpecified;
            }
            set {
                this.constractEndDateFieldSpecified = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="date", Order=9)]
        public System.DateTime ContracClosingDate {
            get {
                return this.contracClosingDateField;
            }
            set {
                this.contracClosingDateField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ContracClosingDateSpecified {
            get {
                return this.contracClosingDateFieldSpecified;
            }
            set {
                this.contracClosingDateFieldSpecified = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=10)]
        public double Amount {
            get {
                return this.amountField;
            }
            set {
                this.amountField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AmountSpecified {
            get {
                return this.amountFieldSpecified;
            }
            set {
                this.amountFieldSpecified = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=11)]
        public string ChildIndentificator {
            get {
                return this.childIndentificatorField;
            }
            set {
                this.childIndentificatorField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=12)]
        public Flag IsChildRegistered {
            get {
                return this.isChildRegisteredField;
            }
            set {
                this.isChildRegisteredField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=13)]
        public Flag IsRegisteredInRisk {
            get {
                return this.isRegisteredInRiskField;
            }
            set {
                this.isRegisteredInRiskField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=14)]
        public Flag IsSettled {
            get {
                return this.isSettledField;
            }
            set {
                this.isSettledField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=15)]
        public Flag IsSettledEver {
            get {
                return this.isSettledEverField;
            }
            set {
                this.isSettledEverField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="date", Order=16)]
        public System.DateTime SattleDate {
            get {
                return this.sattleDateField;
            }
            set {
                this.sattleDateField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SattleDateSpecified {
            get {
                return this.sattleDateFieldSpecified;
            }
            set {
                this.sattleDateFieldSpecified = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="date", Order=17)]
        public System.DateTime SattleEndDate {
            get {
                return this.sattleEndDateField;
            }
            set {
                this.sattleEndDateField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SattleEndDateSpecified {
            get {
                return this.sattleEndDateFieldSpecified;
            }
            set {
                this.sattleEndDateFieldSpecified = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=18)]
        public Flag hasChildTelk {
            get {
                return this.hasChildTelkField;
            }
            set {
                this.hasChildTelkField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=19)]
        public double ChildAmount {
            get {
                return this.childAmountField;
            }
            set {
                this.childAmountField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ChildAmountSpecified {
            get {
                return this.childAmountFieldSpecified;
            }
            set {
                this.childAmountFieldSpecified = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.17065")]
    [System.SerializableAttribute()]
    public enum Flag {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0")]
        Item0,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("1")]
        Item1,
    }
}
