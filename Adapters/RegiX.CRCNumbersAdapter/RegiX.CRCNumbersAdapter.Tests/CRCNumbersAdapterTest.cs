using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechnoLogica.RegiX.Adapters.TestUtils;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.CRCNumbersAdapter;
using TechnoLogica.RegiX.CRCNumbersAdapter.AdapterService;

namespace TechnoLogica.RegiX.CRCNumbersAdapter.Tests
{
    [TestClass]
    public class CRCNumbersAdapterTest : AdapterTest<TechnoLogica.RegiX.CRCNumbersAdapter.AdapterService.CRCNumbersAdapter, ICRCNumbersAdapter>
    {
        //[TestMethod]
        public void GetUniversalOperatorsInfoTest()
        {
            TechnoLogica.RegiX.CRCNumbersAdapter.AdapterService.CRCNumbersAdapter cRCNumbersAdapter = new TechnoLogica.RegiX.CRCNumbersAdapter.AdapterService.CRCNumbersAdapter();

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

            GetNumbersInfoRequest request = new GetNumbersInfoRequest
            {

            };

            var result = cRCNumbersAdapter.GetNumbersInfo(request, AccessMatrix.CreateForType(typeof(GetNumbersInfoResponseType)), additionalParameters);

            Assert.IsTrue(true);
        }
    }
}
