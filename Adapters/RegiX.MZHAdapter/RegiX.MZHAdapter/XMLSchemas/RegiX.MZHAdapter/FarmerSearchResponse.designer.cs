// ------------------------------------------------------------------------------
//  <auto-generated>
//    Generated by Xsd2Code. Version 3.4.0.24467
//    <NameSpace>TechnoLogica.RegiX.MZHAdapter</NameSpace><Collection>List</Collection><codeType>CSharp</codeType><EnableDataBinding>False</EnableDataBinding><EnableLazyLoading>False</EnableLazyLoading><TrackingChangesEnable>False</TrackingChangesEnable><GenTrackingClasses>False</GenTrackingClasses><HidePrivateFieldInIDE>False</HidePrivateFieldInIDE><EnableSummaryComment>True</EnableSummaryComment><VirtualProp>False</VirtualProp><IncludeSerializeMethod>False</IncludeSerializeMethod><UseBaseClass>False</UseBaseClass><GenBaseClass>False</GenBaseClass><GenerateCloneMethod>False</GenerateCloneMethod><GenerateDataContracts>False</GenerateDataContracts><CodeBaseTag>Net40</CodeBaseTag><SerializeMethodName>Serialize</SerializeMethodName><DeserializeMethodName>Deserialize</DeserializeMethodName><SaveToFileMethodName>SaveToFile</SaveToFileMethodName><LoadFromFileMethodName>LoadFromFile</LoadFromFileMethodName><GenerateXMLAttributes>True</GenerateXMLAttributes><EnableEncoding>False</EnableEncoding><AutomaticProperties>False</AutomaticProperties><GenerateShouldSerialize>False</GenerateShouldSerialize><DisableDebug>False</DisableDebug><PropNameSpecified>Default</PropNameSpecified><Encoder>UTF8</Encoder><CustomUsings></CustomUsings><ExcludeIncludedTypes>True</ExcludeIncludedTypes><EnableInitializeFields>True</EnableInitializeFields>
//  </auto-generated>
// ------------------------------------------------------------------------------
namespace TechnoLogica.RegiX.MZHAdapter {
    using System;
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System.Collections;
    using System.Xml.Schema;
    using System.ComponentModel;
    using System.Collections.Generic;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.23362")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/MZH/FarmerSearchResponse")]
    [System.Xml.Serialization.XmlRootAttribute("Farmer", Namespace="http://egov.bg/RegiX/MZH/FarmerSearchResponse", IsNullable=false)]
    public partial class FarmerType {
        
        private AdministrativeDataType administrativeDataField;
        
        private List<LandType> landsField;
        
        private List<CropType> cropsField;
        
        private List<AnimalType> animalsField;
        
        /// <summary>
        /// FarmerType class constructor
        /// </summary>
        public FarmerType() {
            this.animalsField = new List<AnimalType>();
            this.cropsField = new List<CropType>();
            this.landsField = new List<LandType>();
            this.administrativeDataField = new AdministrativeDataType();
        }
        
        /// <summary>
        /// ?????????????????????????????? ??????????
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        [System.ComponentModel.DescriptionAttribute("?????????????????????????????? ??????????")]
        public AdministrativeDataType AdministrativeData {
            get {
                return this.administrativeDataField;
            }
            set {
                this.administrativeDataField = value;
            }
        }
        
        /// <summary>
        /// ???????????????????? ????????
        /// </summary>
        [System.Xml.Serialization.XmlArrayAttribute(Order=1)]
        [System.Xml.Serialization.XmlArrayItemAttribute("Land", Namespace="http://egov.bg/RegiX/MZH", IsNullable=false)]
        [System.ComponentModel.DescriptionAttribute("???????????????????? ????????")]
        public List<LandType> Lands {
            get {
                return this.landsField;
            }
            set {
                this.landsField = value;
            }
        }
        
        /// <summary>
        /// ???????????????????? ??????????????
        /// </summary>
        [System.Xml.Serialization.XmlArrayAttribute(Order=2)]
        [System.Xml.Serialization.XmlArrayItemAttribute("Crop", Namespace="http://egov.bg/RegiX/MZH", IsNullable=false)]
        [System.ComponentModel.DescriptionAttribute("???????????????????? ??????????????")]
        public List<CropType> Crops {
            get {
                return this.cropsField;
            }
            set {
                this.cropsField = value;
            }
        }
        
        /// <summary>
        /// ???????????????????? ??????????????
        /// </summary>
        [System.Xml.Serialization.XmlArrayAttribute(Order=3)]
        [System.Xml.Serialization.XmlArrayItemAttribute("Animal", Namespace="http://egov.bg/RegiX/MZH", IsNullable=false)]
        [System.ComponentModel.DescriptionAttribute("???????????????????? ??????????????")]
        public List<AnimalType> Animals {
            get {
                return this.animalsField;
            }
            set {
                this.animalsField = value;
            }
        }
    }
}
