using System;
using System.ServiceModel;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.Core.Data.Interfaces;
using TechnoLogica.RegiX.Core.Interfaces;
using TechnoLogica.RegiX.Core.Interfaces.TransportObjects;
using TechnoLogica.RegiX.Core.Utils;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace TechnoLogica.RegiX.CoreServices
{

    /// <summary>
    /// Услуга съдържаща операции за работа с API услуги. Позволява синхронно и асинхронно изпълнение на произволни API услуги, които са част от RegiX
    /// </summary>
    [ServiceBehavior(AddressFilterMode = AddressFilterMode.Any)]
    public class RegiXEntryPointV2 : IRegiXEntryPointV2
    {
        /// <summary>
        /// Интерфейс за извличане на данни от базата
        /// </summary>
        private IRegiXData RegiXData { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        public RegiXEntryPointV2()
        {
            RegiXData = Composition.CompositionContainer.GetExportedValue<IRegiXData>();
        }

        /// <summary>
        /// Изпълнява заявката
        /// </summary>
        /// <param name="request">Аргумент за изпълнение на заявка</param>
        /// <returns>Резултат от изпълнението заявката</returns>
        public ResultWrapper Execute(RequestWrapper wrappedRequest)
        {
            IAPIService apiServiceImplementation = Composition.CompositionContainer.GetExportedValueOrDefault<IAPIService>(wrappedRequest?.Request?.Contract);
            if (apiServiceImplementation != null)
            {
                ServiceResultData result = apiServiceImplementation.Execute(wrappedRequest.Request);
                return result.Wrap();
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
        public ResultWrapper CheckResult(ServiceCheckResultWrapper wrappedArgument)
        {
            string apiServiceContract = RegiXData.GetAPIServiceContract(wrappedArgument?.Request?.ServiceCallID);
            if (!string.IsNullOrEmpty(apiServiceContract))
            {
                IAPIService apiServiceImplementation = Composition.CompositionContainer.GetExportedValueOrDefault<IAPIService>(apiServiceContract);
                if (apiServiceImplementation != null)
                {
                    ServiceResultData result = apiServiceImplementation.CheckResult(wrappedArgument.Request);
                    return result.Wrap();
                }
                else
                {                    
                    throw new ArgumentException(StringResources.InvalidArgumentOperation);
                }
            }
            else
            {
                throw new ArgumentException(StringResources.InvalidServiceCallID);
            }
        }

        /// <summary>
        /// Операция имплементирана от клиента за получаване на асинхронен резултат чрез използване на callback
        /// </summary>
        /// <param name="request">Резултат от изпълнение на аснихронна заявка</param>
        public void ExecuteCallback(ResultWrapper request)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Acknowledges that the result of an operation is received
        /// </summary>
        /// <param name="argument">Arugment containing the service call id and verification code</param>
        public void AcknowledgeResultReceived(ServiceCheckResultWrapper argument)
        {
            string apiServiceContract = RegiXData.GetAPIServiceContract(argument?.Request?.ServiceCallID);
            if (!string.IsNullOrEmpty(apiServiceContract))
            {
                IAPIService apiServiceImplementation = Composition.CompositionContainer.GetExportedValueOrDefault<IAPIService>(apiServiceContract);
                if (apiServiceImplementation != null)
                {
                    apiServiceImplementation.AcknowledgeResultReceived(argument.Request);
                }
                else
                {
                    throw new ArgumentException(StringResources.InvalidArgumentOperation);
                }
            }
            else
            {
                throw new ArgumentException(StringResources.InvalidServiceCallID);
            }
        }
    }
}
