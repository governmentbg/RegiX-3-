using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechnoLogica.RegiX.Adapters.TestUtils;
using TechnoLogica.RegiX.IAMAVesselsAdapter.AdapterService;
using TechnoLogica.RegiX.IAMAVesselsAdapter.Mock;

namespace TechnoLogica.RegiX.IAMAVesselsAdapter.Tests
{
    [TestClass]
    public class VesselsAdapterMockTest : MockTest<VesselsAdapterMock, IVesselsAdapter>
    {
    }
}

