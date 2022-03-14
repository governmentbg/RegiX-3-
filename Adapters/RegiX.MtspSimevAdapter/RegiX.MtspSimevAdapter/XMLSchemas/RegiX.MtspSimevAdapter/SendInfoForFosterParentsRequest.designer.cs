// ------------------------------------------------------------------------------
//  <auto-generated>
//    Generated by Xsd2Code. Version 3.4.0.24420
//    <NameSpace>TechnoLogica.RegiX.MtspSimevAdapter</NameSpace><Collection>List</Collection><codeType>CSharp</codeType><EnableDataBinding>False</EnableDataBinding><EnableLazyLoading>False</EnableLazyLoading><TrackingChangesEnable>False</TrackingChangesEnable><GenTrackingClasses>False</GenTrackingClasses><HidePrivateFieldInIDE>False</HidePrivateFieldInIDE><EnableSummaryComment>True</EnableSummaryComment><VirtualProp>False</VirtualProp><IncludeSerializeMethod>False</IncludeSerializeMethod><UseBaseClass>False</UseBaseClass><GenBaseClass>False</GenBaseClass><GenerateCloneMethod>False</GenerateCloneMethod><GenerateDataContracts>False</GenerateDataContracts><CodeBaseTag>Net40</CodeBaseTag><SerializeMethodName>Serialize</SerializeMethodName><DeserializeMethodName>Deserialize</DeserializeMethodName><SaveToFileMethodName>SaveToFile</SaveToFileMethodName><LoadFromFileMethodName>LoadFromFile</LoadFromFileMethodName><GenerateXMLAttributes>True</GenerateXMLAttributes><EnableEncoding>False</EnableEncoding><AutomaticProperties>False</AutomaticProperties><GenerateShouldSerialize>False</GenerateShouldSerialize><DisableDebug>False</DisableDebug><PropNameSpecified>Default</PropNameSpecified><Encoder>UTF8</Encoder><CustomUsings></CustomUsings><ExcludeIncludedTypes>True</ExcludeIncludedTypes><EnableInitializeFields>True</EnableInitializeFields>
//  </auto-generated>
// ------------------------------------------------------------------------------
namespace TechnoLogica.RegiX.MtspSimevAdapter {
    using System;
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System.Collections;
    using System.Xml.Schema;
    using System.ComponentModel;
    using System.Collections.Generic;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.25223")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/MTSP/SendInfoForFosterParents/MtspInfoFosterParentsRequest")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://egov.bg/RegiX/MTSP/SendInfoForFosterParents/MtspInfoFosterParentsRequest", IsNullable=false)]
    public partial class MtspInfoFosterParentsRequest {
        
        private MtspHeader headerField;
        
        private MtspData dataField;
        
        /// <summary>
        /// MtspInfoFosterParentsRequest class constructor
        /// </summary>
        public MtspInfoFosterParentsRequest() {
            this.dataField = new MtspData();
            this.headerField = new MtspHeader();
        }
        
        /// <summary>
        /// Заглавна част на запитването
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        [System.ComponentModel.DescriptionAttribute("Заглавна част на запитването")]
        public MtspHeader Header {
            get {
                return this.headerField;
            }
            set {
                this.headerField = value;
            }
        }
        
        /// <summary>
        /// Детайли на запитването
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        [System.ComponentModel.DescriptionAttribute("Детайли на запитването")]
        public MtspData Data {
            get {
                return this.dataField;
            }
            set {
                this.dataField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.25223")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/MTSP/SendInfoForFosterParents/MtspInfoFosterParentsRequest")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://egov.bg/RegiX/MTSP/SendInfoForFosterParents/MtspInfoFosterParentsRequest", IsNullable=true)]
    public partial class MtspHeader {
        
        private int requestNumberField;
        
        private int sizeField;
        
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
        
        /// <summary>
        /// Брой редове в отговора
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        [System.ComponentModel.DescriptionAttribute("Брой редове в отговора")]
        public int Size {
            get {
                return this.sizeField;
            }
            set {
                this.sizeField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.25223")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/MTSP/SendInfoForFosterParents/MtspInfoFosterParentsRequest")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://egov.bg/RegiX/MTSP/SendInfoForFosterParents/MtspInfoFosterParentsRequest", IsNullable=true)]
    public partial class MtspDataItem {
        
        private int rowField;
        
        private string parentIdentificatorField;
        
        private bool isRegisteredField;
        
        private bool isRegisteredFieldSpecified;
        
        private bool isFosterParentField;
        
        private bool isFosterParentFieldSpecified;
        
        private bool hasTelkField;
        
        private bool hasTelkFieldSpecified;
        
        private string contractNumberField;
        
        private System.DateTime contractDateField;
        
        private bool contractDateFieldSpecified;
        
        private System.DateTime contractStartDateField;
        
        private bool contractStartDateFieldSpecified;
        
        private System.DateTime contractEndDateField;
        
        private bool contractEndDateFieldSpecified;
        
        private System.DateTime contractClosingDateField;
        
        private bool contractClosingDateFieldSpecified;
        
        private double amountField;
        
        private bool amountFieldSpecified;
        
        private string childIndentificatorField;
        
        private bool isChildRegisteredField;
        
        private bool isChildRegisteredFieldSpecified;
        
        private bool isRegisteredInRiskField;
        
        private bool isRegisteredInRiskFieldSpecified;
        
        private bool isSettledField;
        
        private bool isSettledFieldSpecified;
        
        private bool isSettledEverField;
        
        private bool isSettledEverFieldSpecified;
        
        private System.DateTime sattleDateField;
        
        private bool sattleDateFieldSpecified;
        
        private System.DateTime sattleEndDateField;
        
        private bool sattleEndDateFieldSpecified;
        
        private bool hasChildTelkField;
        
        private bool hasChildTelkFieldSpecified;
        
        private double childAmountField;
        
        private bool childAmountFieldSpecified;
        
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
        
        /// <summary>
        /// ЕГН/ЛНЧ на приемен родител
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        [System.ComponentModel.DescriptionAttribute("ЕГН/ЛНЧ на приемен родител")]
        public string ParentIdentificator {
            get {
                return this.parentIdentificatorField;
            }
            set {
                this.parentIdentificatorField = value;
            }
        }
        
        /// <summary>
        /// Присъства ли лицето в базата данни на ИИС на АСП?
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        [System.ComponentModel.DescriptionAttribute("Присъства ли лицето в базата данни на ИИС на АСП?")]
        public bool IsRegistered {
            get {
                return this.isRegisteredField;
            }
            set {
                this.isRegisteredField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IsRegisteredSpecified {
            get {
                return this.isRegisteredFieldSpecified;
            }
            set {
                this.isRegisteredFieldSpecified = value;
            }
        }
        
        /// <summary>
        /// Присъства ли лицето в регистъра на приемните семейства на ИИС на АСП за указания период?
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        [System.ComponentModel.DescriptionAttribute("Присъства ли лицето в регистъра на приемните семейства на ИИС на АСП за указания " +
            "период?")]
        public bool IsFosterParent {
            get {
                return this.isFosterParentField;
            }
            set {
                this.isFosterParentField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IsFosterParentSpecified {
            get {
                return this.isFosterParentFieldSpecified;
            }
            set {
                this.isFosterParentFieldSpecified = value;
            }
        }
        
        /// <summary>
        /// Регистрирано ли е лицето в ИИС на АСП ТЕЛК, валиден за указания период?
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        [System.ComponentModel.DescriptionAttribute("Регистрирано ли е лицето в ИИС на АСП ТЕЛК, валиден за указания период?")]
        public bool HasTelk {
            get {
                return this.hasTelkField;
            }
            set {
                this.hasTelkField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool HasTelkSpecified {
            get {
                return this.hasTelkFieldSpecified;
            }
            set {
                this.hasTelkFieldSpecified = value;
            }
        }
        
        /// <summary>
        /// Номер на последен договор за приемна грижа с общината, включващ указания период
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        [System.ComponentModel.DescriptionAttribute("Номер на последен договор за приемна грижа с общината, включващ указания период")]
        public string ContractNumber {
            get {
                return this.contractNumberField;
            }
            set {
                this.contractNumberField = value;
            }
        }
        
        /// <summary>
        /// Дата на договор по т.5
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date", Order=6)]
        [System.ComponentModel.DescriptionAttribute("Дата на договор по т.5")]
        public System.DateTime ContractDate {
            get {
                return this.contractDateField;
            }
            set {
                this.contractDateField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ContractDateSpecified {
            get {
                return this.contractDateFieldSpecified;
            }
            set {
                this.contractDateFieldSpecified = value;
            }
        }
        
        /// <summary>
        /// Дата на начало на договора по т.5
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date", Order=7)]
        [System.ComponentModel.DescriptionAttribute("Дата на начало на договора по т.5")]
        public System.DateTime ContractStartDate {
            get {
                return this.contractStartDateField;
            }
            set {
                this.contractStartDateField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ContractStartDateSpecified {
            get {
                return this.contractStartDateFieldSpecified;
            }
            set {
                this.contractStartDateFieldSpecified = value;
            }
        }
        
        /// <summary>
        /// Дата на края на договора по т.5
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date", Order=8)]
        [System.ComponentModel.DescriptionAttribute("Дата на края на договора по т.5")]
        public System.DateTime ContractEndDate {
            get {
                return this.contractEndDateField;
            }
            set {
                this.contractEndDateField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ContractEndDateSpecified {
            get {
                return this.contractEndDateFieldSpecified;
            }
            set {
                this.contractEndDateFieldSpecified = value;
            }
        }
        
        /// <summary>
        /// Дата на прекратяване на договора по т.5
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date", Order=9)]
        [System.ComponentModel.DescriptionAttribute("Дата на прекратяване на договора по т.5")]
        public System.DateTime ContractClosingDate {
            get {
                return this.contractClosingDateField;
            }
            set {
                this.contractClosingDateField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ContractClosingDateSpecified {
            get {
                return this.contractClosingDateFieldSpecified;
            }
            set {
                this.contractClosingDateFieldSpecified = value;
            }
        }
        
        /// <summary>
        /// Размер на месечното възнаграждение по договора от т.5
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
        [System.ComponentModel.DescriptionAttribute("Размер на месечното възнаграждение по договора от т.5")]
        public double Amount {
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
        
        /// <summary>
        /// ЕГН/ЛНЧ на настанено дете
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=11)]
        [System.ComponentModel.DescriptionAttribute("ЕГН/ЛНЧ на настанено дете")]
        public string ChildIndentificator {
            get {
                return this.childIndentificatorField;
            }
            set {
                this.childIndentificatorField = value;
            }
        }
        
        /// <summary>
        /// Присъства ли детето в базата данни на ИИС на АСП?
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=12)]
        [System.ComponentModel.DescriptionAttribute("Присъства ли детето в базата данни на ИИС на АСП?")]
        public bool IsChildRegistered {
            get {
                return this.isChildRegisteredField;
            }
            set {
                this.isChildRegisteredField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IsChildRegisteredSpecified {
            get {
                return this.isChildRegisteredFieldSpecified;
            }
            set {
                this.isChildRegisteredFieldSpecified = value;
            }
        }
        
        /// <summary>
        /// Детето присъства ли в регистъра на децата в риск на ИИС на АСП  за указания период?
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=13)]
        [System.ComponentModel.DescriptionAttribute("Детето присъства ли в регистъра на децата в риск на ИИС на АСП  за указания перио" +
            "д?")]
        public bool IsRegisteredInRisk {
            get {
                return this.isRegisteredInRiskField;
            }
            set {
                this.isRegisteredInRiskField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IsRegisteredInRiskSpecified {
            get {
                return this.isRegisteredInRiskFieldSpecified;
            }
            set {
                this.isRegisteredInRiskFieldSpecified = value;
            }
        }
        
        /// <summary>
        /// За детето, предприета ли е мярка "настаняване в приемно семейство" за указания период, при този приемен родител?
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=14)]
        [System.ComponentModel.DescriptionAttribute("За детето, предприета ли е мярка \"настаняване в приемно семейство\" за указания пе" +
            "риод, при този приемен родител?")]
        public bool IsSettled {
            get {
                return this.isSettledField;
            }
            set {
                this.isSettledField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IsSettledSpecified {
            get {
                return this.isSettledFieldSpecified;
            }
            set {
                this.isSettledFieldSpecified = value;
            }
        }
        
        /// <summary>
        /// Детето било ли е настанено някога изобщо при този приемен родител?
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=15)]
        [System.ComponentModel.DescriptionAttribute("Детето било ли е настанено някога изобщо при този приемен родител?")]
        public bool IsSettledEver {
            get {
                return this.isSettledEverField;
            }
            set {
                this.isSettledEverField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IsSettledEverSpecified {
            get {
                return this.isSettledEverFieldSpecified;
            }
            set {
                this.isSettledEverFieldSpecified = value;
            }
        }
        
        /// <summary>
        /// Дата на настаняване, при този приемен родител (последно известно настаняване преди или в указания период)
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date", Order=16)]
        [System.ComponentModel.DescriptionAttribute("Дата на настаняване, при този приемен родител (последно известно настаняване пред" +
            "и или в указания период)")]
        public System.DateTime SattleDate {
            get {
                return this.sattleDateField;
            }
            set {
                this.sattleDateField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SattleDateSpecified {
            get {
                return this.sattleDateFieldSpecified;
            }
            set {
                this.sattleDateFieldSpecified = value;
            }
        }
        
        /// <summary>
        /// Дата на извеждане, от този приемен родител (последно известно извеждане в указания период)
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date", Order=17)]
        [System.ComponentModel.DescriptionAttribute("Дата на извеждане, от този приемен родител (последно известно извеждане в указани" +
            "я период)")]
        public System.DateTime SattleEndDate {
            get {
                return this.sattleEndDateField;
            }
            set {
                this.sattleEndDateField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SattleEndDateSpecified {
            get {
                return this.sattleEndDateFieldSpecified;
            }
            set {
                this.sattleEndDateFieldSpecified = value;
            }
        }
        
        /// <summary>
        /// Регистрирано ли е детето в ИИС на АСП ТЕЛК, валиден за указания период?
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=18)]
        [System.ComponentModel.DescriptionAttribute("Регистрирано ли е детето в ИИС на АСП ТЕЛК, валиден за указания период?")]
        public bool hasChildTelk {
            get {
                return this.hasChildTelkField;
            }
            set {
                this.hasChildTelkField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool hasChildTelkSpecified {
            get {
                return this.hasChildTelkFieldSpecified;
            }
            set {
                this.hasChildTelkFieldSpecified = value;
            }
        }
        
        /// <summary>
        /// Размер на месечната издръжка за това дете при този родител
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=19)]
        [System.ComponentModel.DescriptionAttribute("Размер на месечната издръжка за това дете при този родител")]
        public double ChildAmount {
            get {
                return this.childAmountField;
            }
            set {
                this.childAmountField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ChildAmountSpecified {
            get {
                return this.childAmountFieldSpecified;
            }
            set {
                this.childAmountFieldSpecified = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.25223")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/MTSP/SendInfoForFosterParents/MtspInfoFosterParentsRequest")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://egov.bg/RegiX/MTSP/SendInfoForFosterParents/MtspInfoFosterParentsRequest", IsNullable=true)]
    public partial class MtspData {
        
        private List<MtspDataItem> dataItemField;
        
        /// <summary>
        /// MtspData class constructor
        /// </summary>
        public MtspData() {
            this.dataItemField = new List<MtspDataItem>();
        }
        
        /// <summary>
        /// Данни за дете/приемен родител
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("DataItem", Order=0)]
        [System.ComponentModel.DescriptionAttribute("Данни за дете/приемен родител")]
        public List<MtspDataItem> DataItem {
            get {
                return this.dataItemField;
            }
            set {
                this.dataItemField = value;
            }
        }
    }
}