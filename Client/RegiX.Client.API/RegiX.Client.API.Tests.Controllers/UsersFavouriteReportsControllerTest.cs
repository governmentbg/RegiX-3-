using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNet.OData.Formatter;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoLogica.RegiX.Client.Services.Contracts;

namespace TechnoLogica.RegiX.Client.API.Tests.Controllers
{
    [TestClass]
    public class UsersFavouriteReportsControllerTest
    {
        //[TestMethod]
        //public async Task TestMethod1()
        //{
        //    var webHostBuilder =
        //          new WebHostBuilder()
        //                .UseEnvironment("Test") // You can set the environment you want (development, staging, production)
        //                .UseStartup<TestStartup>(); // Startup class of your web app project

        //    using (var server = new TestServer(webHostBuilder))
        //    using (var client = server.CreateClient())
        //    {
        //        var result = await client.GetAsync("/api/users-favourite-reports/2");
        //    }
        //}
    }

    public class TestStartup
    {
        private const int Major = 1;
        private const int Minor = 0;
        private const string MediaTypeHeader = "application/prs.mock-odata";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureTestServices(IServiceCollection services)
        {
            var mock = new Mock<IUserFavouriteReportService>();
            services.AddTransient<IUserFavouriteReportService>( s => mock.Object);
            services.AddMvc();
            services.AddApiVersioning(
               o =>
               {
                    //o.Conventions.Controller<UserController>().HasApiVersion(1, 0);
                    o.ReportApiVersions = true;
                   o.AssumeDefaultVersionWhenUnspecified = true;
                   o.DefaultApiVersion = new ApiVersion(Major, Minor);
                   o.ApiVersionReader = new UrlSegmentApiVersionReader();
               }
           );

            services.AddAuthorization();
            services
                 .AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme);

            services.AddOData();
            services.AddODataQueryFilter();

            //configuration to make swagger work with odata
            services.AddMvc(op =>
            {
                foreach (var formatter in op.OutputFormatters
                    .OfType<ODataOutputFormatter>()
                    .Where(it => !it.SupportedMediaTypes.Any()))
                {
                    formatter.SupportedMediaTypes.Add(
                        new MediaTypeHeaderValue(MediaTypeHeader));
                }
                foreach (var formatter in op.InputFormatters
                    .OfType<ODataInputFormatter>()
                    .Where(it => !it.SupportedMediaTypes.Any()))
                {
                    formatter.SupportedMediaTypes.Add(
                        new MediaTypeHeaderValue(MediaTypeHeader));
                }
            });
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseAuthentication();


            app.UseMvc(
                routeBuilder =>
                {
                    routeBuilder.EnableDependencyInjection();
                }
            );
        }
    }
}
