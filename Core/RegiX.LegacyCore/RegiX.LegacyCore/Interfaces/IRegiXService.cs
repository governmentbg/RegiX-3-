using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Technologica.WcfCustom;
using TechnoLogica.RegiX.LegacyCore.TransportObject;

namespace TechnoLogica.RegiX.LegacyCore.Interfaces
{
    /// <summary>
    /// Услуга съдържаща операции за работа с API услуги. Позволява синхронно и асинхронно изпълнение на произволни API услуги, които са част от RegiX
    /// </summary>
    [ServiceContract(Namespace = "http://egov.bg/RegiX")]
    [XmlSerializerFormat]
    [Documentation]
    public interface IRegiXService
    {
        /// <summary>
        /// Изпълнява заявката асинхронно
        /// </summary>
        /// <param name="request">Аргумент за изпълнение на заявка</param>
        /// <returns>Резултат от изпълнението на асинхронната заявка</returns>
        [OperationContract]
        [Documentation]
        ServiceExecuteResult Execute(ServiceRequestData request);

        /// <summary>
        /// Проверка на резултата от изпълнението на асинхронни заявки
        /// </summary>
        /// <param name="request">Аргумент съдържащ идентификатор на асинхронната операция</param>
        /// <returns>Резултат от изпълнението на асинхронната заявка</returns>
        [OperationContract]
        [Documentation]
        ServiceResultData CheckResult(ServiceCheckResultArgument argument);

        /// <summary>
        /// Изпълнява заявката синхронно
        /// </summary>
        /// <param name="request">Аргумент за изпълнение на заявка</param>
        /// <returns>Резултат от изпълнението заявката</returns>
        [OperationContract]
        [Documentation]
        ServiceResultData ExecuteSynchronous(ServiceRequestData request);
    }
}
