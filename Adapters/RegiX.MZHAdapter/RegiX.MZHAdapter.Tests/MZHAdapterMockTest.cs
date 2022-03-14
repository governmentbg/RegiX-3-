using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechnoLogica.RegiX.Adapters.TestUtils;
using TechnoLogica.RegiX.MZHAdapter.AdapterService;
using TechnoLogica.RegiX.MZHAdapter.Mock;

namespace TechnoLogica.RegiX.MZHAdapter.Tests
{
    [TestClass]
    public class MZHAdapterMockTest : MockTest<MZHAdapterMock, IMZHAdapter>
    {
    }
}

