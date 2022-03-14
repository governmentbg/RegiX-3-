using System.IO;
using System.Linq;
using System.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.Common.Utils;
using TechnoLogica.RegiX.GitExplosivesAdapter;
using TechnoLogica.RegiX.GitExplosivesAdapter.AdapterService;

namespace RegiX.GitExplosivesAdapterTests
{
    [TestClass]
    public class GitExplosivesAdapterTests
    {
        //[TestMethod]
        //public void GitExplosivesAdapterTest_CheckHealthCheckAndParamtersTest()
        //{
        //    GitExplosivesAdapter adapter = new GitExplosivesAdapter();
        //    //test GetParameters , and ConnectionString
        //    var connectionString = adapter.GetParameters().ParameterList.Where(p => p.Key == TechnoLogica.RegiX.Common.Constants.ConnectionStringParameterKeyName).FirstOrDefault();
        //    //test SetParameter
        //    adapter.SetParameter(TechnoLogica.RegiX.Common.Constants.ConnectionStringParameterKeyName, connectionString.CurrentValue);
        //    //test HCfunctions
        //    var hcFunctions = adapter.GetHealthCheckFunctions();
        //    hcFunctions.HealthInfosList.ForEach(f => adapter.CheckHealthFunction(f.Key));
        //    Assert.IsTrue(true);
        //}

        //[TestMethod]
        //public void GitExplosivesAdapterTest_CheckRegisterConnection()
        //{
        //    GitExplosivesAdapter adapter = new GitExplosivesAdapter();
        //    string result = adapter.CheckRegisterConnection();
        //    Assert.IsTrue(result == TechnoLogica.RegiX.Common.Constants.ConnectionOk || result == TechnoLogica.RegiX.Common.Constants.ConnectionStringNotSet);
        //}

        //[TestMethod]
        //public void GetAuthenticityExplosivesCertificate_Test()
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

        //    // "\"LawReason\":\"Тестване на RegiX\",\"ServiceURI\":\"123456789\",\”ServiceType\”:\”За проверовъчна дейност\”\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"Министерство на земеделието и храните\",\” UserAdministrationID\”:\”10.20.503.4\”,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";

        //    GitExplosivesAdapter adapter = new GitExplosivesAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(ValidExplosivesCertificateResponse));
        //    AuthenticityExplosivesRequestType searchCriteria = new AuthenticityExplosivesRequestType() { Identifier = "9201025865", CertificateNumber = "2001" };

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
        //    additionalParameters.SignResult = true;
        //    additionalParameters.ReturnAccessMatrix = true;

