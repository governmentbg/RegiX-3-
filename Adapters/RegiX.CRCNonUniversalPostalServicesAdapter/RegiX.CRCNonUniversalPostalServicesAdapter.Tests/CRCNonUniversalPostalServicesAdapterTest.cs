using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechnoLogica.RegiX.Adapters.TestUtils;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.CRCNonUniversalPostalServicesAdapter;
using TechnoLogica.RegiX.CRCNonUniversalPostalServicesAdapter.AdapterService;

namespace TechnoLogica.RegiX.CRCNonUniversalPostalServicesAdapter.Tests
{
    [TestClass]
    public class CRCNonUniversalPostalServicesAdapterTest : AdapterTest<TechnoLogica.RegiX.CRCNonUniversalPostalServicesAdapter.AdapterService.CRCNonUniversalPostalServicesAdapter, ICRCNonUniversalPostalServicesAdapter>
    {
        //[TestMethod]
        public void GetRentedIOORInfoTest()
        {
            TechnoLogica.RegiX.CRCNonUniversalPostalServicesAdapter.AdapterService.CRCNonUniversalPostalServicesAdapter cRCNonUniversalPostalServicesAdapter = new TechnoLogica.RegiX.CRCNonUniversalPostalServicesAdapter.AdapterService.CRCNonUniversalPostalServicesAdapter();

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

            GetNonUniversalOperatorsInfoRequest request = new GetNonUniversalOperatorsInfoRequest
            {
               
            };

            var result = cRCNonUniversalPostalServicesAdapter.GetNonUniversalOperatorsInfo(request, AccessMatrix.CreateForType(typeof(GetNonUniversalOperatorsInfoResponseType)), additionalParameters);

            Assert.IsTrue(true);
        }
    }
}
