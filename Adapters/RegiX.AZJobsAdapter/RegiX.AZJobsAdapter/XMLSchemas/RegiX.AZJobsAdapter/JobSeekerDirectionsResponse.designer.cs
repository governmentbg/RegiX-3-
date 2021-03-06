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
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.20562")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/AZ/JobSeekerDirectionsResponse")]
    [System.Xml.Serialization.XmlRootAttribute("JobSeekerDirectionsResponse", Namespace="http://egov.bg/RegiX/AZ/JobSeekerDirectionsResponse", IsNullable=false)]
    public partial class JobSeekerDirectionsData {
        
        private JobSeekerDirectionsDataDirections directionsField;
        
        private PersonData jobSeekerPersonDataField;
        
        /// <summary>
        /// JobSeekerDirectionsData class constructor
        /// </summary>
        public JobSeekerDirectionsData() {
            this.jobSeekerPersonDataField = new PersonData();
            this.directionsField = new JobSeekerDirectionsDataDirections();
        }
        
        /// <summary>
        /// ???????????????????? ???? ?????????????? ???????????? ????????
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        [System.ComponentModel.DescriptionAttribute("???????????????????? ???? ?????????????? ???????????? ????????")]
        public JobSeekerDirectionsDataDirections Directions {
            get {
                return this.directionsField;
            }
            set {
                this.directionsField = value;
            }
        }
        
        /// <summary>
        /// ???????? ?????????? ???? ?????????????????? ????????, ???????????? ?? ?????????????????? ???? ?????????????????? ???????????? ????????
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        [System.ComponentModel.DescriptionAttribute("???????? ?????????? ???? ?????????????????? ????????, ???????????? ?? ?????????????????? ???? ?????????????????? ???????????? ????????")]
        public PersonData JobSeekerPersonData {
            get {
                return this.jobSeekerPersonDataField;
            }
            set {
                this.jobSeekerPersonDataField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.20562")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://egov.bg/RegiX/AZ/JobSeekerDirectionsResponse")]
    public partial class JobSeekerDirectionsDataDirections {
        
        private List<DirectionData> directionField;
        
        /// <summary>
        /// JobSeekerDirectionsDataDirections class constructor
        /// </summary>
        public JobSeekerDirectionsDataDirections() {
            this.directionField = new List<DirectionData>();
        }
        
        [System.Xml.Serialization.XmlElementAttribute("Direction", Order=0)]
        public List<DirectionData> Direction {
            get {
                return this.directionField;
            }
            set {
                this.directionField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.20562")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/AZ/JobSeekerDirectionsResponse")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://egov.bg/RegiX/AZ/JobSeekerDirectionsResponse", IsNullable=true)]
    public partial class DirectionData {
        
        private string registrationNumberField;
        
        private string freeWorkPlaceField;
        
        private string employerField;
        
        private string jobPositionField;
        
        private string stateField;
        
        private System.DateTime resultDateField;
        
        private bool resultDateFieldSpecified;
        
        /// <summary>
        /// ???????????????????????????? ??????????
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        [System.ComponentModel.DescriptionAttribute("???????????????????????????? ??????????")]
        public string RegistrationNumber {
            get {
                return this.registrationNumberField;
            }
            set {
                this.registrationNumberField = value;
            }
        }
        
        /// <summary>
        /// ???????????????? ?????????????? ?????????? (??????????)
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        [System.ComponentModel.DescriptionAttribute("???????????????? ?????????????? ?????????? (??????????)")]
        public string FreeWorkPlace {
            get {
                return this.freeWorkPlaceField;
            }
            set {
                this.freeWorkPlaceField = value;
            }
        }
        
        /// <summary>
        /// ??????????????????????
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        [System.ComponentModel.DescriptionAttribute("??????????????????????")]
        public string Employer {
            get {
                return this.employerField;
            }
            set {
                this.employerField = value;
            }
        }
        
        /// <summary>
        /// ????????????????
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        [System.ComponentModel.DescriptionAttribute("????????????????")]
        public string JobPosition {
            get {
                return this.jobPositionField;
            }
            set {
                this.jobPositionField = value;
            }
        }
        
        /// <summary>
        /// ??????????????????
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        [System.ComponentModel.DescriptionAttribute("??????????????????")]
        public string State {
            get {
                return this.stateField;
            }
            set {
                this.stateField = value;
            }
        }
        
        /// <summary>
        /// ???????? ???? ????????????????
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date", Order=5)]
        [System.ComponentModel.DescriptionAttribute("???????? ???? ????????????????")]
        public System.DateTime ResultDate {
            get {
                return this.resultDateField;
            }
            set {
                this.resultDateField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ResultDateSpecified {
            get {
                return this.resultDateFieldSpecified;
            }
            set {
                this.resultDateFieldSpecified = value;
            }
        }
    }
}
