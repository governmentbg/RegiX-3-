// ------------------------------------------------------------------------------
//  <auto-generated>
//    Generated by Xsd2Code. Version 3.4.0.27043
//    <NameSpace>TechnoLogica.RegiX.IaaaVehicleInspectionsAdapter</NameSpace><Collection>List</Collection><codeType>CSharp</codeType><EnableDataBinding>False</EnableDataBinding><EnableLazyLoading>False</EnableLazyLoading><TrackingChangesEnable>False</TrackingChangesEnable><GenTrackingClasses>False</GenTrackingClasses><HidePrivateFieldInIDE>False</HidePrivateFieldInIDE><EnableSummaryComment>True</EnableSummaryComment><VirtualProp>False</VirtualProp><IncludeSerializeMethod>False</IncludeSerializeMethod><UseBaseClass>False</UseBaseClass><GenBaseClass>False</GenBaseClass><GenerateCloneMethod>False</GenerateCloneMethod><GenerateDataContracts>False</GenerateDataContracts><CodeBaseTag>Net40</CodeBaseTag><SerializeMethodName>Serialize</SerializeMethodName><DeserializeMethodName>Deserialize</DeserializeMethodName><SaveToFileMethodName>SaveToFile</SaveToFileMethodName><LoadFromFileMethodName>LoadFromFile</LoadFromFileMethodName><GenerateXMLAttributes>True</GenerateXMLAttributes><EnableEncoding>False</EnableEncoding><AutomaticProperties>False</AutomaticProperties><GenerateShouldSerialize>False</GenerateShouldSerialize><DisableDebug>False</DisableDebug><PropNameSpecified>Default</PropNameSpecified><Encoder>ASCII</Encoder><CustomUsings></CustomUsings><ExcludeIncludedTypes>True</ExcludeIncludedTypes><EnableInitializeFields>True</EnableInitializeFields>
//  </auto-generated>
// ------------------------------------------------------------------------------
namespace TechnoLogica.RegiX.IaaaVehicleInspectionsAdapter {
    using System;
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System.Collections;
    using System.Xml.Schema;
    using System.ComponentModel;
    using System.Collections.Generic;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.27060")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/Iaaa/VehicleInspections/PermitsInspectionCountReportRequest")]
    [System.Xml.Serialization.XmlRootAttribute("PermitsInspectionCountRequest", Namespace="http://egov.bg/RegiX/Iaaa/VehicleInspections/PermitsInspectionCountReportRequest", IsNullable=false)]
    public partial class PermitsInspectionCountRequestType {
        
        private string identNumberField;
        
        private System.DateTime dateFromField;
        
        private bool dateFromFieldSpecified;
        
        private System.DateTime dateToField;
        
        private bool dateToFieldSpecified;
        
        /// <summary>
        /// ??????/?????????????? ???? ?????????????????? ?????????? ?? ?????????? ???? ???????????????????? ????????????????
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        [System.ComponentModel.DescriptionAttribute("??????/?????????????? ???? ?????????????????? ?????????? ?? ?????????? ???? ???????????????????? ????????????????")]
        public string IdentNumber {
            get {
                return this.identNumberField;
            }
            set {
                this.identNumberField = value;
            }
        }
        
        /// <summary>
        /// ???????? ???? ?????????? ?? ??????????????????
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date", Order=1)]
        [System.ComponentModel.DescriptionAttribute("???????? ???? ?????????? ?? ??????????????????")]
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
        /// ???????? ??O ?????????? ?? ??????????????????
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date", Order=2)]
        [System.ComponentModel.DescriptionAttribute("???????? ??O ?????????? ?? ??????????????????")]
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
    }
}
