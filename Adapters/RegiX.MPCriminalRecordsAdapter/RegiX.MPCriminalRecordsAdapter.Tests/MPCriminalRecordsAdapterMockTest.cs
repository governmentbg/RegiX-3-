using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechnoLogica.RegiX.Adapters.TestUtils;
using TechnoLogica.RegiX.MPCriminalRecordsAdapter.AdapterService;
using TechnoLogica.RegiX.MPCriminalRecordsAdapter.Mock;

namespace TechnoLogica.RegiX.MPCriminalRecordsAdapter.Tests
{
    [TestClass]
    public class MPCriminalRecordsAdapterMockTest : MockTest<MPCriminalRecordsAdapterMock, ICriminalRecordsAdapter>
    {
    }
}

