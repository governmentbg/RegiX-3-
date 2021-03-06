using ReportExecution;
using System;
using System.Runtime.CompilerServices;
using System.ServiceModel;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using RegiX.Info.Services.Contracts;
using RegiX.Info.Services.Helpers;

namespace RegiX.Info.Services.Services
{
    public class ReportingService : IReportingService
    {
        private readonly IOptions<ReportSettings> settings;
       
        const string ReportPathReport = "/RegiX1/Report1";
        const string ReportPathFullReport = "/RegiX1/ConsumerRequestReport";

        const string ReportWidth = "8.5in";
        const string ReportHeight = "11in";
        const string ReportFormat = "PDF";  // Other options include WORDOPENXML and EXCELOPENXML
        const string HistoryId = null;

        public ReportingService(IOptions<ReportSettings> settings)
        {
            this.settings = settings;
        }

        public async Task<byte[]> RunReport(string ProfileId)
        {
            var rs = CreateClient(settings);
            var trustedHeader = new TrustedUserHeader();

            LoadReportResponse loadReponse = await LoadReport(rs, trustedHeader, ReportPathReport);


            var reportParameters = new[]
            {
                new ParameterValue() { Name = "ProfileId", Value = ProfileId }
            };
            await AddParametersToTheReport(rs, loadReponse.ExecutionHeader, trustedHeader, reportParameters);

            RenderResponse response = await RenderReportByteArrayAsync(loadReponse.ExecutionHeader, trustedHeader, rs, ReportFormat, ReportWidth, ReportHeight);

            return response.Result;
        }

        public async Task<byte[]> RunFullReport(string userId, string ConsumerRequestId)
        {
            var rs = CreateClient(settings);
            var trustedHeader = new TrustedUserHeader();

            LoadReportResponse loadReponse = await LoadReport(rs, trustedHeader, ReportPathFullReport);


            var reportParameters = new[]
            {
                new ParameterValue() { Name = "UserId", Value = userId }, 
                new ParameterValue() { Name = "ConsumerRequest", Value = ConsumerRequestId }
            };
            await AddParametersToTheReport(rs, loadReponse.ExecutionHeader, trustedHeader, reportParameters);

            RenderResponse response = await RenderReportByteArrayAsync(loadReponse.ExecutionHeader, trustedHeader, rs, ReportFormat, ReportWidth, ReportHeight);

            return response.Result;
        }

        private static async Task<LoadReportResponse> LoadReport(ReportExecutionServiceSoapClient rs, TrustedUserHeader trustedHeader,string ReportPath)
        {
            // Get the report and set the execution header.
            // Failure to set the execution header will result in this error: "The session identifier is missing. A session identifier is required for this operation."
            // See https://social.msdn.microsoft.com/Forums/sqlserver/en-US/17199edb-5c63-4815-8f86-917f09809504/executionheadervalue-missing-from-reportexecutionservicesoapclient
            LoadReportResponse loadReponse = await rs.LoadReportAsync(trustedHeader, ReportPath, HistoryId);

            return loadReponse;
        }

        private static async Task<SetExecutionParametersResponse> AddParametersToTheReport(ReportExecutionServiceSoapClient rs, ExecutionHeader executionHeader, TrustedUserHeader trustedHeader,ParameterValue[] reportParameters)
        {
            SetExecutionParametersResponse setParamsResponse = await rs.SetExecutionParametersAsync(executionHeader, trustedHeader, reportParameters, "en-US");

            return setParamsResponse;
        }

        private static async Task<RenderResponse> RenderReportByteArrayAsync(ExecutionHeader execHeader, TrustedUserHeader trustedHeader,
            ReportExecutionServiceSoapClient rs, string format, string width, string height)
        {
            string deviceInfo = String.Format("<DeviceInfo><PageHeight>{0}</PageHeight><PageWidth>{1}</PageWidth><PrintDpiX>300</PrintDpiX><PrintDpiY>300</PrintDpiY></DeviceInfo>", height, width);

            var renderRequest = new RenderRequest(execHeader, trustedHeader, format, deviceInfo);

            //get report bytes
            RenderResponse response = await rs.RenderAsync(renderRequest);
            return response;
        }

        private static ReportExecutionServiceSoapClient CreateClient(IOptions<ReportSettings> settings)
        {
            var rsBinding = new BasicHttpBinding
            {
                Security =
                {
                    Mode = BasicHttpSecurityMode.TransportCredentialOnly,
                    Transport = {ClientCredentialType = HttpClientCredentialType.Ntlm}
                },
                MaxBufferPoolSize = 20000000,
                MaxBufferSize = 20000000,
                MaxReceivedMessageSize = 20000000
            };


            // So we can download reports bigger than 64 KBytes
            // See https://stackoverflow.com/questions/884235/wcf-how-to-increase-message-size-quota

            var rsEndpointAddress = new EndpointAddress(settings.Value.Endpoint);
            var rsClient = new ReportExecutionServiceSoapClient(rsBinding, rsEndpointAddress);

            if (
                !string.IsNullOrEmpty(settings?.Value?.ActiveDirectoryCredentials?.UserName) &&
                !string.IsNullOrEmpty(settings?.Value?.ActiveDirectoryCredentials?.Password) &&
                !string.IsNullOrEmpty(settings?.Value?.ActiveDirectoryCredentials?.Domain))
            {
                // Set user name and password
                rsClient.ClientCredentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation;
                rsClient.ClientCredentials.Windows.ClientCredential = new System.Net.NetworkCredential(
                    settings.Value.ActiveDirectoryCredentials.UserName,
                    settings.Value.ActiveDirectoryCredentials.Password,
                    settings.Value.ActiveDirectoryCredentials.Domain);
            }


            return rsClient;
        }
    }
}