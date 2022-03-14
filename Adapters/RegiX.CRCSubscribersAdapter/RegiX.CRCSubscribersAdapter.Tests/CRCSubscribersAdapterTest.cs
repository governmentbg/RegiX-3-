using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechnoLogica.RegiX.Adapters.TestUtils;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.CRCSubscribersAdapter;
using TechnoLogica.RegiX.CRCSubscribersAdapter.AdapterService;

namespace TechnoLogica.RegiX.CRCSubscribersAdapter.Tests
{
    [TestClass]
    public class CRCSubscribersAdapterTest : AdapterTest<TechnoLogica.RegiX.CRCSubscribersAdapter.AdapterService.CRCSubscribersAdapter, ICRCSubscribersAdapter>
    {
        //[TestMethod]
        public void GetCompanyInfoTest()
        {
            TechnoLogica.RegiX.CRCSubscribersAdapter.AdapterService.CRCSubscribersAdapter cRCSubscribersAdapter = new TechnoLogica.RegiX.CRCSubscribersAdapter.AdapterService.CRCSubscribersAdapter();

            AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters()
            {
                OrganizationUnit = "TL",
                EIDToken = "",
                CallContext = new CallContext() { LawReason = "RegiX.Test", EmployeeIdentifier = "tl_mmarinov", AdministrationName = "TL_Miro" },
                SignResult = false,
                ReturnAccessMatrix = true,
                ApiServiceCallId = 191417,
                CallbackURL = "192.168.1.1"
            };

            GetCompanyInfoRequest request = new GetCompanyInfoRequest
            {
                CompanyName = "КЕЙБЪЛТЕЛ-ПРИМА",
                CompanyType = "АД",
                EIK = "147032881"
            };

            var result = cRCSubscribersAdapter.GetCompanyInfo(request, AccessMatrix.CreateForType(typeof(GetCompanyInfoResponseType)), additionalParameters);

            Assert.IsTrue(true);
        }
    }
}
