using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechnoLogica.RegiX.Adapters.TestUtils;
using TechnoLogica.RegiX.NoiRPAdapter.AdapterService;
using TechnoLogica.RegiX.NoiRPAdapter.Mock;

namespace TechnoLogica.RegiX.NoiRPAdapter.Tests
{
    [TestClass]
    public class NoiRPAdapterMockTest : MockTest<NoiRPAdapterMock, IRPAdapter>
    {
    }
}

