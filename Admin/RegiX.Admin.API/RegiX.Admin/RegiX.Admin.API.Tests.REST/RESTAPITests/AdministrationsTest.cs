using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Net.Http;

namespace TechnoLogica.RegiX.Admin.API.Tests.REST.RESTAPITests
{
    [TestClass]
    public class AdministrationsTest
    {
        //    public static string TargetAddress { get; set; }
        //    public static HttpClient HttpClient { get; set; }

        //    [ClassInitialize]
        //    public static void Initialize(TestContext context)
        //    {
        //        var config = new ConfigurationBuilder()
        //            .AddJsonFile("appsettings.json")
        //            .Build();
        //        TargetAddress = config.GetValue<string>("TargetAddress");
        //        HttpClient = new HttpClient();
        //    }


        //    [TestMethod]
        //    public void GetAdministrations()
        //    {
        //        using (var response = HttpClient.GetAsync($"{TargetAddress}administrations"))
        //        {
        //            var resultCode = response.Result.StatusCode;
        //            string apiResponse = response.Result.Content.ReadAsStringAsync().Result;
        //            Assert.IsTrue(
        //                resultCode == HttpStatusCode.OK && 
        //                apiResponse.Length > 0);
        //        }
        //    }
    }
}
