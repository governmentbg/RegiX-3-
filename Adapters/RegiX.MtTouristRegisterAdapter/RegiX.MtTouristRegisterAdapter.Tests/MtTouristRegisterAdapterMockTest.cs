using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechnoLogica.RegiX.Adapters.TestUtils;
using TechnoLogica.RegiX.MtTouristRegisterAdapter.AdapterService;
using TechnoLogica.RegiX.MtTouristRegisterAdapter.Mock;

namespace TechnoLogica.RegiX.MtTouristRegisterAdapter.Tests
{
    [TestClass]
    public class MtTouristRegisterAdapterMockTest : MockTest<MtTouristRegisterAdapterMock, IMtTouristRegisterAdapter>
    {
    }
}

