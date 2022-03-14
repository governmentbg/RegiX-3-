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
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.20588")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/AZ/JobSeekerTrainingsResponse")]
    [System.Xml.Serialization.XmlRootAttribute("JobSeekerTrainingsResponse", Namespace="http://egov.bg/RegiX/AZ/JobSeekerTrainingsResponse", IsNullable=false)]
    public partial class JobSeekerTrainingsData {
        
        private PersonData jobSeekerPersonDataField;
        
        private JobSeekerTrainingsDataTrainings trainingsField;
        
        /// <summary>
        /// JobSeekerTrainingsData class constructor
        /// </summary>
        public JobSeekerTrainingsData() {
            this.trainingsField = new JobSeekerTrainingsDataTrainings();
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
        /// Обучения на търсещо работа лице
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        [System.ComponentModel.DescriptionAttribute("Обучения на търсещо работа лице")]
        public JobSeekerTrainingsDataTrainings Trainings {
            get {
                return this.trainingsField;
            }
            set {
                this.trainingsField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.20588")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/AZ/JobSeekerTrainingsResponse")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://egov.bg/RegiX/AZ/JobSeekerTrainingsResponse", IsNullable=true)]
    public partial class TrainingData {
        
        private string registrationNumberField;
        
        private string trainingTypeField;
        
        private string measureField;
        
        private string trainingNameField;
        
        private System.DateTime dateFromField;
        
        private bool dateFromFieldSpecified;
        
        private System.DateTime dateToField;
        
        private bool dateToFieldSpecified;
        
        private string resultField;
        
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
        /// Тип обучение
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        [System.ComponentModel.DescriptionAttribute("Тип обучение")]
        public string TrainingType {
            get {
                return this.trainingTypeField;
            }
            set {
                this.trainingTypeField = value;
            }
        }
        
        /// <summary>
        /// Мярка/програма/друго
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        [System.ComponentModel.DescriptionAttribute("Мярка/програма/друго")]
        public string Measure {
            get {
                return this.measureField;
            }
            set {
                this.measureField = value;
            }
        }
        
        /// <summary>
        /// Наименование на обучението
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        [System.ComponentModel.DescriptionAttribute("Наименование на обучението")]
        public string TrainingName {
            get {
                return this.trainingNameField;
            }
            set {
                this.trainingNameField = value;
            }
        }
        
        /// <summary>
        /// Начална дата на обучение
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date", Order=4)]
        [System.ComponentModel.DescriptionAttribute("Начална дата на обучение")]
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
        /// Крайна дата на обучение
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date", Order=5)]
        [System.ComponentModel.DescriptionAttribute("Крайна дата на обучение")]
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
        /// Резултат
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        [System.ComponentModel.DescriptionAttribute("Резултат")]
        public string Result {
            get {
                return this.resultField;
            }
            set {
                this.resultField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.20588")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://egov.bg/RegiX/AZ/JobSeekerTrainingsResponse")]
    public partial class JobSeekerTrainingsDataTrainings {
        
        private List<TrainingData> trainingField;
        
        /// <summary>
        /// JobSeekerTrainingsDataTrainings class constructor
        /// </summary>
        public JobSeekerTrainingsDataTrainings() {
            this.trainingField = new List<TrainingData>();
        }
        
        [System.Xml.Serialization.XmlElementAttribute("Training", Order=0)]
        public List<TrainingData> Training {
            get {
                return this.trainingField;
            }
            set {
                this.trainingField = value;
            }
        }
    }
}