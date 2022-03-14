using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//using RegiX.Adapters.FileParameterStore;
using TechnoLogica.RegiX.Adapters.TestUtils;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.Common.Utils;
using TechnoLogica.RegiX.IaosMRABagsAdapter.AdapterService;

namespace TechnoLogica.RegiX.IaosMRABagsAdapter.Tests
{
    [TestClass]
    public class IaosMRABagsAdapterTest : AdapterTest<AdapterService.IaosMRABagsAdapter, IIaosMRABagsAdapter>
    {
        public IaosMRABagsAdapterTest()
        {
            AggregateCatalog catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(AdapterService.IaosMRABagsAdapter).Assembly));
            //catalog.Catalogs.Add(new AssemblyCatalog(typeof(FileParameterStoreImplementation).Assembly));
            catalog.Catalogs.Add(new TypeCatalog(typeof(BinDirectoryLocator)));
            CompositionContainer result = new CompositionContainer(catalog, true);
            result.ComposeExportedValue(result);
            Composition.CompositionContainer = result;
        }


        //public void IaosMRABagsAdapterTest_CheckHealthCheckAndParamtersTest()
        //{
        //                AdapterService.IaosMRABagsAdapter adapter = new AdapterService.IaosMRABagsAdapter();
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

        //public void IaosMRABagsAdapterTest_CheckRegisterConnection()
        //{
        //                AdapterService.IaosMRABagsAdapter adapter = new AdapterService.IaosMRABagsAdapter();
        //    string result = adapter.CheckRegisterConnection();
        //    Assert.IsTrue(result == TechnoLogica.RegiX.Common.Constants.ConnectionOk || result == TechnoLogica.RegiX.Common.Constants.ConnectionStringNotSet);
        //}


        //[TestMethod]
        //public void GetMRA_BAGS_Reg_Number_Date_Test()
        //{
        //    CallContext context = new CallContext()
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

        //    AdapterService.IaosMRABagsAdapter adapter = new AdapterService.IaosMRABagsAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(MRO_BAGS_Reg_Number_Date_Response));
        //    MRO_BAGS_Reg_Number_Date_Request searchCriteria = new MRO_BAGS_Reg_Number_Date_Request()
        //    { DateTime = new DateTime(2015, 5, 5, 0, 0, 0), EIK = "131147842" };

        //    AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
        //    additionalParameters.CallContext =
        //        new CallContext(); // "\"LawReason\":\"�������� �� RegiX\",\"ServiceURI\":\"123456789\",\�ServiceType\�:\��� ������������ �������\�\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"������������ �� ����������� � �������\",\� UserAdministrationID\�:\�10.20.503.4\�,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";
        //    additionalParameters.CitizenEGN = "8888888888";
        //    additionalParameters.ClientIPAddress = "111.111.111.111";
        //    additionalParameters.ConsumerCertificateThumbprint = "###";
        //    additionalParameters.EIDToken = "token123";
        //    additionalParameters.EmployeeEGN = "11111111111111";
        //    additionalParameters.OrganizationEIK = "12121212121";
        //    additionalParameters.OrganizationUnit = "qqqqqq";
        //    additionalParameters.SignResult = false;
        //    additionalParameters.ReturnAccessMatrix = true;

        //    var result = adapter.GetMRA_BAGS_Reg_Number_Date(searchCriteria, accessMatrix, additionalParameters);

        //    string xml = result.XmlSerialize();
        //    using (StreamWriter outfile =
        //        new StreamWriter("GetMRA_BAGS_Reg_Number_Date_Test.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(xml);
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("IaosMRABagsAdapter", "MRO_BAGS_Reg_Number_Date_Request",
        //        result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("IaosMRABagsAdapter", "MRO_BAGS_Reg_Number_Date_Response",
        //        result.Data.Response.XmlSerialize());

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
        //public void GetMRA_BAGS_Reg_Number_Date_NULL_Test()
        //{
        //    CallContext context = new CallContext()
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

        //    AdapterService.IaosMRABagsAdapter adapter = new AdapterService.IaosMRABagsAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(MRO_BAGS_Reg_Number_Date_Response));
        //    MRO_BAGS_Reg_Number_Date_Request searchCriteria = new MRO_BAGS_Reg_Number_Date_Request()
        //    { DateTime = new DateTime(2015, 5, 5, 0, 0, 0), EIK = "11111111111111" };

        //    AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
        //    additionalParameters.CallContext = new CallContext() { Remark = "RegiXTest" };

        //    // "\"LawReason\":\"�������� �� RegiX\",\"ServiceURI\":\"123456789\",\�ServiceType\�:\��� ������������ �������\�\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"������������ �� ����������� � �������\",\� UserAdministrationID\�:\�10.20.503.4\�,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";

        //    additionalParameters.CitizenEGN = "8888888888";
        //    additionalParameters.ClientIPAddress = "111.111.111.111";
        //    additionalParameters.ConsumerCertificateThumbprint = "###";
        //    additionalParameters.EIDToken = "token123";
        //    additionalParameters.EmployeeEGN = "11111111111111";
        //    additionalParameters.OrganizationEIK = "12121212121";
        //    additionalParameters.OrganizationUnit = "qqqqqq";
        //    additionalParameters.SignResult = false;
        //    additionalParameters.ReturnAccessMatrix = true;

        //    var result = adapter.GetMRA_BAGS_Reg_Number_Date(searchCriteria, accessMatrix, additionalParameters);
        //    string xml = result.XmlSerialize();
        //    using (StreamWriter outfile = new StreamWriter("GetMRA_BAGS_Reg_Number_Date_NULL_Test.xml", false,
        //        System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(xml);
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("IaosMRABagsAdapter", "MRO_BAGS_Reg_Number_Date_Request",
        //        result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("IaosMRABagsAdapter", "MRO_BAGS_Reg_Number_Date_Response",
        //        result.Data.Response.XmlSerialize());

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
        //public void GetMRO_BAGS_Validity_Check_Test()
        //{
        //    CallContext context = new CallContext()
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

        //    AdapterService.IaosMRABagsAdapter adapter = new AdapterService.IaosMRABagsAdapter();

        //    var accessMatrix = AccessMatrix.CreateForType(typeof(MRO_BAGS_Validity_Check_Response));
        //    MRO_BAGS_Validity_Check_Request searchCriteria = new MRO_BAGS_Validity_Check_Request() { EIK = "131147842" };

        //    AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
        //    additionalParameters.CallContext =
        //        new CallContext()
        //        {
        //            Remark = "RegiXTestTest"
        //        }; 
            
        //    // "\"LawReason\":\"�������� �� RegiX\",\"ServiceURI\":\"123456789\",\�ServiceType\�:\��� ������������ �������\�\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"������������ �� ����������� � �������\",\� UserAdministrationID\�:\�10.20.503.4\�,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";

        //    additionalParameters.CitizenEGN = "8888888888";
        //    additionalParameters.ClientIPAddress = "111.111.111.111";
        //    additionalParameters.ConsumerCertificateThumbprint = "###";
        //    additionalParameters.EIDToken = "token123";
        //    additionalParameters.EmployeeEGN = "11111111111111";
        //    additionalParameters.OrganizationEIK = "12121212121";
        //    additionalParameters.OrganizationUnit = "qqqqqq";
        //    additionalParameters.SignResult = false;
        //    additionalParameters.ReturnAccessMatrix = true;

        //    var result = adapter.GetMRO_BAGS_Validity_Check(searchCriteria, accessMatrix, additionalParameters);

        //    string xml = result.XmlSerialize();
        //    using (StreamWriter outfile =
        //        new StreamWriter("GetMRO_BAGS_Validity_Check_Test.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(xml);
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("IaosMRABagsAdapter", "MRO_BAGS_Validity_Check_Request",
        //        result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("IaosMRABagsAdapter", "MRO_BAGS_Validity_Check_Response",
        //        result.Data.Response.XmlSerialize());

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
        //public void GetMRO_BAGS_Validity_Check_NULL_Test()
        //{
        //    CallContext context = new CallContext()
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

        //    AdapterService.IaosMRABagsAdapter adapter = new AdapterService.IaosMRABagsAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(MRO_BAGS_Validity_Check_Response));
        //    MRO_BAGS_Validity_Check_Request searchCriteria = new MRO_BAGS_Validity_Check_Request()
        //    { EIK = "111111111111111" };

        //    AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
        //    additionalParameters.CallContext =
        //        new CallContext()
        //        {
        //            Remark = "RegiXTestTest"
        //        }; // "\"LawReason\":\"�������� �� RegiX\",\"ServiceURI\":\"123456789\",\�ServiceType\�:\��� ������������ �������\�\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"������������ �� ����������� � �������\",\� UserAdministrationID\�:\�10.20.503.4\�,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";
        //    additionalParameters.CitizenEGN = "8888888888";
        //    additionalParameters.ClientIPAddress = "111.111.111.111";
        //    additionalParameters.ConsumerCertificateThumbprint = "###";
        //    additionalParameters.EIDToken = "token123";
        //    additionalParameters.EmployeeEGN = "11111111111111";
        //    additionalParameters.OrganizationEIK = "12121212121";
        //    additionalParameters.OrganizationUnit = "qqqqqq";
        //    additionalParameters.SignResult = false;
        //    additionalParameters.ReturnAccessMatrix = true;

        //    var result = adapter.GetMRO_BAGS_Validity_Check(searchCriteria, accessMatrix, additionalParameters);
        //    string xml = result.XmlSerialize();
        //    using (StreamWriter outfile = new StreamWriter("GetMRO_BAGS_Validity_Check_NULL_Test.xml", false,
        //        System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(xml);
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("IaosMRABagsAdapter", "MRO_BAGS_Validity_Check_Request",
        //        result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("IaosMRABagsAdapter", "MRO_BAGS_Validity_Check_Response",
        //        result.Data.Response.XmlSerialize());

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
        //public void GetMRO_BAGS_Reg_Number_Test()
        //{
        //    CallContext context = new CallContext()
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


        //    AdapterService.IaosMRABagsAdapter adapter = new AdapterService.IaosMRABagsAdapter();

        //    var accessMatrix = AccessMatrix.CreateForType(typeof(MRO_BAGS_Reg_Number_Response));
        //    MRO_BAGS_Reg_Number_Request searchCriteria = new MRO_BAGS_Reg_Number_Request() { AuthNum = "1512" };

        //    AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
        //    additionalParameters.CallContext =
        //        new CallContext()
        //        {
        //            Remark = "RegiXTestTest"
        //        };

        //    // "\"LawReason\":\"�������� �� RegiX\",\"ServiceURI\":\"123456789\",\�ServiceType\�:\��� ������������ �������\�\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"������������ �� ����������� � �������\",\� UserAdministrationID\�:\�10.20.503.4\�,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";

        //    additionalParameters.CitizenEGN = "8888888888";
        //    additionalParameters.ClientIPAddress = "111.111.111.111";
        //    additionalParameters.ConsumerCertificateThumbprint = "###";
        //    additionalParameters.EIDToken = "token123";
        //    additionalParameters.EmployeeEGN = "11111111111111";
        //    additionalParameters.OrganizationEIK = "12121212121";
        //    additionalParameters.OrganizationUnit = "qqqqqq";
        //    additionalParameters.SignResult = false;
        //    additionalParameters.ReturnAccessMatrix = true;

        //    var result = adapter.GetMRO_BAGS_Reg_Number(searchCriteria, accessMatrix, additionalParameters);

        //    string xml = result.XmlSerialize();
        //    using (StreamWriter outfile =
        //        new StreamWriter("GetMRO_BAGS_Reg_Number_Test.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(xml);
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("IaosMRABagsAdapter", "MRO_BAGS_Reg_Number_Request",
        //        result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("IaosMRABagsAdapter", "MRO_BAGS_Reg_Number_Response",
        //        result.Data.Response.XmlSerialize());

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
        //public void GetMRO_BAGS_Reg_Number_NULL_Test()
        //{
        //    CallContext context = new CallContext()
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

        //    AdapterService.IaosMRABagsAdapter adapter = new AdapterService.IaosMRABagsAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(MRO_BAGS_Reg_Number_Response));
        //    MRO_BAGS_Reg_Number_Request searchCriteria = new MRO_BAGS_Reg_Number_Request() { AuthNum = "aaaa" };

        //    AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
        //    additionalParameters.CallContext =
        //        new CallContext()
        //        {
        //            Remark = "RegiXTestTest"
        //        };

        //    // "\"LawReason\":\"�������� �� RegiX\",\"ServiceURI\":\"123456789\",\�ServiceType\�:\��� ������������ �������\�\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"������������ �� ����������� � �������\",\� UserAdministrationID\�:\�10.20.503.4\�,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";

        //    additionalParameters.CitizenEGN = "8888888888";
        //    additionalParameters.ClientIPAddress = "111.111.111.111";
        //    additionalParameters.ConsumerCertificateThumbprint = "###";
        //    additionalParameters.EIDToken = "token123";
        //    additionalParameters.EmployeeEGN = "11111111111111";
        //    additionalParameters.OrganizationEIK = "12121212121";
        //    additionalParameters.OrganizationUnit = "qqqqqq";
        //    additionalParameters.SignResult = false;
        //    additionalParameters.ReturnAccessMatrix = true;

        //    var result = adapter.GetMRO_BAGS_Reg_Number(searchCriteria, accessMatrix, additionalParameters);

        //    string xml = result.XmlSerialize();

        //    using (StreamWriter outfile =
        //        new StreamWriter("GetMRO_BAGS_Reg_Number_Test_NULL.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(xml);
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("IaosMRABagsAdapter", "MRO_BAGS_Reg_Number_Request",
        //        result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("IaosMRABagsAdapter", "MRO_BAGS_Reg_Number_Response",
        //        result.Data.Response.XmlSerialize());

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
        //                AdapterService.IaosMRABagsAdapter adapter = new AdapterService.IaosMRABagsAdapter();
        //    ConnectionStatusInfo status = adapter.CheckRegisterConnection();
        //    Assert.IsTrue(true);
        //}
    }
}
