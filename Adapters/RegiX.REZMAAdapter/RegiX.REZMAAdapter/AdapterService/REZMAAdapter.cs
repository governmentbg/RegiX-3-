using System;
using TechnoLogica.RegiX.Common.ObjectMapping;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Common.Utils;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Adapters.Common.DataContracts;
using TechnoLogica.RegiX.Common.DataContracts.Parameter;
using TechnoLogica.RegiX.Adapters.Common.ObjectMapping;
using TechnoLogica.RegiX.WebServiceAdapterService;
using System.Threading.Tasks;
using System.IO;

namespace TechnoLogica.RegiX.REZMAAdapter.AdapterService
{
    [Export(typeof(IAdapterService))]
    [ExportFullName(typeof(REZMAAdapter), typeof(IAdapterService))]
    [ExportSimpleName(typeof(REZMAAdapter), typeof(IAdapterService))]
    public class REZMAAdapter : SoapServiceBaseAdapterService, IREZMAAdapter, IAdapterService
    {
        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(REZMAAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> WebServiceUrl =
                  new ParameterInfo<string>("http://10.240.3.176:8081/is-regix")
                  {
                      Key = Constants.WebServiceUrlParameterKeyName,
                      Description = "Web Service Url",
                      OwnerAssembly = typeof(REZMAAdapter).Assembly
                  };

        public CommonSignedResponse<CustomsObligationsRequestType, CustomsObligationsResponseType> GetCustomsObligations(CustomsObligationsRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.XmlSerialize(), Guid = id });
            try
            {
                REZMAServiceReference.rezmaobligationsportClient client = new REZMAServiceReference.rezmaobligationsportClient(REZMAServiceReference.rezmaobligationsportClient.EndpointConfiguration.rezma_obligations_portSoap11, WebServiceUrl.Value);
                REZMAServiceReference.CustomsObligationsRequestType serviceRequest = new REZMAServiceReference.CustomsObligationsRequestType()
                {
                    Identifier = argument.Identifier
                };

                Task<REZMAServiceReference.CustomsObligationsResponse> serviceResult = client.CustomsObligationsAsync(serviceRequest);
                Task.WaitAll();

                ObjectMapper<REZMAServiceReference.CustomsObligationsResponseType, CustomsObligationsResponseType> mapper = CreateCustomsObligationsMap(accessMatrix);
                CustomsObligationsResponseType result = new CustomsObligationsResponseType();
                mapper.Map(serviceResult.Result.CustomsObligationsResponse1, result);
                return
                       SigningUtils.CreateAndSign(
                           argument,
                           result,
                           accessMatrix,
                           aditionalParameters
                       );
            }
            catch (Exception ex)
            {
                LogError(aditionalParameters, ex, new { Guid = id });
                File.AppendAllText("C://Regix//AmAdapters//log_errors.txt", GetFullExceptionDetails(ex, true));
                throw ex;
            }
        }
        private static ObjectMapper<REZMAServiceReference.CustomsObligationsResponseType, CustomsObligationsResponseType> CreateCustomsObligationsMap(AccessMatrix accessMatrix)
        {
            ObjectMapper<REZMAServiceReference.CustomsObligationsResponseType, CustomsObligationsResponseType> mapper = new ObjectMapper<REZMAServiceReference.CustomsObligationsResponseType, CustomsObligationsResponseType>(accessMatrix);
            mapper.AddPropertyMap((o) => o.UIN, (c) => c.UIN);
            mapper.AddPropertyMap((o) => o.Name, (c) => c.Name);

            mapper.AddCollectionMap<REZMAServiceReference.CustomsObligationsResponseType>((o) => o.Obligations, c => c.Obligations);

            mapper.AddPropertyMap((o) => o.Obligations[0].CodeMU, (c) => c.Obligations[0].CodeMU);
            mapper.AddPropertyMap((o) => o.Obligations[0].MU, (c) => c.Obligations[0].MU);
            mapper.AddPropertyMap((o) => o.Obligations[0].Document, (c) => c.Obligations[0].Document);
            mapper.AddPropertyMap((o) => o.Obligations[0].DocumentNumber, (c) => c.Obligations[0].DocumentNumber);
            mapper.AddPropertyMap((o) => o.Obligations[0].CreationDate, (c) => c.Obligations[0].CreationDate);
            mapper.AddPropertyMap((o) => o.Obligations[0].CreationDateSpecified, (c) => c.Obligations[0].CreationDateSpecified);
            mapper.AddPropertyMap((o) => o.Obligations[0].TypeObligation, (c) => c.Obligations[0].TypeObligation);
            mapper.AddPropertyMap((o) => o.Obligations[0].ObligationAmount, (c) => c.Obligations[0].ObligationAmount);
            mapper.AddPropertyMap((o) => o.Obligations[0].ObligationAmountSpecified, (c) => c.Obligations[0].ObligationAmountSpecified);
            mapper.AddPropertyMap((o) => o.Obligations[0].PayingDocument, (c) => c.Obligations[0].PayingDocument);
            mapper.AddPropertyMap((o) => o.Obligations[0].PayingDate, (c) => c.Obligations[0].PayingDate);
            mapper.AddPropertyMap((o) => o.Obligations[0].PayingDateSpecified, (c) => c.Obligations[0].PayingDateSpecified);
            mapper.AddPropertyMap((o) => o.Obligations[0].PayingAmount, (c) => c.Obligations[0].PayingAmount);
            mapper.AddPropertyMap((o) => o.Obligations[0].PayingAmountSpecified, (c) => c.Obligations[0].PayingAmountSpecified);
            mapper.AddPropertyMap((o) => o.Obligations[0].PayingTotal, (c) => c.Obligations[0].PayingTotal);
            mapper.AddPropertyMap((o) => o.Obligations[0].PayingTotalSpecified, (c) => c.Obligations[0].PayingTotalSpecified);
            mapper.AddPropertyMap((o) => o.Obligations[0].Difference, (c) => c.Obligations[0].Difference);
            mapper.AddPropertyMap((o) => o.Obligations[0].DifferenceSpecified, (c) => c.Obligations[0].DifferenceSpecified);
            mapper.AddPropertyMap((o) => o.Obligations[0].Status, (c) => c.Obligations[0].Status);

            return mapper;
        }

