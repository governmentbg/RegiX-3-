using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechnoLogica.RegiX.Adapters.TestUtils;
using TechnoLogica.RegiX.IAMASeafarersAdapter.AdapterService;
using TechnoLogica.RegiX.IAMASeafarersAdapter.Mock;

namespace TechnoLogica.RegiX.IAMASeafarersAdapter.Tests
{
    [TestClass]
    public class SeafarersAdapterMockTest : MockTest<SeafarersAdapterMock, ISeafarersAdapter>
    {
    }
}

