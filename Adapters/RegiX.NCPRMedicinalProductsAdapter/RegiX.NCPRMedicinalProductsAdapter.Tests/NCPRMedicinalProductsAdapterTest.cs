using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechnoLogica.RegiX.Adapters.TestUtils;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.NCPRMedicinalProductsAdapter;
using TechnoLogica.RegiX.NCPRMedicinalProductsAdapter.AdapterService;

namespace TechnoLogica.NCPRMedicinalProductsAdapter.Tests
{
    [TestClass]
    public class NCPRMedicinalProductsAdapterTest : AdapterTest<TechnoLogica.RegiX.NCPRMedicinalProductsAdapter.AdapterService.NCPRMedicinalProductsAdapter, INCPRMedicinalProductsAdapter>
    {
        //[TestMethod]
        public void ListMedicinalProductsTest()
        {
            TechnoLogica.RegiX.NCPRMedicinalProductsAdapter.AdapterService.NCPRMedicinalProductsAdapter nCPRMedicinalProductsAdapter = new TechnoLogica.RegiX.NCPRMedicinalProductsAdapter.AdapterService.NCPRMedicinalProductsAdapter();

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

            ListMedicinalProductsRequestType request = new ListMedicinalProductsRequestType
            {
                ATCCode = "asd",
                INNCode = "asd",
                MedicinalProductName = "asd",
                RegisterCode = RegisterCodeType.PDL_APPENDIX_1
            };

            var result = nCPRMedicinalProductsAdapter.ListMedicinalProducts(request, AccessMatrix.CreateForType(typeof(ListMedicinalProductsResponseType)), additionalParameters);

            Assert.IsTrue(true);
        }
        //[TestMethod]
        public void ListDeletedMedicinalProductsTest()
        {
            TechnoLogica.RegiX.NCPRMedicinalProductsAdapter.AdapterService.NCPRMedicinalProductsAdapter nCPRMedicinalProductsAdapter = new TechnoLogica.RegiX.NCPRMedicinalProductsAdapter.AdapterService.NCPRMedicinalProductsAdapter();

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

            ListDeletedMedicinalProductsRequestType request = new ListDeletedMedicinalProductsRequestType
            {
                ATCCode = "asd",
                INNCode = "asd",
                MedicinalProductName = "asd",
                RegisterCode = null
            };

            var result = nCPRMedicinalProductsAdapter.ListDeletedMedicinalProducts(request, AccessMatrix.CreateForType(typeof(ListDeletedMedicinalProductsResponseType)), additionalParameters);

            Assert.IsTrue(true);
        }

        //[TestMethod]
        public void GetRegisterMedicinalProductDataTest()
        {
            TechnoLogica.RegiX.NCPRMedicinalProductsAdapter.AdapterService.NCPRMedicinalProductsAdapter nCPRMedicinalProductsAdapter = new TechnoLogica.RegiX.NCPRMedicinalProductsAdapter.AdapterService.NCPRMedicinalProductsAdapter();

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

            GetRegisterMedicinalProductDataRequestType request = new GetRegisterMedicinalProductDataRequestType
            {
                RegisterMedicinalProductId = 122
            };

            var result = nCPRMedicinalProductsAdapter.GetRegisterMedicinalProductData(request, AccessMatrix.CreateForType(typeof(GetRegisterMedicinalProductDataResponseType)), additionalParameters);

            Assert.IsTrue(true);
        }

        //[TestMethod]
        public void GetMedicinalProductDataTest()
        {
            TechnoLogica.RegiX.NCPRMedicinalProductsAdapter.AdapterService.NCPRMedicinalProductsAdapter nCPRMedicinalProductsAdapter = new TechnoLogica.RegiX.NCPRMedicinalProductsAdapter.AdapterService.NCPRMedicinalProductsAdapter();

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

            GetMedinicalProductDataRequestType request = new GetMedinicalProductDataRequestType
            {
                MedicinalProductIdentifier = "123"
            };

            var result = nCPRMedicinalProductsAdapter.GetMedicinalProductData(request, AccessMatrix.CreateForType(typeof(GetMedicinalProductDataResponseType)), additionalParameters);

            Assert.IsTrue(true);
        }
    }
}
