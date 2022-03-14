// ------------------------------------------------------------------------------
//  <auto-generated>
//    Generated by Xsd2Code. Version 3.4.0.19886
//    <NameSpace>TechnoLogica.RegiX.KzldDeniedAdministratorsAdapter</NameSpace><Collection>List</Collection><codeType>CSharp</codeType><EnableDataBinding>False</EnableDataBinding><EnableLazyLoading>False</EnableLazyLoading><TrackingChangesEnable>False</TrackingChangesEnable><GenTrackingClasses>False</GenTrackingClasses><HidePrivateFieldInIDE>False</HidePrivateFieldInIDE><EnableSummaryComment>True</EnableSummaryComment><VirtualProp>False</VirtualProp><IncludeSerializeMethod>False</IncludeSerializeMethod><UseBaseClass>False</UseBaseClass><GenBaseClass>False</GenBaseClass><GenerateCloneMethod>False</GenerateCloneMethod><GenerateDataContracts>False</GenerateDataContracts><CodeBaseTag>Net40</CodeBaseTag><SerializeMethodName>Serialize</SerializeMethodName><DeserializeMethodName>Deserialize</DeserializeMethodName><SaveToFileMethodName>SaveToFile</SaveToFileMethodName><LoadFromFileMethodName>LoadFromFile</LoadFromFileMethodName><GenerateXMLAttributes>True</GenerateXMLAttributes><EnableEncoding>False</EnableEncoding><AutomaticProperties>False</AutomaticProperties><GenerateShouldSerialize>False</GenerateShouldSerialize><DisableDebug>False</DisableDebug><PropNameSpecified>Default</PropNameSpecified><Encoder>UTF8</Encoder><CustomUsings></CustomUsings><ExcludeIncludedTypes>True</ExcludeIncludedTypes><EnableInitializeFields>True</EnableInitializeFields>
//  </auto-generated>
// ------------------------------------------------------------------------------
namespace TechnoLogica.RegiX.KzldDeniedAdministratorsAdapter {
    using System;
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System.Collections;
    using System.Xml.Schema;
    using System.ComponentModel;
    using System.Collections.Generic;
    
    
    /// <summary>
    /// Справка по ЕИК/БУЛСТАТ/ЕГН/ЛНЧ за освободен от регистрация  администратор на лични данни - резултат
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.26647")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://egov.bg/RegiX/KZLD/DeniedAdministrators/DeniedEntryAdministratorResponse")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://egov.bg/RegiX/KZLD/DeniedAdministrators/DeniedEntryAdministratorResponse", IsNullable=false)]
    [System.ComponentModel.DescriptionAttribute("Справка по ЕИК/БУЛСТАТ/ЕГН/ЛНЧ за освободен от регистрация  администратор на личн" +
        "и данни - резултат")]
    public partial class DeniedEntryAdministratorResponse {
        
        private PersonalDataControllerData pDCDeniedEntryDataField;
        
        /// <summary>
        /// DeniedEntryAdministratorResponse class constructor
        /// </summary>
        public DeniedEntryAdministratorResponse() {
            this.pDCDeniedEntryDataField = new PersonalDataControllerData();
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public PersonalDataControllerData PDCDeniedEntryData {
            get {
                return this.pDCDeniedEntryDataField;
            }
            set {
                this.pDCDeniedEntryDataField = value;
            }
        }
    }
}