        public CommonSignedResponse<ExciseObligationsRequestType, ExciseObligationsResponseType> GetExciseObligations(ExciseObligationsRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.XmlSerialize(), Guid = id });
            try
            {
                REZMAServiceReference.rezmaobligationsportClient client = new REZMAServiceReference.rezmaobligationsportClient(
                    REZMAServiceReference.rezmaobligationsportClient.EndpointConfiguration.rezma_obligations_portSoap11,
                    WebServiceUrl.Value);

                REZMAServiceReference.ExciseObligationsRequestType serviceRequest = new REZMAServiceReference.ExciseObligationsRequestType()
                {
                    Identifier = argument.Identifier
                };
                Task<REZMAServiceReference.ExciseObligationsResponse> serviceResult = client.ExciseObligationsAsync(serviceRequest);
                Task.WaitAll();

                ObjectMapper<REZMAServiceReference.ExciseObligationsResponseType, ExciseObligationsResponseType> mapper = CreateExciseObligationsMap(accessMatrix);
                ExciseObligationsResponseType result = new ExciseObligationsResponseType();
                mapper.Map(serviceResult.Result.ExciseObligationsResponse1, result);
                return
                       SigningUtils.CreateAndSign(
                           argument,
                           result,
                           accessMatrix,
                           aditionalParameters
                       );
            }
            catch (Exception ex)
            {
                LogError(aditionalParameters, ex, new { Guid = id });
                File.AppendAllText("C://Regix//AmAdapters//log_errors.txt", GetFullExceptionDetails(ex, true));
                throw ex;
            }
        }
        private static ObjectMapper<REZMAServiceReference.ExciseObligationsResponseType, ExciseObligationsResponseType> CreateExciseObligationsMap(AccessMatrix accessMatrix)
        {
            ObjectMapper<REZMAServiceReference.ExciseObligationsResponseType, ExciseObligationsResponseType> mapper = new ObjectMapper<REZMAServiceReference.ExciseObligationsResponseType, ExciseObligationsResponseType>(accessMatrix);

            mapper.AddPropertyMap((o) => o.UIN, (c) => c.UIN);
            mapper.AddPropertyMap((o) => o.Name, (c) => c.Name);

            mapper.AddCollectionMap<REZMAServiceReference.ExciseObligationsResponseType>((o) => o.Obligations, c => c.Obligations);

            mapper.AddPropertyMap((o) => o.Obligations[0].CodeMU, (c) => c.Obligations[0].CodeMU);
            mapper.AddPropertyMap((o) => o.Obligations[0].MU, (c) => c.Obligations[0].MU);
            mapper.AddPropertyMap((o) => o.Obligations[0].Document, (c) => c.Obligations[0].Document);
            mapper.AddPropertyMap((o) => o.Obligations[0].DocumentNumber, (c) => c.Obligations[0].DocumentNumber);
            mapper.AddPropertyMap((o) => o.Obligations[0].CreationDate, (c) => c.Obligations[0].CreationDate);
            mapper.AddPropertyMap((o) => o.Obligations[0].CreationDateSpecified, (c) => c.Obligations[0].CreationDateSpecified);
            mapper.AddPropertyMap((o) => o.Obligations[0].TypeObligation, (c) => c.Obligations[0].TypeObligation);
            mapper.AddPropertyMap((o) => o.Obligations[0].ObligationAmount, (c) => c.Obligations[0].ObligationAmount);
            mapper.AddPropertyMap((o) => o.Obligations[0].ObligationAmountSpecified, (c) => c.Obligations[0].ObligationAmountSpecified);
            mapper.AddPropertyMap((o) => o.Obligations[0].PayingDocument, (c) => c.Obligations[0].PayingDocument);
            mapper.AddPropertyMap((o) => o.Obligations[0].PayingDate, (c) => c.Obligations[0].PayingDate);
            mapper.AddPropertyMap((o) => o.Obligations[0].PayingDateSpecified, (c) => c.Obligations[0].PayingDateSpecified);
            mapper.AddPropertyMap((o) => o.Obligations[0].PayingAmount, (c) => c.Obligations[0].PayingAmount);
            mapper.AddPropertyMap((o) => o.Obligations[0].PayingAmountSpecified, (c) => c.Obligations[0].PayingAmountSpecified);
            mapper.AddPropertyMap((o) => o.Obligations[0].PayingTotal, (c) => c.Obligations[0].PayingTotal);
            mapper.AddPropertyMap((o) => o.Obligations[0].PayingTotalSpecified, (c) => c.Obligations[0].PayingTotalSpecified);
            mapper.AddPropertyMap((o) => o.Obligations[0].Difference, (c) => c.Obligations[0].Difference);
            mapper.AddPropertyMap((o) => o.Obligations[0].DifferenceSpecified, (c) => c.Obligations[0].DifferenceSpecified);
            mapper.AddPropertyMap((o) => o.Obligations[0].Status, (c) => c.Obligations[0].Status);

            return mapper;
        }
        public CommonSignedResponse<CheckObligationsRequestType, CheckObligationsResponseType> CheckObligations(CheckObligationsRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.XmlSerialize(), Guid = id });
            try
            {
                REZMAServiceReference.rezmaobligationsportClient client = new REZMAServiceReference.rezmaobligationsportClient(
                    REZMAServiceReference.rezmaobligationsportClient.EndpointConfiguration.rezma_obligations_portSoap11,
                    WebServiceUrl.Value);
                REZMAServiceReference.CheckObligationsRequestType serviceRequest = new REZMAServiceReference.CheckObligationsRequestType()
                {
                    Identifier = argument.Identifier
                };

                Task<REZMAServiceReference.CheckObligationsResponse> serviceResult = client.CheckObligationsAsync(serviceRequest);
                Task.WaitAll();

                ObjectMapper<REZMAServiceReference.CheckObligationsResponseType, CheckObligationsResponseType> mapper = CreateCheckObligationsMap(accessMatrix, DateTime.Now);
                CheckObligationsResponseType result = new CheckObligationsResponseType();
                mapper.Map(serviceResult.Result.CheckObligationsResponse1, result);
                return
                       SigningUtils.CreateAndSign(
                           argument,
                           result,
                           accessMatrix,
                           aditionalParameters
                       );
            }
            catch (Exception ex)
            {
                LogError(aditionalParameters, ex, new { Guid = id });
                File.AppendAllText("C://Regix//AmAdapters//log_errors.txt", GetFullExceptionDetails(ex, true));
                throw ex;
            }
        }
        private static ObjectMapper<REZMAServiceReference.CheckObligationsResponseType, CheckObligationsResponseType> CreateCheckObligationsMap(AccessMatrix accessMatrix, DateTime reportDate)
        {
            ObjectMapper<REZMAServiceReference.CheckObligationsResponseType, CheckObligationsResponseType> mapper = new ObjectMapper<REZMAServiceReference.CheckObligationsResponseType, CheckObligationsResponseType>(accessMatrix);

            mapper.AddPropertyMap((o) => o.UIN, (c) => c.UIN);
            mapper.AddPropertyMap((o) => o.Name, (c) => c.Name);
            mapper.AddFunctionMap<REZMAServiceReference.CheckObligationsResponseType, StatusType>((o) => o.Status, (c) => (StatusType)Enum.Parse(typeof(StatusType), c.Status.ToString()));
            mapper.AddPropertyMap((o) => o.ReportDate, (c) => c.ReportDate);
            mapper.AddPropertyMap((o) => o.ReportDateSpecified, (c) => true);

            return mapper;
        }

        private static string GetFullExceptionDetails(Exception e, bool includeStackTrace = false)
        {
            string newLine = Environment.NewLine;
            string message = e.Message;
            string exceptionType = e.GetType().ToString();



            string stack = "";
            if (includeStackTrace && !string.IsNullOrEmpty(e.StackTrace))
            {
                stack = e.StackTrace + newLine;
            }


            string LinesSeparator = new string('=', 27);
            string result = string.Format("{0}{1}{2}{1}{3}{1}{4}{1}{5}",
                LinesSeparator,
                newLine,
                exceptionType,
                e.Source,
                message,
                stack);
            if (e.InnerException != null)
            {
                result = result + GetFullExceptionDetails(e.InnerException, includeStackTrace);
            }

            return result;
        }
    }
}
