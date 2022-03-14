using System;
using System.ComponentModel.Composition;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.Common.TransportObjects;

namespace TechnoLogica.RegiX.Adapters.TestUtils
{
    [Export(typeof(IAdapterClient<>))]
    public class AdapterClient<IAPI> : IAdapterClient
        where IAPI : IAPIService
    {
        public void AcknowledgeResultReceived(IAPIService apiService, ServiceCheckResultArgument checkResult)
        {
            throw new NotImplementedException();
        }

        public ServiceResultData CheckResult(IAPIService apiService, ServiceCheckResultArgument checkResult)
        {
            throw new NotImplementedException();
        }

        public ServiceResultDataSigned<R, T> Execute<I, R, T>(Expression<Func<I, R, AccessMatrix, AdapterAdditionalParameters, CommonSignedResponse<R, T>>> func, ServiceRequestData<R> serviceRequest, [CallerMemberName] string operationName = "")
            where I : IAdapterService
            where R : class
            where T : class
        {
            throw new NotImplementedException();
        }

        public ServiceResultData Execute(IAPIService apiService, ServiceRequestData request)
        {
            throw new NotImplementedException();
        }
    }
}
