using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechnoLogica.RegiX.IaosREG35Adapter.AdapterService;
using TechnoLogica.RegiX.Adapters.TestUtils;

namespace TechnoLogica.RegiX.IaosREG35Adapter.Tests
{
    [TestClass]
    public class IaosREG35AdapterTest : AdapterTest<AdapterService.IaosREG35Adapter, IIaosREG35Adapter>
    {

        //[TestMethod]
        //public void IaosREG35AdapterTest_CheckHealthCheckAndParamtersTest()
        //{
        //    IaosREG35Adapter adapter = new IaosREG35Adapter();
        //    //test GetParameters , and ConnectionString
        //    var connectionString = adapter.GetParameters().ParameterList.Where(p => p.Key == TechnoLogica.RegiX.Common.Constants.WebServiceUrlParameterKeyName).FirstOrDefault();
        //    //test SetParameter
        //    adapter.SetParameter(TechnoLogica.RegiX.Common.Constants.WebServiceUrlParameterKeyName, connectionString.CurrentValue);
        //    //test HCfunctions
        //    var hcFunctions = adapter.GetHealthCheckFunctions();
        //    string checkHealthFunctionResult = string.Empty;
        //    hcFunctions.HealthInfosList.ForEach(f => {
        //        checkHealthFunctionResult = checkHealthFunctionResult + f.Key + ":" + adapter.CheckHealthFunction(f.Key) + ";\r\n";
        //    });
        //    using (StreamWriter outfile = new StreamWriter("CheckHealthFunctions.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(checkHealthFunctionResult);
        //    }
        //    Assert.IsTrue(true);
        //}
        //[TestMethod]
        //public void IaosREG35AdapterTest_CheckRegisterConnection()
        //{
        //    IaosREG35Adapter adapter = new IaosREG35Adapter();
        //    string result = adapter.CheckRegisterConnection();
        //    Assert.IsTrue(result == TechnoLogica.RegiX.Common.Constants.ConnectionOk || result == TechnoLogica.RegiX.Common.Constants.ConnectionStringNotSet);
        //}

        //[TestMethod]
        //public void REG35AllowedWasteCodesTest()
        //{
        //    TechnoLogica.RegiX.Common.TransportObject.CallContext context = new TechnoLogica.RegiX.Common.TransportObject.CallContext()
        //    {
        //        AdministrationOId = "https://trust-party-openid.com",
        //        LawReason = "�������� �� RegiX",
        //        ServiceURI = "1222-200030-12.12.2022",
        //        Remark = "���������",
        //        EmployeeAditionalIdentifier = "����� ����� 3",
        //        EmployeeIdentifier = "test@tesactivedirectory.com",
        //        EmployeeNames = "������ ���������� ����������",
        //        AdministrationName = "��������� ������� �� ��������",
        //        EmployeePosition = "������ ������� ����� \"�������� �� ������������\"",
        //        ResponsiblePersonIdentifier = "392309324",
        //        ServiceType = "�� ������������ �������"
        //    };
        //    string oldcontext = context.ToString();

        //    IaosREG35Adapter adapter = new IaosREG35Adapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(REG35_Allowed_Waste_Codes_Response));
        //    REG35_Allowed_Waste_Codes_Request seatchCriteria = new REG35_Allowed_Waste_Codes_Request() { AuthNum = "00-��-00000185-09", StageNum = "1" };

        //    AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
        //    additionalParameters.CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext() { Remark = "RegiXTest" };// "\"LawReason\":\"�������� �� RegiX\",\"ServiceURI\":\"123456789\",\�ServiceType\�:\��� ������������ �������\�\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"������������ �� ����������� � �������\",\� UserAdministrationID\�:\�10.20.503.4\�,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";
        //    additionalParameters.CitizenEGN = "8888888888";
        //    additionalParameters.ClientIPAddress = "111.111.111.111";
        //    additionalParameters.ConsumerCertificateThumbprint = "###";
        //    additionalParameters.EIDToken = "token123";
        //    additionalParameters.EmployeeEGN = "11111111111111";
        //    additionalParameters.OrganizationEIK = "12121212121";
        //    additionalParameters.OrganizationUnit = "qqqqqq";
        //    additionalParameters.SignResult = false;
        //    additionalParameters.ReturnAccessMatrix = true;

