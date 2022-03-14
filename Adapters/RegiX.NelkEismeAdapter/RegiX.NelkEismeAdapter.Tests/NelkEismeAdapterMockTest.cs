using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechnoLogica.RegiX.Adapters.TestUtils;
using TechnoLogica.RegiX.NelkEismeAdapter.AdapterService;
using TechnoLogica.RegiX.NelkEismeAdapter.Mock;

namespace TechnoLogica.RegiX.NelkEismeAdapter.Tests
{
    [TestClass]
    public class NelkEismeAdapterMockTest : MockTest<NelkEismeAdapterMock, INelkEismeAdapter>
    {
    }
}

