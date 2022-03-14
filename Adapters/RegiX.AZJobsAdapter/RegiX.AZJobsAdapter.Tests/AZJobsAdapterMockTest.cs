using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TechnoLogica.RegiX.Adapters.TestUtils;
using TechnoLogica.RegiX.AZJobsAdapter.AdapterService;
using TechnoLogica.RegiX.AZJobsAdapter.Mocks;

namespace TechnoLogica.RegiX.AZJobsAdapter.Tests
{
    [TestClass]
    public class AZJobsAdapterMockTest : MockTest<AZJobsAdapterMock, IAZJobsAdapter>
    {
    }
}