        //    var result = adapter.GetREG35_Allowed_Waste_Codes(seatchCriteria, accessMatrix, additionalParameters);
        //    string xml = result.Data.Response.XmlSerialize();
        //    using (StreamWriter outfile = new StreamWriter("GetREG35_Allowed_Waste_Codes_Test.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(xml);
        //    }
        //    XsltUtils.RunXsltAndWriteHtml("IaosREG35Adapter", "REG35_Allowed_Waste_Codes_Request", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("IaosREG35Adapter", "REG35_Allowed_Waste_Codes_Response", result.Data.Response.XmlSerialize());

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
        //public void REG35AllowedWasteCodesNullTest()
        //{
        //    TechnoLogica.RegiX.Common.TransportObject.CallContext context = new TechnoLogica.RegiX.Common.TransportObject.CallContext()
        //    {
        //        AdministrationOId = "https://trust-party-openid.com",
        //        LawReason = "�������� �� RegiX",
        //        ServiceURI = "1222-200030-12.12.2022",
        //        Remark = "���������",
        //        EmployeeAditionalIdentifier = "����� ����� 3",
        //        EmployeeIdentifier = "test@tesactivedirectory.com",
        //        EmployeeNames = "������ ���������� ����������",
        //        AdministrationName = "��������� ������� �� ��������",
        //        EmployeePosition = "������ ������� ����� \"�������� �� ������������\"",
        //        ResponsiblePersonIdentifier = "392309324",
        //        ServiceType = "�� ������������ �������"
        //    };
        //    string oldcontext = context.ToString();

        //    IaosREG35Adapter adapter = new IaosREG35Adapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(REG35_Allowed_Waste_Codes_Response));
        //    REG35_Allowed_Waste_Codes_Request seatchCriteria = new REG35_Allowed_Waste_Codes_Request() { AuthNum = "test", StageNum = "1" };

        //    AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
        //    additionalParameters.CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext();// "\"LawReason\":\"�������� �� RegiX\",\"ServiceURI\":\"123456789\",\�ServiceType\�:\��� ������������ �������\�\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"������������ �� ����������� � �������\",\� UserAdministrationID\�:\�10.20.503.4\�,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";
        //    additionalParameters.CitizenEGN = "8888888888";
        //    additionalParameters.ClientIPAddress = "111.111.111.111";
        //    additionalParameters.ConsumerCertificateThumbprint = "###";
        //    additionalParameters.EIDToken = "token123";
        //    additionalParameters.EmployeeEGN = "11111111111111";
        //    additionalParameters.OrganizationEIK = "12121212121";
        //    additionalParameters.OrganizationUnit = "qqqqqq";
        //    additionalParameters.SignResult = false;
        //    additionalParameters.ReturnAccessMatrix = true;

        //    var result = adapter.GetREG35_Allowed_Waste_Codes(seatchCriteria, accessMatrix, additionalParameters);
        //    string xml = result.Data.Response.XmlSerialize();
        //    using (StreamWriter outfile = new StreamWriter("GetREG35_Allowed_Waste_Codes_NULL_Test.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(xml);
        //    }
        //    XsltUtils.RunXsltAndWriteHtml("IaosREG35Adapter", "REG35_Allowed_Waste_Codes_Request", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("IaosREG35Adapter", "REG35_Allowed_Waste_Codes_Response", result.Data.Response.XmlSerialize());

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
        //public void REG35LicensesByEIKWasteCodeWasteOperationTest()
        //{
        //    TechnoLogica.RegiX.Common.TransportObject.CallContext context = new TechnoLogica.RegiX.Common.TransportObject.CallContext()
        //    {
        //        AdministrationOId = "https://trust-party-openid.com",
        //        LawReason = "�������� �� RegiX",
        //        ServiceURI = "1222-200030-12.12.2022",
        //        Remark = "���������",
        //        EmployeeAditionalIdentifier = "����� ����� 3",
        //        EmployeeIdentifier = "test@tesactivedirectory.com",
        //        EmployeeNames = "������ ���������� ����������",
        //        AdministrationName = "��������� ������� �� ��������",
        //        EmployeePosition = "������ ������� ����� \"�������� �� ������������\"",
        //        ResponsiblePersonIdentifier = "392309324",
        //        ServiceType = "�� ������������ �������"
        //    };
        //    string oldcontext = context.ToString();

