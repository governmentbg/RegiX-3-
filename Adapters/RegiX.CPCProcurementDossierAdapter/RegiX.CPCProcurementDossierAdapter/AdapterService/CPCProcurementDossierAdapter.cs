using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Threading.Tasks;
using TechnoLogica.RegiX.Adapters.Common.DataContracts;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Adapters.Common.ObjectMapping;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.Common.Utils;
using TechnoLogica.RegiX.CPCProcurementDossierAdapter;
using TechnoLogica.RegiX.WebServiceAdapterService;
using TechnoLogica.RegiX.Common.DataContracts.Parameter;

namespace RegiX.CPCProcurementDossierAdapter.AdapterService
{
    [Export(typeof(IAdapterService))]
    [ExportFullName(typeof(CPCProcurementDossierAdapter), typeof(IAdapterService))]
    [ExportSimpleName(typeof(CPCProcurementDossierAdapter), typeof(IAdapterService))]
    public class CPCProcurementDossierAdapter : SoapServiceBaseAdapterService, ICPCProcurementDossierAdapter, IAdapterService
    {
        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(CPCProcurementDossierAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> WebServiceUrl =
                          new ParameterInfo<string>("http://regix2-adapters.regix.tlogica.com:8078/")
                          {
                              Key = Constants.WebServiceUrlParameterKeyName,
                              Description = "Web Service Url",
                              OwnerAssembly = typeof(CPCProcurementDossierAdapter).Assembly
                          };
        public CommonSignedResponse<GetProcurementDossierRequest, GetProcurementDossierResponse> GetProcurementDossier(GetProcurementDossierRequest argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(additionalParameters, new { Request = argument.XmlSerialize(), Guid = id });
            try
            {

                var endpointConfig = CPCDossierServiceReference.DossierPortTypeClient.EndpointConfiguration.DossierPort;
                CPCDossierServiceReference.DossierPortTypeClient client = new CPCDossierServiceReference.DossierPortTypeClient(endpointConfig, WebServiceUrl.Value);

                Task<CPCDossierServiceReference.GetProcurementDossierResponse> serviceResult = client.GetProcurementDossierAsync(argument.ProcurementNumber);
                Task.WaitAll();

                //string testServiceResult = ReadFile("C:\\Users\\mmarinov\\Desktop\\DossierResponse.xml");
                //CPCDossierServiceReference.GetProcurementDossierResponse test = testServiceResult.XmlDeserialize<CPCDossierServiceReference.GetProcurementDossierResponse>();

                GetProcurementDossierResponse result = new GetProcurementDossierResponse();
                ObjectMapper<CPCDossierServiceReference.GetProcurementDossierResult, GetProcurementDossierResponse> mapper = CreateProcurementDossierMapper(accessMatrix);
                mapper.Map(serviceResult.Result.ResultData, result);
                //File.WriteAllText("C://RegiX//RegiX.CPCAdapters//log_result.txt", result.XmlSerialize());
                return SigningUtils.CreateAndSign(
                    argument,
                    result,
                    accessMatrix,
                    additionalParameters
                );
            }
            catch (Exception ex)
            {
                LogError(additionalParameters, ex, new { Guid = id });
                File.AppendAllText("C://RegiX//RegiX.CPCAdapters//log_errors.txt", GetFullExceptionDetails(ex,true));
                throw;
            }
        }


        private static ObjectMapper<CPCDossierServiceReference.GetProcurementDossierResult, GetProcurementDossierResponse> CreateProcurementDossierMapper(AccessMatrix accessMatrix)
        {
            ObjectMapper<CPCDossierServiceReference.GetProcurementDossierResult, GetProcurementDossierResponse> mapper = new ObjectMapper<CPCDossierServiceReference.GetProcurementDossierResult, GetProcurementDossierResponse>(accessMatrix);
            mapper.AddPropertyMap((o) => o.ResultMessage, (c) => c.ResultMessage);
            //Enum mapping
            mapper.AddFunctionMap<CPCDossierServiceReference.GetProcurementDossierResult, GetProcurementDossierResponseResultStatus>((o) => o.ResultStatus, (c) => (GetProcurementDossierResponseResultStatus)Enum.Parse(typeof(GetProcurementDossierResponseResultStatus), c.ResultStatus.ToString()));

            ////ProcurementDossiers
            mapper.AddCollectionMap<CPCDossierServiceReference.GetProcurementDossierResult>((o) => o.ProcurementDossiers.ProcurementDossier, c => c.ProcurementDossier);

            mapper.AddPropertyMap((o) => o.ProcurementDossiers.ProcurementDossier[0].ProcurementNumber, (c) => c.ProcurementDossier[0].ProcurementNumber);
            mapper.AddPropertyMap((o) => o.ProcurementDossiers.ProcurementDossier[0].ProceedingsNumber, (c) => c.ProcurementDossier[0].ProceedingsNumber);
            mapper.AddPropertyMap((o) => o.ProcurementDossiers.ProcurementDossier[0].ProceedingsStartDate, (c) => c.ProcurementDossier[0].ProceedingsStartDate);
            mapper.AddPropertyMap((o) => o.ProcurementDossiers.ProcurementDossier[0].ProceedingsStartDateSpecified, (c) => c.ProcurementDossier[0].ProceedingsStartDateSpecified);
            mapper.AddPropertyMap((o) => o.ProcurementDossiers.ProcurementDossier[0].ProceedingsCloseDate, (c) => c.ProcurementDossier[0].ProceedingsCloseDate);
            mapper.AddPropertyMap((o) => o.ProcurementDossiers.ProcurementDossier[0].ProceedingsCloseDateSpecified, (c) => c.ProcurementDossier[0].ProceedingsCloseDateSpecified);
            mapper.AddPropertyMap((o) => o.ProcurementDossiers.ProcurementDossier[0].LegalBase, (c) => c.ProcurementDossier[0].LegalBase);
            mapper.AddPropertyMap((o) => o.ProcurementDossiers.ProcurementDossier[0].ProceedingsType, (c) => c.ProcurementDossier[0].ProceedingsType);
            ////ProceedingsSubsections
            mapper.AddFunctionMap<CPCDossierServiceReference.ProcurementDossier, List<string>>((o) => o.ProcurementDossiers.ProcurementDossier[0].ProceedingsSubsections.ProceedingSubsection, (c) => c.ProceedingsSubsection!=null?c.ProceedingsSubsection.ToList():null);

            ////Initiators
            mapper.AddFunctionMap<CPCDossierServiceReference.ProcurementDossier, List<string>>((o) => o.ProcurementDossiers.ProcurementDossier[0].Initiators.Initiator, (c) => c.Initiator!=null?c.Initiator.ToList():null);

            ////Defendents
            mapper.AddFunctionMap<CPCDossierServiceReference.ProcurementDossier, List<string>>((o) => o.ProcurementDossiers.ProcurementDossier[0].Defendants.Defendant, (c) => c.Defendant!=null?c.Defendant.ToList():null);

            ////UnitedProceedings
            mapper.AddFunctionMap<CPCDossierServiceReference.ProcurementDossier, List<string>>((o) => o.ProcurementDossiers.ProcurementDossier[0].UnitedProceedings.UnitedProceeding, (c) => c.UnitedProceedings != null ?c.UnitedProceedings.ToList():null);

            mapper.AddPropertyMap((o) => o.ProcurementDossiers.ProcurementDossier[0].InterimMeasures, (c) => c.ProcurementDossier[0].InterimMeasures);
            ////ImpostedInterimMeasures
            mapper.AddFunctionMap<CPCDossierServiceReference.ProcurementDossier, List<string>>((o) => o.ProcurementDossiers.ProcurementDossier[0].ImposedInterimMeasures.ImposedInterimMeasure, (c) => c.ImposedInterimMeasure!=null?c.ImposedInterimMeasure.ToList():null);

            mapper.AddPropertyMap((o) => o.ProcurementDossiers.ProcurementDossier[0].CurrentStatus, (c) => c.ProcurementDossier[0].CurrentStatus);

            mapper.AddPropertyMap((o) => o.ProcurementDossiers.ProcurementDossier[0].DossierPublishDate, (c) => c.ProcurementDossier[0].DossierPublishDate);
            mapper.AddPropertyMap((o) => o.ProcurementDossiers.ProcurementDossier[0].DossierPublishDateSpecified, (c) => c.ProcurementDossier[0].DossierPublishDateSpecified);

            mapper.AddPropertyMap((o) => o.ProcurementDossiers.ProcurementDossier[0].LastDecisionPublishDate, (c) => c.ProcurementDossier[0].LastDecisionPublishDate);
            mapper.AddPropertyMap((o) => o.ProcurementDossiers.ProcurementDossier[0].LastDecisionPublishDateSpecified, (c) => c.ProcurementDossier[0].LastDecisionPublishDateSpecified);
            //ImposedPenalties
            mapper.AddFunctionMap<CPCDossierServiceReference.ProcurementDossier, List<string>>((o) => o.ProcurementDossiers.ProcurementDossier[0].ImposedPenalties.ImposedPenalty, (c) => c.ImposedPenalty!=null?c.ImposedPenalty.ToList():null);

            mapper.AddPropertyMap((o) => o.ProcurementDossiers.ProcurementDossier[0].DossierLink, (c) => c.ProcurementDossier[0].DossierLink);
            mapper.AddPropertyMap((o) => o.ProcurementDossiers.ProcurementDossier[0].RegisterID, (c) => c.ProcurementDossier[0].RegisterID);
            return mapper;
        }

        //private static string ReadFile(string path)
        //{
        //    using (StreamReader sr = new StreamReader(path))
        //    {
        //        return sr.ReadToEnd();
        //    }
        //}

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
