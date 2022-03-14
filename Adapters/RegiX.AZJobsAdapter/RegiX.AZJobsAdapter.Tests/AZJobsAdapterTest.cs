using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegiX.Adapters.FileParameterStore;
using TechnoLogica.RegiX.AZJobsAdapter.AdapterService;
using TechnoLogica.RegiX.Adapters.TestUtils;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.Common.Utils;

namespace TechnoLogica.RegiX.AZJobsAdapter.Tests
{
    [TestClass]
    public class AZJobsAdapterTest : AdapterTest<AdapterService.AZJobsAdapter, IAZJobsAdapter>
    {
        //[TestMethod]
        //public void AZJobsAdapter_CheckHealthCheckAndParamtersTest()
        //{
        //    AdapterService.AZJobsAdapter adapter = new AdapterService.AZJobsAdapter();
        //    //test GetParameters , and ConnectionString
        //    var connectionString = adapter.GetParameters().ParameterList.Where(p => p.Key == Constants.ConnectionStringParameterKeyName).FirstOrDefault();
        //    //test SetParameter
        //    adapter.SetParameter(Constants.ConnectionStringParameterKeyName, connectionString.CurrentValue);
        //    //test HCfunctions
        //    var hcFunctions = adapter.GetHealthCheckFunctions();
        //    hcFunctions.HealthInfosList.ForEach(f => adapter.CheckHealthFunction(f.Key));
        //    Assert.IsTrue(true);
        //}

        //[TestMethod]
        //public void AZJobsAdapter_CheckRegisterConnection()
        //{
        //    AdapterService.AZJobsAdapter adapter = new AdapterService.AZJobsAdapter();
        //    string result = adapter.CheckRegisterConnection();
        //    Assert.IsTrue(result == Common.Constants.ConnectionOk || result == Common.Constants.ConnectionStringNotSet);
        //}


        //[TestMethod]
        //public void GetEmployerFreeJobPositionsTest()
        //{
        //    XmlDocument xmlDoc = new XmlDocument();
        //    xmlDoc.PreserveWhitespace = false;
        //    xmlDoc.Load("..\\..\\ValidateSignature.xml");
        //    string text = System.IO.File.ReadAllText("..\\..\\ValidateSignature.xml");

        //    bool valid = SigningUtils.ValidateXmlDocumentWithX509Certificate(text.ToXmlElement());

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

        //    AdapterService.AZJobsAdapter adapter = new AdapterService.AZJobsAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(EmployerFreeJobPositionsResponse));
        //    EmployerFreeJobPositionsRequestType searchCriteria = new EmployerFreeJobPositionsRequestType() { EntityID = "122541245" };

        //    AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
        //    additionalParameters.CallContext = new CallContext() { Remark = oldcontext };
        //    additionalParameters.CitizenEGN = "8888888888";
        //    additionalParameters.ClientIPAddress = "111.111.111.111";
        //    additionalParameters.ConsumerCertificateThumbprint = "###";
        //    additionalParameters.EIDToken = "token123";
        //    additionalParameters.EmployeeEGN = "11111111111111";
        //    additionalParameters.OrganizationEIK = "12121212121";
        //    additionalParameters.OrganizationUnit = "qqqqqq";
        //    additionalParameters.SignResult = true;
        //    additionalParameters.ReturnAccessMatrix = true;

        //    var result = adapter.GetEmployerFreeJobPositions(searchCriteria, accessMatrix, additionalParameters);
        //    string xml = result.XmlSerialize();
        //    using (StreamWriter outfile = new StreamWriter("GetEmployerFreeJobPositionsTest.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(xml);
        //    }
        //    XmlDocument doc = new XmlDocument();
        //    doc.LoadXml(xml);
        //    XsltUtils.RunXsltAndWriteHtml("AZJobsAdapter", "EmployerFreeJobPositionsRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("AZJobsAdapter", "EmployerFreeJobPositionsResponse", result.Data.Response.XmlSerialize());

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
        //public void GetEmployerFreeJobPositionsNULLTest()
        //{
        //    AdapterService.AZJobsAdapter adapter = new AdapterService.AZJobsAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(EmployerFreeJobPositionsResponse));
        //    EmployerFreeJobPositionsRequestType searchCriteria = new EmployerFreeJobPositionsRequestType() { EntityID = "test" };

        //    AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();

        //    additionalParameters.CallContext = new CallContext() { Remark = "RegiXTest" };// "\"LawReason\":\"Тестване на RegiX\",\"ServiceURI\":\"123456789\",\”ServiceType\”:\”За проверовъчна дейност\”\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"Министерство на земеделието и храните\",\” UserAdministrationID\”:\”10.20.503.4\”,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";

