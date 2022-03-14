using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.DataContracts.Health;
using TechnoLogica.RegiX.Common.DataContracts.Parameter;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.Common.TransportObjects;

namespace RegiX.Common.Tests
{
    [TestClass]
    public class AdapterClientTest
    {

        [TestMethod]
        public void TestOperationSet()
        {
            var adapterClient = new AdapterClientImpl();
            adapterClient.Execute<AdapterService, string, string>(null, null);
            Assert.IsTrue(adapterClient.OperationName == nameof(TestOperationSet));
        }
    }

    class AdapterService : IAdapterService
    {
        public Type AdapterServiceInterface => throw new NotImplementedException();

        public Type AdapterServiceType => throw new NotImplementedException();

        public string AdapterServiceName => throw new NotImplementedException();

        public void AcknowledgeResultReceived(ServiceCheckResultArgument checkResult)
        {
            throw new NotImplementedException();
        }

        public string CheckHealthFunction(string key)
        {
            throw new NotImplementedException();
        }

        public string CheckRegisterConnection()
        {
            throw new NotImplementedException();
        }

        public ServiceResultData CheckResult(ServiceCheckResultArgument checkResult)
        {
            throw new NotImplementedException();
        }

        public ServiceResultData Execute(ServiceRequestData request, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters)
        {
            throw new NotImplementedException();
        }

        public uint GetAdapterUptime()
        {
            throw new NotImplementedException();
        }

        public string GetAdapterVersion()
        {
            throw new NotImplementedException();
        }

        public HealthCheckFunctions GetHealthCheckFunctions()
        {
            throw new NotImplementedException();
        }

        public string GetHostMachineInfo()
        {
            throw new NotImplementedException();
        }

        public Parameters GetParameters()
        {
            throw new NotImplementedException();
        }

        public string GetPublicKeyString()
        {
            throw new NotImplementedException();
        }

        public uint GetSystemUptime()
        {
            throw new NotImplementedException();
        }

        public byte[] Ping(byte[] data)
        {
            throw new NotImplementedException();
        }

        public bool SendResultToCore(ServiceResultData result, string callbackURL)
        {
            throw new NotImplementedException();
        }

        public void SetParameter(string key, string value)
        {
            throw new NotImplementedException();
        }

        public void SetParameters(List<ParameterInfo> parameters)
        {
            throw new NotImplementedException();
        }
    }


    class AdapterClientImpl : IAdapterClient
    {
        public string OperationName { get; set; }

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
            OperationName = operationName;
            return null;
        }

        public ServiceResultData Execute(IAPIService apiService, ServiceRequestData request)
        {
            throw new NotImplementedException();
        }
    }
}
