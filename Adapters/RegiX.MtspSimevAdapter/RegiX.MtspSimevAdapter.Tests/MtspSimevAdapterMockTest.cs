using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechnoLogica.RegiX.Adapters.TestUtils;
using TechnoLogica.RegiX.MtspSimevAdapter.AdapterService;
using TechnoLogica.RegiX.MtspSimevAdapter.Mock;

namespace TechnoLogica.RegiX.MtspSimevAdapter.Tests
{
    [TestClass]
    public class MtspSimevAdapterMockTest : MockTest<MtspSimevAdapterMock, IMtspSimevAdapter>
    {
    }
}