        //    additionalParameters.CitizenEGN = "8888888888";
        //    additionalParameters.ClientIPAddress = "111.111.111.111";
        //    additionalParameters.ConsumerCertificateThumbprint = "###";
        //    additionalParameters.EIDToken = "token123";
        //    additionalParameters.EmployeeEGN = "11111111111111";
        //    additionalParameters.OrganizationEIK = "12121212121";
        //    additionalParameters.OrganizationUnit = "qqqqqq";

        //    var result = adapter.GetEmployerFreeJobPositions(searchCriteria, accessMatrix, additionalParameters);
        //    using (StreamWriter outfile = new StreamWriter("GetEmployerFreeJobPositionsNULLTest.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("AZJobsAdapter", "EmployerFreeJobPositionsRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("AZJobsAdapter", "EmployerFreeJobPositionsResponse", result.Data.Response.XmlSerialize());

        //    Assert.IsTrue(true);
        //}

        //[TestMethod]
        //public void GetEmploymentMeasureContractTest()
        //{
        //    AdapterService.AZJobsAdapter adapter = new AdapterService.AZJobsAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(EmploymentMeasureContractResponse));
        //    EmploymentMeasureContractRequestType searchCriteria = new EmploymentMeasureContractRequestType() { EntityID = "1235433" };

        //    AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();

        //    additionalParameters.CallContext = new CallContext() { Remark = "RegiXTest" };// "\"LawReason\":\"Тестване на RegiX\",\"ServiceURI\":\"123456789\",\”ServiceType\”:\”За проверовъчна дейност\”\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"Министерство на земеделието и храните\",\” UserAdministrationID\”:\”10.20.503.4\”,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";

        //    additionalParameters.CitizenEGN = "8888888888";
        //    additionalParameters.ClientIPAddress = "111.111.111.111";
        //    additionalParameters.ConsumerCertificateThumbprint = "###";
        //    additionalParameters.EIDToken = "token123";
        //    additionalParameters.EmployeeEGN = "11111111111111";
        //    additionalParameters.OrganizationEIK = "12121212121";
        //    additionalParameters.OrganizationUnit = "qqqqqq";

        //    var result = adapter.GetEmploymentMeasureContract(searchCriteria, accessMatrix, additionalParameters);
        //    using (StreamWriter outfile = new StreamWriter("GetEmploymentMeasureContractTest.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("AZJobsAdapter", "EmploymentMeasureContactRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("AZJobsAdapter", "EmploymentMeasureContactResponse", result.Data.Response.XmlSerialize());

        //    Assert.IsTrue(true);
        //}

        //[TestMethod]
        //public void GetEmploymentMeasureContractNULLTest()
        //{
        //    AdapterService.AZJobsAdapter adapter = new AdapterService.AZJobsAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(EmploymentMeasureContractResponse));
        //    EmploymentMeasureContractRequestType searchCriteria = new EmploymentMeasureContractRequestType() { EntityID = "test" };

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

        //    var result = adapter.GetEmploymentMeasureContract(searchCriteria, accessMatrix, additionalParameters);
        //    using (StreamWriter outfile = new StreamWriter("GetEmploymentMeasureContractNULLTest.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("AZJobsAdapter", "EmploymentMeasureContactRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("AZJobsAdapter", "EmploymentMeasureContactResponse", result.Data.Response.XmlSerialize());

        //    Assert.IsTrue(true);
        //}

        //[TestMethod]
        //public void GetEmploymentProgramContractTest()
        //{
        //    AdapterService.AZJobsAdapter adapter = new AdapterService.AZJobsAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(EmploymentProgramContractResponse));
        //    EmploymentProgramContractRequestType searchCriteria = new EmploymentProgramContractRequestType() { EntityID = "1235" };

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

        //    var result = adapter.GetEmploymentProgramContract(searchCriteria, accessMatrix, additionalParameters);
        //    using (StreamWriter outfile = new StreamWriter("GetEmploymentProgramContractTest.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("AZJobsAdapter", "EmploymentProgramContractRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("AZJobsAdapter", "EmploymentProgramContractResponse", result.Data.Response.XmlSerialize());

        //    Assert.IsTrue(true);
        //}

        //[TestMethod]
        //public void GetEmploymentProgramContractNULLTest()
        //{
        //    AdapterService.AZJobsAdapter adapter = new AdapterService.AZJobsAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(EmploymentProgramContractResponse));
        //    EmploymentProgramContractRequestType searchCriteria = new EmploymentProgramContractRequestType() { EntityID = "test" };

