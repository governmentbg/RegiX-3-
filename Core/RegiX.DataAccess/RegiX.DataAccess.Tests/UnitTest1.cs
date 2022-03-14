using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RegiX.DataAccess.Tests
{
    using TechnoLogica.RegiX.Core.Data.Interfaces;
    using TechnoLogica.RegiX.DataAccess.DataClasses;

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            IRegiXData service = new RegiXData();

            var adapters = service.GetAdministrations();
            Assert.IsTrue(true);

        }
        [TestMethod]
        public void TestMethod2()
        {
            IRegiXData service = new RegiXData();

            var adapters = service.GetServiceAndConsumerInformation("11FA827B10861EBC3EB5F752F67E6BB0178A4BBA", "TechnoLogica.RegiX.MVRBDSAdapter.APIService.IMVRBDSAPI", "GetPersonalIdentity", string.Empty);
            var adapterID = service.GetRegisterAdapterID("TechnoLogica.RegiX.MVRBDSAdapter.AdapterService.IMVRBDSAdapter");
            var access = service.GetPropertyAccess("GetPersonalIdentity", adapterID, adapters.CertificateID.Value);

            Assert.IsTrue(true);

        }
    }
}