        //    IaosREG35Adapter adapter = new IaosREG35Adapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(REG35_Licenses_By_EIK_Waste_Code_Waste_Operation_Response));
        //    REG35_Licenses_By_EIK_Waste_Code_Waste_Operation_Request searchCriteria = new REG35_Licenses_By_EIK_Waste_Code_Waste_Operation_Request() { EIK = "131103818", WasteCode = "160106", WasteOperation = "�" };

        //    AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
        //    additionalParameters.CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext() { Remark = "RegiXTest" };// "\"LawReason\":\"�������� �� RegiX\",\"ServiceURI\":\"123456789\",\�ServiceType\�:\��� ������������ �������\�\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"������������ �� ����������� � �������\",\� UserAdministrationID\�:\�10.20.503.4\�,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";
        //    additionalParameters.CitizenEGN = "8888888888";
        //    additionalParameters.ClientIPAddress = "111.111.111.111";
        //    additionalParameters.ConsumerCertificateThumbprint = "###";
        //    additionalParameters.EIDToken = "token123";
        //    additionalParameters.EmployeeEGN = "11111111111111";
        //    additionalParameters.OrganizationEIK = "12121212121";
        //    additionalParameters.OrganizationUnit = "qqqqqq";
        //    additionalParameters.SignResult = false;
        //    additionalParameters.ReturnAccessMatrix = true;

        //    var result = adapter.GetREG35_Licenses_By_EIK_Waste_Code_Waste_Operation(searchCriteria, accessMatrix, additionalParameters);
        //    string xml = result.Data.Response.XmlSerialize();
        //    using (StreamWriter outfile = new StreamWriter("GetREG35_Licenses_By_EIK_Waste_Code_Waste_Operation_Test.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(xml);
        //    }
        //    XsltUtils.RunXsltAndWriteHtml("IaosREG35Adapter", "REG35_Licenses_By_EIK_Waste_Operation_Request", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("IaosREG35Adapter", "REG35_Licenses_By_EIK_Waste_Operation_Response", result.Data.Response.XmlSerialize());

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
        //public void REG35LicensesByEIKWasteCodeWasteOperationNullTest()
        //{
        //    TechnoLogica.RegiX.Common.TransportObject.CallContext context = new TechnoLogica.RegiX.Common.TransportObject.CallContext()
        //    {
        //        AdministrationOId = "https://trust-party-openid.com",
        //        LawReason = "�������� �� RegiX",
        //        ServiceURI = "1222-200030-12.12.2022",
        //        Remark = "���������",
        //        EmployeeAditionalIdentifier = "����� ����� 3",
        //        EmployeeIdentifier = "test@tesactivedirectory.com",
        //        EmployeeNames = "������ ���������� ����������",
        //        AdministrationName = "��������� ������� �� ��������",
        //        EmployeePosition = "������ ������� ����� \"�������� �� ������������\"",
        //        ResponsiblePersonIdentifier = "392309324",
        //        ServiceType = "�� ������������ �������"
        //    };
        //    string oldcontext = context.ToString();

        //    IaosREG35Adapter adapter = new IaosREG35Adapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(REG35_Licenses_By_EIK_Waste_Code_Waste_Operation_Response));
        //    REG35_Licenses_By_EIK_Waste_Code_Waste_Operation_Request searchCriteria = new REG35_Licenses_By_EIK_Waste_Code_Waste_Operation_Request() { EIK = "test", WasteCode = "test", WasteOperation = "test" };

        //    AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
        //    additionalParameters.CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext() { Remark = "RegiXTest" };// "\"LawReason\":\"�������� �� RegiX\",\"ServiceURI\":\"123456789\",\�ServiceType\�:\��� ������������ �������\�\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"������������ �� ����������� � �������\",\� UserAdministrationID\�:\�10.20.503.4\�,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";
        //    additionalParameters.CitizenEGN = "8888888888";
        //    additionalParameters.ClientIPAddress = "111.111.111.111";
        //    additionalParameters.ConsumerCertificateThumbprint = "###";
        //    additionalParameters.EIDToken = "token123";
        //    additionalParameters.EmployeeEGN = "11111111111111";
        //    additionalParameters.OrganizationEIK = "12121212121";
        //    additionalParameters.OrganizationUnit = "qqqqqq";
        //    additionalParameters.SignResult = false;
        //    additionalParameters.ReturnAccessMatrix = true;

