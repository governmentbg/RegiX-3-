// ------------------------------------------------------------------------------
//  <auto-generated>
//    Generated by Xsd2Code. Version 3.4.0.24467
//    <NameSpace>TechnoLogica.RegiX.NoiROAdapter</NameSpace><Collection>List</Collection><codeType>CSharp</codeType><EnableDataBinding>False</EnableDataBinding><EnableLazyLoading>False</EnableLazyLoading><TrackingChangesEnable>False</TrackingChangesEnable><GenTrackingClasses>False</GenTrackingClasses><HidePrivateFieldInIDE>False</HidePrivateFieldInIDE><EnableSummaryComment>True</EnableSummaryComment><VirtualProp>False</VirtualProp><IncludeSerializeMethod>False</IncludeSerializeMethod><UseBaseClass>False</UseBaseClass><GenBaseClass>False</GenBaseClass><GenerateCloneMethod>False</GenerateCloneMethod><GenerateDataContracts>False</GenerateDataContracts><CodeBaseTag>Net40</CodeBaseTag><SerializeMethodName>Serialize</SerializeMethodName><DeserializeMethodName>Deserialize</DeserializeMethodName><SaveToFileMethodName>SaveToFile</SaveToFileMethodName><LoadFromFileMethodName>LoadFromFile</LoadFromFileMethodName><GenerateXMLAttributes>True</GenerateXMLAttributes><EnableEncoding>False</EnableEncoding><AutomaticProperties>False</AutomaticProperties><GenerateShouldSerialize>False</GenerateShouldSerialize><DisableDebug>False</DisableDebug><PropNameSpecified>Default</PropNameSpecified><Encoder>UTF8</Encoder><CustomUsings></CustomUsings><ExcludeIncludedTypes>True</ExcludeIncludedTypes><EnableInitializeFields>True</EnableInitializeFields>
//  </auto-generated>
// ------------------------------------------------------------------------------
namespace TechnoLogica.RegiX.NoiROAdapter {
    using System;
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System.Collections;
    using System.Xml.Schema;
    using System.ComponentModel;
    using System.Collections.Generic;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.20605")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/NOI/RO/POVNVEDResponse")]
    [System.Xml.Serialization.XmlRootAttribute("POVNVEDResponse", Namespace="http://egov.bg/RegiX/NOI/RO/POVNVEDResponse", IsNullable=false)]
    public partial class POVNVEDResponseType {
        
        private string identifierField;
        
        private IdentifierType identifierTypeField;
        
        private bool identifierTypeFieldSpecified;
        
        private string namesField;
        
        private List<PaymentWithDateType> paymentDataField;
        
        private string missingDataField;
        
        /// <summary>
        /// POVNVEDResponseType class constructor
        /// </summary>
        public POVNVEDResponseType() {
            this.paymentDataField = new List<PaymentWithDateType>();
        }
        
        /// <summary>
        /// ЕГН/ЛНЧ
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        [System.ComponentModel.DescriptionAttribute("ЕГН/ЛНЧ")]
        public string Identifier {
            get {
                return this.identifierField;
            }
            set {
                this.identifierField = value;
            }
        }
        
        /// <summary>
        /// Тип на идентификатор
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        [System.ComponentModel.DescriptionAttribute("Тип на идентификатор")]
        public IdentifierType IdentifierType {
            get {
                return this.identifierTypeField;
            }
            set {
                this.identifierTypeField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IdentifierTypeSpecified {
            get {
                return this.identifierTypeFieldSpecified;
            }
            set {
                this.identifierTypeFieldSpecified = value;
            }
        }
        
        /// <summary>
        /// Имена
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        [System.ComponentModel.DescriptionAttribute("Имена")]
        public string Names {
            get {
                return this.namesField;
            }
            set {
                this.namesField = value;
            }
        }
        
        [System.Xml.Serialization.XmlArrayAttribute(Order=3)]
        [System.Xml.Serialization.XmlArrayItemAttribute("Payment", Namespace="http://egov.bg/RegiX/NOI/RO", IsNullable=false)]
        public List<PaymentWithDateType> PaymentData {
            get {
                return this.paymentDataField;
            }
            set {
                this.paymentDataField = value;
            }
        }
        
        /// <summary>
        /// Празно - при наличие на данни за лицето. При липса на данни - "Липсват данни за изплатени обезщетения"
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        [System.ComponentModel.DescriptionAttribute("Празно - при наличие на данни за лицето. При липса на данни - \"Липсват данни за и" +
            "зплатени обезщетения\"")]
        public string MissingData {
            get {
                return this.missingDataField;
            }
            set {
                this.missingDataField = value;
            }
        }
    }
}
