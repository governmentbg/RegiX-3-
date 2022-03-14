using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TechnoLogica.RegiX.Common.TransportObjects;

namespace TechnoLogica.RegiX.Core.Interfaces.TransportObjects
{
    /// <summary>
    /// Обект използван за опаковане на данните за заявката
    /// </summary>
    [XmlRoot("RequestWrapper", Namespace = "http://egov.bg/RegiX/SignedData")]
    [XmlType(Namespace = "http://egov.bg/RegiX/SignedData")]
    public class RequestWrapper
    {
        /// <summary>
        /// Данни за заявката
        /// </summary>
        [XmlElement(ElementName = "ServiceRequestData")]
        public ServiceRequestData Request { get; set; }
    }
}
