using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechnoLogica.RegiX.Adapters.TestUtils;
using TechnoLogica.RegiX.NoiROAdapter.AdapterService;
using TechnoLogica.RegiX.NoiROAdapter.Mock;

namespace TechnoLogica.RegiX.NoiROAdapter.Tests
{
    [TestClass]
    public class NoiROAdapterMockTest : MockTest<NoiROAdapterMock, IROAdapter>
    {
    }
}

