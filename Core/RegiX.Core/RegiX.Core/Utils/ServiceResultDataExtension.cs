using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.Core.Interfaces.TransportObjects;

namespace TechnoLogica.RegiX.Core.Utils
{
    /// <summary>
    /// Extension клас за ServiceResultData
    /// </summary>
    public static class ServiceResultDataExtension
    {
        /// <summary>
        /// Опакова подадения обект в ResultWrapper
        /// </summary>
        /// <param name="resultData">Обект, който опаковаме</param>
        /// <returns>Създадения ResultWrapper обект</returns>
        public static ResultWrapper Wrap(this ServiceResultData resultData)
        {
            return new ResultWrapper() { Result = resultData };
        }

        ///// <summary>
        ///// Конвертира ServiceResultData V2 към V1
        ///// </summary>
        ///// <param name="resultData">Обект за конвертиране</param>
        ///// <returns>Резлутата от конверсията</returns>
        //public static TransportObject.Signed.ServiceResultData ToV1(this ServiceResultData resultData)
        //{
        //    TransportObject.Signed.ServiceResultData result = new TransportObject.Signed.ServiceResultData
        //    {
        //        Data = resultData.Data,
        //        Error = resultData.Error,
        //        HasError = resultData.HasError,
        //        IsReady = resultData.IsReady,
        //        ServiceCallID = resultData.ServiceCallID,
        //        Signature = resultData.Signature
        //    };
        //    return result;
        //}

        ///// <summary>
        ///// Конвертира ServiceResultData V2 към V1
        ///// </summary>
        ///// <param name="resultData">Обект за конвертиране</param>
        ///// <returns>Резлутата от конверсията</returns>
        //public static TransportObject.ServiceResultData ToV0(this ServiceResultData resultData)
        //{
        //    TransportObject.ServiceResultData result = new TransportObject.ServiceResultData
        //    {
        //        Result = resultData.Data.Response.Response,
        //        Error = resultData.Error,
        //        HasError = resultData.HasError,
        //        IsReady = resultData.IsReady
        //    };
        //    return result;
        //}
    }
}
