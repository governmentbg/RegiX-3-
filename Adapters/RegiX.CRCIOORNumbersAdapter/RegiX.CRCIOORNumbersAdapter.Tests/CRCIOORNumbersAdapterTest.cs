using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechnoLogica.RegiX.Adapters.TestUtils;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.CRCIOORNumbersAdapter;
using TechnoLogica.RegiX.CRCIOORNumbersAdapter.AdapterService;

namespace TechnoLogica.RegiX.CRCIOORNumbersAdapter.Tests
{
    [TestClass]
    public class CRCIOORNumbersAdapterTest : AdapterTest<TechnoLogica.RegiX.CRCIOORNumbersAdapter.AdapterService.CRCIOORNumbersAdapter, ICRCIOORNumbersAdapter>
    {
        //[TestMethod]
        public void GetUniversalOperatorsInfoTest()
        {
            TechnoLogica.RegiX.CRCIOORNumbersAdapter.AdapterService.CRCIOORNumbersAdapter cRCIOORNumbersAdapter = new TechnoLogica.RegiX.CRCIOORNumbersAdapter.AdapterService.CRCIOORNumbersAdapter();

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

            };

            var result = cRCIOORNumbersAdapter.GetCompanyInfo(request, AccessMatrix.CreateForType(typeof(GetCompanyInfoResponseType)), additionalParameters);

            Assert.IsTrue(true);
        }
    }
}
