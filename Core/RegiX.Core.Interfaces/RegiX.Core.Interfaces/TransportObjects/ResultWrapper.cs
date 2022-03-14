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
    /// Обект използван за опаковане на резултатие от изпълнение на заявка
    /// </summary>    
    [XmlRoot("ResultWrapper", Namespace = "http://egov.bg/RegiX/SignedData")]
    [XmlType(Namespace = "http://egov.bg/RegiX/SignedData")]
    public class ResultWrapper
    {
        /// <summary>
        /// Резултат от изпълнение на заявката
        /// </summary>
        [XmlElement(ElementName = "ServiceResultData")]
        public ServiceResultData Result { get; set; }
    }
}
