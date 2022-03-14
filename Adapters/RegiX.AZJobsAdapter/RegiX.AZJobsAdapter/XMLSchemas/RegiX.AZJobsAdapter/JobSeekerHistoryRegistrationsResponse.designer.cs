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
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.20570")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/AZ/JobSeekerHistoryRegistrationsResponse")]
    [System.Xml.Serialization.XmlRootAttribute("JobSeekerHistoryRegistrationsResponse", Namespace="http://egov.bg/RegiX/AZ/JobSeekerHistoryRegistrationsResponse", IsNullable=false)]
    public partial class JobSeekerHistoryData {
        
        private PersonData jobSeekerPersonDataField;
        
        private JobSeekerHistoryDataHistoryOfRegistrations historyOfRegistrationsField;
        
        /// <summary>
        /// JobSeekerHistoryData class constructor
        /// </summary>
        public JobSeekerHistoryData() {
            this.historyOfRegistrationsField = new JobSeekerHistoryDataHistoryOfRegistrations();
            this.jobSeekerPersonDataField = new PersonData();
        }
        
        /// <summary>
        /// Общи данни за физическо лице, водени в Регистъра на търсещите работа лица
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        [System.ComponentModel.DescriptionAttribute("Общи данни за физическо лице, водени в Регистъра на търсещите работа лица")]
        public PersonData JobSeekerPersonData {
            get {
                return this.jobSeekerPersonDataField;
            }
            set {
                this.jobSeekerPersonDataField = value;
            }
        }
        
        /// <summary>
        /// Данни за история на регистрации на лице в АЗ
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        [System.ComponentModel.DescriptionAttribute("Данни за история на регистрации на лице в АЗ")]
        public JobSeekerHistoryDataHistoryOfRegistrations HistoryOfRegistrations {
            get {
                return this.historyOfRegistrationsField;
            }
            set {
                this.historyOfRegistrationsField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.20570")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/AZ/JobSeekerHistoryRegistrationsResponse")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://egov.bg/RegiX/AZ/JobSeekerHistoryRegistrationsResponse", IsNullable=true)]
    public partial class RegistrationHistoryData {
        
        private string activityField;
        
        private string registrationNumberField;
        
        private string registrationGroupField;
        
        private System.DateTime registrationDateField;
        
        private bool registrationDateFieldSpecified;
        
        private string reasonField;
        
        private string registrationDBTField;
        
        /// <summary>
        /// Действие (регистрация, прекратяване)
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        [System.ComponentModel.DescriptionAttribute("Действие (регистрация, прекратяване)")]
        public string Activity {
            get {
                return this.activityField;
            }
            set {
                this.activityField = value;
            }
        }
        
        /// <summary>
        /// Регистрационен номер
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
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
        /// Група на регистрация
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        [System.ComponentModel.DescriptionAttribute("Група на регистрация")]
        public string RegistrationGroup {
            get {
                return this.registrationGroupField;
            }
            set {
                this.registrationGroupField = value;
            }
        }
        
        /// <summary>
        /// Дата на регистрация
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date", Order=3)]
        [System.ComponentModel.DescriptionAttribute("Дата на регистрация")]
        public System.DateTime RegistrationDate {
            get {
                return this.registrationDateField;
            }
            set {
                this.registrationDateField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool RegistrationDateSpecified {
            get {
                return this.registrationDateFieldSpecified;
            }
            set {
                this.registrationDateFieldSpecified = value;
            }
        }
        
        /// <summary>
        /// Причина
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        [System.ComponentModel.DescriptionAttribute("Причина")]
        public string Reason {
            get {
                return this.reasonField;
            }
            set {
                this.reasonField = value;
            }
        }
        
        /// <summary>
        /// Дирекция Бюро по труда
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        [System.ComponentModel.DescriptionAttribute("Дирекция Бюро по труда")]
        public string RegistrationDBT {
            get {
                return this.registrationDBTField;
            }
            set {
                this.registrationDBTField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.20570")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://egov.bg/RegiX/AZ/JobSeekerHistoryRegistrationsResponse")]
    public partial class JobSeekerHistoryDataHistoryOfRegistrations {
        
        private List<RegistrationHistoryData> historyOfRegistrationField;
        
        /// <summary>
        /// JobSeekerHistoryDataHistoryOfRegistrations class constructor
        /// </summary>
        public JobSeekerHistoryDataHistoryOfRegistrations() {
            this.historyOfRegistrationField = new List<RegistrationHistoryData>();
        }
        
        [System.Xml.Serialization.XmlElementAttribute("HistoryOfRegistration", Order=0)]
        public List<RegistrationHistoryData> HistoryOfRegistration {
            get {
                return this.historyOfRegistrationField;
            }
            set {
                this.historyOfRegistrationField = value;
            }
        }
    }
}