using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TechnoLogica.RegiX.Adapters.TestUtils;
using TechnoLogica.RegiX.AVTRAdapter.AdapterService;
using TechnoLogica.RegiX.AVTRAdapter.Mocks;

namespace TechnoLogica.RegiX.AVTRAdapter.Tests
{
    [TestClass]
    public class TRAdapterMockTest : MockTest<TRAdapterMock, ITRAdapter>
    {
    }
}
