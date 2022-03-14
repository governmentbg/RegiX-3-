//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Data;
//using TechnoLogica.RegiX.Common;
//using TechnoLogica.RegiX.Common.ObjectMapping;
//using TechnoLogica.RegiX.Common.AdapterCore;
//using TechnoLogica.RegiX.Common.Utils;
//using System.ComponentModel.Composition;
//using TechnoLogica.RegiX.IAMAVesselsAdapter;
//using TechnoLogica.RegiX.IAMAVesselsAdapter.VesselsReportService;
//using TechnoLogica.RegiX.Common.ServiceContracts;
//using TechnoLogica.RegiX.Common.DataContracts;
//using TechnoLogica.RegiX.Common.TransportObject;

//namespace TechnoLogica.RegiX.IAMAVesselsAdapter.AdapterService
//{
//    public class VesselsAdapter : WebServiceAdapterService.SoapServiceBaseAdapterService, IVesselsAdapter, IAdapterService
//    {

//        [Export(typeof(ParameterInfo))]
//        [ExportFullName(typeof(VesselsAdapter), typeof(ParameterInfo))]
//        public static ParameterInfo<string> WebServiceUrl =
//            new ParameterInfo<string>("http://egov.ad.tlogica.com/MockRegisters/IAMAVessels/VesselsService.asmx")
//            {
//                Key = Constants.WebServiceUrlParameterKeyName,
//                Description = "Connection String for SOAP Web Service",
//                OwnerAssembly = typeof(VesselsAdapter).Assembly
//            };

//        [Export(typeof(ParameterInfo))]
//        [ExportFullName(typeof(VesselsAdapter), typeof(ParameterInfo))]
//        public static ParameterInfo<string> ServiceUrl =
//            new ParameterInfo<string>("http://egov.ad.tlogica.com/MockRegisters/IAMAVessels/VesselsService.asmx")
//            {
//                Key = "ServiceUrl",
//                Description = "VesselsReport Web Service Url",
//                OwnerAssembly = typeof(VesselsAdapter).Assembly
//            };

//        //public override string CheckRegisterConnection()
//        //{
//        //    return "Connection is OK!";
//        //}

//        public CommonSignedResponse<RegistrationInfoByOwnerRequestType, RegistrationInfoByOwnerResponseType> RegistrationSearchByOwner(RegistrationInfoByOwnerRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters)
//        {
//            Guid id = Guid.NewGuid();
//            LogData(additionalParameters, new { Request = argument.Serialize(), Guid = id });
//            try
//            {
//                VesselsReportService.GovServiceReportSoapClient serviceClient = new GovServiceReportSoapClient("GovServiceReportSoap", ServiceUrl.Value);
//                GovReportShip[] serviceResult = serviceClient.ShipsByOwner(argument.Identifier);

//                ObjectMapper<GovReportShip[], RegistrationInfoByOwnerResponseType> mapper = CreateVesselsByOwnerMapper(accessMatrix);
//                RegistrationInfoByOwnerResponseType searchResults = new RegistrationInfoByOwnerResponseType();
//                mapper.Map(serviceResult, searchResults);
//                return SigningUtils.CreateAndSign(argument,
//                    searchResults,
//                    accessMatrix,
//                    additionalParameters);
//            }
//            catch (Exception ex)
//            {
//                LogError(additionalParameters, ex, new { Guid = id });
//                throw ex;
//            }
//        }

//        private static ObjectMapper<GovReportShip[], RegistrationInfoByOwnerResponseType> CreateVesselsByOwnerMapper(AccessMatrix accessMatrix)
//        {
//            ObjectMapper<GovReportShip[], RegistrationInfoByOwnerResponseType> mapper = new ObjectMapper<GovReportShip[], RegistrationInfoByOwnerResponseType>(accessMatrix);

