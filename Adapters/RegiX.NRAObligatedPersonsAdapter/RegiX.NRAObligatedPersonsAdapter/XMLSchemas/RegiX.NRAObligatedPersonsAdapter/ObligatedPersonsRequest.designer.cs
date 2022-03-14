// ------------------------------------------------------------------------------
//  <auto-generated>
//    Generated by Xsd2Code. Version 3.4.0.33404
//    <NameSpace>TechnoLogica.RegiX.NRAObligatedPersonsAdapter</NameSpace><Collection>List</Collection><codeType>CSharp</codeType><EnableDataBinding>False</EnableDataBinding><EnableLazyLoading>False</EnableLazyLoading><TrackingChangesEnable>False</TrackingChangesEnable><GenTrackingClasses>False</GenTrackingClasses><HidePrivateFieldInIDE>False</HidePrivateFieldInIDE><EnableSummaryComment>True</EnableSummaryComment><VirtualProp>False</VirtualProp><IncludeSerializeMethod>False</IncludeSerializeMethod><UseBaseClass>False</UseBaseClass><GenBaseClass>False</GenBaseClass><GenerateCloneMethod>False</GenerateCloneMethod><GenerateDataContracts>False</GenerateDataContracts><CodeBaseTag>Net40</CodeBaseTag><SerializeMethodName>Serialize</SerializeMethodName><DeserializeMethodName>Deserialize</DeserializeMethodName><SaveToFileMethodName>SaveToFile</SaveToFileMethodName><LoadFromFileMethodName>LoadFromFile</LoadFromFileMethodName><GenerateXMLAttributes>True</GenerateXMLAttributes><EnableEncoding>False</EnableEncoding><AutomaticProperties>False</AutomaticProperties><GenerateShouldSerialize>False</GenerateShouldSerialize><DisableDebug>False</DisableDebug><PropNameSpecified>Default</PropNameSpecified><Encoder>UTF8</Encoder><CustomUsings></CustomUsings><ExcludeIncludedTypes>True</ExcludeIncludedTypes><EnableInitializeFields>True</EnableInitializeFields>
//  </auto-generated>
// ------------------------------------------------------------------------------
namespace TechnoLogica.RegiX.NRAObligatedPersonsAdapter {
    using System;
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System.Collections;
    using System.Xml.Schema;
    using System.ComponentModel;
    using System.Collections.Generic;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.29515")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/NRA/Obligations/Request")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://egov.bg/RegiX/NRA/Obligations/Request", IsNullable=false)]
    public partial class ObligationRequest {
        
        private IdentityTypeRequest identityField;
        
        private ushort thresholdField;
        
        private bool thresholdFieldSpecified;
        
        /// <summary>
        /// ObligationRequest class constructor
        /// </summary>
        public ObligationRequest() {
            this.identityField = new IdentityTypeRequest();
        }
        
        /// <summary>
        /// Идентификатор
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        [System.ComponentModel.DescriptionAttribute("Идентификатор")]
        public IdentityTypeRequest Identity {
            get {
                return this.identityField;
            }
            set {
                this.identityField = value;
            }
        }
        
        /// <summary>
        /// Праг (справката връща задължения, ако са по-големи от полето праг)
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        [System.ComponentModel.DescriptionAttribute("Праг (справката връща задължения, ако са по-големи от полето праг)")]
        public ushort Threshold {
            get {
                return this.thresholdField;
            }
            set {
                this.thresholdField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ThresholdSpecified {
            get {
                return this.thresholdFieldSpecified;
            }
            set {
                this.thresholdFieldSpecified = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.29515")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/NRA/Obligations/Request")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://egov.bg/RegiX/NRA/Obligations/Request", IsNullable=true)]
    public partial class IdentityTypeRequest {
        
        private string idField;
        
        private EikTypeTypeRequest tYPEField;
        
        /// <summary>
        /// Идентификатор(с дължина от 6 до 16 символа)
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        [System.ComponentModel.DescriptionAttribute("Идентификатор(с дължина от 6 до 16 символа)")]
        public string ID {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
        
        /// <summary>
        /// Вид на идентификатора
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        [System.ComponentModel.DescriptionAttribute("Вид на идентификатора")]
        public EikTypeTypeRequest TYPE {
            get {
                return this.tYPEField;
            }
            set {
                this.tYPEField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.29515")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/NRA/Obligations/Request")]
    public enum EikTypeTypeRequest {
        
        /// <remarks/>
        Bulstat,
        
        /// <remarks/>
        EGN,
        
        /// <remarks/>
        LNC,
        
        /// <remarks/>
        SystemNo,
        
        /// <remarks/>
        BulstatCL,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.29515")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/NRA/Obligations/Request")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://egov.bg/RegiX/NRA/Obligations/Request", IsNullable=true)]
    public partial class StatusTypeRequest {
        
        private int codeField;
        
        private bool codeFieldSpecified;
        
        private string messageField;
        
        /// <summary>
        /// 0 - OK
        /// 2 - invalid EIK
        /// 99 - other
        /// 
        /// XML Validation error are returned as plain text with status 400 BadRequest
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        [System.ComponentModel.DescriptionAttribute("0 - OK\n            2 - invalid EIK\n            99 - other\n\n            XML Valida" +
            "tion error are returned as plain text with status 400 BadRequest")]
        public int Code {
            get {
                return this.codeField;
            }
            set {
                this.codeField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CodeSpecified {
            get {
                return this.codeFieldSpecified;
            }
            set {
                this.codeFieldSpecified = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string Message {
            get {
                return this.messageField;
            }
            set {
                this.messageField = value;
            }
        }
    }
}
