// ------------------------------------------------------------------------------
//  <auto-generated>
//    Generated by Xsd2Code. Version 3.4.0.25415
//    <NameSpace>TechnoLogica.RegiX.ASPSocialAdapter</NameSpace><Collection>List</Collection><codeType>CSharp</codeType><EnableDataBinding>False</EnableDataBinding><EnableLazyLoading>False</EnableLazyLoading><TrackingChangesEnable>False</TrackingChangesEnable><GenTrackingClasses>False</GenTrackingClasses><HidePrivateFieldInIDE>False</HidePrivateFieldInIDE><EnableSummaryComment>True</EnableSummaryComment><VirtualProp>False</VirtualProp><IncludeSerializeMethod>False</IncludeSerializeMethod><UseBaseClass>False</UseBaseClass><GenBaseClass>False</GenBaseClass><GenerateCloneMethod>False</GenerateCloneMethod><GenerateDataContracts>False</GenerateDataContracts><CodeBaseTag>Net40</CodeBaseTag><SerializeMethodName>Serialize</SerializeMethodName><DeserializeMethodName>Deserialize</DeserializeMethodName><SaveToFileMethodName>SaveToFile</SaveToFileMethodName><LoadFromFileMethodName>LoadFromFile</LoadFromFileMethodName><GenerateXMLAttributes>True</GenerateXMLAttributes><EnableEncoding>False</EnableEncoding><AutomaticProperties>False</AutomaticProperties><GenerateShouldSerialize>False</GenerateShouldSerialize><DisableDebug>False</DisableDebug><PropNameSpecified>Default</PropNameSpecified><Encoder>UTF8</Encoder><CustomUsings></CustomUsings><ExcludeIncludedTypes>True</ExcludeIncludedTypes><EnableInitializeFields>True</EnableInitializeFields>
//  </auto-generated>
// ------------------------------------------------------------------------------
namespace TechnoLogica.RegiX.ASPSocialAdapter {
    using System;
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System.Collections;
    using System.Xml.Schema;
    using System.ComponentModel;
    using System.Collections.Generic;
    
    
    /// <summary>
    /// Входни данни на справка по ЕГН/ЛНЧ за издадени заповеди за ползване на социални услуги
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.23777")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://egov.bg/RegiX/ASP/SocialServices/GetSocialServicesDecisionsRequest")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://egov.bg/RegiX/ASP/SocialServices/GetSocialServicesDecisionsRequest", IsNullable=false)]
    [System.ComponentModel.DescriptionAttribute("Входни данни на справка по ЕГН/ЛНЧ за издадени заповеди за ползване на социални у" +
        "слуги")]
    public partial class GetSocialServicesDecisionsRequest {
        
        private PersonRequestType personDataField;
        
        /// <summary>
        /// GetSocialServicesDecisionsRequest class constructor
        /// </summary>
        public GetSocialServicesDecisionsRequest() {
            this.personDataField = new PersonRequestType();
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public PersonRequestType PersonData {
            get {
                return this.personDataField;
            }
            set {
                this.personDataField = value;
            }
        }
    }
}
