
using System.Xml.Serialization;

namespace RegiX.Info.Infrastructure.Models
{
    [XmlType("Record")]
    public class Record
    {
        [XmlElement(ElementName = "ConsumerAdministration")]
        public string ConsumerAdministration { get; set; }
        [XmlElement(ElementName = "ConsumerName")]
        public string ConsumerName { get; set; }
        [XmlElement(ElementName = "RegisterAdministration")]
        public string RegisterAdministration { get; set; }
        [XmlElement(ElementName = "RegisterName")]
        public string RegisterName { get; set; }
        [XmlElement(ElementName = "RecordsCount")]
        public int RecordsCount { get; set; }
       
    }
}