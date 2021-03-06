// ------------------------------------------------------------------------------
//  <auto-generated>
//    Generated by Xsd2Code. Version 3.4.0.20336
//    <NameSpace>TechnoLogica.RegiX.NRAPublicDebtsCollectionAdapter</NameSpace><Collection>List</Collection><codeType>CSharp</codeType><EnableDataBinding>False</EnableDataBinding><EnableLazyLoading>False</EnableLazyLoading><TrackingChangesEnable>False</TrackingChangesEnable><GenTrackingClasses>False</GenTrackingClasses><HidePrivateFieldInIDE>False</HidePrivateFieldInIDE><EnableSummaryComment>True</EnableSummaryComment><VirtualProp>False</VirtualProp><IncludeSerializeMethod>False</IncludeSerializeMethod><UseBaseClass>False</UseBaseClass><GenBaseClass>False</GenBaseClass><GenerateCloneMethod>False</GenerateCloneMethod><GenerateDataContracts>False</GenerateDataContracts><CodeBaseTag>Net40</CodeBaseTag><SerializeMethodName>Serialize</SerializeMethodName><DeserializeMethodName>Deserialize</DeserializeMethodName><SaveToFileMethodName>SaveToFile</SaveToFileMethodName><LoadFromFileMethodName>LoadFromFile</LoadFromFileMethodName><GenerateXMLAttributes>True</GenerateXMLAttributes><EnableEncoding>False</EnableEncoding><AutomaticProperties>False</AutomaticProperties><GenerateShouldSerialize>False</GenerateShouldSerialize><DisableDebug>False</DisableDebug><PropNameSpecified>Default</PropNameSpecified><Encoder>UTF8</Encoder><CustomUsings></CustomUsings><ExcludeIncludedTypes>True</ExcludeIncludedTypes><EnableInitializeFields>True</EnableInitializeFields>
//  </auto-generated>
// ------------------------------------------------------------------------------
namespace TechnoLogica.RegiX.NRAPublicDebtsCollectionAdapter {
    using System;
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System.Collections;
    using System.Xml.Schema;
    using System.ComponentModel;
    using System.Collections.Generic;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.18956")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/NRA/PublicDebtsCollection/SendDataForCollectionAdditionToIOR" +
        "equest")]
    [System.Xml.Serialization.XmlRootAttribute("SendDataForCollectionAdditionToIORequest", Namespace="http://egov.bg/RegiX/NRA/PublicDebtsCollection/SendDataForCollectionAdditionToIOR" +
        "equest", IsNullable=false)]
    public partial class SendDataForCollectionAdditionToIORequestType {
        
        private IOCollectionAdditionType ioField;
        
        private CollectionType collectionField;
        
        /// <summary>
        /// SendDataForCollectionAdditionToIORequestType class constructor
        /// </summary>
        public SendDataForCollectionAdditionToIORequestType() {
            this.collectionField = new CollectionType();
            this.ioField = new IOCollectionAdditionType();
        }
        
        /// <summary>
        /// ???????????????????????? ?????????????????? (????)
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        [System.ComponentModel.DescriptionAttribute("???????????????????????? ?????????????????? (????)")]
        public IOCollectionAdditionType IO {
            get {
                return this.ioField;
            }
            set {
                this.ioField = value;
            }
        }
        
        /// <summary>
        /// ??????????????
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        [System.ComponentModel.DescriptionAttribute("??????????????")]
        public CollectionType Collection {
            get {
                return this.collectionField;
            }
            set {
                this.collectionField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.18956")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/NRA/PublicDebtsCollection/SendDataForCollectionAdditionToIOR" +
        "equest")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://egov.bg/RegiX/NRA/PublicDebtsCollection/SendDataForCollectionAdditionToIOR" +
        "equest", IsNullable=true)]
    public partial class IOCollectionAdditionType {
        
        private long actIssurerIDField;
        
        private long subdivisionIDField;
        
        private long titulIDField;
        
        private string subdivisionEIKField;
        
        /// <summary>
        /// ID ???? ??????????????????/????????????????????????????
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        [System.ComponentModel.DescriptionAttribute("ID ???? ??????????????????/????????????????????????????")]
        public long ActIssurerID {
            get {
                return this.actIssurerIDField;
            }
            set {
                this.actIssurerIDField = value;
            }
        }
        
        /// <summary>
        /// ID ???? ??????????????????????????
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        [System.ComponentModel.DescriptionAttribute("ID ???? ??????????????????????????")]
        public long SubdivisionID {
            get {
                return this.subdivisionIDField;
            }
            set {
                this.subdivisionIDField = value;
            }
        }
        
        /// <summary>
        /// ID ???? ????
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        [System.ComponentModel.DescriptionAttribute("ID ???? ????")]
        public long TitulID {
            get {
                return this.titulIDField;
            }
            set {
                this.titulIDField = value;
            }
        }
        
        /// <summary>
        /// ?????????????????????????? ???? ??????????????????/????????????????????????????
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        [System.ComponentModel.DescriptionAttribute("?????????????????????????? ???? ??????????????????/????????????????????????????")]
        public string SubdivisionEIK {
            get {
                return this.subdivisionEIKField;
            }
            set {
                this.subdivisionEIKField = value;
            }
        }
    }
}
