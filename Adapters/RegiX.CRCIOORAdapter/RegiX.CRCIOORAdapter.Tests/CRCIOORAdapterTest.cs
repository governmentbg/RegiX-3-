using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechnoLogica.RegiX.Adapters.TestUtils;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.CRCIOORAdapter;
using TechnoLogica.RegiX.CRCIOORAdapter.AdapterService;

namespace TechnoLogica.RegiX.CRCIOORAdapter.Tests
{
    [TestClass]
    public class CRCIOORAdapterTest : AdapterTest<TechnoLogica.RegiX.CRCIOORAdapter.AdapterService.CRCIOORAdapter, ICRCIOORAdapter>
    {
        //[TestMethod]
        public void GetUniversalOperatorsInfoTest()
        {
            TechnoLogica.RegiX.CRCIOORAdapter.AdapterService.CRCIOORAdapter cRCIOORAdapter = new TechnoLogica.RegiX.CRCIOORAdapter.AdapterService.CRCIOORAdapter();

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

            var result = cRCIOORAdapter.GetCompanyInfo(request, AccessMatrix.CreateForType(typeof(GetCompanyInfoResponseType)), additionalParameters);

            Assert.IsTrue(true);
        }
    }
}
