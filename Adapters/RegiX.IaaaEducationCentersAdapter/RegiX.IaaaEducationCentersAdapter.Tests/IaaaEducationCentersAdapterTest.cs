using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegiX.Adapters.FileParameterStore;
using TechnoLogica.RegiX.Adapters.TestUtils;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.Common.Utils;
using TechnoLogica.RegiX.IaaaEducationCentersAdapter.AdapterService;

namespace TechnoLogica.RegiX.IaaaEducationCentersAdapter.Tests
{



    [TestClass]
    public class IaaaEducationCentersAdapterTest : AdapterTest<AdapterService.IaaaEducationCentersAdapter, IIaaaEducationCentersAdapter>
    {
        //public IaaaEducationCentersAdapterTest()
        //{
        //    AggregateCatalog catalog = new AggregateCatalog();
        //    catalog.Catalogs.Add(new AssemblyCatalog(typeof(AdapterService.IaaaEducationCentersAdapter).Assembly));
        //    catalog.Catalogs.Add(new AssemblyCatalog(typeof(FileParameterStoreImplementation).Assembly));
        //    catalog.Catalogs.Add(new TypeCatalog(typeof(BinDirectoryLocator)));
        //    CompositionContainer result = new CompositionContainer(catalog, true);
        //    result.ComposeExportedValue(result);
        //    Composition.CompositionContainer = result;
        //}

        //[TestMethod]
        //public void IaaaEducationCentersAdapterTest_CheckHealthCheckAndParamtersTest()
        //{
        //    AdapterService.IaaaEducationCentersAdapter adapter = new AdapterService.IaaaEducationCentersAdapter();
        //    //test GetParameters , and ConnectionString
        //    var connectionString = adapter.GetParameters().ParameterList.Where(p => p.Key == Common.Constants.WebServiceUrlParameterKeyName).FirstOrDefault();
        //    //test SetParameter
        //    //adapter.SetParameter(TechnoLogica.RegiX.Common.Constants.WebServiceUrlParameterKeyName, "http://regix2-adapters.regix.tlogica.com/MockRegisters/IaaaEducationCenters/IaaaEducationCentersService.svc/");
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
        //public void IaaaEducationCentersAdapterTest_CheckRegisterConnection()
        //{
        //    AdapterService.IaaaEducationCentersAdapter adapter = new AdapterService.IaaaEducationCentersAdapter();
        //    string result = adapter.CheckRegisterConnection();
        //    Assert.IsTrue(result == TechnoLogica.RegiX.Common.Constants.ConnectionOk || result == TechnoLogica.RegiX.Common.Constants.ConnectionStringNotSet);
        //}

        //[TestMethod]
        //public void GetReport1_PermitTest()
        //{
        //    AdapterService.IaaaEducationCentersAdapter adapter = new AdapterService.IaaaEducationCentersAdapter();

        //    adapter.SetParameter(Constants.WebServiceUrlParameterKeyName, " http://regix2-adapters.regix.tlogica.com/MockRegisters/IaaaEducationCenters/IaaaEducationCentersService.svc/");

        //    var accessMatrix = AccessMatrix.CreateForType(typeof(PermitResponse));
        //    PermitsRequestType searchCriteria = new PermitsRequestType { IdentNumber = "202571811" };

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

        //    var result = adapter.GetReport1Permit(searchCriteria, accessMatrix, additionalParameters);

        //    using (StreamWriter outfile = new StreamWriter("GetReport1_PermitTest.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("IaaaEducationCentersAdapter", "Report1_permitsRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("IaaaEducationCentersAdapter", "Report1_permitResponse", result.Data.Response.XmlSerialize());

        //    Assert.IsTrue(true);
        //}

        //[TestMethod]
        //public void GetReport1_PermitNullTest()
        //{
        //    AdapterService.IaaaEducationCentersAdapter adapter = new AdapterService.IaaaEducationCentersAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(PermitResponse));
        //    PermitsRequestType searchCriteria = new PermitsRequestType { IdentNumber = "0" };

        //    AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
        //    additionalParameters.CallContext = new CallContext() { Remark = "RegiXTest" };// "\"LawReason\":\"�������� �� RegiX\",\"ServiceURI\":\"123456789\",\�ServiceType\�:\��� ������������ �������\�\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"������������ �� ����������� � �������\",\� UserAdministrationID\�:\�10.20.503.4\�,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";
        //    additionalParameters.CitizenEGN = "8888888888";
        //    additionalParameters.ClientIPAddress = "111.111.111.111";
        //    additionalParameters.ConsumerCertificateThumbprint = "###";
        //    additionalParameters.EIDToken = "token123";
        //    additionalParameters.EmployeeEGN = "11111111111111";
        //    additionalParameters.OrganizationEIK = "12121212121";
        //    additionalParameters.OrganizationUnit = "qqqqqq";

