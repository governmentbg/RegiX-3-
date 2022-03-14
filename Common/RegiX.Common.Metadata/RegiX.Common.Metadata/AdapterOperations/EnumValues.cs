using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace TechnoLogica.RegiX.Common.Metadata.AdapterOperations
{
    [GeneratedCode("Xsd2Code", "3.4.0.30000")]
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://egov.bg/RegiX/RegiXClientMetadata")]
    [XmlRootAttribute(Namespace = "http://egov.bg/RegiX/RegiXClientMetadata", IsNullable = true)]
    public class EnumValues
    {
        private List<EnumValue> enumValueField;

        /// <summary>
        ///     EnumValues class constructor
        /// </summary>
        public EnumValues()
        {
            enumValueField = new List<EnumValue>();
        }

        [XmlElementAttribute("EnumValue", Order = 0)]
        public List<EnumValue> EnumValue
        {
            get => enumValueField;
            set => enumValueField = value;
        }
    }
}