// ------------------------------------------------------------------------------
//  <auto-generated>
//    Generated by Xsd2Code. Version 3.4.0.18600
//    <NameSpace>TechnoLogica.RegiX.MtTouristRegisterAdapter</NameSpace><Collection>List</Collection><codeType>CSharp</codeType><EnableDataBinding>False</EnableDataBinding><EnableLazyLoading>False</EnableLazyLoading><TrackingChangesEnable>False</TrackingChangesEnable><GenTrackingClasses>False</GenTrackingClasses><HidePrivateFieldInIDE>False</HidePrivateFieldInIDE><EnableSummaryComment>True</EnableSummaryComment><VirtualProp>False</VirtualProp><IncludeSerializeMethod>False</IncludeSerializeMethod><UseBaseClass>False</UseBaseClass><GenBaseClass>False</GenBaseClass><GenerateCloneMethod>False</GenerateCloneMethod><GenerateDataContracts>False</GenerateDataContracts><CodeBaseTag>Net40</CodeBaseTag><SerializeMethodName>Serialize</SerializeMethodName><DeserializeMethodName>Deserialize</DeserializeMethodName><SaveToFileMethodName>SaveToFile</SaveToFileMethodName><LoadFromFileMethodName>LoadFromFile</LoadFromFileMethodName><GenerateXMLAttributes>True</GenerateXMLAttributes><EnableEncoding>False</EnableEncoding><AutomaticProperties>False</AutomaticProperties><GenerateShouldSerialize>False</GenerateShouldSerialize><DisableDebug>False</DisableDebug><PropNameSpecified>Default</PropNameSpecified><Encoder>UTF8</Encoder><CustomUsings></CustomUsings><ExcludeIncludedTypes>True</ExcludeIncludedTypes><EnableInitializeFields>True</EnableInitializeFields>
//  </auto-generated>
// ------------------------------------------------------------------------------
namespace TechnoLogica.RegiX.MtTouristRegisterAdapter {
    using System;
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System.Collections;
    using System.Xml.Schema;
    using System.ComponentModel;
    using System.Collections.Generic;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.15869")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/MT/TOTAByEIKResponse")]
    [System.Xml.Serialization.XmlRootAttribute("TOTAByEIKResponse", Namespace="http://egov.bg/RegiX/MT/TOTAByEIKResponse", IsNullable=false)]
    public partial class Tota {
        
        private string eIKField;
        
        private string companyNameField;
        
        private System.Nullable<TypeEnum> tourOperationTypeField;
        
        private bool tourOperationTypeFieldSpecified;
        
        private RegistrationType registrationField;
        
        private List<OrderType> orderChangesField;
        
        private OrderType licenseCancellationOrderField;
        
        private LicenseType licenseField;
        
        private List<Office> officesField;
        
        /// <summary>
        /// Tota class constructor
        /// </summary>
        public Tota() {
            this.officesField = new List<Office>();
            this.licenseField = new LicenseType();
            this.licenseCancellationOrderField = new OrderType();
            this.orderChangesField = new List<OrderType>();
            this.registrationField = new RegistrationType();
        }
        
        /// <summary>
        /// Единен идентификационен код (ЕИК)
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        [System.ComponentModel.DescriptionAttribute("Единен идентификационен код (ЕИК)")]
        public string EIK {
            get {
                return this.eIKField;
            }
            set {
                this.eIKField = value;
            }
        }
        
        /// <summary>
        /// Наименование на юридическото лице
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        [System.ComponentModel.DescriptionAttribute("Наименование на юридическото лице")]
        public string CompanyName {
            get {
                return this.companyNameField;
            }
            set {
                this.companyNameField = value;
            }
        }
        
        /// <summary>
        /// Вид туристическа дейност(туроператор;туристически агент;и двете.)
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=2)]
        [System.ComponentModel.DescriptionAttribute("Вид туристическа дейност(туроператор;туристически агент;и двете.)")]
        public System.Nullable<TypeEnum> TourOperationType {
            get {
                return this.tourOperationTypeField;
            }
            set {
                this.tourOperationTypeField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TourOperationTypeSpecified {
            get {
                return this.tourOperationTypeFieldSpecified;
            }
            set {
                this.tourOperationTypeFieldSpecified = value;
            }
        }
        
        /// <summary>
        /// Регистрация
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=3)]
        [System.ComponentModel.DescriptionAttribute("Регистрация")]
        public RegistrationType Registration {
            get {
                return this.registrationField;
            }
            set {
                this.registrationField = value;
            }
        }
        
        /// <summary>
        /// Заповеди за промяна
        /// </summary>
        [System.Xml.Serialization.XmlArrayAttribute(Order=4)]
        [System.Xml.Serialization.XmlArrayItemAttribute("OrderChange")]
        [System.ComponentModel.DescriptionAttribute("Заповеди за промяна")]
        public List<OrderType> OrderChanges {
            get {
                return this.orderChangesField;
            }
            set {
                this.orderChangesField = value;
            }
        }
        
        /// <summary>
        /// Заповед за прекратяване на дейността
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=5)]
        [System.ComponentModel.DescriptionAttribute("Заповед за прекратяване на дейността")]
        public OrderType LicenseCancellationOrder {
            get {
                return this.licenseCancellationOrderField;
            }
            set {
                this.licenseCancellationOrderField = value;
            }
        }
        
        /// <summary>
        /// Лиценз
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=6)]
        [System.ComponentModel.DescriptionAttribute("Лиценз")]
        public LicenseType License {
            get {
                return this.licenseField;
            }
            set {
                this.licenseField = value;
            }
        }
        
        /// <summary>
        /// Данни за офиси
        /// </summary>
        [System.Xml.Serialization.XmlArrayAttribute(Order=7)]
        [System.ComponentModel.DescriptionAttribute("Данни за офиси")]
        public List<Office> Offices {
            get {
                return this.officesField;
            }
            set {
                this.officesField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.15869")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/MT/TOTAByEIKResponse")]
    public enum TypeEnum {
        
        /// <remarks/>
        TO,
        
        /// <remarks/>
        TA,
        
        /// <remarks/>
        TOTA,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.15869")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/MT/TOTAByEIKResponse")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://egov.bg/RegiX/MT/TOTAByEIKResponse", IsNullable=true)]
    public partial class RegistrationType {
        
        private string regNumField;
        
        private System.Nullable<System.DateTime> dateIssuedField;
        
        private bool dateIssuedFieldSpecified;
        
        private OrderType orderField;
        
        /// <summary>
        /// RegistrationType class constructor
        /// </summary>
        public RegistrationType() {
            this.orderField = new OrderType();
        }
        
        /// <summary>
        /// Регистрационен номер
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        [System.ComponentModel.DescriptionAttribute("Регистрационен номер")]
        public string RegNum {
            get {
                return this.regNumField;
            }
            set {
                this.regNumField = value;
            }
        }
        
        /// <summary>
        /// Дата на издаване
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date", IsNullable=true, Order=1)]
        [System.ComponentModel.DescriptionAttribute("Дата на издаване")]
        public System.Nullable<System.DateTime> DateIssued {
            get {
                return this.dateIssuedField;
            }
            set {
                this.dateIssuedField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DateIssuedSpecified {
            get {
                return this.dateIssuedFieldSpecified;
            }
            set {
                this.dateIssuedFieldSpecified = value;
            }
        }
        
        /// <summary>
        /// Заповед за регистрация
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=2)]
        [System.ComponentModel.DescriptionAttribute("Заповед за регистрация")]
        public OrderType Order {
            get {
                return this.orderField;
            }
            set {
                this.orderField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.15869")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/MT/TOTAByEIKResponse")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://egov.bg/RegiX/MT/TOTAByEIKResponse", IsNullable=true)]
    public partial class OrderType {
        
        private string numberField;
        
        private System.Nullable<System.DateTime> dateField;
        
        private bool dateFieldSpecified;
        
        /// <summary>
        /// Номер на заповед
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        [System.ComponentModel.DescriptionAttribute("Номер на заповед")]
        public string Number {
            get {
                return this.numberField;
            }
            set {
                this.numberField = value;
            }
        }
        
        /// <summary>
        /// Дата на заповед
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date", IsNullable=true, Order=1)]
        [System.ComponentModel.DescriptionAttribute("Дата на заповед")]
        public System.Nullable<System.DateTime> Date {
            get {
                return this.dateField;
            }
            set {
                this.dateField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DateSpecified {
            get {
                return this.dateFieldSpecified;
            }
            set {
                this.dateFieldSpecified = value;
            }
        }
    }
    
    /// <summary>
    /// Офис
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.15869")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/MT/TOTAByEIKResponse")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://egov.bg/RegiX/MT/TOTAByEIKResponse", IsNullable=true)]
    [System.ComponentModel.DescriptionAttribute("Офис")]
    public partial class Office {
        
        private string officePopNameField;
        
        private string officeAddressField;
        
        private string officePhoneField;
        
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string OfficePopName {
            get {
                return this.officePopNameField;
            }
            set {
                this.officePopNameField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string OfficeAddress {
            get {
                return this.officeAddressField;
            }
            set {
                this.officeAddressField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string OfficePhone {
            get {
                return this.officePhoneField;
            }
            set {
                this.officePhoneField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.15869")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/MT/TOTAByEIKResponse")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://egov.bg/RegiX/MT/TOTAByEIKResponse", IsNullable=true)]
    public partial class LicenseType {
        
        private string licenseIssuedOrderNumField;
        
        private System.Nullable<System.DateTime> licenseIssuedOrderDateField;
        
        private bool licenseIssuedOrderDateFieldSpecified;
        
        private OrderType orderField;
        
        /// <summary>
        /// LicenseType class constructor
        /// </summary>
        public LicenseType() {
            this.orderField = new OrderType();
        }
        
        /// <summary>
        /// Номер на заповед за издаване на лиценз
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        [System.ComponentModel.DescriptionAttribute("Номер на заповед за издаване на лиценз")]
        public string LicenseIssuedOrderNum {
            get {
                return this.licenseIssuedOrderNumField;
            }
            set {
                this.licenseIssuedOrderNumField = value;
            }
        }
        
        /// <summary>
        /// Дата на заповед за издаване на лиценз
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date", IsNullable=true, Order=1)]
        [System.ComponentModel.DescriptionAttribute("Дата на заповед за издаване на лиценз")]
        public System.Nullable<System.DateTime> LicenseIssuedOrderDate {
            get {
                return this.licenseIssuedOrderDateField;
            }
            set {
                this.licenseIssuedOrderDateField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool LicenseIssuedOrderDateSpecified {
            get {
                return this.licenseIssuedOrderDateFieldSpecified;
            }
            set {
                this.licenseIssuedOrderDateFieldSpecified = value;
            }
        }
        
        /// <summary>
        /// Заповед
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=2)]
        [System.ComponentModel.DescriptionAttribute("Заповед")]
        public OrderType Order {
            get {
                return this.orderField;
            }
            set {
                this.orderField = value;
            }
        }
    }
}