        //    var result = adapter.GetReport1Permit(searchCriteria, accessMatrix, additionalParameters);
        //    using (StreamWriter outfile = new StreamWriter("GetReport1_PermitNullTest.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("IaaaEducationCentersAdapter", "Report1_permitsRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("IaaaEducationCentersAdapter", "Report1_permitResponse", result.Data.Response.XmlSerialize());

        //    Assert.IsTrue(true);
        //}

        //[TestMethod]
        //public void GetReport2_PermitInstructorsTest()
        //{
        //    AdapterService.IaaaEducationCentersAdapter adapter = new AdapterService.IaaaEducationCentersAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(PermitInstructorsResponse));
        //    PermitsRequestType searchCriteria = new PermitsRequestType { IdentNumber = "202571811" };

        //    AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
        //    additionalParameters.CallContext = new CallContext() { Remark = "RegiXTest" };// "\"LawReason\":\"�������� �� RegiX\",\"ServiceURI\":\"123456789\",\�ServiceType\�:\��� ������������ �������\�\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"������������ �� ����������� � �������\",\� UserAdministrationID\�:\�10.20.503.4\�,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";
        //    additionalParameters.CitizenEGN = "8888888888";
        //    additionalParameters.ClientIPAddress = "111.111.111.111";
        //    additionalParameters.ConsumerCertificateThumbprint = "###";
        //    additionalParameters.EIDToken = "token123";
        //    additionalParameters.EmployeeEGN = "11111111111111";
        //    additionalParameters.OrganizationEIK = "12121212121";
        //    additionalParameters.OrganizationUnit = "qqqqqq";

        //    var result = adapter.GetReport2PermitInstructors(searchCriteria, accessMatrix, additionalParameters);
        //    using (StreamWriter outfile = new StreamWriter("GetReport2_PermitInstructorsTest.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("IaaaEducationCentersAdapter", "Report1_permitsRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("IaaaEducationCentersAdapter", "Report2_permitResponseInstructors", result.Data.Response.XmlSerialize());

        //    Assert.IsTrue(true);
        //}

        //[TestMethod]
        //public void GetReport2_PermitInstructorsNullTest()
        //{
        //    AdapterService.IaaaEducationCentersAdapter adapter = new AdapterService.IaaaEducationCentersAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(PermitInstructorsResponse));
        //    PermitsRequestType searchCriteria = new PermitsRequestType { IdentNumber = "0" };

        //    AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
        //    additionalParameters.CallContext = new CallContext() { Remark = "RegiXTest" };// "\"LawReason\":\"�������� �� RegiX\",\"ServiceURI\":\"123456789\",\�ServiceType\�:\��� ������������ �������\�\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"������������ �� ����������� � �������\",\� UserAdministrationID\�:\�10.20.503.4\�,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";
        //    additionalParameters.CitizenEGN = "8888888888";
        //    additionalParameters.ClientIPAddress = "111.111.111.111";
        //    additionalParameters.ConsumerCertificateThumbprint = "###";
        //    additionalParameters.EIDToken = "token123";
        //    additionalParameters.EmployeeEGN = "11111111111111";
        //    additionalParameters.OrganizationEIK = "12121212121";
        //    additionalParameters.OrganizationUnit = "qqqqqq";

        //    var result = adapter.GetReport2PermitInstructors(searchCriteria, accessMatrix, additionalParameters);
        //    using (StreamWriter outfile = new StreamWriter("GetReport2_PermitInstructorsNullTest.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("IaaaEducationCentersAdapter", "Report1_permitsRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("IaaaEducationCentersAdapter", "Report2_permitResponseInstructors", result.Data.Response.XmlSerialize());

        //    Assert.IsTrue(true);
        //}

        //[TestMethod]
        //public void GetReport3_PermitVehiclesTest()
        //{
        //    AdapterService.IaaaEducationCentersAdapter adapter = new AdapterService.IaaaEducationCentersAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(PermitVehiclesResponse));
        //    PermitsRequestType searchCriteria = new PermitsRequestType { IdentNumber = "202571811" };

