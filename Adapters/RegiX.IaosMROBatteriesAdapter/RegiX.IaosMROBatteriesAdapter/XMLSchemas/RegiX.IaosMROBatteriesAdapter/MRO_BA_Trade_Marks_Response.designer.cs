// ------------------------------------------------------------------------------
//  <auto-generated>
//    Generated by Xsd2Code. Version 3.4.0.30983
//    <NameSpace>TechnoLogica.RegiX.IaosMROBatteriesAdapter</NameSpace><Collection>List</Collection><codeType>CSharp</codeType><EnableDataBinding>False</EnableDataBinding><EnableLazyLoading>False</EnableLazyLoading><TrackingChangesEnable>False</TrackingChangesEnable><GenTrackingClasses>False</GenTrackingClasses><HidePrivateFieldInIDE>False</HidePrivateFieldInIDE><EnableSummaryComment>True</EnableSummaryComment><VirtualProp>False</VirtualProp><IncludeSerializeMethod>False</IncludeSerializeMethod><UseBaseClass>False</UseBaseClass><GenBaseClass>False</GenBaseClass><GenerateCloneMethod>False</GenerateCloneMethod><GenerateDataContracts>False</GenerateDataContracts><CodeBaseTag>Net40</CodeBaseTag><SerializeMethodName>Serialize</SerializeMethodName><DeserializeMethodName>Deserialize</DeserializeMethodName><SaveToFileMethodName>SaveToFile</SaveToFileMethodName><LoadFromFileMethodName>LoadFromFile</LoadFromFileMethodName><GenerateXMLAttributes>True</GenerateXMLAttributes><EnableEncoding>False</EnableEncoding><AutomaticProperties>False</AutomaticProperties><GenerateShouldSerialize>False</GenerateShouldSerialize><DisableDebug>False</DisableDebug><PropNameSpecified>Default</PropNameSpecified><Encoder>UTF8</Encoder><CustomUsings></CustomUsings><ExcludeIncludedTypes>True</ExcludeIncludedTypes><EnableInitializeFields>True</EnableInitializeFields>
//  </auto-generated>
// ------------------------------------------------------------------------------
namespace TechnoLogica.RegiX.IaosMROBatteriesAdapter {
    using System;
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System.Collections;
    using System.Xml.Schema;
    using System.ComponentModel;
    using System.Collections.Generic;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.32413")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/IAOS/MROBatteries/TradeMarksResponse")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://egov.bg/RegiX/IAOS/MROBatteries/TradeMarksResponse", IsNullable=false)]
    public partial class MRO_BA_Trade_Marks_Response {
        
        private AuthorizationTradeMarks authorizationField;
        
        /// <summary>
        /// MRO_BA_Trade_Marks_Response class constructor
        /// </summary>
        public MRO_BA_Trade_Marks_Response() {
            this.authorizationField = new AuthorizationTradeMarks();
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public AuthorizationTradeMarks Authorization {
            get {
                return this.authorizationField;
            }
            set {
                this.authorizationField = value;
            }
        }
    }
    
    /// <summary>
    /// Търговски марки
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.32413")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/IAOS/MROBatteries/TradeMarksResponse")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://egov.bg/RegiX/IAOS/MROBatteries/TradeMarksResponse", IsNullable=true)]
    [System.ComponentModel.DescriptionAttribute("Търговски марки")]
    public partial class AuthorizationTradeMarks {
        
        private string companyNameField;
        
        private string eIKField;
        
        private AuthorizationTradeMarksTradeMarks tradeMarksField;
        
        /// <summary>
        /// AuthorizationTradeMarks class constructor
        /// </summary>
        public AuthorizationTradeMarks() {
            this.tradeMarksField = new AuthorizationTradeMarksTradeMarks();
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string CompanyName {
            get {
                return this.companyNameField;
            }
            set {
                this.companyNameField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(DataType="integer", Order=1)]
        public string EIK {
            get {
                return this.eIKField;
            }
            set {
                this.eIKField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public AuthorizationTradeMarksTradeMarks TradeMarks {
            get {
                return this.tradeMarksField;
            }
            set {
                this.tradeMarksField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.32413")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://egov.bg/RegiX/IAOS/MROBatteries/TradeMarksResponse")]
    public partial class AuthorizationTradeMarksTradeMarks {
        
        private List<string> tradeMarkField;
        
        /// <summary>
        /// AuthorizationTradeMarksTradeMarks class constructor
        /// </summary>
        public AuthorizationTradeMarksTradeMarks() {
            this.tradeMarkField = new List<string>();
        }
        
        [System.Xml.Serialization.XmlElementAttribute("TradeMark", Order=0)]
        public List<string> TradeMark {
            get {
                return this.tradeMarkField;
            }
            set {
                this.tradeMarkField = value;
            }
        }
    }
}
