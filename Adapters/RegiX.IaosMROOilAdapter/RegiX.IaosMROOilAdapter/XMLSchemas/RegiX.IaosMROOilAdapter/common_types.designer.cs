// ------------------------------------------------------------------------------
//  <auto-generated>
//    Generated by Xsd2Code. Version 3.4.0.30983
//    <NameSpace>TechnoLogica.RegiX.IaosMROOilAdapter</NameSpace><Collection>List</Collection><codeType>CSharp</codeType><EnableDataBinding>False</EnableDataBinding><EnableLazyLoading>False</EnableLazyLoading><TrackingChangesEnable>False</TrackingChangesEnable><GenTrackingClasses>False</GenTrackingClasses><HidePrivateFieldInIDE>False</HidePrivateFieldInIDE><EnableSummaryComment>True</EnableSummaryComment><VirtualProp>False</VirtualProp><IncludeSerializeMethod>False</IncludeSerializeMethod><UseBaseClass>False</UseBaseClass><GenBaseClass>False</GenBaseClass><GenerateCloneMethod>False</GenerateCloneMethod><GenerateDataContracts>False</GenerateDataContracts><CodeBaseTag>Net40</CodeBaseTag><SerializeMethodName>Serialize</SerializeMethodName><DeserializeMethodName>Deserialize</DeserializeMethodName><SaveToFileMethodName>SaveToFile</SaveToFileMethodName><LoadFromFileMethodName>LoadFromFile</LoadFromFileMethodName><GenerateXMLAttributes>True</GenerateXMLAttributes><EnableEncoding>False</EnableEncoding><AutomaticProperties>False</AutomaticProperties><GenerateShouldSerialize>False</GenerateShouldSerialize><DisableDebug>False</DisableDebug><PropNameSpecified>Default</PropNameSpecified><Encoder>UTF8</Encoder><CustomUsings></CustomUsings><ExcludeIncludedTypes>True</ExcludeIncludedTypes><EnableInitializeFields>True</EnableInitializeFields>
//  </auto-generated>
// ------------------------------------------------------------------------------
namespace TechnoLogica.RegiX.IaosMROOilAdapter {
    using System;
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System.Collections;
    using System.Xml.Schema;
    using System.ComponentModel;
    using System.Collections.Generic;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.22792")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/IAOS/MROOil/Common")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://egov.bg/RegiX/IAOS/MROOil/Common", IsNullable=false)]
    public enum Fulfilment {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("1")]
        Item1,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("2")]
        Item2,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("3")]
        Item3,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.22792")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/IAOS/MROOil/Common")]
    [System.Xml.Serialization.XmlRootAttribute("Authorization", Namespace="http://egov.bg/RegiX/IAOS/MROOil/Common", IsNullable=false)]
    public enum AuthorizationType {
        
        /// <remarks/>
        B,
        
        /// <remarks/>
        TB,
        
        /// <remarks/>
        T,
        
        /// <remarks/>
        РД,
        
        /// <remarks/>
        ДО,
        
        /// <remarks/>
        ОО,
        
        /// <remarks/>
        КР,
        
        /// <remarks/>
        ИНД,
        
        /// <remarks/>
        MRO,
        
        /// <remarks/>
        RAWMB,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.22792")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/IAOS/MROOil/Common")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://egov.bg/RegiX/IAOS/MROOil/Common", IsNullable=false)]
    public enum AuthState35 {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("00")]
        Item00,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("01")]
        Item01,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("02")]
        Item02,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("03")]
        Item03,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("04")]
        Item04,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("05")]
        Item05,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("06")]
        Item06,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("07")]
        Item07,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("08")]
        Item08,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("09")]
        Item09,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("10")]
        Item10,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("11")]
        Item11,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("12")]
        Item12,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("13")]
        Item13,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("14")]
        Item14,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("15")]
        Item15,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("16")]
        Item16,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.22792")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/IAOS/MROOil/Common")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://egov.bg/RegiX/IAOS/MROOil/Common", IsNullable=false)]
    public enum AuthState {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("00")]
        Item00,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("02")]
        Item02,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("03")]
        Item03,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("04")]
        Item04,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("05")]
        Item05,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("06")]
        Item06,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("07")]
        Item07,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("08")]
        Item08,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("09")]
        Item09,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("10")]
        Item10,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("11")]
        Item11,
    }
}