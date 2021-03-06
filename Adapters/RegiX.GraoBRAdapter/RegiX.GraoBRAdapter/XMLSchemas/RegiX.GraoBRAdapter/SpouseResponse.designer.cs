// ------------------------------------------------------------------------------
//  <auto-generated>
//    Generated by Xsd2Code. Version 3.4.0.25768
//    <NameSpace>TechnoLogica.RegiX.GraoBRAdapter</NameSpace><Collection>List</Collection><codeType>CSharp</codeType><EnableDataBinding>False</EnableDataBinding><EnableLazyLoading>False</EnableLazyLoading><TrackingChangesEnable>False</TrackingChangesEnable><GenTrackingClasses>False</GenTrackingClasses><HidePrivateFieldInIDE>False</HidePrivateFieldInIDE><EnableSummaryComment>True</EnableSummaryComment><VirtualProp>False</VirtualProp><IncludeSerializeMethod>False</IncludeSerializeMethod><UseBaseClass>False</UseBaseClass><GenBaseClass>False</GenBaseClass><GenerateCloneMethod>False</GenerateCloneMethod><GenerateDataContracts>False</GenerateDataContracts><CodeBaseTag>Net40</CodeBaseTag><SerializeMethodName>Serialize</SerializeMethodName><DeserializeMethodName>Deserialize</DeserializeMethodName><SaveToFileMethodName>SaveToFile</SaveToFileMethodName><LoadFromFileMethodName>LoadFromFile</LoadFromFileMethodName><GenerateXMLAttributes>True</GenerateXMLAttributes><EnableEncoding>False</EnableEncoding><AutomaticProperties>False</AutomaticProperties><GenerateShouldSerialize>False</GenerateShouldSerialize><DisableDebug>False</DisableDebug><PropNameSpecified>Default</PropNameSpecified><Encoder>UTF8</Encoder><CustomUsings></CustomUsings><ExcludeIncludedTypes>True</ExcludeIncludedTypes><EnableInitializeFields>True</EnableInitializeFields>
//  </auto-generated>
// ------------------------------------------------------------------------------
namespace TechnoLogica.RegiX.GraoBRAdapter {
    using System;
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System.Collections;
    using System.Xml.Schema;
    using System.ComponentModel;
    using System.Collections.Generic;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.30911")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/GRAO/BR/SpouseResponse")]
    [System.Xml.Serialization.XmlRootAttribute("SpouseResponse", Namespace="http://egov.bg/RegiX/GRAO/BR/SpouseResponse", IsNullable=false)]
    public partial class SpouseResponseType {
        
        private string eGNField;
        
        private string firstNameField;
        
        private string surNameField;
        
        private string familyNameField;
        
        private System.DateTime birthDateField;
        
        private bool birthDateFieldSpecified;
        
        private System.DateTime deathDateField;
        
        private bool deathDateFieldSpecified;
        
        private int genderCodeField;
        
        private bool genderCodeFieldSpecified;
        
        private GenderNameType genderNameField;
        
        private bool genderNameFieldSpecified;
        
        private string nationalityCodeField;
        
        private string nationalityNameField;
        
        private string secondNationalityCodeField;
        
        private string secondNationalityNameField;
        
        /// <summary>
        /// ЕГН/дата на раждане на съпруга/ съпругата
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        [System.ComponentModel.DescriptionAttribute("ЕГН/дата на раждане на съпруга/ съпругата")]
        public string EGN {
            get {
                return this.eGNField;
            }
            set {
                this.eGNField = value;
            }
        }
        
        /// <summary>
        /// Собствено име на съпруга/ съпругата
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        [System.ComponentModel.DescriptionAttribute("Собствено име на съпруга/ съпругата")]
        public string FirstName {
            get {
                return this.firstNameField;
            }
            set {
                this.firstNameField = value;
            }
        }
        
        /// <summary>
        /// Бащино име на съпруга/ съпругата
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        [System.ComponentModel.DescriptionAttribute("Бащино име на съпруга/ съпругата")]
        public string SurName {
            get {
                return this.surNameField;
            }
            set {
                this.surNameField = value;
            }
        }
        
        /// <summary>
        /// Фамилно име на съпруга/ съпругата
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        [System.ComponentModel.DescriptionAttribute("Фамилно име на съпруга/ съпругата")]
        public string FamilyName {
            get {
                return this.familyNameField;
            }
            set {
                this.familyNameField = value;
            }
        }
        
        /// <summary>
        /// Дата на раждане на съпруга/ съпругата
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date", Order=4)]
        [System.ComponentModel.DescriptionAttribute("Дата на раждане на съпруга/ съпругата")]
        public System.DateTime BirthDate {
            get {
                return this.birthDateField;
            }
            set {
                this.birthDateField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool BirthDateSpecified {
            get {
                return this.birthDateFieldSpecified;
            }
            set {
                this.birthDateFieldSpecified = value;
            }
        }
        
        /// <summary>
        /// Дата на смърт на съпруга/ съпругата
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date", Order=5)]
        [System.ComponentModel.DescriptionAttribute("Дата на смърт на съпруга/ съпругата")]
        public System.DateTime DeathDate {
            get {
                return this.deathDateField;
            }
            set {
                this.deathDateField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DeathDateSpecified {
            get {
                return this.deathDateFieldSpecified;
            }
            set {
                this.deathDateFieldSpecified = value;
            }
        }
        
        /// <summary>
        /// Код на пол на съпруга/ съпругата
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        [System.ComponentModel.DescriptionAttribute("Код на пол на съпруга/ съпругата")]
        public int GenderCode {
            get {
                return this.genderCodeField;
            }
            set {
                this.genderCodeField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool GenderCodeSpecified {
            get {
                return this.genderCodeFieldSpecified;
            }
            set {
                this.genderCodeFieldSpecified = value;
            }
        }
        
        /// <summary>
        /// Пол на съпруга/ съпругата
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        [System.ComponentModel.DescriptionAttribute("Пол на съпруга/ съпругата")]
        public GenderNameType GenderName {
            get {
                return this.genderNameField;
            }
            set {
                this.genderNameField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool GenderNameSpecified {
            get {
                return this.genderNameFieldSpecified;
            }
            set {
                this.genderNameFieldSpecified = value;
            }
        }
        
        /// <summary>
        /// Код на гражданство на съпруга/ съпругата
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        [System.ComponentModel.DescriptionAttribute("Код на гражданство на съпруга/ съпругата")]
        public string NationalityCode {
            get {
                return this.nationalityCodeField;
            }
            set {
                this.nationalityCodeField = value;
            }
        }
        
        /// <summary>
        /// Гражданство на съпруга/ съпругата
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        [System.ComponentModel.DescriptionAttribute("Гражданство на съпруга/ съпругата")]
        public string NationalityName {
            get {
                return this.nationalityNameField;
            }
            set {
                this.nationalityNameField = value;
            }
        }
        
        /// <summary>
        /// Код на второ гражданство на съпруга/ съпругата
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
        [System.ComponentModel.DescriptionAttribute("Код на второ гражданство на съпруга/ съпругата")]
        public string SecondNationalityCode {
            get {
                return this.secondNationalityCodeField;
            }
            set {
                this.secondNationalityCodeField = value;
            }
        }
        
        /// <summary>
        /// Второ гражданство на съпруга/ съпругата
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=11)]
        [System.ComponentModel.DescriptionAttribute("Второ гражданство на съпруга/ съпругата")]
        public string SecondNationalityName {
            get {
                return this.secondNationalityNameField;
            }
            set {
                this.secondNationalityNameField = value;
            }
        }
    }
}
