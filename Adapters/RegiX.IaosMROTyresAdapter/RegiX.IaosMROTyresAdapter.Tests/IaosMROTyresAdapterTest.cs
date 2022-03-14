using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechnoLogica.RegiX.IaosMROTyresAdapter.AdapterService;
using TechnoLogica.RegiX.Adapters.TestUtils;

namespace TechnoLogica.RegiX.IaosMROTyresAdapter.Tests
{
    [TestClass]
    public class IaosMROTyresAdapterTest :AdapterTest<AdapterService.IaosMROTyresAdapter, IIaosMROTyresAdapter>
    {

        //[TestMethod]
        //public void IaosMROTyresAdapterTest_CheckHealthCheckAndParamtersTest()
        //{
        //    IaosMROTyresAdapter adapter = new IaosMROTyresAdapter();
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
        //public void IaosMROTyresAdapterTest_CheckRegisterConnection()
        //{
        //    IaosMROTyresAdapter adapter = new IaosMROTyresAdapter();
        //    string result = adapter.CheckRegisterConnection();
        //    Assert.IsTrue(result == TechnoLogica.RegiX.Common.Constants.ConnectionOk || result == TechnoLogica.RegiX.Common.Constants.ConnectionStringNotSet);
        //}


        //[TestMethod]
        //public void MROTyresExecutionTypeTest()
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

        //    IaosMROTyresAdapter adapter = new IaosMROTyresAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(MRO_TYRES_Execution_Type_Response));
        //    MRO_TYRES_Execution_Type_Request searchCriteria = new MRO_TYRES_Execution_Type_Request() { EIK = "160086930" };

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

        //    var result = adapter.GetMRO_TYRES_Execution_Type(searchCriteria, accessMatrix, additionalParameters);
        //    string xml = result.XmlSerialize();
        //    using (StreamWriter outfile = new StreamWriter("GetMRO_TYRES_Execution_Type_Test.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(xml);
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("IaosMROTyresAdapter", "MRO_TYRES_Execution_Type_Request", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("IaosMROTyresAdapter", "MRO_TYRES_Execution_Type_Response", result.Data.Response.XmlSerialize());

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
        //public void MROTyresExecutionTypeNUllTest()
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

        //    IaosMROTyresAdapter adapter = new IaosMROTyresAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(MRO_TYRES_Execution_Type_Response));
        //    MRO_TYRES_Execution_Type_Request searchCriteria = new MRO_TYRES_Execution_Type_Request() { EIK = "111111111111" };

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
        //    var result = adapter.GetMRO_TYRES_Execution_Type(searchCriteria, accessMatrix, additionalParameters);
        //    string xml = result.XmlSerialize();
        //    using (StreamWriter outfile = new StreamWriter("GetMRO_TYRES_Execution_Type_NUll_Test.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(xml);
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("IaosMROTyresAdapter", "MRO_TYRES_Execution_Type_Request", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("IaosMROTyresAdapter", "MRO_TYRES_Execution_Type_Response", result.Data.Response.XmlSerialize());

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
        //public void MROTyresTradeMarksTest()
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

        //    IaosMROTyresAdapter adapter = new IaosMROTyresAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(MRO_TYRES_Trade_Marks_Response));
        //    MRO_TYRES_Trade_Marks_Request searchCriteria = new MRO_TYRES_Trade_Marks_Request() { AuthNum = "1466" };

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

        //    var result = adapter.GetMRO_TYRES_Trade_Marks(searchCriteria, accessMatrix, additionalParameters);
        //    string xml = result.XmlSerialize();
        //    using (StreamWriter outfile = new StreamWriter("GetMRO_TYRES_Trade_Marks_Test.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(xml);
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("IaosMROTyresAdapter", "MRO_TYRES_Trade_Marks_Request", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("IaosMROTyresAdapter", "MRO_TYRES_Trade_Marks_Response", result.Data.Response.XmlSerialize());

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
        //public void MROTyresTradeMarksNUllTest()
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


        //    IaosMROTyresAdapter adapter = new IaosMROTyresAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(MRO_TYRES_Trade_Marks_Response));
        //    MRO_TYRES_Trade_Marks_Request searchCriteria = new MRO_TYRES_Trade_Marks_Request() { AuthNum = "11111111111111" };

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

        //    var result = adapter.GetMRO_TYRES_Trade_Marks(searchCriteria, accessMatrix, additionalParameters);
        //    string xml = result.XmlSerialize();
        //    using (StreamWriter outfile = new StreamWriter("GetMRO_TYRES_Trade_Marks_null_Test.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(xml);
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("IaosMROTyresAdapter", "MRO_TYRES_Trade_Marks_Request", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("IaosMROTyresAdapter", "MRO_TYRES_Trade_Marks_Response", result.Data.Response.XmlSerialize());

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
        //public void MROTyresValidityCheckTest()
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

        //    IaosMROTyresAdapter adapter = new IaosMROTyresAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(MRO_TYRES_Validity_Check_Response));
        //    MRO_TYRES_Validity_Check_Request searchCriteria = new MRO_TYRES_Validity_Check_Request() { EIK = "160086930" };

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

        //    var result = adapter.GetMRO_TYRES_Validity_Check(searchCriteria, accessMatrix, additionalParameters);
        //    string xml = result.XmlSerialize();
        //    using (StreamWriter outfile = new StreamWriter("GetMRO_TYRES_Validity_Check_Test.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(xml);
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("IaosMROTyresAdapter", "MRO_TYRES_Validity_Check_Request", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("IaosMROTyresAdapter", "MRO_TYRES_Validity_Check_Response", result.Data.Response.XmlSerialize());

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
        //public void MROTyresValidityCheckNullTest()
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

        //    IaosMROTyresAdapter adapter = new IaosMROTyresAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(MRO_TYRES_Validity_Check_Response));
        //    MRO_TYRES_Validity_Check_Request searchCriteria = new MRO_TYRES_Validity_Check_Request() { EIK = "1111111111" };

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

        //    var result = adapter.GetMRO_TYRES_Validity_Check(searchCriteria, accessMatrix, additionalParameters);
        //    string xml = result.XmlSerialize();
        //    using (StreamWriter outfile = new StreamWriter("GetMRO_TYRES_Validity_Check_NUll_Test.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(xml);
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("IaosMROTyresAdapter", "MRO_TYRES_Validity_Check_Request", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("IaosMROTyresAdapter", "MRO_TYRES_Validity_Check_Response", result.Data.Response.XmlSerialize());

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
        ////    IaosMROTyresAdapter adapter = new IaosMROTyresAdapter();
        ////    ConnectionStatusInfo status = adapter.CheckRegisterConnection();
        ////    Assert.IsTrue(true);
        ////}
    }

}


