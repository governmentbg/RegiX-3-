using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.Core;

namespace TechnoLogica.RegiX.Core.Utils
{
    public static class ServiceResultDataSignedExtensions
    {
        public static void FromAdapterResult<R, T>(this ServiceResultDataSigned<R, T> serviceResultData, AdapterResult<CommonSignedResponse<R, T>> adapterResult)
            where T : class
            where R : class
        {
            // adapterResult.Result?.Data?.Response  check added for compatibility with RegiX III
            serviceResultData.IsReady = (adapterResult.HasError) ? true : adapterResult.Result.IsReady || adapterResult.Result?.Data?.Response != null; 
            serviceResultData.Result = (adapterResult.HasError) ? null as T : adapterResult.Result?.Data?.Response;
            serviceResultData.Request = (adapterResult.HasError) ? null as R : adapterResult.Result?.Data?.Request;
            serviceResultData.Matrix = (adapterResult.HasError) ? null as DataAccessMatrix : adapterResult.Result?.Data?.Matrix;
            serviceResultData.Signature = (adapterResult.HasError) ? null : adapterResult.Result?.Signature;
            serviceResultData.Error = (adapterResult.HasError) ? adapterResult.Error : null as string;
            serviceResultData.HasError = adapterResult.HasError;
            serviceResultData.VerificationCode = (adapterResult.HasError) ? null : adapterResult.Result?.VerificationCode;
        }
    }
}
