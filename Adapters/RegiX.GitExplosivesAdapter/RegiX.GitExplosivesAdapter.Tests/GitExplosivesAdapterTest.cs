using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechnoLogica.RegiX.Adapters.TestUtils;
using TechnoLogica.RegiX.GitExplosivesAdapter.AdapterService;

namespace TechnoLogica.RegiX.GitExplosivesAdapter.Tests
{
    [TestClass]
    public class GitExplosivesAdapterTest : AdapterTest<AdapterService.GitExplosivesAdapter, IGitExplosivesAdapter>
    {
    }
}
