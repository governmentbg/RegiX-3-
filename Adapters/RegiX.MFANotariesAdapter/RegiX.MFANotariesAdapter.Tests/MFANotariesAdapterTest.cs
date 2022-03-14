using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Threading;
using TechnoLogica.RegiX.Adapters.TestUtils;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.Common.Utils;
using TechnoLogica.RegiX.MFANotariesAdapter.AdapterService;
using TechnoLogica.RegiX.MFANotariesAdapter.APIService;
using TechnoLogica.RegiX.MFANotariesAdapter.Integration;
using BinDirectoryLocator = TechnoLogica.RegiX.MFANotariesAdapter.Integration.BinDirectoryLocator;

namespace TechnoLogica.RegiX.MFANotariesAdapter.Tests
{
    [TestClass]
    public class MFANotariesAdapterTest : AdapterTest<AdapterService.MFANotariesAdapter, IMFANotariesAdapter>
    {
        public MFANotariesAdapterTest()
        {
            AggregateCatalog catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(AdapterService.MFANotariesAdapter).Assembly));
            catalog.Catalogs.Add(new TypeCatalog(typeof(NotImplementedParameterStore))); // Setting connection string
            catalog.Catalogs.Add(new TypeCatalog(typeof(BinDirectoryLocator)));
            CompositionContainer result = new CompositionContainer(catalog, true);
            Composition.CompositionContainer = result;
        }

        // [TestMethod]
        public void SendNotaryDocumentDBInsertTest()
        {
            AdapterService.MFANotariesAdapter mfaNotariesAdapter = new AdapterService.MFANotariesAdapter();

            var ticks = DateTime.Now.Ticks / 100_000;
            var apiServiceCallId = int.Parse(ticks.ToString().Substring(5));
            var additionalParameters = new AdapterAdditionalParameters()
            {
                OrganizationUnit = "TL",
                EIDToken = "",
                CallContext = new CallContext()
                {
                    LawReason = "RegiX.Test",
                    EmployeeIdentifier = "tl_mdonchev",
                    AdministrationName = "Нотариус Милен Дончев"
                },
                SignResult = true,
                ReturnAccessMatrix = false,
                ApiServiceCallId = apiServiceCallId,
                CallbackURL = "192.168.1.1",
                ClientIPAddress = "127.0.0.1",
                ConsumerCertificateThumbprint = "d107cda05756d4e1901e93bcc969651c3c41081b",
                ResponseProcessing = ResponseProcessing.TransformToPDF, // Optional
            };

            var random = new Random();
            var consuls = new List<string>() { "Istanbul", "Berlin", "Tirana", "Vienna", "Budapest" };
            var randIndex = random.Next(0, consuls.Count);
            var consulCode = consuls[randIndex];

            var fileName = Path.Combine("Files", "test.jpg");
            var documentContent = File.ReadAllBytes(fileName);
            var extraName = additionalParameters.ResponseProcessing == ResponseProcessing.TransformToPDF ? "pdf" : "xml";
            SendNotaryDocumentsRequest request = new SendNotaryDocumentsRequest
            {
                AuthenticationDate = DateTime.Now.Date,
                AuthenticationNumber = (apiServiceCallId % 1000).ToString(),
                ConsulCode = consulCode,
                AuthenticationType = AuthenticationType.CorrectnessOfStatements,
                Documents = new DocumentsType()
                {
                    Document = new List<DocumentType>()
                    {
                        new DocumentType() 
                        {
                            Content = documentContent,
                            FileName = "Декларация1.png",
                        }
                    },
                }
            };

            var temp = request.XmlSerialize();
            var serviceRequestData = new ServiceRequestData
            {
                Argument = request.XmlSerialize().ToXmlElement(),
                ResponseProcessing = additionalParameters.ResponseProcessing,
                CallContext = additionalParameters.CallContext,
                CallbackURL = additionalParameters.CallbackURL,
                CitizenEGN = additionalParameters.CitizenEGN,
                SignResult = additionalParameters.SignResult,
                ReturnAccessMatrix = additionalParameters.ReturnAccessMatrix,
                EmployeeEGN = additionalParameters.EmployeeEGN,
                EIDToken = additionalParameters.EIDToken,
                Operation = typeof(IMFANotariesAPI).FullName + "." + nameof(IMFANotariesAPI.SendNotaryDocuments),
            };

            var accessMatrix = AccessMatrix.CreateForType(typeof(SendNotaryDocumentsResponse));
            var result = mfaNotariesAdapter.Execute(serviceRequestData, accessMatrix, additionalParameters);

            Assert.IsTrue(result.IsReady == false);
        }

        // [TestMethod]
        public void SendNotaryDocumentAsyncProcessorTest()
        {
            var asyncProcessor = new AsyncProcessor();

            Thread.Sleep(300 * 1000); // 300 seconds = 5 mins
        }
    }
}
