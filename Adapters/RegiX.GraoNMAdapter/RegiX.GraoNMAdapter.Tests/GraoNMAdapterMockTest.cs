using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechnoLogica.RegiX.Adapters.TestUtils;
using TechnoLogica.RegiX.GraoNMAdapter.AdapterService;
using TechnoLogica.RegiX.GraoNMAdapter.Mock;

namespace TechnoLogica.RegiX.GraoNMAdapter.Tests
{
    [TestClass]
    public class GraoNMAdapterMockTest : MockTest<NMAdapterMock, INMAdapter>
    {
    }
}

