using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Xml.Serialization;
using TechnoLogica.RegiX.Common.DataContracts;

namespace TechnoLogica.RegiX.LegacyCore.TransportObject
{
    /// <summary>
    /// Резултат, при асинхронно извикване
    /// </summary>
    [Serializable]
//    [MessageContract(IsWrapped =false)]
    public class ServiceExecuteResult : IErrorInfo
    {
        /// <summary>
        /// Идентификатор на подаден заявка, с който в последствие може да се получи резултата
        /// </summary>
        [XmlElement]
        public decimal ServiceCallID { get; set; }

        /// <summary>
        /// Указва дали е възникнала грешка
        /// </summary>
        [XmlElement]
        public bool HasError { get; set; }


        private string _error;

        /// <summary>
        /// Съобщение за грешка. Setting this propery automatically sets the HasError property to true
        /// </summary>
        [XmlElement(IsNullable=true)]
        public string Error
        {
            get
            {
                return _error;
            }
            set
            {
                _error = value;
                HasError = true;
            }
        }
    }
}
