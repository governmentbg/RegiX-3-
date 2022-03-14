using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechnoLogica.RegiX.Adapters.TestUtils;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.CRCIOORGeoPositionAdapter;
using TechnoLogica.RegiX.CRCIOORGeoPositionAdapter.AdapterService;

namespace TechnoLogica.RegiX.CRCIOORGeoPositionAdapter.Tests
{
    [TestClass]
    public class CRCNotificationsAdapterTest : AdapterTest<TechnoLogica.RegiX.CRCIOORGeoPositionAdapter.AdapterService.CRCIOORGeoPositionAdapter, ICRCIOORGeoPositionAdapter>
    {
        //[TestMethod]
        public void GetCompanyInfoTest()
        {
            TechnoLogica.RegiX.CRCIOORGeoPositionAdapter.AdapterService.CRCIOORGeoPositionAdapter cRCIOORGeoPositionAdapter = new TechnoLogica.RegiX.CRCIOORGeoPositionAdapter.AdapterService.CRCIOORGeoPositionAdapter();

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
                CompanyName = null,//"НЕТ 001 v25",
                CompanyType = null,//"ET",
                EIK = null,//"8596326v2",
                Address = null, //"бул. Цариградско шосе 34",
                WebPageAddress = null,//"www.net001_new2.net",
                PermissionNumber = null,//"45671",
                IssueDateFrom = new DateTime(2010, 9, 18),
                IssueDateTo = new DateTime(2010, 9, 18),
                IssueDateFromSpecified = true,
                IssueDateToSpecified = true,
                EndOfActionFromDate = null,
                EndOfActionFromDateSpecified = false,
                EndOfActionToDate = null,
                EndOfActionToDateSpecified = false

            };

            var result = cRCIOORGeoPositionAdapter.GetCompanyInfo(request, AccessMatrix.CreateForType(typeof(GetCompanyInfoResponseType)), additionalParameters);

            Assert.IsTrue(true);
        }
    }
}
