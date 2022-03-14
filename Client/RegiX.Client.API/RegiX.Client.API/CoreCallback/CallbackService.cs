using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnoLogica.RegiX.Client.Services.Contracts;
using TechnoLogica.RegiX.Common.Utils;
using TechnoLogica.RegiX.Core.Interfaces.TransportObjects;

namespace TechnoLogica.RegiX.Client.API.CoreCallback
{
    public class CallbackService : ICallbackService
    {
        private ILogger<CallbackService> Logger { get; set; }
        private readonly IServiceScopeFactory scopeFactory;

        public CallbackService(ILogger<CallbackService> logger,
            IServiceScopeFactory scopeFactory)
        {
            Logger = logger;
            this.scopeFactory = scopeFactory;
        }

        public Task<ResultWrapper> CheckResultAsync(ServiceCheckResultWrapper argument)
        {
            throw new NotImplementedException();
        }

        public Task<ResultWrapper> ExecuteAsync(RequestWrapper request)
        {
            throw new NotImplementedException();
        }

        public async Task ExecuteCallbackAsync(ResultWrapper request)
        {
            Logger.LogInformation($"Callback received for ServiceCallID: {request?.Result?.ServiceCallID}");
            using (IServiceScope scope = scopeFactory.CreateScope())
            {
                var result = request.Result;
                var asyncReportExecutionsService = scope.ServiceProvider.GetRequiredService<IAsyncReportExecutionsService>();
                asyncReportExecutionsService.UpdateRequest(
                    result.ServiceCallID,
                    result.VerificationCode,
                    result.XmlSerialize());
            }
        }

        public Task<ResultWrapper> AcknowledgeResultReceivedAsync(ServiceCheckResultWrapper argument)
        {
            throw new NotImplementedException();
        }
    }
}
