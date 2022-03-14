// ------------------------------------------------------------------------------
//  <auto-generated>
//    Generated by Xsd2Code. Version 3.4.0.20336
//    <NameSpace>TechnoLogica.RegiX.CRCIOORAdapter</NameSpace><Collection>List</Collection><codeType>CSharp</codeType><EnableDataBinding>False</EnableDataBinding><EnableLazyLoading>False</EnableLazyLoading><TrackingChangesEnable>False</TrackingChangesEnable><GenTrackingClasses>False</GenTrackingClasses><HidePrivateFieldInIDE>False</HidePrivateFieldInIDE><EnableSummaryComment>True</EnableSummaryComment><VirtualProp>False</VirtualProp><IncludeSerializeMethod>False</IncludeSerializeMethod><UseBaseClass>False</UseBaseClass><GenBaseClass>False</GenBaseClass><GenerateCloneMethod>False</GenerateCloneMethod><GenerateDataContracts>False</GenerateDataContracts><CodeBaseTag>Net40</CodeBaseTag><SerializeMethodName>Serialize</SerializeMethodName><DeserializeMethodName>Deserialize</DeserializeMethodName><SaveToFileMethodName>SaveToFile</SaveToFileMethodName><LoadFromFileMethodName>LoadFromFile</LoadFromFileMethodName><GenerateXMLAttributes>True</GenerateXMLAttributes><EnableEncoding>False</EnableEncoding><AutomaticProperties>False</AutomaticProperties><GenerateShouldSerialize>False</GenerateShouldSerialize><DisableDebug>False</DisableDebug><PropNameSpecified>Default</PropNameSpecified><Encoder>UTF8</Encoder><CustomUsings></CustomUsings><ExcludeIncludedTypes>True</ExcludeIncludedTypes><EnableInitializeFields>True</EnableInitializeFields>
//  </auto-generated>
// ------------------------------------------------------------------------------
namespace TechnoLogica.RegiX.CRCIOORAdapter {
    using System;
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System.Collections;
    using System.Xml.Schema;
    using System.ComponentModel;
    using System.Collections.Generic;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.24829")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/CRC/IOOR/GetCompanyInfoResponse")]
    [System.Xml.Serialization.XmlRootAttribute("GetCompanyInfoResponse", Namespace="http://egov.bg/RegiX/CRC/IOOR/GetCompanyInfoResponse", IsNullable=false)]
    public partial class GetCompanyInfoResponseType {
        
        private CompaniesType companiesField;
        
        /// <summary>
        /// GetCompanyInfoResponseType class constructor
        /// </summary>
        public GetCompanyInfoResponseType() {
            this.companiesField = new CompaniesType();
        }
        
        /// <summary>
        /// Данни за предприятия
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        [System.ComponentModel.DescriptionAttribute("Данни за предприятия")]
        public CompaniesType Companies {
            get {
                return this.companiesField;
            }
            set {
                this.companiesField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.24829")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/CRC/IOOR/GetCompanyInfoResponse")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://egov.bg/RegiX/CRC/IOOR/GetCompanyInfoResponse", IsNullable=true)]
    public partial class CompaniesType {
        
        private List<CompanyType> companyField;
        
        /// <summary>
        /// CompaniesType class constructor
        /// </summary>
        public CompaniesType() {
            this.companyField = new List<CompanyType>();
        }
        
        /// <summary>
        /// Данни за предприятие
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("Company", Order=0)]
        [System.ComponentModel.DescriptionAttribute("Данни за предприятие")]
        public List<CompanyType> Company {
            get {
                return this.companyField;
            }
            set {
                this.companyField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.24829")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/CRC/IOOR/GetCompanyInfoResponse")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://egov.bg/RegiX/CRC/IOOR/GetCompanyInfoResponse", IsNullable=true)]
    public partial class CompanyType {
        
        private string companyNameField;
        
        private string compTypeField;
        
        private string eIKField;
        
        private string headquartersAddressField;
        
        private string webPageAddressField;
        
        private NetworkInfoType networkInfoField;
        
        /// <summary>
        /// CompanyType class constructor
        /// </summary>
        public CompanyType() {
            this.networkInfoField = new NetworkInfoType();
        }
        
        /// <summary>
        /// Предприятие
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        [System.ComponentModel.DescriptionAttribute("Предприятие")]
        public string CompanyName {
            get {
                return this.companyNameField;
            }
            set {
                this.companyNameField = value;
            }
        }
        
        /// <summary>
        /// Вид
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        [System.ComponentModel.DescriptionAttribute("Вид")]
        public string CompType {
            get {
                return this.compTypeField;
            }
            set {
                this.compTypeField = value;
            }
        }
        
        /// <summary>
        /// ЕИК
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        [System.ComponentModel.DescriptionAttribute("ЕИК")]
        public string EIK {
            get {
                return this.eIKField;
            }
            set {
                this.eIKField = value;
            }
        }
        
        /// <summary>
        /// Седалище и адрес на управление
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        [System.ComponentModel.DescriptionAttribute("Седалище и адрес на управление")]
        public string HeadquartersAddress {
            get {
                return this.headquartersAddressField;
            }
            set {
                this.headquartersAddressField = value;
            }
        }
        
        /// <summary>
        /// Интернет страница
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        [System.ComponentModel.DescriptionAttribute("Интернет страница")]
        public string WebPageAddress {
            get {
                return this.webPageAddressField;
            }
            set {
                this.webPageAddressField = value;
            }
        }
        
        /// <summary>
        /// Информация за мрежа
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        [System.ComponentModel.DescriptionAttribute("Информация за мрежа")]
        public NetworkInfoType NetworkInfo {
            get {
                return this.networkInfoField;
            }
            set {
                this.networkInfoField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.24829")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/CRC/IOOR/GetCompanyInfoResponse")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://egov.bg/RegiX/CRC/IOOR/GetCompanyInfoResponse", IsNullable=true)]
    public partial class NetworkInfoType {
        
        private string netTypeField;
        
        private string permissionNumberField;
        
        private System.DateTime issueDateField;
        
        private bool issueDateFieldSpecified;
        
        private System.DateTime startOfActionDateField;
        
        private bool startOfActionDateFieldSpecified;
        
        private System.DateTime endOfActionDateField;
        
        private bool endOfActionDateFieldSpecified;
        
        private string purposeField;
        
        private string townField;
        
        private string nameField;
        
        private string regionField;
        
        private string lowerFrequencyLimitField;
        
        private string upperFrequencyLimitField;
        
        private string channelNumberField;
        
        private string frequencyRangeField;
        
        private string descriptionField;
        
        private decimal countField;
        
        private bool countFieldSpecified;
        
        private decimal blocksCountField;
        
        private bool blocksCountFieldSpecified;
        
        private decimal totalSpectrumField;
        
        private bool totalSpectrumFieldSpecified;
        
        private string networkTypeField;
        
        private string frequencyBandwidthField;
        
        private string mainFrequencyField;
        
        private string territorialScopeField;
        
        private string locationField;
        
        private string transmissionFrequencyField;
        
        private string transmissionBandwidthField;
        
        private string receptionBandwidthField;
        
        private string statusField;
        
        /// <summary>
        /// Вид мрежа
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        [System.ComponentModel.DescriptionAttribute("Вид мрежа")]
        public string NetType {
            get {
                return this.netTypeField;
            }
            set {
                this.netTypeField = value;
            }
        }
        
        /// <summary>
        /// Разрешение №
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        [System.ComponentModel.DescriptionAttribute("Разрешение №")]
        public string PermissionNumber {
            get {
                return this.permissionNumberField;
            }
            set {
                this.permissionNumberField = value;
            }
        }
        
        /// <summary>
        /// Дата на
        /// издаване
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date", Order=2)]
        [System.ComponentModel.DescriptionAttribute("Дата на\nиздаване")]
        public System.DateTime IssueDate {
            get {
                return this.issueDateField;
            }
            set {
                this.issueDateField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IssueDateSpecified {
            get {
                return this.issueDateFieldSpecified;
            }
            set {
                this.issueDateFieldSpecified = value;
            }
        }
        
        /// <summary>
        /// Начална дата
        /// на действие
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date", Order=3)]
        [System.ComponentModel.DescriptionAttribute("Начална дата\nна действие")]
        public System.DateTime StartOfActionDate {
            get {
                return this.startOfActionDateField;
            }
            set {
                this.startOfActionDateField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool StartOfActionDateSpecified {
            get {
                return this.startOfActionDateFieldSpecified;
            }
            set {
                this.startOfActionDateFieldSpecified = value;
            }
        }
        
        /// <summary>
        /// Крайна дата
        /// на действие
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date", Order=4)]
        [System.ComponentModel.DescriptionAttribute("Крайна дата\nна действие")]
        public System.DateTime EndOfActionDate {
            get {
                return this.endOfActionDateField;
            }
            set {
                this.endOfActionDateField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EndOfActionDateSpecified {
            get {
                return this.endOfActionDateFieldSpecified;
            }
            set {
                this.endOfActionDateFieldSpecified = value;
            }
        }
        
        /// <summary>
        /// Предназначение
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        [System.ComponentModel.DescriptionAttribute("Предназначение")]
        public string Purpose {
            get {
                return this.purposeField;
            }
            set {
                this.purposeField = value;
            }
        }
        
        /// <summary>
        /// гр./с
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        [System.ComponentModel.DescriptionAttribute("гр./с")]
        public string Town {
            get {
                return this.townField;
            }
            set {
                this.townField = value;
            }
        }
        
        /// <summary>
        /// Наименование
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        [System.ComponentModel.DescriptionAttribute("Наименование")]
        public string Name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
        
        /// <summary>
        /// Област
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        [System.ComponentModel.DescriptionAttribute("Област")]
        public string Region {
            get {
                return this.regionField;
            }
            set {
                this.regionField = value;
            }
        }
        
        /// <summary>
        /// Долна граница
        /// (MHz)
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        [System.ComponentModel.DescriptionAttribute("Долна граница\n(MHz)")]
        public string LowerFrequencyLimit {
            get {
                return this.lowerFrequencyLimitField;
            }
            set {
                this.lowerFrequencyLimitField = value;
            }
        }
        
        /// <summary>
        /// Горна граница
        /// (MHz)
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
        [System.ComponentModel.DescriptionAttribute("Горна граница\n(MHz)")]
        public string UpperFrequencyLimit {
            get {
                return this.upperFrequencyLimitField;
            }
            set {
                this.upperFrequencyLimitField = value;
            }
        }
        
        /// <summary>
        /// Номер на канала
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=11)]
        [System.ComponentModel.DescriptionAttribute("Номер на канала")]
        public string ChannelNumber {
            get {
                return this.channelNumberField;
            }
            set {
                this.channelNumberField = value;
            }
        }
        
        /// <summary>
        /// Честотен обхват
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=12)]
        [System.ComponentModel.DescriptionAttribute("Честотен обхват")]
        public string FrequencyRange {
            get {
                return this.frequencyRangeField;
            }
            set {
                this.frequencyRangeField = value;
            }
        }
        
        /// <summary>
        /// Описание
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=13)]
        [System.ComponentModel.DescriptionAttribute("Описание")]
        public string Description {
            get {
                return this.descriptionField;
            }
            set {
                this.descriptionField = value;
            }
        }
        
        /// <summary>
        /// Брой
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=14)]
        [System.ComponentModel.DescriptionAttribute("Брой")]
        public decimal Count {
            get {
                return this.countField;
            }
            set {
                this.countField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CountSpecified {
            get {
                return this.countFieldSpecified;
            }
            set {
                this.countFieldSpecified = value;
            }
        }
        
        /// <summary>
        /// Брой блокове
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=15)]
        [System.ComponentModel.DescriptionAttribute("Брой блокове")]
        public decimal BlocksCount {
            get {
                return this.blocksCountField;
            }
            set {
                this.blocksCountField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool BlocksCountSpecified {
            get {
                return this.blocksCountFieldSpecified;
            }
            set {
                this.blocksCountFieldSpecified = value;
            }
        }
        
        /// <summary>
        /// Общо спектър (MHz)
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=16)]
        [System.ComponentModel.DescriptionAttribute("Общо спектър (MHz)")]
        public decimal TotalSpectrum {
            get {
                return this.totalSpectrumField;
            }
            set {
                this.totalSpectrumField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TotalSpectrumSpecified {
            get {
                return this.totalSpectrumFieldSpecified;
            }
            set {
                this.totalSpectrumFieldSpecified = value;
            }
        }
        
        /// <summary>
        /// Тип на мрежа
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=17)]
        [System.ComponentModel.DescriptionAttribute("Тип на мрежа")]
        public string NetworkType {
            get {
                return this.networkTypeField;
            }
            set {
                this.networkTypeField = value;
            }
        }
        
        /// <summary>
        /// Честотна лента
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=18)]
        [System.ComponentModel.DescriptionAttribute("Честотна лента")]
        public string FrequencyBandwidth {
            get {
                return this.frequencyBandwidthField;
            }
            set {
                this.frequencyBandwidthField = value;
            }
        }
        
        /// <summary>
        /// Носеща честота
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=19)]
        [System.ComponentModel.DescriptionAttribute("Носеща честота")]
        public string MainFrequency {
            get {
                return this.mainFrequencyField;
            }
            set {
                this.mainFrequencyField = value;
            }
        }
        
        /// <summary>
        /// Териториален обхват
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=20)]
        [System.ComponentModel.DescriptionAttribute("Териториален обхват")]
        public string TerritorialScope {
            get {
                return this.territorialScopeField;
            }
            set {
                this.territorialScopeField = value;
            }
        }
        
        /// <summary>
        /// Местоположение
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=21)]
        [System.ComponentModel.DescriptionAttribute("Местоположение")]
        public string Location {
            get {
                return this.locationField;
            }
            set {
                this.locationField = value;
            }
        }
        
        /// <summary>
        /// Честота на предаване
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=22)]
        [System.ComponentModel.DescriptionAttribute("Честота на предаване")]
        public string TransmissionFrequency {
            get {
                return this.transmissionFrequencyField;
            }
            set {
                this.transmissionFrequencyField = value;
            }
        }
        
        /// <summary>
        /// Честотна лента на предаване
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=23)]
        [System.ComponentModel.DescriptionAttribute("Честотна лента на предаване")]
        public string TransmissionBandwidth {
            get {
                return this.transmissionBandwidthField;
            }
            set {
                this.transmissionBandwidthField = value;
            }
        }
        
        /// <summary>
        /// Честотна лента на получаване
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=24)]
        [System.ComponentModel.DescriptionAttribute("Честотна лента на получаване")]
        public string ReceptionBandwidth {
            get {
                return this.receptionBandwidthField;
            }
            set {
                this.receptionBandwidthField = value;
            }
        }
        
        /// <summary>
        /// Статус
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=25)]
        [System.ComponentModel.DescriptionAttribute("Статус")]
        public string Status {
            get {
                return this.statusField;
            }
            set {
                this.statusField = value;
            }
        }
    }
}