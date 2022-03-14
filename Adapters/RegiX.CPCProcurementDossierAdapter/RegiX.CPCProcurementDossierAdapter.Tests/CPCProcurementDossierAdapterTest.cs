using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegiX.CPCProcurementDossierAdapter.AdapterService;
using TechnoLogica.RegiX.Adapters.TestUtils;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.CPCProcurementDossierAdapter;

namespace RegiX.CPCProcurementDossierAdapter.Tests
{
    [TestClass]
    public class CPCProcurementDossierAdapterTest : AdapterTest<AdapterService.CPCProcurementDossierAdapter, ICPCProcurementDossierAdapter>
    {
        //[TestMethod]
        public void SendNotaryDocumentDBInsertTest()
        {
            AdapterService.CPCProcurementDossierAdapter cPCProcurementDossierAdapter = new AdapterService.CPCProcurementDossierAdapter();

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
            GetProcurementDossierRequest request = new GetProcurementDossierRequest
            {
               ProcurementNumber = "test123"
            };
            var result = cPCProcurementDossierAdapter.GetProcurementDossier(request, AccessMatrix.CreateForType(typeof(GetProcurementDossierResponse)), additionalParameters);


            Assert.IsTrue(result.Data.Response.ResultStatus == GetProcurementDossierResponseResultStatus.OK);
        }
    }
}
