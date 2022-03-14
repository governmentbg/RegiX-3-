using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechnoLogica.RegiX.Adapters.TestUtils;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.CRCSignificantEnterprisesAdapter;
using TechnoLogica.RegiX.CRCSignificantEnterprisesAdapter.AdapterService;

namespace TechnoLogica.RegiX.CRCSignificantEnterprisesAdapter.Tests
{
    [TestClass]
    public class CRCSignificantEnterprisesAdapterTest : AdapterTest<TechnoLogica.RegiX.CRCSignificantEnterprisesAdapter.AdapterService.CRCSignificantEnterprisesAdapter, ICRCSignificantEnterprisesAdapter>
    {
        //[TestMethod]
        public void GetCompanyInfoTest()
        {
            TechnoLogica.RegiX.CRCSignificantEnterprisesAdapter.AdapterService.CRCSignificantEnterprisesAdapter cRCSignificantEnterprisesAdapter = new TechnoLogica.RegiX.CRCSignificantEnterprisesAdapter.AdapterService.CRCSignificantEnterprisesAdapter();

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
                CompanyName = "ТЕСТ_НЕТ 002",
                CompanyType = "ЕООД",
                EIK = "4654654564",
            };

            var result = cRCSignificantEnterprisesAdapter.GetCompanyInfo(request, AccessMatrix.CreateForType(typeof(GetCompanyInfoResponseType)), additionalParameters);

            Assert.IsTrue(true);
        }


    }
}
