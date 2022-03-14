using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegiX.NRAPublicDebtsCollectionAdapter.Mocks;
using TechnoLogica.RegiX.Adapters.TestUtils;
using TechnoLogica.RegiX.NRAPublicDebtsCollectionAdapter.AdapterService;

namespace TechnoLogica.RegiX.NRAPublicDebtsCollectionAdapter.Tests
{
    [TestClass]
    public class NRAPublicDebtsCollectionAdapterMockTest : MockTest<NRAPublicDebtsCollectionAdapterMock, INRAPublicDebtsCollectionAdapter>
    {
    }
}
