using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechnoLogica.RegiX.Adapters.TestUtils;
using TechnoLogica.RegiX.RTSAdapter.AdapterService;
using TechnoLogica.RegiX.RTSAdapter.Mock;

namespace TechnoLogica.RegiX.RTSAdapter.Tests
{
    [TestClass]
    public class RTSAdapterMockTest : MockTest<RTSAdapterMock, IRTSAdapter>
    {
    }
}

