using IdentityServer4.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegiX.IdentityServer.RegiXClientUsers;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TechnoLogica.Mail;
using TechnoLogica.RegiX.IdentityServer.ClientAppCredentials;

namespace RegiX.IdentityServer.ClientAppCredentials.Tests
{
    [TestClass]
    public class ClientProfileServiceTest
    {
        public static RegiXClientContext RegiXClientContext { get; set; }
        public static IConfiguration Configuration { get; set; }

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {

            var config = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json")
               .Build();
            Configuration = config;

            var options = new DbContextOptionsBuilder<RegiXClientContext>()
                  .UseSqlServer(config.GetConnectionString("RegiXClientConnection"))
                  .Options;

            RegiXClientContext regiXClientContext = new RegiXClientContext(options);
            RegiXClientContext = regiXClientContext;

            //var configurationMock = new Mock<IConfiguration>();
            //Configuration = configurationMock.Object;
        }

        [DataTestMethod]
        [DataRow("tl_regix3_local")]
        [DataRow("tl_regix3_administration")]
        public async Task FindByUsernameTest(string username)
        {
            var clientProfileService = new ClientProfileService(RegiXClientContext, Configuration, new MailService(Configuration));
            var userInfo = await clientProfileService.FindByUsername("idsrv", username);
            Assert.IsTrue(username.Equals(userInfo?.Username));
        }

        [DataTestMethod]
        [DataRow("tl_regix3_local", "tl_regix3_local_password")]
        [DataRow("tl_regix3_administration", "tl_regix3_administration_password")]
        [DataRow("tl_regix3_basic", "tl_regix3_basic_password")]
        public async Task ValidateCredentialsTest(string username, string password)
        {
            var clientProfileService = new ClientProfileService(RegiXClientContext, Configuration, new MailService(Configuration));
            var isValid = await clientProfileService.ValidateCredentials("idsrv", username, password);
            Assert.IsTrue(isValid);
        }

        [DataTestMethod]
        [DataRow("1061")]
        [DataRow("1062")]
        [DataRow("1063")]
        public async Task IsActiveAsync(string subjectId)
        {
            var context = new IsActiveContext(new TestPrincipal(new Claim("sub", subjectId)), new Client() { ClientId = "regixadminangular" }, "test");
            var clientProfileService = new ClientProfileService(RegiXClientContext, Configuration, new MailService(Configuration));
            await clientProfileService.IsActiveAsync(context);
            Assert.IsTrue(context.IsActive);
        }

        [DataTestMethod]
        [DataRow("1061", "0", "Local Regix3 User")]
        [DataRow("1062", "34", "Local Regix3 Administration")]
        [DataRow("1063", "34", "Local Regix3 Basic")]
        public async Task GetProfileDataAsync(string subjectId, string expectedAdministrationId, string expectedFullName)
        {
            var context =
                new ProfileDataRequestContext()
                {
                    Client = new Client() { ClientId = "regixadminangular" },
                    Caller = "test",
                    Subject = new TestPrincipal(new Claim("sub", subjectId))
                };
            var clientProfileService = new ClientProfileService(RegiXClientContext, Configuration, new MailService(Configuration));
            await clientProfileService.GetProfileDataAsync(context);
            Assert.IsTrue(context.IssuedClaims.Where(c => c.Type == "AdministrationID").FirstOrDefault().Value.Equals(expectedAdministrationId));
            Assert.IsTrue(context.IssuedClaims.Where(c => c.Type == "FullName").FirstOrDefault().Value.Equals(expectedFullName));
        }

        //[TestMethod]
        public async Task CreateUserTest()
        {
            var clientProfileService = new ClientProfileService(RegiXClientContext, Configuration, new MailService(Configuration));
            var additoinalParameters = new Dictionary<string, string>();
            additoinalParameters.Add("AuthorityID", "0");
            await clientProfileService.RegisterUser("EDeliveryHandler", "new user", "newUserName", "new@user.com", "asdf", additoinalParameters);
        }
    }

    public class TestPrincipal : ClaimsPrincipal
    {
        public TestPrincipal(params Claim[] claims) : base(new TestIdentity(claims))
        {
        }
    }

    public class TestIdentity : ClaimsIdentity
    {
        public TestIdentity(params Claim[] claims) : base(claims)
        {
        }
    }
}
