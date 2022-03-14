using System;
using System.Xml.Serialization;

namespace TechnoLogica.RegiX.LegacyCore.TransportObject
{
    [Serializable()]
    [XmlType(Namespace = "http://egov.bg/RegiX/BinaryResponse")]
    [XmlRoot("BinaryArgument", Namespace = "http://egov.bg/RegiX/BinaryResponse", IsNullable = false)]
    public class BinaryResponse
    {
        [XmlElement]
        public byte[] Binary { get; set; }
    }
}
