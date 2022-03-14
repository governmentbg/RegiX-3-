// ------------------------------------------------------------------------------
//  <auto-generated>
//    Generated by Xsd2Code. Version 3.4.0.24467
//    <NameSpace>TechnoLogica.RegiX.MVRMPSAdapter</NameSpace><Collection>List</Collection><codeType>CSharp</codeType><EnableDataBinding>False</EnableDataBinding><EnableLazyLoading>False</EnableLazyLoading><TrackingChangesEnable>False</TrackingChangesEnable><GenTrackingClasses>False</GenTrackingClasses><HidePrivateFieldInIDE>False</HidePrivateFieldInIDE><EnableSummaryComment>True</EnableSummaryComment><VirtualProp>False</VirtualProp><IncludeSerializeMethod>False</IncludeSerializeMethod><UseBaseClass>False</UseBaseClass><GenBaseClass>False</GenBaseClass><GenerateCloneMethod>False</GenerateCloneMethod><GenerateDataContracts>False</GenerateDataContracts><CodeBaseTag>Net40</CodeBaseTag><SerializeMethodName>Serialize</SerializeMethodName><DeserializeMethodName>Deserialize</DeserializeMethodName><SaveToFileMethodName>SaveToFile</SaveToFileMethodName><LoadFromFileMethodName>LoadFromFile</LoadFromFileMethodName><GenerateXMLAttributes>True</GenerateXMLAttributes><EnableEncoding>False</EnableEncoding><AutomaticProperties>False</AutomaticProperties><GenerateShouldSerialize>False</GenerateShouldSerialize><DisableDebug>False</DisableDebug><PropNameSpecified>Default</PropNameSpecified><Encoder>UTF8</Encoder><CustomUsings></CustomUsings><ExcludeIncludedTypes>False</ExcludeIncludedTypes><EnableInitializeFields>True</EnableInitializeFields>
//  </auto-generated>
// ------------------------------------------------------------------------------
namespace TechnoLogica.RegiX.MVRMPSAdapter {
    using System;
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System.Collections;
    using System.Xml.Schema;
    using System.ComponentModel;
    using System.Collections.Generic;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.17198")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/MVR/MPS/MotorVehicleRegistrationResponse")]
    [System.Xml.Serialization.XmlRootAttribute("MotorVehicleRegistrationResponse", Namespace="http://egov.bg/RegiX/MVR/MPS/MotorVehicleRegistrationResponse", IsNullable=false)]
    public partial class MotorVehicleRegistrationResponseType {
        
        private ReturnInformation returnInformationField;
        
        private List<Vehicle> vehiclesField;
        
        /// <summary>
        /// MotorVehicleRegistrationResponseType class constructor
        /// </summary>
        public MotorVehicleRegistrationResponseType() {
            this.vehiclesField = new List<Vehicle>();
            this.returnInformationField = new ReturnInformation();
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public ReturnInformation ReturnInformation {
            get {
                return this.returnInformationField;
            }
            set {
                this.returnInformationField = value;
            }
        }
        
        [System.Xml.Serialization.XmlArrayAttribute(Order=1)]
        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable=false)]
        public List<Vehicle> Vehicles {
            get {
                return this.vehiclesField;
            }
            set {
                this.vehiclesField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.17198")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/MVR/MPS/MotorVehicleRegistrationResponse")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://egov.bg/RegiX/MVR/MPS/MotorVehicleRegistrationResponse", IsNullable=true)]
    public partial class ReturnInformation {
        
        private string returnCodeField;
        
        private string infoField;
        
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string ReturnCode {
            get {
                return this.returnCodeField;
            }
            set {
                this.returnCodeField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string Info {
            get {
                return this.infoField;
            }
            set {
                this.infoField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.17198")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/MVR/MPS/MotorVehicleRegistrationResponse")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://egov.bg/RegiX/MVR/MPS/MotorVehicleRegistrationResponse", IsNullable=true)]
    public partial class ForeignerPersonData {
        
        private string eGNField;
        
        private string lNChField;
        
        private string namesField;
        
        private string namesLatinField;
        
        private string genderNameField;
        
        private string genderNameLatinField;
        
        /// <summary>
        /// ЕГН
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        [System.ComponentModel.DescriptionAttribute("ЕГН")]
        public string EGN {
            get {
                return this.eGNField;
            }
            set {
                this.eGNField = value;
            }
        }
        
        /// <summary>
        /// ЛНЧ
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        [System.ComponentModel.DescriptionAttribute("ЛНЧ")]
        public string LNCh {
            get {
                return this.lNChField;
            }
            set {
                this.lNChField = value;
            }
        }
        
        /// <summary>
        /// Имена
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        [System.ComponentModel.DescriptionAttribute("Имена")]
        public string Names {
            get {
                return this.namesField;
            }
            set {
                this.namesField = value;
            }
        }
        
        /// <summary>
        /// Имена, изписани на латиница
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        [System.ComponentModel.DescriptionAttribute("Имена, изписани на латиница")]
        public string NamesLatin {
            get {
                return this.namesLatinField;
            }
            set {
                this.namesLatinField = value;
            }
        }
        
        /// <summary>
        /// Наименование на пол
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        [System.ComponentModel.DescriptionAttribute("Наименование на пол")]
        public string GenderName {
            get {
                return this.genderNameField;
            }
            set {
                this.genderNameField = value;
            }
        }
        
        /// <summary>
        /// Наименование на пол на латиница
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        [System.ComponentModel.DescriptionAttribute("Наименование на пол на латиница")]
        public string GenderNameLatin {
            get {
                return this.genderNameLatinField;
            }
            set {
                this.genderNameLatinField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.17198")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/MVR/MPS/MotorVehicleRegistrationResponse")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://egov.bg/RegiX/MVR/MPS/MotorVehicleRegistrationResponse", IsNullable=true)]
    public partial class EntityData {
        
        private string identifierField;
        
        private string nameField;
        
        private string nameLatinField;
        
        /// <summary>
        /// ЕИК/БУЛСТАТ
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        [System.ComponentModel.DescriptionAttribute("ЕИК/БУЛСТАТ")]
        public string Identifier {
            get {
                return this.identifierField;
            }
            set {
                this.identifierField = value;
            }
        }
        
        /// <summary>
        /// Фирмено име
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        [System.ComponentModel.DescriptionAttribute("Фирмено име")]
        public string Name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
        
        /// <summary>
        /// Фирмено име, изписано на латиница
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        [System.ComponentModel.DescriptionAttribute("Фирмено име, изписано на латиница")]
        public string NameLatin {
            get {
                return this.nameLatinField;
            }
            set {
                this.nameLatinField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.17198")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/MVR/MPS/MotorVehicleRegistrationResponse")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://egov.bg/RegiX/MVR/MPS/MotorVehicleRegistrationResponse", IsNullable=true)]
    public partial class PersonData {
        
        private string eGNField;
        
        private string firstNameField;
        
        private string surnameField;
        
        private string familyNameField;
        
        private string firstNameLatinField;
        
        private string surnameLatinField;
        
        private string lastNameLatinField;
        
        private System.DateTime birthDateField;
        
        private bool birthDateFieldSpecified;
        
        private string genderNameField;
        
        private string genderNameLatinField;
        
        /// <summary>
        /// ЕГН
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        [System.ComponentModel.DescriptionAttribute("ЕГН")]
        public string EGN {
            get {
                return this.eGNField;
            }
            set {
                this.eGNField = value;
            }
        }
        
        /// <summary>
        /// Собствено име
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        [System.ComponentModel.DescriptionAttribute("Собствено име")]
        public string FirstName {
            get {
                return this.firstNameField;
            }
            set {
                this.firstNameField = value;
            }
        }
        
        /// <summary>
        /// Бащино име
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        [System.ComponentModel.DescriptionAttribute("Бащино име")]
        public string Surname {
            get {
                return this.surnameField;
            }
            set {
                this.surnameField = value;
            }
        }
        
        /// <summary>
        /// Фамилно име
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        [System.ComponentModel.DescriptionAttribute("Фамилно име")]
        public string FamilyName {
            get {
                return this.familyNameField;
            }
            set {
                this.familyNameField = value;
            }
        }
        
        /// <summary>
        /// Собствено име, изписано на латиница
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        [System.ComponentModel.DescriptionAttribute("Собствено име, изписано на латиница")]
        public string FirstNameLatin {
            get {
                return this.firstNameLatinField;
            }
            set {
                this.firstNameLatinField = value;
            }
        }
        
        /// <summary>
        /// Бащино име, изписано на латиница
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        [System.ComponentModel.DescriptionAttribute("Бащино име, изписано на латиница")]
        public string SurnameLatin {
            get {
                return this.surnameLatinField;
            }
            set {
                this.surnameLatinField = value;
            }
        }
        
        /// <summary>
        /// Фамилно име, изписано на латиница
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        [System.ComponentModel.DescriptionAttribute("Фамилно име, изписано на латиница")]
        public string LastNameLatin {
            get {
                return this.lastNameLatinField;
            }
            set {
                this.lastNameLatinField = value;
            }
        }
        
        /// <summary>
        /// Дата на раждане
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        [System.ComponentModel.DescriptionAttribute("Дата на раждане")]
        public System.DateTime BirthDate {
            get {
                return this.birthDateField;
            }
            set {
                this.birthDateField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool BirthDateSpecified {
            get {
                return this.birthDateFieldSpecified;
            }
            set {
                this.birthDateFieldSpecified = value;
            }
        }
        
        /// <summary>
        /// Наименование на пол
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        [System.ComponentModel.DescriptionAttribute("Наименование на пол")]
        public string GenderName {
            get {
                return this.genderNameField;
            }
            set {
                this.genderNameField = value;
            }
        }
        
        /// <summary>
        /// Наименование на пол на латиница
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        [System.ComponentModel.DescriptionAttribute("Наименование на пол на латиница")]
        public string GenderNameLatin {
            get {
                return this.genderNameLatinField;
            }
            set {
                this.genderNameLatinField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.17198")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/MVR/MPS/MotorVehicleRegistrationResponse")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://egov.bg/RegiX/MVR/MPS/MotorVehicleRegistrationResponse", IsNullable=true)]
    public partial class Vehicle {
        
        private string vehicleRegistrationNumberField;
        
        private System.DateTime firstRegistrationDateField;
        
        private bool firstRegistrationDateFieldSpecified;
        
        private string motorVehicleRegistrationCertificateNumberField;
        
        private PersonData ownerPersonDataField;
        
        private EntityData ownerEntityDataField;
        
        private ForeignerPersonData ownerForeignerPersonDataField;
        
        private string motorVehicleTypeField;
        
        private string motorVehicleTypeLatinField;
        
        private string motorVehicleModelField;
        
        private string motorVehicleModelLatinField;
        
        private string motorVehicleModelTypeField;
        
        private string tradeDescriptionField;
        
        private string tradeDescriptionLatinField;
        
        private string vINNumberField;
        
        private System.DateTime issueDateField;
        
        private bool issueDateFieldSpecified;
        
        private string categoryField;
        
        private string colorField;
        
        private string colorLatinField;
        
        private string engineNumberField;
        
        private string colorSecondaryField;
        
        private string colorSecondaryLatinField;
        
        /// <summary>
        /// Vehicle class constructor
        /// </summary>
        public Vehicle() {
            this.ownerForeignerPersonDataField = new ForeignerPersonData();
            this.ownerEntityDataField = new EntityData();
            this.ownerPersonDataField = new PersonData();
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string VehicleRegistrationNumber {
            get {
                return this.vehicleRegistrationNumberField;
            }
            set {
                this.vehicleRegistrationNumberField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public System.DateTime FirstRegistrationDate {
            get {
                return this.firstRegistrationDateField;
            }
            set {
                this.firstRegistrationDateField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool FirstRegistrationDateSpecified {
            get {
                return this.firstRegistrationDateFieldSpecified;
            }
            set {
                this.firstRegistrationDateFieldSpecified = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string MotorVehicleRegistrationCertificateNumber {
            get {
                return this.motorVehicleRegistrationCertificateNumberField;
            }
            set {
                this.motorVehicleRegistrationCertificateNumberField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public PersonData OwnerPersonData {
            get {
                return this.ownerPersonDataField;
            }
            set {
                this.ownerPersonDataField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public EntityData OwnerEntityData {
            get {
                return this.ownerEntityDataField;
            }
            set {
                this.ownerEntityDataField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public ForeignerPersonData OwnerForeignerPersonData {
            get {
                return this.ownerForeignerPersonDataField;
            }
            set {
                this.ownerForeignerPersonDataField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public string MotorVehicleType {
            get {
                return this.motorVehicleTypeField;
            }
            set {
                this.motorVehicleTypeField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public string MotorVehicleTypeLatin {
            get {
                return this.motorVehicleTypeLatinField;
            }
            set {
                this.motorVehicleTypeLatinField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public string MotorVehicleModel {
            get {
                return this.motorVehicleModelField;
            }
            set {
                this.motorVehicleModelField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        public string MotorVehicleModelLatin {
            get {
                return this.motorVehicleModelLatinField;
            }
            set {
                this.motorVehicleModelLatinField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
        public string MotorVehicleModelType {
            get {
                return this.motorVehicleModelTypeField;
            }
            set {
                this.motorVehicleModelTypeField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=11)]
        public string TradeDescription {
            get {
                return this.tradeDescriptionField;
            }
            set {
                this.tradeDescriptionField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=12)]
        public string TradeDescriptionLatin {
            get {
                return this.tradeDescriptionLatinField;
            }
            set {
                this.tradeDescriptionLatinField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=13)]
        public string VINNumber {
            get {
                return this.vINNumberField;
            }
            set {
                this.vINNumberField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=14)]
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
        
        [System.Xml.Serialization.XmlElementAttribute(Order=15)]
        public string Category {
            get {
                return this.categoryField;
            }
            set {
                this.categoryField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=16)]
        public string Color {
            get {
                return this.colorField;
            }
            set {
                this.colorField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=17)]
        public string ColorLatin {
            get {
                return this.colorLatinField;
            }
            set {
                this.colorLatinField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=18)]
        public string EngineNumber {
            get {
                return this.engineNumberField;
            }
            set {
                this.engineNumberField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=19)]
        public string ColorSecondary {
            get {
                return this.colorSecondaryField;
            }
            set {
                this.colorSecondaryField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=20)]
        public string ColorSecondaryLatin {
            get {
                return this.colorSecondaryLatinField;
            }
            set {
                this.colorSecondaryLatinField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.17198")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/MVR/MPS/MotorVehicleRegistrationResponse")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://egov.bg/RegiX/MVR/MPS/MotorVehicleRegistrationResponse", IsNullable=true)]
    public partial class Vehicles {
        
        private List<Vehicle> vehicleField;
        
        /// <summary>
        /// Vehicles class constructor
        /// </summary>
        public Vehicles() {
            this.vehicleField = new List<Vehicle>();
        }
        
        [System.Xml.Serialization.XmlElementAttribute("Vehicle", Order=0)]
        public List<Vehicle> Vehicle {
            get {
                return this.vehicleField;
            }
            set {
                this.vehicleField = value;
            }
        }
    }
}