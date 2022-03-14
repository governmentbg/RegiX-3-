using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechnoLogica.RegiX.Adapters.TestUtils;
using TechnoLogica.RegiX.GraoLEAdapter.AdapterService;
using TechnoLogica.RegiX.GraoLEAdapter.Mock;

namespace TechnoLogica.RegiX.GraoLEAdapter.Tests
{
    [TestClass]
    public class GraoLEAdapterMockTest : MockTest<LEAdapterMock, ILEAdapter>
    {
    }
}

