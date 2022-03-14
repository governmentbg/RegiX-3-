// ------------------------------------------------------------------------------
//  <auto-generated>
//    Generated by Xsd2Code. Version 3.4.0.19886
//    <NameSpace>TechnoLogica.RegiX.ChNTsAdapter</NameSpace><Collection>List</Collection><codeType>CSharp</codeType><EnableDataBinding>False</EnableDataBinding><EnableLazyLoading>False</EnableLazyLoading><TrackingChangesEnable>False</TrackingChangesEnable><GenTrackingClasses>False</GenTrackingClasses><HidePrivateFieldInIDE>False</HidePrivateFieldInIDE><EnableSummaryComment>True</EnableSummaryComment><VirtualProp>False</VirtualProp><IncludeSerializeMethod>False</IncludeSerializeMethod><UseBaseClass>False</UseBaseClass><GenBaseClass>False</GenBaseClass><GenerateCloneMethod>False</GenerateCloneMethod><GenerateDataContracts>False</GenerateDataContracts><CodeBaseTag>Net40</CodeBaseTag><SerializeMethodName>Serialize</SerializeMethodName><DeserializeMethodName>Deserialize</DeserializeMethodName><SaveToFileMethodName>SaveToFile</SaveToFileMethodName><LoadFromFileMethodName>LoadFromFile</LoadFromFileMethodName><GenerateXMLAttributes>True</GenerateXMLAttributes><EnableEncoding>False</EnableEncoding><AutomaticProperties>False</AutomaticProperties><GenerateShouldSerialize>False</GenerateShouldSerialize><DisableDebug>False</DisableDebug><PropNameSpecified>Default</PropNameSpecified><Encoder>UTF8</Encoder><CustomUsings></CustomUsings><ExcludeIncludedTypes>True</ExcludeIncludedTypes><EnableInitializeFields>True</EnableInitializeFields>
//  </auto-generated>
// ------------------------------------------------------------------------------
namespace TechnoLogica.RegiX.ChNTsAdapter {
    using System;
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System.Collections;
    using System.Xml.Schema;
    using System.ComponentModel;
    using System.Collections.Generic;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.19748")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/MP/ChNTs/ForeignerPermissionsResponse")]
    [System.Xml.Serialization.XmlRootAttribute("ForeignerPermissionsResponse", Namespace="http://egov.bg/RegiX/MP/ChNTs/ForeignerPermissionsResponse", IsNullable=false)]
    public partial class ForeignerPermissionsResponseType {
        
        private List<ForeignerPermissionData> permissionDataField;
        
        private System.DateTime searchDateField;
        
        private bool searchDateFieldSpecified;
        
        /// <summary>
        /// ForeignerPermissionsResponseType class constructor
        /// </summary>
        public ForeignerPermissionsResponseType() {
            this.permissionDataField = new List<ForeignerPermissionData>();
        }
        
        [System.Xml.Serialization.XmlElementAttribute("PermissionData", Order=0)]
        public List<ForeignerPermissionData> PermissionData {
            get {
                return this.permissionDataField;
            }
            set {
                this.permissionDataField = value;
            }
        }
        
        /// <summary>
        /// Дата, към която е извършена справката
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        [System.ComponentModel.DescriptionAttribute("Дата, към която е извършена справката")]
        public System.DateTime SearchDate {
            get {
                return this.searchDateField;
            }
            set {
                this.searchDateField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SearchDateSpecified {
            get {
                return this.searchDateFieldSpecified;
            }
            set {
                this.searchDateFieldSpecified = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.19748")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/MP/ChNTs/ForeignerPermissionsResponse")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://egov.bg/RegiX/MP/ChNTs/ForeignerPermissionsResponse", IsNullable=true)]
    public partial class ForeignerPermissionData {
        
        private string namesLatinField;
        
        private string namesCyrillicField;
        
        private string nationalityCodeField;
        
        private string nationalityNameField;
        
        private int statusCodeField;
        
        private bool statusCodeFieldSpecified;
        
        private string statusNameField;
        
        private Resolution resolutionField;
        
        private Permission permissionField;
        
        /// <summary>
        /// ForeignerPermissionData class constructor
        /// </summary>
        public ForeignerPermissionData() {
            this.permissionField = new Permission();
            this.resolutionField = new Resolution();
        }
        
        /// <summary>
        /// Имена на латиница
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        [System.ComponentModel.DescriptionAttribute("Имена на латиница")]
        public string NamesLatin {
            get {
                return this.namesLatinField;
            }
            set {
                this.namesLatinField = value;
            }
        }
        
        /// <summary>
        /// Имена на кирилица
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        [System.ComponentModel.DescriptionAttribute("Имена на кирилица")]
        public string NamesCyrillic {
            get {
                return this.namesCyrillicField;
            }
            set {
                this.namesCyrillicField = value;
            }
        }
        
        /// <summary>
        /// Националност - код на държава
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        [System.ComponentModel.DescriptionAttribute("Националност - код на държава")]
        public string NationalityCode {
            get {
                return this.nationalityCodeField;
            }
            set {
                this.nationalityCodeField = value;
            }
        }
        
        /// <summary>
        /// Националност - наименование на държава
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        [System.ComponentModel.DescriptionAttribute("Националност - наименование на държава")]
        public string NationalityName {
            get {
                return this.nationalityNameField;
            }
            set {
                this.nationalityNameField = value;
            }
        }
        
        /// <summary>
        /// Код на статус: 1 - Новосъздаден, 2 - Регистриран, 3 - Отказан
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        [System.ComponentModel.DescriptionAttribute("Код на статус: 1 - Новосъздаден, 2 - Регистриран, 3 - Отказан")]
        public int StatusCode {
            get {
                return this.statusCodeField;
            }
            set {
                this.statusCodeField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool StatusCodeSpecified {
            get {
                return this.statusCodeFieldSpecified;
            }
            set {
                this.statusCodeFieldSpecified = value;
            }
        }
        
        /// <summary>
        /// Наименование на статус
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        [System.ComponentModel.DescriptionAttribute("Наименование на статус")]
        public string StatusName {
            get {
                return this.statusNameField;
            }
            set {
                this.statusNameField = value;
            }
        }
        
        /// <summary>
        /// Решение за разрешение
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        [System.ComponentModel.DescriptionAttribute("Решение за разрешение")]
        public Resolution Resolution {
            get {
                return this.resolutionField;
            }
            set {
                this.resolutionField = value;
            }
        }
        
        /// <summary>
        /// Разрешение
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        [System.ComponentModel.DescriptionAttribute("Разрешение")]
        public Permission Permission {
            get {
                return this.permissionField;
            }
            set {
                this.permissionField = value;
            }
        }
    }
    
    /// <summary>
    /// Решение за разрешение
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.19748")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/MP/ChNTs/ForeignerPermissionsResponse")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://egov.bg/RegiX/MP/ChNTs/ForeignerPermissionsResponse", IsNullable=true)]
    [System.ComponentModel.DescriptionAttribute("Решение за разрешение")]
    public partial class Resolution {
        
        private string orderNumberField;
        
        private System.DateTime orderDateField;
        
        private bool orderDateFieldSpecified;
        
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string OrderNumber {
            get {
                return this.orderNumberField;
            }
            set {
                this.orderNumberField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public System.DateTime OrderDate {
            get {
                return this.orderDateField;
            }
            set {
                this.orderDateField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool OrderDateSpecified {
            get {
                return this.orderDateFieldSpecified;
            }
            set {
                this.orderDateFieldSpecified = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.19748")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/MP/ChNTs/ForeignerPermissionsResponse")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://egov.bg/RegiX/MP/ChNTs/ForeignerPermissionsResponse", IsNullable=true)]
    public partial class ActivityAddress {
        
        private string districtCodeField;
        
        private string districtNameField;
        
        private string municipalityCodeField;
        
        private string municipalityNameField;
        
        private string territorialUnitCodeField;
        
        private string territorialUnitNameField;
        
        private string addressDescriptionField;
        
        /// <summary>
        /// Код на област
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        [System.ComponentModel.DescriptionAttribute("Код на област")]
        public string DistrictCode {
            get {
                return this.districtCodeField;
            }
            set {
                this.districtCodeField = value;
            }
        }
        
        /// <summary>
        /// Наименование на област
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        [System.ComponentModel.DescriptionAttribute("Наименование на област")]
        public string DistrictName {
            get {
                return this.districtNameField;
            }
            set {
                this.districtNameField = value;
            }
        }
        
        /// <summary>
        /// Код на община
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        [System.ComponentModel.DescriptionAttribute("Код на община")]
        public string MunicipalityCode {
            get {
                return this.municipalityCodeField;
            }
            set {
                this.municipalityCodeField = value;
            }
        }
        
        /// <summary>
        /// Наименование на община
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        [System.ComponentModel.DescriptionAttribute("Наименование на община")]
        public string MunicipalityName {
            get {
                return this.municipalityNameField;
            }
            set {
                this.municipalityNameField = value;
            }
        }
        
        /// <summary>
        /// Код на населено място
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        [System.ComponentModel.DescriptionAttribute("Код на населено място")]
        public string TerritorialUnitCode {
            get {
                return this.territorialUnitCodeField;
            }
            set {
                this.territorialUnitCodeField = value;
            }
        }
        
        /// <summary>
        /// Наименование на населено място
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        [System.ComponentModel.DescriptionAttribute("Наименование на населено място")]
        public string TerritorialUnitName {
            get {
                return this.territorialUnitNameField;
            }
            set {
                this.territorialUnitNameField = value;
            }
        }
        
        /// <summary>
        /// Описание на адрес в рамките на населеното място на дейността
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        [System.ComponentModel.DescriptionAttribute("Описание на адрес в рамките на населеното място на дейността")]
        public string AddressDescription {
            get {
                return this.addressDescriptionField;
            }
            set {
                this.addressDescriptionField = value;
            }
        }
    }
    
    /// <summary>
    /// Разрешение
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.19748")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/MP/ChNTs/ForeignerPermissionsResponse")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://egov.bg/RegiX/MP/ChNTs/ForeignerPermissionsResponse", IsNullable=true)]
    [System.ComponentModel.DescriptionAttribute("Разрешение")]
    public partial class Permission {
        
        private System.DateTime dateFromField;
        
        private bool dateFromFieldSpecified;
        
        private System.DateTime dateToField;
        
        private bool dateToFieldSpecified;
        
        private string activityTypeField;
        
        private string nonprofitEntityNameField;
        
        private ActivityAddress addressField;
        
        /// <summary>
        /// Permission class constructor
        /// </summary>
        public Permission() {
            this.addressField = new ActivityAddress();
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public System.DateTime DateFrom {
            get {
                return this.dateFromField;
            }
            set {
                this.dateFromField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DateFromSpecified {
            get {
                return this.dateFromFieldSpecified;
            }
            set {
                this.dateFromFieldSpecified = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public System.DateTime DateTo {
            get {
                return this.dateToField;
            }
            set {
                this.dateToField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DateToSpecified {
            get {
                return this.dateToFieldSpecified;
            }
            set {
                this.dateToFieldSpecified = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string ActivityType {
            get {
                return this.activityTypeField;
            }
            set {
                this.activityTypeField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string NonprofitEntityName {
            get {
                return this.nonprofitEntityNameField;
            }
            set {
                this.nonprofitEntityNameField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public ActivityAddress Address {
            get {
                return this.addressField;
            }
            set {
                this.addressField = value;
            }
        }
    }
}
