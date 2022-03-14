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
    public class EnumValue
    {
        private string displayTextField;

        private byte identifierTypeField;

        private bool identifierTypeFieldSpecified;

        private string valueField;

        [XmlElementAttribute(Order = 0)]
        public string Value
        {
            get => valueField;
            set => valueField = value;
        }

        [XmlElementAttribute(Order = 1)]
        public string DisplayText
        {
            get => displayTextField;
            set => displayTextField = value;
        }

        [XmlElementAttribute(Order = 2)]
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
    }
}