        //    var result = adapter.GetREG35_Licenses_By_EIK_Waste_Code_Waste_Operation(searchCriteria, accessMatrix, additionalParameters);
        //    string xml = result.Data.Response.XmlSerialize();
        //    using (StreamWriter outfile = new StreamWriter("GetREG35_Licenses_By_EIK_Waste_Code_Waste_Operation_NULL_Test.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(xml);
        //    }
        //    XsltUtils.RunXsltAndWriteHtml("IaosREG35Adapter", "REG35_Licenses_By_EIK_Waste_Operation_Request", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("IaosREG35Adapter", "REG35_Licenses_By_EIK_Waste_Operation_Response", result.Data.Response.XmlSerialize());

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
        //public void REG35StagesByAuthNumTest()
        //{
        //    TechnoLogica.RegiX.Common.TransportObject.CallContext context = new TechnoLogica.RegiX.Common.TransportObject.CallContext()
        //    {
        //        AdministrationOId = "https://trust-party-openid.com",
        //        LawReason = "�������� �� RegiX",
        //        ServiceURI = "1222-200030-12.12.2022",
        //        Remark = "���������",
        //        EmployeeAditionalIdentifier = "����� ����� 3",
        //        EmployeeIdentifier = "test@tesactivedirectory.com",
        //        EmployeeNames = "������ ���������� ����������",
        //        AdministrationName = "��������� ������� �� ��������",
        //        EmployeePosition = "������ ������� ����� \"�������� �� ������������\"",
        //        ResponsiblePersonIdentifier = "392309324",
        //        ServiceType = "�� ������������ �������"
        //    };
        //    string oldcontext = context.ToString();

        //    IaosREG35Adapter adapter = new IaosREG35Adapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(REG35_Stages_By_Auth_Num_Response));
        //    REG35_Stages_By_Auth_Num_Request searchCriteria = new REG35_Stages_By_Auth_Num_Request() { AuthNum = "00-��-00000185-09" };

        //    AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
        //    additionalParameters.CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext() { Remark = "RegiXTest" };// "\"LawReason\":\"�������� �� RegiX\",\"ServiceURI\":\"123456789\",\�ServiceType\�:\��� ������������ �������\�\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"������������ �� ����������� � �������\",\� UserAdministrationID\�:\�10.20.503.4\�,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";
        //    additionalParameters.CitizenEGN = "8888888888";
        //    additionalParameters.ClientIPAddress = "111.111.111.111";
        //    additionalParameters.ConsumerCertificateThumbprint = "###";
        //    additionalParameters.EIDToken = "token123";
        //    additionalParameters.EmployeeEGN = "11111111111111";
        //    additionalParameters.OrganizationEIK = "12121212121";
        //    additionalParameters.OrganizationUnit = "qqqqqq";
        //    additionalParameters.SignResult = false;
        //    additionalParameters.ReturnAccessMatrix = true;

        //    var result = adapter.GetREG35_Stages_By_Auth_Num(searchCriteria, accessMatrix, additionalParameters);
        //    string xml = result.Data.Response.XmlSerialize();
        //    using (StreamWriter outfile = new StreamWriter("GetREG35_Stages_By_Auth_Num_Test.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(xml);
        //    }
        //    XsltUtils.RunXsltAndWriteHtml("IaosREG35Adapter", "REG35_Stages_By_Auth_Num_Request", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("IaosREG35Adapter", "REG35_Stages_By_Auth_Num_Response", result.Data.Response.XmlSerialize());

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
        //public void REG35StagesByAuthNumNullTest()
        //{
        //    TechnoLogica.RegiX.Common.TransportObject.CallContext context = new TechnoLogica.RegiX.Common.TransportObject.CallContext()
        //    {
        //        AdministrationOId = "https://trust-party-openid.com",
        //        LawReason = "�������� �� RegiX",
        //        ServiceURI = "1222-200030-12.12.2022",
        //        Remark = "���������",
        //        EmployeeAditionalIdentifier = "����� ����� 3",
        //        EmployeeIdentifier = "test@tesactivedirectory.com",
        //        EmployeeNames = "������ ���������� ����������",
        //        AdministrationName = "��������� ������� �� ��������",
        //        EmployeePosition = "������ ������� ����� \"�������� �� ������������\"",
        //        ResponsiblePersonIdentifier = "392309324",
        //        ServiceType = "�� ������������ �������"
        //    };
        //    string oldcontext = context.ToString();

