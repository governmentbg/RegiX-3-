using System.ServiceModel;
using Technologica.WcfCustom;
using TechnoLogica.RegiX.LegacyCore.TransportObject;

namespace TechnoLogica.RegiX.Common.Interfaces
{
    /// <summary>
    /// Услуга съдържаща операции за работа с API услуги. Позволява синхронно и асинхронно изпълнение на произволни API услуги, които са част от RegiX
    /// </summary>
    [ServiceContract]
    [XmlSerializerFormat]
    [Documentation]
    public interface IRegiXEntryPoint
    {
        /// <summary>
        /// Изпълнява заявката асинхронно
        /// </summary>
        /// <param name="request">Аргумент за изпълнение на заявка</param>
        /// <returns>Резултат от изпълнението на асинхронната заявка</returns>
        [OperationContract]
        [Documentation]
        ServiceExecuteResult Execute(LegacyCore.TransportObject.Signed.ServiceRequestData request);

        /// <summary>
        /// Проверка на резултата от изпълнението на асинхронни заявки
        /// </summary>
        /// <param name="argument">Аргумент съдържащ идентификатор на асинхронната операция</param>
        /// <returns>Резултат от изпълнението на асинхронната заявка</returns>
        [OperationContract]
        [Documentation]
        LegacyCore.TransportObject.Signed.ServiceResultData CheckResult(ServiceCheckResultArgument argument);

        /// <summary>
        /// Изпълнява заявката синхронно
        /// </summary>
        /// <param name="request">Аргумент за изпълнение на заявка</param>
        /// <returns>Резултат от изпълнението заявката</returns>
        [OperationContract]
        [Documentation]
        LegacyCore.TransportObject.Signed.ServiceResultData ExecuteSynchronous(LegacyCore.TransportObject.Signed.ServiceRequestData request);
    }
}
