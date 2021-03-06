// ------------------------------------------------------------------------------
//  <auto-generated>
//    Generated by Xsd2Code. Version 3.4.0.24870
//    <NameSpace>TechnoLogica.RegiX.NHIFAdapter</NameSpace><Collection>List</Collection><codeType>CSharp</codeType><EnableDataBinding>False</EnableDataBinding><EnableLazyLoading>False</EnableLazyLoading><TrackingChangesEnable>False</TrackingChangesEnable><GenTrackingClasses>False</GenTrackingClasses><HidePrivateFieldInIDE>False</HidePrivateFieldInIDE><EnableSummaryComment>False</EnableSummaryComment><VirtualProp>False</VirtualProp><IncludeSerializeMethod>False</IncludeSerializeMethod><UseBaseClass>False</UseBaseClass><GenBaseClass>False</GenBaseClass><GenerateCloneMethod>False</GenerateCloneMethod><GenerateDataContracts>False</GenerateDataContracts><CodeBaseTag>Net20</CodeBaseTag><SerializeMethodName>Serialize</SerializeMethodName><DeserializeMethodName>Deserialize</DeserializeMethodName><SaveToFileMethodName>SaveToFile</SaveToFileMethodName><LoadFromFileMethodName>LoadFromFile</LoadFromFileMethodName><GenerateXMLAttributes>False</GenerateXMLAttributes><EnableEncoding>False</EnableEncoding><AutomaticProperties>False</AutomaticProperties><GenerateShouldSerialize>False</GenerateShouldSerialize><DisableDebug>False</DisableDebug><PropNameSpecified>Default</PropNameSpecified><Encoder>UTF8</Encoder><CustomUsings></CustomUsings><ExcludeIncludedTypes>True</ExcludeIncludedTypes><EnableInitializeFields>True</EnableInitializeFields>
//  </auto-generated>
// ------------------------------------------------------------------------------
namespace TechnoLogica.RegiX.NHIFAdapter {
    using System;
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System.Collections;
    using System.Xml.Schema;
    using System.ComponentModel;
    using System.Collections.Generic;
    
    
    public partial class PatientRecordHospitalizationsResponse {
        
        private List<PatientRecordHospitalizationType> patientRecordHospitalizationsField;
        
        public PatientRecordHospitalizationsResponse() {
            this.patientRecordHospitalizationsField = new List<PatientRecordHospitalizationType>();
        }
        
        [System.Xml.Serialization.XmlArrayAttribute(Order=0)]
        [System.Xml.Serialization.XmlArrayItemAttribute("PatientRecordHospitalization", IsNullable=false)]
        public List<PatientRecordHospitalizationType> PatientRecordHospitalizations {
            get {
                return this.patientRecordHospitalizationsField;
            }
            set {
                this.patientRecordHospitalizationsField = value;
            }
        }
    }
    
    public partial class PatientRecordHospitalizationType {
        
        private string patientIdentificatorField;
        
        private string branchNameField;
        
        private MSPTypeHosp mSPField;
        
        private ClinicalPathHosp clinicalPathField;
        
        private HospICDType iCDField;
        
        private string dateFromField;
        
        private string dateToField;
        
        private string bedDaysField;
        
        private string implantsInfoField;
        
        public PatientRecordHospitalizationType() {
            this.iCDField = new HospICDType();
            this.clinicalPathField = new ClinicalPathHosp();
            this.mSPField = new MSPTypeHosp();
        }
        
        public string PatientIdentificator {
            get {
                return this.patientIdentificatorField;
            }
            set {
                this.patientIdentificatorField = value;
            }
        }
        
        public string BranchName {
            get {
                return this.branchNameField;
            }
            set {
                this.branchNameField = value;
            }
        }
        
        public MSPTypeHosp MSP {
            get {
                return this.mSPField;
            }
            set {
                this.mSPField = value;
            }
        }
        
        public ClinicalPathHosp ClinicalPath {
            get {
                return this.clinicalPathField;
            }
            set {
                this.clinicalPathField = value;
            }
        }
        
        public HospICDType ICD {
            get {
                return this.iCDField;
            }
            set {
                this.iCDField = value;
            }
        }
        
        public string DateFrom {
            get {
                return this.dateFromField;
            }
            set {
                this.dateFromField = value;
            }
        }
        
        public string DateTo {
            get {
                return this.dateToField;
            }
            set {
                this.dateToField = value;
            }
        }
        
        public string BedDays {
            get {
                return this.bedDaysField;
            }
            set {
                this.bedDaysField = value;
            }
        }
        
        public string ImplantsInfo {
            get {
                return this.implantsInfoField;
            }
            set {
                this.implantsInfoField = value;
            }
        }
    }
    
    public partial class PatientRecordHospitalizationsType {
        
        private List<PatientRecordHospitalizationType> patientRecordHospitalizationField;
        
        public PatientRecordHospitalizationsType() {
            this.patientRecordHospitalizationField = new List<PatientRecordHospitalizationType>();
        }
        
        public List<PatientRecordHospitalizationType> PatientRecordHospitalization {
            get {
                return this.patientRecordHospitalizationField;
            }
            set {
                this.patientRecordHospitalizationField = value;
            }
        }
    }
}