        //    AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
        //    additionalParameters.CallContext = new CallContext() { Remark = "RegiXTest" };// "\"LawReason\":\"Тестване на RegiX\",\"ServiceURI\":\"123456789\",\”ServiceType\”:\”За проверовъчна дейност\”\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"Министерство на земеделието и храните\",\” UserAdministrationID\”:\”10.20.503.4\”,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";
        //    additionalParameters.CitizenEGN = "8888888888";
        //    additionalParameters.ClientIPAddress = "111.111.111.111";
        //    additionalParameters.ConsumerCertificateThumbprint = "###";
        //    additionalParameters.EIDToken = "token123";
        //    additionalParameters.EmployeeEGN = "11111111111111";
        //    additionalParameters.OrganizationEIK = "12121212121";
        //    additionalParameters.OrganizationUnit = "qqqqqq";

        //    var result = adapter.GetEmploymentProgramContract(searchCriteria, accessMatrix, additionalParameters);
        //    using (StreamWriter outfile = new StreamWriter("GetEmploymentProgramContractNULLTest.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("AZJobsAdapter", "EmploymentProgramContractRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("AZJobsAdapter", "EmploymentProgramContractResponse", result.Data.Response.XmlSerialize());

        //    Assert.IsTrue(true);
        //}

        //[TestMethod]
        //public void GetJobSeekerContractsTest()
        //{
        //    AdapterService.AZJobsAdapter adapter = new AdapterService.AZJobsAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(JobSeekerContractsData));
        //    JobSeekerContractsRequestType searchCriteria = new JobSeekerContractsRequestType() { PersonalID = "23541" };

        //    AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
        //    additionalParameters.CallContext = new CallContext() { Remark = "RegiXTest" };// "\"LawReason\":\"Тестване на RegiX\",\"ServiceURI\":\"123456789\",\”ServiceType\”:\”За проверовъчна дейност\”\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"Министерство на земеделието и храните\",\” UserAdministrationID\”:\”10.20.503.4\”,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";
        //    additionalParameters.CitizenEGN = "8888888888";
        //    additionalParameters.ClientIPAddress = "111.111.111.111";
        //    additionalParameters.ConsumerCertificateThumbprint = "###";
        //    additionalParameters.EIDToken = "token123";
        //    additionalParameters.EmployeeEGN = "11111111111111";
        //    additionalParameters.OrganizationEIK = "12121212121";
        //    additionalParameters.OrganizationUnit = "qqqqqq";

        //    var result = adapter.GetJobSeekerContracts(searchCriteria, accessMatrix, additionalParameters);
        //    using (StreamWriter outfile = new StreamWriter("GetJobSeekerContractsTest.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }
        //    XsltUtils.RunXsltAndWriteHtml("AZJobsAdapter", "JobSeekerContractsRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("AZJobsAdapter", "JobSeekerContractsResponse", result.Data.Response.XmlSerialize());
        //    Assert.IsTrue(true);
        //}

        //[TestMethod]
        //public void GetJobSeekerContractsNULLTest()
        //{
        //    AdapterService.AZJobsAdapter adapter = new AdapterService.AZJobsAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(JobSeekerContractsData));
        //    JobSeekerContractsRequestType searchCriteria = new JobSeekerContractsRequestType() { PersonalID = "test" };

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

        //    var result = adapter.GetJobSeekerContracts(searchCriteria, accessMatrix, additionalParameters);
        //    using (StreamWriter outfile = new StreamWriter("GetJobSeekerContractsNULLTest.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("AZJobsAdapter", "JobSeekerContractsRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("AZJobsAdapter", "JobSeekerContractsResponse", result.Data.Response.XmlSerialize());
        //    Assert.IsTrue(true);
        //}

        //[TestMethod]
        //public void GetJobSeekerDirectionsTest()
        //{
        //    AdapterService.AZJobsAdapter adapter = new AdapterService.AZJobsAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(JobSeekerDirectionsData));
        //    JobSeekerDirectionsRequestType searchCriteria = new JobSeekerDirectionsRequestType() { PersonalID = "12313" };

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

        //    var result = adapter.GetJobSeekerDirections(searchCriteria, accessMatrix, additionalParameters);
        //    using (StreamWriter outfile = new StreamWriter("GetJobSeekerDirectionsTest.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("AZJobsAdapter", "JobSeekerDirectionsRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("AZJobsAdapter", "JobSeekerDirectionsResponse", result.Data.Response.XmlSerialize());

        //    Assert.IsTrue(true);
        //}

