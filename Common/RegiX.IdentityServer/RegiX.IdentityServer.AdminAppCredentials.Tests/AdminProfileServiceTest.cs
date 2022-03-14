using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TechnoLogica.Mail;
using TechnoLogica.RegiX.IdentityServer.AdminAppCredentials;

namespace RegiX.IdentityServer.AdminAppCredentials.Tests
{
    [TestClass]
    public class AdminProfileServiceTest
    {
        public static RegiXAdminContext RegiXAdminContext { get; set; }
        public static IConfiguration Configuration { get; set; }

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            var config = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json")
               .Build();

            Configuration = config;

            var options = new DbContextOptionsBuilder<RegiXAdminContext>()
                  .UseSqlServer(config.GetConnectionString("RegiXAdminConnection"))
                  .Options;

            RegiXAdminContext regiXAdminContext = new RegiXAdminContext(options);
            RegiXAdminContext = regiXAdminContext;


        }

        [TestMethod]
        public  void CreateUserTest()
        {
            var adminProfileService = new AdminProfileService(RegiXAdminContext, Configuration, new MailService(Configuration));
            var additoinalParameters = new Dictionary<string, object>();
            //additoinalParameters.Add("AuthorityID", 0);
             adminProfileService.RegisterUser(null, "new user", "newUserName", "new@user.com", "asdf", null);
        }
    }
}
