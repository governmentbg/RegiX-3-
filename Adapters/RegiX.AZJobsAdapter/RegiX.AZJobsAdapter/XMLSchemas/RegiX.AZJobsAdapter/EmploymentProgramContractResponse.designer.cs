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
    /// Справка по ЕИК/БУЛСТАТ за сключен рамков договор с работодател по програма за заетост - резултат
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.20546")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://egov.bg/RegiX/AZ/EmploymentProgramContractResponse")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://egov.bg/RegiX/AZ/EmploymentProgramContractResponse", IsNullable=false)]
    [System.ComponentModel.DescriptionAttribute("Справка по ЕИК/БУЛСТАТ за сключен рамков договор с работодател по програма за зае" +
        "тост - резултат")]
    public partial class EmploymentProgramContractResponse {
        
        private EntityData employerDataField;
        
        private List<EmploymentProgramContract> employmentProgramContractsField;
        
        /// <summary>
        /// EmploymentProgramContractResponse class constructor
        /// </summary>
        public EmploymentProgramContractResponse() {
            this.employmentProgramContractsField = new List<EmploymentProgramContract>();
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
        public List<EmploymentProgramContract> EmploymentProgramContracts {
            get {
                return this.employmentProgramContractsField;
            }
            set {
                this.employmentProgramContractsField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.20546")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/AZ/EmploymentProgramContractResponse")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://egov.bg/RegiX/AZ/EmploymentProgramContractResponse", IsNullable=true)]
    public partial class EmploymentProgramContract {
        
        private string ContractNumberField;
        
        private string employmentProgramNameField;
        
        private System.DateTime contractDateField;
        
        private bool contractDateFieldSpecified;
        
        private string contractStatusField;
        
        /// <summary>
        /// Номер на договор
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        [System.ComponentModel.DescriptionAttribute("Номер на договор")]
        public string ContractNumber {
            get {
                return this.ContractNumberField;
            }
            set {
                this.ContractNumberField = value;
            }
        }
        
        /// <summary>
        /// Наименование на програма за заетост
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        [System.ComponentModel.DescriptionAttribute("Наименование на програма за заетост")]
        public string EmploymentProgramName {
            get {
                return this.employmentProgramNameField;
            }
            set {
                this.employmentProgramNameField = value;
            }
        }
        
        /// <summary>
        /// Дата на сключване
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date", Order=2)]
        [System.ComponentModel.DescriptionAttribute("Дата на сключване")]
        public System.DateTime ContractDate {
            get {
                return this.contractDateField;
            }
            set {
                this.contractDateField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ContractDateSpecified {
            get {
                return this.contractDateFieldSpecified;
            }
            set {
                this.contractDateFieldSpecified = value;
            }
        }
        
        /// <summary>
        /// Състояние на договор
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        [System.ComponentModel.DescriptionAttribute("Състояние на договор")]
        public string ContractStatus {
            get {
                return this.contractStatusField;
            }
            set {
                this.contractStatusField = value;
            }
        }
    }
}