        //[TestMethod]
        //public void GetJobSeekerDirectionsNULLTest()
        //{
        //    AdapterService.AZJobsAdapter adapter = new AdapterService.AZJobsAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(JobSeekerDirectionsData));
        //    JobSeekerDirectionsRequestType searchCriteria = new JobSeekerDirectionsRequestType() { PersonalID = "test" };

        //    AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
        //    additionalParameters.CallContext = new CallContext() { Remark = "RegiXTest" };// "\"LawReason\":\"Тестване на RegiX\",\"ServiceURI\":\"123456789\",\”ServiceType\”:\”За проверовъчна дейност\”\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"Министерство на земеделието и храните\",\” UserAdministrationID\”:\”10.20.503.4\”,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";
        //    additionalParameters.CitizenEGN = "8888888888";
        //    additionalParameters.ClientIPAddress = "111.111.111.111";
        //    additionalParameters.ConsumerCertificateThumbprint = "###";
        //    additionalParameters.EIDToken = "token123";
        //    additionalParameters.EmployeeEGN = "11111111111111";
        //    additionalParameters.OrganizationEIK = "12121212121";
        //    additionalParameters.OrganizationUnit = "qqqqqq";

        //    var result = adapter.GetJobSeekerDirections(searchCriteria, accessMatrix, additionalParameters);
        //    using (StreamWriter outfile = new StreamWriter("GetJobSeekerDirectionsNULLTest.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("AZJobsAdapter", "JobSeekerDirectionsRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("AZJobsAdapter", "JobSeekerDirectionsResponse", result.Data.Response.XmlSerialize());
        //    Assert.IsTrue(true);
        //}

        //[TestMethod]
        //public void GetJobSeekerHistoryRegistrationsTest()
        //{
        //    AdapterService.AZJobsAdapter adapter = new AdapterService.AZJobsAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(JobSeekerHistoryData));
        //    JobSeekerHistoryRegistrationsRequestType searchCriteria = new JobSeekerHistoryRegistrationsRequestType() { PersonalID = "124124" };

        //    AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
        //    additionalParameters.CallContext = new CallContext() { Remark = "RegiXTest" };// "\"LawReason\":\"Тестване на RegiX\",\"ServiceURI\":\"123456789\",\”ServiceType\”:\”За проверовъчна дейност\”\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"Министерство на земеделието и храните\",\” UserAdministrationID\”:\”10.20.503.4\”,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";
        //    additionalParameters.CitizenEGN = "8888888888";
        //    additionalParameters.ClientIPAddress = "111.111.111.111";
        //    additionalParameters.ConsumerCertificateThumbprint = "###";
        //    additionalParameters.EIDToken = "token123";
        //    additionalParameters.EmployeeEGN = "11111111111111";
        //    additionalParameters.OrganizationEIK = "12121212121";
        //    additionalParameters.OrganizationUnit = "qqqqqq";

        //    var result = adapter.GetJobSeekerHistoryRegistrations(searchCriteria, accessMatrix, additionalParameters);
        //    using (StreamWriter outfile = new StreamWriter("GetJobSeekerHistoryRegistrationsTest.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("AZJobsAdapter", "JobSeekerHistoryRegistrationsRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("AZJobsAdapter", "JobSeekerHistoryRegistrationsResponse", result.Data.Response.XmlSerialize());
        //    Assert.IsTrue(true);
        //}

        //[TestMethod]
        //public void GetJobSeekerHistoryRegistrationsNULLTest()
        //{
        //    AdapterService.AZJobsAdapter adapter = new AdapterService.AZJobsAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(JobSeekerHistoryData));
        //    JobSeekerHistoryRegistrationsRequestType searchCriteria = new JobSeekerHistoryRegistrationsRequestType() { PersonalID = "test" };

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

        //    var result = adapter.GetJobSeekerHistoryRegistrations(searchCriteria, accessMatrix, additionalParameters);
        //    using (StreamWriter outfile = new StreamWriter("GetJobSeekerHistoryRegistrationsNULLTest.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }
        //    XsltUtils.RunXsltAndWriteHtml("AZJobsAdapter", "JobSeekerHistoryRegistrationsRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("AZJobsAdapter", "JobSeekerHistoryRegistrationsResponse", result.Data.Response.XmlSerialize());
        //    Assert.IsTrue(true);
        //}

        //[TestMethod]
        //public void GetJobSeekerStatusTest()
        //{
        //    AdapterService.AZJobsAdapter adapter = new AdapterService.AZJobsAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(JobSeekerStatusData));
        //    JobSeekerStatusRequestType searchCriteria = new JobSeekerStatusRequestType() { PersonalID = "2342354" };

