using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Xml.Serialization;

namespace TechnoLogica.RegiX.Common.Metadata.AdapterOperations
{
    [GeneratedCode("Xsd2Code", "3.4.0.30000")]
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://egov.bg/RegiX/RegiXClientMetadata")]
    [XmlRootAttribute(Namespace = "http://egov.bg/RegiX/RegiXClientMetadata", IsNullable = true)]
    public class ParameterType
    {
        private List<EnumValue> enumValuesField;

        private string typeField;

        /// <summary>
        ///     ParameterType class constructor
        /// </summary>
        public ParameterType()
        {
            enumValuesField = new List<EnumValue>();
        }

        [XmlElementAttribute(Order = 0)]
        public string Type
        {
            get => typeField;
            set => typeField = value;
        }

        [XmlArrayAttribute(Order = 1)]
        [XmlArrayItemAttribute(IsNullable = false)]
        public List<EnumValue> EnumValues
        {
            get => enumValuesField;
            set => enumValuesField = value;
        }
    }
}
