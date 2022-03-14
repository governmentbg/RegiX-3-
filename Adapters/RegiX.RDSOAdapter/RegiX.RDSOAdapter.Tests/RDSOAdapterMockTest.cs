using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechnoLogica.RegiX.Adapters.TestUtils;
using TechnoLogica.RegiX.RDSOAdapter.AdapterService;
using TechnoLogica.RegiX.RDSOAdapter.Mock;

namespace TechnoLogica.RegiX.RDSOAdapter.Tests
{
    [TestClass]
    public class RDSOAdapterMockTest : MockTest<RDSOAdapterMock, IRDSOAdapter>
    {
    }
}

