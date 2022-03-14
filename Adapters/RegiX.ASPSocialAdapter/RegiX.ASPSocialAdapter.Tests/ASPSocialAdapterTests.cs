using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.Common.DataContracts;
using System.IO;
using TechnoLogica.RegiX.Common.Utils;
using System.Xml;
using System.Linq;
using RegiX.Adapters.FileParameterStore;
using TechnoLogica.RegiX.ASPSocialAdapter.AdapterService;
using TechnoLogica.RegiX.Adapters.TestUtils;
using TechnoLogica.RegiX.Common;

namespace TechnoLogica.RegiX.ASPSocialAdapter.Tests
{
    [TestClass]
    public class ASPSocialAdapterTests : AdapterTest<AdapterService.ASPSocialAdapter, IASPSocialAdapter>
    {

        public ASPSocialAdapterTests()
        {
            AggregateCatalog catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(AdapterService.ASPSocialAdapter).Assembly));
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(FileParameterStoreImplementation).Assembly));
            catalog.Catalogs.Add(new TypeCatalog(typeof(BinDirectoryLocator)));
            CompositionContainer result = new CompositionContainer(catalog, true);
            result.ComposeExportedValue(result);
            Composition.CompositionContainer = result;
        }

        [TestMethod]
        public void ASPSocialAdapter_CheckHealthCheckAndParamtersTest()
        {
            AdapterService.ASPSocialAdapter adapter = new AdapterService.ASPSocialAdapter();
           // test GetParameters, and ConnectionString
           //var connectionString = adapter.GetParameters().ParameterList.Where(p => p.Key == Common.Constants.ConnectionStringParameterKeyName).FirstOrDefault();
           // test SetParameter
           // adapter.SetParameter(Common.Constants.ConnectionStringParameterKeyName, connectionString.CurrentValue);
           // test HCfunctions
            var hcFunctions = adapter.GetHealthCheckFunctions();
            hcFunctions.HealthInfosList.ForEach(f => adapter.CheckHealthFunction(f.Key));
            Assert.IsTrue(true);
        }

        //[TestMethod]
        //public void ASPSocialAdapter_CheckRegisterConnection()
        //{
        //    AdapterService.ASPSocialAdapter adapter = new AdapterService.ASPSocialAdapter();
        //    adapter.ParameterStore = new FileParameterStoreImplementation();
        //    string result = adapter.CheckRegisterConnection();
        //    Assert.IsTrue(result == TechnoLogica.RegiX.Common.Constants.ConnectionOk || result == TechnoLogica.RegiX.Common.Constants.ConnectionStringNotSet);
        //}

        //[TestMethod]
        //public void GetMonthlySocialBenefitsTest()
        //{
        //    CallContext context = new CallContext()
        //    {
        //        AdministrationOId = "https://trust-party-openid.com",
        //        LawReason = "Тестване на RegiX",
        //        ServiceURI = "1222-200030-12.12.2022",
        //        Remark = "Забележки",
        //        EmployeeAditionalIdentifier = "Карта номер 3",
        //        EmployeeIdentifier = "test@tesactivedirectory.com",
        //        EmployeeNames = "Тестов Потребител Потребител",
        //        AdministrationName = "Българска агенция за Тестване",
        //        EmployeePosition = "Старши експерт Отдел \"Тестване на интеграцията\"",
        //        ResponsiblePersonIdentifier = "392309324",
        //        ServiceType = "За проверовъчна дейност"
        //    };
        //    string oldcontext = context.ToString();

        //    AdapterService.ASPSocialAdapter adapter = new AdapterService.ASPSocialAdapter();

        //    var accessMatrix = AccessMatrix.CreateForType(typeof(GetMonthlySocialBenefitsResponseType));

        //    AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
        //    additionalParameters.CallContext = new CallContext() { Remark = "RegiXTest" };// "\"LawReason\":\"Тестване на RegiX\",\"ServiceURI\":\"123456789\",\”ServiceType\”:\”За проверовъчна дейност\”\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"Министерство на земеделието и храните\",\” UserAdministrationID\”:\”10.20.503.4\”,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";
        //    additionalParameters.CitizenEGN = "8888888888";
        //    additionalParameters.ClientIPAddress = "111.111.111.111";
        //    additionalParameters.ConsumerCertificateThumbprint = "###";
        //    additionalParameters.EIDToken = "token123";
        //    additionalParameters.EmployeeEGN = "11111111111111";
        //    additionalParameters.OrganizationEIK = "12121212121";
        //    additionalParameters.OrganizationUnit = "qqqqqq";
        //    additionalParameters.SignResult = false;
        //    additionalParameters.ReturnAccessMatrix = false;

        //    GetMonthlySocialBenefitsRequest searchCriteria = new GetMonthlySocialBenefitsRequest();
        //    searchCriteria.PersonData = new PersonRequestType() { Identifier = "8112246848", IdentifierType = IdentifierType.EGN };
        //    var result = adapter.GetMonthlySocialBenefits(searchCriteria, accessMatrix, additionalParameters);
        //    string xml = result.XmlSerialize();
        //    using (StreamWriter outfile = new StreamWriter("GetMonthlySocialBenefitsTest.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(xml);
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("ASPSocialAdapter", "GetMonthlySocialBenefitsRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("ASPSocialAdapter", "GetMonthlySocialBenefitsResponse", result.Data.Response.XmlSerialize());

        //    XmlDocument doc = new XmlDocument();
        //    doc.LoadXml(xml);
        //    if (SigningUtils.HasSignature(doc))
        //    {
        //        bool isValid = SigningUtils.ValidateXmlDocumentWithX509Certificate(doc.DocumentElement);
        //        if (isValid)
        //        {
        //            Assert.IsTrue(true);
        //        }
        //    }
        //    else
        //    {
        //        Assert.IsTrue(true);
        //    }
        //}

        //[TestMethod]
        //public void GetMonthlySocialBenefitsNULLTest()
        //{
        //    CallContext context = new CallContext()
        //    {
        //        AdministrationOId = "https://trust-party-openid.com",
        //        LawReason = "Тестване на RegiX",
        //        ServiceURI = "1222-200030-12.12.2022",
        //        Remark = "Забележки",
        //        EmployeeAditionalIdentifier = "Карта номер 3",
        //        EmployeeIdentifier = "test@tesactivedirectory.com",
        //        EmployeeNames = "Тестов Потребител Потребител",
        //        AdministrationName = "Българска агенция за Тестване",
        //        EmployeePosition = "Старши експерт Отдел \"Тестване на интеграцията\"",
        //        ResponsiblePersonIdentifier = "392309324",
        //        ServiceType = "За проверовъчна дейност"
        //    };
        //    string oldcontext = context.ToString();

        //    AdapterService.ASPSocialAdapter adapter = new AdapterService.ASPSocialAdapter();

        //    var accessMatrix = AccessMatrix.CreateForType(typeof(GetMonthlySocialBenefitsResponseType));

        //    AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
        //    additionalParameters.CallContext = new CallContext() { Remark = "RegiXTest" };// "\"LawReason\":\"Тестване на RegiX\",\"ServiceURI\":\"123456789\",\”ServiceType\”:\”За проверовъчна дейност\”\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"Министерство на земеделието и храните\",\” UserAdministrationID\”:\”10.20.503.4\”,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";
        //    additionalParameters.CitizenEGN = "8888888888";
        //    additionalParameters.ClientIPAddress = "111.111.111.111";
        //    additionalParameters.ConsumerCertificateThumbprint = "###";
        //    additionalParameters.EIDToken = "token123";
        //    additionalParameters.EmployeeEGN = "11111111111111";
        //    additionalParameters.OrganizationEIK = "12121212121";
        //    additionalParameters.OrganizationUnit = "qqqqqq";
        //    additionalParameters.SignResult = false;
        //    additionalParameters.ReturnAccessMatrix = false;

        //    GetMonthlySocialBenefitsRequest searchCriteria = new GetMonthlySocialBenefitsRequest();
        //    searchCriteria.PersonData = new PersonRequestType() { Identifier = "811224684811", IdentifierType = IdentifierType.LNCh };
        //    var result = adapter.GetMonthlySocialBenefits(searchCriteria, accessMatrix, additionalParameters);
        //    string xml = result.XmlSerialize();
        //    using (StreamWriter outfile = new StreamWriter("GetMonthlySocialBenefitsNULLTest.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(xml);
        //    }

        //    //XsltUtils.RunXsltAndWriteHtml("ASPSocialAdapter", "GetMonthlySocialBenefitsRequest", result.Data.Request.XmlSerialize());
        //    //XsltUtils.RunXsltAndWriteHtml("ASPSocialAdapter", "GetMonthlySocialBenefitsResponse", result.Data.Response.XmlSerialize());

        //    XmlDocument doc = new XmlDocument();
        //    doc.LoadXml(xml);
        //    if (SigningUtils.HasSignature(doc))
        //    {
        //        bool isValid = SigningUtils.ValidateXmlDocumentWithX509Certificate(doc.DocumentElement);
        //        if (isValid)
        //        {
        //            Assert.IsTrue(true);
        //        }
        //    }
        //    else
        //    {
        //        Assert.IsTrue(true);
        //    }
        //}

        //[TestMethod]
        //public void GetBenefitsForHeatingTest()
        //{
        //    CallContext context = new CallContext()
        //    {
        //        AdministrationOId = "https://trust-party-openid.com",
        //        LawReason = "Тестване на RegiX",
        //        ServiceURI = "1222-200030-12.12.2022",
        //        Remark = "Забележки",
        //        EmployeeAditionalIdentifier = "Карта номер 3",
        //        EmployeeIdentifier = "test@tesactivedirectory.com",
        //        EmployeeNames = "Тестов Потребител Потребител",
        //        AdministrationName = "Българска агенция за Тестване",
        //        EmployeePosition = "Старши експерт Отдел \"Тестване на интеграцията\"",
        //        ResponsiblePersonIdentifier = "392309324",
        //        ServiceType = "За проверовъчна дейност"
        //    };
        //    string oldcontext = context.ToString();

        //    AdapterService.ASPSocialAdapter adapter = new AdapterService.ASPSocialAdapter();

        //    var accessMatrix = AccessMatrix.CreateForType(typeof(GetBenefitsForHeatingResponseType));

        //    AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
        //    additionalParameters.CallContext = new CallContext() { Remark = "RegiXTest" };// "\"LawReason\":\"Тестване на RegiX\",\"ServiceURI\":\"123456789\",\”ServiceType\”:\”За проверовъчна дейност\”\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"Министерство на земеделието и храните\",\” UserAdministrationID\”:\”10.20.503.4\”,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";
        //    additionalParameters.CitizenEGN = "8888888888";
        //    additionalParameters.ClientIPAddress = "111.111.111.111";
        //    additionalParameters.ConsumerCertificateThumbprint = "###";
        //    additionalParameters.EIDToken = "token123";
        //    additionalParameters.EmployeeEGN = "11111111111111";
        //    additionalParameters.OrganizationEIK = "12121212121";
        //    additionalParameters.OrganizationUnit = "qqqqqq";
        //    additionalParameters.SignResult = false;
        //    additionalParameters.ReturnAccessMatrix = false;

        //    GetBenefitsForHeatingRequest searchCriteria = new GetBenefitsForHeatingRequest();
        //    searchCriteria.PersonData = new PersonRequestType() { Identifier = "5509221709", IdentifierType = IdentifierType.EGN };
        //    var result = adapter.GetBenefitsForHeating(searchCriteria, accessMatrix, additionalParameters);
        //    string xml = result.XmlSerialize();
        //    using (StreamWriter outfile = new StreamWriter("GetBenefitsForHeatingTest.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(xml);
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("ASPSocialAdapter", "GetBenefitsForHeatingRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("ASPSocialAdapter", "GetBenefitsForHeatingResponse", result.Data.Response.XmlSerialize());

        //    XmlDocument doc = new XmlDocument();
        //    doc.LoadXml(xml);
        //    if (SigningUtils.HasSignature(doc))
        //    {
        //        bool isValid = SigningUtils.ValidateXmlDocumentWithX509Certificate(doc.DocumentElement);
        //        if (isValid)
        //        {
        //            Assert.IsTrue(true);
        //        }
        //    }
        //    else
        //    {
        //        Assert.IsTrue(true);
        //    }
        //}

        //[TestMethod]
        //public void GetBenefitsForHeatingNULLTest()
        //{
        //   CallContext context = new CallContext()
        //    {
        //        AdministrationOId = "https://trust-party-openid.com",
        //        LawReason = "Тестване на RegiX",
        //        ServiceURI = "1222-200030-12.12.2022",
        //        Remark = "Забележки",
        //        EmployeeAditionalIdentifier = "Карта номер 3",
        //        EmployeeIdentifier = "test@tesactivedirectory.com",
        //        EmployeeNames = "Тестов Потребител Потребител",
        //        AdministrationName = "Българска агенция за Тестване",
        //        EmployeePosition = "Старши експерт Отдел \"Тестване на интеграцията\"",
        //        ResponsiblePersonIdentifier = "392309324",
        //        ServiceType = "За проверовъчна дейност"
        //    };
        //    string oldcontext = context.ToString();

        //    AdapterService.ASPSocialAdapter adapter = new AdapterService.ASPSocialAdapter();

        //    var accessMatrix = AccessMatrix.CreateForType(typeof(GetBenefitsForHeatingResponseType));

        //    AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
        //    additionalParameters.CallContext = new CallContext() { Remark = "RegiXTest" };
            
        //    // "\"LawReason\":\"Тестване на RegiX\",\"ServiceURI\":\"123456789\",\”ServiceType\”:\”За проверовъчна дейност\”\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"Министерство на земеделието и храните\",\” UserAdministrationID\”:\”10.20.503.4\”,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";

        //    additionalParameters.CitizenEGN = "8888888888";
        //    additionalParameters.ClientIPAddress = "111.111.111.111";
        //    additionalParameters.ConsumerCertificateThumbprint = "###";
        //    additionalParameters.EIDToken = "token123";
        //    additionalParameters.EmployeeEGN = "11111111111111";
        //    additionalParameters.OrganizationEIK = "12121212121";
        //    additionalParameters.OrganizationUnit = "qqqqqq";
        //    additionalParameters.SignResult = false;
        //    additionalParameters.ReturnAccessMatrix = false;

        //    GetBenefitsForHeatingRequest searchCriteria = new GetBenefitsForHeatingRequest();
        //    searchCriteria.PersonData = new PersonRequestType() { Identifier = "55092217090", IdentifierType = IdentifierType.EGN };
        //    var result = adapter.GetBenefitsForHeating(searchCriteria, accessMatrix, additionalParameters);
        //    string xml = result.XmlSerialize();
        //    using (StreamWriter outfile = new StreamWriter("GetBenefitsForHeatingNULLTest.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(xml);
        //    }

        //    //XsltUtils.RunXsltAndWriteHtml("ASPSocialAdapter", "GetBenefitsForHeatingRequest", result.Data.Request.XmlSerialize());
        //    //XsltUtils.RunXsltAndWriteHtml("ASPSocialAdapter", "GetBenefitsForHeatingResponse", result.Data.Response.XmlSerialize());

        //    XmlDocument doc = new XmlDocument();
        //    doc.LoadXml(xml);
        //    if (SigningUtils.HasSignature(doc))
        //    {
        //        bool isValid = SigningUtils.ValidateXmlDocumentWithX509Certificate(doc.DocumentElement);
        //        if (isValid)
        //        {
        //            Assert.IsTrue(true);
        //        }
        //    }
        //    else
        //    {
        //        Assert.IsTrue(true);
        //    }
        //}

        //[TestMethod]
        //public void GetSocialServicesDecisionsTest()
        //{
        //    CallContext context = new CallContext()
        //    {
        //        AdministrationOId = "https://trust-party-openid.com",
        //        LawReason = "Тестване на RegiX",
        //        ServiceURI = "1222-200030-12.12.2022",
        //        Remark = "Забележки",
        //        EmployeeAditionalIdentifier = "Карта номер 3",
        //        EmployeeIdentifier = "test@tesactivedirectory.com",
        //        EmployeeNames = "Тестов Потребител Потребител",
        //        AdministrationName = "Българска агенция за Тестване",
        //        EmployeePosition = "Старши експерт Отдел \"Тестване на интеграцията\"",
        //        ResponsiblePersonIdentifier = "392309324",
        //        ServiceType = "За проверовъчна дейност"
        //    };
        //    string oldcontext = context.ToString();

        //    AdapterService.ASPSocialAdapter adapter = new AdapterService.ASPSocialAdapter();

        //    var accessMatrix = AccessMatrix.CreateForType(typeof(GetSocialServicesDecisionsResponseType));

        //    AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
        //    additionalParameters.CallContext = new CallContext() { Remark = "RegiXTest" };// "\"LawReason\":\"Тестване на RegiX\",\"ServiceURI\":\"123456789\",\”ServiceType\”:\”За проверовъчна дейност\”\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"Министерство на земеделието и храните\",\” UserAdministrationID\”:\”10.20.503.4\”,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";
        //    additionalParameters.CitizenEGN = "8888888888";
        //    additionalParameters.ClientIPAddress = "111.111.111.111";
        //    additionalParameters.ConsumerCertificateThumbprint = "###";
        //    additionalParameters.EIDToken = "token123";
        //    additionalParameters.EmployeeEGN = "11111111111111";
        //    additionalParameters.OrganizationEIK = "12121212121";
        //    additionalParameters.OrganizationUnit = "qqqqqq";
        //    additionalParameters.SignResult = false;
        //    additionalParameters.ReturnAccessMatrix = false;

        //    GetSocialServicesDecisionsRequest searchCriteria = new GetSocialServicesDecisionsRequest();
        //    searchCriteria.PersonData = new PersonRequestType() { Identifier = "6308246245", IdentifierType = IdentifierType.EGN };
        //    var result = adapter.GetSocialServicesDecisions(searchCriteria, accessMatrix, additionalParameters);
        //    string xml = result.XmlSerialize();
        //    using (StreamWriter outfile = new StreamWriter("GetSocialServicesDecisionsTest.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(xml);
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("ASPSocialAdapter", "GetSocialServicesDecisionsRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("ASPSocialAdapter", "GetSocialServicesDecisionsResponse", result.Data.Response.XmlSerialize());

        //    XmlDocument doc = new XmlDocument();
        //    doc.LoadXml(xml);
        //    if (SigningUtils.HasSignature(doc))
        //    {
        //        bool isValid = SigningUtils.ValidateXmlDocumentWithX509Certificate(doc.DocumentElement);
        //        if (isValid)
        //        {
        //            Assert.IsTrue(true);
        //        }
        //    }
        //    else
        //    {
        //        Assert.IsTrue(true);
        //    }
        //}

        //[TestMethod]
        //public void GetSocialServicesDecisionsNULLTest()
        //{
        //   CallContext context = new CallContext()
        //    {
        //        AdministrationOId = "https://trust-party-openid.com",
        //        LawReason = "Тестване на RegiX",
        //        ServiceURI = "1222-200030-12.12.2022",
        //        Remark = "Забележки",
        //        EmployeeAditionalIdentifier = "Карта номер 3",
        //        EmployeeIdentifier = "test@tesactivedirectory.com",
        //        EmployeeNames = "Тестов Потребител Потребител",
        //        AdministrationName = "Българска агенция за Тестване",
        //        EmployeePosition = "Старши експерт Отдел \"Тестване на интеграцията\"",
        //        ResponsiblePersonIdentifier = "392309324",
        //        ServiceType = "За проверовъчна дейност"
        //    };
        //    string oldcontext = context.ToString();

        //    AdapterService.ASPSocialAdapter adapter = new AdapterService.ASPSocialAdapter();

        //    var accessMatrix = AccessMatrix.CreateForType(typeof(GetSocialServicesDecisionsResponseType));

        //    AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
        //    additionalParameters.CallContext = new CallContext() { Remark = "RegiXTest" };// "\"LawReason\":\"Тестване на RegiX\",\"ServiceURI\":\"123456789\",\”ServiceType\”:\”За проверовъчна дейност\”\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"Министерство на земеделието и храните\",\” UserAdministrationID\”:\”10.20.503.4\”,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";
        //    additionalParameters.CitizenEGN = "8888888888";
        //    additionalParameters.ClientIPAddress = "111.111.111.111";
        //    additionalParameters.ConsumerCertificateThumbprint = "###";
        //    additionalParameters.EIDToken = "token123";
        //    additionalParameters.EmployeeEGN = "11111111111111";
        //    additionalParameters.OrganizationEIK = "12121212121";
        //    additionalParameters.OrganizationUnit = "qqqqqq";
        //    additionalParameters.SignResult = false;
        //    additionalParameters.ReturnAccessMatrix = false;

        //    GetSocialServicesDecisionsRequest searchCriteria = new GetSocialServicesDecisionsRequest();
        //    searchCriteria.PersonData = new PersonRequestType() { Identifier = "63082462450", IdentifierType = IdentifierType.LNCh };
        //    var result = adapter.GetSocialServicesDecisions(searchCriteria, accessMatrix, additionalParameters);
        //    string xml = result.XmlSerialize();
        //    using (StreamWriter outfile = new StreamWriter("GetSocialServicesDecisionsNULLTest.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(xml);
        //    }

        //    //XsltUtils.RunXsltAndWriteHtml("ASPSocialAdapter", "GetSocialServicesDecisionsRequest", result.Data.Request.XmlSerialize());
        //    //XsltUtils.RunXsltAndWriteHtml("ASPSocialAdapter", "GetSocialServicesDecisionsResponse", result.Data.Response.XmlSerialize());

        //    XmlDocument doc = new XmlDocument();
        //    doc.LoadXml(xml);
        //    if (SigningUtils.HasSignature(doc))
        //    {
        //        bool isValid = SigningUtils.ValidateXmlDocumentWithX509Certificate(doc.DocumentElement);
        //        if (isValid)
        //        {
        //            Assert.IsTrue(true);
        //        }
        //    }
        //    else
        //    {
        //        Assert.IsTrue(true);
        //    }
        //}

        //[TestMethod]
        //public void GetPersonWithDisabilitiesSocialBenefitsListTest()
        //{
        //    CallContext context = new CallContext()
        //    {
        //        AdministrationOId = "https://trust-party-openid.com",
        //        LawReason = "Тестване на RegiX",
        //        ServiceURI = "1222-200030-12.12.2022",
        //        Remark = "Забележки",
        //        EmployeeAditionalIdentifier = "Карта номер 3",
        //        EmployeeIdentifier = "test@tesactivedirectory.com",
        //        EmployeeNames = "Тестов Потребител Потребител",
        //        AdministrationName = "Българска агенция за Тестване",
        //        EmployeePosition = "Старши експерт Отдел \"Тестване на интеграцията\"",
        //        ResponsiblePersonIdentifier = "392309324",
        //        ServiceType = "За проверовъчна дейност"
        //    };
        //    string oldcontext = context.ToString();

        //    AdapterService.ASPSocialAdapter adapter = new AdapterService.ASPSocialAdapter();

        //    var accessMatrix = AccessMatrix.CreateForType(typeof(PeopleWithDisabilitiesResponseType));

        //    AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
        //    additionalParameters.CallContext = new CallContext() { Remark = "RegiXTest" };// "\"LawReason\":\"Тестване на RegiX\",\"ServiceURI\":\"123456789\",\”ServiceType\”:\”За проверовъчна дейност\”\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"Министерство на земеделието и храните\",\” UserAdministrationID\”:\”10.20.503.4\”,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";
        //    additionalParameters.CitizenEGN = "8888888888";
        //    additionalParameters.ClientIPAddress = "111.111.111.111";
        //    additionalParameters.ConsumerCertificateThumbprint = "###";
        //    additionalParameters.EIDToken = "token123";
        //    additionalParameters.EmployeeEGN = "11111111111111";
        //    additionalParameters.OrganizationEIK = "12121212121";
        //    additionalParameters.OrganizationUnit = "qqqqqq";
        //    additionalParameters.SignResult = false;
        //    additionalParameters.ReturnAccessMatrix = false;

        //    PeopleWithDisabilitiesRequest searchCriteria = new PeopleWithDisabilitiesRequest();
        //    searchCriteria.RIdentType = 1;
        //    searchCriteria.RIdentificator = "3001073054";
        //    searchCriteria.RDRelation = "EQ";
        //    var result = adapter.GetPersonWithDisabilitiesSocialBenefitsList(searchCriteria, accessMatrix, additionalParameters);
        //    string xml = result.XmlSerialize();
        //    using (StreamWriter outfile = new StreamWriter("GetPersonWithDisabilitiesSocialBenefitsListTest.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(xml);
        //    }

        //    //XsltUtils.RunXsltAndWriteHtml("ASPSocialAdapter", "GetSocialServicesDecisionsRequest", result.Data.Request.XmlSerialize());
        //    //XsltUtils.RunXsltAndWriteHtml("ASPSocialAdapter", "GetSocialServicesDecisionsResponse", result.Data.Response.XmlSerialize());

        //    XmlDocument doc = new XmlDocument();
        //    doc.LoadXml(xml);
        //    if (SigningUtils.HasSignature(doc))
        //    {
        //        bool isValid = SigningUtils.ValidateXmlDocumentWithX509Certificate(doc.DocumentElement);
        //        if (isValid)
        //        {
        //            Assert.IsTrue(true);
        //        }
        //    }
        //    else
        //    {
        //        Assert.IsTrue(true);
        //    }
        //}
    }
}
