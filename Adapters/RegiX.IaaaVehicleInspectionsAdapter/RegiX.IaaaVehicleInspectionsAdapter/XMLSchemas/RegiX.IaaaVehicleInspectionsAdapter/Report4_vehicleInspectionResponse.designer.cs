// ------------------------------------------------------------------------------
//  <auto-generated>
//    Generated by Xsd2Code. Version 3.4.0.29134
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
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.26516")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://egov.bg/RegiX/Iaaa/VehicleInspections/VehicleInspectionResponse")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://egov.bg/RegiX/Iaaa/VehicleInspections/VehicleInspectionResponse", IsNullable=false)]
    public partial class VehicleInspectionResponse {
        
        private long protocolNumberField;
        
        private bool protocolNumberFieldSpecified;
        
        private long stickerNumberField;
        
        private bool stickerNumberFieldSpecified;
        
        private PermitDto permitField;
        
        private System.DateTime inspectionDateTimeField;
        
        private bool inspectionDateTimeFieldSpecified;
        
        private System.DateTime endDateTimeField;
        
        private bool endDateTimeFieldSpecified;
        
        private string conclusionField;
        
        private string nextInspectionDateField;
        
        private PermitInspectorDto chairmanField;
        
        private PermitInspectorDto memberField;
        
        private string regNumberField;
        
        private string currentStatusField;
        
        /// <summary>
        /// VehicleInspectionResponse class constructor
        /// </summary>
        public VehicleInspectionResponse() {
            this.memberField = new PermitInspectorDto();
            this.chairmanField = new PermitInspectorDto();
            this.permitField = new PermitDto();
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public long ProtocolNumber {
            get {
                return this.protocolNumberField;
            }
            set {
                this.protocolNumberField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ProtocolNumberSpecified {
            get {
                return this.protocolNumberFieldSpecified;
            }
            set {
                this.protocolNumberFieldSpecified = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public long StickerNumber {
            get {
                return this.stickerNumberField;
            }
            set {
                this.stickerNumberField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool StickerNumberSpecified {
            get {
                return this.stickerNumberFieldSpecified;
            }
            set {
                this.stickerNumberFieldSpecified = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public PermitDto Permit {
            get {
                return this.permitField;
            }
            set {
                this.permitField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(DataType="date", Order=3)]
        public System.DateTime InspectionDateTime {
            get {
                return this.inspectionDateTimeField;
            }
            set {
                this.inspectionDateTimeField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool InspectionDateTimeSpecified {
            get {
                return this.inspectionDateTimeFieldSpecified;
            }
            set {
                this.inspectionDateTimeFieldSpecified = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(DataType="date", Order=4)]
        public System.DateTime EndDateTime {
            get {
                return this.endDateTimeField;
            }
            set {
                this.endDateTimeField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EndDateTimeSpecified {
            get {
                return this.endDateTimeFieldSpecified;
            }
            set {
                this.endDateTimeFieldSpecified = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string Conclusion {
            get {
                return this.conclusionField;
            }
            set {
                this.conclusionField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public string NextInspectionDate {
            get {
                return this.nextInspectionDateField;
            }
            set {
                this.nextInspectionDateField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public PermitInspectorDto Chairman {
            get {
                return this.chairmanField;
            }
            set {
                this.chairmanField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public PermitInspectorDto Member {
            get {
                return this.memberField;
            }
            set {
                this.memberField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        public string RegNumber {
            get {
                return this.regNumberField;
            }
            set {
                this.regNumberField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
        public string CurrentStatus {
            get {
                return this.currentStatusField;
            }
            set {
                this.currentStatusField = value;
            }
        }
    }
}
