// ------------------------------------------------------------------------------
//  <auto-generated>
//    Generated by Xsd2Code. Version 3.4.0.19886
//    <NameSpace>TechnoLogica.RegiX.KzldAdministratorsAdapter</NameSpace><Collection>List</Collection><codeType>CSharp</codeType><EnableDataBinding>False</EnableDataBinding><EnableLazyLoading>False</EnableLazyLoading><TrackingChangesEnable>False</TrackingChangesEnable><GenTrackingClasses>False</GenTrackingClasses><HidePrivateFieldInIDE>False</HidePrivateFieldInIDE><EnableSummaryComment>True</EnableSummaryComment><VirtualProp>False</VirtualProp><IncludeSerializeMethod>False</IncludeSerializeMethod><UseBaseClass>False</UseBaseClass><GenBaseClass>False</GenBaseClass><GenerateCloneMethod>False</GenerateCloneMethod><GenerateDataContracts>False</GenerateDataContracts><CodeBaseTag>Net40</CodeBaseTag><SerializeMethodName>Serialize</SerializeMethodName><DeserializeMethodName>Deserialize</DeserializeMethodName><SaveToFileMethodName>SaveToFile</SaveToFileMethodName><LoadFromFileMethodName>LoadFromFile</LoadFromFileMethodName><GenerateXMLAttributes>True</GenerateXMLAttributes><EnableEncoding>False</EnableEncoding><AutomaticProperties>False</AutomaticProperties><GenerateShouldSerialize>False</GenerateShouldSerialize><DisableDebug>False</DisableDebug><PropNameSpecified>Default</PropNameSpecified><Encoder>UTF8</Encoder><CustomUsings></CustomUsings><ExcludeIncludedTypes>True</ExcludeIncludedTypes><EnableInitializeFields>True</EnableInitializeFields>
//  </auto-generated>
// ------------------------------------------------------------------------------
namespace TechnoLogica.RegiX.KzldAdministratorsAdapter {
    using System;
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System.Collections;
    using System.Xml.Schema;
    using System.ComponentModel;
    using System.Collections.Generic;
    
    
    /// <summary>
    /// Справка по ЕИК/БУЛСТАТ/ЕГН за вписан администратор на лични данни - резултат
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.24841")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://egov.bg/RegiX/KZLD/Administrators/RegisteredAdministratorByIDResponse")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://egov.bg/RegiX/KZLD/Administrators/RegisteredAdministratorByIDResponse", IsNullable=false)]
    [System.ComponentModel.DescriptionAttribute("Справка по ЕИК/БУЛСТАТ/ЕГН за вписан администратор на лични данни - резултат")]
    public partial class RegisteredAdministratorByIDResponse {
        
        private PersonalDataControllerData pDCDataField;
        
        private List<PersonalDataControllerRegister> pDSRegistersField;
        
        /// <summary>
        /// RegisteredAdministratorByIDResponse class constructor
        /// </summary>
        public RegisteredAdministratorByIDResponse() {
            this.pDSRegistersField = new List<PersonalDataControllerRegister>();
            this.pDCDataField = new PersonalDataControllerData();
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public PersonalDataControllerData PDCData {
            get {
                return this.pDCDataField;
            }
            set {
                this.pDCDataField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute("PDSRegisters", Order=1)]
        public List<PersonalDataControllerRegister> PDSRegisters {
            get {
                return this.pDSRegistersField;
            }
            set {
                this.pDSRegistersField = value;
            }
        }
    }
}