        //    AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
        //    additionalParameters.CallContext = new CallContext() { Remark = "RegiXTestTest" };// "\"LawReason\":\"Тестване на RegiX\",\"ServiceURI\":\"123456789\",\”ServiceType\”:\”За проверовъчна дейност\”\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"Министерство на земеделието и храните\",\” UserAdministrationID\”:\”10.20.503.4\”,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";
        //    additionalParameters.CitizenEGN = "8888888888";
        //    additionalParameters.ClientIPAddress = "111.111.111.111";
        //    additionalParameters.ConsumerCertificateThumbprint = "###";
        //    additionalParameters.EIDToken = "token123";
        //    additionalParameters.EmployeeEGN = "11111111111111";
        //    additionalParameters.OrganizationEIK = "12121212121";
        //    additionalParameters.OrganizationUnit = "qqqqqq";

        //    var result = adapter.GetJobSeekerStatus(searchCriteria, accessMatrix, additionalParameters);
        //    using (StreamWriter outfile = new StreamWriter("GetJobSeekerStatusTest.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }
        //    XsltUtils.RunXsltAndWriteHtml("AZJobsAdapter", "JobSeekerStatusRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("AZJobsAdapter", "JobSeekerStatusResponse", result.Data.Response.XmlSerialize());
        //    Assert.IsTrue(true);
        //}

        //[TestMethod]
        //public void GetJobSeekerStatusNULLTest()
        //{
        //    AdapterService.AZJobsAdapter adapter = new AdapterService.AZJobsAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(JobSeekerStatusData));
        //    JobSeekerStatusRequestType searchCriteria = new JobSeekerStatusRequestType() { PersonalID = "test" };

        //    AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
        //    additionalParameters.CallContext = new CallContext() { Remark = "RegiXTestTest" };// "\"LawReason\":\"Тестване на RegiX\",\"ServiceURI\":\"123456789\",\”ServiceType\”:\”За проверовъчна дейност\”\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"Министерство на земеделието и храните\",\” UserAdministrationID\”:\”10.20.503.4\”,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";
        //    additionalParameters.CitizenEGN = "8888888888";
        //    additionalParameters.ClientIPAddress = "111.111.111.111";
        //    additionalParameters.ConsumerCertificateThumbprint = "###";
        //    additionalParameters.EIDToken = "token123";
        //    additionalParameters.EmployeeEGN = "11111111111111";
        //    additionalParameters.OrganizationEIK = "12121212121";
        //    additionalParameters.OrganizationUnit = "qqqqqq";

        //    var result = adapter.GetJobSeekerStatus(searchCriteria, accessMatrix, additionalParameters);
        //    using (StreamWriter outfile = new StreamWriter("GetJobSeekerStatusNULLTest.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }
        //    XsltUtils.RunXsltAndWriteHtml("AZJobsAdapter", "JobSeekerStatusRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("AZJobsAdapter", "JobSeekerStatusResponse", result.Data.Response.XmlSerialize());
        //    Assert.IsTrue(true);
        //}

        //[TestMethod]
        //public void GetJobSeekerTrainingsTest()
        //{
        //    AdapterService.AZJobsAdapter adapter = new AdapterService.AZJobsAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(JobSeekerTrainingsData));
        //    JobSeekerTrainingsRequestType searchCriteria = new JobSeekerTrainingsRequestType() { PersonalID = "213" };

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

        //    var result = adapter.GetJobSeekerTrainings(searchCriteria, accessMatrix, additionalParameters);
        //    using (StreamWriter outfile = new StreamWriter("GetJobSeekerTrainingsTest.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }
        //    XsltUtils.RunXsltAndWriteHtml("AZJobsAdapter", "JobSeekerTrainingsRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("AZJobsAdapter", "JobSeekerTrainingsResponse", result.Data.Response.XmlSerialize());
        //    Assert.IsTrue(true);
        //}

        //[TestMethod]
        //public void GetJobSeekerTrainingsNULLTest()
        //{
        //    AdapterService.AZJobsAdapter adapter = new AdapterService.AZJobsAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(JobSeekerTrainingsData));
        //    JobSeekerTrainingsRequestType searchCriteria = new JobSeekerTrainingsRequestType() { PersonalID = "test" };

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

        //    var result = adapter.GetJobSeekerTrainings(searchCriteria, accessMatrix, additionalParameters);
        //    using (StreamWriter outfile = new StreamWriter("GetJobSeekerTrainingsNULLTest.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("AZJobsAdapter", "JobSeekerTrainingsRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("AZJobsAdapter", "JobSeekerTrainingsResponse", result.Data.Response.XmlSerialize());
        //    Assert.IsTrue(true);
        //}
    }
}