        //    IaosREG35Adapter adapter = new IaosREG35Adapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(REG35_Stages_By_Auth_Num_Response));
        //    REG35_Stages_By_Auth_Num_Request searchCriteria = new REG35_Stages_By_Auth_Num_Request() { AuthNum = "8" };

        //    AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
        //    additionalParameters.CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext() { Remark = "RegiXTest" };// "\"LawReason\":\"�������� �� RegiX\",\"ServiceURI\":\"123456789\",\�ServiceType\�:\��� ������������ �������\�\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"������������ �� ����������� � �������\",\� UserAdministrationID\�:\�10.20.503.4\�,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";
        //    additionalParameters.CitizenEGN = "8888888888";
        //    additionalParameters.ClientIPAddress = "111.111.111.111";
        //    additionalParameters.ConsumerCertificateThumbprint = "###";
        //    additionalParameters.EIDToken = "token123";
        //    additionalParameters.EmployeeEGN = "11111111111111";
        //    additionalParameters.OrganizationEIK = "12121212121";
        //    additionalParameters.OrganizationUnit = "qqqqqq";
        //    additionalParameters.SignResult = false;
        //    additionalParameters.ReturnAccessMatrix = true;

        //    var result = adapter.GetREG35_Stages_By_Auth_Num(searchCriteria, accessMatrix, additionalParameters);
        //    string xml = result.Data.Response.XmlSerialize();
        //    using (StreamWriter outfile = new StreamWriter("GetREG35_Stages_By_Auth_Num_NULL_Test.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(xml);
        //    }
        //    XsltUtils.RunXsltAndWriteHtml("IaosREG35Adapter", "REG35_Stages_By_Auth_Num_Request", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("IaosREG35Adapter", "REG35_Stages_By_Auth_Num_Response", result.Data.Response.XmlSerialize());

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
        //public void REG35StagesValidityPeriodTest()
        //{
        //    TechnoLogica.RegiX.Common.TransportObject.CallContext context = new TechnoLogica.RegiX.Common.TransportObject.CallContext()
        //    {
        //        AdministrationOId = "https://trust-party-openid.com",
        //        LawReason = "�������� �� RegiX",
        //        ServiceURI = "1222-200030-12.12.2022",
        //        Remark = "���������",
        //        EmployeeAditionalIdentifier = "����� ����� 3",
        //        EmployeeIdentifier = "test@tesactivedirectory.com",
        //        EmployeeNames = "������ ���������� ����������",
        //        AdministrationName = "��������� ������� �� ��������",
        //        EmployeePosition = "������ ������� ����� \"�������� �� ������������\"",
        //        ResponsiblePersonIdentifier = "392309324",
        //        ServiceType = "�� ������������ �������"
        //    };
        //    string oldcontext = context.ToString();

        //    IaosREG35Adapter adapter = new IaosREG35Adapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(REG35_Stages_Validity_Period_Response));
        //    REG35_Stages_Validity_Period_Request searchCriteria = new REG35_Stages_Validity_Period_Request() { AuthNum = "00-��-00000185-09", DateTime = new DateTime(2015, 01, 25), StageNum = "1" };

