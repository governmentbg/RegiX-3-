// ------------------------------------------------------------------------------
//  <auto-generated>
//    Generated by Xsd2Code. Version 3.4.0.30983
//    <NameSpace>TechnoLogica.RegiX.IaosMROElectricityAdapter</NameSpace><Collection>List</Collection><codeType>CSharp</codeType><EnableDataBinding>False</EnableDataBinding><EnableLazyLoading>False</EnableLazyLoading><TrackingChangesEnable>False</TrackingChangesEnable><GenTrackingClasses>False</GenTrackingClasses><HidePrivateFieldInIDE>False</HidePrivateFieldInIDE><EnableSummaryComment>True</EnableSummaryComment><VirtualProp>False</VirtualProp><IncludeSerializeMethod>False</IncludeSerializeMethod><UseBaseClass>False</UseBaseClass><GenBaseClass>False</GenBaseClass><GenerateCloneMethod>False</GenerateCloneMethod><GenerateDataContracts>False</GenerateDataContracts><CodeBaseTag>Net40</CodeBaseTag><SerializeMethodName>Serialize</SerializeMethodName><DeserializeMethodName>Deserialize</DeserializeMethodName><SaveToFileMethodName>SaveToFile</SaveToFileMethodName><LoadFromFileMethodName>LoadFromFile</LoadFromFileMethodName><GenerateXMLAttributes>True</GenerateXMLAttributes><EnableEncoding>False</EnableEncoding><AutomaticProperties>False</AutomaticProperties><GenerateShouldSerialize>False</GenerateShouldSerialize><DisableDebug>False</DisableDebug><PropNameSpecified>Default</PropNameSpecified><Encoder>UTF8</Encoder><CustomUsings></CustomUsings><ExcludeIncludedTypes>True</ExcludeIncludedTypes><EnableInitializeFields>True</EnableInitializeFields>
//  </auto-generated>
// ------------------------------------------------------------------------------
namespace TechnoLogica.RegiX.IaosMROElectricityAdapter {
    using System;
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System.Collections;
    using System.Xml.Schema;
    using System.ComponentModel;
    using System.Collections.Generic;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.21970")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/IAOS/MROElectricity/EquipmentCategoryResponse")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://egov.bg/RegiX/IAOS/MROElectricity/EquipmentCategoryResponse", IsNullable=false)]
    public partial class MRO_EEO_Equipment_Category_Response {
        
        private Authorization authorizationField;
        
        /// <summary>
        /// MRO_EEO_Equipment_Category_Response class constructor
        /// </summary>
        public MRO_EEO_Equipment_Category_Response() {
            this.authorizationField = new Authorization();
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public Authorization Authorization {
            get {
                return this.authorizationField;
            }
            set {
                this.authorizationField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.21970")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/IAOS/MROElectricity/EquipmentCategoryResponse")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://egov.bg/RegiX/IAOS/MROElectricity/EquipmentCategoryResponse", IsNullable=true)]
    public partial class Authorization {
        
        private string authNumField;
        
        private string companyNameField;
        
        private AuthorizationEEOCategories eEOCategoriesField;
        
        /// <summary>
        /// Authorization class constructor
        /// </summary>
        public Authorization() {
            this.eEOCategoriesField = new AuthorizationEEOCategories();
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string AuthNum {
            get {
                return this.authNumField;
            }
            set {
                this.authNumField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string CompanyName {
            get {
                return this.companyNameField;
            }
            set {
                this.companyNameField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public AuthorizationEEOCategories EEOCategories {
            get {
                return this.eEOCategoriesField;
            }
            set {
                this.eEOCategoriesField = value;
            }
        }
    }
    
    /// <summary>
    /// Категории електрическо оборудване
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.21970")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://egov.bg/RegiX/IAOS/MROElectricity/EquipmentCategoryResponse")]
    [System.ComponentModel.DescriptionAttribute("Категории електрическо оборудване")]
    public partial class AuthorizationEEOCategories {
        
        private List<string> eEOCategoryField;
        
        /// <summary>
        /// AuthorizationEEOCategories class constructor
        /// </summary>
        public AuthorizationEEOCategories() {
            this.eEOCategoryField = new List<string>();
        }
        
        [System.Xml.Serialization.XmlElementAttribute("EEOCategory", Order=0)]
        public List<string> EEOCategory {
            get {
                return this.eEOCategoryField;
            }
            set {
                this.eEOCategoryField = value;
            }
        }
    }
}