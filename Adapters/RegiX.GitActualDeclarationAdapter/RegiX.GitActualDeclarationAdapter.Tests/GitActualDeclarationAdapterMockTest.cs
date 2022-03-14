using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechnoLogica.RegiX.Adapters.TestUtils;
using TechnoLogica.RegiX.GitActualDeclarationAdapter.AdapterService;
using TechnoLogica.RegiX.GitActualDeclarationAdapter.Mocks;

namespace TechnoLogica.RegiX.GitActualDeclarationAdapter.Tests
{
    [TestClass]
    public class GitActualDeclarationAdapterMockTest : MockTest<GitActualDeclarationAdapterMock, IGitActualDeclarationAdapter>
    {
    }
}
