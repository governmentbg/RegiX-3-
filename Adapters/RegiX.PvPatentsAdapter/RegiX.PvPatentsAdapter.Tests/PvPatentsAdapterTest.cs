using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechnoLogica.RegiX.Adapters.TestUtils;
using TechnoLogica.RegiX.PvPatentsAdapter.AdapterService;

namespace TechnoLogica.RegiX.PvPatentsAdapter.Tests
{
    [TestClass]
    public class PvPatentsAdapterTest : AdapterTest<AdapterService.PvPatentsAdapter, IPvPatentsAdapter>
    {
        //[TestMethod]
        //public void PvPatentsAdapter_CheckHealthCheckAndParamtersTest()
        //{
        //    PvPatentsAdapter adapter = new PvPatentsAdapter();
        //    //test GetParameters , and ConnectionString
        //    var connectionString = adapter.GetParameters().ParameterList.Where(p => p.Key == TechnoLogica.RegiX.Common.Constants.WebServiceUrlParameterKeyName).FirstOrDefault();
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
        //public void PvPatentsAdapter_CheckRegisterConnection()
        //{
        //    PvPatentsAdapter adapter = new PvPatentsAdapter();
        //    string result = adapter.CheckRegisterConnection();
        //    Assert.IsTrue(result == TechnoLogica.RegiX.Common.Constants.ConnectionOk || result == TechnoLogica.RegiX.Common.Constants.ConnectionStringNotSet);
        //}

        //[TestMethod]
        //public void GetREG_PATENT_App_Number_Test()
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
        //    // "\"LawReason\":\"�������� �� RegiX\",\"ServiceURI\":\"123456789\",\�ServiceType\�:\��� ������������ �������\�\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"������������ �� ����������� � �������\",\� UserAdministrationID\�:\�10.20.503.4\�,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";
        //    PvPatentsAdapter adapter = new PvPatentsAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(REG_UM_PATENT_PatentDetails_Response));
        //    getPatentByAppNumType searchCriteria = new getPatentByAppNumType() { AppNum = "1952120001N" };

        //    AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
        //    additionalParameters.CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext(){ Remark = "RegiXTest"};// "\"LawReason\":\"�������� �� RegiX\",\"ServiceURI\":\"123456789\",\�ServiceType\�:\��� ������������ �������\�\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"������������ �� ����������� � �������\",\� UserAdministrationID\�:\�10.20.503.4\�,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";
        //    additionalParameters.CitizenEGN = "8888888888";
        //    additionalParameters.ClientIPAddress = "111.111.111.111";
        //    additionalParameters.ConsumerCertificateThumbprint = "###";
        //    additionalParameters.EIDToken = "token123";
        //    additionalParameters.EmployeeEGN = "11111111111111";
        //    additionalParameters.OrganizationEIK = "12121212121";
        //    additionalParameters.OrganizationUnit = "qqqqqq";
        //    additionalParameters.SignResult = true;
        //    additionalParameters.ReturnAccessMatrix = true;

