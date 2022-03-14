// ------------------------------------------------------------------------------
//  <auto-generated>
//    Generated by Xsd2Code. Version 3.4.0.30367
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
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.30375")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute("PeopleWithDisabilitiesResponse", Namespace="", IsNullable=false)]
    public partial class PeopleWithDisabilitiesResponseType {
        
        private HeaderType headerField;
        
        private DataType dataField;
        
        /// <summary>
        /// PeopleWithDisabilitiesResponseType class constructor
        /// </summary>
        public PeopleWithDisabilitiesResponseType() {
            this.dataField = new DataType();
            this.headerField = new HeaderType();
        }
        
        /// <summary>
        /// Заглавна част на отговора
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        [System.ComponentModel.DescriptionAttribute("Заглавна част на отговора")]
        public HeaderType Header {
            get {
                return this.headerField;
            }
            set {
                this.headerField = value;
            }
        }
        
        /// <summary>
        /// Детайли на отговора
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        [System.ComponentModel.DescriptionAttribute("Детайли на отговора")]
        public DataType Data {
            get {
                return this.dataField;
            }
            set {
                this.dataField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.30375")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=true)]
    public partial class HeaderType {
        
        private int requestNumberField;
        
        private bool requestNumberFieldSpecified;
        
        private int sizeField;
        
        private bool sizeFieldSpecified;
        
        private System.DateTime paymentMonthField;
        
        private bool paymentMonthFieldSpecified;
        
        private string personNameField;
        
        /// <summary>
        /// Номер на запитването в АСП
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        [System.ComponentModel.DescriptionAttribute("Номер на запитването в АСП")]
        public int RequestNumber {
            get {
                return this.requestNumberField;
            }
            set {
                this.requestNumberField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool RequestNumberSpecified {
            get {
                return this.requestNumberFieldSpecified;
            }
            set {
                this.requestNumberFieldSpecified = value;
            }
        }
        
        /// <summary>
        /// Общ брой редове в отговора
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        [System.ComponentModel.DescriptionAttribute("Общ брой редове в отговора")]
        public int Size {
            get {
                return this.sizeField;
            }
            set {
                this.sizeField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SizeSpecified {
            get {
                return this.sizeFieldSpecified;
            }
            set {
                this.sizeFieldSpecified = value;
            }
        }
        
        /// <summary>
        /// Месец, в който сумата е включена във ведомост (1-во число на месеца)
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date", Order=2)]
        [System.ComponentModel.DescriptionAttribute("Месец, в който сумата е включена във ведомост (1-во число на месеца)")]
        public System.DateTime PaymentMonth {
            get {
                return this.paymentMonthField;
            }
            set {
                this.paymentMonthField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PaymentMonthSpecified {
            get {
                return this.paymentMonthFieldSpecified;
            }
            set {
                this.paymentMonthFieldSpecified = value;
            }
        }
        
        /// <summary>
        /// Име на лицето с увреждания
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        [System.ComponentModel.DescriptionAttribute("Име на лицето с увреждания")]
        public string PersonName {
            get {
                return this.personNameField;
            }
            set {
                this.personNameField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.30375")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=true)]
    public partial class ErrorType {
        
        private string errorCodeField;
        
        private string errorTextField;
        
        /// <summary>
        /// Код на грешката
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        [System.ComponentModel.DescriptionAttribute("Код на грешката")]
        public string ErrorCode {
            get {
                return this.errorCodeField;
            }
            set {
                this.errorCodeField = value;
            }
        }
        
        /// <summary>
        /// Вид на социалната услуга
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        [System.ComponentModel.DescriptionAttribute("Вид на социалната услуга")]
        public string ErrorText {
            get {
                return this.errorTextField;
            }
            set {
                this.errorTextField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.30375")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=true)]
    public partial class SocialServicesType {
        
        private int rowField;
        
        private bool rowFieldSpecified;
        
        private string typeField;
        
        private string orderNoField;
        
        private System.DateTime orderDateField;
        
        private bool orderDateFieldSpecified;
        
        /// <summary>
        /// Номер на ред
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        [System.ComponentModel.DescriptionAttribute("Номер на ред")]
        public int Row {
            get {
                return this.rowField;
            }
            set {
                this.rowField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool RowSpecified {
            get {
                return this.rowFieldSpecified;
            }
            set {
                this.rowFieldSpecified = value;
            }
        }
        
        /// <summary>
        /// Вид на социалната услуга
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        [System.ComponentModel.DescriptionAttribute("Вид на социалната услуга")]
        public string Type {
            get {
                return this.typeField;
            }
            set {
                this.typeField = value;
            }
        }
        
        /// <summary>
        /// № на заповед
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        [System.ComponentModel.DescriptionAttribute("№ на заповед")]
        public string OrderNo {
            get {
                return this.orderNoField;
            }
            set {
                this.orderNoField = value;
            }
        }
        
        /// <summary>
        /// Дата на заповед
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date", Order=3)]
        [System.ComponentModel.DescriptionAttribute("Дата на заповед")]
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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.30375")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=true)]
    public partial class BDZType {
        
        private System.DateTime endDateField;
        
        private bool endDateFieldSpecified;
        
        /// <summary>
        /// Срок на издадено удостоверение за пътуване с БДЖ
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date", Order=0)]
        [System.ComponentModel.DescriptionAttribute("Срок на издадено удостоверение за пътуване с БДЖ")]
        public System.DateTime EndDate {
            get {
                return this.endDateField;
            }
            set {
                this.endDateField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EndDateSpecified {
            get {
                return this.endDateFieldSpecified;
            }
            set {
                this.endDateFieldSpecified = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.30375")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=true)]
    public partial class VignetteType {
        
        private System.DateTime endDateField;
        
        private bool endDateFieldSpecified;
        
        /// <summary>
        /// Срок на предоставен винетен стикер
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date", Order=0)]
        [System.ComponentModel.DescriptionAttribute("Срок на предоставен винетен стикер")]
        public System.DateTime EndDate {
            get {
                return this.endDateField;
            }
            set {
                this.endDateField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EndDateSpecified {
            get {
                return this.endDateFieldSpecified;
            }
            set {
                this.endDateFieldSpecified = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.30375")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=true)]
    public partial class АuxType {
        
        private int rowField;
        
        private bool rowFieldSpecified;
        
        private string pSNameField;
        
        private System.DateTime endDateField;
        
        private bool endDateFieldSpecified;
        
        /// <summary>
        /// Номер на ред
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        [System.ComponentModel.DescriptionAttribute("Номер на ред")]
        public int Row {
            get {
                return this.rowField;
            }
            set {
                this.rowField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool RowSpecified {
            get {
                return this.rowFieldSpecified;
            }
            set {
                this.rowFieldSpecified = value;
            }
        }
        
        /// <summary>
        /// Вид на ПСПСМИ
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        [System.ComponentModel.DescriptionAttribute("Вид на ПСПСМИ")]
        public string PSName {
            get {
                return this.pSNameField;
            }
            set {
                this.pSNameField = value;
            }
        }
        
        /// <summary>
        /// Експлоатационен срок изтича на
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date", Order=2)]
        [System.ComponentModel.DescriptionAttribute("Експлоатационен срок изтича на")]
        public System.DateTime EndDate {
            get {
                return this.endDateField;
            }
            set {
                this.endDateField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EndDateSpecified {
            get {
                return this.endDateFieldSpecified;
            }
            set {
                this.endDateFieldSpecified = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.30375")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=true)]
    public partial class OtherType {
        
        private int rowField;
        
        private bool rowFieldSpecified;
        
        private string groundNameField;
        
        private decimal amountField;
        
        private bool amountFieldSpecified;
        
        /// <summary>
        /// Номер на ред
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        [System.ComponentModel.DescriptionAttribute("Номер на ред")]
        public int Row {
            get {
                return this.rowField;
            }
            set {
                this.rowField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool RowSpecified {
            get {
                return this.rowFieldSpecified;
            }
            set {
                this.rowFieldSpecified = value;
            }
        }
        
        /// <summary>
        /// Вид на отпуснатата помощ
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        [System.ComponentModel.DescriptionAttribute("Вид на отпуснатата помощ")]
        public string GroundName {
            get {
                return this.groundNameField;
            }
            set {
                this.groundNameField = value;
            }
        }
        
        /// <summary>
        /// Размер на отпуснатата сума за месеца в поле 3 на заглавната част
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        [System.ComponentModel.DescriptionAttribute("Размер на отпуснатата сума за месеца в поле 3 на заглавната част")]
        public decimal Amount {
            get {
                return this.amountField;
            }
            set {
                this.amountField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AmountSpecified {
            get {
                return this.amountFieldSpecified;
            }
            set {
                this.amountFieldSpecified = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.30375")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=true)]
    public partial class ISType {
        
        private int rowField;
        
        private bool rowFieldSpecified;
        
        private string groundNameField;
        
        private decimal amountField;
        
        private bool amountFieldSpecified;
        
        /// <summary>
        /// Номер на ред
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        [System.ComponentModel.DescriptionAttribute("Номер на ред")]
        public int Row {
            get {
                return this.rowField;
            }
            set {
                this.rowField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool RowSpecified {
            get {
                return this.rowFieldSpecified;
            }
            set {
                this.rowFieldSpecified = value;
            }
        }
        
        /// <summary>
        /// Вид на отпусната интеграционна добавка
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        [System.ComponentModel.DescriptionAttribute("Вид на отпусната интеграционна добавка")]
        public string GroundName {
            get {
                return this.groundNameField;
            }
            set {
                this.groundNameField = value;
            }
        }
        
        /// <summary>
        /// Размер на отпуснатата сума за месеца в поле 3 на заглавната част (може да е празно, ако няма за месеца!)
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        [System.ComponentModel.DescriptionAttribute("Размер на отпуснатата сума за месеца в поле 3 на заглавната част (може да е празн" +
            "о, ако няма за месеца!)")]
        public decimal Amount {
            get {
                return this.amountField;
            }
            set {
                this.amountField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AmountSpecified {
            get {
                return this.amountFieldSpecified;
            }
            set {
                this.amountFieldSpecified = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.30375")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=true)]
    public partial class DataType {
        
        private List<ISType> isField;
        
        private List<OtherType> otherField;
        
        private List<АuxType> auxField;
        
        private List<VignetteType> vignetteField;
        
        private List<BDZType> bDZField;
        
        private List<SocialServicesType> ssField;
        
        private List<ErrorType> errorField;
        
        /// <summary>
        /// DataType class constructor
        /// </summary>
        public DataType() {
            this.errorField = new List<ErrorType>();
            this.ssField = new List<SocialServicesType>();
            this.bDZField = new List<BDZType>();
            this.vignetteField = new List<VignetteType>();
            this.auxField = new List<АuxType>();
            this.otherField = new List<OtherType>();
            this.isField = new List<ISType>();
        }
        
        /// <summary>
        /// Интеграционни добавки
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("IS", Order=0)]
        [System.ComponentModel.DescriptionAttribute("Интеграционни добавки")]
        public List<ISType> IS {
            get {
                return this.isField;
            }
            set {
                this.isField = value;
            }
        }
        
        /// <summary>
        /// Други плащания
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("Other", Order=1)]
        [System.ComponentModel.DescriptionAttribute("Други плащания")]
        public List<OtherType> Other {
            get {
                return this.otherField;
            }
            set {
                this.otherField = value;
            }
        }
        
        /// <summary>
        /// ПСПСМИ
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("Aux", Order=2)]
        [System.ComponentModel.DescriptionAttribute("ПСПСМИ")]
        public List<АuxType> Aux {
            get {
                return this.auxField;
            }
            set {
                this.auxField = value;
            }
        }
        
        /// <summary>
        /// Винетни стикери
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("Vignette", Order=3)]
        [System.ComponentModel.DescriptionAttribute("Винетни стикери")]
        public List<VignetteType> Vignette {
            get {
                return this.vignetteField;
            }
            set {
                this.vignetteField = value;
            }
        }
        
        /// <summary>
        /// Удостоверение за пътуване с БДЖ
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("BDZ", Order=4)]
        [System.ComponentModel.DescriptionAttribute("Удостоверение за пътуване с БДЖ")]
        public List<BDZType> BDZ {
            get {
                return this.bDZField;
            }
            set {
                this.bDZField = value;
            }
        }
        
        /// <summary>
        /// Социални услуги
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("SS", Order=5)]
        [System.ComponentModel.DescriptionAttribute("Социални услуги")]
        public List<SocialServicesType> SS {
            get {
                return this.ssField;
            }
            set {
                this.ssField = value;
            }
        }
        
        /// <summary>
        /// Грешки
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("Error", Order=6)]
        [System.ComponentModel.DescriptionAttribute("Грешки")]
        public List<ErrorType> Error {
            get {
                return this.errorField;
            }
            set {
                this.errorField = value;
            }
        }
    }
}
