using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;
using TechnoLogica.RegiX.Admin.Infrastructure;
using TechnoLogica.RegiX.Admin.Repositories;
using TechnoLogica.RegiX.Admin.Repositories.Impl;

namespace RegiX.Admin.Repositories.Tests
{
    [TestClass]
    public class ApiServiceConsumersRepositoryTest
    {
        [TestMethod]
        public void SelectAll_ExistingApiServiceConsumersSelectedBy_Admin()
        {
            var dbContext = new TestDataContextFactory().Create();

            Mock<IUserContext> contextMock = new Mock<IUserContext>();
            contextMock.SetupGet(u => u.AdministrationID).Returns(1);

            var repository = new ApiServiceConsumersRepository(dbContext, contextMock.Object);
            var result = repository.SelectAll();

            Assert.IsTrue(result.Count() == 1, $"Expected 1 got { result.Count()}");
        }

        //Only Global Admins have no AdministrationID so we return everything.
        [TestMethod]
        public void SelectAll_ExistingApiServiceConsumersSelectedBy_GlobalAdmin()
        {
            var dbContext = new TestDataContextFactory().Create();

            Mock<IUserContext> contextMock = new Mock<IUserContext>();
            contextMock.SetupGet(u => u.AdministrationID).Returns((int?)null);

            var repository = new ApiServiceConsumersRepository(dbContext, contextMock.Object);
            var result = repository.SelectAll();

            Assert.IsTrue(result.Count() == 2, $"Expected 2 got { result.Count()}");
        }
    }
}