using System;
using System.IO;
using System.Linq;
using System.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.Common.Utils;
using TechnoLogica.RegiX.GitPenalProvisionsAdapter;
using TechnoLogica.RegiX.GitPenalProvisionsAdapter.AdapterService;

namespace RegiX.GitPenalProvisionsAdapterTests
{
    [TestClass]
    public class GitPenalProvisionsAdapterTests
    {
        //[TestMethod]
        //public void GitPenalProvisionsAdapterTest_CheckHealthCheckAndParamtersTest()
        //{
        //    GitPenalProvisionsAdapter adapter = new GitPenalProvisionsAdapter();
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
        //public void GitPenalProvisionsAdapterTest_CheckRegisterConnection()
        //{
        //    GitPenalProvisionsAdapter adapter = new GitPenalProvisionsAdapter();
        //    string result = adapter.CheckRegisterConnection();
        //    Assert.IsTrue(result == TechnoLogica.RegiX.Common.Constants.ConnectionOk || result == TechnoLogica.RegiX.Common.Constants.ConnectionStringNotSet);
        //}

        //[TestMethod]
        //public void GetPenalProvisionForPeriodTest()
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

        //    GitPenalProvisionsAdapter adapter = new GitPenalProvisionsAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(PenalProvisionForPeriodResponse));
        //    PenalProvisionForPeriodRequest searchCriteria = new PenalProvisionForPeriodRequest() { IntruderIdentifier = "9002045860", DateFrom = new DateTime(2015, 05, 05, 0, 0, 0), DateTo = new DateTime(2016, 05, 05, 0, 0, 0) };

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

        //    var result = adapter.GetPenalProvisionForPeriod(searchCriteria, accessMatrix, additionalParameters);
        //    string xml = result.XmlSerialize();
        //    using (StreamWriter outfile = new StreamWriter("GetPenalProvisionForPeriodTest.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(xml);
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("GitPenalProvisionsAdapter", "PenalProvisionForPeriodRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("GitPenalProvisionsAdapter", "PenalProvisionForPeriod", result.Data.Response.XmlSerialize());

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
        //public void GetPenalProvisionForPeriodNullTest()
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

        //    GitPenalProvisionsAdapter adapter = new GitPenalProvisionsAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(PenalProvisionForPeriodResponse));
        //    PenalProvisionForPeriodRequest searchCriteria = new PenalProvisionForPeriodRequest() { IntruderIdentifier = "Ivan Ivanov Georgiev", DateFrom = new DateTime(2014, 05, 05, 0, 0, 0), DateTo = new DateTime(2014, 05, 06, 0, 0, 0) };

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

        //    var result = adapter.GetPenalProvisionForPeriod(searchCriteria, accessMatrix, additionalParameters);
        //    string xml = result.XmlSerialize();
        //    using (StreamWriter outfile = new StreamWriter("GetPenalProvisionForPeriodNullTest.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(xml);
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("GitPenalProvisionsAdapter", "PenalProvisionForPeriodRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("GitPenalProvisionsAdapter", "PenalProvisionForPeriod", result.Data.Response.XmlSerialize());

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
        //public void GetPenalProvisionMediatorActTest()
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

        //    GitPenalProvisionsAdapter adapter = new GitPenalProvisionsAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(PenalProvisionMediatorActResponse));
        //    PenalProvisionMediatorActType searchCriteria = new PenalProvisionMediatorActType() { PenalProvisionRelation = "TODO", IntruderIdentifier = "9002045860", DateFrom = new DateTime(2015, 05, 05, 0, 0, 0), DateTo = new DateTime(2016, 05, 05, 0, 0, 0) };

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

        //    var result = adapter.GetPenalProvisionMediatorAct(searchCriteria, accessMatrix, additionalParameters);
        //    string xml = result.XmlSerialize();
        //    using (StreamWriter outfile = new StreamWriter("GetPenalProvisionMediatorActTest.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(xml);
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("GitPenalProvisionsAdapter", "PenalProvisionMediatorActRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("GitPenalProvisionsAdapter", "PenalProvisionMediatorActResponse", result.Data.Response.XmlSerialize());

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
        //public void GetPenalProvisionMediatorActNullTest()
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

        //    GitPenalProvisionsAdapter adapter = new GitPenalProvisionsAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(PenalProvisionMediatorActResponse));
        //    PenalProvisionMediatorActType searchCriteria = new PenalProvisionMediatorActType() { PenalProvisionRelation = "TODO", IntruderIdentifier = "0000000000", DateFrom = new DateTime(2015, 05, 05, 0, 0, 0), DateTo = new DateTime(2016, 05, 05, 0, 0, 0) };

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

        //    var result = adapter.GetPenalProvisionMediatorAct(searchCriteria, accessMatrix, additionalParameters);
        //    string xml = result.XmlSerialize();
        //    using (StreamWriter outfile = new StreamWriter("GetPenalProvisionMediatorActNullTest.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(xml);
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("GitPenalProvisionsAdapter", "PenalProvisionMediatorActRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("GitPenalProvisionsAdapter", "PenalProvisionMediatorActResponse", result.Data.Response.XmlSerialize());

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
        //public void GetPenalProvisionUnpaidFeeTest()
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

        //    GitPenalProvisionsAdapter adapter = new GitPenalProvisionsAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(PenalProvisionUnpaidFeeResponse));

        //    PenalProvisionUnpaidFeeType searchCriteria = new PenalProvisionUnpaidFeeType() { IntruderIdentifier = "9002045860", DateFrom = new DateTime(2015, 05, 05, 0, 0, 0), DateTo = new DateTime(2016, 05, 05, 0, 0, 0) };

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

        //    var result = adapter.GetPenalProvisionUnpaidFee(searchCriteria, accessMatrix, additionalParameters);

        //    string xml = result.Data.Response.XmlSerialize();
        //    using (StreamWriter outfile = new StreamWriter("GetPenalProvisionUnpaidFeeTest.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(xml);
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("GitPenalProvisionsAdapter", "PenalProvisionUnpaidFeeRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("GitPenalProvisionsAdapter", "PenalProvisionUnpaidFeeResponse", result.Data.Response.XmlSerialize());

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
        //public void GetPenalProvisionUnpaidFeeNullTest()
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

        //    GitPenalProvisionsAdapter adapter = new GitPenalProvisionsAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(PenalProvisionUnpaidFeeResponse));

        //    PenalProvisionUnpaidFeeType searchCriteria = new PenalProvisionUnpaidFeeType() { IntruderIdentifier = "0000000000", DateFrom = new DateTime(2015, 05, 05, 0, 0, 0), DateTo = new DateTime(2016, 05, 05, 0, 0, 0) };

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

        //    var result = adapter.GetPenalProvisionUnpaidFee(searchCriteria, accessMatrix, additionalParameters);
        //    string xml = result.XmlSerialize();
        //    using (StreamWriter outfile = new StreamWriter("GetPenalProvisionUnpaidFeeNullTest.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(xml);
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("GitPenalProvisionsAdapter", "PenalProvisionUnpaidFeeRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("GitPenalProvisionsAdapter", "PenalProvisionUnpaidFeeResponse", result.Data.Response.XmlSerialize());

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
        //    GitPenalProvisionsAdapter adapter = new GitPenalProvisionsAdapter();
        //    string status = adapter.CheckRegisterConnection();
        //    Assert.IsTrue(true);
        //}
    }
}
