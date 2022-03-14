// ------------------------------------------------------------------------------
//  <auto-generated>
//    Generated by Xsd2Code. Version 3.4.0.24803
//    <NameSpace>TechnoLogica.RegiX.NRAObligatedPersonsAdapter</NameSpace><Collection>List</Collection><codeType>CSharp</codeType><EnableDataBinding>False</EnableDataBinding><EnableLazyLoading>False</EnableLazyLoading><TrackingChangesEnable>False</TrackingChangesEnable><GenTrackingClasses>False</GenTrackingClasses><HidePrivateFieldInIDE>False</HidePrivateFieldInIDE><EnableSummaryComment>True</EnableSummaryComment><VirtualProp>False</VirtualProp><IncludeSerializeMethod>False</IncludeSerializeMethod><UseBaseClass>False</UseBaseClass><GenBaseClass>False</GenBaseClass><GenerateCloneMethod>False</GenerateCloneMethod><GenerateDataContracts>False</GenerateDataContracts><CodeBaseTag>Net40</CodeBaseTag><SerializeMethodName>Serialize</SerializeMethodName><DeserializeMethodName>Deserialize</DeserializeMethodName><SaveToFileMethodName>SaveToFile</SaveToFileMethodName><LoadFromFileMethodName>LoadFromFile</LoadFromFileMethodName><GenerateXMLAttributes>True</GenerateXMLAttributes><EnableEncoding>False</EnableEncoding><AutomaticProperties>False</AutomaticProperties><GenerateShouldSerialize>False</GenerateShouldSerialize><DisableDebug>False</DisableDebug><PropNameSpecified>Default</PropNameSpecified><Encoder>UTF8</Encoder><CustomUsings></CustomUsings><ExcludeIncludedTypes>False</ExcludeIncludedTypes><EnableInitializeFields>True</EnableInitializeFields>
//  </auto-generated>
// ------------------------------------------------------------------------------
namespace TechnoLogica.RegiX.NRAObligatedPersonsAdapter {
    using System;
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System.Collections;
    using System.Xml.Schema;
    using System.ComponentModel;
    using System.Collections.Generic;
    
    
    /// <summary>
    /// Справка данни за осигуряване от декларации по Наредба Н-8 към Кодекса за социално осигуряване - резултат
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.16181")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
    [System.ComponentModel.DescriptionAttribute("Справка данни за осигуряване от декларации по Наредба Н-8 към Кодекса за социално" +
        " осигуряване - резултат")]
    public partial class GetSocialSecurityDataFromDeclarationsResponse {
        
        private List<SocialSecurityDataFromDeclarationsResponseType> socialSecurityDataFromDeclarationsField;
        
        /// <summary>
        /// GetSocialSecurityDataFromDeclarationsResponse class constructor
        /// </summary>
        public GetSocialSecurityDataFromDeclarationsResponse() {
            this.socialSecurityDataFromDeclarationsField = new List<SocialSecurityDataFromDeclarationsResponseType>();
        }
        
