using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechnoLogica.RegiX.Adapters.TestUtils;
using TechnoLogica.RegiX.NRAEmploymentContractsAdapter.AdapterService;
using TechnoLogica.RegiX.NRAEmploymentContractsAdapter.Mock;

namespace TechnoLogica.RegiX.NRAEmploymentContractsAdapter.Tests
{
    [TestClass]
    public class NRAEmploymentContractsAdapterMockTest : MockTest<NRAEmploymentContractsAdapterMock, INRAEmploymentContractsAdapter>
    {
    }
}

