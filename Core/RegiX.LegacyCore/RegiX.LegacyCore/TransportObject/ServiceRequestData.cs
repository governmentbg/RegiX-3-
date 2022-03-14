using System;
using System.Xml;
using System.Xml.Serialization;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.Utils;

namespace TechnoLogica.RegiX.LegacyCore.TransportObject
{
    [Serializable]
    public class ServiceRequestData<T> //: IServiceRequestData
        where T : class
    {
        [XmlElement]
        public T Argument { get; set; }

        [XmlElement]
        public string EIDToken { get; set; }

        [XmlElement]
        public CallContext CallContext { get; set; }

        [XmlElement]
        public string EmployeeEGN { get; set; }

        [XmlElement]
        public string CitizenEGN { get; set; }

        [XmlElement]
        public string CallbackURL { get; set; }

        [XmlElement]
        public bool SignResult { get; set; }

        [XmlElement]
        public bool ReturnAccessMatrix { get; set; }

        public void SetArgument(XmlElement argument)
        {
            if (argument != null)
            {
                try
                {
                    object deserializedArgument = argument.Deserialize(typeof(T));
                    Argument = deserializedArgument as T;
                }
                catch
                {
                    throw new ArgumentException(StringResources.InvalidArgumentRequestArgument);
                }
            }
            else
            {
                throw new ArgumentException(StringResources.InvalidArgumentRequestArgument);
            }
        }
    }

    /// <summary>
    /// Обект за заявяка за изпълнение на операция
    /// </summary>
    [Serializable]
    public class ServiceRequestData
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
                return Operation.Substring(Operation.LastIndexOf('.') + 1);
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
        public string CallContext { get; set; }

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

        public CallContext GetCallContext()
        {
            return new CallContext() { Remark = this.CallContext };
        }
    }

    
}
