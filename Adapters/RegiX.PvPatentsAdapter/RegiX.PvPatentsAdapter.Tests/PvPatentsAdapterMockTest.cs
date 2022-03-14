using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechnoLogica.RegiX.Adapters.TestUtils;
using TechnoLogica.RegiX.PvPatentsAdapter.AdapterService;
using TechnoLogica.RegiX.PvPatentsAdapter.Mock;

namespace TechnoLogica.RegiX.PvPatentsAdapter.Tests
{
    [TestClass]
    public class PvPatentsAdapterMockTest : MockTest<PvPatentsAdapterMock, IPvPatentsAdapter>
    {
    }
}