        //    AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
        //    additionalParameters.CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext() { Remark = "RegiXTest" };// "\"LawReason\":\"�������� �� RegiX\",\"ServiceURI\":\"123456789\",\�ServiceType\�:\��� ������������ �������\�\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"������������ �� ����������� � �������\",\� UserAdministrationID\�:\�10.20.503.4\�,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";
        //    additionalParameters.CitizenEGN = "8888888888";
        //    additionalParameters.ClientIPAddress = "111.111.111.111";
        //    additionalParameters.ConsumerCertificateThumbprint = "###";
        //    additionalParameters.EIDToken = "token123";
        //    additionalParameters.EmployeeEGN = "11111111111111";
        //    additionalParameters.OrganizationEIK = "12121212121";
        //    additionalParameters.OrganizationUnit = "qqqqqq";
        //    additionalParameters.SignResult = false;
        //    additionalParameters.ReturnAccessMatrix = true;

        //    var result = adapter.GetREG35_Stages_Validity_Period(searchCriteria, accessMatrix, additionalParameters);
        //    string xml = result.Data.Response.XmlSerialize();
        //    using (StreamWriter outfile = new StreamWriter("GetREG35_Stages_Validity_Period_Test.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(xml);
        //    }
        //    XsltUtils.RunXsltAndWriteHtml("IaosREG35Adapter", "REG35_Stages_Validity_Period_Request", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("IaosREG35Adapter", "REG35_Stages_Validity_Period_Response", result.Data.Response.XmlSerialize());

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
        //public void REG35StagesValidityPeriodNullTest()
        //{
        //    TechnoLogica.RegiX.Common.TransportObject.CallContext context = new TechnoLogica.RegiX.Common.TransportObject.CallContext()
        //    {
        //        AdministrationOId = "https://trust-party-openid.com",
        //        LawReason = "�������� �� RegiX",
        //        ServiceURI = "1222-200030-12.12.2022",
        //        Remark = "���������",
        //        EmployeeAditionalIdentifier = "����� ����� 3",
        //        EmployeeIdentifier = "test@tesactivedirectory.com",
        //        EmployeeNames = "������ ���������� ����������",
        //        AdministrationName = "��������� ������� �� ��������",
        //        EmployeePosition = "������ ������� ����� \"�������� �� ������������\"",
        //        ResponsiblePersonIdentifier = "392309324",
        //        ServiceType = "�� ������������ �������"
        //    };
        //    string oldcontext = context.ToString();

        //    IaosREG35Adapter adapter = new IaosREG35Adapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(REG35_Stages_Validity_Period_Response));
        //    REG35_Stages_Validity_Period_Request searchCriteria = new REG35_Stages_Validity_Period_Request() { AuthNum = "test", DateTime = new DateTime(2000, 1, 1), StageNum = "2" };

        //    AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
        //    additionalParameters.CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext() { Remark = "RegiXTest" };// "\"LawReason\":\"�������� �� RegiX\",\"ServiceURI\":\"123456789\",\�ServiceType\�:\��� ������������ �������\�\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"������������ �� ����������� � �������\",\� UserAdministrationID\�:\�10.20.503.4\�,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";
        //    additionalParameters.CitizenEGN = "8888888888";
        //    additionalParameters.ClientIPAddress = "111.111.111.111";
        //    additionalParameters.ConsumerCertificateThumbprint = "###";
        //    additionalParameters.EIDToken = "token123";
        //    additionalParameters.EmployeeEGN = "11111111111111";
        //    additionalParameters.OrganizationEIK = "12121212121";
        //    additionalParameters.OrganizationUnit = "qqqqqq";
        //    additionalParameters.SignResult = false;
        //    additionalParameters.ReturnAccessMatrix = true;

        //    var result = adapter.GetREG35_Stages_Validity_Period(searchCriteria, accessMatrix, additionalParameters);
        //    string xml = result.Data.Response.XmlSerialize();
        //    using (StreamWriter outfile = new StreamWriter("GetREG35_Stages_Validity_Period_NULL_Test.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(xml);
        //    }
        //    XsltUtils.RunXsltAndWriteHtml("IaosREG35Adapter", "REG35_Stages_Validity_Period_Request", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("IaosREG35Adapter", "REG35_Stages_Validity_Period_Response", result.Data.Response.XmlSerialize());

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

        ////[TestMethod]
        ////public void CheckConnectionTest()
        ////{
        ////    IaosREG35Adapter adapter = new IaosREG35Adapter();
        ////    ConnectionStatusInfo status = adapter.CheckRegisterConnection();
        ////    Assert.IsTrue(true);
        ////}
    }
}


