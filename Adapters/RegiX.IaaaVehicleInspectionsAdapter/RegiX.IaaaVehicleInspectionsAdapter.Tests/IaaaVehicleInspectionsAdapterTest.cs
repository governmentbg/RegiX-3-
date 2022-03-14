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
using TechnoLogica.RegiX.IaaaVehicleInspectionsAdapter.AdapterService;

namespace TechnoLogica.RegiX.IaaaVehicleInspectionsAdapter.Tests
{
    [TestClass]
    public class IaaaVehicleInspectionsAdapterTest : AdapterTest<AdapterService.IaaaVehicleInspectionsAdapter, IIaaaVehicleInspectionsAdapter>
    {
        //public IaaaVehicleInspectionsAdapterTest()
        //{
        //    AggregateCatalog catalog = new AggregateCatalog();
        //    catalog.Catalogs.Add(new AssemblyCatalog(typeof(AdapterService.IaaaVehicleInspectionsAdapter).Assembly));
        //    catalog.Catalogs.Add(new AssemblyCatalog(typeof(FileParameterStoreImplementation).Assembly));
        //    catalog.Catalogs.Add(new TypeCatalog(typeof(BinDirectoryLocator)));
        //    CompositionContainer result = new CompositionContainer(catalog, true);
        //    result.ComposeExportedValue(result);
        //    Composition.CompositionContainer = result;
        //}

        //[TestMethod]
        //public void IaaaVehicleInspectionsAdapterTest_CheckHealthCheckAndParamtersTest()
        //{
        //    AdapterService.IaaaVehicleInspectionsAdapter adapter = new AdapterService.IaaaVehicleInspectionsAdapter();
        //    //test GetParameters , and ConnectionString
        //    var connectionString = adapter.GetParameters().ParameterList.Where(p => p.Key == TechnoLogica.RegiX.Common.Constants.WebServiceUrlParameterKeyName).FirstOrDefault();
        //    //test SetParameter
        //    adapter.SetParameter(TechnoLogica.RegiX.Common.Constants.WebServiceUrlParameterKeyName, "http://localhost:8087/IaaaVehicleInspectionsAdapterMockup/IaaaVehicleInspectionsService.svc/");
        //    //http://localhost:8087/IaaaVehicleInspectionsAdapterMockup/IaaaVehicleInspectionsService.svc
        //    //http://regix2-adapters.regix.tlogica.com/MockRegisters/IaaaVehicleInspections/IaaaVehicleInspectionsService.svc/
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
        //public void IaaaVehicleInspectionsAdapterTest_CheckRegisterConnection()
        //{
        //    AdapterService.IaaaVehicleInspectionsAdapter adapter = new AdapterService.IaaaVehicleInspectionsAdapter();
        //    string result = adapter.CheckRegisterConnection();
        //    Assert.IsTrue(result == TechnoLogica.RegiX.Common.Constants.ConnectionOk || result == TechnoLogica.RegiX.Common.Constants.ConnectionStringNotSet);
        //}

        //[TestMethod]
        //public void GetReport1_PermitTest()
        //{
        //    AdapterService.IaaaVehicleInspectionsAdapter adapter = new AdapterService.IaaaVehicleInspectionsAdapter();
        //    //adapter.SetParameter(TechnoLogica.RegiX.Common.Constants.WebServiceUrlParameterKeyName, "https://192.168.168.11:8444/egov-web/api/rir2/reports/"); //"http://regix2-adapters.regix.tlogica.com/MockRegisters/IaaaVehicleInspections/IaaaVehicleInspectionsService.svc/");
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(PermitResponse));
        //    PermitRequestType searchCriteria = new PermitRequestType { IdentNumber = "130132589" };

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

        //    XsltUtils.RunXsltAndWriteHtml("IaaaVehicleInspectionsAdapter", "Report1_permitRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("IaaaVehicleInspectionsAdapter", "Report1_permitResponse", result.Data.Response.XmlSerialize());

        //    Assert.IsTrue(true);
        //}

        //[TestMethod]
        //public void GetReport1_PermitNullTest()
        //{
        //    AdapterService.IaaaVehicleInspectionsAdapter adapter = new AdapterService.IaaaVehicleInspectionsAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(PermitResponse));
        //    PermitRequestType searchCriteria = new PermitRequestType { IdentNumber = "" };

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

        //    using (StreamWriter outfile = new StreamWriter("GetReport1_PermitNullTest.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("IaaaVehicleInspectionsAdapter", "Report1_permitRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("IaaaVehicleInspectionsAdapter", "Report1_permitResponse", result.Data.Response.XmlSerialize());

        //    Assert.IsTrue(true);
        //}

