// ------------------------------------------------------------------------------
//  <auto-generated>
//    Generated by Xsd2Code. Version 3.4.0.20738
//    <NameSpace>TechnoLogica.RegiX.MPRNAdapter</NameSpace><Collection>List</Collection><codeType>CSharp</codeType><EnableDataBinding>False</EnableDataBinding><EnableLazyLoading>False</EnableLazyLoading><TrackingChangesEnable>False</TrackingChangesEnable><GenTrackingClasses>False</GenTrackingClasses><HidePrivateFieldInIDE>False</HidePrivateFieldInIDE><EnableSummaryComment>True</EnableSummaryComment><VirtualProp>False</VirtualProp><IncludeSerializeMethod>False</IncludeSerializeMethod><UseBaseClass>False</UseBaseClass><GenBaseClass>False</GenBaseClass><GenerateCloneMethod>False</GenerateCloneMethod><GenerateDataContracts>False</GenerateDataContracts><CodeBaseTag>Net40</CodeBaseTag><SerializeMethodName>Serialize</SerializeMethodName><DeserializeMethodName>Deserialize</DeserializeMethodName><SaveToFileMethodName>SaveToFile</SaveToFileMethodName><LoadFromFileMethodName>LoadFromFile</LoadFromFileMethodName><GenerateXMLAttributes>True</GenerateXMLAttributes><EnableEncoding>False</EnableEncoding><AutomaticProperties>False</AutomaticProperties><GenerateShouldSerialize>False</GenerateShouldSerialize><DisableDebug>False</DisableDebug><PropNameSpecified>Default</PropNameSpecified><Encoder>UTF8</Encoder><CustomUsings></CustomUsings><ExcludeIncludedTypes>False</ExcludeIncludedTypes><EnableInitializeFields>True</EnableInitializeFields>
//  </auto-generated>
// ------------------------------------------------------------------------------
namespace TechnoLogica.RegiX.MPRNAdapter {
    using System;
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System.Collections;
    using System.Xml.Schema;
    using System.ComponentModel;
    using System.Collections.Generic;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.28328")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/MP/RNSearchResponse")]
    [System.Xml.Serialization.XmlRootAttribute("RNSearchResponse", Namespace="http://egov.bg/RegiX/MP/RNSearchResponse", IsNullable=false)]
    public partial class RNSearchResponseType {
        
        private List<CasesType> casesField;
        
        /// <summary>
        /// RNSearchResponseType class constructor
        /// </summary>
        public RNSearchResponseType() {
            this.casesField = new List<CasesType>();
        }
        
        /// <summary>
        /// Производства по несъстоятелност
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("Cases", Order=0)]
        [System.ComponentModel.DescriptionAttribute("Производства по несъстоятелност")]
        public List<CasesType> Cases {
            get {
                return this.casesField;
            }
            set {
                this.casesField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.28328")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/MP/RNSearchResponse")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://egov.bg/RegiX/MP/RNSearchResponse", IsNullable=true)]
    public partial class CasesType {
        
        private CaseInfoType caseInfoField;
        
        private SideInfoType sideInfoField;
        
        private System.DateTime lastUpdatedField;
        
        private bool lastUpdatedFieldSpecified;
        
        /// <summary>
        /// CasesType class constructor
        /// </summary>
        public CasesType() {
            this.sideInfoField = new SideInfoType();
            this.caseInfoField = new CaseInfoType();
        }
        
        /// <summary>
        /// Делото в което е намерена като страна организацията/лицето
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        [System.ComponentModel.DescriptionAttribute("Делото в което е намерена като страна организацията/лицето")]
        public CaseInfoType CaseInfo {
            get {
                return this.caseInfoField;
            }
            set {
                this.caseInfoField = value;
            }
        }
        
        /// <summary>
        /// Детайли за страната
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        [System.ComponentModel.DescriptionAttribute("Детайли за страната")]
        public SideInfoType SideInfo {
            get {
                return this.sideInfoField;
            }
            set {
                this.sideInfoField = value;
            }
        }
        
        /// <summary>
        /// Дата и час кога е взет от базата данни резултата
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date", Order=2)]
        [System.ComponentModel.DescriptionAttribute("Дата и час кога е взет от базата данни резултата")]
        public System.DateTime LastUpdated {
            get {
                return this.lastUpdatedField;
            }
            set {
                this.lastUpdatedField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool LastUpdatedSpecified {
            get {
                return this.lastUpdatedFieldSpecified;
            }
            set {
                this.lastUpdatedFieldSpecified = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.28328")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/MP/RNSearchResponse")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://egov.bg/RegiX/MP/RNSearchResponse", IsNullable=true)]
    public partial class CaseInfoType {
        
        private int numberField;
        
        private bool numberFieldSpecified;
        
        private int yearField;
        
        private bool yearFieldSpecified;
        
        private System.Nullable<System.DateTime> dateField;
        
        private bool dateFieldSpecified;
        
        private string courtField;
        
        private string courtNameField;
        
        private System.Nullable<System.DateTime> lastUpdateField;
        
        private bool lastUpdateFieldSpecified;
        
        /// <summary>
        /// Номер
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        [System.ComponentModel.DescriptionAttribute("Номер")]
        public int Number {
            get {
                return this.numberField;
            }
            set {
                this.numberField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool NumberSpecified {
            get {
                return this.numberFieldSpecified;
            }
            set {
                this.numberFieldSpecified = value;
            }
        }
        
        /// <summary>
        /// Година
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        [System.ComponentModel.DescriptionAttribute("Година")]
        public int Year {
            get {
                return this.yearField;
            }
            set {
                this.yearField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool YearSpecified {
            get {
                return this.yearFieldSpecified;
            }
            set {
                this.yearFieldSpecified = value;
            }
        }
        
        /// <summary>
        /// Дата
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=2)]
        [System.ComponentModel.DescriptionAttribute("Дата")]
        public System.Nullable<System.DateTime> Date {
            get {
                return this.dateField;
            }
            set {
                this.dateField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DateSpecified {
            get {
                return this.dateFieldSpecified;
            }
            set {
                this.dateFieldSpecified = value;
            }
        }
        
        /// <summary>
        /// Идентификатор на съд
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        [System.ComponentModel.DescriptionAttribute("Идентификатор на съд")]
        public string Court {
            get {
                return this.courtField;
            }
            set {
                this.courtField = value;
            }
        }
        
        /// <summary>
        /// Име на съд
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        [System.ComponentModel.DescriptionAttribute("Име на съд")]
        public string CourtName {
            get {
                return this.courtNameField;
            }
            set {
                this.courtNameField = value;
            }
        }
        
        /// <summary>
        /// Дата и час на последна модификация на обекта в базата данни
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=5)]
        [System.ComponentModel.DescriptionAttribute("Дата и час на последна модификация на обекта в базата данни")]
        public System.Nullable<System.DateTime> LastUpdate {
            get {
                return this.lastUpdateField;
            }
            set {
                this.lastUpdateField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool LastUpdateSpecified {
            get {
                return this.lastUpdateFieldSpecified;
            }
            set {
                this.lastUpdateFieldSpecified = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.28328")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/MP/RNSearchResponse")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://egov.bg/RegiX/MP/RNSearchResponse", IsNullable=true)]
    public partial class SideInfoType {
        
        private string nameField;
        
        private bool isPersonField;
        
        private bool isPersonFieldSpecified;
        
        private string eGNField;
        
        private string bulstatField;
        
        private int involvementField;
        
        private bool involvementFieldSpecified;
        
        private string involvementTextField;
        
        private System.Nullable<System.DateTime> lastUpdateField;
        
        private bool lastUpdateFieldSpecified;
        
        /// <summary>
        /// Име
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        [System.ComponentModel.DescriptionAttribute("Име")]
        public string Name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
        
        /// <summary>
        /// Дали е човек
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        [System.ComponentModel.DescriptionAttribute("Дали е човек")]
        public bool IsPerson {
            get {
                return this.isPersonField;
            }
            set {
                this.isPersonField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IsPersonSpecified {
            get {
                return this.isPersonFieldSpecified;
            }
            set {
                this.isPersonFieldSpecified = value;
            }
        }
        
        /// <summary>
        /// ЕГН
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        [System.ComponentModel.DescriptionAttribute("ЕГН")]
        public string EGN {
            get {
                return this.eGNField;
            }
            set {
                this.eGNField = value;
            }
        }
        
        /// <summary>
        /// Булстат
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        [System.ComponentModel.DescriptionAttribute("Булстат")]
        public string Bulstat {
            get {
                return this.bulstatField;
            }
            set {
                this.bulstatField = value;
            }
        }
        
        /// <summary>
        /// Идентификатор на тип участие на страната
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        [System.ComponentModel.DescriptionAttribute("Идентификатор на тип участие на страната")]
        public int Involvement {
            get {
                return this.involvementField;
            }
            set {
                this.involvementField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool InvolvementSpecified {
            get {
                return this.involvementFieldSpecified;
            }
            set {
                this.involvementFieldSpecified = value;
            }
        }
        
        /// <summary>
        /// Тип участие на страната
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        [System.ComponentModel.DescriptionAttribute("Тип участие на страната")]
        public string InvolvementText {
            get {
                return this.involvementTextField;
            }
            set {
                this.involvementTextField = value;
            }
        }
        
        /// <summary>
        /// Дата и час на последна модификация на обекта в базата данни
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=6)]
        [System.ComponentModel.DescriptionAttribute("Дата и час на последна модификация на обекта в базата данни")]
        public System.Nullable<System.DateTime> LastUpdate {
            get {
                return this.lastUpdateField;
            }
            set {
                this.lastUpdateField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool LastUpdateSpecified {
            get {
                return this.lastUpdateFieldSpecified;
            }
            set {
                this.lastUpdateFieldSpecified = value;
            }
        }
    }
}
