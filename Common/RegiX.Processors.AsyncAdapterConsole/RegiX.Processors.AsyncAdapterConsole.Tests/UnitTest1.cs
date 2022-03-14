using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Threading;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Processors.AsyncAdapterConsole;
using TechnoLogica.RegiX.Processors.AsyncAdapterConsole.DB;
using DA = Contoso.RegiX.ReferenceAdapter.AdapterService;
using System.Linq;
using System;
using TechnoLogica.RegiX.Adapters.Common.Interfaces;
using TechnoLogica.RegiX.Common.Utils;
using TechnoLogica.RegiX.Common.TransportObjects;
using System.Collections.Generic;
using System.Threading.Tasks;
using FastMember;
using Contoso.RegiX.ReferenceAdapter.AdapterService;
using TechnoLogica.RegiX.Adapters.Common.Utils;
using Contoso.RegiX.ReferenceAdapter;
using TechnoLogica.RegiX.Common.ObjectMapping;

namespace RegiX.Processors.AsyncAdapterConsole.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            AggregateCatalog catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(Processor<>).Assembly));
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(DA.ReferenceAdapter).Assembly));
            CompositionContainer result = new CompositionContainer(catalog, true);
            result.ComposeExportedValue(result);
            Composition.CompositionContainer = result;
        }

        [TestMethod]
        public void TestMethod1()
        {
            new Processor<DA.ReferenceAdapter>();
            Thread.Sleep(10 * 1000);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var set = new RegiXAdapterConsoleContext().AdapterOperations;
            var res =
                from v in set
                select v;
            var count = res.Count();
            Console.WriteLine(count);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var set = new RegiXAdapterConsoleContext().OperationsPersistance;
            var res =
                from v in set
                select new
                {
                    v.Id,
                    v.ApiServiceCallId,
                    v.AdapterOperationId,
                    v.AdapterOperation,
                    v.CallbackUrl,
                    v.Acknowledged,
                    v.NextRetry,
                    v.RetryCount,
                    v.VerificationCode,
                    //   v.RawRequst,
                    v.RawResult
                };
            Console.WriteLine(res.ToList());
        }
        [TestMethod]
        public void PersistProcessing()
        {
            var pv = Composition.CompositionContainer.GetExportedValue<IPersistanceProvider>();
            pv.PersistProcessing(1, "asdf");
        }

        [TestMethod]
        public void RetrieveResult()
        {
            var pv = Composition.CompositionContainer.GetExportedValue<IPersistanceProvider>();
            var res = pv.RetrieveResult(1, "asdf");
            Console.WriteLine(res.XmlSerialize());
        }

        [TestMethod]
        public void PersistResultTest()
        {
            var pv = Composition.CompositionContainer.GetExportedValue<IPersistanceProvider>();
            pv.PersistResult(1, new ServiceResultData());
        }

        [TestMethod]
        public void RemoveTest()
        {
            var pv = Composition.CompositionContainer.GetExportedValue<IPersistanceProvider>();
            pv.Remove(1, "asdf");
        }
        //[TestMethod]
        //public void TestQuery()
        //{
        //    ProcessResults.Invoke();
        //}

        [TestMethod]
        public void TestSerializeDeserialize()
        {
            //var serializedRequestData =
            //  new OperationRequest<ExampleRequest, ExampleResponse>()
            //  {
            //      Request = new ExampleRequest() { Identifier = "blah" },
            //      AccessMatrix = AccessMatrix.CreateForType(typeof(ExampleResponse)),
            //      AdapterAdditionalParameters = new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters() {
            //       CallbackURL ="Http"},
            //      Response = null
            //  }.XmlSerialize();

            //Console.WriteLine(serializedRequestData);

            var serializedRequestData = "<?xml version=\"1.0\"?><OperationRequestOfExampleRequestExampleResponse xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">  <Request><Identifier xmlns=\"http://egov.bg/RegiX/Reference/ExampleRequest\">83090875491</Identifier>  </Request></OperationRequestOfExampleRequestExampleResponse>";

            var deserializeType = typeof(OperationRequest<,>).MakeGenericType(typeof(ExampleRequest), typeof(ExampleResponse));
            TypeAccessor operationRequestTA = TypeAccessor.Create(deserializeType);

            var result = serializedRequestData.XmlDeserialize(deserializeType);
            Console.WriteLine(result);
        }

        class CallResult
        {
            public string Contract { get; set; }
            public int Id { get; set; }
            public string Response { get; set; }
            public string RawRequst { get; set; }
            public string CallbackUrl { get; set; }

        }

        private Action ProcessResults
        {
            get =>
                () =>
                {
                    while (true)
                    {
                            //retrieve data
                            // AdapterService.ProcessCallback<>();
                            List<CallResult> queryResult = new List<CallResult>();
                            using (var context = new RegiXAdapterConsoleContext())
                            {
                                // 
                                queryResult =
                                    (from ao in context.AdapterOperations
                                     join rc in context.ReturnedCalls on ao.Id equals rc.AdapterOperationId
                                     join op in context.OperationsPersistance on rc.ApiServiceCallId equals op.ApiServiceCallId
                                     where ao.Contract.Contains("Contoso.RegiX.ReferenceAdapter.AdapterService.IReferenceAdapter") &&
                                           op.RawResult == null
                                     select new CallResult()
                                     {
                                         Contract = ao.Contract,
                                         Id = op.Id,
                                         Response = rc.Response,
                                         RawRequst = op.RawRequst,
                                         CallbackUrl = op.CallbackUrl
                                     }).ToList();
                            }

                            var adapterInterface = typeof(ReferenceAdapter).GetAdapterServiceInterface();
                            foreach (var serviceCall in queryResult)
                            {
                                //res.Contract
                                var method = adapterInterface.GetMethods().Where(m => serviceCall.Contract.EndsWith($".{m.Name }")).Single();
                                var parameters = method.GetParameters();
                                var requestType = parameters[0].ParameterType;
                                var responseType = method.ReturnParameter.ParameterType.GenericTypeArguments[1];
                                var deserializeType = typeof(OperationRequest<,>).MakeGenericType(requestType, responseType);

                                TypeAccessor operationRequestTA = TypeAccessor.Create(deserializeType);
                                var result = serviceCall.RawRequst.XmlDeserialize(deserializeType);
                                string procesesCallbackMethodName = "ProcessCallback";  //nameof...

                            }
                    }
                };
        }
    }
}
