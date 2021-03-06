// ------------------------------------------------------------------------------
//  <auto-generated>
//    Generated by Xsd2Code. Version 3.4.0.25768
//    <NameSpace>TechnoLogica.RegiX.GraoLEAdapter</NameSpace><Collection>List</Collection><codeType>CSharp</codeType><EnableDataBinding>False</EnableDataBinding><EnableLazyLoading>False</EnableLazyLoading><TrackingChangesEnable>False</TrackingChangesEnable><GenTrackingClasses>False</GenTrackingClasses><HidePrivateFieldInIDE>False</HidePrivateFieldInIDE><EnableSummaryComment>True</EnableSummaryComment><VirtualProp>False</VirtualProp><IncludeSerializeMethod>False</IncludeSerializeMethod><UseBaseClass>False</UseBaseClass><GenBaseClass>False</GenBaseClass><GenerateCloneMethod>False</GenerateCloneMethod><GenerateDataContracts>False</GenerateDataContracts><CodeBaseTag>Net40</CodeBaseTag><SerializeMethodName>Serialize</SerializeMethodName><DeserializeMethodName>Deserialize</DeserializeMethodName><SaveToFileMethodName>SaveToFile</SaveToFileMethodName><LoadFromFileMethodName>LoadFromFile</LoadFromFileMethodName><GenerateXMLAttributes>True</GenerateXMLAttributes><EnableEncoding>False</EnableEncoding><AutomaticProperties>False</AutomaticProperties><GenerateShouldSerialize>False</GenerateShouldSerialize><DisableDebug>False</DisableDebug><PropNameSpecified>Default</PropNameSpecified><Encoder>UTF8</Encoder><CustomUsings></CustomUsings><ExcludeIncludedTypes>True</ExcludeIncludedTypes><EnableInitializeFields>True</EnableInitializeFields>
//  </auto-generated>
// ------------------------------------------------------------------------------
namespace TechnoLogica.RegiX.GraoLEAdapter {
    using System;
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System.Collections;
    using System.Xml.Schema;
    using System.ComponentModel;
    using System.Collections.Generic;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.29720")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/GRAO/LE/LocationsRequest")]
    [System.Xml.Serialization.XmlRootAttribute("LocationsRequest", Namespace="http://egov.bg/RegiX/GRAO/LE/LocationsRequest", IsNullable=false)]
    public partial class LocationsRequestType {
        
        private System.DateTime startDateField;
        
        private System.DateTime endDateField;
        
        private ActualizationType actualizationTypeField;
        
        private bool actualizationTypeFieldSpecified;
        
        /// <summary>
        /// ?????????????? ????????
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date", Order=0)]
        [System.ComponentModel.DescriptionAttribute("?????????????? ????????")]
        public System.DateTime StartDate {
            get {
                return this.startDateField;
            }
            set {
                this.startDateField = value;
            }
        }
        
        /// <summary>
        /// ???????????? ????????
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date", Order=1)]
        [System.ComponentModel.DescriptionAttribute("???????????? ????????")]
        public System.DateTime EndDate {
            get {
                return this.endDateField;
            }
            set {
                this.endDateField = value;
            }
        }
        
        /// <summary>
        /// ?????? ?????????????????????????????? ?????????? (??????, ?????? ?? ??????)
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        [System.ComponentModel.DescriptionAttribute("?????? ?????????????????????????????? ?????????? (??????, ?????? ?? ??????)")]
        public ActualizationType ActualizationType {
            get {
                return this.actualizationTypeField;
            }
            set {
                this.actualizationTypeField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ActualizationTypeSpecified {
            get {
                return this.actualizationTypeFieldSpecified;
            }
            set {
                this.actualizationTypeFieldSpecified = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.29720")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/GRAO/LE/LocationsRequest")]
    public enum ActualizationType {
        
        /// <remarks/>
        ??????,
        
        /// <remarks/>
        ??????,
        
        /// <remarks/>
        ??????,
    }
}
