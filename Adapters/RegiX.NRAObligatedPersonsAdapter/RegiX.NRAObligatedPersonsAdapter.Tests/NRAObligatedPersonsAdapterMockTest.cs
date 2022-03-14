using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechnoLogica.RegiX.Adapters.TestUtils;
using TechnoLogica.RegiX.NRAObligatedPersonsAdapter.AdapterService;
using TechnoLogica.RegiX.NRAObligatedPersonsAdapter.Mock;

namespace TechnoLogica.RegiX.NRAObligatedPersonsAdapter.Tests
{
    [TestClass]
    public class NRAObligatedPersonsAdapterMockTest : MockTest<NRAObligatedPersonsAdapterMock, INRAObligatedPersonsAdapter>
    {
    }
}