        //[TestMethod]
        //public void GetReport2_PermitInspectorsTest()
        //{
        //    AdapterService.IaaaVehicleInspectionsAdapter adapter = new AdapterService.IaaaVehicleInspectionsAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(PermitInspectorsResponse));
        //    PermitInspectorsRequestType searchCriteria = new PermitInspectorsRequestType { IdentNumber = "5104257561" };

        //    AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
        //    additionalParameters.CallContext = new CallContext() { Remark = "RegiXTest" };// "\"LawReason\":\"�������� �� RegiX\",\"ServiceURI\":\"123456789\",\�ServiceType\�:\��� ������������ �������\�\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"������������ �� ����������� � �������\",\� UserAdministrationID\�:\�10.20.503.4\�,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";
        //    additionalParameters.CitizenEGN = "8888888888";
        //    additionalParameters.ClientIPAddress = "111.111.111.111";
        //    additionalParameters.ConsumerCertificateThumbprint = "###";
        //    additionalParameters.EIDToken = "token123";
        //    additionalParameters.EmployeeEGN = "11111111111111";
        //    additionalParameters.OrganizationEIK = "12121212121";
        //    additionalParameters.OrganizationUnit = "qqqqqq";

        //    var result = adapter.GetReport2PermitInspectors(searchCriteria, accessMatrix, additionalParameters);
        //    using (StreamWriter outfile = new StreamWriter("GetReport2_PermitInspectorsTest.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("IaaaVehicleInspectionsAdapter", "Report2_permitInspectorsRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("IaaaVehicleInspectionsAdapter", "Report2_permitInspectorsResponse", result.Data.Response.XmlSerialize());

        //    Assert.IsTrue(true);
        //}

        //[TestMethod]
        //public void GetReport2_PermitInspectorsNullTest()
        //{
        //    AdapterService.IaaaVehicleInspectionsAdapter adapter = new AdapterService.IaaaVehicleInspectionsAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(PermitInspectorsResponse));
        //    PermitInspectorsRequestType searchCriteria = new PermitInspectorsRequestType { IdentNumber = "0" };

        //    AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
        //    additionalParameters.CallContext = new CallContext() { Remark = "RegiXTest" };// "\"LawReason\":\"�������� �� RegiX\",\"ServiceURI\":\"123456789\",\�ServiceType\�:\��� ������������ �������\�\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"������������ �� ����������� � �������\",\� UserAdministrationID\�:\�10.20.503.4\�,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";
        //    additionalParameters.CitizenEGN = "8888888888";
        //    additionalParameters.ClientIPAddress = "111.111.111.111";
        //    additionalParameters.ConsumerCertificateThumbprint = "###";
        //    additionalParameters.EIDToken = "token123";
        //    additionalParameters.EmployeeEGN = "11111111111111";
        //    additionalParameters.OrganizationEIK = "12121212121";
        //    additionalParameters.OrganizationUnit = "qqqqqq";

        //    var result = adapter.GetReport2PermitInspectors(searchCriteria, accessMatrix, additionalParameters);
        //    using (StreamWriter outfile = new StreamWriter("GetReport2_PermitInspectorsNullTest.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("IaaaVehicleInspectionsAdapter", "Report2_permitInspectorsRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("IaaaVehicleInspectionsAdapter", "Report2_permitInspectorsResponse", result.Data.Response.XmlSerialize());

        //    Assert.IsTrue(true);
        //}

        //[TestMethod]
        //public void GetReport3_PermitsInspectionCountTest()
        //{
        //    AdapterService.IaaaVehicleInspectionsAdapter adapter = new AdapterService.IaaaVehicleInspectionsAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(PermitsInspectionCountResponse));


        //    PermitsInspectionCountRequestType searchCriteria = new PermitsInspectionCountRequestType { IdentNumber = "130132589", DateFrom = new DateTime(2015, 01, 01), DateTo = new DateTime(2015, 02, 01), DateFromSpecified = true, DateToSpecified = true };

        //    AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
        //    additionalParameters.CallContext = new CallContext() { Remark = "RegiXTest" };// "\"LawReason\":\"�������� �� RegiX\",\"ServiceURI\":\"123456789\",\�ServiceType\�:\��� ������������ �������\�\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"������������ �� ����������� � �������\",\� UserAdministrationID\�:\�10.20.503.4\�,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";
        //    additionalParameters.CitizenEGN = "8888888888";
        //    additionalParameters.ClientIPAddress = "111.111.111.111";
        //    additionalParameters.ConsumerCertificateThumbprint = "###";
        //    additionalParameters.EIDToken = "token123";
        //    additionalParameters.EmployeeEGN = "11111111111111";
        //    additionalParameters.OrganizationEIK = "12121212121";
        //    additionalParameters.OrganizationUnit = "qqqqqq";

