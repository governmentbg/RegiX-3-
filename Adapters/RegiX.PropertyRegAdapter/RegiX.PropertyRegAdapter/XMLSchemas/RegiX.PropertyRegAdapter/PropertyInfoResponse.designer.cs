// ------------------------------------------------------------------------------
//  <auto-generated>
//    Generated by Xsd2Code. Version 3.4.0.25716
//    <NameSpace>TechnoLogica.RegiX.PropertyRegAdapter</NameSpace><Collection>List</Collection><codeType>CSharp</codeType><EnableDataBinding>False</EnableDataBinding><EnableLazyLoading>False</EnableLazyLoading><TrackingChangesEnable>False</TrackingChangesEnable><GenTrackingClasses>False</GenTrackingClasses><HidePrivateFieldInIDE>False</HidePrivateFieldInIDE><EnableSummaryComment>True</EnableSummaryComment><VirtualProp>False</VirtualProp><IncludeSerializeMethod>False</IncludeSerializeMethod><UseBaseClass>False</UseBaseClass><GenBaseClass>False</GenBaseClass><GenerateCloneMethod>False</GenerateCloneMethod><GenerateDataContracts>False</GenerateDataContracts><CodeBaseTag>Net40</CodeBaseTag><SerializeMethodName>Serialize</SerializeMethodName><DeserializeMethodName>Deserialize</DeserializeMethodName><SaveToFileMethodName>SaveToFile</SaveToFileMethodName><LoadFromFileMethodName>LoadFromFile</LoadFromFileMethodName><GenerateXMLAttributes>True</GenerateXMLAttributes><EnableEncoding>False</EnableEncoding><AutomaticProperties>False</AutomaticProperties><GenerateShouldSerialize>False</GenerateShouldSerialize><DisableDebug>False</DisableDebug><PropNameSpecified>Default</PropNameSpecified><Encoder>UTF8</Encoder><CustomUsings></CustomUsings><ExcludeIncludedTypes>True</ExcludeIncludedTypes><EnableInitializeFields>True</EnableInitializeFields>
//  </auto-generated>
// ------------------------------------------------------------------------------
namespace TechnoLogica.RegiX.PropertyRegAdapter {
    using System;
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System.Collections;
    using System.Xml.Schema;
    using System.ComponentModel;
    using System.Collections.Generic;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.21817")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/AV/PropertyReg/PropertyInfoResponse")]
    [System.Xml.Serialization.XmlRootAttribute("PropertyInfoResponse", Namespace="http://egov.bg/RegiX/AV/PropertyReg/PropertyInfoResponse", IsNullable=false)]
    public partial class PropertyInfoResponseType {
        
        private System.DateTime dateFromField;
        
        private bool dateFromFieldSpecified;
        
        private System.DateTime dateToField;
        
        private bool dateToFieldSpecified;
        
        private string propertyDataField;
        
        private string lotTypeField;
        
        private string lotNumberField;
        
        private System.DateTime dateOpenedField;
        
        private bool dateOpenedFieldSpecified;
        
        private string cadastreNumberField;
        
        private List<PropertyActDetail> propertyActDetailListField;
        
        private string registryAgencyField;
        
        private string siteIDField;
        
        private System.DateTime siteStartDateField;
        
        private bool siteStartDateFieldSpecified;
        
        /// <summary>
        /// PropertyInfoResponseType class constructor
        /// </summary>
        public PropertyInfoResponseType() {
            this.propertyActDetailListField = new List<PropertyActDetail>();
        }
        
        /// <summary>
        /// ???? ????????
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        [System.ComponentModel.DescriptionAttribute("???? ????????")]
        public System.DateTime DateFrom {
            get {
                return this.dateFromField;
            }
            set {
                this.dateFromField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DateFromSpecified {
            get {
                return this.dateFromFieldSpecified;
            }
            set {
                this.dateFromFieldSpecified = value;
            }
        }
        
        /// <summary>
        /// ???? ????????
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        [System.ComponentModel.DescriptionAttribute("???? ????????")]
        public System.DateTime DateTo {
            get {
                return this.dateToField;
            }
            set {
                this.dateToField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DateToSpecified {
            get {
                return this.dateToFieldSpecified;
            }
            set {
                this.dateToFieldSpecified = value;
            }
        }
        
        /// <summary>
        /// ?????????? ???? ????????
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        [System.ComponentModel.DescriptionAttribute("?????????? ???? ????????")]
        public string PropertyData {
            get {
                return this.propertyDataField;
            }
            set {
                this.propertyDataField = value;
            }
        }
        
        /// <summary>
        /// ?????? ??????????????
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        [System.ComponentModel.DescriptionAttribute("?????? ??????????????")]
        public string LotType {
            get {
                return this.lotTypeField;
            }
            set {
                this.lotTypeField = value;
            }
        }
        
        /// <summary>
        /// ??????????????
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        [System.ComponentModel.DescriptionAttribute("??????????????")]
        public string LotNumber {
            get {
                return this.lotNumberField;
            }
            set {
                this.lotNumberField = value;
            }
        }
        
        /// <summary>
        /// ?????????????? ???????? ???? ??????????????
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        [System.ComponentModel.DescriptionAttribute("?????????????? ???????? ???? ??????????????")]
        public System.DateTime DateOpened {
            get {
                return this.dateOpenedField;
            }
            set {
                this.dateOpenedField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DateOpenedSpecified {
            get {
                return this.dateOpenedFieldSpecified;
            }
            set {
                this.dateOpenedFieldSpecified = value;
            }
        }
        
        /// <summary>
        /// ?????????????????????? ??????????????????????????
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        [System.ComponentModel.DescriptionAttribute("?????????????????????? ??????????????????????????")]
        public string CadastreNumber {
            get {
                return this.cadastreNumberField;
            }
            set {
                this.cadastreNumberField = value;
            }
        }
        
        /// <summary>
        /// ??????????????????, ????????????????????????, ??????????????????????
        /// </summary>
        [System.Xml.Serialization.XmlArrayAttribute(Order=7)]
        [System.Xml.Serialization.XmlArrayItemAttribute(Namespace="http://egov.bg/RegiX/AV/PropertyReg", IsNullable=false)]
        [System.ComponentModel.DescriptionAttribute("??????????????????, ????????????????????????, ??????????????????????")]
        public List<PropertyActDetail> PropertyActDetailList {
            get {
                return this.propertyActDetailListField;
            }
            set {
                this.propertyActDetailListField = value;
            }
        }
        
        /// <summary>
        /// ???????????? ???? ??????????????????
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        [System.ComponentModel.DescriptionAttribute("???????????? ???? ??????????????????")]
        public string RegistryAgency {
            get {
                return this.registryAgencyField;
            }
            set {
                this.registryAgencyField = value;
            }
        }
        
        /// <summary>
        /// ?????????????????????????? ???? ???????????? ???? ??????????????????
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        [System.ComponentModel.DescriptionAttribute("?????????????????????????? ???? ???????????? ???? ??????????????????")]
        public string SiteID {
            get {
                return this.siteIDField;
            }
            set {
                this.siteIDField = value;
            }
        }
        
        /// <summary>
        /// ???????????? ???? ???????????????????? ???? ?????????????????????????? ??????????????
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date", Order=10)]
        [System.ComponentModel.DescriptionAttribute("???????????? ???? ???????????????????? ???? ?????????????????????????? ??????????????")]
        public System.DateTime SiteStartDate {
            get {
                return this.siteStartDateField;
            }
            set {
                this.siteStartDateField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SiteStartDateSpecified {
            get {
                return this.siteStartDateFieldSpecified;
            }
            set {
                this.siteStartDateFieldSpecified = value;
            }
        }
    }
}
