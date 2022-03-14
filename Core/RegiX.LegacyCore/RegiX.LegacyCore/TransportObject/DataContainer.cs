using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;

namespace TechnoLogica.RegiX.LegacyCore.TransportObject
{
    /// <summary>
    /// Data container (not typed)
    /// </summary>
    [Serializable]
    [XmlType]
    [XmlRoot(ElementName = "Data")]
    public class DataContainer
    {
        /// <summary>
        /// Data identifier attribute
        /// </summary>
        [XmlAttributeAttribute("id", DataType = "ID")]
        public string DataID = "data";

        /// <summary>
        /// Contains the request argument of the operation. It contains the data from
        /// the Argument property of the ServiceRequest object
        /// </summary>
        [XmlElement]
        public RequestContainer Request { get; set; }

        /// <summary>
        /// Contains the response accoring to the request argument and access matrix
        /// Additional information for the structure of the response see: http://regixaisweb.egov.bg/RegiXInfo
        /// </summary>
        [XmlElement]
        public ResponseContainer Response { get; set; }

        /// <summary>
        /// Access matrix. Describes the accessible properties of the response (depenes of the caller privileges)
        /// </summary>
        [XmlElement(IsNullable = true)]
        public DataAccessMatrix Matrix { get; set; }
    }
}
