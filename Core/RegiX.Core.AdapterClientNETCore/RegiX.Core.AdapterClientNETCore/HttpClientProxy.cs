using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.ComponentModel.Composition.Hosting;
using System.Net.Http;
using TechnoLogica.RegiX.Common.Utils;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.Common.TransportObjects;
using FastMember;
using System.Web;

namespace TechnoLogica.RegiX.Core.AdapterClientNETCore
{
    public class HttpClientProxy<T> : DispatchProxy
    {
        private static CompositionContainer CompositionContainer { get; set; } 
        public static T Create(CompositionContainer compositionContainer)
        {
            CompositionContainer = compositionContainer;

            var proxy = Create<T, HttpClientProxy<T>>();
            return proxy;
        }

        protected override object Invoke(MethodInfo targetMethod, object[] args)
        {
            if (args.Length > 0)
            {
                return ExecutePost(targetMethod, args);
            }
            else
            {
                return ExecuteGet(targetMethod);
            }
        }

        private static object ExecutePost(MethodInfo targetMethod, object[] args)
        {
            var httpClient = CompositionContainer.GetExportedValue<HttpClient<T>>();
            HttpContent httpContent;
            HttpResponseMessage response;
            if (args.Length == 1)
            {
                httpContent = new StringContent(args[0].XmlSerialize(), Encoding.UTF8, "application/xml");
                response = httpClient.PostAsync(targetMethod.Name, httpContent).Result;
                object result = ExtractReturnObect(targetMethod.ReturnType, response);
                return result;
            }
            else if (args.Length == 2 && targetMethod.Name.Equals("SetParameter"))
            {
                var query = HttpUtility.ParseQueryString(string.Empty);
                query["key"] = args[0].ToString();
                query["value"] = args[1].ToString();
                string queryString = query.ToString();
                httpContent = new StringContent("", Encoding.UTF8, "application/xml");
                response = httpClient.PostAsync($"{targetMethod.Name}?{query.ToString()}", httpContent).Result;
                return null;
            }
            else if (args.Length == 3)
            {
                if (targetMethod.Name.Equals("Execute"))
                {
                    var requestWrapper = new RequestWrapper()
                    {
                        Request = args[0] as ServiceRequestData,
                        AccessMatrix = args[1] as AccessMatrix,
                        AdditionalParameters = (args[2] as AdapterAdditionalParameters)?.XmlSerialize().ToXmlElement()
                    };
                    httpContent = new StringContent(requestWrapper.XmlSerialize(), Encoding.UTF8, "application/xml");
                    response = httpClient.PostAsync(targetMethod.Name, httpContent).Result;
                    object result = ExtractReturnObect(targetMethod.ReturnType, response);
                    return result;
                }
                else
                {
                    var requestWrapper = new RequestWrapper()
                    {
                        Request = new Common.TransportObjects.ServiceRequestData()
                        {
                            Argument = args[0].XmlSerialize().ToXmlElement(),
                            Operation = $"{targetMethod.DeclaringType.FullName}.{targetMethod.Name}"
                        },
                        AccessMatrix = args[1] as AccessMatrix,
                        AdditionalParameters = (args[2] as AdapterAdditionalParameters)?.XmlSerialize().ToXmlElement()
                    };
                    httpContent = new StringContent(requestWrapper.XmlSerialize(), Encoding.UTF8, "application/xml");
                    response = httpClient.PostAsync("Execute", httpContent).Result;
                    var serviceResultData = ExtractReturnObect(typeof(ServiceResultData), response) as ServiceResultData;
                    
                    Type commondDataType = targetMethod.ReturnType.GetProperty("Data").PropertyType;
                    TypeAccessor dataAccessor = TypeAccessor.Create(commondDataType);
                    object data = dataAccessor.CreateNew();
                    dataAccessor[data, "Request"] = serviceResultData.Data?.Request.Request.Deserialize(commondDataType.GetGenericArguments()[0]);
                    dataAccessor[data, "Response"] = serviceResultData.Data?.Response.Response.Deserialize(commondDataType.GetGenericArguments()[1]);
                    dataAccessor[data, "Matrix"] = serviceResultData.Data?.Matrix;

                    TypeAccessor returnTypeAccessor = TypeAccessor.Create(targetMethod.ReturnType);
                    object result = returnTypeAccessor.CreateNew();
                    returnTypeAccessor[result, "Signature"] = serviceResultData.Signature;
                    returnTypeAccessor[result, "Data"] = data;
                    returnTypeAccessor[result, "IsReady"] = serviceResultData.IsReady;
                    returnTypeAccessor[result, "VerificationCode"] = serviceResultData.VerificationCode;
                    // returnTypeAccessor[result, "ServiceCallID"] = serviceResultData.ServiceCallID;

                    return result;
                }
            }
            else
            {
                throw new ArgumentException();
            }
        }

        // serviceResultData.Data
        // result.Signature = serviceResultData.Signature;
        // result.Data = Activator.CreateInstance(commondDataType);
        // result.Data.Request = serviceResultData.Data.Request.Request.Deserialize(commondDataType.GetGenericArguments()[0]);
        // result.Data.Response = serviceResultData.Data.Response.Response.Deserialize(commondDataType.GetGenericArguments()[0]);
        // result.Data.Matrix = serviceResultData.Data.Matrix;

        private static object ExecuteGet(MethodInfo targetMethod)
        {
            var httpClient = CompositionContainer.GetExportedValue<HttpClient<T>>();
            HttpResponseMessage response = httpClient.GetAsync(targetMethod.Name).Result;
            return ExtractReturnObect(targetMethod.ReturnType, response);
        }

        private static object ExtractReturnObect(Type resultType, HttpResponseMessage response)
        {
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var resultString = response.Content.ReadAsStringAsync().Result;
                var resultObject = resultString.XmlDeserialize(resultType);
                return resultObject;
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }
}
