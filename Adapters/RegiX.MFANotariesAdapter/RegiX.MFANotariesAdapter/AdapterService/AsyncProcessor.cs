using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechnoLogica.RegiX.Adapters.Common.Interfaces;
using TechnoLogica.RegiX.Adapters.Common.Utils;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.Common.Utils;
using TechnoLogica.RegiX.MFANotariesAdapter.Helpers;

namespace TechnoLogica.RegiX.MFANotariesAdapter.AdapterService
{
    [Export(typeof(IAsynchronousProcessor<MFANotariesAdapter>))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class AsyncProcessor : IAsynchronousProcessor<MFANotariesAdapter>
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly NpgsqlDbUtils dbUtils;

        private CancellationTokenSource CancellationTokenSource { get; set; }
        private CancellationToken CancellationToken { get; set; }

        private CancellationTokenSource CancellationRetriesTokenSource { get; set; }
        private CancellationToken CancellationRetriesToken { get; set; }

        public MFANotariesAdapter AdapterService { get; set; }

        public AsyncProcessor()
        {
            log.Info("Стартиране на AsyncProcessor-а");

            AdapterService = Composition.CompositionContainer.GetExportedValue<IAdapterService>(typeof(MFANotariesAdapter).FullName) as MFANotariesAdapter;
            dbUtils = CreateNpgsqlDbUtils();

            // Засега не се ползват
            //CancellationTokenSource = new CancellationTokenSource();
            //CancellationToken = CancellationTokenSource.Token;
            //Task.Run(ProcessResults, CancellationToken);

            CancellationRetriesTokenSource = new CancellationTokenSource();
            CancellationRetriesToken = CancellationRetriesTokenSource.Token;
            Task.Run(ProcessRetries, CancellationRetriesToken);
        }

        private void TestSingeCall()
        {
            DbConnection connection = dbUtils.CreateDbConnection();
            try
            {
                SendResultToSender(connection);
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
            finally
            {
                connection.Close();
            }
        }

        private Action ProcessRetries
        {
            get =>
                async () =>
                {
                    DbConnection connection = dbUtils.CreateDbConnection();
                    while (true)
                    {
                        await Task.Delay(30 * 1000, CancellationRetriesToken);
                        if (CancellationRetriesToken.IsCancellationRequested)
                        {
                            break;
                        }

                        try
                        {
                            SendResultToSender(connection);
                        }
                        catch (Exception ex)
                        {
                            log.Error(ex);
                        }
                        finally
                        {
                            connection.Close();
                        }
                    }
                };
        }

        private void SendResultToSender(DbConnection connection)
        {
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }

            List<CallResult> queryResult = dbUtils.GetCallResult(connection);

            log.Debug($"Retry query returned {queryResult.Count} results");

            foreach (var persistedResult in queryResult)
            {
                var apiServiceCallId = persistedResult.ApiServiceCallId;
                var verificationCode = persistedResult.VerificationCode;
                var callbackUrl = persistedResult.CallbackUrl;

                try
                {
                    var data = persistedResult.RawResult.XmlDeserialize<ServiceResultData>();
                    var success = AdapterService.SendResultToCore(data, callbackUrl);
                    if (success)
                    {
                        dbUtils.RemovePersistance(connection, apiServiceCallId, verificationCode);
                    }
                    else
                    {
                        dbUtils.IncreaseRetryCount(connection, apiServiceCallId, verificationCode);
                    }
                }
                catch (Exception ex)
                {
                    dbUtils.IncreaseRetryCount(connection, apiServiceCallId, verificationCode);
                    log.Error(ex);
                }
            }
        }

        //private Action ProcessResults
        //{
        //    get =>
        //        async () =>
        //        {
        //            while (true)
        //            {
        //                await Task.Delay(5 * 1000, CancellationToken);
        //                if (CancellationToken.IsCancellationRequested)
        //                {
        //                    break;
        //                }
        //                try
        //                {
        //                    //Търсим такива, които са с произведен резултат, подписан от оператор, със статус Ready и чакат само подпис от адаптер
        //                    List<CallResult> queryResult = new List<CallResult>();
        //                    //select и RAW_REQUEST!!!

        //                    log.Debug($"Query for result returned {queryResult.Count()} results");

        //                    var adapterInterface = typeof(MFANotariesAdapter).GetAdapterServiceInterface();
        //                    foreach (var serviceCall in queryResult)
        //                    {
        //                        var rawRequest = serviceCall.RawRequest.XmlDeserialize<OperationRequest>();
        //                        var operatorSignedResult = serviceCall.RawResult;
        //                        //response-a Ще го имам в CallResult.Response или си го създавам като обект на база статуса в базата данни
        //                        //Обаче резултата ми идва като CommonSignedResponse, как го подавам на CreateAndSign
        //                        var signed = SigningUtils.CreateAndSign(rawRequest.Request, new SendNotaryDocumentsResponse(), rawRequest.AccessMatrix, rawRequest.AdapterAdditionalParameters);
        //                        //окончателния резултат - неподписан от оператор, а само от адаптера.
        //                        var resultData = AdapterService.PrepareResult(signed, rawRequest.AdapterAdditionalParameters);


        //                        //зда запазя resultData в базата в raw_unsigned_result
        //                        //using (var context = new RegiXAdapterConsoleContext())
        //                        //{
        //                        //    var serviceCallObj = context.OperationsPersistance.Where(op => op.Id == serviceCall.Id).SingleOrDefault();
        //                        //    if (serviceCallObj != null)
        //                        //    {
        //                        //        serviceCallObj.RawUnsignedResult = resultData.XmlSerialize();
        //                        //        context.SaveChanges();
        //                        //    }
        //                        //}
        //                    }
        //                }
        //                catch (Exception ex)
        //                {
        //                    log.Error(ex);
        //                }
        //            }
        //        };
        //}

        public CommonSignedResponse<Req, Resp> Process<Req, Resp>(Req request, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters, Resp response = null)
            where Req : class
            where Resp : class
        {
            DbConnection connection = dbUtils.CreateDbConnection();

            var currentRequest = request as SendNotaryDocumentsRequest;
            var serializedRequestData = new OperationRequest()
            {
                Request = currentRequest,
                AccessMatrix = accessMatrix,
                AdapterAdditionalParameters = additionalParameters,
            }.XmlSerialize();

            serializedRequestData = StringHelper.RemoveXmlDeclaration(serializedRequestData);

            try
            {
                connection.Open();
                dbUtils.InsertDataFromRequest(connection, currentRequest, additionalParameters, serializedRequestData);
            }
            finally
            {
                connection.Close();
            }

            return new CommonSignedResponse<Req, Resp>()
            {
                IsReady = false
            };
        }

        public void Dispose()
        {
            // CancellationTokenSource.Cancel();
            CancellationRetriesTokenSource.Cancel();
        }

        private NpgsqlDbUtils CreateNpgsqlDbUtils()
        {
            var result = new NpgsqlDbUtils(MFANotariesAdapter.ConnectionString.Value);
            return result;
        }
    }
}
