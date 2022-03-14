using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Xml;
using System.Xml.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//using RegiX.Adapters.FileParameterStore;
using TechnoLogica.RegiX.Adapters.Common;
using TechnoLogica.RegiX.Adapters.Common.DataContracts;
using TechnoLogica.RegiX.Adapters.Common.Interfaces;
using TechnoLogica.RegiX.Adapters.TestUtils;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.DataContracts.Parameter;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.Common.Utils;
using TechnoLogica.RegiX.IaosMROBatteriesAdapter.AdapterService;

namespace TechnoLogica.RegiX.IaosMROBatteriesAdapter.Tests
{
    [TestClass]
    public class IaosMROBatteriesAdapterTest : AdapterTest<AdapterService.IaosMROBatteriesAdapter, IIaosMROBatteriesAdapter>
    {

        public IaosMROBatteriesAdapterTest()
        {
            AggregateCatalog catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new TypeCatalog(typeof(BinDirectoryLocator)));
            //catalog.Catalogs.Add(new AssemblyCatalog(typeof(FileParameterStoreImplementation).Assembly));
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(AdapterService.IaosMROBatteriesAdapter).Assembly));

            CompositionContainer result = new CompositionContainer(catalog, true);
            result.ComposeExportedValue(result);
            Composition.CompositionContainer = result;
        }


        //[TestMethod]
        //public void IaosMROBatteriesAdapterTest_CheckHealthCheckAndParamtersTest()
        //{
        //    AdapterService.IaosMROBatteriesAdapter adapter = new AdapterService.IaosMROBatteriesAdapter();
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
        //public void IaosMROBatteriesAdapterTest_CheckRegisterConnection()
        //{
        //    AdapterService.IaosMROBatteriesAdapter adapter = new AdapterService.IaosMROBatteriesAdapter();
        //    string result = adapter.CheckRegisterConnection();
        //    Assert.IsTrue(result == TechnoLogica.RegiX.Common.Constants.ConnectionOk || result == TechnoLogica.RegiX.Common.Constants.ConnectionStringNotSet);
        //}


        //[TestMethod]
        //public void GetMRO_BA_Validity_Check_Test()
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

        //    AdapterService.IaosMROBatteriesAdapter adapter = new AdapterService.IaosMROBatteriesAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(MRO_BA_Validity_Check_Response));
        //    MRO_BA_Validity_Check_Request searchCriteria = new MRO_BA_Validity_Check_Request() { EIK = "131103818" };

        //    AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
        //    additionalParameters.CallContext = new CallContext();
        //    additionalParameters.CitizenEGN = "8888888888";
        //    additionalParameters.ClientIPAddress = "111.111.111.111";
        //    additionalParameters.ConsumerCertificateThumbprint = "###";
        //    additionalParameters.EIDToken = "token123";
        //    additionalParameters.EmployeeEGN = "11111111111111";
        //    additionalParameters.OrganizationEIK = "12121212121";
        //    additionalParameters.OrganizationUnit = "qqqqqq";
        //    additionalParameters.SignResult = false;
        //    additionalParameters.ReturnAccessMatrix = true;

        //    var result = adapter.GetMRO_BA_Validity_Check(searchCriteria, accessMatrix, additionalParameters);
        //    string xml = result.XmlSerialize();
        //    using (StreamWriter outfile = new StreamWriter("GetMRO_BA_Validity_Check_Test.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(xml);
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("IaosMROBatteriesAdapter", "MRO_BA_Validity_Check_Request", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("IaosMROBatteriesAdapter", "MRO_BA_Validity_Check_Response", result.Data.Response.XmlSerialize());

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
        //public void GetMRO_BA_Validity_Check_NULL_Test()
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

        //    AdapterService.IaosMROBatteriesAdapter adapter = new AdapterService.IaosMROBatteriesAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(MRO_BA_Validity_Check_Response));
        //    MRO_BA_Validity_Check_Request searchCriteria = new MRO_BA_Validity_Check_Request() { EIK = "1111111111" };

        //    AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
        //    additionalParameters.CallContext = new CallContext();
        //    additionalParameters.CitizenEGN = "8888888888";
        //    additionalParameters.ClientIPAddress = "111.111.111.111";
        //    additionalParameters.ConsumerCertificateThumbprint = "###";
        //    additionalParameters.EIDToken = "token123";
        //    additionalParameters.EmployeeEGN = "11111111111111";
        //    additionalParameters.OrganizationEIK = "12121212121";
        //    additionalParameters.OrganizationUnit = "qqqqqq";
        //    additionalParameters.SignResult = false;
        //    additionalParameters.ReturnAccessMatrix = true;
        //    var result = adapter.GetMRO_BA_Validity_Check(searchCriteria, accessMatrix, additionalParameters);
        //    string xml = result.XmlSerialize();
        //    using (StreamWriter outfile = new StreamWriter("GetMRO_BA_Validity_Check_Test_NULL.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(xml);
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("IaosMROBatteriesAdapter", "MRO_BA_Validity_Check_Request", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("IaosMROBatteriesAdapter", "MRO_BA_Validity_Check_Response", result.Data.Response.XmlSerialize());

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
        //public void GetMRO_BA_Execution_Type_Test()
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

        //    AdapterService.IaosMROBatteriesAdapter adapter = Composition.CompositionContainer.GetExportedValue<IAdapterService>(typeof(AdapterService.IaosMROBatteriesAdapter).FullName) as AdapterService.IaosMROBatteriesAdapter;
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(MRO_BA_Execution_Type_Response));
        //    MRO_BA_Execution_Type_Request searchCriteria = new MRO_BA_Execution_Type_Request() { EIK = "131103818" };

        //    AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
        //    additionalParameters.CallContext = new CallContext();
        //    additionalParameters.CitizenEGN = "8888888888";
        //    additionalParameters.ClientIPAddress = "111.111.111.111";
        //    additionalParameters.ConsumerCertificateThumbprint = "###";
        //    additionalParameters.EIDToken = "token123";
        //    additionalParameters.EmployeeEGN = "11111111111111";
        //    additionalParameters.OrganizationEIK = "12121212121";
        //    additionalParameters.OrganizationUnit = "qqqqqq";
        //    additionalParameters.SignResult = false;
        //    additionalParameters.ReturnAccessMatrix = true;


        //    //adapter.ParameterStore = Composition.CompositionContainer.GetExportedValue<IParameterStore>();
        //    adapter.SetParameter(Constants.WebServiceUrlParameterKeyName, "https://regix2-adapters.regix.tlogica.com:4434/RegiX.IaosMROBatteriesAdapterMockup/MROBatteriesService.svc");
        //    var result = adapter.GetMRO_BA_Execution_Type(searchCriteria, accessMatrix, additionalParameters);

        //    string xml = result.XmlSerialize();
        //    using (StreamWriter outfile = new StreamWriter("GetMRO_BA_Execution_Type_Test.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(xml);
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("IaosMROBatteriesAdapter", "MRO_BA_Execution_Type_Request", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("IaosMROBatteriesAdapter", "MRO_BA_Execution_Type_Response", result.Data.Response.XmlSerialize());

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
        //public void GetMRO_BA_Execution_Type_NULL_Test()
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


        //    AdapterService.IaosMROBatteriesAdapter adapter = new AdapterService.IaosMROBatteriesAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(MRO_BA_Execution_Type_Response));
        //    MRO_BA_Execution_Type_Request searchCriteria = new MRO_BA_Execution_Type_Request() { EIK = "111111111111" };

        //    AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
        //    additionalParameters.CallContext = new CallContext(); additionalParameters.CitizenEGN = "8888888888";
        //    additionalParameters.ClientIPAddress = "111.111.111.111";
        //    additionalParameters.ConsumerCertificateThumbprint = "###";
        //    additionalParameters.EIDToken = "token123";
        //    additionalParameters.EmployeeEGN = "11111111111111";
        //    additionalParameters.OrganizationEIK = "12121212121";
        //    additionalParameters.OrganizationUnit = "qqqqqq";
        //    additionalParameters.SignResult = false;
        //    additionalParameters.ReturnAccessMatrix = true;

        //    var result = adapter.GetMRO_BA_Execution_Type(searchCriteria, accessMatrix, additionalParameters);
        //    string xml = result.XmlSerialize();

        //    using (StreamWriter outfile = new StreamWriter("GetMRO_BA_Execution_Type_NULL_Test.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(xml);
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("IaosMROBatteriesAdapter", "MRO_BA_Execution_Type_Request", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("IaosMROBatteriesAdapter", "MRO_BA_Execution_Type_Response", result.Data.Response.XmlSerialize());

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
        //public void GetMRO_BA_Trade_Marks_Test()
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

        //    AdapterService.IaosMROBatteriesAdapter adapter = new AdapterService.IaosMROBatteriesAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(MRO_BA_Trade_Marks_Response));
        //    MRO_BA_Trade_Marks_Request searchCriteria = new MRO_BA_Trade_Marks_Request() { AuthNum = "1924" };

        //    AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
        //    additionalParameters.CallContext = new CallContext();
        //    additionalParameters.CitizenEGN = "8888888888";
        //    additionalParameters.ClientIPAddress = "111.111.111.111";
        //    additionalParameters.ConsumerCertificateThumbprint = "###";
        //    additionalParameters.EIDToken = "token123";
        //    additionalParameters.EmployeeEGN = "11111111111111";
        //    additionalParameters.OrganizationEIK = "12121212121";
        //    additionalParameters.OrganizationUnit = "qqqqqq";
        //    additionalParameters.SignResult = false;
        //    additionalParameters.ReturnAccessMatrix = true;

        //    var result = adapter.GetMRO_BA_Trade_Marks(searchCriteria, accessMatrix, additionalParameters);
        //    string xml = result.XmlSerialize();
        //    using (StreamWriter outfile = new StreamWriter("GetMRO_BA_Trade_Marks_Test.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("IaosMROBatteriesAdapter", "MRO_BA_Trade_Marks_Request", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("IaosMROBatteriesAdapter", "MRO_BA_Trade_Marks_Response", result.Data.Response.XmlSerialize());

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
        //public void GetMRO_BA_Trade_Marks_NULL_Test()
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

        //    AdapterService.IaosMROBatteriesAdapter adapter = new AdapterService.IaosMROBatteriesAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(MRO_BA_Trade_Marks_Response));
        //    MRO_BA_Trade_Marks_Request searchCriteria = new MRO_BA_Trade_Marks_Request() { AuthNum = "alabala" };

        //    AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
        //    additionalParameters.CallContext = new CallContext(); additionalParameters.CitizenEGN = "8888888888";
        //    additionalParameters.ClientIPAddress = "111.111.111.111";
        //    additionalParameters.ConsumerCertificateThumbprint = "###";
        //    additionalParameters.EIDToken = "token123";
        //    additionalParameters.EmployeeEGN = "11111111111111";
        //    additionalParameters.OrganizationEIK = "12121212121";
        //    additionalParameters.OrganizationUnit = "qqqqqq";
        //    additionalParameters.SignResult = false;
        //    additionalParameters.ReturnAccessMatrix = true;

        //    var result = adapter.GetMRO_BA_Trade_Marks(searchCriteria, accessMatrix, additionalParameters);
        //    string xml = result.XmlSerialize();

        //    using (StreamWriter outfile = new StreamWriter("GetMRO_BA_Trade_Marks_NULL_Test.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("IaosMROBatteriesAdapter", "MRO_BA_Trade_Marks_Request", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("IaosMROBatteriesAdapter", "MRO_BA_Trade_Marks_Response", result.Data.Response.XmlSerialize());

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
        //public void GetMRO_BA_Category_Test()
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

        //    AdapterService.IaosMROBatteriesAdapter adapter = new AdapterService.IaosMROBatteriesAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(MRO_BA_Category_Response));
        //    MRO_BA_Category_Request searchCriteria = new MRO_BA_Category_Request() { EIK = "131103818" };

        //    AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
        //    additionalParameters.CallContext = new CallContext();
        //    additionalParameters.CitizenEGN = "8888888888";
        //    additionalParameters.ClientIPAddress = "111.111.111.111";
        //    additionalParameters.ConsumerCertificateThumbprint = "###";
        //    additionalParameters.EIDToken = "token123";
        //    additionalParameters.EmployeeEGN = "11111111111111";
        //    additionalParameters.OrganizationEIK = "12121212121";
        //    additionalParameters.OrganizationUnit = "qqqqqq";
        //    additionalParameters.SignResult = false;
        //    additionalParameters.ReturnAccessMatrix = true;

        //    var result = adapter.GetMRO_BA_Category(searchCriteria, accessMatrix, additionalParameters);
        //    string xml = result.XmlSerialize();
        //    using (StreamWriter outfile = new StreamWriter("GetMRO_BA_Category_Test.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("IaosMROBatteriesAdapter", "MRO_BA_Category_Request", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("IaosMROBatteriesAdapter", "MRO_BA_Category_Response", result.Data.Response.XmlSerialize());

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
        //public void GetMRO_BA_Category_NULL_Test()
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

        //    AdapterService.IaosMROBatteriesAdapter adapter = new AdapterService.IaosMROBatteriesAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(MRO_BA_Category_Response));
        //    MRO_BA_Category_Request searchCriteria = new MRO_BA_Category_Request() { EIK = "1111111111" };

        //    AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
        //    additionalParameters.CallContext = new CallContext();
        //    additionalParameters.CitizenEGN = "8888888888";
        //    additionalParameters.ClientIPAddress = "111.111.111.111";
        //    additionalParameters.ConsumerCertificateThumbprint = "###";
        //    additionalParameters.EIDToken = "token123";
        //    additionalParameters.EmployeeEGN = "11111111111111";
        //    additionalParameters.OrganizationEIK = "12121212121";
        //    additionalParameters.OrganizationUnit = "qqqqqq";
        //    additionalParameters.SignResult = false;
        //    additionalParameters.ReturnAccessMatrix = true;

        //    var result = adapter.GetMRO_BA_Category(searchCriteria, accessMatrix, additionalParameters);
        //    string xml = result.XmlSerialize();

        //    using (StreamWriter outfile = new StreamWriter("GetMRO_BA_Category_Test_NULL.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("IaosMROBatteriesAdapter", "MRO_BA_Category_Request", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("IaosMROBatteriesAdapter", "MRO_BA_Category_Response", result.Data.Response.XmlSerialize());

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
        //public void WebServiceTest()
        //{
        //    AdapterService.IaosMROBatteriesAdapter adapter = new AdapterService.IaosMROBatteriesAdapter();
        //    ConnectionStatusInfo status = adapter.CheckRegisterConnection();
        //    Assert.IsTrue(true);
        //}
    }

}
