using Nest;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Net;
using TechnoLogica.RegiX.Adapters.Common.DataContracts;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Adapters.Common.ObjectMapping;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.DataContracts.Parameter;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.Common.Utils;
using TechnoLogica.RegiX.WebServiceAdapterService;

namespace TechnoLogica.RegiX.DaeuReportsAdapter.AdapterService
{
    [Export(typeof(IAdapterService))]
    [ExportFullName(typeof(DaeuReportsAdapter), typeof(IAdapterService))]
    [ExportSimpleName(typeof(DaeuReportsAdapter), typeof(IAdapterService))]
    public class DaeuReportsAdapter : WebServiceBaseAdapterService, IDaeuReportsAdapter
    {
        public DaeuReportsAdapter()
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }

        public override string CheckRegisterConnection()
        {
            try
            {
                var webServiceUrl = this.GetParameters().ParameterList.Where(p => p.Key == Constants.WebServiceUrlParameterKeyName).FirstOrDefault();
                if (webServiceUrl != null && !String.IsNullOrEmpty(webServiceUrl.CurrentValue))
                {
                    var myRequest = (HttpWebRequest)WebRequest.Create(webServiceUrl.CurrentValue);

                    String username = elasticUser.Value;
                    String password = elasticPassword.Value;
                    String encoded = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(username + ":" + password));
                    myRequest.Headers.Add("Authorization", "Basic " + encoded);

                    var response = (HttpWebResponse)myRequest.GetResponse();

                    //if (response.StatusCode == HttpStatusCode.OK)
                    //{
                    //  it's at least in some way responsive
                    //  but may be internally broken
                    //  as you could find out if you called one of the methods for real
                    return Constants.ConnectionOk;
                    //}
                }
                else
                {
                    return Constants.WebServiceUrlNotSet;
                }
            }
            catch (Exception ex)
            {
                return String.Format(Constants.ConnectionException, ex.Message);
            }
        }



        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(DaeuReportsAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> WebServiceUrl =
        new ParameterInfo<string>("http://regix2-sqlnode2.regix.tlogica.com:9200/")
        {
            Key = Constants.WebServiceUrlParameterKeyName,
            Description = "Connection String for Elasticsearch Service",
            OwnerAssembly = typeof(DaeuReportsAdapter).Assembly
        };

        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(DaeuReportsAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> elasticUser =
        new ParameterInfo<string>("elastic")
        {
            Key = "ElasticUser",
            Description = "Username for Elasticsearch Service",
            OwnerAssembly = typeof(DaeuReportsAdapter).Assembly
        };

        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(DaeuReportsAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> elasticPassword =
        new ParameterInfo<string>("elasticPassword")
        {
            Key = "ElasticPassword",
            Description = "Password for Elasticsearch Service",
            OwnerAssembly = typeof(DaeuReportsAdapter).Assembly
        };

        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(DaeuReportsAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> MaxAllowedResults =
        new ParameterInfo<string>("50")
        {
            Key = "maxAllowedResults",
            Description = "Maximum allowed results",
            OwnerAssembly = typeof(DaeuReportsAdapter).Assembly
        };

        public CommonSignedResponse<SearchByIdentifierRequestType, SearchByIdentifierResponse> SearchByIdentifier(SearchByIdentifierRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
            try
            {
                var connectionSettings = new ConnectionSettings(new Uri(WebServiceUrl.Value))
                    .BasicAuthentication(elasticUser.Value, elasticPassword.Value)
                    .DefaultMappingFor<APIServiceCall>(
                    i => i
                        .IndexName("regix-log-*")
                    )
                    .EnableDebugMode()
                    .PrettyJson()
                    .RequestTimeout(TimeSpan.FromMinutes(2));

                var client = new ElasticClient(connectionSettings);

                var filters = new List<Func<QueryContainerDescriptor<APIServiceCall>, QueryContainer>>();
                filters.Add(f => f.MatchPhrase(ph => ph.Field(a => a.Identifier).Query(argument.Identifier)));
                filters.Add(f => f.MatchPhrase(ph => ph.Field(a => a.IdentifierType).Query(argument.IdentifierType.ToString())));
                filters.Add(f => f.Bool(b => b.MustNot(m => m.Exists(ma => ma.Field(a => a.Hidden)))));
                if (argument.DateFromSpecified)
                {
                    filters.Add(f => f.DateRange(d => d.Field(a => a.StartTime).GreaterThan(argument.DateFrom)));
                }
                if (argument.DateToSpecified)
                {
                    filters.Add(f => f.DateRange(d => d.Field(a => a.StartTime).LessThan(argument.DateTo.AddDays(1))));
                }
                var searchResults =
                    client.Search<APIServiceCall>(
                        sc => sc.Query(
                            q => q.Bool(
                                sel => sel.Filter(
                                    filters.ToArray()
                                )
                            )
                        )
                        .Sort(sd => sd.Descending(f => f.StartTime))
                        .Size(Convert.ToInt32(MaxAllowedResults.Value))
                    );
                QueryResult result = new QueryResult()
                {
                    ApiServiceCalls = searchResults.Documents.Cast<APIServiceCall>().ToArray(),
                    MaxAllowedResults = Convert.ToInt32(MaxAllowedResults.Value),
                    TotalResults = searchResults.Total,
                };
                ObjectMapper<QueryResult, SearchByIdentifierResponse> mapper = CreateSearchByIdentifierMapper(accessMatrix);
                SearchByIdentifierResponse response = new SearchByIdentifierResponse();
                mapper.Map(result, response);
                return
                     SigningUtils.CreateAndSign(
                         argument,
                         response,
                         accessMatrix,
                         aditionalParameters
                     );
            }
            catch (Exception ex)
            {
                LogError(aditionalParameters, ex, new { Guid = id });
                throw ex;
            }
        }

        private ObjectMapper<QueryResult, SearchByIdentifierResponse> CreateSearchByIdentifierMapper(AccessMatrix accessMatrix)
        {
            ObjectMapper<QueryResult, SearchByIdentifierResponse> mapper = new ObjectMapper<QueryResult, SearchByIdentifierResponse>(accessMatrix);
            mapper.AddPropertyMap((o) => o.MaxAllowedResults, (c) => c.MaxAllowedResults);
            mapper.AddPropertyMap((o) => o.TotalResults, (c) => c.TotalResults);
            mapper.AddCollectionMap<QueryResult>(o => o.ExecutedCalls, c => c.ApiServiceCalls);
            mapper.AddPropertyMap((o) => o.ExecutedCalls[0].ApiServiceCallID, (c) => c.ApiServiceCalls[0].ApiServiceCallId);
            mapper.AddFunctionMap<APIServiceCall, DateTime>((o) => o.ExecutedCalls[0].StartTime, (a) => a.StartTime.ToLocalTime());
            mapper.AddPropertyMap((o) => o.ExecutedCalls[0].ReportName, (c) => c.ApiServiceCalls[0].ReportName);
            mapper.AddPropertyMap((o) => o.ExecutedCalls[0].LawReason, (c) => c.ApiServiceCalls[0].ContextLawReason);
            mapper.AddPropertyMap((o) => o.ExecutedCalls[0].ConsumerAdministration, (c) => c.ApiServiceCalls[0].ConsumerAdministration);
            mapper.AddPropertyMap((o) => o.ExecutedCalls[0].Consumer, (c) => c.ApiServiceCalls[0].Consumer);
            mapper.AddPropertyMap((o) => o.ExecutedCalls[0].Producer, (c) => c.ApiServiceCalls[0].Producer);
            mapper.AddPropertyMap((o) => o.ExecutedCalls[0].ProducerAdministration, (c) => c.ApiServiceCalls[0].ProducerAdministration);
            return mapper;
        }
    }
}
