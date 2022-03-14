namespace TechnoLogica.RegiX.IAMASeafarersAdapter.AdapterService
{
    //public class SeafarersAdapter : WebServiceAdapterService.SoapServiceBaseAdapterService, ISeafarersAdapter, IAdapterService
    //{

    //    [Export(typeof(ParameterInfo))]
    //    public static ParameterInfo<string> WebServiceUrl =
    //        new ParameterInfo<string>("http://egov.ad.tlogica.com/MockRegisters/IAMAVessels/VesselsService.asmx")
    //        {
    //            Key = Constants.WebServiceUrlParameterKeyName,
    //            Description = "Connection String for SOAP Web Service",
    //            OwnerAssembly = typeof(SeafarersAdapter).Assembly
    //        };

    //    [Export(typeof(ParameterInfo))]
    //    public static ParameterInfo<string> ServiceUrl =
    //        new ParameterInfo<string>("http://egov.ad.tlogica.com/MockRegisters/IAMAVessels/VesselsService.asmx")
    //        {
    //            Key = "ServiceUrl",
    //            Description = "SeamanCertificatesService Web Service Url",
    //            OwnerAssembly = typeof(SeafarersAdapter).Assembly
    //        };

    //    //public override ConnectionStatusInfo CheckRegisterConnection()
    //    //{
    //    //    return new ConnectionStatusInfo()
    //    //    {
    //    //        Description = "Connection is OK!",
    //    //        status = ConnectionStatus.OK
    //    //    };
    //    //}

    //    private static ObjectMapper<SeamanCertificates, SeafarersLicensesResponseType> CreateMapper(AccessMatrix accessMatrix)
    //    {
    //        ObjectMapper<SeamanCertificates, SeafarersLicensesResponseType> mapper = new ObjectMapper<SeamanCertificates, SeafarersLicensesResponseType>(accessMatrix);

    //        mapper.AddPropertyMap((o) => o.EGN, (c) => c.EGN);

    //        mapper.AddPropertyMap((o) => o.Name, (c) => c.Name);
    //        mapper.AddPropertyMap((o) => o.Surname, (c) => c.Surname);
    //        mapper.AddPropertyMap((o) => o.FamilyName, (c) => c.FamilyName);

    //        mapper.AddCollectionMap<SeamanCertificates>((o) => o.Certificates, c => c.Certificates);
    //        mapper.AddPropertyMap((o) => o.Certificates[0].CertificateType, (c) => c.Certificates[0].CertificateType);
    //        mapper.AddPropertyMap((o) => o.Certificates[0].Id, (c) => c.Certificates[0].Id);
    //        mapper.AddPropertyMap((o) => o.Certificates[0].IssueDate, (c) => c.Certificates[0].IssueDate);
    //        mapper.AddPropertyMap((o) => o.Certificates[0].UniqueNumber, (c) => c.Certificates[0].UniqueNumber);
    //        mapper.AddPropertyMap((o) => o.Certificates[0].ValidDate, (c) => c.Certificates[0].ValidDate);
    //        mapper.AddFunctionMap<TechnoLogica.RegiX.IAMASeafarersAdapter.SeamanCertificatesService.Certificate, List<string>>((o) => o.Certificates[0].Duty, (c) => new List<string>(c.Duty));
    //        mapper.AddFunctionMap<TechnoLogica.RegiX.IAMASeafarersAdapter.SeamanCertificatesService.Certificate, List<string>>((o) => o.Certificates[0].Qualification, (c) => new List<string>(c.Qualification));

    //        return mapper;
    //    }

    //    public CommonSignedResponse<SeafarersLicensesRequestType, SeafarersLicensesResponseType> SeafarersLicensesSearch(SeafarersLicensesRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters)
    //    {
    //        Guid id = Guid.NewGuid();
    //        LogData(additionalParameters, new { Request = argument.Serialize(), Guid = id });
    //        try
    //        {
    //            VesselsServiceSoapClient serviceClient = new VesselsServiceSoapClient("SeamanCertificatesServiceEndpoint", ServiceUrl.Value);
    //            SeamanCertificates serviceResult = serviceClient.GetCertificatesByEGN(argument.EGN);

    //            ObjectMapper<SeamanCertificates, SeafarersLicensesResponseType> mapper = CreateMapper(accessMatrix);
    //            SeafarersLicensesResponseType searchResults = new SeafarersLicensesResponseType();
    //            mapper.Map(serviceResult, searchResults);
    //            return SigningUtils.CreateAndSign(argument,
    //                searchResults,
    //                accessMatrix,
    //                additionalParameters
    //                );
    //        }
    //        catch (Exception ex)
    //        {
    //            LogError(additionalParameters, ex, new { Guid = id });
    //            throw ex;
    //        }
    //    }
    //}
}