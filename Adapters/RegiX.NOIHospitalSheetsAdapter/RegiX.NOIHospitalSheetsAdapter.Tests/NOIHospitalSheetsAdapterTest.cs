using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechnoLogica.RegiX.Adapters.TestUtils;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.NOIHospitalSheetsAdapter.AdapterService;
using TechnoLogica.RegiX.NOIHospotalSheetsAdapter;

namespace RegiX.NOIHospitalSheetsAdapter.Tests
{
    [TestClass]
    public class NOIHospitalSheetsAdapterTest: AdapterTest<TechnoLogica.RegiX.NOIHospitalSheetsAdapter.AdapterService.NOIHospitalSheetsAdapter, INOIHospitalSheetsAdapter>
    {
        [TestMethod]
        public void GetHospitalSheetsDataTest()
        {
            TechnoLogica.RegiX.NOIHospitalSheetsAdapter.AdapterService.NOIHospitalSheetsAdapter nOIHospitalSheetsAdapter = new TechnoLogica.RegiX.NOIHospitalSheetsAdapter.AdapterService.NOIHospitalSheetsAdapter();
            
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

            GetHospitalSheetsDataRequestType request = new GetHospitalSheetsDataRequestType
            {
                Identifier = "1111111110",
                IdentifierType = IdentifierType.EGN,
                IdentifierTypeSpecified = true
            };

            var result = nOIHospitalSheetsAdapter.GetHospitalSheetsData(request, AccessMatrix.CreateForType(typeof(GetHospitalSheetsDataResponseType)), additionalParameters);

            Assert.IsTrue(result.Data.Response.Title.Name == "Справка за постъпили данни от издадени/ анулирани болнични листове по ЕГН/ ЛНЧ");
        }
    }
}
