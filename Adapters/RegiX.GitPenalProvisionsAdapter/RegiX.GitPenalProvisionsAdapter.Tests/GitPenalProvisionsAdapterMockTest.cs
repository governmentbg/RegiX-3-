using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechnoLogica.RegiX.Adapters.TestUtils;
using TechnoLogica.RegiX.GitPenalProvisionsAdapter.AdapterService;
using TechnoLogica.RegiX.GitPenalProvisionsAdapter.Mocks;

namespace TechnoLogica.RegiX.GitPenalProvisionsAdapter.Tests
{
    [TestClass]
    public class GitPenalProvisionsAdapterMockTest : MockTest<GitPenalProvisionsAdapterMock, IGitPenalProvisionsAdapter>
    {
    }
}
