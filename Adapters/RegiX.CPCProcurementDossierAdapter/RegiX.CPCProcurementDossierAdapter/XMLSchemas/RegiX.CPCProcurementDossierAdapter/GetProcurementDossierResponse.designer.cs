// ------------------------------------------------------------------------------
//  <auto-generated>
//    Generated by Xsd2Code. Version 3.4.0.20336
//    <NameSpace>TechnoLogica.RegiX.CPCProcurementDossierAdapter</NameSpace><Collection>List</Collection><codeType>CSharp</codeType><EnableDataBinding>False</EnableDataBinding><EnableLazyLoading>False</EnableLazyLoading><TrackingChangesEnable>False</TrackingChangesEnable><GenTrackingClasses>False</GenTrackingClasses><HidePrivateFieldInIDE>False</HidePrivateFieldInIDE><EnableSummaryComment>True</EnableSummaryComment><VirtualProp>False</VirtualProp><IncludeSerializeMethod>False</IncludeSerializeMethod><UseBaseClass>False</UseBaseClass><GenBaseClass>False</GenBaseClass><GenerateCloneMethod>False</GenerateCloneMethod><GenerateDataContracts>False</GenerateDataContracts><CodeBaseTag>Net40</CodeBaseTag><SerializeMethodName>Serialize</SerializeMethodName><DeserializeMethodName>Deserialize</DeserializeMethodName><SaveToFileMethodName>SaveToFile</SaveToFileMethodName><LoadFromFileMethodName>LoadFromFile</LoadFromFileMethodName><GenerateXMLAttributes>True</GenerateXMLAttributes><EnableEncoding>False</EnableEncoding><AutomaticProperties>False</AutomaticProperties><GenerateShouldSerialize>False</GenerateShouldSerialize><DisableDebug>False</DisableDebug><PropNameSpecified>Default</PropNameSpecified><Encoder>UTF8</Encoder><CustomUsings></CustomUsings><ExcludeIncludedTypes>False</ExcludeIncludedTypes><EnableInitializeFields>True</EnableInitializeFields>
//  </auto-generated>
// ------------------------------------------------------------------------------
namespace TechnoLogica.RegiX.CPCProcurementDossierAdapter {
    using System;
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System.Collections;
    using System.Xml.Schema;
    using System.ComponentModel;
    using System.Collections.Generic;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.21886")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
    public partial class GetProcurementDossierResponse {
        
        private string resultMessageField;
        
        private GetProcurementDossierResponseResultStatus resultStatusField;
        
        private ProcurementDossiersType procurementDossiersField;
        
