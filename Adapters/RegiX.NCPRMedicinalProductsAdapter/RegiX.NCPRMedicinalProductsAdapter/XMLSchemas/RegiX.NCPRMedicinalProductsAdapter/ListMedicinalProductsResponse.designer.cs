// ------------------------------------------------------------------------------
//  <auto-generated>
//    Generated by Xsd2Code. Version 3.4.0.20336
//    <NameSpace>TechnoLogica.RegiX.NCPRMedicinalProductsAdapter</NameSpace><Collection>List</Collection><codeType>CSharp</codeType><EnableDataBinding>False</EnableDataBinding><EnableLazyLoading>False</EnableLazyLoading><TrackingChangesEnable>False</TrackingChangesEnable><GenTrackingClasses>False</GenTrackingClasses><HidePrivateFieldInIDE>False</HidePrivateFieldInIDE><EnableSummaryComment>True</EnableSummaryComment><VirtualProp>False</VirtualProp><IncludeSerializeMethod>False</IncludeSerializeMethod><UseBaseClass>False</UseBaseClass><GenBaseClass>False</GenBaseClass><GenerateCloneMethod>False</GenerateCloneMethod><GenerateDataContracts>False</GenerateDataContracts><CodeBaseTag>Net40</CodeBaseTag><SerializeMethodName>Serialize</SerializeMethodName><DeserializeMethodName>Deserialize</DeserializeMethodName><SaveToFileMethodName>SaveToFile</SaveToFileMethodName><LoadFromFileMethodName>LoadFromFile</LoadFromFileMethodName><GenerateXMLAttributes>True</GenerateXMLAttributes><EnableEncoding>False</EnableEncoding><AutomaticProperties>False</AutomaticProperties><GenerateShouldSerialize>False</GenerateShouldSerialize><DisableDebug>False</DisableDebug><PropNameSpecified>Default</PropNameSpecified><Encoder>UTF8</Encoder><CustomUsings></CustomUsings><ExcludeIncludedTypes>True</ExcludeIncludedTypes><EnableInitializeFields>True</EnableInitializeFields>
//  </auto-generated>
// ------------------------------------------------------------------------------
namespace TechnoLogica.RegiX.NCPRMedicinalProductsAdapter {
    using System;
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System.Collections;
    using System.Xml.Schema;
    using System.ComponentModel;
    using System.Collections.Generic;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.19424")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/NCPR/MedicinalProducts/ListMedicinalProductsResponse")]
    [System.Xml.Serialization.XmlRootAttribute("ListMedicinalProductsResponse", Namespace="http://egov.bg/RegiX/NCPR/MedicinalProducts/ListMedicinalProductsResponse", IsNullable=false)]
    public partial class ListMedicinalProductsResponseType {
        
        private int resultsCountField;
        
        private bool resultsCountFieldSpecified;
        
        private MedicinalProductsType medicinalProductsField;
        
        /// <summary>
        /// ListMedicinalProductsResponseType class constructor
        /// </summary>
        public ListMedicinalProductsResponseType() {
            this.medicinalProductsField = new MedicinalProductsType();
        }
        
        /// <summary>
        /// ?????? ???????? ????????????
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        [System.ComponentModel.DescriptionAttribute("?????? ???????? ????????????")]
        public int ResultsCount {
            get {
                return this.resultsCountField;
            }
            set {
                this.resultsCountField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ResultsCountSpecified {
            get {
                return this.resultsCountFieldSpecified;
            }
            set {
                this.resultsCountFieldSpecified = value;
            }
        }
        
        /// <summary>
        /// ???????????? ?? ?????????????????????? ????????????????
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        [System.ComponentModel.DescriptionAttribute("???????????? ?? ?????????????????????? ????????????????")]
        public MedicinalProductsType MedicinalProducts {
            get {
                return this.medicinalProductsField;
            }
            set {
                this.medicinalProductsField = value;
            }
        }
    }
}
