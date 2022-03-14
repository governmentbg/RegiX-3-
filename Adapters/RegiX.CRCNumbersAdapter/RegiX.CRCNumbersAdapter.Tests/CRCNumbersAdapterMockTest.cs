using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechnoLogica.RegiX.Adapters.TestUtils;
using TechnoLogica.RegiX.CRCNumbersAdapter.AdapterService;
using TechnoLogica.RegiX.CRCNumbersAdapter.Mocks;

namespace TechnoLogica.RegiX.CRCNumbersAdapter.Tests
{
    [TestClass]
    public class CRCNumbersAdapterMockTest : MockTest<CRCNumbersAdapterMock, ICRCNumbersAdapter>
    {
    }
}
