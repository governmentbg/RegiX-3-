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
    /// Обект използван за опаковане на аргумент за проверка на резултат от асинхронно изпълнение на заявка
    /// </summary>
    [XmlRoot("ServiceCheckResultWrapper", Namespace = "http://egov.bg/RegiX/SignedData")]
    [XmlType(Namespace = "http://egov.bg/RegiX/SignedData")]
    public class ServiceCheckResultWrapper
    {
        /// <summary>
        /// Данни за проверка на асинхронна заявка
        /// </summary>
        [XmlElement(ElementName = "ServiceCheckResultArgument")]
        public ServiceCheckResultArgument Request { get; set; }
    }
}
