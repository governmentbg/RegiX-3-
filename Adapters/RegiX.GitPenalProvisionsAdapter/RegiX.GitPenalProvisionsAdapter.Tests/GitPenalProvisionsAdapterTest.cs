using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechnoLogica.RegiX.Adapters.TestUtils;
using TechnoLogica.RegiX.GitPenalProvisionsAdapter.AdapterService;

namespace TechnoLogica.RegiX.GitPenalProvisionsAdapter.Tests
{
    [TestClass]
    public class GitPenalProvisionsAdapterTest : AdapterTest<AdapterService.GitPenalProvisionsAdapter, IGitPenalProvisionsAdapter>
    {
    }
}
