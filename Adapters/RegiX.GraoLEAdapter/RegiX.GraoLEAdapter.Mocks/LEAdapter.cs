namespace TechnoLogica.RegiX.GraoLEAdapter.AdapterService
{
    //public class LEAdapter : InformixAdapterService.InformixBaseAdapterService, ILEAdapter, IAdapterService
    //{

    //    [Export(typeof(ParameterInfo))]
    //    public static ParameterInfo<string> ConnectionString =
    //        new ParameterInfo<string>("Database=grao;Host=egov;Server=;Service=25852;Protocol=onsoctcp;UID=informix;Password=;DB_LOCALE=en_US.57372")
    //        {
    //            Key = Constants.ConnectionStringParameterKeyName,
    //            Description = "Connection string for Informix",
    //            OwnerAssembly = typeof(LEAdapter).Assembly
    //        };

    //    //[Export(typeof(HealthInfo))]
    //    //public static HealthInfoWithFunction CheckDBConnection =
    //    //    new HealthInfoWithFunction()
    //    //    {
    //    //        Key = "CheckDBConnection",
    //    //        Name = "Проверява връзката към базата",
    //    //        Description = "Проверява връзката към базата",
    //    //        CheckFunction =
    //    //        () =>
    //    //        {
    //    //            using (IfxConnection connection = new IfxConnection(ConnectionString.Value))
    //    //            {
    //    //                connection.Open();
    //    //                return "LE Connection - OK";
    //    //            }
    //    //        }
    //    //    };

    //    [Export(typeof(ParameterInfo))]
    //    public static ParameterInfo<string> SchemaName =
    //        new ParameterInfo<string>("grao")
    //        {
    //            Key = "SchemaName",
    //            Description = "Name of the schema in database",
    //            OwnerAssembly = typeof(LEAdapter).Assembly
    //        };

    //    public CommonSignedResponse<LocationsRequestType, LocationsResponseType> LocationsSearch(
    //        LocationsRequestType argument,
    //        AccessMatrix accessMatrix, 
    //        AdapterAdditionalParameters aditionalParameters)
    //    {
    //        Guid id = Guid.NewGuid();
    //        LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
    //        try
    //        {
    //            LocationsResponseType result = new LocationsResponseType();
    //            if (argument.StartDate.Equals(new DateTime(1900, 1, 1)))
    //            {
    //                result = (LocationsResponseType)FileUtils.ReadXml("\\XMLData\\LocationsResponse.xml", typeof(LocationsResponseType));
    //            }
    //            else
    //            {
    //                result = (LocationsResponseType)FileUtils.ReadXml("\\XMLData\\LocationsResponse2.xml", typeof(LocationsResponseType));
    //            }
    //            return
    //                SigningUtils.CreateAndSign(
    //                argument,
    //                result,
    //                accessMatrix,
    //                aditionalParameters
    //                );
    //        }
    //        catch (Exception ex)
    //        {
    //            LogError(aditionalParameters, ex, new { Guid = id });
    //            throw ex;
    //        }
    //    }
    //}
}
