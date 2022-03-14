using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.Common.Utils;

namespace TechnoLogica.RegiX.Core
{
    /// <summary>
    /// Типизиран контекст на изпълнение. Позволява връщането на типизирани резултати
    /// </summary>
    /// <typeparam name="I">Контракт на адаптер</typeparam>
    /// <typeparam name="R">Тип на аргумент</typeparam>
    /// <typeparam name="T">Тип на резултат</typeparam>
    [Export(typeof(ExecutionContext<,,>))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ExecutionContext<I, R, T> : ExecutionAdapterContext<I>
        where I : IAdapterService //IAdapterServiceWCF, IAdapterServiceNETCore
        where T : class
        where R : class
    {
        /// <summary>
        /// Logger
        /// </summary>
        private static readonly log4net.ILog Logger =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Кеш за съхранение на компилирани experssion-и
        /// </summary>
        private static ConcurrentDictionary<string, object> expressionCache = new ConcurrentDictionary<string, object>();

        /// <summary>
        /// Инициализира контекст за изпълнение
        /// </summary>
        /// <param name="serviceRequest">Заявка за изпълнение на операция</param>
        public void Initialize(ServiceRequestData<R> serviceRequest)
        {
            base.Initialize(serviceRequest);
            Argument = serviceRequest.Argument;
        }

        /// <summary>
        /// Expression за извкивне на адаптер операция
        /// </summary>
        public Expression<Func<I, R, AccessMatrix, AdapterAdditionalParameters, T>> AdapterFunction { get; set; }

        /// <summary>
        /// Аргумент на заявка
        /// </summary>
        public R Argument { get; set; }

        /// <summary>
        /// Компилиран expression за извикване на адаптер операция
        /// </summary>
        public Func<I, R, AccessMatrix, AdapterAdditionalParameters, T> CompiledAdapterFunction
        {
            get
            {
                return
                    (Func<I, R, AccessMatrix, AdapterAdditionalParameters, T>)expressionCache
                        .GetOrAdd(
                            string.Format("{0}#{1}", AdapterContractName, AdapterOperationName),
                            (k) => AdapterFunction.Compile()
                        );
            }
        }
        
        /// <summary>
        /// Извлича име на адаптер операция от подаденият expression
        /// </summary>
        /// <param name="func">Expression за извикване на адаптер операция</param>
        public void ProcessAdapterContractAndOperation(Expression<Func<I, R, AccessMatrix, AdapterAdditionalParameters, T>> func)
        {
            if (func.Body is MethodCallExpression)
            {
                AdapterOperationName = (func.Body as MethodCallExpression).Method.Name;
            }
            else
            {
                throw new ApplicationException("Function in API body should be method invocation!");
            }
        }

        /// <summary>
        /// Изпълнява извикването на адаптер
        /// </summary>
        /// <returns>Резултат от изпълнението на операцията</returns>
        public AdapterResult<T> Execute()
        {
            AdapterResult<T> result = null;
            DateTime startTime = DateTime.Now;
            try
            {
                T resultObject =
                    CompiledAdapterFunction.Invoke(
                      Channel,
                      Argument,
                      AccessMatrix,
                      AdditionalParameter
                  );
                result = new AdapterResult<T>() { HasError = false, Result = resultObject };
            }
            catch (Exception ex)
            {
                string message;
                string stackTrace = ExceptionManager.GetExceptionFullStackTrace(ex);
                string adapterResultMessage;
                ExceptionManager.ExtractMessageAndStackTrace(ex, out adapterResultMessage, out message);
                RegiXData.AddAdapterOperationErrorLog(
                    ServiceInformation.APIServiceOperationID,
                    ServiceInformation.AdapterOperationID,
                    this.ApiServiceCallId,
                    DateTime.Now,
                    message,
                    stackTrace
                    );
                result = new AdapterResult<T>() { HasError = true, Error = adapterResultMessage };
            }
            RegiXData.AddAdapterOperationLog(ApiServiceCallId, ServiceInformation.AdapterOperationID, startTime, DateTime.Now);
            return result;
        }
    }
}