        /// <summary>
        /// GetProcurementDossierResponse class constructor
        /// </summary>
        public GetProcurementDossierResponse() {
            this.procurementDossiersField = new ProcurementDossiersType();
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string ResultMessage {
            get {
                return this.resultMessageField;
            }
            set {
                this.resultMessageField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public GetProcurementDossierResponseResultStatus ResultStatus {
            get {
                return this.resultStatusField;
            }
            set {
                this.resultStatusField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public ProcurementDossiersType ProcurementDossiers {
            get {
                return this.procurementDossiersField;
            }
            set {
                this.procurementDossiersField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.21886")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public enum GetProcurementDossierResponseResultStatus {
        
        /// <remarks/>
        OK,
        
        /// <remarks/>
        INVALID_INPUT,
        
        /// <remarks/>
        NO_DATA_FOUND,
        
        /// <remarks/>
        ERROR,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.21886")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=true)]
    public partial class ProcurementDossiersType {
        
        private List<ProcurementDossierType> procurementDossierField;
        
        /// <summary>
        /// ProcurementDossiersType class constructor
        /// </summary>
        public ProcurementDossiersType() {
            this.procurementDossierField = new List<ProcurementDossierType>();
        }
        
        [System.Xml.Serialization.XmlElementAttribute("ProcurementDossier", Order=0)]
        public List<ProcurementDossierType> ProcurementDossier {
            get {
                return this.procurementDossierField;
            }
            set {
                this.procurementDossierField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.21886")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=true)]
    public partial class ProcurementDossierType {
        
        private string procurementNumberField;
        
        private string proceedingsNumberField;
        
        private System.DateTime proceedingsStartDateField;
        
        private bool proceedingsStartDateFieldSpecified;
        
        private System.DateTime proceedingsCloseDateField;
        
        private bool proceedingsCloseDateFieldSpecified;
        
        private string legalBaseField;
        
        private string proceedingsTypeField;
        
        private ProceedingsSubsectionsType proceedingsSubsectionsField;
        
        private InitiatorsType initiatorsField;
        
        private DefendantsType defendantsField;
        
        private UnitedProceedingsType unitedProceedingsField;
        
        private bool interimMeasuresField;
        
        private bool interimMeasuresFieldSpecified;
        
        private ImposedInterimMeasuresType imposedInterimMeasuresField;
        
        private string currentStatusField;
        
        private System.DateTime dossierPublishDateField;
        
        private bool dossierPublishDateFieldSpecified;
        
        private System.DateTime lastDecisionPublishDateField;
        
        private bool lastDecisionPublishDateFieldSpecified;
        
        private ImposedPenaltiesType imposedPenaltiesField;
        
        private string dossierLinkField;
        
        private string registerIDField;
        
        /// <summary>
        /// ProcurementDossierType class constructor
        /// </summary>
        public ProcurementDossierType() {
            this.imposedPenaltiesField = new ImposedPenaltiesType();
            this.imposedInterimMeasuresField = new ImposedInterimMeasuresType();
            this.unitedProceedingsField = new UnitedProceedingsType();
            this.defendantsField = new DefendantsType();
            this.initiatorsField = new InitiatorsType();
            this.proceedingsSubsectionsField = new ProceedingsSubsectionsType();
        }
        
        /// <summary>
        /// Уникален номер на поръчка в РОП
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        [System.ComponentModel.DescriptionAttribute("Уникален номер на поръчка в РОП")]
        public string ProcurementNumber {
            get {
                return this.procurementNumberField;
            }
            set {
                this.procurementNumberField = value;
            }
        }
        
        /// <summary>
        /// Номер на производство
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        [System.ComponentModel.DescriptionAttribute("Номер на производство")]
        public string ProceedingsNumber {
            get {
                return this.proceedingsNumberField;
            }
            set {
                this.proceedingsNumberField = value;
            }
        }
        
        /// <summary>
        /// Дата на образуване
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date", Order=2)]
        [System.ComponentModel.DescriptionAttribute("Дата на образуване")]
        public System.DateTime ProceedingsStartDate {
            get {
                return this.proceedingsStartDateField;
            }
            set {
                this.proceedingsStartDateField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ProceedingsStartDateSpecified {
            get {
                return this.proceedingsStartDateFieldSpecified;
            }
            set {
                this.proceedingsStartDateFieldSpecified = value;
            }
        }
        
        /// <summary>
        /// Дата на приключване
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date", Order=3)]
        [System.ComponentModel.DescriptionAttribute("Дата на приключване")]
        public System.DateTime ProceedingsCloseDate {
            get {
                return this.proceedingsCloseDateField;
            }
            set {
                this.proceedingsCloseDateField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ProceedingsCloseDateSpecified {
            get {
                return this.proceedingsCloseDateFieldSpecified;
            }
            set {
                this.proceedingsCloseDateFieldSpecified = value;
            }
        }
        
        /// <summary>
        /// Правно основание
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        [System.ComponentModel.DescriptionAttribute("Правно основание")]
        public string LegalBase {
            get {
                return this.legalBaseField;
            }
            set {
                this.legalBaseField = value;
            }
        }
        
        /// <summary>
        /// Вид производство
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        [System.ComponentModel.DescriptionAttribute("Вид производство")]
        public string ProceedingsType {
            get {
                return this.proceedingsTypeField;
            }
            set {
                this.proceedingsTypeField = value;
            }
        }
        
        /// <summary>
        /// Предмети/подпредмети
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        [System.ComponentModel.DescriptionAttribute("Предмети/подпредмети")]
        public ProceedingsSubsectionsType ProceedingsSubsections {
            get {
                return this.proceedingsSubsectionsField;
            }
            set {
                this.proceedingsSubsectionsField = value;
            }
        }
        
        /// <summary>
        /// Инициатор(и)
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        [System.ComponentModel.DescriptionAttribute("Инициатор(и)")]
        public InitiatorsType Initiators {
            get {
                return this.initiatorsField;
            }
            set {
                this.initiatorsField = value;
            }
        }
        
        /// <summary>
        /// Ответник(ници)
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        [System.ComponentModel.DescriptionAttribute("Ответник(ници)")]
        public DefendantsType Defendants {
            get {
                return this.defendantsField;
            }
            set {
                this.defendantsField = value;
            }
        }
        
        /// <summary>
        /// Обединена с производство
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        [System.ComponentModel.DescriptionAttribute("Обединена с производство")]
        public UnitedProceedingsType UnitedProceedings {
            get {
                return this.unitedProceedingsField;
            }
            set {
                this.unitedProceedingsField = value;
            }
        }
        
        /// <summary>
        /// Искане за временни мерки
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
        [System.ComponentModel.DescriptionAttribute("Искане за временни мерки")]
        public bool InterimMeasures {
            get {
                return this.interimMeasuresField;
            }
            set {
                this.interimMeasuresField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool InterimMeasuresSpecified {
            get {
                return this.interimMeasuresFieldSpecified;
            }
            set {
                this.interimMeasuresFieldSpecified = value;
            }
        }
        
        /// <summary>
        /// Има ли наложени временни мерки
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=11)]
        [System.ComponentModel.DescriptionAttribute("Има ли наложени временни мерки")]
        public ImposedInterimMeasuresType ImposedInterimMeasures {
            get {
                return this.imposedInterimMeasuresField;
            }
            set {
                this.imposedInterimMeasuresField = value;
            }
        }
        
        /// <summary>
        /// Текущ статус
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=12)]
        [System.ComponentModel.DescriptionAttribute("Текущ статус")]
        public string CurrentStatus {
            get {
                return this.currentStatusField;
            }
            set {
                this.currentStatusField = value;
            }
        }
        
        /// <summary>
        /// Дата на публикуване
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date", Order=13)]
        [System.ComponentModel.DescriptionAttribute("Дата на публикуване")]
        public System.DateTime DossierPublishDate {
            get {
                return this.dossierPublishDateField;
            }
            set {
                this.dossierPublishDateField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DossierPublishDateSpecified {
            get {
                return this.dossierPublishDateFieldSpecified;
            }
            set {
                this.dossierPublishDateFieldSpecified = value;
            }
        }
        
        /// <summary>
        /// Дата на публикуване на последното решение
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date", Order=14)]
        [System.ComponentModel.DescriptionAttribute("Дата на публикуване на последното решение")]
        public System.DateTime LastDecisionPublishDate {
            get {
                return this.lastDecisionPublishDateField;
            }
            set {
                this.lastDecisionPublishDateField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool LastDecisionPublishDateSpecified {
            get {
                return this.lastDecisionPublishDateFieldSpecified;
            }
            set {
                this.lastDecisionPublishDateFieldSpecified = value;
            }
        }
        
        /// <summary>
        /// Наложени санкции
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=15)]
        [System.ComponentModel.DescriptionAttribute("Наложени санкции")]
        public ImposedPenaltiesType ImposedPenalties {
            get {
                return this.imposedPenaltiesField;
            }
            set {
                this.imposedPenaltiesField = value;
            }
        }
        
        /// <summary>
        /// Връзка към портала на КЗК
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=16)]
        [System.ComponentModel.DescriptionAttribute("Връзка към портала на КЗК")]
        public string DossierLink {
            get {
                return this.dossierLinkField;
            }
            set {
                this.dossierLinkField = value;
            }
        }
        
        /// <summary>
        /// Входящ номер на жалба
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=17)]
        [System.ComponentModel.DescriptionAttribute("Входящ номер на жалба")]
        public string RegisterID {
            get {
                return this.registerIDField;
            }
            set {
                this.registerIDField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.21886")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=true)]
    public partial class ProceedingsSubsectionsType {
        
        private List<string> proceedingSubsectionField;
        
        /// <summary>
        /// ProceedingsSubsectionsType class constructor
        /// </summary>
        public ProceedingsSubsectionsType() {
            this.proceedingSubsectionField = new List<string>();
        }
        
        /// <summary>
        /// Предмет/подпредмет
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("ProceedingSubsection", Order=0)]
        [System.ComponentModel.DescriptionAttribute("Предмет/подпредмет")]
        public List<string> ProceedingSubsection {
            get {
                return this.proceedingSubsectionField;
            }
            set {
                this.proceedingSubsectionField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.21886")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=true)]
    public partial class ImposedPenaltiesType {
        
        private List<string> imposedPenaltyField;
        
        /// <summary>
        /// ImposedPenaltiesType class constructor
        /// </summary>
        public ImposedPenaltiesType() {
            this.imposedPenaltyField = new List<string>();
        }
        
        /// <summary>
        /// Наложена санкция
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("ImposedPenalty", Order=0)]
        [System.ComponentModel.DescriptionAttribute("Наложена санкция")]
        public List<string> ImposedPenalty {
            get {
                return this.imposedPenaltyField;
            }
            set {
                this.imposedPenaltyField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.21886")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=true)]
    public partial class ImposedInterimMeasuresType {
        
        private List<string> imposedInterimMeasureField;
        
        /// <summary>
        /// ImposedInterimMeasuresType class constructor
        /// </summary>
        public ImposedInterimMeasuresType() {
            this.imposedInterimMeasureField = new List<string>();
        }
        
        /// <summary>
        /// Наложена временна мярка
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("ImposedInterimMeasure", Order=0)]
        [System.ComponentModel.DescriptionAttribute("Наложена временна мярка")]
        public List<string> ImposedInterimMeasure {
            get {
                return this.imposedInterimMeasureField;
            }
            set {
                this.imposedInterimMeasureField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.21886")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=true)]
    public partial class UnitedProceedingsType {
        
        private List<string> unitedProceedingField;
        
        /// <summary>
        /// UnitedProceedingsType class constructor
        /// </summary>
        public UnitedProceedingsType() {
            this.unitedProceedingField = new List<string>();
        }
        
        [System.Xml.Serialization.XmlElementAttribute("UnitedProceeding", Order=0)]
        public List<string> UnitedProceeding {
            get {
                return this.unitedProceedingField;
            }
            set {
                this.unitedProceedingField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.21886")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=true)]
    public partial class DefendantsType {
        
        private List<string> defendantField;
        
        /// <summary>
        /// DefendantsType class constructor
        /// </summary>
        public DefendantsType() {
            this.defendantField = new List<string>();
        }
        
        /// <summary>
        /// Ответник
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("Defendant", Order=0)]
        [System.ComponentModel.DescriptionAttribute("Ответник")]
        public List<string> Defendant {
            get {
                return this.defendantField;
            }
            set {
                this.defendantField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.21886")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=true)]
    public partial class InitiatorsType {
        
        private List<string> initiatorField;
        
        /// <summary>
        /// InitiatorsType class constructor
        /// </summary>
        public InitiatorsType() {
            this.initiatorField = new List<string>();
        }
        
        /// <summary>
        /// Инициатор
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("Initiator", Order=0)]
        [System.ComponentModel.DescriptionAttribute("Инициатор")]
        public List<string> Initiator {
            get {
                return this.initiatorField;
            }
            set {
                this.initiatorField = value;
            }
        }
    }
}
