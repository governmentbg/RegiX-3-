using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace TechnoLogica.RegiX.LegacyCore.TransportObject
{
    /// <summary>
    /// Заявка за получаване на резултат, при асинхронни заявки
    /// </summary>
    [Serializable]
    public class ServiceCheckResultArgument
    {
        /// <summary>
        /// Идентификатор на пусната вече асинхронна заявка. Този идентификатор е един от елементите на резултата от извикване на Execute
        /// </summary>
        [XmlElement]
        public decimal ServiceCallID { get; set; }
    }
}