        //    AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
        //    additionalParameters.CallContext = new CallContext() { Remark = "RegiXTest" };// "\"LawReason\":\"�������� �� RegiX\",\"ServiceURI\":\"123456789\",\�ServiceType\�:\��� ������������ �������\�\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"������������ �� ����������� � �������\",\� UserAdministrationID\�:\�10.20.503.4\�,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";
        //    additionalParameters.CitizenEGN = "8888888888";
        //    additionalParameters.ClientIPAddress = "111.111.111.111";
        //    additionalParameters.ConsumerCertificateThumbprint = "###";
        //    additionalParameters.EIDToken = "token123";
        //    additionalParameters.EmployeeEGN = "11111111111111";
        //    additionalParameters.OrganizationEIK = "12121212121";
        //    additionalParameters.OrganizationUnit = "qqqqqq";

        //    var result = adapter.GetReport3PermitVehicles(searchCriteria, accessMatrix, additionalParameters);
        //    using (StreamWriter outfile = new StreamWriter("GetReport3_PermitVehicles.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("IaaaEducationCentersAdapter", "Report1_permitsRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("IaaaEducationCentersAdapter", "Report3_permitResponseVehicles", result.Data.Response.XmlSerialize());

        //    Assert.IsTrue(true);
        //}

        //[TestMethod]
        //public void GetReport3_PermitVehiclesNullTest()
        //{
        //    AdapterService.IaaaEducationCentersAdapter adapter = new AdapterService.IaaaEducationCentersAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(PermitVehiclesResponse));
        //    PermitsRequestType searchCriteria = new PermitsRequestType { IdentNumber = "0" };

        //    AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
        //    additionalParameters.CallContext = new CallContext() { Remark = "RegiXTest" };// "\"LawReason\":\"�������� �� RegiX\",\"ServiceURI\":\"123456789\",\�ServiceType\�:\��� ������������ �������\�\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"������������ �� ����������� � �������\",\� UserAdministrationID\�:\�10.20.503.4\�,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";
        //    additionalParameters.CitizenEGN = "8888888888";
        //    additionalParameters.ClientIPAddress = "111.111.111.111";
        //    additionalParameters.ConsumerCertificateThumbprint = "###";
        //    additionalParameters.EIDToken = "token123";
        //    additionalParameters.EmployeeEGN = "11111111111111";
        //    additionalParameters.OrganizationEIK = "12121212121";
        //    additionalParameters.OrganizationUnit = "qqqqqq";

        //    var result = adapter.GetReport3PermitVehicles(searchCriteria, accessMatrix, additionalParameters);
        //    using (StreamWriter outfile = new StreamWriter("GetReport3_PermitVehiclesNullTest.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("IaaaEducationCentersAdapter", "Report1_permitsRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("IaaaEducationCentersAdapter", "Report3_permitResponseVehicles", result.Data.Response.XmlSerialize());

        //    Assert.IsTrue(true);
        //}

        //[TestMethod]
        //public void GetReport4_InstructorPermitsReportTest()
        //{
        //    AdapterService.IaaaEducationCentersAdapter adapter = new AdapterService.IaaaEducationCentersAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(PermitsInstructorsResponse));
        //    PermitsInstructorsRequestType searchCriteria = new PermitsInstructorsRequestType { SubjectIdentNumber = "6005100169" };

        //    AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
        //    additionalParameters.CallContext = new CallContext() { Remark = "RegiXTest" };// "\"LawReason\":\"�������� �� RegiX\",\"ServiceURI\":\"123456789\",\�ServiceType\�:\��� ������������ �������\�\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"������������ �� ����������� � �������\",\� UserAdministrationID\�:\�10.20.503.4\�,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";
        //    additionalParameters.CitizenEGN = "8888888888";
        //    additionalParameters.ClientIPAddress = "111.111.111.111";
        //    additionalParameters.ConsumerCertificateThumbprint = "###";
        //    additionalParameters.EIDToken = "token123";
        //    additionalParameters.EmployeeEGN = "11111111111111";
        //    additionalParameters.OrganizationEIK = "12121212121";
        //    additionalParameters.OrganizationUnit = "qqqqqq";

        //    var result = adapter.GetReport4InstructorPermitsDetails(searchCriteria, accessMatrix, additionalParameters);
        //    using (StreamWriter outfile = new StreamWriter("GetReport4_InstructorPermitsReportTest.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("IaaaEducationCentersAdapter", "Report4_instructorPermitsDetailsRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("IaaaEducationCentersAdapter", "Report4_instructorPermitsDetailsResponse", result.Data.Response.XmlSerialize());

        //    Assert.IsTrue(true);
        //}