        //    var result = adapter.GetReport3PermitsInspectionCount(searchCriteria, accessMatrix, additionalParameters);
        //    using (StreamWriter outfile = new StreamWriter("GetReport3_PermitsInspectionCountTest.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("IaaaVehicleInspectionsAdapter", "Report3_permitsInspectionCountRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("IaaaVehicleInspectionsAdapter", "Report3_permitsInspectionCountResponse", result.Data.Response.XmlSerialize());

        //    Assert.IsTrue(true);
        //}

        //[TestMethod]
        //public void GetReport3_PermitsInspectionCountNullTest()
        //{
        //    AdapterService.IaaaVehicleInspectionsAdapter adapter = new AdapterService.IaaaVehicleInspectionsAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(PermitsInspectionCountResponse));
        //    PermitsInspectionCountRequestType searchCriteria = new PermitsInspectionCountRequestType { IdentNumber = "0", DateFrom = new DateTime(2015, 01, 01), DateTo = new DateTime(2015, 02, 01), DateFromSpecified = true, DateToSpecified = true };

        //    AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
        //    additionalParameters.CallContext = new CallContext() { Remark = "RegiXTest" };// "\"LawReason\":\"�������� �� RegiX\",\"ServiceURI\":\"123456789\",\�ServiceType\�:\��� ������������ �������\�\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"������������ �� ����������� � �������\",\� UserAdministrationID\�:\�10.20.503.4\�,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";
        //    additionalParameters.CitizenEGN = "8888888888";
        //    additionalParameters.ClientIPAddress = "111.111.111.111";
        //    additionalParameters.ConsumerCertificateThumbprint = "###";
        //    additionalParameters.EIDToken = "token123";
        //    additionalParameters.EmployeeEGN = "11111111111111";
        //    additionalParameters.OrganizationEIK = "12121212121";
        //    additionalParameters.OrganizationUnit = "qqqqqq";

        //    var result = adapter.GetReport3PermitsInspectionCount(searchCriteria, accessMatrix, additionalParameters);
        //    using (StreamWriter outfile = new StreamWriter("GetReport3_PermitsInspectionCountNullTest.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("IaaaVehicleInspectionsAdapter", "Report3_permitsInspectionCountRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("IaaaVehicleInspectionsAdapter", "Report3_permitsInspectionCountResponse", result.Data.Response.XmlSerialize());

        //    Assert.IsTrue(true);
        //}

        //[TestMethod]
        //public void GetReport4_VehicleInspectionTest()
        //{
        //    AdapterService.IaaaVehicleInspectionsAdapter adapter = new AdapterService.IaaaVehicleInspectionsAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(VehicleInspectionResponse));
        //    VehicleInspectionRequestType searchCriteria = new VehicleInspectionRequestType { RegNumber = "CA2598MH" };

        //    AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
        //    additionalParameters.CallContext = new CallContext() { Remark = "RegiXTest" };// "\"LawReason\":\"�������� �� RegiX\",\"ServiceURI\":\"123456789\",\�ServiceType\�:\��� ������������ �������\�\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"������������ �� ����������� � �������\",\� UserAdministrationID\�:\�10.20.503.4\�,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";
        //    additionalParameters.CitizenEGN = "8888888888";
        //    additionalParameters.ClientIPAddress = "111.111.111.111";
        //    additionalParameters.ConsumerCertificateThumbprint = "###";
        //    additionalParameters.EIDToken = "token123";
        //    additionalParameters.EmployeeEGN = "11111111111111";
        //    additionalParameters.OrganizationEIK = "12121212121";
        //    additionalParameters.OrganizationUnit = "qqqqqq";

        //    var result = adapter.GetReport4VehicleInspection(searchCriteria, accessMatrix, additionalParameters);
        //    using (StreamWriter outfile = new StreamWriter("GetReport4_VehicleInspectionTest.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("IaaaVehicleInspectionsAdapter", "Report4_vehicleInspectionRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("IaaaVehicleInspectionsAdapter", "Report4_vehicleInspectionResponse", result.Data.Response.XmlSerialize());

        //    Assert.IsTrue(true);
        //}

        //[TestMethod]
        //public void GetReport4_VehicleInspectionNullTest()
        //{
        //    AdapterService.IaaaVehicleInspectionsAdapter adapter = new AdapterService.IaaaVehicleInspectionsAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(VehicleInspectionResponse));
        //    VehicleInspectionRequestType searchCriteria = new VehicleInspectionRequestType { RegNumber = "0" };

