// ------------------------------------------------------------------------------
//  <auto-generated>
//    Generated by Xsd2Code. Version 3.4.0.20336
//    <NameSpace>TechnoLogica.RegiX.NOIHospotalSheetsAdapter</NameSpace><Collection>List</Collection><codeType>CSharp</codeType><EnableDataBinding>False</EnableDataBinding><EnableLazyLoading>False</EnableLazyLoading><TrackingChangesEnable>False</TrackingChangesEnable><GenTrackingClasses>False</GenTrackingClasses><HidePrivateFieldInIDE>False</HidePrivateFieldInIDE><EnableSummaryComment>True</EnableSummaryComment><VirtualProp>False</VirtualProp><IncludeSerializeMethod>False</IncludeSerializeMethod><UseBaseClass>False</UseBaseClass><GenBaseClass>False</GenBaseClass><GenerateCloneMethod>False</GenerateCloneMethod><GenerateDataContracts>False</GenerateDataContracts><CodeBaseTag>Net40</CodeBaseTag><SerializeMethodName>Serialize</SerializeMethodName><DeserializeMethodName>Deserialize</DeserializeMethodName><SaveToFileMethodName>SaveToFile</SaveToFileMethodName><LoadFromFileMethodName>LoadFromFile</LoadFromFileMethodName><GenerateXMLAttributes>True</GenerateXMLAttributes><EnableEncoding>False</EnableEncoding><AutomaticProperties>False</AutomaticProperties><GenerateShouldSerialize>False</GenerateShouldSerialize><DisableDebug>False</DisableDebug><PropNameSpecified>Default</PropNameSpecified><Encoder>UTF8</Encoder><CustomUsings></CustomUsings><ExcludeIncludedTypes>False</ExcludeIncludedTypes><EnableInitializeFields>True</EnableInitializeFields>
//  </auto-generated>
// ------------------------------------------------------------------------------
namespace TechnoLogica.RegiX.NOIHospotalSheetsAdapter {
    using System;
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System.Collections;
    using System.Xml.Schema;
    using System.ComponentModel;
    using System.Collections.Generic;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.24968")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/NOI/HospitalSheets/GetHospitalSheetsDataRequest")]
    [System.Xml.Serialization.XmlRootAttribute("GetHospitalSheetsDataRequest", Namespace="http://egov.bg/RegiX/NOI/HospitalSheets/GetHospitalSheetsDataRequest", IsNullable=false)]
    public partial class GetHospitalSheetsDataRequestType {
        
        private string identifierField;
        
        private IdentifierType identifierTypeField;
        
        private bool identifierTypeFieldSpecified;
        
        /// <summary>
        /// Идентификатор
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        [System.ComponentModel.DescriptionAttribute("Идентификатор")]
        public string Identifier {
            get {
                return this.identifierField;
            }
            set {
                this.identifierField = value;
            }
        }
        
        /// <summary>
        /// Тип на идентификатор (ЕГН/ЛНЧ)
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        [System.ComponentModel.DescriptionAttribute("Тип на идентификатор (ЕГН/ЛНЧ)")]
        public IdentifierType IdentifierType {
            get {
                return this.identifierTypeField;
            }
            set {
                this.identifierTypeField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IdentifierTypeSpecified {
            get {
                return this.identifierTypeFieldSpecified;
            }
            set {
                this.identifierTypeFieldSpecified = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.24968")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/NOI/HospitalSheets/GetHospitalSheetsDataRequest")]
    public enum IdentifierType {
        
        /// <remarks/>
        LNCh,
        
        /// <remarks/>
        EGN,
    }
}