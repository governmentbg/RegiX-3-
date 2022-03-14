// ------------------------------------------------------------------------------
//  <auto-generated>
//    Generated by Xsd2Code. Version 3.4.0.30983
//    <NameSpace>TechnoLogica.RegiX.AZJobsAdapter</NameSpace><Collection>List</Collection><codeType>CSharp</codeType><EnableDataBinding>False</EnableDataBinding><EnableLazyLoading>False</EnableLazyLoading><TrackingChangesEnable>False</TrackingChangesEnable><GenTrackingClasses>False</GenTrackingClasses><HidePrivateFieldInIDE>False</HidePrivateFieldInIDE><EnableSummaryComment>True</EnableSummaryComment><VirtualProp>False</VirtualProp><IncludeSerializeMethod>False</IncludeSerializeMethod><UseBaseClass>False</UseBaseClass><GenBaseClass>False</GenBaseClass><GenerateCloneMethod>False</GenerateCloneMethod><GenerateDataContracts>False</GenerateDataContracts><CodeBaseTag>Net40</CodeBaseTag><SerializeMethodName>Serialize</SerializeMethodName><DeserializeMethodName>Deserialize</DeserializeMethodName><SaveToFileMethodName>SaveToFile</SaveToFileMethodName><LoadFromFileMethodName>LoadFromFile</LoadFromFileMethodName><GenerateXMLAttributes>True</GenerateXMLAttributes><EnableEncoding>False</EnableEncoding><AutomaticProperties>False</AutomaticProperties><GenerateShouldSerialize>False</GenerateShouldSerialize><DisableDebug>False</DisableDebug><PropNameSpecified>Default</PropNameSpecified><Encoder>UTF8</Encoder><CustomUsings></CustomUsings><ExcludeIncludedTypes>True</ExcludeIncludedTypes><EnableInitializeFields>True</EnableInitializeFields>
//  </auto-generated>
// ------------------------------------------------------------------------------
namespace TechnoLogica.RegiX.AZJobsAdapter {
    using System;
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System.Collections;
    using System.Xml.Schema;
    using System.ComponentModel;
    using System.Collections.Generic;
    
    
    /// <summary>
    /// Справка по ЕИК/БУЛСТАТ за обявени свободни работни места при работодател - резултат
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.20530")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://egov.bg/RegiX/AZ/EmployerFreeJobPositionsResponse")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://egov.bg/RegiX/AZ/EmployerFreeJobPositionsResponse", IsNullable=false)]
    [System.ComponentModel.DescriptionAttribute("Справка по ЕИК/БУЛСТАТ за обявени свободни работни места при работодател - резулт" +
        "ат")]
    public partial class EmployerFreeJobPositionsResponse {
        
        private EntityData employerDataField;
        
        private List<FreeJobPosition> freeJobPositionsField;
        
        /// <summary>
        /// EmployerFreeJobPositionsResponse class constructor
        /// </summary>
        public EmployerFreeJobPositionsResponse() {
            this.freeJobPositionsField = new List<FreeJobPosition>();
            this.employerDataField = new EntityData();
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public EntityData EmployerData {
            get {
                return this.employerDataField;
            }
            set {
                this.employerDataField = value;
            }
        }
        
        [System.Xml.Serialization.XmlArrayAttribute(Order=1)]
        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable=false)]
        public List<FreeJobPosition> FreeJobPositions {
            get {
                return this.freeJobPositionsField;
            }
            set {
                this.freeJobPositionsField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.20530")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/AZ/EmployerFreeJobPositionsResponse")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://egov.bg/RegiX/AZ/EmployerFreeJobPositionsResponse", IsNullable=true)]
    public partial class FreeJobPosition {
        
        private string jobPositionField;
        
        private System.DateTime dateFromField;
        
        private bool dateFromFieldSpecified;
        
        private System.DateTime dateToField;
        
        private bool dateToFieldSpecified;
        
        private int announcedFreeJobsCountField;
        
        private bool announcedFreeJobsCountFieldSpecified;
        
        private int jobSeekersDirectedCountField;
        
        private bool jobSeekersDirectedCountFieldSpecified;
        
        private int vacantJobsCountField;
        
        private bool vacantJobsCountFieldSpecified;
        
        private string minucipalityField;
        
        private string areaField;
        
        private string townField;
        
        private string districtField;
        
        private string addressField;
        
        private string educationRequirementsField;
        
        private string languageSkillsRequirementsField;
        
        private string computerSkillsRequirementsField;
        
        /// <summary>
        /// Длъжност (свободно работно място)
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        [System.ComponentModel.DescriptionAttribute("Длъжност (свободно работно място)")]
        public string JobPosition {
            get {
                return this.jobPositionField;
            }
            set {
                this.jobPositionField = value;
            }
        }
        
        /// <summary>
        /// Начална дата на валидност на обявената позиция
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date", Order=1)]
        [System.ComponentModel.DescriptionAttribute("Начална дата на валидност на обявената позиция")]
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
        /// Крайна дата на валидност на обявената позиция
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date", Order=2)]
        [System.ComponentModel.DescriptionAttribute("Крайна дата на валидност на обявената позиция")]
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
        /// Брой обявени свободни работни места
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        [System.ComponentModel.DescriptionAttribute("Брой обявени свободни работни места")]
        public int AnnouncedFreeJobsCount {
            get {
                return this.announcedFreeJobsCountField;
            }
            set {
                this.announcedFreeJobsCountField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AnnouncedFreeJobsCountSpecified {
            get {
                return this.announcedFreeJobsCountFieldSpecified;
            }
            set {
                this.announcedFreeJobsCountFieldSpecified = value;
            }
        }
        
        /// <summary>
        /// Брой насочени търсещи работа лица
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        [System.ComponentModel.DescriptionAttribute("Брой насочени търсещи работа лица")]
        public int JobSeekersDirectedCount {
            get {
                return this.jobSeekersDirectedCountField;
            }
            set {
                this.jobSeekersDirectedCountField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool JobSeekersDirectedCountSpecified {
            get {
                return this.jobSeekersDirectedCountFieldSpecified;
            }
            set {
                this.jobSeekersDirectedCountFieldSpecified = value;
            }
        }
        
        /// <summary>
        /// Брой незаети свободни работни места
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        [System.ComponentModel.DescriptionAttribute("Брой незаети свободни работни места")]
        public int VacantJobsCount {
            get {
                return this.vacantJobsCountField;
            }
            set {
                this.vacantJobsCountField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool VacantJobsCountSpecified {
            get {
                return this.vacantJobsCountFieldSpecified;
            }
            set {
                this.vacantJobsCountFieldSpecified = value;
            }
        }
        
        /// <summary>
        /// Община на местонахождение на работно място
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        [System.ComponentModel.DescriptionAttribute("Община на местонахождение на работно място")]
        public string Minucipality {
            get {
                return this.minucipalityField;
            }
            set {
                this.minucipalityField = value;
            }
        }
        
        /// <summary>
        /// Област
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        [System.ComponentModel.DescriptionAttribute("Област")]
        public string Area {
            get {
                return this.areaField;
            }
            set {
                this.areaField = value;
            }
        }
        
        /// <summary>
        /// Град
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        [System.ComponentModel.DescriptionAttribute("Град")]
        public string Town {
            get {
                return this.townField;
            }
            set {
                this.townField = value;
            }
        }
        
        /// <summary>
        /// Район
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        [System.ComponentModel.DescriptionAttribute("Район")]
        public string District {
            get {
                return this.districtField;
            }
            set {
                this.districtField = value;
            }
        }
        
        /// <summary>
        /// Адрес
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
        [System.ComponentModel.DescriptionAttribute("Адрес")]
        public string Address {
            get {
                return this.addressField;
            }
            set {
                this.addressField = value;
            }
        }
        
        /// <summary>
        /// Изисквания за образование
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=11)]
        [System.ComponentModel.DescriptionAttribute("Изисквания за образование")]
        public string EducationRequirements {
            get {
                return this.educationRequirementsField;
            }
            set {
                this.educationRequirementsField = value;
            }
        }
        
        /// <summary>
        /// Изисквания за езикови умения
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=12)]
        [System.ComponentModel.DescriptionAttribute("Изисквания за езикови умения")]
        public string LanguageSkillsRequirements {
            get {
                return this.languageSkillsRequirementsField;
            }
            set {
                this.languageSkillsRequirementsField = value;
            }
        }
        
        /// <summary>
        /// Изисквания за компютърни умения
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=13)]
        [System.ComponentModel.DescriptionAttribute("Изисквания за компютърни умения")]
        public string ComputerSkillsRequirements {
            get {
                return this.computerSkillsRequirementsField;
            }
            set {
                this.computerSkillsRequirementsField = value;
            }
        }
    }
}