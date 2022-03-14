using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Xml;
using RegiX.Adapters.FileParameterStore;
using TechnoLogica.RegiX.Adapters.TestUtils;
using TechnoLogica.RegiX.ASPFosterParentsAdapter.AdapterService;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.Common.Utils;


namespace TechnoLogica.RegiX.ASPFosterParentsAdapter.Tests
{
    [TestClass]
    public class ASPFosterParentsAdapterTests : AdapterTest<AdapterService.ASPFosterParentsAdapter, IASPFosterParentsAdapter>
    {
        public ASPFosterParentsAdapterTests()
        {
            AggregateCatalog catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(AdapterService.ASPFosterParentsAdapter).Assembly));
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(FileParameterStoreImplementation).Assembly));
            catalog.Catalogs.Add(new TypeCatalog(typeof(BinDirectoryLocator)));
            CompositionContainer result = new CompositionContainer(catalog, true);
            result.ComposeExportedValue(result);
            Composition.CompositionContainer = result;
        }

        [TestMethod]
        public void SendRequestForFosterParentsTest()
        {
          CallContext context = new CallContext()
            {
                AdministrationOId = "https://trust-party-openid.com",
                LawReason = "Тестване на RegiX",
                ServiceURI = "1222-200030-12.12.2022",
                Remark = "Забележки",
                EmployeeAditionalIdentifier = "Карта номер 3",
                EmployeeIdentifier = "test@tesactivedirectory.com",
                EmployeeNames = "Тестов Потребител Потребител",
                AdministrationName = "Българска агенция за Тестване",
                EmployeePosition = "Старши експерт Отдел \"Тестване на интеграцията\"",
                ResponsiblePersonIdentifier = "392309324",
                ServiceType = "За проверовъчна дейност"
            };
            string oldcontext = context.ToString();

            AdapterService.ASPFosterParentsAdapter adapter = new AdapterService.ASPFosterParentsAdapter();

            var accessMatrix = AccessMatrix.CreateForType(typeof(AspFosterParentsResponse));

            var additionalParameters = new AdapterAdditionalParameters();

            additionalParameters.CallContext = new CallContext() { Remark = "RegiXTest" };

            // "\"LawReason\":\"Тестване на RegiX\",\"ServiceURI\":\"123456789\",\”ServiceType\”:\”За проверовъчна дейност\”\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"Министерство на земеделието и храните\",\” UserAdministrationID\”:\”10.20.503.4\”,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";

            additionalParameters.CitizenEGN = "8888888888";
            additionalParameters.ClientIPAddress = "111.111.111.111";
            additionalParameters.ConsumerCertificateThumbprint = "###";
            additionalParameters.EIDToken = "token123";
            additionalParameters.EmployeeEGN = "11111111111111";
            additionalParameters.OrganizationEIK = "12121212121";
            additionalParameters.OrganizationUnit = "qqqqqq";
            additionalParameters.SignResult = false;
            additionalParameters.ReturnAccessMatrix = false;

            AspFosterParentsRequest searchCriteria = new AspFosterParentsRequest();
            searchCriteria.Header = new AspHeader();
            searchCriteria.Header.StartDate = new DateTime(2015, 10, 10);
            searchCriteria.Header.EndDate = new DateTime(2015, 11, 10);
            searchCriteria.Header.RequestSize = 2;
            searchCriteria.Header.IsunCode = "abc";

            searchCriteria.Data = new AspData();
            searchCriteria.Data.DataItem = new List<AspDataItem>();
            searchCriteria.Data.DataItem.Add(new AspDataItem()
            {
                Row = 3,
                IdentificatorParent = "9795939190",
                IdentTypeParent = IdentTypeType.Item1,
                IdentTypeParentSpecified = true,
            });
            searchCriteria.Data.DataItem.Add(new AspDataItem()
            {
                Row = 4,
                IdentificatorChild = "1525354555",
                IdentTypeChild = IdentTypeType.Item1,
                IdentTypeChildSpecified = true,
            });
            searchCriteria.Data.DataItem.Add(new AspDataItem()
            {
                Row = 4,
                IdentificatorParent = "9795939190",
                IdentTypeParent = IdentTypeType.Item1,
                IdentTypeParentSpecified = true,
                IdentificatorChild = "1525354555",
                IdentTypeChild = IdentTypeType.Item2,
                IdentTypeChildSpecified = true,
            });

            var result = adapter.SendRequestForFosterParents(searchCriteria, accessMatrix, additionalParameters);
            string xml = result.XmlSerialize();
            using (StreamWriter outfile = new StreamWriter("SendRequestForFosterParents.xml", false, System.Text.Encoding.UTF8))
            {
                outfile.Write(xml);
            }

            XsltUtils.RunXsltAndWriteHtml("ASPFosterParentsAdapter", "SendRequestForFosterParentsResponse", result.Data.Request.XmlSerialize());
            XsltUtils.RunXsltAndWriteHtml("ASPFosterParentsAdapter", "SendRequestForFosterParentsRequest", result.Data.Response.XmlSerialize());

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            if (SigningUtils.HasSignature(doc))
            {
                bool isValid = SigningUtils.ValidateXmlDocumentWithX509Certificate(doc.DocumentElement);
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
