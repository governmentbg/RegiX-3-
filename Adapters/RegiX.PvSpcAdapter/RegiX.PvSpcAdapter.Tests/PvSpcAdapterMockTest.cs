using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechnoLogica.RegiX.Adapters.TestUtils;
using TechnoLogica.RegiX.PvSpcAdapter.AdapterService;
using TechnoLogica.RegiX.PvSpcAdapter.Mock;

namespace TechnoLogica.RegiX.PvSpcAdapter.Tests
{
    [TestClass]
    public class PvSpcAdapterMockTest : MockTest<PvSpcAdapterMock, IPvSpcAdapter>
    {
    }
}

