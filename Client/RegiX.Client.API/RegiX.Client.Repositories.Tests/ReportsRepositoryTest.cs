using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TechnoLogica.RegiX.Client.Repositories;
using TechnoLogica.RegiX.Client.Repositories.Impl;

namespace RegiX.Client.Repositories.Tests
{
    [TestClass]
    public class ReportsRepositoryTest
    {
        [TestMethod]
        public void SelectAll_ExistingReports()
        {
            var dbContext = new TestDataContextFactory().Create();

            Mock<IUserContext> contextMock = new Mock<IUserContext>();
            contextMock.SetupGet(u => u.AdministrationID).Returns(1);

            var repository = new ReportsRepository(dbContext, contextMock.Object);
            var result = repository.SelectAll();

            Assert.IsTrue(result.Count() == 2, $"Expected 2 got { result.Count()}");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SelectAll_NoAdministration()
        {
            var dbContext = new TestDataContextFactory().Create();
            Mock<IUserContext> contextMock = new Mock<IUserContext>();

            contextMock.SetupGet(u => u.AdministrationID).Returns((int?)null);

            var repository = new ReportsRepository(dbContext, contextMock.Object);

            var result = repository.SelectAll();
        }
    }
}