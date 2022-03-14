using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegiX.Adapters.FileParameterStore;
using TechnoLogica.RegiX.IAMASeafarersAdapter.AdapterService;
using TechnoLogica.RegiX.Adapters.TestUtils;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.Common.Utils;

namespace TechnoLogica.RegiX.IAMASeafarersAdapter.Tests
{
    [TestClass]
    public class IAMASeafarersAdapterTest : AdapterTest<SeafarersAdapter, ISeafarersAdapter>
    {

        public IAMASeafarersAdapterTest()
        {
            AggregateCatalog catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(AdapterService.SeafarersAdapter).Assembly));
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(FileParameterStoreImplementation).Assembly));
            catalog.Catalogs.Add(new TypeCatalog(typeof(BinDirectoryLocator)));
            CompositionContainer result = new CompositionContainer(catalog, true);
            result.ComposeExportedValue(result);
            Composition.CompositionContainer = result;
        }


        public void SeafarersAdapterTest_CheckHealthCheckAndParamtersTest()
        {
            SeafarersAdapter adapter = new SeafarersAdapter();
            //test GetParameters , and ConnectionString
            var connectionString = adapter.GetParameters().ParameterList.Where(p => p.Key == Common.Constants.WebServiceUrlParameterKeyName).FirstOrDefault();
            //test SetParameter
            adapter.SetParameter(TechnoLogica.RegiX.Common.Constants.WebServiceUrlParameterKeyName, connectionString.CurrentValue);
            //test HCfunctions
            var hcFunctions = adapter.GetHealthCheckFunctions();
            string checkHealthFunctionResult = string.Empty;
            hcFunctions.HealthInfosList.ForEach(f =>
            {
                checkHealthFunctionResult = checkHealthFunctionResult + f.Key + ":" + adapter.CheckHealthFunction(f.Key) + ";\r\n";
            });
            using (StreamWriter outfile = new StreamWriter("CheckHealthFunctions.xml", false, System.Text.Encoding.UTF8))
            {
                outfile.Write(checkHealthFunctionResult);
            }


            Assert.IsTrue(true);
        }

        public void SeafarersAdapterTest_CheckRegisterConnection()
        {
            SeafarersAdapter adapter = new SeafarersAdapter();
            string result = adapter.CheckRegisterConnection();
            Assert.IsTrue(result == TechnoLogica.RegiX.Common.Constants.ConnectionOk || result == TechnoLogica.RegiX.Common.Constants.ConnectionStringNotSet);
        }

        //TODO: Fix ParameterStore mock
       // [TestMethod]
        public void SeafarersLicensesSearchTest()
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
            string oldcontext = context.ToString();

            SeafarersAdapter adapter = new SeafarersAdapter();
            var accessMatrix = AccessMatrix.CreateForType(typeof(SeafarersLicensesResponseType));
            SeafarersLicensesRequestType searchCriteria = new SeafarersLicensesRequestType { EGN = "8901084451" };

            AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
            additionalParameters.CallContext = new CallContext() { Remark = "RegiXTest" };

            // "\"LawReason\":\"�������� �� RegiX\",\"ServiceURI\":\"123456789\",\�ServiceType\�:\��� ������������ �������\�\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"������������ �� ����������� � �������\",\� UserAdministrationID\�:\�10.20.503.4\�,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";

            additionalParameters.CitizenEGN = "8888888888";
            additionalParameters.ClientIPAddress = "111.111.111.111";
            additionalParameters.ConsumerCertificateThumbprint = "###";
            additionalParameters.EIDToken = "token123";
            additionalParameters.EmployeeEGN = "11111111111111";
            additionalParameters.OrganizationEIK = "12121212121";
            additionalParameters.OrganizationUnit = "qqqqqq";
            additionalParameters.SignResult = false;
            additionalParameters.ReturnAccessMatrix = true;

            var result = adapter.SeafarersLicensesSearch(searchCriteria, accessMatrix, additionalParameters);

            string xml = result.Data.Response.XmlSerialize();
            using (StreamWriter outfile = new StreamWriter("IAMASeafarers.xml", false, System.Text.Encoding.UTF8))
            {
                outfile.Write(xml);
            }
            XsltUtils.RunXsltAndWriteHtml("IAMASeafarersAdapter", "IAMASeafarersLicensesRequest", result.Data.Request.XmlSerialize());
            XsltUtils.RunXsltAndWriteHtml("IAMASeafarersAdapter", "IAMASeafarersLicensesResponse", result.Data.Response.XmlSerialize());

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


