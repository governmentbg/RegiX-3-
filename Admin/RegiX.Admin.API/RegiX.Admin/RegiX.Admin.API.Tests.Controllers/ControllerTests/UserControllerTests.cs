using TechnoLogica.RegiX.Admin.API.Controllers;
using TechnoLogica.RegiX.Admin.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using System.Collections.Generic;
using TechnoLogica.RegiX.Admin.API.Controllers.V1;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Authorization;

namespace TechnoLogica.RegiX.Admin.API.Tests.Controllers.ControllerTests
{
    [TestClass]
    public class UserControllerTests : TestBase
    {
        ////NOTE: should be replaced by an interface
        //UserController _controller;

        //public UserControllerTests() : base()
        //{
        //    var serviceProvider = _services.BuildServiceProvider();
        //    var businessService = serviceProvider.GetRequiredService<IUserService>();
        //    _controller = new UserController(businessService);
        //}

        //[TestMethod]
        //public async Task CreateUser_Nominal_OK()
        //{
        //    //Simple test
        //    var user = _controller.Post(new UserInDto
        //    {
        //        UserName = "testUsername",
        //        Password = "wdwdwdf14taq13",
        //        Email = "test@abv.bg",
        //        Name = "testov"
        //    });

        //    Assert.IsNotNull(user);
        //}


        [DataTestMethod]
        [DynamicData(nameof(GetControllers), DynamicDataSourceType.Method)]
        public void CheckAuthorizeAttribute(Type controller)
        {
            Assert.IsTrue(controller.CustomAttributes.Any(c => c.AttributeType == typeof(AuthorizeAttribute)));
        }

        public static IEnumerable<object[]> GetControllers()
        {
            return
                typeof(AdapterOperationController)
                .Assembly
                .GetTypes()
                .Where(c => typeof(ControllerBase).IsAssignableFrom(c))
                .Select( c=> new object[] { c });
        }
    }
}
