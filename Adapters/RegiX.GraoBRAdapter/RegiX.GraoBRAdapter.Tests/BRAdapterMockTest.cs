using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TechnoLogica.RegiX.Adapters.TestUtils;
using TechnoLogica.RegiX.GraoBRAdapter.AdapterService;
using TechnoLogica.RegiX.GraoBRAdapter.Mocks;

namespace TechnoLogica.RegiX.GraoBRAdapter.Tests
{
    [TestClass]
    public class BRAdapterMockTest : MockTest<BRAdapterMock, IBRAdapter>
    {
    }
}
