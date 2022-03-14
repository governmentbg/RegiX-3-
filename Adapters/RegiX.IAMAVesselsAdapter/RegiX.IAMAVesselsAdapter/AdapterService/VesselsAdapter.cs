using System;
using System.Collections.Generic;
using System.Linq;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.Common.Utils;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.IAMAVesselsAdapter.VesselsReportService;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.IAMAVesselsAdapter.Ships;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Adapters.Common.DataContracts;
using TechnoLogica.RegiX.Common.DataContracts.Parameter;
using TechnoLogica.RegiX.Adapters.Common.ObjectMapping;

namespace TechnoLogica.RegiX.IAMAVesselsAdapter.AdapterService
{
    [Export(typeof(IAdapterService))]
    [ExportFullName(typeof(VesselsAdapter), typeof(IAdapterService))]
    [ExportSimpleName(typeof(VesselsAdapter), typeof(IAdapterService))]
    public class VesselsAdapter : WebServiceAdapterService.SoapServiceBaseAdapterService, IVesselsAdapter, IAdapterService
    {

        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(VesselsAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> WebServiceUrl =
            new ParameterInfo<string>("http://172.16.69.13:8078/IamaV2Mockup/GovServiceReport.svc")
            //new ParameterInfo<string>("http://localhost:51834/GovServiceReport.svc")
            {
                Key = Constants.WebServiceUrlParameterKeyName,
                Description = "Connection String for SOAP Web Service",
                OwnerAssembly = typeof(VesselsAdapter).Assembly
            };


        #region PublicOperations

        public CommonSignedResponse<Ships.ShipsByOwnerRequest, ShipsResponse> RegistrationSearchByOwner(Ships.ShipsByOwnerRequest argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(additionalParameters, new { Request = argument.Serialize(), Guid = id });
            try
            {
                VesselsReportService.GovServiceReportSoapClient serviceClient = new GovServiceReportSoapClient("GovServiceReportSoap", WebServiceUrl.Value);
                VesselsReportService.GovReportShip[] serviceResult = serviceClient.ShipsByOwner(argument.egn);

                ShipsResponse searchResults = new ShipsResponse();
                ObjectMapper<VesselsReportService.GovReportShip[], ShipsResponse> mapper = CreateShipsResponseMapper(accessMatrix);
                mapper.Map(serviceResult, searchResults);

                return SigningUtils.CreateAndSign(argument,
                    searchResults,
                    accessMatrix,
                    additionalParameters);
            }
            catch (Exception ex)
            {
                LogError(additionalParameters, ex, new { Guid = id });
                throw ex;
            }
        }

        public CommonSignedResponse<Ships.ShipsByCharacteristicsRequest, ShipsResponse> RegistrationByCharacteristicsSearch(Ships.ShipsByCharacteristicsRequest argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(additionalParameters, new { Request = argument.XmlSerialize(), Guid = id });

            try
            {
                VesselsReportService.GovServiceReportSoapClient serviceClient = new GovServiceReportSoapClient("GovServiceReportSoap", WebServiceUrl.Value);

                VesselsReportService.GovReportShip[] serviceResult = serviceClient.ShipByCharacteristics(
                    shipType: argument.shipType,
                    shipSubType: argument.shipSubType,
                    hullNumber: argument.hullNumber,
                    engineFuel: argument.engineFuel,
                    engineNumber: argument.engineNumber,
                    maxLengthFrom: argument.maxLengthFrom,
                    maxLengthTo: argument.maxLengthTo
                        );

                ShipsResponse searchResults = new ShipsResponse();
                ObjectMapper<VesselsReportService.GovReportShip[], ShipsResponse> mapper = CreateShipsResponseMapper(accessMatrix);
                mapper.Map(serviceResult, searchResults);

                return SigningUtils.CreateAndSign(argument,
                    searchResults,
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

        public CommonSignedResponse<NomenclaturesRequest, NomenclatureResponse> GetNomenclatures(NomenclaturesRequest argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(additionalParameters, new { Request = argument.XmlSerialize(), Guid = id });

            try
            {
                VesselsReportService.GovServiceReportSoapClient serviceClient = new GovServiceReportSoapClient("GovServiceReportSoap", WebServiceUrl.Value);

                NomenclatureResponse searchResults = new NomenclatureResponse();
                searchResults.ShipTypeNomenclature = new List<Ships.Nomenclature>();
                searchResults.ShipSubTypeNomenclature = new List<Ships.Nomenclature>();
                searchResults.EngineFuelNomenclature = new List<Ships.Nomenclature>();

                var shipTypeResult = serviceClient.ShipType();
                foreach (var res in shipTypeResult)
                {
                    searchResults.ShipTypeNomenclature.Add(new Ships.Nomenclature { Id = res.Id, IdSpecified = true, Name = res.Name });
                }

                var shipSubType = serviceClient.ShipSubType();
                foreach (var res in shipSubType)
                {
                    searchResults.ShipSubTypeNomenclature.Add(new Ships.Nomenclature { Id = res.Id, IdSpecified = true, Name = res.Name });
                }

                var engineFuelResult = serviceClient.EngineFuel();
                foreach (var res in engineFuelResult)
                {
                    searchResults.EngineFuelNomenclature.Add(new Ships.Nomenclature { Id = res.Id, IdSpecified = true, Name = res.Name });
                }

                NomenclatureResponse nomResponse = new NomenclatureResponse();
                ObjectMapper<NomenclatureResponse, NomenclatureResponse> mapper = CreateNomenclaturesMapper(accessMatrix);
                mapper.Map(searchResults, nomResponse);

                return SigningUtils.CreateAndSign(argument,
                    nomResponse,
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
        
        #endregion


        #region PrivateMappers

        private static ObjectMapper<VesselsReportService.GovReportShip[], ShipsResponse> CreateShipsResponseMapper(AccessMatrix accessMatrix)
        {
            ObjectMapper<VesselsReportService.GovReportShip[], ShipsResponse> mapper = new ObjectMapper<VesselsReportService.GovReportShip[], ShipsResponse>(accessMatrix);
            
            mapper.AddCollectionMap<VesselsReportService.GovReportShip[]>((o) => o.Ships, c => c.ToArray());

            mapper.AddObjectMap((o) => o.Ships[0].RegistrationInfo, (c) => c[0].RegistrationInfo);

            mapper.AddPropertyMap((o) => o.Ships[0].RegistrationInfo.ShipName, (c) => c[0].RegistrationInfo.ShipName);
            mapper.AddPropertyMap((o) => o.Ships[0].RegistrationInfo.ShipNameLatin, (c) => c[0].RegistrationInfo.ShipNameLatin);
            mapper.AddPropertyMap((o) => o.Ships[0].RegistrationInfo.RegistrationPort, (c) => c[0].RegistrationInfo.RegistrationPort);
            mapper.AddPropertyMap((o) => o.Ships[0].RegistrationInfo.RegistrationNumber, (c) => c[0].RegistrationInfo.RegistrationNumber);
            mapper.AddPropertyMap((o) => o.Ships[0].RegistrationInfo.Tom, (c) => c[0].RegistrationInfo.Tom);
            mapper.AddPropertyMap((o) => o.Ships[0].RegistrationInfo.Page, (c) => c[0].RegistrationInfo.Page);
            mapper.AddPropertyMap((o) => o.Ships[0].RegistrationInfo.Type, (c) => c[0].RegistrationInfo.Type);
            mapper.AddFunctionMap<VesselsReportService.ShipRegistration, Ships.StatusEnum>((o) => o.Ships[0].RegistrationInfo.Status, (c) => (Ships.StatusEnum)Enum.Parse(typeof(Ships.StatusEnum), c.Status.ToString()));

            mapper.AddCollectionMap<VesselsReportService.GovReportShip>((o) => o.Ships[0].OwnersInfo, s => s.OwnersInfo);

            mapper.AddPropertyMap((o) => o.Ships[0].OwnersInfo[0].Firm, (c) => c[0].OwnersInfo[0].Firm);
            mapper.AddPropertyMap((o) => o.Ships[0].OwnersInfo[0].ImoNumber, (c) => c[0].OwnersInfo[0].ImoNumber);
            mapper.AddPropertyMap((o) => o.Ships[0].OwnersInfo[0].IsUser, (c) => c[0].OwnersInfo[0].IsUser);
            mapper.AddPropertyMap((o) => o.Ships[0].OwnersInfo[0].Address, (c) => c[0].OwnersInfo[0].Address);
            mapper.AddPropertyMap((o) => o.Ships[0].OwnersInfo[0].BulstatEGN, (c) => c[0].OwnersInfo[0].BulstatEGN);
            mapper.AddPropertyMap((o) => o.Ships[0].OwnersInfo[0].Name, (c) => c[0].OwnersInfo[0].Name);
            mapper.AddPropertyMap((o) => o.Ships[0].OwnersInfo[0].SurName, (c) => c[0].OwnersInfo[0].SurName);
            mapper.AddPropertyMap((o) => o.Ships[0].OwnersInfo[0].FamilyName, (c) => c[0].OwnersInfo[0].FamilyName);

            mapper.AddObjectMap((o) => o.Ships[0].Characteristics, (c) => c[0].Characteristics);

            mapper.AddPropertyMap((o) => o.Ships[0].Characteristics.BT, (c) => c[0].Characteristics.BT);
            mapper.AddPropertyMap((o) => o.Ships[0].Characteristics.NT, (c) => c[0].Characteristics.NT);
            mapper.AddPropertyMap((o) => o.Ships[0].Characteristics.MaxLength, (c) => c[0].Characteristics.MaxLength);
            mapper.AddPropertyMap((o) => o.Ships[0].Characteristics.MaxWidth, (c) => c[0].Characteristics.MaxWidth);
            mapper.AddPropertyMap((o) => o.Ships[0].Characteristics.Waterplane, (c) => c[0].Characteristics.Waterplane);
            mapper.AddPropertyMap((o) => o.Ships[0].Characteristics.ShipboardHeight, (c) => c[0].Characteristics.ShipboardHeight);
            mapper.AddPropertyMap((o) => o.Ships[0].Characteristics.DW, (c) => c[0].Characteristics.DW);
            mapper.AddPropertyMap((o) => o.Ships[0].Characteristics.Displacement, (c) => c[0].Characteristics.Displacement);
            mapper.AddPropertyMap((o) => o.Ships[0].Characteristics.NumberOfEngines, (c) => c[0].Characteristics.NumberOfEngines);
            mapper.AddPropertyMap((o) => o.Ships[0].Characteristics.EnginesFuel, (c) => c[0].Characteristics.EnginesFuel);
            mapper.AddPropertyMap((o) => o.Ships[0].Characteristics.SumEnginePower, (c) => c[0].Characteristics.SumEnginePower);
            mapper.AddPropertyMap((o) => o.Ships[0].Characteristics.BodyNumber, (c) => c[0].Characteristics.BodyNumber);

            mapper.AddCollectionMap<VesselsReportService.ShipCharacteristics>((o) => o.Ships[0].Characteristics.Engines, c => c.Engines);
            mapper.AddPropertyMap((o) => o.Ships[0].Characteristics.Engines[0].SystemModification, (c) => c[0].Characteristics.Engines[0].SystemModification);
            mapper.AddPropertyMap((o) => o.Ships[0].Characteristics.Engines[0].EngineNumber, (c) => c[0].Characteristics.Engines[0].EngineNumber);
            mapper.AddPropertyMap((o) => o.Ships[0].Characteristics.Engines[0].Power, (c) => c[0].Characteristics.Engines[0].Power);
            mapper.AddPropertyMap((o) => o.Ships[0].Characteristics.Engines[0].EnginteType, (c) => c[0].Characteristics.Engines[0].EnginteType);

            return mapper;
        }
        
        private static ObjectMapper<NomenclatureResponse, NomenclatureResponse> CreateNomenclaturesMapper(AccessMatrix accessMatrix)
        {
            ObjectMapper<NomenclatureResponse, NomenclatureResponse> mapper = new ObjectMapper<NomenclatureResponse, NomenclatureResponse>(accessMatrix);
            
          //  mapper.AddObjectMap<NomenclatureResponse, NomenclatureResponse>((o) => o, (c) => c);

            mapper.AddCollectionMap<NomenclatureResponse>((o) => o.ShipTypeNomenclature, c => c.ShipTypeNomenclature);
            mapper.AddPropertyMap((o) => o.ShipTypeNomenclature[0].Id, (c) => c.ShipTypeNomenclature[0].Id);
            mapper.AddPropertyMap((o) => o.ShipTypeNomenclature[0].Name, (c) => c.ShipTypeNomenclature[0].Name);

            mapper.AddCollectionMap<NomenclatureResponse>((o) => o.ShipSubTypeNomenclature, c => c.ShipSubTypeNomenclature);
            mapper.AddPropertyMap((o) => o.ShipSubTypeNomenclature[0].Id, (c) => c.ShipSubTypeNomenclature[0].Id);
            mapper.AddPropertyMap((o) => o.ShipSubTypeNomenclature[0].Name, (c) => c.ShipSubTypeNomenclature[0].Name);

            mapper.AddCollectionMap<NomenclatureResponse>((o) => o.EngineFuelNomenclature, c => c.EngineFuelNomenclature);
            mapper.AddPropertyMap((o) => o.EngineFuelNomenclature[0].Id, (c) => c.EngineFuelNomenclature[0].Id);
            mapper.AddPropertyMap((o) => o.EngineFuelNomenclature[0].Name, (c) => c.EngineFuelNomenclature[0].Name);
           
            return mapper;
        }

        #endregion

    }
}
