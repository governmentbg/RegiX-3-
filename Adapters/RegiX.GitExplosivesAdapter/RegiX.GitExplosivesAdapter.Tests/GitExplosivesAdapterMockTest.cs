using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TechnoLogica.RegiX.Adapters.TestUtils;
using TechnoLogica.RegiX.GitExplosivesAdapter.AdapterService;
using TechnoLogica.RegiX.GitExplosivesAdapter.Mocks;

namespace TechnoLogica.RegiX.GitExplosivesAdapter.Tests
{
    [TestClass]
    public class GitExplosivesAdapterMockTest : MockTest<GitExplosivesAdapterMock, IGitExplosivesAdapter>
    {
    }
}
