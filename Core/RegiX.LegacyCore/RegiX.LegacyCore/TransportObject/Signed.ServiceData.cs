using System;
using System.Xml;
using System.Xml.Serialization;
using TechnoLogica.RegiX.Common.DataContracts;

namespace TechnoLogica.RegiX.LegacyCore.TransportObject.Signed
{
    /// <summary>
    /// Обект, който се връща като резултат
    /// </summary>
    [Serializable]
    public class ServiceResultData : IErrorInfo
    {        
        private string _error;

        /// <summary>
        /// Указва, дали са получени данни от Първичния регистър
        /// </summary>
        [XmlElement]
        public bool IsReady { get; set; }

        /// <summary>
        /// Данни, които връща операцията. Тук има данни, при HasError=false и IsReady=true
        /// </summary>
        [XmlElement(IsNullable = true)]
        public DataContainer Data { get; set; }

        /// <summary>
        /// Подпис, върху контейнера с данни
        /// </summary>
        [XmlAnyElement(Name = "Signature", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        public XmlElement Signature { get; set; }

        /// <summary>
        /// Указва дали е възникнала грешка при изпълнение на операцията
        /// </summary>
        [XmlElement]
        public bool HasError { get; set; }

        /// <summary>
        /// Съобщение за грешка. При HasError=true
        /// </summary>
        [XmlElement(IsNullable = true)]
        public string Error
        {
            get
            {
                return _error;
            }
            set
            {
                _error = value;
                HasError = !string.IsNullOrEmpty(_error);
            }
        }
        
        /// <summary>
        /// Идентификатор на подаден заявка, с който в последствие може да се получи резултата
        /// </summary>
        [XmlElement]
        public decimal ServiceCallID { get; set; }
    }

    /// <summary>
    /// Обект за заявяка за изпълнение на операция
    /// </summary>
    [Serializable]
    public class ServiceRequestData //: TransportObjectV2.IServiceRequestData
    {
        /// <summary>
        /// Име на извикваната операция. За повече информация за иментата на операциите http://regixaisweb.egov.bg/regixinfo/. 
        /// Пример: "TechnoLogica.RegiX.GraoNBDAdapter.APIService.INBDAPI.ValidPersonSearch"
        /// </summary>
        [XmlElement]
        public string Operation { get; set; }

        [XmlIgnore]
        public string Contract
        {
            get
            {
                if (!String.IsNullOrEmpty(Operation))
                {
                    try
                    {
                        return Operation.Substring(0, Operation.LastIndexOf('.'));
                    }
                    catch
                    {
                        throw new ArgumentException(StringResources.InvalidArgumentOperation);
                    }
                }
                else
                {
                    throw new ArgumentException(StringResources.InvalidArgumentOperation);
                }
            }
        }

        [XmlIgnore]
        public string OperationName
        {
            get
            {
                try
                {
                    return Operation.Substring(Operation.LastIndexOf('.') + 1);
                }
                catch
                {
                    throw new ArgumentException(StringResources.InvalidArgumentOperation);
                }
            }
        }

        /// <summary>
        /// XML съдържание на заявката. За повече информация за структурата(xsd) на заявките за различните операции: http://regixaisweb.egov.bg/regixinfo/.
        /// Важно е да се знае, че елементите трябва да са qualified, т.е. да включват namespace от схемата за избраната операция
        /// </summary>
        [XmlElement]
        public XmlElement Argument { get; set; }

        /// <summary>
        /// Идентификатор за електронна идентичност(получен от http://eid.egov.bg/)
        /// </summary>
        [XmlElement(IsNullable = true)]
        public string EIDToken { get; set; }

        /// <summary>
        /// Контекст, в който се прави извикване. Запазва се в логовете на RegiX
        /// </summary>
        [XmlElement]
        public CallContext CallContext { get; set; }

        [XmlElement(IsNullable = true)]
        public string CallbackURL { get; set; }

        /// <summary>
        /// ЕГН на служителя, изпълняващ заявката. Не се запазва в логовете на RegiX, а директно се предава към Първичния регистър
        /// </summary>
        [XmlElement(IsNullable = true)]
        public string EmployeeEGN { get; set; }

        /// <summary>
        /// ЕГН на лицето, за който се прави справка, ако справката е за физическо лице. 
        /// Не се запазва в логовете на RegiX, а директно се предава към Първичния регистър
        /// </summary>
        [XmlElement(IsNullable = true)]
        public string CitizenEGN { get; set; }

        /// <summary>
        /// Указва дали резултата да бъде подписан след изготвянето му
        /// </summary>
        [XmlElement]
        public bool SignResult { get; set; }

        /// <summary>
        /// Указва дали да се върне матрицата за достъп, с която са получени данните, спрямо правата на консуматора
        /// </summary>
        [XmlElement]
        public bool ReturnAccessMatrix { get; set; }
    }
}
