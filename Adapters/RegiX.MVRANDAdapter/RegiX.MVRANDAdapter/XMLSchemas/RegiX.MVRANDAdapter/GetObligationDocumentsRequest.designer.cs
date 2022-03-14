// ------------------------------------------------------------------------------
//  <auto-generated>
//    Generated by Xsd2Code. Version 3.4.0.18727
//    <NameSpace>TechnoLogica.RegiX.MVRANDAdapter</NameSpace><Collection>List</Collection><codeType>CSharp</codeType><EnableDataBinding>False</EnableDataBinding><EnableLazyLoading>False</EnableLazyLoading><TrackingChangesEnable>False</TrackingChangesEnable><GenTrackingClasses>False</GenTrackingClasses><HidePrivateFieldInIDE>False</HidePrivateFieldInIDE><EnableSummaryComment>True</EnableSummaryComment><VirtualProp>False</VirtualProp><IncludeSerializeMethod>False</IncludeSerializeMethod><UseBaseClass>False</UseBaseClass><GenBaseClass>False</GenBaseClass><GenerateCloneMethod>False</GenerateCloneMethod><GenerateDataContracts>False</GenerateDataContracts><CodeBaseTag>Net40</CodeBaseTag><SerializeMethodName>Serialize</SerializeMethodName><DeserializeMethodName>Deserialize</DeserializeMethodName><SaveToFileMethodName>SaveToFile</SaveToFileMethodName><LoadFromFileMethodName>LoadFromFile</LoadFromFileMethodName><GenerateXMLAttributes>True</GenerateXMLAttributes><EnableEncoding>False</EnableEncoding><AutomaticProperties>False</AutomaticProperties><GenerateShouldSerialize>False</GenerateShouldSerialize><DisableDebug>False</DisableDebug><PropNameSpecified>Default</PropNameSpecified><Encoder>UTF8</Encoder><CustomUsings></CustomUsings><ExcludeIncludedTypes>False</ExcludeIncludedTypes><EnableInitializeFields>True</EnableInitializeFields>
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
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.25079")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/MVR/ObligationDocuments/GetObligationDocumentsRequest")]
    [System.Xml.Serialization.XmlRootAttribute("GetObligationDocumentsRequest", Namespace="http://egov.bg/RegiX/MVR/ObligationDocuments/GetObligationDocumentsRequest", IsNullable=false)]
    public partial class ObligationDocumentsRequestType {
        
        private DocumentType documentTypeField;
        
        private string documentSeriesField;
        
        private string documentNumberField;
        
        private double initialAmountField;
        
        /// <summary>
        /// Тип документ.
        /// Документ от тип АУАН, Фиш, НП
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        [System.ComponentModel.DescriptionAttribute("Тип документ.\nДокумент от тип АУАН, Фиш, НП")]
        public DocumentType documentType {
            get {
                return this.documentTypeField;
            }
            set {
                this.documentTypeField = value;
            }
        }
        
        /// <summary>
        /// Серия на документ.
        /// Задължително се посочва за документи от тип АУАН и фиш
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        [System.ComponentModel.DescriptionAttribute("Серия на документ.\nЗадължително се посочва за документи от тип АУАН и фиш")]
        public string documentSeries {
            get {
                return this.documentSeriesField;
            }
            set {
                this.documentSeriesField = value;
            }
        }
        
        /// <summary>
        /// Номер на документ.
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        [System.ComponentModel.DescriptionAttribute("Номер на документ.")]
        public string documentNumber {
            get {
                return this.documentNumberField;
            }
            set {
                this.documentNumberField = value;
            }
        }
        
        /// <summary>
        /// Сума за плащане.
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        [System.ComponentModel.DescriptionAttribute("Сума за плащане.")]
        public double initialAmount {
            get {
                return this.initialAmountField;
            }
            set {
                this.initialAmountField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.25079")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/MVR/ObligationDocuments/GetObligationDocumentsRequest")]
    public enum DocumentType {
        
        /// <remarks/>
        TICKET,
        
        /// <remarks/>
        ACT,
        
        /// <remarks/>
        PENAL_DECREE,
    }
}