        //    var result = adapter.GetAuthenticityExplosivesCertificate(searchCriteria, accessMatrix, additionalParameters);
        //    string xml = result.Data.Response.XmlSerialize();
        //    using (StreamWriter outfile = new StreamWriter("GetAuthenticityExplosivesCertificate_Test.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(xml);
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("GitExplosivesAdapter", "AuthenticityExplosivesCertificateRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("GitExplosivesAdapter", "ValidExplosivesCertificateResponse", result.Data.Response.XmlSerialize());

        //    XmlDocument doc = new XmlDocument();
        //    doc.LoadXml(xml);
        //    if (SigningUtils.HasSignature(doc))
        //    {
        //        bool isValid = SigningUtils.ValidateXmlDocumentWithX509Certificate(doc);
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
        //public void GetAuthenticityExplosivesCertificate_NULL_Test()
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
        //    // "\"LawReason\":\"Тестване на RegiX\",\"ServiceURI\":\"123456789\",\”ServiceType\”:\”За проверовъчна дейност\”\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"Министерство на земеделието и храните\",\” UserAdministrationID\”:\”10.20.503.4\”,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";
        //    GitExplosivesAdapter adapter = new GitExplosivesAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(ValidExplosivesCertificateResponse));
        //    AuthenticityExplosivesRequestType searchCriteria = new AuthenticityExplosivesRequestType() { Identifier = "92010258650000000000", CertificateNumber = "2001" };

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
        //    additionalParameters.SignResult = true;
        //    additionalParameters.ReturnAccessMatrix = true;

        //    var result = adapter.GetAuthenticityExplosivesCertificate(searchCriteria, accessMatrix, additionalParameters);
        //    string xml = result.XmlSerialize();
        //    using (StreamWriter outfile = new StreamWriter("GetAuthenticityExplosivesCertificate_NULL_Test.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(xml);
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("GitExplosivesAdapter", "AuthenticityExplosivesCertificateRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("GitExplosivesAdapter", "ValidExplosivesCertificateResponse", result.Data.Response.XmlSerialize());

        //    XmlDocument doc = new XmlDocument();
        //    doc.LoadXml(xml);
        //    if (SigningUtils.HasSignature(doc))
        //    {
        //        bool isValid = SigningUtils.ValidateXmlDocumentWithX509Certificate(doc);
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
        //public void GetValidExplosivesCertificate_Test()
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

        //    // "\"LawReason\":\"Тестване на RegiX\",\"ServiceURI\":\"123456789\",\”ServiceType\”:\”За проверовъчна дейност\”\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"Министерство на земеделието и храните\",\” UserAdministrationID\”:\”10.20.503.4\”,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";

        //    GitExplosivesAdapter adapter = new GitExplosivesAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(ValidExplosivesCertificateResponse));
        //    ValidExplosivesRequestType searchCriteria = new ValidExplosivesRequestType() { Identifier = "9201025865" };

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
        //    additionalParameters.SignResult = true;
        //    additionalParameters.ReturnAccessMatrix = true;

        //    var result = adapter.GetValidExplosivesCertificate(searchCriteria, accessMatrix, additionalParameters);
        //    string xml = result.XmlSerialize();
        //    using (StreamWriter outfile = new StreamWriter("GetValidExplosivesCertificate_Test.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(xml);
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("GitExplosivesAdapter", "ValidExplosivesCertificateRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("GitExplosivesAdapter", "ValidExplosivesCertificateResponse", result.Data.Response.XmlSerialize());

        //    XmlDocument doc = new XmlDocument();
        //    doc.LoadXml(xml);
        //    if (SigningUtils.HasSignature(doc))
        //    {
        //        bool isValid = SigningUtils.ValidateXmlDocumentWithX509Certificate(doc);
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
        //public void GetValidExplosivesCertificate_NULL_Test()
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

        //    // "\"LawReason\":\"Тестване на RegiX\",\"ServiceURI\":\"123456789\",\”ServiceType\”:\”За проверовъчна дейност\”\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"Министерство на земеделието и храните\",\” UserAdministrationID\”:\”10.20.503.4\”,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";

        //    GitExplosivesAdapter adapter = new GitExplosivesAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(ValidExplosivesCertificateResponse));
        //    ValidExplosivesRequestType searchCriteria = new ValidExplosivesRequestType() { Identifier = "92010258650000000000000000000000" };

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
        //    additionalParameters.SignResult = true;
        //    additionalParameters.ReturnAccessMatrix = true;

        //    var result = adapter.GetValidExplosivesCertificate(searchCriteria, accessMatrix, additionalParameters);
        //    string xml = result.XmlSerialize();
        //    using (StreamWriter outfile = new StreamWriter("GetValidExplosivesCertificate_NULL_Test.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(xml);
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("GitExplosivesAdapter", "ValidExplosivesCertificateRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("GitExplosivesAdapter", "ValidExplosivesCertificateResponse", result.Data.Response.XmlSerialize());

        //    XmlDocument doc = new XmlDocument();
        //    doc.LoadXml(xml);
        //    if (SigningUtils.HasSignature(doc))
        //    {
        //        bool isValid = SigningUtils.ValidateXmlDocumentWithX509Certificate(doc);
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
        //public void CheckConnectionTest()
        //{
        //    GitExplosivesAdapter adapter = new GitExplosivesAdapter();
        //    string status = adapter.CheckRegisterConnection();
        //    Assert.IsTrue(true);
        //}
    }
}
