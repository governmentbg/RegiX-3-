using System.ServiceModel;
using Technologica.WcfCustom;
using TechnoLogica.RegiX.Core.Interfaces.TransportObjects;

namespace TechnoLogica.RegiX.Core.Interfaces
{
    /// <summary>
    /// Услуга съдържаща операции за работа с API услуги. Позволява синхронно и асинхронно изпълнение на произволни API услуги, които са част от RegiX
    /// </summary>
    [ServiceContract(Namespace = "http://egov.bg/RegiX")]
    [XmlSerializerFormat]
    [Documentation]
    public interface IRegiXEntryPointV2
    {
        /// <summary>
        /// Изпълнява заявката
        /// </summary>
        /// <param name="request">Аргумент за изпълнение на заявка</param>
        /// <returns>Резултат от изпълнението заявката</returns>
        [OperationContract]
        [Documentation]
        ResultWrapper Execute(RequestWrapper request);

        /// <summary>
        /// Проверка на резултата от изпълнението на асинхронни заявки
        /// </summary>
        /// <param name="argument">Аргумент съдържащ идентификатор на асинхронната операция</param>
        /// <returns>Резултат от изпълнението на асинхронната заявка</returns>
        [OperationContract]
        [Documentation]
        ResultWrapper CheckResult(ServiceCheckResultWrapper argument);

        /// <summary>
        /// Acknowledges that the result of an operation is received
        /// </summary>
        /// <param name="argument">Service result check argument</param>
        [OperationContract]
        [Documentation]
        void AcknowledgeResultReceived(ServiceCheckResultWrapper argument);

        /// <summary>
        /// Операция имплементирана от клиента за получаване на асинхронен резултат чрез използване на callback
        /// </summary>
        /// <param name="request">Резултат от изпълнение на аснихронна заявка</param>
        [OperationContract]
        [Documentation]
        void ExecuteCallback(ResultWrapper request);
    }
}
