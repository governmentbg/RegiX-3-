using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechnoLogica.RegiX.Adapters.TestUtils;
using TechnoLogica.RegiX.MPRNAdapter.AdapterService;
using TechnoLogica.RegiX.MPRNAdapter.Mock;

namespace TechnoLogica.RegiX.MPRNAdapter.Tests
{
    [TestClass]
    public class MPRNAdapterMockTest : MockTest<MPRNAdapterMock, IRNAdapter>
    {
    }
}

