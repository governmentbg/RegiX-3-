using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechnoLogica.RegiX.Adapters.TestUtils;
using TechnoLogica.RegiX.Common.Utils;
using TechnoLogica.RegiX.NHIFAdapter.AdapterService;
using TechnoLogica.RegiX.NHIFAdapter.Mock;

namespace TechnoLogica.RegiX.NHIFAdapter.Tests
{
    [TestClass]
    public class NHIFAdapterMockTest : MockTest<NHIFAdapterMock, INHIFAdapter>
    {
    }
}

