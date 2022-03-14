// ------------------------------------------------------------------------------
//  <auto-generated>
//    Generated by Xsd2Code. Version 3.4.0.20336
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
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.30026")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/MVR/PaymentNotification/SendPaymentNotificationRequest")]
    [System.Xml.Serialization.XmlRootAttribute("SendPaymentNotificationRequest", Namespace="http://egov.bg/RegiX/MVR/PaymentNotification/SendPaymentNotificationRequest", IsNullable=false)]
    public partial class SendPaymentNotificationRequestType {
        
        private string transactionNumberField;
        
        private SendNotificationDocumentType documentTypeField;
        
        private string documentSeriesField;
        
        private string documentNumberField;
        
        private double paymentAmountField;
        
        private System.DateTime paymentDateField;
        
        private string payerPinField;
        
        private SendNotificationPayerType payerTypeField;
        
        private bool payerTypeFieldSpecified;
        
        private int systemIdField;
        
        private bool systemIdFieldSpecified;
        
        private string administrationNameField;
        
        /// <summary>
        /// Уникален номер на транзакцията от ePay
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        [System.ComponentModel.DescriptionAttribute("Уникален номер на транзакцията от ePay")]
        public string TransactionNumber {
            get {
                return this.transactionNumberField;
            }
            set {
                this.transactionNumberField = value;
            }
        }
        
        /// <summary>
        /// Тип документ.
        /// Документ от тип АУАН, Фиш, НП
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        [System.ComponentModel.DescriptionAttribute("Тип документ.\nДокумент от тип АУАН, Фиш, НП")]
        public SendNotificationDocumentType DocumentType {
            get {
                return this.documentTypeField;
            }
            set {
                this.documentTypeField = value;
            }
        }
        
        /// <summary>
        /// Серия на документ
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        [System.ComponentModel.DescriptionAttribute("Серия на документ")]
        public string DocumentSeries {
            get {
                return this.documentSeriesField;
            }
            set {
                this.documentSeriesField = value;
            }
        }
        
        /// <summary>
        /// Номер на документ
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        [System.ComponentModel.DescriptionAttribute("Номер на документ")]
        public string DocumentNumber {
            get {
                return this.documentNumberField;
            }
            set {
                this.documentNumberField = value;
            }
        }
        
        /// <summary>
        /// Платена сума, BGN
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        [System.ComponentModel.DescriptionAttribute("Платена сума, BGN")]
        public double PaymentAmount {
            get {
                return this.paymentAmountField;
            }
            set {
                this.paymentAmountField = value;
            }
        }
        
        /// <summary>
        /// Дата/час на плащането
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        [System.ComponentModel.DescriptionAttribute("Дата/час на плащането")]
        public System.DateTime PaymentDate {
            get {
                return this.paymentDateField;
            }
            set {
                this.paymentDateField = value;
            }
        }
        
        /// <summary>
        /// Идентификатор на наредител (ЕГН/ЛНЧ/ЕИК)
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        [System.ComponentModel.DescriptionAttribute("Идентификатор на наредител (ЕГН/ЛНЧ/ЕИК)")]
        public string PayerPin {
            get {
                return this.payerPinField;
            }
            set {
                this.payerPinField = value;
            }
        }
        
        /// <summary>
        /// Тип на наредител  - (P) „Физическо лице“
        /// (L) „Юридическо лице“
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        [System.ComponentModel.DescriptionAttribute("Тип на наредител  - (P) „Физическо лице“\n(L) „Юридическо лице“")]
        public SendNotificationPayerType PayerType {
            get {
                return this.payerTypeField;
            }
            set {
                this.payerTypeField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PayerTypeSpecified {
            get {
                return this.payerTypeFieldSpecified;
            }
            set {
                this.payerTypeFieldSpecified = value;
            }
        }
        
        /// <summary>
        /// Стойност от номенклатура "Информационни системи"
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        [System.ComponentModel.DescriptionAttribute("Стойност от номенклатура \"Информационни системи\"")]
        public int SystemId {
            get {
                return this.systemIdField;
            }
            set {
                this.systemIdField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SystemIdSpecified {
            get {
                return this.systemIdFieldSpecified;
            }
            set {
                this.systemIdFieldSpecified = value;
            }
        }
        
        /// <summary>
        /// Структура/администрация
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        [System.ComponentModel.DescriptionAttribute("Структура/администрация")]
        public string AdministrationName {
            get {
                return this.administrationNameField;
            }
            set {
                this.administrationNameField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.30026")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/MVR/PaymentNotification/SendPaymentNotificationRequest")]
    public enum SendNotificationDocumentType {
        
        /// <remarks/>
        TICKET,
        
        /// <remarks/>
        PENAL_DECREE,
        
        /// <remarks/>
        AGREEMENT,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.30026")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/MVR/PaymentNotification/SendPaymentNotificationRequest")]
    public enum SendNotificationPayerType {
        
        /// <remarks/>
        P,
        
        /// <remarks/>
        L,
    }
}
