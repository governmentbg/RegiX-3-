// ------------------------------------------------------------------------------
//  <auto-generated>
//    Generated by Xsd2Code. Version 3.4.0.18727
//    <NameSpace>TechnoLogica.RegiX.MVRANDAdapter</NameSpace><Collection>List</Collection><codeType>CSharp</codeType><EnableDataBinding>False</EnableDataBinding><EnableLazyLoading>False</EnableLazyLoading><TrackingChangesEnable>False</TrackingChangesEnable><GenTrackingClasses>False</GenTrackingClasses><HidePrivateFieldInIDE>False</HidePrivateFieldInIDE><EnableSummaryComment>True</EnableSummaryComment><VirtualProp>False</VirtualProp><IncludeSerializeMethod>False</IncludeSerializeMethod><UseBaseClass>False</UseBaseClass><GenBaseClass>False</GenBaseClass><GenerateCloneMethod>False</GenerateCloneMethod><GenerateDataContracts>False</GenerateDataContracts><CodeBaseTag>Net40</CodeBaseTag><SerializeMethodName>Serialize</SerializeMethodName><DeserializeMethodName>Deserialize</DeserializeMethodName><SaveToFileMethodName>SaveToFile</SaveToFileMethodName><LoadFromFileMethodName>LoadFromFile</LoadFromFileMethodName><GenerateXMLAttributes>True</GenerateXMLAttributes><EnableEncoding>False</EnableEncoding><AutomaticProperties>False</AutomaticProperties><GenerateShouldSerialize>False</GenerateShouldSerialize><DisableDebug>False</DisableDebug><PropNameSpecified>Default</PropNameSpecified><Encoder>UTF8</Encoder><CustomUsings></CustomUsings><ExcludeIncludedTypes>True</ExcludeIncludedTypes><EnableInitializeFields>True</EnableInitializeFields>
//  </auto-generated>
// ------------------------------------------------------------------------------
namespace TechnoLogica.RegiX.MVRANDAdapter {
    using System;
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System.Collections;
    using System.Xml.Schema;
    using System.ComponentModel;
    using System.Collections.Generic;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.19538")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/MVR/ObligationDocumentsByLicenceNum/GetObligationDocumentsBy" +
        "LicenceNumRequest")]
    [System.Xml.Serialization.XmlRootAttribute("GetObligationDocumentsByLicenceNumRequest", Namespace="http://egov.bg/RegiX/MVR/ObligationDocumentsByLicenceNum/GetObligationDocumentsBy" +
        "LicenceNumRequest", IsNullable=false)]
    public partial class GetObligationDocumentsByLicenceNumRequestType {
        
        private string eGNField;
        
        private string licenceNumField;
        
        /// <summary>
        /// ЕГН на водач, за чиито документи ще бъде изведена информация
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        [System.ComponentModel.DescriptionAttribute("ЕГН на водач, за чиито документи ще бъде изведена информация")]
        public string EGN {
            get {
                return this.eGNField;
            }
            set {
                this.eGNField = value;
            }
        }
        
        /// <summary>
        /// Номер на СУМПС на водач
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        [System.ComponentModel.DescriptionAttribute("Номер на СУМПС на водач")]
        public string LicenceNum {
            get {
                return this.licenceNumField;
            }
            set {
                this.licenceNumField = value;
            }
        }
    }
}