//            mapper.AddCollectionMap<GovReportShip[]>((o) => o.VesselInfo, c => c);
//            mapper.AddObjectMap((o) => o.VesselInfo[0].RegistrationData, (c) => c[0].RegistrationInfo);
//            mapper.AddObjectMap((o) => o.VesselInfo[0].MainFeatures, (c) => c[0].Characteristics);

//            mapper.AddPropertyMap((o) => o.VesselInfo[0].RegistrationData.ShipName, (c) => c[0].RegistrationInfo.ShipName);
//            mapper.AddPropertyMap((o) => o.VesselInfo[0].RegistrationData.ShipNameLatin, (c) => c[0].RegistrationInfo.ShipNameLatin);
//            mapper.AddPropertyMap((o) => o.VesselInfo[0].RegistrationData.RegistrationPort, (c) => c[0].RegistrationInfo.RegistrationPort);
//            mapper.AddPropertyMap((o) => o.VesselInfo[0].RegistrationData.RegistrationNumber, (c) => c[0].RegistrationInfo.RegistrationNumber);
//            mapper.AddPropertyMap((o) => o.VesselInfo[0].RegistrationData.Tom, (c) => c[0].RegistrationInfo.Tom);
//            mapper.AddPropertyMap((o) => o.VesselInfo[0].RegistrationData.Page, (c) => c[0].RegistrationInfo.Page);
//            mapper.AddPropertyMap((o) => o.VesselInfo[0].RegistrationData.Type, (c) => c[0].RegistrationInfo.Type);
//            mapper.AddFunctionMap<ShipRegistration, StatusEnum>((o) => o.VesselInfo[0].RegistrationData.Status, (c) => (StatusEnum)Enum.Parse(typeof(StatusEnum), c.Status.ToString()));

//            mapper.AddCollectionMap<GovReportShip>((o) => o.VesselInfo[0].Owners, s => s.OwnersInfo);

//            mapper.AddPropertyMap((o) => o.VesselInfo[0].Owners[0].IsCompany, (c) => c[0].OwnersInfo[0].Firm);
//            mapper.AddPropertyMap((o) => o.VesselInfo[0].Owners[0].ImoNumber, (c) => c[0].OwnersInfo[0].ImoNumber);
//            mapper.AddPropertyMap((o) => o.VesselInfo[0].Owners[0].IsUser, (c) => c[0].OwnersInfo[0].IsUser);
//            mapper.AddPropertyMap((o) => o.VesselInfo[0].Owners[0].Address, (c) => c[0].OwnersInfo[0].Address);

//            mapper.AddFunctionMap<ShipOwner, CompanyDataType>((o) => o.VesselInfo[0].Owners[0].Company, (so) => (so.Firm.HasValue && so.Firm.Value) ? new CompanyDataType() : null);
//            mapper.AddPropertyMap((o) => o.VesselInfo[0].Owners[0].Company.EIK, (c) => c[0].OwnersInfo[0].BulstatEGN);
//            mapper.AddPropertyMap((o) => o.VesselInfo[0].Owners[0].Company.CompanyName, (c) => c[0].OwnersInfo[0].Name);

//            mapper.AddFunctionMap<ShipOwner, PersonDataType>((o) => o.VesselInfo[0].Owners[0].Person, (so) => (so.Firm.HasValue && !so.Firm.Value) ? new PersonDataType() : null);
//            mapper.AddPropertyMap((o) => o.VesselInfo[0].Owners[0].Person.EGN, (c) => c[0].OwnersInfo[0].BulstatEGN);
//            mapper.AddPropertyMap((o) => o.VesselInfo[0].Owners[0].Person.Names.FirstName, (c) => c[0].OwnersInfo[0].Name);
//            mapper.AddPropertyMap((o) => o.VesselInfo[0].Owners[0].Person.Names.SurName, (c) => c[0].OwnersInfo[0].SurName);
//            mapper.AddPropertyMap((o) => o.VesselInfo[0].Owners[0].Person.Names.FamilyName, (c) => c[0].OwnersInfo[0].FamilyName);

