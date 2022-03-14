using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechnoLogica.RegiX.Adapters.TestUtils;
using TechnoLogica.RegiX.GraoPNAAdapter.AdapterService;
using TechnoLogica.RegiX.GraoPNAAdapter.Mock;

namespace TechnoLogica.RegiX.GraoPNAAdapter.Tests
{
    [TestClass]
    public class GraoPNAAdapterMockTest : MockTest<PNAAdapterMock, IPNAAdapter>
    {
    }
}

