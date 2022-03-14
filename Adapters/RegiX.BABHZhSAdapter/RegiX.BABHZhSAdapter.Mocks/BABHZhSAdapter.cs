namespace TechnoLogica.RegiX.BABHZhSAdapter.AdapterService
{
    //public class BABHZhSAdapter : WebServiceAdapterService.SoapServiceBaseAdapterService, IBABHZhSAdapter, IAdapterService
    //{
    //    [Export(typeof(ParameterInfo))]
    //    public static ParameterInfo<string> WebServiceUrl =
    //    new ParameterInfo<string>("http://172.16.69.13:8081/BABHZhSAdapterMockup/BABHZhSServiceImplServiceInterfaces.svc")
    //    {
    //        Key = Constants.WebServiceUrlParameterKeyName,
    //        Description = "Connection String for SOAP Web Service",
    //        OwnerAssembly = typeof(BABHZhSAdapter).Assembly
    //    };

    //    //public BABHZhSAdapter()
    //    //{
    //    //    WebServiceUrl =
    //    //        new ParameterInfo<string>("http://172.16.69.13:8081/BABHZhSAdapterMockup/BABHZhSServiceImplServiceInterfaces.svc")
    //    //        {
    //    //            Key = "ServiceUrl",
    //    //            Description = "BABHZh Web Service Url",
    //    //            OwnerAssembly = typeof(BABHZhSAdapter).Assembly
    //    //        };
    //    //}

    //    [Export(typeof(ParameterInfo))]
    //    public static ParameterInfo<string> EndpointConfigurationName =
    //        new ParameterInfo<string>("ReportWSPort")
    //        {
    //            Key = "EndpointConfigurationName",
    //            Description = "EndpointConfigurationName for ReportWSClient",
    //            OwnerAssembly = typeof(BABHZhSAdapter).Assembly
    //        };

    //    // Справка за идентифицирано животно
    //    public CommonSignedResponse<AnimalIdentificationRequestType, AnimalIdentificationResponseType> GetAnimalIdentification(AnimalIdentificationRequestType argument, Common.ObjectMapping.AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
    //    {
    //        Guid id = Guid.NewGuid();
    //        LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
    //        try
    //        {
    //            AnimalIdentificationResponseType result = new AnimalIdentificationResponseType();
    //            BABHServiceReference.ReportWSClient babhClient = new BABHServiceReference.ReportWSClient(EndpointConfigurationName.Value, WebServiceUrl.Value);
    //            BABHServiceReference.animalWsObject[] animalInfo = babhClient.getSpravkaJivotni(argument.AnimalIdentificationNumber);
    //            ObjectMapper<BABHServiceReference.animalWsObject[], AnimalIdentificationResponseType> mapper = CreateAnimalIdentificationMapper(accessMatrix);
    //            mapper.Map(animalInfo, result);
    //            return
    //                SigningUtils.CreateAndSign(
    //                    argument,
    //                    result,
    //                    accessMatrix,
    //                    aditionalParameters
    //                );
    //        }
    //        catch (Exception ex)
    //        {
    //            LogError(aditionalParameters, ex, new { Guid = id });
    //            throw ex;
    //        }

    //    }

    //    private string GetExceptionMessage(Exception ex)
    //    {
    //        return "Exception:" + ex.Message + "Stack trace: " + ex.StackTrace + (ex.InnerException != null ? "; Inner Exception:" + ex.InnerException.Message + "Inner Stack trace: " + ex.InnerException.StackTrace + (ex.InnerException.InnerException != null ? "; InnerInner Exception:" + ex.InnerException.InnerException.Message + "Inner Stack trace: " + ex.InnerException.InnerException.StackTrace : string.Empty) : string.Empty);
    //    }

    //    private ObjectMapper<BABHServiceReference.animalWsObject[], AnimalIdentificationResponseType> CreateAnimalIdentificationMapper(AccessMatrix accessMatrix)
    //    {
    //        ObjectMapper<BABHServiceReference.animalWsObject[], AnimalIdentificationResponseType> mapper = new ObjectMapper<BABHServiceReference.animalWsObject[], AnimalIdentificationResponseType>(accessMatrix);

    //        mapper.AddCollectionMap<BABHServiceReference.animalWsObject[]>((o) => o.AnimalIdentification, p => (p != null ? p.ToList<BABHServiceReference.animalWsObject>() : null));


    //        mapper.AddCollectionMap<BABHServiceReference.animalWsObject>(o => o.AnimalIdentification[0].IdentificationDataList, p => p.identsList);
    //        mapper.AddPropertyMap(o => o.AnimalIdentification[0].IdentificationDataList[0].Type, p => p[0].identsList[0].type);
    //        mapper.AddPropertyMap(o => o.AnimalIdentification[0].IdentificationDataList[0].Number, p => p[0].identsList[0].nomer);
    //        mapper.AddPropertyMap(o => o.AnimalIdentification[0].IdentificationDataList[0].Status, p => p[0].identsList[0].status);
    //        mapper.AddPropertyMap(o => o.AnimalIdentification[0].IdentificationDataList[0].Foreign, p => p[0].identsList[0].chujd);
    //        mapper.AddPropertyMap(o => o.AnimalIdentification[0].AnimalProfile.Type, p => p[0].vid);
    //        mapper.AddPropertyMap(o => o.AnimalIdentification[0].AnimalProfile.Nationality, p => p[0].nacionalnost);
    //        mapper.AddPropertyMap(o => o.AnimalIdentification[0].AnimalProfile.Breed, p => p[0].poroda);
    //        mapper.AddPropertyMap(o => o.AnimalIdentification[0].AnimalProfile.Sex, p => p[0].pol);
    //        mapper.AddPropertyMap(o => o.AnimalIdentification[0].AnimalProfile.Color, p => p[0].cvqt);
    //        mapper.AddPropertyMap(o => o.AnimalIdentification[0].AnimalProfile.BirthDate, p => p[0].dataRajdane);
    //        mapper.AddPropertyMap(o => o.AnimalIdentification[0].AnimalProfile.UniqueNumber, p => p[0].unikalenNomer);
    //        mapper.AddPropertyMap(o => o.AnimalIdentification[0].AnimalPassport.Number, p => p[0].nomerPassport);
    //        mapper.AddPropertyMap(o => o.AnimalIdentification[0].AnimalPassport.IssueDate, p => p[0].dataIzdavanePassport);
    //        mapper.AddPropertyMap(o => o.AnimalIdentification[0].AnimalPassport.Status, p => p[0].statusPassport);
    //        mapper.AddPropertyMap(o => o.AnimalIdentification[0].AnimalStatus.Status, p => p[0].status);
    //        mapper.AddPropertyMap(o => o.AnimalIdentification[0].AnimalStatus.StatusDate, p => p[0].dateStatus);
    //        mapper.AddPropertyMap(o => o.AnimalIdentification[0].AnimalResidence.OEZNumber, p => p[0].nomerOez);
    //        mapper.AddPropertyMap(o => o.AnimalIdentification[0].AnimalResidence.District, p => p[0].oblast);
    //        mapper.AddPropertyMap(o => o.AnimalIdentification[0].AnimalResidence.Municipality, p => p[0].obshtina);
    //        mapper.AddPropertyMap(o => o.AnimalIdentification[0].AnimalResidence.Settlement, p => p[0].nasMesto);
    //        mapper.AddPropertyMap(o => o.AnimalIdentification[0].AnimalResidence.Address, p => p[0].adress);
    //        mapper.AddPropertyMap(o => o.AnimalIdentification[0].AnimalResidence.DateFrom, p => p[0].dateBegDom);
    //        mapper.AddPropertyMap(o => o.AnimalIdentification[0].AnimalOwner.OwnerNames, p => p[0].imeSobs);
    //        mapper.AddPropertyMap(o => o.AnimalIdentification[0].AnimalOwner.OwnerIdentifier, p => p[0].egn);
    //        mapper.AddPropertyMap(o => o.AnimalIdentification[0].AnimalOwner.OwnerDate, p => p[0].dateBegSobs);

    //        return mapper;
    //    }



    //    public CommonSignedResponse<MotorVehicleLicenceRequestType, MotorVehicleLicenceResponseType> GetMotorVehicleLicence(MotorVehicleLicenceRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
    //    {
    //        Guid id = Guid.NewGuid();
    //        LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
    //        try
    //        {
    //            MotorVehicleLicenceResponseType result = new MotorVehicleLicenceResponseType();
    //            BABHServiceReference.ReportWSClient babhClient = new BABHServiceReference.ReportWSClient(EndpointConfigurationName.Value, WebServiceUrl.Value);
    //            BABHServiceReference.mpsWsObject info = babhClient.getSpravkaMps(argument.MotorVehicleRegNumber);
    //            ObjectMapper<BABHServiceReference.mpsWsObject, MotorVehicleLicenceResponseType> mapper = CreateMotorVehicleMapper(accessMatrix);
    //            mapper.Map(info, result);
    //            return
    //                SigningUtils.CreateAndSign(
    //                    argument,
    //                    result,
    //                    accessMatrix,
    //                    aditionalParameters
    //                );
    //        }
    //        catch (Exception ex)
    //        {
    //            LogError(aditionalParameters, ex, new { Guid = id });
    //            throw ex;
    //        }
    //    }

    //    private ObjectMapper<BABHServiceReference.mpsWsObject, MotorVehicleLicenceResponseType> CreateMotorVehicleMapper(AccessMatrix accessMatrix)
    //    {
    //        ObjectMapper<BABHServiceReference.mpsWsObject, MotorVehicleLicenceResponseType> mapper = new ObjectMapper<BABHServiceReference.mpsWsObject, MotorVehicleLicenceResponseType>(accessMatrix);

    //        mapper.AddPropertyMap(o => o.MotorVehicleData.MotorVehicleType, p => p.vidMps);
    //        mapper.AddPropertyMap(o => o.MotorVehicleData.RegistrationNumber, p => p.regNomer);
    //        mapper.AddPropertyMap(o => o.MotorVehicleData.Area, p => p.space);
    //        mapper.AddPropertyMap(o => o.MotorVehicleData.Status, p => p.status);
    //        mapper.AddPropertyMap(o => o.MotorVehicleData.StatusDate, p => p.dataStatus);
    //        //mapper.AddPropertyMap(o => o.MotorVehicleData.AdditionalInfo, p => (p.dopInfo == null ? null : p.dopInfo.dopInfo));
    //        mapper.AddFunctionMap<BABHServiceReference.mpsWsObject, string>(o => o.MotorVehicleData.AdditionalInfo, p => (p.dopInfo == null ? null : p.dopInfo.dopInfo));

    //        mapper.AddCollectionMap<BABHServiceReference.mpsWsObject>(o => o.LicencesData, p => p.sertifikatList);
    //        mapper.AddPropertyMap(o => o.LicencesData[0].LicenceType, p => p.sertifikatList[0].vidSert);
    //        mapper.AddPropertyMap(o => o.LicencesData[0].LicenceNumber, p => p.sertifikatList[0].regNomer);
    //        mapper.AddPropertyMap(o => o.LicencesData[0].DateFrom, p => p.sertifikatList[0].datBeg);
    //        mapper.AddPropertyMap(o => o.LicencesData[0].DateTo, p => p.sertifikatList[0].datEnd);
    //        mapper.AddPropertyMap(o => o.LicencesData[0].RevokeReason, p => p.sertifikatList[0].prichina);

    //        mapper.AddCollectionMap<BABHServiceReference.mpsWsObject>(o => o.UsedAnimalTypes, p => p.jivotniMpsList);
    //        mapper.AddPropertyMap(o => o.UsedAnimalTypes[0].AnimalKind, p => p.jivotniMpsList[0].vidJivotno);
    //        mapper.AddPropertyMap(o => o.UsedAnimalTypes[0].Count, p => p.jivotniMpsList[0].broi);

    //        mapper.AddCollectionMap<BABHServiceReference.mpsWsObject>(o => o.ReltionshipsData, p => p.vrazkiLicaOrgMpsList);
    //        mapper.AddPropertyMap(o => o.ReltionshipsData[0].RelationshipType, p => p.vrazkiLicaOrgMpsList[0].tipVraz);
    //        mapper.AddPropertyMap(o => o.ReltionshipsData[0].Name, p => p.vrazkiLicaOrgMpsList[0].liceOrg);
    //        mapper.AddPropertyMap(o => o.ReltionshipsData[0].Identificator, p => p.vrazkiLicaOrgMpsList[0].egnBulstat);
    //        mapper.AddPropertyMap(o => o.ReltionshipsData[0].DateFrom, p => p.vrazkiLicaOrgMpsList[0].dataBeg);
    //        mapper.AddPropertyMap(o => o.ReltionshipsData[0].DateTo, p => p.vrazkiLicaOrgMpsList[0].dataEnd);

    //        return mapper;
    //    }

    //    public CommonSignedResponse<RegisteredAnimalsByCategoryRequestType, RegisteredAnimalsByCategoryResponseType> GetRegisteredAnimalsByCategory(RegisteredAnimalsByCategoryRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
    //    {
    //        Guid id = Guid.NewGuid();
    //        LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
    //        try
    //        {
    //            RegisteredAnimalsByCategoryResponseType result = new RegisteredAnimalsByCategoryResponseType();
    //            BABHServiceReference.ReportWSClient babhClient = new BABHServiceReference.ReportWSClient(EndpointConfigurationName.Value, WebServiceUrl.Value);
    //            BABHServiceReference.sprZemedelskiProizv info = babhClient.getSpravkaZemProizv(argument.EGN, argument.ValidDate);
    //            ObjectMapper<BABHServiceReference.sprZemedelskiProizv, RegisteredAnimalsByCategoryResponseType> mapper = CreateAnimalCategoryMapper(accessMatrix, argument.ValidDate);
    //            mapper.Map(info, result);
    //            return
    //                SigningUtils.CreateAndSign(
    //                    argument,
    //                    result,
    //                    accessMatrix,
    //                    aditionalParameters
    //                );
    //        }
    //        catch (Exception ex)
    //        {
    //            LogError(aditionalParameters, ex, new { Guid = id });
    //            throw ex;
    //        }
    //    }

    //    private ObjectMapper<BABHServiceReference.sprZemedelskiProizv, RegisteredAnimalsByCategoryResponseType> CreateAnimalCategoryMapper(AccessMatrix accessMatrix, DateTime validDate)
    //    {
    //        ObjectMapper<BABHServiceReference.sprZemedelskiProizv, RegisteredAnimalsByCategoryResponseType> mapper = new ObjectMapper<BABHServiceReference.sprZemedelskiProizv, RegisteredAnimalsByCategoryResponseType>(accessMatrix);

    //        mapper.AddPropertyMap(o => o.FarmerData.FarmerName, p => p.name);
    //        mapper.AddPropertyMap(o => o.FarmerData.FarmerEGN, p => p.EGN);
    //        mapper.AddCollectionMap<BABHServiceReference.sprZemedelskiProizv>(o => o.FarmsInformation, p => p.jivObList);
    //        mapper.AddPropertyMap(o => o.FarmsInformation[0].FarmMainData.FarmNumber, p => p.jivObList[0].nomerOb);
    //        mapper.AddPropertyMap(o => o.FarmsInformation[0].FarmMainData.OldFarmNumber, p => p.jivObList[0].oldNomerOb);
    //        mapper.AddPropertyMap(o => o.FarmsInformation[0].FarmMainData.DistrictName, p => p.jivObList[0].oblastOb);
    //        mapper.AddPropertyMap(o => o.FarmsInformation[0].FarmMainData.MunicipalityName, p => p.jivObList[0].obshtOb);
    //        mapper.AddPropertyMap(o => o.FarmsInformation[0].FarmMainData.TerritorialUnitName, p => p.jivObList[0].mestoOb);
    //        mapper.AddPropertyMap(o => o.FarmsInformation[0].FarmMainData.FarmerRelationship, p => p.jivObList[0].roliaZemProizv);

    //        mapper.AddCollectionMap<BABHServiceReference.jivObektSprZem>(o => o.FarmsInformation[0].RelationshipPersonsData, p => p.licaList);
    //        mapper.AddPropertyMap(o => o.FarmsInformation[0].RelationshipPersonsData[0].Name, p => p.jivObList[0].licaList[0].name);
    //        mapper.AddPropertyMap(o => o.FarmsInformation[0].RelationshipPersonsData[0].EGN, p => p.jivObList[0].licaList[0].EGN);
    //        mapper.AddPropertyMap(o => o.FarmsInformation[0].RelationshipPersonsData[0].Type, p => p.jivObList[0].licaList[0].roliaLice);

    //        mapper.AddCollectionMap<BABHServiceReference.jivObektSprZem>(o => o.FarmsInformation[0].AnimalCategories, p => p.pokList);
    //        mapper.AddPropertyMap(o => o.FarmsInformation[0].AnimalCategories[0].CategoryCode, p => p.jivObList[0].pokList[0].kodKat);
    //        mapper.AddPropertyMap(o => o.FarmsInformation[0].AnimalCategories[0].CategoryName, p => p.jivObList[0].pokList[0].nameKat);
    //        mapper.AddPropertyMap(o => o.FarmsInformation[0].AnimalCategories[0].Quantity, p => p.jivObList[0].pokList[0].sumaKat);

    //        mapper.AddCollectionMap<BABHServiceReference.jivObektSprZem>(o => o.FarmsInformation[0].EarTags, p => p.markiList);
    //        mapper.AddPropertyMap(o => o.FarmsInformation[0].EarTags[0].CategoryCode, p => p.jivObList[0].markiList[0].kodKat);
    //        mapper.AddPropertyMap(o => o.FarmsInformation[0].EarTags[0].CategoryName, p => p.jivObList[0].markiList[0].nameKat);
    //        mapper.AddPropertyMap(o => o.FarmsInformation[0].EarTags[0].Tags, p => p.jivObList[0].markiList[0].markiKat);


    //        mapper.AddConstantMap((r) => r.ValidDate, validDate);

    //        return mapper;
    //    }

//}
}
