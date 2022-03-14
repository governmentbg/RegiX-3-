using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TechnoLogica.RegiX.Adapters.TestUtils;
using TechnoLogica.RegiX.NCPRMedicinalProductsAdapter.AdapterService;
using TechnoLogica.RegiX.NCPRMedicinalProductsAdapter.Mocks;

namespace TechnoLogica.NCPRMedicinalProductsAdapter.Tests
{
    [TestClass]
    public class NCPRMedicinalProductsAdapterMockTest : MockTest<NCPRMedicinalProductsAdapterMock, INCPRMedicinalProductsAdapter>
    {
    }
}
