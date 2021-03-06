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
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.20552")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/AZ/JobSeekerContractsResponse")]
    [System.Xml.Serialization.XmlRootAttribute("JobSeekerContractsResponse", Namespace="http://egov.bg/RegiX/AZ/JobSeekerContractsResponse", IsNullable=false)]
    public partial class JobSeekerContractsData {
        
        private JobSeekerContractsDataJobSeekerPersonData jobSeekerPersonDataField;
        
        private JobSeekerContractsDataContracts contractsField;
        
        /// <summary>
        /// JobSeekerContractsData class constructor
        /// </summary>
        public JobSeekerContractsData() {
            this.contractsField = new JobSeekerContractsDataContracts();
            this.jobSeekerPersonDataField = new JobSeekerContractsDataJobSeekerPersonData();
        }
        
        /// <summary>
        /// ???????? ?????????? ???? ?????????????????? ????????, ???????????? ?? ?????????????????? ???? ?????????????????? ???????????? ????????
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        [System.ComponentModel.DescriptionAttribute("???????? ?????????? ???? ?????????????????? ????????, ???????????? ?? ?????????????????? ???? ?????????????????? ???????????? ????????")]
        public JobSeekerContractsDataJobSeekerPersonData JobSeekerPersonData {
            get {
                return this.jobSeekerPersonDataField;
            }
            set {
                this.jobSeekerPersonDataField = value;
            }
        }
        
        /// <summary>
        /// ???????????????? ???????????????? ?????????? ?????????????????? ???? ?????????????????? ?? ???????????????????? ????????
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        [System.ComponentModel.DescriptionAttribute("???????????????? ???????????????? ?????????? ?????????????????? ???? ?????????????????? ?? ???????????????????? ????????")]
        public JobSeekerContractsDataContracts Contracts {
            get {
                return this.contractsField;
            }
            set {
                this.contractsField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.20552")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://egov.bg/RegiX/AZ/JobSeekerContractsResponse")]
    public partial class JobSeekerContractsDataJobSeekerPersonData : PersonData {
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.20552")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/AZ/JobSeekerContractsResponse")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://egov.bg/RegiX/AZ/JobSeekerContractsResponse", IsNullable=true)]
    public partial class ContractData {
        
        private string contractNumberField;
        
        private string measureField;
        
        private string contractStatusField;
        
        /// <summary>
        /// ?????????? ???? ??????????????
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        [System.ComponentModel.DescriptionAttribute("?????????? ???? ??????????????")]
        public string ContractNumber {
            get {
                return this.contractNumberField;
            }
            set {
                this.contractNumberField = value;
            }
        }
        
        /// <summary>
        /// ??????????/????????????????/??????????
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        [System.ComponentModel.DescriptionAttribute("??????????/????????????????/??????????")]
        public string Measure {
            get {
                return this.measureField;
            }
            set {
                this.measureField = value;
            }
        }
        
        /// <summary>
        /// ???????????? ???? ????????????????
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        [System.ComponentModel.DescriptionAttribute("???????????? ???? ????????????????")]
        public string ContractStatus {
            get {
                return this.contractStatusField;
            }
            set {
                this.contractStatusField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.20552")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://egov.bg/RegiX/AZ/JobSeekerContractsResponse")]
    public partial class JobSeekerContractsDataContracts {
        
        private List<ContractData> contractField;
        
        /// <summary>
        /// JobSeekerContractsDataContracts class constructor
        /// </summary>
        public JobSeekerContractsDataContracts() {
            this.contractField = new List<ContractData>();
        }
        
        [System.Xml.Serialization.XmlElementAttribute("Contract", Order=0)]
        public List<ContractData> Contract {
            get {
                return this.contractField;
            }
            set {
                this.contractField = value;
            }
        }
    }
}