        //    var result = adapter.GetREG_PATENT_App_Number(searchCriteria, accessMatrix, additionalParameters);
        //    string xml = result.XmlSerialize();
        //    using (StreamWriter outfile = new StreamWriter("GetREG_PATENT_App_Number_Test.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(xml);
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("PvPatentsAdapter", "REG_PATENT_App_Number_Reuqest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("PvPatentsAdapter", "REG_UM_PATENT_PatentDetails_Response", result.Data.Response.XmlSerialize());

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
        //public void GetREG_PATENT_App_Number_NoData_Test()
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
        //    // "\"LawReason\":\"�������� �� RegiX\",\"ServiceURI\":\"123456789\",\�ServiceType\�:\��� ������������ �������\�\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"������������ �� ����������� � �������\",\� UserAdministrationID\�:\�10.20.503.4\�,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";
        //    PvPatentsAdapter adapter = new PvPatentsAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(REG_UM_PATENT_PatentDetails_Response));
        //    getPatentByAppNumType searchCriteria = new getPatentByAppNumType() { AppNum = "1071520000000000000000" };

        //    AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
        //    additionalParameters.CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext();// "\"LawReason\":\"�������� �� RegiX\",\"ServiceURI\":\"123456789\",\�ServiceType\�:\��� ������������ �������\�\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"������������ �� ����������� � �������\",\� UserAdministrationID\�:\�10.20.503.4\�,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";
        //    additionalParameters.CitizenEGN = "8888888888";
        //    additionalParameters.ClientIPAddress = "111.111.111.111";
        //    additionalParameters.ConsumerCertificateThumbprint = "###";
        //    additionalParameters.EIDToken = "token123";
        //    additionalParameters.EmployeeEGN = "11111111111111";
        //    additionalParameters.OrganizationEIK = "12121212121";
        //    additionalParameters.OrganizationUnit = "qqqqqq";
        //    additionalParameters.SignResult = true;
        //    additionalParameters.ReturnAccessMatrix = true;

        //    var result = adapter.GetREG_PATENT_App_Number(searchCriteria, accessMatrix, additionalParameters);
        //    string xml = result.XmlSerialize();
        //    using (StreamWriter outfile = new StreamWriter("GetREG_PATENT_App_Number_NoData_Test.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(xml);
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("PvPatentsAdapter", "REG_PATENT_App_Number_Reuqest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("PvPatentsAdapter", "REG_UM_PATENT_PatentDetails_Response", result.Data.Response.XmlSerialize());

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
        //public void GetREG_PATENT_Patent_Name_Test()
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
        //    // "\"LawReason\":\"�������� �� RegiX\",\"ServiceURI\":\"123456789\",\�ServiceType\�:\��� ������������ �������\�\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"������������ �� ����������� � �������\",\� UserAdministrationID\�:\�10.20.503.4\�,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";
        //    PvPatentsAdapter adapter = new PvPatentsAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(REG_UM_PATENT_PatentDetails_Response));
        //    getPatentsByNameType searchCriteria = new getPatentsByNameType() { PatentName = "���������� �� ������������� ������� �� ��������� �� ������ � ������� �������� �����" };

        //    AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
        //    additionalParameters.CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext(){ Remark = "RegiXTest"};// "\"LawReason\":\"�������� �� RegiX\",\"ServiceURI\":\"123456789\",\�ServiceType\�:\��� ������������ �������\�\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"������������ �� ����������� � �������\",\� UserAdministrationID\�:\�10.20.503.4\�,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";
        //    additionalParameters.CitizenEGN = "8888888888";
        //    additionalParameters.ClientIPAddress = "111.111.111.111";
        //    additionalParameters.ConsumerCertificateThumbprint = "###";
        //    additionalParameters.EIDToken = "token123";
        //    additionalParameters.EmployeeEGN = "11111111111111";
        //    additionalParameters.OrganizationEIK = "12121212121";
        //    additionalParameters.OrganizationUnit = "qqqqqq";
        //    additionalParameters.SignResult = true;
        //    additionalParameters.ReturnAccessMatrix = true;

        //    var result = adapter.GetREG_PATENT_Patent_Name(searchCriteria, accessMatrix, additionalParameters);
        //    string xml = result.XmlSerialize();
        //    using (StreamWriter outfile = new StreamWriter("GetREG_PATENT_Patent_Name_Test.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(xml);
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("PvPatentsAdapter", "REG_PATENT_Patent_Name_Request", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("PvPatentsAdapter", "REG_UM_PATENT_PatentDetails_Response", result.Data.Response.XmlSerialize());

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
        //public void GetREG_PATENT_Patent_Name_NoData_Test()
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
        //    // "\"LawReason\":\"�������� �� RegiX\",\"ServiceURI\":\"123456789\",\�ServiceType\�:\��� ������������ �������\�\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"������������ �� ����������� � �������\",\� UserAdministrationID\�:\�10.20.503.4\�,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";
        //    PvPatentsAdapter adapter = new PvPatentsAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(REG_UM_PATENT_PatentDetails_Response));
        //    getPatentsByNameType searchCriteria = new getPatentsByNameType() { PatentName = "dgfsdgdfsgdfg" };

        //    AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
        //    additionalParameters.CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext(){ Remark = "RegiXTestTest"};// "\"LawReason\":\"�������� �� RegiX\",\"ServiceURI\":\"123456789\",\�ServiceType\�:\��� ������������ �������\�\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"������������ �� ����������� � �������\",\� UserAdministrationID\�:\�10.20.503.4\�,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";
        //    additionalParameters.CitizenEGN = "8888888888";
        //    additionalParameters.ClientIPAddress = "111.111.111.111";
        //    additionalParameters.ConsumerCertificateThumbprint = "###";
        //    additionalParameters.EIDToken = "token123";
        //    additionalParameters.EmployeeEGN = "11111111111111";
        //    additionalParameters.OrganizationEIK = "12121212121";
        //    additionalParameters.OrganizationUnit = "qqqqqq";
        //    additionalParameters.SignResult = true;
        //    additionalParameters.ReturnAccessMatrix = true;

        //    var result = adapter.GetREG_PATENT_Patent_Name(searchCriteria, accessMatrix, additionalParameters);
        //    string xml = result.XmlSerialize();
        //    using (StreamWriter outfile = new StreamWriter("GetREG_PATENT_Patent_Name_NoData_Test.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(xml);
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("PvPatentsAdapter", "REG_PATENT_Patent_Name_Request", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("PvPatentsAdapter", "REG_UM_PATENT_PatentDetails_Response", result.Data.Response.XmlSerialize());

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
        //public void GetREG_PATENT_Patent_Owner_Test()
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
        //    // "\"LawReason\":\"�������� �� RegiX\",\"ServiceURI\":\"123456789\",\�ServiceType\�:\��� ������������ �������\�\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"������������ �� ����������� � �������\",\� UserAdministrationID\�:\�10.20.503.4\�,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";
        //    PvPatentsAdapter adapter = new PvPatentsAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(REG_UM_PATENT_PatentDetails_Response));
        //    getPatentByOwnersNameType searchCriteria = new getPatentByOwnersNameType() { FirstName = "", Surname = "", LastName = "OCTAPHARMA BIOPHARMACEUTICALS GMBH" };

        //    AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
        //    additionalParameters.CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext() { Remark = "RegiXTest" };// "\"LawReason\":\"�������� �� RegiX\",\"ServiceURI\":\"123456789\",\�ServiceType\�:\��� ������������ �������\�\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"������������ �� ����������� � �������\",\� UserAdministrationID\�:\�10.20.503.4\�,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";
        //    additionalParameters.CitizenEGN = "8888888888";
        //    additionalParameters.ClientIPAddress = "111.111.111.111";
        //    additionalParameters.ConsumerCertificateThumbprint = "###";
        //    additionalParameters.EIDToken = "token123";
        //    additionalParameters.EmployeeEGN = "11111111111111";
        //    additionalParameters.OrganizationEIK = "12121212121";
        //    additionalParameters.OrganizationUnit = "qqqqqq";
        //    additionalParameters.SignResult = true;
        //    additionalParameters.ReturnAccessMatrix = true;

        //    var result = adapter.GetREG_PATENT_Patent_Owner(searchCriteria, accessMatrix, additionalParameters);
        //    string xml = result.XmlSerialize();
        //    using (StreamWriter outfile = new StreamWriter("GetREG_PATENT_Patent_Owner_Test.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(xml);
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("PvPatentsAdapter", "REG_PATENT_Patent_Owner_Request", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("PvPatentsAdapter", "REG_UM_PATENT_PatentDetails_Response", result.Data.Response.XmlSerialize());

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
        //public void GetREG_PATENT_Patent_Owner_NoData_Test()
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
        //    // "\"LawReason\":\"�������� �� RegiX\",\"ServiceURI\":\"123456789\",\�ServiceType\�:\��� ������������ �������\�\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"������������ �� ����������� � �������\",\� UserAdministrationID\�:\�10.20.503.4\�,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";
        //    PvPatentsAdapter adapter = new PvPatentsAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(REG_UM_PATENT_PatentDetails_Response));
        //    getPatentByOwnersNameType searchCriteria = new getPatentByOwnersNameType() { FirstName = "", Surname = "", LastName = "blablalal" };

        //    AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
        //    additionalParameters.CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext() { Remark = "RegiXTest" };// "\"LawReason\":\"�������� �� RegiX\",\"ServiceURI\":\"123456789\",\�ServiceType\�:\��� ������������ �������\�\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"������������ �� ����������� � �������\",\� UserAdministrationID\�:\�10.20.503.4\�,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";
        //    additionalParameters.CitizenEGN = "8888888888";
        //    additionalParameters.ClientIPAddress = "111.111.111.111";
        //    additionalParameters.ConsumerCertificateThumbprint = "###";
        //    additionalParameters.EIDToken = "token123";
        //    additionalParameters.EmployeeEGN = "11111111111111";
        //    additionalParameters.OrganizationEIK = "12121212121";
        //    additionalParameters.OrganizationUnit = "qqqqqq";
        //    additionalParameters.SignResult = true;
        //    additionalParameters.ReturnAccessMatrix = true;

        //    var result = adapter.GetREG_PATENT_Patent_Owner(searchCriteria, accessMatrix, additionalParameters);
        //    string xml = result.XmlSerialize();
        //    using (StreamWriter outfile = new StreamWriter("GetREG_PATENT_Patent_Owner_NoData_Test.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(xml);
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("PvPatentsAdapter", "REG_PATENT_Patent_Owner_Request", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("PvPatentsAdapter", "REG_UM_PATENT_PatentDetails_Response", result.Data.Response.XmlSerialize());

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
        //public void GetREG_PATENT_Reg_Number_Test()
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
        //    // "\"LawReason\":\"�������� �� RegiX\",\"ServiceURI\":\"123456789\",\�ServiceType\�:\��� ������������ �������\�\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"������������ �� ����������� � �������\",\� UserAdministrationID\�:\�10.20.503.4\�,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";
        //    PvPatentsAdapter adapter = new PvPatentsAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(REG_UM_PATENT_PatentDetails_Response));
        //    getPatentByRegNumType searchCriteria = new getPatentByRegNumType() { RegNum = "065930" };

        //    AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
        //    additionalParameters.CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext();// "\"LawReason\":\"�������� �� RegiX\",\"ServiceURI\":\"123456789\",\�ServiceType\�:\��� ������������ �������\�\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"������������ �� ����������� � �������\",\� UserAdministrationID\�:\�10.20.503.4\�,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";
        //    additionalParameters.CitizenEGN = "8888888888";
        //    additionalParameters.ClientIPAddress = "111.111.111.111";
        //    additionalParameters.ConsumerCertificateThumbprint = "###";
        //    additionalParameters.EIDToken = "token123";
        //    additionalParameters.EmployeeEGN = "11111111111111";
        //    additionalParameters.OrganizationEIK = "12121212121";
        //    additionalParameters.OrganizationUnit = "qqqqqq";
        //    additionalParameters.SignResult = true;
        //    additionalParameters.ReturnAccessMatrix = true;

        //    var result = adapter.GetREG_PATENT_Reg_Number(searchCriteria, accessMatrix, additionalParameters);
        //    string xml = result.XmlSerialize();
        //    using (StreamWriter outfile = new StreamWriter("GetREG_PATENT_Reg_Number_Test.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(xml);
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("PvPatentsAdapter", "REG_PATENT_Reg_Number_Request", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("PvPatentsAdapter", "REG_UM_PATENT_PatentDetails_Response", result.Data.Response.XmlSerialize());

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
        //public void GetREG_PATENT_Reg_Number_NOdata_Test()
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
        //    // "\"LawReason\":\"�������� �� RegiX\",\"ServiceURI\":\"123456789\",\�ServiceType\�:\��� ������������ �������\�\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"������������ �� ����������� � �������\",\� UserAdministrationID\�:\�10.20.503.4\�,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";
        //    PvPatentsAdapter adapter = new PvPatentsAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(REG_UM_PATENT_PatentDetails_Response));
        //    getPatentByRegNumType searchCriteria = new getPatentByRegNumType() { RegNum = "06593000000000000" };

        //    AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
        //    additionalParameters.CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext();// "\"LawReason\":\"�������� �� RegiX\",\"ServiceURI\":\"123456789\",\�ServiceType\�:\��� ������������ �������\�\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"������������ �� ����������� � �������\",\� UserAdministrationID\�:\�10.20.503.4\�,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";
        //    additionalParameters.CitizenEGN = "8888888888";
        //    additionalParameters.ClientIPAddress = "111.111.111.111";
        //    additionalParameters.ConsumerCertificateThumbprint = "###";
        //    additionalParameters.EIDToken = "token123";
        //    additionalParameters.EmployeeEGN = "11111111111111";
        //    additionalParameters.OrganizationEIK = "12121212121";
        //    additionalParameters.OrganizationUnit = "qqqqqq";
        //    additionalParameters.SignResult = true;
        //    additionalParameters.ReturnAccessMatrix = true;

        //    var result = adapter.GetREG_PATENT_Reg_Number(searchCriteria, accessMatrix, additionalParameters);
        //    string xml = result.XmlSerialize();
        //    using (StreamWriter outfile = new StreamWriter("GetREG_PATENT_Reg_Number_NOData_Test.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(xml);
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("PvPatentsAdapter", "REG_PATENT_Reg_Number_Request", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("PvPatentsAdapter", "REG_UM_PATENT_PatentDetails_Response", result.Data.Response.XmlSerialize());

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
    }
}


