// ------------------------------------------------------------------------------
//  <auto-generated>
//    Generated by Xsd2Code. Version 3.4.0.25415
//    <NameSpace>TechnoLogica.RegiX.AVTRAdapter</NameSpace><Collection>List</Collection><codeType>CSharp</codeType><EnableDataBinding>False</EnableDataBinding><EnableLazyLoading>False</EnableLazyLoading><TrackingChangesEnable>False</TrackingChangesEnable><GenTrackingClasses>False</GenTrackingClasses><HidePrivateFieldInIDE>False</HidePrivateFieldInIDE><EnableSummaryComment>True</EnableSummaryComment><VirtualProp>False</VirtualProp><IncludeSerializeMethod>False</IncludeSerializeMethod><UseBaseClass>False</UseBaseClass><GenBaseClass>False</GenBaseClass><GenerateCloneMethod>False</GenerateCloneMethod><GenerateDataContracts>False</GenerateDataContracts><CodeBaseTag>Net40</CodeBaseTag><SerializeMethodName>Serialize</SerializeMethodName><DeserializeMethodName>Deserialize</DeserializeMethodName><SaveToFileMethodName>SaveToFile</SaveToFileMethodName><LoadFromFileMethodName>LoadFromFile</LoadFromFileMethodName><GenerateXMLAttributes>True</GenerateXMLAttributes><EnableEncoding>False</EnableEncoding><AutomaticProperties>False</AutomaticProperties><GenerateShouldSerialize>False</GenerateShouldSerialize><DisableDebug>False</DisableDebug><PropNameSpecified>Default</PropNameSpecified><Encoder>UTF8</Encoder><CustomUsings></CustomUsings><ExcludeIncludedTypes>True</ExcludeIncludedTypes><EnableInitializeFields>True</EnableInitializeFields>
//  </auto-generated>
// ------------------------------------------------------------------------------
namespace TechnoLogica.RegiX.AVTRAdapter {
    using System;
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System.Collections;
    using System.Xml.Schema;
    using System.ComponentModel;
    using System.Collections.Generic;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.28029")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/AV/TR/ActualStateResponse")]
    [System.Xml.Serialization.XmlRootAttribute("ActualStateResponse", Namespace="http://egov.bg/RegiX/AV/TR/ActualStateResponse", IsNullable=false)]
    public partial class ActualStateResponseType {
        
        private StatusType statusField;
        
        private bool statusFieldSpecified;
        
        private string uICField;
        
        private string companyField;
        
        private LegalFormType legalFormField;
        
        private string transliterationField;
        
        private SeatType seatField;
        
        private AddressType seatForCorrespondenceField;
        
        private SubjectOfActivityType subjectOfActivityField;
        
        private NKIDType subjectOfActivityNKIDField;
        
        private string wayOfManagementField;
        
        private string wayOfRepresentationField;
        
        private string termsOfPartnershipField;
        
        private string termOfExistingField;
        
        private string specialConditionsField;
        
        private string hiddenNonMonetaryDepositField;
        
        private string sharePaymentResponsibilityField;
        
        private string concededEstateValueField;
        
        private string cessationOfTradeField;
        
        private string addemptionOfTraderField;
        
        private AddemptionOfTraderType addemptionOfTraderSeatChangeField;
        
        private CapitalAmountType fundsField;
        
        private List<ShareType> sharesField;
        
        private CapitalAmountType minimumAmountField;
        
        private CapitalAmountType depositedFundsField;
        
        private List<NonMonetaryDepositType> nonMonetaryDepositsField;
        
        private string buyBackDecisionField;
        
        private MandateType boardOfDirectorsMandateField;
        
        private MandateType administrativeBoardMandateField;
        
        private MandateType boardOfManagersMandateField;
        
        private MandateType boardOfManagers2MandateField;
        
        private MandateType leadingBoardMandateField;
        
        private MandateType supervisingBoardMandateField;
        
        private MandateType supervisingBoard2MandateField;
        
        private MandateType controllingBoardMandateField;
        
        private List<DetailType> detailsField;
        
        private System.DateTime dataValidForDateField;
        
        private bool dataValidForDateFieldSpecified;
        
        private LiquidationOrInsolvency liquidationOrInsolvencyField;
        
        private bool liquidationOrInsolvencyFieldSpecified;
        
        /// <summary>
        /// ActualStateResponseType class constructor
        /// </summary>
        public ActualStateResponseType() {
            this.detailsField = new List<DetailType>();
            this.controllingBoardMandateField = new MandateType();
            this.supervisingBoard2MandateField = new MandateType();
            this.supervisingBoardMandateField = new MandateType();
            this.leadingBoardMandateField = new MandateType();
            this.boardOfManagers2MandateField = new MandateType();
            this.boardOfManagersMandateField = new MandateType();
            this.administrativeBoardMandateField = new MandateType();
            this.boardOfDirectorsMandateField = new MandateType();
            this.nonMonetaryDepositsField = new List<NonMonetaryDepositType>();
            this.depositedFundsField = new CapitalAmountType();
            this.minimumAmountField = new CapitalAmountType();
            this.sharesField = new List<ShareType>();
            this.fundsField = new CapitalAmountType();
            this.addemptionOfTraderSeatChangeField = new AddemptionOfTraderType();
            this.subjectOfActivityNKIDField = new NKIDType();
            this.subjectOfActivityField = new SubjectOfActivityType();
            this.seatForCorrespondenceField = new AddressType();
            this.seatField = new SeatType();
            this.legalFormField = new LegalFormType();
        }
        
        /// <summary>
        /// Статус на партида
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        [System.ComponentModel.DescriptionAttribute("Статус на партида")]
        public StatusType Status {
            get {
                return this.statusField;
            }
            set {
                this.statusField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool StatusSpecified {
            get {
                return this.statusFieldSpecified;
            }
            set {
                this.statusFieldSpecified = value;
            }
        }
        
        /// <summary>
        /// Код на поле:00010 - ЕИК
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        [System.ComponentModel.DescriptionAttribute("Код на поле:00010 - ЕИК")]
        public string UIC {
            get {
                return this.uICField;
            }
            set {
                this.uICField = value;
            }
        }
        
        /// <summary>
        /// Код на поле:00020 - Фирма
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        [System.ComponentModel.DescriptionAttribute("Код на поле:00020 - Фирма")]
        public string Company {
            get {
                return this.companyField;
            }
            set {
                this.companyField = value;
            }
        }
        
        /// <summary>
        /// Код на поле:00030 - Правна форма
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        [System.ComponentModel.DescriptionAttribute("Код на поле:00030 - Правна форма")]
        public LegalFormType LegalForm {
            get {
                return this.legalFormField;
            }
            set {
                this.legalFormField = value;
            }
        }
        
        /// <summary>
        /// Код на поле:00040 - Изписване на чужд език
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        [System.ComponentModel.DescriptionAttribute("Код на поле:00040 - Изписване на чужд език")]
        public string Transliteration {
            get {
                return this.transliterationField;
            }
            set {
                this.transliterationField = value;
            }
        }
        
        /// <summary>
        /// Код на поле:00050 - Седалище и адрес на управление
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        [System.ComponentModel.DescriptionAttribute("Код на поле:00050 - Седалище и адрес на управление")]
        public SeatType Seat {
            get {
                return this.seatField;
            }
            set {
                this.seatField = value;
            }
        }
        
        /// <summary>
        /// Код на поле:00051 - Адрес за кореспонденция с НАП на територията на страната
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        [System.ComponentModel.DescriptionAttribute("Код на поле:00051 - Адрес за кореспонденция с НАП на територията на страната")]
        public AddressType SeatForCorrespondence {
            get {
                return this.seatForCorrespondenceField;
            }
            set {
                this.seatForCorrespondenceField = value;
            }
        }
        
        /// <summary>
        /// Код на поле:00060 - Предмет на дейност
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        [System.ComponentModel.DescriptionAttribute("Код на поле:00060 - Предмет на дейност")]
        public SubjectOfActivityType SubjectOfActivity {
            get {
                return this.subjectOfActivityField;
            }
            set {
                this.subjectOfActivityField = value;
            }
        }
        
        /// <summary>
        /// Код на поле:00061 - Основна  дейност по НКИД
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        [System.ComponentModel.DescriptionAttribute("Код на поле:00061 - Основна  дейност по НКИД")]
        public NKIDType SubjectOfActivityNKID {
            get {
                return this.subjectOfActivityNKIDField;
            }
            set {
                this.subjectOfActivityNKIDField = value;
            }
        }
        
        /// <summary>
        /// Код на поле:00080 - Начин на управление
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        [System.ComponentModel.DescriptionAttribute("Код на поле:00080 - Начин на управление")]
        public string WayOfManagement {
            get {
                return this.wayOfManagementField;
            }
            set {
                this.wayOfManagementField = value;
            }
        }
        
        /// <summary>
        /// Код на поле:00110 - Начин на представляване
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
        [System.ComponentModel.DescriptionAttribute("Код на поле:00110 - Начин на представляване")]
        public string WayOfRepresentation {
            get {
                return this.wayOfRepresentationField;
            }
            set {
                this.wayOfRepresentationField = value;
            }
        }
        
        /// <summary>
        /// Код на поле:00160 - Срок на дружеството
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=11)]
        [System.ComponentModel.DescriptionAttribute("Код на поле:00160 - Срок на дружеството")]
        public string TermsOfPartnership {
            get {
                return this.termsOfPartnershipField;
            }
            set {
                this.termsOfPartnershipField = value;
            }
        }
        
        /// <summary>
        /// Код на поле:00161 - Срок на съществуване
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=12)]
        [System.ComponentModel.DescriptionAttribute("Код на поле:00161 - Срок на съществуване")]
        public string TermOfExisting {
            get {
                return this.termOfExistingField;
            }
            set {
                this.termOfExistingField = value;
            }
        }
        
        /// <summary>
        /// Код на поле:00170 - Специални условия
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=13)]
        [System.ComponentModel.DescriptionAttribute("Код на поле:00170 - Специални условия")]
        public string SpecialConditions {
            get {
                return this.specialConditionsField;
            }
            set {
                this.specialConditionsField = value;
            }
        }
        
        /// <summary>
        /// Код на поле:00241 - Скрита непарична вноска
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=14)]
        [System.ComponentModel.DescriptionAttribute("Код на поле:00241 - Скрита непарична вноска")]
        public string HiddenNonMonetaryDeposit {
            get {
                return this.hiddenNonMonetaryDepositField;
            }
            set {
                this.hiddenNonMonetaryDepositField = value;
            }
        }
        
        /// <summary>
        /// Код на поле:00250 - Отговорност над дялови вноски
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=15)]
        [System.ComponentModel.DescriptionAttribute("Код на поле:00250 - Отговорност над дялови вноски")]
        public string SharePaymentResponsibility {
            get {
                return this.sharePaymentResponsibilityField;
            }
            set {
                this.sharePaymentResponsibilityField = value;
            }
        }
        
        /// <summary>
        /// Код на поле:00251 - Стойност на имуществото, предоставено от държавата или общината
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=16)]
        [System.ComponentModel.DescriptionAttribute("Код на поле:00251 - Стойност на имуществото, предоставено от държавата или община" +
            "та")]
        public string ConcededEstateValue {
            get {
                return this.concededEstateValueField;
            }
            set {
                this.concededEstateValueField = value;
            }
        }
        
        /// <summary>
        /// Код на поле:00260 - Прекратяване на търговската дейност
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=17)]
        [System.ComponentModel.DescriptionAttribute("Код на поле:00260 - Прекратяване на търговската дейност")]
        public string CessationOfTrade {
            get {
                return this.cessationOfTradeField;
            }
            set {
                this.cessationOfTradeField = value;
            }
        }
        
        /// <summary>
        /// Код на поле:00270 - Заличаване на търговеца
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=18)]
        [System.ComponentModel.DescriptionAttribute("Код на поле:00270 - Заличаване на търговеца")]
        public string AddemptionOfTrader {
            get {
                return this.addemptionOfTraderField;
            }
            set {
                this.addemptionOfTraderField = value;
            }
        }
        
        /// <summary>
        /// Код на поле:00271 - Заличаване поради преместване на седалището в друга дъжвава-членка
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=19)]
        [System.ComponentModel.DescriptionAttribute("Код на поле:00271 - Заличаване поради преместване на седалището в друга дъжвава-ч" +
            "ленка")]
        public AddemptionOfTraderType AddemptionOfTraderSeatChange {
            get {
                return this.addemptionOfTraderSeatChangeField;
            }
            set {
                this.addemptionOfTraderSeatChangeField = value;
            }
        }
        
        /// <summary>
        /// Код на поле:00310 - Капитал Размер
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=20)]
        [System.ComponentModel.DescriptionAttribute("Код на поле:00310 - Капитал Размер")]
        public CapitalAmountType Funds {
            get {
                return this.fundsField;
            }
            set {
                this.fundsField = value;
            }
        }
        
        /// <summary>
        /// Код на поле:00311 - Акции
        /// </summary>
        [System.Xml.Serialization.XmlArrayAttribute(Order=21)]
        [System.Xml.Serialization.XmlArrayItemAttribute("Share", Namespace="http://egov.bg/RegiX/AV/TR", IsNullable=false)]
        [System.ComponentModel.DescriptionAttribute("Код на поле:00311 - Акции")]
        public List<ShareType> Shares {
            get {
                return this.sharesField;
            }
            set {
                this.sharesField = value;
            }
        }
        
        /// <summary>
        /// Код на поле:00312 - Минимален размер
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=22)]
        [System.ComponentModel.DescriptionAttribute("Код на поле:00312 - Минимален размер")]
        public CapitalAmountType MinimumAmount {
            get {
                return this.minimumAmountField;
            }
            set {
                this.minimumAmountField = value;
            }
        }
        
        /// <summary>
        /// Код на поле:00320 - Внесен капитал
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=23)]
        [System.ComponentModel.DescriptionAttribute("Код на поле:00320 - Внесен капитал")]
        public CapitalAmountType DepositedFunds {
            get {
                return this.depositedFundsField;
            }
            set {
                this.depositedFundsField = value;
            }
        }
        
        /// <summary>
        /// Код на поле:00330 - Непарична вноска
        /// </summary>
        [System.Xml.Serialization.XmlArrayAttribute(Order=24)]
        [System.Xml.Serialization.XmlArrayItemAttribute("NonMonetaryDeposit", Namespace="http://egov.bg/RegiX/AV/TR", IsNullable=false)]
        [System.ComponentModel.DescriptionAttribute("Код на поле:00330 - Непарична вноска")]
        public List<NonMonetaryDepositType> NonMonetaryDeposits {
            get {
                return this.nonMonetaryDepositsField;
            }
            set {
                this.nonMonetaryDepositsField = value;
            }
        }
        
        /// <summary>
        /// Код на поле:00340 - Решение за обратно изкупуване на акции
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=25)]
        [System.ComponentModel.DescriptionAttribute("Код на поле:00340 - Решение за обратно изкупуване на акции")]
        public string BuyBackDecision {
            get {
                return this.buyBackDecisionField;
            }
            set {
                this.buyBackDecisionField = value;
            }
        }
        
        /// <summary>
        /// Код на поле:00120 - Съвет на директорите
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=26)]
        [System.ComponentModel.DescriptionAttribute("Код на поле:00120 - Съвет на директорите")]
        public MandateType BoardOfDirectorsMandate {
            get {
                return this.boardOfDirectorsMandateField;
            }
            set {
                this.boardOfDirectorsMandateField = value;
            }
        }
        
        /// <summary>
        /// Код на поле:00122 - Административен орган
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=27)]
        [System.ComponentModel.DescriptionAttribute("Код на поле:00122 - Административен орган")]
        public MandateType AdministrativeBoardMandate {
            get {
                return this.administrativeBoardMandateField;
            }
            set {
                this.administrativeBoardMandateField = value;
            }
        }
        
        /// <summary>
        /// Код на поле:00130 - Управителен съвет
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=28)]
        [System.ComponentModel.DescriptionAttribute("Код на поле:00130 - Управителен съвет")]
        public MandateType BoardOfManagersMandate {
            get {
                return this.boardOfManagersMandateField;
            }
            set {
                this.boardOfManagersMandateField = value;
            }
        }
        
        /// <summary>
        /// Код на поле:00132 - Управителен съвет
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=29)]
        [System.ComponentModel.DescriptionAttribute("Код на поле:00132 - Управителен съвет")]
        public MandateType BoardOfManagers2Mandate {
            get {
                return this.boardOfManagers2MandateField;
            }
            set {
                this.boardOfManagers2MandateField = value;
            }
        }
        
        /// <summary>
        /// Код на поле:00133 - Ръководен орган
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=30)]
        [System.ComponentModel.DescriptionAttribute("Код на поле:00133 - Ръководен орган")]
        public MandateType LeadingBoardMandate {
            get {
                return this.leadingBoardMandateField;
            }
            set {
                this.leadingBoardMandateField = value;
            }
        }
        
        /// <summary>
        /// Код на поле:00140 - Надзорен съвет
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=31)]
        [System.ComponentModel.DescriptionAttribute("Код на поле:00140 - Надзорен съвет")]
        public MandateType SupervisingBoardMandate {
            get {
                return this.supervisingBoardMandateField;
            }
            set {
                this.supervisingBoardMandateField = value;
            }
        }
        
        /// <summary>
        /// Код на поле:00142 - Надзорен орган
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=32)]
        [System.ComponentModel.DescriptionAttribute("Код на поле:00142 - Надзорен орган")]
        public MandateType SupervisingBoard2Mandate {
            get {
                return this.supervisingBoard2MandateField;
            }
            set {
                this.supervisingBoard2MandateField = value;
            }
        }
        
        /// <summary>
        /// Код на поле:00150 - Контролен съвет
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=33)]
        [System.ComponentModel.DescriptionAttribute("Код на поле:00150 - Контролен съвет")]
        public MandateType ControllingBoardMandate {
            get {
                return this.controllingBoardMandateField;
            }
            set {
                this.controllingBoardMandateField = value;
            }
        }
        
        [System.Xml.Serialization.XmlArrayAttribute(Order=34)]
        [System.Xml.Serialization.XmlArrayItemAttribute("Detail", Namespace="http://egov.bg/RegiX/AV/TR", IsNullable=false)]
        public List<DetailType> Details {
            get {
                return this.detailsField;
            }
            set {
                this.detailsField = value;
            }
        }
        
        /// <summary>
        /// Дата на валидност на данните
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=35)]
        [System.ComponentModel.DescriptionAttribute("Дата на валидност на данните")]
        public System.DateTime DataValidForDate {
            get {
                return this.dataValidForDateField;
            }
            set {
                this.dataValidForDateField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DataValidForDateSpecified {
            get {
                return this.dataValidForDateFieldSpecified;
            }
            set {
                this.dataValidForDateFieldSpecified = value;
            }
        }
        
        /// <summary>
        /// Статус за ликвидация или несъстоятелност
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=36)]
        [System.ComponentModel.DescriptionAttribute("Статус за ликвидация или несъстоятелност")]
        public LiquidationOrInsolvency LiquidationOrInsolvency {
            get {
                return this.liquidationOrInsolvencyField;
            }
            set {
                this.liquidationOrInsolvencyField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool LiquidationOrInsolvencySpecified {
            get {
                return this.liquidationOrInsolvencyFieldSpecified;
            }
            set {
                this.liquidationOrInsolvencyFieldSpecified = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.28029")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/AV/TR/ActualStateResponse")]
    public enum LiquidationOrInsolvency {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("В ликвидация")]
        Вликвидация,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("В несъстоятелност")]
        Внесъстоятелност,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("В несъстоятелност (на II инстанция)")]
        ВнесъстоятелностнаIIинстанция,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("В несъстоятелност (на III инстанция)")]
        ВнесъстоятелностнаIIIинстанция,
    }
}
