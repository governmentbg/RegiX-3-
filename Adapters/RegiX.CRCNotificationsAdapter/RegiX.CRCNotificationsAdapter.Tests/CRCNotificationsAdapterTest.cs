using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechnoLogica.RegiX.Adapters.TestUtils;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.CRCNotificationsAdapter;
using TechnoLogica.RegiX.CRCNotificationsAdapter.AdapterService;

namespace TechnoLogica.CRCNotificationsAdapter.Tests
{
    [TestClass]
    public class CRCNotificationsAdapterTest : AdapterTest<TechnoLogica.RegiX.CRCNotificationsAdapter.AdapterService.CRCNotificationsAdapter, ICRCNotificationsAdapter>
    {
        ////[TestMethod]
        //public void GetCompanyInfoTest()
        //{
        //    TechnoLogica.RegiX.CRCNotificationsAdapter.AdapterService.CRCNotificationsAdapter cRCNotificationsAdapter = new TechnoLogica.RegiX.CRCNotificationsAdapter.AdapterService.CRCNotificationsAdapter();

        //    AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters()
        //    {
        //        OrganizationUnit = "TL",
        //        EIDToken = "",
        //        CallContext = new CallContext() { LawReason = "RegiX.Test", EmployeeIdentifier = "tl_mmarinov", AdministrationName = "TL_Miro" },
        //        SignResult = false,
        //        ReturnAccessMatrix = true,
        //        ApiServiceCallId = 191417,
        //        CallbackURL = "192.168.1.1"
        //    };

        //    GetCompanyInfoRequest request = new GetCompanyInfoRequest
        //    {
        //        CompanyName = "TEST COMPANY",
        //        CompanyType = "ООД",
        //        EIK = "4546789",
        //        WebPageAddress = "company.bg"
        //    };

        //    var result = cRCNotificationsAdapter.GetCompanyInfo(request, AccessMatrix.CreateForType(typeof(GetCompanyInfoResponseType)), additionalParameters);

        //    Assert.IsTrue(true);
        //}

        ////[TestMethod]
        //public void GetNetworksAndServicesInfoTest()
        //{
        //    TechnoLogica.RegiX.CRCNotificationsAdapter.AdapterService.CRCNotificationsAdapter cRCNotificationsAdapter = new TechnoLogica.RegiX.CRCNotificationsAdapter.AdapterService.CRCNotificationsAdapter();

        //    AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters()
        //    {
        //        OrganizationUnit = "TL",
        //        EIDToken = "",
        //        CallContext = new CallContext() { LawReason = "RegiX.Test", EmployeeIdentifier = "tl_mmarinov", AdministrationName = "TL_Miro" },
        //        SignResult = false,
        //        ReturnAccessMatrix = true,
        //        ApiServiceCallId = 191417,
        //        CallbackURL = "192.168.1.1"
        //    };

        //    GetNetworksAndServicesInfoRequest request = new GetNetworksAndServicesInfoRequest
        //    {
        //        Description = "2. Наземни мрежи с ползване на радиочестотен спектър - SAP/SAB включително ENG/OB",
        //        Settlement = "с.",
        //        Name = "Агатово",
        //        Municipality = "Севлиево",
        //        Region = "Габрово",
        //        RightsOriginStartDate = new DateTime(2010, 11, 25),
        //        RightsOriginEndDate = new DateTime(2011, 09, 03)

        //    };

        //    var result = cRCNotificationsAdapter.GetNetworksAndServicesInfo(request, AccessMatrix.CreateForType(typeof(GetNetworksAndServicesInfoResponseType)), additionalParameters);

        //    Assert.IsTrue(true);
        //}
    }
}
