// ------------------------------------------------------------------------------
//  <auto-generated>
//    Generated by Xsd2Code. Version 3.4.0.19886
//    <NameSpace>TechnoLogica.RegiX.MPNPOAdapter</NameSpace><Collection>List</Collection><codeType>CSharp</codeType><EnableDataBinding>False</EnableDataBinding><EnableLazyLoading>False</EnableLazyLoading><TrackingChangesEnable>False</TrackingChangesEnable><GenTrackingClasses>False</GenTrackingClasses><HidePrivateFieldInIDE>False</HidePrivateFieldInIDE><EnableSummaryComment>True</EnableSummaryComment><VirtualProp>False</VirtualProp><IncludeSerializeMethod>False</IncludeSerializeMethod><UseBaseClass>False</UseBaseClass><GenBaseClass>False</GenBaseClass><GenerateCloneMethod>False</GenerateCloneMethod><GenerateDataContracts>False</GenerateDataContracts><CodeBaseTag>Net40</CodeBaseTag><SerializeMethodName>Serialize</SerializeMethodName><DeserializeMethodName>Deserialize</DeserializeMethodName><SaveToFileMethodName>SaveToFile</SaveToFileMethodName><LoadFromFileMethodName>LoadFromFile</LoadFromFileMethodName><GenerateXMLAttributes>True</GenerateXMLAttributes><EnableEncoding>False</EnableEncoding><AutomaticProperties>False</AutomaticProperties><GenerateShouldSerialize>False</GenerateShouldSerialize><DisableDebug>False</DisableDebug><PropNameSpecified>Default</PropNameSpecified><Encoder>UTF8</Encoder><CustomUsings></CustomUsings><ExcludeIncludedTypes>False</ExcludeIncludedTypes><EnableInitializeFields>True</EnableInitializeFields>
//  </auto-generated>
// ------------------------------------------------------------------------------
namespace TechnoLogica.RegiX.MPNPOAdapter {
    using System;
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System.Collections;
    using System.Xml.Schema;
    using System.ComponentModel;
    using System.Collections.Generic;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.30959")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/MP/NPODetailsResponse")]
    [System.Xml.Serialization.XmlRootAttribute("NPODetailsResponse", Namespace="http://egov.bg/RegiX/MP/NPODetailsResponse", IsNullable=false)]
    public partial class NPODetailsResponseType {
        
        private string registrationNumberField;
        
        private string nameField;
        
        private string orgFormField;
        
        private string addressField;
        
        private string contactInfoField;
        
        private string courtNameField;
        
        private string lotNumberField;
        
        private string courtCaseField;
        
        private string nationalityCodeField;
        
        private string nationalityField;
        
        private string boardTypeField;
        
        private List<BoardMemberType> boardMembersField;
        
        /// <summary>
        /// NPODetailsResponseType class constructor
        /// </summary>
        public NPODetailsResponseType() {
            this.boardMembersField = new List<BoardMemberType>();
        }
        
        /// <summary>
        /// Регистрационен номер
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        [System.ComponentModel.DescriptionAttribute("Регистрационен номер")]
        public string RegistrationNumber {
            get {
                return this.registrationNumberField;
            }
            set {
                this.registrationNumberField = value;
            }
        }
        
        /// <summary>
        /// Наименование на юридическо лице
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        [System.ComponentModel.DescriptionAttribute("Наименование на юридическо лице")]
        public string Name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
        
        /// <summary>
        /// Организационна форма
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        [System.ComponentModel.DescriptionAttribute("Организационна форма")]
        public string OrgForm {
            get {
                return this.orgFormField;
            }
            set {
                this.orgFormField = value;
            }
        }
        
        /// <summary>
        /// Седалище – адрес
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        [System.ComponentModel.DescriptionAttribute("Седалище – адрес")]
        public string Address {
            get {
                return this.addressField;
            }
            set {
                this.addressField = value;
            }
        }
        
        /// <summary>
        /// Информация за контакт
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        [System.ComponentModel.DescriptionAttribute("Информация за контакт")]
        public string ContactInfo {
            get {
                return this.contactInfoField;
            }
            set {
                this.contactInfoField = value;
            }
        }
        
        /// <summary>
        /// Съд по регистрация
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        [System.ComponentModel.DescriptionAttribute("Съд по регистрация")]
        public string CourtName {
            get {
                return this.courtNameField;
            }
            set {
                this.courtNameField = value;
            }
        }
        
        /// <summary>
        /// Партиден номер
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        [System.ComponentModel.DescriptionAttribute("Партиден номер")]
        public string LotNumber {
            get {
                return this.lotNumberField;
            }
            set {
                this.lotNumberField = value;
            }
        }
        
        /// <summary>
        /// Съдебно дело
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        [System.ComponentModel.DescriptionAttribute("Съдебно дело")]
        public string CourtCase {
            get {
                return this.courtCaseField;
            }
            set {
                this.courtCaseField = value;
            }
        }
        
        /// <summary>
        /// Код на националност
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        [System.ComponentModel.DescriptionAttribute("Код на националност")]
        public string NationalityCode {
            get {
                return this.nationalityCodeField;
            }
            set {
                this.nationalityCodeField = value;
            }
        }
        
        /// <summary>
        /// Националност
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        [System.ComponentModel.DescriptionAttribute("Националност")]
        public string Nationality {
            get {
                return this.nationalityField;
            }
            set {
                this.nationalityField = value;
            }
        }
        
        /// <summary>
        /// Управителен орган
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
        [System.ComponentModel.DescriptionAttribute("Управителен орган")]
        public string BoardType {
            get {
                return this.boardTypeField;
            }
            set {
                this.boardTypeField = value;
            }
        }
        
        /// <summary>
        /// Членове на управителен орган
        /// </summary>
        [System.Xml.Serialization.XmlArrayAttribute(Order=11)]
        [System.Xml.Serialization.XmlArrayItemAttribute("BoardMember", IsNullable=false)]
        [System.ComponentModel.DescriptionAttribute("Членове на управителен орган")]
        public List<BoardMemberType> BoardMembers {
            get {
                return this.boardMembersField;
            }
            set {
                this.boardMembersField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.30959")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/MP/NPODetailsResponse")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://egov.bg/RegiX/MP/NPODetailsResponse", IsNullable=true)]
    public partial class BoardMemberType {
        
        private string nameField;
        
        private System.DateTime dateFromField;
        
        private bool dateFromFieldSpecified;
        
        private System.DateTime dateToField;
        
        private bool dateToFieldSpecified;
        
        /// <summary>
        /// Имена
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        [System.ComponentModel.DescriptionAttribute("Имена")]
        public string Name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
        
        /// <summary>
        /// Начална дата на мандат
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date", Order=1)]
        [System.ComponentModel.DescriptionAttribute("Начална дата на мандат")]
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
        /// Крайна дата на мандат
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date", Order=2)]
        [System.ComponentModel.DescriptionAttribute("Крайна дата на мандат")]
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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.30959")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/MP/NPODetailsResponse")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://egov.bg/RegiX/MP/NPODetailsResponse", IsNullable=true)]
    public partial class BoardMembersType {
        
        private List<BoardMemberType> boardMemberField;
        
        /// <summary>
        /// BoardMembersType class constructor
        /// </summary>
        public BoardMembersType() {
            this.boardMemberField = new List<BoardMemberType>();
        }
        
        /// <summary>
        /// Член на управителния съвет
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("BoardMember", Order=0)]
        [System.ComponentModel.DescriptionAttribute("Член на управителния съвет")]
        public List<BoardMemberType> BoardMember {
            get {
                return this.boardMemberField;
            }
            set {
                this.boardMemberField = value;
            }
        }
    }
}
