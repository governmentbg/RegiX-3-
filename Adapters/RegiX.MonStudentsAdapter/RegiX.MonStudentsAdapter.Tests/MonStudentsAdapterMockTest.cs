using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechnoLogica.RegiX.Adapters.TestUtils;
using TechnoLogica.RegiX.MonStudentsAdapter.AdapterService;
using TechnoLogica.RegiX.MonStudentsAdapter.Mock;

namespace TechnoLogica.RegiX.MonStudentsAdapter.Tests
{
    [TestClass]
    public class MonStudentsAdapterMockTest : MockTest<MonStudentsAdapterMock, IMonStudentsAdapter>
    {
    }
}