        [System.Xml.Serialization.XmlArrayAttribute(Order=0)]
        [System.Xml.Serialization.XmlArrayItemAttribute("SocialSecurityDataFromDeclaration", IsNullable=false)]
        public List<SocialSecurityDataFromDeclarationsResponseType> SocialSecurityDataFromDeclarations {
            get {
                return this.socialSecurityDataFromDeclarationsField;
            }
            set {
                this.socialSecurityDataFromDeclarationsField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.16181")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=true)]
    public partial class SocialSecurityDataFromDeclarationsResponseType {
        
        private string declarationTypeField;
        
        private string personIdentifierField;
        
        private string personLastNameAndInitialsField;
        
        private string insurerIdentifierField;
        
        private string insurerNameField;
        
        private string insurerAdressField;
        
        private string monthField;
        
        private string yearField;
        
        private string personTypeField;
        
        private string totalInsuredDaysField;
        
        private string daysWorkedField;
        
        private string lawEstablishedWorkHoursField;
        
        private string dailyAgreedWorkHoursField;
        
        private string socialSecurityIncomeField;
        
        private string gVRSFundFlagField;
        
        private string correctionCodeField;
        
        private System.DateTime submissionDateField;
        
        private bool submissionDateFieldSpecified;
        
        private string requestPersonIdentifierField;
        
        private PersonIdentifierTypeEnum requestPersonIdentifierTypeField;
        
        private bool requestPersonIdentifierTypeFieldSpecified;
        
        private string requestInsurerIdentificatorField;
        
        private int requestMonthFromField;
        
        private bool requestMonthFromFieldSpecified;
        
        private int requestYearFromField;
        
        private bool requestYearFromFieldSpecified;
        
        private int requestMonthToField;
        
        private bool requestMonthToFieldSpecified;
        
        private int requestYearToField;
        
        private bool requestYearToFieldSpecified;
        
        /// <summary>
        /// Вид на декларацията
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        [System.ComponentModel.DescriptionAttribute("Вид на декларацията")]
        public string DeclarationType {
            get {
                return this.declarationTypeField;
            }
            set {
                this.declarationTypeField = value;
            }
        }
        
        /// <summary>
        /// Идентификатор на осигуреното лице (при избор на справката по осигурител);
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        [System.ComponentModel.DescriptionAttribute("Идентификатор на осигуреното лице (при избор на справката по осигурител);")]
        public string PersonIdentifier {
            get {
                return this.personIdentifierField;
            }
            set {
                this.personIdentifierField = value;
            }
        }
        
        /// <summary>
        /// Инициали и фамилия на осигуреното лице (при избор на справката по осигурител);
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        [System.ComponentModel.DescriptionAttribute("Инициали и фамилия на осигуреното лице (при избор на справката по осигурител);")]
        public string PersonLastNameAndInitials {
            get {
                return this.personLastNameAndInitialsField;
            }
            set {
                this.personLastNameAndInitialsField = value;
            }
        }
        
        /// <summary>
        /// Идентификатор на осигурител (при избор на справката за осигуреното лице)
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        [System.ComponentModel.DescriptionAttribute("Идентификатор на осигурител (при избор на справката за осигуреното лице)")]
        public string InsurerIdentifier {
            get {
                return this.insurerIdentifierField;
            }
            set {
                this.insurerIdentifierField = value;
            }
        }
        
        /// <summary>
        /// Наименование на осигурител (при избор на справката за осигуреното лице)
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        [System.ComponentModel.DescriptionAttribute("Наименование на осигурител (при избор на справката за осигуреното лице)")]
        public string InsurerName {
            get {
                return this.insurerNameField;
            }
            set {
                this.insurerNameField = value;
            }
        }
        
        /// <summary>
        /// Адрес на осигурителя (при избор на справката за осигуреното лице)
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        [System.ComponentModel.DescriptionAttribute("Адрес на осигурителя (при избор на справката за осигуреното лице)")]
        public string InsurerAdress {
            get {
                return this.insurerAdressField;
            }
            set {
                this.insurerAdressField = value;
            }
        }
        
        /// <summary>
        /// Месец
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        [System.ComponentModel.DescriptionAttribute("Месец")]
        public string Month {
            get {
                return this.monthField;
            }
            set {
                this.monthField = value;
            }
        }
        
        /// <summary>
        /// Година
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        [System.ComponentModel.DescriptionAttribute("Година")]
        public string Year {
            get {
                return this.yearField;
            }
            set {
                this.yearField = value;
            }
        }
        
        /// <summary>
        /// Вид осигурен
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        [System.ComponentModel.DescriptionAttribute("Вид осигурен")]
        public string PersonType {
            get {
                return this.personTypeField;
            }
            set {
                this.personTypeField = value;
            }
        }
        
        /// <summary>
        /// Дни в осигуряване – общо
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        [System.ComponentModel.DescriptionAttribute("Дни в осигуряване – общо")]
        public string TotalInsuredDays {
            get {
                return this.totalInsuredDaysField;
            }
            set {
                this.totalInsuredDaysField = value;
            }
        }
        
        /// <summary>
        /// Отработени дни
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
        [System.ComponentModel.DescriptionAttribute("Отработени дни")]
        public string DaysWorked {
            get {
                return this.daysWorkedField;
            }
            set {
                this.daysWorkedField = value;
            }
        }
        
        /// <summary>
        /// Законоустановено работно време
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=11)]
        [System.ComponentModel.DescriptionAttribute("Законоустановено работно време")]
        public string LawEstablishedWorkHours {
            get {
                return this.lawEstablishedWorkHoursField;
            }
            set {
                this.lawEstablishedWorkHoursField = value;
            }
        }
        
        /// <summary>
        /// Дневно договорено работно време
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=12)]
        [System.ComponentModel.DescriptionAttribute("Дневно договорено работно време")]
        public string DailyAgreedWorkHours {
            get {
                return this.dailyAgreedWorkHoursField;
            }
            set {
                this.dailyAgreedWorkHoursField = value;
            }
        }
        
