using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace RegiX.Info.Infrastructure.Models
{
    public class Records
    {
        [XmlElement("Record")]
        public List<Record> Record { get; set; }

        public DateTime RefreshedTime { get; set; }
    }
}