        //    AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
        //    additionalParameters.CallContext = new CallContext() { Remark = "RegiXTest" };// "\"LawReason\":\"�������� �� RegiX\",\"ServiceURI\":\"123456789\",\�ServiceType\�:\��� ������������ �������\�\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"������������ �� ����������� � �������\",\� UserAdministrationID\�:\�10.20.503.4\�,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";
        //    additionalParameters.CitizenEGN = "8888888888";
        //    additionalParameters.ClientIPAddress = "111.111.111.111";
        //    additionalParameters.ConsumerCertificateThumbprint = "###";
        //    additionalParameters.EIDToken = "token123";
        //    additionalParameters.EmployeeEGN = "11111111111111";
        //    additionalParameters.OrganizationEIK = "12121212121";
        //    additionalParameters.OrganizationUnit = "qqqqqq";

        //    var result = adapter.GetReport4VehicleInspection(searchCriteria, accessMatrix, additionalParameters);
        //    using (StreamWriter outfile = new StreamWriter("GetReport4_VehicleInspectionNullTest.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("IaaaVehicleInspectionsAdapter", "Report4_vehicleInspectionRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("IaaaVehicleInspectionsAdapter", "Report4_vehicleInspectionResponse", result.Data.Response.XmlSerialize());

        //    Assert.IsTrue(true);
        //}

        //[TestMethod]
        //public void GetReport5_VehicleInspectionStickerTest()
        //{
        //    AdapterService.IaaaVehicleInspectionsAdapter adapter = new AdapterService.IaaaVehicleInspectionsAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(VehicleInspectionResponse));
        //    VehicleInspectionStickerRequestType searchCriteria = new VehicleInspectionStickerRequestType { RegNumber = "CA2598MH", StickerNumber = 7038153, StickerNumberSpecified = true };

        //    AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
        //    additionalParameters.CallContext = new CallContext() { Remark = "RegiXTest" };// "\"LawReason\":\"�������� �� RegiX\",\"ServiceURI\":\"123456789\",\�ServiceType\�:\��� ������������ �������\�\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"������������ �� ����������� � �������\",\� UserAdministrationID\�:\�10.20.503.4\�,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";
        //    additionalParameters.CitizenEGN = "8888888888";
        //    additionalParameters.ClientIPAddress = "111.111.111.111";
        //    additionalParameters.ConsumerCertificateThumbprint = "###";
        //    additionalParameters.EIDToken = "token123";
        //    additionalParameters.EmployeeEGN = "11111111111111";
        //    additionalParameters.OrganizationEIK = "12121212121";
        //    additionalParameters.OrganizationUnit = "qqqqqq";

        //    var result = adapter.GetReport5VehicleInspectionSticker(searchCriteria, accessMatrix, additionalParameters);
        //    using (StreamWriter outfile = new StreamWriter("GetReport5_VehicleInspectionStickerTest.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("IaaaVehicleInspectionsAdapter", "Report5_vehicleInspectionStickerRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("IaaaVehicleInspectionsAdapter", "Report4_vehicleInspectionResponse", result.Data.Response.XmlSerialize());

        //    Assert.IsTrue(true);
        //}

        //[TestMethod]
        //public void GetReport5_VehicleInspectionStickerNullTest()
        //{
        //    AdapterService.IaaaVehicleInspectionsAdapter adapter = new AdapterService.IaaaVehicleInspectionsAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(VehicleInspectionResponse));
        //    VehicleInspectionStickerRequestType searchCriteria = new VehicleInspectionStickerRequestType { RegNumber = "0", StickerNumber = 0 };

        //    AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
        //    additionalParameters.CallContext = new CallContext() { Remark = "RegiXTest" };// "\"LawReason\":\"�������� �� RegiX\",\"ServiceURI\":\"123456789\",\�ServiceType\�:\��� ������������ �������\�\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"������������ �� ����������� � �������\",\� UserAdministrationID\�:\�10.20.503.4\�,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";
        //    additionalParameters.CitizenEGN = "8888888888";
        //    additionalParameters.ClientIPAddress = "111.111.111.111";
        //    additionalParameters.ConsumerCertificateThumbprint = "###";
        //    additionalParameters.EIDToken = "token123";
        //    additionalParameters.EmployeeEGN = "11111111111111";
        //    additionalParameters.OrganizationEIK = "12121212121";
        //    additionalParameters.OrganizationUnit = "qqqqqq";

        //    var result = adapter.GetReport5VehicleInspectionSticker(searchCriteria, accessMatrix, additionalParameters);
        //    using (StreamWriter outfile = new StreamWriter("GetReport5_VehicleInspectionStickerNullTest.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }
        //    Assert.IsTrue(true);
        //}
    }
}
