using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechnoLogica.RegiX.Adapters.TestUtils;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.CRCTransferredRightsAdapter;
using TechnoLogica.RegiX.CRCTransferredRightsAdapter.AdapterService;

namespace TechnoLogica.RegiX.CRCTransferredRightsAdapter.Tests
{
    [TestClass]
    public class CRCTransferredRightsAdapterTest : AdapterTest<TechnoLogica.RegiX.CRCTransferredRightsAdapter.AdapterService.CRCTransferredRightsAdapter, ICRCTransferredRightsAdapter>
    {
        //[TestMethod]
        public void GetRentedIOORInfoTest()
        {
            TechnoLogica.RegiX.CRCTransferredRightsAdapter.AdapterService.CRCTransferredRightsAdapter cRCTransferredRightsAdapter = new TechnoLogica.RegiX.CRCTransferredRightsAdapter.AdapterService.CRCTransferredRightsAdapter();

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

            GetRentedIOORInfoRequest request = new GetRentedIOORInfoRequest
            {
               
            };

            var result = cRCTransferredRightsAdapter.GetRentedIOORInfo(request, AccessMatrix.CreateForType(typeof(GetRentedIOORInfoResponseType)), additionalParameters);

            Assert.IsTrue(true);
        }

        //[TestMethod]
        public void GetTransferredRightsInfoTest()
        {
            TechnoLogica.RegiX.CRCTransferredRightsAdapter.AdapterService.CRCTransferredRightsAdapter cRCTransferredRightsAdapter = new TechnoLogica.RegiX.CRCTransferredRightsAdapter.AdapterService.CRCTransferredRightsAdapter();

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

            GetTransferredRightsRequest request = new GetTransferredRightsRequest
            {


            };

            var result = cRCTransferredRightsAdapter.GetTransferredRightsInfo(request, AccessMatrix.CreateForType(typeof(GetTransferredRightsInfoResponseType)), additionalParameters);

            Assert.IsTrue(true);
        }
    }
}
