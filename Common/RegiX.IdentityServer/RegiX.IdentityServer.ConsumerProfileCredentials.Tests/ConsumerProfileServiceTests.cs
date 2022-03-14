using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegiX.IdentityServer.ConsumerProfileCredentials.Context;
using System.Net.Mail;

namespace RegiX.IdentityServer.ConsumerProfileCredentials.Tests
{
    [TestClass]
    public class ConsumerProfileServiceTests
    {
        public static ConsumerProfilesContext ConsumerProfilesContext { get; set; }

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {

            var config = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json")
               .Build();

            var options = new DbContextOptionsBuilder<ConsumerProfilesContext>()
                  .UseSqlServer(config.GetConnectionString("ConsumerProfilesConnection"))
                  .Options;

            ConsumerProfilesContext consumerProfilesContext = new ConsumerProfilesContext(options);
            ConsumerProfilesContext = consumerProfilesContext;
        }

        [TestMethod]
        public void RegisterUserTest()
        {
            //var clientProfileService = new ConsumerProfileService(RegiXClientContext, Configuration);
            //var userInfo = await clientProfileService.FindByUsername(username);
            //Assert.IsTrue(username.Equals(userInfo?.Username));
        }


        [TestMethod]
        public void PrepareMailBodyTest()
        {
            var newConsumerProfileUserMessage = new MailMessage("from@from.to", "to@from.to");
            newConsumerProfileUserMessage.Subject = string.Format(Resources.ConsumerProfileUserSubejct, "profile_name");
            ConsumerProfileService.PrepareBody(newConsumerProfileUserMessage, Resources.ConsumerProfileUserBody, "email_to", "Profile_name");

        }
    }
}
