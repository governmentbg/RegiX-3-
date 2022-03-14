// ------------------------------------------------------------------------------
//  <auto-generated>
//    Generated by Xsd2Code. Version 3.4.0.30983
//    <NameSpace>TechnoLogica.RegiX.IaosMROBatteriesAdapter</NameSpace><Collection>List</Collection><codeType>CSharp</codeType><EnableDataBinding>False</EnableDataBinding><EnableLazyLoading>False</EnableLazyLoading><TrackingChangesEnable>False</TrackingChangesEnable><GenTrackingClasses>False</GenTrackingClasses><HidePrivateFieldInIDE>False</HidePrivateFieldInIDE><EnableSummaryComment>True</EnableSummaryComment><VirtualProp>False</VirtualProp><IncludeSerializeMethod>False</IncludeSerializeMethod><UseBaseClass>False</UseBaseClass><GenBaseClass>False</GenBaseClass><GenerateCloneMethod>False</GenerateCloneMethod><GenerateDataContracts>False</GenerateDataContracts><CodeBaseTag>Net40</CodeBaseTag><SerializeMethodName>Serialize</SerializeMethodName><DeserializeMethodName>Deserialize</DeserializeMethodName><SaveToFileMethodName>SaveToFile</SaveToFileMethodName><LoadFromFileMethodName>LoadFromFile</LoadFromFileMethodName><GenerateXMLAttributes>True</GenerateXMLAttributes><EnableEncoding>False</EnableEncoding><AutomaticProperties>False</AutomaticProperties><GenerateShouldSerialize>False</GenerateShouldSerialize><DisableDebug>False</DisableDebug><PropNameSpecified>Default</PropNameSpecified><Encoder>UTF8</Encoder><CustomUsings></CustomUsings><ExcludeIncludedTypes>True</ExcludeIncludedTypes><EnableInitializeFields>True</EnableInitializeFields>
//  </auto-generated>
// ------------------------------------------------------------------------------
namespace TechnoLogica.RegiX.IaosMROBatteriesAdapter {
    using System;
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System.Collections;
    using System.Xml.Schema;
    using System.ComponentModel;
    using System.Collections.Generic;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.32356")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/IAOS/MROBatteries/CategoryResponse")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://egov.bg/RegiX/IAOS/MROBatteries/CategoryResponse", IsNullable=false)]
    public partial class MRO_BA_Category_Response {
        
        private AuthorizationCategory authorizationField;
        
        /// <summary>
        /// MRO_BA_Category_Response class constructor
        /// </summary>
        public MRO_BA_Category_Response() {
            this.authorizationField = new AuthorizationCategory();
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public AuthorizationCategory Authorization {
            get {
                return this.authorizationField;
            }
            set {
                this.authorizationField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.32356")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/IAOS/MROBatteries/CategoryResponse")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://egov.bg/RegiX/IAOS/MROBatteries/CategoryResponse", IsNullable=true)]
    public partial class AuthorizationCategory {
        
        private string authNumField;
        
        private string companyNameField;
        
        private AuthorizationCategoryBACategories bACategoriesField;
        
        /// <summary>
        /// AuthorizationCategory class constructor
        /// </summary>
        public AuthorizationCategory() {
            this.bACategoriesField = new AuthorizationCategoryBACategories();
        }
        
        /// <summary>
        /// Регистрационен номер
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        [System.ComponentModel.DescriptionAttribute("Регистрационен номер")]
        public string AuthNum {
            get {
                return this.authNumField;
            }
            set {
                this.authNumField = value;
            }
        }
        
        /// <summary>
        /// Наименование на организацията
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        [System.ComponentModel.DescriptionAttribute("Наименование на организацията")]
        public string CompanyName {
            get {
                return this.companyNameField;
            }
            set {
                this.companyNameField = value;
            }
        }
        
        /// <summary>
        /// Вид батерии и акумулатори
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        [System.ComponentModel.DescriptionAttribute("Вид батерии и акумулатори")]
        public AuthorizationCategoryBACategories BACategories {
            get {
                return this.bACategoriesField;
            }
            set {
                this.bACategoriesField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.32356")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://egov.bg/RegiX/IAOS/MROBatteries/CategoryResponse")]
    public partial class AuthorizationCategoryBACategories {
        
        private List<string> bACategoryField;
        
        /// <summary>
        /// AuthorizationCategoryBACategories class constructor
        /// </summary>
        public AuthorizationCategoryBACategories() {
            this.bACategoryField = new List<string>();
        }
        
        [System.Xml.Serialization.XmlElementAttribute("BACategory", Order=0)]
        public List<string> BACategory {
            get {
                return this.bACategoryField;
            }
            set {
                this.bACategoryField = value;
            }
        }
    }
}
