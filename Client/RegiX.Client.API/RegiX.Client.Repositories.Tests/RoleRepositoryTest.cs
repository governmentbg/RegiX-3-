using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TechnoLogica.RegiX.Client.Repositories;
using TechnoLogica.RegiX.Client.Repositories.Impl;

namespace RegiX.Client.Repositories.Tests
{

    [TestClass]
    public class RoleRepositoryTest
    {
        [TestMethod]
        public void SelectAll_ExistingRole()
        {
            var dbContext = new TestDataContextFactory().Create();

            Mock<IUserContext> contextMock = new Mock<IUserContext>();
            //contextMock.SetupGet(u => u.RoleID).Returns(new int[2]);//number of returned roles (currently we have two for authority #1)
            contextMock.SetupGet(u => u.AdministrationID).Returns(1);

            var repository = new RolesRepository(dbContext, contextMock.Object);
            var result = repository.SelectAll();

            Assert.IsTrue(result.Count() == 2, $"Expected 2 got { result.Count()}");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SelectAll_NoRole()
        {
            var dbContext = new TestDataContextFactory().Create();

            Mock<IUserContext> contextMock = new Mock<IUserContext>();
            contextMock.SetupGet(u => u.AdministrationID).Returns((int?)null);

            var repository = new RolesRepository(dbContext, contextMock.Object);
            var result = repository.SelectAll();
        }
    }
}