// ------------------------------------------------------------------------------
//  <auto-generated>
//    Generated by Xsd2Code. Version 3.4.0.29837
//    <NameSpace>Infosys.RegiX.CRCAdapter</NameSpace><Collection>List</Collection><codeType>CSharp</codeType><EnableDataBinding>False</EnableDataBinding><EnableLazyLoading>False</EnableLazyLoading><TrackingChangesEnable>False</TrackingChangesEnable><GenTrackingClasses>False</GenTrackingClasses><HidePrivateFieldInIDE>False</HidePrivateFieldInIDE><EnableSummaryComment>True</EnableSummaryComment><VirtualProp>False</VirtualProp><IncludeSerializeMethod>False</IncludeSerializeMethod><UseBaseClass>False</UseBaseClass><GenBaseClass>False</GenBaseClass><GenerateCloneMethod>False</GenerateCloneMethod><GenerateDataContracts>False</GenerateDataContracts><CodeBaseTag>Net40</CodeBaseTag><SerializeMethodName>Serialize</SerializeMethodName><DeserializeMethodName>Deserialize</DeserializeMethodName><SaveToFileMethodName>SaveToFile</SaveToFileMethodName><LoadFromFileMethodName>LoadFromFile</LoadFromFileMethodName><GenerateXMLAttributes>True</GenerateXMLAttributes><EnableEncoding>False</EnableEncoding><AutomaticProperties>False</AutomaticProperties><GenerateShouldSerialize>False</GenerateShouldSerialize><DisableDebug>False</DisableDebug><PropNameSpecified>Default</PropNameSpecified><Encoder>UTF8</Encoder><CustomUsings></CustomUsings><ExcludeIncludedTypes>True</ExcludeIncludedTypes><EnableInitializeFields>True</EnableInitializeFields>
//  </auto-generated>
// ------------------------------------------------------------------------------
namespace Infosys.RegiX.CRCAdapter {
    using System;
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System.Collections;
    using System.Xml.Schema;
    using System.ComponentModel;
    using System.Collections.Generic;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.29838")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/CRC/CRCFindAllResponse")]
    [System.Xml.Serialization.XmlRootAttribute("CRCFindAllResponse", Namespace="http://egov.bg/RegiX/CRC/CRCFindAllResponse", IsNullable=false)]
    public partial class CRCFindAllResponseType {
        
        private List<CRCFindAllElementType> measurementField;
        
        /// <summary>
        /// CRCFindAllResponseType class constructor
        /// </summary>
        public CRCFindAllResponseType() {
            this.measurementField = new List<CRCFindAllElementType>();
        }
        
        [System.Xml.Serialization.XmlElementAttribute("Measurement", Order=0)]
        public List<CRCFindAllElementType> Measurement {
            get {
                return this.measurementField;
            }
            set {
                this.measurementField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.29838")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/CRC/CRCFindAllResponse")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://egov.bg/RegiX/CRC/CRCFindAllResponse", IsNullable=true)]
    public partial class CRCFindAllElementType {
        
        private long uIDField;
        
        private string codeField;
        
        private string statusField;
        
        private string ipField;
        
        private string cityField;
        
        private string regionField;
        
        private string providerField;
        
        private string networkTypeField;
        
        private string platformField;
        
        private string modelField;
        
        private string hostnameField;
        
        private string geoLocationField;
        
        private string testUuidField;
        
        private string clientUuidField;
        
        private string openTestUuidField;
        
        private byte testDurationField;
        
        private long speedUploadField;
        
        private bool speedUploadFieldSpecified;
        
        private long speedDownloadField;
        
        private bool speedDownloadFieldSpecified;
        
        private long pingField;
        
        private bool pingFieldSpecified;
        
        private int signalStrengthField;
        
        private bool signalStrengthFieldSpecified;
        
        private short packetLossField;
        
        private bool packetLossFieldSpecified;
        
        private string modelVersionField;
        
        private string blockedPortsField;
        
        private System.DateTime timeField;
        
        private string loopModeLoopUidField;
        
        private int loopModeUidField;
        
        private bool loopModeUidFieldSpecified;
        
        private string networkTypeGroupField;
        
        private string iMEIField;
        
        /// <summary>
        /// UID
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        [System.ComponentModel.DescriptionAttribute("UID")]
        public long UID {
            get {
                return this.uIDField;
            }
            set {
                this.uIDField = value;
            }
        }
        
        /// <summary>
        /// Код на тип измерване
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        [System.ComponentModel.DescriptionAttribute("Код на тип измерване")]
        public string Code {
            get {
                return this.codeField;
            }
            set {
                this.codeField = value;
            }
        }
        
        /// <summary>
        /// Статус
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        [System.ComponentModel.DescriptionAttribute("Статус")]
        public string Status {
            get {
                return this.statusField;
            }
            set {
                this.statusField = value;
            }
        }
        
        /// <summary>
        /// IP адрес (анонимизиран)
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        [System.ComponentModel.DescriptionAttribute("IP адрес (анонимизиран)")]
        public string IP {
            get {
                return this.ipField;
            }
            set {
                this.ipField = value;
            }
        }
        
        /// <summary>
        /// Населено място
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        [System.ComponentModel.DescriptionAttribute("Населено място")]
        public string City {
            get {
                return this.cityField;
            }
            set {
                this.cityField = value;
            }
        }
        
        /// <summary>
        /// Адм. област
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        [System.ComponentModel.DescriptionAttribute("Адм. област")]
        public string Region {
            get {
                return this.regionField;
            }
            set {
                this.regionField = value;
            }
        }
        
        /// <summary>
        /// Доставчик
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        [System.ComponentModel.DescriptionAttribute("Доставчик")]
        public string Provider {
            get {
                return this.providerField;
            }
            set {
                this.providerField = value;
            }
        }
        
        /// <summary>
        /// Тип достъп
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        [System.ComponentModel.DescriptionAttribute("Тип достъп")]
        public string NetworkType {
            get {
                return this.networkTypeField;
            }
            set {
                this.networkTypeField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public string Platform {
            get {
                return this.platformField;
            }
            set {
                this.platformField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        public string Model {
            get {
                return this.modelField;
            }
            set {
                this.modelField = value;
            }
        }
        
        /// <summary>
        /// DNS
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
        [System.ComponentModel.DescriptionAttribute("DNS")]
        public string Hostname {
            get {
                return this.hostnameField;
            }
            set {
                this.hostnameField = value;
            }
        }
        
        /// <summary>
        /// Геолокация
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=11)]
        [System.ComponentModel.DescriptionAttribute("Геолокация")]
        public string GeoLocation {
            get {
                return this.geoLocationField;
            }
            set {
                this.geoLocationField = value;
            }
        }
        
        /// <summary>
        /// Test UUID
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=12)]
        [System.ComponentModel.DescriptionAttribute("Test UUID")]
        public string TestUuid {
            get {
                return this.testUuidField;
            }
            set {
                this.testUuidField = value;
            }
        }
        
        /// <summary>
        /// Client UUID
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=13)]
        [System.ComponentModel.DescriptionAttribute("Client UUID")]
        public string ClientUuid {
            get {
                return this.clientUuidField;
            }
            set {
                this.clientUuidField = value;
            }
        }
        
        /// <summary>
        /// Open Test UUID
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=14)]
        [System.ComponentModel.DescriptionAttribute("Open Test UUID")]
        public string OpenTestUuid {
            get {
                return this.openTestUuidField;
            }
            set {
                this.openTestUuidField = value;
            }
        }
        
        /// <summary>
        /// Времетраене на измерването (секунди)
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=15)]
        [System.ComponentModel.DescriptionAttribute("Времетраене на измерването (секунди)")]
        public byte TestDuration {
            get {
                return this.testDurationField;
            }
            set {
                this.testDurationField = value;
            }
        }
        
        /// <summary>
        /// Измерена скорост на качване
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=16)]
        [System.ComponentModel.DescriptionAttribute("Измерена скорост на качване")]
        public long SpeedUpload {
            get {
                return this.speedUploadField;
            }
            set {
                this.speedUploadField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SpeedUploadSpecified {
            get {
                return this.speedUploadFieldSpecified;
            }
            set {
                this.speedUploadFieldSpecified = value;
            }
        }
        
        /// <summary>
        /// Измерена скорост на сваляне
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=17)]
        [System.ComponentModel.DescriptionAttribute("Измерена скорост на сваляне")]
        public long SpeedDownload {
            get {
                return this.speedDownloadField;
            }
            set {
                this.speedDownloadField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SpeedDownloadSpecified {
            get {
                return this.speedDownloadFieldSpecified;
            }
            set {
                this.speedDownloadFieldSpecified = value;
            }
        }
        
        /// <summary>
        /// Закъснение
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=18)]
        [System.ComponentModel.DescriptionAttribute("Закъснение")]
        public long Ping {
            get {
                return this.pingField;
            }
            set {
                this.pingField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PingSpecified {
            get {
                return this.pingFieldSpecified;
            }
            set {
                this.pingFieldSpecified = value;
            }
        }
        
        /// <summary>
        /// Сила на сигнала
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=19)]
        [System.ComponentModel.DescriptionAttribute("Сила на сигнала")]
        public int SignalStrength {
            get {
                return this.signalStrengthField;
            }
            set {
                this.signalStrengthField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SignalStrengthSpecified {
            get {
                return this.signalStrengthFieldSpecified;
            }
            set {
                this.signalStrengthFieldSpecified = value;
            }
        }
        
        /// <summary>
        /// Загуба на пакети
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=20)]
        [System.ComponentModel.DescriptionAttribute("Загуба на пакети")]
        public short PacketLoss {
            get {
                return this.packetLossField;
            }
            set {
                this.packetLossField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PacketLossSpecified {
            get {
                return this.packetLossFieldSpecified;
            }
            set {
                this.packetLossFieldSpecified = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=21)]
        public string ModelVersion {
            get {
                return this.modelVersionField;
            }
            set {
                this.modelVersionField = value;
            }
        }
        
        /// <summary>
        /// Блокирани портове
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=22)]
        [System.ComponentModel.DescriptionAttribute("Блокирани портове")]
        public string BlockedPorts {
            get {
                return this.blockedPortsField;
            }
            set {
                this.blockedPortsField = value;
            }
        }
        
        /// <summary>
        /// Дата на измерване
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=23)]
        [System.ComponentModel.DescriptionAttribute("Дата на измерване")]
        public System.DateTime Time {
            get {
                return this.timeField;
            }
            set {
                this.timeField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=24)]
        public string LoopModeLoopUid {
            get {
                return this.loopModeLoopUidField;
            }
            set {
                this.loopModeLoopUidField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=25)]
        public int LoopModeUid {
            get {
                return this.loopModeUidField;
            }
            set {
                this.loopModeUidField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool LoopModeUidSpecified {
            get {
                return this.loopModeUidFieldSpecified;
            }
            set {
                this.loopModeUidFieldSpecified = value;
            }
        }
        
        /// <summary>
        /// Вид мрежа
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=26)]
        [System.ComponentModel.DescriptionAttribute("Вид мрежа")]
        public string NetworkTypeGroup {
            get {
                return this.networkTypeGroupField;
            }
            set {
                this.networkTypeGroupField = value;
            }
        }
        
        /// <summary>
        /// IMEI
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=27)]
        [System.ComponentModel.DescriptionAttribute("IMEI")]
        public string IMEI {
            get {
                return this.iMEIField;
            }
            set {
                this.iMEIField = value;
            }
        }
    }
}