        //[TestMethod]
        //public void GetReport4_InstructorPermitsReportNullTest()
        //{
        //    AdapterService.IaaaEducationCentersAdapter adapter = new AdapterService.IaaaEducationCentersAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(PermitsInstructorsResponse));
        //    PermitsInstructorsRequestType searchCriteria = new PermitsInstructorsRequestType { SubjectIdentNumber = "0" };

        //    AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
        //    additionalParameters.CallContext = new CallContext() { Remark = "RegiXTest" };// "\"LawReason\":\"�������� �� RegiX\",\"ServiceURI\":\"123456789\",\�ServiceType\�:\��� ������������ �������\�\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"������������ �� ����������� � �������\",\� UserAdministrationID\�:\�10.20.503.4\�,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";
        //    additionalParameters.CitizenEGN = "8888888888";
        //    additionalParameters.ClientIPAddress = "111.111.111.111";
        //    additionalParameters.ConsumerCertificateThumbprint = "###";
        //    additionalParameters.EIDToken = "token123";
        //    additionalParameters.EmployeeEGN = "11111111111111";
        //    additionalParameters.OrganizationEIK = "12121212121";
        //    additionalParameters.OrganizationUnit = "qqqqqq";

        //    var result = adapter.GetReport4InstructorPermitsDetails(searchCriteria, accessMatrix, additionalParameters);
        //    using (StreamWriter outfile = new StreamWriter("GetReport4_InstructorPermitsReportNullTest.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("IaaaEducationCentersAdapter", "Report4_instructorPermitsDetailsRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("IaaaEducationCentersAdapter", "Report4_instructorPermitsDetailsResponse", result.Data.Response.XmlSerialize());

        //    Assert.IsTrue(true);
        //}

        //[TestMethod]
        //public void GetReport5_PermitsExamPeopleCountTest()
        //{
        //    AdapterService.IaaaEducationCentersAdapter adapter = new AdapterService.IaaaEducationCentersAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(PermitsExamPeopleCountResponse));
        //    PermitsExamPeopleCountRequestType searchCriteria = new PermitsExamPeopleCountRequestType { IdentNumber = "202571811", DateFrom = new DateTime(2012, 01, 01), DateTo = new DateTime(2016, 01, 01), DateFromSpecified = true, DateToSpecified = true };

        //    AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
        //    additionalParameters.CallContext = new CallContext() { Remark = "RegiXTest" };// "\"LawReason\":\"�������� �� RegiX\",\"ServiceURI\":\"123456789\",\�ServiceType\�:\��� ������������ �������\�\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"������������ �� ����������� � �������\",\� UserAdministrationID\�:\�10.20.503.4\�,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";
        //    additionalParameters.CitizenEGN = "8888888888";
        //    additionalParameters.ClientIPAddress = "111.111.111.111";
        //    additionalParameters.ConsumerCertificateThumbprint = "###";
        //    additionalParameters.EIDToken = "token123";
        //    additionalParameters.EmployeeEGN = "11111111111111";
        //    additionalParameters.OrganizationEIK = "12121212121";
        //    additionalParameters.OrganizationUnit = "qqqqqq";

        //    var result = adapter.GetReport5PermitsExamPeopleCount(searchCriteria, accessMatrix, additionalParameters);
        //    using (StreamWriter outfile = new StreamWriter("GetReport5_PermitsExamPeopleCountTest.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("IaaaEducationCentersAdapter", "Report5_permitsExamPeopleCountRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("IaaaEducationCentersAdapter", "Report5_permitsExamPeopleCountResponse", result.Data.Response.XmlSerialize());

        //    Assert.IsTrue(true);
        //}

        //[TestMethod]
        //public void GetReport5_PermitsExamPeopleCountNullTest()
        //{
        //    AdapterService.IaaaEducationCentersAdapter adapter = new AdapterService.IaaaEducationCentersAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(PermitsExamPeopleCountResponse));
        //    PermitsExamPeopleCountRequestType searchCriteria = new PermitsExamPeopleCountRequestType { IdentNumber = "0", DateFrom = new DateTime(0001, 01, 01), DateTo = new DateTime(0001, 01, 01), DateFromSpecified = true, DateToSpecified = true };

