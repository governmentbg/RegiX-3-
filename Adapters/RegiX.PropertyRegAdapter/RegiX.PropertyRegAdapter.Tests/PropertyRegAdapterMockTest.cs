using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechnoLogica.RegiX.Adapters.TestUtils;
using TechnoLogica.RegiX.PropertyRegAdapter.AdapterService;
using TechnoLogica.RegiX.PropertyRegAdapter.Mock;

namespace TechnoLogica.RegiX.PropertyRegAdapter.Tests
{
    [TestClass]
    public class PropertyRegAdapterMockTest : MockTest<PropertyRegAdapterMock, IPropertyRegAdapter>
    {
    }
}

