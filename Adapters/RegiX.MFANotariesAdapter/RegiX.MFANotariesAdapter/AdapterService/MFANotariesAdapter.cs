using System;
using System.ComponentModel.Composition;
using System.Data.Common;
using System.ServiceModel;
using TechnoLogica.RegiX.Adapters.Common;
using TechnoLogica.RegiX.Adapters.Common.DataContracts;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.DataContracts.Parameter;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.Common.Utils;
using TechnoLogica.RegiX.MFANotariesAdapter.Helpers;
using TechnoLogica.RegiX.NpgsqlAdapterService;

namespace TechnoLogica.RegiX.MFANotariesAdapter.AdapterService
{
    [Export(typeof(IAdapterService))]
    [ExportFullName(typeof(MFANotariesAdapter), typeof(IAdapterService))]
    [ExportSimpleName(typeof(MFANotariesAdapter), typeof(IAdapterService))]
    public class MFANotariesAdapter : NpgsqlBaseAdapterService, IMFANotariesAdapter, IAdapterService
    {
        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(MFANotariesAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> ConnectionString =
            new ParameterInfo<string>("Host=172.31.12.64;Database=aises;Username=aises;Password=ais3s;Timeout=1024")
            {
                Key = Constants.ConnectionStringParameterKeyName,
                Description = "Connection string",
                OwnerAssembly = typeof(MFANotariesAdapter).Assembly
            };

        public CommonSignedResponse<SendNotaryDocumentsRequest, SendNotaryDocumentsResponse> SendNotaryDocuments(SendNotaryDocumentsRequest argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            var request = argument.XmlSerialize();
            LogData(aditionalParameters, new { Request = request, Guid = id });           
            try
            {
                var result = ProcessAsynchronous<SendNotaryDocumentsRequest, SendNotaryDocumentsResponse>(argument, accessMatrix, aditionalParameters);
                return result;
            }
            catch (Exception ex)
            {
                LogError(aditionalParameters, ex, new { Guid = id });
                throw ex;
            }

            // For testing purposes
            //var serializedRequestData = new OperationRequest()
            //{
            //    Request = argument,
            //    AccessMatrix = accessMatrix,
            //    AdapterAdditionalParameters = aditionalParameters,
            //}.XmlSerialize();
            //var dbUtils = new NpgsqlDbUtils("Host=172.31.12.64;Database=aises;Username=aises;Password=ais3s;Timeout=1024");
            //DbConnection connection = dbUtils.CreateDbConnection();

            //try
            //{
            //    connection.Open();
            //    dbUtils.InsertDataFromRequest(connection, argument, aditionalParameters, serializedRequestData);
            //    return new CommonSignedResponse<SendNotaryDocumentsRequest, SendNotaryDocumentsResponse>();
            //}
            //finally
            //{
            //    connection.Close();
            //}
        }

        public override bool SendResultToCore(ServiceResultData result, string callbackURL)
        {
            // TODO: logging
            // TODO: in parameters
            try
            {
                var maxBytes = 25 * 1024 * 1024; // 25 MB
                var binding = new BasicHttpBinding()
                {
                    MaxReceivedMessageSize = maxBytes,
                    MaxBufferSize = maxBytes
                };

                binding.ReaderQuotas.MaxDepth = 64; // Default value is 3
                binding.ReaderQuotas.MaxStringContentLength = int.MaxValue;
                binding.ReaderQuotas.MaxArrayLength = int.MaxValue;
                binding.ReaderQuotas.MaxBytesPerRead = int.MaxValue;
                binding.ReaderQuotas.MaxNameTableCharCount = int.MaxValue;

                //binding.Security.Mode = BasicHttpSecurityMode.Transport;
                //binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.None;

                // TODO: 
                //var message = DateTime.Now.ToString() + " " + "RegiXCallbackEndpoint: " + ParametersInfoDefinitions.RegiXCallbackEndpoint.Value;
                //System.IO.File.AppendAllText("customlog.txt", message + Environment.NewLine);

                var remoteAddress = new EndpointAddress(ParametersInfoDefinitions.RegiXCallbackEndpoint.Value);
                var regiXServerChannel = new ChannelFactory<IReceiveResult>(binding, remoteAddress).CreateChannel();

                //log.Debug($"Sending result to core: {ParametersInfoDefinitions.RegiXCallbackEndpoint.Value}");
                regiXServerChannel.ReceiveResult(result, callbackURL);
                //log.Debug("Result send successfully");
                return true;
            }
            catch (Exception ex)
            {
                //var message = DateTime.Now.ToString() + " " + ex.GetType().FullName + ":" + ex.Message;
                //System.IO.File.AppendAllText("customlog.txt", message + Environment.NewLine);
                
                //log.Error("Error while sending result to core", ex);
                return false;
            }
        }
    }
}