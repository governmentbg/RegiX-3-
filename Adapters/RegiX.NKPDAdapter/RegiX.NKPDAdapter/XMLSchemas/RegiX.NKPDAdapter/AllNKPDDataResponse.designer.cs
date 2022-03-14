// ------------------------------------------------------------------------------
//  <auto-generated>
//    Generated by Xsd2Code. Version 3.4.0.24467
//    <NameSpace>TechnoLogica.RegiX.NKPDAdapter</NameSpace><Collection>List</Collection><codeType>CSharp</codeType><EnableDataBinding>False</EnableDataBinding><EnableLazyLoading>False</EnableLazyLoading><TrackingChangesEnable>False</TrackingChangesEnable><GenTrackingClasses>False</GenTrackingClasses><HidePrivateFieldInIDE>False</HidePrivateFieldInIDE><EnableSummaryComment>True</EnableSummaryComment><VirtualProp>False</VirtualProp><IncludeSerializeMethod>False</IncludeSerializeMethod><UseBaseClass>False</UseBaseClass><GenBaseClass>False</GenBaseClass><GenerateCloneMethod>False</GenerateCloneMethod><GenerateDataContracts>False</GenerateDataContracts><CodeBaseTag>Net40</CodeBaseTag><SerializeMethodName>Serialize</SerializeMethodName><DeserializeMethodName>Deserialize</DeserializeMethodName><SaveToFileMethodName>SaveToFile</SaveToFileMethodName><LoadFromFileMethodName>LoadFromFile</LoadFromFileMethodName><GenerateXMLAttributes>True</GenerateXMLAttributes><EnableEncoding>False</EnableEncoding><AutomaticProperties>False</AutomaticProperties><GenerateShouldSerialize>False</GenerateShouldSerialize><DisableDebug>False</DisableDebug><PropNameSpecified>Default</PropNameSpecified><Encoder>UTF8</Encoder><CustomUsings></CustomUsings><ExcludeIncludedTypes>True</ExcludeIncludedTypes><EnableInitializeFields>True</EnableInitializeFields>
//  </auto-generated>
// ------------------------------------------------------------------------------
namespace TechnoLogica.RegiX.NKPDAdapter {
    using System;
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System.Collections;
    using System.Xml.Schema;
    using System.ComponentModel;
    using System.Collections.Generic;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.25506")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/MTSP/NKPD/AllNKPDDataResponse")]
    [System.Xml.Serialization.XmlRootAttribute("AllNKPDDataResponse", Namespace="http://egov.bg/RegiX/MTSP/NKPD/AllNKPDDataResponse", IsNullable=false)]
    public partial class AllNKPDDataType {
        
        private string versionNameField;
        
        private System.DateTime validDateField;
        
        private bool validDateFieldSpecified;
        
        private List<NKPDEntry> nKPDField;
        
        /// <summary>
        /// AllNKPDDataType class constructor
        /// </summary>
        public AllNKPDDataType() {
            this.nKPDField = new List<NKPDEntry>();
        }
        
        /// <summary>
        /// Наименование на версия
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        [System.ComponentModel.DescriptionAttribute("Наименование на версия")]
        public string VersionName {
            get {
                return this.versionNameField;
            }
            set {
                this.versionNameField = value;
            }
        }
        
        /// <summary>
        /// Дата на валидност
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date", Order=1)]
        [System.ComponentModel.DescriptionAttribute("Дата на валидност")]
        public System.DateTime ValidDate {
            get {
                return this.validDateField;
            }
            set {
                this.validDateField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ValidDateSpecified {
            get {
                return this.validDateFieldSpecified;
            }
            set {
                this.validDateFieldSpecified = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute("NKPD", Order=2)]
        public List<NKPDEntry> NKPD {
            get {
                return this.nKPDField;
            }
            set {
                this.nKPDField = value;
            }
        }
    }
}
