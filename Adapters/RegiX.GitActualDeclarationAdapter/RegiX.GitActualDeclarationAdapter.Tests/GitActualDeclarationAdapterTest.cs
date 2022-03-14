using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TechnoLogica.RegiX.Adapters.TestUtils;
using TechnoLogica.RegiX.GitActualDeclarationAdapter.AdapterService;

namespace TechnoLogica.RegiX.GitActualDeclarationAdapter.Tests
{
    [TestClass]
    public class GitActualDeclarationAdapterTest : AdapterTest<AdapterService.GitActualDeclarationAdapter, IGitActualDeclarationAdapter>
    {
    }
}