//            mapper.AddPropertyMap((o) => o.VesselInfo[0].MainFeatures.BT, (c) => c[0].Characteristics.BT);
//            mapper.AddPropertyMap((o) => o.VesselInfo[0].MainFeatures.NT, (c) => c[0].Characteristics.NT);
//            mapper.AddPropertyMap((o) => o.VesselInfo[0].MainFeatures.MaxLength, (c) => c[0].Characteristics.MaxLength);
//            mapper.AddPropertyMap((o) => o.VesselInfo[0].MainFeatures.MaxWidth, (c) => c[0].Characteristics.MaxWidth);
//            mapper.AddPropertyMap((o) => o.VesselInfo[0].MainFeatures.Waterplane, (c) => c[0].Characteristics.Waterplane);
//            mapper.AddPropertyMap((o) => o.VesselInfo[0].MainFeatures.ShipboardHeight, (c) => c[0].Characteristics.ShipboardHeight);
//            mapper.AddPropertyMap((o) => o.VesselInfo[0].MainFeatures.Deadweight, (c) => c[0].Characteristics.DW);
//            mapper.AddPropertyMap((o) => o.VesselInfo[0].MainFeatures.NumberOfEngines, (c) => c[0].Characteristics.NumberOfEngines);
//            mapper.AddPropertyMap((o) => o.VesselInfo[0].MainFeatures.EnginesFuel, (c) => c[0].Characteristics.EnginesFuel);
//            mapper.AddPropertyMap((o) => o.VesselInfo[0].MainFeatures.SumEnginePower, (c) => c[0].Characteristics.SumEnginePower);
//            mapper.AddPropertyMap((o) => o.VesselInfo[0].MainFeatures.BodyNumber, (c) => c[0].Characteristics.BodyNumber);

//            mapper.AddCollectionMap<ShipCharacteristics>((o) => o.VesselInfo[0].MainFeatures.Engines, c => c.Engines);
//            mapper.AddPropertyMap((o) => o.VesselInfo[0].MainFeatures.Engines[0].SystemModification, (c) => c[0].Characteristics.Engines[0].SystemModification);
//            mapper.AddPropertyMap((o) => o.VesselInfo[0].MainFeatures.Engines[0].EngineNumber, (c) => c[0].Characteristics.Engines[0].EngineNumber);
//            mapper.AddPropertyMap((o) => o.VesselInfo[0].MainFeatures.Engines[0].Power, (c) => c[0].Characteristics.Engines[0].Power);
//            mapper.AddPropertyMap((o) => o.VesselInfo[0].MainFeatures.Engines[0].Type, (c) => c[0].Characteristics.Engines[0].EnginteType);

//            return mapper;
//        }

//        public CommonSignedResponse<RegistrationInfoByCharacteristicsRequestType, RegistrationInfoByCharacteristicsResponseType> RegistrationByCharacteristicsSearch(RegistrationInfoByCharacteristicsRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters)
//        {
//            Guid id = Guid.NewGuid();
//            LogData(additionalParameters, new { Request = argument.XmlSerialize(), Guid = id });

//            try
//            {
//                VesselsReportService.GovServiceReportSoapClient serviceClient = new GovServiceReportSoapClient("GovServiceReportSoap", ServiceUrl.Value);

//                GovReportShip[] serviceResult = serviceClient.ShipByCharacteristicTest(
//                    argument.VesselTypeSpecified ? argument.VesselType.ToString() : null,
//                    argument.VesselSubTypeSpecified ? argument.VesselSubType.ToString() : null,
//                    argument.HullNumber,
//                    argument.EngineFuelSpecified ? argument.EngineFuel.ToString() : null,
//                    argument.EngineNumber,
//                    argument.MaxLength.FromSpecified ? argument.MaxLength.From.ToString() : null,
//                    argument.MaxLength.ToSpecified ? argument.MaxLength.To.ToString() : null
//                        );

