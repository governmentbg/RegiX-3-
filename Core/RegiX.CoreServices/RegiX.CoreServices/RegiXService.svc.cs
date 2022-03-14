using System;
using System.ServiceModel;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Core.Data.Interfaces;
using TechnoLogica.RegiX.LegacyCore.Helpers;
using TechnoLogica.RegiX.LegacyCore.Interfaces;
using TechnoLogica.RegiX.LegacyCore.TransportObject;

namespace TechnoLogica.RegiX.CoreServices
{
    /// <summary>
    /// Услуга съдържаща операции за работа с API услуги. Позволява синхронно и асинхронно изпълнение на произволни API услуги, които са част от RegiX
    /// </summary>
    [ServiceBehavior(AddressFilterMode = AddressFilterMode.Any)]
    public class RegiXService : IRegiXService
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public RegiXService()
        {
            RegiXData = Composition.CompositionContainer.GetExportedValueOrDefault<IRegiXData>();
        }

        /// <summary>
        /// Интерфейс за извличане на данни от базата
        /// </summary>
        private IRegiXData RegiXData { get; set; }

        /// <summary>
        /// Изпълнява заявката асинхронно
        /// </summary>
        /// <param name="request">Аргумент за изпълнение на заявка</param>
        /// <returns>Резултат от изпълнението на асинхронната заявка</returns>
        public ServiceExecuteResult Execute(ServiceRequestData request)
        {
            IAPIService apiServiceImplementation = Composition.CompositionContainer.GetExportedValueOrDefault<IAPIService>(request.Contract);
            if (apiServiceImplementation != null)
            {
                var requestV2 = request.ToServiceRequestData();
                requestV2.RequestProcessing = Common.TransportObjects.RequestProcessing.Asynchronous;
                return apiServiceImplementation.Execute(requestV2).ToServiceExecuteResult();
            }
            else
            {
                throw new ArgumentException(StringResources.InvalidArgumentOperation);
            }
        }

        /// <summary>
        /// Проверка на резултата от изпълнението на асинхронни заявки
        /// </summary>
        /// <param name="request">Аргумент съдържащ идентификатор на асинхронната операция</param>
        /// <returns>Резултат от изпълнението на асинхронната заявка</returns>
        public ServiceResultData CheckResult(ServiceCheckResultArgument argument)
        {
            string apiServiceContract = RegiXData.GetAPIServiceContract(argument.ServiceCallID);
            if (!String.IsNullOrEmpty(apiServiceContract))
            {
                IAPIService apiServiceImplementation = Composition.CompositionContainer.GetExportedValueOrDefault<IAPIService>(apiServiceContract);
                var result = apiServiceImplementation.CheckResult(argument.ToV2()).ToV0();
                return result;
            }
            else
            {
                throw new ArgumentException(StringResources.InvalidArgumentOperation);
            }
        }

        /// <summary>
        /// Изпълнява заявката синхронно
        /// </summary>
        /// <param name="request">Аргумент за изпълнение на заявка</param>
        /// <returns>Резултат от изпълнението заявката</returns>
        public ServiceResultData ExecuteSynchronous(ServiceRequestData request)
        {
            IAPIService apiServiceImplementation = Composition.CompositionContainer.GetExportedValueOrDefault<IAPIService>(request.Contract);
            if (apiServiceImplementation != null)
            {
                var requestV2 = request.ToServiceRequestData();
                return apiServiceImplementation.Execute(requestV2).ToV0();
            }
            else
            {
                throw new ArgumentException(StringResources.InvalidArgumentOperation);
            }
        }
    }
}
