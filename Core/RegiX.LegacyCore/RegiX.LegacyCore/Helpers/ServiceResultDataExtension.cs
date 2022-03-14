using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoLogica.RegiX.LegacyCore.Helpers
{
    /// <summary>
    /// Extension клас за ServiceResultData
    /// </summary>
    public static class ServiceResultDataExtension
    {

        /// <summary>
        /// Конвертира ServiceResultData V2 към V1
        /// </summary>
        /// <param name="resultData">Обект за конвертиране</param>
        /// <returns>Резлутата от конверсията</returns>
        public static TransportObject.Signed.ServiceResultData ToV1(this Common.TransportObjects.ServiceResultData resultData)
        {
            TransportObject.Signed.ServiceResultData result = new TransportObject.Signed.ServiceResultData
            {
                Data = new TransportObject.DataContainer() {
                    Matrix = resultData.Data?.Matrix,
                    Request = resultData.Data?.Request,
                    Response = resultData.Data?.Response,
                },
                Error = resultData.Error,
                HasError = resultData.HasError,
                IsReady = resultData.IsReady,
                ServiceCallID = resultData.ServiceCallID,
                Signature = resultData.Signature
            };
            return result;
        }

        ///// <summary>
        ///// Опакова подадения обект в ResultWrapper
        ///// </summary>
        ///// <param name="resultData">Обект, който опаковаме</param>
        ///// <returns>Създадения ResultWrapper обект</returns>
        //public static ResultWrapper Wrap(this ServiceResultData resultData)
        //{
        //    return new ResultWrapper() { Result = resultData };
        //}

        /// <summary>
        /// Конвертира ServiceResultData V2 към V1
        /// </summary>
        /// <param name="resultData">Обект за конвертиране</param>
        /// <returns>Резлутата от конверсията</returns>
        public static TransportObject.ServiceResultData ToV0(this Common.TransportObjects.ServiceResultData resultData)
        {
            TransportObject.ServiceResultData result = new TransportObject.ServiceResultData
            {
                Result = resultData.Data.Response.Response,
                Error = resultData.Error,
                HasError = resultData.HasError,
                IsReady = resultData.IsReady
            };
            return result;
        }

        /// <summary>
        /// Конвертира обекта до ServiceExecuteResult
        /// </summary>
        /// <param name="resultData">Обект за конвертиране</param>
        /// <returns>Създаденият ServiceExecuteResult</returns>
        public static TransportObject.ServiceExecuteResult ToServiceExecuteResult(this Common.TransportObjects.ServiceResultData resultData)
        {            
            var result = new TransportObject.ServiceExecuteResult()
            {
                HasError = resultData.HasError,
                Error = resultData.Error,
                ServiceCallID = resultData.ServiceCallID
            };
            return result;
        }
    }
}
