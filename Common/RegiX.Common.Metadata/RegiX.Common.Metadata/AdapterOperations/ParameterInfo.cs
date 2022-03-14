using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Xml.Serialization;

namespace TechnoLogica.RegiX.Common.Metadata.AdapterOperations
{
    [GeneratedCode("Xsd2Code", "3.4.0.30000")]
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://egov.bg/RegiX/RegiXClientMetadata")]
    [XmlRootAttribute(Namespace = "http://egov.bg/RegiX/RegiXClientMetadata", IsNullable = true)]
    public class ParameterInfo
    {
        private byte identifierTypeField;

        private bool identifierTypeFieldSpecified;

        private bool isRequiredField;

        private bool isRequiredFieldSpecified;

        private bool isXmlElementField;

        private string namespaceField;

        private int orderNumberField;

        private bool orderNumberFieldSpecified;

        private string parameterLabelField;

        private string parameterNameField;

        private ParameterType parameterTypeField;

        private string regexExpressionField;

        /// <summary>
        ///     ParameterInfo class constructor
        /// </summary>
        public ParameterInfo()
        {
            parameterTypeField = new ParameterType();
        }

        [XmlElementAttribute(Order = 0)]
        public string ParameterName
        {
            get => parameterNameField;
            set => parameterNameField = value;
        }

        [XmlElementAttribute(Order = 1)]
        public string ParameterLabel
        {
            get => parameterLabelField;
            set => parameterLabelField = value;
        }

        [XmlElementAttribute(Order = 2)]
        public string RegexExpression
        {
            get => regexExpressionField;
            set => regexExpressionField = value;
        }

        [XmlElementAttribute(Order = 3)]
        public bool IsRequired
        {
            get => isRequiredField;
            set => isRequiredField = value;
        }

        [XmlIgnoreAttribute]
        public bool IsRequiredSpecified
        {
            get => isRequiredFieldSpecified;
            set => isRequiredFieldSpecified = value;
        }

        [XmlElementAttribute(Order = 4)]
        public bool IsXmlElement
        {
            get => isXmlElementField;
            set => isXmlElementField = value;
        }

        [XmlElementAttribute(Order = 5)]
        public int OrderNumber
        {
            get => orderNumberField;
            set => orderNumberField = value;
        }

        [XmlIgnoreAttribute]
        public bool OrderNumberSpecified
        {
            get => orderNumberFieldSpecified;
            set => orderNumberFieldSpecified = value;
        }

        [XmlElementAttribute(Order = 6)]
        public string Namespace
        {
            get => namespaceField;
            set => namespaceField = value;
        }

        [XmlElementAttribute(Order = 7)]
        public byte IdentifierType
        {
            get => identifierTypeField;
            set => identifierTypeField = value;
        }

        [XmlIgnoreAttribute]
        public bool IdentifierTypeSpecified
        {
            get => identifierTypeFieldSpecified;
            set => identifierTypeFieldSpecified = value;
        }

        [XmlElementAttribute(Order = 8)]
        public ParameterType ParameterType
        {
            get => parameterTypeField;
            set => parameterTypeField = value;
        }
    }
}