// ------------------------------------------------------------------------------
//  <auto-generated>
//    Generated by Xsd2Code. Version 3.4.0.30312
//    <NameSpace>TechnoLogica.RegiX.CRCNotificationsAdapter</NameSpace><Collection>List</Collection><codeType>CSharp</codeType><EnableDataBinding>False</EnableDataBinding><EnableLazyLoading>False</EnableLazyLoading><TrackingChangesEnable>False</TrackingChangesEnable><GenTrackingClasses>False</GenTrackingClasses><HidePrivateFieldInIDE>False</HidePrivateFieldInIDE><EnableSummaryComment>True</EnableSummaryComment><VirtualProp>False</VirtualProp><IncludeSerializeMethod>False</IncludeSerializeMethod><UseBaseClass>False</UseBaseClass><GenBaseClass>False</GenBaseClass><GenerateCloneMethod>False</GenerateCloneMethod><GenerateDataContracts>False</GenerateDataContracts><CodeBaseTag>Net40</CodeBaseTag><SerializeMethodName>Serialize</SerializeMethodName><DeserializeMethodName>Deserialize</DeserializeMethodName><SaveToFileMethodName>SaveToFile</SaveToFileMethodName><LoadFromFileMethodName>LoadFromFile</LoadFromFileMethodName><GenerateXMLAttributes>True</GenerateXMLAttributes><EnableEncoding>False</EnableEncoding><AutomaticProperties>False</AutomaticProperties><GenerateShouldSerialize>False</GenerateShouldSerialize><DisableDebug>False</DisableDebug><PropNameSpecified>Default</PropNameSpecified><Encoder>UTF8</Encoder><CustomUsings></CustomUsings><ExcludeIncludedTypes>True</ExcludeIncludedTypes><EnableInitializeFields>True</EnableInitializeFields>
//  </auto-generated>
// ------------------------------------------------------------------------------
namespace TechnoLogica.RegiX.CRCNotificationsAdapter {
    using System;
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System.Collections;
    using System.Xml.Schema;
    using System.ComponentModel;
    using System.Collections.Generic;
    
    
    /// <summary>
    /// Входни параметри на Справка по мрежа/услуга
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.30313")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://egov.bg/RegiX/CRC/Notifications/GetNetworksAndServicesInfoRequest")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://egov.bg/RegiX/CRC/Notifications/GetNetworksAndServicesInfoRequest", IsNullable=false)]
    [System.ComponentModel.DescriptionAttribute("Входни параметри на Справка по мрежа/услуга")]
    public partial class GetNetworksAndServicesInfoRequest {
        
        private string descriptionField;
        
        private string settlementField;
        
        private string nameField;
        
        private string municipalityField;
        
        private string regionField;
        
        private System.DateTime rightsOriginStartDateField;
        
        private System.DateTime rightsOriginEndDateField;
        
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string Description {
            get {
                return this.descriptionField;
            }
            set {
                this.descriptionField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string Settlement {
            get {
                return this.settlementField;
            }
            set {
                this.settlementField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string Name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string Municipality {
            get {
                return this.municipalityField;
            }
            set {
                this.municipalityField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string Region {
            get {
                return this.regionField;
            }
            set {
                this.regionField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(DataType="date", Order=5)]
        public System.DateTime RightsOriginStartDate {
            get {
                return this.rightsOriginStartDateField;
            }
            set {
                this.rightsOriginStartDateField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(DataType="date", Order=6)]
        public System.DateTime RightsOriginEndDate {
            get {
                return this.rightsOriginEndDateField;
            }
            set {
                this.rightsOriginEndDateField = value;
            }
        }
    }
}
