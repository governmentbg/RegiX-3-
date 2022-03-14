using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechnoLogica.RegiX.MPNPOAdapter.AdapterService;
using TechnoLogica.RegiX.Adapters.TestUtils;

namespace TechnoLogica.RegiX.MPNPOAdapter.Tests
{
    [TestClass]
    public class MPNPOAdapterTest : AdapterTest<AdapterService.MPNPOAdapter, IMPNPOAdapter>
    {
        //[TestMethod]
        //public void MPNPOAdapterTest_CheckHealthCheckAndParamtersTest()
        //{
        //    MPNPOAdapter adapter = new MPNPOAdapter();
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
        //public void MPNPOAdapterTest_CheckRegisterConnection()
        //{
        //    MPNPOAdapter adapter = new MPNPOAdapter();
        //    string result = adapter.CheckRegisterConnection();
        //    Assert.IsTrue(result == TechnoLogica.RegiX.Common.Constants.ConnectionOk || result == TechnoLogica.RegiX.Common.Constants.ConnectionStringNotSet);
        //}

        //[TestMethod]
        //public void GetNPORegistrationInfoTest()
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

        //    MPNPOAdapter npo = new MPNPOAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(NPODetailsResponseType));
        //    NPODetailsRequestType searchCriteria = new NPODetailsRequestType() { Bulstat = "22222222" }; //123456789
        //    var result = npo.GetNPORegistrationInfo(searchCriteria, accessMatrix, additionalParameters);
        //    string xml = result.XmlSerialize();
        //    using (StreamWriter outfile = new StreamWriter("GetNPORegistrationInfoTest.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(xml);
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("MPNPOAdapter", "NpoDetailsRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("MPNPOAdapter", "NPODeatailsInfo", result.Data.Response.XmlSerialize());


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
        //public void GetNPOStatusInfoTest()
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

        //    MPNPOAdapter npo = new MPNPOAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(NPOStatusResponseType));
        //    NPOStatusRequestType searchCriteria = new NPOStatusRequestType() { Bulstat = "22222222" }; //123456789
        //    var result = npo.GetNPOStatusInfo(searchCriteria, accessMatrix, additionalParameters);
        //    string xml = result.XmlSerialize();
        //    using (StreamWriter outfile = new StreamWriter("NPOStatusInfo.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(xml);
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("MPNPOAdapter", "NPOStatusRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("MPNPOAdapter", "NPOStatusInfo", result.Data.Response.XmlSerialize());

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


