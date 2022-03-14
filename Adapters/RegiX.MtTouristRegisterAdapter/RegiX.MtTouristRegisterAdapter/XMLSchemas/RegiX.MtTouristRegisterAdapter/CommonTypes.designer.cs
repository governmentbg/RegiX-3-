// ------------------------------------------------------------------------------
//  <auto-generated>
//    Generated by Xsd2Code. Version 3.4.0.18600
//    <NameSpace>TechnoLogica.RegiX.MtTouristRegisterAdapter</NameSpace><Collection>List</Collection><codeType>CSharp</codeType><EnableDataBinding>False</EnableDataBinding><EnableLazyLoading>False</EnableLazyLoading><TrackingChangesEnable>False</TrackingChangesEnable><GenTrackingClasses>False</GenTrackingClasses><HidePrivateFieldInIDE>False</HidePrivateFieldInIDE><EnableSummaryComment>True</EnableSummaryComment><VirtualProp>False</VirtualProp><IncludeSerializeMethod>False</IncludeSerializeMethod><UseBaseClass>False</UseBaseClass><GenBaseClass>False</GenBaseClass><GenerateCloneMethod>False</GenerateCloneMethod><GenerateDataContracts>False</GenerateDataContracts><CodeBaseTag>Net40</CodeBaseTag><SerializeMethodName>Serialize</SerializeMethodName><DeserializeMethodName>Deserialize</DeserializeMethodName><SaveToFileMethodName>SaveToFile</SaveToFileMethodName><LoadFromFileMethodName>LoadFromFile</LoadFromFileMethodName><GenerateXMLAttributes>True</GenerateXMLAttributes><EnableEncoding>False</EnableEncoding><AutomaticProperties>False</AutomaticProperties><GenerateShouldSerialize>False</GenerateShouldSerialize><DisableDebug>False</DisableDebug><PropNameSpecified>Default</PropNameSpecified><Encoder>UTF8</Encoder><CustomUsings></CustomUsings><ExcludeIncludedTypes>True</ExcludeIncludedTypes><EnableInitializeFields>True</EnableInitializeFields>
//  </auto-generated>
// ------------------------------------------------------------------------------
namespace TechnoLogica.RegiX.MtTouristRegisterAdapter {
    using System;
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System.Collections;
    using System.Xml.Schema;
    using System.ComponentModel;
    using System.Collections.Generic;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.25858")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/MT/Common")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://egov.bg/RegiX/MT/Common", IsNullable=false)]
    public enum EntertainmentObjectTypeEnum {
        
        /// <remarks/>
        Bar,
        
        /// <remarks/>
        Restaurant,
        
        /// <remarks/>
        Other,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.25858")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/MT/Common")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://egov.bg/RegiX/MT/Common", IsNullable=true)]
    public partial class ContactType {
        
        private string distNameField;
        
        private string terNameField;
        
        private string popNameField;
        
        private string adressField;
        
        private string phoneField;
        
        private string faxField;
        
        /// <summary>
        /// Област
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        [System.ComponentModel.DescriptionAttribute("Област")]
        public string DistName {
            get {
                return this.distNameField;
            }
            set {
                this.distNameField = value;
            }
        }
        
        /// <summary>
        /// Община
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        [System.ComponentModel.DescriptionAttribute("Община")]
        public string TerName {
            get {
                return this.terNameField;
            }
            set {
                this.terNameField = value;
            }
        }
        
        /// <summary>
        /// Населено място
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        [System.ComponentModel.DescriptionAttribute("Населено място")]
        public string PopName {
            get {
                return this.popNameField;
            }
            set {
                this.popNameField = value;
            }
        }
        
        /// <summary>
        /// Адрес
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        [System.ComponentModel.DescriptionAttribute("Адрес")]
        public string Adress {
            get {
                return this.adressField;
            }
            set {
                this.adressField = value;
            }
        }
        
        /// <summary>
        /// Телефон
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        [System.ComponentModel.DescriptionAttribute("Телефон")]
        public string Phone {
            get {
                return this.phoneField;
            }
            set {
                this.phoneField = value;
            }
        }
        
        /// <summary>
        /// Факс
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        [System.ComponentModel.DescriptionAttribute("Факс")]
        public string Fax {
            get {
                return this.faxField;
            }
            set {
                this.faxField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.25858")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/MT/Common")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://egov.bg/RegiX/MT/Common", IsNullable=true)]
    public partial class CertificateType {
        
        private string categoryCertNumField;
        
        private System.Nullable<System.DateTime> categoryCertDateField;
        
        private bool categoryCertDateFieldSpecified;
        
        private System.Nullable<System.DateTime> validityTermField;
        
        private bool validityTermFieldSpecified;
        
        /// <summary>
        /// Номер на удостоверение за категория
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        [System.ComponentModel.DescriptionAttribute("Номер на удостоверение за категория")]
        public string CategoryCertNum {
            get {
                return this.categoryCertNumField;
            }
            set {
                this.categoryCertNumField = value;
            }
        }
        
        /// <summary>
        /// Дата на удостоверението за категория
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date", IsNullable=true, Order=1)]
        [System.ComponentModel.DescriptionAttribute("Дата на удостоверението за категория")]
        public System.Nullable<System.DateTime> CategoryCertDate {
            get {
                return this.categoryCertDateField;
            }
            set {
                this.categoryCertDateField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CategoryCertDateSpecified {
            get {
                return this.categoryCertDateFieldSpecified;
            }
            set {
                this.categoryCertDateFieldSpecified = value;
            }
        }
        
        /// <summary>
        /// Срок на валидност
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date", IsNullable=true, Order=2)]
        [System.ComponentModel.DescriptionAttribute("Срок на валидност")]
        public System.Nullable<System.DateTime> ValidityTerm {
            get {
                return this.validityTermField;
            }
            set {
                this.validityTermField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ValidityTermSpecified {
            get {
                return this.validityTermFieldSpecified;
            }
            set {
                this.validityTermFieldSpecified = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.25858")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/MT/Common")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://egov.bg/RegiX/MT/Common", IsNullable=true)]
    public partial class TouristSubobjectType {
        
        private string descriptionField;
        
        private System.Nullable<EntertainmentObjectTypeEnum> typeField;
        
        private bool typeFieldSpecified;
        
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string Description {
            get {
                return this.descriptionField;
            }
            set {
                this.descriptionField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=1)]
        public System.Nullable<EntertainmentObjectTypeEnum> Type {
            get {
                return this.typeField;
            }
            set {
                this.typeField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TypeSpecified {
            get {
                return this.typeFieldSpecified;
            }
            set {
                this.typeFieldSpecified = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.25858")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/MT/Common")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://egov.bg/RegiX/MT/Common", IsNullable=true)]
    public partial class CapacityType {
        
        private int capacityField;
        
        private bool capacityFieldSpecified;
        
        private int indoorsCapacityField;
        
        private bool indoorsCapacityFieldSpecified;
        
        private int outdoorsCapacityField;
        
        private bool outdoorsCapacityFieldSpecified;
        
        /// <summary>
        /// Определен капацитет
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        [System.ComponentModel.DescriptionAttribute("Определен капацитет")]
        public int Capacity {
            get {
                return this.capacityField;
            }
            set {
                this.capacityField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CapacitySpecified {
            get {
                return this.capacityFieldSpecified;
            }
            set {
                this.capacityFieldSpecified = value;
            }
        }
        
        /// <summary>
        /// Определен капацитет на закрито
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        [System.ComponentModel.DescriptionAttribute("Определен капацитет на закрито")]
        public int IndoorsCapacity {
            get {
                return this.indoorsCapacityField;
            }
            set {
                this.indoorsCapacityField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IndoorsCapacitySpecified {
            get {
                return this.indoorsCapacityFieldSpecified;
            }
            set {
                this.indoorsCapacityFieldSpecified = value;
            }
        }
        
        /// <summary>
        /// Определен капацитет на открито
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        [System.ComponentModel.DescriptionAttribute("Определен капацитет на открито")]
        public int OutdoorsCapacity {
            get {
                return this.outdoorsCapacityField;
            }
            set {
                this.outdoorsCapacityField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool OutdoorsCapacitySpecified {
            get {
                return this.outdoorsCapacityFieldSpecified;
            }
            set {
                this.outdoorsCapacityFieldSpecified = value;
            }
        }
    }
}
