

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RegiX.Info.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class NotifyChangedController : ControllerBase
    {
        private IServiceProvider Services { get; set; }
        private ILogger<NotifyChangedController> Logger { get; set; }
        // Should be one...
        public NotifyChangedController(
            ILogger<NotifyChangedController> logger,
            IServiceProvider services)
        {
            Services = services;
            Logger = logger;
        }

        [HttpGet("")]
        public async Task Get()
        {
            var scope = Services.CreateScope();
            _ = Task.Run(async () =>
            {
                using (scope)
                {
                    var adapterInformationLoader =
                        scope.ServiceProvider
                            .GetRequiredService<IAdapterInformationLoader>();

                    await adapterInformationLoader.Load();
                }
            });
        }
    }
}