        //    AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
        //    additionalParameters.CallContext = new CallContext() { Remark = "RegiXTest" };// "\"LawReason\":\"�������� �� RegiX\",\"ServiceURI\":\"123456789\",\�ServiceType\�:\��� ������������ �������\�\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"������������ �� ����������� � �������\",\� UserAdministrationID\�:\�10.20.503.4\�,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";
        //    additionalParameters.CitizenEGN = "8888888888";
        //    additionalParameters.ClientIPAddress = "111.111.111.111";
        //    additionalParameters.ConsumerCertificateThumbprint = "###";
        //    additionalParameters.EIDToken = "token123";
        //    additionalParameters.EmployeeEGN = "11111111111111";
        //    additionalParameters.OrganizationEIK = "12121212121";
        //    additionalParameters.OrganizationUnit = "qqqqqq";

        //    var result = adapter.GetReport5PermitsExamPeopleCount(searchCriteria, accessMatrix, additionalParameters);
        //    using (StreamWriter outfile = new StreamWriter("GetReport5_PermitsExamPeopleCountNullTest.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("IaaaEducationCentersAdapter", "Report5_permitsExamPeopleCountRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("IaaaEducationCentersAdapter", "Report5_permitsExamPeopleCountResponse", result.Data.Response.XmlSerialize());

        //    Assert.IsTrue(true);
        //}

        //[TestMethod]
        //public void GetReport6_SubjectOwnedCategoriesTest()
        //{
        //    AdapterService.IaaaEducationCentersAdapter adapter = new AdapterService.IaaaEducationCentersAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(SubjectOwnedCategoriesResponse));
        //    SubjectOwnedCategoriesRequestType searchCriteria = new SubjectOwnedCategoriesRequestType { SubjectIdentNumber = "8912160548" };

        //    AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
        //    additionalParameters.CallContext = new CallContext() { Remark = "RegiXTest" };// "\"LawReason\":\"�������� �� RegiX\",\"ServiceURI\":\"123456789\",\�ServiceType\�:\��� ������������ �������\�\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"������������ �� ����������� � �������\",\� UserAdministrationID\�:\�10.20.503.4\�,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";
        //    additionalParameters.CitizenEGN = "8888888888";
        //    additionalParameters.ClientIPAddress = "111.111.111.111";
        //    additionalParameters.ConsumerCertificateThumbprint = "###";
        //    additionalParameters.EIDToken = "token123";
        //    additionalParameters.EmployeeEGN = "11111111111111";
        //    additionalParameters.OrganizationEIK = "12121212121";
        //    additionalParameters.OrganizationUnit = "qqqqqq";

        //    var result = adapter.GetReport6SubjectOwnedCategories(searchCriteria, accessMatrix, additionalParameters);
        //    using (StreamWriter outfile = new StreamWriter("GetReport6_SubjectOwnedCategoriesTest.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("IaaaEducationCentersAdapter", "Report6_subjectOwnedCategoriesRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("IaaaEducationCentersAdapter", "Report6_subjectOwnedCategoriesResponse", result.Data.Response.XmlSerialize());

        //    Assert.IsTrue(true);
        //}

        //[TestMethod]
        //public void GetReport6_SubjectOwnedCategoriesNullTest()
        //{
        //    AdapterService.IaaaEducationCentersAdapter adapter = new AdapterService.IaaaEducationCentersAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(SubjectOwnedCategoriesResponse));
        //    SubjectOwnedCategoriesRequestType searchCriteria = new SubjectOwnedCategoriesRequestType { SubjectIdentNumber = "0" };

        //    AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
        //    additionalParameters.CallContext = new CallContext() { Remark = "RegiXTest" };// "\"LawReason\":\"�������� �� RegiX\",\"ServiceURI\":\"123456789\",\�ServiceType\�:\��� ������������ �������\�\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"������������ �� ����������� � �������\",\� UserAdministrationID\�:\�10.20.503.4\�,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";
        //    additionalParameters.CitizenEGN = "8888888888";
        //    additionalParameters.ClientIPAddress = "111.111.111.111";
        //    additionalParameters.ConsumerCertificateThumbprint = "###";
        //    additionalParameters.EIDToken = "token123";
        //    additionalParameters.EmployeeEGN = "11111111111111";
        //    additionalParameters.OrganizationEIK = "12121212121";
        //    additionalParameters.OrganizationUnit = "qqqqqq";

        //    var result = adapter.GetReport6SubjectOwnedCategories(searchCriteria, accessMatrix, additionalParameters);
        //    using (StreamWriter outfile = new StreamWriter("GetReport6_SubjectOwnedCategoriesNullTest.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("IaaaEducationCentersAdapter", "Report6_subjectOwnedCategoriesRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("IaaaEducationCentersAdapter", "Report6_subjectOwnedCategoriesResponse", result.Data.Response.XmlSerialize());

        //    Assert.IsTrue(true);
        //}
    }
}
