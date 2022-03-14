// ------------------------------------------------------------------------------
//  <auto-generated>
//    Generated by Xsd2Code. Version 3.4.0.25716
//    <NameSpace>TechnoLogica.RegiX.PropertyRegAdapter</NameSpace><Collection>List</Collection><codeType>CSharp</codeType><EnableDataBinding>False</EnableDataBinding><EnableLazyLoading>False</EnableLazyLoading><TrackingChangesEnable>False</TrackingChangesEnable><GenTrackingClasses>False</GenTrackingClasses><HidePrivateFieldInIDE>False</HidePrivateFieldInIDE><EnableSummaryComment>True</EnableSummaryComment><VirtualProp>False</VirtualProp><IncludeSerializeMethod>False</IncludeSerializeMethod><UseBaseClass>False</UseBaseClass><GenBaseClass>False</GenBaseClass><GenerateCloneMethod>False</GenerateCloneMethod><GenerateDataContracts>False</GenerateDataContracts><CodeBaseTag>Net40</CodeBaseTag><SerializeMethodName>Serialize</SerializeMethodName><DeserializeMethodName>Deserialize</DeserializeMethodName><SaveToFileMethodName>SaveToFile</SaveToFileMethodName><LoadFromFileMethodName>LoadFromFile</LoadFromFileMethodName><GenerateXMLAttributes>True</GenerateXMLAttributes><EnableEncoding>False</EnableEncoding><AutomaticProperties>False</AutomaticProperties><GenerateShouldSerialize>False</GenerateShouldSerialize><DisableDebug>False</DisableDebug><PropNameSpecified>Default</PropNameSpecified><Encoder>UTF8</Encoder><CustomUsings></CustomUsings><ExcludeIncludedTypes>True</ExcludeIncludedTypes><EnableInitializeFields>True</EnableInitializeFields>
//  </auto-generated>
// ------------------------------------------------------------------------------
namespace TechnoLogica.RegiX.PropertyRegAdapter {
    using System;
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System.Collections;
    using System.Xml.Schema;
    using System.ComponentModel;
    using System.Collections.Generic;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.21840")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/AV/PropertyReg/PropertySearchRequest")]
    [System.Xml.Serialization.XmlRootAttribute("PropertySearchRequest", Namespace="http://egov.bg/RegiX/AV/PropertyReg/PropertySearchRequest", IsNullable=false)]
    public partial class PropertySearchRequestType {
        
        private string propertyLotField;
        
        private string oldPropertyLotField;
        
        private string cadastreNumberField;
        
        private string secondCadastreNumberField;
        
        private string siteIDField;
        
        private string housingEstateField;
        
        private string neighborhoodNameField;
        
        private string streetNameField;
        
        private string streetNumberField;
        
        private string blockField;
        
        private string entranceField;
        
        private string floorField;
        
        private string appartmentField;
        
        private string postBoxField;
        
        /// <summary>
        /// Номер на имотна партида
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        [System.ComponentModel.DescriptionAttribute("Номер на имотна партида")]
        public string PropertyLot {
            get {
                return this.propertyLotField;
            }
            set {
                this.propertyLotField = value;
            }
        }
        
        /// <summary>
        /// Стара имотна партида
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        [System.ComponentModel.DescriptionAttribute("Стара имотна партида")]
        public string OldPropertyLot {
            get {
                return this.oldPropertyLotField;
            }
            set {
                this.oldPropertyLotField = value;
            }
        }
        
        /// <summary>
        /// Кадастрален идентификатор
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        [System.ComponentModel.DescriptionAttribute("Кадастрален идентификатор")]
        public string CadastreNumber {
            get {
                return this.cadastreNumberField;
            }
            set {
                this.cadastreNumberField = value;
            }
        }
        
        /// <summary>
        /// Втори кадастрален идентификатор
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        [System.ComponentModel.DescriptionAttribute("Втори кадастрален идентификатор")]
        public string SecondCadastreNumber {
            get {
                return this.secondCadastreNumberField;
            }
            set {
                this.secondCadastreNumberField = value;
            }
        }
        
        /// <summary>
        /// Идентификатор на служба по вписвания
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        [System.ComponentModel.DescriptionAttribute("Идентификатор на служба по вписвания")]
        public string SiteID {
            get {
                return this.siteIDField;
            }
            set {
                this.siteIDField = value;
            }
        }
        
        /// <summary>
        /// Жилищен комплекс
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        [System.ComponentModel.DescriptionAttribute("Жилищен комплекс")]
        public string HousingEstate {
            get {
                return this.housingEstateField;
            }
            set {
                this.housingEstateField = value;
            }
        }
        
        /// <summary>
        /// Квартал
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        [System.ComponentModel.DescriptionAttribute("Квартал")]
        public string NeighborhoodName {
            get {
                return this.neighborhoodNameField;
            }
            set {
                this.neighborhoodNameField = value;
            }
        }
        
        /// <summary>
        /// Улица
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        [System.ComponentModel.DescriptionAttribute("Улица")]
        public string StreetName {
            get {
                return this.streetNameField;
            }
            set {
                this.streetNameField = value;
            }
        }
        
        /// <summary>
        /// Номер на улица
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        [System.ComponentModel.DescriptionAttribute("Номер на улица")]
        public string StreetNumber {
            get {
                return this.streetNumberField;
            }
            set {
                this.streetNumberField = value;
            }
        }
        
        /// <summary>
        /// Блок
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        [System.ComponentModel.DescriptionAttribute("Блок")]
        public string Block {
            get {
                return this.blockField;
            }
            set {
                this.blockField = value;
            }
        }
        
        /// <summary>
        /// Вход
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
        [System.ComponentModel.DescriptionAttribute("Вход")]
        public string Entrance {
            get {
                return this.entranceField;
            }
            set {
                this.entranceField = value;
            }
        }
        
        /// <summary>
        /// Етаж
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=11)]
        [System.ComponentModel.DescriptionAttribute("Етаж")]
        public string Floor {
            get {
                return this.floorField;
            }
            set {
                this.floorField = value;
            }
        }
        
        /// <summary>
        /// Апартамент
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=12)]
        [System.ComponentModel.DescriptionAttribute("Апартамент")]
        public string Appartment {
            get {
                return this.appartmentField;
            }
            set {
                this.appartmentField = value;
            }
        }
        
        /// <summary>
        /// Пощенска кутия
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=13)]
        [System.ComponentModel.DescriptionAttribute("Пощенска кутия")]
        public string PostBox {
            get {
                return this.postBoxField;
            }
            set {
                this.postBoxField = value;
            }
        }
    }
}