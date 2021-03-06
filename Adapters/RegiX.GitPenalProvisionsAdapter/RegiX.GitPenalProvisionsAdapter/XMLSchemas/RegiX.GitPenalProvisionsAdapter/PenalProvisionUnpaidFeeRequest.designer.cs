// ------------------------------------------------------------------------------
//  <auto-generated>
//    Generated by Xsd2Code. Version 3.4.0.27043
//    <NameSpace>TechnoLogica.RegiX.GitPenalProvisionsAdapter</NameSpace><Collection>List</Collection><codeType>CSharp</codeType><EnableDataBinding>False</EnableDataBinding><EnableLazyLoading>False</EnableLazyLoading><TrackingChangesEnable>False</TrackingChangesEnable><GenTrackingClasses>False</GenTrackingClasses><HidePrivateFieldInIDE>False</HidePrivateFieldInIDE><EnableSummaryComment>True</EnableSummaryComment><VirtualProp>False</VirtualProp><IncludeSerializeMethod>False</IncludeSerializeMethod><UseBaseClass>False</UseBaseClass><GenBaseClass>False</GenBaseClass><GenerateCloneMethod>False</GenerateCloneMethod><GenerateDataContracts>False</GenerateDataContracts><CodeBaseTag>Net40</CodeBaseTag><SerializeMethodName>Serialize</SerializeMethodName><DeserializeMethodName>Deserialize</DeserializeMethodName><SaveToFileMethodName>SaveToFile</SaveToFileMethodName><LoadFromFileMethodName>LoadFromFile</LoadFromFileMethodName><GenerateXMLAttributes>True</GenerateXMLAttributes><EnableEncoding>False</EnableEncoding><AutomaticProperties>False</AutomaticProperties><GenerateShouldSerialize>False</GenerateShouldSerialize><DisableDebug>False</DisableDebug><PropNameSpecified>Default</PropNameSpecified><Encoder>UTF8</Encoder><CustomUsings></CustomUsings><ExcludeIncludedTypes>True</ExcludeIncludedTypes><EnableInitializeFields>True</EnableInitializeFields>
//  </auto-generated>
// ------------------------------------------------------------------------------
namespace TechnoLogica.RegiX.GitPenalProvisionsAdapter {
    using System;
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System.Collections;
    using System.Xml.Schema;
    using System.ComponentModel;
    using System.Collections.Generic;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.28623")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/GIT/RNP/PenalProvisionUnpaidFeeRequest")]
    [System.Xml.Serialization.XmlRootAttribute("PenalProvisionUnpaidFeeRequest", Namespace="http://egov.bg/RegiX/GIT/RNP/PenalProvisionUnpaidFeeRequest", IsNullable=false)]
    public partial class PenalProvisionUnpaidFeeType {
        
        private string intruderIdentifierField;
        
        private System.DateTime dateFromField;
        
        private System.DateTime dateToField;
        
        /// <summary>
        /// ?????? ?????? ?????????????? ???? ??????????????????
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        [System.ComponentModel.DescriptionAttribute("?????? ?????? ?????????????? ???? ??????????????????")]
        public string IntruderIdentifier {
            get {
                return this.intruderIdentifierField;
            }
            set {
                this.intruderIdentifierField = value;
            }
        }
        
        /// <summary>
        /// ?????????????? ???????? ???? ???????????? ???? ?????????????? ???? ????
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date", Order=1)]
        [System.ComponentModel.DescriptionAttribute("?????????????? ???????? ???? ???????????? ???? ?????????????? ???? ????")]
        public System.DateTime DateFrom {
            get {
                return this.dateFromField;
            }
            set {
                this.dateFromField = value;
            }
        }
        
        /// <summary>
        /// ???????????? ???????? ???? ???????????? ???? ?????????????? ???? ????
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date", Order=2)]
        [System.ComponentModel.DescriptionAttribute("???????????? ???????? ???? ???????????? ???? ?????????????? ???? ????")]
        public System.DateTime DateTo {
            get {
                return this.dateToField;
            }
            set {
                this.dateToField = value;
            }
        }
    }
}
