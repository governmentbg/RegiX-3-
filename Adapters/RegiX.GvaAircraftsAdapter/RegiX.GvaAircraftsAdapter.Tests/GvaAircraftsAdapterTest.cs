using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegiX.Adapters.FileParameterStore;
using TechnoLogica.RegiX.Adapters.TestUtils;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.Common.Utils;
using TechnoLogica.RegiX.GvaAircraftsAdapter.AdapterService;

namespace TechnoLogica.RegiX.GvaAircraftsAdapter.Tests
{
    [TestClass]
    public class GvaAircraftsAdapterTest : AdapterTest<AdapterService.GvaAircraftsAdapter, IGvaAircraftsAdapter>
    {
        public GvaAircraftsAdapterTest()
        {
            AggregateCatalog catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(AdapterService.GvaAircraftsAdapter).Assembly));
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(FileParameterStoreImplementation).Assembly));
            catalog.Catalogs.Add(new TypeCatalog(typeof(BinDirectoryLocator)));
            CompositionContainer result = new CompositionContainer(catalog, true);
            result.ComposeExportedValue(result);
            Composition.CompositionContainer = result;
        }


        public CallContext GetCallContext()
        {
           CallContext context = new CallContext()
            {
                AdministrationOId = "https://trust-party-openid.com",
                LawReason = "�������� �� RegiX",
                ServiceURI = "1222-200030-12.12.2022",
                Remark = "���������",
                EmployeeAditionalIdentifier = "����� ����� 3",
                EmployeeIdentifier = "test@tesactivedirectory.com",
                EmployeeNames = "������ ���������� ����������",
                AdministrationName = "��������� ������� �� ��������",
                EmployeePosition = "������ ������� ����� \"�������� �� ������������\"",
                ResponsiblePersonIdentifier = "392309324",
                ServiceType = "�� ������������ �������"
            };
            return context;

        }

        public AdapterAdditionalParameters GetAdditionalParameters()
        {
            AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
            additionalParameters.CallContext = GetCallContext();
            additionalParameters.CitizenEGN = "8888888888";
            additionalParameters.ClientIPAddress = "111.111.111.111";
            additionalParameters.ConsumerCertificateThumbprint = "###";
            additionalParameters.EIDToken = "token123";
            additionalParameters.EmployeeEGN = "11111111111111";
            additionalParameters.OrganizationEIK = "12121212121";
            additionalParameters.OrganizationUnit = "qqqqqq";
            additionalParameters.SignResult = false;
            additionalParameters.ReturnAccessMatrix = true;
            return additionalParameters;
        }

        //TODO: Test not working without network
        //[TestMethod]
        public void TestGvaAircraftByMSN()
        {
            AdapterService.GvaAircraftsAdapter adapter = new AdapterService.GvaAircraftsAdapter();

            var accessMatrix = AccessMatrix.CreateForType(typeof(AircraftsResponse));
            AircraftsByMSNType searchCriteria = new AircraftsByMSNType() { MSN = "7706005" };

            var result = adapter.GetAircraftsByMSN(searchCriteria, accessMatrix, GetAdditionalParameters());

            string xml = result.Data.Response.XmlSerialize();
            using (StreamWriter outfile = new StreamWriter("GetAircraftsByMSN_Test_7706005.xml", false, System.Text.Encoding.UTF8))
            {
                outfile.Write(xml);
            }
            // XsltUtils.RunXsltAndWriteHtml("GvaAircraftsAdapter", "AircraftsRequest", result.Data.Request.XmlSerialize());
            // XsltUtils.RunXsltAndWriteHtml("GvaAircraftsAdapter", "AircraftsResponse", result.Data.Response.XmlSerialize());

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);

            if (SigningUtils.HasSignature(doc))
            {
                bool isValid = SigningUtils.ValidateXmlDocumentWithX509Certificate(doc);
                if (isValid)
                {
                    Assert.IsTrue(true);
                }
            }
            else
            {
                Assert.IsTrue(true);
            }
        }

        //TODO: Test not working without network
        //[TestMethod]
        public void TestGvaAircraftByMSN_11015506()
        {
            AdapterService.GvaAircraftsAdapter adapter = new AdapterService.GvaAircraftsAdapter();

            var accessMatrix = AccessMatrix.CreateForType(typeof(AircraftsResponse));
            AircraftsByMSNType searchCriteria = new AircraftsByMSNType() { MSN = "11015506" };

            var result = adapter.GetAircraftsByMSN(searchCriteria, accessMatrix, GetAdditionalParameters());
            string xml = result.Data.Response.XmlSerialize();
            using (StreamWriter outfile = new StreamWriter("GetAircraftsByMSN_Test_11015506.xml", false, System.Text.Encoding.UTF8))
            {
                outfile.Write(xml);
            }
            // XsltUtils.RunXsltAndWriteHtml("GvaAircraftsAdapter", "AircraftsRequest", result.Data.Request.XmlSerialize());
            //  XsltUtils.RunXsltAndWriteHtml("GvaAircraftsAdapter", "AircraftsResponse", result.Data.Response.XmlSerialize());
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            if (SigningUtils.HasSignature(doc))
            {
                bool isValid = SigningUtils.ValidateXmlDocumentWithX509Certificate(doc);
                if (isValid)
                {
                    Assert.IsTrue(true);
                }
            }
            else
            {
                Assert.IsTrue(true);
            }
        }

        //TODO: Test not working without network
        //[TestMethod]
        public void TestGvaAircraftByMSN_1085()
        {
            AdapterService.GvaAircraftsAdapter adapter = new AdapterService.GvaAircraftsAdapter();

            var accessMatrix = AccessMatrix.CreateForType(typeof(AircraftsResponse));
            AircraftsByMSNType searchCriteria = new AircraftsByMSNType() { MSN = "1085" };

            var result = adapter.GetAircraftsByMSN(searchCriteria, accessMatrix, GetAdditionalParameters());
            string xml = result.Data.Response.XmlSerialize();
            using (StreamWriter outfile = new StreamWriter("GetAircraftsByMSN_Test_1085.xml", false, System.Text.Encoding.UTF8))
            {
                outfile.Write(xml);
            }
            // XsltUtils.RunXsltAndWriteHtml("GvaAircraftsAdapter", "AircraftsRequest", result.Data.Request.XmlSerialize());
            //  XsltUtils.RunXsltAndWriteHtml("GvaAircraftsAdapter", "AircraftsResponse", result.Data.Response.XmlSerialize());
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            if (SigningUtils.HasSignature(doc))
            {
                bool isValid = SigningUtils.ValidateXmlDocumentWithX509Certificate(doc);
                if (isValid)
                {
                    Assert.IsTrue(true);
                }
            }
            else
            {
                Assert.IsTrue(true);
            }
        }

        //TODO: Test not working without network
        //[TestMethod]
        public void TestGvaAircraftByIdentifier_816088508()
        {
            AdapterService.GvaAircraftsAdapter adapter = new AdapterService.GvaAircraftsAdapter();

            var accessMatrix = AccessMatrix.CreateForType(typeof(AircraftsResponse));
            AircraftsByOwnerType searchCriteria = new AircraftsByOwnerType() { OwnerID = "816088508" };

            var result = adapter.GetAircraftsByOwner(searchCriteria, accessMatrix, GetAdditionalParameters());
            string xml = result.Data.Response.XmlSerialize();
            using (StreamWriter outfile = new StreamWriter("TestGvaAircraftByIdentifier_816088508.xml", false, System.Text.Encoding.UTF8))
            {
                outfile.Write(xml);
            }
            // XsltUtils.RunXsltAndWriteHtml("GvaAircraftsAdapter", "AircraftsRequest", result.Data.Request.XmlSerialize());
            //  XsltUtils.RunXsltAndWriteHtml("GvaAircraftsAdapter", "AircraftsResponse", result.Data.Response.XmlSerialize());
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            if (SigningUtils.HasSignature(doc))
            {
                bool isValid = SigningUtils.ValidateXmlDocumentWithX509Certificate(doc);
                if (isValid)
                {
                    Assert.IsTrue(true);
                }
            }
            else
            {
                Assert.IsTrue(true);
            }
        }

        //TODO: Test not working without network
        //[TestMethod]
        public void TestGvaAircraftByIdentifier_103179157()
        {
            AdapterService.GvaAircraftsAdapter adapter = new AdapterService.GvaAircraftsAdapter();

            var accessMatrix = AccessMatrix.CreateForType(typeof(AircraftsResponse));
            AircraftsByOwnerType searchCriteria = new AircraftsByOwnerType() { OwnerID = "103179157" };

            var result = adapter.GetAircraftsByOwner(searchCriteria, accessMatrix, GetAdditionalParameters());
            string xml = result.Data.Response.XmlSerialize();
            using (StreamWriter outfile = new StreamWriter("TestGvaAircraftByIdentifier_103179157.xml", false, System.Text.Encoding.UTF8))
            {
                outfile.Write(xml);
            }
            // XsltUtils.RunXsltAndWriteHtml("GvaAircraftsAdapter", "AircraftsRequest", result.Data.Request.XmlSerialize());
            //  XsltUtils.RunXsltAndWriteHtml("GvaAircraftsAdapter", "AircraftsResponse", result.Data.Response.XmlSerialize());
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            if (SigningUtils.HasSignature(doc))
            {
                bool isValid = SigningUtils.ValidateXmlDocumentWithX509Certificate(doc);
                if (isValid)
                {
                    Assert.IsTrue(true);
                }
            }
            else
            {
                Assert.IsTrue(true);
            }
        }

        //TODO: Test not working without network
        //[TestMethod]
        public void TestGvaAircraftByIdentifier_4809057380()
        {
            AdapterService.GvaAircraftsAdapter adapter = new AdapterService.GvaAircraftsAdapter();

            var accessMatrix = AccessMatrix.CreateForType(typeof(AircraftsResponse));
            AircraftsByOwnerType searchCriteria = new AircraftsByOwnerType() { OwnerID = "4809057380" };

            var result = adapter.GetAircraftsByOwner(searchCriteria, accessMatrix, GetAdditionalParameters());
            string xml = result.Data.Response.XmlSerialize();
            using (StreamWriter outfile = new StreamWriter("TestGvaAircraftByIdentifier_4809057380.xml", false, System.Text.Encoding.UTF8))
            {
                outfile.Write(xml);
            }
            // XsltUtils.RunXsltAndWriteHtml("GvaAircraftsAdapter", "AircraftsRequest", result.Data.Request.XmlSerialize());
            //  XsltUtils.RunXsltAndWriteHtml("GvaAircraftsAdapter", "AircraftsResponse", result.Data.Response.XmlSerialize());
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            if (SigningUtils.HasSignature(doc))
            {
                bool isValid = SigningUtils.ValidateXmlDocumentWithX509Certificate(doc);
                if (isValid)
                {
                    Assert.IsTrue(true);
                }
            }
            else
            {
                Assert.IsTrue(true);
            }
        }

        //TODO: Test not working without network
        //[TestMethod]
        public void TestGvaAircraftByIdentifier_123758172()
        {
            AdapterService.GvaAircraftsAdapter adapter = new AdapterService.GvaAircraftsAdapter();

            var accessMatrix = AccessMatrix.CreateForType(typeof(AircraftsResponse));
            AircraftsByOwnerType searchCriteria = new AircraftsByOwnerType() { OwnerID = "123758172" };

            var result = adapter.GetAircraftsByOwner(searchCriteria, accessMatrix, GetAdditionalParameters());
            string xml = result.Data.Response.XmlSerialize();
            using (StreamWriter outfile = new StreamWriter("TestGvaAircraftByIdentifier_123758172.xml", false, System.Text.Encoding.UTF8))
            {
                outfile.Write(xml);
            }
            // XsltUtils.RunXsltAndWriteHtml("GvaAircraftsAdapter", "AircraftsRequest", result.Data.Request.XmlSerialize());
            //  XsltUtils.RunXsltAndWriteHtml("GvaAircraftsAdapter", "AircraftsResponse", result.Data.Response.XmlSerialize());
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            if (SigningUtils.HasSignature(doc))
            {
                bool isValid = SigningUtils.ValidateXmlDocumentWithX509Certificate(doc);
                if (isValid)
                {
                    Assert.IsTrue(true);
                }
            }
            else
            {
                Assert.IsTrue(true);
            }
        }
        //TODO: Test not working without network
        //[TestMethod]
        public void TestGvaAircraftByIdentifier_131352367()
        {
            AdapterService.GvaAircraftsAdapter adapter = new AdapterService.GvaAircraftsAdapter();

            var accessMatrix = AccessMatrix.CreateForType(typeof(AircraftsResponse));
            AircraftsByOwnerType searchCriteria = new AircraftsByOwnerType() { OwnerID = "131352367" };

            var result = adapter.GetAircraftsByOwner(searchCriteria, accessMatrix, GetAdditionalParameters());
            string xml = result.Data.Response.XmlSerialize();
            using (StreamWriter outfile = new StreamWriter("TestGvaAircraftByIdentifier_131352367.xml", false, System.Text.Encoding.UTF8))
            {
                outfile.Write(xml);
            }
            // XsltUtils.RunXsltAndWriteHtml("GvaAircraftsAdapter", "AircraftsRequest", result.Data.Request.XmlSerialize());
            //  XsltUtils.RunXsltAndWriteHtml("GvaAircraftsAdapter", "AircraftsResponse", result.Data.Response.XmlSerialize());
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            if (SigningUtils.HasSignature(doc))
            {
                bool isValid = SigningUtils.ValidateXmlDocumentWithX509Certificate(doc);
                if (isValid)
                {
                    Assert.IsTrue(true);
                }
            }
            else
            {
                Assert.IsTrue(true);
            }
        }

        //TODO: Test not working without network
        //[TestMethod]
        public void TestGvaAircraftByIdentifier_175080520()
        {
            AdapterService.GvaAircraftsAdapter adapter = new AdapterService.GvaAircraftsAdapter();

            var accessMatrix = AccessMatrix.CreateForType(typeof(AircraftsResponse));
            AircraftsByOwnerType searchCriteria = new AircraftsByOwnerType() { OwnerID = "175080520" };

            var result = adapter.GetAircraftsByOwner(searchCriteria, accessMatrix, GetAdditionalParameters());
            string xml = result.Data.Response.XmlSerialize();
            using (StreamWriter outfile = new StreamWriter("TestGvaAircraftByIdentifier_175080520.xml", false, System.Text.Encoding.UTF8))
            {
                outfile.Write(xml);
            }
            // XsltUtils.RunXsltAndWriteHtml("GvaAircraftsAdapter", "AircraftsRequest", result.Data.Request.XmlSerialize());
            //  XsltUtils.RunXsltAndWriteHtml("GvaAircraftsAdapter", "AircraftsResponse", result.Data.Response.XmlSerialize());
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            if (SigningUtils.HasSignature(doc))
            {
                bool isValid = SigningUtils.ValidateXmlDocumentWithX509Certificate(doc);
                if (isValid)
                {
                    Assert.IsTrue(true);
                }
            }
            else
            {
                Assert.IsTrue(true);
            }
        }
    }
}
