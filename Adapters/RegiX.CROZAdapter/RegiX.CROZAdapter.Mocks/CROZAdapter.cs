namespace TechnoLogica.RegiX.CROZAdapter.AdapterService
{
    //public class CROZAdapter : WebServiceAdapterService.SoapServiceBaseAdapterService, ICROZAdapter, IAdapterService
    //{


    //[Export(typeof(ParameterInfo))]
    //public static ParameterInfo<string> WebServiceUrl =
    //    new ParameterInfo<string>("http://172.16.69.13:8081/CROZAdapterMockup/CROZServiceImplServiceInterfaces.svc")
    //    {
    //        Key = Constants.WebServiceUrlParameterKeyName,
    //        Description = "Connection String for SOAP Web Service",
    //        OwnerAssembly = typeof(CROZAdapter).Assembly
    //    };

    //#region
    //[Export(typeof(ParameterInfo))]
    //public static ParameterInfo<string> ImageProxyServletUrl =
    //    new ParameterInfo<string>("http://172.16.69.13:8081/CROZAdapterMockup/CROZServiceImplServiceInterfaces.svc")
    //    {
    //        Key = "ImageProxyServlet",
    //        Description = "servlet Url for object archives access",
    //        OwnerAssembly = typeof(CROZAdapter).Assembly
    //    };


    //[Export(typeof(ParameterInfo))]
    //public static ParameterInfo<string> ImageFormat =
    //    new ParameterInfo<string>("tifnoconv")
    //    {
    //        Key = "ImageFormat",
    //        Description = "image type sent to the servlet for object archives access",
    //        OwnerAssembly = typeof(CROZAdapter).Assembly
    //    };

    //[Export(typeof(ParameterInfo))]
    //public static ParameterInfo<string> EndpointConfigurationName =
    //    new ParameterInfo<string>("WebServices")
    //    {
    //        Key = "EndpointConfigurationName",
    //        Description = "EndpointConfigurationName for CROZWebServiceClient",
    //        OwnerAssembly = typeof(CROZAdapter).Assembly
    //    };

    //#endregion
    ////public override ConnectionStatusInfo CheckRegisterConnection()
    ////{
    ////    return new ConnectionStatusInfo()
    ////    {
    ////        Description = "Connection is OK!",
    ////        status = ConnectionStatus.OK
    ////    };
    ////}

    ////Намира участници по зададен идентификационен код или наименование
    //public CommonSignedResponse<ParticipantsSearchType, ParticipantsDataType> ParticipantsSearch(ParticipantsSearchType argument, Common.ObjectMapping.AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
    //{
    //    //поне един от входните параметри ттрябва да е попълнен. В противен случай - гърми

    //    Guid id = Guid.NewGuid();
    //    LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
    //    try
    //    {

    //        if (argument.ParticipantCode == null && argument.ParticipantName == null)
    //        {
    //            throw new FaultException("ParticipantCode and ParticipantName cannot be null at the same time!");
    //        }

    //        ParticipantsDataType result = new ParticipantsDataType();
    //        CROZServiceReference.CROZWebServiceClient crozServiceClient = new CROZServiceReference.CROZWebServiceClient(EndpointConfigurationName.Value, WebServiceUrl.Value);
    //        CROZServiceReference.participant[] srvResult = crozServiceClient.searchByParticipant(argument.ParticipantCode, argument.ParticipantName, GetSecurityInfo(aditionalParameters));
    //        ObjectMapper<CROZServiceReference.participant[], ParticipantsDataType> mapper = CreateParticipantsMapper(accessMatrix);
    //        mapper.Map(srvResult, result);
    //        return
    //                SigningUtils.CreateAndSign(
    //                    argument,
    //                    result,
    //                    accessMatrix,
    //                    aditionalParameters
    //                );
    //    }
    //    catch (Exception ex)
    //    {
    //        LogError(aditionalParameters, ex, new { Guid = id });
    //        throw ex;
    //    }

    //}

    //private CROZServiceReference.property[] GetSecurityInfo(AdapterAdditionalParameters additionalParameters)
    //{
    //    List<property> properties = new List<property>();
    //    //properties.Add(new property() { name = "enCertSha1", Value = additionalParameters.ConsumerCertificateThumbprint });
    //    properties.Add(new property() { name = "enUserName", Value = "regix" });
    //    //properties.Add(new property() { name = "enRemoteAddr", Value = additionalParameters.ClientIPAddress });
    //    //properties.Add(new property() { name = "enPersonId", Value = additionalParameters.CitizenEGN });
    //    //properties.Add(new property() { name = "enCompanyId", Value = string.Format("{0} - {1}", additionalParameters.OrganizationEIK, additionalParameters.OrganizationUnit) });
    //    return properties.ToArray();
    //}

    //private ObjectMapper<CROZServiceReference.participant[], ParticipantsDataType> CreateParticipantsMapper(AccessMatrix accessMatrix)
    //{
    //    ObjectMapper<CROZServiceReference.participant[], ParticipantsDataType> mapper = new ObjectMapper<CROZServiceReference.participant[], ParticipantsDataType>(accessMatrix);
    //    mapper.AddCollectionMap<CROZServiceReference.participant[]>((o) => o.participantsList, p => p.ToArray<CROZServiceReference.participant>());
    //    mapper.AddPropertyMap((o) => o.participantsList[0].particip_id, (p) => p[0].particip_id);
    //    mapper.AddPropertyMap((o) => o.participantsList[0].particip_id_code, (p) => p[0].particip_id_code);
    //    mapper.AddObjectMap((o) => o.participantsList[0].name, (p) => p[0].name);
    //    mapper.AddPropertyMap((o) => o.participantsList[0].name.name1, (p) => p[0].name.name1);
    //    mapper.AddPropertyMap((o) => o.participantsList[0].name.name2, (p) => p[0].name.name2);
    //    mapper.AddPropertyMap((o) => o.participantsList[0].name.name3, (p) => p[0].name.name3);
    //    mapper.AddPropertyMap((o) => o.participantsList[0].name.company, (p) => p[0].name.company);
    //    mapper.AddPropertyMap((o) => o.participantsList[0].full_name, (p) => p[0].full_name);
    //    mapper.AddPropertyMap((o) => o.participantsList[0].city, (p) => p[0].city);
    //    mapper.AddPropertyMap((o) => o.participantsList[0].address, (p) => p[0].address);
    //    mapper.AddPropertyMap((o) => o.participantsList[0].zip, (p) => p[0].zip);
    //    return mapper;
    //}


    ////Извлича данни за вписванията по партида на определено лице
    //public CommonSignedResponse<ConsignmentInfoSearchType, ConsignmentDataType> GetConsignmentInfo(ConsignmentInfoSearchType argument, Common.ObjectMapping.AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
    //{
    //    Guid id = Guid.NewGuid();
    //    LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
    //    try
    //    {
    //        ConsignmentDataType result = new ConsignmentDataType();

    //        CROZServiceReference.CROZWebServiceClient crozServiceClient = new CROZServiceReference.CROZWebServiceClient(EndpointConfigurationName.Value, WebServiceUrl.Value);

    //        int participantID = argument.ParticipantID;
    //        string archiveLikeFilter = "ALL";
    //        string syncDate;
    //        int mode;
    //        CROZServiceReference.consignment srvResult = crozServiceClient.getConsignmentInfo(participantID, ref archiveLikeFilter, GetSecurityInfo(aditionalParameters), out syncDate, out mode);

    //        //ограничава по подадения период
    //        IFormatProvider provider = CultureInfo.InvariantCulture;
    //        var filteredconsignEntries = srvResult.consignEntries.Where(ce => ((DateTime.ParseExact(ce.reg_date, "dd.MM.yyyy", provider) >= argument.DateFrom)
    //                    && (DateTime.ParseExact(ce.reg_date, "dd.MM.yyyy", provider) <= argument.DateTo)));

    //        //var filteredconsignEntries = srvResult.consignEntries.Where(ce => ((DateTime.Parse(ce.reg_date) >= ConsignmentInfoSearchType.DateFrom)
    //        //            && (DateTime.Parse(ce.reg_date) <= ConsignmentInfoSearchType.DateTo)));

    //        srvResult.consignEntries = filteredconsignEntries.ToArray<CROZServiceReference.consignEntry>();
    //        ObjectMapper<CROZServiceReference.consignment, ConsignmentDataType> mapper = CreateConsignmentMapper(accessMatrix, syncDate, mode, archiveLikeFilter);
    //        mapper.Map(srvResult, result);

    //        return
    //                SigningUtils.CreateAndSign(
    //                    argument,
    //                    result,
    //                    accessMatrix,
    //                    aditionalParameters
    //                );
    //    }
    //    catch (Exception ex)
    //    {
    //        LogError(aditionalParameters, ex, new { Guid = id });
    //        throw ex;
    //    }
    //}

    //private ObjectMapper<CROZServiceReference.consignment, ConsignmentDataType> CreateConsignmentMapper(AccessMatrix accessMatrix, string syncDate, int mode, string archiveLikeFilter)
    //{
    //    ObjectMapper<CROZServiceReference.consignment, ConsignmentDataType> mapper = new ObjectMapper<CROZServiceReference.consignment, ConsignmentDataType>(accessMatrix);

    //    mapper.AddConstantMap(o => o.synchronizationDate, syncDate);
    //    mapper.AddConstantMap(o => o.mode, mode);
    //    mapper.AddConstantMap(o => o.synchronizationDate, syncDate);
    //    mapper.AddConstantMap(o => o.archiveLikeFilter, archiveLikeFilter);

    //    mapper.AddObjectMap((o) => o.consignment, c => c);
    //    mapper.AddPropertyMap((o) => o.consignment.consignment_number, (c) => c.consignment_number);
    //    mapper.AddCollectionMap<CROZServiceReference.consignment>((o) => o.consignment.consignmentParticipants, (c) => c.consignmentParticipants);
    //    mapper.AddPropertyMap((o) => o.consignment.consignmentParticipants[0].particip_id, (c) => c.consignmentParticipants[0].particip_id);
    //    mapper.AddPropertyMap((o) => o.consignment.consignmentParticipants[0].particip_id_code, (c) => c.consignmentParticipants[0].particip_id_code);
    //    mapper.AddObjectMap((o) => o.consignment.consignmentParticipants[0].name, (c) => c.consignmentParticipants[0].name);
    //    mapper.AddPropertyMap((o) => o.consignment.consignmentParticipants[0].name.name1, (c) => c.consignmentParticipants[0].name.name1);
    //    mapper.AddPropertyMap((o) => o.consignment.consignmentParticipants[0].name.name2, (c) => c.consignmentParticipants[0].name.name2);
    //    mapper.AddPropertyMap((o) => o.consignment.consignmentParticipants[0].name.name3, (c) => c.consignmentParticipants[0].name.name3);
    //    mapper.AddPropertyMap((o) => o.consignment.consignmentParticipants[0].name.company, (c) => c.consignmentParticipants[0].name.company);
    //    mapper.AddPropertyMap((o) => o.consignment.consignmentParticipants[0].full_name, (c) => c.consignmentParticipants[0].full_name);
    //    mapper.AddPropertyMap((o) => o.consignment.consignmentParticipants[0].city, (c) => c.consignmentParticipants[0].city);
    //    mapper.AddPropertyMap((o) => o.consignment.consignmentParticipants[0].address, (c) => c.consignmentParticipants[0].address);
    //    mapper.AddPropertyMap((o) => o.consignment.consignmentParticipants[0].zip, (c) => c.consignmentParticipants[0].zip);

    //    mapper.AddCollectionMap<CROZServiceReference.consignment>((o) => o.consignment.consignEntries, (c) => c.consignEntries);
    //    mapper.AddPropertyMap((o) => o.consignment.consignEntries[0].regId, (c) => c.consignEntries[0].regId);
    //    mapper.AddPropertyMap((o) => o.consignment.consignEntries[0].status, (c) => c.consignEntries[0].status);
    //    mapper.AddPropertyMap((o) => o.consignment.consignEntries[0].description, (c) => c.consignEntries[0].description);
    //    mapper.AddPropertyMap((o) => o.consignment.consignEntries[0].reg_date, (c) => c.consignEntries[0].reg_date);
    //    mapper.AddPropertyMap((o) => o.consignment.consignEntries[0].reg_time, (c) => c.consignEntries[0].reg_time);
    //    mapper.AddPropertyMap((o) => o.consignment.consignEntries[0].page_numbers, (c) => c.consignEntries[0].page_numbers);
    //    mapper.AddPropertyMap((o) => o.consignment.consignEntries[0].expire_date, (c) => c.consignEntries[0].expire_date);
    //    mapper.AddPropertyMap((o) => o.consignment.consignEntries[0].scanned, (c) => c.consignEntries[0].scanned);
    //    mapper.AddCollectionMap<CROZServiceReference.consignEntry>((o) => o.consignment.consignEntries[0].creditors, (c) => c.creditors);
    //    mapper.AddObjectMap((o) => o.consignment.consignEntries[0].creditors[0].participant, (c) => c.consignEntries[0].creditors[0].participant);
    //    mapper.AddPropertyMap((o) => o.consignment.consignEntries[0].creditors[0].participant.particip_id, (c) => c.consignEntries[0].creditors[0].participant.particip_id);
    //    mapper.AddPropertyMap((o) => o.consignment.consignEntries[0].creditors[0].participant.particip_id_code, (c) => c.consignEntries[0].creditors[0].participant.particip_id_code);
    //    mapper.AddObjectMap((o) => o.consignment.consignEntries[0].creditors[0].participant.name, (c) => c.consignEntries[0].creditors[0].participant.name);
    //    mapper.AddPropertyMap((o) => o.consignment.consignEntries[0].creditors[0].participant.name.name1, (c) => c.consignEntries[0].creditors[0].participant.name.name1);
    //    mapper.AddPropertyMap((o) => o.consignment.consignEntries[0].creditors[0].participant.name.name2, (c) => c.consignEntries[0].creditors[0].participant.name.name2);
    //    mapper.AddPropertyMap((o) => o.consignment.consignEntries[0].creditors[0].participant.name.name3, (c) => c.consignEntries[0].creditors[0].participant.name.name3);
    //    mapper.AddPropertyMap((o) => o.consignment.consignEntries[0].creditors[0].participant.name.company, (c) => c.consignEntries[0].creditors[0].participant.name.company);
    //    mapper.AddPropertyMap((o) => o.consignment.consignEntries[0].creditors[0].participant.full_name, (c) => c.consignEntries[0].creditors[0].participant.full_name);
    //    mapper.AddPropertyMap((o) => o.consignment.consignEntries[0].creditors[0].participant.city, (c) => c.consignEntries[0].creditors[0].participant.city);
    //    mapper.AddPropertyMap((o) => o.consignment.consignEntries[0].creditors[0].participant.address, (c) => c.consignEntries[0].creditors[0].participant.address);
    //    mapper.AddPropertyMap((o) => o.consignment.consignEntries[0].creditors[0].participant.zip, (c) => c.consignEntries[0].creditors[0].participant.zip);
    //    //mapper.AddCollectionMap<CROZServiceReference.consignCreditor>((o) => o.consignment.consignEntries[0].creditors[0].proceedexecutionDates, (c) => c.proceedexecutionDates);
    //    //mapper.AddCollectionMap<CROZServiceReference.consignCreditor>((o) => o.consignment.consignEntries[0].creditors[0].leftExecutionDates, (c) => c.leftExecutionDates);
    //    //mapper.AddCollectionMap<CROZServiceReference.consignCreditor>((o) => o.consignment.consignEntries[0].creditors[0].eraseExecutionDates, (c) => c.eraseExecutionDates);
    //    mapper.AddFunctionMap<CROZServiceReference.consignCreditor, List<string>>((o) => o.consignment.consignEntries[0].creditors[0].proceedexecutionDates, d => (d.eraseExecutionDates != null ? d.eraseExecutionDates.ToList<string>() : new List<string>()));
    //    mapper.AddFunctionMap<CROZServiceReference.consignCreditor, List<string>>((o) => o.consignment.consignEntries[0].creditors[0].leftExecutionDates, d => (d.leftExecutionDates != null ? d.leftExecutionDates.ToList<string>() : new List<string>()));
    //    mapper.AddFunctionMap<CROZServiceReference.consignCreditor, List<string>>((o) => o.consignment.consignEntries[0].creditors[0].eraseExecutionDates, d => (d.eraseExecutionDates != null ? d.eraseExecutionDates.ToList<string>() : new List<string>()));

    //    mapper.AddPropertyMap((o) => o.consignment.consignEntries[0].rejected, (c) => c.consignEntries[0].rejected);
    //    mapper.AddPropertyMap((o) => o.consignment.consignEntries[0].archived, (c) => c.consignEntries[0].archived);
    //    mapper.AddCollectionMap<CROZServiceReference.consignEntry>((o) => o.consignment.consignEntries[0].oa_pole17, (c) => c.oa_pole17);
    //    mapper.AddPropertyMap((o) => o.consignment.consignEntries[0].oa_pole17[0].regId, (c) => c.consignEntries[0].oa_pole17[0].regId);
    //    mapper.AddPropertyMap((o) => o.consignment.consignEntries[0].oa_pole17[0].sheet, (c) => c.consignEntries[0].oa_pole17[0].sheet);
    //    mapper.AddPropertyMap((o) => o.consignment.consignEntries[0].oa_pole17[0].sheet_type, (c) => c.consignEntries[0].oa_pole17[0].sheet_type);
    //    // mapper.AddCollectionMap<CROZServiceReference.OA>((o) => o.consignment.consignEntries[0].oa_pole17[0].img_side, (c) => c.img_side);

    //    //намиране на картинките на поле 17
    //    mapper.AddFunctionMap<CROZServiceReference.OA, byte[]>((o) => o.consignment.consignEntries[0].oa_pole17[0].imgFace, o => FindImage(o));
    //    mapper.AddFunctionMap<CROZServiceReference.OA, string>((o) => o.consignment.consignEntries[0].oa_pole17[0].imgFaceType, o => FindImageType(o));
    //    //IMAGES        
    //    mapper.AddFunctionMap<CROZServiceReference.OA, List<string>>((o) => o.consignment.consignEntries[0].oa_pole17[0].img_side, e => (e.img_side != null) ? e.img_side.ToList<string>() : new List<string>());


    //    //mapper.AddCollectionMap<CROZServiceReference.consignEntry>((o) => o.consignment.consignEntries[0].newManagerDates, (c) => c.newManagerDates);
    //    mapper.AddFunctionMap<CROZServiceReference.consignEntry, List<string>>((o) => o.consignment.consignEntries[0].newManagerDates, d => (d.newManagerDates != null ? d.newManagerDates.ToList<string>() : new List<string>()));
    //    mapper.AddPropertyMap((o) => o.consignment.consignEntries[0].amd_numbers, (c) => c.consignEntries[0].amd_numbers);
    //    mapper.AddPropertyMap((o) => o.consignment.consignEntries[0].opis_header, (c) => c.consignEntries[0].opis_header);
    //    mapper.AddPropertyMap((o) => o.consignment.consignEntries[0].retId, (c) => c.consignEntries[0].retId);
    //    mapper.AddPropertyMap((o) => o.consignment.consignEntries[0].pledgeOnClaim, (c) => c.consignEntries[0].pledgeOnClaim);
    //    //mapper.AddObjectMap((o) => o.consignment.consignEntries[0].distrainSecuredClaims, (c) => c.consignEntries[0].distrainSecuredClaims);
    //    mapper.AddFunctionMap<CROZServiceReference.consignEntry, List<string>>((o) => o.consignment.consignEntries[0].distrainSecuredClaims, d => (d.distrainSecuredClaims != null) ? d.distrainSecuredClaims.ToList<string>() : new List<string>());

    //    return mapper;
    //}

    //public CommonSignedResponse<DealInfoSearchType, DealInfoDataType> GetDealInfo(DealInfoSearchType argument, Common.ObjectMapping.AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
    //{
    //    Guid id = Guid.NewGuid();
    //    LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
    //    try
    //    {
    //        DealInfoDataType result = new DealInfoDataType();
    //        CROZServiceReference.CROZWebServiceClient crozServiceClient = new CROZServiceReference.CROZWebServiceClient(EndpointConfigurationName.Value, WebServiceUrl.Value);
    //        string isOAIncluded = "yes";
    //        string archiveLikeFilter = "ALL";
    //        string syncDate;
    //        int mode;

    //        CROZServiceReference.deal srvResult = crozServiceClient.getDealInfo(argument.RegEntryID, ref isOAIncluded, ref archiveLikeFilter, GetSecurityInfo(aditionalParameters), out syncDate, out mode);
    //        ObjectMapper<CROZServiceReference.deal, DealInfoDataType> mapper = CreateDealInfoMapper(accessMatrix, syncDate, mode, isOAIncluded, archiveLikeFilter);
    //        mapper.Map(srvResult, result);

    //        return
    //                SigningUtils.CreateAndSign(
    //                    argument,
    //                    result,
    //                    accessMatrix,
    //                    aditionalParameters
    //                );
    //    }
    //    catch (Exception ex)
    //    {
    //        LogError(aditionalParameters, ex, new { Guid = id });
    //        throw ex;
    //    }
    //}

    //private ObjectMapper<CROZServiceReference.deal, DealInfoDataType> CreateDealInfoMapper(AccessMatrix accessMatrix, string syncDate, int mode, string isOAIncluded, string archiveLikeFilter)
    //{
    //    ObjectMapper<CROZServiceReference.deal, DealInfoDataType> mapper = new ObjectMapper<CROZServiceReference.deal, DealInfoDataType>(accessMatrix);

    //    mapper.AddConstantMap(o => o.synchronizationDate, syncDate);
    //    mapper.AddConstantMap(o => o.mode, mode);
    //    mapper.AddConstantMap(o => o.isOAIncluded, isOAIncluded);
    //    mapper.AddConstantMap(o => o.archiveLikeFilter, archiveLikeFilter);

    //    mapper.AddObjectMap((o) => o.deal, d => d);
    //    mapper.AddObjectMap((o) => o.deal.entry, d => d.entry);
    //    mapper.AddPropertyMap((o) => o.deal.entry.regId, d => d.entry.regId);
    //    mapper.AddPropertyMap((o) => o.deal.entry.status, d => d.entry.status);
    //    mapper.AddPropertyMap((o) => o.deal.entry.description, d => d.entry.description);
    //    mapper.AddPropertyMap((o) => o.deal.entry.reg_date, d => d.entry.reg_date);
    //    mapper.AddPropertyMap((o) => o.deal.entry.reg_time, d => d.entry.reg_time);
    //    mapper.AddPropertyMap((o) => o.deal.entry.page_numbers, d => d.entry.page_numbers);
    //    mapper.AddPropertyMap((o) => o.deal.entry.expire_date, d => d.entry.expire_date);
    //    mapper.AddPropertyMap((o) => o.deal.entry.scanned, d => d.entry.scanned);
    //    mapper.AddCollectionMap<CROZServiceReference.entry>((o) => o.deal.entry.creditors, (e) => e.creditors);
    //    mapper.AddPropertyMap((o) => o.deal.entry.creditors[0].particip_id, d => d.entry.creditors[0].particip_id);
    //    mapper.AddPropertyMap((o) => o.deal.entry.creditors[0].particip_id_code, d => d.entry.creditors[0].particip_id_code);
    //    mapper.AddObjectMap((o) => o.deal.entry.creditors[0].name, d => d.entry.creditors[0].name);
    //    mapper.AddPropertyMap((o) => o.deal.entry.creditors[0].name.name1, d => d.entry.creditors[0].name.name1);
    //    mapper.AddPropertyMap((o) => o.deal.entry.creditors[0].name.name2, d => d.entry.creditors[0].name.name2);
    //    mapper.AddPropertyMap((o) => o.deal.entry.creditors[0].name.name3, d => d.entry.creditors[0].name.name3);
    //    mapper.AddPropertyMap((o) => o.deal.entry.creditors[0].name.company, d => d.entry.creditors[0].name.company);
    //    mapper.AddPropertyMap((o) => o.deal.entry.creditors[0].full_name, d => d.entry.creditors[0].full_name);
    //    mapper.AddPropertyMap((o) => o.deal.entry.creditors[0].city, d => d.entry.creditors[0].city);
    //    mapper.AddPropertyMap((o) => o.deal.entry.creditors[0].address, d => d.entry.creditors[0].address);
    //    mapper.AddPropertyMap((o) => o.deal.entry.creditors[0].zip, d => d.entry.creditors[0].zip);
    //    mapper.AddCollectionMap<CROZServiceReference.entry>((o) => o.deal.entry.debtors, (d) => d.debtors);
    //    mapper.AddPropertyMap((o) => o.deal.entry.debtors[0].particip_id, d => d.entry.debtors[0].particip_id);
    //    mapper.AddPropertyMap((o) => o.deal.entry.debtors[0].particip_id_code, d => d.entry.debtors[0].particip_id_code);
    //    mapper.AddObjectMap((o) => o.deal.entry.debtors[0].name, d => d.entry.debtors[0].name);
    //    mapper.AddPropertyMap((o) => o.deal.entry.debtors[0].name.name1, d => d.entry.debtors[0].name.name1);
    //    mapper.AddPropertyMap((o) => o.deal.entry.debtors[0].name.name2, d => d.entry.debtors[0].name.name2);
    //    mapper.AddPropertyMap((o) => o.deal.entry.debtors[0].name.name3, d => d.entry.debtors[0].name.name3);
    //    mapper.AddPropertyMap((o) => o.deal.entry.debtors[0].name.company, d => d.entry.debtors[0].name.company);
    //    mapper.AddPropertyMap((o) => o.deal.entry.debtors[0].full_name, d => d.entry.debtors[0].full_name);
    //    mapper.AddPropertyMap((o) => o.deal.entry.debtors[0].city, d => d.entry.debtors[0].city);
    //    mapper.AddPropertyMap((o) => o.deal.entry.debtors[0].address, d => d.entry.debtors[0].address);
    //    mapper.AddPropertyMap((o) => o.deal.entry.debtors[0].zip, d => d.entry.debtors[0].zip);
    //    mapper.AddPropertyMap((o) => o.deal.entry.rejected, d => d.entry.rejected);
    //    mapper.AddPropertyMap((o) => o.deal.entry.archived, d => d.entry.archived);
    //    mapper.AddCollectionMap<CROZServiceReference.entry>((o) => o.deal.entry.oa_pole17, (d) => d.oa_pole17);
    //    mapper.AddPropertyMap((o) => o.deal.entry.oa_pole17[0].regId, d => d.entry.oa_pole17[0].regId);
    //    mapper.AddPropertyMap((o) => o.deal.entry.oa_pole17[0].sheet, d => d.entry.oa_pole17[0].sheet);
    //    mapper.AddPropertyMap((o) => o.deal.entry.oa_pole17[0].sheet_type, d => d.entry.oa_pole17[0].sheet_type);


    //    //намиране на картинките на Оптичния архив
    //    mapper.AddFunctionMap<CROZServiceReference.OA, byte[]>((o) => o.deal.entry.oa_pole17[0].imgFace, o => FindImage(o));
    //    mapper.AddFunctionMap<CROZServiceReference.OA, string>((o) => o.deal.entry.oa_pole17[0].imgFaceType, o => FindImageType(o));
    //    // IMAGES
    //    mapper.AddFunctionMap<CROZServiceReference.OA, List<string>>((o) => o.deal.entry.oa_pole17[0].img_side, e => (e.img_side != null) ? e.img_side.ToList<string>() : new List<string>());


    //    mapper.AddCollectionMap<CROZServiceReference.entry>((o) => o.deal.entry.oa_extraPages, (d) => d.oa_extraPages);
    //    mapper.AddPropertyMap((o) => o.deal.entry.oa_extraPages[0].regId, d => d.entry.oa_extraPages[0].regId);
    //    mapper.AddPropertyMap((o) => o.deal.entry.oa_extraPages[0].sheet, d => d.entry.oa_extraPages[0].sheet);
    //    mapper.AddPropertyMap((o) => o.deal.entry.oa_extraPages[0].sheet_type, d => d.entry.oa_extraPages[0].sheet_type);


    //    //намиране на картинките на Оптичния архив
    //    //mapper.AddFunctionMap<CROZServiceReference.OA, byte[]>((o) => o.deal.entry.oa_extraPages[0].imgFace, o => FindImage(o));
    //    //mapper.AddFunctionMap<CROZServiceReference.OA, string>((o) => o.deal.entry.oa_extraPages[0].imgFaceType, o => FindImageType(o));
    //    //IMAGES
    //    mapper.AddFunctionMap<CROZServiceReference.OA, List<string>>((o) => o.deal.entry.oa_extraPages[0].img_side, e => (e.img_side != null) ? e.img_side.ToList<string>() : new List<string>());



    //    mapper.AddPropertyMap((o) => o.deal.entry.parent, d => d.entry.parent);
    //    mapper.AddPropertyMap((o) => o.deal.entry.opis_header, d => d.entry.opis_header);
    //    mapper.AddPropertyMap((o) => o.deal.entry.retId, d => d.entry.retId);
    //    mapper.AddPropertyMap((o) => o.deal.entry.pledgeOnClaim, d => d.entry.pledgeOnClaim);
    //    mapper.AddFunctionMap<CROZServiceReference.entry, List<string>>((o) => o.deal.entry.distrainSecuredClaims, d => (d.distrainSecuredClaims != null ? d.distrainSecuredClaims.ToList<string>() : new List<string>()));
    //    mapper.AddCollectionMap<CROZServiceReference.deal>((o) => o.deal.amendments, d => d.amendments);
    //    mapper.AddObjectMap((o) => o.deal.amendments[0].entry, d => d.amendments[0].entry);
    //    mapper.AddPropertyMap((o) => o.deal.amendments[0].entry.regId, d => d.amendments[0].entry.regId);
    //    mapper.AddPropertyMap((o) => o.deal.amendments[0].entry.status, d => d.amendments[0].entry.status);
    //    mapper.AddPropertyMap((o) => o.deal.amendments[0].entry.description, d => d.amendments[0].entry.description);
    //    mapper.AddPropertyMap((o) => o.deal.amendments[0].entry.reg_date, d => d.amendments[0].entry.reg_date);
    //    mapper.AddPropertyMap((o) => o.deal.amendments[0].entry.reg_time, d => d.amendments[0].entry.reg_time);
    //    mapper.AddPropertyMap((o) => o.deal.amendments[0].entry.page_numbers, d => d.amendments[0].entry.page_numbers);
    //    mapper.AddPropertyMap((o) => o.deal.amendments[0].entry.expire_date, d => d.amendments[0].entry.expire_date);
    //    mapper.AddPropertyMap((o) => o.deal.amendments[0].entry.scanned, d => d.amendments[0].entry.scanned);
    //    mapper.AddCollectionMap<CROZServiceReference.entry>((o) => o.deal.amendments[0].entry.creditors, (d) => d.creditors);
    //    mapper.AddPropertyMap((o) => o.deal.amendments[0].entry.creditors[0].particip_id, d => d.amendments[0].entry.creditors[0].particip_id);
    //    mapper.AddPropertyMap((o) => o.deal.amendments[0].entry.creditors[0].particip_id_code, d => d.amendments[0].entry.creditors[0].particip_id_code);
    //    mapper.AddObjectMap((o) => o.deal.amendments[0].entry.creditors[0].name, d => d.amendments[0].entry.creditors[0].name);
    //    mapper.AddPropertyMap((o) => o.deal.amendments[0].entry.creditors[0].name.name1, d => d.amendments[0].entry.creditors[0].name.name1);
    //    mapper.AddPropertyMap((o) => o.deal.amendments[0].entry.creditors[0].name.name2, d => d.amendments[0].entry.creditors[0].name.name2);
    //    mapper.AddPropertyMap((o) => o.deal.amendments[0].entry.creditors[0].name.name3, d => d.amendments[0].entry.creditors[0].name.name3);
    //    mapper.AddPropertyMap((o) => o.deal.amendments[0].entry.creditors[0].name.company, d => d.amendments[0].entry.creditors[0].name.company);
    //    mapper.AddPropertyMap((o) => o.deal.amendments[0].entry.creditors[0].full_name, d => d.amendments[0].entry.creditors[0].full_name);
    //    mapper.AddPropertyMap((o) => o.deal.amendments[0].entry.creditors[0].city, d => d.amendments[0].entry.creditors[0].city);
    //    mapper.AddPropertyMap((o) => o.deal.amendments[0].entry.creditors[0].address, d => d.amendments[0].entry.creditors[0].address);
    //    mapper.AddPropertyMap((o) => o.deal.amendments[0].entry.creditors[0].zip, d => d.amendments[0].entry.creditors[0].zip);
    //    mapper.AddCollectionMap<CROZServiceReference.entry>((o) => o.deal.amendments[0].entry.debtors, (d) => d.debtors);
    //    mapper.AddPropertyMap((o) => o.deal.amendments[0].entry.debtors[0].particip_id, d => d.amendments[0].entry.debtors[0].particip_id);
    //    mapper.AddPropertyMap((o) => o.deal.amendments[0].entry.debtors[0].particip_id_code, d => d.amendments[0].entry.debtors[0].particip_id_code);
    //    mapper.AddObjectMap((o) => o.deal.amendments[0].entry.debtors[0].name, d => d.amendments[0].entry.debtors[0].name);
    //    mapper.AddPropertyMap((o) => o.deal.amendments[0].entry.debtors[0].name.name1, d => d.amendments[0].entry.debtors[0].name.name1);
    //    mapper.AddPropertyMap((o) => o.deal.amendments[0].entry.debtors[0].name.name2, d => d.amendments[0].entry.debtors[0].name.name2);
    //    mapper.AddPropertyMap((o) => o.deal.amendments[0].entry.debtors[0].name.name3, d => d.amendments[0].entry.debtors[0].name.name3);
    //    mapper.AddPropertyMap((o) => o.deal.amendments[0].entry.debtors[0].name.company, d => d.amendments[0].entry.debtors[0].name.company);
    //    mapper.AddPropertyMap((o) => o.deal.amendments[0].entry.debtors[0].full_name, d => d.amendments[0].entry.debtors[0].full_name);
    //    mapper.AddPropertyMap((o) => o.deal.amendments[0].entry.debtors[0].city, d => d.amendments[0].entry.debtors[0].city);
    //    mapper.AddPropertyMap((o) => o.deal.amendments[0].entry.debtors[0].address, d => d.amendments[0].entry.debtors[0].address);
    //    mapper.AddPropertyMap((o) => o.deal.amendments[0].entry.debtors[0].zip, d => d.amendments[0].entry.debtors[0].zip);
    //    mapper.AddPropertyMap((o) => o.deal.amendments[0].entry.rejected, d => d.amendments[0].entry.rejected);
    //    mapper.AddPropertyMap((o) => o.deal.amendments[0].entry.archived, d => d.amendments[0].entry.archived);
    //    mapper.AddCollectionMap<CROZServiceReference.entry>((o) => o.deal.amendments[0].entry.oa_pole17, (d) => d.oa_pole17);
    //    mapper.AddPropertyMap((o) => o.deal.amendments[0].entry.oa_pole17[0].regId, d => d.amendments[0].entry.oa_pole17[0].regId);
    //    mapper.AddPropertyMap((o) => o.deal.amendments[0].entry.oa_pole17[0].sheet, d => d.amendments[0].entry.oa_pole17[0].sheet);
    //    mapper.AddPropertyMap((o) => o.deal.amendments[0].entry.oa_pole17[0].sheet_type, d => d.amendments[0].entry.oa_pole17[0].sheet_type);

    //    //намиране на картинките на поле 17
    //    mapper.AddFunctionMap<CROZServiceReference.OA, byte[]>((o) => o.deal.amendments[0].entry.oa_pole17[0].imgFace, o => FindImage(o));
    //    mapper.AddFunctionMap<CROZServiceReference.OA, string>((o) => o.deal.amendments[0].entry.oa_pole17[0].imgFaceType, o => FindImageType(o));


    //    mapper.AddFunctionMap<CROZServiceReference.OA, List<string>>((o) => o.deal.amendments[0].entry.oa_pole17[0].img_side, e => (e.img_side != null) ? e.img_side.ToList<string>() : new List<string>());

    //    mapper.AddCollectionMap<CROZServiceReference.entry>((o) => o.deal.amendments[0].entry.oa_extraPages, (d) => d.oa_extraPages);
    //    mapper.AddPropertyMap((o) => o.deal.amendments[0].entry.oa_extraPages[0].regId, d => d.amendments[0].entry.oa_extraPages[0].regId);
    //    mapper.AddPropertyMap((o) => o.deal.amendments[0].entry.oa_extraPages[0].sheet, d => d.amendments[0].entry.oa_extraPages[0].sheet);
    //    mapper.AddPropertyMap((o) => o.deal.amendments[0].entry.oa_extraPages[0].sheet_type, d => d.amendments[0].entry.oa_extraPages[0].sheet_type);

    //    //намиране на картинките на Оптичния архив
    //    //mapper.AddFunctionMap<CROZServiceReference.OA, byte[]>((o) => o.deal.amendments[0].entry.oa_extraPages[0].imgFace, o => FindImage(o));
    //    //mapper.AddFunctionMap<CROZServiceReference.OA, string>((o) => o.deal.amendments[0].entry.oa_extraPages[0].imgFaceType, o => FindImageType(o));

    //    //IMAGES        
    //    mapper.AddFunctionMap<CROZServiceReference.OA, List<string>>((o) => o.deal.amendments[0].entry.oa_extraPages[0].img_side, e => (e.img_side != null) ? e.img_side.ToList<string>() : new List<string>());

    //    mapper.AddPropertyMap((o) => o.deal.amendments[0].entry.parent, d => d.amendments[0].entry.parent);
    //    mapper.AddPropertyMap((o) => o.deal.amendments[0].entry.opis_header, d => d.amendments[0].entry.opis_header);
    //    mapper.AddPropertyMap((o) => o.deal.amendments[0].entry.retId, d => d.amendments[0].entry.retId);
    //    mapper.AddPropertyMap((o) => o.deal.amendments[0].entry.pledgeOnClaim, d => d.amendments[0].entry.pledgeOnClaim);
    //    mapper.AddFunctionMap<CROZServiceReference.entry, List<string>>((o) => o.deal.amendments[0].entry.distrainSecuredClaims, e => (e.distrainSecuredClaims != null) ? e.distrainSecuredClaims.ToList<string>() : new List<string>());
    //    mapper.AddObjectMap((o) => o.deal.amendments[0].changeType, d => d.amendments[0].changeType);
    //    mapper.AddPropertyMap((o) => o.deal.amendments[0].changeType.prop1, d => d.amendments[0].changeType.prop1);
    //    mapper.AddPropertyMap((o) => o.deal.amendments[0].changeType.prop1, d => d.amendments[0].changeType.prop2);
    //    mapper.AddPropertyMap((o) => o.deal.amendments[0].changeType.prop1, d => d.amendments[0].changeType.prop3);

    //    return mapper;
    //}

    //// намиране на файлове от оптичен архив 
    //private byte[] FindImage(CROZServiceReference.OA oa)
    //{
    //    byte[] result = null;

    //    if (oa.regId != null && oa.sheet != null && oa.sheet_type != null)
    //    {
    //        string url = String.Format("{0}?regId={1}&sheet={2}&sheetType={3}&imgSide={4}&imgType={5}",
    //            ImageProxyServletUrl.Value, oa.regId, oa.sheet, oa.sheet_type, "FACE", ImageFormat.Value);

    //        WebRequest request = WebRequest.Create(url);
    //        WebResponse response = request.GetResponse();

    //        using (Stream s = response.GetResponseStream())
    //        {
    //            int count;
    //            Byte[] buf = new byte[8192];
    //            StringBuilder sb = new StringBuilder();
    //            do
    //            {
    //                count = s.Read(buf, 0, buf.Length);
    //                if (count != 0)
    //                {
    //                    sb.Append(Encoding.UTF8.GetString(buf, 0, count));
    //                }
    //            } while (count > 0);

    //            result = System.Text.Encoding.UTF8.GetBytes(sb.ToString());
    //        }

    //        response.Close();

    //    }

    //    return result;
    //}

    //// намиране на типа файлове от оптичен архив 
    //// За сега типа се определя със второ извикване на сървлета. !!!
    //private string FindImageType(CROZServiceReference.OA oa)
    //{
    //    string result = null;

    //    if (oa.regId != null && oa.sheet != null && oa.sheet_type != null)
    //    {
    //        string url = String.Format("{0}?regId={1}&sheet={2}&sheetType={3}&imgSide={4}&imgType={5}",
    //            ImageProxyServletUrl.Value, oa.regId, oa.sheet, oa.sheet_type, "FACE", ImageFormat.Value);

    //        WebRequest request = WebRequest.Create(url);
    //        WebResponse response = request.GetResponse();
    //        result = response.ContentType;
    //        response.Close();
    //    }

    //    return result;
    //}



    //}
}
