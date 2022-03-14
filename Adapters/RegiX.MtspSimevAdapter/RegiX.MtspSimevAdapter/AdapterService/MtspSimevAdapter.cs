using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Xml;
using TechnoLogica.RegiX.Adapters.Common.DataContracts;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Adapters.Common.ObjectMapping;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.DataContracts.Parameter;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.Common.Utils;

namespace TechnoLogica.RegiX.MtspSimevAdapter.AdapterService
{
    [Export(typeof(IAdapterService))]
    [ExportFullName(typeof(MtspSimevAdapter), typeof(IAdapterService))]
    [ExportSimpleName(typeof(MtspSimevAdapter), typeof(IAdapterService))]
    public class MtspSimevAdapter : WebServiceAdapterService.SoapServiceBaseAdapterService, IMtspSimevAdapter, IAdapterService
    {
        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(MtspSimevAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> WebServiceUrl =
        new ParameterInfo<string>("https://customs.gravis.bg/simevsoa/soap/SimevAsp")
        {
            Key = Constants.WebServiceUrlParameterKeyName,
            Description = "Connection String for SOAP Web Service",
            OwnerAssembly = typeof(MtspSimevAdapter).Assembly
        };

        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(MtspSimevAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> IgnoreServerCertificate =
        new ParameterInfo<string>("1")
        {
            Key = "IgnoreServerCertificate",
            Description = "Ignore Server Certificate for SSL:{0,1}",
            OwnerAssembly = typeof(MtspSimevAdapter).Assembly
        };


        public CommonSignedResponse<MtspInfoFosterParentsRequest, MtspInfoFosterParentsResponse> SendInfoForFosterParents(MtspInfoFosterParentsRequest argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.Header != null ? argument.Header.XmlSerialize() : "EmptyHeader", Guid = id });
            try
            {
                MtspInfoFosterParentsResponse adapterResult = new MtspInfoFosterParentsResponse();
                SimevAspServiceReference.SimevAspServiceClient client = new SimevAspServiceReference.SimevAspServiceClient("SimevAspServiceImplPort", WebServiceUrl.Value);

                if (IgnoreServerCertificate.Value.Equals("1"))
                {
                    System.Net.ServicePointManager.ServerCertificateValidationCallback += delegate
                    {
                        return true;
                    };
                }
             //   LogData(aditionalParameters, new { Datetime = "1.Begin GravisService call", Guid = id });
                string serviceResultString = client.RequestResult(ArgumentMapper(argument));
             //   LogData(aditionalParameters, new { Datetime = "2.End GravisService call with result=" + serviceResultString});
                XmlElement serviceResultElement = serviceResultString.ToXmlElement();
              //  LogData(aditionalParameters, new { Datetime = "3.ToXmlElement", Request = argument.Header != null ? argument.Header.XmlSerialize() : "EmptyHeader", Guid = id });
                var serviceResult = (SimevServiceXSD.ResultResponse)serviceResultElement.Deserialize(typeof(SimevServiceXSD.ResultResponse));

              //  LogData(aditionalParameters, new { Datetime = "4.Deserialize result", Request = argument.Header != null ? argument.Header.XmlSerialize() : "EmptyHeader", Guid = id });

                var mapper = CreateMtspMapper(accessMatrix);
                mapper.Map(serviceResult, adapterResult);
               // LogData(aditionalParameters, new { Datetime = "5.Map ended", Request = argument.Header != null ? argument.Header.XmlSerialize() : "EmptyHeader", Guid = id });
                argument.Data = null;
               // LogData(aditionalParameters, new { Datetime = "6.argument.Data = null;", Request = argument.Header != null ? argument.Header.XmlSerialize() : "EmptyHeader", Guid = id });
                return
                    SigningUtils.CreateAndSign(
                        argument,
                        adapterResult,
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

        private static ObjectMapper<SimevServiceXSD.ResultResponse, MtspInfoFosterParentsResponse> CreateMtspMapper(AccessMatrix accessMatrix)
        {
            ObjectMapper<SimevServiceXSD.ResultResponse, MtspInfoFosterParentsResponse> mapper = new ObjectMapper<SimevServiceXSD.ResultResponse, MtspInfoFosterParentsResponse>(accessMatrix);

            mapper.AddObjectMap((o) => o, (c) => c);
            mapper.AddPropertyMap((o) => o.ResponseCode, (c) => c.ResponseCode);
            mapper.AddPropertyMap((o) => o.Error, (c) => c.Error);

            return mapper;
        }
        public string ArgumentMapper(MtspInfoFosterParentsRequest argument)
        {
            if (argument == null)
            {
                return string.Empty;
            }
            var serviceRequest = new SimevServiceXSD.Result();
            if (argument.Header != null)
            {
                serviceRequest.Header = new SimevServiceXSD.ResultHeader();
                serviceRequest.Header.RequestNumber = argument.Header.RequestNumber;
                serviceRequest.Header.Size = argument.Header.Size;
            }
            if (argument.Data != null)
            {
                serviceRequest.Data = new List<SimevServiceXSD.ResultDataItem>();
                foreach (var argData in argument.Data.DataItem)
                {
                    var dataItem = new SimevServiceXSD.ResultDataItem();
                    if (argData.AmountSpecified)
                    {
                        dataItem.Amount = argData.Amount;
                        dataItem.AmountSpecified = argData.AmountSpecified;
                    }
                    if (argData.ChildAmountSpecified)
                    {
                        dataItem.ChildAmount = argData.ChildAmount;
                        dataItem.ChildAmountSpecified = argData.ChildAmountSpecified;
                    }
                    dataItem.ChildIndentificator = argData.ChildIndentificator;
                    if (argData.ContractEndDateSpecified)
                    {
                        dataItem.ConstractEndDate = argData.ContractEndDate;
                        dataItem.ConstractEndDateSpecified = argData.ContractEndDateSpecified;
                    }
                    if (argData.ContractStartDateSpecified)
                    {
                        dataItem.ConstractStartDate = argData.ContractStartDate;
                        dataItem.ConstractStartDateSpecified = argData.ContractStartDateSpecified;
                    }
                    if (argData.ContractClosingDateSpecified)
                    {
                        dataItem.ContracClosingDate = argData.ContractClosingDate;
                        dataItem.ContracClosingDateSpecified = argData.ContractClosingDateSpecified;
                    }
                    if (argData.ContractDateSpecified)
                    {
                        dataItem.ContractDate = argData.ContractDate;
                        dataItem.ContractDateSpecified = argData.ContractDateSpecified;
                    }
                    dataItem.ContractNumber = argData.ContractNumber;
                    if (argData.IsFosterParentSpecified)
                    {
                        dataItem.FosterParent = argData.IsFosterParent ? SimevServiceXSD.Flag.Item1 : SimevServiceXSD.Flag.Item0;
                    }
                    if (argData.hasChildTelkSpecified)
                    {
                        dataItem.hasChildTelk = argData.hasChildTelk ? SimevServiceXSD.Flag.Item1 : SimevServiceXSD.Flag.Item0;
                    }
                    if (argData.HasTelkSpecified)
                    {
                        dataItem.HasTelk = argData.HasTelk ? SimevServiceXSD.Flag.Item1 : SimevServiceXSD.Flag.Item0;
                    }
                    dataItem.Identificator = argData.ParentIdentificator;
                    if (argData.IsChildRegisteredSpecified)
                    {
                        dataItem.IsChildRegistered = argData.IsChildRegistered ? SimevServiceXSD.Flag.Item1 : SimevServiceXSD.Flag.Item0;
                    }
                    if (argData.IsRegisteredSpecified)
                    {
                        dataItem.isRegistered = argData.IsRegistered ? SimevServiceXSD.Flag.Item1 : SimevServiceXSD.Flag.Item0;
                    }
                    if (argData.IsRegisteredInRiskSpecified)
                    {
                        dataItem.IsRegisteredInRisk = argData.IsRegisteredInRisk ? SimevServiceXSD.Flag.Item1 : SimevServiceXSD.Flag.Item0;
                    }
                    if (argData.IsSettledSpecified)
                    {
                        dataItem.IsSettled = argData.IsSettled ? SimevServiceXSD.Flag.Item1 : SimevServiceXSD.Flag.Item0;
                    }
                    if (argData.IsSettledEverSpecified)
                    {
                        dataItem.IsSettledEver = argData.IsSettledEver ? SimevServiceXSD.Flag.Item1 : SimevServiceXSD.Flag.Item0;
                    }
                    dataItem.Row = argData.Row;
                    if (argData.SattleDateSpecified)
                    {
                        dataItem.SattleDate = argData.SattleDate;
                        dataItem.SattleDateSpecified = argData.SattleDateSpecified;
                    }
                    if (argData.SattleEndDateSpecified)
                    {
                        dataItem.SattleEndDate = argData.SattleEndDate;
                        dataItem.SattleEndDateSpecified = argData.SattleEndDateSpecified;
                    }
                    serviceRequest.Data.Add(dataItem);
                }
            }
            return serviceRequest.XmlSerialize();
        }
    }
}