//                ObjectMapper<GovReportShip[], RegistrationInfoByCharacteristicsResponseType> mapper = CreateVesselsByCharacteristicsMapper(accessMatrix);
//                RegistrationInfoByCharacteristicsResponseType searchResults = new RegistrationInfoByCharacteristicsResponseType();
//                mapper.Map(serviceResult, searchResults);
//                return SigningUtils.CreateAndSign(argument,
//                    searchResults,
//                    accessMatrix,
//                    additionalParameters
//                    );
//            }
//            catch (Exception ex)
//            {
//                LogError(additionalParameters, ex, new { Guid = id });
//                throw ex;
//            }
//        }


//        private static ObjectMapper<GovReportShip[], RegistrationInfoByCharacteristicsResponseType> CreateVesselsByCharacteristicsMapper(AccessMatrix accessMatrix)
//        {
//            ObjectMapper<GovReportShip[], RegistrationInfoByCharacteristicsResponseType> mapper = new ObjectMapper<GovReportShip[], RegistrationInfoByCharacteristicsResponseType>(accessMatrix);

//            mapper.AddCollectionMap<GovReportShip[]>((o) => o.VesselInfo, c => c);
//            mapper.AddObjectMap((o) => o.VesselInfo[0].RegistrationData, (c) => c[0].RegistrationInfo);
//            mapper.AddObjectMap((o) => o.VesselInfo[0].MainFeatures, (c) => c[0].Characteristics);

//            mapper.AddPropertyMap((o) => o.VesselInfo[0].RegistrationData.ShipName, (c) => c[0].RegistrationInfo.ShipName);
//            mapper.AddPropertyMap((o) => o.VesselInfo[0].RegistrationData.ShipNameLatin, (c) => c[0].RegistrationInfo.ShipNameLatin);
//            mapper.AddPropertyMap((o) => o.VesselInfo[0].RegistrationData.RegistrationPort, (c) => c[0].RegistrationInfo.RegistrationPort);
//            mapper.AddPropertyMap((o) => o.VesselInfo[0].RegistrationData.RegistrationNumber, (c) => c[0].RegistrationInfo.RegistrationNumber);
//            mapper.AddPropertyMap((o) => o.VesselInfo[0].RegistrationData.Tom, (c) => c[0].RegistrationInfo.Tom);
//            mapper.AddPropertyMap((o) => o.VesselInfo[0].RegistrationData.Page, (c) => c[0].RegistrationInfo.Page);
//            mapper.AddPropertyMap((o) => o.VesselInfo[0].RegistrationData.Type, (c) => c[0].RegistrationInfo.Type);
//            mapper.AddFunctionMap<ShipRegistration, StatusEnum>((o) => o.VesselInfo[0].RegistrationData.Status, (c) => (StatusEnum)Enum.Parse(typeof(StatusEnum), c.Status.ToString()));

//            mapper.AddCollectionMap<GovReportShip>((o) => o.VesselInfo[0].Owners, s => s.OwnersInfo);

//            mapper.AddPropertyMap((o) => o.VesselInfo[0].Owners[0].IsCompany, (c) => c[0].OwnersInfo[0].Firm);
//            mapper.AddPropertyMap((o) => o.VesselInfo[0].Owners[0].ImoNumber, (c) => c[0].OwnersInfo[0].ImoNumber);
//            mapper.AddPropertyMap((o) => o.VesselInfo[0].Owners[0].IsUser, (c) => c[0].OwnersInfo[0].IsUser);
//            mapper.AddPropertyMap((o) => o.VesselInfo[0].Owners[0].Address, (c) => c[0].OwnersInfo[0].Address);

//            mapper.AddFunctionMap<ShipOwner, CompanyDataType>((o) => o.VesselInfo[0].Owners[0].Company, (so) => (so.Firm.HasValue && so.Firm.Value) ? new CompanyDataType() : null);
//            mapper.AddPropertyMap((o) => o.VesselInfo[0].Owners[0].Company.CompanyName, (c) => c[0].OwnersInfo[0].Name);
//            mapper.AddPropertyMap((o) => o.VesselInfo[0].Owners[0].Company.EIK, (c) => c[0].OwnersInfo[0].BulstatEGN);

