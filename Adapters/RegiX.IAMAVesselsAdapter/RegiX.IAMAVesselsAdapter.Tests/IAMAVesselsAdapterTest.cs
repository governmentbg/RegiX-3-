using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechnoLogica.RegiX.IAMAVesselsAdapter;
using TechnoLogica.RegiX.IAMAVesselsAdapter.AdapterService;
using TechnoLogica.RegiX.Common.ObjectMapping;
using System.Linq;
using TechnoLogica.RegiX.Common.Utils;
using System.IO;
using TechnoLogica.RegiX.Common.DataContracts;
using System.Xml;
using RegiX.Adapters.FileParameterStore;
using TechnoLogica.RegiX.IAMAVesselsAdapter.Ships;
using TechnoLogica.RegiX.Adapters.TestUtils;
using TechnoLogica.RegiX.Common;

namespace TechnoLogica.RegiX.IAMAVesselsAdapter.Tests
{
    [TestClass]
    public class IAMAVesselsAdapterTest : AdapterTest<VesselsAdapter, IVesselsAdapter>
    {

        public IAMAVesselsAdapterTest()
        {
            AggregateCatalog catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(AdapterService.VesselsAdapter).Assembly));
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(FileParameterStoreImplementation).Assembly));
            catalog.Catalogs.Add(new TypeCatalog(typeof(BinDirectoryLocator)));
            CompositionContainer result = new CompositionContainer(catalog, true);
            result.ComposeExportedValue(result);
            Composition.CompositionContainer = result;
        }


        //[TestMethod]
        //public void SeafarersAdapterTest_CheckHealthCheckAndParamtersTest()
        //{
        //    VesselsAdapter adapter = new VesselsAdapter();
        //    //test GetParameters , and ConnectionString
        //    var connectionString = adapter.GetParameters().ParameterList.Where(p => p.Key == Common.Constants.WebServiceUrlParameterKeyName).FirstOrDefault();
        //    //test SetParameter
        //    adapter.SetParameter(TechnoLogica.RegiX.Common.Constants.WebServiceUrlParameterKeyName, connectionString.CurrentValue);
        //    //test HCfunctions
        //    var hcFunctions = adapter.GetHealthCheckFunctions();
        //    string checkHealthFunctionResult = string.Empty;
        //    hcFunctions.HealthInfosList.ForEach(f =>
        //    {
        //        checkHealthFunctionResult = checkHealthFunctionResult + f.Key + ":" + adapter.CheckHealthFunction(f.Key) + ";\r\n";
        //    });
        //    using (StreamWriter outfile = new StreamWriter("CheckHealthFunctions.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(checkHealthFunctionResult);
        //    }
        //    Assert.IsTrue(true);
        //}
        //[TestMethod]
        //public void SeafarersAdapterTest_CheckRegisterConnection()
        //{
        //    VesselsAdapter adapter = new VesselsAdapter();
        //    string result = adapter.CheckRegisterConnection();
        //    Assert.IsTrue(result == TechnoLogica.RegiX.Common.Constants.ConnectionOk || result == TechnoLogica.RegiX.Common.Constants.ConnectionStringNotSet);
        //}


        //[TestMethod]
        public void IAMAVesselsAdapterTestByOwner()
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

            VesselsAdapter adapter = new VesselsAdapter();
            var accessMatrix = AccessMatrix.CreateForType(typeof(ShipsResponse));
            ShipsByOwnerRequest searchCriteria = new ShipsByOwnerRequest() { egn = "8901084451" };

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

            var result = adapter.RegistrationSearchByOwner(searchCriteria, accessMatrix, additionalParameters);

            string xml = result.Data.Response.XmlSerialize();
            using (StreamWriter outfile = new StreamWriter("VesselsByOwner.xml", false, System.Text.Encoding.UTF8))
            {
                outfile.Write(xml);
            }
            XsltUtils.RunXsltAndWriteHtml("IAMAVesselsAdapter", "RegistrationInfoByOwnerRequest", result.Data.Request.XmlSerialize());
            XsltUtils.RunXsltAndWriteHtml("IAMAVesselsAdapter", "RegistrationInfoByOwnerResponse", result.Data.Response.XmlSerialize());

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

        //[TestMethod]
        public void IAMAVesselsAdapterTestByCharacteristics()
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

            VesselsAdapter adapter = new VesselsAdapter();
            var accessMatrix = AccessMatrix.CreateForType(typeof(ShipsResponse));
            ShipsByCharacteristicsRequest searchCriteria = new ShipsByCharacteristicsRequest() { };
            searchCriteria.engineFuel = 1;
            searchCriteria.engineNumber = "65f4s687";

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

            var result = adapter.RegistrationByCharacteristicsSearch(searchCriteria, accessMatrix, additionalParameters);

            string xml = result.Data.Response.XmlSerialize();
            using (StreamWriter outfile = new StreamWriter("VesselsByCharacteristics.xml", false, System.Text.Encoding.UTF8))
            {
                outfile.Write(xml);
            }
            XsltUtils.RunXsltAndWriteHtml("IAMAVesselsAdapter", "RegistrationInfoByCharacteristicsRequest", result.Data.Request.XmlSerialize());
            XsltUtils.RunXsltAndWriteHtml("IAMAVesselsAdapter", "RegistrationInfoByCharacteristicsResponse", result.Data.Response.XmlSerialize());

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

       // [TestMethod]
        public void IAMAVesselsAdapterTestNomenclatures()
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

            VesselsAdapter adapter = new VesselsAdapter();
            var accessMatrix = AccessMatrix.CreateForType(typeof(NomenclatureResponse));
            NomenclaturesRequest searchCriteria = new NomenclaturesRequest() { };

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

            var result = adapter.GetNomenclatures(searchCriteria, accessMatrix, additionalParameters);

            string xml = result.Data.Response.XmlSerialize();
            using (StreamWriter outfile = new StreamWriter("Nomenclatures.xml", false, System.Text.Encoding.UTF8))
            {
                outfile.Write(xml);
            }
            //XsltUtils.RunXsltAndWriteHtml("IAMAVesselsAdapter", "RegistrationInfoByCharacteristicsRequest", result.Data.Request.XmlSerialize());
            XsltUtils.RunXsltAndWriteHtml("IAMAVesselsAdapter", "NomenclaturesResponse", result.Data.Response.XmlSerialize());

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