        /// <summary>
        /// Осигурителен доход (опционално поле)
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=13)]
        [System.ComponentModel.DescriptionAttribute("Осигурителен доход (опционално поле)")]
        public string SocialSecurityIncome {
            get {
                return this.socialSecurityIncomeField;
            }
            set {
                this.socialSecurityIncomeField = value;
            }
        }
        
        /// <summary>
        /// Флаг фонд ГВРС
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=14)]
        [System.ComponentModel.DescriptionAttribute("Флаг фонд ГВРС")]
        public string GVRSFundFlag {
            get {
                return this.gVRSFundFlagField;
            }
            set {
                this.gVRSFundFlagField = value;
            }
        }
        
        /// <summary>
        /// Код на корекция
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=15)]
        [System.ComponentModel.DescriptionAttribute("Код на корекция")]
        public string CorrectionCode {
            get {
                return this.correctionCodeField;
            }
            set {
                this.correctionCodeField = value;
            }
        }
        
        /// <summary>
        /// Дата на подаване
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=16)]
        [System.ComponentModel.DescriptionAttribute("Дата на подаване")]
        public System.DateTime SubmissionDate {
            get {
                return this.submissionDateField;
            }
            set {
                this.submissionDateField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SubmissionDateSpecified {
            get {
                return this.submissionDateFieldSpecified;
            }
            set {
                this.submissionDateFieldSpecified = value;
            }
        }
        
        /// <summary>
        /// От request-a -> Идентификатор за осигуреното физическо лице – с ограничение до 10 разряда
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=17)]
        [System.ComponentModel.DescriptionAttribute("От request-a -> Идентификатор за осигуреното физическо лице – с ограничение до 10" +
            " разряда")]
        public string RequestPersonIdentifier {
            get {
                return this.requestPersonIdentifierField;
            }
            set {
                this.requestPersonIdentifierField = value;
            }
        }
        
        /// <summary>
        /// От request-a -> Тип на идентификатор за физическите лица - с възможност за избор на:
        /// •	ЕГН;
        /// •	ЛН/ЛНЧ;
        /// •	Служебен номер от регистъра на НАП;
        /// •	ЕИК по БУЛСТАТ.
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=18)]
        [System.ComponentModel.DescriptionAttribute("От request-a -> Тип на идентификатор за физическите лица - с възможност за избор " +
            "на: \n•\tЕГН; \n•\tЛН/ЛНЧ; \n•\tСлужебен номер от регистъра на НАП; \n•\tЕИК по БУЛСТАТ." +
            "")]
        public PersonIdentifierTypeEnum RequestPersonIdentifierType {
            get {
                return this.requestPersonIdentifierTypeField;
            }
            set {
                this.requestPersonIdentifierTypeField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool RequestPersonIdentifierTypeSpecified {
            get {
                return this.requestPersonIdentifierTypeFieldSpecified;
            }
            set {
                this.requestPersonIdentifierTypeFieldSpecified = value;
            }
        }
        
        /// <summary>
        /// От request-a -> Идентификатор на осигурителя (ЕИК/сл.№ от регистъра на НАП) -  с ограничение до 13 разряда.
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=19)]
        [System.ComponentModel.DescriptionAttribute("От request-a -> Идентификатор на осигурителя (ЕИК/сл.№ от регистъра на НАП) -  с " +
            "ограничение до 13 разряда.")]
        public string RequestInsurerIdentificator {
            get {
                return this.requestInsurerIdentificatorField;
            }
            set {
                this.requestInsurerIdentificatorField = value;
            }
        }
        
        /// <summary>
        /// От request-a -> Месец от
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=20)]
        [System.ComponentModel.DescriptionAttribute("От request-a -> Месец от")]
        public int RequestMonthFrom {
            get {
                return this.requestMonthFromField;
            }
            set {
                this.requestMonthFromField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool RequestMonthFromSpecified {
            get {
                return this.requestMonthFromFieldSpecified;
            }
            set {
                this.requestMonthFromFieldSpecified = value;
            }
        }
        
        /// <summary>
        /// От request-a -> Година от
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=21)]
        [System.ComponentModel.DescriptionAttribute("От request-a -> Година от")]
        public int RequestYearFrom {
            get {
                return this.requestYearFromField;
            }
            set {
                this.requestYearFromField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool RequestYearFromSpecified {
            get {
                return this.requestYearFromFieldSpecified;
            }
            set {
                this.requestYearFromFieldSpecified = value;
            }
        }
        
        /// <summary>
        /// От request-a -> Месец до
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=22)]
        [System.ComponentModel.DescriptionAttribute("От request-a -> Месец до")]
        public int RequestMonthTo {
            get {
                return this.requestMonthToField;
            }
            set {
                this.requestMonthToField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool RequestMonthToSpecified {
            get {
                return this.requestMonthToFieldSpecified;
            }
            set {
                this.requestMonthToFieldSpecified = value;
            }
        }
        
        /// <summary>
        /// От request-a -> Година до
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=23)]
        [System.ComponentModel.DescriptionAttribute("От request-a -> Година до")]
        public int RequestYearTo {
            get {
                return this.requestYearToField;
            }
            set {
                this.requestYearToField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool RequestYearToSpecified {
            get {
                return this.requestYearToFieldSpecified;
            }
            set {
                this.requestYearToFieldSpecified = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.16181")]
    [System.SerializableAttribute()]
    public enum PersonIdentifierTypeEnum {
        
        /// <remarks/>
        NOT_SPECIFIED,
        
        /// <remarks/>
        EGN,
        
        /// <remarks/>
        LNCh,
        
        /// <remarks/>
        NRASystemNo,
        
        /// <remarks/>
        EIK_BULSTAT,
    }
}