//            mapper.AddFunctionMap<ShipOwner, PersonDataType>((o) => o.VesselInfo[0].Owners[0].Person, (so) => (so.Firm.HasValue && !so.Firm.Value) ? new PersonDataType() : null);
//            mapper.AddPropertyMap((o) => o.VesselInfo[0].Owners[0].Person.Names.FirstName, (c) => c[0].OwnersInfo[0].Name);
//            mapper.AddPropertyMap((o) => o.VesselInfo[0].Owners[0].Person.Names.SurName, (c) => c[0].OwnersInfo[0].SurName);
//            mapper.AddPropertyMap((o) => o.VesselInfo[0].Owners[0].Person.Names.FamilyName, (c) => c[0].OwnersInfo[0].FamilyName);
//            mapper.AddPropertyMap((o) => o.VesselInfo[0].Owners[0].Person.EGN, (c) => c[0].OwnersInfo[0].BulstatEGN);

//            mapper.AddPropertyMap((o) => o.VesselInfo[0].MainFeatures.BT, (c) => c[0].Characteristics.BT);
//            mapper.AddPropertyMap((o) => o.VesselInfo[0].MainFeatures.NT, (c) => c[0].Characteristics.NT);
//            mapper.AddPropertyMap((o) => o.VesselInfo[0].MainFeatures.MaxLength, (c) => c[0].Characteristics.MaxLength);
//            mapper.AddPropertyMap((o) => o.VesselInfo[0].MainFeatures.MaxWidth, (c) => c[0].Characteristics.MaxWidth);
//            mapper.AddPropertyMap((o) => o.VesselInfo[0].MainFeatures.Waterplane, (c) => c[0].Characteristics.Waterplane);
//            mapper.AddPropertyMap((o) => o.VesselInfo[0].MainFeatures.ShipboardHeight, (c) => c[0].Characteristics.ShipboardHeight);
//            mapper.AddPropertyMap((o) => o.VesselInfo[0].MainFeatures.Deadweight, (c) => c[0].Characteristics.DW);
//            mapper.AddPropertyMap((o) => o.VesselInfo[0].MainFeatures.NumberOfEngines, (c) => c[0].Characteristics.NumberOfEngines);
//            mapper.AddPropertyMap((o) => o.VesselInfo[0].MainFeatures.EnginesFuel, (c) => c[0].Characteristics.EnginesFuel);
//            mapper.AddPropertyMap((o) => o.VesselInfo[0].MainFeatures.SumEnginePower, (c) => c[0].Characteristics.SumEnginePower);
//            mapper.AddPropertyMap((o) => o.VesselInfo[0].MainFeatures.BodyNumber, (c) => c[0].Characteristics.BodyNumber);

//            mapper.AddCollectionMap<ShipCharacteristics>((o) => o.VesselInfo[0].MainFeatures.Engines, c => c.Engines);
//            mapper.AddPropertyMap((o) => o.VesselInfo[0].MainFeatures.Engines[0].SystemModification, (c) => c[0].Characteristics.Engines[0].SystemModification);
//            mapper.AddPropertyMap((o) => o.VesselInfo[0].MainFeatures.Engines[0].EngineNumber, (c) => c[0].Characteristics.Engines[0].EngineNumber);
//            mapper.AddPropertyMap((o) => o.VesselInfo[0].MainFeatures.Engines[0].Power, (c) => c[0].Characteristics.Engines[0].Power);
//            mapper.AddPropertyMap((o) => o.VesselInfo[0].MainFeatures.Engines[0].Type, (c) => c[0].Characteristics.Engines[0].EnginteType);

//            return mapper;
//        }
//    }
//}
