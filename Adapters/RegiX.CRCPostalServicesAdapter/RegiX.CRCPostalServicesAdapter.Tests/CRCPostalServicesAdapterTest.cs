using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechnoLogica.RegiX.Adapters.TestUtils;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.CRCPostalServicesAdapter;
using TechnoLogica.RegiX.CRCPostalServicesAdapter.AdapterService;

namespace TechnoLogica.RegiX.CRCPostalServicesAdapter.Tests
{
    [TestClass]
    public class CRCPostalServicesAdapterTest : AdapterTest<TechnoLogica.RegiX.CRCPostalServicesAdapter.AdapterService.CRCPostalServicesAdapter, ICRCPostalServicesAdapter>
    {
       //[TestMethod]
        public void GetUniversalOperatorsInfoTest()
        {
            TechnoLogica.RegiX.CRCPostalServicesAdapter.AdapterService.CRCPostalServicesAdapter cRCPostalServicesAdapter = new TechnoLogica.RegiX.CRCPostalServicesAdapter.AdapterService.CRCPostalServicesAdapter();

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

            GetUniversalOperatorsInfoRequest request = new GetUniversalOperatorsInfoRequest
            {
               
            };

            var result = cRCPostalServicesAdapter.GetUniversalOperatorsInfo(request, AccessMatrix.CreateForType(typeof(GetUniversalOperatorsInfoResponseType)), additionalParameters);

            Assert.IsTrue(true);
        }
    }
}
