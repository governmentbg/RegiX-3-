using NCPRMedicinalProductsServiceReference;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;
using TechnoLogica.RegiX.Adapters.Common.DataContracts;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Adapters.Common.ObjectMapping;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.DataContracts.Parameter;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.Common.Utils;
using TechnoLogica.RegiX.WebServiceAdapterService;

namespace TechnoLogica.RegiX.NCPRMedicinalProductsAdapter.AdapterService
{
    [Export(typeof(IAdapterService))]
    [ExportFullName(typeof(NCPRMedicinalProductsAdapter), typeof(IAdapterService))]
    [ExportSimpleName(typeof(NCPRMedicinalProductsAdapter), typeof(IAdapterService))]
    public class NCPRMedicinalProductsAdapter : SoapServiceBaseAdapterService, INCPRMedicinalProductsAdapter, IAdapterService
    {
        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(NCPRMedicinalProductsAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> WebServiceUrl =
                          new ParameterInfo<string>("http://regix2-adapters.regix.tlogica.com:8078/")
                          {
                              Key = Constants.WebServiceUrlParameterKeyName,
                              Description = "Web Service Url",
                              OwnerAssembly = typeof(NCPRMedicinalProductsAdapter).Assembly
                          };

        public CommonSignedResponse<GetMedinicalProductDataRequestType, GetMedicinalProductDataResponseType> GetMedicinalProductData(GetMedinicalProductDataRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(additionalParameters, new { Request = argument.Serialize(), Guid = id });
            try
            {
                MedicinalProductsRegistersConServiceClient client = new MedicinalProductsRegistersConServiceClient(MedicinalProductsRegistersConServiceClient.EndpointConfiguration.MedicinalProductsRegistersConServiceImplPort, WebServiceUrl.Value);
                getMedicinalProductDataConRequest serviceRequest = new getMedicinalProductDataConRequest()
                {
                    medicinalProductIdentifier = long.Parse(argument.MedicinalProductIdentifier)
                };

                Task<getMedicinalProductDataConResponse> serviceResponse = client.getMedicinalProductDataConAsync(serviceRequest.medicinalProductIdentifier);
                Task.WaitAll();

                ObjectMapper<medicinalProductDataCon, GetMedicinalProductDataResponseType> mapper = CreateGetMedicinalProductDataMapper(accessMatrix);
                var result = new GetMedicinalProductDataResponseType();
                mapper.Map(serviceResponse.Result.@return, result);
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
                throw ex;
            }
        }

        public CommonSignedResponse<GetRegisterMedicinalProductDataRequestType, GetRegisterMedicinalProductDataResponseType> GetRegisterMedicinalProductData(GetRegisterMedicinalProductDataRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(additionalParameters, new { Request = argument.Serialize(), Guid = id });
            try
            {
                MedicinalProductsRegistersConServiceClient client = new MedicinalProductsRegistersConServiceClient(MedicinalProductsRegistersConServiceClient.EndpointConfiguration.MedicinalProductsRegistersConServiceImplPort, WebServiceUrl.Value);

                Task<getRegisterMedicinalProductDataConResponse> serviceResponse = client.getRegisterMedicinalProductDataConAsync(argument.RegisterMedicinalProductId);
                Task.WaitAll();

                ObjectMapper<medicinalProductDataCon, GetRegisterMedicinalProductDataResponseType> mapper = CreateGetRegisterMedicinalProductDataMapper(accessMatrix);
                var result = new GetRegisterMedicinalProductDataResponseType();
                mapper.Map(serviceResponse.Result.@return, result);
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
                throw ex;
            }
        }

        public CommonSignedResponse<ListDeletedMedicinalProductsRequestType, ListDeletedMedicinalProductsResponseType> ListDeletedMedicinalProducts(ListDeletedMedicinalProductsRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(additionalParameters, new { Request = argument.Serialize(), Guid = id });
            try
            {
                MedicinalProductsRegistersConServiceClient client = new MedicinalProductsRegistersConServiceClient(MedicinalProductsRegistersConServiceClient.EndpointConfiguration.MedicinalProductsRegistersConServiceImplPort, WebServiceUrl.Value);

                RegisterCode tempRegCode;
                RegisterCode? RegCode = null;

                if (Enum.TryParse<RegisterCode>(argument.RegisterCode.ToString(), out tempRegCode))
                {
                    RegCode = tempRegCode;
                }
                NCPRMedicinalProductsServiceReference.medicinalProductFilter filter = new medicinalProductFilter
                {
                    atcCode = argument.ATCCode,
                    innCode = argument.INNCode,
                    medicinalProductName = argument.MedicinalProductName,
                    registerCode = RegCode
                };

                //В операциите listDeletedMedicinalProductsAsync и listMedicinalProductsAsync освен филтрите, 
                //които адаптерът ще подава като входни параметри, има и два параметъра, които доколкото разбрах от 
                //документацията се използват в случай на странициране, а именно: fromRow и numberOfRows.
                //Какви стойности да подаваме в тези параметри, тъй като са задължителни. 
                //Целта е да получаваме пълен резултат, няма да ползваме странициране.
                //Отговор: 
                //fromRow = 0
                //numberOfRows = (max int -1)
                Task<listDeletedMedicinalProductsResponse> serviceResponse = client.listDeletedMedicinalProductsAsync(filter, 0,int.MaxValue - 1);

                Task.WaitAll();

                ObjectMapper<medicinalProductList, ListDeletedMedicinalProductsResponseType> mapper = CreateListDeletedMedicinalProductsMapper(accessMatrix);
                var result = new ListDeletedMedicinalProductsResponseType();

                mapper.Map(serviceResponse.Result.@return, result);
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
                throw ex;
            }
        }

        public CommonSignedResponse<ListMedicinalProductsRequestType, ListMedicinalProductsResponseType> ListMedicinalProducts(ListMedicinalProductsRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(additionalParameters, new { Request = argument.Serialize(), Guid = id });
            try
            {
                MedicinalProductsRegistersConServiceClient client = new MedicinalProductsRegistersConServiceClient(MedicinalProductsRegistersConServiceClient.EndpointConfiguration.MedicinalProductsRegistersConServiceImplPort, WebServiceUrl.Value);

                RegisterCode tempRegCode;
                RegisterCode? RegCode = null;

                if (Enum.TryParse<RegisterCode>(argument.RegisterCode.ToString(), out tempRegCode))
                {
                    RegCode = tempRegCode;
                }
                NCPRMedicinalProductsServiceReference.medicinalProductFilter filter = new medicinalProductFilter
                {
                    atcCode = argument.ATCCode,
                    innCode = argument.INNCode,
                    medicinalProductName = argument.MedicinalProductName,
                    registerCode = RegCode
                };

                //В операциите listDeletedMedicinalProductsAsync и listMedicinalProductsAsync освен филтрите, 
                //които адаптерът ще подава като входни параметри, има и два параметъра, които доколкото разбрах от 
                //документацията се използват в случай на странициране, а именно: fromRow и numberOfRows.
                //Какви стойности да подаваме в тези параметри, тъй като са задължителни. 
                //Целта е да получаваме пълен резултат, няма да ползваме странициране.
                //Отговор: 
                //fromRow = 0
                //numberOfRows = (max int -1)
                Task<listMedicinalProductsResponse> serviceResponse = client.listMedicinalProductsAsync(filter, 0, int.MaxValue - 1);

                Task.WaitAll();

                ObjectMapper<medicinalProductList, ListMedicinalProductsResponseType> mapper = CreateListMedicinalProductsMapper(accessMatrix);
                var result = new ListMedicinalProductsResponseType();

                mapper.Map(serviceResponse.Result.@return, result);
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
                throw ex;
            }
        }

        #region Mappers
        private static ObjectMapper<medicinalProductDataCon, GetMedicinalProductDataResponseType> CreateGetMedicinalProductDataMapper(AccessMatrix accessMatrix)
        {
            ObjectMapper<medicinalProductDataCon, GetMedicinalProductDataResponseType> mapper = new ObjectMapper<medicinalProductDataCon, GetMedicinalProductDataResponseType>(accessMatrix);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.MedicinalProductIdentifier, (c) => c.medicinalProductIdentifier);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.NameBG, (c) => c.nameBG);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.NameEN, (c) => c.nameEN);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.INN, (c) => c.inn);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.AuthorizationHolder, (c) => c.authorizationHolder);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.AuthorizationNumber, (c) => c.authorizationNumber);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.MedicamentForm, (c) => c.medicamentForm);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.Quantity, (c) => c.quantity);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.MedicamentUnit, (c) => c.medicamentUnit);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.FinalPack, (c) => c.finalPack);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.Producer, (c) => c.producer);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.ProducerDeclaredPrice, (c) => c.producerDeclaredPrice);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.ProducerPriceCurrency, (c) => c.producerPriceCurrency);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.ProducerPriceExchangeRate, (c) => c.producerPriceExchangeRate);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.ProducerPrice, (c) => c.producerPrice);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.ProducerVat, (c) => c.producerVat);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.ProducerFinalPriceBGN, (c) => c.producerFinalPriceBGN);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.MerchantMarginPercent, (c) => c.merchantMarginPercent);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.MerchantMarginValue, (c) => c.merchantMarginValue);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.MerchantPriceNoVat, (c) => c.merchantPriceNoVat);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.MerchantVat, (c) => c.merchantVat);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.MerchantFinalPriceBGN, (c) => c.merchantFinalPriceBGN);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.RetailerMarginValue, (c) => c.retailerMarginValue);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.RetailerPriceNoVat, (c) => c.retailerPriceNoVat);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.RetailerVat, (c) => c.retailerVat);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.RetailerFinalPriceBGN, (c) => c.retailerFinalPriceBGN);
            
            //MedicinalProductMaxPricesRegisterData
            mapper.AddCollectionMap<medicinalProductDataCon>(o => o.MedicinalProductData.MedicinalProductMaxPricesRegisterData.MedicinalProductMaxPriceRegisterData, c => c.MedicinalProductMaxPricesRegisterData);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.MedicinalProductMaxPricesRegisterData.MedicinalProductMaxPriceRegisterData[0].MaximumPrice, (c) => c.MedicinalProductMaxPricesRegisterData[0].maximumPrice);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.MedicinalProductMaxPricesRegisterData.MedicinalProductMaxPriceRegisterData[0].PublishedAt, (c) => c.MedicinalProductMaxPricesRegisterData[0].publishedAt);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.MedicinalProductMaxPricesRegisterData.MedicinalProductMaxPriceRegisterData[0].RegisterCode, (c) => c.MedicinalProductMaxPricesRegisterData[0].registerCode);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.MedicinalProductMaxPricesRegisterData.MedicinalProductMaxPriceRegisterData[0].RegisterName, (c) => c.MedicinalProductMaxPricesRegisterData[0].registerName);

            //MedicinalProductPDLRegisterData
            mapper.AddCollectionMap<medicinalProductDataCon>(o => o.MedicinalProductData.MedicinalProductPDLRegistersData.MedicinalProductPDLRegisterData, c => c.MedicinalProductPDLRegisterData);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.MedicinalProductPDLRegistersData.MedicinalProductPDLRegisterData[0].DDDUnit, (c) => c.MedicinalProductPDLRegisterData[0].dddUnit);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.MedicinalProductPDLRegistersData.MedicinalProductPDLRegisterData[0].Group, (c) => c.MedicinalProductPDLRegisterData[0].group);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.MedicinalProductPDLRegistersData.MedicinalProductPDLRegisterData[0].IsDddWHO, (c) => c.MedicinalProductPDLRegisterData[0].isDddWHO);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.MedicinalProductPDLRegistersData.MedicinalProductPDLRegisterData[0].PackDDDNumber, (c) => c.MedicinalProductPDLRegisterData[0].packDDDNumber);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.MedicinalProductPDLRegistersData.MedicinalProductPDLRegisterData[0].PackPriceRefDDD, (c) => c.MedicinalProductPDLRegisterData[0].packPriceRefDDD);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.MedicinalProductPDLRegistersData.MedicinalProductPDLRegisterData[0].PrescriptionRestrictions, (c) => c.MedicinalProductPDLRegisterData[0].prescriptionRestrictions);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.MedicinalProductPDLRegistersData.MedicinalProductPDLRegisterData[0].PublishedAt, (c) => c.MedicinalProductPDLRegisterData[0].publishedAt);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.MedicinalProductPDLRegistersData.MedicinalProductPDLRegisterData[0].RegisterCode, (c) => c.MedicinalProductPDLRegisterData[0].registerCode);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.MedicinalProductPDLRegistersData.MedicinalProductPDLRegisterData[0].RegisterName, (c) => c.MedicinalProductPDLRegisterData[0].registerName);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.MedicinalProductPDLRegistersData.MedicinalProductPDLRegisterData[0].ReimbursementPercent, (c) => c.MedicinalProductPDLRegisterData[0].reimbursementPercent);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.MedicinalProductPDLRegistersData.MedicinalProductPDLRegisterData[0].ReimbursementValue, (c) => c.MedicinalProductPDLRegisterData[0].reimbursementValue);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.MedicinalProductPDLRegistersData.MedicinalProductPDLRegisterData[0].TreatmentSpecifics, (c) => c.MedicinalProductPDLRegisterData[0].treatmentSpecifics);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.MedicinalProductPDLRegistersData.MedicinalProductPDLRegisterData[0].AverageTreatmentPeriod, (c) => c.MedicinalProductPDLRegisterData[0].averageTreatmentPeriod);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.MedicinalProductPDLRegistersData.MedicinalProductPDLRegisterData[0].ConcomitantTreatmentSpecifics, (c) => c.MedicinalProductPDLRegisterData[0].concomitantTreatmentSpecifics);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.MedicinalProductPDLRegistersData.MedicinalProductPDLRegisterData[0].DDDReferentValue, (c) => c.MedicinalProductPDLRegisterData[0].dddReferentValue);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.MedicinalProductPDLRegistersData.MedicinalProductPDLRegisterData[0].DDDValue, (c) => c.MedicinalProductPDLRegisterData[0].dddValue);

            mapper.AddFunctionMap<NCPRMedicinalProductsServiceReference.medicinalProductPDLRegisterData, List<string>>((o) => o.MedicinalProductData.MedicinalProductPDLRegistersData.MedicinalProductPDLRegisterData[0].ATCCodes.ATCCode, (c) => (c.atcCodes == null) ? null : c.atcCodes.ToList());
            mapper.AddFunctionMap<NCPRMedicinalProductsServiceReference.medicinalProductPDLRegisterData, List<string>>((o) => o.MedicinalProductData.MedicinalProductPDLRegistersData.MedicinalProductPDLRegisterData[0].ICDCodes.ICDCode, (c) => (c.icdCodes == null) ? null : c.icdCodes.ToList());
            ///MedicinalProductCeilingPriceRegisterData
            mapper.AddCollectionMap<medicinalProductDataCon>(o => o.MedicinalProductData.MedicinalProductCeilingPricesRegisterData.MedicinalProductCeilingPriceRegisterData, c => c.MedicinalProductCeilingPricesRegisterData);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.MedicinalProductCeilingPricesRegisterData.MedicinalProductCeilingPriceRegisterData[0].RegisterName, (c) => c.MedicinalProductCeilingPricesRegisterData[0].registerName);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.MedicinalProductCeilingPricesRegisterData.MedicinalProductCeilingPriceRegisterData[0].RegisterCode, (c) => c.MedicinalProductCeilingPricesRegisterData[0].registerCode);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.MedicinalProductCeilingPricesRegisterData.MedicinalProductCeilingPriceRegisterData[0].PublishedAt, (c) => c.MedicinalProductCeilingPricesRegisterData[0].publishedAt);

            return mapper;
        }

        private static ObjectMapper<medicinalProductDataCon, GetRegisterMedicinalProductDataResponseType> CreateGetRegisterMedicinalProductDataMapper(AccessMatrix accessMatrix)
        {
            ObjectMapper<medicinalProductDataCon, GetRegisterMedicinalProductDataResponseType> mapper = new ObjectMapper<medicinalProductDataCon, GetRegisterMedicinalProductDataResponseType>(accessMatrix);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.MedicinalProductIdentifier, (c) => c.medicinalProductIdentifier);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.NameBG, (c) => c.nameBG);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.NameEN, (c) => c.nameEN);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.INN, (c) => c.inn);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.AuthorizationHolder, (c) => c.authorizationHolder);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.AuthorizationNumber, (c) => c.authorizationNumber);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.MedicamentForm, (c) => c.medicamentForm);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.Quantity, (c) => c.quantity);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.MedicamentUnit, (c) => c.medicamentUnit);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.FinalPack, (c) => c.finalPack);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.Producer, (c) => c.producer);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.ProducerDeclaredPrice, (c) => c.producerDeclaredPrice);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.ProducerPriceCurrency, (c) => c.producerPriceCurrency);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.ProducerPriceExchangeRate, (c) => c.producerPriceExchangeRate);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.ProducerPrice, (c) => c.producerPrice);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.ProducerVat, (c) => c.producerVat);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.ProducerFinalPriceBGN, (c) => c.producerFinalPriceBGN);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.MerchantMarginPercent, (c) => c.merchantMarginPercent);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.MerchantMarginValue, (c) => c.merchantMarginValue);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.MerchantPriceNoVat, (c) => c.merchantPriceNoVat);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.MerchantVat, (c) => c.merchantVat);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.MerchantFinalPriceBGN, (c) => c.merchantFinalPriceBGN);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.RetailerMarginValue, (c) => c.retailerMarginValue);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.RetailerPriceNoVat, (c) => c.retailerPriceNoVat);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.RetailerVat, (c) => c.retailerVat);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.RetailerFinalPriceBGN, (c) => c.retailerFinalPriceBGN);

            //MedicinalProductMaxPricesRegisterData
            mapper.AddCollectionMap<medicinalProductDataCon>(o => o.MedicinalProductData.MedicinalProductMaxPricesRegisterData.MedicinalProductMaxPriceRegisterData, c => c.MedicinalProductMaxPricesRegisterData);

            mapper.AddPropertyMap((o) => o.MedicinalProductData.MedicinalProductMaxPricesRegisterData.MedicinalProductMaxPriceRegisterData[0].MaximumPrice, (c) => c.MedicinalProductMaxPricesRegisterData[0].maximumPrice);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.MedicinalProductMaxPricesRegisterData.MedicinalProductMaxPriceRegisterData[0].PublishedAt, (c) => c.MedicinalProductMaxPricesRegisterData[0].publishedAt);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.MedicinalProductMaxPricesRegisterData.MedicinalProductMaxPriceRegisterData[0].RegisterCode, (c) => c.MedicinalProductMaxPricesRegisterData[0].registerCode);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.MedicinalProductMaxPricesRegisterData.MedicinalProductMaxPriceRegisterData[0].RegisterName, (c) => c.MedicinalProductMaxPricesRegisterData[0].registerName);

            //MedicinalProductPDLRegisterData
            mapper.AddCollectionMap<medicinalProductDataCon>(o => o.MedicinalProductData.MedicinalProductPDLRegistersData.MedicinalProductPDLRegisterData, c => c.MedicinalProductPDLRegisterData);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.MedicinalProductPDLRegistersData.MedicinalProductPDLRegisterData[0].DDDUnit, (c) => c.MedicinalProductPDLRegisterData[0].dddUnit);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.MedicinalProductPDLRegistersData.MedicinalProductPDLRegisterData[0].Group, (c) => c.MedicinalProductPDLRegisterData[0].group);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.MedicinalProductPDLRegistersData.MedicinalProductPDLRegisterData[0].IsDddWHO, (c) => c.MedicinalProductPDLRegisterData[0].isDddWHO);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.MedicinalProductPDLRegistersData.MedicinalProductPDLRegisterData[0].PackDDDNumber, (c) => c.MedicinalProductPDLRegisterData[0].packDDDNumber);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.MedicinalProductPDLRegistersData.MedicinalProductPDLRegisterData[0].PackPriceRefDDD, (c) => c.MedicinalProductPDLRegisterData[0].packPriceRefDDD);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.MedicinalProductPDLRegistersData.MedicinalProductPDLRegisterData[0].PrescriptionRestrictions, (c) => c.MedicinalProductPDLRegisterData[0].prescriptionRestrictions);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.MedicinalProductPDLRegistersData.MedicinalProductPDLRegisterData[0].PublishedAt, (c) => c.MedicinalProductPDLRegisterData[0].publishedAt);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.MedicinalProductPDLRegistersData.MedicinalProductPDLRegisterData[0].RegisterCode, (c) => c.MedicinalProductPDLRegisterData[0].registerCode);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.MedicinalProductPDLRegistersData.MedicinalProductPDLRegisterData[0].RegisterName, (c) => c.MedicinalProductPDLRegisterData[0].registerName);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.MedicinalProductPDLRegistersData.MedicinalProductPDLRegisterData[0].ReimbursementPercent, (c) => c.MedicinalProductPDLRegisterData[0].reimbursementPercent);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.MedicinalProductPDLRegistersData.MedicinalProductPDLRegisterData[0].ReimbursementValue, (c) => c.MedicinalProductPDLRegisterData[0].reimbursementValue);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.MedicinalProductPDLRegistersData.MedicinalProductPDLRegisterData[0].TreatmentSpecifics, (c) => c.MedicinalProductPDLRegisterData[0].treatmentSpecifics);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.MedicinalProductPDLRegistersData.MedicinalProductPDLRegisterData[0].AverageTreatmentPeriod, (c) => c.MedicinalProductPDLRegisterData[0].averageTreatmentPeriod);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.MedicinalProductPDLRegistersData.MedicinalProductPDLRegisterData[0].ConcomitantTreatmentSpecifics, (c) => c.MedicinalProductPDLRegisterData[0].concomitantTreatmentSpecifics);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.MedicinalProductPDLRegistersData.MedicinalProductPDLRegisterData[0].DDDReferentValue, (c) => c.MedicinalProductPDLRegisterData[0].dddReferentValue);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.MedicinalProductPDLRegistersData.MedicinalProductPDLRegisterData[0].DDDValue, (c) => c.MedicinalProductPDLRegisterData[0].dddValue);
            mapper.AddFunctionMap<NCPRMedicinalProductsServiceReference.medicinalProductPDLRegisterData, List<string>>((o) => o.MedicinalProductData.MedicinalProductPDLRegistersData.MedicinalProductPDLRegisterData[0].ATCCodes.ATCCode, (c) => (c.atcCodes == null) ? null : c.atcCodes.ToList());
            mapper.AddFunctionMap<NCPRMedicinalProductsServiceReference.medicinalProductPDLRegisterData, List<string>>((o) => o.MedicinalProductData.MedicinalProductPDLRegistersData.MedicinalProductPDLRegisterData[0].ICDCodes.ICDCode, (c) => (c.icdCodes == null) ? null : c.icdCodes.ToList());

            ///MedicinalProductCeilingPriceRegisterData
            mapper.AddCollectionMap<medicinalProductDataCon>(o => o.MedicinalProductData.MedicinalProductCeilingPricesRegisterData.MedicinalProductCeilingPriceRegisterData, c => c.MedicinalProductCeilingPricesRegisterData);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.MedicinalProductCeilingPricesRegisterData.MedicinalProductCeilingPriceRegisterData[0].RegisterName, (c) => c.MedicinalProductCeilingPricesRegisterData[0].registerName);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.MedicinalProductCeilingPricesRegisterData.MedicinalProductCeilingPriceRegisterData[0].RegisterCode, (c) => c.MedicinalProductCeilingPricesRegisterData[0].registerCode);
            mapper.AddPropertyMap((o) => o.MedicinalProductData.MedicinalProductCeilingPricesRegisterData.MedicinalProductCeilingPriceRegisterData[0].PublishedAt, (c) => c.MedicinalProductCeilingPricesRegisterData[0].publishedAt);
            
            return mapper;
        }

        private static ObjectMapper<medicinalProductList, ListDeletedMedicinalProductsResponseType> CreateListDeletedMedicinalProductsMapper(AccessMatrix accessMatrix)
        {
            ObjectMapper<medicinalProductList, ListDeletedMedicinalProductsResponseType> mapper = new ObjectMapper<medicinalProductList, ListDeletedMedicinalProductsResponseType>(accessMatrix);
            mapper.AddPropertyMap((o) => o.ResultsCount, (c) => c.allResultsCount);

            mapper.AddCollectionMap<medicinalProductList>(o => o.MedicinalProducts.MedicinalProduct, c => c.medicinalProductListItemList);

            mapper.AddPropertyMap((o) => o.MedicinalProducts.MedicinalProduct[0].RegisterMedicamentId, (c) => c.medicinalProductListItemList[0].registerMedicamentId);
            mapper.AddPropertyMap((o) => o.MedicinalProducts.MedicinalProduct[0].MedicinalProductIdentifier, (c) => c.medicinalProductListItemList[0].medicinalProductIdentifier);
            mapper.AddPropertyMap((o) => o.MedicinalProducts.MedicinalProduct[0].RegisterCode, (c) => c.medicinalProductListItemList[0].registerCode);
            mapper.AddPropertyMap((o) => o.MedicinalProducts.MedicinalProduct[0].RegisterName, (c) => c.medicinalProductListItemList[0].registerName);
            mapper.AddPropertyMap((o) => o.MedicinalProducts.MedicinalProduct[0].NameBG, (c) => c.medicinalProductListItemList[0].nameBG);
            mapper.AddPropertyMap((o) => o.MedicinalProducts.MedicinalProduct[0].NameEN, (c) => c.medicinalProductListItemList[0].nameEN);
            mapper.AddPropertyMap((o) => o.MedicinalProducts.MedicinalProduct[0].INN, (c) => c.medicinalProductListItemList[0].inn);
            mapper.AddPropertyMap((o) => o.MedicinalProducts.MedicinalProduct[0].AuthorizationHolder, (c) => c.medicinalProductListItemList[0].authorizationHolder);
            mapper.AddPropertyMap((o) => o.MedicinalProducts.MedicinalProduct[0].Producer, (c) => c.medicinalProductListItemList[0].producer);
            mapper.AddPropertyMap((o) => o.MedicinalProducts.MedicinalProduct[0].MedicamentForm, (c) => c.medicinalProductListItemList[0].medicamentForm);
            mapper.AddPropertyMap((o) => o.MedicinalProducts.MedicinalProduct[0].Quantity, (c) => c.medicinalProductListItemList[0].quantity);
            mapper.AddPropertyMap((o) => o.MedicinalProducts.MedicinalProduct[0].MedicamentUnit, (c) => c.medicinalProductListItemList[0].medicamentUnit);
            mapper.AddPropertyMap((o) => o.MedicinalProducts.MedicinalProduct[0].FinalPack, (c) => c.medicinalProductListItemList[0].finalPack);
            mapper.AddPropertyMap((o) => o.MedicinalProducts.MedicinalProduct[0].MerchantFinalPriceBGN, (c) => c.medicinalProductListItemList[0].merchantFinalPriceBGN);
            mapper.AddPropertyMap((o) => o.MedicinalProducts.MedicinalProduct[0].RetailerFinalPriceBGN, (c) => c.medicinalProductListItemList[0].retailerFinalPriceBGN);
            mapper.AddPropertyMap((o) => o.MedicinalProducts.MedicinalProduct[0].PublishedAt, (c) => c.medicinalProductListItemList[0].publishedAt);
            //string[] to List<string>
            mapper.AddFunctionMap<medicinalProductListItem, List<string>>((o) => o.MedicinalProducts.MedicinalProduct[0].ATCCodes.ATCCode, (c) => (c.atcCodes == null) ? null : c.atcCodes.ToList());

            return mapper;
        }

        private static ObjectMapper<medicinalProductList, ListMedicinalProductsResponseType> CreateListMedicinalProductsMapper(AccessMatrix accessMatrix)
        {
            ObjectMapper<medicinalProductList, ListMedicinalProductsResponseType> mapper = new ObjectMapper<medicinalProductList, ListMedicinalProductsResponseType>(accessMatrix);
            mapper.AddPropertyMap((o) => o.ResultsCount, (c) => c.allResultsCount);

            mapper.AddCollectionMap<medicinalProductList>(o => o.MedicinalProducts.MedicinalProduct, c => c.medicinalProductListItemList);

            mapper.AddPropertyMap((o) => o.MedicinalProducts.MedicinalProduct[0].RegisterMedicamentId, (c) => c.medicinalProductListItemList[0].registerMedicamentId);
            mapper.AddPropertyMap((o) => o.MedicinalProducts.MedicinalProduct[0].MedicinalProductIdentifier, (c) => c.medicinalProductListItemList[0].medicinalProductIdentifier);
            mapper.AddPropertyMap((o) => o.MedicinalProducts.MedicinalProduct[0].RegisterCode, (c) => c.medicinalProductListItemList[0].registerCode);
            mapper.AddPropertyMap((o) => o.MedicinalProducts.MedicinalProduct[0].RegisterName, (c) => c.medicinalProductListItemList[0].registerName);
            mapper.AddPropertyMap((o) => o.MedicinalProducts.MedicinalProduct[0].NameBG, (c) => c.medicinalProductListItemList[0].nameBG);
            mapper.AddPropertyMap((o) => o.MedicinalProducts.MedicinalProduct[0].NameEN, (c) => c.medicinalProductListItemList[0].nameEN);
            mapper.AddPropertyMap((o) => o.MedicinalProducts.MedicinalProduct[0].INN, (c) => c.medicinalProductListItemList[0].inn);
            mapper.AddPropertyMap((o) => o.MedicinalProducts.MedicinalProduct[0].AuthorizationHolder, (c) => c.medicinalProductListItemList[0].authorizationHolder);
            mapper.AddPropertyMap((o) => o.MedicinalProducts.MedicinalProduct[0].Producer, (c) => c.medicinalProductListItemList[0].producer);
            mapper.AddPropertyMap((o) => o.MedicinalProducts.MedicinalProduct[0].MedicamentForm, (c) => c.medicinalProductListItemList[0].medicamentForm);
            mapper.AddPropertyMap((o) => o.MedicinalProducts.MedicinalProduct[0].Quantity, (c) => c.medicinalProductListItemList[0].quantity);
            mapper.AddPropertyMap((o) => o.MedicinalProducts.MedicinalProduct[0].MedicamentUnit, (c) => c.medicinalProductListItemList[0].medicamentUnit);
            mapper.AddPropertyMap((o) => o.MedicinalProducts.MedicinalProduct[0].FinalPack, (c) => c.medicinalProductListItemList[0].finalPack);
            mapper.AddPropertyMap((o) => o.MedicinalProducts.MedicinalProduct[0].MerchantFinalPriceBGN, (c) => c.medicinalProductListItemList[0].merchantFinalPriceBGN);
            mapper.AddPropertyMap((o) => o.MedicinalProducts.MedicinalProduct[0].RetailerFinalPriceBGN, (c) => c.medicinalProductListItemList[0].retailerFinalPriceBGN);
            mapper.AddPropertyMap((o) => o.MedicinalProducts.MedicinalProduct[0].PublishedAt, (c) => c.medicinalProductListItemList[0].publishedAt);
            mapper.AddFunctionMap<medicinalProductListItem, List<string>>((o) => o.MedicinalProducts.MedicinalProduct[0].ATCCodes.ATCCode, (c) => (c.atcCodes == null) ? null : c.atcCodes.ToList());
            return mapper;
        }
        #endregion
    }
}
