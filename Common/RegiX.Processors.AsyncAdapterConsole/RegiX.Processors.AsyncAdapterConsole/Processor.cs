using FastMember;
using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Reflection;
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
using TechnoLogica.RegiX.Processors.AsyncAdapterConsole.DB;

namespace TechnoLogica.RegiX.Processors.AsyncAdapterConsole
{
    [Export(typeof(IAsynchronousProcessor<>))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class Processor<T> : IAsynchronousProcessor<T>
        where T : class, IAsynchronousAdapterService
    {

        /// <summary>
        /// Logger
        /// </summary>
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private CancellationTokenSource CancellationTokenSource { get; set; }
        private CancellationToken CancellationToken { get; set; }

        private CancellationTokenSource CancellationRetriesTokenSource { get; set; }
        private CancellationToken CancellationRetriesToken { get; set; }
        

        public T AdapterService
        {
            get;
            set;
        }

        public Processor()
        {
            AdapterService = Composition.CompositionContainer.GetExportedValue<IAdapterService>(typeof(T).FullName) as T;

            CancellationTokenSource = new CancellationTokenSource();
            CancellationToken = CancellationTokenSource.Token;
            Task.Run(
                ProcessResults, 
                CancellationToken
            );
            CancellationRetriesTokenSource = new CancellationTokenSource();
            CancellationRetriesToken = CancellationRetriesTokenSource.Token;
            Task.Run(
                ProcessRetries,
                CancellationRetriesToken
            );
        }


        private Action ProcessRetries
        {
            get =>
                async () =>
                {
                    while (true)
                    {
                        await Task.Delay(30 * 1000, CancellationToken);
                        if (CancellationRetriesToken.IsCancellationRequested)
                        {
                            break;
                        }
                        try
                        {
                            List<CallResult> queryResult = new List<CallResult>();
                            using (var context = new RegiXAdapterConsoleContext())
                            {
                                // 
                                queryResult =
                                    (from ao in context.AdapterOperations
                                     join rc in context.ReturnedCalls on ao.Id equals rc.AdapterOperationId
                                     join op in context.OperationsPersistance on rc.ApiServiceCallId equals op.ApiServiceCallId
                                     where ao.Contract.Contains(AdapterContractName) &&
                                           op.RawResult != null &&
                                           op.CallbackUrl != null &&
                                           (op.NextRetry == null || DateTime.Now > op.NextRetry)
                                     select new CallResult()
                                     {
                                         Contract = ao.Contract,
                                         Id = op.Id,
                                         RawRequst = op.RawRequst,
                                         CallbackUrl = op.CallbackUrl,
                                         RawResult = op.RawResult
                                     }).ToList();
                            }
                            log.Debug($"Retry query returned {queryResult.Count()} results");
                            foreach (var persistedResult in queryResult)
                            {
                                var success =
                                    AdapterService.SendResultToCore(
                                        persistedResult.RawResult.XmlDeserialize<ServiceResultData>(),
                                        persistedResult.CallbackUrl);

                                using (var context = new RegiXAdapterConsoleContext())
                                {
                                    var persistedOperation = context.OperationsPersistance.Where(op => op.Id == persistedResult.Id).Single();                                    
                                    if (success)
                                    {
                                        context.OperationsPersistance.Remove(persistedOperation);
                                    }
                                    else
                                    {
                                        persistedOperation.RetryCount = persistedOperation.RetryCount.HasValue ? persistedOperation.RetryCount.Value + 1 : 1;
                                        persistedOperation.NextRetry = DateTime.Now.AddMinutes(persistedOperation.RetryCount.Value);
                                    }
                                    context.SaveChanges();
                                }
                                
                            }
                        }
                        catch(Exception ex)
                        {
                            log.Error(ex);
                        }
                    }
                };
        }
        class CallResult
        {
            public string Contract { get; set; }
            public int Id { get; set; }
            public string Response { get; set; }
            public string RawRequst { get; set; }
            public string RawResult { get; set; }
            public string CallbackUrl { get; set; }        
        }

        private string AdapterContractName { get => typeof(T).GetAdapterServiceInterface().FullName; }

        private Action ProcessResults 
        {
            get =>
                async () =>
                {
                    while (true)
                    {
                        await Task.Delay(5 * 1000, CancellationToken);
                        if (CancellationToken.IsCancellationRequested)
                        {
                            break;
                        }
                        try
                        {
                            //retrieve data
                            // AdapterService.ProcessCallback<>();
                            List<CallResult> queryResult = new List<CallResult>();
                            using (var context = new RegiXAdapterConsoleContext())
                            {
                                // 
                                queryResult = 
                                    (from ao in context.AdapterOperations
                                    join rc in context.ReturnedCalls on ao.Id equals rc.AdapterOperationId
                                    join op in context.OperationsPersistance on rc.ApiServiceCallId equals op.ApiServiceCallId
                                    where ao.Contract.Contains(AdapterContractName) &&
                                          op.RawResult == null
                                    select new CallResult()
                                    {
                                        Contract = ao.Contract,
                                        Id = op.Id,
                                        Response = rc.Response,
                                        RawRequst = op.RawRequst,
                                        CallbackUrl = op.CallbackUrl
                                    }).ToList();
                            }
                            log.Debug($"Query for result returned {queryResult.Count()} results");

                            var adapterInterface = typeof(T).GetAdapterServiceInterface();
                            foreach (var serviceCall in queryResult)
                            {
                                //res.Contract
                                var method = adapterInterface.GetMethods().Where(m => serviceCall.Contract.EndsWith($".{m.Name }")).Single();
                                var parameters = method.GetParameters();
                                var requestType = parameters[0].ParameterType; // First argument
                                var responseType = method.ReturnParameter.ParameterType.GenericTypeArguments[1]; //Second generic argument of CommonSignResponse
                                var deserializeType = typeof(OperationRequest<,>).MakeGenericType(requestType, responseType);

                                TypeAccessor operationRequestTA = TypeAccessor.Create(deserializeType);
                                var result = serviceCall.RawRequst.XmlDeserialize(deserializeType);

                                string prepareResultMethodName = "PrepareResult";
                                var prepareresultMethod = AdapterService.GetType().GetMethod(prepareResultMethodName);

                                var createAdnSignMethod =
                                typeof(SigningUtils)
                                .GetMethods()
                                .Single(m =>
                                       m.Name == nameof(SigningUtils.CreateAndSign) &&
                                       m.GetParameters().Length == 4
                                )
                                .MakeGenericMethod(
                                    new Type[] {
                                        requestType,
                                        responseType
                                    }
                                );
                                object commonSignedResponse = createAdnSignMethod.Invoke(
                                    null,
                                    new object[]
                                    {
                                        operationRequestTA[result, "Request"],
                                        serviceCall.Response.XmlDeserialize(responseType),
                                        operationRequestTA[result, "AccessMatrix"],
                                        operationRequestTA[result, "AdapterAdditionalParameters"]
                                    }
                                );
                                var resultData = prepareresultMethod.Invoke(
                                    AdapterService,
                                    new object[] {
                                        commonSignedResponse,
                                        operationRequestTA[result, "AdapterAdditionalParameters"]
                                    }
                                );
                                using (var context = new RegiXAdapterConsoleContext())
                                {
                                    var serviceCallObj = context.OperationsPersistance.Where(op => op.Id == serviceCall.Id).SingleOrDefault();
                                    if (serviceCallObj != null)
                                    {
                                        serviceCallObj.RawUnsignedResult = resultData.XmlSerialize();
                                        context.SaveChanges();
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            log.Error(ex);
                        }
                    }
                };
        }

        public CommonSignedResponse<Req, Resp> Process<Req, Resp>(
            Req request,
            AccessMatrix accessMatrix,
            AdapterAdditionalParameters additionalParameters,
            Resp response = null)
            where Req : class
            where Resp : class
        {
            try
            {
                var serializedRequestData =
                  new OperationRequest<Req, Resp>()
                  {
                      Request = request,
                      AccessMatrix = accessMatrix,
                      AdapterAdditionalParameters = additionalParameters,
                      Response = response
                  }.XmlSerialize();

                string callingMethodName = additionalParameters.ProcessingData.Single(s => s.Key == "OperationName").Value.OuterXml.XmlDeserialize<string>();
                string contractName = $"{typeof(T).GetAdapterServiceInterface().FullName}.{callingMethodName}";

                using (var context = new RegiXAdapterConsoleContext())
                {
                    var adapterOperationID = context.AdapterOperations.Where(ao => ao.Contract == contractName).Select(ao => ao.Id).Single();

                    var operationPersistance = context.OperationsPersistance.Where(o => o.ApiServiceCallId == additionalParameters.ApiServiceCallId).Single();
                    operationPersistance.AdapterOperationId = adapterOperationID;
                    operationPersistance.RawRequst = serializedRequestData;
                    operationPersistance.CallbackUrl = additionalParameters.CallbackURL;

                    context.OperationCalls.Add(
                        new DB.Entities.OperationCalls()
                        {
                            AdapterOperationId = adapterOperationID,
                            RequestXML = request.XmlSerialize(),
                            ResponseXML = response?.XmlSerialize(),
                            StartTime = DateTime.Now,
                            ApiServiceCallId = Convert.ToInt32(additionalParameters.ApiServiceCallId)
                        }
                    );
                    context.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                log.Error(ex);
                throw ex;
            }

            return new CommonSignedResponse<Req, Resp>()
            {
                IsReady = false
            };
        }

        public void Dispose()
        {
            CancellationTokenSource.Cancel();
        }
    }
}
